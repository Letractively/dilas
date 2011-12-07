<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Discusses_Insert.aspx.cs" Inherits="DilasUser_Discusses_Discusses_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
            $(".datepicker input").datepicker();
        });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg  admin_board"></div>
  <div class="admin_middlebg">
  <div class="container">


<h1>新增塗鴉牆主題</h1>


<div class="from_table">
<table>

<tr>
<th width="18%">主　　題</th>
<td> <asp:TextBox
                ID="title" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'標題必填'}}}"></asp:TextBox></td>
</tr>
<tr>
<th>類　　別</th>
<td> <asp:DropDownList ID="ddlClass1" runat="server" DataTextField="className" DataValueField="id">
            </asp:DropDownList></td>
</tr>
<tr>
<th>張貼時間</th>
<td><asp:TextBox
                ID="initDate" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>開始日期</th>
<td><asp:TextBox
                ID="startDate" runat="server" Width="250px"></asp:TextBox></td>
</tr>
<tr>
<th>結束日期</th>
<td><asp:TextBox
                ID="endDate" runat="server" Width="250px" CssClass="{validate:{date:true, messages:{date:'結束日期格式不正確'}}}"></asp:TextBox>
            (不設定代表永遠生效)</td>
</tr>
<tr>
<th>圖　　片</th>
<td><asp:FileUpload ID="fuPic" runat="server" /></td>
</tr>
<tr>
<th>詳細內容</th>
<td><asp:TextBox ID="shortDescription" runat="server" Width="450px" TextMode="MultiLine"
                    Height="250px" MaxLength="500" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox></td>
</tr>

</table>
<div class="search_btn">
 <asp:Button ID="InsertButton" runat="server" Text="加入" CssClass="button btn_small" OnClick="InsertButton_Click">
            </asp:Button>
            <input onclick="location='Discusses_List.aspx?ModuleID=<%=Request["ModuleID"] %>&grade_id=<%=Request["grade_id"] %>'" type="button"
                value="回列表" class="button  btn_small" />
</div>
</div>
 <%--不顯示欄位--%>
        <asp:Panel ID="pnlHidden" runat="server" Visible="false">
       <div style="display: inherit">
            <div>
                <asp:Label ID="lblarticle" runat="server" AssociatedControlID="article">詳細內容</asp:Label>
            </div>
            <div style="clear:both">
                <asp:TextBox ID="article" Height="250px" MaxLength="500" Width="450px" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>

            
            <div style="display: inherit">
                <asp:Label ID="lblOrgID" runat="server" AssociatedControlID="ddlOrg">機關</asp:Label>
                <asp:DropDownList ID="ddlOrg" runat="server" DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
            </div>
            
            <div style="display: inherit">
                <asp:Label ID="lblfileUrl" runat="server" AssociatedControlID="fileUrl">檔案</asp:Label><asp:DropDownList
                    ID="ddlFile" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                    <asp:ListItem>檔案上傳</asp:ListItem>
                    <asp:ListItem>檔案連結</asp:ListItem>
                </asp:DropDownList>
                <asp:FileUpload ID="fuFile" runat="server" />
                <asp:TextBox ID="fileUrl" runat="server" Width="250px" Visible="False"></asp:TextBox></div>
            <div style="display: inherit">
                <asp:Label ID="lbllinkUrl" runat="server" AssociatedControlID="linkUrl">連結</asp:Label><asp:TextBox
                    ID="linkUrl" runat="server" Width="250px"></asp:TextBox>
                <asp:DropDownList ID="linkTarget" runat="server">
                    <asp:ListItem Value="_blank">另開新視窗</asp:ListItem>
                    <asp:ListItem Value="_self">在當前視窗開啟</asp:ListItem>
                </asp:DropDownList>
                (外連結請加http://)
            </div>
            <div style="display: inherit">
                <asp:Label ID="lbllinkText" runat="server" AssociatedControlID="linkText">連結說明文字</asp:Label><asp:TextBox
                    ID="linkText" runat="server" Width="250px"></asp:TextBox></div>

            <div style="display: inherit">
                <asp:Label ID="lbllistNum" runat="server" AssociatedControlID="listNum">排序</asp:Label><asp:TextBox
                    ID="listNum" runat="server" Width="250px" CssClass="{validate:{required:true, number:true, messages:{required:'必填', number:'須為數字'}}}"></asp:TextBox></div>
            <div style="display: inherit">
                <asp:Label ID="lbleable" runat="server" AssociatedControlID="eable">顯示狀態</asp:Label>
                <asp:CheckBox ID="eable" runat="server" Text="是否顯示" CssClass="checkbox" Checked="true" /></div>
            <div style="display: inherit">
                <asp:Label ID="lblbeSelect" runat="server" AssociatedControlID="beSelect">beSelect</asp:Label><asp:TextBox
                    ID="beSelect" runat="server" Width="250px"></asp:TextBox></div>
            <div style="display: inherit">
                <asp:Label ID="lblstatus" runat="server" AssociatedControlID="status">狀態</asp:Label><asp:TextBox
                    ID="status" runat="server" Width="250px"></asp:TextBox></div>
    </asp:Panel>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>


</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>

        
</asp:Content>


