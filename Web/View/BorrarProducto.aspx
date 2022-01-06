<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/BorrarProducto.aspx.cs" Inherits="View_BorrarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style32 {
            width: 100%;
            height: 429px;
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
        .auto-style25 {
            font-size: xx-large;
        }
        .auto-style23 {
            text-align: center;
            height: 99px;
            width: 29%;
        }
        .auto-style24 {
            text-align: left;
            height: 99px;
        }
        .auto-style27 {
            width: 157px;
        }
        .auto-style29 {
            font-size: large;
        }
        .auto-style26 {
            width: 29%;
            text-align: center;
        }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="543px">
        <table class="auto-style32">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="503px" Width="763px">
                        <br />
                        <br />
                        <br />
                        <table class="auto-style17">
                            <tr>
                                <td class="auto-style21" colspan="2">
                                    <asp:Label ID="LBBorreProduc" runat="server" CssClass="auto-style25" Text="Borre productos de su inventario"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23"></td>
                                <td class="auto-style24">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style27">
                                                <br />
                                                <asp:Label ID="LBCodigo" runat="server" CssClass="auto-style29" Text="Codigo del producto"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DL_productos" runat="server" Height="17px" Width="128px" OnSelectedIndexChanged="DL_productos_SelectedIndexChanged" DataSourceID="ODSObtenerProductos" DataTextField="Descripcion" DataValueField="IdProducto">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ODSObtenerProductos" runat="server" SelectMethod="ObtenerProductosDrop" TypeName="Logica.LSede">
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style26">
                                    <br />
                                    <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/InventarioSede.aspx" />
                                    <br />
                                </td>
                                <td class="auto-style9">
                                    <asp:Button ID="BTBorrar" runat="server" BackColor="#FFB56A" Height="40px" OnClick="Button7_Click" Text="Borrar productos" />
                                </td>
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

