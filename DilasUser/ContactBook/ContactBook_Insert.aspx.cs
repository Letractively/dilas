using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_ContactBook_ContactBook_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person person = new Person();
            //驗證身份
            if (person.Role == Person.LoginRole.SchoolAdmin || person.Role == Person.LoginRole.Administrator ||
                person.Role == Person.LoginRole.Parent || person.Role == Person.LoginRole.Student)
            {
                Response.Redirect("~/Default.aspx");
            }
            ShowGrade();
            ShowTemplateMessage();
        }
    }

    private void ShowTemplateMessage()
    {
        Person person = new Person();
        EasyDataProvide TemplateMessage = new EasyDataProvide("TemplateMessage");
        TemplateMessage.AddParameter("people_id", person.people_id);
        DataTable dt = TemplateMessage.GetData("people_id=@people_id");
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }

    private void ShowGrade()
    {
        Person person = new Person();
        DTeacher dTeacher = new DTeacher(person.people_id);
        DataTable dtGrade = dTeacher.GetMasterGradeList();
        grade_id.DataTextField = "GradeFullName";
        grade_id.DataValueField = "grade_id";
        grade_id.DataSource = dtGrade;
        grade_id.DataBind();
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        EasyDataProvide ContactBook = new EasyDataProvide("ContactBook");
        ContactBook.AddParameter("date", date.Text);
        ContactBook.AddParameter("grade_id", grade_id.SelectedValue);
        int i = ContactBook.GetRowCount("date=@date and grade_id=@grade_id");
        if (i > 0)
        {
            My.WebForm.doJavaScript("alert('該日該班級以建立聯絡簿，請重新選擇！');");
            return;
        }
        ContactBook.AddParameter("description", description.Text);
        string ContactBook_id=  ContactBook.InsertReturnValue();
        EasyDataProvide GradeStudent = new EasyDataProvide("GradeStudent");
        GradeStudent.AddParameter("grade_id",grade_id.SelectedValue);
        DataTable dtStudent = GradeStudent.GetData("grade_id=@grade_id");
        EasyDataProvide StudentContactBook = new EasyDataProvide("StudentContactBook");

        foreach (DataRow row in dtStudent.Rows)
        {
            StudentContactBook.AddParameter("people_id", row["student_id"].ToString());
            StudentContactBook.AddParameter("contactBook_id", ContactBook_id);
            StudentContactBook.Insert();
        }
     

        My.WebForm.doJavaScript("alert('新增成功');location.href='ContactBook_detail.aspx'");

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
       if(!My.WebForm.IsNumber((hide.Value)))
        {
           return;
        }
        string ID = ((HiddenField) Repeater1.Items[Convert.ToInt16(hide.Value)].FindControl("hidID")).Value;
        EasyDataProvide TemplateMessage = new EasyDataProvide("TemplateMessage");
        TemplateMessage.DeleteById(ID);
        ShowTemplateMessage();

    }
}