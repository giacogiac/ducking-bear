﻿using System;
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}