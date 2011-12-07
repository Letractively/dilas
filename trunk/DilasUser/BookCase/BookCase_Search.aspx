<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="BookCase_Search.aspx.cs" Inherits="DilasUser_BookCase_BookCase_Search" %>
<%@ Import Namespace="ExtensionMethods" %>
<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_Bookcase"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>搜尋書籍</h1>
<div class="h2_padding">
搜尋書櫃<asp:RadioButtonList ID="rblPublicLevel" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" 
        onselectedindexchanged="rblPublicLevel_SelectedIndexChanged">
    <asp:ListItem Value="1" Selected="True">班級書櫃</asp:ListItem>
    <asp:ListItem Value="2">學校書櫃</asp:ListItem>
    <asp:ListItem Value="3">公開書櫃</asp:ListItem>
    </asp:RadioButtonList>
</div>

<div class="h2_padding">
 <asp:Label ID="lblGrade" runat="server" Text="班　　級"></asp:Label><asp:DropDownList ID="ddlGrade"
        runat="server">
    </asp:DropDownList>
</div>

<div class="h2_padding">
關鍵字<asp:TextBox ID="txtSearch" runat="server" CssClass="keyWord"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜尋"　CssClass="btn_small" OnClick="Button1_Click" />
</div>

<asp:DataList ID="dlBookCase" runat="server" RepeatColumns="5">
                            <ItemTemplate>
                                <div style="width: 100px; height:100px ">
                                <table>
                                <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "BookCase_Search_View.aspx?id=" + Eval("id") %>'> <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Eval("coverPicName").ToString().ToScodeBookCaseURL(Eval("school_id").ToString(),Eval("people_id").ToString()) %>' /></asp:HyperLink>
                                 
                                </td>
                                </tr>
                                 <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("subject") %>'></asp:Label>
                                </td>
                                </tr>
                                </table>
                                   
                                </div>

                            </ItemTemplate>
                        </asp:DataList>


<uc1:Pagination ID="Pagination1" runat="server" />



</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>





</asp:Content>

