<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/ReporteProsede.aspx.cs" Inherits="View_ReporteProsede" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

          
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style30 {
            width: 100%;
            height: 480px;
        }
        .auto-style31 {
            width: 10%;
        }
        .auto-style32 {
            text-align: center;
            background-color: #FFFFFF;
        }
        .auto-style33 {
            width: 10%;
            background-color: #FFFFFF;
        }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

           
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1205px" Width="100%">
                    <br />
                    
                                <table class="auto-style30">
                                    <tr>
                                        <td class="auto-style31">
                                            &nbsp;</td>
                                        <td>
                                            <div class="auto-style9">
                                                <CR:CrystalReportViewer ID="CRV_ReporteProsede" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="700px" ReportSourceID="CRS_ReporteProsede" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="400px" />
                                            </div>
                                            <CR:CrystalReportSource ID="CRS_ReporteProsede" runat="server">
                                                <Report FileName="~/Reportes/ReporteProsede.rpt">
                                                </Report>
                                            </CR:CrystalReportSource>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style33">&nbsp;</td>
                                        <td class="auto-style32">
                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="120px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/Consultas.aspx" />
                                        </td>
                                    </tr>
                                </table>
                        
                </asp:Panel>
          
   
    
</asp:Content>

