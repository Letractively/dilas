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
    DataLayer _dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
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

            }
            DataTable dtCourseByGrade = _dl.GetTeacherCourseByGradeID(Request["id"]);
            ViewState["CourseByGrade"] = dtCourseByGrade;

            Show();
        }
    }

    private void Show()
    {
        DataTable dt = _dl.GetTimeTableDatabyGradeId(Request["id"]);
        DataList1.DataSource = dt;
        DataList1.DataBind();

        EasyDataProvide Grade = new EasyDataProvide("Grade");
        DataRow row = Grade.GetById(Request["ID"]);
        DGrade dGrade = new DGrade();
        AllName.Text = dGrade.GetFullGradeNameById((int)row["id"]);
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.EditItem)
        {
            DropDownList ddlGradeCourseSubject = (DropDownList)e.Item.FindControl("ddlGradeCourseSubject");
            ddlGradeCourseSubject.DataTextField = "CourseSubjectName";
            ddlGradeCourseSubject.DataValueField = "id";
            DataTable dt = (DataTable)ViewState["CourseByGrade"];
            ddlGradeCourseSubject.DataSource = dt;
            ddlGradeCourseSubject.DataBind();
            DataRowView row = (DataRowView)e.Item.DataItem; //取得繫節過來那一筆DataRow
            if (!string.IsNullOrEmpty(row["GradeCourseSubjectID"].ToString()))
            {
                ddlGradeCourseSubject.SelectedValue = row["GradeCourseSubjectID"].ToString();
            }

           

        }
        if(e.Item.ItemType== ListItemType.Item || e.Item.ItemType== ListItemType.AlternatingItem)
        {
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.Administrator)
            {
                Panel addPan = (Panel)e.Item.FindControl("addPan");
                addPan.Visible = false;

            }
        }
    }
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = e.Item.ItemIndex;
        Show();
    }
    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        //更新到資料庫

        DropDownList ddlGradeCourseSubject = (DropDownList)e.Item.FindControl("ddlGradeCourseSubject");
        if (ddlGradeCourseSubject.Items.Count > 0)
        {
            string id = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            EasyDataProvide TimeTable = new EasyDataProvide("TimeTable");
            TimeTable.AddParameter("grade_id", Request["id"]);
            TimeTable.AddParameter("sectionIndex_id", id);
            TimeTable.Delete("grade_id=@grade_id and sectionIndex_id=@sectionIndex_id");
            TimeTable.AddParameter("gradeCourseSubject_id", ddlGradeCourseSubject.SelectedValue);
            TimeTable.Insert();

        }
        DataList1.EditItemIndex = -1;
        Show();
    }
    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = -1;
        Show();
    }
    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string id = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        EasyDataProvide TimeTable = new EasyDataProvide("TimeTable");
        TimeTable.AddParameter("grade_id", Request["id"]);
        TimeTable.AddParameter("sectionIndex_id", id);
        TimeTable.Delete("grade_id=@grade_id and sectionIndex_id=@sectionIndex_id");

        Show();
    }
}