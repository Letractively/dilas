<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Grade_Insert.aspx.cs" Inherits="Grade_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            
            $('.currentYear').change(function () {
                var year = (new Date()).getFullYear();
                year = year - $('.currentYear').find("option:selected").val();
                if ((new Date()).getMonth() > 8) year++;
                $('.enrollYear').val(year);
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
  <h1>新增班級</h1>
<div class="from_table">
<table>
<tr>
<th width="18%"> <asp:Label ID="lblname" runat="server" AssociatedControlID="name">班級名稱</asp:Label></th>
<td><asp:TextBox
                    ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'班級名稱必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="Label1" runat="server" AssociatedControlID="currentYear">年　　級</asp:Label></th>
<td> <asp:DropDownList ID="currentYear" runat="server" CssClass="currentYear">
                    <asp:ListItem Value="1">1年級</asp:ListItem>
                    <asp:ListItem Value="2">2年級</asp:ListItem>
                    <asp:ListItem Value="3">3年級</asp:ListItem>
                    <asp:ListItem Value="4">4年級</asp:ListItem>
                    <asp:ListItem Value="5">5年級</asp:ListItem>
                    <asp:ListItem Value="6">6年級</asp:ListItem>
                </asp:DropDownList></td>
</tr>
<tr>
<th> <asp:Label ID="lblenrollYear" runat="server" AssociatedControlID="enrollYear">註冊年份</asp:Label></th>
<td>  <asp:TextBox
                    ID="enrollYear" runat="server" Width="250px" CssClass="enrollYear {validate:{required:true, messages:{required:'註冊年份必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th> <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說　　明</asp:Label></th>
<td> <asp:TextBox ID="description" runat="server" Width="250px" Height="160px" TextMode="MultiLine"></asp:TextBox></td>
</tr>


</table>
</div>


<div class="footer_button">
 <asp:Button ID="InsertButton" runat="server" CssClass="btn_small" Text="新增" OnClick="InsertButton_Click">
                </asp:Button> <input class="btn_small" type="button" value="回上頁" onclick="javascript:history.back();" />



</div>

</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>





  
</asp:Content>
