using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_ContactBook_ContactBook_ForStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person person = new Person();
            //驗證身份
            if (person.Role == Person.LoginRole.SchoolAdmin || person.Role == Person.LoginRole.Administrator ||
                person.Role == Person.LoginRole.Parent || person.Role == Person.LoginRole.Teacher)
            {
                Response.Redirect("~/Default.aspx");
            }
            ShowInfo();
            ShowContactBookData();
            ShowStudentMessages();


        }
    }

    private void ShowInfo()
    {
        DStudent dStudent = new DStudent((new Person()).people_id);
        DataRow sRow = dStudent.GetBaseRow();
        GradeName.Text = dStudent.GradeAllName;
        StudentName.Text = sRow["name"].ToString();
    }

    private void ShowContactBookData()
    {
        DStudent student = new DStudent((new Person()).people_id);

        //Step 1:取得ContactBook Data
        DataLayer dl = new DataLayer();
        DataRow rowBook = dl.GetTop1ContentBook(txtDate.Text, student.GradeID, "true");
        //如果txtDate.Text為空，會自動去抓取最新一筆聯絡簿資料
        if (rowBook == null)
        {
            My.WebForm.doJavaScript("alert('無聯絡簿資料！');");
            return;
        }
        description.Text = My.WebForm.TXT2HTML(rowBook["description"].ToString());
        
        //Step 2:取得StudentContactBook 資料
        //根據contactBook_id 與people_id 取得StudentContactBook 資料
        EasyDataProvide StudentContactBook = new EasyDataProvide("StudentContactBook");
        StudentContactBook.AddParameter("contactBook_id", rowBook["id"].ToString());
        StudentContactBook.AddParameter("people_id", (new Person()).people_id);
        DataRow rowStudentBook = StudentContactBook.GetSingleRow("contactBook_id=@contactBook_id and people_id=@people_id");
        if (rowStudentBook == null)
        {
            return;
        }
        //如果聯絡簿資料已經上傳就不可以再編輯
        if (rowStudentBook["checkUpload"].ToString() == "1")
        {
            Panel1.Visible = false;
        }

        //Step 3:取得StudentContactBookMessage 資料
        //如果有資料則撈回學生個別聯絡事項資料
        EasyDataProvide StudentContactBookMessage = new EasyDataProvide("StudentContactBookMessage");
        StudentContactBookMessage.AddParameter("student_id", (new Person()).people_id);
        StudentContactBookMessage.AddParameter("studentContactBook_id", rowStudentBook["id"].ToString());

        //DataRow rowMessage = StudentContactBookMessage.FillContentPlaceHolderControls("student_id=@student_id and studentContactBook_id=@studentContactBook_id");
        //txtArticle.Text = rowMessage["article"].ToString();


        ViewState["date"] = rowBook["date"].ToString();
        ViewState["contactBook_id"] = rowStudentBook["id"].ToString();
    }

    private void ShowStudentMessages()
    {
        DataLayer dl = new DataLayer();
        DataTable dt = dl.GetContactBookMessageByStudent((new Person()).people_id);
        gvList.DataSource = dt;
        gvList.DataBind();

    }




    protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvList.PageIndex = e.NewPageIndex; //指定顯示第幾頁
        ShowStudentMessages();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        Person person = new Person();
        EasyDataProvide StudentContactBookMessage = new EasyDataProvide("StudentContactBookMessage");
        StudentContactBookMessage.AddParameter("studentContactBook_id", ViewState["contactBook_id"].ToString());
        //先刪除
        StudentContactBookMessage.AddParameter("studentContactBook_id", ViewState["contactBook_id"].ToString());
        StudentContactBookMessage.Delete("studentContactBook_id=@studentContactBook_id and Role=1");
        //後新增
        StudentContactBookMessage.AddParameter("student_id", person.people_id);
        StudentContactBookMessage.AddParameter("people_id", person.people_id);
        StudentContactBookMessage.AddParameter("Role", "1");
        StudentContactBookMessage.AddParameter("article", txtArticle.Text);
        StudentContactBookMessage.AddParameter("contactBookDate", ViewState["date"].ToString());
        StudentContactBookMessage.Insert();

        My.WebForm.doJavaScript("alert('新增成功');location.href='ContactBook_ForStudent.aspx'");
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ShowInfo();
        ShowContactBookData();

        ShowStudentMessages();
    }
}