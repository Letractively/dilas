using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_BookCase_BookCase_Insert : System.Web.UI.Page
{
    Person _myPerson = new Person();
    protected void Page_Load(object sender, EventArgs e)
    {




        if (!Page.IsPostBack)
        {
            //驗證身份
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


        }
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

    private void ShowTabs()
    {
        EasyDataProvide BookTab = new EasyDataProvide("BookTab");
        BookTab.AddParameter("people_id", _myPerson.people_id);
        DataTable dt = BookTab.GetData("people_id=@people_id or status=2");
        tab_id.DataTextField = "subject";
        tab_id.DataValueField = "id";
        tab_id.DataSource = dt;
        tab_id.DataBind();
        
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


        EasyDataProvide AttachmentFile = new EasyDataProvide("AttachmentFile");
        EasyDataProvide BookCase = new EasyDataProvide("BookCase");
        AttachmentFile.SetPlaceHolderFormQuest();
        //取得副檔名
        string Path = GetMyPath();


        if (!fuFile.HasFile)
        {
            My.WebForm.doJavaScript("alert('請上傳檔案')");
            return;
        }
        string Extension = fuFile.FileName.Split('.')[fuFile.FileName.Split('.').Length - 1];
        //新檔案名稱
        string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);

        fuFile.SaveAs(String.Format("{0}/{1}", Path, fileName));

        string filePic = "";
        if (fuPic.HasFile)
        {
            string PicExtension = fuPic.FileName.Split('.')[fuPic.FileName.Split('.').Length - 1];
            //新檔案名稱
            filePic = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, PicExtension);

            fuPic.SaveAs(String.Format("{0}/{1}", Path, filePic));
            My.WebForm.GenerateThumbnailImage(filePic, fuPic.PostedFile.InputStream, Path, "S", 86, 69);

            AttachmentFile.AddParameter("coverPicName", filePic);
        }


        AttachmentFile.AddParameter("fileName", fileName);
        AttachmentFile.AddParameter("extension", Extension);
        AttachmentFile.AddParameter("school_id", _myPerson.School_id);
        AttachmentFile.AddParameter("people_id", _myPerson.people_id);


        EasyDataProvide School = new EasyDataProvide("School");
        DataRow row = School.GetById(_myPerson.School_id);
        string domainName = "";
        if (row != null)
        {
            domainName = row["domainName"].ToString();
        }
        AttachmentFile.AddParameter("domainName", domainName);
        string file_id = AttachmentFile.InsertReturnValue();


        BookCase.SetPlaceHolderFormQuest();
        BookCase.AddParameter("file_id", file_id);
        BookCase.AddParameter("school_id", _myPerson.School_id);
        BookCase.AddParameter("people_id", _myPerson.people_id);
        BookCase.AddParameter("role", _myPerson.Role == Person.LoginRole.Teacher ? "0" : "1");

        string BookCaseID = BookCase.InsertReturnValue();
        EasyDataProvide BookCaseGrade = new EasyDataProvide("BookCaseGrade");
        if (_myPerson.Role == Person.LoginRole.Teacher)
        {
            foreach (ListItem item in cblGrade.Items)
            {
                if (item.Selected)
                {
                    BookCaseGrade.AddParameter("bookCase_id", BookCaseID);
                    BookCaseGrade.AddParameter("grade_id", item.Value);
                    BookCaseGrade.Insert();
                }
            }

        }
        else
        {
            DStudent dStudent=new DStudent(_myPerson.people_id);
            BookCaseGrade.AddParameter("bookCase_id", BookCaseID);
            BookCaseGrade.AddParameter("grade_id", dStudent.GradeID);
            BookCaseGrade.Insert();
        }
        My.WebForm.doJavaScript("alert('新增成功');location.href='BookCase_List.aspx'");
        
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