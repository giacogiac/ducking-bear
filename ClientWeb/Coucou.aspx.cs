using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWeb
{
    public partial class Coucou : System.Web.UI.Page
    {
        protected void Authentifier_Click(object sender, EventArgs e)
        {
            Session["user"] = UserTextBox.Text;
            Session["pass"] = PwTextBox.Text;

            ImageTransfertServiceRef.ImageTransfertClient imageTransfertService = new ImageTransfertServiceRef.ImageTransfertClient();

            imageTransfertService.ClientCredentials.UserName.UserName = (string)Session["user"];
            imageTransfertService.ClientCredentials.UserName.Password = (string)Session["pass"];

            try
            {
                ImageTransfertServiceRef.UserData data = new ImageTransfertServiceRef.UserData();
                data.name = (string)Session["user"];
                data.pass = (string)Session["pass"];
                imageTransfertService.authentify(data);
                Response.Redirect("VoirImage.aspx");
            }
            catch (Exception eee)
            {
                Session["user"] = null;
                Session["pass"] = null;
            }
            


        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}