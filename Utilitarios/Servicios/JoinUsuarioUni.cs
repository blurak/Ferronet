using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Servicios
{
    public class JoinUsuarioUni
    {
        private String nombre;
        private String titulo;
        private String habilidad1;
        private String habilidad2;
        private String habilidad3;
        private int id_aspirante;
        private String apellido;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Habilidad1 { get => habilidad1; set => habilidad1 = value; }
        public string Habilidad2 { get => habilidad2; set => habilidad2 = value; }
        public string Habilidad3 { get => habilidad3; set => habilidad3 = value; }
        public int Id_aspirante { get => id_aspirante; set => id_aspirante = value; }
        public string Apellido { get => apellido; set => apellido = value; }
    }
}
