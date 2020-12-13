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
    public partial class activarnuevoscreditos : System.Web.UI.Page
    {

        DPersona DatosPersona = new DPersona();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                visualizarSolicitudes();
            }
        }

        void visualizarSolicitudes() {
            GridView1.DataSource = DatosPersona.ObtieneSolicitudesNuevas();
            GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Aprobar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[rowIndex];

                DatosPersona.procesarEvalucionCredito(1, Convert.ToInt32(row.Cells[0].Text));

                visualizarSolicitudes();
            }
            else if (e.CommandName == "Rechazar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[rowIndex];

                DatosPersona.procesarEvalucionCredito(2, Convert.ToInt32(row.Cells[0].Text));

                visualizarSolicitudes();
            }
        }
        }
    }