<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/AdministracionDeSubsedes.aspx.cs" Inherits="View_AdministracionDeSubsedes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style32 {
            width: 100%;
            height: 429px;
        }
        .auto-style33 {
            width: 4%;
        }

        .auto-style34 {
            width: 286px;
        }

    </style>
       <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="702px">
        <table class="auto-style32">
            <tr>
                <td class="auto-style34">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="503px" Width="763px">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style33">&nbsp;</td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style9">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <asp:ImageButton ID="IBRegistrarAdminYCajero" runat="server" Height="165px" ImageUrl="~/Images/botones/cajeroyadmin.jpg" PostBackUrl="~/View/CrearCajeroyAdmin.aspx" />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td class="auto-style9">
                                                <asp:ImageButton ID="IBCrearSubsede" runat="server" Height="165px" ImageUrl="~/Images/botones/sede.jpg" PostBackUrl="~/View/CrearSede.aspx" />
                                            </td>
                                            <td class="auto-style9">
                                                <br />
                                                <asp:ImageButton ID="IBAsignarInventario" runat="server" Height="165px" ImageUrl="~/Images/botones/inventarioSubsede.jpg" PostBackUrl="~/View/InventarioSubsede.aspx" />
                                                <br />
                                            </td>
                                            <td class="auto-style9">
                                                <asp:ImageButton ID="IBCantidadesBajas" runat="server" Height="165px" ImageUrl="~/Images/botones/cantidadesBajas.jpg" PostBackUrl="~/View/CantidadesProximasATerminar.aspx" />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
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
    <br />
</asp:Content>

