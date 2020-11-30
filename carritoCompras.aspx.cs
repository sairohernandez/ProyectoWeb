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
        DFactura DatosFactura = new DFactura();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                Session["GridView"] = DatosFactura.ObtenerCarrito();
                llenarGrid();
            
            }
          
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Aumentar")
            {
 
                int rowIndex = Convert.ToInt32(e.CommandArgument);


                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nCountry: " + country + "');", true);


                List<EFacturaDetalle> dt = (List<EFacturaDetalle>)Session["GridView"];

    
                dt[rowIndex].cantidadDetalle += 1;


                //GridView1.EditIndex = -1;


                llenarGrid();

            }
            else if (e.CommandName == "Disminuir")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                List<EFacturaDetalle> dt = (List<EFacturaDetalle>)Session["GridView"];

                dt[rowIndex].cantidadDetalle -= 1;

                llenarGrid();
            }

            else if (e.CommandName == "Borrar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                List<EFacturaDetalle> dt = (List<EFacturaDetalle>)Session["GridView"];

                dt.RemoveAt(rowIndex);

                llenarGrid();
            }
        }
        private void llenarGrid()
        {
            GridView1.DataSource = Session["GridView"];
            GridView1.DataBind();
        }

    }

}