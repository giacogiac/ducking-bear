using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLib;

namespace ClientWeb
{
    public partial class Image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On récupére la valeur du paramètre ImageID passé dans l’URL
            String userid = Request.QueryString["userid"];
            String albumid = Request.QueryString["albumid"];
            String pictureid = Request.QueryString["pictureid"];
            // Si ce paramètre n'est pas nul
            if (userid != null && albumid != null && pictureid != null)
            {
                // on récupére notre image là où il faut
                Connexion connex = new Connexion();
                Byte[] bytes = connex.getUser(userid).getAlbum(albumid).getImage(pictureid);
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