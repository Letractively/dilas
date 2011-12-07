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

public partial class Teacher_Edit : System.Web.UI.Page
{
    EasyDataProvide _people = new EasyDataProvide("People");
    EasyDataProvide _telephone = new EasyDataProvide("Telephone");
    EasyDataProvide _address = new EasyDataProvide("Address");
    EasyDataProvide _teacher = new EasyDataProvide("Teacher");
    EasyDataProvide _account = new EasyDataProvide("Account");
    EasyDataProvide _people_School = new EasyDataProvide("People_School");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            ShowSchool();

            //校管只能找自己學校//總管可以找全部
            if (myPerson.Role == Person.LoginRole.SchoolAdmin)
            {
                ddlSchool.SelectedValue = myPerson.School_id;
                ddlSchool.Enabled = false;
            }else
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
        DTeacher dTeacher=new DTeacher(Request["id"]);
        rank.SelectedValue = dTeacher.RankValue;
        username.Text = dTeacher.Account;
        emailAddress.Text = dTeacher.Email;
        ddlSchool.SelectedValue = dTeacher.SchoolID;

        TeacherName.Text = row["name"].ToString();
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
        EasyDataProvide People = new EasyDataProvide("People");
        People.SetPlaceHolderFormQuest();
        People.AddParameter("address_id", telID);
        People.AddParameter("telephone_id", areaID);
        People.UpdateById(Request["id"]);

        //更新teacher
        _teacher.AddParameter("rank", rank.SelectedValue);
        _teacher.UpdateById(Request["id"]);

        //更新People_School
       
        _people_School.AddParameter("people_id", Request["id"]);
        _people_School.AddParameter("school_id", ddlSchool.SelectedValue);
        _people_School.Update("people_id=@people_id");

        //更新帳號

        _account.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"));
        _account.AddParameter("emailAddress", emailAddress.Text);
        _account.AddParameter("people_id", Request["id"]);
        _account.UpdateById(Request["id"]);
        My.WebForm.doJavaScript("alert('修改成功');location.href='Teacher_List.aspx'");
    }
}