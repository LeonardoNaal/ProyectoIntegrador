using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using WebUTM.localhost;
namespace WebUTM.WebUTM2
{
    public partial class agregar_pub2 : System.Web.UI.Page
    {
        WebService Servicios = new WebService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataTextField = "NomTipo";
                DropDownList1.DataValueField = "IDTipo";
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(Servicios.TiposPublicaciones());
                DropDownList1.DataSource = dataSet.Tables[0]; ;
                DropDownList1.DataBind();
            }
            if ((String)Session["Estado"] == "Codigo")
            {
                MostrarCodigo();
            }
        }
        UsuarioBO s = new UsuarioBO();
        public string codUser;
        public void MostrarCodigo()
        {
            UsuarioBO objUser = (UsuarioBO)Session["sUser"];
            if (objUser != null)
            {
                codUser = objUser.IdUsuario;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            PublicacionBO objPublicaciones = new PublicacionBO();
            string mensaje = "";
            if (txtDescripcion.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la  descripción \n";
            }
            if (txtTitulo.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el título \n";
            }
            if (DropDownList1.SelectedItem.ToString().Trim().Length == 0)
            {
                mensaje = mensaje + "Selecciona el tipo de publicación \n";
            }
            if (mensaje.Trim().Length == 0)
            {
                objPublicaciones.Contenido = txtDescripcion.Text;
                objPublicaciones.Titulo = txtTitulo.Text;
                objPublicaciones.CodUsuario = codUser;
                objPublicaciones.IdTipo = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
                int i = Servicios.AgregarPublicacion(objPublicaciones);
                if (i == 1)
                {
                    Mensaje("Los datos se agregaron correctamente");
                    Limpiar();
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
        public void Limpiar()
        {
            txtDescripcion.Text = "";
            txtTitulo.Text = "";
            DropDownList1.SelectedIndex = 0;
        }
    }
}