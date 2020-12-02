using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using PrograWeb.Modelos;

namespace PrograWeb.Datos
{
    public class DArticulo
    {

        MySqlConnection connection;
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;


        public List<EArticulo> getNuevosArticulos()
        {
            return this.getArticulos("SELECT * FROM Articulo ORDER BY idArticulo DESC LIMIT 6");
        }

        public List<EArticulo> getArticulosPorCategoria(string categoria, string codigoMarca = "")
        {
            string whereMarca = "";

            if (codigoMarca != "")
            {
                whereMarca = " AND codigoMarca = " + codigoMarca;
            }

            return this.getArticulos("SELECT * FROM Articulo WHERE categoriaArticulo = '" + categoria + "'" + whereMarca + " ORDER BY nombreArticulo ASC");
        }

        public List<EArticulo> getArticulos(string sql)
        {
            List<EArticulo> articulos = new List<EArticulo>();

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
                                EArticulo articulo = new EArticulo();
                                articulo.idArticulo = reader.GetInt32("idArticulo");
                                articulo.skuArticulo = reader.GetString("skuArticulo");
                                articulo.nombreArticulo = reader.GetString("nombreArticulo");
                                articulo.cantidadArticulo = reader.GetDouble("cantidadArticulo");
                                articulo.descripcionArticulo = reader.GetString("descripcionArticulo");
                                articulo.codigoMarca = reader.GetInt32("codigoMarca");
                                articulo.categoriaArticulo = reader.GetString("categoriaArticulo");
                                articulo.precioArticulo = reader.GetDouble("precioArticulo");
                                articulo.porcentajeImpuesto = reader.GetDouble("porcentajeImpuesto");
                                articulo.rutaImagen = reader.GetString("rutaImagen");
                                articulos.Add(articulo);
                            }
                            reader.Close();
                            connection.Close();
                        }

                        return articulos;
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
