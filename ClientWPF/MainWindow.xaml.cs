using System;
using System.IO;
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
        private ImageCollection imageCollection1;
        private ImageCollection imageCollection2;
        public MainWindow()
        {
            InitializeComponent();
            // On crée notre collection d'image et on y ajoute deux images
            imageCollection1 = new ImageCollection();
            imageCollection1.Add(new ImageObjet("celestial",
            lireFichier(@"D:\Pictures\boobsncat2.jpg")));
            imageCollection1.Add(new ImageObjet("pearlscale",
            lireFichier(@"D:\Pictures\boobsncat.jpg")));
            imageCollection2 = new ImageCollection();
            imageCollection2.Add(new ImageObjet("celestial",
            lireFichier(@"D:\Pictures\boobs1.jpg")));
            imageCollection2.Add(new ImageObjet("pearlscale",
            lireFichier(@"D:\Pictures\boobs2.jpg")));
            // On lie la collectionau ObjectDataProvider déclaré dans le fichier XAML
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
    }
}
