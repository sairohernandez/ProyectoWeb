using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace PrograWeb
{
    public partial class Login : System.Web.UI.Page

    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label_Error.Visible = false;
        }

        protected void Submit_Click(object sender, EventArgs e)

        {
            Label_Error.Visible = false;

   
            string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            MySqlConnection conn = new MySqlConnection(myConnectionString);

            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select codigoUsuario,nombreUsuario,tipoUsuario from Usuarios where identificacionUsuario = '" + TextBox_Username.Text + "' and claveUsuario = '" + TextBox_Password.Text + "' and estadoUsuario = 1";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Session["codigoUsuario"] = dr["codigoUsuario"].ToString();
                Session["nombreUsuario"] = dr["nombreUsuario"].ToString();
                Session["tipoUsuario"] = dr["tipoUsuario"].ToString();
                Response.Redirect("Default.aspx");
            }

            conn.Close();

            Label_Error.Text = "Usuario o Password incorrectos";
            Label_Error.Visible = true;

 
        }

    }
}