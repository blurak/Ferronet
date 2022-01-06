<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/PromocionesPlatos.aspx.cs" Inherits="View_PromocionesPlatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 869px;
            height: 108px;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 70%;
        }
        .auto-style6 {
            font-size: medium;
        }
        .auto-style8 {
            width: 890px;
            height: 97px;
        }
        .auto-style9 {
            width: 306px;
        }
        .auto-style10 {
            width: 306px;
            height: 30px;
        }
        .auto-style11 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <img class="auto-style1" src="../Images/Slideshow/platosBanner.jpg" width="70%" /><br />
            <br />
            <div class="auto-style4">
            <asp:GridView ID="GWPlatos" runat="server" Width="78%" OnSelectedIndexChanging="GWPlatos_SelectedIndexChanging" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                     <asp:CommandField ButtonType="Button" SelectText="Pedir" ShowSelectButton="True" />
                       
                     <asp:BoundField DataField="id" HeaderText="Codigo" />
                     <asp:BoundField DataField="nombre" HeaderText="Platillo" />
                     <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                     <asp:BoundField DataField="precio" HeaderText="Precio" />
                     <asp:ImageField DataImageUrlField="imagen" HeaderText="Foto">
                         <ControlStyle Height="80px" Width="80px" />
                     </asp:ImageField>
                       
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            </div>
            <br />
            <br />
            <img class="auto-style8" src="../Images/Slideshow/platosContactenos.jpg" /><br />
            <table class="auto-style5">
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="LBNombre" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TBNombre" runat="server" BackColor="Silver"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBNombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonEnviar"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="LBEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TBEmail" runat="server" BackColor="Silver" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TBEmail" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonEnviar"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="LTelefono" runat="server" Text="Telefono"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:TextBox ID="TBTelefono" runat="server" BackColor="Silver"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TBTelefono" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonEnviar"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="LMensaje" runat="server" Text="Mensaje"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TBMensaje" runat="server" BackColor="Silver" Height="83px" TextMode="MultiLine" Width="175px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TBMensaje" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonEnviar"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2">
                        <asp:Button ID="BtnEnviar" runat="server" BackColor="#EBB462" CssClass="auto-style6" Height="43px" Text="Enviar" Width="77px" OnClick="BtnEnviar_Click" ValidationGroup="BotonEnviar" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <table class="auto-style5">
                <tr>
                    <td class="auto-style4">
            <asp:Button ID="BtnSalir" runat="server" CssClass="auto-style3" Height="35px" OnClick="BtnSalir_Click" Text="Salir" Width="75px" BackColor="#EBB462" />
                    </td>
                </tr>
            </table>
            <br />
        </div>

        <br />
    </form>
</body>
</html>
