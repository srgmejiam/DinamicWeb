using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DinamicWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkNombreSitio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }
        protected void lnkInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }
        protected void lnkFormulario_1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Formulario_1.aspx");
        }
        protected void lnkFormulario_2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Formulario_2.aspx");
        }
        protected void lnkFormulario_3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Formulario_3.aspx");
        }
        protected void lnkFormulario_4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Formulario_4.aspx");
        }
    }
}