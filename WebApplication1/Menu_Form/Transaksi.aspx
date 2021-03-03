<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Transaksi.aspx.cs" Inherits="WebApplication1.Menu_Form.Transaksi" %>

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
                        <table>
                            <tr>
                                <td style="left: 10px; width: 120px">Id Perusahaan :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:Label ID="lblIdPerusahaan" Width="100px" runat="server" CssClass="form-control"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px">Nama Perusahaan :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:DropDownList ID="ddNamaPerusahaan" runat="server" Width="210px" OnSelectedIndexChanged="ddNamaPerusahaan_SelectedIndexChanged" ></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px">Alamat :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:Label ID="lblAlamat" Width="500px" runat="server" CssClass="form-control"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px">Id Barang :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:Label ID="lblIdBarang" Width="100px" runat="server" CssClass="form-control"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px">Nama Barang :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:DropDownList ID="ddNamaBarang" runat="server" Width="210px"></asp:DropDownList>
                                </td>
                            </tr>
                           <tr>
                                <td style="left: 10px; width: 120px">Qty :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:Label ID="lblQty" Width="200px" runat="server" CssClass="form-control"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="left: 10px; width: 120px">Harga :</td>
                                <td style="left: 60px; width: 30px">
                                    <asp:Label ID="lblHarga" Width="200px" runat="server" CssClass="form-control"></asp:Label>
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
                                OnRowUpdating="GridResult_RowUpdating" AllowPaging="false" DataKeyNames="IdTransaksi"
                                CssClass="table table-bordered table-hover" AutoGenerateColumns="false" HeaderStyle-CssClass="gridHeaderAlignCenter">
                            <Columns>
                                <asp:TemplateField HeaderText="IdTransaksi" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdTransaksi" runat="server" Text='<%# Eval("IdBarang") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdPerusahaan" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdPerusahaan" runat="server" Text='<%# Eval("IdPerusahaan") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl2IdPerusahaan" runat="server" Width="200px" Text='<%# Eval("IdPerusahaan") %>'></asp:Label>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nama Perusahaan" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNamaPerusahaan" runat="server" Text='<%# Eval("NamaPerusahaan") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddNamaPerusahaan2" runat="server" Width="210px"></asp:DropDownList>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Idbarang" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdBarang" runat="server" Text='<%# Eval("IdBarang") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl2IdBarang" runat="server" Width="200px" Text='<%# Eval("IdBarang") %>'></asp:Label>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nama Barang" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNamaBarang" runat="server" Text='<%# Eval("NamaBarang") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddNamaBarang2" runat="server" Width="210px"></asp:DropDownList>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl2Qty" runat="server" Width="200px" Text='<%# Eval("Qty") %>'></asp:Label>
                                        </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Harga" HeaderStyle-Width="180px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHarga" runat="server" Text='<%# Eval("Harga") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl2Harga" runat="server" Width="200px" Text='<%# Eval("Harga") %>'></asp:Label>
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
