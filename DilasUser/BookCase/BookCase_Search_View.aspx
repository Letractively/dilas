<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="BookCase_Search_View.aspx.cs" Inherits="DilasUser_BookCase_BookCase_Search_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="admin_menu">
        <fieldset>
            <legend>詳細內容</legend>
            <div style="display: inherit; text-align: left;">
                教材書籍名稱：<asp:Label ID="subject" runat="server"></asp:Label>
            </div>
            <div style="display: inherit; text-align: left;">
                <asp:Image ID="coverPicName" runat="server" Height="100px" ImageUrl="" />
            </div>
            <div style="display: inherit; text-align: left;">
                作者：<asp:Label ID="author" runat="server"></asp:Label>
            </div>
            <div style="display: inherit; text-align: left;">
                出版社：<asp:Label ID="publisher" runat="server"></asp:Label>
            </div>
            <div style="display: inherit; text-align: left;">
                出版日期：<asp:Label ID="publishDate" runat="server"></asp:Label>
            </div>
            <div style="display: inherit; text-align: left;">
                ISBN：<asp:Label ID="isbn" runat="server"></asp:Label>
            </div>
            <div style="display: inherit; text-align: left;">
            <asp:Label ID="lblType" runat="server" AssociatedControlID="type">類型：</asp:Label><asp:Label
                    ID="type" runat="server"></asp:Label>
            </div>
            <div style="display: inherit; text-align: left;">
            <asp:Label ID="lblPublicLevel" runat="server" AssociatedControlID="publicLevel">是否公開：</asp:Label><asp:Label
                    ID="publicLevel" runat="server"></asp:Label>
            </div>
            <div style="display: inherit; text-align: left;">
                詳細介紹：<asp:Label ID="description" runat="server"></asp:Label>
            </div>
            <div style="display: inherit; text-align: left;">
                <asp:LinkButton ID="lnkAddMyBookCase" runat="server" 
                    onclick="lnkAddMyBookCase_Click">加到我的書櫃</asp:LinkButton>
            </div>
        </fieldset>
    </div>
</asp:Content>

