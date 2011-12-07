<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="ContactBook_Insert.aspx.cs" Inherits="DilasUser_ContactBook_ContactBook_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .canMessage
        {
            width: 300px;
            height: 200px;
            overflow: auto;
            border: 1px solid #094275;
        }
        
        .messageItem
        {
            height: 80px;
            border-bottom: 1px dashed #545454;
            font-size: 13px;
            padding: 10px;
        }
        
        .messageItem:hover
        {
            background: #fcf9e1;
            cursor: pointer;
        }
        
        .messageChangeItem
        {
            background: lightgreen;
        }
        .noMessage
        {
            height: 100%;
            text-align: center;
            vertical-align: middle;
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
							    $('#description').text(
										$('#description').text()
												+ $('.copyItem').eq(
														$('#hide').val()).html()
														.replace(/<br>/g, '\n'));
							});
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg  admin_ContactBook"></div>
  <div class="admin_middlebg">
  <div class="container">




<h1>新建聯絡簿</h1>
<div class="search">
<table class="search_table">
<tr>
<th width="14%"　class="datepicker">日　　期</th>
<td width="24%"> <asp:Label ID="lblDate" runat="server" AssociatedControlID="date"></asp:Label><asp:TextBox
                ID="date" runat="server" Width="250px"></asp:TextBox></td>
<th width="16%">級任班級</th>
<td width="46%"> <asp:Label ID="Label1" runat="server" AssociatedControlID="grade_id"></asp:Label><asp:DropDownList
                ID="grade_id" runat="server">
            </asp:DropDownList></td>
  </tr>
 
</table>
</div>
<h2><asp:Label ID="Label2" runat="server" AssociatedControlID="description">班級聯絡事項：</asp:Label></h2>
<table width="100%" border="0">
            <tr>
                <td width="45%">
                    <div style="display: inherit; text-align: left;">
                        <asp:TextBox
                            ID="description" runat="server" Width="250px" Height="150px" TextMode="MultiLine"
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
                                <span class="copyItem">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("messages") %>'></asp:Literal></span></div>
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
                        <asp:Button ID="InsertButton" runat="server" CssClass="btn_small" Text="建立聯絡簿" OnClick="InsertButton_Click">
                        </asp:Button></div>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <div style="margin:10px 0 0 0">
                        <input id="Button1" type="button" value="新增訊息" class="btn_small" onclick="tb_show('新增訊息','TemplateMessage_Insert.aspx?KeepThis=true&TB_iframe=true&height=400&width=400','thickbox')" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn_small" OnClick="btnDelete_Click" Text="刪除訊息" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;" />
                    </div>
                </td>
            </tr>
        </table>
</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
</asp:Content>
