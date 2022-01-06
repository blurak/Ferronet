<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/ConsultasSubsede.aspx.cs" Inherits="View_ConsultasSubsede" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style29 {
        width: 100%;
        height: 531px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style28 {
            width: 25%;
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
                            <td class="auto-style28">&nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="404px" Width="642px">
                                    <table class="auto-style1">
                                        <tr>
                                            <td>
                                                <br />
                                                <br />
                                                <table class="auto-style1">
                                                    <tr>
                                                        <td class="auto-style9">
                                                            <asp:ImageButton ID="IBAdminCaje" runat="server" Height="165px" ImageUrl="~/Images/botones/adminycajeroporsubsede.jpg" OnClick="ImageButton1_Click" />
                                                        </td>
                                                        <td class="auto-style9">
                                                            <asp:ImageButton ID="IBInventarioSubsede" runat="server" Height="165px" ImageUrl="~/Images/botones/inventario subsede.jpg" PostBackUrl="~/View/Productos_subsede.aspx" />
                                                        </td>
                                                        <td class="auto-style9">
                                                            <asp:ImageButton ID="IBVentasHoy" runat="server" Height="165px" ImageUrl="~/Images/botones/ventas hoy.jpg" PostBackUrl="~/View/ConsultaSuperVentasDeldia.aspx" />
                                                        </td>
                                                        <td class="auto-style9">
                                                            <asp:ImageButton ID="IBVentasPasadas" runat="server" Height="165px" ImageUrl="~/Images/botones/ventas pasadas.jpg" PostBackUrl="~/View/VentasPasadasSuper.aspx" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style9" colspan="4">
                                                            <br />
                                                            <br />
                                                            <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/Consultas.aspx" />
                                                        </td>
                                                    </tr>
                                                </table>
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

