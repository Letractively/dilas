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

public partial class DilasUser_BookCase_BookCase_View : System.Web.UI.Page
{
    EasyDataProvide _BookCase = new EasyDataProvide("BookCase");
    EasyDataProvide _AttachmentFile = new EasyDataProvide("AttachmentFile");
    
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
            //只有學生和老師才可以編輯

            if (myPerson.Role == Person.LoginRole.Teacher || myPerson.Role == Person.LoginRole.Student)
            {
                PublishTab1.isOpenEditTab = true;
            }

            if (myPerson.Role == Person.LoginRole.Teacher)
            {
                PublishTab1.isOpenFun1Tab = true;
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
        hlFileName.NavigateUrl = ConfigurationManager.AppSettings["FileUploadPath"] + "/" + rowAttachmentFile["school_id"] + "/" + rowAttachmentFile["people_id"] + "/" + rowAttachmentFile["fileName"];

        type.Text = type.Text.ToScodeBookTypeName();
        publicLevel.Text = publicLevel.Text.ToScodePublicLevelName();
    }
}