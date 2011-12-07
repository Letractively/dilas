using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_ContactBook_ContactBook_detail : System.Web.UI.Page
{
    DataLayer _dl = new DataLayer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person myPerson = new Person();
            //驗證身份
            if (myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Administrator ||
                myPerson.Role == Person.LoginRole.Parent || myPerson.Role == Person.LoginRole.Student)
            {
                Response.Redirect("~/Default.aspx");
            }
            ShowGrade();
            ShowContact();
            
        }
    }
    private void ShowGrade()
    {
        Person myPerson = new Person();
        DTeacher dTeacher = new DTeacher(myPerson.people_id);
        DataTable dtGrade = dTeacher.GetMasterGradeList();
        ddlGrade.DataTextField = "GradeFullName";
        ddlGrade.DataValueField = "grade_id";
        ddlGrade.DataSource = dtGrade;
        ddlGrade.DataBind();
    }

    private void ShowContact()
    {

        DataRow row = _dl.GetTop1ContentBook(txtDate.Text, ddlGrade.SelectedValue,"");
        if (row==null)
        {
            My.WebForm.doJavaScript("alert('無聯絡簿資料！');");
            return;
        }
        lblDate.Text =Convert.ToDateTime(row["date"]) .ToString("yyyy-MM-dd");
        description.Text = row["description"].ToString();
        ViewState["id"] = row["id"].ToString();
        ViewState["date"] = Convert.ToDateTime(row["date"]).ToString("yyyy/MM/dd");
        if (row["activity"].ToString() == "True")
        {
            btnSend.Visible = false;
        }
        else
        {
            btnSend.Visible = true;
        }
        ShowStudents();

    }
    private void ShowStudents()
    {
        DataTable dt = _dl.GetContactBookStudentList(ViewState["date"].ToString(), ddlGrade.SelectedValue,
                                                     ViewState["id"].ToString());
        gvList.DataSource = dt;
        gvList.DataBind();
    }


    protected void btnView_Click(object sender, EventArgs e)
    {
        ShowContact();
        ShowStudents();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        EasyDataProvide ContactBook = new EasyDataProvide("ContactBook");
        ContactBook.AddParameter("activity", "true");
        ContactBook.UpdateById(ViewState["id"].ToString());
        ShowContact();
        ShowStudents();
        My.WebForm.doJavaScript("alert('聯絡簿已經送出！');");
    }
}