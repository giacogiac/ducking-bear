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
            Connexion c = new Connexion();
            //c.addUser("giac", "giacpw", "user").addAlbum("noel");
            String rol = c.getUser("admin").getRole();
            Console.WriteLine("salut " + rol);
            //c.getAllUsers();
            //c.getUser("gwenn");
            Console.WriteLine("Administration terminal : ");
            // Instanciation de la référence de service 
            ImageTransfertServiceRef.ImageTransfertClient imageTransfertService = new ImageTransfertServiceRef.ImageTransfertClient();

            imageTransfertService.ClientCredentials.UserName.UserName = "userTest";
            imageTransfertService.ClientCredentials.UserName.Password = "pw";

            MemoryStream imageStream = new MemoryStream(lireFichier(@"C:\fichier.jpg"));
            Console.WriteLine("Image read from disk");
            // Appel de notre web method 
            ImageTransfertServiceRef.ImageInfo info = new ImageTransfertServiceRef.ImageInfo();
            info.albumid = "noel";
            info.userid = "giac";
            info.imageid = "cul";
            ImageTransfertServiceRef.UserData data = new ImageTransfertServiceRef.UserData();
            data.name = "admin";
            data.pass="";
            imageTransfertService.deleteUser(data);
            //imageTransfertService.UploadImage(info, imageStream);

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
