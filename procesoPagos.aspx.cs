using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrograWeb.Datos;
using PrograWeb.Modelos;

namespace PrograWeb
{
    public partial class procesoPagos : System.Web.UI.Page
    {

        DPagos dpagos;
        List<EFacturaEncabezado> listaCreditos = new List<EFacturaEncabezado>();
        List<EPagos> listaPagos = new List<EPagos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int a;
        }

        public void CargarPrestamos()
        {


            dpagos = new DPagos();
            int codigoUsuario = dpagos.buscaUsuarioPorIndentificacion(txtIdentificacion.Text);
            cmbPrestamos.Items.Clear();
            if (codigoUsuario > 0)
            {
                listaCreditos = dpagos.ObtieneCreditosPendientes(codigoUsuario);
                Session["prestamos"] = listaCreditos;
                cmbPrestamos.DataSource = Session["prestamos"];
                cmbPrestamos.DataBind();
                cmbPrestamos.DataTextField = "numeroFactura";
                cmbPrestamos.DataValueField = "codigoFactura";
                cmbPrestamos.DataBind();
                cmbPrestamos.SelectedIndex = 0;
            }
        }




        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            CargarPrestamos();
            calculaCuotras();
        }

        public void CalculaTotalPago()
        {
            double totalAmortizacion = 0;
            double totalIntereses = 0;
            double totalPago = 0;

            foreach (EPagos pago in listaPagos)
            {
                totalAmortizacion += pago.montoAmortizacionPago;
                totalIntereses += pago.montoInteresesPago;
                totalPago += pago.montoPago;
            }
            lblTotalAmortizacion.Text = totalAmortizacion.ToString("C2");
            lblTotalIntereses.Text = totalIntereses.ToString("C2");
            lblTotalPago.Text = totalPago.ToString("C2");
        }

        protected void cmbPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {


            calculaCuotras();

        }

        void calculaCuotras()
        {

            if (cmbPrestamos.Items.Count > 0)
            {


                int valorNumerico = 0;

                if (int.TryParse(txtNumeroCuotas.Text, out valorNumerico))
                {

                    dpagos = new DPagos();
                    listaCreditos = (List<EFacturaEncabezado>)Session["prestamos"];

                    if (Convert.ToInt32(txtNumeroCuotas.Text) > listaCreditos[cmbPrestamos.SelectedIndex].plazoPaFactura - listaCreditos[cmbPrestamos.SelectedIndex].numeroCuotasAplicadas)

                    {
                        string script = "validacionCantidadCuotas();";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    }
                    else
                    {

                        if (listaCreditos.Count > 0)
                        {

                            listaPagos = dpagos.CalculaPagos(listaCreditos[cmbPrestamos.SelectedIndex], Convert.ToInt32(txtNumeroCuotas.Text));
                            CalculaTotalPago();
                            lblSaldoCuotas.Text = (listaCreditos[cmbPrestamos.SelectedIndex].plazoPaFactura - listaCreditos[cmbPrestamos.SelectedIndex].numeroCuotasAplicadas).ToString();
                            lblSaldoFactura.Text = listaCreditos[cmbPrestamos.SelectedIndex].saldoFactura.ToString("C2");
                            lblFechaUltimaCuota.Text = listaCreditos[cmbPrestamos.SelectedIndex].fechaUltimaCuota.ToString("dd/MM/yyyy");
                            lblFechaVencimiento.Text = listaCreditos[cmbPrestamos.SelectedIndex].fechaRegFactura.AddMonths(listaCreditos[cmbPrestamos.SelectedIndex].plazoPaFactura).ToString("dd/MM/yyyy");

                            Session["pagos"] = listaPagos;
                        }
                    }
                }
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            dpagos = new DPagos();
            listaCreditos = (List<EFacturaEncabezado>)Session["prestamos"];
            listaPagos = (List<EPagos>)Session["pagos"];
            if (dpagos.GuardarPagos(listaCreditos[cmbPrestamos.SelectedIndex], listaPagos,Convert.ToInt32(txtNumeroCuotas.Text)))
            {
                string script = "mensajePagoOk();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
              
                LimpiarInterfaz();
            }
            else
            {
                string script = "mensajeError();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        void LimpiarInterfaz()
        {
            //txtIdentificacion.Text = "";
            lblTotalAmortizacion.Text = "";
            lblTotalIntereses.Text = "";
            lblTotalPago.Text = "";
            cmbPrestamos.Items.Clear();
            cmbPrestamos.DataSource = null;
            lblSaldoFactura.Text = "";
            lblFechaUltimaCuota.Text = "";
            lblFechaVencimiento.Text = "";
            Session["prestamos"] = null;
            Session["pagos"] = null;
        }

        protected void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            LimpiarInterfaz();
        }

        protected void txtNumeroCuotas_TextChanged(object sender, EventArgs e)
        {
            calculaCuotras();
        }
    }
}