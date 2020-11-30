using System;
namespace PrograWeb.Modelos
{
    public class EArticulo
    {
        public int idArticulo { get; set; }
        public string skuArticulo { get; set; }
        public string nombreArticulo { get; set; }
        public double cantidadArticulo { get; set; }
        public string descripcionArticulo { get; set; }
        public int codigoMarca { get; set; }
        public string categoriaArticulo { get; set; }
        public double precioArticulo { get; set; }
        public double porcentajeImpuesto { get; set; }
        public string rutaImagen { get; set; }
    }
}
