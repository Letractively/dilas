<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="ContactBook_detail.aspx.cs" Inherits="DilasUser_ContactBook_ContactBook_detail" %>

<%@ Import Namespace="ExtensionMethods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_ContactBook"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1><asp:Label ID="lblDate" runat="server"></asp:Label>家庭聯絡簿</h1>
<div class="top_control"><input type="button" class="btn_small" onclick="location='ContactBook_Insert.aspx'" value="新增聯絡簿" /></div>
<div class="search" style="padding:0;">
<table class="search_table">
<tr>
<th width="15%">級任班級</th>
<td width="15%"><asp:DropDownList ID="ddlGrade" runat="server">
            </asp:DropDownList></td>
<th width="20%"><asp:Label ID="Label1" runat="server" AssociatedControlID="txtDate">日　　期</asp:Label></th>
<td width="20%"><asp:TextBox
                ID="txtDate" runat="server" Width="100px" CssClass="datepicker"></asp:TextBox></td>
<td width="30%"><asp:Button ID="btnView" CssClass="btn_small" runat="server" Text="檢視其他日期聯絡簿" OnClick="btnView_Click" />
  <input onclick="location='ContactBook_GradeSearch.aspx'" type="button" value="班級聯絡簿搜尋" style="display:none" /><input
                onclick="location='ContactBook_StudentSearch.aspx'" type="button" value="學生聯絡簿搜尋" style="display:none" />
</td> 
 </tr>
  
</table>

</div>

<h2>班級聯絡事項</h2>
<div class="h2_padding">
 <asp:TextBox ID="description" runat="server" Width="550px" Height="150px" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="btnModify" runat="server" Text="修改" CssClass="btn_small" />
</div>
<h2>學生個別聯絡事項</h2>
<div class="data_table">
 <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="people_id" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="seatNumber" HeaderText="座號" 
                        SortExpression="seatNumber" >
                    <HeaderStyle width="40px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="姓名" SortExpression="name">
   <HeaderStyle width="100px" />
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "ContactBook_ForTeacher.aspx?people_id=" + Eval("people_id") + "&contactBook_id=" + ViewState["id"].ToString() %>'
                                Text='<%# Eval("name") %>'></asp:HyperLink>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="APP下載狀態" SortExpression="checkDownload">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("checkDownload").ToString().ToMessageReplyName() %>'></asp:Label>
                        </ItemTemplate>
                     
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="APP回傳狀態" SortExpression="checkUpload">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("checkUpload").ToString().ToMessageReplyName() %>'></asp:Label>
                        </ItemTemplate>
                      
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="isSign" HeaderText="家長簽名" 
                        SortExpression="isSign" >
                    
                    </asp:CheckBoxField>
                    <asp:TemplateField HeaderText="上期回應" SortExpression="lastReply">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("lastReply").ToString().ToMessageReplyName() %>'></asp:Label>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="本期回應" SortExpression="toDayReply">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("toDayReply").ToString().ToMessageReplyName() %>'></asp:Label>
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                </Columns>
                        </asp:GridView>
</div>

 <asp:Button ID="btnSend" runat="server" Text="送出聯絡簿" onclick="btnSend_Click" />
 </div>



</div>
<div class="admin_bottombg"> </div>
</div>
</div>


    
</asp:Content>
