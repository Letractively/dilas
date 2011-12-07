using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtensionMethods;
using TIN;

public partial class DilasUser_BookCase_BookCase_Edit : System.Web.UI.Page
{
    private Person _myPerson = new Person();
    EasyDataProvide _BookCase = new EasyDataProvide("BookCase");
    EasyDataProvide _AttachmentFile = new EasyDataProvide("AttachmentFile");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Administrator || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (_myPerson.Role == Person.LoginRole.Teacher)
            {
                pnlGrade.Visible = true;
                ShowGrade();
            }
            ShowTabs();
            if (myPerson.Role == Person.LoginRole.Teacher || myPerson.Role == Person.LoginRole.Student)
            {
                PublishTab1.isOpenEditTab = true;
            }

            if (myPerson.Role == Person.LoginRole.Teacher)
            {
                PublishTab1.isOpenFun1Tab = true;
            }
            if(tab_id.Items.Count==0)
            {
                My.WebForm.doJavaScript("alert('請先建立書籤!');location.href='BookCase_Tabs.aspx'");
            }
            Show();

        }
    }

    private void ShowTabs()
    {
        EasyDataProvide BookTab = new EasyDataProvide("BookTab");
        BookTab.AddParameter("people_id", _myPerson.people_id);
        DataTable dt = BookTab.GetData("people_id=@people_id  or status=2");
        tab_id.DataTextField = "subject";
        tab_id.DataValueField = "id";
        tab_id.DataSource = dt;
        tab_id.DataBind();
    }
    private void ShowGrade()
    {
        DTeacher dTeacher = new DTeacher(_myPerson.people_id);
        DataTable dtGrade = dTeacher.GetGradeList();
        cblGrade.DataTextField = "GradeFullName";
        cblGrade.DataValueField = "grade_id";
        cblGrade.DataSource = dtGrade;
        cblGrade.DataBind();

    }

    private void Show()
    {
        DataRow rowBookCase = _BookCase.FillPlaceHolderControlsById(Request["id"]);
        if (rowBookCase == null) return;
        DataRow rowAttachmentFile = _AttachmentFile.FillPlaceHolderControlsById(rowBookCase["file_id"].ToString());
        ViewState["file_id"] = rowBookCase["file_id"].ToString();
        if (rowAttachmentFile == null) return;


        type.Text = type.Text.ToScodeBookTypeName();
        publicLevel.Text = publicLevel.Text.ToScodePublicLevelName();
        hlPic.NavigateUrl = ConfigurationManager.AppSettings["FileUploadPath"] + "/" + rowAttachmentFile["school_id"] + "/" + rowAttachmentFile["people_id"] + "/" + rowAttachmentFile["coverPicName"];

        EasyDataProvide BookCaseGrade = new EasyDataProvide("BookCaseGrade");
        BookCaseGrade.AddParameter("bookCase_id", Request["id"]);
        DataTable dtGrade = BookCaseGrade.GetData("bookCase_id=@bookCase_id");
        
        System.Text.StringBuilder tempGeaidStringBuilder = new System.Text.StringBuilder();
        foreach (DataRow row in dtGrade.Rows)
        {
            tempGeaidStringBuilder.Append(String.Format(",{0},", row["grade_id"]));
        }

        foreach (ListItem item in cblGrade.Items)
        {
            if (tempGeaidStringBuilder.ToString().IndexOf(String.Format(",{0},", item.Value)) >= 0)
            {
                item.Selected = true;
            }
        }
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        if (_myPerson.Role == Person.LoginRole.Teacher)
        {
            bool flag = false;
            foreach (ListItem item in cblGrade.Items)
            {
                if (item.Selected)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                My.WebForm.doJavaScript("alert('請選擇班級！！')");
                return;
            }
        }

        _BookCase.SetPlaceHolderFormQuest();
        _BookCase.UpdateById(Request["id"]);
        _AttachmentFile.SetPlaceHolderFormQuest();
        string Path = GetMyPath();
        string filePic = "";
        if (fuPic.HasFile)
        {
            string PicExtension = fuPic.FileName.Split('.')[fuPic.FileName.Split('.').Length - 1];
            //新檔案名稱
            filePic = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, PicExtension);

            fuPic.SaveAs(String.Format("{0}/{1}", Path, filePic));
            _AttachmentFile.AddParameter("coverPicName", filePic);
        }


        _AttachmentFile.UpdateById(ViewState["file_id"].ToString());

        EasyDataProvide BookCaseGrade = new EasyDataProvide("BookCaseGrade");
        if (_myPerson.Role == Person.LoginRole.Teacher)
        {
            BookCaseGrade.AddParameter("bookCase_id", Request["id"]);
            BookCaseGrade.Delete("bookCase_id=@bookCase_id");
            foreach (ListItem item in cblGrade.Items)
            {
                if (item.Selected)
                {
                    BookCaseGrade.AddParameter("bookCase_id", Request["id"]);
                    BookCaseGrade.AddParameter("grade_id", item.Value);
                    BookCaseGrade.Insert();
                }
            }

        }



        My.WebForm.doJavaScript("alert('修改成功');location.href='BookCase_List.aspx'");
    }
    private string GetMyPath()
    {
        string Path = ConfigurationManager.AppSettings["FileUploadPath"].ToString();

        System.IO.DirectoryInfo directory = new DirectoryInfo(Server.MapPath(String.Format("{0}/{1}", Path, _myPerson.School_id)));
        if (!directory.Exists)
        {
            directory.Create();
        }
        System.IO.DirectoryInfo directory1 = new DirectoryInfo(Server.MapPath(String.Format("{0}/{1}/{2}", Path, _myPerson.School_id, _myPerson.people_id)));
        if (!directory1.Exists)
        {
            directory1.Create();
        }

        return Server.MapPath(String.Format("{0}/{1}/{2}", Path, _myPerson.School_id, _myPerson.people_id));
    }
}

