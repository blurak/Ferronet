//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sql
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string usuario1 { get; set; }
        public string correo { get; set; }
        public Nullable<int> id_rol { get; set; }
        public string session { get; set; }
        public Nullable<System.DateTime> last_modified { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<int> sesiones_activas { get; set; }
        public Nullable<int> sessiones_maximas { get; set; }
        public Nullable<int> intentos_incorrectos { get; set; }
        public Nullable<System.DateTime> baneo { get; set; }
        public Nullable<bool> baneado { get; set; }
    }
}