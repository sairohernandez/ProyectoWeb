using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using PrograWeb.Modelos;

namespace PrograWeb.Datos
{
    public class DMarca
    {

        MySqlConnection connection;
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;


        public List<EMarca> getAllMarcas()
        {
            return this.getMarcas("SELECT * FROM Marca ORDER BY nombreMarca ASC");
        }

        public List<EMarca> getMarcas(string sql)
        {
            List<EMarca> marcas = new List<EMarca>();

            try
            {
                using (connection = new MySqlConnection(myConnectionString))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EMarca marca = new EMarca();
                                marca.codigoMarca = reader.GetInt32("codigoMarca");
                                marca.nombreMarca = reader.GetString("nombreMarca");
                                marcas.Add(marca);
                            }
                            reader.Close();
                            connection.Close();
                        }

                        return marcas;
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
