using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using PrograWeb.Modelos;

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
            Link_Admin.Visible = false;

            if (Convert.ToString(Session["codigoUsuario"]) != "")
            {
                Label_Username.Text = "Hola, " + Convert.ToString(Session["nombreUsuario"]);
                Label_Username.Visible = true;
                Link_Login.Visible = false;
                Link_Logout.Visible = true;
                Link_Cart.Visible = true;
                this.Refresh_Cart_Counter();

                if (Convert.ToString(Session["tipoUsuario"]) == "1")
                {
                    Link_Admin.Visible = true;
                }
            } else
            {
                Label_Username.Visible = false;
                Link_Login.Visible = true;
                Link_Logout.Visible = false;
                Link_Cart.Visible = false;
                Link_Admin.Visible = false;
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
            Session["tipoUsuario"] = "";
            Session["messageContent"] = "";
            Session["messageType"] = "";
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }

        private void Refresh_Cart_Counter() 
        {
            List<EFacturaDetalle> cart = (List<EFacturaDetalle>)Session["GridView"];

            if (cart != null)
            {
                double totalQty = 0;

                foreach (EFacturaDetalle item in cart)
                {
                    totalQty += item.cantidadDetalle;
                }

                Label_Cart_Counter.Text = totalQty.ToString();
            }
        }

        protected void carritocompras_click(object sender, EventArgs e)
        {
            Response.Redirect("carritoCompras.aspx");
        }
    }
}
