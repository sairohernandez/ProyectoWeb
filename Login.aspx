<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrograWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label_Username" runat="server" Text="Username"/>

                <br />

                <asp:TextBox ID="TextBox_Username" placeholder="Username" runat="server"/>

                <br />

                <asp:Label ID="Label_Password" runat="server" Text="Password"/>

                <br />

                <asp:TextBox ID="TextBox_Password" placeholder="Password" runat="server" TextMode="Password"/>

                <br />

                <asp:Button id="Submit" Onclick="Submit_Click" runat="server" Text="Login"/>

                <br />

                <asp:Label ID="Label_Error" runat="server" OnClick="Submit_Click" Text=""/>
        </div>
    </form>
</body>
</html>
