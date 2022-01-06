<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador.master" AutoEventWireup="true" CodeFile="~/Controller/CajeroAsignado.aspx.cs" Inherits="View_CajeroAsignado" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .auto-style29 {
        width: 100%;
        height: 513px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style27 {
            width: 30%;
        }
        .auto-style28 {
            width: 25%;
        }
    .auto-style30 {
        text-align: left;
    }
    .auto-style31 {
        font-size: large;
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
                <td class="auto-style27">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="356px" Width="507px">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style28">&nbsp;</td>
                                <td>
                                    <br />
                                    <br />
                                    <asp:DataList ID="DLCajero" runat="server" DataSourceID="DAOSCajeroSubsede" OnItemDataBound="DLCajero_ItemDataBound" RepeatDirection="Horizontal">
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="LCodigo" runat="server" Text="Codigo" ForeColor="Red" CssClass="auto-style31"></asp:Label>
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td class="auto-style30">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Id_pedido") %>' CssClass="auto-style31"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LNombre" runat="server" Text="Nombre" ForeColor="Red" CssClass="auto-style31"></asp:Label>
                                                        <br />
                                                    </td>
                                                    <td class="auto-style8">
                                                        <br />
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Nombre1") %>' CssClass="auto-style31"></asp:Label>
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <asp:Label ID="LUsuario" runat="server" Text="Usuario" ForeColor="Red" CssClass="auto-style31"></asp:Label>
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td class="auto-style8">
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("TipoDeEntrega") %>' CssClass="auto-style31"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <asp:Label ID="LCorreo" runat="server" Text="Correo" ForeColor="Red" CssClass="auto-style31"></asp:Label>
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td class="auto-style8">
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Direccion1") %>' CssClass="auto-style31"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <asp:ObjectDataSource ID="DAOSCajeroSubsede" runat="server" SelectMethod="ObtenerCajeroAsignadoAdmin" TypeName="Logica.LSubsede">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="id_usuario" SessionField="user_id" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
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
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

