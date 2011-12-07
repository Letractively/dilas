<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="School_View.aspx.cs" Inherits="School_View" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">

<h1>學校內容</h1>

    <uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="School" />
  

           
        
<div class="from_table">
<table>
<tr>
<th width="18%">編　　號</th>
<td><asp:label ID="id" runat="server"></asp:label></td>
</tr>
<tr>
<th>學校名稱</th>
<td><asp:label ID="name" runat="server"></asp:label></td>
</tr>
<tr>
<th>學校網址</th>
<td><asp:label ID="offcialUrl" runat="server"></asp:label></td>
</tr>
<tr>
<th>學校網域</th>
<td><asp:label ID="domainName" runat="server"></asp:label></td>
</tr>
<tr>
<th>狀　　態</th>
<td><asp:label ID="enable" runat="server"></asp:label></td>
</tr>
<tr>
<th>地　　址</th>
<td><asp:label ID="address_id" runat="server"></asp:label></td>
</tr>
<tr>
<th>電　　話</th>
<td><asp:label ID="telephone_id" runat="server"></asp:label></td>
</tr>
<tr>
<th>說　　明</th>
<td><asp:label ID="description" runat="server"></asp:label></td>
</tr>
<tr>
<th>建立時間</th>
<td>
<asp:label ID="initDate" runat="server"></asp:label></td>
</tr>
</table>
  </div>

  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>

