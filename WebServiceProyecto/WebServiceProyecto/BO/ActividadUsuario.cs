using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class ActividadUsuario
    {
        int ID;
        int IDActividad;
        bool Asistencia;
       string CodUsuario;

        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public int IDActividad1
        {
            get
            {
                return IDActividad;
            }

            set
            {
                IDActividad = value;
            }
        }

        public bool Asistencia1
        {
            get
            {
                return Asistencia;
            }

            set
            {
                Asistencia = value;
            }
        }
        

        public string CodUsuario1
        {
            get
            {
                return CodUsuario;
            }

            set
            {
                CodUsuario = value;
            }
        }
    }
}