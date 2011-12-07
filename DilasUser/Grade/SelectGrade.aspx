﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="SelectGrade.aspx.cs" Inherits="DilasUser_Grade_SelectGrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_contacts"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>選擇班級</h1>

<asp:DataList ID="DataList1" runat="server" RepeatColumns="5" CssClass="select_class">


            <ItemTemplate>

 <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "AddressBook.aspx?grade_id=" + Eval("grade_id") %>'
                                    Text='<%# Eval("GradeFullName") %>'>
                                </asp:HyperLink>
                          <br />

                           
            </ItemTemplate>

        </asp:DataList>



</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>


    </asp:Content>
