<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 應用程式啟動時執行的程式碼
        RegisterRoutes(RouteTable.Routes);

    }
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Default", "Default", "~/Default.aspx");
        routes.MapPageRoute("Ready", "Ready", "~/Ready.aspx");
        //A01Permission
        routes.MapPageRoute("Permission", "Permission/list/{ModuleID}", "~/A01Permission/Account.aspx");
        routes.MapPageRoute("ADDAccount", "Permission/ADDAccount/{ModuleID}", "~/A01Permission/ADDAccount.aspx");
        routes.MapPageRoute("ADDRole", "Permission/ADDRole/{ModuleID}", "~/A01Permission/ADDRole.aspx");
        routes.MapPageRoute("UpdateAccount", "Permission/EditAccount/{ModuleID}/{AccountID}", "~/A01Permission/UpdateAccount.aspx");
        routes.MapPageRoute("UpdateRole", "Permission/EditRole/{ModuleID}/{RoleID}", "~/A01Permission/UpdateRole.aspx");
        routes.MapPageRoute("RoleMapping", "Permission/RoleMapping/{ModuleID}/{RoleID}", "~/A01Permission/RoleMapping.aspx");

  

        //D02Shortcut
        routes.MapPageRoute("Shortcut", "Shortcut/list/{ModuleID}/{*OrgID}", "~/D02Shortcut/Shortcut_List.aspx");
        routes.MapPageRoute("ShortcutInsert", "Shortcut/Insert/{ModuleID}/{*OrgID}", "~/D02Shortcut/Shortcut_Insert.aspx");
        routes.MapPageRoute("ShortcutEdit", "Shortcut/Edit/{ModuleID}/{ID}", "~/D02Shortcut/Shortcut_Edit.aspx");

        //D03Download
        routes.MapPageRoute("HomeDownload", "HomeDownload/list/{ModuleID}/{*OrgID}", "~/D03HomeDownload/Download_List.aspx");
        routes.MapPageRoute("HomeDownloadInsert", "HomeDownload/Insert/{ModuleID}/{*OrgID}", "~/D03HomeDownload/Download_Insert.aspx");
        routes.MapPageRoute("HomeDownloadEdit", "HomeDownload/Edit/{ModuleID}/{ID}", "~/D03HomeDownload/Download_Edit.aspx");
        routes.MapPageRoute("HomeDownloadArticles", "HomeDownload/EditArticles/{ModuleID}/{ID}", "~/D03HomeDownload/_homeDownload_Articles.aspx");
        routes.MapPageRoute("HomeDownloadFiles", "HomeDownload/EditFiles/{ModuleID}/{ID}", "~/D03HomeDownload/_homeDownload_Files.aspx");

        //D04AboutLink
        routes.MapPageRoute("AboutLink", "AboutLink/list/{ModuleID}", "~/D04AboutLink/AboutLink_List.aspx");
        routes.MapPageRoute("AboutLinkInsert", "AboutLink/Insert/{ModuleID}", "~/D04AboutLink/AboutLink_Insert.aspx");
        routes.MapPageRoute("AboutLinkEdit", "AboutLink/Edit/{ModuleID}/{ID}", "~/D04AboutLink/AboutLink_Edit.aspx");
        //D05Banner
        routes.MapPageRoute("PageBanner", "PageBanner/list/{ModuleID}/{*OrgID}", "~/D05Banner/PageBanner_List.aspx");
        routes.MapPageRoute("PageBannerInsert", "PageBanner/Insert/{ModuleID}/{*OrgID}", "~/D05Banner/PageBanner_Insert.aspx");
        routes.MapPageRoute("PageBannerEdit", "PageBanner/Edit/{ModuleID}/{ID}", "~/D05Banner/PageBanner_Edit.aspx");
        //D06Skin
        routes.MapPageRoute("Skin", "Skin/list/{ModuleID}/{*OrgID}", "~/D06Skin/Skin_List.aspx");
        //D07SubStation
        routes.MapPageRoute("SubStation", "SubStation/list/{ModuleID}/{*OrgID}", "~/D07SubStation/SubStation_List.aspx");
        routes.MapPageRoute("SubStationInsert", "SubStation/Insert/{ModuleID}/{*OrgID}", "~/D07SubStation/SubStation_Insert.aspx");
        routes.MapPageRoute("SubStationEdit", "SubStation/Edit/{ModuleID}/{ID}", "~/D07SubStation/SubStation_Edit.aspx");

        //D08Division
        routes.MapPageRoute("Division", "Division/list/{ModuleID}/{*OrgID}", "~/D08Division/Division_List.aspx");
        routes.MapPageRoute("DivisionInsert", "Division/Insert/{ModuleID}/{*OrgID}", "~/D08Division/Division_Insert.aspx");
        routes.MapPageRoute("DivisionEdit", "Division/Edit/{ModuleID}/{ID}", "~/D08Division/Division_Edit.aspx");


        //D09Theme
        routes.MapPageRoute("Theme", "Theme/list/{ModuleID}/{*OrgID}", "~/D09Theme/Theme_List.aspx");
        routes.MapPageRoute("ThemeInsert", "Theme/Insert/{ModuleID}/{*OrgID}", "~/D09Theme/Theme_Insert.aspx");
        routes.MapPageRoute("ThemeEdit", "Theme/Edit/{ModuleID}/{ID}", "~/D09Theme/Theme_Edit.aspx");

        //D10Area
        routes.MapPageRoute("Area", "Area/list/{ModuleID}/{*OrgID}", "~/D10Area/Area_List.aspx");
        routes.MapPageRoute("AreaInsert", "Area/Insert/{ModuleID}/{*OrgID}", "~/D10Area/Area_Insert.aspx");
        routes.MapPageRoute("AreaEdit", "Area/Edit/{ModuleID}/{ID}", "~/D10Area/Area_Edit.aspx");
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  應用程式關閉時執行的程式碼

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 發生未處理錯誤時執行的程式碼

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 啟動新工作階段時執行的程式碼

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 工作階段結束時執行的程式碼。 
        // 注意: 只有在 Web.config 檔將 sessionstate 模式設定為 InProc 時，
        // 才會引發 Session_End 事件。如果將工作階段模式設定為 StateServer 
        // 或 SQLServer，就不會引發這個事件。

    }
       
</script>
