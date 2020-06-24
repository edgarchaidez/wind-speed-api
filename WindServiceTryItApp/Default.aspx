<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WindServiceTryItApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Wind Energy Service"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="Medium" Text="Enter latitude and longitude coordinates to get wind speed data from that location. (Make sure coordinates are correct)"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Medium" Text="Enter latitude:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="Medium" Text="Enter longitude:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Coordinates" Width="190px" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Medium" Text="Location:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="Medium" Text="Max Wind Speed:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="Medium" Text="Min Wind Speed:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="Medium" Text="Average Wind Speed:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
