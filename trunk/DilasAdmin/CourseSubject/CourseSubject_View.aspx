<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="CourseSubject_View.aspx.cs" Inherits="CourseSubject_View" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


<div class="admin">
<div class="admin_bg">
<div class="admin_topbg"></div>
<div class="admin_middlebg">
<div class="container">
 
<h1>課程科目內容</h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="CourseSubject" />
  <asp:Button ID="btnEdit" runat="server" Text="編輯" OnClick="btnEdit_Click" Visible="False"/>

<div class="from_table">
<table>
<tr>
<th width="18%">科目名稱</th>
<td>   <asp:Label ID="name" runat="server"></asp:Label></td>
</tr>
<tr>
<th>適用年級</th>
<td> <asp:Label ID="fitGradeYear" runat="server"></asp:Label></td>
</tr>
<tr>
<th>學期狀態</th>
<td><asp:Label ID="semesterTerm" runat="server"></asp:Label></td>
</tr>
<tr>
<th>狀　　態</th>
<td><asp:Label ID="enable" runat="server"></asp:Label></td>
</tr>
<tr>
<th>建立時間</th>
<td> <asp:Label ID="initDate" runat="server"></asp:Label></td>
</tr>
<tr>
<th>說　　明</th>
<td><asp:Label ID="description" runat="server"></asp:Label></td>
</tr>

</table>
</div>
 
   
    
    
   
    
<div class="footer_button"><input type="button" value="回上頁" class="btn_small" onclick="location='CourseSubject_List.aspx'" /></div>
    

</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>

</asp:Content>
