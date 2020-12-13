using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using PrograWeb.Modelos;


namespace PrograWeb.Datos
{
    public class DPersona
    {

        MySqlConnection connection;
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        //Obtiene solicitude pendientes de aprobacion
        public DataTable ObtieneSolicitudesNuevas()
        {

            using (connection = new MySqlConnection(myConnectionString))
            {
                connection.Open();

                string sql;

                sql = "select codigoUsuario,identificacionUsuario,nombreUsuario,apellidosUsuario,correoUsuario,telefonoUsuario from Usuarios where estadousuario = 3";

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {

                    DataTable dt = new DataTable();
                    MySqlDataAdapter Da = new MySqlDataAdapter();
                    Da.SelectCommand = cmd;
                    Da.Fill(dt);

                    return dt;


                }
            }
        }



        public bool procesarEvalucionCredito(int codigoRespuesta, int codigoUsuario)
        {

            try
            {

                using (connection = new MySqlConnection(myConnectionString))
                {
                    connection.Open();

                    string sql;

                    sql = "update Usuarios set estadousuario = @estadousuario where codigoUsuario = @codigoUsuario";


                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@estadoUsuario", MySqlDbType.Int32).Value = codigoRespuesta;
                        cmd.Parameters.Add("@codigoUsuario", MySqlDbType.Int32).Value = codigoUsuario;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                    }
                    connection.Close();
                }
        
                return true;

            }
            catch (Exception e)
            {

                return false;
            }
        }


        public int GuardarSolicitudCredito(EPersona solicitud)
        {

            try
            {


                using (connection = new MySqlConnection(myConnectionString))
                {
                    connection.Open();

                    string sql;

                    sql = "select estadousuario from Usuarios where identificacionUsuario = @identificacionUsuario";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@identificacionUsuario", MySqlDbType.VarChar, 50).Value = solicitud.identificacionUsuario;
                        DataTable dt = new DataTable();
                        MySqlDataAdapter Da = new MySqlDataAdapter();
                        Da.SelectCommand = cmd;
                        Da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            if (int.Parse(dt.Rows[0][0].ToString()) == 1 || int.Parse(dt.Rows[0][0].ToString()) == 3)
                            {

                                return 3;
                            }
                        }


                    }
                    sql = "INSERT  Usuarios " +
                    "VALUES(@codigoUsuario,@identificacionUsuario,@nombreUsuario,@apellidosUsuario,@fechaNacUsuario," +
                    "@correoUsuario,@telefonoUsuario,@direccionUsuario,@claveUsuario," +
                    "@vencimientoClave,@tipoUsuario,@fechaRegUsuario,@limiteCreditoUsuario,@estadoUsuario);";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@codigoUsuario", MySqlDbType.Int32).Value = 0;
                        cmd.Parameters.Add("@identificacionUsuario", MySqlDbType.VarChar, 50).Value = solicitud.identificacionUsuario;
                        cmd.Parameters.Add("@nombreUsuario", MySqlDbType.VarChar, 50).Value = solicitud.nombreUsuario;
                        cmd.Parameters.Add("@apellidosUsuario", MySqlDbType.VarChar).Value = solicitud.apellidosUsuario;
                        cmd.Parameters.Add("@fechaNacUsuario", MySqlDbType.DateTime, 50).Value = solicitud.fechaNacUsuario;
                        cmd.Parameters.Add("@correoUsuario", MySqlDbType.VarChar, 50).Value = solicitud.correoUsuario;
                        cmd.Parameters.Add("@telefonoUsuario", MySqlDbType.VarChar, 10).Value = solicitud.telefonoUsuario;
                        cmd.Parameters.Add("@direccionUsuario", MySqlDbType.VarChar, 500).Value = solicitud.direccionUsuario;
                        cmd.Parameters.Add("@claveUsuario", MySqlDbType.VarChar, 50).Value = "";
                        cmd.Parameters.Add("@vencimientoClave", MySqlDbType.DateTime).Value = DateTime.Today.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@tipoUsuario", MySqlDbType.VarChar, 1).Value = 2;
                        cmd.Parameters.Add("@fechaRegUsuario", MySqlDbType.DateTime).Value = DateTime.Today.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@limiteCreditoUsuario", MySqlDbType.Double, 50).Value = 0;
                        cmd.Parameters.Add("@estadoUsuario", MySqlDbType.Int32).Value = 3;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                    }

                }
                connection.Close();
                return 1;

            }
            catch (Exception e)
            {

                return 0;
            }


        }
    }
}
