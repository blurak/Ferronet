using System;
using Utilitarios;
using Datos;
using System.Data;
using Datos.Dataset;
using System.Collections.Generic;
using Utilitarios.Join;
using Utilitarios.Tablas;
using Datos.Persistencia;
using System.Linq;

namespace Logica
{
    public class LSede
    {

        private EProductoSede antiguo = new EProductoSede();
        private EProductoSede nuevo = new EProductoSede();

        private EProductoSubsede antiguoSub = new EProductoSubsede();
        private EProductoSubsede nuevoSub = new EProductoSubsede();

        private LAuditoria auditoria = new LAuditoria();
        private DAOAuditoria audi = new DAOAuditoria();

        public List<JoinPedidoCliente> obtenerCategorias()
        {
            DAOSede datos = new DAOSede();
            return datos.obtenerCategorias();
        }
        public List<JoinPedidoCliente> obtenerAdministradoresP()
        {
            DAOSede datos = new DAOSede();
            return datos.obtenerAdministradores();
        }

        public List<JoinPedidoCliente> obtenerCajerosP()
        {
            DAOSede datos = new DAOSede();
            return datos.obtenerCajeros();
        }

        /*public List<JoinPedidoCliente> obtenerProductosAsignar(int idUsuario)*/

        public List<JoinPedidoCliente> recuperarProductos(int idusuario)
        {
            DAOSede produc = new DAOSede();
            return produc.obtenerProductosAsignar(idusuario);
        }

        public EProveedor RegistrarProveedor(EProveedor entrada, int idUsuario, String mensajeProveedorRegistrado)
        {
            DProducto pr = new DProducto();

            DataTable resultado = pr.obtenerSede(idUsuario);
            entrada.IdSede = int.Parse(resultado.Rows[0]["id_sede"].ToString());

            DProveedores registrar = new DProveedores();
            registrar.RegistrarProoveedores(entrada);

            entrada.Nombre = "";
            entrada.Correo = "";
            entrada.Telefono = "";
            entrada.Script = @"<script type='text/javascript'>alert('" + mensajeProveedorRegistrado + "');</script>";

            return entrada;
        }

        public InfoReportProsede ObtenerInformeProductosSede(int idUsuario)
        {

            DataRow fila;
            DataTable informacion = new DataTable();
            InfoReportProsede datos = new InfoReportProsede();

            DAOSede pr = new DAOSede();
            List<JoinProductoSede> lista = new List<JoinProductoSede>();
            lista = pr.ReporteProsede(idUsuario);



            informacion = datos.Tables["inventario_principal"];
            DSede provee = new DSede();


            foreach (JoinProductoSede prime in lista)
            {
                fila = informacion.NewRow();
                fila["id_producto"] = prime.Codigo_producto1;
                fila["cantidad"] = prime.Cantidadd1;
                fila["cantidadmin"] = prime.CantidadMin1;
                fila["descripcion"] = prime.Descripcion;
                informacion.Rows.Add(fila);
            }

            return datos;

        }

        public String ValidarSesion(String sesion, String rol)
        {
            String script = "";
            if (sesion.Equals(null))
            {
                script = @"<script type='text/javascript'>SesionNula();</script>";
            }
            else
            {
                if (rol.Equals("2"))
                {
                    //correcto
                }
                else
                {
                    script = @"<script type='text/javascript'>RolIncorrecto();</script>";
                }
            }
            return script;
        }

        public EUsuario RegistrarAdministradorYCajero(EUsuario usuario, String mensaje, String mensajeErroneo)
        {
            PUsuario f = new PUsuario();
            DAOUsuario dao = new DAOUsuario();
            PUsuario tabla = new PUsuario();
            tabla.Usuario = usuario.UserName;
            tabla.Correo = usuario.Correo;
            tabla.Clave = usuario.Clave;
            tabla.Nombre = usuario.Nombre;
            tabla.IdRol = usuario.IdRol;
            tabla.Session = usuario.Session;
            tabla.Estado = 1;
            tabla.SesionesActivas = 0;
            foreach (JoinProductoSubsede d in dao.obtenerSesionesMaximas(tabla.IdRol))
            {
                tabla.SesionesMaximas = d.Codigo_producto1;
            }
            tabla.IntentosIncorrectos = 0;
            // tabla.Baneo = DateTime.
            tabla.Baneado = false;
            f = dao.verificarExistenciaDelUsuario(tabla.Usuario);
            if (f != null)
            {
                usuario.Correo = usuario.Correo;
                usuario.Nombre = usuario.Nombre;
                usuario.UserName = String.Empty;
                usuario.Clave = usuario.Clave;

                usuario.Mensaje = @"<script type='text/javascript'>alert('" + mensajeErroneo + "');</script>";

            }
            else if (f == null)
            {
                tabla.Last = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                dao.registrarUsuario(tabla);

                usuario.UserName = String.Empty;
                usuario.Correo = String.Empty;
                usuario.Clave = String.Empty;
                usuario.Nombre = String.Empty;

                usuario.Mensaje = @"<script type='text/javascript'>alert('" + mensaje + "');</script>";
            }
            return usuario;
            //DUsuario u = new DUsuario();
            //DataTable usu = u.verificarExistenciaDelUsuario(entrada.UserName);

            //if (usu.Rows[0]["verificar_username"].ToString().Equals("true"))
            //{
            //    entrada.Mensaje = @"<script type='text/javascript'>alert('"+mensajeErroneo+"');</script>";
            //    entrada.UserName = "";
            //}
            //else
            //{
            //    u.registrarUsuario(entrada);
            //    entrada.Nombre = "";
            //    entrada.UserName = "";
            //    entrada.Clave = "";
            //    entrada.Correo = "";
            //    entrada.Mensaje = @"<script type='text/javascript'>alert('"+mensaje+"');</script>";
            //}
            //return entrada;
        }

        public EProducto CrearProducto(EProducto entrada, String extension, String nombreArchivo)
        {
            DateTime thisDay = DateTime.Now;

            if (!(string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpe", true) == 0 || string.Compare(extension, ".png", true) == 0))
            {
                entrada.SaveLocation = @"<script type='text/javascript'>alert('" + entrada.MensajeProductoYaAsignado + "');</script>";
            }
            else
            {
                entrada.SaveLocation = "~\\Images\\productos";
                entrada.Milisegundo = thisDay.Minute.ToString() + thisDay.Millisecond.ToString();
                entrada.Imagen = "~\\Images\\productos" + "\\" + entrada.Milisegundo + nombreArchivo;
                if (entrada.Imagen != null)
                {
                    DAOSede registrar = new DAOSede();
                    entrada.Last = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

                    registrar.registrarProducto(entrada);
                    entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeAsignadoCorrectamente + "');</script>";
                    entrada.Precio = 0;
                    entrada.Descripcion = String.Empty;
                    entrada.Categoria = 0;
                }
            }
            return entrada;
        }

        public EProducto AsignarProductoAInventario(EProducto entrada, int idUsuario, EProductoSede encaps)
        {
            DProducto consultar = new DProducto();
            DAOSede sede = new DAOSede();
            ESede sedeencap = new ESede();
            //DataTable resultado = consultar.obtenerSede(idUsuario);
            sedeencap = sede.DevolverSede(idUsuario);


            if (encaps.Cantidad < encaps.CantidadMinima)
            {
                entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeCantidadMinimaMenorACantidadMaxima + "');</script>";
            }
            else
            {
                if (encaps.Cantidad <= 0 | encaps.CantidadMinima <= 0)
                {
                    entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeCantidadNegativa + "');</script>";
                }
                else
                {
                    encaps.IdSede = sedeencap.Id;
                    encaps.Activo = true;
                    DAOSede dao = new DAOSede();
                    encaps.Last = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                    dao.AsignarProducto(encaps);

                    //DataTable y = consultar.AgregarProductos(entrada);

                    entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeAsignadoCorrectamente + "');</script>";
                    entrada.Cantidad = 0;
                    entrada.CantidadMinima = 0;

                    //if (y.Rows[0]["agregar_productos"].ToString().Equals("correcto"))
                    //{
                    //}


                    //if (y.Rows[0]["agregar_productos"].ToString().Equals("productoasignado"))
                    //{

                    //    entrada.Mensaje = @"<script type='text/javascript'>alert('"+entrada.MensajeProductoYaAsignado+"');</script>";
                    //}

                }

            }
            return entrada;
        }

        public void ModificarProductosProximosAterminarsub(int idProducto, int idRegistro, int idUsuario, int cantidad, int codigo_producto, String subsede, String producto, String categoria, int cantidadminima, String imagen, int codigo_registro)
        {
            DSede datos = new DSede();
            datos.ModificarProductosProximosAterminar(idProducto, idRegistro, idUsuario, cantidad, codigo_producto, subsede, producto, categoria, cantidadminima, imagen, codigo_registro);
        }

        public ESubsede RegistrarSubsede(ESubsede entrada, int idUsuario, String mensajeAdminYCajero, String mensajeCorrecto)
        {
            if (entrada.Ubicacion.Equals(""))
            {
                entrada.Ubicacion = "4.7064752877673435, -74.07232940081076";
            }

            if (entrada.IdCajero.ToString().Equals("0") | entrada.IdAdmin.ToString().Equals("0"))
            {

                entrada.Mensaje = @"<script type='text/javascript'>alert('" + mensajeAdminYCajero + "');</script>";

            }
            else
            {
                DProducto obtener = new DProducto();
                DataTable resultado = obtener.obtenerSede(idUsuario);
                DSede s = new DSede();

                entrada.IdSede = int.Parse(resultado.Rows[0]["id_sede"].ToString());


                s.RegistrarSubsede(entrada);

                entrada.Mensaje = @"<script type='text/javascript'>alert('" + mensajeCorrecto + "');</script>";
                entrada.Nombre = "";
                entrada.Ubicacion = "";

            }

            return entrada;
        }

        public InfoReportProvee obtenerReporteProvedorP(int idUsuario)
        {
            DataRow fila;
            DataTable informacion = new DataTable();

            DAOSede colabora = new DAOSede();
            InfoReportProvee datos = new InfoReportProvee();

            informacion = datos.Tables["provee"];
            List<JoinProveedoresCategoria> lista = new List<JoinProveedoresCategoria>();

            lista = colabora.obtenerProveedores(idUsuario);
            foreach (JoinProveedoresCategoria prime in lista)
            {
                fila = informacion.NewRow();
                fila["id"] = prime.IdProveedor;
                fila["nombre"] = prime.Nombre;
                fila["correo"] = prime.Correo;
                fila["telefono"] = prime.Telefono;
                fila["id_categoria"] = prime.Categoria;
                informacion.Rows.Add(fila);
            }
            return datos;
        }

        public InfoReportCajeroyAdmin ObtenerInformeAdminYcajero(int idUsuario)
        {
            DataRow fila;
            DataTable informacion = new DataTable();

            DAOSede colabora = new DAOSede();
            InfoReportCajeroyAdmin datos = new InfoReportCajeroyAdmin();
            informacion = datos.Tables["colaboradores"];
            List<JoinReporteAdminyCajero> lista = new List<JoinReporteAdminyCajero>();
            lista = colabora.ReporteAdminyCajero();


            foreach (JoinReporteAdminyCajero prime in lista)
            {
                fila = informacion.NewRow();
                fila["nombre"] = prime.Nombre;
                fila["id_cajero"] = prime.IdCajero;
                fila["id_admin"] = prime.IdAdmin;
                fila["cajero"] = prime.Cajero;
                fila["administrador"] = prime.Admins;
                informacion.Rows.Add(fila);
            }

            return datos;

        }



        //public DataTable obtenerInventarioSede(int usuario)
        //{
        //    DProducto datos = new DProducto();
        //    DataTable y = datos.obtenerProductosSede(usuario);
        //    return y;
        //}
        public DataTable obtenerInventarioSedebajas(int usuario)
        {
            DProducto datos = new DProducto();
            DataTable y = datos.obtenerProductosBajasCantidadesSede(usuario);
            return y;
        }


        public void modificarInventarioSede(int cantidad, int cantidadmin, int idProducto, int id_usuario, int id_producto, String descripcio, int cantidad_minima)
        {
            DProducto datos = new DProducto();
            datos.modificarCantidades(cantidad, cantidadmin, idProducto, id_usuario, id_producto, descripcio, cantidad_minima);
        }
        public InfoReportProvee ObtenerInformeProveedores(int idUsuario)
        {

            DataRow fila;
            DataTable informacion = new DataTable();
            InfoReportProvee datos = new InfoReportProvee();


            DProducto pr = new DProducto();
            DataTable resultado = pr.obtenerSede(idUsuario);
            int sede = int.Parse(resultado.Rows[0]["id_sede"].ToString());

            informacion = datos.Tables["provee"];
            DProveedores provee = new DProveedores();

            DataTable intermedio = provee.obtenerProvee(sede);
            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                fila = informacion.NewRow();
                fila["id"] = intermedio.Rows[i]["id"].ToString();
                fila["nombre"] = intermedio.Rows[i]["nombre"].ToString();
                fila["correo"] = intermedio.Rows[i]["correo"].ToString();
                fila["telefono"] = intermedio.Rows[i]["telefono"].ToString();
                fila["id_categoria"] = intermedio.Rows[i]["id_categoria"].ToString();
                informacion.Rows.Add(fila);
            }

            return datos;
        }


        public DataTable buscarProductosConId(int idUsuario)
        {
            DataTable resultado = new DataTable();
            DSede consulta = new DSede();
            return resultado = consulta.buscarProductoConIdUsuario(idUsuario);
        }

        public List<JoinProductoSede> buscarProductosEnInventarioSede(String CriterioDeBusqueda, int idUsuario)
        {
            DAOSede datos = new DAOSede();
            return datos.obtenerProductosSede(CriterioDeBusqueda, idUsuario);

            //DataTable resultado = new DataTable();
            //DSede consulta = new DSede();
            //return resultado = consulta.BuscarProductoInventarioSede(CriterioDeBusqueda,idUsuario);
        }

        public EProducto DevolverInformacionDeProducto(EProducto entrada, int idUsuario)
        {
            DAOSede datos = new DAOSede();
            entrada.Cantidad = datos.cantidadDisponible(entrada.IdProducto, idUsuario);
            entrada.Descripcion = datos.nombreProducto(entrada.IdProducto);

            return entrada;
        }


        public EProducto registrarCantidadEnSubsede(EProducto entrada, int idUsuario)
        {

            if (entrada.Cantidad > entrada.CantidadMinima)
            {
                if (entrada.Cantidad <= 0 | entrada.CantidadMinima <= 0)
                {
                    entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeCantidadNegativa + "');</script>";
                }
                else
                {
                    DSede a = new DSede();
                    DataTable y = a.AsignarProductosSubsede(entrada, idUsuario);

                    if (y.Rows[0]["registrar_productos_de_subsede"].ToString().Equals("correcto"))
                    {
                        entrada.Mensaje = @"<script type='text/javascript'> alert('" + entrada.MensajeAsignadoCorrectamente + "');window.close();</script>";
                    }
                    else
                    {
                        if (y.Rows[0]["registrar_productos_de_subsede"].ToString().Equals("productoasignado"))
                        {
                            entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeProductoYaAsignado + "');window.close();</script>";
                        }
                        else
                        {
                            if (y.Rows[0]["registrar_productos_de_subsede"].ToString().Equals("cantidadexcedida"))
                            {
                                entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeCantidadInsuficiente + "');</script>";
                            }
                        }


                    }
                }

            }
            else
            {
                entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeCantidadMinimaMenorACantidadMaxima + "');</script>";

            }
            return entrada;

        }
        public DataTable obtenerAdmins()
        {
            DSede datos = new DSede();
            DataTable y = datos.obtenerAdministradores();
            return y;
        }
        public DataTable obtenerCajeros()
        {
            DSede datos = new DSede();
            DataTable y = datos.obtenerCajeros();
            return y;
        }
        public List<JoinPedidoCliente> obtenerSubsedesInve(int usuario)
        {
            DAOSede datos = new DAOSede();
            //DSede datos = new DSede();
            //DataTable y = datos.obtenerSubsedes(usuario);
            return datos.obtenerSubsede(usuario);
        }
        public DataTable obtenerProximosTer(int usuario)
        {
            DSede datos = new DSede();
            DataTable y = datos.ProductosProximosAterminar(usuario);
            return y;
        }

        public DataTable obtenerSusbsedesSuper(int usuario)
        {
            DSubsede datos = new DSubsede();
            DataTable y = datos.obtenerSubsedesSuper(usuario);
            return y;
        }
        public DataTable obtenerProducotos(int usuario)
        {
            DSubsede datos = new DSubsede();
            DataTable y = datos.obtenerProducotos_subsede(usuario);
            return y;
        }
        public DataTable obtenerVentasDia(int usuario, string fecha)
        {
            DSubsede datos = new DSubsede();
            DataTable y = datos.ObtenerVentasDias(usuario, fecha);
            return y;
        }
        public DataTable DetalleVentas(int usuario)
        {
            DSubsede datos = new DSubsede();
            DataTable y = datos.detalleVenta(usuario);
            return y;
        }
        public DataTable ObtenertotalDetalleVentas(int usuario, string Fecha)
        {
            DSubsede datos = new DSubsede();
            DataTable y = datos.ObtenerTotalVentasHoy(usuario, Fecha);
            return y;
        }
        public DataTable ObtenerVentasDiasuper(int usuario, string Fecha, string fechafin)
        {
            DSubsede datos = new DSubsede();
            DataTable y = datos.ObtenerVentasDiaSuper(usuario, Fecha, fechafin);
            return y;
        }
        public DataTable Totalvendido(int usuario, string Fecha, string fechafin)
        {
            DProducto datos = new DProducto();
            DataTable y = datos.totalVendido(usuario, Fecha, fechafin);
            return y;
        }
        public DataTable ObtenerProductos(int usuario)
        {
            DProducto datos = new DProducto();
            DataTable y = datos.productos_sede_principal(usuario);
            return y;
        }

        public List<JoinProductosProximosATerminar> ProductosProximosATerminars(int idUsuario)
        {
            DAOSede fr = new DAOSede();
            return fr.obtenerProductosProximosATerminar(idUsuario);
        }


        public List<JoinProductoSede> obtenerInventarioSede(int idUsuario)
        {
            DAOSede fr = new DAOSede();
            return fr.obtenerInventarioSede(idUsuario);
        }

        //cantidad, cantidadmin, idProducto, id_usuario, id_producto, descripcio, cantidad_minima, Codigo_producto1, Descripcion, CantidadMin1, Cantidadd1
        public void PmodificarInventarioSede(int cantidad, int cantidadmin, int idProducto, int id_usuario, int id_producto, String descripcio, int cantidad_minima, int Codigo_producto1, String Descripcion, int CantidadMin1, int Cantidadd1)
        {
            DAOSede datos = new DAOSede();
            EProductoSede inventario = new EProductoSede();
            inventario.Id_producto = Codigo_producto1;
            inventario = datos.DevolverIdProductoSede(inventario);
            inventario.Cantidad = Cantidadd1;
            antiguo = datos.devolverProductoSede(inventario.Id);
            datos.ModificarCantidades(inventario);
            nuevo = datos.devolverProductoSede(antiguo.Id);
            audi.AuditoriaModificar(auditoria.AuditoriaModificarProductosSede(antiguo, nuevo));
        }

        public List<JoinProductoSede> obtenerInventarioSedeCantidadesBajas(int idUsuario)
        {
            DAOSede fr = new DAOSede();
            return fr.obtenerInventarioSedeCantidadesBajas(idUsuario);
        }

        public EProveedor insertarProveedor(EProveedor provee, String mensajeProveedorRegistrado)
        {
            DAOSede d = new DAOSede();
            d.insertarProveedorEmpy(provee);
            provee.Nombre = "";
            provee.Correo = "";
            provee.Telefono = "";
            provee.Script = @"<script type='text/javascript'>alert('" + mensajeProveedorRegistrado + "');</script>";
            return provee;
        }

        public EProductoSede ObteneridProductosede(EProductoSede producto)
        {
            DAOSede datos = new DAOSede();

            EProductoSede solicion = new EProductoSede();
            solicion = datos.ObtenerIdProducto(producto);
            return solicion;
        }

        public EProductoSede ActualizarEstadoproducto(EProductoSede usuario, string mensajeBorradoCorrectamente)
        {
            DAOSede datos = new DAOSede();
            EProductoSede solicion = new EProductoSede();
            antiguo = datos.devolverProductoSede(usuario.Id);
            datos.ActualizarEstadosProducto(usuario);
            nuevo = datos.devolverProductoSede(usuario.Id);
            audi.AuditoriaModificar(auditoria.AuditoriaModificarProductosSede(antiguo, nuevo));
            usuario.Mensaje = @"<script type='text/javascript'>alert('" + mensajeBorradoCorrectamente + "');</script>";
            return usuario;
        }

        public List<EProductosDrop> ObtenerProductosDrop(int idUsuario)
        {
            DAOSede a = new DAOSede();
            return a.ObtenerProductosDrop(idUsuario);

        }
        public List<JoinDetalleDeVenta> ObtenerProductosPorsubsede(int id_subsede)
        {
            DAOSede a = new DAOSede();
            return a.ObtenerProductosPorSubsede(id_subsede);

        }
        public List<EProductosDrop> ObtenerSubsedees()
        {
            DAOSede a = new DAOSede();
            return a.ObtenerSubsedees();

        }
        public List<EVenta> ObtenerVentasPorSubsede(int id_subsede, string fecha)
        {
            DAOSede a = new DAOSede();
            return a.ObtenerVentaas(id_subsede, fecha);

        }
        public List<EVentasPasadas> ObtenerVentasPasadasPorSubsede(int id_subsede, DateTime fechaincio, DateTime fechafin)
        {
            DAOSede a = new DAOSede();
            return a.ObtenerVentaasPasadas(id_subsede, fechaincio, fechafin);

        }
        public List<JoinDetalleDeVenta> ObtenerDetalleVentasPorSubsede(int id_venta)
        {
            DAOSede a = new DAOSede();
            return a.ObtenerDetalleVentaas(id_venta);

        }


        public ESubsede insertarSubsede(ESubsede entrada, String mensajeAdminYCajero, String mensajeCorrecto, int idUsuario)
        {
            if (entrada.Ubicacion.Equals(""))
            {
                entrada.Ubicacion = "4.7064752877673435, -74.07232940081076";
            }

            if (entrada.IdCajero.ToString().Equals("0") | entrada.IdAdmin.ToString().Equals("0"))
            {

                entrada.Mensaje = @"<script type='text/javascript'>alert('" + mensajeAdminYCajero + "');</script>";

            }
            else
            {
                DAOSede a = new DAOSede();
                entrada.Last = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                a.insertarSede(entrada, idUsuario);

                entrada.Mensaje = @"<script type='text/javascript'>alert('" + mensajeCorrecto + "');</script>";
                entrada.Nombre = "";
                entrada.Ubicacion = "";

            }
            return entrada;
        }


        public void ModificarProductosProximosAterminarsubP(int CodigoRegistro, int CodigoProducto, String Producto, String Categoria, String subsede, int Cantidad, int CantidadMinima, int CantidadDisponible, int codigo)
        {
            DAOSede sede = new DAOSede();
            EProductoSubsede psub = new EProductoSubsede();
            EProductoSede pse = new EProductoSede();
            psub.Id = CodigoRegistro;
            psub.Cantidad = Cantidad;
            pse.Id_producto = CodigoProducto;
            pse.Cantidad = CantidadDisponible - Cantidad;

            if (Cantidad > CantidadDisponible)
            {

            }
            else
            {
                antiguo = sede.devolverProductoSede(sede.DevolverRegistroProducto(pse.Id_producto).Id);
                sede.ModificarCantidadesProductosBajosSede(pse);
                nuevo = sede.devolverProductoSede(antiguo.Id);
                audi.AuditoriaModificar(auditoria.AuditoriaModificarProductosSede(antiguo, nuevo));

                antiguoSub = sede.devolverProductoSubsede(psub.Id);
                sede.ModificarCantidadesProductosBajosSubsede(psub);
                nuevoSub = sede.devolverProductoSubsede(antiguoSub.Id);
                audi.AuditoriaModificar(auditoria.AuditoriaModificarProductoSubsede(antiguoSub, nuevoSub));
            }
        }


        public int ObtenerTotalVendidoHoy(int idSubsede, String fechaHoy)
        {
            int venta = 0;
            if (idSubsede == 0)
            {

            }
            else
            {
                DAOSede sede = new DAOSede();
                venta = sede.ObtenerTotalVendidoHoy(idSubsede, fechaHoy);
            }
            return venta;
        }
        public void ObtenerUsuarioParaSessionesMax(int rol, int numeroSessiones)
        {
            DAOSede datos = new DAOSede();
            DAOSede datos2 = new DAOSede();
            List<JoinModificaSessiones> lista = new List<JoinModificaSessiones>();
            lista = datos.ObtenerUsuariosModificarSessiones(rol);

            foreach (JoinModificaSessiones prime in lista)
            {

                PUsuario a = new PUsuario();
                a.Id = prime.Id;
                a = datos2.obtenerUsuarioSessionesMaximas(a);
                a.SesionesMaximas = numeroSessiones;
                datos2.ActualizarSessionesMaximas(a);

            }
        }
        public DataTable ObtenerVentasPasadasSuperAdminSql(int idSubsede, string fecha_inicio, string fecha_fin)
        {
            DAOSede datos = new DAOSede();
            DataTable a = new DataTable();
            a = datos.ObtenerVentaasPasadasSql(idSubsede, fecha_inicio, fecha_fin);

            return a;


        }
        public List<JoinProductosSubsede> obtenerProductosService(int id_categoria)
        {
            DAOSede a = new DAOSede();
            return a.obtenerproductosService(id_categoria);

        }
        public int obtenerIdSubsede(int idUsuario)
        {
            ESubsede b = new ESubsede();
            DAOSubsede a = new DAOSubsede();
            b = a.obtenerIdSubsede(idUsuario);
            int iid = b.Id;
            return iid;

        }
        public int ObtenerTotalVentasPasadasSuperAdminSql(int idSubsede, string fecha_inicio, string fecha_fin)
        {
            DAOSede datos = new DAOSede();
            DataTable a = new DataTable();
            a = datos.ObtenerVentaasPasadasSql(idSubsede, fecha_inicio, fecha_fin);
            int sum = 0;
            foreach (DataRow dr in a.Rows)
            {
                sum += Convert.ToInt32(dr["valor_total"].ToString());
            }
            int nuevo = sum;
            return sum;


        }
        public void FuncionMultiidoma(string control, string terminacion, int id_formulario, string texto, String session)
        {
            int id_idioma;
            int id_control;
            int validarcontrol;
            DAOSede O = new DAOSede();
            DAOSede w = new DAOSede();
            DAOSede a = new DAOSede();
            EIdioma I = new EIdioma();
            EControles c = new EControles();
            I.Terminacion = terminacion;
            I = O.ObtenerIdidioma(I);
            id_idioma = I.Id;
            c.IdFormulario = id_formulario;
            c.Control = control;
            c.IdIdioma = id_idioma;
            c = w.ObtenerResultadoIdioma(c);
            I.Terminacion = terminacion;
            I = O.ObtenerIdidioma(I);
            id_idioma = I.Id;
            if (c != null)
            {
                id_control = c.Id;

                List<JoinProductosSubsede> join = new List<JoinProductosSubsede>();
                join = a.ObtenerControlParaContar(id_control);
                var count = join.Count();
                validarcontrol = count;
                EControles con = new EControles();
                con.Id = id_control;
                con.Texto = texto;
                con.Session = session;
                if (validarcontrol == 1)
                {
                    DAOAuditoria audi = new DAOAuditoria();
                    DAOSede p = new DAOSede();
                    EControles antiguo = p.devolverControl(con.Id);
                    p.ModificarIdioma(con);
                    EControles nuevo = p.devolverControl(antiguo.Id);
                    LAuditoria auditoria = new LAuditoria();
                    audi.AuditoriaModificar(auditoria.AuditoriaModificarControl(antiguo, nuevo));

                }
            }
            else
            {

                DAOSede p = new DAOSede();
                EControles controlnew = new EControles();
                controlnew.Control = control;
                controlnew.Texto = texto;
                controlnew.IdIdioma = id_idioma;
                controlnew.IdFormulario = id_formulario;
                controlnew.Session = session;
                p.registrarcontrol(controlnew);

            }






        }


        public void registrarprueba(Epruebiña prueba)
        {
            DAOSede a = new DAOSede();
            a.insertarPrueba(prueba);
        }
    }
}
