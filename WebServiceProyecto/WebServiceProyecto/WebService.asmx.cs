using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceProyecto.BO;
using WebServiceProyecto.DAO;
using System.Data.SqlClient;
using System.Data;
namespace WebServiceProyecto
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void UsuarioBo(UsuarioBO obj) { }
        [WebMethod]
        public void PublicacionBo(PublicacionBO obj) { }
        [WebMethod]
        public void TipoUsuarioBo(TipoUsuarioBO obj) { }
        [WebMethod]
        public void SitioBo(SitioBO obj) { }
        [WebMethod]
        public void ActividadBo(ActividadesBO obj) { }
        [WebMethod]
        public void HorarioBo(HorarioBO obj) { }
        [WebMethod]
        public void usuarioHoraBo(UsuarioHoraBO obj) { }
        [WebMethod]
        public void ActividadHoraBo(ActividadHoraBO obj) { }
        [WebMethod]
        public void TipoPublicacionBo(TipoPublicacionBO obj) { }
        [WebMethod]
        public void ComentarioBO(ComentarioBO obj) { }
        [WebMethod]
        public int AgregarComentario(object ob)
        {
            ComentarioDAO s = new ComentarioDAO();
            return s.creaComentarioSP(ob);
        }
        [WebMethod]
        public string DevuelveComentarios(object obj)
        {
            ComentarioDAO f = new ComentarioDAO();
            return f.devuelveComentario(obj);
        }
        [WebMethod]
        public string filtrocomentario(object ob)
        {
            ComentarioDAO k = new ComentarioDAO();
            return k.devuelveComentarioSP(ob);
        }
        [WebMethod]
        public int cargarCodTipoSitio(string tipo)
        {
            SitioDAO s = new SitioDAO();
            return s.cargarCodTipoSitio(tipo);
        }
        [WebMethod]
        public string jsonpublicaciones()
        {
            PublicacionDAO s = new PublicacionDAO();
            return s.jsonPublicacion();
        }
        [WebMethod]
        public string jsonAviso()
        {
            PublicacionDAO s = new PublicacionDAO();
            return s.jsonAviso();
        }
        [WebMethod]
        public string jsonPublicidad()
        {
            PublicacionDAO s = new PublicacionDAO();
            return s.jsonPublicidad();
        }
        [WebMethod]
        public string jsonReporte()
        {
            PublicacionDAO s = new PublicacionDAO();
            return s.jsonReporte();
        }
        [WebMethod]
        public byte[] imagenes(int cod)
        {
            PublicacionDAO s = new PublicacionDAO();
            return s.imagen(cod);
        }
        [WebMethod]
        public DataSet Videos(int cod)
        {
            PublicacionDAO s = new PublicacionDAO();
            return s.video(cod);
        }
        [WebMethod]
        public void ActividadUsuarioBO(ActividadUsuario obj) { }
        [WebMethod]
        public string AsistenciaActividades(object obj)
        {
            ActividadUsuarioDAO a = new ActividadUsuarioDAO();
            return a.AsistenciaActividades(obj);
        }
        [WebMethod]
        public DataTable cargarCA(int codA, string codUser)
        {
            ActividadUsuarioDAO a = new ActividadUsuarioDAO();
            return a.cargarCA(codA, codUser);
        }
        [WebMethod]
        public int ModificarActividadUsuario(object ob)
        {
            ActividadUsuarioDAO a = new ActividadUsuarioDAO();
            return a.modificaActividadUsuarioSP(ob);
        }
        [WebMethod]
        public int AgregarActividadUsuario(object obj)
        {
            ActividadUsuarioDAO a = new ActividadUsuarioDAO();
            return a.creaActividadUsuarioSP(obj);
        }
        [WebMethod]
        public int ComprobarExistActividad(object ob)
        {
            ActividadUsuarioDAO a = new ActividadUsuarioDAO();
            return a.ComprobarExistActividadSP(ob);
        }
        [WebMethod]
        //Usuario ABC y B
        public int AgregarUsuario(object obj) {
            UsuarioDAO l = new UsuarioDAO();
            return l.creaUsuarioSP(obj);
        }
        [WebMethod]
        public int EliminarUsuario(object obj)
        {
            UsuarioDAO m = new UsuarioDAO();
            return m.eliminaUsuarioSP(obj);
        }
        [WebMethod]
        public int modificarUsuario(object obj) {
            UsuarioDAO u = new UsuarioDAO();
            return u.modificaUsuarioSP(obj);
        }
        [WebMethod]
        public string Usuarios() {
            UsuarioDAO s = new UsuarioDAO();
            return s.devuelveUsuario();
        }
        [WebMethod]
        public string BuscarUsuario(object obj)
        {
            UsuarioDAO s = new UsuarioDAO();
            return s.devuelveUsuarioSP(obj);
        }
        [WebMethod]
        public int CodigoTipoUsuario(string Nombre)
        {
            UsuarioDAO s = new UsuarioDAO();
            return s.cargarCodTipoUser(Nombre);
        }
        [WebMethod]
        public int ValidarUsuario(object obj)
        {
            UsuarioDAO f = new UsuarioDAO();
            return f.Loguin(obj);
        }
        [WebMethod]
        public DataTable VistaReporteUser()
        {
            UsuarioDAO f = new UsuarioDAO();
            return f.VistaReporteUsuario();
        }
        [WebMethod]
        //TipoUsuario ABC y B
        public int AgregarTipoUsuario(object obj)
        {
            TipoUsuarioDAO l = new TipoUsuarioDAO();
            return l.creaTipoUsuarioSP(obj);
        }
        [WebMethod]
        public int EliminarTipoUsuario(object obj)
        {
            TipoUsuarioDAO l = new TipoUsuarioDAO();
            return l.eliminaTipoUsuarioSP(obj);
        }
        [WebMethod]
        public int modificarTipoUsuario(object obj)
        {
            TipoUsuarioDAO l = new TipoUsuarioDAO();
            return l.modificaTipoUsuarioSP(obj);
        }
        [WebMethod]
        public string NomTipoUsuario(int cod)
        {
            TipoUsuarioDAO l = new TipoUsuarioDAO();
            return l.cargarTipoUser(cod);
        }
        [WebMethod]
        public string TiposUsuarios()
        {
            TipoUsuarioDAO l = new TipoUsuarioDAO();
            return l.devuelveTiposUsuarios();
        }
        [WebMethod]
        public string TiposUsuariosAdmin()
        {
            TipoUsuarioDAO l = new TipoUsuarioDAO();
            return l.devuelveTiposUsuariosAdmin();
        }
        [WebMethod]
        public string BuscarTipoUsuario(object obj)
        {
            TipoUsuarioDAO l = new TipoUsuarioDAO();
            return l.devuelveTiposUsuariosSP(obj);
        }
        [WebMethod]
        //Actividad A,B,C Y B       
        public int AgregarActividad(object obj)
        {
            ActividadesDAO l = new ActividadesDAO();
            return l.creaActividadSP(obj);
        }
        [WebMethod]
        public string TopActividades()
        {
            ActividadesDAO l = new ActividadesDAO();
            return l.TopActividades();
        }
        [WebMethod]
        public int EliminarActividad(object obj)
        {
            ActividadesDAO l = new ActividadesDAO();
            return l.eliminaActividadSP(obj);
        }
        [WebMethod]
        public int modificarActividad(object obj)
        {
            ActividadesDAO l = new ActividadesDAO();
            return l.modificaActividadSP(obj);
        }
        [WebMethod]
        public string Actividades()
        {
            ActividadesDAO l = new ActividadesDAO();
            return l.devuelveActividad();
        }
        [WebMethod]
        public string BuscarActividad(object obj)
        {
            ActividadesDAO l = new ActividadesDAO();
            return l.devuelveActividadSP(obj);
        }
        [WebMethod]
        //Actividad Hora
        public int AgregarActividadHora(object obj)
        {
            ActividadHoraDAO l = new ActividadHoraDAO();
            return l.creaActividadHoraSP(obj);
        }
        [WebMethod]
        public DataSet EliminarActividadHora()
        {
            ActividadHoraDAO l = new ActividadHoraDAO();
            return l.devuelveActividadHora();
        }
        [WebMethod]
        //Horario
        public int AgregarHorario(object obj)
        {
            HorarioDAO l = new HorarioDAO();
            return l.creaHorarioSP(obj);
        }
        [WebMethod]
        public int EliminarHorario(object obj)
        {
            HorarioDAO l = new HorarioDAO();
            return l.eliminaAlumnoSP(obj);
        }
        [WebMethod]
        public int modificarHorario(object obj)
        {
            HorarioDAO l = new HorarioDAO();
            return l.modificaAlumnoSP(obj);
        }
        [WebMethod]
        public string TiposHorario()
        {
            HorarioDAO l = new HorarioDAO();
            return l.devuelveHorario();
        }
        [WebMethod]
        public DataSet BuscarHorario(object obj)
        {
            HorarioDAO l = new HorarioDAO();
            return l.devuelveHorarioSP(obj);
        }
        [WebMethod]
        //Publicación A,B,C Y B
        public int AgregarPublicacion(object obj)
        {
            PublicacionDAO l = new PublicacionDAO();
            return l.creaPublicacionSP(obj);
        }
        [WebMethod]
        public string TopPublicaciones()
        {
            PublicacionDAO l = new PublicacionDAO();
            return l.TopPublicaciones();
        }
        [WebMethod]
        public string TopPublicaciones2()
        {
            PublicacionDAO l = new PublicacionDAO();
            return l.TopPublicaciones2();
        }
        [WebMethod]
        public int EliminarPublicacion(object obj)
        {
            PublicacionDAO l = new PublicacionDAO();
            return l.eliminaPublicacionSP(obj);
        }

        [WebMethod]
        public int modificarPublicacion(object obj)
        {
            PublicacionDAO l = new PublicacionDAO();
            return l.modificaPublicacionSP(obj);
        }

        [WebMethod]
        public string BuscarPublicaciones(object obj)
        {
            PublicacionDAO l = new PublicacionDAO();
            return l.devuelvePublicacionSP(obj);
        }
        [WebMethod]
        //Sítio A,B,C Y B
        public int AgregarSitio(object obj)
        {
            SitioDAO l = new SitioDAO();
            return l.creaSitioSP(obj);
        }
        [WebMethod]
        public int EliminarSitio(object obj)
        {
            SitioDAO l = new SitioDAO();
            return l.eliminaSitioSP(obj);
        }
        [WebMethod]
        public string GetUser()
        {
            UsuarioDAO s = new UsuarioDAO();
            return s.GetUser();
        }
        [WebMethod]

        public int modificarSitio(object obj)
        {
            SitioDAO l = new SitioDAO();
            return l.modificaSitioSP(obj);
        }
        [WebMethod]
        public string GetHora()
        {
            HorarioDAO l = new HorarioDAO();
            return l.devuelveHora();
        }
        [WebMethod]
        public string GetTipoSitios()
        {
            SitioDAO s = new SitioDAO();
            return s.devuelveTiposSitio();
        }
        [WebMethod]
        public string Sitios()
        {
            SitioDAO l = new SitioDAO();
            return l.devuelveSitio();
        }
        [WebMethod]
        public string BuscarSitio(object obj)
        {
            SitioDAO l = new SitioDAO();
            return l.devuelveSitioSP(obj);
        }
        [WebMethod]
        //TipoPublicacion A,B,C Y B
        public int AgregarTipoPublicacion(object obj)
        {
            TipoPublicacionDAO l = new TipoPublicacionDAO();
            return l.creatipoPublicacionSP(obj);
        }
        [WebMethod]
        public int EliminarTipoPublicacion(object obj)
        {
            TipoPublicacionDAO l = new TipoPublicacionDAO();
            return l.eliminaTipoPublicacionSP(obj);
        }
        [WebMethod]
        public int modificarTipoPublicacion(object obj)
        {
            TipoPublicacionDAO l = new TipoPublicacionDAO();
            return l.modificaTipoPublicacionSP(obj);
        }
        [WebMethod]
        public string TiposPublicaciones()
        {
            TipoPublicacionDAO l = new TipoPublicacionDAO();
            return l.devuelveTiposPublicaciones();
        }
        [WebMethod]
        public DataSet BuscarTipoPublicacion(object obj)
        {
            TipoPublicacionDAO l = new TipoPublicacionDAO();
            return l.devuelveTiposPublicacionesSP(obj);
        }
        [WebMethod]
         //Usuario Hora
       public int AgregarUsuarioHora(object obj)
        {
            UsuarioHoraDAO l = new UsuarioHoraDAO();            
            return l.creaUsuarioHoraSP(obj);
        }
        [WebMethod]
        public string BuscarUsuarioHora(object obj)
        {
            UsuarioHoraDAO s = new UsuarioHoraDAO();
            return s.BuscarUsuarioHora(obj);
        }
        [WebMethod]
        public int EliminarUsuarioHora(object obj)
        {
            UsuarioHoraDAO d = new UsuarioHoraDAO();
            return d.eliminaUsuarioHoraSP(obj);
        }
        [WebMethod]
        public string devuelveUsuarioHoraSP(object ok)
        {
            UsuarioHoraDAO d = new UsuarioHoraDAO();
            return d.devuelveUsuarioHoraSP(ok);
        }
        [WebMethod]
        public DataSet UsuariosHoras()
        {
            UsuarioHoraDAO l = new UsuarioHoraDAO();
            return l.devuelveUsuarioHora();
        }
        [WebMethod]
        public int comprobarExistencia(string matricula)
        {
            UsuarioDAO l = new UsuarioDAO();
            return l.ComprobarExistenciaMatricula(matricula);
        }
    }
}
