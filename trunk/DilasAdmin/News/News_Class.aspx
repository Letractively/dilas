<%@ Page Title="最新動態-類別維護" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="News_Class.aspx.cs" Inherits="manage_News_News_Class" %>

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
    <div id="admin_menu">
        <div>
            新增類別:<asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="確定" OnClick="btnAdd_Click" />
            <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button"
                value="回列表" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            EnableModelValidation="True" CssClass="tableStyle1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
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
        <div>
            <asp:Button ID="btnSure" runat="server" Text="更新排序" CssClass="button" OnClick="btnSure_Click" />
            (請拖曳更改排序)
        </div>
    </div>
</asp:Content>
