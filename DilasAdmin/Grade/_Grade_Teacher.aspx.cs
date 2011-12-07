using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasAdmin_Grade_Grade_Teacher : System.Web.UI.Page
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
            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                PublishTab1.isOpenEditTab = true;
                addPan.Visible = true;
                btnSure.Visible = true;
                gvList.Columns[gvList.Columns.Count - 1].Visible = true;
            }
            Show();
        }
    }

    private void Show()
    {
        DataTable dt = dl.GetTeacherByGradeID(Request["id"]);
        gvList.DataSource = dt;
        gvList.DataBind();

        EasyDataProvide Grade = new EasyDataProvide("Grade");
        DataRow row = Grade.GetById(Request["ID"]);
        DGrade dGrade = new DGrade();
        AllName.Text = dGrade.GetFullGradeNameById((int)row["id"]);
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        EasyDataProvide GradeTeacher = new EasyDataProvide("GradeTeacher");
        foreach (GridViewRow row in gvList.Rows)
        {
            string ID = gvList.DataKeys[row.RowIndex].Value.ToString();
            DropDownList ddlClassify = (DropDownList)row.FindControl("ddlClassify");
            GradeTeacher.AddParameter("classify", ddlClassify.SelectedValue);
            GradeTeacher.UpdateById(ID);
        }
        My.WebForm.doJavaScript("alert('設定成功');location.href='" + Request.Url.ToString() + "'");
    }
    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EasyDataProvide GradeTeacher = new EasyDataProvide("GradeTeacher");
        string ID = gvList.DataKeys[e.RowIndex].Value.ToString();
        GradeTeacher.DeleteById(ID);
        Show();
    }

}