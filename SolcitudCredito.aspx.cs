using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrograWeb.Modelos;
using PrograWeb.Datos;

namespace PrograWeb
{
    public partial class SolcitudCredito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
          //  EPersona solicitud = new EPersona ();
           
          //  solicitud.identificacionUsuario = txtIdentificacion.Text;
          //  solicitud.nombreUsuario = txtNombre.Text;
          //  solicitud.apellidosUsuario = txtApellidos.Text;
          //  solicitud.fechaNacUsuario = DateTime.Parse(txtFechaNacimiento.Text);
          //  solicitud.direccionUsuario = txtDireccionExacta.Text;
          //  solicitud.telefonoUsuario = txtTelefono.Text;
          //  solicitud.correoUsuario = txtCorreo.Text;

          //  DPersona datosPersona = new DPersona();
          //if   (datosPersona.GuardarSolicitudCredito(solicitud))

          //  {
                string script = "myFuncionAlerta();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            //}
                
        }
    }
}