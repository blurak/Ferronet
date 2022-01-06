using Datos.Persistencia;
using Logica;
using Newtonsoft.Json;
using System;
using System.Web.Services;
using Utilitarios.Tablas;
/// <summary>
/// Descripción breve de Servicios
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class Servicios : System.Web.Services.WebService
{
    public Logica.SeguridadToken SoapHeader;
    LServicio logica = new LServicio();
    public Servicios()
    {
        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string autenticacionUsuario()
    {
        try
        {
            return logica.LogicaAutenticacion(SoapHeader);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public String ConsultaDeProductos(String criterio)
    {
        try
        {
            return logica.LogicaConsultaBusquedaDeProductos(SoapHeader, criterio);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public String ConsultaDeUbicaciones()
    {
        try
        {
            return logica.LogicaConsultaDeUbicaciones(SoapHeader);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public String ConsultaDeProveedores(int idCategoria)
    {
        try
        {
            return logica.LogicaConsultaDeProveedores(SoapHeader,idCategoria);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public String ConsultaDeUsuarios()
    {
        try
        {
            return logica.LogicaConsultaDeUsuarios(SoapHeader);

        }
        catch (Exception ex)
        {
            throw;
        }

    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public String ConsultaTopSubsedes()
    {
        try
        {
            return logica.LogicaConsultaTop3Subsedes(SoapHeader);

        }
        catch (Exception ex)
        {
            throw;
        }

    }

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public String ConsultaTopProductos()
    {
        try
        {
            return logica.LogicaConsultaTop3Productos(SoapHeader);

        }
        catch (Exception ex)
        {
            throw;
        }

    }
}
