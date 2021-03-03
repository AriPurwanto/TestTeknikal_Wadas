<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Wadas</title>
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <style>
        .login-container {
            float: none;
            margin: 0 auto;
            margin-left: auto;
            margin-right: auto;
            width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login-container" style="margin-top: 15%">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title"><strong>Login</strong></h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label for="lblUsername">Username</label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword1">Password </label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                            </div>
                            <br />
                            <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-md btn-default" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                </div>
                <center><asp:Label ID="lblMessage" runat="server" Text="LabelMessage" ForeColor="Red"></asp:Label></center>
            </div>
        </div>
    </form>
</body>
</html>
