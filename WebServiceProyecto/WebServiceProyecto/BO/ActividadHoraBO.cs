using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class ActividadHoraBO
    {
        public ActividadHoraBO() { }
        int idActividad;
        int codHora;

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

        public int CodHora
        {
            get
            {
                return codHora;
            }

            set
            {
                codHora = value;
            }
        }
    }
}