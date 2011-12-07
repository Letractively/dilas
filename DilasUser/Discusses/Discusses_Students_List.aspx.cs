using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Discusses_Discusses_Students_List : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 20;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[Request["ModuleID"] + "txtSearch"] != null)
            {

                //txtSearch.Text = Session[Request["ModuleID"] + "txtSearch"].ToString();
                //Session["txtSearch"] = null;
            }

            Show();
        }
    }



    private void Show()
    {
        Person person = new Person();
        DStudent student=new DStudent(person.people_id);
        int totaleItems = dl.GetPublishListCount(Request["ModuleID"], student.GradeID, "", "", DataLayer.SortMethed.OrderByInitDate, false);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "Discusses_Students_List.aspx?ModuleID=" + Request["ModuleID"];
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetPublishList(Request["ModuleID"], student.GradeID, "", "", DataLayer.SortMethed.OrderByInitDate, false, PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Session[Request["ModuleID"] + "txtSearch"] = txtSearch.Text;
        Response.Redirect(String.Format("Discusses_Students_List.aspx?ModuleID={0}", Request["ModuleID"]));
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

        Session[Request["ModuleID"] + "txtSearch"] = null;

        //txtSearch.Text = "";
        Response.Redirect(String.Format("Discusses_Students_List.aspx?ModuleID={0}", Request["ModuleID"]));
    }
    protected void gvList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater repFiles = (Repeater) e.Item.FindControl("repFiles");
        HiddenField hidID = (HiddenField) e.Item.FindControl("hidID");
        EasyDataProvide ModuleFiles = new EasyDataProvide("ModuleFiles");
        ModuleFiles.AddParameter("publishID", hidID.Value);
        DataTable dt = ModuleFiles.GetData("publishID=@publishID");
        repFiles.DataSource = dt;
        repFiles.DataBind();

        Repeater repReply = (Repeater) e.Item.FindControl("repReply");
        DataLayer dl=new DataLayer();
        DataTable dtReply = dl.GetDiscussesReply(hidID.Value);
        repReply.DataSource = dtReply;
        repReply.DataBind();
    }
}