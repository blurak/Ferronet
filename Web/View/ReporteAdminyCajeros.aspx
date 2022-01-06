<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/ReporteAdminyCajeros.aspx.cs" Inherits="View_ReporteAdminyCajeros" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

          
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style14 {
            width: 100%;
        }

      

        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1500px" Width="100%">
                    <CR:CrystalReportViewer ID="CRV_ReporteCajeroyAdmin" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="700px" ReportSourceID="CRS_ReporteCajeroyAdmin" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="400px" />
                    <CR:CrystalReportSource ID="CRS_ReporteCajeroyAdmin" runat="server">
                        <Report FileName="~/Reportes/ReporteCajeroAdmin.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <br />
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style14">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style10">
                                <asp:ImageButton ID="ImageButton6" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/ConsultasSubsede.aspx" Width="81px" />
                            </td>
                        </tr>
                    </table>
              
                </asp:Panel>

</asp:Content>

