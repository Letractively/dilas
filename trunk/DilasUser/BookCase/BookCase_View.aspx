<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="BookCase_View.aspx.cs" Inherits="DilasUser_BookCase_BookCase_View" %>

<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_Bookcase"></div>
  <div class="admin_middlebg">
  <div class="container">
 <uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="BookCase" 
            isOpenEditTab="True" Fun1TabName="所屬班級" Fun1TabURL="Grade" 
            isOpenFun1Tab="False" />

<div class="from_table">

<table>
<tr>
<th>預覽圖片</th>
<td><asp:Image ID="coverPicName" runat="server" Height="100px" ImageUrl="" /></td>
</tr>
<tr>
<th width="18%">教材書籍</th>
<td><asp:Label ID="subject" runat="server"></asp:Label>
           </td>
</tr>
<tr>
<th>作　　者</th>
<td><asp:Label ID="author" runat="server"></asp:Label></td>
</tr>
<tr>
<th>出<span class="padd_1"></span>版<span class="padd_1"></span>社</th>
<td><asp:Label ID="publisher" runat="server"></asp:Label></td>
</tr>
<tr>
<th>出版日期</th>
<td><asp:Label ID="publishDate" runat="server"></asp:Label></td>
</tr>
<tr>
<th>I<span class="padd_2"></span>S<span class="padd_2"></span>B<span class="padd_2"></span>N</th>
<td><asp:Label ID="isbn" runat="server"></asp:Label></td>
</tr>
<tr>
<th><asp:Label ID="lblType" runat="server" AssociatedControlID="type">類　　型</asp:Label></th>
<td><asp:Label
                    ID="type" runat="server"></asp:Label></td>
</tr>
<tr>
<th> <asp:Label ID="lblPublicLevel" runat="server" AssociatedControlID="publicLevel">是否公開</asp:Label></th>
<td><asp:Label
                    ID="publicLevel" runat="server"></asp:Label></td>
</tr>
<tr>
<th>詳細介紹</th>
<td><asp:Label ID="description" runat="server"></asp:Label></td>
</tr>
<tr>
<th>下　　載</th>
<td><asp:HyperLink ID="hlFileName" Target="_blank" runat="server">點我下載</asp:HyperLink></td>
</table>
</div>
<div style="text-align:center">

</div>

<div class="footer_button">
           
            </asp:Button> <input type="button" class="btn_small" value="回列表" onclick="location='BookCase_List.aspx'" /></div>
        <div>
  
</div>
</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
  
</asp:Content>
