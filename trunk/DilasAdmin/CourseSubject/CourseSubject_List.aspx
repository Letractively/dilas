<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="CourseSubject_List.aspx.cs" Inherits="CourseSubject_List" %>
<%@ Import Namespace="ExtensionMethods" %>
<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
 
<h1>課程管理</h1>
<div class="top_control">  <input class="btn_small" type="button" onclick="location='CourseSubject_Insert.aspx'" value="新增科目" runat="server" id="btnAdd" Visible="false" />
  </div>
<div class="search">
<table class="search_table">
<tr>
<th width="14%">  狀　　態</th>
<td width="24%"><asp:DropDownList ID="ddlEnable" runat="server">
            <asp:ListItem Value="-1">請選擇</asp:ListItem>
            <asp:ListItem Value="True">啟用</asp:ListItem>
            <asp:ListItem Value="False">停用</asp:ListItem>
        </asp:DropDownList></td>
<th width="16%">科目名稱</th>
<td width="46%"><asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
  </tr>
<table class="search_table">
<tr>
<th width="14%"> 適用年級</th>
<td width="24%"> <asp:DropDownList ID="ddlFitGradeYear" runat="server">
            <asp:ListItem Value="-1">請選擇</asp:ListItem>
            <asp:ListItem Value="1">1年級</asp:ListItem>
            <asp:ListItem Value="2">2年級</asp:ListItem>
            <asp:ListItem Value="3">3年級</asp:ListItem>
            <asp:ListItem Value="4">4年級</asp:ListItem>
            <asp:ListItem Value="5">5年級</asp:ListItem>
            <asp:ListItem Value="6">6年級</asp:ListItem>
        </asp:DropDownList></td>
<th width="16%">學期類型</th>
<td width="46%">  <asp:DropDownList ID="ddlSemesterTerm" runat="server">
            <asp:ListItem Value="-1">請選擇</asp:ListItem>
            <asp:ListItem Value="0">上學期</asp:ListItem>
            <asp:ListItem Value="1">下學期</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
 <tr style="display:none">
<th width="14%"><asp:Label ID="lblSchool" runat="server" Text="學　　校"/>　</th>
<td width="24%"><asp:DropDownList ID="ddlSchool" runat="server"> </asp:DropDownList></td>
<th width="16%"></th>
<td width="46%"></td>
  </tr>
 
</table>
<div class="search_btn">
  <asp:Button ID="Button1" runat="server" Text="搜尋" CssClass="btn_small" OnClick="Button1_Click" />
        <asp:Button ID="btnReset" runat="server" CssClass="btn_small" OnClick="btnReset_Click" Text="取消搜尋" />
</div>
</div>
<div class="data_table">
<asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" 
            onrowupdating="gvList_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:BoundField DataField="schoolName" HeaderText="學校" />
                <asp:BoundField DataField="name" HeaderText="課程名稱" SortExpression="name" />
                <asp:BoundField DataField="fitGradeYear" HeaderText="適用年級" SortExpression="fitGradeYear" />
             <asp:TemplateField HeaderText="學期類型">
                          <ItemTemplate>
                              <asp:Label ID="lblsemesterTerm" runat="server"
                                  Text='<%# Eval("semesterTerm").ToString().ToScodeSemesterTermName()  %>'></asp:Label>
                          </ItemTemplate>
                         
                          <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="狀態">
                          <ItemTemplate>
                              <asp:Label ID="Label1" runat="server" CssClass="dis"
                                  Text='<%# Eval("enable").ToString().ToScodeEnableName()  %>'></asp:Label>
                          </ItemTemplate>
                         
                          <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="檢視">
                    <ItemTemplate>
                
                        <asp:ImageButton ID="ibtnView" runat="server" AlternateText="檢視" 
                            CommandName="Update" ImageUrl="~/images/Modify.gif" />
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
