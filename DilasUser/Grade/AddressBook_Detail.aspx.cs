using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtensionMethods;
using TIN;

public partial class DilasUser_Grade_AddressBook_Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //驗證身份
        Person person = new Person();
        if (person.Role == Person.LoginRole.Administrator || person.Role == Person.LoginRole.SchoolAdmin || person.Role == Person.LoginRole.Parent)
        {
            Response.Redirect("~/Default.aspx");
        }
        Show();
    }
    private void Show()
    {
        EasyDataProvide People = new EasyDataProvide("People");

        DataRow row = People.FillPageControlsById(Request["id"]);
        if (row == null) return;

        gender.Text = gender.Text.ToScodeGenderName();

        DStudent dStudent = new DStudent(Request["id"]);
        telephone_id.Text = dStudent.Phone;
        address_id.Text = dStudent.Address;
        username.Value = dStudent.Account;
        emailAddress.Text = dStudent.Email;
        studentNumber.Text = dStudent.StudentNumber;
        seatNumber.Text = dStudent.SeatNumber;
        hidPeople_id.Value = Request["id"];
        myPhoto.ImageUrl = row["myPhoto"].ToString() == "" ? (row["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, row["id"], row["myPhoto"]);

        Person person = new Person();
        if (person.Role == Person.LoginRole.Teacher)
        {
            plPassword.Visible = true;
            
        }
        else
        {
            plPassword.Visible = false;
        }
        
    }
    
}