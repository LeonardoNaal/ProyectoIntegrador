using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUTM.localhost;
using System.Data;
using Newtonsoft.Json;

namespace WebUTM.WebUTM
{
    public partial class Actividades : System.Web.UI.Page
    {
        WebService servicio = new WebService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dataSetActividades = JsonConvert.DeserializeObject<DataSet>(servicio.TopActividades());
                DataList1.DataSource = dataSetActividades.Tables[0];
                DataList1.DataBind();
            }
            if (!IsPostBack)
            {
                Bind();
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
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
           if(e.CommandName=="VerAsistencia")
            {
                Int64 id = (Int64)DataList1.DataKeys[e.Item.ItemIndex];
                ActividadUsuario d = new ActividadUsuario();
                d.IDActividad1 = Convert.ToInt32(id);
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.AsistenciaActividades(d));
                Repeater1.DataSource = dataSet.Tables[0];
                Repeater1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
    }
}