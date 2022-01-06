<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador.master" AutoEventWireup="true" CodeFile="~/Controller/ConsultaPedidosAdministrador.aspx.cs" Inherits="View_ConsultaPedidosAdministrador" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .auto-style29 {
        width: 100%;
        height: 351px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style30 {
        font-size: large;
    }
    .auto-style32 {
        width: 102%;
    }
    .auto-style33 {
        font-size: x-large;
    }
    .auto-style34 {
        width: 17%;
    }
    </style>
      <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1113px" Width="100%">
    <br />
    <table class="auto-style29">
        <tr>
            <td class="auto-style34">&nbsp;</td>
            <td>
                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1013px" Width="869px">
                    <table class="auto-style32">
                        <tr>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table class="auto-style1">
                                            <tr>
                                                <td class="auto-style8" colspan="2">
                                                    <br />
                                                    <asp:Label ID="LPedidosActivos" runat="server" CssClass="auto-style33" Text="PEDIDOS ACTIVOS"></asp:Label>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                    <asp:Label ID="lSeleccionePedido" runat="server" CssClass="auto-style30" Text="Seleccione el pedido:"></asp:Label>
                                                    <br />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="auto-style8">
                                                        <asp:GridView ID="GW_pedidos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="Id_pedido" DataSourceID="DOS_pedidos_subsede" ForeColor="Black" GridLines="None" Width="814px" EmptyDataText="Aun no hay pedidos registrados">
                                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                            <Columns>
                                                                <asp:CommandField ShowSelectButton="True" />
                                                                <asp:BoundField DataField="Id_pedido" HeaderText="N° de pedido" />
                                                                <asp:BoundField DataField="TipoDeEntrega" HeaderText="Tipo de entrega" />
                                                                <asp:BoundField DataField="Total" HeaderText="Valor total" />
                                                                <asp:BoundField DataField="Estado1" HeaderText="Estado" />
                                                            </Columns>
                                                            <FooterStyle BackColor="Tan" />
                                                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                                                        </asp:GridView>
                                                    </div>
                                                    <asp:ObjectDataSource ID="DOS_pedidos_subsede" runat="server" SelectMethod="ObtenerPedidosAdmin" TypeName="Logica.LSubsede">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="administrador" SessionField="user_id" Type="Int32" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                                <td>
                                                    <div class="auto-style8">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div class="auto-style8">
                                                        <asp:GridView ID="GW_detalle" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="DOS_detalle_pedido" ForeColor="Black" GridLines="None" Width="825px" EmptyDataText="Aun no se ha seleccionado un pedido">
                                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                            <Columns>
                                                                <asp:BoundField DataField="IdProducto" HeaderText="Codigo producto" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                                <asp:BoundField DataField="CantidadMin" HeaderText="Total" />
                                                            </Columns>
                                                            <FooterStyle BackColor="Tan" />
                                                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                                                        </asp:GridView>
                                                    </div>
                                                    <asp:ObjectDataSource ID="DOS_detalle_pedido" runat="server" SelectMethod="ObtenerDetallePedidoAdmin" TypeName="Logica.LSubsede">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="GW_pedidos" Name="id_venta" PropertyName="SelectedValue" Type="Int32" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GW_pedidos" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>

