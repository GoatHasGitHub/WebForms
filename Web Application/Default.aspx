<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Application.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <link rel="stylesheet" type="text/css" href="default.css" />
</head>
<body>
    <form runat="server">
        <div>
            <h2>Registration</h2>
            <!-- Add the error message label here -->
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" CssClass="error-message"></asp:Label>
        </div>
        <div>
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <label for="txtFullName">Full Name:</label>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            <br />
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <label for="txtRepeatPassword">Repeat Password:</label>
            <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Imate Account?"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        </div>
    </form>
</body>
</html>
