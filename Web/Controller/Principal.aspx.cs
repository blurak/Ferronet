using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            Dictionary<String, String> resultado = new Dictionary<String, String>();
            String selectedLanguaje = Session["terminacion"].ToString();
            LVisitante datos = new LVisitante();
            resultado=datos.devolver("principal.aspx", selectedLanguaje);
            imagen1.Src = resultado["imagen1"];
            imagen2.Src = resultado["imagen2"];
            imagen3.Src = resultado["imagen3"];
        }
        catch (Exception)
        {
            
        }

    }
}