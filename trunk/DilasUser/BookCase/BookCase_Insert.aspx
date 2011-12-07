<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="BookCase_Insert.aspx.cs" Inherits="DilasUser_BookCase_BookCase_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script src="<%= Page.ResolveUrl(@"~/js/twzipcode-1.3.1.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $(".datepicker input").datepicker();
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_Bookcase"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>新增書籍</h1>
<div class="from_table">
<table>
<tr>
<th width="18%">書籍/教材名稱</th>
<td><asp:TextBox
                ID="subject" runat="server" Width="250px" class="{validate:{required:true, messages:{required:'書籍/教材名稱必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="Label1" runat="server" AssociatedControlID="tab_id">書　　籤</asp:Label></th>
<td><asp:DropDownList
                ID="tab_id" runat="server">
            </asp:DropDownList></td>
</tr>
<tr>
<th> <asp:Label ID="Label2" runat="server" AssociatedControlID="type">類　　型</asp:Label></th>
<td> <asp:DropDownList
                ID="type" runat="server"><asp:ListItem Value="0">免費</asp:ListItem>
            </asp:DropDownList></td>
</tr>
<tr>
<th> <asp:Label ID="Label3" runat="server" AssociatedControlID="publicLevel">是否公開</asp:Label></th>
<td> <asp:DropDownList ID="publicLevel" runat="server">
                <asp:ListItem Value="0">不公開</asp:ListItem>
                <asp:ListItem Value="2">公開</asp:ListItem>
            </asp:DropDownList></td>
</tr>
<tr>
<th>  <asp:Label ID="lblfileName" runat="server" AssociatedControlID="fuFile">上傳檔案</asp:Label></th>
<td> <asp:FileUpload ID="fuFile" runat="server" /></td>
</tr>
<tr>
<th>   <asp:Label ID="lblcoverPicName" runat="server" AssociatedControlID="fuPic">封面圖片</asp:Label></th>
<td>  <asp:FileUpload ID="fuPic" runat="server" /></td>
</tr>
<tr>
<th> <asp:Label ID="Label4" runat="server" AssociatedControlID="cblGrade">所屬班級</asp:Label></th>
<td> <asp:CheckBoxList ID="cblGrade" runat="server" RepeatColumns="5" 
                RepeatLayout="Flow">
            </asp:CheckBoxList></td>
</tr>
<tr>
<th>  <asp:Label ID="lblauthor" runat="server" AssociatedControlID="author">作　　者</asp:Label></th>
<td><asp:TextBox
                ID="author" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lblpublisher" runat="server" AssociatedControlID="publisher">出版社</asp:Label></th>
<td><asp:TextBox
                ID="publisher" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th class="datepicker">  <asp:Label ID="lblpublishDate" runat="server" AssociatedControlID="publishDate">出版日期</asp:Label></th>
<td><asp:TextBox
                ID="publishDate" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>  <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說　　明</asp:Label></th>
<td><asp:TextBox
                ID="description" runat="server" Width="250px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="lblisbn" runat="server" AssociatedControlID="isbn">ISBN</asp:Label></th>
<td><asp:TextBox
                ID="isbn" runat="server" Width="250px"></asp:TextBox></td>
</tr>
</table>
</div>

<asp:Panel ID="pnlGrade" runat="server" Visible="false">
           
           
        </asp:Panel>

<div class="footer_button"> <asp:Button ID="InsertButton" CssClass="btn_small" runat="server" Text="新增" OnClick="InsertButton_Click">
            　</asp:Button> <input type="button" class="btn_small" value="回上頁" onclick="location='BookCase_List.aspx'" /></div>


     <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
  
</asp:Content>
