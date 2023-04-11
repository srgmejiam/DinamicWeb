using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DinamicWeb
{
    public partial class AdministracionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }
        #region Metodos y Funciones
        private void cargarGrid()
        {
            gridUsuarios.DataSource = BL_Usuarios.vUsuarios();
            gridUsuarios.DataBind();
        }
        #endregion
        #region Evento de los Controles

        #endregion
    }
}