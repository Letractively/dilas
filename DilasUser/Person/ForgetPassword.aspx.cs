using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Person_ForgetPassword : System.Web.UI.Page
{
    private Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        EasyDataProvide Account = new EasyDataProvide("Account");
        Account.AddParameter("username",txtAccount.Text);
        Account.AddParameter("emailAddress", txtEmail.Text);
        DataRow row = Account.GetSingleRow("username=@username and emailAddress=@emailAddress");
        if(row==null)
        {
            lblMessage.Text = "填入資料與資料庫不符，請恰尋學校管理者，謝謝";
            return;
        }
        //取得新密碼
        string newPassword = GenerateRandomCode();
        Account.RemoveParameter("emailAddress");
        Account.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword, "MD5"));
        Account.Update("username=@username");

        //送到信箱

        My.WebForm.doJavaScript("alert('密碼已經寄到您註冊的信箱!')");
    }

    private string GenerateRandomCode()
    {
        string s = "";
        for (int i = 0; i < 4; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        return s;
    }
}