<%@ Page Title="" Language="C#" MasterPageFile="~/layout.master" AutoEventWireup="true"
    CodeFile="School_Edit.aspx.cs" Inherits="School_Edit" %>
<%@ Register TagPrefix="uc2" TagName="PublishTab" Src="~/UserControl/PublishTab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%= Page.ResolveUrl(@"~/js/twzipcode-1.3.1.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.zipcode').twzipcode({
                zipSel: $('#hidzip').val(),
                zipReadonly: false
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
<h1>學校維護</h1>
<uc2:PublishTab ID="PublishTab1" runat="server" tab="2" FunctionName="School" 
            isOpenEditTab="True" />
 <asp:HiddenField ID="hidzip" runat="server" ClientIDMode="Static" />
<div class="from_table">
<table>
<tr>
<th width="12%"><asp:Label ID="lblid" runat="server" AssociatedControlID="id">編號</asp:Label></th>
<td> <asp:TextBox
                ID="id" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'編號必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th>  <asp:Label ID="lblname" runat="server" AssociatedControlID="name">名稱</asp:Label></th>
<td><asp:TextBox
                ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'名稱必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="Label3" runat="server" AssociatedControlID="enable">狀態</asp:Label></th>
<td>  <asp:DropDownList
                ID="enable" runat="server">
                <asp:ListItem Value="True">啟用</asp:ListItem>
                <asp:ListItem Value="False">停用</asp:ListItem>
            </asp:DropDownList></td>
</tr>
<tr>
<th><asp:Label ID="lbloffcialUrl" runat="server" AssociatedControlID="offcialUrl">網址</asp:Label></th>
<td> <asp:TextBox
                ID="offcialUrl" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lbldomainName" runat="server" AssociatedControlID="domainName">網域</asp:Label></th>
<td> <asp:TextBox
                ID="domainName" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>電話</th>
<td> <input type="text" id="areaCode" style="width: 30px" value="" runat="server" CssClass="{validate:{required:true, messages:{required:'電話必填'}}}" />
            <input type="text" id="numberCode" style="width: 210px" value="" runat="server" /></td>
</tr>
<tr>
<th>地址</th>
<td>  <span class="zipcode"></span><input type="text" id="address" style="width: 210px"
                value="" runat="server" CssClass="{validate:{required:true, messages:{required:'地址必填'}}}" /></td>
</tr>
<tr>
<th> <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說明</asp:Label></th>
<td> <asp:TextBox ID="description" runat="server" Width="250px" Height="160px" TextMode="MultiLine"></asp:TextBox></td>
</tr>


</table>
</div>


<div class="footer_button">
 <asp:Button ID="InsertButton" runat="server" Text="修改" CssClass="btn_small"
 OnClick="InsertButton_Click">
            </asp:Button> <input class="btn_small" type="button" value="回上頁" onclick="location='School_List.aspx'" />
<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</div>




  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>
