using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        //驗證身份
        if (Page.User.Identity.IsAuthenticated == false)
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person myPerson = new Person();

            DPeople people = new DTeacher(myPerson.people_id);
            DataRow rowPeople = people.GetBaseRow();
            name.Text = rowPeople["name"].ToString();
            schoolName.Text = people.SchoolName;
            myPhoto.ImageUrl = rowPeople["myPhoto"].ToString() == "" ? (rowPeople["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, rowPeople["id"], rowPeople["myPhoto"]);


            switch (myPerson.Role)
            {
                case Person.LoginRole.Teacher:
                    imgH1.ImageUrl = "~/img/h1_teacher.jpg";
                    pnlteacher.Visible = true;
                    break;
                case Person.LoginRole.Student:
                    imgH1.ImageUrl = "~/img/h1_student.jpg";
                    pnlStudent.Visible = true;

                    DStudent student = new DStudent(myPerson.people_id);
                  
                    GradeName.Text = student.GradeAllName;
                    seatNumber.Text = student.SeatNumber;
                    lblseatNumber.Visible = true;
                    break;
                case Person.LoginRole.Parent:
                    imgH1.ImageUrl = "~/img/h1_Parent.jpg";
                    pnlParent.Visible = true;
                    break;


                case Person.LoginRole.SchoolAdmin:
                    imgH1.ImageUrl = "~/img/h1_schooladmin.jpg";
                    pnlSchoolAdmin.Visible = true;

                   
                    break;
                case Person.LoginRole.Administrator:
                    imgH1.ImageUrl = "~/img/h1_administrator.jpg";
                    pnlAdministrator.Visible = true;
                    break;
            }

        }
    }
    
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/Default.aspx");
    }
}
