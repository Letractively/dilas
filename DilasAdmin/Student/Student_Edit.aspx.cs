using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasAdmin_Student_Student_Edit : System.Web.UI.Page
{
    EasyDataProvide _people = new EasyDataProvide("People");
    EasyDataProvide _telephone = new EasyDataProvide("Telephone");
    EasyDataProvide _address = new EasyDataProvide("Address");
    EasyDataProvide _student = new EasyDataProvide("Student");
    EasyDataProvide _account = new EasyDataProvide("Account");
    EasyDataProvide _people_School = new EasyDataProvide("People_School");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
           
            ShowSchool();

            Person person = new Person();

            if (person.Role == Person.LoginRole.SchoolAdmin)
            {
                ddlSchool.SelectedValue = person.School_id;
                ddlSchool.Enabled = false;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
           
            

            Show();
        }
    }
    private void ShowSchool()
    {
        EasyDataProvide School = new EasyDataProvide("School");
        DataTable dtTable = School.GetData("enable='True'");
        ddlSchool.DataTextField = "name";
        ddlSchool.DataValueField = "id";
        ddlSchool.DataSource = dtTable;
        ddlSchool.DataBind();
    }

    private void Show()
    {
         ViewState["tel"] = "";
        ViewState["address"] = "";
        DataRow row = _people.FillPlaceHolderControlsById(Request["id"]);
        if (row == null) return;
        myPhoto.ImageUrl = row["myPhoto"].ToString() == "" ? (row["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, row["id"], row["myPhoto"]);

        DataRow telRow = _telephone.GetById(row["telephone_id"].ToString());
        if (telRow != null)
        {
            ViewState["tel"] = telRow["id"].ToString();
            areaCode.Value = telRow["areaCode"].ToString();
            numberCode.Value = telRow["numberCode"].ToString();
        }

        DataRow areaRow = _address.GetById(row["address_id"].ToString());
        if (areaRow != null)
        {
            ViewState["address"] = areaRow["id"].ToString();
            hidzip.Value = areaRow["zip"].ToString();
            address.Value = areaRow["address"].ToString();
        }
        DStudent dStudent = new DStudent(Request["id"]);
        username.Text = dStudent.Account;
        emailAddress.Text = dStudent.Email;
        ddlSchool.SelectedValue = dStudent.SchoolID;
        ddlCurrentYear.SelectedValue = dStudent.CurrentYear;
        ShowGrade();
        ddlGrade.SelectedValue = dStudent.GradeID;
        studentNumber.Text = dStudent.StudentNumber;

        StudentName.Text = row["name"].ToString();

    }


    protected void InsertButton_Click(object sender, EventArgs e)
    {
        string areaID = "";
        string telID = "";

        //新增或修改電話
        _telephone.AddParameter("areaCode", areaCode.Value);
        _telephone.AddParameter("numberCode", numberCode.Value);

        if (string.IsNullOrEmpty(ViewState["tel"].ToString()))
        {
            telID = _telephone.InsertReturnValue();
        }
        else
        {
            _telephone.UpdateById(ViewState["tel"].ToString());
            telID = ViewState["tel"].ToString();
        }

        //新增或修改地址
        _address.AddParameter("city", Request["city"]);
        _address.AddParameter("division", Request["division"]);
        _address.AddParameter("zip", Request["zip"]);
        _address.AddParameter("address", address.Value);
        if (string.IsNullOrEmpty(ViewState["address"].ToString()))
        {
            areaID = _address.InsertReturnValue();
        }
        else
        {
            _address.UpdateById(ViewState["address"].ToString());
            areaID = ViewState["address"].ToString();
        }

        //更新Pepole
        _people.SetPlaceHolderFormQuest();
        _people.AddParameter("address_id", telID);
        _people.AddParameter("telephone_id", areaID);
        _people.UpdateById(Request["id"]);

        //更新Student
        _student.AddParameter("studentNumber", studentNumber.Text);
        _student.UpdateById(Request["id"]);

        //更新People_School

        _people_School.AddParameter("people_id", Request["id"]);
        _people_School.AddParameter("school_id", ddlSchool.SelectedValue);
        _people_School.Update("people_id=@people_id");

        //更新GradeStudent
        EasyDataProvide GradeStudent = new EasyDataProvide("GradeStudent");

        GradeStudent.AddParameter("student_id", Request["id"]);
        GradeStudent.AddParameter("grade_id", ddlGrade.SelectedValue);
        GradeStudent.Update("student_id=@student_id");

        //更新帳號

        _account.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"));
        _account.AddParameter("emailAddress", emailAddress.Text);
        _account.AddParameter("people_id", Request["id"]);
        _account.UpdateById(Request["id"]);
        My.WebForm.doJavaScript("alert('修改成功');location.href='Student_List.aspx'");
    }
    protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCurrentYear.SelectedValue = "-1";
        ShowGrade();
    }
    protected void ddlCurrentYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowGrade();
    }

    private void ShowGrade()
    {
        if (ddlSchool.SelectedValue != "-1" || ddlCurrentYear.SelectedValue != "-1")
        {
            EasyDataProvide Grade = new EasyDataProvide("Grade");
            DataTable dt = Grade.GetData(String.Format("Enable='True' and school_id='{0}' and currentYear={1}", ddlSchool.SelectedValue, ddlCurrentYear.SelectedValue));
            ddlGrade.DataSource = dt;
            ddlGrade.DataBind();
        }
       
    }
    
}