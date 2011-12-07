using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class CourseSubject_Edit : System.Web.UI.Page
{
    EasyDataProvide _courseSubject = new EasyDataProvide("CourseSubject");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Person myPerson = new Person();


            //僅限校管新增修改
            if (myPerson.Role != Person.LoginRole.SchoolAdmin)
            {
                Response.Redirect("~/Default.aspx");
            }
            Show();
        }
    }

    private void Show()
    {
        _courseSubject.FillPlaceHolderControlsById(Request["id"]);
        
    }

   

 

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        _courseSubject.SetPlaceHolderFormQuest();
        _courseSubject.UpdateById(Request["id"]);
        My.WebForm.doJavaScript("alert('修改成功');location.href='CourseSubject_View.aspx?id=" + Request["id"] + "'");
    }
}