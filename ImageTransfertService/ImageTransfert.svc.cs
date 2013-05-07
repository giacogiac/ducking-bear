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
        String server = "OPERA\\SQLEXPRESS";
        String database = "ducking_bear_db";

        public String UploadImage(Stream image)
        {
            // Stocker l’image en BDD 
            byte[] imageBytes = null;
            MemoryStream imageStreamEnMemoire = new MemoryStream();
            image.CopyTo(imageStreamEnMemoire);
            imageBytes = imageStreamEnMemoire.ToArray();
            String imageID = null;
            imageID = bdAccess.addImage(imageBytes);
            imageStreamEnMemoire.Close();
            image.Close();
            return imageID;
        }

        public Stream DownloadImage(String userid, String albumid, String imageid)
        {
            // Récupérer l'image stockée en BDD et la transférer au client 
            byte[] imageBytes = null;
            Connexion bdAccess = new Connexion(server, database);
            imageBytes = bdAccess.getUser(userid).getAlbum(albumid).getImage(imageid);
            MemoryStream imageStreamEnMemoire = new MemoryStream(imageBytes);
            return imageStreamEnMemoire;
        }
    }
}
