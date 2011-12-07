using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_ContactBook_ContactBook_ForParent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person person = new Person();
            //驗證身份
            if (person.Role == Person.LoginRole.SchoolAdmin || person.Role == Person.LoginRole.Administrator ||
                person.Role == Person.LoginRole.Student || person.Role == Person.LoginRole.Teacher)
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
        DStudent dStudent = new DStudent(Request["people_id"]);
        DataRow sRow = dStudent.GetBaseRow();
        GradeName.Text = dStudent.GradeAllName;
        StudentName.Text = sRow["name"].ToString();
    }

    private void ShowContactBookData()
    {
        DStudent student = new DStudent(Request["people_id"]);

        //Step 1:取得ContactBook Data
        DataLayer dl = new DataLayer();
        //如果txtDate.Text為空，會自動去抓取最新一筆聯絡簿資料
        DataRow rowBook = dl.GetTop1ContentBook(txtDate.Text, student.GradeID, "true");
        if (rowBook == null)
        {
            My.WebForm.doJavaScript("alert('無聯絡簿資料！');");
            return;
        }
        description.Text =My.WebForm.TXT2HTML(rowBook["description"].ToString());

        //Step 2:取得StudentContactBook 資料
        //根據contactBook_id 與people_id 取得StudentContactBook 資料
        EasyDataProvide StudentContactBook = new EasyDataProvide("StudentContactBook");
        StudentContactBook.AddParameter("contactBook_id", rowBook["id"].ToString());
        StudentContactBook.AddParameter("people_id", Request["people_id"]); //由網址列取得
        DataRow rowStudentBook = StudentContactBook.GetSingleRow("contactBook_id=@contactBook_id and people_id=@people_id");
        if (rowStudentBook == null)
        {
            return;
        }
        //如果聯絡簿資料已經上傳就不可以再編輯
        if(rowStudentBook["checkUpload"].ToString()=="1")
        {
            Panel1.Visible = false;
        }

        //Step 3:取得StudentContactBookMessage 資料
        //如果有資料則撈回學生個別聯絡事項資料
        EasyDataProvide StudentContactBookMessage = new EasyDataProvide("StudentContactBookMessage");
        StudentContactBookMessage.AddParameter("student_id", Request["people_id"]);
        StudentContactBookMessage.AddParameter("studentContactBook_id", rowStudentBook["id"].ToString());

        StudentContactBookMessage.FillContentPlaceHolderControls("student_id=@student_id and studentContactBook_id=@studentContactBook_id and Role=0");
       
        

        ViewState["date"] = rowBook["date"].ToString();
        ViewState["studentContactBook_id"] = rowStudentBook["id"].ToString();
    }

    private void ShowStudentMessages()
    {
        DataLayer dl = new DataLayer();
        DataTable dt = dl.GetContactBookMessageByStudent(Request["people_id"]);
        gvList.DataSource = dt;
        gvList.DataBind();

    }


    protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvList.PageIndex = e.NewPageIndex; //指定顯示第幾頁
        ShowStudentMessages();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ShowInfo();
        ShowContactBookData();

        ShowStudentMessages();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataLayer dataLayer = new DataLayer();
        DataRow row = dataLayer.Login(User.Identity.Name, Password.Text);
        if (row == null)
        {
            My.WebForm.doJavaScript("alert('密碼錯誤')");
            return;
        }

        Person person = new Person();

        EasyDataProvide StudentContactBookMessage = new EasyDataProvide("StudentContactBookMessage");
        StudentContactBookMessage.AddParameter("studentContactBook_id", ViewState["studentContactBook_id"].ToString());

        //先刪除
        StudentContactBookMessage.AddParameter("studentContactBook_id", ViewState["studentContactBook_id"].ToString());
        StudentContactBookMessage.Delete("studentContactBook_id=@studentContactBook_id and Role=2");
        //後新增
        StudentContactBookMessage.AddParameter("student_id", Request["people_id"]);
        StudentContactBookMessage.AddParameter("people_id", person.people_id);
        StudentContactBookMessage.AddParameter("Role", "2");
        StudentContactBookMessage.AddParameter("article", txtArticle.Text);
        StudentContactBookMessage.AddParameter("contactBookDate", ViewState["date"].ToString());
        StudentContactBookMessage.Insert();

        EasyDataProvide StudentContactBook = new EasyDataProvide("StudentContactBook");
        StudentContactBook.AddParameter("isSign", "true");
        StudentContactBook.UpdateById(ViewState["studentContactBook_id"].ToString());

        My.WebForm.doJavaScript(String.Format("alert('新增成功');location.href='ContactBook_ForParent.aspx?people_id={0}'", Request["people_id"]));
    }
}