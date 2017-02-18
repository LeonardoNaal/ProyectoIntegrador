using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebServiceProyecto.DAO
{
    public class ComentarioDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public string devuelveComentario(object obj)
        {
            BO.ComentarioBO data = (BO.ComentarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetComentarios";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", data.CodPub);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        public string devuelveComentarioSP(object obj)
        {
            BO.ComentarioBO data = (BO.ComentarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraComentario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idComentario",data.Id);
            cmd.Parameters.AddWithValue("@Fecha",data.Fecha);
            cmd.Parameters.AddWithValue("@Contenido", data.Contenido);
            cmd.Parameters.AddWithValue("@idUsuario", data.CodUsuario);
            cmd.Parameters.AddWithValue("@idPub", data.CodPub);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }

        public string devuelve()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "Get";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        

        public int creaComentarioSP(object obj)
        {
            BO.ComentarioBO data = (BO.ComentarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarComentario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Contenido", data.Contenido);
            cmd.Parameters.AddWithValue("@CodUsuario",data.CodUsuario);
            cmd.Parameters.AddWithValue("@codPub", data.CodPub);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
    }
}