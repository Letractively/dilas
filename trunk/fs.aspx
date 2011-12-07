<%@ Page Language="VB" AutoEventWireup="false" CodeFile="fs.aspx.vb" Inherits="fs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <FONT face=新細明體><asp:textbox id=txtPhysicalApplicationPath runat="server" Width="520px"></asp:textbox><asp:Button id=btnMove runat="server" Text="<-"></asp:Button><BR><INPUT 
id=txtPersonFile type=file name=File1 runat="server"><asp:Button id=btnUpdateFile runat="server" Text="go"></asp:Button><asp:Label id=lblUpdateFileErr runat="server" ForeColor="Red"></asp:Label><asp:datagrid id=dgFileSystem runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" DataKeyField="Name">
<Columns>
<asp:TemplateColumn>
<ItemTemplate>
<asp:Image id=Image1 runat="server" ImageUrl='<%# iif(DataBinder.Eval(Container, "DataItem.Type")=0,"images/folder.gif","images/html.gif") %>'></asp:Image>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<ItemTemplate>
<asp:LinkButton id=LinkButton1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name").Replace(txtPhysicalApplicationPath.Text, "") %>' CommandName="Edit"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
</asp:datagrid></FONT>
    </div>
    </form>
</body>
</html>

