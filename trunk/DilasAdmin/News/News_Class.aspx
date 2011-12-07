<%@ Page Title="�̷s�ʺA-���O���@" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
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
            �s�W���O:<asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="�T�w" OnClick="btnAdd_Click" />
            <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button"
                value="�^�C��" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            EnableModelValidation="True" CssClass="tableStyle1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="�W��" SortExpression="className">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("className") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("className") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��l�Ƨ�" SortExpression="className">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("listNum") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�s�Ƨ�">
                    <ItemTemplate>
                        <asp:TextBox ID="listNum" runat="server" CssClass="position {validate:{required:true,number:true, messages:{required:'�s�Ƨǥ���',number:'�����Ʀr'}}}"
                            Width="40px" Text='<%# Eval("listNum") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="�s��" ShowEditButton="True" />
                <asp:CommandField HeaderText="�R��" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <div>
            <asp:Button ID="btnSure" runat="server" Text="��s�Ƨ�" CssClass="button" OnClick="btnSure_Click" />
            (�Щ즲���Ƨ�)
        </div>
    </div>
</asp:Content>
