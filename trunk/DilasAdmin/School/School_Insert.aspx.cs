using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class School_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //驗證身份
        Person myPerson = new Person();
        if (myPerson.Role != Person.LoginRole.Administrator)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {

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

        //新增學校
        EasyDataProvide school = new EasyDataProvide("School");
        school.AddParameter("id",id.Text);
        int i = school.GetRowCount("id=@id");
        if(i>0)
        {
            My.WebForm.doJavaScript("alert('學校編號已經重複!')");
            return;
        }
        school.RemoveParameter("id");
        school.SetPlaceHolderFormQuest();

       
        school.AddParameter("address_id", addressID);
        school.AddParameter("telephone_id", telephoneID);
        school.Insert();
        My.WebForm.doJavaScript("alert('新增成功');location.href='School_List.aspx'");
    }
}