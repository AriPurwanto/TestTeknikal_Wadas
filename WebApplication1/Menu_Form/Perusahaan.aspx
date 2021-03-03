<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perusahaan.aspx.cs" Inherits="WebApplication1.Menu_Form.Perusahaan" %>

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
                            <h3>PERUSAHAAN</h3>
                        </div>
                        <div>
                        <table>
                            <tr>
                                <td style="left: 10px; width: 120px">Nama Perusahaan :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:TextBox ID="textNamaPerusahaan" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px">Alamat :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:TextBox ID="textAlamat" Width="500px" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px"></td>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" CssClass="btn btn-md btn-default" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </div>
                        <div class="table-responsive">
                        <asp:GridView ID="GridResult" runat="server" OnRowCancelingEdit="GridResult_RowCancelingEdit" OnRowEditing="GridResult_RowEditing"
                                OnRowUpdating="GridResult_RowUpdating" AllowPaging="false" DataKeyNames="IdPerusahaan"
                                CssClass="table table-bordered table-hover" AutoGenerateColumns="false" HeaderStyle-CssClass="gridHeaderAlignCenter">
                            <Columns>
                                <asp:TemplateField HeaderText="IdPerusahaan" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdPerusahaan" runat="server" Text='<%# Eval("IdPerusahaan") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="NamaPerusahaan" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNamaPerusahaan" runat="server" Text='<%# Eval("Nama Perusahaan") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNamaPerusahaan" runat="server" Width="200px" Text='<%# Eval("Nama Perusahaan") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Alamat" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAlamat" runat="server" Text='<%# Eval("Alamat") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAlamat" runat="server" Width="500px" Text='<%# Eval("Alamat") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACTION" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" CommandName="Edit" CommandArgument='<%# Eval("IdPerusahaan") %>'
                                                runat="server" Text="Edit" CssClass="btn btn-info" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update"
                                                CommandName="Update" CssClass="btn btn-info" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                                CommandName="Cancel" CssClass="btn btn-info" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
