using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Datos;
using Utilitarios;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Net.Mail;
using Datos.Persistencia;
using Utilitarios.Join;
using Utilitarios.Tablas;

namespace Logica
{
    public class LUsuario
    {
        private DAOAuditoria audi = new DAOAuditoria();
        private PUsuario antiguo = new PUsuario();
        private PUsuario nuevo = new PUsuario();
        private EAutenticacion antiguoA = new EAutenticacion();
        private EAutenticacion nuevoA = new EAutenticacion();
        private LAuditoria auditoria = new LAuditoria();
        private DAOUsuario datosUsuario = new DAOUsuario();
        public void restarsessiones(int id)
        {
            
            DAOUsuario datos = new DAOUsuario();
            antiguo = datos.devolverUsuario(id);
            datos.restarSesiones(id);
            nuevo = datos.devolverUsuario(antiguo.Id);
            audi.AuditoriaModificar(auditoria.AuditoriaModificarUsuario(antiguo, nuevo));
            //DUsuario datos = new DUsuario();
            //datos.restarSessiones(id);
        }

        public void modificarSesionesMaximas(int idRol, int SesionesModifica)
        {
            DUsuario datos = new DUsuario();
            datos.modificarSesionesMaximas(idRol, SesionesModifica);
        }
        public DataTable pintarProductos(String criterio)
        {
            DataTable y = new DataTable();
            DUsuario datos = new DUsuario();
            y=datos.obtenerUsuarios(criterio);
            return y;
        }

        public void CerrarSesion(EUsuario entrada)
        {
            
            DAOUsuario usu = new DAOUsuario();
            antiguoA = usu.devolverAutenticacion(entrada.Session);
            usu.cerrarSesion(entrada.Session);
            nuevoA = usu.devolverAutenticacion(antiguoA.Id);
            audi.AuditoriaModificar(auditoria.AuditoriaModificarAutenticacion(antiguoA, nuevoA));
            //DUsuario data = new DUsuario();
            //data.cerrarSession(entrada);
        }

        public PUsuario logear(PUsuario entrada)
        {
            PUsuario salida = new PUsuario();
            
            DAOSubsede datosSubsede = new DAOSubsede();
            ESubsede subsede = new ESubsede();
            EAutenticacion autentica = new EAutenticacion();
            LMAC datosConexion = new LMAC();
            String Session = entrada.Session;
            String MensajeUsuarioInexistente = entrada.MensajeUsuarioInexistente;
            String MensajeBaneado = entrada.MensajeBaneado;
            String MensajeSesionesMaximas = entrada.MensajeSesionesMaximas;
            String MensajeSinSubsedeAsignada = entrada.MensajeSinSubsedeAsignada;
            String MensajeContrasenaIncorrecta = entrada.MensajeContrasenaIncorrecta;
            String clave = entrada.Clave;
            String userName = entrada.Usuario;

            entrada=datosUsuario.Loggin(entrada);

            if (entrada==null)
            {
                salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeUsuarioInexistente + "');</script>";
            }else  
            {
                if (entrada.Clave.Equals(clave) && entrada.Usuario.Equals(userName))
                {
                    if (entrada.Baneado == true)
                    {
                        salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeBaneado + "');</script>";
                    }
                    else
                    {
                        if (entrada.SesionesMaximas.Equals(entrada.SesionesActivas))
                        {
                            salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeSesionesMaximas + "');</script>";
                        }
                        else
                        {
                           
                            if (entrada.IntentosIncorrectos != 0)
                            {
                                entrada.IntentosIncorrectos = 0;
                                antiguo = datosUsuario.devolverUsuario(entrada.Id);
                                datosUsuario.actualizarIntentosErroneosACero(entrada);
                                nuevo = datosUsuario.devolverUsuario(antiguo.Id);
                                audi.AuditoriaModificar(auditoria.AuditoriaModificarUsuario(antiguo, nuevo));
                            }
                            

                            
                          entrada.SesionesActivas = 1;
                          antiguo = datosUsuario.devolverUsuario(entrada.Id);
                          datosUsuario.SumarSesiones(entrada);
                          nuevo = datosUsuario.devolverUsuario(antiguo.Id);
                          audi.AuditoriaModificar(auditoria.AuditoriaModificarUsuario(antiguo, nuevo));
                            
                            
                            autentica.IdUsuario = entrada.Id;
                            salida.Id = entrada.Id;
                            autentica.Ip = datosConexion.ip();
                            autentica.Mac = datosConexion.mac();
                            autentica.FechaInicio = DateTime.Now;
                            autentica.Session = Session;

                            datosUsuario.guardarSesion(autentica);

                            switch (entrada.IdRol)
                            {
                                case 1:
                                    //cliente
                                    salida.IdRol = 1;
                                    salida.Mensaje = @"<script type='text/javascript'>window.location.href = 'HacerPedidoCliente.aspx';</script>";
                                    break;
                                case 2:
                                    //super
                                    salida.IdRol = 2;
                                    salida.Mensaje = @"<script type='text/javascript'>window.location.href = 'AdministracionDeSubsedes.aspx';</script>";
                                    break;
                                case 3:
                                    //administrador
                                    salida.IdRol = 3;
                                    subsede = datosSubsede.verificarSiTieneSubsede(entrada.Id);
                                    if (subsede == null)
                                    {
                                        salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeSinSubsedeAsignada + "');window.location.href='IniciarSesion.aspx';</script>";
                                    }
                                    else
                                    {
                                        salida.Mensaje = @"<script type='text/javascript'> window.location.href = 'InventarioActualSubsede.aspx';</script>";
                                    }
                                    break;
                                case 4:
                                    //cajero
                                    salida.IdRol = 4;

                                    subsede = datosSubsede.verificarSiTieneSubsede(entrada.Id);
                                    if (subsede == null)
                                    {
                                        salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeSinSubsedeAsignada + "');window.location.href='IniciarSesion.aspx';</script>";
                                    }
                                    else
                                    {
                                        salida.Mensaje = @"<script type='text/javascript'> window.location.href ='RegistrarVentaConGridview.aspx';</script>";
                                    }
                                    
                                    break;
                            }
                        }
                    }
                }
                else if (entrada.Usuario.Equals(userName) && entrada.Clave != clave)
                {
                    if (entrada.Baneado == true)
                    {
                        salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeBaneado + "');</script>";
                    }
                    else
                    {
                        salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeContrasenaIncorrecta + "');</script>";
                    }
                    
                    if (entrada.IntentosIncorrectos == 2)
                    {
                        entrada.Baneado = true;
                        DateTime fecha = DateTime.Now;
                        entrada.Baneo = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm")).AddMinutes(30);
                        entrada.IntentosIncorrectos = 1;
                        antiguo = datosUsuario.devolverUsuario(entrada.Id);
                        datosUsuario.actualizarIntentosErroneos(entrada);
                        nuevo = datosUsuario.devolverUsuario(entrada.Id);
                        audi.AuditoriaModificar(auditoria.AuditoriaModificarUsuario(antiguo, nuevo));

                        antiguo = datosUsuario.devolverUsuario(entrada.Id);
                        datosUsuario.ColocarBaneos(entrada);
                        nuevo = datosUsuario.devolverUsuario(entrada.Id);
                        audi.AuditoriaModificar(auditoria.AuditoriaModificarUsuario(antiguo, nuevo));
                        salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeContrasenaIncorrecta + "');</script>";
                    }
                    else if (entrada.IntentosIncorrectos != 3)
                    {
                        entrada.IntentosIncorrectos = 1;
                        antiguo = datosUsuario.devolverUsuario(entrada.Id);
                        datosUsuario.actualizarIntentosErroneos(entrada);
                        nuevo = datosUsuario.devolverUsuario(entrada.Id);
                        audi.AuditoriaModificar(auditoria.AuditoriaModificarUsuario(antiguo, nuevo));
                        salida.Mensaje = @"<script type='text/javascript'>alert('" + MensajeContrasenaIncorrecta + "');</script>";
                    }
                   
                }

            }
          
            return salida;
        }

 
        public String recuperarContrasena(String userName,String lenguaje,String mensajeEnviado,String mensajeTokenExistente,String mensajeUsuarioInexistente,String mensajeCorreo)
        {
            PUsuario user = new PUsuario();
            List<JoinUsuario> listaToken = new List<JoinUsuario>();
            String mensaje="";
            DAOUsuario datoos = new DAOUsuario();
            user= datoos.generarToken(userName);

            if (user != null)
            {
                listaToken = datoos.ValidarToken(userName);
                if (listaToken.Count > 0)
                {
                    mensaje = mensajeTokenExistente;
                }
                else
                {
                    
                    EtokenRecuperacionUsuario token = new EtokenRecuperacionUsuario();
                    listaToken=datoos.DevolverUsuario(userName);
                    foreach (JoinUsuario usuarioToken in listaToken)
                    {
                        token.UserId = usuarioToken.Id;
                        token.Nombre = usuarioToken.Nombre;
                        token.User_name = usuarioToken.Usuario;
                        token.Estado = usuarioToken.Estado;
                        token.Correo = usuarioToken.Correo;
                        token.Fecha = DateTime.Now.ToFileTimeUtc();
                    }

                    token.Token = encriptar(JsonConvert.SerializeObject(token));

                    datoos.almacenarToken(token);

                    Correo correo = new Correo();
                    mensaje = mensajeEnviado;
                    mensajeCorreo = mensajeCorreo + "http://ferronet.hopto.org/View/RecuperarContrasena.aspx?" + token.Token;
                    correo.enviarCorreo(token.Correo,token.Token, mensajeCorreo);
                }
            }
            else
            {
                mensaje = mensajeUsuarioInexistente;
            }
            return mensaje;
        }

      

        private string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public String verificarToken(int query,String token,String lenguaje)
        {
            String script="";
            DAOUsuario datos = new DAOUsuario();
            List<JoinUsuario> listaResultado = new List<JoinUsuario>();
            listaResultado = datos.verificarTokenSiEsValido(token);
            
            DUsuario bd = new DUsuario();

            //DataTable informacion = new DataTable();

            //informacion=bd.obtenerUsuarioToken(token);

            if (query > 0)
            {

                if (listaResultado.Count > 0)
                {
                    listaResultado = datos.verificarTokenSiEstaVencido(token);
                    if (listaResultado.Count > 0)
                    {
                        foreach (JoinUsuario user in listaResultado)
                        {
                            script = user.Id.ToString();
                        }
                    }
                    else
                    {
                        datos.borrarTokenVencido(token);
                        if (lenguaje.Equals("es-CO"))
                        {
                            script = @"<script type='text/javascript'>TokenVencido();</script>";
                        }
                        if (lenguaje.Equals("en-US"))
                        {

                            script = @"<script type='text/javascript'> alert('The token is expired, generate a new one'); window.location.href = 'GenerarToken.aspx';</script>";
                        }
                    }
                }
                else
                {

                    if (lenguaje.Equals("es-CO"))
                    {
                        script = @"<script type='text/javascript'>TokenInvalido();</script>";
                    }
                    if (lenguaje.Equals("en-US"))
                    {

                        script = @"<script type='text/javascript'> alert('The token is invalid, please verify and try again'); window.location.href = 'IniciarSesion.aspx';</script>";
                    }
                }


            }
            else
                script = @"<script type='text/javascript'>RedireccionarIniciarSesion();</script>";

            return script;
        }

        public String cambioContrasena(String contrasena, String verificarContrasena,String idUsuario,String MensajeContrasenasNoIguales,String MensajeContrasenaCambiada)
        {
            DAOUsuario datosUsuario = new DAOUsuario();

            //DUsuario bd = new DUsuario();
            String salida="";
            if (contrasena.Equals(verificarContrasena))
            {
                PUsuario user = new PUsuario();
                user.Id = int.Parse(idUsuario);
                user.Clave = contrasena;
                datosUsuario.actualizarContrasena(user);
                //EUsuario user = new EUsuario();
                //user.UserId = int.Parse(idUsuario);
                //user.Clave = contrasena;
                //bd.actualizarContrasena(user);
                salida = @"<script type='text/javascript'>alert('"+MensajeContrasenaCambiada+"'); window.location.href = 'IniciarSesion.aspx';</script>";
                
              
            }
            else
            {
                salida = @"<script type='text/javascript'>alert('"+MensajeContrasenasNoIguales+"');</script>";
               
            }

            return salida;

        }

        public EUsuario insertarUsuario(EUsuario usuario)
        {
            PUsuario f = new  PUsuario();
            DAOUsuario dao = new DAOUsuario();
            PUsuario tabla = new PUsuario();
            tabla.Usuario = usuario.UserName;
            tabla.Correo = usuario.Correo;
            tabla.Clave = usuario.Clave;
            tabla.Nombre = usuario.Nombre;
            tabla.IdRol = 1;
            tabla.Session = usuario.Session;
            tabla.Estado = 1;
            tabla.SesionesActivas = 0;
            foreach(JoinProductoSubsede d in dao.obtenerSesionesMaximas(tabla.IdRol))
            {
                tabla.SesionesMaximas = d.Codigo_producto1;
            }
            tabla.IntentosIncorrectos = 0;
            //tabla.Baneo = null;
            tabla.Baneado = false;
            tabla.Last=Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            f =dao.verificarExistenciaDelUsuario(tabla.Usuario);
            if (f!=null)
            {
                usuario.Correo = usuario.Correo;
                usuario.Nombre = usuario.Nombre;
                usuario.UserName = String.Empty;
                usuario.Clave = usuario.Clave;

                usuario.Mensaje = @"<script type='text/javascript'>alert('" + usuario.MensajeUsernameNoDisponible + "');</script>";

            }
            else if (f==null)
            {

                dao.registrarUsuario(tabla);

                usuario.UserName = String.Empty;
                usuario.Correo = String.Empty;
                usuario.Clave = String.Empty;
                usuario.Nombre = String.Empty;

                usuario.Mensaje = @"<script type='text/javascript'>alert('" + usuario.Mensaje + "');</script>";
            }
            return usuario;
        }

        public EUsuario registrarUsuario(EUsuario usuario)
        {
            EUsuario resultado = new EUsuario();

            DUsuario verificar = new DUsuario();
            

            DataTable usu = verificar.verificarExistenciaDelUsuario(usuario.UserName);

            if (usu.Rows[0]["verificar_username"].ToString().Equals("true"))
            {
                resultado.Correo = usuario.Correo;
                resultado.Nombre = usuario.Nombre;
                resultado.UserName = String.Empty;
                resultado.Clave = usuario.Clave;
               
                resultado.Mensaje = @"<script type='text/javascript'>alert('"+usuario.MensajeUsuarioInexistente+"');</script>";
               
            }
            else
            {
                verificar.registrarUsuario(usuario);

                resultado.UserName = String.Empty;
                resultado.Correo = String.Empty;
                resultado.Clave = String.Empty;
                resultado.Nombre = String.Empty;

                resultado.Mensaje = @"<script type='text/javascript'>alert('"+ usuario.Mensaje + "');</script>";
            }
                return resultado;
        }

        public EEmail enviarCorreoContactenos(EEmail entrada,String lenguaje)
        {
            EEmail resultado = new EEmail();
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("jeisongaona@hotmail.com", entrada.Nombre);

                //Aquí ponemos el asunto del correo
                mail.Subject = entrada.Asunto;
                //Aquí ponemos el mensaje que incluirá el correo
                mail.Body = "mi correo electronico es " + entrada.Email + "   adjunto mi mensaje :" + entrada.Mensaje;
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add("ferronet67@gmail.com");
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));
                mail.IsBodyHtml = true;

                mail.Priority = MailPriority.Normal;
                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                                       //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("ferronet67@gmail.com", "ingenieria");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                resultado.Nombre = String.Empty;
                resultado.Email = String.Empty;
                resultado.Asunto = String.Empty;
                resultado.Mensaje = String.Empty;
                resultado.Script = @"<script type='text/javascript'>alert('"+entrada.MensajeCorreoEnviado+"');</script>";
            }
            catch (Exception ex)
            {
                
                resultado.Nombre = entrada.Nombre;
                resultado.Email = entrada.Email;
                resultado.Asunto =entrada.Asunto;
                resultado.Mensaje =entrada.Mensaje;

                resultado.Script = @"<script type='text/javascript'>alert('"+entrada.MensajeCorreoNoEnviado+"');</script>";
                ex.Message.ToString();
            }

            return resultado;
        }

        public List<JoinProductoSubsede> obtenerProductosVisitante(String criterio)
        {
            DAOUsuario usuario = new DAOUsuario();
            return usuario.obtenerProductosSubsede(criterio);
        }



        //public void CerrarSesion(EUsuario datos)
        //{
        //    DUsuario u = new DUsuario();
        //    u.cerrarSession(datos);
        //}

    }
}
