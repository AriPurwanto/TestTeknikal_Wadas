<%@ Page Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboards.aspx.cs" Inherits="WebApplication1.Menu_Form.Dashboards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
        <div>
            <script src="Scripts/fusioncharts.js"></script>
            <script src="Scripts/fusioncharts.charts.js"></script>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <div class="page-header">
                            <h3>Dashboards</h3>
                        </div>
                    </div>
                </ContentTemplate>
             </asp:UpdatePanel>
         </div>
</asp:Content>
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>
