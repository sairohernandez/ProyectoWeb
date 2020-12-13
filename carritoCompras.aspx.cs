using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrograWeb.Datos;
using PrograWeb.Modelos;


namespace PrograWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DFactura DatosFactura;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                DatosFactura = new DFactura();

                //DatosFactura.EFactura.LEFacturadetalle = DatosFactura.ObtenerCarrito();

                DatosFactura.EFactura.LEFacturadetalle = (List<EFacturaDetalle>)Session["GridView"];
                //Session["GridView"] = DatosFactura.EFactura.LEFacturadetalle;


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


                llenarGrid();
            }

            else if (e.CommandName == "Disminuir")

            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                DatosFactura = new DFactura();
                DatosFactura.EFactura.LEFacturadetalle = (List<EFacturaDetalle>)Session["GridView"];

                if (DatosFactura.EFactura.LEFacturadetalle[rowIndex].cantidadDetalle == 1)
                {
                    DatosFactura.EFactura.LEFacturadetalle[rowIndex].cantidadDetalle = 1;

                }
                else
                {
                    DatosFactura.EFactura.LEFacturadetalle[rowIndex].cantidadDetalle -= 1;
                }

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

            if (DatosFactura.EFactura.LEFacturadetalle != null)
            {
                DatosFactura.CalcularTotalFactura(DatosFactura.EFactura.LEFacturadetalle);
                GridView1.DataSource = DatosFactura.EFactura.LEFacturadetalle;
                GridView1.DataBind();
                LtotalFactura.Text = DatosFactura.EFactura.totalFactura.ToString("C2");
            }

            else
            {
                LtotalFactura.Text = (0).ToString("C2");
            }

        }


        protected void OnTextChanged(object sender, EventArgs e)
        {

            var txtName = (TextBox)sender;
            var row = (GridViewRow)txtName.NamingContainer;
            //Reference the TextBox.
            //TextBox textBox = sender as TextBox;

            DatosFactura = new DFactura();
            DatosFactura.EFactura.LEFacturadetalle = (List<EFacturaDetalle>)Session["GridView"];

            DatosFactura.EFactura.LEFacturadetalle[row.RowIndex].cantidadDetalle = Convert.ToDouble(txtName.Text);


            llenarGrid();

            ////Get the ID of the TextBox.
            //string id = textBox.ID;

            ////Display the Text of TextBox.
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + textBox.Text + "');", true);
        }

        protected void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("procesoVenta.aspx");
        }
    }

}