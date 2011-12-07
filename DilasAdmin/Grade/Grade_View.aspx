<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Grade_View.aspx.cs" Inherits="Grade_View" %>

<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">

<h1>班級維護-<asp:Label ID="AllName" runat="server" Text="Label"></asp:Label></h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="Grade" Fun1TabName="設定學生"
            Fun1TabURL="Student" Fun2TabName="設定老師" Fun2TabURL="Teacher" Fun3TabName="授課科目"
            Fun3TabURL="CourseSubject" Fun4TabName="預設課表" Fun4TabURL="DefaultTimeTable" isOpenEditTab="False"
            isOpenFun1Tab="False" isOpenFun2Tab="False" isOpenFun3Tab="False" isOpenFun4Tab="False" />

<div class="from_table">
<table>
<tr>
<th width="18%"> 學校名稱</th>
<td><asp:Label ID="schoolName" runat="server"></asp:Label></td>
</tr>
<tr>
<th>班級名稱</th>
<td><asp:Label ID="GradeName" runat="server"></asp:Label></td>
</tr>
<tr>
<th>註冊年份</th>
<td><asp:Label ID="enrollYear" runat="server"></asp:Label></td>
</tr>
<tr>
<th>狀　　態</th>
<td> <asp:Label ID="enable" runat="server"></asp:Label></td>
</tr>
<tr>
<th>班級人數</th>
<td><asp:Label ID="GradeStudentCount" runat="server"></asp:Label></td>
</tr>
<tr>
<th>說　　明</th>
<td><asp:Label ID="description" runat="server"></asp:Label></td>
</tr>
<tr>
<th>建立時間</th>
<td><asp:Label ID="initDate" runat="server"></asp:Label></td>
</tr>

</table>
</div>


  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
