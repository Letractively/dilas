<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Student_List.aspx.cs" Inherits="Student_List" %>
<%@ Import Namespace="ExtensionMethods" %>
<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">


<h1>學生管理</h1>
<div class="top_control"> <input type="button" onclick="location='Student_Insert.aspx'" value="新增學生" runat="server" id="btnAdd" visible="false" Class="btn_small"/></div>
<div class="search">
<table class="search_table">
  <tr>
    <th>學　　號</th>
    <td><asp:TextBox ID="txtSearchNumber" runat="server" CssClass="keyWord"></asp:TextBox></td>
     
    <th>姓　　名</th>
    <td><asp:TextBox ID="txtSearch" runat="server" CssClass="keyWord"></asp:TextBox></td>
    
    
    </td>
  </tr>
  <th>年　　級</th>
    <td><asp:DropDownList
               ID="ddlCurrentYear" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlCurrentYear_SelectedIndexChanged">
                    <asp:ListItem Value="-1">請選擇</asp:ListItem>
                    <asp:ListItem Value="1">1年級</asp:ListItem>
                    <asp:ListItem Value="2">2年級</asp:ListItem>
                    <asp:ListItem Value="3">3年級</asp:ListItem>
                    <asp:ListItem Value="4">4年級</asp:ListItem>
                    <asp:ListItem Value="5">5年級</asp:ListItem>
                    <asp:ListItem Value="6">6年級</asp:ListItem>
           </asp:DropDownList>
  
   <th>班　　級</th>
    <td><asp:DropDownList ID="ddlGrade" runat="server" DataTextField="name" 
                DataValueField="id">
            </asp:DropDownList>
  </tr>
  <tr>
    <th>狀　　態</th>
    <td><asp:DropDownList
               ID="ddlEnable" runat="server">
                    <asp:ListItem Value="-1">請選擇</asp:ListItem>
                    <asp:ListItem Value="True">啟用</asp:ListItem>
                    <asp:ListItem Value="False">停用</asp:ListItem>
           </asp:DropDownList></td>
    <th>性　　別</th>
    <td><asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Value="-1">請選擇</asp:ListItem>
                <asp:ListItem Value="False">男</asp:ListItem>
                <asp:ListItem Value="True">女</asp:ListItem>
            </asp:DropDownList></td>
  </tr>
  <tr>
    <th><asp:Label ID="lblSchool" runat="server" Text="學　　校"></asp:Label></th>
    <td><asp:DropDownList ID="ddlSchool" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlSchool_SelectedIndexChanged">
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
<asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            GridLines="None" CellPadding="4" ForeColor="#333333" OnRowDeleting="GridView1_RowDeleting"
            Width="100%" OnRowUpdating="gvList_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="schoolName" HeaderText="學校">
                  
                </asp:BoundField>
                
                <asp:BoundField DataField="gradeName" HeaderText="班級">
                  
                </asp:BoundField>
                 <asp:BoundField DataField="studentNumber" HeaderText="學號" SortExpression="name">
                    
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name">
                    
                </asp:BoundField>
                <asp:BoundField DataField="birthday" DataFormatString="{0:d}" HeaderText="生日" SortExpression="birthday">
                    
                </asp:BoundField>
                <asp:TemplateField HeaderText="姓別" SortExpression="gender">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("gender").ToString().ToScodeGenderName()  %>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="狀態" SortExpression="enable">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("enable").ToString().ToScodeEnableName()  %>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="建立日期" SortExpression="initDate">
                    
                </asp:BoundField>
                <asp:TemplateField HeaderText="檢視">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" CommandName="Update"
                            ImageUrl="~/images/Modify.gif" />
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                            ImageUrl="~/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                    
                </asp:TemplateField>
            </Columns>
           
           
      </asp:GridView>
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>


</div>

</div>
<div class="admin_bottombg"></div>
</div>
</div>

</asp:Content>































