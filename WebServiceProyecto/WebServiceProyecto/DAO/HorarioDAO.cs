using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebServiceProyecto.BO;
using Newtonsoft.Json;

namespace WebServiceProyecto.DAO
{
    public class HorarioDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public DataSet devuelveHorarioSP(object obj)
        {
            HorarioBO data = (HorarioBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraHorario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodHora", data.CodHora);
            cmd.Parameters.AddWithValue("@HoraIni", data.HoraIni);
            cmd.Parameters.AddWithValue("@HoraFin", data.HoraFin);
            cmd.Parameters.AddWithValue("@IDSitio", data.IdSitio);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            return dsUsuario;
        }
        public string devuelveHorario()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "Horarios";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        public string devuelveHora()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetHorario";
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

        public int creaHorarioSP(object obj)
        {
            HorarioBO data = (HorarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarHorario";
            cmd.CommandType = CommandType.StoredProcedure;           
            cmd.Parameters.AddWithValue("@HoraIni", data.HoraIni);
            cmd.Parameters.AddWithValue("@HoraFin", data.HoraFin);
            cmd.Parameters.AddWithValue("@IDSitio", data.IdSitio);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        public int eliminaAlumnoSP(object obj)
        {
            HorarioBO data = (HorarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "EliminarHorario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodHora", data.CodHora);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }
        public int modificaAlumnoSP(object obj)
        {
            HorarioBO data = (HorarioBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ModificarHorario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodHora", data.CodHora);
            cmd.Parameters.AddWithValue("@HoraIni", data.HoraIni);
            cmd.Parameters.AddWithValue("@HoraFin", data.HoraFin);
            cmd.Parameters.AddWithValue("@IDSitio", data.IdSitio);
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