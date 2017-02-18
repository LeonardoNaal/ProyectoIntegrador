using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using WebServiceProyecto.BO;
namespace WebServiceProyecto.DAO
{
    public class UsuarioHoraDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public string devuelveUsuarioHoraSP(object obj)
        {
            UsuarioHoraBO data = (UsuarioHoraBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraUsuarioHora";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodUsuario", data.CodUsuario);
            cmd.Parameters.AddWithValue("@dia", data.Dia);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        public DataSet devuelveUsuarioHora()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetUsuarioHora";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            return dsUsuario;
        }
        public string BuscarUsuarioHora(object obj)
        {
            UsuarioHoraBO data = (UsuarioHoraBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "BuscarHora";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", data.Id);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        public int creaUsuarioHoraSP(object obj)
        {
            UsuarioHoraBO data=(UsuarioHoraBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarUsuarioHora";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodHora", data.CodHora);
            cmd.Parameters.AddWithValue("@CodUsuario", data.CodUsuario);
            cmd.Parameters.AddWithValue("@idsitio",data.IdSitio);
            cmd.Parameters.AddWithValue("@dia",data.Dia);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        public int eliminaUsuarioHoraSP(object obj)
        {
            UsuarioHoraBO data = (UsuarioHoraBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "EliminarUsuarioHora";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", data.Id);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }
        //public int modificaTipoUsuarioSP(object obj)
        //{
        //    TipoUsuarioBO data = (TipoUsuarioBO)obj;
        //    cmd = new SqlCommand();
        //    dsUsuario = new DataSet();
        //    da = new SqlDataAdapter();
        //    con = new ConexionBD();
        //    cmd.Connection = con.establecerConexion();
        //    con.abrirConexion();
        //    cmd.CommandText = "ActualizarTipoUsuario";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@CodigoTipo", data.CodTipo);
        //    cmd.Parameters.AddWithValue("@NomTipo", data.NombreTipo);
        //    int i = cmd.ExecuteNonQuery();
        //    // validamos si se  Actualizo de manera correcta
        //    if (i <= 0)
        //    {
        //        return 1;
        //    }
        //    return 0;
        //}

        public int cargarCA(string user)
        {
            string sql = ("select AlumnoID as'CA' From Alumno where Usuario='" + user + "'");
            string campo = "CA";
            return con.cargarCodTablas(sql, campo);
        }
    }
}