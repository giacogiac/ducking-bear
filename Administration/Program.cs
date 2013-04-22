using System;
using System.IO; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLib;

namespace Administration
{
    class Program
    {
        //TEST SUR L'UPLOAD D'UNE IMAGE ( voir enoncé 2 )
        static void Main(string[] args)
        {
            // Instanciation de la référence de service 
            ImageTransfertServiceReference.Service1Client imageTransfertService =
                new ImageTransfertServiceReference.Service1Client();
            MemoryStream imageStream = new
            MemoryStream(lireFichier(@"c:\fichier.jpg"));
            // Appel de notre web method 
            imageTransfertService.UploadImage(imageStream);
            Console.Out.WriteLine("Transfert Terminé");
            Console.ReadLine();
        }

        /// <summary> 
        /// Lit et retourne le contenu du fichier sous la forme de tableau de byte 
        /// </summary> 
        /// <param name="chemin">chemin du fichier</param> 
        /// <returns></returns> 
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
