<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="BookCase_Tabs.aspx.cs" Inherits="DilasUser_BookCase_BookCase_Tabs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery.tablednd.0.5.js") %>"></script>
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
    <style type="text/css">
        .action
        {
             cursor:pointer;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_Bookcase"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>新增書籤</h1>
<div class="h2_padding">
 新增書籤:<asp:TextBox ID="subject" runat="server"></asp:TextBox>
 <asp:Button ID="btnAdd" runat="server" Text="確定" CssClass="btn_small" OnClick="btnAdd_Click" />
</div>



<div class="data_table">
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="id" CssClass="tableStyle1" GridLines="None"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
            CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="名稱">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSubject" runat="server" Text='<%# Bind("subject") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("subject") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="原始排序" SortExpression="className">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("listNum") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="新排序">
                    <ItemTemplate>
                        <asp:TextBox ID="listNum" runat="server" CssClass="position {validate:{required:true,number:true, messages:{required:'新排序必填',number:'須為數字'}}}"
                            Width="40px" Text='<%# Eval("listNum") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                         <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/images/color_1_40.gif"
                            CommandName="edit" CssClass="action" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ibtnUpdate" runat="server" CommandName="update" 
                            ImageUrl="~/images/color_1_48.gif" CssClass="action" />
                        <asp:ImageButton ID="ibtnCancel" runat="server" CommandName="cancel" 
                            ImageUrl="~/images/color_1_49.gif" CssClass="action" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="delete" 
                            ImageUrl="~/images/color_1_41.gif" CssClass="action" 
                            OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           
        </asp:GridView>
        <div style="margin:20px 0 0 0">
            <asp:Button ID="btnSure"  runat="server" Text="更新排序" CssClass="button btn_small" OnClick="btnSure_Click" />
            (請拖曳更改排序)
        </div>
</div>
<div class="footer_button">
            <input onclick="location='BookCase_List.aspx'" class="btn_small" type="button"
                value="回列表" />
</div>


</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>

 
</asp:Content>

