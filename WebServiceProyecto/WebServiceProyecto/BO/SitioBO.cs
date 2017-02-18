using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class SitioBO
    {
        public SitioBO() { }

        int idSitio;
        string nombre;
        int tipoSitio;
        int planta;

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

        public int Planta
        {
            get
            {
                return planta;
            }

            set
            {
                planta = value;
            }
        }

        public int TipoSitio
        {
            get
            {
                return tipoSitio;
            }

            set
            {
                tipoSitio = value;
            }
        }
    }
}