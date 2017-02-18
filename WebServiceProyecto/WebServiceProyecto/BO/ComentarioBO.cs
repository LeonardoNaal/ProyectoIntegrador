using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class ComentarioBO
    {
        int id;
        string contenido;
        string codUsuario;
       int codPub;
        string fecha;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Contenido
        {
            get
            {
                return contenido;
            }

            set
            {
                contenido = value;
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
        

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int CodPub
        {
            get
            {
                return codPub;
            }

            set
            {
                codPub = value;
            }
        }
    }
}