<%@ WebHandler Language="C#" Class="ModifyPassword" %>

using System;
using System.Web;
using System.Web.Security;
using TIN;

public class ModifyPassword : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        EasyDataProvide Account = new EasyDataProvide("Account");
        Account.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(context.Request["password"], "MD5"));
        Account.AddParameter("people_id", context.Request["id"]);
        Account.Update("people_id=@people_id");     
        context.Response.Write("密碼修改成功！！");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}