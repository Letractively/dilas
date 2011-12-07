<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookCase_Show.aspx.cs" Inherits="DilasUser_PrepareLesson_BookCase_Show" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="ExtensionMethods" %>
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
     書籍標題:<asp:TextBox ID="txtSearch" runat="server" Width="77px"></asp:TextBox>
                  
                    <asp:Button ID="btnSearch" runat="server" Text="搜尋" OnClick="btnSearch_Click" />
    </div>
    <div>
                            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" DataKeyNames="id" Width="400px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox2" CssClass="selectall" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="selectOne" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="subject" HeaderText="標題" SortExpression="subject" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                請下條件搜尋
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
    <div>
                        <asp:Button ID="btnSend" runat="server" Text="送出" OnClick="btnSend_Click" />
                    
    </div>
    </form>
</body>
</html>
