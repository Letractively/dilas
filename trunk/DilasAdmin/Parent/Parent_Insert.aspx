<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Parent_Insert.aspx.cs" Inherits="Parent_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%= Page.ResolveUrl(@"~/js/twzipcode-1.3.1.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            
            $('.zipcode').twzipcode({
                zipSel: "800",
                zipReadonly: false
            });
            $(".datepicker input").datepicker({ defaultDate: "-25y" });
            
            $('#btnCheckAccount').click(function () {
                if ($("#username").val() == "") return;
                $.get('../../ashx/CheckAccount.ashx', { username: $("#username").val() }, function (data) {
                    if (data == "1") {
                        $("#checkmessage").text("帳號已經存在，請使用其他帳號名稱！");
                    } else {
                        $("#checkmessage").text("此帳號可以使用！");
                    }
                });

            });


        });
        
  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="admin">
<div class="admin_bg">
<div class="admin_topbg"></div>
<div class="admin_middlebg">
<div class="container">

<h1>新增家長</h1>
<div class="from_table">
<table>
<tr>
<th width="18%"> <asp:Label ID="lblusername" runat="server" AssociatedControlID="username">帳　　號</asp:Label></th>
<td><asp:TextBox
                ID="username" runat="server" Width="250px" 
                CssClass="{validate:{required:true, messages:{required:'帳號必填'}}}" 
                ClientIDMode="Static"></asp:TextBox><input id="btnCheckAccount" type="button" value="檢查帳號" /><span id="checkmessage" style="color: red"></span></td>
</tr>
<tr>
<th> <asp:Label ID="lblpassword" runat="server" AssociatedControlID="password">密　　碼</asp:Label></th>
<td> <asp:TextBox
                ID="password" runat="server" Width="250px" ClientIDMode="Static" CssClass="{validate:{required:true, messages:{required:'密碼必填'}}}"
                TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="Label3" runat="server" AssociatedControlID="txtPassword">確認密碼</asp:Label></th>
<td><asp:TextBox
                ID="txtPassword" runat="server" Width="250px" CssClass="{validate:{required:true, equalTo:'#password', messages:{required:'密碼必填', equalTo:'密碼輸入不相同'}}}"
                TextMode="Password"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lblemailAddress" runat="server" AssociatedControlID="emailAddress">聯絡E-mail</asp:Label></th>
<td> <asp:TextBox
                ID="emailAddress" runat="server" Width="250px" CssClass="{validate:{required:true, email:true, messages:{required:'聯絡E-mail必填', email:'請檢查E-mail 格式是否正確'}}}"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lblname" runat="server" AssociatedControlID="name">姓　　名</asp:Label></th>
<td> <asp:TextBox
                ID="name" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'姓名必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lblbirthday" runat="server" AssociatedControlID="birthday">生　　日</asp:Label></th>
<td class="datepicker"> <asp:TextBox
                ID="birthday" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lblgender" runat="server" AssociatedControlID="gender">性　　別</asp:Label></th>
<td> <asp:DropDownList
                ID="gender" runat="server">
                <asp:ListItem Value="True">男</asp:ListItem>
                <asp:ListItem Value="False">女</asp:ListItem>
            </asp:DropDownList></td>
</tr>
<tr>
<th><asp:Label ID="Label1" runat="server" AssociatedControlID="occupation">職　　業</asp:Label></th>
<td><asp:TextBox
                ID="occupation" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th><asp:Label ID="lbltelephone_id" runat="server" AssociatedControlID="numberCode">電　　話</asp:Label></th>
<td><input type="text" id="areaCode" style="width: 30px" value="" runat="server" />
            <input type="text" id="numberCode" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'電話必填'}}}" /></td>
</tr>

<tr>
<th> <asp:Label ID="lbladdress_id" runat="server" AssociatedControlID="address">地　　址</asp:Label></th>
<td> <span class="zipcode"></span>
            <input type="text" id="address" style="width: 210px" value="" runat="server" class="{validate:{required:true, messages:{required:'地址必填'}}}" />
        </td>
</tr>
<tr>
<th>  <asp:Label ID="lbldescription" runat="server" AssociatedControlID="description">說　　明</asp:Label></th>
<td>  <asp:TextBox ID="description" runat="server" Width="400px" Height="100px" 
                TextMode="MultiLine"></asp:TextBox></td>
</tr>
</table>
</div>
<div class="footer_button">
 <asp:Button ID="InsertButton" CssClass="btn_small" runat="server" Text="新增" OnClick="InsertButton_Click">
            </asp:Button> <input class="btn_small" type="button" value="回上頁" onclick="javascript:history.back();" />
 <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>


</div>



</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>

　　
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">

<div id="admin_menu">
        <div>
           <asp:Label ID="lblSchool" runat="server" Text="學校："></asp:Label><asp:DropDownList ID="ddlSchool" runat="server">
            </asp:DropDownList>
            姓 名：<asp:TextBox ID="txtSearch" runat="server" CssClass="keyWord"></asp:TextBox>
            
            性別：<asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Value="-1">請選擇</asp:ListItem>
                <asp:ListItem Value="0">男</asp:ListItem>
                <asp:ListItem Value="1">女</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Text="搜尋" OnClick="Button1_Click" />
            <input type="button" onclick="location='Parent_List.aspx'" value="取消搜尋" />
        </div>
        <div>
            <input type="button" onclick="location='Parent_Insert.aspx'" value="新增家長" runat="server" id="btnAdd" Visible="false" />
        </div>
        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            GridLines="None" CellPadding="4" ForeColor="#333333" OnRowDeleting="GridView1_RowDeleting"
            Width="100%" OnRowUpdating="gvList_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="schoolName" HeaderText="學校">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="家長姓名" SortExpression="name">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="birthday" DataFormatString="{0:d}" HeaderText="生日" SortExpression="birthday">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="姓別" SortExpression="gender">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# SCode.ToScodeGenderName(Eval("gender").ToString())  %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="狀態" SortExpression="enable">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# SCode.ToScodeEnableName(Eval("enable").ToString())  %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="initDate" DataFormatString="{0:d}" HeaderText="建立日期" SortExpression="initDate">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="檢視">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" AlternateText="編輯" CommandName="Update"
                            ImageUrl="~/images/Modify.gif" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除" ShowHeader="False" Visible="False">
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
        <uc1:Pagination ID="Pagination1" runat="server" />
    </div>


  </div>
  </div>
  <div class="admin_bottombg"> </div>
 
  
</div>
</div>
</asp:Content>--%>

