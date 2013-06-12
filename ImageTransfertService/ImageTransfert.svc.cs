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

        public ErrorMessage UploadImage(ImageUploadRequest data)
        {
            ErrorMessage mes = new ErrorMessage();
            try
            {
                // Stocker l’image en BDD 
                byte[] imageBytes = null;
                MemoryStream imageStreamEnMemoire = new MemoryStream();
                data.ImageData.CopyTo(imageStreamEnMemoire);
                imageBytes = imageStreamEnMemoire.ToArray();

                Connexion connex = new Connexion();
                connex.getUser(data.ImageInfo.userid).getAlbum(data.ImageInfo.albumid).addImage(data.ImageInfo.imageid, imageBytes);
                imageStreamEnMemoire.Close();
                data.ImageData.Close();
                
                mes.message = "Image uploaded";
                
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
            return mes;
        }

        public ImageDownloadResponse Download(ImageDownloadRequest data)
        {
            try{
                // Récupérer l'image stockée en BDD et la transférer au client 
                byte[] imageBytes = null;
                Connexion connex = new Connexion();
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

         public ErrorMessage addUser(UserInfo info)
         {
             ErrorMessage mes = new ErrorMessage();

             try
             {
                 Connexion connex = new Connexion(SERVER, DATABASE);
                 connex.addUser(info.data.name, info.data.pass);
                 mes.message = "User added";

             }
             catch (Exception ex)
             {
                 throw new FaultException(ex.ToString());
             }

             return mes;
         }

         public ErrorMessage deleteUser(UserInfo info)
         {
             ErrorMessage mes = new ErrorMessage();

             try
             {
                 Connexion connex = new Connexion(SERVER, DATABASE);
                 //remove User : connex.
                 mes.message = "User removed";

             }
             catch (Exception ex)
             {
                 throw new FaultException(ex.ToString());
             }

             return mes;
         }

        public ErrorMessage createAlbum(ImageParam param)
         {
             ErrorMessage mes = new ErrorMessage();

             try
             {
                 Connexion connex = new Connexion(SERVER, DATABASE);
                 User user = connex.getUser(param.info.userid);
                 user.addAlbum(param.info.albumid);
                 mes.message = "Album added";

             }
             catch (Exception ex)
             {
                 throw new FaultException(ex.ToString());
             }

             return mes;
         }

         public ErrorMessage deleteAlbum(ImageParam param)
         {
             ErrorMessage mes = new ErrorMessage();

             try
             {
                 Connexion connex = new Connexion(SERVER, DATABASE);
                 User user = connex.getUser(param.info.userid);
                 //user.removeAlbum
                 mes.message = "Album removed";

             }
             catch (Exception ex)
             {
                 throw new FaultException(ex.ToString());
             }

             return mes;
         }

         public ErrorMessage deleteImage(ImageParam param)
         {
             ErrorMessage mes = new ErrorMessage();

             try
             {
                 Connexion connex = new Connexion(SERVER, DATABASE);
                 User user = connex.getUser(param.info.userid);
                 Album album = user.getAlbum(param.info.albumid);
                 //album.removeImage
                 mes.message = "Image removed";

             }
             catch (Exception ex)
             {
                 throw new FaultException(ex.ToString());
             }

             return mes;
         }

         public ListResult getAllUserNames()
         {
             ListResult res = new ListResult();
             try
             {
                 Connexion connex = new Connexion(SERVER, DATABASE);
                 List<User> users = connex.getAllUsers();
                 List<String> strings = new List<string>();
                 foreach( User us in users){
                     strings.Add(us.getUserId());
                 }
                 res.names = strings;
             }
             catch (Exception ex)
             {
                 throw new FaultException(ex.ToString());
             }
             return res;
         }

         public ListResult getAllAlbumNames(ImageParam param)
         {
             ListResult res = new ListResult();
             try
             {
                 Connexion connex = new Connexion(SERVER, DATABASE);
                 User user = connex.getUser(param.info.userid);
                 List<String> strings = new List<string>();
                 List<Album> albums = user.getAllAlbums();
                 foreach (Album alb in albums)
                 {
                     strings.Add(alb.getAlbumId());
                 }
                 res.names = strings;
             }
             catch (Exception ex)
             {
                 throw new FaultException(ex.ToString());
             }
             return res;
         }

         public ListResult getAllImageName(ImageParam param)
         {
             ListResult res = new ListResult();
             try
             {
                 Connexion connex = new Connexion(SERVER, DATABASE);
                 User user = connex.getUser(param.info.userid);
                 List<String> strings = new List<string>();
                 Album album = user.getAlbum(param.info.albumid);
                 //strings = album.getAllImageNames();
                 res.names = strings;
             }
             catch (Exception ex)
             {
                 throw new FaultException(ex.ToString());
             }
             return res;
         }

    }
}
