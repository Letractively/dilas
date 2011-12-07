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

public partial class Teacher_View : System.Web.UI.Page
{
   

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

            }
            Show();
        }
    }

    private void Show()
    {
        EasyDataProvide people = new EasyDataProvide("People");
        DataRow row = people.FillPlaceHolderControlsById(Request["id"]);
        if (row == null) return;
        myPhoto.ImageUrl = row["myPhoto"].ToString() == "" ? (row["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, row["id"], row["myPhoto"]);


        gender.Text = gender.Text.ToScodeGenderName();
        
        DTeacher dTeacher = new DTeacher( Request["id"]);
        telephone_id.Text = dTeacher.Phone;
        address_id.Text = dTeacher.Address;
        rank.Text = dTeacher.Rank;
        username.Text = dTeacher.Account;
        emailAddress.Text = dTeacher.Email;
        schoolName.Text = dTeacher.SchoolName;
        enable.Text = enable.Text.ToScodeEnableName();
        description.Text = My.WebForm.TXT2HTML(description.Text);

        TeacherName.Text = row["name"].ToString();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Teacher_Edit.aspx?id=" + Request["id"]);
    }
}