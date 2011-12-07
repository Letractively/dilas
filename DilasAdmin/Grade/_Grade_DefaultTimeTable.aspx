<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="_Grade_DefaultTimeTable.aspx.cs" Inherits="DilasAdmin_Grade_Grade_DefaultTimeTable" %>

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
 <div id="admin_menu">
        <uc2:PublishTab ID="PublishTab1" runat="server" tab="6" FunctionName="Grade" Fun1TabName="設定學生"
            Fun1TabURL="Student" Fun2TabName="設定老師" Fun2TabURL="Teacher" Fun3TabName="授課科目"
            Fun3TabURL="CourseSubject" Fun4TabName="預設課表" Fun4TabURL="DefaultTimeTable" isOpenEditTab="False"
            isOpenFun1Tab="True" isOpenFun2Tab="True" isOpenFun3Tab="True" isOpenFun4Tab="True" />
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" DataKeyField="id" OnItemDataBound="DataList1_ItemDataBound"
            OnEditCommand="DataList1_EditCommand" OnCancelCommand="DataList1_CancelCommand"
            OnUpdateCommand="DataList1_UpdateCommand" 
            ondeletecommand="DataList1_DeleteCommand">
            <ItemTemplate>
                <div style="width: 125px; height: 70px; border: 1px #ccc solid; padding: 1px">
                    <div>
                        <asp:Panel ID="addPan" runat="server" > <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/images/color_1_40.gif"
                            CommandName="edit" />
                        <asp:ImageButton ID="ibtnDelete" runat="server"  ImageUrl="~/images/color_1_41.gif"
                            CommandName="delete" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                        </asp:Panel>
                       
                    </div>
                    <div style="text-align: center">
                        <%# Eval("CourseSubjectName")%>
                    </div>
                    <div style="text-align: center">
                        <%# Eval("teacherName")%>
                    </div>
                    
                </div>
            </ItemTemplate>
            <EditItemTemplate>
                <div style="width: 150px; height: 70px; border: 1px #ccc solid; padding: 1px; background-color: #ccc;">
                    <div>
                        <asp:ImageButton ID="ibtnUpdate" runat="server" ImageUrl="~/images/color_1_48.gif"
                            CommandName="update" />
                        <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/images/color_1_49.gif"
                            CommandName="cancel" />
                    </div>
                    <div style="text-align: center">
                        <asp:DropDownList ID="ddlGradeCourseSubject" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </EditItemTemplate>
        </asp:DataList>
    </div>



  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
