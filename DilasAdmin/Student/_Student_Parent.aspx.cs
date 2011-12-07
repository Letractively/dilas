using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtensionMethods;
using TIN;

public partial class DilasAdmin_Student_Student_Parent : System.Web.UI.Page
{
    EasyDataProvide _people = new EasyDataProvide("People");

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
                PublishTab1.isOpenFun1Tab = true;
            }
            Show();
        }
    }

    private void Show()
    {
        EasyDataProvide ParentChildren = new EasyDataProvide("ParentChildren");
        ParentChildren.AddParameter("student_id",Request["id"]);
        DataRow pcRow = ParentChildren.GetSingleRow("student_id=@student_id");
        if(pcRow==null)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            return;
        }else
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        DataRow row = _people.FillPlaceHolderControlsById(pcRow["parent_id"].ToString());
        if (row == null) return;
        myPhoto.ImageUrl = row["myPhoto"].ToString() == "" ? (row["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, row["id"], row["myPhoto"]);


        gender.Text = SCode.ToScodeGenderName(gender.Text);
        DParent dParent = new DParent(pcRow["parent_id"].ToString());
        telephone_id.Text = dParent.Phone;
        address_id.Text = dParent.Address;
        occupation.Text = dParent.Occupation;
        username.Text = dParent.Account;
        emailAddress.Text = dParent.Email;
        schoolName.Text = dParent.SchoolName;
        enable.Text = enable.Text.ToScodeEnableName();
        description.Text = My.WebForm.TXT2HTML(description.Text);
        EasyDataProvide people = new EasyDataProvide("People");
        DataRow peoplwRow = people.GetById(Request["id"]);
        StudentName.Text = peoplwRow["name"].ToString();
    }
    /*
    protected void btnDisable_Click(object sender, EventArgs e)
    {
        _people.AddParameter("disable", btnDisable.Text == "按我啟用" ? "False" : "True");
        _people.UpdateById(Request["id"]);
        Show();
        My.WebForm.doJavaScript(btnDisable.Text == "按我啟用" ? "alert('停用成功');" : "alert('啟用成功');");
    }
     */
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Parent_Edit.aspx?id=" + Request["id"]);
    }
}