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
    public partial class index : System.Web.UI.Page
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