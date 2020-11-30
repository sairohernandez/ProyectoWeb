using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace PrograWeb.Datos
{
    public class DArticulo
    {

        MySqlConnection connection;
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;


        public DataTable getArticulos()
        {
            try
            {
                using (connection = new MySqlConnection(myConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Articulo";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        MySqlDataAdapter Da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        Da.Fill(dt);

                        connection.Close();

                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
