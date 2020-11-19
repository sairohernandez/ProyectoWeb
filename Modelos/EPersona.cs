using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrograWeb.Modelos
{
    public class EPersona
    {
        public int codigoUsuario { get; set; }
        public string identificacionUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidosUsuario { get; set; }
        public string correoUsuario { get; set; }

        public DateTime fechaNacUsuario { get; set; }
        
        public string telefonoUsuario { get; set; }

        public string direccionUsuario { get; set; }

        public string claveUsuario { get; set; }
        public DateTime vencimientoClave { get; set; }
        
        public string tipoUsuario { get; set; }

        public DateTime fechaRegUsuario { get; set; }
        public double limiteCreditoUsuario { get; set; }
        public int estadoUsuario { get; set; }

    }
}