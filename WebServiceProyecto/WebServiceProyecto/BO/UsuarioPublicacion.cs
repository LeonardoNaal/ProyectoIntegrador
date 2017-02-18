using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class UsuarioPublicacion
    {
        int ID;
        string comentario;
        int CodUsuario;
        int IDPublicacion;

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

        public string Comentario
        {
            get
            {
                return comentario;
            }

            set
            {
                comentario = value;
            }
        }

        public int CodUsuario1
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

        public int IDPublicacion1
        {
            get
            {
                return IDPublicacion;
            }

            set
            {
                IDPublicacion = value;
            }
        }
    }
}