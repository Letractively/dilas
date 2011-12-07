<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Parent_Edit.aspx.cs" Inherits="Parent_Edit" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%= Page.ResolveUrl(@"~/js/twzipcode-1.3.1.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            
            $('.zipcode').twzipcode({
                zipSel: $('#hidzip').val(),
                zipReadonly: false
            });
            $(".datepicker input").datepicker({ defaultDate: "-25y" });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>家長維護-<asp:Label ID="ParentName" runat="server" Text="Label"></asp:Label></h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="2" FunctionName="Parent" 
            isOpenEditTab="True" isOpenFun1Tab="True" Fun1TabName="在校子女" Fun1TabURL="Children" />
<div class="from_table">
<asp:HiddenField ID="hidzip" runat="server" ClientIDMode="Static" />
<table>
<tr>
<th width="18%">個人圖片</th>
<td> 
        <asp:image id="myPhoto" runat="server" /></td>
</tr>
<tr>
<th> <asp:Label ID="lblusername" runat="server" AssociatedControlID="username">帳　　號</asp:Label></th>
<td><asp:Label ID="username" runat="server"></asp:Label></td>
</tr>
<tr>
<th> <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">密　　碼</asp:Label></th>
<td>  <asp:TextBox
                ID="password" runat="server" Width="250px" ClientIDMode="Static" TextMode="Password"></asp:TextBox>（密碼已經加密，若不修改請勿填寫。）
        </td>
</tr>
<tr>
<th> <asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">聯絡E-mail</asp:Label></th>
<td><asp:TextBox
                ID="emailAddress" runat="server" Width="250px" CssClass="{validate:{required:true, email:true, messages:{required:'聯絡E-mail必填', email:'請檢查E-mail 格式是否正確'}}}"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lblname" runat="server" AssociatedControlID="name">家長姓名</asp:Label></th>
<td> <asp:TextBox
                ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'姓名必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="Label3" runat="server" AssociatedControlID="enable">狀　　態</asp:Label></th>
<td> <asp:DropDownList
                ID="enable" runat="server">
                <asp:ListItem Value="True">啟用</asp:ListItem>
                <asp:ListItem Value="False">停用</asp:ListItem>
            </asp:DropDownList></td>
</tr>
<tr>
<th><asp:Label ID="lblbirthday" runat="server" AssociatedControlID="birthday">生　　日</asp:Label></th>
<td class="datepicker"><asp:TextBox
                ID="birthday" runat="server" Width="250px" CssClass="{validate:{required:true,date:true, messages:{required:'出生日期必填',date:'日期格式有誤'}}}"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lblgender" runat="server" AssociatedControlID="gender">性　　別</asp:Label></th>
<td>  <asp:DropDownList
                ID="gender" runat="server">
                <asp:ListItem Value="True">男</asp:ListItem>
                <asp:ListItem Value="False">女</asp:ListItem>
            </asp:DropDownList></td>
</tr>
<tr>
<th> <asp:Label ID="Label1" runat="server" AssociatedControlID="occupation">職　　業</asp:Label></th>
<td>    <asp:TextBox  ID="occupation" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'職業必填'}}}"></asp:TextBox>
      </td>
</tr>
<tr>
<th> <asp:Label ID="lbltelephone_id" runat="server" AssociatedControlID="numberCode">電　　話</asp:Label></th>
<td>   <input type="text" id="areaCode" style="width: 30px" value="" runat="server" />
            <input type="text" id="numberCode" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'電話必填'}}}" />
       </td>
</tr>
<tr>
<th> <asp:Label ID="lbladdress_id" runat="server" AssociatedControlID="address">地　　址</asp:Label></th>
<td><span class="zipcode"></span>
            <input type="text" id="address" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'地址必填'}}}" />
       </td>
</tr>
<tr>
<th> <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">備　　註</asp:Label></th>
<td> <asp:TextBox ID="description" runat="server" Width="400px" Height="160px" TextMode="MultiLine"></asp:TextBox></td>
</tr>


</table>
</div>

<div class="footer_button">
     <asp:Button CssClass="btn_small" ID="InsertButton" runat="server" Text="確定修改" OnClick="InsertButton_Click">
            </asp:Button> <input class="btn_small" type="button" value="回列表頁" onclick="location='Teacher_List.aspx'" />
<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>


</div>
  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>

