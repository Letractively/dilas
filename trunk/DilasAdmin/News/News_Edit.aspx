<%@ Page  ValidateRequest="false"  Title="�s��̷s�ʺA" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
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
<th width="18%"> <asp:Label ID="lbltitle" runat="server" AssociatedControlID="title">�D�@�@�D</asp:Label> </th>
<td> <asp:TextBox
                ID="title" runat="server" Width="250px" CssClass="{validate:{required:true, messages:{required:'���D����'}}}"></asp:TextBox> </td>

</tr>
<tr>
<th width="18%"> <asp:Label ID="lblinitDate" runat="server" AssociatedControlID="initDate">�i�K�ɶ�</asp:Label> </th>
<td class="datepicker"><asp:TextBox ID="initDate" runat="server" Width="250px"></asp:TextBox> </td>


</tr>

<tr>
<th width="18%"> <asp:Label ID="lblstartDate" runat="server" AssociatedControlID="startDate" CssClass="{validate:{required:true, messages:{required:'�}�l�������'}}}">�}�l���</asp:Label> </th>
<td class="datepicker"><asp:TextBox
                ID="startDate" runat="server" Width="250px"></asp:TextBox> </td>
</tr>


<tr>
<th width="18%">  <asp:Label ID="lblendDate" runat="server" AssociatedControlID="endDate">�������</asp:Label></th>
<td class="datepicker">   <asp:TextBox
                ID="endDate" runat="server" Width="250px" CssClass="{validate:{date:true, messages:{date:'��������榡�����T'}}}"></asp:TextBox>
            (���]�w�N��û��ͮ�)</td>


<tr>
<th width="18%" valign="top"> <asp:Label ID="lblarticle" runat="server" AssociatedControlID="article">�ԲӤ��e</asp:Label> </th>
<td> <asp:TextBox ID="article" Height="250px" MaxLength="500" Width="450px" runat="server" CssClass="ckeditor" TextMode="MultiLine"></asp:TextBox> </td>
</tr>
</table>

</div>
        
        <%--��������--%>
         <asp:Panel ID="pnlHidden" runat="server" Visible="false">
         <div style="display: inherit" class="max">
            <asp:Label ID="lblshortDescription" runat="server" AssociatedControlID="shortDescription">�Ч�n�������e<br />(500�r�H���A�Ω�C��A��r�s�����P���ިϥ�)</asp:Label>
            <asp:TextBox ID="shortDescription" runat="server" Width="450px" TextMode="MultiLine"
                Height="250px" MaxLength="500" CssClass="{validate:{required:true, messages:{required:'����'}}}"></asp:TextBox></div>

         <div style="display: inherit">
            <asp:Label ID="lblclassID" runat="server" AssociatedControlID="ddlClass1">���O</asp:Label>
            <asp:DropDownList ID="ddlClass1" runat="server" DataTextField="className" DataValueField="id">
            </asp:DropDownList>
        </div>
        <div style="display: inherit">
            <asp:Label ID="lblOrgID" runat="server" AssociatedControlID="ddlOrg">����</asp:Label>
            <asp:DropDownList ID="ddlOrg" runat="server" DataTextField="Name" DataValueField="id">
            </asp:DropDownList>
        </div>
        <div style="display: inherit">
            <asp:Label ID="lblpicUrl" runat="server" AssociatedControlID="picUrlLink">�Ϥ�</asp:Label>
            <asp:FileUpload ID="fuPic" runat="server" />
            <asp:HyperLink ID="picUrlLink" runat="server" Target="_blank">�˵��Ϥ�</asp:HyperLink>
        </div>
        <div style="display: inherit">
            <asp:Label ID="lblfileUrl" runat="server" AssociatedControlID="fileUrl">�ɮ�</asp:Label><asp:DropDownList
                ID="ddlFile" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFile_SelectedIndexChanged">
                <asp:ListItem>�ɮ׳s��</asp:ListItem>
                <asp:ListItem>�ɮפW��</asp:ListItem>
            </asp:DropDownList>
            <asp:FileUpload ID="fuFile" runat="server" Visible="False" />
            <asp:TextBox ID="fileUrl" runat="server" Width="250px"></asp:TextBox>
            <asp:HyperLink ID="fileUrlLink" runat="server" Target="_blank">�U���ɮ�</asp:HyperLink>
        </div>
        <div style="display: inherit">
            <asp:Label ID="lbllinkUrl" runat="server" AssociatedControlID="linkUrl">�s��</asp:Label><asp:TextBox
                ID="linkUrl" runat="server" Width="250px"></asp:TextBox>
            <asp:DropDownList ID="linkTarget" runat="server">
                <asp:ListItem Value="_blank">�t�}�s����</asp:ListItem>
                <asp:ListItem Value="_self">�b��e�����}��</asp:ListItem>
            </asp:DropDownList>
            (�~�s���Х[http://)
        </div>
        <div style="display: inherit">
            <asp:Label ID="lbllinkText" runat="server" AssociatedControlID="linkText">�s��������r</asp:Label><asp:TextBox
                ID="linkText" runat="server" Width="250px"></asp:TextBox></div>
        <div style="display: inherit">
            <asp:Label ID="lblcounts" runat="server" AssociatedControlID="counts">�I�\��</asp:Label><asp:TextBox
                ID="counts" runat="server" Width="250px" CssClass="{validate:{required:true, number:true, messages:{required:'����', number:'�����Ʀr'}}}"></asp:TextBox></div>
        <div style="display: inherit">
            <asp:Label ID="lbllistNum" runat="server" AssociatedControlID="listNum">�Ƨ�</asp:Label><asp:TextBox
                ID="listNum" runat="server" Width="250px" CssClass="{validate:{required:true, number:true, messages:{required:'����', number:'�����Ʀr'}}}"></asp:TextBox></div>
        <div style="display: inherit">
            <asp:Label ID="lbleable" runat="server" AssociatedControlID="eable">��ܪ��A</asp:Label>
            <asp:CheckBox ID="eable" runat="server" Text="�O�_���" CssClass="checkbox" Checked="true" /></div>
        <div style="display: inherit">
            <asp:Label ID="lblbeSelect" runat="server" AssociatedControlID="beSelect">beSelect</asp:Label><asp:TextBox
                ID="beSelect" runat="server" Width="250px"></asp:TextBox></div>
        <div style="display: inherit">
            <asp:Label ID="lblstatus" runat="server" AssociatedControlID="status">���A</asp:Label><asp:TextBox
                ID="status" runat="server" Width="250px"></asp:TextBox></div>
       
        </asp:Panel>
      <div class="footer_button">
            <asp:Button ID="InsertButton" runat="server" Text="�T�w" CssClass="button btn_small" OnClick="InsertButton_Click">
            </asp:Button>
            <input onclick="location='News_List.aspx?ModuleID=<%=Request["ModuleID"] %>&page=<%=string.IsNullOrEmpty(Request["page"])?"1":Request["page"] %>'" type="button"
                value="�^�C��" class="button btn_small" />
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
