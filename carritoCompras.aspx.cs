using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PrograWeb.Datos;
using PrograWeb.Modelos;


namespace PrograWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DFactura DatosFactura ;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                DatosFactura = new DFactura();

                DatosFactura.EFactura.LEFacturadetalle = DatosFactura.ObtenerCarrito();

                Session["GridView"] = DatosFactura.EFactura.LEFacturadetalle;


                llenarGrid();
            
            }
          
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Aumentar")
            {
 
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                DatosFactura = new DFactura();
                DatosFactura.EFactura.LEFacturadetalle = (List<EFacturaDetalle>)Session["GridView"];

                DatosFactura.EFactura.LEFacturadetalle[rowIndex].cantidadDetalle += 1;

                //pedidoCliente.LEFacturadetalle[rowIndex].cantidadDetalle += 1;



                //GridView1.EditIndex = -1;


                llenarGrid();

            }
            else if (e.CommandName == "Disminuir")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                DatosFactura = new DFactura();
                DatosFactura.EFactura.LEFacturadetalle = (List<EFacturaDetalle>)Session["GridView"];

                DatosFactura.EFactura.LEFacturadetalle[rowIndex].cantidadDetalle -= 1;

                //pedidoCliente.LEFacturadetalle[rowIndex].cantidadDetalle -= 1;

                llenarGrid();
            }

            else if (e.CommandName == "Borrar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                DatosFactura = new DFactura();
                DatosFactura.EFactura.LEFacturadetalle = (List<EFacturaDetalle>)Session["GridView"];

                DatosFactura.EFactura.LEFacturadetalle.RemoveAt(rowIndex);

                llenarGrid();
            }
        }
        private void llenarGrid()
        {

          
            DatosFactura.CalcularTotalFactura(DatosFactura.EFactura.LEFacturadetalle);
            GridView1.DataSource = DatosFactura.EFactura.LEFacturadetalle;
            GridView1.DataBind();

            LtotalFactura.Text = "¢"+DatosFactura.EFactura.totalFactura.ToString("N2");
        }

        protected void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            DatosFactura = new DFactura();
            DatosFactura.EFactura.LEFacturadetalle = (List<EFacturaDetalle>)Session["GridView"];
            DatosFactura.CalcularTotalFactura(DatosFactura.EFactura.LEFacturadetalle);
            if (DatosFactura.GuardarFactura())
            {
                string script = "mensajeCorrecto();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                string script = "mensajeError();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }

}