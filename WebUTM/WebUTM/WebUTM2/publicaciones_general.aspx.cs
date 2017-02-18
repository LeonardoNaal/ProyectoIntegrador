using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUTM.localhost;
using System.Data;
using Newtonsoft.Json;
namespace WebUTM.WebUTM2
{
    public partial class publicaciones_general : System.Web.UI.Page
    {
        WebService servicio = new WebService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLTipoUsuarios.DataTextField = "NomTipo";
                DDLTipoUsuarios.DataValueField = "IDTipo";
                DataSet dataSetTipos = JsonConvert.DeserializeObject<DataSet>(servicio.TiposPublicaciones());
                DDLTipoUsuarios.DataSource = dataSetTipos.Tables[0];
                DDLTipoUsuarios.DataBind();
                DDLTipoUsuarios.Items.Insert(0, "Seleccionar...");
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.jsonpublicaciones());
                DataList1.DataSource = dataSet.Tables[0];
                DataList1.DataBind();
            }
            if (!IsPostBack)
            {
                Bind();
            }
            if ((String)Session["Estado"] == "Codigo")
            {
                MostrarCodigo();
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

        protected void DDLTipoUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicacionBO obj = new PublicacionBO();
            string valor = DDLTipoUsuarios.SelectedItem.Value.ToString();
            obj.IdTipo = Convert.ToInt32(valor);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarPublicaciones(obj));
            DataList1.DataSource = dataSet.Tables[0];
            DataList1.DataBind();
        }
        private void Bind()
        {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.jsonpublicaciones());
            DataTable dt = dataSet.Tables[0];
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
        private void Mensaje(string ex)
        {
            string mensaje = ex;
            mensaje = mensaje.Replace(Environment.NewLine, "\\n");
            mensaje = mensaje.Replace("\n", "\\n");
            mensaje = mensaje.Replace("'", "\"");
            ClientScript.RegisterClientScriptBlock(typeof(Page), "Error", "<script> alert('" + mensaje + "');</script>");
        }
        DataSet ds = new DataSet();
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AgregarComentario")
            {
                if (((TextBox)e.Item.FindControl("TextBox1")).Text == "")
                {
                    Mensaje("--Llena el campo. Por favor--");
                }
                else
                {
                    Int64 id = (Int64)DataList1.DataKeys[e.Item.ItemIndex];
                    ComentarioBO ob = new ComentarioBO();
                    string g = ((TextBox)e.Item.FindControl("TextBox1")).Text;
                    if (g.Trim().Length != 0)
                    {
                        ob.Contenido = g;
                    }
                    ob.CodPub = Convert.ToInt32(id);
                    ob.CodUsuario = codUser;
                    servicio.AgregarComentario(ob);
                    ((TextBox)e.Item.FindControl("TextBox1")).Text = "";
                    Mensaje("Mensaje agregado con exito");
                }
            }

            if (e.CommandName == "VerComentarios")
            {
                Int64 id = (Int64)DataList1.DataKeys[e.Item.ItemIndex];
                ComentarioBO d = new ComentarioBO();
                d.CodPub = Convert.ToInt32(id);
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.DevuelveComentarios(d));
                Repeater1.DataSource = dataSet.Tables[0];
                Repeater1.DataBind();
            }
            if (e.CommandName == "VerVideo")
            {
                Int64 id = (Int64)DataList1.DataKeys[e.Item.ItemIndex];
                ds = servicio.Videos(Convert.ToInt32(id));
                DataRow dr;
                dr = ds.Tables[0].Rows[0];
                string c = dr["video"].ToString();
                if (c != "")
                {
                    byte[] vid = (byte[])dr["video"];
                    if (vid != null)
                    {
                        DataList2.DataSource = servicio.Videos(Convert.ToInt32(id));
                        DataList2.DataBind();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal2();", true);
                    }
                }
                else
                {
                    Mensaje("No hay video disponible");
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}