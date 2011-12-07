<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="_Grade_CourseSubject.aspx.cs" Inherits="DilasAdmin_Grade_Grade_CourseSubject" %>

<%@ Import Namespace="ExtensionMethods" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">

 <h1>班級維護-<asp:Label ID="AllName" runat="server" Text="Label"></asp:Label></h1>
 <uc2:PublishTab ID="PublishTab1" runat="server" tab="5" FunctionName="Grade" Fun1TabName="設定學生"
            Fun1TabURL="Student" Fun2TabName="設定老師" Fun2TabURL="Teacher" Fun3TabName="授課科目"
            Fun3TabURL="CourseSubject" Fun4TabName="預設課表" Fun4TabURL="DefaultTimeTable" isOpenEditTab="False"
            isOpenFun1Tab="True" isOpenFun2Tab="True" isOpenFun3Tab="True" isOpenFun4Tab="True" />
            
授課老師：<asp:DropDownList ID="ddlTeacher" runat="server">
            </asp:DropDownList>
            授課科目：<asp:DropDownList ID="ddlCourseSubject" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnAdd" runat="server" Text="加入課程" OnClick="btnAdd_Click" />
   <asp:Panel ID="addPan" runat="server">
       
  qweqwe
        </asp:Panel> 
<div class="data_table">
 <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="id" ForeColor="#333333" GridLines="None" Width="100%" OnRowDeleting="gvList_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="教師類型" SortExpression="classify">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("classify").ToString().ToScodeClassifyName() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="教師姓名" SortExpression="name" />
                    <asp:TemplateField HeaderText="性別" SortExpression="gender">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("gender").ToString().ToScodeGenderName()  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="等級" SortExpression="rank">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("rank").ToString().ToScodeRankName() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="fitGradeYear" HeaderText="適用年級" SortExpression="fitGradeYear" />
                    <asp:TemplateField HeaderText="學期類型" SortExpression="semesterTerm">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("semesterTerm").ToString().ToScodeSemesterTermName() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CourseName" HeaderText="科目名稱" SortExpression="CourseName" />
                    
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

  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
