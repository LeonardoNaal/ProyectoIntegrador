using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using Newtonsoft.Json;
using WebServiceProyecto.BO;
using System.Drawing;
namespace WebServiceProyecto.DAO
{
    public class PublicacionDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public string devuelvePublicacionSP(object obj)
        {
            PublicacionBO data = (PublicacionBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDPublicacion", data.IdPublicacion);
            cmd.Parameters.AddWithValue("@Titulo", data.Titulo);            
            cmd.Parameters.AddWithValue("@Contenido", data.Contenido);
            cmd.Parameters.AddWithValue("@IDTipo", data.IdTipo);
            cmd.Parameters.AddWithValue("@CodUsuario", data.CodUsuario);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            dsUsuario.AcceptChanges();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }

        public string jsonPublicacion()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            dsUsuario.AcceptChanges();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }

        public int creaPublicacionSP(object obj)
        {
            PublicacionBO data = (PublicacionBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Titulo", data.Titulo);
            if (data.Imagen != null)
            {
                SqlParameter imageParam = cmd.Parameters.Add("@image", System.Data.SqlDbType.Image);
                imageParam.Value =data.Imagen;
            }
            cmd.Parameters.AddWithValue("@Contenido", data.Contenido);
            if (data.Video != null)
            {
                cmd.Parameters.AddWithValue("@video",data.Video);
            }
            cmd.Parameters.AddWithValue("@IDTipo", data.IdTipo);
            cmd.Parameters.AddWithValue("@CodUsuario", data.CodUsuario);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        
        public byte[] imagen(int cod)
        {
            DataSet ds = new DataSet();
            con = new ConexionBD();
            SqlDataAdapter da = new SqlDataAdapter();
            byte[] arrContent;
            DataRow dr;
            string strSql;
            strSql = "Select Image from Publicacion where IDPublicacion= " + cod + "";
            da = new SqlDataAdapter(strSql, con.establecerConexion());
            con.abrirConexion();
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];
            arrContent = (byte[])dr["Image"];
            con.cerrarConexion();
            return arrContent;
        }
        public DataSet video(int cod)
        {
            DataSet ds = new DataSet();
            con = new ConexionBD();
            SqlDataAdapter da = new SqlDataAdapter();
            string strSql;
            strSql = "Select video,IDPublicacion from Publicacion where IDPublicacion= " + cod + "";
            da = new SqlDataAdapter(strSql, con.establecerConexion());
            con.abrirConexion();
            da.Fill(ds);
            con.cerrarConexion();
            return ds;
        }
        public int eliminaPublicacionSP(object obj)
        {
            PublicacionBO data = (PublicacionBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "EliminarPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDPublicacion", data.IdPublicacion);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }

        public string TopPublicaciones()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetTopPublicaciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        public string TopPublicaciones2()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetTopPublicaciones2";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        public int modificaPublicacionSP(object obj)
        {
            PublicacionBO data = (PublicacionBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ModificarPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDPublicacion", data.IdPublicacion);
            cmd.Parameters.AddWithValue("@Titulo", data.Titulo);            
            cmd.Parameters.AddWithValue("@Contenido", data.Contenido);
            if (data.Imagen != null)
            {
                SqlParameter imageParam = cmd.Parameters.Add("@image", System.Data.SqlDbType.Image);
                imageParam.Value = data.Imagen;
            }
            cmd.Parameters.AddWithValue("@IDTipo", data.IdTipo);
            cmd.Parameters.AddWithValue("@CodUsuario", data.CodUsuario);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  Actualizo de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }
    }
}