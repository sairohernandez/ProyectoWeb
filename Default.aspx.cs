using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace PrograWeb
{

    public partial class Default : System.Web.UI.Page
    {

        //MySqlConnection conn;
        //string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            conn = new MySqlConnection(myConnectionString);

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select count(1) as cantidad from Usuarios");
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            MySqlDataAdapter Da = new MySqlDataAdapter();
            Da.SelectCommand = cmd;
            Da.Fill(dt);

            TextBox1.Text = dt.Rows[0][0].ToString();
            */


        }
    }
}