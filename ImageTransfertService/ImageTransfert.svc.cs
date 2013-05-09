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

        public const String SERVER = "X064";
        public const String DATABASE = "testDB";

        public void  UploadImage(ImageUploadRequest data)
        {
            try
            {
                // Stocker l’image en BDD 
                byte[] imageBytes = null;
                MemoryStream imageStreamEnMemoire = new MemoryStream();
                data.ImageData.CopyTo(imageStreamEnMemoire);
                imageBytes = imageStreamEnMemoire.ToArray();

                Connexion connex = new Connexion(Connexion.SERVER, Connexion.DATABASE);
                connex.getUser(data.ImageInfo.userid).getAlbum(data.ImageInfo.albumid).addImage(data.ImageInfo.imageid, imageBytes);
                imageStreamEnMemoire.Close();
                data.ImageData.Close();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }

        public ImageDownloadResponse Download(ImageDownloadRequest data)
        {
            try{
                // Récupérer l'image stockée en BDD et la transférer au client 
                byte[] imageBytes = null;
                Connexion connex = new Connexion(SERVER, DATABASE);
                imageBytes = connex.getUser(data.ImageInfo.userid).getAlbum(data.ImageInfo.albumid).getImage(data.ImageInfo.imageid);
                MemoryStream imageStreamEnMemoire = new MemoryStream(imageBytes);
                ImageDownloadResponse res = new ImageDownloadResponse();
                res.ImageData = imageStreamEnMemoire;
                return res;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }

    }
}
