<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddressBook_Detail.aspx.cs" Inherits="DilasUser_Grade_AddressBook_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
    <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>" rel="stylesheet" type="text/css" />
   <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSure').click(function () {
                if ($("#password").val() == "") return;
                $.get('../../ashx/ModifyPassword.ashx', { password: $("#password").val(), id: $('#hidPeople_id').val() }, function (data) {
                    $("#Message").text(data);
                    $("#password").val('');
                });
            });

        });
           
            
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            var ID = $('#hidPeople_id').val();
            $('#btnSure').attr("onclick", "tb_show('變更學生密碼','ChangePassword.aspx?KeepThis=true&people_id=" + ID + "&TB_iframe=true&height=200&width=400','thickbox')");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
  <div class="phonebook_photo">
   <div class="phonebook_s_1"></div>
    <div class="phonebook_s_2"> <asp:Image ID="myPhoto" runat="server" />
    </div>
  </div>
  <div class="pb_name">
  <asp:Label
                    ID="name" runat="server"></asp:Label> <asp:HiddenField ID="username" runat="server" />
            
  </div>
  <div class="pb_x ac">
   <div class="pb_left">性別</div>
   <div class="pb_right"><asp:Label
                    ID="gender" runat="server"></asp:Label></div>
   <div class="clear"></div>
  </div>
  <div class="pb_number ac">
   <div class="pb_left">座號</div>
   <div class="pb_right"> <asp:Label ID="studentNumber" runat="server"></asp:Label></div>
   <div class="clear"></div>
  </div>
  <div class="pb_home ad">
   <div class="pb_left">住宅電話</div>
   <div class="pb_right"> <asp:Label ID="telephone_id" runat="server"></asp:Label></div>
   <div class="clear"></div>
  </div>

  <div class="pb_adress ad">
   <div class="pb_left">住　　址</div>
   <div class="pb_right ae"><asp:Label ID="address_id" runat="server"></asp:Label></div>
   <div class="clear"></div>
  </div>
  <div class="pb_email ad">
   <div class="pb_left">E&nbsp;-&nbsp;Mail</div>
   <div class="pb_right"> <asp:Label ID="emailAddress" runat="server"></asp:Label></div>
   <div class="clear"></div>
  </div>
  <div class="pb_note ad" style="border:none; text-align:center">
 <asp:Panel ID="plPassword" runat="server" Visible="false">
                
              
 <input id="btnSure" type="button" value="變更學生密碼" class="btn_small" />
                   <%-- <input id="password" type="password" />--%>
                    <asp:HiddenField ID="hidPeople_id" runat="server" ClientIDMode="Static" />
   <div class="clear"></div>
</asp:Panel>
  </div>
<div style="display:none"><asp:Label
                    ID="birthday" runat="server"></asp:Label> <asp:Label ID="seatNumber" runat="server"></asp:Label></div>
 
    
   
  
    </form>
</body>
</html>
