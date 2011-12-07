<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="DilasUser_Grade_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery-1.6.3.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery.metadata.js") %>"></script>
     <link href="<%= Page.ResolveUrl(@"~/css/jquery_validate.css") %>" rel="stylesheet"
        type="text/css" />
 <link href="<%= Page.ResolveUrl(@"~/css/default.css") %>" rel="stylesheet"
        type="text/css" />
<style type="text/css">
html{background:none;}
div{margin:10px;}
</style>
</head>
<body>
    <form id="form1" runat="server">
   <div style="display: inherit; text-align: left;">
            <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">輸入密碼　</asp:Label><asp:TextBox
                ID="password" runat="server" Width="250px" ClientIDMode="Static" CssClass="{validate:{required:true, messages:{required:'密碼必填'}}}" TextMode="Password" ></asp:TextBox>
        </div>
        <div style="display: inherit; text-align: left;">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="cpassword" >確認密碼　</asp:Label><asp:TextBox
                ID="cpassword" CssClass="{validate:{required:true, equalTo:'#password', messages:{required:'密碼必填', equalTo:'密碼輸入不相同'}}}" runat="server" Width="250px" TextMode="Password" ></asp:TextBox>
        </div>
        <div style="text-align:center">
        <asp:Button ID="Button1" runat="server" Text="確定修改" onclick="Button1_Click" CssClass="btn_small" />
        </div>
    
    </form>
</body>
</html>
