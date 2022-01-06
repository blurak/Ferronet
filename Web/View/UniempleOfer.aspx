<%@ Page Title="" Language="C#" MasterPageFile="~/View/principal.master" AutoEventWireup="true" CodeFile="~/Controller/UniempleOfer.aspx.cs" Inherits="View_UniempleOfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style15 {
        width: 100%;
        height: 300px;
    }
        .auto-style16 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style15" __designer:mapid="1d80">
    <tr __designer:mapid="1d81">
        <td class="auto-style16" __designer:mapid="1d82">
            <asp:Image ID="Image3" runat="server" Height="251px" ImageAlign="Middle" ImageUrl="~/Images/maletin.png" Width="366px" BackColor="White" />
            <br __designer:mapid="1d85" /></td>
    </tr>
</table>
<br __designer:mapid="1d86" />
<br __designer:mapid="1d8b" />
<table class="auto-style1" __designer:mapid="1d8c">
    <tr __designer:mapid="1d8d">
        <td class="auto-style16" __designer:mapid="1d8e">
            <asp:GridView ID="GV_miPost" runat="server" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Width="1216px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="nombre_empresa" HeaderText="Empresa" />
                    <asp:BoundField DataField="direccion_empresa" HeaderText="Direccion" />
                    <asp:BoundField DataField="nit" HeaderText="NIT" />
                    <asp:BoundField DataField="Puntos_totales" HeaderText="Puntos totales" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </td>
    </tr>
</table>
<br __designer:mapid="1dae" />
<br __designer:mapid="1daf" />
<table class="auto-style1" __designer:mapid="1db0">
    <tr __designer:mapid="1db1">
        <td class="auto-style16" __designer:mapid="1db2">
            <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/Principal.aspx" />
            <br />
        </td>
    </tr>
</table>
<br __designer:mapid="1db4" />
</asp:Content>

