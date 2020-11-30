﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrograWeb.Modelos
{
    public class EFacturaEncabezado
    {
        public int codigoFactura { get; set; }
        public int codigoUsuarioFactura { get; set; }
        public string numeroFactura { get; set; }
        public string fechaRegFactura { get; set; }
        public double totalPrecio { get; set; }
        public double totalImpuesto { get; set; }
        public double totalGarantiaExtendida { get; set; }
        public double totalFactura { get; set; }
        public int plazoPaFactura { get; set; }
        public double tazaCreditoFactura { get; set; }
        public double numeroCuotasAplicadas { get; set; }
        public double montoCuotaFija { get; set; }
        public double saldoFactura { get; set; }
        public DateTime fechaUltimaCuota { get; set; }
        public List<EFacturaDetalle> LEFacturadetalle { get; set; }
    }
}