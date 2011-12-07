<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Grade_List.aspx.cs" Inherits="Grade_List" %>

<%@ Import Namespace="ExtensionMethods" %>
<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../UserControl/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".dis").each(function () {
                if ($(this).text() == "停用") {
                    $(this).css("color", "red");
                }
            });

        });     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">




<h1>班級管理</h1>
<div class="top_control"> <input type="button" onclick="location='Grade_Insert.aspx'" value="新增班級" runat="server" id="btnAdd" visible="false" Class="btn_small"/></div>
<div class="search">
<table class="search_table">
  <tr>
    <th>註冊年份</th>
    <td><asp:DropDownList ID="ddlEnrollYear" runat="server">
        </asp:DropDownList></td>
    
    
    
    <th>關<span class="padd_1"></span>鍵<span class="padd_1"></span>字</th>
    <td><asp:TextBox ID="txtSearch" runat="server" CssClass="keyWord">
        </asp:TextBox></td>
  </tr>
  <tr>
    <th>狀　　態</th>
    <td><asp:DropDownList ID="ddlEnable" runat="server">
            <asp:ListItem Value="-1">請選擇</asp:ListItem>
            <asp:ListItem Value="True">啟用</asp:ListItem>
            <asp:ListItem Value="False">停用</asp:ListItem>
        </asp:DropDownList></td>
    <th>年　　級</th>
    <td><asp:DropDownList ID="ddlCurrentYear" runat="server">
            <asp:ListItem Value="-1">請選擇</asp:ListItem>
            <asp:ListItem Value="1">1年級</asp:ListItem>
            <asp:ListItem Value="2">2年級</asp:ListItem>
            <asp:ListItem Value="3">3年級</asp:ListItem>
            <asp:ListItem Value="4">4年級</asp:ListItem>
            <asp:ListItem Value="5">5年級</asp:ListItem>
            <asp:ListItem Value="6">6年級</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
  
   <th><asp:Label ID="lblSchool" runat="server" Text="學　　校" /></th>
    <td><asp:DropDownList ID="ddlSchool"
            runat="server">
        </asp:DropDownList></td>
  
  
    
    <th colspan="2">&nbsp;</th>
    </tr>
</table>

<div class="search_btn">

<asp:Button ID="Button1" runat="server" Text="搜尋" OnClick="Button1_Click" CssClass="btn_small"/>

<asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="取消搜尋" CssClass="btn_small" />

</div>
</div>

<div class="data_table">
 <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" OnRowUpdating="gvList_RowUpdating" Width="100%"
                DataKeyNames="id">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="schoolName" HeaderText="學校" />
                    <asp:BoundField DataField="currentYear" HeaderText="年級" SortExpression="currentYear" />
                    <asp:BoundField DataField="GradeName" HeaderText="班級" SortExpression="name" />
                    <asp:BoundField DataField="enrollYear" HeaderText="註冊年份" SortExpression="enrollYear" />
                    <asp:BoundField DataField="GradeStudentCount" HeaderText="學生人數" />
                    <asp:TemplateField HeaderText="狀態">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" CssClass="dis" Text='<%# SCode.ToScodeEnableName(Eval("enable").ToString())  %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="檢視">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnView" runat="server" AlternateText="檢視" CommandName="Update"
                                ImageUrl="~/images/Modify.gif" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                </Columns>
              
            </asp:GridView>
 <uc1:Pagination ID="Pagination1" runat="server" />
</div>
























































            

     

  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
