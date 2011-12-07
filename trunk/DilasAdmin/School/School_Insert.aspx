<%@ Page Title="新增學校" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="School_Insert.aspx.cs" Inherits="School_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%= Page.ResolveUrl(@"~/js/twzipcode-1.3.1.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            
            $('.zipcode').twzipcode({
                zipSel: "800",
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

<h1>新增學校</h1>


<div class="from_table">
<table>
<tr>
<th width="18%">編號</th>
<td><asp:TextBox
                ID="id" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'編號必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th>名稱</th>
<td><asp:TextBox
                ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'名稱必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th>網址</th>
<td><asp:TextBox
                ID="offcialUrl" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>網域</th>
<td><asp:TextBox
                ID="domainName" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>電話</th>
<td> <input type="text" id="areaCode" style="width: 30px" value="" runat="server"  />
            <input type="text" id="numberCode" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'電話必填'}}}" /></td>
</tr>
<tr>
<th>地址</th>
<td> <span class="zipcode"></span><input type="text" id="address" style="width: 210px"
                value="" runat="server" class="{validate:{required:true, messages:{required:'地址必填'}}}" /></td>
</tr>
<tr>
<th>說明</th>
<td><asp:Label ID="lbldescription" runat="server" AssociatedControlID="description"></asp:Label>
            <asp:TextBox ID="description" runat="server" Width="250px" Height="160px" TextMode="MultiLine"></asp:TextBox></td>
</tr>
</table>
</div>

<div class="footer_button">
   <asp:Button ID="InsertButton" CssClass="btn_small" runat="server" Text="新增" OnClick="InsertButton_Click">
            </asp:Button> <input class="btn_small" type="button" value="回上頁" onclick="location='School_List.aspx'" />
 <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

</div>
   
</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
</asp:Content>
