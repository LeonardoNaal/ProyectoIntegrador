using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using WebServiceProyecto.BO;
namespace WebServiceProyecto.DAO
{
    public class SitioDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public string devuelveSitioSP(object obj)
        {
            SitioBO data = (SitioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraSitio";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDSitio", data.IdSitio);
            cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
            //cmd.Parameters.AddWithValue("@idTipo",data.TipoSitio);
            cmd.Parameters.AddWithValue("@Planta", data.Planta);            
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }

        public string devuelveSitio()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetTodosSitios";
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

        public string devuelveTiposSitio()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "getTipoSitio";
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

        public int cargarCU()
        {
            string sql = ("select MAX(AlumnoID) as'CA' From Alumno");
            string campo = "CA";
            return con.cargarCodTablas(sql, campo);
        }

        public int creaSitioSP(object obj)
        {
            SitioBO data = (SitioBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarSitio";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
            cmd.Parameters.AddWithValue("@Planta", data.Planta);
            cmd.Parameters.AddWithValue("@IDTipoSitio",data.TipoSitio);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }

        public int cargarCodTipoSitio(string TipSitio)
        {
            con = new ConexionBD();
            string sql = ("select IDTipo From TipoSitio where NombreTipo='" + TipSitio + "'");
            string campo = "IDTipo";
            return con.cargarCodTablas(sql, campo);
        }
        public int eliminaSitioSP(object obj)
        {
            SitioBO data = (SitioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "EliminarSitio";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDSitio", data.IdSitio);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }
        public int modificaSitioSP(object obj)
        {
            SitioBO data = (SitioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ModificarSitio";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDSitio", data.IdSitio);
            cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
            cmd.Parameters.AddWithValue("@Planta", data.Planta); 
                cmd.Parameters.AddWithValue("@IDTIPO", data.TipoSitio);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  Actualizo de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }

        public int cargarCA(string user)
        {
            string sql = ("select AlumnoID as'CA' From Alumno where Usuario='" + user + "'");
            string campo = "CA";
            return con.cargarCodTablas(sql, campo);
        }
    }
}