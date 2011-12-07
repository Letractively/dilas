using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_BookCase_BookCase_Tabs : System.Web.UI.Page
{
    EasyDataProvide _BookTab = new EasyDataProvide("BookTab");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Show();
        }
    }

    private void Show()
    {
        Person myPerson = new Person();
        _BookTab.AddParameter("people_id", myPerson.people_id);
        DataTable dt = _BookTab.GetData("people_id=@people_id", "order by listNum");
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        if(subject.Text=="")
        {
            return;
        }
        _BookTab.SetPlaceHolderFormQuest();
        Person myPerson = new Person();
        _BookTab.AddParameter("people_id", myPerson.people_id);
        _BookTab.Insert();
        Response.Redirect(Request.Url.ToString());

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Show();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        EasyDataProvide BookCase = new EasyDataProvide("BookCase");
        BookCase.AddParameter("tab_id", ID);
        int i = BookCase.GetRowCount("tab_id=@tab_id");
        if(i>0)
        {
            My.WebForm.doJavaScript("alert('該書籤目前正使用中！');");
            return;
        }


        _BookTab.DeleteById(ID);
        Show();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Show();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtSubject = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSubject");
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        _BookTab.AddParameter("subject", txtSubject.Text);
        _BookTab.UpdateById(ID);
        GridView1.EditIndex = -1;
        Show();
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            TextBox listNum = (TextBox)row.FindControl("listNum");
            _BookTab.AddParameter("listNum", listNum.Text);
            string ID = GridView1.DataKeys[row.RowIndex].Value.ToString();
            _BookTab.UpdateById(ID);
            Show();
        }
    }
}