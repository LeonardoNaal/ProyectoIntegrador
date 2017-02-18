using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web;
using WebServiceProyecto.BO;

namespace WebServiceProyecto.DAO
{
    public class ActividadUsuarioDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public string AsistenciaActividades(object obj)
        {
            ActividadUsuario data=(ActividadUsuario)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetAsistencia";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", data.IDActividad1);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            dsUsuario.AcceptChanges();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }

        public int creaActividadUsuarioSP(object obj)
        {
            ActividadUsuario data = (ActividadUsuario)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarActividadUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Asistencia", data.Asistencia1);
            cmd.Parameters.AddWithValue("@IDActividad", data.IDActividad1);
            cmd.Parameters.AddWithValue("@IDUsuario", data.CodUsuario1);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }

        public int ComprobarExistActividadSP(object obj)
        {
            ActividadUsuario data = (ActividadUsuario)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "Comprobar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID1", data.IDActividad1);
            cmd.Parameters.AddWithValue("@ID2", data.CodUsuario1);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            // validamos si se  Actualizo de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public DataTable cargarCA(int idAct,string coduser)
        {
            con = new ConexionBD();
            string sql = ("select * From ActividadUsuario where IDActividad=" + idAct + " and CodUsuario='"+coduser+"'");
            return con.Tablas(sql, "ActividadUsuario");
        }

        public int modificaActividadUsuarioSP(object obj)
        {
            ActividadUsuario data = (ActividadUsuario)obj;
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ModificarActividadUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID",data.ID1);
            int val=0;
            if (data.Asistencia1 == true)
            {
               val = 1;
            }
            else
            {
                val = 0;
            }
            cmd.Parameters.AddWithValue("@Asistencia", val);
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