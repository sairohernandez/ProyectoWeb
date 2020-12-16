using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrograWeb.Datos;
using PrograWeb.Modelos;
using System.Web.Security;

namespace PrograWeb
{
    public partial class procesoVenta : System.Web.UI.Page
    {
        DFactura DatosFactura = new DFactura();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Session["codigoUsuario"]) == "")
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                HttpContext.Current.Response.Redirect("Default.aspx", true);
            }

            if (!Page.IsPostBack)
            {
                //Seguridad
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();

                txtDireccionExacta.Visible = false;
                calculaDatosFactura();
                lblFechaFormalizacion.Text = DateTime.Today.ToString("dd/MM/yyyy");
                lblTotalDocumento.Text = DatosFactura.EFactura.totalFactura.ToString("C2");
            }


        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            calculaDatosFactura();

            if (cmdEntrega.SelectedIndex == 1)
            {
                DatosFactura.EFactura.direccionEnvio = txtDireccionExacta.Text;
            }
            else
            {
                DatosFactura.EFactura.direccionEnvio = "";
            }

            if (DatosFactura.GuardarFactura())
            {
                string script = "msEnvioFactura();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                Session["GridView"] = null;
            }
            else
            {
                string script = "mensajeError();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }

        protected void cmbPlazos_SelectedIndexChanged(object sender, EventArgs e)
        {

            calculaDatosFactura();

        }

        void calculaDatosFactura()
        {
            DatosFactura.EFactura.codigoUsuarioFactura = Convert.ToInt32(Session["codigoUsuario"]);
            DatosFactura.EFactura.plazoPaFactura = Convert.ToInt32(cmbPlazos.SelectedValue);
            DatosFactura.EFactura.LEFacturadetalle = (List<EFacturaDetalle>)Session["GridView"];
            DatosFactura.CalcularTotalFactura(DatosFactura.EFactura.LEFacturadetalle);
            lblMontoCuota.Text = DatosFactura.EFactura.montoCuotaFija.ToString("C2");
            lblTFechaVencimiento.Text = DateTime.Today.AddMonths((int)DatosFactura.EFactura.plazoPaFactura).ToString("dd/MM/yyyy");
        }

        protected void cmdEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdEntrega.SelectedIndex == 1)
            {
                txtDireccionExacta.Visible = true;
                txtDireccionExacta.Style.Add("required", "true");
            }
            else
            {
                txtDireccionExacta.Visible = false;
                txtDireccionExacta.Style.Add("required", "false");
            }

        }
    }
}