using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_PrepareLesson_PrepareLesson : System.Web.UI.Page
{
    EasyDataProvide _PrepareLesson = new EasyDataProvide("PrepareLesson");
    EasyDataProvide _PrepareLessonItem = new EasyDataProvide("PrepareLessonItem");
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
            if (!My.WebForm.IsNumber(Request["sectionIndex_id"]))
            {
                My.WebForm.doJavaScript("alert('系統發生錯誤！')");
                return;
            }
            lblCourseSubjectName.Text = Server.UrlDecode(Request["CourseSubjectName"]);
            string[] Days = GetNearWeekDay(Convert.ToInt16(Request["sectionIndex_id"]));
            ddlDate.DataSource = Days;
            ddlDate.DataBind();
            if (Request["Pdate"] != null)
            {
                ddlDate.SelectedValue = Request["Pdate"].ToString();
            }
            Show();

        }
    }

    private void Show()
    {


        _PrepareLesson.AddParameter("timetable_id", Request["timetable_id"]);
        _PrepareLesson.AddParameter("prepareDate", ddlDate.SelectedValue);
        DataRow rowPrepareLesson = _PrepareLesson.FillContentPlaceHolderControls("timetable_id=@timetable_id and prepareDate=@prepareDate");
        if (rowPrepareLesson == null)
        {
            ViewState["exist"] = "False";
            gvItem.DataSource = null;
            gvItem.DataBind();
            return;
        }

        ViewState["ID"] = rowPrepareLesson["id"].ToString();
        ViewState["exist"] = "True";

        _PrepareLessonItem.AddParameter("prepareLesson_id", rowPrepareLesson["id"].ToString());
        DataTable dtItem = _PrepareLessonItem.GetData("prepareLesson_id=@prepareLesson_id");
        gvItem.DataSource = dtItem;
        gvItem.DataBind();
        ShowFile1();
        ShowFile2();



    }

    private void ShowFile2()
    {
        if (ViewState["exist"].ToString() == "False") return;
        EasyDataProvide PrepareLessonFile = new EasyDataProvide("PrepareLessonFile");
        PrepareLessonFile.AddParameter("prepareLesson_id", ViewState["ID"].ToString());
        DataTable dtPrepareLessonFile = PrepareLessonFile.GetData("prepareLesson_id=@prepareLesson_id and type=8");
        GridView3.DataSource = dtPrepareLessonFile;
        GridView3.DataBind();
    }

    private void ShowFile1()
    {
        if( ViewState["exist"].ToString() == "False") return;
        EasyDataProvide PrepareLessonFile = new EasyDataProvide("PrepareLessonFile");
        PrepareLessonFile.AddParameter("prepareLesson_id", ViewState["ID"].ToString());
        DataTable dtPrepareLessonFile = PrepareLessonFile.GetData("prepareLesson_id=@prepareLesson_id and type=7");
        GridView2.DataSource = dtPrepareLessonFile;
        GridView2.DataBind();
    }
    /// <summary>
    /// 根據SectionIndex取得離今日最近那個禮拜幾的四個日期
    /// </summary>
    /// <param name="sectionIndex">SectionIndex</param>
    /// <returns></returns>
    private string[] GetNearWeekDay(int sectionIndex)
    {
        int weekNumber = (sectionIndex / 8) + 1;
        if (sectionIndex % 8 == 0)
        {
            weekNumber = (sectionIndex / 8);
        }
        DateTime firstDay = DateTime.Now.AddDays(Convert.ToDouble((weekNumber - Convert.ToInt16(DateTime.Now.DayOfWeek))));

        if (DateTime.Now >= firstDay)
        {
            firstDay = firstDay.AddDays(7);
        }
        string[] days = new string[4];
        days[0] = firstDay.ToShortDateString();
        days[1] = firstDay.AddDays(7).ToShortDateString();
        days[2] = firstDay.AddDays(14).ToShortDateString();
        days[3] = firstDay.AddDays(21).ToShortDateString();

        return days;

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtSubject.Text))
        {
            return;
        }
        string ID = ViewState["exist"].ToString() == "False" ? CreateNewPrepareLesson() : ViewState["ID"].ToString();
        _PrepareLessonItem.SetPlaceHolderFormQuest();
        _PrepareLessonItem.AddParameter("prepareLesson_id", ID);
        _PrepareLessonItem.AddParameter("subject", txtSubject.Text);
        _PrepareLessonItem.Insert();
        txtSubject.Text = "";
        My.WebForm.doJavaScript(String.Format("alert('新增成功！');location.href='PrepareLesson.aspx?timetable_id={0}&sectionIndex_id={1}&CourseSubjectName={2}&Pdate={3}';", Request["timetable_id"], Request["sectionIndex_id"], Server.UrlEncode(Server.UrlDecode(Request["CourseSubjectName"])), ddlDate.SelectedValue));
    }

    private string CreateNewPrepareLesson()
    {
        _PrepareLesson.AddParameter("prepareDate", ddlDate.SelectedValue);
        _PrepareLesson.AddParameter("people_id", (new Person()).people_id);
        _PrepareLesson.AddParameter("timetable_id", Request["timetable_id"]);
        _PrepareLesson.AddParameter("sectionIndex_id", Request["sectionIndex_id"]);
        _PrepareLesson.AddParameter("courseSubjectName", Request["courseSubjectName"]);
        _PrepareLesson.AddParameter("initDate", DateTime.Now.ToShortDateString());
        string id = _PrepareLesson.InsertReturnValue();
        return id;
    }


    protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Show();
    }
    protected void btnDescriptionSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(description.Text))
        {
            return;
        }
        if (ViewState["exist"].ToString() == "False")
        {
            _PrepareLesson.AddParameter("prepareDate", ddlDate.SelectedValue);
            _PrepareLesson.AddParameter("people_id", (new Person()).people_id);
            _PrepareLesson.AddParameter("timetable_id", Request["timetable_id"]);
            _PrepareLesson.AddParameter("sectionIndex_id", Request["sectionIndex_id"]);
            _PrepareLesson.AddParameter("courseSubjectName", Request["courseSubjectName"]);
            _PrepareLesson.AddParameter("description", description.Text);
            _PrepareLesson.AddParameter("initDate", DateTime.Now.ToShortDateString());
            _PrepareLesson.Insert();

        }
        else
        {
            _PrepareLesson.AddParameter("description", description.Text);
            _PrepareLesson.UpdateById(ViewState["ID"].ToString());
        }
        Show();
        My.WebForm.doJavaScript("alert('儲存成功');");
    }
    protected void btnImportantDescriptionSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(importantDescription.Text))
        {
            return;
        }
        if (ViewState["exist"].ToString() == "False")
        {
            _PrepareLesson.AddParameter("prepareDate", ddlDate.SelectedValue);
            _PrepareLesson.AddParameter("people_id", (new Person()).people_id);
            _PrepareLesson.AddParameter("timetable_id", Request["timetable_id"]);
            _PrepareLesson.AddParameter("sectionIndex_id", Request["sectionIndex_id"]);
            _PrepareLesson.AddParameter("courseSubjectName", Request["courseSubjectName"]);
            _PrepareLesson.AddParameter("importantDescription", importantDescription.Text);
            _PrepareLesson.AddParameter("initDate", DateTime.Now.ToShortDateString());
            _PrepareLesson.Insert();

        }
        else
        {
            _PrepareLesson.AddParameter("importantDescription", importantDescription.Text);
            _PrepareLesson.UpdateById(ViewState["ID"].ToString());
        }
        Show();
        My.WebForm.doJavaScript("alert('儲存成功');");
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = gvItem.DataKeys[e.RowIndex].Value.ToString();
        _PrepareLessonItem.DeleteById(ID);
        Show();
    }

    protected void BtnUpFile1_Click1(object sender, EventArgs e)
    {
        if (ViewState["exist"].ToString() == "False")
        {
            My.WebForm.doJavaScript("alert('請先輸入課程備註、重要事項或備課事項');");
            return;
        }
        EasyDataProvide TimeTable = new EasyDataProvide("TimeTable");
        DataRow rowTime = TimeTable.GetById(Request["timetable_id"]);
        if(rowTime==null)
        {
            My.WebForm.doJavaScript("備課資料有誤！");
            return;
        }
        string grade_id = rowTime["grade_id"].ToString();


        Person myPerson = new Person();
        EasyDataProvide AttachmentFile = new EasyDataProvide("AttachmentFile");
        AttachmentFile.SetPlaceHolderFormQuest();
        //取得副檔名
        string Path = GetMyPath();


        if (!FuFile1.HasFile)
        {
            My.WebForm.doJavaScript("alert('請上傳檔案')");
            return;
        }
        string Extension = FuFile1.FileName.Split('.')[FuFile1.FileName.Split('.').Length - 1];
        //新檔案名稱
        string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);

        FuFile1.SaveAs(String.Format("{0}/{1}", Path, fileName));
        AttachmentFile.AddParameter("fileName", fileName);
        AttachmentFile.AddParameter("extension", Extension);
        AttachmentFile.AddParameter("school_id", myPerson.School_id);
        AttachmentFile.AddParameter("people_id", myPerson.people_id);

        EasyDataProvide School = new EasyDataProvide("School");
        DataRow row = School.GetById(myPerson.School_id);
        string domainName = "";
        if (row != null)
        {
            domainName = row["domainName"].ToString();
        }
        AttachmentFile.AddParameter("domainName", domainName);
        string file_id = AttachmentFile.InsertReturnValue();


        EasyDataProvide PrepareLessonFile = new EasyDataProvide("PrepareLessonFile");
        PrepareLessonFile.AddParameter("type", "0");
        PrepareLessonFile.AddParameter("prepareLesson_id", ViewState["ID"].ToString());
        PrepareLessonFile.AddParameter("file_id", file_id);
        PrepareLessonFile.AddParameter("initDate", DateTime.Now.ToShortDateString());
        PrepareLessonFile.AddParameter("poster", myPerson.account);
        PrepareLessonFile.Insert();

        EasyDataProvide BookCase = new EasyDataProvide("BookCase");
        BookCase.SetPlaceHolderFormQuest();
        BookCase.AddParameter("file_id", file_id);
        BookCase.AddParameter("school_id", myPerson.School_id);
        BookCase.AddParameter("people_id", myPerson.people_id);
        BookCase.AddParameter("role", myPerson.Role == Person.LoginRole.Teacher ? "0" : "1");

       

        
        
        string BookCaseID = BookCase.InsertReturnValue();

        EasyDataProvide BookCaseGrade = new EasyDataProvide("BookCaseGrade");
        BookCaseGrade.AddParameter("bookCase_id", BookCaseID);
        BookCaseGrade.AddParameter("grade_id", grade_id);
        BookCaseGrade.AddParameter("tab_id", "7");
        BookCaseGrade.Insert();
        ShowFile1();


    }
    protected void BtnUpFile2_Click(object sender, EventArgs e)
    {
        if (ViewState["exist"].ToString() == "False")
        {
            My.WebForm.doJavaScript("alert('請先輸入課程備註、重要事項或備課事項');");
            return;
        }
        EasyDataProvide TimeTable = new EasyDataProvide("TimeTable");
        DataRow rowTime = TimeTable.GetById(Request["timetable_id"]);
        if (rowTime == null)
        {
            My.WebForm.doJavaScript("備課資料有誤！");
            return;
        }
        string grade_id = rowTime["grade_id"].ToString();


        Person myPerson = new Person();
        EasyDataProvide AttachmentFile = new EasyDataProvide("AttachmentFile");
        AttachmentFile.SetPlaceHolderFormQuest();
        //取得副檔名
        string Path = GetMyPath();


        if (!FuFile1.HasFile)
        {
            My.WebForm.doJavaScript("alert('請上傳檔案')");
            return;
        }
        string Extension = FuFile1.FileName.Split('.')[FuFile1.FileName.Split('.').Length - 1];
        //新檔案名稱
        string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);

        FuFile1.SaveAs(String.Format("{0}/{1}", Path, fileName));
        AttachmentFile.AddParameter("fileName", fileName);
        AttachmentFile.AddParameter("extension", Extension);
        AttachmentFile.AddParameter("school_id", myPerson.School_id);
        AttachmentFile.AddParameter("people_id", myPerson.people_id);

        EasyDataProvide School = new EasyDataProvide("School");
        DataRow row = School.GetById(myPerson.School_id);
        string domainName = "";
        if (row != null)
        {
            domainName = row["domainName"].ToString();
        }
        AttachmentFile.AddParameter("domainName", domainName);
        string file_id = AttachmentFile.InsertReturnValue();


        EasyDataProvide PrepareLessonFile = new EasyDataProvide("PrepareLessonFile");
        PrepareLessonFile.AddParameter("type", "1");
        PrepareLessonFile.AddParameter("prepareLesson_id", ViewState["ID"].ToString());
        PrepareLessonFile.AddParameter("file_id", file_id);
        PrepareLessonFile.AddParameter("initDate", DateTime.Now.ToShortDateString());
        PrepareLessonFile.AddParameter("poster", myPerson.account);
        PrepareLessonFile.Insert();

        EasyDataProvide BookCase = new EasyDataProvide("BookCase");
        BookCase.SetPlaceHolderFormQuest();
        BookCase.AddParameter("file_id", file_id);
        BookCase.AddParameter("school_id", myPerson.School_id);
        BookCase.AddParameter("people_id", myPerson.people_id);
        BookCase.AddParameter("role", myPerson.Role == Person.LoginRole.Teacher ? "0" : "1");





        string BookCaseID = BookCase.InsertReturnValue();

        EasyDataProvide BookCaseGrade = new EasyDataProvide("BookCaseGrade");
        BookCaseGrade.AddParameter("bookCase_id", BookCaseID);
        BookCaseGrade.AddParameter("grade_id", grade_id);
        BookCaseGrade.AddParameter("tab_id", "8");
        BookCaseGrade.Insert();
        ShowFile2();
    }
    private string GetMyPath()
    {
        Person myPerson = new Person();
        string Path = ConfigurationManager.AppSettings["FileUploadPath"].ToString();

        System.IO.DirectoryInfo directory = new DirectoryInfo(Server.MapPath(String.Format("{0}/{1}", Path, myPerson.School_id)));
        if (!directory.Exists)
        {
            directory.Create();
        }
        System.IO.DirectoryInfo directory1 = new DirectoryInfo(Server.MapPath(String.Format("{0}/{1}/{2}", Path, myPerson.School_id, myPerson.people_id)));
        if (!directory1.Exists)
        {
            directory1.Create();
        }

        return Server.MapPath(String.Format("{0}/{1}/{2}", Path, myPerson.School_id, myPerson.people_id));
    }

   
}