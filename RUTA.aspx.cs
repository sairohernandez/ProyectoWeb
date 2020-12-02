using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrograWeb.Datos;
using PrograWeb.Modelos;

namespace PrograWeb
{

    public partial class RUTA : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Intentamos traer las marcas para filtrar
            try
            {
                List<EMarca> marcas = new List<EMarca>();
                DMarca mMarca = new DMarca();
                marcas = mMarca.getAllMarcas();
                MarcasList.DataSource = marcas;
                MarcasList.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Intentamos traer los productos para esta categoria
            try
            {
                List<EArticulo> articulos = new List<EArticulo>();
                DArticulo mArticulo = new DArticulo();
                articulos = mArticulo.getArticulosPorCategoria("RUTA");
                ProductosGrid.DataSource = articulos;
                ProductosGrid.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            EmptyGridLabel.Visible = (ProductosGrid.Items.Count == 0);
        }

        protected void Filter_Products(object sender, CommandEventArgs e)
        {
            try
            {
                List<EArticulo> articulos = new List<EArticulo>();
                DArticulo mArticulo = new DArticulo();
                articulos = mArticulo.getArticulosPorCategoria("RUTA", e.CommandArgument.ToString());
                ProductosGrid.DataSource = articulos;
                ProductosGrid.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            EmptyGridLabel.Visible = (ProductosGrid.Items.Count == 0);
        }

    }
}
