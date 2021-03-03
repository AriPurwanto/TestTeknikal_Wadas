<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WebApplication1.Menu_Form.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <div class="page-header">
                            <h3>TRANSAKSI</h3>
                        </div>
                        <div>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px"></td>
                                <td>
                                    <asp:Button ID="btnAddbarang" runat="server" Text="Generate Barang to Excel" Width="250px" CssClass="btn btn-md btn-default" OnClick="btnAddBarang_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px"></td>
                                <td>
                                    <asp:Button ID="btnAddPerusahaan" runat="server" Text="Generate Perusahaan to Excel" Width="250px" CssClass="btn btn-md btn-default" OnClick="btnAddPerus_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px"></td>
                                <td>
                                    <asp:Button ID="btnAddTransaksi" runat="server" Text="Generate Transaksi to Excel" Width="250px" CssClass="btn btn-md btn-default" OnClick="btnAddTrans_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <asp:Label ID="lblMessage" runat="server" Text="LabelMessage" ForeColor="Green"></asp:Label></center>
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
