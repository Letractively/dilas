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

public partial class DilasAdmin_Student_Student_View : System.Web.UI.Page
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

            }
            Show();
        }
        
    }

    private void Show()
    {
        DataRow row = _people.FillPlaceHolderControlsById(Request["id"]);
        if (row == null) return;
        myPhoto.ImageUrl = row["myPhoto"].ToString() == "" ? (row["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, row["id"], row["myPhoto"]);

        gender.Text = gender.Text.ToScodeGenderName();

        DStudent dStudent = new DStudent(Request["id"]);
        telephone_id.Text = dStudent.Phone;
        address_id.Text = dStudent.Address;
        username.Text = dStudent.Account;
        emailAddress.Text = dStudent.Email;
        schoolName.Text = dStudent.SchoolName;
        gradeName.Text = dStudent.GradeAllName;
        enable.Text = enable.Text.ToScodeEnableName();
        description.Text = My.WebForm.TXT2HTML(description.Text);
        studentNumber.Text = dStudent.StudentNumber;
        seatNumber.Text = dStudent.SeatNumber;

        StudentName.Text = row["name"].ToString();
       
    }
}