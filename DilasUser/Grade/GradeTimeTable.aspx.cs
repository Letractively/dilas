using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_TimeTable_GradeTimeTable : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.Teacher || myPerson.Role == Person.LoginRole.Parent || myPerson.Role == Person.LoginRole.Administrator || myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                Response.Redirect("~/Default.aspx");
            }
            Show();
        }
    }

    private void Show()
    {
        DataLayer dl = new DataLayer();
        DStudent dStudent = new DStudent((new Person()).people_id);
        string ID = dStudent.GradeID;
        DataTable dt = dl.GetTimeTableDatabyGradeId(ID);
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
}