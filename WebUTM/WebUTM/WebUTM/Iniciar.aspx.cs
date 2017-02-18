using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using WebUTM.localhost;
namespace WebUTM.WebUTM
{
    public partial class Iniciar : System.Web.UI.Page
    {
        UsuarioBO usr = new UsuarioBO();
        protected void Page_Load(object sender, EventArgs e)
        {
                try
                {
                    if (Convert.ToInt32(Session["sVali"]) == 1)
                    {
                        usr = (UsuarioBO)Session["sUser"];
                        //lblBienvenido.Text = "Bienvenido " + usr.Nombre + "! Presiona el botón para registrar a tu mascota!";
                    }
                }
                catch
                {
                }         
        }
        WebService servicioWeb = new WebService();
        public int ValidarUsuario()        
        {
            UsuarioBO objUsuario = new UsuarioBO();
            objUsuario.IdUsuario = (txtMatricula.Text);
            objUsuario.Password = txtContraseña.Text;
            return servicioWeb.ValidarUsuario(objUsuario);
        }
        private void Mensaje(string ex)
        {
            string mensaje = ex;
            mensaje = mensaje.Replace(Environment.NewLine, "\\n");
            mensaje = mensaje.Replace("\n", "\\n");
            mensaje = mensaje.Replace("'", "\"");
            ClientScript.RegisterClientScriptBlock(typeof(Page), "Error", "<script> alert('" + mensaje + "');</script>");
        }
        DataTable dt;
        protected void Button1_Click(object sender, EventArgs e)
        {
            int res = ValidarUsuario();
            if (res >= 1)
            {
                UsuarioBO use = new UsuarioBO();
                use.IdUsuario = txtMatricula.Text;
                dt = new DataTable();
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicioWeb.BuscarUsuario(use));
                dt = dataSet.Tables[0];
                DataRow row = dt.Rows[0];
                string tip = row["Tipo_Usuario"].ToString();
                use.Nombre = row["Nombre"].ToString();
                use.ApePat = row["Apellido_Paterno"].ToString();
                use.Password= row["password"].ToString();
                if (row["Apellido_Materno"].ToString() !="")
                {
                    use.ApeMat = row["Apellido_Materno"].ToString();
                }
                Session["sUser"] = use;
                Session["Estado"] = "Codigo";
                Session["sVali"] = 1;
                if (tip == "Administrador")
                {
                    Response.Redirect("../WebUTMAdmin/admin_pub.aspx");
                }
                else
                {
                    Response.Redirect("../WebUTM2/publicaciones2.aspx");
                }
            }
            else
            {
                Mensaje("Matrícula o Contraseña incorrecto. Favor de verificar");
            }
        }
    }
}