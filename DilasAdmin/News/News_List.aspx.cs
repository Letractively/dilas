using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_List : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize =20;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ModuleID = Request["ModuleID"];

            ShowSchool();
            ShowClass1();
            ddlSchool.SelectedValue = Request["OrgID"];
            ddlClass1.SelectedValue = Request["ClassID"];
            //ddlClass1.SelectedValue = ModuleID.Substring(0, 3);
            //showClass2(ddlClass1.SelectedValue);
            //if (!DataLayer.IsInRole("admins", User.Identity.Name))
            //{
            //    string[] strUserData = ((FormsIdentity)(Page.User.Identity)).Ticket.UserData.Split(new Char[] { ';' });
            //    ddlOrg.SelectedValue = strUserData[5];
            //    ddlOrg.Enabled = false;
            //    ddlClass1.Enabled = false;
            //    ddlClass2.Enabled = false;
            //}
            if (Session[Request["ModuleID"] +"ddlOrg"] != null)
            {
                ddlSchool.SelectedValue = Session[Request["ModuleID"] + "ddlOrg"].ToString();
                //Session["ddlOrg"] = null;
            }
            if (Session[Request["ModuleID"] +"Class1"] != null)
            {
                ddlClass1.SelectedValue = Session[Request["ModuleID"] + "Class1"].ToString();

                //Session["Class1"] = null;
            }

            if (Session[Request["ModuleID"]�@+"txtSearch"] != null)
            {

                txtSearch.Text = Session[Request["ModuleID"] + "txtSearch"].ToString();
                //Session["txtSearch"] = null;
            }
            //�պޥu���ۤv�Ǯ�//�`�ޥi�H�����
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                ddlSchool.SelectedValue = myPerson.School_id;
                ddlSchool.Visible = false;
                lblSchool.Visible = false;

            }
            Show();
        }
    }

    private void ShowClass1()
    {
        EasyDataProvide ModuleClass = new EasyDataProvide("ModuleClass");
        DataTable dtClass = ModuleClass.GetData(string.Format("moduleID='{0}'", Request["ModuleID"]));
        ddlClass1.DataSource = dtClass;
        ddlClass1.DataBind();
        ListItem item = new ListItem("����", "");
        ddlClass1.Items.Insert(0, item);
    }

    private void Show()
    {

        int totaleItems = dl.GetPublishListCount(Request["ModuleID"], ddlSchool.SelectedValue, ddlClass1.SelectedValue, txtSearch.Text, DataLayer.SortMethed.OrderByInitDate, false);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "News_List.aspx?ModuleID=" + Request["ModuleID"]  + "&ClassID=" + ddlClass1.SelectedValue;
        //�ޥ�:�Q�γo�ؤ覡�~�i�H�I�susercontrol�̪�public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetPublishList(Request["ModuleID"], ddlSchool.SelectedValue, ddlClass1.SelectedValue, txtSearch.Text, DataLayer.SortMethed.OrderByInitDate, false, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
    }

    private void ShowSchool()
    {

        EasyDataProvide School = new EasyDataProvide("School");
        DataTable dtTable = School.GetData("enable='True'");
        ddlSchool.DataTextField = "name";
        ddlSchool.DataValueField = "id";
        ddlSchool.DataSource = dtTable;
        ddlSchool.DataBind();
        ListItem item = new ListItem("�п��", "");
        ddlSchool.Items.Insert(0, item);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session[Request["ModuleID"] + "ddlOrg"] = ddlSchool.SelectedValue;
        Session[Request["ModuleID"] +"Class1"] = ddlClass1.SelectedValue;
        Session[Request["ModuleID"] +"txtSearch"] = txtSearch.Text;
        Response.Redirect(String.Format("News_List.aspx?ModuleID={0}", Request["ModuleID"]));
    }

    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //RowDataBound Code
        }
    }

    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        ModulePublish.DeleteById(strID);
        Show();
    }
    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Session[Request["ModuleID"] + "ddlOrg"] = ddlSchool.SelectedValue;
        Session[Request["ModuleID"] + "Class1"] = ddlClass1.SelectedValue;
        Session[Request["ModuleID"] +"txtSearch"] = txtSearch.Text;
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        string page = Request["page"] ?? "1";
        Response.Redirect("News_Edit.aspx?ID=" + strID + "&ModuleID=" + Request["ModuleID"] + "&page=" + page );
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session[Request["ModuleID"] + "ddlOrg"] = null;
        Session[Request["ModuleID"] + "Class1"] = null;
        Session[Request["ModuleID"] + "txtSearch"] = null;
        ddlSchool.SelectedValue = "";
        ddlClass1.SelectedValue = "";
        txtSearch.Text = "";
        Response.Redirect(String.Format("News_List.aspx?ModuleID={0}", Request["ModuleID"]));
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvList.Rows)
        {
            CheckBox CheckBox1 = (CheckBox)row.Cells[0].FindControl("CheckBox1");
            if (CheckBox1.Checked)
            {
                string ID = Convert.ToString(gvList.DataKeys[row.RowIndex].Value);
                EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
                ModulePublish.DeleteById(ID);
            }
        }
        Show();
    }
}