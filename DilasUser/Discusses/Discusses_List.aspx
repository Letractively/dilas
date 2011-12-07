<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Discusses_List.aspx.cs" Inherits="DilasUser_Discusses_Discusses_List_" %>

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
  <div class="admin_topbg admin_board"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>班級塗鴉牆管理</h1>
<div class="top_control">
 <input onclick="location='Discusses_Insert.aspx?ModuleID=<%=Request["ModuleID"] %>&grade_id=<%=Request["grade_id"] %>'" type="button"
                value="新增主題" class="Addbutton btn_small" />
            <input onclick="location='Discusses_Class.aspx?ModuleID=<%=Request["ModuleID"] %>&grade_id=<%=Request["grade_id"] %> '" type="button"
                value="類別維護" class="Addbutton btn_small" />
</div>

<div class="search">
<table class="search_table " >
<tr>
<th width="14%">分　　類</th>
<td width="24%"><asp:DropDownList ID="ddlClass1" runat="server"
                DataTextField="className" DataValueField="id">
            </asp:DropDownList></td>
<th width="16%">關鍵字</th>
<td width="46%"><asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
  </tr>
 
</table>
<div class="search_btn">
 <asp:Button ID="btnSearch" runat="server" Text="搜尋" OnClick="btnSearch_Click" class="btn_small" />
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重設" class="btn_small" />
</div>
</div>

<div class="data_table">
   <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            Font-Size="14px" OnRowDataBound="gvList_RowDataBound" OnRowDeleting="gvList_RowDeleting"
            Width="100%" OnRowUpdating="gvList_RowUpdating"
            CssClass="tableStyle1" GridLines="None" CellPadding="4" 
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
                <asp:BoundField DataField="className" HeaderText="類別名稱" 
                    SortExpression="className" >
  
                </asp:BoundField>
                <asp:BoundField DataField="title" HeaderText="主題" SortExpression="title">
        
                </asp:BoundField>
                <asp:BoundField DataField="poster" HeaderText="發佈者" SortExpression="poster" 
                    Visible="False" />
                <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="張貼日" 
                    SortExpression="initDate" >
              
                </asp:BoundField>
                <asp:BoundField DataField="startDate" DataFormatString="{0:d}" HeaderText="開始日" 
                    SortExpression="startDate" Visible="False" />
                <asp:TemplateField HeaderText="結束日" SortExpression="endDate" Visible="False">
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
</div>
 <div class="cc_m_listguide">
            <uc1:Pagination ID="Pagination1" runat="server" />
        </div>
  <div style="display: inherit">
            <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"
                OnClick="btnDelete_Click" Visible="False" />
        </div>


     
      
       
  


</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>

</asp:Content>

