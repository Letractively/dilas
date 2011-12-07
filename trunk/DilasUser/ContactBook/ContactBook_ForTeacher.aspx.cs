using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_ContactBook_ContactBook_detail_Student : System.Web.UI.Page
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
            ShowInfo();
            ShowContactBookMessage();
            ShowTemplateMessage();
            ShowStudentMessages();
        }
    }

    private void ShowInfo()
    {
        DStudent dStudent = new DStudent(Request["people_id"]);
        DataRow sRow = dStudent.GetBaseRow();
        GradeName.Text = dStudent.GradeAllName;
        StudentName.Text = sRow["name"].ToString();
    }

    private void ShowStudentMessages()
    {
        DataLayer dl=new DataLayer();
        DataTable dt = dl.GetContactBookMessageByStudent(Request["people_id"]);
        gvList.DataSource = dt;
        gvList.DataBind();

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

    private void ShowContactBookMessage()
    {
        EasyDataProvide ContactBook = new EasyDataProvide("ContactBook");
        //如果有資料則撈回學生個別聯絡事項資料
        EasyDataProvide StudentContactBook = new EasyDataProvide("StudentContactBook");
        StudentContactBook.AddParameter("contactBook_id", Request["contactBook_id"]);
        StudentContactBook.AddParameter("people_id", Request["people_id"]);
        DataRow rowSbook = StudentContactBook.GetSingleRow("people_id=@people_id and contactBook_id=@contactBook_id");
        if(rowSbook==null)
        {
            return;
        }




        EasyDataProvide StudentContactBookMessage = new EasyDataProvide("StudentContactBookMessage");
        StudentContactBookMessage.AddParameter("student_id", Request["people_id"]);
        StudentContactBookMessage.AddParameter("studentContactBook_id", rowSbook["id"].ToString());
        StudentContactBookMessage.FillContentPlaceHolderControls("student_id=@student_id and studentContactBook_id=@studentContactBook_id and Role=0");
       
        DataRow row= ContactBook.FillPlaceHolderControlsById(Request["contactBook_id"]);
        if(row["activity"].ToString()=="True")
        {
            InsertButton.Visible = false;
        }
        ViewState["date"] = row["date"].ToString();
        ViewState["contactBook_id"] = rowSbook["id"].ToString();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (!My.WebForm.IsNumber((hide.Value)))
        {
            return;
        }
        string ID = ((HiddenField)Repeater1.Items[Convert.ToInt16(hide.Value)].FindControl("hidID")).Value;
        EasyDataProvide TemplateMessage = new EasyDataProvide("TemplateMessage");
        TemplateMessage.DeleteById(ID);
        ShowTemplateMessage();

    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        Person person = new Person();
        EasyDataProvide StudentContactBookMessage = new EasyDataProvide("StudentContactBookMessage");
        //先刪除
        StudentContactBookMessage.AddParameter("studentContactBook_id", ViewState["contactBook_id"].ToString());
        StudentContactBookMessage.Delete("studentContactBook_id=@studentContactBook_id");
        //後新增
        StudentContactBookMessage.AddParameter("student_id", Request["people_id"]);
        StudentContactBookMessage.AddParameter("people_id", person.people_id);
        StudentContactBookMessage.AddParameter("Role", "0");
        StudentContactBookMessage.AddParameter("article", article.Text);
        StudentContactBookMessage.AddParameter("contactBookDate", ViewState["date"].ToString());
        StudentContactBookMessage.Insert();

        My.WebForm.doJavaScript("alert('新增成功');location.href='ContactBook_detail.aspx'");
    }
    protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ShowStudentMessages();
    }
}