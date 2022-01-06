using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ConsultarVentasdelDia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        LSubsede inicio = new LSubsede();
        try
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()));
        }
        catch (Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");
        }

        Response.Cache.SetNoStore();

        try
        {
            DateTime fecha;
            string fecha1;
            fecha = DateTime.Today;
            
            string formato = "MM dd yyyy";
            fecha1 = fecha.ToString(formato);
            Session["Fechahoy"] = fecha1;

            Session["idSub"] = inicio.DevolverIdSubsedeAdministrador(Session["user_id"].ToString());
        }
        catch (Exception we)
        {
            String script = @"<script type='text/javascript'>SesionNula();</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
        }

        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("ConsultarVentasdelDia.aspx", selectedLanguaje);

            LDetalleVenta.Text = hashMap["LDetalleVenta"];
            LInstruccionUno.Text = hashMap["LInstruccionUno"];

            GVVenta.Columns[1].HeaderText = hashMap["GVVentaColumna1"];
            GVVenta.Columns[2].HeaderText = hashMap["GVVentaColumna2"];
            GVVenta.Columns[3].HeaderText = hashMap["GVVentaColumna3"];
            GVVenta.Columns[4].HeaderText = hashMap["GVVentaColumna4"];
            GVVenta.EmptyDataText = hashMap["EmptyGVVenta"];

            GVDetalleVenta.Columns[0].HeaderText = hashMap["GVDetalleVentaColumna0"];
            GVDetalleVenta.Columns[1].HeaderText = hashMap["GVDetalleVentaColumna1"];
            GVDetalleVenta.Columns[2].HeaderText = hashMap["GVDetalleVentaColumna2"];
            GVDetalleVenta.Columns[3].HeaderText = hashMap["GVDetalleVentaColumna3"];
            GVDetalleVenta.EmptyDataText = hashMap["EmptyGVDetalleVenta"];

            GVTotalVendido.Columns[0].HeaderText = hashMap["GVTotalVendidoColumna0"];
            GVTotalVendido.EmptyDataText = hashMap["EmptyGVTotalVendido"];

            IBSalir.ImageUrl = hashMap["IBSalir"];
        }
        catch (Exception)
        {

        }


    }
}