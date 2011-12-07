using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasAdmin_Parent_Parent_Children : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
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


            Show();
        }

    }

    private void Show()
    {
        DataTable dt = dl.GetStudentList((new Person()).School_id, "-1", "", "", "-1", "-1", Request["ID"], "", "order by StudentNumber asc", 70, 1);
        gvList.DataSource = dt;
        gvList.DataBind();

        EasyDataProvide People = new EasyDataProvide("People");
        DataRow row = People.GetById(Request["id"]);
        ParentName.Text = row["name"].ToString();
    }

    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EasyDataProvide ParentChildren = new EasyDataProvide("ParentChildren");
        string ID = gvList.DataKeys[e.RowIndex].Value.ToString();
        ParentChildren.AddParameter("student_id", ID);
        ParentChildren.Delete("student_id=@student_id");
        Show();
    }
    protected void btnRelation_Click(object sender, EventArgs e)
    {
        EasyDataProvide ParentChildren = new EasyDataProvide("ParentChildren");
        foreach (GridViewRow row in gvList.Rows)
        {
            string ID = gvList.DataKeys[row.RowIndex].Value.ToString();
            TextBox txtRelationship = (TextBox)row.FindControl("txtRelationship");
            ParentChildren.AddParameter("relationship", txtRelationship.Text);
            ParentChildren.AddParameter("student_id", ID);
            ParentChildren.Update("student_id=@student_id");
           
        }
        Show();
        My.WebForm.doJavaScript("alert('儲存成功');");
    }
}