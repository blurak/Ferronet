<%@ Page Title="" Language="C#" MasterPageFile="~/View/Cajero.master" AutoEventWireup="true" CodeFile="~/Controller/PedidosCajero.aspx.cs" Inherits="View_PedidosCajero" %>

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
            width: 50%;
        }
        .auto-style24 {
            text-align: center;
            height: 99px;
        }
        .auto-style33 {
            font-size: xx-large;
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
                                    <asp:Label ID="LBPedidos" runat="server" CssClass="auto-style33" Text="PEDIDOS ACTUALES"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23">
                                    <asp:ImageButton ID="IBConsulta" runat="server" Height="150px" ImageUrl="~/Images/botones/consultarpedidoscajeros.jpg" PostBackUrl="~/View/ConsultaPedidosCajero.aspx" />
                                </td>
                                <td class="auto-style24">
                                    <asp:ImageButton ID="IBDespachar" runat="server" Height="150px" ImageUrl="~/Images/botones/despacharpedidos.jpg" PostBackUrl="~/View/CambiarEstadoPedido.aspx" />
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

