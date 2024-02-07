<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RadioStanice.aspx.cs" Inherits="Web_Application.RadioStanice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Radio Stanice
    </title>
</head>
<body>
     <form runat="server">
        <div>
            <h2>Radio</h2>
            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
            <div>
                <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
            <div class="gridview-container">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="delete-button" />
                    </Columns>
                    <HeaderStyle BackColor="#3498db" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
