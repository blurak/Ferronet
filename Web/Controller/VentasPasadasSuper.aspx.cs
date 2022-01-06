using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_VentasPasadasSuper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();

        LSede inicio = new LSede();
        try
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()));

        }
        catch (Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");
        }

        DateTime fecha;
        string fecha1;
        fecha = DateTime.Today;
        string formato = "yyy-MM-dd";
        fecha1 = fecha.ToString(formato);
        Session["fecha"] = fecha1;

        string fecha2;
        fecha = DateTime.Today;
        string formato2 = "yyy-MM-dd";
        fecha2 = fecha.ToString(formato2);
        Session["fechafin"] = fecha2;

        string fsolucion = Calendar1.SelectedDate.ToString("yyy-MM-dd");
        Session["fecha"] = fsolucion;
        string fechafin = Calendar2.SelectedDate.ToString("yyy-MM-dd");
        Session["fechafin"] = fechafin;
        try
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["terminacion"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["terminacion"].ToString());
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("VentasPasadasSuper.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            GWDetalle.EmptyDataText = hashMap["EmptyGWVenta"];
            GWVenta.EmptyDataText = hashMap["EmptyGWDetalle"];
            GWDetalle.Columns[0].HeaderText = hashMap["GWDetalle0"];
            GWDetalle.Columns[1].HeaderText = hashMap["GWDetalle1"];
            GWDetalle.Columns[2].HeaderText = hashMap["GWDetalle2"];
            GWDetalle.Columns[3].HeaderText = hashMap["GWDetalle3"];
            
            LBVentasSubsede.Text = hashMap["LBVentasSubsede"];
            LBFin.Text = hashMap["LBFin"];
            LBDetalle.Text = hashMap["LBDetalle"];
            LBInicio.Text = hashMap["LBInicio"];
            LBSubsede.Text = hashMap["LBSubsede"];
            IBSalir.ImageUrl = hashMap["IBSalir"];

            GWSede.Columns[1].HeaderText = hashMap["GWSede0"];
            GWSede.Columns[2].HeaderText = hashMap["GWSede1"];
            GWVenta.Columns[1].HeaderText = hashMap["GWVenta0"];
            GWVenta.Columns[2].HeaderText = hashMap["GWVenta1"];
            GWVenta.Columns[3].HeaderText = hashMap["GWVenta2"];
            GWVenta.Columns[4].HeaderText = hashMap["GWVenta3"];

        }
        catch (Exception)
        {


        }




    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string fsolucion = Calendar1.SelectedDate.ToString("yyy-MM-dd");
        Session["fecha"] = fsolucion;

    }

    protected void ODS_VentasPasadasSueper_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }

    protected void Button5_Click1(object sender, EventArgs e)
    {
        string fsolucion = Calendar1.SelectedDate.ToString("yyy-MM-dd");
        Session["fecha"] = fsolucion;

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        string fsolucion = Calendar1.SelectedDate.ToString("yyy-MM-dd");
        Session["fecha"] = fsolucion;
        string fechafin = Calendar2.SelectedDate.ToString("yyy-MM-dd");
        Session["fechafin"] = fechafin;

    }

    void seleccion()
    {

    }
}