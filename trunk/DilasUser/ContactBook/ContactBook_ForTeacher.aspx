<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="ContactBook_ForTeacher.aspx.cs" Inherits="DilasUser_ContactBook_ContactBook_detail_Student" %>
<%@ Import Namespace="ExtensionMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>" rel="stylesheet" type="text/css" />
<style type="text/css">
.canMessage {
	width: 300px;
	height: 200px;
	overflow: auto;
	border:1px solid #094275
}

.messageItem {

	height: 80px;
	border-bottom: 1px dashed #545454;
	font-size:13px;
	padding:10px
}

.messageItem:hover {
	background: #fcf9e1;
	cursor: pointer;
}

.messageChangeItem {
	background: lightgreen;
}
.noMessage{ 
	height:100%;
	text-align:center;
	vertical-align:middle;
}
</style>
<!-- CSS部份結束 -->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker input").datepicker();


            $('.messageItem').click(function () {
                $('.messageItem').removeClass("messageChangeItem");
                $(this).addClass("messageChangeItem");
                $('#hide').val($('.messageItem').index(this));
            });
            $('#messageBtn').click(
							function () {
							    $('#article').val(
										$('#article').val()
												+ ($('.copyItem').eq(
														$('#hide').val()).find("input").val()
														));
							});
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg  admin_ContactBook"></div>
  <div class="admin_middlebg">
  <div class="container">
<h2><asp:Label ID="date" runat="server" Text="Label"></asp:Label>/ <asp:Label ID="GradeName" runat="server" Text="Label"></asp:Label><asp:Label ID="StudentName" runat="server" Text="Label"></asp:Label>的聯絡簿</h2>
<h2>全班聯絡事項</h2>
<div class="h2_padding">
 <asp:Label ID="description" runat="server"></asp:Label>
</div>


<h2>  <asp:Label ID="Label2" runat="server" AssociatedControlID="article">學生個別聯絡事項：</asp:Label></h2>

<table width="100%" border="0">
            <tr>
                <td width="45%">
                    <div style="display: inherit; text-align: left;">
                        <asp:TextBox
                            ID="article" runat="server" Width="250px" Height="150px" TextMode="MultiLine"
                            ClientIDMode="Static"></asp:TextBox></div>
                </td>
                <td width="10%">
                    <input id="messageBtn" type="button" value="<<" />
                </td>
                <td width="45%">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <div class="canMessage">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="messageItem">
                                <asp:HiddenField ID="hidID" runat="server" Value='<%# Eval("id") %>' />
                                <asp:Literal ID="Literal1" runat="server" Text='<%# My.WebForm.TXT2HTML(Eval("messages").ToString())  %>'></asp:Literal>
                                <span class="copyItem"><asp:HiddenField ID="HiddenField1" runat="server"  Value='<%# Eval("messages")  %>'  /></span>
                                </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hide" runat="server" ClientIDMode="Static" />
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <asp:Button ID="InsertButton" runat="server" Text="確定送出" 
                            onclick="InsertButton_Click">
                        </asp:Button></div>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <div style="margin:10px 0 0 0">
                        <input id="Button1" class="btn_small" type="button" value="新增訊息" onclick="tb_show('新增訊息','TemplateMessage_Insert.aspx?KeepThis=true&TB_iframe=true&height=400&width=400','thickbox')" />
                        <asp:Button ID="btnDelete" class="btn_small" runat="server" OnClick="btnDelete_Click" Text="刪除訊息" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </div>
                </td>
            </tr>
        </table>

  <h2> 回應事項回顧</h2>
<div class="data_table">
<asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" 
                AllowPaging="True" ShowHeader="False" 
                onpageindexchanging="gvList_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                    
                        <ItemTemplate>
                        <div style="text-align:left">
                        【<asp:Label ID="Label3" runat="server" Text='<%# Eval("role").ToString().ToScodeRoleName() %>'></asp:Label>
                            】<asp:Label ID="Label1" runat="server" Text='<%# Eval("name").ToString() %>'></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("initDate", "{0:d}") %>'></asp:Label>
                        </div>
                        <div style="text-align:left">
                            <asp:Literal ID="Literal2" runat="server" Text='<%# My.WebForm.TXT2HTML(Eval("article").ToString())   %>'></asp:Literal>
                        </div>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                </Columns>
            
            </asp:GridView>
</div>

</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>



</asp:Content>

