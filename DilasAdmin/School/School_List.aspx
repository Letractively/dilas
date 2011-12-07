<%@ Page Title="" Language="C#" MasterPageFile="~/layout.master" AutoEventWireup="true"
    CodeFile="School_List.aspx.cs" Inherits="School_List" %>
<%@ Import Namespace="ExtensionMethods" %>

<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%= Page.ResolveUrl(@"~/UserControl/pagination.css") %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".dis").each(function () {
                if ($(this).text() == "停用") {
                    $(this).css("color", "red");
                }
            });

        });     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">

<h1>學校專區</h1>
<div class="top_control"> <input type="button" onclick="location='School_Insert.aspx'" value="新增學校" class="btn_small" /></div>
<div class="search">

<table class="search_table " >



  <tr>

    <th width="14%"> 關<span class="padd_1"></span>鍵<span class="padd_1"></span>字 </th>

    <td width="24%">
<asp:TextBox ID="txtSearch" runat="server" CssClass="keyWord"></asp:TextBox>
      

    </td>

    <th width="16%">  網域名稱</th>

    <td width="46%">
<input id="domainNamePattern" name="domainNamePattern" class="input_text t1" type="text" value=""/>
</td>

  </tr>

  <tr>

    <th>區　　域</th>

    <td>
<asp:DropDownList ID="ddlArea" runat="server">
            </asp:DropDownList>
</td>

    <th>狀　　態</th>

    <td>

   <asp:DropDownList
                ID="ddlEnable" runat="server">
                <asp:ListItem Value="-1">請選擇</asp:ListItem>
                <asp:ListItem Value="True">啟用</asp:ListItem>
                <asp:ListItem Value="False">停用</asp:ListItem>
            </asp:DropDownList>

    </td>

  </tr>

</table>



				<div class="search_btn">

				 <asp:Button ID="Button1" runat="server" Text="搜尋" CssClass="btn_small" OnClick="Button1_Click" />
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="取消搜尋"  CssClass="btn_small" />

                        </div>

                        </div>

     <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                GridLines="None" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" CellPadding="4"
                 Width="100%" CssClass="data_table">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="識別碼" ReadOnly="True" SortExpression="id">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="name" HeaderText="名稱" SortExpression="name">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="division" HeaderText="區域">
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="GradeCount" HeaderText="班級數">
                       
                    </asp:BoundField>
                    <asp:BoundField DataField="initDate" HeaderText="建立日期" SortExpression="initDate"
                        DataFormatString="{0:d}">
                       
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="狀態">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" CssClass="dis" Text='<%# SCode.ToScodeEnableName( Eval("Enable").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("able") %>'></asp:TextBox>
                        </EditItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="檢視">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" CommandName="Update"
                                ImageUrl="~/images/Modify.gif" />
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="刪除" ShowHeader="False" Visible="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                                ImageUrl="~/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                </Columns>
                
            </asp:GridView>
            <uc1:Pagination ID="Pagination1" runat="server" />


  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
