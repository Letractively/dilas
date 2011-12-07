using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Grade_AddressBook : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();

             if (myPerson.Role == Person.LoginRole.Administrator || myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }
            Show();
        }

    }

    private void Show()
    {
        Person person = new Person();
        DStudent dStudent =new DStudent(person.people_id);
        string GradeId = dStudent.GradeID;
        DGrade dGrade = new DGrade();
        
        if(person.Role == Person.LoginRole.Teacher)
        {
            GradeId = Request["grade_id"];
        }
        lblGradeName.Text = dGrade.GetShortGradeNameById(Convert.ToInt16(GradeId));
        DataTable dt = dl.GetStudentList(person.School_id, GradeId, "", "", "-1", "-1", "-1", "", "order by SeatNumber asc", 70, 1);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
       
    }
}