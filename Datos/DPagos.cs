using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrograWeb.Datos;
using PrograWeb.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.IO;


namespace PrograWeb.Datos
{


    public class DPagos
    {
        EPagos Epagos;

        MySqlConnection connection;
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public List<EPagos> CalculaPagos(EFacturaEncabezado prestamo, int numeroPagos)
        {


            DateTime proximFechaPago = prestamo.fechaUltimaCuota;
            double nuevoSaldo = prestamo.saldoFactura;


            List<EPagos> listaPagos = new List<EPagos>();

            for (int contador = prestamo.numeroCuotasAplicadas; contador < (prestamo.numeroCuotasAplicadas+ numeroPagos); contador++)
            {
                Epagos = new EPagos();
                Epagos.numeroDocumentoPago = 0;
                Epagos.numeroCuotaPago += 1;
                Epagos.montoAmortizacionPago = (((prestamo.montoCuotaFija * (30 / (prestamo.tasaCreditoFactura / 100))) - (nuevoSaldo * 30)) / (30 / (prestamo.tasaCreditoFactura / 100)));
                Epagos.montoInteresesPago = nuevoSaldo * (prestamo.tasaCreditoFactura / 100);
                Epagos.montoPago = Epagos.montoAmortizacionPago + Epagos.montoInteresesPago;
                proximFechaPago=proximFechaPago.AddMonths(1);
                Epagos.fechaCuotaPago = proximFechaPago;

                nuevoSaldo  -= Epagos.montoAmortizacionPago;

                Epagos.nuevoSaldoCredito = nuevoSaldo;

                listaPagos.Add(Epagos);
            }
            return listaPagos;
        }
       public bool GuardarPagos(EFacturaEncabezado prestamo, List<EPagos> pagos, int cuotasAplicadas,int codigoUsuario)
        {
            MySqlTransaction transaccion;
            try
            {
                using (connection = new MySqlConnection(myConnectionString))
                {
                    connection.Open();

                    transaccion = connection.BeginTransaction();

                    string sql;
                    MySqlCommand cmd;
                    MySqlDataAdapter dta;
                    DataTable ds;

                    foreach (EPagos linea in pagos)
                    {

                        //Actualizar consecutivos de recibos
                        sql = " update Consecutivos set ultimoconsecutivo = ultimoconsecutivo + 1 where codigoConsecutivo  = 2; \n" +
                            "Select ultimoconsecutivo  from Consecutivos where codigoConsecutivo  = 2;";

                        using (cmd = new MySqlCommand(sql, connection))
                        using (dta = new MySqlDataAdapter())
                        using (ds = new DataTable())
                        {
                            cmd.Transaction = transaccion;
                            cmd.CommandType = CommandType.Text;
                            dta.SelectCommand = cmd;
                            dta.Fill(ds);


                            linea.numeroDocumentoPago = Convert.ToInt32(ds.Rows[0][0]);
                        }


                        sql = "INSERT Pagos " +
                              "VALUES(@codigoPago,@codigoFactura,@fechaRegPago,@numeroCuotaPago,@numeroDocumentoPago," +
                              "@montoAmortizacionPago,@montoInteresesPago,@montoPago,@fechaCuotaPago," +
                              "@codigoUsuarioPago,@nuevoSaldoCredito);";


                        using (cmd = new MySqlCommand(sql, connection))

                        {
                            cmd.Transaction = transaccion;
                            cmd.Parameters.Add("@codigoPago", MySqlDbType.Int32).Value = 0;
                            cmd.Parameters.Add("@codigoFactura", MySqlDbType.Int32).Value = prestamo.codigoFactura;
                            cmd.Parameters.Add("@fechaRegPago", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            cmd.Parameters.Add("@numeroCuotaPago", MySqlDbType.Int32).Value = linea.numeroCuotaPago;
                            cmd.Parameters.Add("@numeroDocumentoPago", MySqlDbType.VarChar, 50).Value = linea.numeroDocumentoPago;
                            cmd.Parameters.Add("@montoAmortizacionPago", MySqlDbType.Double).Value = linea.montoAmortizacionPago;
                            cmd.Parameters.Add("@montoInteresesPago", MySqlDbType.Double).Value = linea.montoInteresesPago;
                            cmd.Parameters.Add("@montoPago", MySqlDbType.Double).Value = linea.montoPago;
                            cmd.Parameters.Add("@fechaCuotaPago", MySqlDbType.DateTime).Value = linea.fechaCuotaPago.ToString("yyyy-MM-dd");
                            cmd.Parameters.Add("@codigoUsuarioPago", MySqlDbType.Int32).Value = codigoUsuario;//Convert.ToInt32(Session["codigoUsuario"]);
                            cmd.Parameters.Add("@nuevoSaldoCredito", MySqlDbType.Double).Value = linea.nuevoSaldoCredito;

                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                        }

                    }
                    //Actualizar los datos de la factura


                    sql = "UPDATE   Factura_Encabezado SET fechaUltimaCuota = @fechaUltimaCuota, saldoFactura = @saldoFactura, numeroCuotasAplicadas = numeroCuotasAplicadas + @numeroCuotasAplicadas " +
                         "WHERE codigoFactura =  @codigoFactura;";


                    using (cmd = new MySqlCommand(sql, connection))

                    {
                        cmd.Transaction = transaccion;
                        cmd.Parameters.Add("@codigoFactura", MySqlDbType.Int32).Value = prestamo.codigoFactura;
                        cmd.Parameters.Add("@fechaUltimaCuota", MySqlDbType.DateTime).Value = pagos[pagos.Count-1].fechaCuotaPago.ToString("yyyy-MM-dd hh:mm:ss");
                        cmd.Parameters.Add("@saldoFactura", MySqlDbType.Double).Value = pagos[pagos.Count - 1].nuevoSaldoCredito;
                        cmd.Parameters.Add("@numeroCuotasAplicadas", MySqlDbType.Int32).Value = cuotasAplicadas;
                     

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                    }
                    transaccion.Commit();
                    connection.Close();
                }


                return true;
            }

            catch (Exception ex)
            {

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Agregar texto a la bitacora
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "LogPrograWeb.txt"), true))
                {
                    outputFile.WriteLine("Error. Fecha y Hora: " + DateTime.Now.ToString() + " " + ex.Message);
                }
                return false;
            }

        }


        public List<EFacturaEncabezado> ObtieneCreditosPendientes(int codigoCliente)
        {

            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter dta;
            DataTable ds;
            EFacturaEncabezado factura;
            List<EFacturaEncabezado> listaFactura;


            sql = " select codigoFactura,codigoUsuarioFactura,numeroFactura,fechaRegFactura,montoCuotaFija,tasaCreditoFactura,fechaUltimaCuota,plazoPaFactura,numeroCuotasAplicadas, saldoFactura " +
                           " from Factura_Encabezado where codigoUsuarioFactura = @codigoUsuario and saldoFactura > 0;";

            using (cmd = new MySqlCommand(sql, connection))
            using (dta = new MySqlDataAdapter())
            using (ds = new DataTable())
            {
                cmd.Parameters.Add("@codigoUsuario", MySqlDbType.Int32).Value = codigoCliente;
                cmd.CommandType = CommandType.Text;
                dta.SelectCommand = cmd;
                dta.Fill(ds);

                if (ds.Rows.Count > 0)
                {
                    listaFactura = new List<EFacturaEncabezado>();
                    for (int contador = 0; contador <= ds.Rows.Count - 1; contador++)
                    {

                        factura = new EFacturaEncabezado();
                        factura.codigoFactura = Convert.ToInt32(ds.Rows[contador]["codigoFactura"]);
                        factura.codigoUsuarioFactura = Convert.ToInt32(ds.Rows[contador]["codigoUsuarioFactura"]);
                        factura.fechaRegFactura = Convert.ToDateTime(ds.Rows[contador]["fechaRegFactura"]);
                        factura.montoCuotaFija = Convert.ToDouble(ds.Rows[contador]["montoCuotaFija"]);
                        factura.tasaCreditoFactura = Convert.ToInt32(ds.Rows[contador]["tasaCreditoFactura"]);
                        factura.plazoPaFactura = Convert.ToInt32(ds.Rows[contador]["plazoPaFactura"]);
                        factura.numeroCuotasAplicadas = Convert.ToInt32(ds.Rows[contador]["numeroCuotasAplicadas"]);
                        factura.numeroFactura = Convert.ToString(ds.Rows[contador]["numeroFactura"]);
                        factura.saldoFactura = Convert.ToDouble(ds.Rows[contador]["saldoFactura"]);
                        factura.fechaUltimaCuota = Convert.ToDateTime(ds.Rows[contador]["fechaUltimaCuota"]);
                        listaFactura.Add(factura);
                    }
                    return listaFactura;
                }
                else
                { return null; }

            }


        }


        public int buscaUsuarioPorIndentificacion(string identificacion)
        {

            using (connection = new MySqlConnection(myConnectionString))
            {
                string sql;
                MySqlCommand cmd;
                MySqlDataAdapter dta;
                DataTable ds;

                sql = "select codigoUsuario,nombreUsuario from Usuarios where identificacionUsuario = @identificacionUsuario  and estadoUsuario = 1";

                using (cmd = new MySqlCommand(sql, connection))
                using (dta = new MySqlDataAdapter())
                using (ds = new DataTable())
                {
                    cmd.Parameters.Add("@identificacionUsuario", MySqlDbType.String).Value = identificacion;
                    cmd.CommandType = CommandType.Text;
                    dta.SelectCommand = cmd;
                    dta.Fill(ds);
                    if (ds.Rows.Count > 0)
                    {
                        return Convert.ToInt32(ds.Rows[0]["codigoUsuario"]);
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
        }

      

    }
}