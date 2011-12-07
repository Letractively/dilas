using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_PrepareLesson_TodayLesson_ : System.Web.UI.Page
{
    DataLayer _dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.Administrator || myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Teacher || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }

            Show();

        }
    }

    private void Show()
    {
        DStudent dStudent = new DStudent((new Person()).people_id);
        string gradeId = dStudent.GradeID;
        string useDate = DateTime.Now.ToShortDateString();
        if (!string.IsNullOrEmpty(txtDate.Text))
        {
            useDate = txtDate.Text;
        }
        lblROCDate.Text = My.WebForm.Date2CrocWeekFormat(Convert.ToDateTime(useDate));
        DataTable dt = _dl.GetClassSessionDataByDay(useDate, gradeId);
        RepeaterLesson.DataSource = dt;
        RepeaterLesson.DataBind();


    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Show();
    }
    protected void RepeaterLesson_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        HiddenField hidID = (HiddenField)e.Item.FindControl("hidID");
        if (!string.IsNullOrEmpty(hidID.Value))
        {
            Repeater repItem = (Repeater)e.Item.FindControl("repItem");
            EasyDataProvide PrepareLessonItem = new EasyDataProvide("PrepareLessonItem");
            PrepareLessonItem.AddParameter("prepareLesson_id", hidID.Value);
            DataTable dt = PrepareLessonItem.GetData("prepareLesson_id=@prepareLesson_id");
            repItem.DataSource = dt;
            repItem.DataBind();

        }
    }
}