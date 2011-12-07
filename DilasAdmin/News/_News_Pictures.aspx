<%@ Page Title="�̷s�ʺA-���[�Ϥ�" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="_News_Pictures.aspx.cs" Inherits="manage_News_News_Pictures" %>

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
 <uc2:PublishTab ID="PublishTab1" runat="server" tab="4"  FunctionName="News" />
 <fieldset>
        <legend>���[�Ϥ����@</legend>
        <p>
        <a href="<%=String.Format("_News_Pictures_Insert.aspx?publishID={0}&ModuleID={1}&KeepThis=true&TB_iframe=true&height=400&width=600", Request["ID"].ToString(), Request["ModuleID"]) %>" title="�s�W���[�Ϥ�" class="thickbox" >�s�W���[�Ϥ�</a>
        </p>
        (�Щ즲�ۭq����)
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="id" ForeColor="#333333" 
            onrowdatabound="gvList_RowDataBound" onrowdeleting="gvList_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="�Ϥ�" SortExpression="fileUrl">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%#  My.WebForm.ConverInsideLink(Eval("picUrl"),"~/UploadFiles/Images/",false)  %>'  Target="_blank">
                             <asp:Image ID="Image1" runat="server" ImageUrl='<%# My.WebForm.ConverInsideLink(Eval("picUrl"),"~/UploadFiles/Images/s",false) %>' AlternateText='<%# Eval("picName") %>' />
                            </asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fileUrl") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��l�Ƨ�" SortExpression="listNum">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("listNum") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("listNum") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�s�Ƨ�">
                    <ItemTemplate>
                        <asp:TextBox ID="listNum" runat="server" CssClass="position {validate:{required:true,number:true, messages:{required:'�s�Ƨǥ���',number:'�����Ʀr'}}}" Width="40px" 
                            Text='<%# Eval("listNum") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�s��">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEdit" runat="server" CssClass="thickbox" title="�s����[�s��" >�s��</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" HeaderText="�R��" />
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
        <asp:Button ID="btnSure" runat="server" Text="��s�Ƨ�" CssClass="button" 
                onclick="btnSure_Click" />
            <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>'" type="button" value="�^�C��" class="button" />
            
            </div>
    </fieldset>
    </div>
</asp:Content>

