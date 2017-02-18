using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class TipoPublicacionBO
    {
        public TipoPublicacionBO() { }

        int idTipo;
        string nomTipo;

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