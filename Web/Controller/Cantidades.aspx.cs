using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using Utilitarios;

public partial class View_Cantidades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        LSede inicio = new LSede();

        try
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()), false);
            EProducto producto = new EProducto();
            producto.IdProducto = int.Parse(Session["idProducto"].ToString());
            EProducto resultado = new EProducto();
            resultado.IdProducto = int.Parse(Session["idProducto"].ToString());

            resultado = inicio.DevolverInformacionDeProducto(resultado, int.Parse(Session["user_id"].ToString()));

            Lb_codigo.Text = String.Concat(resultado.IdProducto);

            LbCantidadInventario.Text = resultado.Cantidad.ToString();

            Lb_producto.Text = resultado.Descripcion.ToString();

        }
        catch (Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");

        }
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("Cantidades.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBCodigo.Text = hashMap["LBCodigo"];
            LBProducto.Text = hashMap["LBProducto"];
            LBCantidadinve.Text = hashMap["LBCantidadinve"];
            LBCantidadmin.Text = hashMap["LBCantidadmin"];
            LBCantidad.Text = hashMap["LBCantidad"];
            BTAceptar.Text = hashMap["BTAceptar"];
            BTCancelar.Text = hashMap["BTCancelar"];

        }
        catch (Exception)
        {

        }
        

    }

    protected void Bt_aceptar_Click(object sender, EventArgs e)
    {
        String mensajeCantidadNoNegativa = "", mensajeCantidadExcedida = "",mensajeProductoYaAsignado="",mensajeProductoAsignado="",mensajeCantidadMinima="";
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            mensajeCantidadNoNegativa = hashMap["mensajeCantidadNoNegativa"];
            mensajeCantidadExcedida = hashMap["mensajeCantidadExcedida"];
            mensajeProductoYaAsignado = hashMap["mensajeProductoYaAsignado"];
            mensajeProductoAsignado = hashMap["mensajeProductoAsignado"];
            mensajeCantidadMinima = hashMap["mensajeCantidadMinima"];
        }
        catch (Exception)
        {

        }
        LSubsede registrar = new LSubsede();
        EProductoSede resultado = new EProductoSede();
        int  cantidad = int.Parse(TbCantidad.Text);
        int cantidadminima= int.Parse(TbCantidadMinima.Text);
        int id_subsede = int.Parse(Session["subsede"].ToString());

        resultado.Cantidad = int.Parse(TbCantidad.Text);
        resultado.CantidadMinima = int.Parse(TbCantidadMinima.Text);
        resultado.Id_producto = int.Parse(Session["idProducto"].ToString());
        resultado.IdSede = int.Parse(Session["subsede"].ToString());
        resultado.Session = Session.SessionID;
        resultado.MensajeCantidadNegativa = mensajeCantidadNoNegativa;
        resultado.MensajeCantidadInsuficiente = mensajeCantidadExcedida;
        resultado.MensajeProductoYaAsignado = mensajeProductoYaAsignado;
        resultado.MensajeAsignadoCorrectamente = mensajeProductoAsignado;
        resultado.MensajeCantidadMinimaMenorACantidadMaxima = mensajeCantidadMinima;
        resultado.Session = Session.SessionID;
        resultado=registrar.insertarproductosSubsede(resultado, id_subsede,cantidad,cantidadminima);

        TbCantidad.Text = resultado.Cantidad.ToString();
        TbCantidadMinima.Text = resultado.CantidadMinima.ToString();

        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", resultado.Mensaje, false);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", resultado.Mensaje);

    }


    protected void BtCancelar_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", @"<script type='text/javascript'>window.close();</script>", false);
        String ejecutar = @"<script type='text/javascript'>window.close();</script>";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", ejecutar);
    }
}