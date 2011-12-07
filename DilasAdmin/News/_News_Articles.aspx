<%@ Page ValidateRequest="false" Title="�̷s�ʺA-���e�s��" Language="C#" MasterPageFile="~/Layout.master"
    AutoEventWireup="true" CodeFile="_News_Articles.aspx.cs" Inherits="manage_News_News_Articles" %>

<%@ Register Src="../../UserControl/PublishTab1.ascx" TagName="PublishTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/webEditor/ckeditor/ckeditor.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/single_seventeen.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" })
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="admin_menu">
        <uc2:PublishTab ID="PublishTab1" runat="server" tab="2" FunctionName="News" />
        <fieldset>
            <legend>�ԲӤ��e�s��</legend>
            <div>
                <asp:TextBox ID="article" runat="server" CssClass="ckeditor {validate:{required:true, messages:{required:'���e����'}}}"
                    TextMode="MultiLine"></asp:TextBox></div>
            <div>
                <asp:Button ID="btnSure" runat="server" Text="�T�w" OnClick="btnSure_Click" CssClass="button" />
                <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>'"
                    type="button" value="�^�C��" class="button" />
            </div>
        </fieldset>
    </div>
</asp:Content>
