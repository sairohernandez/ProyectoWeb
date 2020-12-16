using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrograWeb.Modelos
{
    public class EPagos
    {
        public int codigoPago { get; set; }
        public int codigoFactura { get; set; }
        public DateTime fechaRegPago { get; set; }
        public int numeroCuotaPago { get; set; }
        public int numeroDocumentoPago { get; set; }
        public double montoAmortizacionPago { get; set; }
        public double montoInteresesPago { get; set; }
        public double montoPago { get; set; }
        public DateTime fechaCuotaPago { get; set; }
        public int codigoUsuarioPago { get; set; }

        public double nuevoSaldoCredito { get; set; }
    }
}