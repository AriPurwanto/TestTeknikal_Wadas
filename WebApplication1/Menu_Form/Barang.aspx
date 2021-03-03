<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Barang.aspx.cs" Inherits="WebApplication1.Menu_Form.Barang" %>

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
                            <h3>BARANG</h3>
                        </div>
                        <div>
                        <table>
                            <tr>
                                <td style="left: 10px; width: 120px">Nama Barang :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:TextBox ID="textNamabarang" runat="server" Width="200px" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px">Qty :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:TextBox ID="textQty" Width="200px" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                           <tr>
                                <td style="left: 10px; width: 120px">Harga :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:TextBox ID="textharga" Width="200px" runat="server" CssClass="form-control"></asp:TextBox>
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
                                OnRowUpdating="GridResult_RowUpdating" AllowPaging="false" DataKeyNames="IdBarang"
                                CssClass="table table-bordered table-hover" AutoGenerateColumns="false" HeaderStyle-CssClass="gridHeaderAlignCenter">
                            <Columns>
                                <asp:TemplateField HeaderText="IdBarang" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdBarang" runat="server" Text='<%# Eval("IdBarang") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="NamaBarang" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNamaBarang" runat="server" Text='<%# Eval("Nama Barang") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNamaBarang" runat="server" Width="200px" Text='<%# Eval("Nama Barang") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtQty" runat="server" Width="200px" Text='<%# Eval("Qty") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Harga" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHarga" runat="server" Text='<%# Eval("Harga") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHarga" runat="server" Width="200px" Text='<%# Eval("Harga") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACTION" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" CommandName="Edit" CommandArgument='<%# Eval("IdBarang") %>'
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
