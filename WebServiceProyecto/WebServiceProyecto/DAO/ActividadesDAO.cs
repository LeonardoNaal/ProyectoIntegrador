using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;
using WebServiceProyecto.BO;
namespace WebServiceProyecto.DAO
{
    public class ActividadesDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public string devuelveActividadSP(object obj)
        {
            ActividadesBO data = (ActividadesBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraActividad";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDActividad", data.IdActividad);
            cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
            cmd.Parameters.AddWithValue("@FechaIni", data.FechaIni);
            cmd.Parameters.AddWithValue("@FechaFin", data.FechaFinal);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        
      public string TopActividades()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetTopActividades";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        
        public string devuelveActividad()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetActividad";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }

        //public int cargarCU()
        //{
        //    string sql = ("select MAX(AlumnoID) as'CA' From Alumno");
        //    string campo = "CA";
        //    return con.cargarCodTablas(sql, campo);
        //}

        public int creaActividadSP(object obj)
        {
            ActividadesBO data = (ActividadesBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarActividades";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
            DateTime dt = DateTime.ParseExact(data.FechaIni,"dd/MM/yyyy",CultureInfo.InvariantCulture);
            DateTime dtFin = DateTime.ParseExact(data.FechaFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime h1;
            DateTime.TryParse(data.HoraIni,out h1);
            DateTime h2;
            DateTime.TryParse(data.HoraFin,out h2);
            TimeSpan ts = TimeSpan.Parse(data.HoraIni);
            TimeSpan ts2 = TimeSpan.Parse(data.HoraFin);
            cmd.Parameters.AddWithValue("@HoraInicio",ts);
            cmd.Parameters.AddWithValue("@HoraFin", ts2);
            cmd.Parameters.AddWithValue("@FechaIni",dt);
            cmd.Parameters.AddWithValue("@FechaFin", dtFin);
            cmd.Parameters.AddWithValue("@CodUsuario", data.CodUsuario);
            cmd.Parameters.AddWithValue("@IDSitio",data.IdSitio);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        public int eliminaActividadSP(object obj)
        {
            ActividadesBO data = (ActividadesBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "EliminarActividades";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDActividad", data.IdActividad);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }
        public int modificaActividadSP(object obj)
        {
            ActividadesBO data = (ActividadesBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ModificarActividades";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDActividad", data.IdActividad);
            cmd.Parameters.AddWithValue("@Nombre", data.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", data.Descripcion);
            DateTime dt = DateTime.ParseExact(data.FechaIni, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtFin = DateTime.ParseExact(data.FechaFinal, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime h1;
            DateTime.TryParse(data.HoraIni, out h1);
            DateTime h2;
            DateTime.TryParse(data.HoraFin, out h2);
            TimeSpan ts = TimeSpan.Parse(data.HoraIni);
            TimeSpan ts2 = TimeSpan.Parse(data.HoraFin);
            cmd.Parameters.AddWithValue("@HoraInicio", ts);
            cmd.Parameters.AddWithValue("@HoraFin", ts2);
            cmd.Parameters.AddWithValue("@FechaIni", dt);
            cmd.Parameters.AddWithValue("@FechaFin", dtFin);
            cmd.Parameters.AddWithValue("@CodUsuario", data.CodUsuario);
            cmd.Parameters.AddWithValue("@IDSitio", data.IdSitio);
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