<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="_Grade_Teacher.aspx.cs" Inherits="DilasAdmin_Grade_Grade_Teacher" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>
<%@ Import Namespace="ExtensionMethods" %>

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

<h1>班級維護-<asp:Label ID="AllName" runat="server" Text="Label"></asp:Label></h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="4" FunctionName="Grade" Fun1TabName="設定學生"
            Fun1TabURL="Student" Fun2TabName="設定老師" Fun2TabURL="Teacher" Fun3TabName="授課科目"
            Fun3TabURL="CourseSubject" Fun4TabName="預設課表" Fun4TabURL="DefaultTimeTable" isOpenEditTab="False"
            isOpenFun1Tab="True" isOpenFun2Tab="True" isOpenFun3Tab="True" isOpenFun4Tab="True" />
<div class="tab_control">
 <asp:Panel ID="addPan" runat="server" Visible="False">
            <input class="btn_small" id="Button1" type="button" value="設定授課老師" onclick="tb_show('設定授課老師','_Grade_Teacher_Show.aspx?GradeId=<%= Request["id"] %>&KeepThis=true&TB_iframe=true&height=500&width=650','thickbox')" />
       </asp:Panel> 
</div>


<div class="data_table">
 <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" DataKeyNames="id" Width="100%" 
            onrowdeleting="gvList_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="等級" SortExpression="rank">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("rank").ToString().ToScodeRankName() %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="教師姓名" SortExpression="name" />
                 <asp:TemplateField HeaderText="教師類型" >
                 <ItemTemplate>
                     <asp:DropDownList ID="ddlClassify" runat="server" 
                         SelectedValue='<%# Eval("classify") %>'>
                        <asp:ListItem Value="0">級任老師</asp:ListItem>
                    <asp:ListItem Value="1">專任老師</asp:ListItem>
                     </asp:DropDownList>
                 </ItemTemplate>
             </asp:TemplateField>
                <asp:TemplateField HeaderText="性別" SortExpression="gender">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("gender").ToString().ToScodeGenderName()  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                            ImageUrl="~/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
          
        </asp:GridView>
</div>

<div class="footer_button">

 <asp:Button CssClass="btn_small" ID="btnSure" runat="server" Text="設定完成" OnClick="btnSure_Click" Visible="False"/>

</div>



  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
