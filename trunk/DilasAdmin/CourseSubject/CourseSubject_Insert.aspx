<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="CourseSubject_Insert.aspx.cs" Inherits="CourseSubject_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
<div class="admin_topbg"></div>
<div class="admin_middlebg">
<div class="container">
 <h1>新增課程科目</h1>
<div class="from_table">
<table>
<tr>
<th width="18%"> <asp:Label ID="lblfitGradeYear" runat="server" AssociatedControlID="fitGradeYear">適用年級</asp:Label>
           </th>
<td><asp:DropDownList ID="fitGradeYear" runat="server">
                <asp:ListItem Value="1">1年級</asp:ListItem>
                <asp:ListItem Value="2">2年級</asp:ListItem>
                <asp:ListItem Value="3">3年級</asp:ListItem>
                <asp:ListItem Value="4">4年級</asp:ListItem>
                <asp:ListItem Value="5">5年級</asp:ListItem>
                <asp:ListItem Value="6">6年級</asp:ListItem>
            </asp:DropDownList></td>
</tr>
<tr>
<th><asp:Label ID="lblsemesterTerm" runat="server" AssociatedControlID="semesterTerm">學期類型</asp:Label>
           </th>
<td>   <asp:DropDownList ID="semesterTerm" runat="server">
                <asp:ListItem Value="0">上學期</asp:ListItem>
                <asp:ListItem Value="1">下學期</asp:ListItem>
            </asp:DropDownList>     </td>
</tr>
<tr>
<th><asp:Label ID="lblname" runat="server" AssociatedControlID="name">科目名稱</asp:Label></th>
<td> <asp:TextBox
                ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'科目名稱必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說明</asp:Label></th>
<td><asp:TextBox
                ID="description" runat="server" Width="250px" Height="150px" TextMode="MultiLine"></asp:TextBox></td>
</tr>

</table>
</div>
<div class="footer_button">
 <asp:Button ID="InsertButton" runat="server" Text="新增" CssClass="btn_small" OnClick="InsertButton_Click">
            </asp:Button> <input type="button" value="回上頁" Class="btn_small" onclick="location='CourseSubject_List.aspx'" /></div>



</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
   
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
 
</asp:Content>
