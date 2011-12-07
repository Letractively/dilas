<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplateMessage_Insert.aspx.cs"
    Inherits="DilasUser_ContactBook_TemplateMessage_Insert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <h1>
            新增聯絡事項</h1>
        <div>
            <asp:TextBox ID="messages" runat="server" Height="150px" TextMode="MultiLine" 
                Width="250px"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="確定新增" onclick="Button1_Click" />
        </div>
    </div>
    </form>
</body>
</html>
