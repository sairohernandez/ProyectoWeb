﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrograWeb.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace PrograWeb.Datos
{
    public class DFactura
    {
        public EFacturaEncabezado EFactura = new EFacturaEncabezado();
        //public  DFactura (EFacturaEncabezado factura) {

        //       EFactura = factura;

        //   }

        MySqlConnection connection;
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public List<EFacturaDetalle> ObtenerCarrito()
        {

            return new List<EFacturaDetalle>
            {

                  new EFacturaDetalle
                  {
                  codigoDetalle= 1,
                  codigoArticulo= 1,
                  cantidadDetalle=1,
                  precioDetalle=500000,
                  nombreArticulo="Bisicleta #1"
                  },
                  new EFacturaDetalle
                  {
                  codigoDetalle= 2,
                  codigoArticulo=2,
                  cantidadDetalle=2,
                  precioDetalle=1000000,
                  nombreArticulo="Bisicleta #2"
                  }

          };

        }

        public void CalcularTotalFactura(List<EFacturaDetalle> carrito)
        {


            //EFactura = new EFacturaEncabezado();

            EFactura.LEFacturadetalle = carrito;

            EFactura.totalFactura = 0;

            EFactura.totalPrecio = 0;

            EFactura.totalImpuesto = 0;

            foreach (EFacturaDetalle linea in EFactura.LEFacturadetalle)
            {
                linea.subtotal = linea.cantidadDetalle * linea.precioDetalle;

                EFactura.totalFactura += linea.subtotal;
            }

        }



        public bool GuardarFactura() 
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




                    sql = " update Consecutivos set ultimoconsecutivo = ultimoconsecutivo + 1 where codigoConsecutivo  = 1; \n" +
                        "Select ultimoconsecutivo  from Consecutivos where codigoConsecutivo  = 1;";
                   
                    using (cmd = new MySqlCommand(sql, connection))
                    using (dta = new MySqlDataAdapter())
                    using (ds = new DataTable())
                    {
                        cmd.CommandType = CommandType.Text; 
                        dta.SelectCommand = cmd;
                        dta.Fill(ds);

                      
                        EFactura.numeroFactura ="9990000101" + Convert.ToInt32(ds.Rows[0][0]).ToString("0000000000");
                    }


                    sql = "INSERT  Factura_Encabezado " +
                          "VALUES(@codigoFactura,@codigoUsuarioFactura,@numeroFactura,@fechaRegFactura,@totalPrecio," +
                          "@totalImpuesto,@totalGarantiaExtendida,@totalFactura,@plazoPaFactura," +
                          "@tazaCreditoFactura,@numeroCuotasAplicadas,@montoCuotaFija,@saldoFactura,@fechaUltimaCuota);";
                     

                    using (cmd = new MySqlCommand(sql, connection))
           
                    {
                        cmd.Parameters.Add("@codigoFactura", MySqlDbType.Int32).Value = 0;
                        cmd.Parameters.Add("@codigoUsuarioFactura", MySqlDbType.Int32).Value = 1;
                        cmd.Parameters.Add("@numeroFactura", MySqlDbType.VarChar, 50).Value = EFactura.numeroFactura;
                        cmd.Parameters.Add("@fechaRegFactura", MySqlDbType.DateTime).Value = DateTime.Today.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@totalPrecio", MySqlDbType.Double).Value = EFactura.totalPrecio;
                        cmd.Parameters.Add("@totalImpuesto", MySqlDbType.Double).Value = EFactura.totalImpuesto;
                        cmd.Parameters.Add("@totalGarantiaExtendida", MySqlDbType.Double).Value = 0;
                        cmd.Parameters.Add("@totalFactura", MySqlDbType.Double).Value = EFactura.totalFactura;
                        cmd.Parameters.Add("@plazoPaFactura", MySqlDbType.Int32).Value = 30; //30 Dias por defecto
                        cmd.Parameters.Add("@tazaCreditoFactura", MySqlDbType.Int32).Value = 2;
                        cmd.Parameters.Add("@numeroCuotasAplicadas", MySqlDbType.Int32).Value = 0;
                        cmd.Parameters.Add("@montoCuotaFija", MySqlDbType.Double).Value = 0;
                        cmd.Parameters.Add("@saldoFactura", MySqlDbType.Double, 50).Value = 0;
                        cmd.Parameters.Add("@fechaUltimaCuota", MySqlDbType.DateTime).Value = DateTime.Today.ToString("yyyy-MM-dd");
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                    }


                    sql = " Select max(codigoFactura) as id from Factura_Encabezado;";
                    using (cmd = new MySqlCommand(sql, connection))
                    using (dta = new MySqlDataAdapter())
                    using (ds = new DataTable())
                    {
                        cmd.CommandType = CommandType.Text;
                        dta.SelectCommand = cmd;
                        dta.Fill(ds);
                    }



                    sql = "INSERT  Factura_Detalle " +
                    "VALUES(@codigoDetalle,@codigoFactura,@codigoArticulo,@cantidadDetalle,@precioDetalle," +
                    "@impuestoDetalle,@plazoGarantiaDetalle,@montoGarantiaDetalle);";

                    foreach (EFacturaDetalle linea in EFactura.LEFacturadetalle)
                    {
                        using (cmd = new MySqlCommand(sql, connection))
                        {
                           
                            cmd.Parameters.Add("@codigoDetalle", MySqlDbType.Int32).Value = 0;
                            cmd.Parameters.Add("@codigoFactura", MySqlDbType.Int32).Value = (int)ds.Rows[0][0];
                            cmd.Parameters.Add("@codigoArticulo", MySqlDbType.Int32).Value = linea.codigoArticulo;
                            cmd.Parameters.Add("@cantidadDetalle", MySqlDbType.Double).Value = linea.cantidadDetalle;
                            cmd.Parameters.Add("@precioDetalle", MySqlDbType.Double).Value = linea.precioDetalle;
                            cmd.Parameters.Add("@impuestoDetalle", MySqlDbType.Double).Value = linea.impuestoDetalle;
                            cmd.Parameters.Add("@plazoGarantiaDetalle", MySqlDbType.Int32).Value = 0;
                            cmd.Parameters.Add("@montoGarantiaDetalle", MySqlDbType.Int32).Value = 0;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                        }
                    }

                    connection.Close();
                }


                return true;
            }

            catch (Exception ex)
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Append text to an existing file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "LogPrograWeb.txt"), true))
                {
                    outputFile.WriteLine("Error. Fecha y Hora: " + DateTime.Today.ToString() + " "   + ex.Message);
                }
                return false;
            }
        }


    }
}