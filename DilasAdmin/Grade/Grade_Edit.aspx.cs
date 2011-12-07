using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Grade_Edit : System.Web.UI.Page
{
    EasyDataProvide _grade = new EasyDataProvide("Grade");
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Person myPerson = new Person();


            //僅限校管新增修改


           
            if (myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Administrator)
            {
                PublishTab1.isOpenEditTab = true;
                PublishTab1.isOpenFun1Tab = true;
                PublishTab1.isOpenFun2Tab = true;
                PublishTab1.isOpenFun3Tab = true;
                PublishTab1.isOpenFun4Tab = true;

            }
            if ( myPerson.Role == Person.LoginRole.Administrator)
            {
                UpdateButton.Visible = false;
            }
            Show();
        }
    }

    //秀出所有學校名單(下拉式選單)
    
    private void Show()
    {
        DGrade dGrade = new DGrade();
        DataRow row = _grade.FillPlaceHolderControlsById(Request["id"]);

        //取得學校名稱
        DSchool dSchool = new DSchool();
        schoolName.Text = dSchool.GetNameBySchoolId(row["school_id"].ToString());

        AllName.Text = dGrade.GetFullGradeNameById((int)row["id"]);


    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {

        //修改班級
        _grade.SetPlaceHolderFormQuest();
        _grade.UpdateById(Request["id"]);

        My.WebForm.doJavaScript("alert('修改成功');location.href='Grade_View.aspx?id=" + Request["id"] + "'");
    }
}