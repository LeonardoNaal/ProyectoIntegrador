using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using WebServiceProyecto.BO;
namespace WebServiceProyecto.DAO
{
    public class TipoUsuarioDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public string devuelveTiposUsuariosSP(object obj)
        {
            TipoUsuarioBO data = (TipoUsuarioBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraTipoUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoTipo", data.CodTipo);
            cmd.Parameters.AddWithValue("@NomTipo", data.NombreTipo);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            dsUsuario.AcceptChanges();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        public string cargarTipoUser(int user)
        {
            con = new ConexionBD();
            string sql = ("select NomTipo From TipoUsuario where CodigoTipo=" + user + "");
            string campo = "NomTipo";
            return con.cargarTablas(sql, campo);
        }
        public string devuelveTiposUsuarios()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetTipoUsuario";
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
        public string devuelveTiposUsuariosAdmin()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetTiposUsuarios";
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

        public int creaTipoUsuarioSP(object obj)
        {
            TipoUsuarioBO data = (TipoUsuarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertaTipoUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomTipo", data.NombreTipo);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        public int eliminaTipoUsuarioSP(object obj)
        {
            TipoUsuarioBO data = (TipoUsuarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "EliminarTipoUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoTipo", data.CodTipo);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }
        public int modificaTipoUsuarioSP(object obj)
        {
            TipoUsuarioBO data = (TipoUsuarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ModificarTipoUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodigoTipo", data.CodTipo);
            cmd.Parameters.AddWithValue("@NomTipo", data.NombreTipo);
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