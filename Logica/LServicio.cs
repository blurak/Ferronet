using Datos.Persistencia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Utilitarios.Tablas;
using Utilitarios.Servicios;
using System.Data;
using Utilitarios.Join;
using Datos;

namespace Logica
{
    public class LServicio
    {
        public DAOServicio serviciodatos = new DAOServicio();
        public EServicio servicio = new EServicio();
        
        
        

        public String LogicaAutenticacion(SeguridadToken SoapHeader)
        {
            try
            {
                if (SoapHeader == null) return "-1"; //que esta vacio
                 
                servicio = serviciodatos.devolverToken(SoapHeader.username, SoapHeader.contrasena);

                if (servicio == null)
                {
                    return "-1";
                }
                else
                {
                    List<JoinUsuario> t = serviciodatos.ValidarToken(servicio);

                    if (serviciodatos.ValidarToken(servicio).Count > 0) {
                        servicio.Token = Guid.NewGuid().ToString();
                        serviciodatos.modificarToken(servicio);
                    }

                    if (servicio.Validez == null | servicio.Token == null)
                    {
                        servicio.Token = Guid.NewGuid().ToString();
                        serviciodatos.modificarToken(servicio);
                    }
                }

                return servicio.Token;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String LogicaConsultaBusquedaDeProductos(SeguridadToken SoapHeader, String criterio)
        {
            try
            {
                if (SoapHeader == null)
                {
                    throw new Exception("Requiere validacion");
                }

                if (!SoapHeader.blCredencialesValides(SoapHeader))
                {
                    throw new Exception("Requiere credenciales");
                }

                String algo = JsonConvert.SerializeObject(serviciodatos.obtenerProductosVisitante(criterio));
                return algo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String LogicaConsultaDeProveedores(SeguridadToken SoapHeader,int categoria)
        {
            try
            {
                if (SoapHeader == null)
                {
                    throw new Exception("Requiere validacion");
                }

                if (!SoapHeader.blCredencialesValides(SoapHeader))
                {
                    throw new Exception("Requiere credenciales");
                }
                String algo = JsonConvert.SerializeObject(serviciodatos.obtenerProveedores(categoria));
                return algo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String LogicaConsultaDeUbicaciones(SeguridadToken SoapHeader)
        {
            try
            {
                if (SoapHeader == null)
                {
                    throw new Exception("Requiere validacion");
                }

                if (!SoapHeader.blCredencialesValides(SoapHeader))
                {
                    throw new Exception("Requiere credenciales");
                }
                List<JoinProveedoresCategoria> lista=serviciodatos.ObtenerUbicacionesDeSubsede();
                List<Ubicaciones> ubicaciones = new List<Ubicaciones>();
                foreach (JoinProveedoresCategoria p in lista)
                {
                    Ubicaciones ubicacion = new Ubicaciones();
                    string[] separadas = p.Nombre.Split(',');
                    ubicacion.Latitud = separadas[0];
                    ubicacion.Longitud = separadas[1];
                    ubicaciones.Add(ubicacion);
                    ubicacion = null;
                }
                String algo = JsonConvert.SerializeObject(ubicaciones);
                return algo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String LogicaConsultaDeUsuarios(SeguridadToken SoapHeader)
        {
            try
            {
                if (SoapHeader == null)
                {
                    throw new Exception("Requiere validacion");
                }

                if (!SoapHeader.blCredencialesValides(SoapHeader))
                {
                    throw new Exception("Requiere credenciales");
                }

                String algo = JsonConvert.SerializeObject(serviciodatos.ObtenerUsuarios());
                return algo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String LogicaConsultaTop3Subsedes(SeguridadToken SoapHeader)
        {
            DAOServicio datos = new DAOServicio();
            DAOServicio datos2 = new DAOServicio();

            int[,] valores;
            int[] ids;
            int numeroregistros1 = 0;
            int numeroregistros2 = 0;
            int numeroregistros3 = 0;
            int id1 = 0;
            int id2 = 0;
            int id3 = 0;

            List<JoinModificaSessiones> lista = new List<JoinModificaSessiones>();
            lista = datos.ObteneridsSubsedes();
            var count1 = lista.Count();
            int numerodecount = count1;
            valores = new int[count1, 2];
            ids = new int[count1];
            int suma = 0;
            foreach (JoinModificaSessiones prime in lista)
            {

                ESubsede a = new ESubsede();
                int id_subsede = prime.Id;
                List<JoinModificaSessiones> lista2 = new List<JoinModificaSessiones>();
                lista2 = datos2.ObtenerventasPorSubsede(id_subsede);
                var count = lista2.Count();
                int numerofila = count;
                valores[suma, 0] = numerofila;
                valores[suma, 1] = id_subsede;
                suma = suma + 1;
            }

            for (int i = 0; i < count1; i++)
            {
                if (valores[i, 0] > numeroregistros1)
                {
                    id1 = valores[i, 1];
                    numeroregistros1 = valores[i, 0];
                }

            }
            for (int i = 0; i < count1; i++)
            {
                if (valores[i, 0] > numeroregistros2)
                {
                    if (valores[i, 0] < numeroregistros1)
                    {
                        id2 = valores[i, 1];
                        numeroregistros2 = valores[i, 0];
                    }
                }

            }
            for (int i = 0; i < count1; i++)
            {
                if (valores[i, 0] > numeroregistros3)
                {
                    if (valores[i, 0] < numeroregistros2)
                    {
                        id3 = valores[i, 1];
                        numeroregistros3 = valores[i, 0];
                    }
                }

            }
            DAOServicio w = new DAOServicio();
            String algo = JsonConvert.SerializeObject(w.obtenerSubsedesevice(id1, id2, id3));
            return algo;
        }

        public String LogicaConsultaTop3Productos(SeguridadToken SoapHeader)
        {
            int[] ids;
            int[] idsproductos;
            DateTime r = new DateTime();
            r = DateTime.Now;
            string mes = Convert.ToString(r.Month);

            DataTable aa = new DataTable();
            DAOServicio q = new DAOServicio();
            aa = q.ObteneridsVentasdelmes(mes);
            var count1 = aa.Rows.Count;
            int suma = 0;
            ids = new int[count1];
            idsproductos = new int[count1 * 3];
            int contador = 0;
            foreach (DataRow row in aa.Rows)
            {
                ids[suma] = Int32.Parse(row["id"].ToString());
                suma = suma + 1;
            }
            int contador2 = 0;
            int contador3 = 0;

            for (int i = 0; i < count1; i++)
            {
                DAOServicio w = new DAOServicio();
                List<JoinModificaSessiones> o = new List<JoinModificaSessiones>();
                int idventa = ids[contador2];
                contador2 = contador2 + 1;
                o = w.obtenerdetalleventaservice(idventa);
                foreach (JoinModificaSessiones prime in o)
                {

                    idsproductos[contador3] = prime.Id;
                    contador3 = contador3 + 1;

                }

            }
            List<JoinPedidoCliente> nuevo = new List<JoinPedidoCliente>();
            int[] filtro = idsproductos.Distinct().ToArray();

            int cantidad1 = 0;
            int cantidad2 = 0;
            int cantidad3 = 0;
            int id1 = 0;
            int id2 = 0;
            int id3 = 0;
            int[,] valores;
            var count123 = filtro.Count();
            valores = new int[count123, 2];
            for (int i = 0; i < count123; i++)
            {
                List<JoinModificaSessiones> p = new List<JoinModificaSessiones>();
                DAOServicio l = new DAOServicio();
                p = l.obtenerdetalleventaservicenumero(filtro[i]);
                var count1234 = p.Count();
                valores[i, 0] = count1234;
                valores[i, 1] = filtro[i];
            }


            for (int i = 0; i < count123; i++)
            {
                if (valores[i, 0] > cantidad1)
                {
                    id1 = valores[i, 1];
                    cantidad1 = valores[i, 0];
                }

            }
            for (int i = 0; i < count123; i++)
            {
                if (valores[i, 0] > cantidad2)
                {
                    if (valores[i, 0] < cantidad1)
                    {
                        id2 = valores[i, 1];
                        cantidad2 = valores[i, 0];
                    }
                }

            }
            for (int i = 0; i < count123; i++)
            {
                if (valores[i, 0] > cantidad3)
                {
                    if (valores[i, 0] < cantidad2)
                    {
                        id3 = valores[i, 1];
                        cantidad3 = valores[i, 0];
                    }
                }

            }

            List<JoinModificaSessiones> nuevo2 = new List<JoinModificaSessiones>();
            List<JoinProductoSubsede> productos = new List<JoinProductoSubsede>();

            DAOServicio servi = new DAOServicio();
            String algo = JsonConvert.SerializeObject(servi.obtenerProductosSubsede(id1, id2, id3));
            return algo;
        }
    }
}
