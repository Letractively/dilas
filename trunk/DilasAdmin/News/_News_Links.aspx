<%@ Page Title="最新動態-附加連結" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="_News_Links.aspx.cs" Inherits="manage_News_News_Links" %>

<%@ Register src="../../UserControl/PublishTab1.ascx" tagname="PublishTab" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery-1.4.2.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.validate.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.metadata.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/thickbox.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/Sys/javascript/jquery.tablednd.0.5.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/single_seventeen.css") %>" rel="stylesheet"
        type="text/css" />
        <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/thickbox.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $("table").tableDnD({
                onDragClass: "showDragHandle",
                onDrop: function (table, row) {
                    var rows = table.tBodies[0].rows;
                    for (var i = 0; i < rows.length; i++) {
                        $(rows[i]).find(".position").val(i);
                    }
                }
            });
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="admin_menu">
 <uc2:PublishTab ID="PublishTab1" runat="server" tab="3" FunctionName="News" />
 <fieldset>
        <legend>附加連結維護</legend>
        <p><a href="<%=String.Format("_News_Links_Insert.aspx?publishID={0}&ModuleID={1}&KeepThis=true&TB_iframe=true&height=400&width=600", Request["ID"], Request["ModuleID"]) %>" title="新增附加連結" class="thickbox" >新增附加連結</a></p>
       (請拖曳自訂順序)
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="id" ForeColor="#333333" 
            onrowdatabound="gvList_RowDataBound" onrowdeleting="gvList_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="linkName" HeaderText="連結說明" 
                    SortExpression="linkName" />
                <asp:TemplateField HeaderText="連結網址" SortExpression="linkUrl">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# Bind("linkUrl") %>' Text='<%# Bind("linkUrl") %>' Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("linkUrl") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="linkTarget" HeaderText="開啟目標" 
                    SortExpression="linkTarget" />
                <asp:TemplateField HeaderText="原始排序" SortExpression="listNum">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("listNum") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("listNum") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="新排序">
                    <ItemTemplate>
                        <asp:TextBox ID="listNum" runat="server" CssClass="position {validate:{required:true,number:true, messages:{required:'新排序必填',number:'須為數字'}}}" Width="40px" 
                            Text='<%# Eval("listNum") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEdit" runat="server" CssClass="thickbox" title="編輯附加連結" >編輯</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" HeaderText="刪除" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                CssClass="nodrop nodrag" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            
        </asp:GridView>
        <div style="background-color:Green;color:White;font-weight:bold;margin-top:20px;">
            <asp:Button ID="btnSure" runat="server" Text="更新排序" CssClass="button" 
                onclick="btnSure_Click" />
            <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>'" type="button" value="回列表" class="button" />
            </div>
    </fieldset>
    </div>
</asp:Content>

