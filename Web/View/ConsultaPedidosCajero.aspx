<%@ Page Title="" Language="C#" MasterPageFile="~/View/Cajero.master" AutoEventWireup="true" CodeFile="~/Controller/ConsultaPedidosCajero.aspx.cs" Inherits="View_ConsultaPedidosCajero" %>

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

      

        .auto-style28 {
            width: 47%;
        }
        .auto-style30 {
            margin-left: 0;
        }
        .auto-style31 {
            width: 10%;
        }
    .auto-style32 {
        width: 343px;
    }
    .auto-style33 {
        width: 102%;
    }
    .auto-style34 {
        font-size: x-large;
    }
        .auto-style35 {
            font-size: large;
        }
    </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="700px" Width="100%">
        <br />
        <table class="auto-style29">
            <tr>
                <td class="auto-style31">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="585px" Width="1100px" CssClass="auto-style30">
                        <table class="auto-style33">
                            <tr>
                                <td class="auto-style6" colspan="2">
                                    <br />
                                    <asp:Label ID="LBPedidos" runat="server" CssClass="auto-style34" Text="PEDIDOS ACTUALES"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style28">
                                    <br />
                                    <asp:Label ID="LBSeleccione" runat="server" Text="Seleccione el pedido que desea consultar:" CssClass="auto-style35"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                                <td class="auto-style32">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style28">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </td>
                                <td class="auto-style32">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="DAOSPedidosSubsede" runat="server" SelectMethod="obtenerPedidosCajeroP" TypeName="Logica.LCajero">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        <div class="auto-style6">
                                                            <asp:GridView ID="GWPedido" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NumeroPedido" DataSourceID="DAOSPedidosSubsede" ForeColor="#333333" GridLines="None" Width="581px" AllowPaging="True" EmptyDataText="No Tenemos Pedidos">
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                <Columns>
                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                    <asp:BoundField DataField="NumeroPedido" HeaderText="N° de pedido" InsertVisible="False" />
                                                                    <asp:BoundField DataField="TipoDeEntrega" HeaderText="Tipo de entrega" />
                                                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                                                    <asp:BoundField DataField="Total" HeaderText="Total" />
                                                                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                                </Columns>
                                                                <EditRowStyle BackColor="#999999" />
                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:ObjectDataSource ID="DAOSDetallePedido" runat="server" SelectMethod="obtenerDetallePedidoProductoP" TypeName="Logica.LCajero">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="GWPedido" Name="idPedido" PropertyName="SelectedValue" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        <div class="auto-style6">
                                                            <asp:GridView ID="GWDetalle" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DAOSDetallePedido" ForeColor="#333333" GridLines="None" AllowPaging="True" Width="436px" EmptyDataText="No Tenemos Detalles">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                                    <asp:BoundField DataField="ValorTotal" HeaderText="Total" />
                                                                </Columns>
                                                                <EditRowStyle BackColor="#7C6F57" />
                                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#E3EAEB" />
                                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GWDetalle" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6" colspan="2">
                                    <br />
                                    <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/PedidosCajero.aspx" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

