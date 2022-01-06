using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinIdiomaControles
    {
        private String control;
        private String texto;
        private int id;
        private int idFormulario;

        public string Control { get => control; set => control = value; }
        public string Texto { get => texto; set => texto = value; }
        public int Id { get => id; set => id = value; }
        public int IdFormulario { get => idFormulario; set => idFormulario = value; }
    }
}
