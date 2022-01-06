<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Cantidades.aspx.cs" Inherits="View_Cantidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 200px%;
        }
        .auto-style2 {
            text-align: right;
            height: 30px;
        }
        .auto-style3 {
            font-size: small;
        }
        .auto-style4 {
            text-align: right;
            height: 30px;
            width: 184px;
        }
        .auto-style5 {
            font-size: medium;
        }
    </style>

       <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="2">
                        <br />
            <asp:Label ID="LBCodigo" runat="server" Text="Codigo" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <br />
            <asp:Label ID="Lb_codigo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
            <asp:Label ID="LBProducto" runat="server" Text="Producto" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <br />
            <asp:Label ID="Lb_producto" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <asp:Label ID="LBCantidadinve" runat="server" Text="Cantidad en inventario" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:Label ID="LbCantidadInventario" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
            <asp:Label ID="LBCantidadmin" runat="server" Text="Cantidad minima" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <br />
            <asp:TextBox ID="TbCantidadMinima" runat="server" CssClass="auto-style5" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TbCantidadMinima" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonAceptar"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="ReCantidadminimaExcedida" runat="server" ControlToValidate="TbCantidadMinima" CssClass="auto-style3" ErrorMessage="Esta cantidad excede el limite permitido que es 429496729" ForeColor="Red" ValidationExpression="^[0-9]{1,9}$" ValidationGroup="botonAceptar"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
            <asp:Label ID="LBCantidad" runat="server" Text="Cantidad " ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <br />
            <asp:TextBox ID="TbCantidad" runat="server" CssClass="auto-style5" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TbCantidad" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonAceptar"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="ReCantidadExcedida" runat="server" ControlToValidate="TbCantidad" CssClass="auto-style3" ErrorMessage="Esta cantidad excede el limite permitido que es 429496729" ForeColor="Red" ValidationExpression="^[0-9]{1,9}$" ValidationGroup="botonAceptar"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                        <asp:Label ID="Lb_mensaje" runat="server" ForeColor="Red"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
            <asp:Button ID="BTAceptar" runat="server" Text="Aceptar" OnClick="Bt_aceptar_Click" ValidationGroup="botonAceptar" BackColor="#FF952B" Height="40px" />
                    </td>
                    <td class="auto-style2" colspan="2">
                        <asp:Button ID="BTCancelar" runat="server"  Text="Cancelar" OnClick="BtCancelar_Click" BackColor="#FF952B" Height="40px" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
