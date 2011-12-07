<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="_BookCase_Grade.aspx.cs" Inherits="DilasUser_BookCase_BookCase_Grade" %>

<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_Bookcase"></div>
  <div class="admin_middlebg">
  <div class="container">

 <div id="admin_menu">
        <uc2:PublishTab ID="PublishTab1" runat="server" tab="3" FunctionName="BookCase" isOpenEditTab="True"
            Fun1TabName="所屬班級" Fun1TabURL="Grade" isOpenFun1Tab="True" />
<div class="from_table">
<table>
<tr>
<th width="18%">所屬班級</th>
<td><asp:Label ID="Label1" runat="server" AssociatedControlID="grade_id">授課班級:</asp:Label><asp:DropDownList
                    ID="grade_id" runat="server">
                </asp:DropDownList></td>
</tr>
<tr>
<th> <asp:Label ID="Label4" runat="server" AssociatedControlID="cblTab">預設書籤</asp:Label></th>
<td><asp:Panel ID="pnlGrade" runat="server" Visible="True">
               
                <asp:CheckBoxList ID="cblTab" runat="server" RepeatColumns="5" RepeatLayout="Flow">
                </asp:CheckBoxList>
            </asp:Panel></td>
</tr>
</table>
</div>
<div class="footer_button" style="margin: 0 0 10px 0"> <asp:Button CssClass="btn_small" ID="InsertButton" runat="server" Text="確定" OnClick="InsertButton_Click">
                </asp:Button>
                <input type="button" class="btn_small" value="回上頁" onclick="location='BookCase_List.aspx'" />
                </div>
<div class="data_table">
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="id" ForeColor="#333333" GridLines="None" Width="80%" 
                onrowdeleting="GridView1_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
               
                    <asp:BoundField DataField="gradeName" HeaderText="班 級"  />
                    <asp:BoundField DataField="subject" HeaderText="預設書籤" />
                    <asp:TemplateField HeaderText="刪除">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="delete" ImageUrl="~/images/color_1_41.gif"
                                CssClass="action" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
               
            </asp:GridView>
</div>


       </div>
      
</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
   
</asp:Content>
