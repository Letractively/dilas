using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtensionMethods;
using TIN;

public partial class Grade_View : System.Web.UI.Page
{
    EasyDataProvide _grade = new EasyDataProvide("Grade");

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
            //只有校管才可以停用與編輯

            if (myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Administrator)
            {
               
                PublishTab1.isOpenFun1Tab = true;
                PublishTab1.isOpenFun2Tab = true;
                PublishTab1.isOpenFun3Tab = true;
                PublishTab1.isOpenFun4Tab = true;

            }
            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                PublishTab1.isOpenEditTab = true;
            }
            Show();
        }
    }

    private void Show()
    {
        DataRow row = _grade.FillPlaceHolderControlsById(Request["id"]);


        if (row == null) return;



        DGrade dGrade = new DGrade();
        DSchool dSchool = new DSchool();

        //取得學校名稱
        String schoolAllName = dSchool.GetNameBySchoolId(row["school_id"].ToString());
        schoolName.Text = schoolAllName;

        //取得班級名稱
        GradeName.Text = dGrade.GetShortGradeNameById((int) row["id"]);

        //學校班級名稱 
        AllName.Text = dGrade.GetFullGradeNameById((int) row["id"]);

        //取得班級人數
        String gradeStudentCount = dGrade.GetGradeCountById((int) row["id"]);
        GradeStudentCount.Text = gradeStudentCount;
        description.Text = My.WebForm.TXT2HTML(description.Text);

        enable.Text = enable.Text.ToScodeEnableName();
    }

  
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Grade_Edit.aspx?id=" + Request["id"]);
    }
}