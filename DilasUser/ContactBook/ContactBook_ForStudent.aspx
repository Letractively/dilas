<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="ContactBook_ForStudent.aspx.cs" Inherits="DilasUser_ContactBook_ContactBook_ForStudent" %>

<%@ Import Namespace="ExtensionMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>" rel="stylesheet" type="text/css" />

<!-- CSS部份結束 -->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();


           
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="homebook">
<div class="homebook_bg">
<!--左方開始 -->
<div class="homebook_left">
<div class="hb_class"><asp:Label ID="GradeName" runat="server" Text="Label"></asp:Label> <asp:Label ID="StudentName" runat="server" Text="Label"></asp:Label>
 <asp:Label ID="Label1" runat="server" AssociatedControlID="txtDate">日期：</asp:Label><asp:TextBox
                ID="txtDate" runat="server" Width="100px" CssClass="datepicker"></asp:TextBox>
            <asp:Button ID="btnView" runat="server" Text="搜尋" CssClass="btn_small" OnClick="btnView_Click" /></div>


<div class="clear" style="margin:0 0 30px 0" ></div>
<h2>全班聯絡事項</h2>
<div class="hb_allclass">
<asp:Label ID="description" runat="server"></asp:Label>
</div>
<h2>學生個別聯絡事項</h2>
<div class="hb_oneclass">
 <asp:Label ID="article" runat="server"></asp:Label>
</div>
</div>
<!--左方結束 -->
<!--右方開始 -->
<div class="homebook_right">
<div class="homebook_right_in">
<h2>回應交流區</h2>
<div class="hb_common">

  <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
                AllowPaging="True" ShowHeader="False" 
                onpageindexchanging="gvList_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                    
                        <ItemTemplate>
                        <div>
                        【<asp:Label ID="Label3" runat="server" Text='<%# Eval("role").ToString().ToScodeRoleName() %>'></asp:Label>】<asp:Label ID="Label1" runat="server" Text='<%# Eval("name").ToString() %>'></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("initDate", "{0:d}") %>'></asp:Label>
                        </div>
                        <div style="margin:0 0 0 65px">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# My.WebForm.TXT2HTML(Eval("article").ToString())   %>'></asp:Literal>
                        </div>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                </Columns>
            
            </asp:GridView>
</div>
<h2>學生回應</h2>
<div class="hb_write">
<asp:Panel ID="Panel1" runat="server">
<table>

<tr>
<td> <asp:TextBox ID="txtArticle" runat="server" Height="120px" TextMode="MultiLine" 
        Width="250px"></asp:TextBox></td>

</td>
<td valign="bottom"><asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" CssClass="btn_small" Text="送出" /></td>
</tr>

</table>
 


   
    


    </asp:Panel>

</div>
<div class="footer_button"></div>

</div>
</div>
<!--右方結束 -->
</div>
</div>
</asp:Content>

