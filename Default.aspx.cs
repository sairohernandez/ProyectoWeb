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

namespace PrograWeb
{

    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            DArticulo mArticulo = new DArticulo();

            GridView1.DataSource = mArticulo.getArticulos();
            GridView1.DataBind();
        }
    }
}