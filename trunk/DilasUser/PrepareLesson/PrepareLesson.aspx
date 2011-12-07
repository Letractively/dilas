<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="PrepareLesson.aspx.cs" Inherits="DilasUser_PrepareLesson_PrepareLesson" %>
<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
  <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="admin">
<div class="admin_bg ">
  <div class="admin_topbg admin_curriculum"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>備課資料-<asp:Label ID="lblCourseSubjectName" runat="server" Text="Label"></asp:Label>
   <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlDate_SelectedIndexChanged">
        </asp:DropDownList></h1>

<h2>備課事項</h2>
<div class="h2_padding">
 <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox> 
      <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="btn_small" onclick="btnAdd_Click" />
</div>
<div class="data_table">
 <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
          DataKeyNames="id" style="margin-top: 0px" CellPadding="4" 
          ForeColor="#333333" GridLines="None" onrowdeleting="gvItem_RowDeleting">
          <AlternatingRowStyle BackColor="White" />
          <Columns>
 <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                            ImageUrl="~/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                    
                </asp:TemplateField>
              <asp:BoundField DataField="subject" HeaderText="事項" SortExpression="subject" />
              
          </Columns>

          <EmptyDataTemplate>
              暫無資料！！
          </EmptyDataTemplate>

         
      </asp:GridView>
</div>
<h2>課程備註</h2>
<div class="h2_padding">
<asp:TextBox ID="description" runat="server" Height="200px" 
         TextMode="MultiLine" Width="400px" ClientIDMode="Static"></asp:TextBox>
     <asp:Button ID="btnDescriptionSave" runat="server" CssClass="btn_small" Text="儲存" 
         onclick="btnDescriptionSave_Click" />
</div>
<h2>重要事項</h2>
<div class="h2_padding">
<asp:TextBox ID="importantDescription" runat="server" Height="200px" 
         TextMode="MultiLine" Width="400px" ClientIDMode="Static"></asp:TextBox>
     <asp:Button ID="btnImportantDescriptionSave" runat="server" Text="儲存" 
        onclick="btnImportantDescriptionSave_Click" CssClass="btn_small" />
</div>

<h2>教科書</h2>
<div class="h2_padding">
書本名稱：<asp:TextBox ID="txtFileSubject1" runat="server"></asp:TextBox>
 <asp:FileUpload ID="FuFile1" runat="server" />
    <asp:Button ID="BtnUpFile1" runat="server"
          Text="上傳" CssClass="btn_small" onclick="BtnUpFile1_Click1" />

     
<input class="btn_small" style="display: none" id="joinStudent" type="button" value="加入書籍" onclick="tb_show('加入書籍','BookCase_Show.aspx?timetable_id=<%= Request["timetable_id"] %>&KeepThis=true&TB_iframe=true&height=500&width=650','thickbox')" />

</div>
<div class="data_table">
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
          CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" 
          style="margin-top: 0px">
          <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:BoundField DataField="subject" HeaderText="書籍" SortExpression="subject" />
              <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                  <ItemTemplate>
                      <asp:ImageButton ID="ibtnDelete0" runat="server" CommandName="Delete" 
                          CssClass="action" ImageUrl="~/images/Delete.gif" 
                          OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                  </ItemTemplate>
                  <HeaderStyle HorizontalAlign="Left" />
              </asp:TemplateField>
          </Columns>
         
      </asp:GridView>
</div>

<h2>老師教材</h2>
<div class="h2_padding">
 <asp:FileUpload ID="FuFile2" runat="server" /> 
    <asp:Button ID="BtnUpFile2" runat="server"
          Text="上傳" CssClass="btn_small" onclick="BtnUpFile2_Click" />
</div>
<div class="data_table">
  <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="id" ForeColor="#333333" GridLines="None" 
            style="margin-top: 0px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="subject" HeaderText="書籍" SortExpression="subject" />
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete1" runat="server" CommandName="Delete" 
                            CssClass="action" ImageUrl="~/images/Delete.gif" 
                            OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
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

