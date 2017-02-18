using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebServiceProyecto.BO;

namespace WebServiceProyecto.DAO
{
    public class ActividadHoraDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public DataSet devuelveActividadHoraSP(object obj)
        {
            ActividadHoraBO data = (ActividadHoraBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraActividadHora";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDActividad", data.IdActividad);
            cmd.Parameters.AddWithValue("@CodHora", data.CodHora);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            return dsUsuario;
        }
        public DataSet devuelveActividadHora()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetActividadHora";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            return dsUsuario;
        }
        //Agrega 
        public int creaActividadHoraSP(object obj)
        {
            ActividadHoraBO data = (ActividadHoraBO)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarActividadHora";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDActividad", data.IdActividad);
            cmd.Parameters.AddWithValue("@CodHora", data.CodHora);
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