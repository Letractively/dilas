using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Grade_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Person person = new Person();

            if (person.Role != Person.LoginRole.Teacher)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        EasyDataProvide Account = new EasyDataProvide("Account");
        Account.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"));
        Account.AddParameter("people_id", Request["people_id"]);
        Account.Update("people_id=@people_id");
        My.WebForm.doJavaScript("alert('修改成功');parent.tb_remove()");
    }
}