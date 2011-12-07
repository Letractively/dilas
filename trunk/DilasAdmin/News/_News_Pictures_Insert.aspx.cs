using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Pictures_Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        EasyDataProvide ModulePictures = new EasyDataProvide("ModulePictures");
        FileUploadSetup fus = new FileUploadSetup();
        fus.name = "picUrl";
        fus.fileType = FileUploadSetup.UpfileType.Image;
        fus.allowNoFile = false;


        ThumbnailImage timg = new ThumbnailImage();
        timg.suffix = "s";
        timg.maxWidth = 142;
        timg.MaxHight = 89;

        fus.ThumbnailImages.Add(timg);
        ModulePictures.FileUploadSetups.Add(fus);
        try
        {
            ModulePictures.SetPageFormQuest();
        }
        catch (Exception ex1)
        {
            lblError.Text = ex1.Message;
            return;
        }

        ModulePictures.AddParameter("publishID", Request["publishID"].ToString());

        ModulePictures.Insert();
        string Publish = "_News_Pictures.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["publishID"];
        My.WebForm.doJavaScript(String.Format("parent.tb_remove();parent.location='{0}';", Publish));
    }
}