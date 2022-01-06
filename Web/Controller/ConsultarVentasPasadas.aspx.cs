using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ConsultarVentasPasadas : System.Web.UI.Page
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
        LSede a = new LSede();
        int id_subsede= a.obtenerIdSubsede(int.Parse(Session["user_id"].ToString()));
        Session["id_subsede"] = id_subsede;
        DateTime fecha;
        string fecha1;
        string fecha2;
        string formato = "yyy-MM-dd";
        string formato2 = "yyy-MM-dd";
        LSubsede resultado = new LSubsede();

        fecha = DateTime.Today;
        fecha1 = fecha.ToString(formato);
        Session["fechapasada"] = fecha1;


        fecha = DateTime.Today;
        fecha2 = fecha.ToString(formato2);
        Session["fechadespues"] = fecha2;

        string fsolucion = Calendar1.SelectedDate.ToString("yyy-MM-dd");
        Session["fechapasada"] = fsolucion;

        string fechafin = Calendar2.SelectedDate.ToString("yyy-MM-dd");
        Session["fechadespues"] = fechafin;


        Session["idSub"] = resultado.DevolverIdSubsedeAdministrador(Session["user_id"].ToString());

        try
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["terminacion"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["terminacion"].ToString());
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("ConsultarVentasPasadas.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LVentasPasadas.Text = hashMap["LVentasPasadas"];
            LInstruccionDos.Text = hashMap["LInstruccionDos"];
            LInstruccionUno.Text = hashMap["LInstruccionUno"];
            LBInstruccionTres.Text = hashMap["LBInstruccionTres"];
            LDetalleVenta.Text = hashMap["LDetalleVenta"];

            GVVentas.Columns[1].HeaderText = hashMap["GVVentasColumna1"];
            GVVentas.Columns[2].HeaderText = hashMap["GVVentasColumna2"];
            GVVentas.Columns[3].HeaderText = hashMap["GVVentasColumna3"];
            GVVentas.Columns[4].HeaderText = hashMap["GVVentasColumna4"];
            GVVentas.EmptyDataText = hashMap["EmptyGVVentas"];

            GVDetalleVenta.Columns[0].HeaderText = hashMap["GVDetalleVentaColumna0"];
            GVDetalleVenta.Columns[1].HeaderText = hashMap["GVDetalleVentaColumna1"];
            GVDetalleVenta.Columns[2].HeaderText = hashMap["GVDetalleVentaColumna2"];
            GVDetalleVenta.Columns[3].HeaderText = hashMap["GVDetalleVentaColumna3"];
            GVDetalleVenta.EmptyDataText = hashMap["EmptyGVDetalleVenta"];

           

            IBSalir.ImageUrl = hashMap["IBSalir"];


        }
        catch (Exception)
        {

        }
        }

  
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}