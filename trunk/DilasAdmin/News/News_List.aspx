<%@ Page  Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="News_List.aspx.cs" Inherits="manage_News_News_List" %>

<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%= Page.ResolveUrl(@"~/Sys/css_styles/components/thickbox.css") %>"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".selectall input").click(function () {
                $(".selectOne input").each(function () {
                    $(this).attr("checked", $(".selectall input").attr("checked"));
                });
            });

            $(".selectOne input").click(function () {
                $(".selectall input").attr("checked", false);
            });
        });

    </script>
    <style type="text/css">
        .tableStyle1 tr:hover td
        {
            background-color: #B8E4E4;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">

<h1>�Ǯդ��i</h1>
<div class="top_control"> 
 <input onclick="location='News_Insert.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button"
                value="�s�W�̷s�ʺA" class="Addbutton btn_small" />
            <input onclick="location='News_Class.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button"
                value="���O���@" class="Addbutton btn_small" style="display: none" />
</div>
<div class="search">
<table class="search_table " >
<tr>
<th width="14%">����r </th>
<td width="24%"> <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>

<th width="16%"> </th>
<td width="46%"> </td>
</tr>
<tr style="display:none">
<th width="14%">  <span style="display:inherit"><asp:Label ID="lblSchool" runat="server" Text="����:" /></span></th>
<td width="24%">  <asp:DropDownList ID="ddlSchool" runat="server" AutoPostBack="True">
                </asp:DropDownList> </td>

<th width="16%"> </th>
<td width="46%"> </td>
</tr>
</table>
<div class="search_btn">
<asp:Button ID="btnSearch" CssClass="btn_small" runat="server" Text="�j�M" OnClick="btnSearch_Click" />
            <asp:Button CssClass="btn_small" ID="btnReset" runat="server" OnClick="btnReset_Click" Text="���]" />
</div>
</div>

    <div id="admin_menu">
        <div>
           
            <div style="clear: both">
            </div>
        </div>
        <div>
           
              
            <span style="display: none">�п�ܵo�G�����G<asp:DropDownList ID="ddlClass1" runat="server"
                DataTextField="className" DataValueField="id">
            </asp:DropDownList>
            </span>
            
        </div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            Font-Size="14px" OnRowDataBound="gvList_RowDataBound" OnRowDeleting="gvList_RowDeleting"
            Width="100%" OnRowUpdating="gvList_RowUpdating"
            CssClass="tableStyle1 data_table" GridLines="None" CellPadding="4" 
            ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField Visible="False">
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBox2" CssClass="selectall" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="selectOne" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="OrgNames" HeaderText="���" SortExpression="OrgNames" Visible="False">
                </asp:BoundField>
                <asp:BoundField DataField="className" HeaderText="���O�W��" SortExpression="className"
                    Visible="False" />
                <asp:BoundField DataField="title" HeaderText="���D" SortExpression="title">
                <HeaderStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="poster" HeaderText="�o�G��" SortExpression="poster" 
                    Visible="False" />
                <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="�i�K��" SortExpression="initDate" />
                <asp:BoundField DataField="startDate" DataFormatString="{0:d}" HeaderText="�}�l��" SortExpression="startDate" />
                <asp:TemplateField HeaderText="������" SortExpression="endDate">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("endDate", "{0:d}")=="2800/1/1"?"":Eval("endDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("endDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="counts" HeaderText="�I�\��" SortExpression="counts">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="�s��">
                    <ItemTemplate>
                        <asp:HiddenField ID="hidbeSelect" runat="server" Value='<%# Eval("beSelect") %>' />
                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="�s��" CommandName="Update"
                            ImageUrl="~/images/Modify.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�R��" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                            ImageUrl="~/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('�A�T�w�n�R����?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           
        </asp:GridView>
        <div style="display: inherit">
            <asp:Button ID="btnDelete" runat="server" Text="�R��" OnClientClick="javascript:if(!window.confirm('�A�T�w�n�R����?')) window.event.returnValue = false;"
                OnClick="btnDelete_Click" Visible="False" />
        </div>
        <div class="cc_m_listguide">
            <uc1:Pagination ID="Pagination1" runat="server" />
        </div>
    </div>

</div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
