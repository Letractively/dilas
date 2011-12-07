<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_Grade_Student_Insert.aspx.cs"
    Inherits="DilasAdmin_Grade_Grade_Student_Insert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="background:#fff;">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery-1.6.3.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/ui.datepicker.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/ui.datepicker-zh-TW.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/pagecode.js") %>"></script>
    <script src="<%= Page.ResolveUrl(@"~/js/twzipcode-1.3.1.js") %>" type="text/javascript"></script>
    <link href="<%= Page.ResolveUrl(@"~/css/default.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/css/jquery_validate.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/css/ui.core.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/css/ui.datepicker.css") %>" rel="stylesheet"
        type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/css/ui.theme.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/css/single_seventeen.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });


            $('.zipcode').twzipcode({
                zipSel: "800",
                zipReadonly: false
            });
            $(".datepicker input").datepicker({ defaultDate: "-10y" });
            $('#btnCheckAccount').click(function () {
                if ($("#username").val() == "") return;
                $.get('../../ashx/CheckAccount.ashx', { username: $("#username").val() }, function (data) {
                    if (data == "1") {
                        $("#checkmessage").text("帳號已經存在，請使用其他帳號名稱！");
                    } else {
                        $("#checkmessage").text("此帳號可以使用！");
                    }
                });

            });
        });
        
  
    </script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="from_table">
<table>
<tr>
<th width="18%"> <asp:Label ID="lblusername" runat="server" AssociatedControlID="username">帳　　號</asp:Label></th>
<td> <asp:TextBox
                    ID="username" runat="server" Width="250px" CssClass="{validate:{required:true, email:true, messages:{required:'帳號必填', email:'帳號格式須為E-mail格式'}}}"
                    ClientIDMode="Static"></asp:TextBox><input id="btnCheckAccount" type="button"  value="檢查帳號" /><span
                        id="checkmessage" style="color: red"></span></td>
</tr>
<tr>
<th>  <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">密　　碼</asp:Label></th>
<td> <asp:TextBox
                    ID="password" runat="server" Width="250px" ClientIDMode="Static" CssClass="{validate:{required:true, messages:{required:'密碼必填'}}}"
                    TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="Label3" runat="server" AssociatedControlID="txtPassword">確認密碼</asp:Label></th>
<td> <asp:TextBox
                    ID="txtPassword" runat="server" Width="250px" CssClass="{validate:{required:true, equalTo:'#password', messages:{required:'密碼必填', equalTo:'密碼輸入不相同'}}}"
                    TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">聯絡E-mail</asp:Label></th>
<td> <asp:TextBox
                    ID="emailAddress" runat="server" Width="250px" CssClass="{validate:{required:true, email:true, messages:{required:'聯絡E-mail必填', email:'請檢查E-mail 格式是否正確'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="lblname" runat="server" AssociatedControlID="name">姓　　名</asp:Label></th>
<td> <asp:TextBox
                    ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'姓名必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lblbirthday" runat="server" AssociatedControlID="birthday">生　　日</asp:Label></th>
<td  class="datepicker"> <asp:TextBox
                    ID="birthday" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>  <asp:Label ID="lblgender" runat="server" AssociatedControlID="gender">性　　別</asp:Label></th>
<td> <asp:DropDownList
                    ID="gender" runat="server">
                    <asp:ListItem Value="True">男</asp:ListItem>
                    <asp:ListItem Value="False">女</asp:ListItem>
                </asp:DropDownList></td>
</tr>
<tr>
<th> <asp:Label ID="lblstudentNumber" runat="server" AssociatedControlID="studentNumber">學　　號</asp:Label></th>
<td>  <asp:TextBox
                    ID="studentNumber" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'學號必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lbltelephone_id" runat="server" AssociatedControlID="numberCode">電　　話</asp:Label></th>
<td>  <input type="text" id="areaCode" style="width: 30px" value="" runat="server" />
                <input type="text" id="numberCode" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'電話必填'}}}" /></td>
</tr>
<tr>
<th> <asp:Label ID="lbladdress_id" runat="server" AssociatedControlID="address">地　　址</asp:Label></th>
<td> <span class="zipcode"></span>
                <input type="text" id="address" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'地址必填'}}}" /></td>
</tr>
<tr>
<th> <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說　　明</asp:Label></th>
<td>  <asp:TextBox ID="description" runat="server" Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox></td>
</tr>



</table>
</div>


<div class="footer_button">
 <asp:Button CssClass="btn_small" ID="InsertButton" runat="server" Text="新增" OnClick="InsertButton_Click">
                </asp:Button> <input class="btn_small" type="button" value="回上頁" onclick="parent.tb_remove();" />



</div>

    </form>
</body>
</html>
