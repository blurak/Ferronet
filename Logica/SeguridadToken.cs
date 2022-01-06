using Datos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Logica
{
   public class SeguridadToken : System.Web.Services.Protocols.SoapHeader
    {
        public String stToken { get; set; }
        public String AutenticacionToken { get; set; }
        public String username { get; set; }
        public String contrasena { get; set; }

        public bool blCredencialesValides(String stToken)
        {
            try
            {
                if (stToken == DateTime.Now.ToString("yyyyMMdd"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool blCredencialesValides(SeguridadToken SoapHeader)
        {

            DAOServicio datos = new DAOServicio();

            try
            {
                if (SoapHeader == null) return false;

                if (!string.IsNullOrEmpty(SoapHeader.AutenticacionToken))
                    if (datos.devolverToken(SoapHeader.AutenticacionToken) == null)
                        return false;

                return true;
            }
            catch (Exception EX)
            {
                throw EX;
            }

        }
    }
}
