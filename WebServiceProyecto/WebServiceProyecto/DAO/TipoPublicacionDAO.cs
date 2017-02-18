using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;
using WebServiceProyecto.BO;
namespace WebServiceProyecto.DAO
{
    public class TipoPublicacionDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public DataSet devuelveTiposPublicacionesSP(object obj)
        {
            TipoPublicacionBO data = (TipoPublicacionBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraTipoPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDTipo", data.IdTipo);
            cmd.Parameters.AddWithValue("@NomTipo", data.NomTipo);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            return dsUsuario;
        }
        public string devuelveTiposPublicaciones()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetTipoPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            dsUsuario.AcceptChanges();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json ;
        }

        public int cargarCU()
        {
            string sql = ("select MAX(AlumnoID) as'CA' From Alumno");
            string campo = "CA";
            return con.cargarCodTablas(sql, campo);
        }

        public int creatipoPublicacionSP(object obj)
        {
            TipoPublicacionBO data = (TipoPublicacionBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertaTipoPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;            
            cmd.Parameters.AddWithValue("@NomTipo", data.NomTipo);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        public int eliminaTipoPublicacionSP(object obj)
        {
            TipoPublicacionBO data = (TipoPublicacionBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "EliminarTipoPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDTipo", data.IdTipo);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }
        public int modificaTipoPublicacionSP(object obj)
        {
            TipoPublicacionBO data = (TipoPublicacionBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ModificarTipoPublicacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDTipo", data.IdTipo);
            cmd.Parameters.AddWithValue("@NomTipo", data.NomTipo);
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