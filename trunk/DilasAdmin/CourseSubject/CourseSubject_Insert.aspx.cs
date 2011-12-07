using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class CourseSubject_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Person myPerson = new Person();

        //校管只能找自己學校//總管可以找全部
        if (myPerson.Role != Person.LoginRole.SchoolAdmin)
        {
            Response.Redirect("~/Default.aspx");
        }
        
    }


    protected void InsertButton_Click(object sender, EventArgs e)
    {
        EasyDataProvide courseSubject = new EasyDataProvide("CourseSubject");
        courseSubject.SetPlaceHolderFormQuest();
        
        courseSubject.AddParameter("school_id",(new Person()).School_id);
        courseSubject.Insert();
        My.WebForm.doJavaScript("alert('新增成功');location.href='CourseSubject_List.aspx'");
    }
}