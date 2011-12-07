using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DilasUser_BookCase_BookCase_Search : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 15;
      
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Administrator)
            {
                Response.Redirect("~/Default.aspx");
            }
            ShowGrade();

            Show();
        }
    }

    private void ShowGrade()
    {
        Person myPerson = new Person();
        DGrade grade=new DGrade();
        DataTable dt = grade.GeGradeFullNameListBySchoolID(myPerson.School_id);
        ddlGrade.DataTextField = "gradeName";
        ddlGrade.DataValueField = "id";
        ddlGrade.DataSource = dt;
        ddlGrade.DataBind();

    }

    private void Show()
    {
        string subject = txtSearch.Text == "請輸入關鍵字" ? "" : txtSearch.Text;
        string schoolID = "-1";
        string GradeID = "-1";
        Person myPerson = new Person();
       

        switch (rblPublicLevel.SelectedValue)
        {
            case "1": //班級
                schoolID = myPerson.School_id;
                GradeID = ddlGrade.SelectedValue;
                break;
            case "2": //學校
                schoolID = myPerson.School_id;
                break;
            default:
                break;
                
        }


        int totaleItems = dl.GetBookCaseListCount(schoolID, subject, GradeID);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Student_List.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetBookCaseList(schoolID, subject, GradeID, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        dlBookCase.DataSource = dt;
        dlBookCase.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Show();
    }
    protected void rblPublicLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rblPublicLevel.SelectedValue=="1")
        {
            lblGrade.Visible = true;
            ddlGrade.Visible = true;
        }else
        {
            lblGrade.Visible = false;
            ddlGrade.Visible = false;
        }
    }
}