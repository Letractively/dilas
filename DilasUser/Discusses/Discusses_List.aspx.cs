using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Discusses_Discusses_List_ : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 20;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ModuleID = Request["ModuleID"];

            ShowClass1();
            ddlClass1.SelectedValue = Request["ClassID"];
           
            
            if (Session[Request["ModuleID"] + "Class1"] != null)
            {
                ddlClass1.SelectedValue = Session[Request["ModuleID"] + "Class1"].ToString();

                //Session["Class1"] = null;
            }

            if (Session[Request["ModuleID"] + "txtSearch"] != null)
            {

                txtSearch.Text = Session[Request["ModuleID"] + "txtSearch"].ToString();
                //Session["txtSearch"] = null;
            }
            Show();
        }
    }

    private void ShowClass1()
    {
        EasyDataProvide ModuleClass = new EasyDataProvide("ModuleClass");
        ModuleClass.AddParameter("ModuleID", Request["ModuleID"]);
        ModuleClass.AddParameter("OrgID", Request["grade_id"]);
        DataTable dtClass = ModuleClass.GetData("ModuleID=ModuleID and OrgID=@OrgID");
        ddlClass1.DataSource = dtClass;
        ddlClass1.DataBind();
        ListItem item = new ListItem("全部", "");
        ddlClass1.Items.Insert(0, item);
    }

    private void Show()
    {

        Person person = new Person();
        int totaleItems = dl.GetPublishListCount(Request["ModuleID"], Request["grade_id"], ddlClass1.SelectedValue, txtSearch.Text, DataLayer.SortMethed.OrderByInitDate, false);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Discusses_List.aspx?ModuleID=" + Request["ModuleID"] + "&ClassID=" + ddlClass1.SelectedValue + "&grade_id=" + Request["grade_id"];
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetPublishList(Request["ModuleID"], Request["grade_id"], ddlClass1.SelectedValue, txtSearch.Text, DataLayer.SortMethed.OrderByInitDate, false, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session[Request["ModuleID"] + "Class1"] = ddlClass1.SelectedValue;
        Session[Request["ModuleID"] + "txtSearch"] = txtSearch.Text;
        Response.Redirect(String.Format("Discusses_List.aspx?ModuleID={0}&grade_id={1}", Request["ModuleID"], Request["grade_id"]));
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
        Session[Request["ModuleID"] + "Class1"] = ddlClass1.SelectedValue;
        Session[Request["ModuleID"] + "txtSearch"] = txtSearch.Text;
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        string page = Request["page"] ?? "1";
        Response.Redirect("Discusses_Edit.aspx?ID=" + strID + "&ModuleID=" + Request["ModuleID"] + "&grade_id=" + Request["grade_id"] + "&page=" + page);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session[Request["ModuleID"] + "Class1"] = null;
        Session[Request["ModuleID"] + "txtSearch"] = null;
        ddlClass1.SelectedValue = "";
        txtSearch.Text = "";
        Response.Redirect(String.Format("Discusses_List.aspx?ModuleID={0}&grade_id={1}", Request["ModuleID"], Request["grade_id"]));
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