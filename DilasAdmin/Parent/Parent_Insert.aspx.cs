using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Parent_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Person myPerson = new Person();

            //校管只能找自己學校//總管可以找全部
            if (myPerson.Role != Person.LoginRole.SchoolAdmin)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
        protected void InsertButton_Click(object sender, EventArgs e)
    {
        //檢查帳號是否重複
        EasyDataProvide Account = new EasyDataProvide("Account");
        Account.AddParameter("username", username.Text);
        DataRow rowCheck = Account.GetSingleRow("username=@username");
        if (rowCheck != null)
        {
            My.WebForm.doJavaScript("alert('帳號已經存在')");
            return;
        }

        string peopleId = Guid.NewGuid().ToString();
        //新增地址
        EasyDataProvide Address = new EasyDataProvide("Address");
        Address.AddParameter("city", Request["city"]);
        Address.AddParameter("division", Request["division"]);
        Address.AddParameter("zip", Request["zip"]);
        Address.AddParameter("address", address.Value);
        string addressID = Address.InsertReturnValue();

        //新增電話
        EasyDataProvide Telepone = new EasyDataProvide("Telephone");
        Telepone.AddParameter("areaCode", areaCode.Value);
        Telepone.AddParameter("numberCode", numberCode.Value);
        string telephoneID = Telepone.InsertReturnValue();

        //新增Pepole
        EasyDataProvide People = new EasyDataProvide("People");
        People.SetPlaceHolderFormQuest();
        People.AddParameter("id", peopleId);
        People.AddParameter("address_id", addressID);
        People.AddParameter("telephone_id", telephoneID);
        People.AddParameter("role", "2");
        People.Insert();

        //新增Parent
        EasyDataProvide Parent = new EasyDataProvide("Parent");

        Parent.AddParameter("id", peopleId);
        Parent.SetPlaceHolderFormQuest();
        Parent.Insert();

        //新增People_School
        EasyDataProvide People_School = new EasyDataProvide("People_School");
        People_School.AddParameter("people_id", peopleId);
        People_School.AddParameter("school_id", (new Person()).School_id);
        People_School.Insert();

        //新增帳號
        Account.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"));
        Account.AddParameter("emailAddress", emailAddress.Text);

        Account.AddParameter("people_id", peopleId);
        Account.AddParameter("id", Guid.NewGuid().ToString());
        Account.Insert();

        My.WebForm.doJavaScript("alert('新增成功');location.href='Parent_List.aspx'");
    }
}