<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_Grade_Teacher_Show.aspx.cs"
    Inherits="DilasAdmin_Grade_Grade_Teacher_Show" %>

<%@ Register Src="~/UserControl/Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<%@ Import Namespace="ExtensionMethods" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/jquery-1.6.3.min.js") %>"></script>
    <script type="text/javascript">
        $(function () {
            $(".selectall input").click(function () {
                $(".selectOne input").each(function () {
                    if ($(".selectall input").attr("checked") == "checked") {
                        $(this).attr("checked", $(".selectall input").attr("checked"));
                    } else {
                        $(this).attr("checked", false);
                    }
                });
            });

            $(".selectOne input").click(function () {
                $(".selectall input").attr("checked", false);
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="101%" border="1">
            <tr>
                <td width="45%">
                    姓名:<asp:TextBox ID="txtSearch" runat="server" Width="77px"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="搜尋" OnClick="btnSearch_Click" />
                </td>
                <td rowspan="2" width="10%" align="center" valign="middle">
                    <asp:Button ID="btnAdd" runat="server" Text=">>" OnClick="btnAdd_Click" />
                </td>
                <td rowspan="2" width="45%" valign="top">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="等級">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("rank").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="name" HeaderText="教師姓名" SortExpression="name" />
                            <asp:TemplateField HeaderText="教師類型">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlClassify" runat="server">
                                        <asp:ListItem Value="0">級任老師</asp:ListItem>
                                        <asp:ListItem Value="1">專任老師</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="性別">
                                <ItemTemplate>
                                    <asp:Label ID="gender" runat="server" Text='<%# Eval("gender").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnDelete" runat="server" CssClass="action" CommandName="Delete"
                                        ImageUrl="~/images/Delete.gif" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="overflow-y: scroll">
                        <asp:Label ID="lblMessage" runat="server" Text="請下條件搜尋未指派班級的教師"></asp:Label>
                        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" DataKeyNames="id">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox2" CssClass="selectall" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="selectOne" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="等級">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRank" runat="server" Text='<%#  Eval("rank").ToString().ToScodeRankName() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="name" HeaderText="教師姓名" SortExpression="name" />
                                <asp:TemplateField HeaderText="性別">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text='<%#  Eval("gender").ToString().ToScodeGenderName() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                請下條件搜尋未指派班級的教師
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                        <uc1:Pagination ID="Pagination1" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="btnSend" runat="server" Text="送出" OnClick="btnSend_Click" />
                    &nbsp;<input type="reset" name="button3" id="button3" value="關閉" onclick="parent.tb_remove();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
