using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using PrograWeb.Datos;
using PrograWeb.Modelos;

namespace PrograWeb
{

    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Cargamos los ultimos 6 productos
            try
            {
                List<EArticulo> articulos = new List<EArticulo>();
                DArticulo mArticulo = new DArticulo();
                articulos = mArticulo.getNuevosArticulos();
                NuevosProductos.DataSource = articulos;
                NuevosProductos.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}