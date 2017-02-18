using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebUTM.localhost;
namespace WebUTM
{
    /// <summary>
    /// Summary description for VideoHandler
    /// </summary>
    public class VideoHandler : IHttpHandler
    {
        WebService ws = new WebService();
        byte[] imagen;
        public void ProcessRequest(HttpContext context)
        {
            DataSet ds = new DataSet();
            string imageid = context.Request.QueryString["ID"];
            ds = ws.Videos(Convert.ToInt32(imageid));
            DataRow dr;
            dr = ds.Tables[0].Rows[0];
            imagen = (byte[])dr["video"];
            context.Response.Clear();
            context.Response.Buffer = true;
            //context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + "Video");
            context.Response.ContentType = "video/mp4";
            context.Response.BinaryWrite(imagen);
            context.Response.End(); context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}