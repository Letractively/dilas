using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasAdmin_Grade_Grade_Student : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();

            //僅限校管新增修改
            if (myPerson.Role == Person.LoginRole.Teacher || myPerson.Role == Person.LoginRole.Student || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                PublishTab1.isOpenEditTab = true;
                addPan.Visible = true;
                btnSure.Visible = true;
                gvList.Columns[gvList.Columns.Count-1].Visible = true;
            }
            Show();
        }
    }


    protected void Show()
    {
        EasyDataProvide Grade = new EasyDataProvide("Grade");
        DataRow row = Grade.GetById(Request["ID"]);
        if(row==null) return;
        DataTable dt = dl.GetStudentList(row["school_id"].ToString(), Request["ID"], "", "", "-1", "-1", "-1", "", "order by SeatNumber asc", 70, 1);
        gvList.DataSource = dt;
        gvList.DataBind();

        DGrade dGrade = new DGrade();
        AllName.Text = dGrade.GetFullGradeNameById((int)row["id"]);
    }

    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        EasyDataProvide GradeStudent = new EasyDataProvide("GradeStudent");
        string ID = gvList.DataKeys[e.RowIndex].Value.ToString();
        GradeStudent.Delete(String.Format("student_id='{0}'", ID));
        Show();
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvList.Rows)
        {
            TextBox txtSeatNumber = (TextBox)row.FindControl("txtSeatNumber");
            if (!My.WebForm.IsNumber(txtSeatNumber.Text))
            {
                My.WebForm.doJavaScript("alert('座號請輸入數字')");
                return;
            }
        }
        EasyDataProvide GradeStudent = new EasyDataProvide("GradeStudent");
        foreach (GridViewRow row in gvList.Rows)
        {
            string ID = gvList.DataKeys[row.RowIndex].Value.ToString();
            TextBox txtSeatNumber = (TextBox)row.FindControl("txtSeatNumber");
            GradeStudent.AddParameter("seatNumber", txtSeatNumber.Text);
            GradeStudent.Update("student_id='" + ID + "'");
        }
        My.WebForm.doJavaScript("alert('設定成功');location.href='" + Request.Url.ToString() + "'");
    }
}