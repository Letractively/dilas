<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="AddressBook.aspx.cs" Inherits="DilasUser_Grade_AddressBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">

    $(document).ready(function () {

        $.ajaxSetup({
            cache: false //关闭AJAX相应的缓存
        });
        
        $('.student').click(function () {
            $('#Xfile').load("AddressBook_Detail.aspx?id=" + $(this).find(':hidden').val());
        });
        $('#Xfile').ajaxStart(function () {
            $("#loading").show();
        });
        $('#Xfile').ajaxStop(function () {
            $("#loading").hide();
        });
$('#Xfile').load("AddressBook_Detail.aspx?id=" + $(".student").eq(0).find(':hidden').val());
    });
    

</script>
<style type="text/css">
.student{ cursor:pointer}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="phonebook">
<div class="phonebook_bg">

<div class="phonebook_in">
 <div class="phonebook_left">

 <h1><asp:Label ID="lblGradeName" runat="server" Text="Label"></asp:Label>通訊錄</h1>
  <div class="phonebook_left_box">

    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>

<div class="phonebook_namelist student"><asp:HiddenField ID="hid" runat="server" Value='<%# Eval("id") %>'  />
   <div class="phonebook_name"><asp:Label ID="lblName" runat="server" Text='<%# Eval("name") %>'></asp:Label></div>
   <div class="phonebook_number"><asp:Label ID="lblSeatNumber" runat="server" Text='<%# Eval("seatNumber")  %>'></asp:Label></div>
   <div class="clear"></div>
  </div>

    </ItemTemplate>
  
    </asp:Repeater>
  

  
  </div>  
  </div>
  <div class="phonebook_right">
<div id="Xfile"></div>

<span id="loading" style=" color:White; background-color:Red; display:none">Loading....</span>
</div>
</div>

</div>
</div>




<div id="admin_menu">
<div style="float: left;width:30%">
    
</div>

<div style="float: right ;width:70%">
<div id="Xfile"></div>
</div>
<span id="loading" style=" color:White; background-color:Red; display:none">Loading....</span>
</div>
</asp:Content>

