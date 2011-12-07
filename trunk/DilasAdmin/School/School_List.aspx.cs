using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class School_List : System.Web.UI.Page
{
    EasyDataProvide _school = new EasyDataProvide("School");
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize =15;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role != Person.LoginRole.Administrator)
            {
                Response.Redirect("~/Default.aspx");
            }
            ShowDivision();
            Show();
        }
    }

    private void ShowDivision()
    {
        
        DataTable dtDivision = dl.GetCityDivision();
        ddlArea.DataTextField = "CityDivision";
        ddlArea.DataValueField = "CityDivision";
        ddlArea.DataSource = dtDivision;
        ddlArea.DataBind();
        ListItem list =new ListItem("請選擇","-1");
        ddlArea.Items.Insert(0,list);


    }
    private void Show()
    {
        string name = txtSearch.Text == "請輸入關鍵字" ? "" : txtSearch.Text;


        int totaleItems = dl.GetSchoolListCount(ddlArea.SelectedValue, name, ddlEnable.SelectedValue);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "School_List.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetSchoolList(ddlArea.SelectedValue, name, ddlEnable.SelectedValue, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvList.PageIndex = e.NewPageIndex;
        Show();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strId = gvList.DataKeys[e.RowIndex].Value.ToString();
        Response.Redirect(String.Format("School_View.aspx?id={0}", strId));
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //string strId = gvList.DataKeys[e.RowIndex].Value.ToString();
        //_school.AddParameter("enable","False");
        //_school.UpdateById(strId);
        //Show();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Show();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString());
    }
}