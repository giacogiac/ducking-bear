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
            ImageCourante.ImageUrl = "Image.aspx?userid=" + UseridBox.Text
                + "&albumid=" + AlbumidBox.Text + "&pictureid=" + ImageidBox.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}