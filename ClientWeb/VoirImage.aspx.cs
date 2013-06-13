using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
    public partial class VoirImage : System.Web.UI.Page
    {
        protected void Visualiser_Click(object sender, EventArgs e)
        {
            string album = AlbumidBox.Text;
            string img = ImageidBox.Text;
            ImageCourante.ImageUrl = "Image.aspx?albumid=" + album + "&pictureid=" + img;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}