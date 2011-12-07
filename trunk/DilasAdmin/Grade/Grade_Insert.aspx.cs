using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Grade_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person myPerson = new Person();

            //僅限校管新增修改
            if (myPerson.Role != Person.LoginRole.SchoolAdmin)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }


    //秀出所有學校名單(下拉式選單)
  /* 
   * private void ShowSchools()
    {
        EasyDataProvide School = new EasyDataProvide("School");
        DataTable dt = School.GetData("disable='False'");
        school_id.DataTextField ="name";
        school_id.DataValueField = "id";
        school_id.DataSource = dt;
        school_id.DataBind();
    }
   * */
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        //新增班級
        EasyDataProvide grade = new EasyDataProvide("Grade");
        grade.SetPlaceHolderFormQuest();
        grade.AddParameter("school_id", (new Person()).School_id);
        grade.Insert();
        My.WebForm.doJavaScript("alert('新增成功');location.href='Grade_List.aspx'");
    }
}