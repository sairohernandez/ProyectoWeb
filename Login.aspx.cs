using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using MySqlX.XDevAPI;

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
            MySqlConnection conn = new MySqlConnection("server=remotemysql.com;port=3306;database=JU7v5Dpmc3;user id=JU7v5Dpmc3; password=80JwZf6LER");

            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Usuarios where nombreUsuario = '" + TextBox_Username.Text + "' and claveUsuario = '" + TextBox_Password.Text + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Session["codigoUsuario"] = dr["codigoUsuario"].ToString();
                Session["nombreUsuario"] = dr["nombreUsuario"].ToString();
                Response.Redirect("Default.aspx");
            }

            conn.Close();

            Label_Error.Text = "Usuario o Password incorrectos";
            Label_Error.Visible = true;

            //String User = TextBox_Username.Text;
            //String Password = TextBox_Password.Text;

            //MySqlConnection conn = new MySqlConnection("server=remotemysql.com;port=3306;database=JU7v5Dpmc3;user id=JU7v5Dpmc3; password=80JwZf6LER") ;

            //MySqlDataAdapter sda = new MySqlDataAdapter("select count (*) Usuarios where nombreUsuario = '" + TextBox_Username.Text + "' and claveUsuario = '"+ TextBox_Password.Text +"'", conn);

            //DataTable dt = new DataTable();

            //sda.Fill(dt);

            //if (dt.Rows[0][0].ToString() == "1")
            //{
            //    Response.Redirect("Default.aspx");
            //}
            //else
            //{
            //    Label_Error.Text = "Username/Password Incorrect";
            //}
        }

    }
}