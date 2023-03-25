using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL;
using BL;
using static EL.Enums;
using System.Text;

namespace DinamicWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Metodos y Funciones
        private void Mensaje(string Message, eMessage tipoMensaje, string Encabezado = "", bool Html = false, bool Fondo = false, bool returnLogin = false, string UrlReturn = "", bool CerrarClick = true)
        {
            //icon -->      success,warning, error,  info
            //btnColor -->  #32A525,#E38618,#F27474,#3FC3EE

            //Parametros que recibe el metodo
            //function Mensaje(title, mensaje, icon = 'success', btnConfirmText = 'Aceptar', btnConfirmColor = '#32A525', html = false, fondo = false, ReturnLogin = false, UrlReturn)

            switch (tipoMensaje)
            {
                case eMessage.Exito:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Exito", "Mensaje('" + Encabezado + "', '" + Message + "','success','Aceptar','#32A525'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Alerta:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Alerta", "Mensaje('" + Encabezado + "', '" + Message + "','warning','Aceptar','#E38618'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Error:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Error", "Mensaje('" + Encabezado + "', '" + Message + "','error','Aceptar','#F27474'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Info:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Info", "Mensaje('" + Encabezado + "', '" + Message + "','info','Aceptar','#3FC3EE'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
            }
        }
        private string Justify(string msj)
        {
            string Html = "<div style = text-align:justify> " + msj + " </div>";
            return Html;
        }
        private bool ValidarAcceso()
        {
            if(string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Mensaje("Ingrese el usuario", eMessage.Alerta);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Mensaje("Ingrese la contraseña", eMessage.Alerta);
                return false;
            }
            if(!BL_Usuarios.ExisteUserName(txtUsuario.Text))
            {
                Mensaje("Credenciales incorrectas", eMessage.Alerta);
                return false;
            }

            if(BL_Usuarios.VerificarCuentaBloqueada(txtUsuario.Text))
            {
                Mensaje("Su cuenta a sido bloqueada por multiples intentos fallidos de iniciar sesión.", eMessage.Error);
                return false;
            }

            byte[] Pass = BL_Usuarios.Encrypt(txtPassword.Text);
            if (!BL_Usuarios.ValidarCredenciales(txtUsuario.Text,Pass))
            {
                Mensaje(Justify("Credenciales incorrectas, si supera 3 intentos fallidos de inicio de sesión, su cuenta será bloqueada"), eMessage.Alerta,"",true);
                Usuarios User = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
                if(User.IntentosFallidos >= 2)
                {
                    BL_Usuarios.BloquearCuentaUsuario(User.IdUsuario,true,User.IdUsuario);
          
                }
                
                if(User!= null)
                {
                    BL_Usuarios.SumarIntentosFallido(User.IdUsuario);
                }
                return false;               
            }

            Usuarios UserVerificado = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
            if(UserVerificado!= null)
            {
                if (UserVerificado.IntentosFallidos > 0)
                {
                    BL_Usuarios.RestablecerIntentosFallido(UserVerificado.IdUsuario, UserVerificado.IdUsuario);
                }   

                Session["IdUsuario"] = UserVerificado.IdUsuario;
                Session["IdRol"] = UserVerificado.IdRol;
                Session["NombreCompleto"] = UserVerificado.NombreCompleto;
                Session["Correo"] = UserVerificado.Correo;
                Session["UserName"] = UserVerificado.UserName;
                //Redireccionar
                Response.Redirect("~/Principal.aspx");
            }  

            return true;    
        }
        #endregion

        #region Evento de los Controles
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarAcceso())
            {

            }
        }
        #endregion


    }
}