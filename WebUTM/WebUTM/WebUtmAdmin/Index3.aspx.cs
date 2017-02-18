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
    public partial class Index3 : System.Web.UI.Page
    {
        WebService servicio = new WebService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.TopPublicaciones());
                DataList1.DataSource = dataSet.Tables[0];
                DataList1.DataBind();
                DataSet dataSetActividades = JsonConvert.DeserializeObject<DataSet>(servicio.TopActividades());
                DataList2.DataSource = dataSetActividades.Tables[0];
                DataList2.DataBind();
            }
        }
    }
}