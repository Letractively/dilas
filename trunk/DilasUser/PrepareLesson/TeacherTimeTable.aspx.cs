using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;
public partial class DilasAdmin_Grade_Grade_DefaultTimeTable : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.Administrator || myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Student || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }
            DataLayer dl = new DataLayer();
            DataTable dtCourseByGrade = dl.GetTeacherCourseByGradeID(Request["grade_id"]);
            ViewState["CourseByGrade"] = dtCourseByGrade;

            Show();
        }
    }

    private void Show()
    {
        DataLayer dl = new DataLayer();
        DataTable dt = dl.GetTimeTableDatabyGradeId(Request["grade_id"]);
        DataList1.DataSource = dt;
        DataList1.DataBind();
        
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
             Person myPerson = new Person();
            HiddenField hidPeople = (HiddenField)e.Item.FindControl("hidPeople");
            HyperLink hlCourseSubjectName = (HyperLink)e.Item.FindControl("hlCourseSubjectName");
            Label lblCourseSubjectName = (Label)e.Item.FindControl("lblCourseSubjectName");

            if(hidPeople.Value == myPerson.people_id )
            {
                hlCourseSubjectName.Visible = true;
                lblCourseSubjectName.Visible = false;
            }
        }
    }
   
}