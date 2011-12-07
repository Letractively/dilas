<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="_Parent_Children.aspx.cs" Inherits="DilasAdmin_Parent_Parent_Children" %>
<%@ Import Namespace="ExtensionMethods" %>

<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">

<h1>家長維護-<asp:Label ID="ParentName" runat="server" Text="Label"></asp:Label></h1>
 <uc2:PublishTab ID="PublishTab1" runat="server" tab="3" FunctionName="Parent" Fun1TabName="在校子女"
            Fun1TabURL="Children" isOpenEditTab="True" isOpenFun1Tab="True" />


<div class="tab_control">
 <input id="Button3" class="btn_small" type="button" value="加入子女" onclick="tb_show('加入子女','_Parent_children_Show.aspx?ParentId=<%= Request["id"] %>&KeepThis=true&TB_iframe=true&height=500&width=650','thickbox')" />
        
</div>
<div class="data_table">
 <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            GridLines="None" CellPadding="4" ForeColor="#333333" Width="100%" 
            onrowdeleting="gvList_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="gradeName" HeaderText="班級">
                
                </asp:BoundField>
                 <asp:BoundField DataField="studentNumber" HeaderText="學號" SortExpression="studentNumber">
               
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="子女姓名" SortExpression="name">
               
                </asp:BoundField>
                <asp:TemplateField HeaderText="關係" SortExpression="relationship">
                 <ItemTemplate>
                     <asp:TextBox ID="txtRelationship" runat="server" Text='<%# Eval("relationship") %>'></asp:TextBox>
                 </ItemTemplate>
             </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                            ImageUrl="~/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </ItemTemplate>
           
                </asp:TemplateField>
            </Columns>
    
        </asp:GridView>
</div>

<div class="footer_button">
 <asp:Button CssClass="btn_small" ID="btnRelation" runat="server" Text="儲存關係" 
            onclick="btnRelation_Click" />



</div>

  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
