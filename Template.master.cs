using System;
using System.Web;
using System.Web.UI;
namespace PrograWeb
{
    public partial class Template : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Label_Username.Visible = false;
            Link_Login.Visible = false;
            Link_Logout.Visible = false;
            Link_Cart.Visible = false;

            if (Convert.ToString(Session["codigoUsuario"]) != "")
            {
                Label_Username.Text = "Hola, " + Convert.ToString(Session["nombreUsuario"]);
                Label_Username.Visible = true;
                Link_Login.Visible = false;
                Link_Logout.Visible = true;
                Link_Cart.Visible = true;
            } else
            {
                Label_Username.Visible = false;
                Link_Login.Visible = true;
                Link_Logout.Visible = false;
                Link_Cart.Visible = false;
            }
        }

        protected void IBLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void IBLogout_Click(object sender, EventArgs e)
        {
            Session["codigoUsuario"] = "";
            Session["nombreUsuario"] = "";
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

    }
}
