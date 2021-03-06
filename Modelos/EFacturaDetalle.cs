﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrograWeb.Modelos
{
    public class EFacturaDetalle
    {

        public int codigoDetalle { get; set; }
        //public int codigoFactura { get; set; }
        //public EArticulo  EArticulo { get; set; }

        public int codigoArticulo { get; set; }
        public string nombreArticulo { get; set; }
        public double cantidadDetalle { get; set; }
        public double precioDetalle { get; set; }
        public double impuestoDetalle { get; set; } //Para totalizar el monto de impuesto de linea
        public int plazoGarantiaDetalle { get; set; }
        public double montoGarantiaDetalle { get; set; }

        public double porcentajeImpuesto { get; set; } //porcentaje de impuesto que paga el articulo
        public double subtotal { get; set; } //Para totalizar el detalle
        public string  rutaImagen { get; set; }
    }
}