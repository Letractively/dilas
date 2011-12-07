using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtensionMethods;
using TIN;

public partial class CourseSubject_View : System.Web.UI.Page
{
    EasyDataProvide _courseSubject = new EasyDataProvide("CourseSubject");
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

            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                PublishTab1.isOpenEditTab = true;
            }
            Show();
        }
    }
    
    private void Show()
    {
        DataRow row = _courseSubject.FillPlaceHolderControlsById(Request["id"]);
        if (row == null) return;

        enable.Text = SCode.ToScodeEnableName(enable.Text);
        semesterTerm.Text = SCode.ToScodeSemesterTermName(semesterTerm.Text);
        description.Text = My.WebForm.TXT2HTML(description.Text);
    }
    

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("CourseSubject_Edit.aspx?id=" + Request["id"]);
    }
}