using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_CantidadesProximasATerminar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LSede inicio = new LSede();

        try
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()));

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
            hashMap = datos.devolver("CantidadesProximasATerminar.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBSubsedesCanti.Text = hashMap["LBSubsedesCanti"];
            IBSalir.ImageUrl = hashMap["IBSalir"];

            GWCantiadesBajas.Columns[2].HeaderText = hashMap["GWCantiadesBajas0"];
            GWCantiadesBajas.Columns[3].HeaderText = hashMap["GWCantiadesBajas1"];
            GWCantiadesBajas.Columns[4].HeaderText = hashMap["GWCantiadesBajas2"];
            GWCantiadesBajas.Columns[5].HeaderText = hashMap["GWCantiadesBajas3"];
            GWCantiadesBajas.Columns[6].HeaderText = hashMap["GWCantiadesBajas4"];
            GWCantiadesBajas.Columns[7].HeaderText = hashMap["GWCantiadesBajas5"];
            GWCantiadesBajas.Columns[8].HeaderText = hashMap["GWCantiadesBajas6"];








        }
        catch (Exception)
        {

        }

    }
}