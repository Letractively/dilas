<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Person_DataEdit.aspx.cs" Inherits="DilasUser_Person_Person_DataEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="<%= Page.ResolveUrl(@"~/js/twzipcode-1.3.1.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.zipcode').twzipcode({
                zipSel: $('#hidzip').val(),
                zipReadonly: false
            });
            $(".datepicker input").datepicker({ defaultDate: "-10y" });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="admin">
<div class="admin_bg">
<div class="admin_topbg"></div>
<div class="admin_middlebg">
<div class="container">
 <h1>維護個人資料</h1>
<span style="display:none"> <asp:Image ID="myPhoto" runat="server" /></span>
 <asp:HiddenField ID="hidzip" runat="server" ClientIDMode="Static" />
<div class="from_table">
<table>
<tr>
<th width="18%"><asp:Label ID="lblusername" runat="server" AssociatedControlID="username">帳　　號</asp:Label></th>
<td> <asp:Label ID="username" runat="server"></asp:Label></td>
</tr>
<tr>
<th> <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">修改密碼</asp:Label></th>
<td> <asp:TextBox
                ID="password" runat="server" Width="250px" ClientIDMode="Static" TextMode="Password"></asp:TextBox>（密碼經加密，若不修改請勿填寫。）
        </td>
</tr>
<tr>
<th> <asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">聯絡E-mail</asp:Label></th>
<td><asp:TextBox
                ID="emailAddress" runat="server" Width="250px" CssClass="{validate:{required:true, email:true, messages:{required:'聯絡E-mail必填', email:'請檢查E-mail 格式是否正確'}}}"></asp:TextBox></div>
       </td>
</tr>
<tr>
<th> <asp:Label ID="lblname" runat="server" AssociatedControlID="name">姓　　名</asp:Label></th>
<td> <asp:TextBox
                ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'姓名必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="lblbirthday" runat="server" AssociatedControlID="birthday">生　　日</asp:Label></th>
<td>        <asp:TextBox
                ID="birthday" runat="server" Width="250px" CssClass="{validate:{required:true,date:true, messages:{required:'出生日期必填',date:'日期格式有誤'}}}"></asp:TextBox></td>
</tr>
<tr>
<th>  <asp:Label ID="lblgender" runat="server" AssociatedControlID="gender">性　　別</asp:Label></th>
<td><asp:DropDownList
                ID="gender" runat="server">
                <asp:ListItem Value="True">男</asp:ListItem>
                <asp:ListItem Value="False">女</asp:ListItem>
            </asp:DropDownList>
        </div></td>
</tr>
<tr>
<th><asp:Label ID="lbltelephone_id" runat="server" AssociatedControlID="numberCode">電　　話</asp:Label></th>
<td>  <input type="text" id="areaCode" style="width: 30px" value="" runat="server" />
            <input type="text" id="numberCode" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'電話必填'}}}" />
        </td>
</tr>
<tr>
<th>  <asp:Label ID="lbladdress_id" runat="server" AssociatedControlID="address">地　　址</asp:Label></th>
<td> <span class="zipcode"></span>
            <input type="text" id="address" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'地址必填'}}}" />
        </td>
</tr>
<tr>
<th>  <asp:Label ID="lblMyPhoto" runat="server" AssociatedControlID="fuMyPhoto">我的照片</asp:Label></th>
<td>  <asp:FileUpload ID="fuMyPhoto" runat="server" /></td>
</tr>
</table>
</div>
<div class="footer_button">   <asp:Button ID="InsertButton" CssClass="btn_small" runat="server" Text="確定修改" OnClick="InsertButton_Click">
            </asp:Button><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>


</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
<div id="admin_menu">
    <fieldset>
       
</asp:Content>

