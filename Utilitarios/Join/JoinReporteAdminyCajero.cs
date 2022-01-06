using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinReporteAdminyCajero
    {
        string nombre;
        int idCajero;
        int idAdmin;
        string cajero;
        string admins;

        public string Nombre { get => nombre; set => nombre = value; }
        public int IdCajero { get => idCajero; set => idCajero = value; }
        public int IdAdmin { get => idAdmin; set => idAdmin = value; }
        public string Cajero { get => cajero; set => cajero = value; }
        public string Admins { get => admins; set => admins = value; }
    }
}
