using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class UsuarioBO
    {
        public UsuarioBO() { }
        string idUsuario;
        string nombre;
        string apePat;
        string apeMat;
        string password;
        int codTipo;
        string nomTipo;

        public string IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
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

        public string ApePat
        {
            get
            {
                return apePat;
            }

            set
            {
                apePat = value;
            }
        }

        public string ApeMat
        {
            get
            {
                return apeMat;
            }

            set
            {
                apeMat = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public int CodTipo
        {
            get
            {
                return codTipo;
            }

            set
            {
                codTipo = value;
            }
        }

        public string NomTipo
        {
            get
            {
                return nomTipo;
            }

            set
            {
                nomTipo = value;
            }
        }
    }
}