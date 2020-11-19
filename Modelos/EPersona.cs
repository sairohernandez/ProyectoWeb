using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrograWeb.Modelos
{
    public class EPersona
    {
        public int codigoUsuario { get; set; }
        public int identificacionUsuario { get; set; }
        public int nombreUsuario { get; set; }
        public int apellidosUsuario { get; set; }
        public int correoUsuario { get; set; }

        public int fechaNacUsuario { get; set; }
        
        public string telefonoUsuario { get; set; }

        public int direccionUsuario { get; set; }

        public int claveUsuario { get; set; }
        public int vencimientoClave { get; set; }
        
        public int tipoUsuario { get; set; }

        public int fechaRegUsuario { get; set; }
        public int limiteCreditoUsuario { get; set; }
        public int estadoUsuario { get; set; }

    }
}