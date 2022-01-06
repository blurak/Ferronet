<%@ Page Title="" Language="C#" MasterPageFile="~/View/principal.master" AutoEventWireup="true" CodeFile="~/Controller/Productos.aspx.cs" Inherits="View_Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style14 {
            width: 80%;
        }
        .auto-style16 {
            width: 20%;
        }
        .auto-style18 {
            font-size: medium;
        }
        .auto-style19 {
            text-align: center;
        }
        .auto-style20 {
            font-size: large;
        }
       
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="1700px">
        <table class="auto-style1">
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td>
                    <br />
                    <br />
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1503px" Width="822px">
                        <br />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LBusqueAquiSuProducto" runat="server" CssClass="auto-style20" Text="Busque aqui su producto"></asp:Label>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="Tbbuscar" runat="server" CssClass="auto-style18" Height="19px" Width="147px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="BBuscar" runat="server" CssClass="auto-style18" Height="32px" Text="Buscar" Width="80px" />
                                <br />
                                <br />
                                <asp:ObjectDataSource ID="pintar_productos" runat="server" SelectMethod="obtenerProductosVisitante" TypeName="Logica.LUsuario">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="Tbbuscar" DefaultValue= " " PropertyName="Text" Type="String" Name="Criterio" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <br />
                                <div class="auto-style19">
                                    <asp:GridView ID="GVProductos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="pintar_productos" EmptyDataText="No hay resultados" ForeColor="#333333" GridLines="None" Width="819px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
                                                <ControlStyle Height="100px" />
                                            </asp:ImageField>
                                            <asp:BoundField DataField="Codigo_producto1" HeaderText="Codigo del producto" />
                                            <asp:BoundField DataField="Descripcion1" HeaderText="Descripcion" />
                                            <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                            <asp:BoundField DataField="Subsede" HeaderText="Subsede" />
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
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="BBuscar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="GVProductos" EventName="PageIndexChanging" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
        </table>
</asp:Panel>
<p>
    <br />
</p>
<p>
</p>
<p>
</p>
</asp:Content>

