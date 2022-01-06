using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_ConsultaSuperVentasDeldia : System.Web.UI.Page
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
        LSede sede = new LSede();
        DateTime fecha;
        string fecha1;
        fecha = DateTime.Today;
        string formato = "MM dd yyyy";
        fecha1 = fecha.ToString(formato);
        Session["Fechahoy"] = fecha1;
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("ConsultaSuperVentasDeldia.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            GWVenta.EmptyDataText = hashMap["EmptyGWVenta"];
            GWDetalle.EmptyDataText = hashMap["EmptyGWDetalle"];
            GWDetalle.Columns[0].HeaderText = hashMap["GWDetalle0"];
            GWDetalle.Columns[1].HeaderText = hashMap["GWDetalle1"];
            GWDetalle.Columns[2].HeaderText = hashMap["GWDetalle2"];
            GWDetalle.Columns[3].HeaderText = hashMap["GWDetalle3"];
           //  GWTotalVendido.Columns[0].HeaderText = hashMap["GWTotal0"];
            LBVentas.Text = hashMap["LBVentas"];
            LBSeleccionSub.Text = hashMap["LBSeleccionSub"];
            LBDetalle.Text = hashMap["LBDetalle"];
            IBSalir.ImageUrl = hashMap["IBSalir"];
            LBSeleccioneVenta.Text = hashMap["LBSeleccioneVenta"];
            GWSede.Columns[1].HeaderText = hashMap["GWSede0"];
            GWSede.Columns[2].HeaderText = hashMap["GWSede1"];

            GWVenta.Columns[1].HeaderText = hashMap["GWVenta0"];
            GWVenta.Columns[2].HeaderText = hashMap["GWVenta1"];
            GWVenta.Columns[3].HeaderText = hashMap["GWVenta2"];
            GWVenta.Columns[4].HeaderText = hashMap["GWVentas3"];
            
           
          


        }
        catch (Exception)
        {
            
        }




    }
}