﻿using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;
using static EL.Enums;

namespace DinamicWeb
{
    public partial class AdministracionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarSesion();
            if (!IsPostBack)
            {
                cargarGrid();
                cargarDDLRoles();
            }
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
        private void AbandonarSesion(bool MostrarMensaje = true)
        {
            Session.Abandon();
            Session.RemoveAll();
            HttpCookie CookieSesion = new HttpCookie("ASP.NET_SessionId", "");
            Response.Cookies.Add(CookieSesion);
            if (MostrarMensaje)
            {
                Mensaje("Inicie Sesión Nuevamente", eMessage.Info, "Datos de Sesión Incompletos", false, true, true, "/Login.aspx", false);
            }
        }
        private bool ValidarSesion()
        {
            try
            {
                int IdUsuarioGl = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);
                int IdRolGl = (int)General.ValidarEnteros(Session["IdRolGl"]);
                if (!(IdUsuarioGl > 0))
                {
                    AbandonarSesion();
                    return false;
                }

                if (!(IdRolGl > 0))
                {
                    AbandonarSesion();
                    return false;
                }

                Usuarios User = BL_Usuarios.Registro(IdUsuarioGl);
                if (User == null)
                {
                    AbandonarSesion();
                    return false;
                }

                if (User.IdRol != IdRolGl)
                {
                    AbandonarSesion();
                    return false;
                }

                List<RolFormularios> FormulariosUser = BL_RolFormulario.List(IdRolGl);
                if (!(FormulariosUser.Count > 0))
                {
                    AbandonarSesion(false);
                    Mensaje("Estimado usuario, no cuenta con permisos necesarios para ingresar a ningún formulario", eMessage.Info, "", false, true, true, "/Login.aspx", false);
                    return false;
                }
                Session["RolFormulariosGl"] = FormulariosUser;

                List<RolPermisos> PersmisosUser = BL_RolPermisos.List(IdRolGl);
                panelBtnLimpiar.Visible = true;
                panelBtnGuardar.Visible = false;
                panelBtnAnular.Visible = false;

                if (PersmisosUser.Count > 0)
                {
                    foreach (var PermisoUser in PersmisosUser)
                    {
                        if (PermisoUser.IdPermiso == (int)ePermisos.Escritura)
                        {
                            panelBtnGuardar.Visible = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.Anular)
                        {
                            panelBtnAnular.Visible = true;
                        }
                    }
                }
                return true;
            }
            catch
            {
                AbandonarSesion();
                return false;
            }
        }
        private void cargarGrid()
        {
            gridUsuarios.DataSource = BL_Usuarios.vUsuarios();
            gridUsuarios.DataBind();
        }
        private void cargarDDLRoles()
        {
            try
            {
                ddlRol.Items.Clear();
                ddlRol.Items.Insert(0, new ListItem("--Seleccione--"));
                ddlRol.DataSource = BL_Roles.List();
                ddlRol.DataValueField = "IdRol";
                ddlRol.DataTextField = "Rol";
                ddlRol.DataBind();
            }
            catch
            {
                Mensaje("Error al cargar los roles", eMessage.Error);
            }
        }
        private void ResetControles()
        {
            txtNombreCompleto.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            ddlRol.SelectedIndex = 0;
            HF_IdUsuario.Value = "0";
        }
        private bool validarInsertar()
        {
            if (string.IsNullOrEmpty(txtNombreCompleto.Text) || string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                Mensaje("Ingrese el nombre completo del usuario", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                Mensaje("Ingrese el correo del usuario", eMessage.Alerta);
                return false;
            }
            if (!General.CorreoEsValido(txtCorreo.Text))
            {
                Mensaje("Ingrese un correo válido", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                Mensaje("Ingrese el login del usuario", eMessage.Alerta);
                return false;
            }
            if (BL_Usuarios.ExisteUserName(txtLogin.Text))
            {
                Mensaje("El Login ya existe en el sistema.", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                Mensaje("Ingrese la contraseña del usuario", eMessage.Alerta);
                return false;
            }
            if (!General.validarComplejidadPassword(txtContraseña.Text))
            {
                Mensaje(Justify("La contraseña debe cumplir con los siguientes requerimientos mínimos: <ul> <li>Longitud Mínima: 8 caracteres</li> <li> Una letra Mayúscula</li> <li> Una letra Minúscula</li> <li> Un número</li></ul>"), eMessage.Alerta, "", true);
                return false;
            }
            if (ddlRol.SelectedIndex == 0)
            {
                Mensaje("Seleccione el Rol del usuario", eMessage.Alerta);
                return false;
            }

            return true;
        }
        private bool validarActualizar()
        {

            return true;
        }
        private void Guardar()
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);

                if (!(IdUsuarioSistema > 0))
                {
                    Mensaje("Datos del Usuario de sistema no encontrados", eMessage.Alerta);
                    return;
                }

                int IdRegistro = (int)General.ValidarEnteros(HF_IdUsuario.Value);
                if (IdRegistro > 0)
                {
                    //Actualizando
                    return;
                }
                //Insertar
                if (validarInsertar())
                {
                    Usuarios User = new Usuarios();
                    User.NombreCompleto = txtNombreCompleto.Text;
                    User.Correo = txtCorreo.Text;
                    User.UserName = txtLogin.Text;
                    User.Password = BL_Usuarios.Encrypt(txtContraseña.Text);
                    User.IdRol = (int)General.ValidarEnteros(ddlRol.SelectedValue);
                    User.IdUsuarioRegistra = IdUsuarioSistema;

                    if (BL_Usuarios.Insert(User).IdUsuario > 0)
                    {
                        ResetControles();
                        cargarGrid();
                        Mensaje("Registro Guardardo Correctamente", eMessage.Exito);
                        return;
                    }
                    Mensaje("El Registro no se guardo Correctamente", eMessage.Error);
                    return;
                }
                //Mandar Mesaje operacion no realizada
            }
            catch
            {
                //Mandar Mensaje Error
            }

        }
        #endregion

        #region Evento de los Controles
        protected void lnkMostrarPassword_Click(object sender, EventArgs e)
        {
            if (txtContraseña.TextMode == TextBoxMode.SingleLine)
            {
                txtContraseña.TextMode = TextBoxMode.Password;
                iconoVerPassword.Attributes.Remove("fas fa-eye-slash");
                iconoVerPassword.Attributes.Add("class", "fas fa-eye");
                return;
            }
            txtContraseña.TextMode = TextBoxMode.SingleLine;
            iconoVerPassword.Attributes.Remove("fas fa-eye");
            iconoVerPassword.Attributes.Add("class", "fas fa-eye-slash");

        }
        protected void lnkVolver_Click(object sender, EventArgs e)
        {

        }
        protected void lnkLimpiar_Click(object sender, EventArgs e)
        {
            ResetControles();
        }
        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        protected void lnkAnular_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}