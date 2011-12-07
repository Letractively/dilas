using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Parent_List : System.Web.UI.Page
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

    private void Show()
    {
        string name = txtSearch.Text == "請輸入關鍵字" ? "" : txtSearch.Text;

        int totaleItems = dl.GetParentListCount(ddlSchool.SelectedValue, name, ddlGender.SelectedValue);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Parent_List.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetParentList(ddlSchool.SelectedValue, name, ddlGender.SelectedValue, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        //EasyDataProvide People = new EasyDataProvide("People");
        //People.DeleteById(strID);
        //EasyDataProvide Teacher = new EasyDataProvide("Teacher");
        //Teacher.DeleteById(strID);
        //Show();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Show();
    }
    
    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strId = gvList.DataKeys[e.RowIndex].Value.ToString();
        Response.Redirect(String.Format("Parent_View.aspx?id={0}", strId));
    }
}