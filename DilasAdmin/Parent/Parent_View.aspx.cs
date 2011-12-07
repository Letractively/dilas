using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtensionMethods;
using TIN;

public partial class Parent_View : System.Web.UI.Page
{
    EasyDataProvide _people = new EasyDataProvide("People");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.Teacher || myPerson.Role == Person.LoginRole.Student || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }
            //只有校管才可以停用與編輯

            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                PublishTab1.isOpenEditTab = true;
                PublishTab1.isOpenFun1Tab = true;
                //  btnDisable.Visible = true;
            }
            Show();
        }
    }

    private void Show()
    {

        DataRow row = _people.FillPlaceHolderControlsById(Request["id"]);
        if (row == null) return;
        myPhoto.ImageUrl = row["myPhoto"].ToString() == "" ? (row["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, row["id"], row["myPhoto"]);


        gender.Text = SCode.ToScodeGenderName(gender.Text);
      //  btnDisable.Text = SCode.GetDisableButtonName(row["disable"].ToString());
        DParent dParent = new DParent(Request["id"]);
        telephone_id.Text = dParent.Phone;
        address_id.Text = dParent.Address;
        occupation.Text = dParent.Occupation;
        username.Text = dParent.Account;
        emailAddress.Text = dParent.Email;
        schoolName.Text = dParent.SchoolName;
        enable.Text = enable.Text.ToScodeEnableName();
        description.Text = My.WebForm.TXT2HTML(description.Text);

        ParentName.Text = row["name"].ToString();
    }
    /*
    protected void btnDisable_Click(object sender, EventArgs e)
    {
        _people.AddParameter("disable", btnDisable.Text == "按我啟用" ? "False" : "True");
        _people.UpdateById(Request["id"]);
        Show();
        My.WebForm.doJavaScript(btnDisable.Text == "按我啟用" ? "alert('停用成功');" : "alert('啟用成功');");
    }
     */
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Parent_Edit.aspx?id=" + Request["id"]);
    }
}