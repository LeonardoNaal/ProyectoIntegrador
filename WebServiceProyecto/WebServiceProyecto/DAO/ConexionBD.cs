using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace WebServiceProyecto.DAO
{
    public class ConexionBD
    {
        SqlConnection con;
        public ConexionBD()
        {

        }
        SqlCommand cmd;
        SqlDataReader respuesta;
        int res2 = 0;
        public int cargarCodTablas(string sql, string campo)
        {
            cmd = new SqlCommand(sql, establecerConexion());
            abrirConexion();
            respuesta = cmd.ExecuteReader();
            if (respuesta.Read())
            {
                res2 = Convert.ToInt32(respuesta[campo]);
            }
            respuesta.Close();
            return res2;
        }
        string res="";
        public string cargarTablas(string sql, string campo)
        {
            cmd = new SqlCommand(sql, establecerConexion());
            abrirConexion();
            respuesta = cmd.ExecuteReader();
            if (respuesta.Read())
            {
                res = respuesta[campo].ToString();
            }
            respuesta.Close();
            return res;
        }
        public SqlConnection establecerConexion()
        {
            //string cs = "Data Source=.\\sqlexpress;Initial Catalog=TiendaEnLinea;Integrated Security=True";
            string cs = "Data Source=DMAYCEN\\SQLEXPRESS;Initial Catalog=BDUTM;Integrated Security=True";
            con = new SqlConnection(cs);
            return con;
        }
        public DataTable Tablas(string sql, string nombre)
        {
            try
            {
                SqlDataAdapter datta = new SqlDataAdapter(sql, establecerConexion());
                DataTable TablaNueva = new DataTable(nombre);
                datta.Fill(TablaNueva);
                return TablaNueva;
            }
            catch
            {
                DataTable TablaNueva = new DataTable();
                return TablaNueva;
            }
        }
        //haciendo una sobrecarga del mismo metodo para modificar los valores de la coneccion
        public SqlConnection establecerConexion(string conexionString)
        {
            string cs = conexionString;
            con = new SqlConnection(cs);
            return con;
        }
        public void abrirConexion()
        {
            con.Open();
        }
        public void cerrarConexion()
        {
            con.Close();
        }
    }
}