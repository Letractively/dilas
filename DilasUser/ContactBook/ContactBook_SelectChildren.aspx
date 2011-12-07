<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="ContactBook_SelectChildren.aspx.cs" Inherits="DilasUser_ContactBook_ContactBook_SelectChildren" %>
<%@ Import Namespace="ExtensionMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_ContactBook"></div>
  <div class="admin_middlebg">
  <div class="container">
<style ="text/css">
.cont_student td{ padding:5px;}
</style>
<h1>選擇學生</h1>
  <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" >
        <ItemTemplate>
            <table width="100px" class="cont_student">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("gradeName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl='<%# ("M" + Eval("myPhoto")).ToString().ToScodeBookCaseURL(Eval("school_id").ToString(),Eval("id").ToString())  %>' NavigateUrl='<%# "ContactBook_ForParent.aspx?people_id=" + Eval("id") %>'></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>' ></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>


</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
  
</asp:Content>
