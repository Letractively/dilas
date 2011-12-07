<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="CourseSubject_Edit.aspx.cs" Inherits="CourseSubject_Edit" %>

<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
<div class="admin_topbg"></div>
<div class="admin_middlebg">
<div class="container">
 
<h1>編輯課程科目</h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="2" FunctionName="CourseSubject"
            isOpenEditTab="True" />
  

<div class="from_table">
<table>
<tr>
<th>   <asp:Label ID="lblname" runat="server" AssociatedControlID="name">科目名稱</asp:Label></th>
<td> <asp:TextBox
                    ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'科目名稱必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="lblfitGradeYear" runat="server" AssociatedControlID="fitGradeYear">適用年級</asp:Label></th>
<td>  <asp:DropDownList ID="fitGradeYear" runat="server">
                    <asp:ListItem Value="1">1年級</asp:ListItem>
                    <asp:ListItem Value="2">2年級</asp:ListItem>
                    <asp:ListItem Value="3">3年級</asp:ListItem>
                    <asp:ListItem Value="4">4年級</asp:ListItem>
                    <asp:ListItem Value="5">5年級</asp:ListItem>
                    <asp:ListItem Value="6">6年級</asp:ListItem>
                </asp:DropDownList></td>
</tr>
</tr>
<tr>
<th> <asp:Label ID="lblsemesterTerm" runat="server" AssociatedControlID="semesterTerm">學期類型</asp:Label></th>
<td><asp:DropDownList ID="semesterTerm" runat="server">
                    <asp:ListItem Value="0">上學期</asp:ListItem>
                    <asp:ListItem Value="1">下學期</asp:ListItem>
                </asp:DropDownList></td>
</tr>
</tr>

</tr>
<tr>
<th> <asp:Label ID="Label3" runat="server" AssociatedControlID="enable">狀態</asp:Label></th>
<td><asp:DropDownList
                    ID="enable" runat="server">
                    <asp:ListItem Value="True">啟用</asp:ListItem>
                    <asp:ListItem Value="False">停用</asp:ListItem>
                </asp:DropDownList></td>
</tr>
</tr>
<tr>
<th> <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說明</asp:Label>
               </th>
<td> <asp:TextBox ID="description" runat="server" Width="250px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
</tr>


</table>
</div>
 
   
    
    
   
    
<div class="footer_button">
  <asp:Button ID="UpdateButton" runat="server" CssClass="btn_small" Text="更新" OnClick="UpdateButton_Click">
                </asp:Button>　<input type="button" CssClass="btn_small" class="btn_small" value="回上頁" onclick="location=''" />
</div>
    

</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
    
</asp:Content>
