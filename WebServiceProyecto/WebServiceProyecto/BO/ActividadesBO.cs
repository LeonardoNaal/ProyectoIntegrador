using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class ActividadesBO
    {
        public ActividadesBO() { }
        int idActividad;
        string nombre;
        string descripcion;
        string fechaIni;
        string fechaFinal;
        string codUsuario;
        string horaIni;
        string horaFin;
        int idSitio;
        public int IdActividad
        {
            get
            {
                return idActividad;
            }

            set
            {
                idActividad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string FechaIni
        {
            get
            {
                return fechaIni;
            }

            set
            {
                fechaIni = value;
            }
        }

        public string FechaFinal
        {
            get
            {
                return fechaFinal;
            }

            set
            {
                fechaFinal = value;
            }
        }

        public string CodUsuario
        {
            get
            {
                return codUsuario;
            }

            set
            {
                codUsuario = value;
            }
        }
        

        public string HoraIni
        {
            get
            {
                return horaIni;
            }

            set
            {
                horaIni = value;
            }
        }

        public string HoraFin
        {
            get
            {
                return horaFin;
            }

            set
            {
                horaFin = value;
            }
        }

        public int IdSitio
        {
            get
            {
                return idSitio;
            }

            set
            {
                idSitio = value;
            }
        }
    }
}