<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true"
    CodeFile="Discusses_Students_List.aspx.cs" Inherits="DilasUser_Discusses_Discusses_Students_List" %>

<%@ Register TagPrefix="uc1" TagName="Pagination" Src="~/UserControl/Pagination.ascx" %>
<%@ Import Namespace="ExtensionMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script type="text/javascript" src="<%= Page.ResolveUrl(@"~/js/thickbox.js") %>"></script>
 <link href="<%= Page.ResolveUrl(@"~/css/thickbox.css") %>" rel="stylesheet"   type="text/css" />
 <script type="text/javascript">
     $(document).ready(function () {
         $(".paint_more").click(function () {
             $(this).next("div").toggle();
             $(".paint").tinyscrollbar();
         });
     });
           
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--賈斯汀從這裡開始抓全部 開始 -->
    <div class="board">
        <div class="paint">
            <div class="scrollbar">
                <div class="track">
                    <div class="thumb">
                        <div class="end">
                        </div>
                    </div>
                </div>
            </div>
            <div class="paint_box viewport">
                <div class="paint_in overview">
                    <!--迴圈開始 賈斯汀要抓的整體迴圈 -->
                    <!--第一則主題 開始 -->
                    <asp:Repeater ID="gvList" runat="server" OnItemDataBound="gvList_ItemDataBound">
                        <ItemTemplate>
                            <div class="paint_inbox">
                                <!--發文者 開始 -->
                                <div class="paint_post">
                                    <div class="paint_post_img">
                                        <asp:Image ID="myPhoto" runat="server" ImageUrl='<%#  Eval("myPhoto").ToString()!="" ?(("M" + Eval("myPhoto")).ToString().ToScodeBookCaseURL((new Person()).School_id,Eval("poster").ToString())):Eval("gender").ToString()=="True"?"~/images/Male90x85.jpg":"~/images/FeMale90x85.jpg"  %>' />
                                      
                                    </div>
                                    <div class="paint_post_word">
                                        <h1>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>'></asp:Label></h1>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/UploadFiles/Images/" + Eval("picUrl") %>'
                                            Visible='<%# Eval("picUrl").ToString() != "" %>' />
                                        <p>
                                            <h2>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                                            </h2>
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# My.WebForm.TXT2HTML(Eval("shortDescription").ToString())  %>'></asp:Literal>
                                        </p>
                                        <div class="clear">
                                        </div>
                                        <div class="paint_download">
                                            <asp:Repeater ID="repFiles" runat="server">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "~/UploadFiles/Files/" + Eval("fileUrl") %>'
                                                        Text='<%# Eval("fileName") %>'></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:HiddenField ID="hidID" runat="server" Value='<%# Eval("id") %>' />
                                        </div>
                                        <div class="paint_time">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("initDate", "{0:d}") %>'></asp:Label></div>
                                    </div>
                                </div>
                                <!--發文者結束 -->
                                <!--達10人發文者顯示 開始-->
                                <div class="paint_more">
                                    展開全部<%# Eval("articleCount") %>則留言 <a style="text-decoration:underline" href="<%# String.Format("Discusses_Students_Reply.aspx?id={0}&KeepThis=true&TB_iframe=true&height=400&width=600", Request["ID"], Request["ModuleID"]) %>" title="回覆留言" class="thickbox a_btn" >回覆留言</a></div>
                                <!--達10人發文者顯示 結束 -->
                                <div style="display:inherit">
                                <asp:Repeater ID="repReply" runat="server">
                                    <ItemTemplate>
                                        <div class="paint_re">
                                            <div class="paint_re_img">
                                                <asp:Image ID="myPhoto1" runat="server" ImageUrl='<%# ("M" + Eval("myPhoto")).ToString().ToScodeBookCaseURL((new Person()).School_id,Eval("poster").ToString())  %>' /></div>
                                            <div class="paint_re_word">
                                                <h1>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>'></asp:Label></h1>
                                                <p>
                                                   <asp:Label ID="Label4" runat="server" Text='<%# Eval("article") %>'></asp:Label></p>
                                                <div class="clear">
                                                </div>
                                                <div class="paint_time">
                                                   <asp:Label ID="Label3" runat="server" Text='<%# Bind("initDate", "{0:d}") %>'></asp:Label></div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                </div>
                                
                                <div class="clear">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <uc1:Pagination ID="Pagination1" runat="server" />
                    <!--第一則主題 結束 -->
                    <!--迴圈結束 賈斯汀要抓的整體迴圈 -->
                </div>
            </div>
        </div>
    </div>
    <!--賈斯汀從這裡抓全部 結束 -->
</asp:Content>
