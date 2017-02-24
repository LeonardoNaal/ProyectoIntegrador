using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUTM.localhost;
using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace WebUTM.WebUtmAdmin
{
    public partial class admin_pub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                DropDownList1.DataTextField = "NomTipo";
                DropDownList1.DataValueField = "IDTipo";
                DataSet dataSettipos = JsonConvert.DeserializeObject<DataSet>(servicio.TiposPublicaciones());
                DropDownList1.DataSource = dataSettipos.Tables[0];
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0,"Seleccionar...");
                Bind();
            }
            if ((String)Session["Estado"] == "Codigo")
            {
                MostrarCodigo();
            }
        }

        WebService servicio = new WebService();
        public void Limpiar()
        {
            txtDescripcion.Text = "";
            txtTitulo.Text = "";
            txtFecha.Text = "";
            DropDownList1.SelectedIndex = 0;
            image1.ImageUrl=null;
        }
        WebService Servicios = new WebService();        
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
        
        public object Filtro()
        {
            PublicacionBO ob = new PublicacionBO();
            if (txtDescripcion.Text.Trim().Length  != 0)
            {
                ob.Contenido = txtDescripcion.Text;
            }
            if (txtTitulo.Text.Trim().Length != 0)
            {
                ob.Titulo = txtTitulo.Text;                
            }
            if (DropDownList1.SelectedItem.ToString() !="Seleccionar...")
            {
                ob.IdTipo = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
            }
            return ob;
        }
        DataTable dt;
        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
            PublicacionBO obj = new PublicacionBO();
            Int64 id = (Int64)DataList1.DataKeys[e.Item.ItemIndex];
            obj.IdPublicacion = Convert.ToInt32(id);
            servicio.EliminarPublicacion(obj);
            actualizar();
            }
            catch (Exception ex)
            {
                Mensaje(ex.ToString());
            }
        }
        public void actualizar()
        {
            Bind();
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName=="update")
            {
                try
                {
                Int64 id = (Int64)DataList1.DataKeys[e.Item.ItemIndex];
                lblcod.Text = id.ToString();
                PublicacionBO s = new PublicacionBO();
                s.IdPublicacion = Convert.ToInt32(id);
                dt = new DataTable();
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarPublicaciones(s));
                dt = dataSet.Tables[0];
                DataRow row = dt.Rows[0];
                txtDescripcion.Text = row["Contenido"].ToString();
                txtFecha.Text = row["Fecha"].ToString();
                txtTitulo.Text = row["Titulo"].ToString();
                lblcoduser.Text = row["CodUsuario"].ToString();
                DropDownList1.SelectedValue = row["IDTipo"].ToString();
                string base64String  = Convert.ToString(row["Image"]);
                if(base64String!=null)
                { 
                Label4.Text = base64String;
                 image1.ImageUrl= "data:image/jpeg;base64," + base64String;
                        //imageUrl
                }
                LinkButton3.Enabled= true;
                LinkButton2.Enabled = false;
                LinkButton1.Enabled = false;
                }
                catch (Exception ex)
                {
                    Mensaje(ex.ToString());
                }
            }
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
        public int idPub = 0;
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            PublicacionBO objPublicaciones = new PublicacionBO();
            string mensaje = "";
            if (txtDescripcion.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la  descripción \n";
            }
            if (FileUpload2.PostedFile.ContentLength != 0)
            {
                using (BinaryReader br = new BinaryReader(FileUpload2.PostedFile.InputStream))
                {
                    byte[] bytes = br.ReadBytes((int)FileUpload2.PostedFile.InputStream.Length);
                    objPublicaciones.Video = bytes;
                }
            }
            if (FileUpload1.PostedFile.ContentLength != 0)
            {
                System.Web.HttpPostedFile ImgFile = FileUpload1.PostedFile;
                // Almacenamos la imagen en una variable para insertarla en la bd.
                Byte[] byteImage = new Byte[FileUpload1.PostedFile.ContentLength];
                ImgFile.InputStream.Read(byteImage, 0, FileUpload1.PostedFile.ContentLength);
                objPublicaciones.Imagen = byteImage;
            }
            if (txtTitulo.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce el título \n";
            }
            if (DropDownList1.SelectedItem.ToString() == "Seleccionar...")
            {
                mensaje = mensaje + "Selecciona el tipo de publicación \n";
            }
            if (mensaje.Trim().Length == 0)
            {
                objPublicaciones.Contenido = txtDescripcion.Text;
                objPublicaciones.Titulo = txtTitulo.Text.ToUpper();
                objPublicaciones.CodUsuario = codUser;
                objPublicaciones.IdTipo = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
                int i = Servicios.AgregarPublicacion(objPublicaciones);
                if (i == 1)
                {
                    Mensaje("Los datos se agregaron correctamente");
                    Limpiar();
                    actualizar();
                    LinkButton3.Enabled = false;
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
        public static byte[] ImagenABytes(System.Drawing.Image ima)
        {
            MemoryStream ms = new MemoryStream();
           ima.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arreglo = ms.ToArray();
            return arreglo;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarPublicaciones(Filtro()));
            DataList1.DataSource = dataSet.Tables[0];
            DataList1.DataBind();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            PublicacionBO objPublicaciones = new PublicacionBO();
            string mensaje = "";
            if (Label4.Text.Trim().Length != 0)
            {
                byte[] newBytes = Convert.FromBase64String((Label4.Text));
                objPublicaciones.Imagen = newBytes;
            }
            else if (FileUpload1.PostedFile.ContentLength != 0)
            {
                Stream imgStream = FileUpload1.PostedFile.InputStream;
                int imgLen = FileUpload1.PostedFile.ContentLength;
                byte[] imgBinaryData = new byte[imgLen];
                objPublicaciones.Imagen = imgBinaryData;
            }
            if (txtDescripcion.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la descripción \n";
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
                objPublicaciones.IdPublicacion = Convert.ToInt32(lblcod.Text);
                objPublicaciones.Contenido = txtDescripcion.Text;
                objPublicaciones.Titulo = txtTitulo.Text;
                objPublicaciones.CodUsuario = lblcoduser.Text;
                objPublicaciones.IdTipo = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
                int i = Servicios.modificarPublicacion(objPublicaciones);
                if (i == 1)
                {
                    Mensaje("Los datos se modificaron correctamente");
                    LinkButton3.Enabled = false;
                    LinkButton1.Enabled = true;
                    LinkButton2.Enabled = true;
                    actualizar();
                    Limpiar();
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
    }
}