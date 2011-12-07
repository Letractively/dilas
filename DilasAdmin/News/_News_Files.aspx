<%@ Page Title="最新動態-附加檔案" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="_News_Files.aspx.cs" Inherits="manage_News_News_Files" %>

<%@ Register src="~/UserControl/PublishTab1.ascx" tagname="PublishTab" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery.tablednd.0.5.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/css/jquery_validate.css") %>"
        rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>" rel="stylesheet"
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
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">
<uc2:PublishTab ID="PublishTab1" runat="server" tab="2" FunctionName="News" isOpenEditTab="false" isCloseFileTab="false" isCloseImageTab="true" isCloseLinkTab="true" />
     
        <p style="margin:10px 0;">
  <a style="text-decoration:underline" href="<%=String.Format("_News_Files_Insert.aspx?publishID={0}&ModuleID={1}&KeepThis=true&TB_iframe=true&height=400&width=600", Request["ID"], Request["ModuleID"]) %>" title="新增附加檔案" class="a_btn thickbox" >新增附加檔案</a>
      

       
        </p>
     
        <asp:GridView width="100%" CssClass="data_table" ID="gvList" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" ForeColor="#333333" onrowdatabound="gvList_RowDataBound" onrowdeleting="gvList_RowDeleting">
            <AlternatingRowStyle BackColor="White"  />
            <Columns>
                <asp:BoundField DataField="fileName" HeaderText="檔案說明" 
                    SortExpression="fileName" />
                <asp:TemplateField HeaderText="檔案" SortExpression="fileUrl">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# My.WebForm.ConverInsideLink(Eval("fileUrl"), "~/UploadFiles/Files/",false) %>' Text='<%# Eval("fileName") %>' Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fileUrl") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
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
           
        </asp:GridView>  
        <div class="footer_button" style="margin-top:20px;">
         
 <asp:Button ID="btnSure" runat="server" Text="更新排序" CssClass="button btn_small" 
                onclick="btnSure_Click" style="display:none" />
        <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>'" type="button" value="回列表" class="button btn_small" />
        
        </div>

</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>

</asp:Content>

