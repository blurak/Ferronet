using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Utilitarios.Tablas;
namespace Logica
{
    public class LAuditoria
    {
        public EAuditoria AuditoriaModificarControl(EControles antiguo,EControles nuevo)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            auditoria.Accion = "UPDATE";
            auditoria.Schema = "idioma";
            auditoria.Tabla = "controles";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Data = "{";
            if (!antiguo.Texto.Equals(nuevo.Texto))
                auditoria.Data += "\"" + "texto" + "_antiguo: " + "\"" + antiguo.Texto + " ," + "\"" + "texto" + "_nuevo: " + "\"" + nuevo.Texto + " ,";

            if (!antiguo.Control.Equals(nuevo.Control))
                auditoria.Data += "\"" + "control" + "_antiguo: " + "\"" + antiguo.Control + " ," + "\"" + "control" + "_nuevo: " + "\"" + nuevo.Control + " ,";

            if (!antiguo.IdIdioma.Equals(nuevo.IdIdioma))
                auditoria.Data += "\"" + "id_idioma" + "_antiguo: " + "\"" + antiguo.IdIdioma + " ," + "\"" + "id_idioma" + "_nuevo: " + "\"" + nuevo.IdIdioma + " ,";

            if (!antiguo.IdFormulario.Equals(nuevo.IdFormulario))
                auditoria.Data += "\"" + "id_formulario" + "_antiguo: " + "\"" + antiguo.IdFormulario + " ," + "\"" + "id_formulario" + "_nuevo: " + "\"" + nuevo.IdFormulario + " ,";

            if (!antiguo.Session.Equals(nuevo.Session))
                auditoria.Data += "\"" + "session" + "_antiguo: " + "\"" + antiguo.Session + " ," + "\"" + "session" + "_nuevo: " + "\"" + nuevo.Session + " ,";


            auditoria.Data += "}";
            auditoria.Session = nuevo.Session;
            auditoria.Pk = String.Concat(nuevo.Id);

            return auditoria;
        }
        
        public EAuditoria AuditoriaModificarUsuario(PUsuario antiguo,PUsuario nuevo) 
        {

            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            auditoria.Accion = "UPDATE";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "usuario";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Data = "{";
            if (!antiguo.Clave.Equals(nuevo.Clave))
                auditoria.Data += "\"" + "clave" + "_antiguo: " + "\"" + antiguo.Clave + " ," + "\"" + "clave" + "_nuevo: " + "\"" + nuevo.Clave + " ,";

            if (!antiguo.Session.Equals(nuevo.Session))
                auditoria.Data += "\"" + "session" + "_antiguo: " + "\"" + antiguo.Session + " ," + "\"" + "session" + "_nuevo: " + "\"" + nuevo.Session + " ,";

            if (!antiguo.Last.Equals(nuevo.Last))
                auditoria.Data += "\"" + "last_modified" + "_antiguo: " + "\"" + antiguo.Last + " ," + "\"" + "last_modified" + "_nuevo: " + "\"" + nuevo.Last + " ,";

            if (!antiguo.Estado.Equals(nuevo.Estado))
                auditoria.Data += "\"" + "estado" + "_antiguo: " + "\"" + antiguo.Estado + " ," + "\"" + "estado" + "_nuevo: " + "\"" + nuevo.Estado + " ,";

            if (!antiguo.SesionesActivas.Equals(nuevo.SesionesActivas))
                auditoria.Data += "\"" + "sesiones_activas" + "_antiguo: " + "\"" + antiguo.SesionesActivas + " ," + "\"" + "sesiones_activas" + "_nuevo: " + "\"" + nuevo.SesionesActivas + " ,";

            if (!antiguo.SesionesMaximas.Equals(nuevo.SesionesMaximas))
                auditoria.Data += "\"" + "sesiones_maximas" + "_antiguo: " + "\"" + antiguo.SesionesMaximas + " ," + "\"" + "sesiones_maximas" + "_nuevo: " + "\"" + nuevo.SesionesMaximas + " ,";

            if (!antiguo.IntentosIncorrectos.Equals(nuevo.IntentosIncorrectos))
                auditoria.Data += "\"" + "intentos_incorrectos" + "_antiguo: " + "\"" + antiguo.IntentosIncorrectos + " ," + "\"" + "intentos_incorrectos" + "_nuevo: " + "\"" + nuevo.IntentosIncorrectos + " ,";
            try
            {
                if (!antiguo.Baneo.Equals(nuevo.Baneo))
                    auditoria.Data += "\"" + "baneo" + "_antiguo: " + "\"" + antiguo.Baneo + " ," + "\"" + "baneo" + "_nuevo: " + "\"" + nuevo.Baneo + " ,";
            }
            catch (Exception )
            {

            }

            if (!antiguo.Baneado.Equals(nuevo.Baneado))
                auditoria.Data += "\"" + "baneado" + "_antiguo: " + "\"" + antiguo.Baneado + " ," + "\"" + "baneado" + "_nuevo: " + "\"" + nuevo.Baneado + " ,";


            auditoria.Data += "}";
            auditoria.Session = nuevo.Session;
            auditoria.Pk = String.Concat(nuevo.Id);
            return auditoria;
        }

        public EAuditoria AuditoriaModificarPedido(EPedido antiguo, EPedido nuevo)
        {

            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            auditoria.Accion = "UPDATE";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "pedido";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Data = "{";
            if (!antiguo.Estado1.Equals(nuevo.Estado1))
                auditoria.Data += "\"" + "estado" + "_antiguo: " + "\"" + antiguo.Estado1 + " ," + "\"" + "estado" + "_nuevo: " + "\"" + nuevo.Estado1 + " ,";

            if (!antiguo.Session.Equals(nuevo.Session))
                auditoria.Data += "\"" + "session" + "_antiguo: " + "\"" + antiguo.Session + " ," + "\"" + "session" + "_nuevo: " + "\"" + nuevo.Session + " ,";

            if (!antiguo.Last.Equals(nuevo.Last))
                auditoria.Data += "\"" + "last_modified" + "_antiguo: " + "\"" + antiguo.Last + " ," + "\"" + "last_modified" + "_nuevo: " + "\"" + nuevo.Last + " ,";

  
            auditoria.Data += "}";
            auditoria.Session = nuevo.Session;
            auditoria.Pk = String.Concat(nuevo.IdPedido);
            return auditoria;
        }

        public EAuditoria AuditoriaModificarProductosSede(EProductoSede antiguo, EProductoSede nuevo)
        {

            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            auditoria.Accion = "UPDATE";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "producto_sede";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Data = "{";
            if (!antiguo.Cantidad.Equals(nuevo.Cantidad))
                auditoria.Data += "\"" + "cantidad" + "_antiguo: " + "\"" + antiguo.Cantidad + " ," + "\"" + "cantidad" + "_nuevo: " + "\"" + nuevo.Cantidad + " ,";

            if (!antiguo.Activo.Equals(nuevo.Activo))
                auditoria.Data += "\"" + "activo" + "_antiguo: " + "\"" + antiguo.Activo + " ," + "\"" + "activo" + "_nuevo: " + "\"" + nuevo.Activo + " ,";

            if (!antiguo.Session.Equals(nuevo.Session))
                auditoria.Data += "\"" + "session" + "_antiguo: " + "\"" + antiguo.Session + " ," + "\"" + "session" + "_nuevo: " + "\"" + nuevo.Session + " ,";

            if (!antiguo.Last.Equals(nuevo.Last))
                auditoria.Data += "\"" + "last_modified" + "_antiguo: " + "\"" + antiguo.Last + " ," + "\"" + "last_modified" + "_nuevo: " + "\"" + nuevo.Last + " ,";


            auditoria.Data += "}";
            auditoria.Session = nuevo.Session;
            auditoria.Pk = String.Concat(nuevo.Id);
            return auditoria;
        }

        public EAuditoria AuditoriaModificarProductoSubsede(EProductoSubsede antiguo, EProductoSubsede nuevo)
        {

            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            auditoria.Accion = "UPDATE";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "producto_subsede";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Data = "{";
            if (!antiguo.Cantidad.Equals(nuevo.Cantidad))
                auditoria.Data += "\"" + "cantidad" + "_antiguo: " + "\"" + antiguo.Cantidad + " ," + "\"" + "cantidad" + "_nuevo: " + "\"" + nuevo.Cantidad + " ,";

            if (!antiguo.Session.Equals(nuevo.Session))
                auditoria.Data += "\"" + "session" + "_antiguo: " + "\"" + antiguo.Session + " ," + "\"" + "session" + "_nuevo: " + "\"" + nuevo.Session + " ,";

            if (!antiguo.Last.Equals(nuevo.Last))
                auditoria.Data += "\"" + "last_modified" + "_antiguo: " + "\"" + antiguo.Last + " ," + "\"" + "last_modified" + "_nuevo: " + "\"" + nuevo.Last + " ,";


            auditoria.Data += "}";
            auditoria.Session = nuevo.Session;
            auditoria.Pk = String.Concat(nuevo.Id);
            return auditoria;
        }

        public EAuditoria AuditoriaModificarAutenticacion(EAutenticacion antiguo, EAutenticacion nuevo)
        {

            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            auditoria.Accion = "UPDATE";
            auditoria.Schema = "security";
            auditoria.Tabla = "autenticacion";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Data = "{";
            if (!antiguo.FechaFin.Equals(nuevo.FechaFin))
                auditoria.Data += "\"" + "fecha_fin" + "_antiguo: " + "\"" + antiguo.FechaFin + " ," + "\"" + "fecha_fin" + "_nuevo: " + "\"" + nuevo.FechaFin + " ,";

            if (!antiguo.Session.Equals(nuevo.Session))
                auditoria.Data += "\"" + "session" + "_antiguo: " + "\"" + antiguo.Session + " ," + "\"" + "session" + "_nuevo: " + "\"" + nuevo.Session + " ,";



            auditoria.Data += "}";
            auditoria.Session = nuevo.Session;
            auditoria.Pk = String.Concat(nuevo.Id);
            return auditoria;
        }

    }

}
