<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="TodayLesson.aspx.cs" Inherits="DilasUser_PrepareLesson_TodayLesson_" %>

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
            <div class="day_topbg">
            </div>
            <div class="admin_middlebg">
                <div class="day_h1">
                    <asp:Label ID="lblROCDate" runat="server" Text="Label"></asp:Label>
                </div>
                <div style="display: inherit; text-align: left; margin:0 0 10px 0">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtDate">日期：</asp:Label><asp:TextBox
                        ID="txtDate" runat="server" Width="100px"  CssClass="datepicker"></asp:TextBox>
                    <asp:Button ID="btnView" runat="server" CssClass="btn_small" Text="檢視其他日期課表" OnClick="btnView_Click" />
                </div>
                <!--迴圈開始 -->
                <asp:Repeater ID="RepeaterLesson" runat="server" OnItemDataBound="RepeaterLesson_ItemDataBound">
                    <ItemTemplate>
                        <div class="day">
                            <div class="day_class">
                                <em class="day_number">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("SectionIndex_id") %>'></asp:Label>.</em>
                                <span class="day_name">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("courseSubjectName") %>'></asp:Label></span>
                                <asp:Repeater ID="repFiles" runat="server">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "~/UploadFiles/Files/" + Eval("fileUrl") %>'
                                            Text='<%# Eval("fileName") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="day_teacher">
                           
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") + (Eval("name").ToString()==""?"": "老師") %>'></asp:Label>
                            </div>
                            <asp:HiddenField ID="hidID" runat="server" Value='<%# Eval("id") %>' />
                            <asp:Repeater ID="repItem" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("subject") %>'></asp:Label>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div style="margin:5px 0;padding:0 0 0 25px;">
                                <asp:Label ID="Label4" runat="server" Text="課程備註：" Visible='<%# Eval("description").ToString() != "" %>'></asp:Label><asp:Label ID="description" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                            </div>
                            <div style="margin:5px 0;padding:0 0 0 25px">
                                <asp:Label ID="Label5" runat="server" ForeColor="red" Text="重要事項：" Visible='<%# Eval("importantDescription").ToString() != "" %>'></asp:Label>
                                <asp:Label ID="importantDescription" ForeColor="red" runat="server" Text='<%# Eval("importantDescription") %>'></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!--迴圈結束 -->
            </div>
            <div class="admin_bottombg">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
