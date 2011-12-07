<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Student_View.aspx.cs" Inherits="DilasAdmin_Student_Student_View" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>學生維護-<asp:Label ID="StudentName" runat="server" Text="Label"></asp:Label></h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="Student" 
            Fun1TabName="緊急聯絡人" Fun1TabURL="Parent" isOpenFun1Tab="True" />
<div class="from_table">
<table>
<tr>
<th width="18%"></th>
<td><asp:image id="myPhoto" runat="server" /></td>
</tr>
<tr>
<th><asp:Label ID="Label2" runat="server" AssociatedControlID="schoolName">學校名稱</asp:Label></th>
<td><asp:Label ID="schoolName" runat="server" Text="Label"></asp:Label></td>
</tr>
<tr>
<th>  <asp:Label ID="Label1" runat="server" AssociatedControlID="gradeName">班級名稱</asp:Label></th>
<td> <asp:Label ID="gradeName" runat="server" Text="Label"></asp:Label></td>
</tr>
<tr>
<th><asp:Label ID="lblusername" runat="server" AssociatedControlID="username">帳　　號</asp:Label></th>
<td><asp:Label ID="username" runat="server"></asp:Label></td>
</tr>
<tr>
<th><asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">聯絡E-mail</asp:Label></th>
<td> <asp:Label ID="emailAddress" runat="server"></asp:Label></td>
</tr>
<tr>
<th>  <asp:Label ID="lblname" runat="server" AssociatedControlID="name">姓　　名</asp:Label></th>
<td><asp:Label
                    ID="name" runat="server"></asp:Label></td>
</tr>
<tr>
<th><asp:Label ID="lblbirthday" runat="server" AssociatedControlID="birthday">生　　日</asp:Label></th>
<td class="datepicker"><asp:Label
                    ID="birthday" runat="server"></asp:Label></td>
</tr>
<tr>
<th><asp:Label ID="lblgender" runat="server" AssociatedControlID="gender">性　　別</asp:Label></th>
<td> <asp:Label
                    ID="gender" runat="server"></asp:Label></td>
</tr>
<tr>
<th> <asp:Label ID="Label3" runat="server" AssociatedControlID="studentNumber">學　　號</asp:Label></th>
<td>  <asp:Label ID="studentNumber" runat="server"></asp:Label></td>
</tr>
<tr>
<th> <asp:Label ID="Label5" runat="server" AssociatedControlID="seatNumber">座　　號</asp:Label></th>
<td> <asp:Label ID="seatNumber" runat="server"></asp:Label></td>
</tr>
<tr>
<th><asp:Label ID="lblenable" runat="server" AssociatedControlID="enable">狀　　態</asp:Label></th>
<td><asp:Label ID="enable" runat="server"></asp:Label></td>
</tr>
<tr>
<th> <asp:Label ID="lbltelephone_id" runat="server" AssociatedControlID="telephone_id">電　　話</asp:Label></th>
<td>  <asp:Label ID="telephone_id" runat="server"></asp:Label></td>
</tr>
<tr>
<th> <asp:Label ID="lbladdress_id" runat="server" AssociatedControlID="address_id">地　　址</asp:Label></th>
<td> <asp:Label ID="address_id" runat="server"></asp:Label></td>
</tr>
<tr>
<th>   <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說　　明</asp:Label></th>
<td> <asp:Label ID="description" runat="server"></asp:Label></td>
</tr>
</table>
</div>


<div class="footer_button">

  <input type="button" class="btn_small" value="回上頁" onclick="location='Student_List.aspx'" />


</div>




  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
