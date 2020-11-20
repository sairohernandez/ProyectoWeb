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
            EPersona solicitud = new EPersona();

            solicitud.identificacionUsuario = txtIdentificacion.Text;
            solicitud.nombreUsuario = txtNombre.Text;
            solicitud.apellidosUsuario = txtApellidos.Text;
            solicitud.fechaNacUsuario = DateTime.Parse(txtFechaNacimiento.Text);
            solicitud.direccionUsuario = txtDireccionExacta.Text;
            solicitud.telefonoUsuario = txtTelefono.Text;
            solicitud.correoUsuario = txtCorreo.Text;

            DPersona datosPersona = new DPersona();
            int respuesta = datosPersona.GuardarSolicitudCredito(solicitud);

            if (respuesta == 1)

            {
                string script = "mensajeCorrecto();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else if (respuesta == 3)
            {
                string script = "mensajeExisteRegistro();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

            LimpiarPantalla();
        }

        void LimpiarPantalla()
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccionExacta.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }
    }
}