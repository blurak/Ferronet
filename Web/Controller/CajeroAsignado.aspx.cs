using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_CajeroAsignado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        LSubsede inicio = new LSubsede();
        try
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()), false);
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
            hashMap = datos.devolver("CajeroAsignado.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
        }
        catch (Exception )
        {

        }
        


    }

    protected void DLCajero_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("L_Header3")).Text = ((Dictionary<String, String>)Session["mensajes"])["GV_Idioma_Column0"].ToString();
            }
            catch (Exception exe)
            {

                ((Label)e.Item.FindControl("LCodigo")).Text = ((Dictionary<String, String>)Session["idioma"])["LCodigo"].ToString();
                ((Label)e.Item.FindControl("LNombre")).Text = ((Dictionary<String, String>)Session["idioma"])["LNombre"].ToString();
                ((Label)e.Item.FindControl("LUsuario")).Text = ((Dictionary<String, String>)Session["idioma"])["LUsuario"].ToString();
                ((Label)e.Item.FindControl("LCorreo")).Text = ((Dictionary<String, String>)Session["idioma"])["LCorreo"].ToString();
              


            }
        }
        catch (Exception exx)
        {
        }
    }
}