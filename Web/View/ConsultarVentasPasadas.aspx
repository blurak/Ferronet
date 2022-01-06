<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador.master" AutoEventWireup="true" CodeFile="~/Controller/ConsultarVentasPasadas.aspx.cs" Inherits="View_ConsultarVentasPasadas" %>

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
            width: 24%;
        }
        .auto-style15 {
            text-align: center;
        }
        .auto-style31 {
            font-size: large;
        }
        .auto-style32 {
            font-size: x-large;
        }
        .auto-style34 {
            width: 255px;
        }
    </style>
       <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1400px" Width="100%">
                    <br />
                    <table class="auto-style29">
                        <tr>
                            <td class="auto-style27">&nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1300px" Width="675px">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ClientIDMode="AutoID">
                                        <ContentTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td class="auto-style15" colspan="2">
                                                        <br />
                                                        <asp:Label ID="LVentasPasadas" runat="server" CssClass="auto-style32" Text="VENTAS PASADAS DE SU SEDE"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style34">
                                                        <br />
                                                        <asp:Label ID="LInstruccionUno" runat="server" CssClass="auto-style31" Text="Seleccione con doble click un dia de inicio:"></asp:Label>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <br />
                                                        <asp:Label ID="LInstruccionDos" runat="server" CssClass="auto-style31" Text="Seleccione con doble click  el dia de fin:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style34">
                                                        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" SelectedDate="2018-10-18">
                                                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                            <SelectorStyle BackColor="#FFCC66" />
                                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                                        </asp:Calendar>
                                                    </td>
                                                    <td>
                                                        <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" SelectedDate="10/28/2018 17:20:15">
                                                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                            <OtherMonthDayStyle ForeColor="#999999" />
                                                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                            <WeekendDayStyle BackColor="#CCCCFF" />
                                                        </asp:Calendar>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                        <asp:Label ID="LBInstruccionTres" runat="server" CssClass="auto-style31" Text="Seleccione la venta para ver los detalles:"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <div class="auto-style15">
                                                            <asp:GridView ID="GVVentas" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="ODS_Ventaspasadas" EmptyDataText="No tenemos ventas para mostrar" ForeColor="#333333" GridLines="None" Width="665px">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                    <asp:BoundField DataField="id" HeaderText="Codigo de venta" />
                                                                    <asp:BoundField DataField="valor_total" HeaderText="Valor total" />
                                                                    <asp:BoundField DataField="dia" HeaderText="Fecha" />
                                                                    <asp:BoundField DataField="hora" HeaderText="Hora" />
                                                                </Columns>
                                                                <EditRowStyle BackColor="#7C6F57" />
                                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#E3EAEB" />
                                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                            </asp:GridView>
                                                        </div>
                                                        <asp:ObjectDataSource ID="ODS_Ventaspasadas" runat="server" SelectMethod="ObtenerVentasPasadasSuperAdminSql" TypeName="Logica.LSede">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="idSubsede" SessionField="id_subsede" Type="Int32" />
                                                                <asp:SessionParameter Name="fecha_inicio" SessionField="fechapasada" Type="String" />
                                                                <asp:SessionParameter Name="fecha_fin" SessionField="fechadespues" Type="String" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                        <asp:Label ID="LDetalleVenta" runat="server" CssClass="auto-style31" Text="Detalle de la venta"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <div class="auto-style15">
                                                            <asp:GridView ID="GVDetalleVenta" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODSDetallePedido" ForeColor="#333333" GridLines="None" Width="665px" EmptyDataText="Aun no hay una venta seleecionada">
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Producto" />
                                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                                    <asp:BoundField DataField="ValorTotal" HeaderText="Valor total" />
                                                                </Columns>
                                                                <EditRowStyle BackColor="#999999" />
                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                            </asp:GridView>
                                                        </div>
                                                        <asp:ObjectDataSource ID="ODSDetallePedido" runat="server" SelectMethod="ObtenerDetalleVenta" TypeName="Logica.LSubsede">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="GVVentas" Name="idVenta" PropertyName="SelectedValue" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GVTotalVendido" runat="server" AutoGenerateColumns="False" EmptyDataText="Aun no hay una venta seleccionada" >
                                                            <Columns>
                                                                <asp:BoundField DataField="obtener_total_vendido" HeaderText="Total vendido" />
                                                            </Columns>
                                                        </asp:GridView>
                                                        <asp:ObjectDataSource ID="ODStotalVendido" runat="server" SelectMethod="totalVendidoSubsede" TypeName="Logica.LSubsede">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="id_subsede" SessionField="idSub" Type="Int32" />
                                                                <asp:SessionParameter DefaultValue="" Name="fechainicio" SessionField="fechapasada" Type="String" />
                                                                <asp:SessionParameter Name="fechafin" SessionField="fechadespues" Type="String" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="ODS_Total">
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                                            <asp:ObjectDataSource ID="ODS_Total" runat="server" SelectMethod="ObtenerTotalVentasPasadasSuperAdminSql" TypeName="Logica.LSede">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="idSubsede" SessionField="id_subsede" Type="Int32" />
                                                    <asp:SessionParameter Name="fecha_inicio" SessionField="fechapasada" Type="String" />
                                                    <asp:SessionParameter Name="fecha_fin" SessionField="fechadespues" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <br />
                                            <table class="auto-style1">
                                                <tr>
                                                    <td class="auto-style15">
                                                        <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/ConsultaVentasAdministrador.aspx" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="Calendar2" EventName="SelectionChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="GVVentas" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
                                    <br />
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
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

