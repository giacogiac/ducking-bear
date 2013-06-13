using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLib;
using System.IO;

namespace ClientWeb
{
    public partial class Image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            // On récupére la valeur du paramètre ImageID passé dans l’URL
            String userid = (String)Session["user"];
            String pass = (String)Session["pass"];
            String albumid = Request.QueryString["albumid"];
            String pictureid = Request.QueryString["pictureid"];
            // Si ce paramètre n'est pas nul
            if (userid != null && albumid != null && pictureid != null)
            {
                ImageTransfertServiceRef.ImageTransfertClient imageTransfertService = new ImageTransfertServiceRef.ImageTransfertClient();

                imageTransfertService.ClientCredentials.UserName.UserName = userid;
                imageTransfertService.ClientCredentials.UserName.Password = pass;

                ImageTransfertServiceRef.ImageInfo info = new ImageTransfertServiceRef.ImageInfo();

                info.albumid = albumid;
                info.userid = userid;
                info.imageid = pictureid;

                Stream imgData = imageTransfertService.Download(info);
                var memoryStream = new MemoryStream();
                imgData.CopyTo(memoryStream);

                Byte[] bytes = memoryStream.ToArray();
                // et on crée le contenu de notre réponse à la requête HTTP
                // (ici un contenu de type image)
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
    }
}