using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using WebUTM.localhost;
namespace WebUTM.WebUtmAdmin
{
    public partial class Horario : System.Web.UI.Page
    {
        WebService servicio = new WebService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLSitio.DataTextField = "NombreTipo";
                DDLSitio.DataValueField = "IDTipo";
                DataSet dataSetSitio = JsonConvert.DeserializeObject<DataSet>(servicio.GetTipoSitios());
                DDLSitio.DataSource = dataSetSitio.Tables[0];
                DDLSitio.DataBind();
                DDLSitio.Items.Insert(0, "Seleccionar...");
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.Sitios());
                GridView1.DataSource = modificarTabla(dataSet.Tables[0]).Tables[0];
                GridView1.DataBind();
            }
        }
        public DataSet modificarTabla(DataTable dss)
        {
            string planta = "";
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable("Sitio"));
            ds.Tables["Sitio"].Columns.Add("IDSitio", typeof(Int64));
            ds.Tables["Sitio"].Columns.Add("nombre", typeof(string));
            ds.Tables["Sitio"].Columns.Add("Planta", typeof(string));
            ds.Tables["Sitio"].Columns.Add("NombreTipo", typeof(string));
            foreach (DataRow l in  dss.Rows)
            {
                int num = Convert.ToInt32(l["planta"]);
                if (num == 1)
                {
                    planta = "Alta";
                }
                else
                {
                    planta = "Baja";
                }
                int ids = Convert.ToInt32(l["IDSitio"]);
                string nombreSitio = l["nombre"].ToString();
                string tipoSitio = l["NombreTipo"].ToString();
                ds.Tables["Sitio"].Rows.Add(ids,nombreSitio,planta,tipoSitio);
            }
            return ds;
        }
        private void Mensaje(string ex)
        {
            string mensaje = ex;
            mensaje = mensaje.Replace(Environment.NewLine, "\\n");
            mensaje = mensaje.Replace("\n", "\\n");
            mensaje = mensaje.Replace("'", "\"");
            ClientScript.RegisterClientScriptBlock(typeof(Page), "Error", "<script> alert('" + mensaje + "');</script>");
        }
        public void Limpiar()
        {
            txtNombre.Text = "";
            DDLSitio.SelectedIndex = 0;
        }
        public void Modificar()
        {
            try
            {
                string mensaje = "";
                SitioBO d = new SitioBO();
                if (DDLSitio.SelectedItem.ToString() == "Seleccionar...")
                {
                    mensaje = mensaje + "Selecciona el sitio \n";
                }
                if (txtNombre.Text.Trim().Length == 0)
                {
                    mensaje = mensaje + "Ingresar nombre \n";
                }
                if (mensaje.Trim().Length == 0)
                {
                    d.TipoSitio = Convert.ToInt32(DDLSitio.SelectedItem.Value.ToString());
                    string res = rdbplanta.SelectedItem.Text;
                    if (res == "Alta")
                    {
                        d.Planta = 1;
                    }
                    else
                    {
                        d.Planta = 0;
                    }
                    d.Nombre = txtNombre.Text;
                    d.IdSitio = Convert.ToInt32(Label4.Text);
                    int t = servicio.modificarSitio(d);
                    if (t == 1)
                    {
                        Mensaje("Los datos se modificaron correctamente");
                        Limpiar();
                        LLenarDatos();
                        LinkButton1.Enabled = true;
                        LinkButton2.Enabled = true;
                        LinkButton3.Enabled = false;
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
            catch (Exception ex) {
                Mensaje(ex.ToString());
            }
        }
        public void agregar()
        {
            string mensaje = "";
            SitioBO d = new SitioBO();
            if (DDLSitio.SelectedItem.ToString() == "Seleccionar...")
            {
                mensaje = mensaje + "Selecciona el sitio \n";
            }
            if (txtNombre.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Ingresar nombre \n";
            }
            if (mensaje.Trim().Length == 0)
            {
                d.TipoSitio = Convert.ToInt32(DDLSitio.SelectedItem.Value.ToString());
                string res=rdbplanta.SelectedItem.Text;
                if (res == "Alta")
                {
                    d.Planta = 1;
                }
                else
                {
                    d.Planta = 0;
                }
                d.Nombre = txtNombre.Text;
                int t = servicio.AgregarSitio(d);
                if (t == 1)
                {
                    Mensaje("Los datos se agregaron correctamente");
                    Limpiar();
                    LLenarDatos();
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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            agregar();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarSitio(buscar()));
            GridView1.DataSource = modificarTabla(dataSet.Tables[0]).Tables[0];
            GridView1.DataBind();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Modificar();
        }
        DataTable dt = new DataTable();
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                Int64 id = (Int64)GridView1.DataKeys[indice].Value;
                SitioBO d = new SitioBO();
                d.IdSitio=Convert.ToInt32(id);
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarSitio(d));
                dt = dataSet.Tables[0];
                DataRow row = dt.Rows[0];
                int r= servicio.cargarCodTipoSitio(row["NombreTipo"].ToString());
                DDLSitio.SelectedIndex = r;
                string g =row["Planta"].ToString();
                if (g=="1")
                {
                    rdbplanta.SelectedIndex=0;
                }
                else
                {
                    rdbplanta.SelectedIndex = 1;
                }
                txtNombre.Text= row["Nombre"].ToString();
                Label4.Text = id.ToString();
                LinkButton1.Enabled = false;
                LinkButton2.Enabled = false;
                LinkButton3.Enabled = true;
            }
            if (e.CommandName == "Eliminar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                Int64 id = (Int64)GridView1.DataKeys[indice].Value;
                SitioBO k = new SitioBO();
                k.IdSitio= Convert.ToInt32(id); ;
                int res = servicio.EliminarSitio(k);
                if (res == 1)
                {
                    Mensaje("Datos Eliminados Correctamente");
                    LLenarDatos();
                }
                else
                {
                    Mensaje("Fallo técnico");
                }
            }
        }
        public object buscar()
        {
            SitioBO f = new SitioBO();
            if (txtNombre.Text.Trim() != "")
            {
                f.Nombre = txtNombre.Text;
            }
            return f;
        }
        public void LLenarDatos()
        {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.Sitios());
            GridView1.DataSource = modificarTabla(dataSet.Tables[0]).Tables[0];
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LLenarDatos();
        }
    }
}