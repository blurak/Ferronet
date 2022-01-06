<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/Consultas.aspx.cs" Inherits="View_Consultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style12 {
            width: 20%;
        }
    </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="483px">
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="362px" Width="684px">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style9">
                                    <asp:ImageButton ID="IBInventario" runat="server" Height="165px" ImageUrl="~/Images/botones/inventario principal.jpg" OnClick="ImageButton1_Click" />
                                </td>
                                <td class="auto-style9">
                                    <asp:ImageButton ID="IBSubsedes" runat="server" Height="165px" ImageUrl="~/Images/botones/subsedes.jpg" PostBackUrl="~/View/ConsultasSubsede.aspx" />
                                </td>
                                <td class="auto-style9">
                                    <asp:ImageButton ID="IBProveedores" runat="server" Height="165px" ImageUrl="~/Images/botones/proveedoresss.jpg" OnClick="ImageButton3_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

