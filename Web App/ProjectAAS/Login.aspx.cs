using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAAS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] != null)
            {
                this.Response.Redirect("Default.aspx");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Text;
            Configurator configurator = new Configurator();

            if (configurator.CheckLogin(username, password))
            {
                Session["username"] = username;  // Store username in session
                Session["isLoggedIn"] = true;    // Add an additional session flag
                Response.Redirect("Default.aspx");
            }
            else
            {
                this.LabelMessage.Text = "Invalid username or password!";
            }
        }

    }
}