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

<h1>學校公告</h1>
<div class="top_control"> 
 <input onclick="location='News_Insert.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button"
                value="新增最新動態" class="Addbutton btn_small" />
            <input onclick="location='News_Class.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button"
                value="類別維護" class="Addbutton btn_small" style="display: none" />
</div>
<div class="search">
<table class="search_table " >
<tr>
<th width="14%">關鍵字 </th>
<td width="24%"> <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>

<th width="16%"> </th>
<td width="46%"> </td>
</tr>
<tr style="display:none">
<th width="14%">  <span style="display:inherit"><asp:Label ID="lblSchool" runat="server" Text="機關:" /></span></th>
<td width="24%">  <asp:DropDownList ID="ddlSchool" runat="server" AutoPostBack="True">
                </asp:DropDownList> </td>

<th width="16%"> </th>
<td width="46%"> </td>
</tr>
</table>
<div class="search_btn">
<asp:Button ID="btnSearch" CssClass="btn_small" runat="server" Text="搜尋" OnClick="btnSearch_Click" />
            <asp:Button CssClass="btn_small" ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重設" />
</div>
</div>

    <div id="admin_menu">
        <div>
           
            <div style="clear: both">
            </div>
        </div>
        <div>
           
              
            <span style="display: none">請選擇發佈分類：<asp:DropDownList ID="ddlClass1" runat="server"
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
                <asp:BoundField DataField="OrgNames" HeaderText="單位" SortExpression="OrgNames" Visible="False">
                </asp:BoundField>
                <asp:BoundField DataField="className" HeaderText="類別名稱" SortExpression="className"
                    Visible="False" />
                <asp:BoundField DataField="title" HeaderText="標題" SortExpression="title">
                <HeaderStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="poster" HeaderText="發佈者" SortExpression="poster" 
                    Visible="False" />
                <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="張貼日" SortExpression="initDate" />
                <asp:BoundField DataField="startDate" DataFormatString="{0:d}" HeaderText="開始日" SortExpression="startDate" />
                <asp:TemplateField HeaderText="結束日" SortExpression="endDate">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("endDate", "{0:d}")=="2800/1/1"?"":Eval("endDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("endDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="counts" HeaderText="點閱數" SortExpression="counts">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                        <asp:HiddenField ID="hidbeSelect" runat="server" Value='<%# Eval("beSelect") %>' />
                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" CommandName="Update"
                            ImageUrl="~/images/Modify.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                            ImageUrl="~/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
           
        </asp:GridView>
        <div style="display: inherit">
            <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"
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
