using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUTM.localhost;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using System.IO;
namespace WebUTM.WebUtmAdmin
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataTextField = "NomTipo";
                DropDownList1.DataValueField = "CodigoTipo";
                DataSet dataSetTipos = JsonConvert.DeserializeObject<DataSet>(Servicios.TiposUsuariosAdmin());
                DropDownList1.DataSource = dataSetTipos.Tables[0];
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0,"Seleccionar...");
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(Servicios.Usuarios());
                GridView1.DataSource = dataSet.Tables[0]; 
                GridView1.DataBind();
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
        public object Datos()
        {
            UsuarioBO user = new UsuarioBO();
            string mensaje = "";
            if (txtMatricula.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la Matrícula \n";
            }
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
            }
            if (txtContraseña.Text.Trim().Length == 0 || txtContraseña2.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la contraseña \n";
            }
            if (txtContraseña.Text != txtContraseña2.Text)
            {
                mensaje = mensaje + "Favor de verificar la contraseña \n";
            }
            if (DropDownList1.SelectedItem.ToString() == "Seleccionar...")
            {
                mensaje = mensaje + "Selecciona el tipo de usuario \n";
            }
            if (mensaje.Trim().Length == 0)
            {
                user.IdUsuario = txtMatricula.Text;
                user.Nombre = txtNombre.Text;
                user.ApePat = txtApellidoPaterno.Text;
                user.Password = txtContraseña.Text;
                user.CodTipo = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
                return user;
            }
            else
            {
                Mensaje(mensaje);
                return null;
            }
        }
        
        public object Buscar()
        {
            UsuarioBO user = new UsuarioBO();
            if (txtMatricula.Text.Trim().Length != 0)
            {
                user.IdUsuario = txtMatricula.Text;
            }
            if (txtNombre.Text.Trim().Length != 0)
            {
                user.Nombre = txtNombre.Text;
            }
            if (txtApellidoPaterno.Text.Trim().Length != 0)
            {
                user.ApePat = txtApellidoPaterno.Text;
            }
            if (txtApellidoMaterno.Text.Trim().Length != 0)
            {
                user.ApeMat = txtApellidoMaterno.Text;
            }
            if (DropDownList1.SelectedItem.ToString() != "Seleccionar...")
            {
                string nombre=Servicios.NomTipoUsuario(Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString()));
                user.NomTipo = nombre;
            }
            return user;
        }

        public void limpiar()
        {
            txtMatricula.Text = "";
            txtApellidoMaterno.Text = "";
            txtApellidoPaterno.Text = "";            
            txtContraseña.Attributes.Add("value","");
            txtContraseña2.Attributes.Add("value", "");
            txtNombre.Text = "";
            DropDownList1.SelectedIndex = 0;
        }
        
        DataTable dt;
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                try
                {
                int indice = Convert.ToInt32(e.CommandArgument);
                string id = (string)GridView1.DataKeys[indice].Value;
                UsuarioBO s = new UsuarioBO();
                s.IdUsuario = id;
                dt = new DataTable();
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(Servicios.BuscarUsuario(s));
                dt = dataSet.Tables[0];
                DataRow row = dt.Rows[0];
                txtMatricula.Text = row["Matricula"].ToString();
                txtApellidoMaterno.Text = row["Apellido_Materno"].ToString();
                txtApellidoPaterno.Text = row["Apellido_Paterno"].ToString();
                txtNombre.Text = row["Nombre"].ToString();
                int cod=Servicios.CodigoTipoUsuario(row["Tipo_Usuario"].ToString());
                DropDownList1.SelectedValue = cod.ToString();
                txtContraseña.Attributes.Add("value", row["password"].ToString());
                txtContraseña2.Attributes.Add("value", row["password"].ToString());
                txtMatricula.Enabled = false;
                LinkButton3.Enabled = true;
                LinkButton1.Enabled = false;
                LinkButton2.Enabled = false;
                }
                catch(Exception ex)
                {
                    Mensaje(ex.ToString());
                }
            }
            if (e.CommandName == "Eliminar")
            {
                try
                {
                int indice = Convert.ToInt32(e.CommandArgument);
                string id = (string)GridView1.DataKeys[indice].Value;
                UsuarioBO s = new UsuarioBO();
                s.IdUsuario = id;
                Servicios.EliminarUsuario(s);
                LLenarDatos();
                }
                catch(Exception ex)
                {
                    Mensaje(ex.ToString());
                }
            }
        }
        public void LLenarDatos()
        {
 DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(Servicios.Usuarios());
            GridView1.DataSource = dataSet.Tables[0];
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LLenarDatos();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(Servicios.BuscarUsuario(Buscar()));
            dt = dataSet.Tables[0];
            string ruta = Server.MapPath("CRUsuarios.rpt");
            ReportDocument doc = new ReportDocument();
            doc.Load(ruta);
            doc.SetDataSource(dt);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            //doc.PrintToPrinter(1,false,0,1);
            doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "UTM");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (Datos() != null)
            {
                int res=Servicios.modificarUsuario(Datos());
                if (res==1)
                {
                    Mensaje("Los datos se modificaron correctamente");
                    limpiar();
                    LLenarDatos();
                    txtMatricula.Enabled = true;
                    LinkButton3.Enabled = false;
                    LinkButton1.Enabled = true;
                    LinkButton2.Enabled = true;
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(Servicios.BuscarUsuario(Buscar()));
            GridView1.DataSource = dataSet.Tables[0];
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int res = Servicios.comprobarExistencia(txtMatricula.Text);
            if (res == 0)
            {
                if (Datos() != null)
                {
                    int i = Servicios.AgregarUsuario(Datos());
                    if (i == 1)
                    {
                        Mensaje("Los datos se agregaron correctamente");
                        DropDownList1.SelectedValue = "Seleccionar...";
                        limpiar();
                        LLenarDatos();
                    }
                }
            }
            else
            {
                Mensaje("Matrícula Existente. Favor de verificar");
            }
        }
    }
}