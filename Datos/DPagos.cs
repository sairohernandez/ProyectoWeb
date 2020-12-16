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
        void CalculaPagos(EFacturaEncabezado prestamo)
        {


            DateTime proximFechaPago = prestamo.fechaUltimaCuota;
            double nuevoSaldo = prestamo.saldoFactura;



            for (int contador = prestamo.numeroCuotasAplicadas; contador < prestamo.plazoPaFactura; contador++)
            {
                Epagos = new EPagos();
                Epagos.numeroDocumentoPago = 0;
                Epagos.numeroCuotaPago += 1;
                Epagos.montoAmortizacionPago = (((prestamo.montoCuotaFija * (30 / (prestamo.tasaCreditoFactura / 100))) - (prestamo.saldoFactura * 30)) / (30 / (prestamo.tasaCreditoFactura / 100)));
                Epagos.montoInteresesPago = prestamo.saldoFactura * (prestamo.tasaCreditoFactura / 100);
                Epagos.montoPago = Epagos.montoAmortizacionPago + Epagos.montoInteresesPago;
                proximFechaPago.AddMonths(1);
                Epagos.fechaCuotaPago = proximFechaPago;

                nuevoSaldo = nuevoSaldo = Epagos.montoAmortizacionPago;

                prestamo.fechaUltimaCuota = proximFechaPago; //Actualiza ultima fecha de pago factura
                prestamo.saldoFactura = nuevoSaldo;          //Actualiza saldo de la factura

                Epagos.nuevoSaldoCredito = nuevoSaldo;


            }
        }
        bool GuardarPagos(EFacturaEncabezado prestamo, List<EPagos> pagos)
        {

            try
            {
                using (connection = new MySqlConnection(myConnectionString))
                {
                    connection.Open();

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
                            cmd.CommandType = CommandType.Text;
                            dta.SelectCommand = cmd;
                            dta.Fill(ds);


                            linea.numeroDocumentoPago = Convert.ToInt32(ds.Rows[0][0]);
                        }


                        sql = "INSERT  Factura_Encabezado " +
                              "VALUES(@codigoPago,@codigoFactura,@fechaRegPago,@numeroCuotaPago,@numeroDocumentoPago," +
                              "@montoAmortizacionPago,@montoInteresesPago,@montoPago,@fechaCuotaPago," +
                              "@codigoUsuarioPago,@nuevoSaldoCredito);";


                        using (cmd = new MySqlCommand(sql, connection))

                        {

                            cmd.Parameters.Add("@codigoPago", MySqlDbType.Int32).Value = 0;
                            cmd.Parameters.Add("@codigoFactura", MySqlDbType.Int32).Value = linea.codigoFactura;
                            cmd.Parameters.Add("@fechaRegPago", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            cmd.Parameters.Add("@numeroCuotaPago", MySqlDbType.Int32).Value = linea.numeroCuotaPago;
                            cmd.Parameters.Add("@numeroDocumentoPago", MySqlDbType.VarChar, 50).Value = linea.numeroDocumentoPago;
                            cmd.Parameters.Add("@montoAmortizacionPago", MySqlDbType.Double).Value = linea.montoAmortizacionPago;
                            cmd.Parameters.Add("@montoInteresesPago", MySqlDbType.Double).Value = linea.montoInteresesPago;
                            cmd.Parameters.Add("@montoPago", MySqlDbType.Double).Value = linea.montoPago;
                            cmd.Parameters.Add("@fechaCuotaPago", MySqlDbType.DateTime).Value = DateTime.Today.ToString("yyyy-MM-dd");
                            cmd.Parameters.Add("@codigoUsuarioPago", MySqlDbType.Int32).Value = 0;//Convert.ToInt32(Session["codigoUsuario"]);
                            cmd.Parameters.Add("@nuevoSaldoCredito", MySqlDbType.Double).Value = linea.nuevoSaldoCredito;

                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                        }

                    }
                    //Actualizar los datos de la factura


                    sql = "UPDATE   Factura_Encabezado SET fechaUltimaCuota = @fechaUltimaCuota, saldoFactura = @saldoFactura " +
                         "WHERE codigoFactura =  @codigoFactura;";


                    using (cmd = new MySqlCommand(sql, connection))

                    {

                        cmd.Parameters.Add("@codigoFactura", MySqlDbType.Int32).Value = prestamo.codigoFactura;
                        cmd.Parameters.Add("@fechaUltimaCuota", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        cmd.Parameters.Add("@saldoFactura", MySqlDbType.Double).Value = prestamo.saldoFactura;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                    }

                    connection.Close();
                }


                return true;
            }

            catch (Exception ex)
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Agregar texto a la bitacora
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "LogPrograWeb.txt"), true))
                {
                    outputFile.WriteLine("Error. Fecha y Hora: " + DateTime.Now.ToString() + " " + ex.Message);
                }
                return false;
            }

        }


        List<EFacturaEncabezado> ObtieneCreditosPendientes(int codigoCliente)
        {

            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter dta;
            DataTable ds;
            EFacturaEncabezado factura;
            List<EFacturaEncabezado> listaFactura;


            sql = " select codigoFactura,numeroFactura,fechaUltimaCuota, saldoFactura " +
                           " where codigoFactura  = @codigoUsuario;";

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
                    for (int contador = 0; contador < ds.Rows.Count - 1; contador++)
                    {

                        factura = new EFacturaEncabezado();
                        factura.codigoFactura = Convert.ToInt32(ds.Rows[contador]["codigoFactura"]);
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


    }
}