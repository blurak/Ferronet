<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador.master" AutoEventWireup="true" CodeFile="~/Controller/InventarioActualSubsede.aspx.cs" Inherits="View_InventarioActualSubsede" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .auto-style29 {
        width: 100%;
        height: 520px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style27 {
            width: 21%;
        }
        .auto-style30 {
            width: 99%;
            height: 299px;
        }
        .auto-style31 {
            width: 2%;
        }
        .auto-style32 {
            font-size: xx-large;
        }
    </style>
    <script type="text/javascript" src="javascript/subsede.js"></script>
    <script type="text/javascript" src="javascript/usuario.js"></script>
    <script type="text/javascript" src="javascript/sede.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="100%" Width="100%">
        <br />
        <table class="auto-style29">
            <tr>
                <td class="auto-style27">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="413px" Width="700px">
                        <table class="auto-style30">
                            <tr>
                                <td class="auto-style31">&nbsp;</td>
                                <td class="auto-style8">
                                    <br />
                                    <asp:Label ID="LInventarioActual" runat="server" CssClass="auto-style32" Text="INVENTARIO ACTUAL"></asp:Label>
                                    <br />
                                    <br />
                                    <div class="auto-style8">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GVInventarioActual" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="DAOSProductosSubsede" EmptyDataText="Aun no tiene inventario asignado" ForeColor="Black" GridLines="None" Width="679px">
                                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                    <Columns>
                                                        <asp:BoundField DataField="IdProducto" HeaderText="Codigo del producto" />
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ReadOnly="True" />
                                                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                        <asp:BoundField DataField="CantidadMin" HeaderText="Cantidad minima" />
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
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
                                                <asp:ObjectDataSource ID="DAOSProductosSubsede" runat="server" SelectMethod="ObtenerProductosSubsedeAdmin" TypeName="Logica.LSubsede">
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="administrador" SessionField="user_id" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="GVInventarioActual" EventName="PageIndexChanging" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <br />
                                    </div>
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

