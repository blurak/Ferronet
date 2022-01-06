<%@ Page Title="" Language="C#" MasterPageFile="~/View/Cajero.master" AutoEventWireup="true" CodeFile="~/Controller/InventarioSubsedeCajero.aspx.cs" Inherits="View_InventarioSubsedeCajero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style32 {
            width: 100%;
            height: 429px;
        }
        .auto-style12 {
            width: 20%;
            height: 28px;
            text-align: center;
        }
        
        .auto-style12 {
            width: 20%;
        }
        .auto-style17 {
            width: 100%;
            height: 330px;
        }
        .auto-style21 {
            text-align: center;
            height: 100px;
        }
        .auto-style23 {
            text-align: center;
            height: 99px;
            width: 16%;
        }
        .auto-style24 {
            text-align: left;
            height: 99px;
        }
        .auto-style9 {
            text-align: center;
        }
        .auto-style33 {
            font-size: xx-large;
        }
        .auto-style34 {
            width: 16%;
            text-align: center;
        }
    </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="613px">
        <table class="auto-style32">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="503px" Width="763px">
                        <table class="auto-style17">
                            <tr>
                                <td class="auto-style21" colspan="2">&nbsp;<asp:Label ID="LBInventario" runat="server" CssClass="auto-style33" Text="INVENTARIO ACTUAL"></asp:Label>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style23"></td>
                                <td class="auto-style24">
                                    <div class="auto-style9">
                                        <asp:GridView ID="GWInventario" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_inventario_subsede" ForeColor="#333333" GridLines="None" Width="597px" AllowPaging="True" EmptyDataText="No hay Productos">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField DataField="Codigo_producto1" HeaderText="Codigo del producto" />
                                                <asp:BoundField DataField="Descripcion1" HeaderText="Descripcion" />
                                                <asp:BoundField DataField="Cantidadminima1" HeaderText="Cantidad minima" />
                                                <asp:BoundField DataField="Cantidad1" HeaderText="Cantidad" />
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
                                    <asp:ObjectDataSource ID="ODS_inventario_subsede" runat="server" SelectMethod="ObtenerinventarioCajero" TypeName="Logica.LSubsede">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style34">&nbsp;</td>
                                <td class="auto-style9">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
</asp:Content>

