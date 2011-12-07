using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_BookCase_BookCase_Grade : System.Web.UI.Page
{
    Person _myPerson = new Person();
    EasyDataProvide _BookCaseGrade = new EasyDataProvide("BookCaseGrade");
    DataLayer _dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //驗證身份
            if (_myPerson.Role == Person.LoginRole.SchoolAdmin || _myPerson.Role == Person.LoginRole.Administrator ||
                _myPerson.Role == Person.LoginRole.Parent || _myPerson.Role == Person.LoginRole.Student)
            {
                Response.Redirect("~/Default.aspx");
            }
            ShowGrade();
            ShowTab();
            Show();
        }
    }

    private void ShowTab()
    {
        EasyDataProvide BookTab = new EasyDataProvide("BookTab");
        DataTable dt = BookTab.GetData("status = 0");
        cblTab.DataTextField = "subject";
        cblTab.DataValueField = "id";
        cblTab.DataSource = dt;
        cblTab.DataBind();
    }

    private void ShowGrade()
    {
        DTeacher dTeacher = new DTeacher(_myPerson.people_id);
        DataTable dtGrade = dTeacher.GetGradeList();
        grade_id.DataTextField = "GradeFullName";
        grade_id.DataValueField = "grade_id";
        grade_id.DataSource = dtGrade;
        grade_id.DataBind();
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {

        _BookCaseGrade.AddParameter("bookCase_id", Request["id"]);
        _BookCaseGrade.AddParameter("grade_id", grade_id.SelectedValue);
        System.Text.StringBuilder searchStringBuilder = new System.Text.StringBuilder();
        foreach (ListItem item in cblTab.Items)
        {
            if (item.Selected)
            {
                searchStringBuilder.Append(item.Value + ",");

            }
        }
        string SearchString = searchStringBuilder.ToString();
        SearchString = SearchString.Trim(',');
        if (string.IsNullOrEmpty(SearchString))
        {
            My.WebForm.doJavaScript("alert('請選擇書籤!');");
            return;
        }

        SearchString = String.Format("and tab_id in ({0})", SearchString);

        int i = _BookCaseGrade.GetRowCount(String.Format("bookCase_id=@bookCase_id and grade_id=@grade_id {0}", SearchString));
        if (i > 0)
        {
            My.WebForm.doJavaScript("alert('已有同樣班級書籤，請重新選取分配！');");
            return;
        }

        foreach (ListItem item in cblTab.Items)
        {
            if (item.Selected)
            {
                _BookCaseGrade.AddParameter("bookCase_id", Request["id"]);
                _BookCaseGrade.AddParameter("grade_id", grade_id.SelectedValue);
                _BookCaseGrade.AddParameter("tab_id", item.Value);
                _BookCaseGrade.Insert();
            }
        }


        Response.Redirect("BookCase_List.aspx");
    }

    private void Show()
    {


        DataTable dt = _dl.GetBookCaseGradeList(Request["id"]);
        GridView1.DataSource = dt;
        GridView1.DataBind();


    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        _BookCaseGrade.DeleteById(ID);
        Response.Redirect(Request.Url.ToString());
    }
}