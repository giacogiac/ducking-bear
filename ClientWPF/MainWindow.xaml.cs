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

        Boolean inAlbum;

        private String currentPath;
        private String currentAlbum;

        private ImageCollection imageCollection1;
        private ImageCollection imageCollection2;

        public MainWindow()
        {
            inAlbum = false;
            imageTransfertService = new ImageTransfertServiceRef.ImageTransfertClient();
            InitializeComponent();
            ImageBrush brush1 = new ImageBrush();
            Stream imageStreamSource = new FileStream("../../arrow.png", FileMode.Open, FileAccess.Read, FileShare.Read);
PngBitmapDecoder decoder = new PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
BitmapSource bitmapSource = decoder.Frames[0];
brush1.ImageSource = bitmapSource;
            btnReturn.Background = brush1;
            ImageBrush brush2 = new ImageBrush();
            Stream imageStreamSource2 = new FileStream("../../folder.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            PngBitmapDecoder decoder2 = new PngBitmapDecoder(imageStreamSource2, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource2 = decoder2.Frames[0];
            brush2.ImageSource = bitmapSource2;
            btnFolder.Background = brush2;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayLoginScreen();
            loadFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            loadAlbums();
            
        }

        private void loadAlbum(String albumid)
        {
            currentAlbum = albumid;
            imageCollection1 = new ImageCollection();
            ImageTransfertServiceRef.ImageParam imParam = new ImageTransfertServiceRef.ImageParam();
            imParam.info = new ImageTransfertServiceRef.ImageInfo();
            imParam.info.userid = userInf.name;
            imParam.info.albumid = albumid;
            foreach (String a in imageTransfertService.getAllImageName(imParam.info))
            {
                imParam.info = new ImageTransfertServiceRef.ImageInfo();
                imParam.info.userid = userInf.name;
                imParam.info.albumid = albumid;
                imParam.info.imageid = a;
                Stream imgData = imageTransfertService.Download(imParam.info);
                var memoryStream = new MemoryStream();
                imgData.CopyTo(memoryStream);
                imageCollection1.Add(new ImageObjet(a, memoryStream.ToArray()));
            }
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
                imageCollection1.Add(new ImageObjet(a, lireFichier("../../folder.png")));
            }
            imageCollection1.Add(new ImageObjet("Nouvel Album", lireFichier("../../plus.png")));
            ObjectDataProvider imageSource =
            (ObjectDataProvider)FindResource("ImageCollection1");
            imageSource.ObjectInstance = imageCollection1;
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
        private void ImageDelete(object sender, MouseButtonEventArgs e)
        {
            if (inAlbum)
            {
                ListBox parent = (ListBox)sender;
                dragSource = parent;
                object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
                if (data != null)
                {
                    ImageObjet img = (ImageObjet)data;
                    ImageTransfertServiceRef.ImageParam imParam = new ImageTransfertServiceRef.ImageParam();
                    imParam.info = new ImageTransfertServiceRef.ImageInfo();
                    imParam.info.userid = userInf.name;
                    imParam.info.albumid = currentAlbum;
                    imParam.info.imageid = img.Nom;
                    imageTransfertService.deleteImage(imParam.info);
                    MessageBox.Show("Image deleted");
                    ((IList)parent.ItemsSource).Remove(data);
                }
            }
            else
            {
                ListBox parent = (ListBox)sender;
                dragSource = parent;
                object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
                if (data != null)
                {
                    ImageObjet img = (ImageObjet)data;
                    if (img.Nom != "Nouvel Album")
                    {
                        ImageTransfertServiceRef.ImageParam imParam = new ImageTransfertServiceRef.ImageParam();
                        imParam.info = new ImageTransfertServiceRef.ImageInfo();
                        imParam.info.userid = userInf.name;
                        imParam.info.albumid = img.Nom;
                        imageTransfertService.deleteAlbum(imParam.info);
                        MessageBox.Show("Album deleted");
                        ((IList)parent.ItemsSource).Remove(data);
                    }
                }
            }
        }

        private void ImageDragEventAlbum(object sender, MouseButtonEventArgs e)
        {
            if (inAlbum)
            {
                ListBox parent = (ListBox)sender;
                dragSource = parent;
                object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
                if (data != null)
                {
                    DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
                }
            }
            else
            {
                inAlbum = true;
                ListBox parent = (ListBox)sender;
                dragSource = parent;
                object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
                if (data != null)
                {
                    ImageObjet img = (ImageObjet)data;
                    if (img.Nom == "Nouvel Album")
                    {
                        inAlbum = false;
                        CreateAlbum log = new CreateAlbum();
                        log.Owner = this;
                        log.ShowDialog();
                        if (log.DialogResult.HasValue && log.DialogResult.Value)
                        {
                            ImageTransfertServiceRef.ImageParam imParam = new ImageTransfertServiceRef.ImageParam();
                            imParam.info = new ImageTransfertServiceRef.ImageInfo();
                            imParam.info.userid = userInf.name;
                            imParam.info.albumid = log.txtAlbumName.Text;
                            imageTransfertService.createAlbum(imParam.info);
                            MessageBox.Show("Album created");
                            loadAlbums();
                        }
                    }
                    else
                    {
                        loadAlbum(img.Nom);
                    }
                }
            }
        }

        private void ImageDragEvent(object sender, MouseButtonEventArgs e)
        {
            if (inAlbum)
            {
                ListBox parent = (ListBox)sender;
                dragSource = parent;
                object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
                if (data != null)
                {
                    DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
                }
            }
        }

        // On ajoute l'objet dans la nouvelle ListBox et on le supprime de l'ancienne
        private void ImageDropEventAlbum(object sender, DragEventArgs e)
        {
            if (!inAlbum)
                return;
            ListBox parent = (ListBox)sender;
            if (((IList)dragSource.ItemsSource) != ((IList)parent.ItemsSource))
            {
                ImageObjet data = (ImageObjet)e.Data.GetData(typeof(ImageObjet));
                foreach (ImageObjet i in ((IList)parent.ItemsSource))
                {
                    if (i.Nom == data.Nom)
                    {
                        MessageBox.Show("Image en double");
                        return;
                    }
                }
                MessageBox.Show("upload");
                MemoryStream imageStream = new MemoryStream(lireFichier(currentPath + "\\" + data.Nom + ".jpg"));
                ImageTransfertServiceRef.ImageParam imParam = new ImageTransfertServiceRef.ImageParam();
                imParam.info = new ImageTransfertServiceRef.ImageInfo();
                imParam.info.userid = userInf.name;
                imParam.info.albumid = currentAlbum;
                imParam.info.imageid = data.Nom;
                imageTransfertService.UploadImage(imParam.info, imageStream);
                ((IList)parent.ItemsSource).Add(data);
            }
        }

        // On ajoute l'objet dans la nouvelle ListBox et on le supprime de l'ancienne
        private void ImageDropEvent(object sender, DragEventArgs e)
        {
            if (!inAlbum)
                return;
            ListBox parent = (ListBox)sender;
            if (((IList)dragSource.ItemsSource) != ((IList)parent.ItemsSource))
            {
                ImageObjet data = (ImageObjet)e.Data.GetData(typeof(ImageObjet));
                foreach (ImageObjet i in ((IList)parent.ItemsSource))
                {
                    if (i.Nom == data.Nom)
                    {
                        MessageBox.Show("Image en double");
                        return;
                    }
                }
                MessageBox.Show("download");
                ImageTransfertServiceRef.ImageParam imParam = new ImageTransfertServiceRef.ImageParam();
                imParam.info = new ImageTransfertServiceRef.ImageInfo();
                imParam.info.userid = userInf.name;
                imParam.info.albumid = currentAlbum;
                imParam.info.imageid = data.Nom;
                Stream imgData = imageTransfertService.Download(imParam.info);
                var memoryStream = new MemoryStream();
                imgData.CopyTo(memoryStream);
                FileStream fileStream = new FileStream(currentPath + "\\" + data.Nom + ".jpg", FileMode.Create,
                FileAccess.Write);
                BinaryWriter br = new BinaryWriter(fileStream);
                br.Write(memoryStream.ToArray());
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
            if (!inAlbum)
                return;
            inAlbum = false;
            loadAlbums();
        }

        private void loadFolder(String folder)
        {
            currentPath = folder;
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
