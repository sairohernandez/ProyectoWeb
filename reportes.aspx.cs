using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

using Microsoft.Reporting.WebForms;
namespace PrograWeb
{
    public partial class reportes : System.Web.UI.Page
    {

        MySqlConnection connection;
        string myConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack ) {
               
            }
            
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            reporteVentas();

        }


        void reporteVentas()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter dta;
            DataTable ds;

            sql =   "Select numeroFactura,fechaRegFactura,totalFactura,cantidadDetalle," +
                    "precioDetalle,impuestoDetalle,nombreArticulo from Factura_Encabezado " +
                    "join Factura_Detalle on Factura_Encabezado.codigoFactura = Factura_Detalle.codigoFactura "+
                    "join Articulo on Factura_Detalle.codigoArticulo = Articulo.idArticulo "+
                    "where DATE(fechaRegFactura)    BETWEEN   @fechaIncial AND @fechaFinal; ";

            using (connection = new MySqlConnection(myConnectionString))
            { 

                using (cmd = new MySqlCommand(sql, connection))
                using (dta = new MySqlDataAdapter())
                using (ds = new DataTable())
                {

                    cmd.Parameters.Add("@fechaIncial", MySqlDbType.DateTime).Value = txtFechaInicial.Text;
                    cmd.Parameters.Add("@fechaFinal", MySqlDbType.DateTime).Value = txtFechaFinal.Text;
                    cmd.CommandType = CommandType.Text;
                    dta.SelectCommand = cmd;
                    dta.Fill(ds);
                }

                LocalReport miReporte = new LocalReport();

                //ReportDataSource origenDeDatos = new ReportDataSource("dsVentas", ds);


                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("prmFechaInicial", DateTime.Today.ToString ("dd/MM/yyyy"));
                parameters[1] = new ReportParameter("prmFechaFinal", DateTime.Today.ToString("dd/MM/yyyy"));

                

                //@"F:\Projects\SaleSlip.rdlc"
                miReporte.ReportPath = @"Reportes\reporteVentas.rdlc";


                ReportViewer1.LocalReport.ReportPath = miReporte.ReportPath;
                //ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.SetParameters(parameters);
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsVentas", ds));
          
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
         
            }
        }
    }



}