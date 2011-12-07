using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DilasUser_Grade_SelectGrade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person myPerson = new Person();
            //驗證身份
            if (myPerson.Role != Person.LoginRole.Teacher)
            {
                Response.Redirect("~/Default.aspx");
            }
            Show();
        }
    }

    private void Show()
    {
        Person myPerson = new Person();
        DTeacher dTeacher = new DTeacher(myPerson.people_id);
        DataTable dt = dTeacher.GetGradeList();
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
}