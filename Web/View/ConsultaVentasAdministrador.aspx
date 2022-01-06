<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador.master" AutoEventWireup="true" CodeFile="~/Controller/ConsultaVentasAdministrador.aspx.cs" Inherits="View_ConsultaVentasAdministrador" %>

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

      

        .auto-style27 {
            width: 30%;
        }
        .auto-style28 {
            width: 50%;
            text-align: center;
        }
    </style>
    <script type="text/javascript" src="javascript/subsede.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="100%" Width="100%">
    <br />
    <table class="auto-style29">
        <tr>
            <td class="auto-style27">&nbsp;</td>
            <td>
                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="313px" Width="507px">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style28">
                                <asp:ImageButton ID="IBVentasPasadas" runat="server" Height="180px" ImageUrl="~/Images/botones/ventas pasadas.jpg" PostBackUrl="~/View/ConsultarVentasPasadas.aspx" />
                            </td>
                            <td class="auto-style8">
                                <br />
                                <br />
                                <br />
                                <asp:ImageButton ID="IBVentasDeHoy" runat="server" Height="180px" ImageUrl="~/Images/botones/ventas hoy.jpg" PostBackUrl="~/View/ConsultarVentasdelDia.aspx" />
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

