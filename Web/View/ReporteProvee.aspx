<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/ReporteProvee.aspx.cs" Inherits="View_ReporteProvee" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

          
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style14 {
            width: 10%;
        height: 64px;
    }
        .auto-style15 {
        text-align: center;
        background-color: #FFFFFF;
    }
    .auto-style16 {
        height: 64px;
    }
    .auto-style17 {
        width: 100%;
        height: 575px;
    }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1500px" Width="100%">
                    <br />
                    <br />
                    <CR:CrystalReportViewer ID="CRV_ReporteProveedores" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="700px" ReportSourceID="CRS_ReporteProveedores" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="400px" />
                    <CR:CrystalReportSource ID="CRS_ReporteProveedores" runat="server">
                        <Report FileName="~/Reportes/ReportProvee.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <br />
                    <br />
                    <br />
                    <table class="auto-style17">
                        <tr>
                            <td class="auto-style14"></td>
                            <td class="auto-style16">
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
                        <tr>
                            <td class="auto-style15" colspan="2">
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/Consultas.aspx" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    
                                
                </asp:Panel>
         
</asp:Content>

