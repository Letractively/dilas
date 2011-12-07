<%@ Page  ValidateRequest="false"  Title="編輯最新動態" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="News_Edit.aspx.cs" Inherits="manage_News_News_Edit" %>

<%@ Register Src="~/UserControl/PublishTab1.ascx" TagName="PublishTab" TagPrefix="uc2" %>
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
  <div class="admin_topbg"></div>
  <div class="admin_middlebg">
  <div class="container">

<div id="admin_menu">
    <uc2:PublishTab ID="PublishTab1" runat="server" tab="1" FunctionName="News"  isCloseFileTab="false" isCloseImageTab="true" isCloseLinkTab="true"   />
    



<div class="search" id="admin_menu">
<table class="admin_table " >
<tr>
<th width="18%"> <asp:Label ID="lbltitle" runat="server" AssociatedControlID="title">主　　題</asp:Label> </th>
<td> <asp:TextBox
                ID="title" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'標題必填'}}}"></asp:TextBox> </td>

</tr>
<tr>
<th width="18%"> <asp:Label ID="lblinitDate" runat="server" AssociatedControlID="initDate">張貼時間</asp:Label> </th>
<td class="datepicker"><asp:TextBox ID="initDate" runat="server" Width="250px"></asp:TextBox> </td>


</tr>

<tr>
<th width="18%"> <asp:Label ID="lblstartDate" runat="server" AssociatedControlID="startDate" CssClass="{validate:{required:true, messages:{required:'開始日期必填'}}}">開始日期</asp:Label> </th>
<td class="datepicker"><asp:TextBox
                ID="startDate" runat="server" Width="250px"></asp:TextBox> </td>
</tr>


<tr>
<th width="18%">  <asp:Label ID="lblendDate" runat="server" AssociatedControlID="endDate">結束日期</asp:Label></th>
<td class="datepicker">   <asp:TextBox
                ID="endDate" runat="server" Width="250px" CssClass="{validate:{date:true, messages:{date:'結束日期格式不正確'}}}"></asp:TextBox>
            (不設定代表永遠生效)</td>


<tr>
<th width="18%" valign="top"> <asp:Label ID="lblarticle" runat="server" AssociatedControlID="article">詳細內容</asp:Label> </th>
<td> <asp:TextBox ID="article" Height="250px" MaxLength="500" Width="450px" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox> </td>
</tr>
</table>

</div>
        
        <%--不顯示欄位--%>
         <asp:Panel ID="pnlHidden" runat="server" Visible="false">
         <div style="display: inherit" class="max">
            <asp:Label ID="lblshortDescription" runat="server" AssociatedControlID="shortDescription">請扼要說明內容<br />(500字以內，用於列表，文字瀏覽器與索引使用)</asp:Label>
            <asp:TextBox ID="shortDescription" runat="server" Width="450px" TextMode="MultiLine"
                Height="250px" MaxLength="500" CssClass="{validate:{required:true, messages:{required:'必填'}}}"></asp:TextBox></div>

         <div style="display: inherit">
            <asp:Label ID="lblclassID" runat="server" AssociatedControlID="ddlClass1">類別</asp:Label>
            <asp:DropDownList ID="ddlClass1" runat="server" DataTextField="className" DataValueField="id">
            </asp:DropDownList>
        </div>
        <div style="display: inherit">
            <asp:Label ID="lblOrgID" runat="server" AssociatedControlID="ddlOrg">機關</asp:Label>
            <asp:DropDownList ID="ddlOrg" runat="server" DataTextField="Name" DataValueField="id">
            </asp:DropDownList>
        </div>
        <div style="display: inherit">
            <asp:Label ID="lblpicUrl" runat="server" AssociatedControlID="picUrlLink">圖片</asp:Label>
            <asp:FileUpload ID="fuPic" runat="server" />
            <asp:HyperLink ID="picUrlLink" runat="server" Target="_blank">檢視圖片</asp:HyperLink>
        </div>
        <div style="display: inherit">
            <asp:Label ID="lblfileUrl" runat="server" AssociatedControlID="fileUrl">檔案</asp:Label><asp:DropDownList
                ID="ddlFile" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                <asp:ListItem>檔案連結</asp:ListItem>
                <asp:ListItem>檔案上傳</asp:ListItem>
            </asp:DropDownList>
            <asp:FileUpload ID="fuFile" runat="server" Visible="False" />
            <asp:TextBox ID="fileUrl" runat="server" Width="250px"></asp:TextBox>
            <asp:HyperLink ID="fileUrlLink" runat="server" Target="_blank">下載檔案</asp:HyperLink>
        </div>
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
            <asp:Label ID="lblcounts" runat="server" AssociatedControlID="counts">點閱數</asp:Label><asp:TextBox
                ID="counts" runat="server" Width="250px" CssClass="{validate:{required:true, number:true, messages:{required:'必填', number:'須為數字'}}}"></asp:TextBox></div>
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
      <div class="footer_button">
            <asp:Button ID="InsertButton" runat="server" Text="確定" CssClass="button btn_small" OnClick="InsertButton_Click">
            </asp:Button>
            <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>'" type="button"
                value="回列表" class="button btn_small" />
        </div>
        <div>
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
    </fieldset>
</div>
</div>
    </div>
<div class="admin_bottombg"> </div>
</div>
</div>

</asp:Content>
