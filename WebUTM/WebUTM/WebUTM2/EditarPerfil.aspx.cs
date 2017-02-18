using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUTM.localhost;
namespace WebUTM.WebUTM2
{
    public partial class EditarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["Estado"] == "Codigo")
            {
                MostrarCodigo();
            }
        }
        public string pass;
        public void MostrarCodigo()
        {
            UsuarioBO objUser = (UsuarioBO)Session["sUser"];
            if (objUser != null)
            {
                txtMatricula.Text = objUser.IdUsuario;
                txtNombre.Text = objUser.Nombre;
                txtApellidoPaterno.Text = objUser.ApePat;
                if (objUser.ApeMat != "")
                {
                    txtApellidoMaterno.Text = objUser.ApeMat;
                }
                pass = objUser.Password;
                lbl.Text = objUser.Nombre;
            }
        }
        private void Mensaje(string ex)
        {
            string mensaje = ex;
            mensaje = mensaje.Replace(Environment.NewLine, "\\n");
            mensaje = mensaje.Replace("\n", "\\n");
            mensaje = mensaje.Replace("'", "\"");
            ClientScript.RegisterClientScriptBlock(typeof(Page), "Error", "<script> alert('" + mensaje + "');</script>");
        }
        WebService servicios = new WebService();
        public void modificar()
        {
            UsuarioBO user = new UsuarioBO();
            string mensaje = "";
            if (txtNombre.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el nombre \n";
            }
            if (txtApellidoPaterno.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el apellido paterno \n";
            }
            if (txtApellidoMaterno.Text.Trim().Length != 0)
            {
                user.ApeMat = txtApellidoMaterno.Text;
                //mensaje = mensaje + "Introduce el apellido materno \n";
            }
            if (txtContraseña.Text.Trim().Length != 0 || txtContraseña2.Text.Trim().Length != 0)
            {
                if (txtContraseña.Text != txtContraseña2.Text)
            {
                mensaje = mensaje + "Favor de verificar la contraseña \n";
            }
                else
                {
                    user.Password = txtContraseña.Text;
                }
            }
            else
            {
                user.Password = pass;
            }
            
            if (mensaje.Trim().Length == 0)
            {
                user.IdUsuario = txtMatricula.Text;
                user.Nombre = txtNombre.Text;
                user.ApePat = txtApellidoPaterno.Text;
                user.CodTipo = 1;
                int i = servicios.modificarUsuario(user);
                if (i == 1)
                {
                    Mensaje("Los datos se modificaron correctamente");
                }
                else
                {
                    Mensaje("Los datos no se modificaron, intenta de nuevo");
                }
            }
            else
            {
                Mensaje(mensaje);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            modificar();
        }
    }
}