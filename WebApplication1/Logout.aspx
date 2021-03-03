<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="WebApplication1.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout Wadas</title>
    <link href="Content/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
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
       <div style="text-align: center">
            You are already logout, click <a href="Login.aspx">here</a> to login.
       </div>
    </form>
</body>
</html>
