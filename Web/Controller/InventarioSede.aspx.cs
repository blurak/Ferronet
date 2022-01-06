using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_InventarioSede : System.Web.UI.Page
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
            hashMap = datos.devolver("InventarioSede.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBInventarioActu.Text = hashMap["LBInventarioActu"];
            LBProductosBajas.Text = hashMap["LBProductosBajas"];
            IBEliminarProdu.ImageUrl = hashMap["IBEliminarProdu"];
            IBAgregarProdu.ImageUrl = hashMap["IBAgregarProdu"];
            IBRegistrarProductos.ImageUrl = hashMap["IBRegistrarProductos"];


            GW_productos_sede.Columns[1].HeaderText = hashMap["GWProductos0"];
            GW_productos_sede.Columns[2].HeaderText = hashMap["GWProductos1"];
            GW_productos_sede.Columns[3].HeaderText = hashMap["GWProductos2"];
            GW_productos_sede.Columns[4].HeaderText = hashMap["GWProductos3"];

            GWProductosBajas.Columns[1].HeaderText = hashMap["GWProductos0"];
            GWProductosBajas.Columns[2].HeaderText = hashMap["GWProductos1"];
            GWProductosBajas.Columns[3].HeaderText = hashMap["GWProductos2"];
            GWProductosBajas.Columns[4].HeaderText = hashMap["GWProductos3"];








        }
        catch (Exception)
        {

        }

    }



    protected void Button5_Click(object sender, EventArgs e)
    {

    }






    protected void Button7_Click(object sender, EventArgs e)
    {

    }




    protected void GW_productos_sede_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GW_productos_sede.EditIndex = e.NewEditIndex;

        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["Data"];

        this.GW_productos_sede.DataSource = dt;
        this.GW_productos_sede.DataBind();

    }



    //
    protected void GW_productos_sede_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Reset the edit index.
        GW_productos_sede.EditIndex = -1;
        //Bind data to the GridView control.
        BindData();
    }

    private void BindData()
    {
        GW_productos_sede.DataSource = Session["TaskTable"];
        GW_productos_sede.DataBind();
    }



    protected void GW_productos_sede_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    protected void DOSProductosBajosSede_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }

    protected void GWProductosBajas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}