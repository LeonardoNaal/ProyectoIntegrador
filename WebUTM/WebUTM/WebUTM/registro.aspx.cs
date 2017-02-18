using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUTM.localhost;
using Newtonsoft.Json;
using System.Data;
namespace WebUTM.WebUTM
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList1.DataTextField = "NomTipo";
                DropDownList1.DataValueField = "CodigoTipo";
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(Servicios.TiposUsuarios());
                DropDownList1.DataSource = dataSet.Tables[0];
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Seleccionar...");
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

        WebService Servicios = new WebService();
        public void Agregar()
        {
          UsuarioBO user = new UsuarioBO();
            string mensaje="";

            if(txtMatricula.Text.Trim().Length==0)
            {
                mensaje = mensaje + "Introduce la Matricula \n";
            }
            if (txtNombre.Text.Trim().Length==0)
            {
                mensaje = mensaje + "Introduce el nombre \n";
            }
            if (txtApellidoPaterno.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el apellido paterno \n";
            }
            if (txtApellidoMaterno.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el apellido materno \n";
            }
            if (txtContraseña.Text.Trim().Length == 0|| txtContraseña2.Text.Trim().Length == 0)
            {
                
                mensaje = mensaje + "Introduce la contraseña \n";
            }
            if (txtContraseña.Text!=txtContraseña2.Text)
            {
                    mensaje = mensaje + "Favor de verificar la contraseña \n";
            }
            if (DropDownList1.SelectedItem.ToString().Trim().Length == 0)
            {
                mensaje = mensaje + "Selecciona el tipo de usuario \n";
            }
            if (mensaje.Trim().Length == 0)
            {
                user.IdUsuario =txtMatricula.Text;
                user.Nombre = txtNombre.Text;
                user.ApePat = txtApellidoPaterno.Text;
                user.ApeMat = txtApellidoMaterno.Text;
                user.Password = txtContraseña.Text;
                user.CodTipo =Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
                int i = Servicios.AgregarUsuario(user);
                if (i == 1)
                {
                    Mensaje("Los datos se agregarón correctamente");
                    limpiar();
                }
                else
                {
                    Mensaje("Los datos no se agregaron, intenta de nuevo");
                }
            }
            else
            {
                Mensaje(mensaje);
            }
        }

        public void limpiar()
        {
            txtMatricula.Text = "";
            txtApellidoMaterno.Text = "";
            txtApellidoPaterno.Text = "";
            txtContraseña.Text = "";
            txtContraseña2.Text = "";
            txtNombre.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int res = Servicios.comprobarExistencia(txtMatricula.Text);
            if (res == 0)
            {
                Agregar();
            }
            else
            {
                Mensaje("Matricula Existente. Favor de verificar");
            }
        }
    }
}