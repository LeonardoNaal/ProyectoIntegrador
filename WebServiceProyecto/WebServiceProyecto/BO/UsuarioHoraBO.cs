using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class UsuarioHoraBO
    {
        public UsuarioHoraBO() { }
        int id;
        int codHora;
        string codUsuario;
        string dia;
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

        public string Dia
        {
            get
            {
                return dia;
            }

            set
            {
                dia = value;
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
    }
}