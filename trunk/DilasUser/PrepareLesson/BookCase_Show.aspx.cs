using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DilasUser_PrepareLesson_BookCase_Show : System.Web.UI.Page
{
    private const int PageSize = 15;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Show();
        }
    }

    private void Show()
    {
        Person myPerson = new Person();
        DataLayer _dl = new DataLayer();
        DataTable dtBookCase = _dl.GetMyBookCaseForTeacher(myPerson.people_id);
        gvList.DataSource = dtBookCase;
        gvList.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Show();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {

    }
}