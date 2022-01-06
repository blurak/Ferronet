<%@ Page Title="" Language="C#" MasterPageFile="~/View/Cliente.master" AutoEventWireup="true" CodeFile="~/Controller/ConsultarPedidoCliente.aspx.cs" Inherits="View_ConsultarPedidoCliente" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .auto-style29 {
        width: 100%;
        height: 830px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style27 {
            width: 30%;
        }
        .auto-style28 {
            width: 13%;
        }
        .auto-style30 {
            font-size: large;
        }
        .auto-style31 {
            text-align: center;
        }
        .auto-style32 {
            font-size: large;
            color: #FF5050;
        }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="100%" Width="100%">
    <br />
    <table class="auto-style29">
        <tr>
            <td class="auto-style27">&nbsp;</td>
            <td>
                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="829px" Width="678px">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style28">&nbsp;</td>
                            <td class="auto-style31">
                                <br />
                                <asp:Label ID="LInformacion" runat="server" CssClass="auto-style32" Text="Informacion de su pedido"></asp:Label>
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="LNumeroPedido" runat="server" CssClass="auto-style32" Text="N° pedido:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="nPedido" runat="server" CssClass="auto-style30"></asp:Label>
                                <br />
                                <br />
                                <asp:GridView ID="GVDetallePedido" runat="server" DataSourceID="DOS_pedido_cliente" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="558px" AllowPaging="True" EmptyDataText="Aun no tiene un pedido activo">
                                    <Columns>
                                        <asp:BoundField DataField="CodigoDelProducto" HeaderText="Codigo del producto" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                        <asp:BoundField DataField="ValorTotal" HeaderText="Precio total" />
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="DOS_pedido_cliente" runat="server" SelectMethod="obtenerInformacionPedido" TypeName="Logica.LCliente">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <br />
                                <br />
                                <asp:DataList ID="DLTotalYTipo" runat="server" DataSourceID="DOS_total_tipo" OnItemDataBound="DLTotalYTipo_ItemDataBound" Height="196px" Width="554px">
                                    <ItemTemplate>
                                        <br />
                                        <br />
                                        <table class="auto-style1">
                                            <tr>
                                                <td>
                                                    <br />
                                                    <asp:Label ID="LTotal" runat="server" ForeColor="#FA3044" Text="Total"></asp:Label>
                                                    <br />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                    <asp:Label ID="LTipo" runat="server" CssClass="auto-style31" ForeColor="#FA3044" Text="Tipo de entrega"></asp:Label>
                                                    <br />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" CssClass="auto-style31" Text='<%# Eval("TipoDeEntrega") %>'></asp:Label>
                                                </td>
                                                <td class="auto-style32">&nbsp;</td>
                                                <td class="auto-style32">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                                <asp:ObjectDataSource ID="DOS_total_tipo" runat="server" SelectMethod="obtenerTotalYTipoDeEntrega" TypeName="Logica.LCliente">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>

