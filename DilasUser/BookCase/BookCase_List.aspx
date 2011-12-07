<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="BookCase_List.aspx.cs" Inherits="DilasUser_BookCase_BookCase_List" %>
<%@ Import Namespace="ExtensionMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_Bookcase"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>我的書櫃</h1>
<div class="top_control"><input onclick="location.href='BookCase_Insert.aspx'" type="button"
                value="新增教材書籍" class="Addbutton btn_small" />
            <input onclick="location.href='BookCase_Tabs.aspx'" type="button"
                value="書籤維護" class="Addbutton btn_small" />
                 <input onclick="location.href='BookCase_Search.aspx'" type="button"
                value="搜尋" class="Addbutton btn_small" /></div>

 <asp:DataList ID="dlTabs" runat="server" Width="100%" DataKeyField="id" 
                    onitemdatabound="dlTabs_ItemDataBound">
                    <ItemTemplate>
<h3 style="color:#796A56; font-weight:bold;margin:10px 0;padding:5px; border-top:1px dashed #9A9A9A; border-bottom:1px dashed #9A9A9A">

                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("subject") %>'></asp:Label>
                      
</h3>
                        <asp:DataList ID="dlBookCase" runat="server" RepeatColumns="5">
                            <ItemTemplate>
                                <div >
                                <table>
                                <tr>
                                <td style="padding:5px 10px ; text-align:center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("BookCase_View.aspx?id={0}", Eval("id")) %>'> <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# Eval("coverPicName").ToString().ToScodeBookCaseURL(Eval("school_id").ToString(),Eval("people_id").ToString()) %>' /></asp:HyperLink>
                                 
                                </td>
                                </tr>
                                 <tr>
                                <td style="padding:5px 0;font-size:13px;text-align:center">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("subject") %>'></asp:Label>
                                </td>
                                </tr>
                                </table>
                                   
                                </div>

                            </ItemTemplate>
                        </asp:DataList>
                    </ItemTemplate>
                </asp:DataList>


</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>



    <div id="admin_menu">
        <div>
            
            <div style="clear: both">
               
            </div>
        </div>
    </div>
</asp:Content>
