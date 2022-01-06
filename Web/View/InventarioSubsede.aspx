<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/InventarioSubsede.aspx.cs" Inherits="Controller_InventarioSubsede" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .auto-style32 {
            width: 100%;
            height: 429px;
        }
        .auto-style33 {
            width: 2%;
        }
        .auto-style37 {
            font-size: large;
        }
        .auto-style38 {
            font-size: xx-large;
        }
        </style>
   <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="1208px">
        <table class="auto-style32">
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="976px" Width="849px">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style33">&nbsp;</td>
                                <td>
                                    <br />
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LBSubsede" runat="server" CssClass="auto-style37" Text="Subsede"></asp:Label>
                                                       
                                                        <asp:DropDownList ID="DL_subsede" runat="server" BackColor="#999999" CssClass="auto-style13" DataSourceID="daoSubsede" DataTextField="Cliente" DataValueField="NumeroPedido" Width="120px">
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="daoSubsede" runat="server" SelectMethod="obtenerSubsedesInve" TypeName="Logica.LSede">
                                                            <SelectParameters>
                                                                <asp:SessionParameter DefaultValue="" Name="usuario" SessionField="user_id" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TbBuscar" runat="server"> </asp:TextBox>
                                                        <asp:Button ID="BTBuscar" runat="server" OnClick="BtBuscar_Click" style="height: 26px" Text="Buscar" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="auto-style9">
                                                        <br />
                                                        <asp:Label ID="LBInventarioActualSede" runat="server" CssClass="auto-style38" Text="Inventario actual de la sede"></asp:Label>
                                                        <asp:GridView ID="GwProductosSede" runat="server"  AllowPaging="True"  OnSelectedIndexChanging="GwProductosSede_SelectedIndexChanging" OnPageIndexChanging="GwProductosSede_PageIndexChanging" OnPageIndexChanged="GwProductosSede_PageIndexChanged" DataKeyNames="Codigo" AutoGenerateColumns="False" Width="823px" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="Aun no tiene inventario en su sede" OnRowDataBound="GwProductosSede_RowDataBound">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:CommandField ButtonType="Button" SelectText="Asignar" ShowSelectButton="True"  />
                                                                <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" ControlStyle-Height="100px">
                                                                    <ControlStyle Height="50px" />
                                                                 </asp:ImageField>
                                                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                                                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
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
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="DL_subsede"/>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style9">
                                                <br />
                                                <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/AdministracionDeSubsedes.aspx" />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
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

