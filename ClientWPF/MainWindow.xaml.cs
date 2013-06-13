using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageTransfertServiceRef.ImageTransfertClient imageTransfertService;
        ImageTransfertServiceRef.UserData userInf;

        private ImageCollection imageCollection1;
        private ImageCollection imageCollection2;

        public MainWindow()
        {
            imageTransfertService = new ImageTransfertServiceRef.ImageTransfertClient();
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayLoginScreen();
            loadFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            loadAlbums();
            
        }

        private void loadAlbum(String albumid)
        {
            imageCollection1 = new ImageCollection();
            imageCollection1.Add(new ImageObjet("celestial",
            lireFichier(@"D:\Pictures\boobsncat2.jpg")));
            imageCollection1.Add(new ImageObjet("pearlscale",
            lireFichier(@"D:\Pictures\boobsncat.jpg")));

            // On lie la collectionau ObjectDataProvider déclaré dans le fichier XAML
            ObjectDataProvider imageSource =
            (ObjectDataProvider)FindResource("ImageCollection1");
            imageSource.ObjectInstance = imageCollection1;
        }

        private void loadAlbums()
        {
            imageCollection1 = new ImageCollection();
            ImageTransfertServiceRef.ImageParam imParam = new ImageTransfertServiceRef.ImageParam();
            imParam.info = new ImageTransfertServiceRef.ImageInfo();
            imParam.info.userid = userInf.name;
            foreach (String a in imageTransfertService.getAllAlbumNames(imParam.info))
            {
                MessageBox.Show(a);
                imageCollection1.Add(new ImageObjet(a, lireFichier(@".\folder.png")));
            }
        }

        private static byte[] lireFichier(string chemin)
        {
            byte[] data = null;
            FileInfo fileInfo = new FileInfo(chemin);
            int nbBytes = (int)fileInfo.Length;
            FileStream fileStream = new FileStream(chemin, FileMode.Open,
            FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            data = br.ReadBytes(nbBytes);
            return data;
        }

        ListBox dragSource = null;
        // On initie le Drag and Drop
        private void ImageDragEvent(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }
        // On ajoute l'objet dans la nouvelle ListBox et on le supprime de l'ancienne
        private void ImageDropEvent(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            if (((IList)dragSource.ItemsSource) != ((IList)parent.ItemsSource))
            {
                ImageObjet data = (ImageObjet)e.Data.GetData(typeof(ImageObjet));
                ((IList)dragSource.ItemsSource).Remove(data);
                ((IList)parent.ItemsSource).Add(data);
            }
        }
        // On récupére l'objet que que l'on a dropé
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = (UIElement)source.InputHitTest(point);
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data =
                    source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = (UIElement)VisualTreeHelper.GetParent(element);
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }

        private void DisplayLoginScreen()
        {
            LoginWindow log = new LoginWindow();

            log.Owner = this;
            log.ShowDialog();
            if (log.DialogResult.HasValue && log.DialogResult.Value)
            {
                imageTransfertService.ClientCredentials.UserName.UserName = log.txtUserName.Text;
                imageTransfertService.ClientCredentials.UserName.Password = log.txtPassword.Password;
                try
                {
                    userInf = new ImageTransfertServiceRef.UserData();
                    userInf.name = log.txtUserName.Text;
                    userInf.pass = log.txtPassword.Password;
                    imageTransfertService.authentify(userInf);
                    MessageBox.Show("Logged in");
                }
                catch (Exception)
                {
                    MessageBox.Show("Bad password");
                    DisplayLoginScreen();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loadFolder(folderBrowserDialog1.SelectedPath);
            }


        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Return");
        }

        private void loadFolder(String folder)
        {
            imageCollection2 = new ImageCollection();
            foreach (string file in Directory.EnumerateFiles(folder, "*.jpg"))
            {
                FileInfo fileInfo = new FileInfo(file);
                imageCollection2.Add(new ImageObjet(System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name),
                lireFichier(file)));
            }
            // On lie la collectionau ObjectDataProvider déclaré dans le fichier XAML
            ObjectDataProvider imageDest =
           (ObjectDataProvider)FindResource("ImageCollection2");
            imageDest.ObjectInstance = imageCollection2;
        }
    }
}
