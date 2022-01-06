using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("usuario", Schema = "usuario")]

    public class PUsuario
    {

            private int id;
            private string nombre;
            private string usuario;
            private string correo;
            private string clave;
            private int idRol;
            private string session;
            private int estado;
            private int sesionesActivas;
            private int sesionesMaximas;
            private int intentosIncorrectos;
            private DateTime baneo;
            private Boolean baneado;
            private String mensajeContrasenaIncorrecta;
            private String mensajeSinSubsedeAsignada;
            private String mensajeBaneado;
            private String mensajeSesionesMaximas;
            private String mensajeUsuarioInexistente;
            private String mensajeUsernameNoDisponible;
            private String mensaje;
            private DateTime last;

            [Key]
            [Column("id")]
            public int Id { get => id; set => id = value; }

            [Column("nombre")]
            public string Nombre { get => nombre; set => nombre = value; }

            [Column("usuario")]
            public string Usuario { get => usuario; set => usuario = value; }

            [Column("correo")]
            public string Correo { get => correo; set => correo = value; }

            [Column("clave")]
            public string  Clave { get => clave; set => clave = value; }

            [Column("id_rol")]
            public int IdRol { get => idRol; set => idRol = value; }

            [Column("session")]
            public String Session { get => session; set => session = value; }

            [Column("estado")]
            public int Estado { get => estado; set => estado = value; }
    
            [Column("sesiones_activas")]
            public int SesionesActivas { get => sesionesActivas; set => sesionesActivas = value; }

            [Column("sessiones_maximas")]
            public int SesionesMaximas { get => sesionesMaximas; set => sesionesMaximas = value; }

            [Column("intentos_incorrectos")]
            public int IntentosIncorrectos { get => intentosIncorrectos; set => intentosIncorrectos = value; }

            [Column("baneo")]
            public DateTime Baneo { get => baneo; set => baneo = value; }

            [Column("baneado")]
            public Boolean Baneado { get => baneado; set => baneado = value; }

            [Column("last_modified")]
            public DateTime Last { get => last; set => last = value; }

            [NotMapped]
            public string MensajeContrasenaIncorrecta { get => mensajeContrasenaIncorrecta; set => mensajeContrasenaIncorrecta = value; }
            [NotMapped]
            public string MensajeSinSubsedeAsignada { get => mensajeSinSubsedeAsignada; set => mensajeSinSubsedeAsignada = value; }
            [NotMapped]
            public string MensajeBaneado { get => mensajeBaneado; set => mensajeBaneado = value; }
            [NotMapped]
            public string MensajeSesionesMaximas { get => mensajeSesionesMaximas; set => mensajeSesionesMaximas = value; }
            [NotMapped]
            public string MensajeUsuarioInexistente { get => mensajeUsuarioInexistente; set => mensajeUsuarioInexistente = value; }
            [NotMapped]
            public string MensajeUsernameNoDisponible { get => mensajeUsernameNoDisponible; set => mensajeUsernameNoDisponible = value; }
            [NotMapped]
            public string Mensaje { get => mensaje; set => mensaje = value; }
        
    }
}
