using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using DataLib;

namespace ImageTransfertService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    public class Service1 : IImageTransfert
    {
        static String server = "OPERA\\SQLEXPRESS";
        static String database = "ducking_bear_db";

        public void  UploadImage(ImageUploadRequest data)
        {
            // Stocker l’image en BDD 
            byte[] imageBytes = null;
            MemoryStream imageStreamEnMemoire = new MemoryStream();
            data.ImageData.CopyTo(imageStreamEnMemoire);
            imageBytes = imageStreamEnMemoire.ToArray();

            Connexion connex = new Connexion(server, database);
            connex.getUser(data.ImageInfo.userid).getAlbum(data.ImageInfo.albumid).addImage(data.ImageInfo.imageid, imageBytes);
            imageStreamEnMemoire.Close();
            data.ImageData.Close();
        }

        public ImageDownloadResponse Download(ImageDownloadRequest data)
        {
            // Récupérer l'image stockée en BDD et la transférer au client 
            byte[] imageBytes = null;
            Connexion connex = new Connexion(server, database);
            imageBytes = connex.getUser(data.ImageInfo.userid).getAlbum(data.ImageInfo.albumid).getImage(data.ImageInfo.imageid);
            MemoryStream imageStreamEnMemoire = new MemoryStream(imageBytes);
            ImageDownloadResponse res = new ImageDownloadResponse();
            res.ImageData = imageStreamEnMemoire;
            return res;
        }
    }
}
