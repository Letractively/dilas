<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="DilasUser_Person_ForgetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>忘記密碼</title>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery-1.6.3.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery.metadata.js") %>"></script>
<link href="<%= Page.ResolveUrl(@"~/css/default.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/css/jquery_validate.css") %>" rel="stylesheet"
        type="text/css" />
         <script type="text/javascript">
             $(document).ready(function () {
                 $("form").validate({ meta: "validate" });
             });
        
  
    </script>
</head>
<body>
    <form id="form1" runat="server">

<div class="wrap">

<!-- 表頭 開始 -->
<div class="header">

</div>
<!-- 表頭 結束 -->

<!--主內容 開始 -->
<div class="content ">

<!--右方內容 開始 -->
<div class="main password">
<div class="login_logo">
<a href="http://222.157.252.206/dilas" style="display:block; height:97px;width:112px;"></a>
</div>


<h2 style="position:absolute; top:360px; left:450px; font-weight:bold ; font-size:26px">忘記密碼</h2>
    <div style="position:absolute; top:400px; left:355px; ">
    請輸入帳號：<asp:TextBox ID="txtAccount" runat="server" CssClass="{validate:{required:true, messages:{required:'帳號必填'}}}"></asp:TextBox>
    </div>
    <div  style="position:absolute; top:430px; left:342px; ">
    請輸入E-mail：<asp:TextBox ID="txtEmail" runat="server" CssClass="{validate:{required:true, email:true, messages:{required:'聯絡E-mail必填', email:'請檢查E-mail 格式是否正確'}}}"></asp:TextBox>
    </div>
    <div style="position:absolute; top:450px; left:415px; ">
        <asp:Button CssClass="outt" style="border:none;" ID="btnSend" runat="server" Text="" onclick="btnSend_Click" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" ></asp:Label>
    </div>
    <div style="position:absolute; top:550px; left:325px; ">
     填妥資料送出去後，系統將會寄送新密碼到註冊的信箱，<br />
請用新密碼登入，再修改密碼。
    </div>


<div class="login_footer">
<p>
邁世通科技  /　服務熱線﹝07﹞955-5858  /  <a href="mailto:service@myerstone.com.tw">客服信箱</a></p>

</div>

</div>
<!--右方內容結束 -->

<div class="clear"></div>

</div>
<!--主內容 結束 -->


</div>
    
    </form>
</body>
</html>
