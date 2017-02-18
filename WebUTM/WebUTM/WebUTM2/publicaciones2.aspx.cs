using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Web.UI.WebControls;
using WebUTM.localhost;
namespace WebUTM.WebUTM2
{
    public partial class publicaciones2 : System.Web.UI.Page
    {
        WebService servicio = new WebService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["Estado"] == "Codigo")
            {
                MostrarCodigo();
            }
            if (!IsPostBack)
            {
              
                DropDownList1.DataTextField = "NomTipo";
                DropDownList1.DataValueField = "IDTipo";
                DataSet dataSetTipos = JsonConvert.DeserializeObject<DataSet>(servicio.TiposPublicaciones());
                DropDownList1.DataSource = dataSetTipos.Tables[0];
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Seleccionar...");
                Bind();
            }
        }
        UsuarioBO s = new UsuarioBO();
        public string codUser;
        public void MostrarCodigo()
        {
            UsuarioBO objUser = (UsuarioBO)Session["sUser"];
            if (objUser != null)
            {
                codUser = objUser.IdUsuario;
                Label4.Text = "Publicaciones de "+ objUser.Nombre + " " + objUser.ApePat;
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
            txtTitulo.Text = "";
            
            DropDownList1.SelectedIndex = 0;
        }
        
        DataTable dt;
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
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
                //txt.Text = row["Fecha"].ToString();
                txtTitulo.Text = row["Titulo"].ToString();
                DropDownList1.SelectedValue = row["IDTipo"].ToString();
                string base64String = Convert.ToString(row["Image"]);
                if (base64String != null)
                {
                    lblstringimagen.Text = base64String;
                    img2.ImageUrl = "data:image/jpeg;base64," + base64String;
                }
                LinkButton1.Enabled = false;
                LinkButton2.Enabled = true;
            }
        }
        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            PublicacionBO obj = new PublicacionBO();
            Int64 id = (Int64)DataList1.DataKeys[e.Item.ItemIndex];
            obj.IdPublicacion = Convert.ToInt32(id);
            servicio.EliminarPublicacion(obj);
            actualizar();
        }
        public void actualizar()
        {
            PublicacionBO obj = new PublicacionBO();
            obj.CodUsuario = codUser;
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarPublicaciones(obj));
            DataList1.DataSource = dataSet.Tables[0];
            DataList1.DataBind();
        }
        private void Bind()
        {
            PublicacionBO obj = new PublicacionBO();
            obj.CodUsuario = codUser;
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(servicio.BuscarPublicaciones(obj));
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            PublicacionBO objPublicaciones = new PublicacionBO();
            string mensaje = "";
            if (FileUpload1.PostedFile != null)
            {
                System.Web.HttpPostedFile ImgFile = FileUpload1.PostedFile;
                // Almacenamos la imagen en una variable para insertarla en la bbdd.
                Byte[] byteImage = new Byte[FileUpload1.PostedFile.ContentLength];
                ImgFile.InputStream.Read(byteImage, 0, FileUpload1.PostedFile.ContentLength);
                objPublicaciones.Imagen = byteImage;
            }
            if (txtDescripcion.Text.Trim().Length == 0)
            {
                mensaje = mensaje + "Introduce la  descripción \n";
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
                objPublicaciones.Contenido = txtDescripcion.Text;
                objPublicaciones.Titulo = txtTitulo.Text;
                objPublicaciones.CodUsuario = codUser;
                objPublicaciones.IdTipo = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
                int i = servicio.AgregarPublicacion(objPublicaciones);
                if (i == 1)
                {
                    Mensaje("Los datos se agregaron correctamente");
                    Limpiar();
                    actualizar();
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

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            PublicacionBO objPublicaciones = new PublicacionBO();
            string mensaje = "";

            if (lblstringimagen.Text.Trim().Length != 0)
            {
                byte[] newBytes = Convert.FromBase64String((lblstringimagen.Text));
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
                objPublicaciones.Titulo = txtTitulo.Text.ToUpper();
                objPublicaciones.CodUsuario = codUser;
                objPublicaciones.IdTipo = Convert.ToInt32(DropDownList1.SelectedItem.Value.ToString());
                int i = servicio.modificarPublicacion(objPublicaciones);
                if (i == 1)
                {
                    Mensaje("Los datos se modificaron correctamente");
                    LinkButton1.Enabled = true;
                    LinkButton2.Enabled = false;
                    img2.ImageUrl = null;
                    Bind();
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

   

        protected void FileUpload1_Disposed(object sender, EventArgs e)
        {

 if (FileUpload1.PostedFile != null)
            {
                HttpPostedFile myFile = FileUpload1.PostedFile;

                int nFileLen = myFile.ContentLength;

                if (nFileLen > 0)
                {
                    byte[] myData = new byte[nFileLen];
                    myFile.InputStream.Read(myData, 0, nFileLen);

                    string strNombreArchivo = Path.GetFileName(myFile.FileName);
                    img2.ImageUrl = myFile.FileName;
                    img2.ToolTip = strNombreArchivo;

                }
            }
        }
    }
}