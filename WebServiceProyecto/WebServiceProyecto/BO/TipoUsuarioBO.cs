using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceProyecto.BO
{
    public class TipoUsuarioBO
    {
        public TipoUsuarioBO()
        {}

        int codTipo;
        string nombreTipo;

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

        public string NombreTipo
        {
            get
            {
                return nombreTipo;
            }

            set
            {
                nombreTipo = value;
            }
        }
    }
}