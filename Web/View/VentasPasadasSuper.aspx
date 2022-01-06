<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/VentasPasadasSuper.aspx.cs" Inherits="View_VentasPasadasSuper" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .auto-style29 {
        width: 100%;
        height: 653px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style27 {
            width: 14%;
        }
        .auto-style30 {
            margin-top: 0;
        }
        .auto-style31 {
            width: 100%;
            height: 1245px;
        }
        .auto-style32 {
            font-size: large;
        }
        .auto-style34 {
            width: 470px;
        }
        .auto-style35 {
            width: 248px;
        }
        .auto-style36 {
            width: 257px;
        }
        .auto-style37 {
            font-size: xx-large;
        }
        .auto-style38 {
            width: 312px;
        }
        .auto-style39 {
            width: 277px;
        }
    </style>
    <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1440px" Width="100%">
                    <br />
                    <table class="auto-style29">
                        <tr>
                            <td class="auto-style27">&nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1200px" Width="880px">
                                    <table class="auto-style31">
                                        <tr>
                                            <td>
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td class="auto-style9">
                                                                    <asp:Label ID="LBVentasSubsede" runat="server" CssClass="auto-style37" Text="Ventas de subsedes"></asp:Label>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td class="auto-style35">
                                                                    <asp:Label ID="LBInicio" runat="server" CssClass="auto-style32" Text="Seleccione el dia de incio:"></asp:Label>
                                                                </td>
                                                                <td class="auto-style36">
                                                                    <asp:Label ID="LBFin" runat="server" CssClass="auto-style32" Text="Seleccione el dia de fin:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="LBSubsede" runat="server" CssClass="auto-style32" Text="Seleccione la subsede:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td class="auto-style39">
                                                                    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" CssClass="auto-style30" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" SelectedDate="2018-10-09">
                                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                                        <SelectorStyle BackColor="#FFCC66" />
                                                                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                                                    </asp:Calendar>
                                                                </td>
                                                                <td class="auto-style38">
                                                                    <div class="auto-style9">
                                                                        <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" SelectedDate="2018-05-20" Width="220px">
                                                                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                                            <OtherMonthDayStyle ForeColor="#999999" />
                                                                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                                            <WeekendDayStyle BackColor="#CCCCFF" />
                                                                        </asp:Calendar>
                                                                    </div>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                                <td class="auto-style9">
                                                                    <asp:GridView ID="GWSede" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="IdProducto" DataSourceID="Ods_subsedes" ForeColor="Black" GridLines="None" Width="307px" EmptyDataText="Aun no hay subsedes registradas">
                                                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                                        <Columns>
                                                                            <asp:CommandField ShowSelectButton="True" />
                                                                            <asp:BoundField DataField="IdProducto" HeaderText="Codigo de subsede" />
                                                                            <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
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
                                                                    <asp:ObjectDataSource ID="Ods_subsedes" runat="server" SelectMethod="ObtenerSubsedees" TypeName="Logica.LSede">
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="LBDetalle" runat="server" CssClass="auto-style32" Text="Seleccione para ver detalles de la venta:"></asp:Label>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td class="auto-style34">
                                                                    <div class="auto-style9">
                                                                        <asp:GridView ID="GWVenta" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="id" DataSourceID="ODS_VentasPasadasSueper" EmptyDataText="No tenemos ventas para mostrar" ForeColor="Black" GridLines="None" Width="422px">
                                                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                                            <Columns>
                                                                                <asp:CommandField ShowSelectButton="True" />
                                                                                <asp:BoundField DataField="id" HeaderText="Codigo de venta" />
                                                                                <asp:BoundField DataField="valor_total" HeaderText="Valor total" />
                                                                                <asp:BoundField DataField="dia" HeaderText="Fecha" />
                                                                                <asp:BoundField DataField="hora" HeaderText="Hora" />
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
                                                                    <asp:ObjectDataSource ID="ODS_VentasPasadasSueper" runat="server" OnSelecting="ODS_VentasPasadasSueper_Selecting" SelectMethod="ObtenerVentasPasadasSuperAdminSql" TypeName="Logica.LSede">
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter ControlID="GWSede" Name="idSubsede" PropertyName="SelectedValue" Type="Int32" />
                                                                            <asp:SessionParameter Name="fecha_inicio" SessionField="fecha" Type="String" />
                                                                            <asp:SessionParameter Name="fecha_fin" SessionField="fechafin" Type="String" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                                <td>
                                                                    <div class="auto-style9">
                                                                        <asp:GridView ID="GWDetalle" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="ODSDetalleVentas" GridLines="Horizontal" Width="394px" EmptyDataText="Aun no hay ninguna venta seleccionada">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                                                <asp:BoundField DataField="ValorTotal" HeaderText="Valor total" />
                                                                            </Columns>
                                                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <asp:ObjectDataSource ID="ODSDetalleVentas" runat="server" SelectMethod="ObtenerDetalleVentasPorSubsede" TypeName="Logica.LSede">
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter ControlID="GWVenta" Name="id_venta" PropertyName="SelectedValue" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div class="auto-style9">
                                                            <asp:Label ID="Label1" runat="server" Text="Total Vendido"></asp:Label>
                                                            <asp:GridView ID="GridView2" runat="server" DataSourceID="DAOtotalVendido">
                                                            </asp:GridView>
                                                            <br />
                                                            <asp:ObjectDataSource ID="ORigenprueba" runat="server" SelectMethod="ObtenerVentasPasadasSuperAdminSql" TypeName="Logica.LSede">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="GWSede" Name="idSubsede" PropertyName="SelectedValue" Type="Int32" />
                                                                    <asp:SessionParameter Name="fecha_inicio" SessionField="fecha" Type="String" />
                                                                    <asp:SessionParameter Name="fecha_fin" SessionField="fechafin" Type="String" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </div>
                                                        <asp:ObjectDataSource ID="DAOtotalVendido" runat="server" SelectMethod="ObtenerTotalVentasPasadasSuperAdminSql" TypeName="Logica.LSede">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="GWSede" Name="idSubsede" PropertyName="SelectedValue" Type="Int32" />
                                                                <asp:SessionParameter Name="fecha_inicio" SessionField="fecha" Type="String" />
                                                                <asp:SessionParameter Name="fecha_fin" SessionField="fechafin" Type="String" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        <br />
                                                        <br />
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td class="auto-style9">
                                                                    <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/ConsultasSubsede.aspx" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <br />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="GWSede" EventName="SelectedIndexChanged" />
                                                        <asp:AsyncPostBackTrigger ControlID="GWDetalle" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            <br />
</asp:Content>

