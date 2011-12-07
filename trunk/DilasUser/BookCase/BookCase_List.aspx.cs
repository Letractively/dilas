using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_BookCase_BookCase_List : System.Web.UI.Page
{
    Person _myPerson = new Person();
    private DataTable _dtBookCase;
    DataLayer _dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (_myPerson.Role == Person.LoginRole.SchoolAdmin || _myPerson.Role == Person.LoginRole.Administrator || _myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }


            GetBookcases();
            ShowTabs();
            Session["MyBookCase"] = null;
        }
    }

    private void GetBookcases()
    {
        if (_myPerson.Role == Person.LoginRole.Teacher)
        {
            DataTable dtBookCase = _dl.GetMyBookCaseForTeacher(_myPerson.people_id);
            Session["MyBookCase"] = dtBookCase;
        }
        else
        {
            DStudent student = new DStudent(_myPerson.people_id);
            DataTable dtBookCase = _dl.GetMyBookCaseForStudent(_myPerson.people_id, student.GradeID);
            Session["MyBookCase"] = dtBookCase;
        }

    }

    private void ShowTabs()
    {
        if (_myPerson.Role == Person.LoginRole.Teacher)
        {
            DataTable dtTabs = _dl.GetMyTabsForTeacher(_myPerson.people_id);
            dlTabs.DataSource = dtTabs;
            dlTabs.DataBind();

        }
        else
        {
            DataTable dtTabs = _dl.GetMyTabsForStudent(_myPerson.people_id);
            dlTabs.DataSource = dtTabs;
            dlTabs.DataBind();
        }



    }
    protected void dlTabs_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        string ID = dlTabs.DataKeys[e.Item.ItemIndex].ToString();
        DataTable dtBookCase = (DataTable)Session["MyBookCase"];
        DataView dv = new DataView(dtBookCase);
        dv.RowFilter = "tab_id=" + ID;
        DataList dlBookCase = (DataList)e.Item.FindControl("dlBookCase");
        dlBookCase.DataSource = dv;
        dlBookCase.DataBind();
    }
}