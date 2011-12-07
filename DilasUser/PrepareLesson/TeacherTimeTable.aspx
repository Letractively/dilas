<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="TeacherTimeTable.aspx.cs" Inherits="DilasAdmin_Grade_Grade_DefaultTimeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
    //上方列
        $('<tr><td class="class_th">禮拜一</td><td class="class_th">禮拜二</td><td class="class_th">禮拜三</td><td class="class_th">禮拜四</td><td class="class_th">禮拜五</td></tr>').insertBefore('.main tbody tr:eq(0)');
        
        
        
        //左邊列
        $('<td class="class_th"></td>').insertBefore('.main tbody tr td:eq(0)');
        $('<td class="class_th">第一節</td>').insertBefore('.main tbody tr td:eq(6)');
        $('<td class="class_th">第二節</td>').insertBefore('.main tbody tr td:eq(12)');
        $('<td class="class_th">第三節</td>').insertBefore('.main tbody tr td:eq(18)');
        $('<td class="class_th">第四節</td>').insertBefore('.main tbody tr td:eq(24)');
        $('<td class="class_th">第五節</td>').insertBefore('.main tbody tr td:eq(30)');
        $('<td class="class_th">第六節</td>').insertBefore('.main tbody tr td:eq(36)');
        $('<td class="class_th">第七節</td>').insertBefore('.main tbody tr td:eq(42)');
        $('<td class="class_th">第八節</td>').insertBefore('.main tbody tr td:eq(48)');
    });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  




<div class="admin">
<div class="admin_bg">
  <div class="admin_topbg admin_curriculum"></div>
  <div class="admin_middlebg">
  <div class="container">
<h1>備課管理</h1>

<div class="edit_table">

 <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" DataKeyField="id" 
        OnItemDataBound="DataList1_ItemDataBound" CssClass="Main">
            <ItemTemplate>
              
             

                    <asp:HyperLink ID="hlCourseSubjectName" runat="server"  Text='<%# Eval("CourseSubjectName")%>' NavigateUrl='<%#"PrepareLesson.aspx?timetable_id="+ Eval("timetable_id") +"&sectionIndex_id=" + Eval("sectionIndex_id") + "&CourseSubjectName=" + Server.UrlEncode(Eval("CourseSubjectName").ToString())  %>' Visible="False">
                    
</asp:HyperLink>
 <asp:Label ID="lblCourseSubjectName" runat="server" Text='<%# Eval("CourseSubjectName")%>'></asp:Label>
    <br/>
 <asp:Label ID="lblteacherName" runat="server" Text='<%# Eval("teacherName")%>'></asp:Label>
                    <asp:HiddenField ID="hidPeople" runat="server"  Value='<%# Eval("people_id")%>' />
                   <br/>
                        
            
           
                    
                </div>
            </ItemTemplate>
            
        </asp:DataList>
</div>

</div>
</div>
<div class="admin_bottombg"> </div>
</div>
</div>
</asp:Content>
