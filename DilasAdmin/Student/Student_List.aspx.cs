using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Student_List : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 15;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.Teacher || myPerson.Role == Person.LoginRole.Student || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }
            ShowSchool();
            ShowGrade();
            //校管只能找自己學校//總管可以找全部
            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                ddlSchool.SelectedValue = myPerson.School_id;
                ddlSchool.Visible = false;
                lblSchool.Visible = false;
                gvList.Columns[0].Visible = false;
                btnAdd.Visible = true;
            }
            Show();
        }


    }

    private void ShowGrade()
    {
        if (ddlSchool.SelectedValue != "-1" || ddlCurrentYear.SelectedValue != "-1")
        {
            EasyDataProvide Grade = new EasyDataProvide("Grade");
            DataTable dt = Grade.GetData(String.Format("Enable='True' and school_id='{0}' and currentYear={1}", ddlSchool.SelectedValue, ddlCurrentYear.SelectedValue));
            ddlGrade.DataSource = dt;
            ddlGrade.DataBind();
        }
        ListItem item = new ListItem("請選擇", "-1");
        ddlGrade.Items.Insert(0, item);

    }
    private void ShowSchool()
    {

        EasyDataProvide School = new EasyDataProvide("School");
        DataTable dtTable = School.GetData("enable='True'");
        ddlSchool.DataTextField = "name";
        ddlSchool.DataValueField = "id";
        ddlSchool.DataSource = dtTable;
        ddlSchool.DataBind();
        ListItem item = new ListItem("請選擇", "-1");
        ddlSchool.Items.Insert(0, item);
    }
    protected void Show()
    {
        string name = txtSearch.Text == "請輸入關鍵字" ? "" : txtSearch.Text;
        string studentNumber = txtSearchNumber.Text == "請輸入學號" ? "" : txtSearchNumber.Text;



        int totaleItems = dl.GetStudentListCount(ddlSchool.SelectedValue, ddlGrade.SelectedValue, studentNumber,name, ddlEnable.SelectedValue, ddlGender.SelectedValue, "-1","","");
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Student_List.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetStudentList(ddlSchool.SelectedValue, ddlGrade.SelectedValue,studentNumber, name, ddlEnable.SelectedValue, ddlGender.SelectedValue,"-1" ,"","",PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Show();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }

    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strId = gvList.DataKeys[e.RowIndex].Value.ToString();
        Response.Redirect(String.Format("Student_View.aspx?id={0}", strId));
    }
    protected void ddlCurrentYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowGrade();
    }
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCurrentYear.SelectedValue = "-1";
        ShowGrade();
    }
}