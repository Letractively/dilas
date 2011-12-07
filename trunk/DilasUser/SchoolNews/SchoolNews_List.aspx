<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="SchoolNews_List.aspx.cs" Inherits="DilasUser_SchoolNews_SchoolNews_List" %>
<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="admin_menu">
        <div>
            &nbsp;<input onclick="location='News_Class.aspx?ModuleID=<%=Request["ModuleID"] %>'" type="button"
                value="類別維護" class="Addbutton" style="display: none" />
            <div style="clear: both">
            </div>
        </div>
        <div style="display:none">
            關鍵字<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="搜尋" OnClick="btnSearch_Click" />
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重設" />
        </div>


<div class="bulletin">
<!--內容欄 開始 -->
<div class="bulletin_middle_in">
<div class="bulletin_middle_in_box">
<asp:Repeater ID="gvList" runat="server">
        <ItemTemplate>


<div class="bulletin_list">
<div class="bulletin_title"> <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# "SchoolNews_Detail.aspx?ID=" + Eval("id") %>' 
                            Text='<%# Eval("title") %>'></asp:HyperLink></div>
<div class="bulletin_time"><asp:Label ID="Label2" runat="server" Text='<%# Bind("initDate", "{0:d}") %>'></asp:Label>
</div>
<div class="bulletin_content"><asp:Label ID="Label3" runat="server" Text='<%# Bind("shortDescription") %>'></asp:Label>
<asp:HyperLink ID="HyperLink2" runat="server" 
                            NavigateUrl='<%# "SchoolNews_Detail.aspx?ID=" + Eval("id") %>' 
                            Text='....(閱讀全文)'></asp:HyperLink>
</div>
</div>


        <div>
                              
                            </div>
        </ItemTemplate>
        </asp:Repeater>
        

        <div class="cc_m_listguide">
            <uc1:Pagination ID="Pagination1" runat="server" />
        </div>

</div>
</div>
<!--內容欄 結束 -->
<div class="bulletin_top"></div>
<div class="bulletin_middle">

 



</div>
<div class="bulletin_bottom"></div>
</div>

<div class="clear"></div>
</div>
<!--右方內容結束 -->

       

</asp:Content>

