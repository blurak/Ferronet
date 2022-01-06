using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Utilitarios;
using Utilitarios.Tablas;

namespace Datos
{
    public  class Mapeo:DbContext
    {
        private readonly string schema;
        public DbSet<PUsuario> usuario { get; set; }
        public DbSet<EProducto> producto { get; set; }
        public DbSet<EProductoSede> productoSede { get; set; }
        public DbSet<ECategoria>  categoria { get; set; }
        public DbSet<EProveedor> proveedores { get; set; }
        public DbSet<EAutenticacion> autenticacion { get; set; }
        public DbSet<ESubsede> subsede { get; set; }
        public DbSet<ESede> sede { get; set; }
        public DbSet<EPedido> Pedido { get; set; }
        public DbSet<EProductoSubsede> productoSubsede { get; set; }
        public DbSet<Eventas> Ventas { get; set; }
        public DbSet<EDetalleVenta> DetalleVenta { get; set; }
        public DbSet<EDetallePedido> DetallePedido { get; set; }
        public DbSet<EtokenRecuperacionUsuario> tokenRecuperacion { get; set; }
        public DbSet<EControles> controles { get; set; }
        public DbSet<EIdioma> idioma { get; set; }
        public DbSet<EFormulario> formulario { get; set; }
        public DbSet<EAuditoria> auditoria { get; set; }
        public DbSet<Epruebiña> prueba { get; set; }
        public DbSet<EServicio> servicio { get; set; }



        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }

        public Mapeo(String schema) : base("name=ferronetContext")
        {
            this.schema = schema;
        }

        public Mapeo() : base("name=ferronetContext")
        {
      
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(this.schema);
            base.OnModelCreating(modelBuilder);
        }
    }
}
