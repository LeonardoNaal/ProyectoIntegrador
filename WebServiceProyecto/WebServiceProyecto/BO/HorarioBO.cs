using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class HorarioBO
    {
        public HorarioBO() { }

        int codHora;
        string horaIni;
        string horaFin;
        int idSitio;

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