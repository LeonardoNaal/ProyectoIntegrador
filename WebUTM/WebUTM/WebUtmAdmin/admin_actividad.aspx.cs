using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUTM.localhost;
using System.Data;
using Newtonsoft.Json;
namespace WebUTM.WebUtmAdmin
{
    public partial class admin_actividad : System.Web.UI.Page
    {
        WebService servicio = new WebService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.Sitios());
                DDLTipoSitio.DataTextField = "Nombre";
                DDLTipoSitio.DataValueField = "IDSitio";
                DDLTipoSitio.DataSource = dataSet.Tables[0];
                DDLTipoSitio.DataBind();
                DDLTipoSitio.Items.Insert(0, "Seleccionar...");
            }
            if ((String)Session["Estado"] == "Codigo")
            {
                MostrarCodigo();
            }
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public string codUser;
        public void MostrarCodigo()
        {
            UsuarioBO objUser = (UsuarioBO)Session["sUser"];
            if (objUser != null)
            {
                codUser = objUser.IdUsuario;
            }
        }
        public int index
        {
            get
            {
                if (ViewState["index"] == null)
                    return 0;
                else
                    return Convert.ToInt32(ViewState["index"].ToString());
            }
            set
            {
                ViewState["index"] = value;
            }
        }
        private void Bind()
        {
            DataSet dataSetTipos = JsonConvert.DeserializeObject<DataSet>(servicio.Actividades());
            DataTable dt = dataSetTipos.Tables[0];
            if (dt.Rows.Count > 0)
            {
                PagedDataSource _pageDataSource = new PagedDataSource();
                _pageDataSource.DataSource = dt.DefaultView;
                _pageDataSource.AllowPaging = true;
                _pageDataSource.PageSize = 3;
                _pageDataSource.CurrentPageIndex = index;
                ViewState["LastPage"] = _pageDataSource.PageCount - 1;
                DataList1.DataSource = _pageDataSource;
                DataList1.DataBind();
                btnprevious.Visible = !_pageDataSource.IsFirstPage;
                btnnext.Visible = !_pageDataSource.IsLastPage;
                btnfirst.Visible = !_pageDataSource.IsFirstPage;
                btnlast.Visible = !_pageDataSource.IsLastPage;
            }
        }
        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
            ActividadesBO obj = new ActividadesBO();
            int id = (int)DataList1.DataKeys[e.Item.ItemIndex];
            obj.IdActividad = id;
            servicio.EliminarActividad(obj);
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString());
            }
        }

        public int idAct = 0;
        DataTable dt;
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                try
                {
                Int64 id = (Int64)DataList1.DataKeys[e.Item.ItemIndex];
                lblcodAct.Text = id.ToString();
                ActividadesBO s = new ActividadesBO();
                s.IdActividad = Convert.ToInt32(id);
                dt = new DataTable();
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarActividad(s));
                dt = dataSet.Tables[0];
                DataRow row = dt.Rows[0];
                txtNombre.Text = row["Nombre"].ToString();
                txtFecha1.Text = row["FechaIni"].ToString().Substring(0, 10);
                txtFecha2.Text = row["FechaFin"].ToString().Substring(0, 10);
                txtDescripcion.Text = row["Descripcion"].ToString();
                lblcodUser.Text = row["CodUsuario"].ToString();
                txtHoraIni.Text = row["HoraInicio"].ToString();
                txtHoraFin.Text = row["HoraFin"].ToString();
                if (row["IDSitio"].ToString() != "")
                {
                    DDLTipoSitio.SelectedValue = row["IDSitio"].ToString();
                }
                LinkButton1.Enabled = false;
                LinkButton2.Enabled = false;
                LinkButton3.Enabled = true;
                }
                catch (Exception ex)
                {
                    Mensaje(ex.ToString());
                }
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
        
        public void Limpiar()
        {
            txtDescripcion.Text = "";
            txtFecha1.Text = "";
            txtFecha2.Text = "";
            txtNombre.Text = "";
            txtHoraFin.Text = "";
            DDLTipoSitio.SelectedIndex = 0;
            txtHoraIni.Text = "";
        }
        public void agregar()
        {
            ActividadesBO act = new ActividadesBO();
            string mensaje = "";
            if (txtDescripcion.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la  descripción \n";
            }
            if (txtNombre.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el nombre \n";
            }
            if (txtFecha1.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la fecha inicial \n";
            }
            if (DDLTipoSitio.SelectedItem.ToString() == "Seleccionar...")
            {
                mensaje = mensaje + "Selecciona el sitio \n";
            }
            if (txtFecha2.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la fecha final \n";
            }
            if (txtHoraIni.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la hora inicio \n";
            }
            if (txtHoraFin.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la hora final \n";
            }
            if (mensaje.Trim().Length == 0)
            {
                act.CodUsuario = codUser;
                act.Descripcion = txtDescripcion.Text;
                act.FechaFinal = txtFecha2.Text;
                act.FechaIni = txtFecha1.Text;
                act.Nombre = txtNombre.Text;
                act.HoraIni = txtHoraIni.Text;
                act.HoraFin = txtHoraFin.Text;
                act.IdSitio = Convert.ToInt32(DDLTipoSitio.SelectedItem.Value.ToString());
                int t = servicio.AgregarActividad(act);
                if (t == 1)
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

        public void Modificar()
        {
            ActividadesBO act = new ActividadesBO();
            string mensaje = "";
            if (txtDescripcion.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la  descripción \n";
            }
            if (txtNombre.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el nombre \n";
            }
            if (txtFecha1.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el fecha inicio \n";
            }
            if (txtFecha2.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el fecha final \n";
            }
            if (txtHoraIni.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la hora inicio \n";
            }
            if (txtHoraFin.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la hora final \n";
            }
            if (DDLTipoSitio.SelectedItem.ToString() == "Seleccionar...")
            {
                mensaje = mensaje + "Selecciona el sitio \n";
            }
            if (mensaje.Trim().Length == 0)
            {
                act.Descripcion = txtDescripcion.Text;
                act.Nombre = txtNombre.Text;
                act.FechaFinal = txtFecha2.Text;
                act.FechaIni = txtFecha1.Text;
                act.HoraIni = txtHoraIni.Text;
                act.HoraFin = txtHoraFin.Text;
                act.CodUsuario = lblcodUser.Text;
                act.IdSitio = Convert.ToInt32(DDLTipoSitio.SelectedItem.Value.ToString());
                act.IdActividad = Convert.ToInt32(lblcodAct.Text);
                int t = servicio.modificarActividad(act);
                if (t == 1)
                {
                    Mensaje("Los datos se modificarón correctamente");
                    LinkButton3.Enabled = false;
                    LinkButton1.Enabled = true;
                    LinkButton2.Enabled = false;
                    txtFecha1.Enabled = true;
                    txtFecha2.Enabled = true;
                    Limpiar();
                }
                else
                {
                    Mensaje("Los datos no se modificarón, intenta de nuevo");
                }
            }
            else
            {
                Mensaje(mensaje);
            }
        }
        

        protected void btnlast_Click(object sender, EventArgs e)
        {
            index = Convert.ToInt32(ViewState["LastPage"]);
            Bind();
        }

        protected void btnfirst_Click(object sender, EventArgs e)
        {
            index = 0;
            Bind();
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            index -= 1;
            Bind();
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            index += 1;
            Bind();
        }
        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            agregar();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
ActividadesBO obj = new ActividadesBO();
            if (txtDescripcion.Text.Trim().Length != 0)
            {
                obj.Descripcion = txtDescripcion.Text;
            }
            if (txtNombre.Text.Trim().Length != 0)
            {
                obj.Nombre = txtNombre.Text;
            }
            if (txtFecha1.Text.Trim().Length != 0)
            {
                obj.FechaIni = txtFecha1.Text;
            }
            if (DDLTipoSitio.SelectedItem.ToString() != "Seleccionar...")
            {
                obj.IdSitio= Convert.ToInt32(DDLTipoSitio.SelectedItem.Value.ToString());
            }
            if (txtFecha2.Text.Trim().Length != 0)
            {
                obj.FechaFinal = txtFecha2.Text;
            }
            if (txtHoraIni.Text.Trim().Length != 0)
            {
                obj.HoraIni = txtHoraIni.Text;
            }
            if (txtHoraFin.Text.Trim().Length != 0)
            {
                obj.HoraFin = txtHoraFin.Text;
            }
            DataSet dataSetTipos = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarActividad(obj));
            DataList1.DataSource = dataSetTipos.Tables[0];
            DataList1.DataBind();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}