<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="SchoolNews_Detail.aspx.cs" Inherits="DilasUser_SchoolNews_SchoolNews_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  
<div class="bulletin">
<!--內容欄 開始 -->
<div class="bulletin_middle_in">
<div class="bulletin_middle_in_box">

<div class="bulletin_in_list">
<div class="bulletin_title"><asp:Label ID="title" runat="server"></asp:Label></div>
<div class="bulletin_time"><asp:Label ID="initDate" runat="server"></asp:Label></div>
<div class="bulletin_content"><asp:Literal ID="article" runat="server"></asp:Literal></div>

<div class="bulletin_download">
 <asp:DataList ID="dlFiles" runat="server" RepeatColumns="2" 
        RepeatDirection="Horizontal">
    <ItemTemplate>
    <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# My.WebForm.ConverInsideLink(Eval("fileUrl"), "~/UploadFiles/Files/",false) %>' Text='<%# Eval("fileName") %>' Target="_blank"></asp:HyperLink>
    </ItemTemplate>
    </asp:DataList>
</div>
<div class="footer_button"><input type="button" value="回上頁" class="btn_small" onclick="location='SchoolNews_List.aspx?ModuleID=B01'"></div>
</div>



</div> 
</div>
<!--內容欄 結束 -->
<div class="bulletin_top"></div>
<div class="bulletin_middle"></div>
<div class="bulletin_bottom"></div>
</div>

<div class="clear"></div>
</div>
<!--右方內容結束 -->


</asp:Content>

