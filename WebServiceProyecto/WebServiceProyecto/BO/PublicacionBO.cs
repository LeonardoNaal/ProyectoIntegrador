using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
namespace WebServiceProyecto.BO
{
    public class PublicacionBO
    {
        public PublicacionBO() { }

        int idPublicacion;
        string titulo;
        string contenido;
        int idTipo;
        string codUsuario;
        Byte[] imagen;
        Byte[] video;
        public int IdPublicacion
        {
            get
            {
                return idPublicacion;
            }

            set
            {
                idPublicacion = value;
            }
        }

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
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

        public int IdTipo
        {
            get
            {
                return idTipo;
            }

            set
            {
                idTipo = value;
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

        public byte[] Imagen
        {
            get
            {
                return imagen;
            }

            set
            {
                imagen = value;
            }
        }

        public byte[] Video
        {
            get
            {
                return video;
            }

            set
            {
                video = value;
            }
        }
    }
}