<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Grade_Edit.aspx.cs" Inherits="Grade_Edit" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            
            $('.currentYear').change(function () {
                var year = (new Date()).getFullYear();
                year = year - $('.currentYear').find("option:selected").val();
                if ((new Date()).getMonth() > 8) year++;
                $('.enrollYear').val(year);
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
<h1>班級維護-<asp:Label ID="AllName" runat="server" Text="Label"></asp:Label></h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="2" FunctionName="Grade" 
         Fun1TabName="設定學生" Fun1TabURL="Student" Fun2TabName="設定老師" Fun2TabURL="Teacher" 
         Fun3TabName="授課科目" Fun3TabURL="CourseSubject" Fun4TabName="預設課表" 
         Fun4TabURL="DefaultTimeTable" isOpenEditTab="False" isOpenFun1Tab="False" 
         isOpenFun2Tab="False" isOpenFun3Tab="False" isOpenFun4Tab="False" />

<div class="from_table">
<table>
<tr>
<th width="18%"><asp:Label ID="lblschool_id" runat="server" AssociatedControlID="schoolName">學校名稱</asp:Label></th>
<td> <asp:Label ID="schoolName" runat="server"></asp:Label></td>
</tr>
<tr>
<th> <asp:Label ID="lblname" runat="server" AssociatedControlID="name">班級名稱</asp:Label></th>
<td> <asp:TextBox
                    ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'班級名稱必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="Label1" runat="server" AssociatedControlID="currentYear">年　　級</asp:Label></th>
<td> <asp:DropDownList ID="currentYear" runat="server" CssClass="currentYear">
                    <asp:ListItem Value="1">1年級</asp:ListItem>
                    <asp:ListItem Value="2">2年級</asp:ListItem>
                    <asp:ListItem Value="3">3年級</asp:ListItem>
                    <asp:ListItem Value="4">4年級</asp:ListItem>
                    <asp:ListItem Value="5">5年級</asp:ListItem>
                    <asp:ListItem Value="6">6年級</asp:ListItem>
                </asp:DropDownList></td>
</tr>
<tr>
<th> <asp:Label ID="lblenrollYear" runat="server" AssociatedControlID="enrollYear">註冊年份</asp:Label></th>
<td>  <asp:TextBox
                    ID="enrollYear" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'註冊年份必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="Label3" runat="server" AssociatedControlID="enable">狀　　態</asp:Label></th>
<td>  <asp:DropDownList
                    ID="enable" runat="server">
                    <asp:ListItem Value="True">啟用</asp:ListItem>
                    <asp:ListItem Value="False">停用</asp:ListItem>
                </asp:DropDownList></td>
</tr>
<tr>
<th><asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說　　明</asp:Label></th>
<td> <asp:TextBox
                    ID="description" runat="server" Width="250px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
</tr>


</table>
</div>

<div class="footer_button">
<asp:Button ID="UpdateButton" runat="server" Text="更新" CssClass="btn_small" OnClick="UpdateButton_Click">
                </asp:Button> <input class="btn_small" type="button" value="回上頁" onclick="javascript:history.back();" />



</div>



  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
