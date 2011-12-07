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

public partial class DilasUser_BookCase_BookCase_Search_View : System.Web.UI.Page
{
    EasyDataProvide _BookCase = new EasyDataProvide("BookCase");
    EasyDataProvide _AttachmentFile = new EasyDataProvide("AttachmentFile");
    Person _myPerson = new Person();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role == Person.LoginRole.SchoolAdmin || myPerson.Role == Person.LoginRole.Administrator || myPerson.Role == Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }

         
            Show();
        }
    }

    private void Show()
    {
        DataRow rowBookCase = _BookCase.FillPlaceHolderControlsById(Request["id"]);
        if (rowBookCase == null) return;
        DataRow rowAttachmentFile = _AttachmentFile.FillPlaceHolderControlsById(rowBookCase["file_id"].ToString());
        ViewState["file_id"] = rowBookCase["file_id"].ToString();
        if (rowAttachmentFile == null) return;

        coverPicName.ImageUrl = ConfigurationManager.AppSettings["FileUploadPath"] + "/" + rowAttachmentFile["school_id"] + "/" + rowAttachmentFile["people_id"] + "/" + rowAttachmentFile["coverPicName"];
        //hlFileName.NavigateUrl = ConfigurationManager.AppSettings["FileUploadPath"] + "/" + rowAttachmentFile["school_id"] + "/" + rowAttachmentFile["people_id"] + "/" + rowAttachmentFile["fileName"];

        type.Text = type.Text.ToScodeBookTypeName();
        publicLevel.Text = publicLevel.Text.ToScodePublicLevelName();
    }
    protected void lnkAddMyBookCase_Click(object sender, EventArgs e)
    {
        
        EasyDataProvide BookCase = new EasyDataProvide("BookCase");
        


        BookCase.SetPlaceHolderFormQuest();
        BookCase.AddParameter("file_id", ViewState["file_id"].ToString());
        BookCase.AddParameter("school_id", _myPerson.School_id);
        BookCase.AddParameter("people_id", _myPerson.people_id);
        BookCase.AddParameter("tab_id", "9");
        BookCase.AddParameter("role", _myPerson.Role == Person.LoginRole.Teacher ? "0" : "1");

        BookCase.Insert();

        Response.Redirect("BookCase_List.aspx");
    }
}