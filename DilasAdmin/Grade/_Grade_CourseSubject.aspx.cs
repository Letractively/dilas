using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasAdmin_Grade_Grade_CourseSubject : System.Web.UI.Page
{
    DataLayer _dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.Teacher || myPerson.Role == Person.LoginRole.Student || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                PublishTab1.isOpenEditTab = true;
                //addPan.Visible = true;
                gvList.Columns[gvList.Columns.Count - 1].Visible = true;

                EasyDataProvide Grade = new EasyDataProvide("Grade");
                DataRow row = Grade.GetById(Request["id"]);
                if (row == null) return;
                ViewState["currentYear"] = row["currentYear"].ToString();
                ShowTeacher();
                ShowCourseSubject();
            }




            Show();
        }
    }

    private void ShowCourseSubject()
    {
        DataTable dt = _dl.GetCourseFullName(ViewState["currentYear"].ToString(), "-1", "and school_id=@school_id and id not in(select courseSubject_id from dbo.GradeCourseSubject where grade_id=@searchId)", Request["id"], (new Person()).School_id);
        ddlCourseSubject.DataTextField = "fullName";
        ddlCourseSubject.DataValueField = "id";
        ddlCourseSubject.DataSource = dt;
        ddlCourseSubject.DataBind();
        addPan.Visible = dt.Rows.Count > 0;
    }

    private void ShowTeacher()
    {

        DataTable dt = _dl.GetTeacherByGradeID(Request["id"]);
        ddlTeacher.DataTextField = "name";
        ddlTeacher.DataValueField = "teacher_id";
        ddlTeacher.DataSource = dt;
        ddlTeacher.DataBind();
    }
    private void Show()
    {
        DataTable dt = _dl.GetTeacherCourseByGradeID(Request["id"]);

        gvList.DataSource = dt;
        gvList.DataBind();
        EasyDataProvide Grade = new EasyDataProvide("Grade");
        DataRow row = Grade.GetById(Request["ID"]);
        DGrade dGrade = new DGrade();
        AllName.Text = dGrade.GetFullGradeNameById((int)row["id"]);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlCourseSubject.Items.Count > 0)
        {
            EasyDataProvide GradeCourseSubject = new EasyDataProvide("GradeCourseSubject");
            GradeCourseSubject.AddParameter("courseSubject_id", ddlCourseSubject.SelectedValue);
            GradeCourseSubject.AddParameter("grade_id", Request["id"]);
            GradeCourseSubject.AddParameter("teacher_id", ddlTeacher.SelectedValue);
            GradeCourseSubject.Insert();
            Response.Redirect(Request.Url.ToString());
        }

    }


    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = gvList.DataKeys[e.RowIndex].Value.ToString();


        //判斷預設課表是否有使用
        EasyDataProvide TimeTable = new EasyDataProvide("TimeTable");

        TimeTable.AddParameter("gradeCourseSubject_id", ID);
        int total = TimeTable.GetRowCount("gradeCourseSubject_id=@gradeCourseSubject_id");
        if (total > 0)
        {
            My.WebForm.doJavaScript("alert('預設課表已使用此課程！不可刪除！');");
            return;
        }


        EasyDataProvide GradeCourseSubject = new EasyDataProvide("GradeCourseSubject");

        GradeCourseSubject.DeleteById(ID);
        Response.Redirect(Request.Url.ToString());
    }
}