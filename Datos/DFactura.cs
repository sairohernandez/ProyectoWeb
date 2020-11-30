using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrograWeb.Modelos;

namespace PrograWeb.Datos
{
    public class DFactura
    {


     public   List<EFacturaDetalle> ObtenerCarrito()
        {

            return new List<EFacturaDetalle>
            {
    
                  new EFacturaDetalle 
                  { 
                  codigoDetalle= 1,
                  cantidadDetalle=1,
                  nombreArticulo="Bisicleta #1"
                  },
                  new EFacturaDetalle
                  {
                  codigoDetalle= 2,
                  cantidadDetalle=2,
                 nombreArticulo="Bisicleta #2"
                  }

          };

        }
    }
}