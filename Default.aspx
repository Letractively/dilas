<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>電子書包學習平台</title>
    <script src="js/jquery-1.6.3.min.js" type="text/javascript"></script>
    <script src="js/jquery.validate.js" type="text/javascript"></script>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery_validate.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript">
        //   $(document).ready(function () {
            //   $("#form1").validate({
              //     errorLabelContainer: $("#form1 div.cont")
             //  });
          // });
            
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
<div class="main login">
<div class="login_logo"></div>

<asp:TextBox ID="Username" runat="server" CssClass="required writing a1 login_a1" ></asp:TextBox>

<asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="required writing a1 login_a2"  ></asp:TextBox>
<asp:Button ID="btnLogin" runat="server" Text="" title="會員登入" onclick="btnLogin_Click" class="btn_login btn login_login" />
<a href="DilasUser/Person/ForgetPassword.aspx" class="login_forget"></a>

<div class="login_miss"></div>
<div class="login_bad"> <asp:Label ID="lblErrer" runat="server" ForeColor="Red"></asp:Label>
<div class="mgt_writing1"></div>
<div class="mgt_writing2"></div>
<div class="mgt_writing3"></div>
<div class="cont" style="display: none"><h4>你送出的資料有錯誤，請檢視下列訊息</h4>
	    <ol>
		<li><label for="Username" class="error"> 請輸入帳號</label></li>
	   	<li><label for="Password" class="error"> 請輸入密碼</label></li>
	    </ol>
    </div>
</div>


</div>
<div class="login_footer">
<p>
邁世通科技  /　服務熱線﹝07﹞955-5858  /  <a href="mailto:service@myerstone.com.tw">客服信箱</a>
</p>

</div>

</div>
<!--右方內容結束 -->

<div class="clear"></div>

</div>
<!--主內容 結束 -->


</div>



 
 



    



                       








</div>

</div>
                    
    </form>
</body>
</html>
