using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Servicios
{
   public class TopSubsedes
    {
        private int codigo;
        private String subsede;
        private String sedeCentral;
        private String cajero;
        private String administrador;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Subsede { get => subsede; set => subsede = value; }
        public string SedeCentral { get => sedeCentral; set => sedeCentral = value; }
        public string Cajero { get => cajero; set => cajero = value; }
        public string Administrador { get => administrador; set => administrador = value; }
    }
}
