using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebServiceProyecto.BO;
using Newtonsoft.Json;
namespace WebServiceProyecto.DAO
{
    public class UsuarioDAO
    {
        ConexionBD con;
        //Creamos un dataset sin valores limpio
        //comandos sql
        SqlCommand cmd;
        DataSet dsUsuario;
        //
        SqlDataAdapter da;
        //*******************SP********************
        public string devuelveUsuarioSP(object obj)
        {
            UsuarioBO data = (UsuarioBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "FiltraUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodUsuario", data.IdUsuario);
            cmd.Parameters.AddWithValue("@Nombres", data.Nombre);
            cmd.Parameters.AddWithValue("@Apepat", data.ApePat);
            cmd.Parameters.AddWithValue("@ApeMat", data.ApeMat);
            cmd.Parameters.AddWithValue("@tipouser", data.NomTipo);
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(dsUsuario);
            con.cerrarConexion();
            dsUsuario.AcceptChanges();
            string json = JsonConvert.SerializeObject(dsUsuario, Formatting.Indented);
            return json;
        }
        
        public string devuelveUsuario()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetUsuario";
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
        public string GetUser()
        {
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "GetUser";
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
        
        //public DataSet  VistaReporteUsuario()
        //{
        //    con = new ConexionBD();
        //    string sql = "Select * from Usuarios";
        //    return con.Tablas(sql);
        //}

        public int cargarCU()
        {
            string sql = ("select MAX(AlumnoID) as'CA' From Alumno");
            string campo = "CA";
            return con.cargarCodTablas(sql, campo);
        }

        public DataTable VistaReporteUsuario()
        {
            con = new ConexionBD();
            string sq = "select * from Usuarios ";
            string tabla = "Usuarios";
            return con.Tablas(sq,tabla);       
        }

    public int ComprobarExistenciaMatricula(string matricula)
        {
            cmd = new SqlCommand();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ComprobarExistencia";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Matricula", matricula);
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

        public int creaUsuarioSP(object obj)
        {
            UsuarioBO data = (UsuarioBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "InsertarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodUsuario", data.IdUsuario);
            cmd.Parameters.AddWithValue("@Nombres", data.Nombre);
            cmd.Parameters.AddWithValue("@ApePat", data.ApePat);
            cmd.Parameters.AddWithValue("@ApeMat", data.ApeMat);
            cmd.Parameters.AddWithValue("@password", data.Password);
            cmd.Parameters.AddWithValue("@codigoTipo", data.CodTipo);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }

        public int eliminaUsuarioSP(object obj)
        {
            UsuarioBO data = (UsuarioBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "EliminarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodUsuario", data.IdUsuario);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  inserto de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }

        public int modificaUsuarioSP(object obj)
        {
            UsuarioBO data = (UsuarioBO)obj;            
            cmd = new SqlCommand();
            dsUsuario = new DataSet();
            da = new SqlDataAdapter();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "ModificarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodUsuario",data.IdUsuario);
            cmd.Parameters.AddWithValue("@Nombres", data.Nombre);
            cmd.Parameters.AddWithValue("@ApePat", data.ApePat);
            cmd.Parameters.AddWithValue("@ApeMat", data.ApeMat);
            cmd.Parameters.AddWithValue("@password", data.Password);
            cmd.Parameters.AddWithValue("@CodigoTipo", data.CodTipo);
            int i = cmd.ExecuteNonQuery();
            // validamos si se  Actualizo de manera correcta
            if (i <= 0)
            {
                return 1;
            }
            return 0;
        }

        public int Loguin(object obj)
        {
            UsuarioBO data = (UsuarioBO)obj;
            cmd = new SqlCommand();
            con = new ConexionBD();
            cmd.Connection = con.establecerConexion();
            con.abrirConexion();
            cmd.CommandText = "Loguin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Matricula", data.IdUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", data.Password);            
           int i =Convert.ToInt32( cmd.ExecuteScalar());
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

        public int cargarCodTipoUser(string user)
        {
            con = new ConexionBD();
            string sql = ("select CodigoTipo From TipoUsuario where NomTipo='" + user + "'");
            string campo = "CodigoTipo";
            return con.cargarCodTablas(sql, campo);
        }
    }
}