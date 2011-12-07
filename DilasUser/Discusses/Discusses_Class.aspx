<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Discusses_Class.aspx.cs" Inherits="DilasUser_Discusses_Discusses_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg  admin_board"></div>
  <div class="admin_middlebg">
  <div class="container">


<h1>類別維護</h1>


<div class="search">
<table>
<tr>
<th width="14%">新增類別</th>
<td width="24%"><asp:TextBox ID="txtAdd" runat="server"></asp:TextBox></td>
<th width="16%"><asp:Button ID="btnAdd" runat="server" Text="確定" OnClick="btnAdd_Click" CssClass=" btn_small" /></th>
<td width="46%"></td>
  </tr>
  
</table>
<div class="search_btn"></div>
</div>

<div class="data_table">
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="id" CssClass="tableStyle1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
            CellPadding="4" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="名稱" SortExpression="className">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("className") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("className") %>'></asp:Label>
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
                <asp:CommandField HeaderText="編輯" ShowEditButton="True" />
                <asp:CommandField HeaderText="刪除" ShowDeleteButton="True" />
            </Columns>
           
        </asp:GridView>
</div>
<div class="footer_button">
 
            <input class="btn_small" onclick="location='Discusses_List.aspx?ModuleID=<%=Request["ModuleID"] %>&grade_id=<%=Request["grade_id"] %>'" type="button"
                value="回列表" />
</div>

</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>



  
</asp:Content>

