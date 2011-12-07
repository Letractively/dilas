<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="_Grade_Student.aspx.cs" Inherits="DilasAdmin_Grade_Grade_Student" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>
<%@ Import Namespace="ExtensionMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
  <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>"
        rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>班級維護-<asp:Label ID="AllName" runat="server" Text="Label"></asp:Label></h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="3" FunctionName="Grade" 
         Fun1TabName="設定學生" Fun1TabURL="Student" Fun2TabName="設定老師" Fun2TabURL="Teacher" 
         Fun3TabName="授課科目" Fun3TabURL="CourseSubject" Fun4TabName="預設課表" 
         Fun4TabURL="DefaultTimeTable" isOpenEditTab="False" isOpenFun1Tab="True" 
         isOpenFun2Tab="True" isOpenFun3Tab="True" isOpenFun4Tab="True" />
<div style="text-align:right;margin:0 0 15px 0;">
 <asp:Panel ID="addPan" runat="server" Visible="False">
<input id="joinStudent" class="btn_small" type="button" value="加入學生" onclick="tb_show('加入學生','_Grade_Student_Show.aspx?GradeId=<%= Request["id"] %>&KeepThis=true&TB_iframe=true&height=500&width=650','thickbox')" />
        <input id="addStudent" class="btn_small" type="button" value="新增學生" onclick="tb_show('新增學生','_Grade_Student_Insert.aspx?GradeId=<%= Request["id"] %>&KeepThis=true&TB_iframe=true&height=500&width=650','thickbox')"/>
     </asp:Panel>
 
</div>

<div class="data_table">
<asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
         CellPadding="4"  ForeColor="#333333" 
         GridLines="None" DataKeyNames="id" onrowdeleting="gvList_RowDeleting" 
         Width="100%">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="studentNumber" HeaderText="學號" 
                 SortExpression="studentNumber" />
                 
             
             <asp:BoundField DataField="name" HeaderText="學生姓名" SortExpression="name" />
             <asp:TemplateField HeaderText="性別">
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%#  Eval("gender").ToString().ToScodeGenderName() %>'></asp:Label>
                 </ItemTemplate>
                
             </asp:TemplateField>
             <asp:TemplateField HeaderText="座號" SortExpression="seatNumber">
                 <ItemTemplate>
                     <asp:TextBox ID="txtSeatNumber" runat="server" Text='<%# Eval("seatNumber") %>'></asp:TextBox>
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
<asp:Button CssClass="btn_small" ID="btnSure" runat="server" Text="修改座號" onclick="btnSure_Click" Visible="False"/>



</div>





  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>

