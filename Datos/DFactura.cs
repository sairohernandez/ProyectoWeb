using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrograWeb.Modelos;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

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
        public   List<EFacturaDetalle> ObtenerCarrito()
        {

            return new List<EFacturaDetalle>
            {

                  new EFacturaDetalle
                  {
                  codigoDetalle= 1,
                  cantidadDetalle=1,
                  precioDetalle=500000,
                  nombreArticulo="Bisicleta #1"
                  },
                  new EFacturaDetalle
                  {
                  codigoDetalle= 2,
                  cantidadDetalle=2,
                  precioDetalle=1000000,
                  nombreArticulo="Bisicleta #2"
                  }

          };

        }

    public void CalcularTotalFactura(List<EFacturaDetalle> carrito) {


            //EFactura = new EFacturaEncabezado();

            EFactura.LEFacturadetalle = carrito;

            EFactura.totalFactura = 0;

            foreach (EFacturaDetalle linea in EFactura.LEFacturadetalle)
            {
                linea.subtotal = linea.cantidadDetalle * linea.precioDetalle;

                EFactura.totalFactura += linea.subtotal;
            }

        }



        public void GuardarFactura()
        {

            using (connection = new MySqlConnection(myConnectionString))
            {
                connection.Open();

                string sql;

                sql = "INSERT  Factura_Encabezado " +
                      "VALUES(@codigoFactura,@codigoUsuarioFactura,@numeroFactura,@fechaRegFactura,@totalPrecio," +
                      "@totalImpuesto,@totalGarantiaExtendida,@totalFactura,@plazoPaFactura," +
                      "@tazaCreditoFactura,@numeroCuotasAplicadas,@montoCuotaFija,@saldoFactura,@fechaUltimaCuota);";

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@codigoFactura", MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("@codigoUsuarioFactura", MySqlDbType.VarChar, 50).Value = 1;
                    cmd.Parameters.Add("@numeroFactura", MySqlDbType.VarChar, 50).Value = EFactura.numeroFactura;
                    cmd.Parameters.Add("@fechaRegFactura", MySqlDbType.VarChar).Value = DateTime.Today.ToString("yyyy-MM-dd");
                    cmd.Parameters.Add("@totalPrecio", MySqlDbType.DateTime, 50).Value = EFactura.totalPrecio;
                    cmd.Parameters.Add("@totalImpuesto", MySqlDbType.VarChar, 50).Value = EFactura.totalImpuesto;
                    cmd.Parameters.Add("@totalGarantiaExtendida", MySqlDbType.VarChar, 10).Value = 0;
                    cmd.Parameters.Add("@totalFactura", MySqlDbType.VarChar, 500).Value = EFactura.totalFactura;
                    cmd.Parameters.Add("@plazoPaFactura", MySqlDbType.VarChar, 50).Value = EFactura.plazoPaFactura;
                    cmd.Parameters.Add("@tazaCreditoFactura", MySqlDbType.DateTime).Value = DateTime.Today.ToString("yyyy-MM-dd");
                    cmd.Parameters.Add("@numeroCuotasAplicadas", MySqlDbType.VarChar, 1).Value = 0;
                    cmd.Parameters.Add("@montoCuotaFija", MySqlDbType.DateTime).Value = 0;
                    cmd.Parameters.Add("@saldoFactura", MySqlDbType.Double, 50).Value = 0;
                    cmd.Parameters.Add("@fechaUltimaCuota", MySqlDbType.Int32, 50).Value = DateTime.Today.ToString("yyyy-MM-dd");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }


                sql = "INSERT  Factura_Detalle " +
                   "VALUES(@codigoDetalle,@codigoFactura,@codigoArticulo,@cantidadDetalle,@precioDetalle," +
                   "@impuestoDetalle,@plazoGarantiaDetalle,@montoGarantiaDetalle);";

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@codigoDetalle", MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add("@codigoFactura", MySqlDbType.VarChar, 50).Value = 1;
                    cmd.Parameters.Add("@codigoArticulo", MySqlDbType.VarChar, 50).Value = EFactura.numeroFactura;
                    cmd.Parameters.Add("@cantidadDetalle", MySqlDbType.VarChar).Value = DateTime.Today.ToString("yyyy-MM-dd");
                    cmd.Parameters.Add("@precioDetalle", MySqlDbType.DateTime, 50).Value = EFactura.totalPrecio;
                    cmd.Parameters.Add("@impuestoDetalle", MySqlDbType.VarChar, 50).Value = EFactura.totalImpuesto;
                    cmd.Parameters.Add("@plazoGarantiaDetalle", MySqlDbType.VarChar, 10).Value = 0;
                    cmd.Parameters.Add("@montoGarantiaDetalle", MySqlDbType.VarChar, 500).Value = EFactura.totalFactura;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }
                connection.Close();
            }
        }



    }
}