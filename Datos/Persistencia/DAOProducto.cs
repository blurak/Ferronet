using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Utilitarios.Tablas;

namespace Datos.Persistencia
{
    public class DAOProducto
    {
        private DAOAuditoria auditoria = new DAOAuditoria();
        public ESubsede obtenerIdSubsede(int idUsuario)
        {
            using (var db = new Mapeo())
            {
                return db.subsede.FirstOrDefault(x => x.IdCajero == idUsuario);


            }
        }

        public void insertarVenta(Eventas venta)
        {
            ESubsede sub = new ESubsede();
            sub = obtenerIdSubsede(venta.IdUsusario);
            venta.IdSubsede = sub.Id;
            using (var db = new Mapeo())
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
            }

            auditoria.AuditoriaInsertarVenta(venta);
        }

        public Eventas obtenerIdVenta(String dia,String hora)
        {
            using (var db = new Mapeo())
            {
                return db.Ventas.FirstOrDefault(x => x.Dia.Contains(dia) & x.Hora.Contains(hora));
            }
        }

        public void insertarDetalleVenta(EDetalleVenta detalleVenta)
        {
            using (var db = new Mapeo())
            {
                db.DetalleVenta.Add(detalleVenta);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarDetalleVenta(detalleVenta);

        }

        public void modificarValorTotalVenta(Eventas venta)
        {
            using (var context = new Mapeo())
            {
                var cliente = context.Ventas.Find(venta.Id);
                cliente.ValorTotal = venta.ValorTotal;
                context.SaveChanges();
            }
        }

        public void modificarCantidadDeSub(int idProducto,int cantidad)
        {
            EProductoSubsede sub = new EProductoSubsede();
            sub = devolverSubsede(idProducto);
            using (var context = new Mapeo())
            {
                var cliente = context.productoSubsede.Find(sub.Id);
                cliente.Cantidad =cliente.Cantidad- cantidad;
                context.SaveChanges();
            }
        }

        public EProductoSubsede devolverSubsede(int idProducto)
        {
            using (var db = new Mapeo())
            {
                return db.productoSubsede.FirstOrDefault(x => x.IdProducto==idProducto);


            }
        }

    }
}
