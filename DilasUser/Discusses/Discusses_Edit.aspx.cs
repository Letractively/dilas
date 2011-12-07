using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Discusses_Discusses_Edit : System.Web.UI.Page
{
    DataLayer dl = new DataLayer();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ModuleID = Request["ModuleID"];
            //ShowOrg();
            ShowClass1();
            show();
            ddlClass1.Enabled = false;


        }
    }

    private void show()
    {
        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        DataRow row = ModulePublish.FillPlaceHolderControlsById(Request["ID"]);
        ddlClass1.SelectedValue = row["classID"].ToString();
        //ddlOrg.SelectedValue = row["OrgID"].ToString();
        if (endDate.Text == "2800/1/1")
        {
            endDate.Text = "";
        }
        picUrlLink.NavigateUrl = "~/UploadFiles/Images/" + row["picUrl"].ToString();
        fileUrlLink.NavigateUrl = "~/UploadFiles/Files/" + row["fileUrl"].ToString();

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["ID"]);
        DataRow rowArticle = ModuleContents.GetSingleRow("publishID=@publishID");
        if (rowArticle != null) article.Text = rowArticle["article"].ToString();

        //if (!DataLayer.IsInRole("admins", User.Identity.Name))
        //{
        //    if (row["beSelect"].ToString() != "0") //不是自己發佈的
        //    {
        //        OrgControl.checkBoxList.Enabled = false;
        //        InsertButton.Visible = false;
        //    }
        //    else
        //    {
        //        string[] strUserData = ((FormsIdentity)(User.Identity)).Ticket.UserData.Split(new Char[] { ';' });
        //        for (int i = OrgControl.checkBoxList.Items.Count - 1; i >= 0; i--)
        //        {
        //            ListItem item = OrgControl.checkBoxList.Items[i];
        //            if (item.Value.IndexOf(strUserData[5]) == -1)
        //            {
        //                OrgControl.checkBoxList.Items.Remove(item);

        //            }
        //        }

        //    }

        //}
    }

    private void ShowClass1()
    {
        EasyDataProvide ModuleClass = new EasyDataProvide("ModuleClass");
        ModuleClass.AddParameter("ModuleID", Request["ModuleID"]);
        ModuleClass.AddParameter("OrgID", Request["grade_id"]);
        DataTable dtClass = ModuleClass.GetData("ModuleID=ModuleID and OrgID=@OrgID");
        ddlClass1.DataSource = dtClass;
        ddlClass1.DataBind();
    }

    //private void ShowOrg()
    //{
    //    EasyDataProvide UnitName = new EasyDataProvide("UnitName");
    //    DataTable dt = UnitName.GetAllData();
    //    ddlOrg.DataSource = dt;
    //    ddlOrg.DataBind();


    //}

    protected void InsertButton_Click(object sender, EventArgs e)
    {

        Person person = new Person();

        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        ModulePublish.SetPlaceHolderFormQuest();
        //處理上傳檔案
        if (ddlFile.SelectedValue == "檔案上傳" && fuFile.HasFile)
        {
            //取得副檔名
            string Extension = fuFile.FileName.Split('.')[fuFile.FileName.Split('.').Length - 1];
            //新檔案名稱
            string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
            fuFile.SaveAs(Server.MapPath(String.Format("~/UploadFiles/Files/{0}", fileName)));
            ModulePublish.AddParameter("fileUrl", fileName);

        }

        //處理上傳圖片

        if (fuPic.HasFile)
        {
            if (fuPic.PostedFile.ContentType.IndexOf("image") == -1)
            {
                My.WebForm.doJavaScript("alert('檔案型態錯誤!');");
                return;
            }

            //取得副檔名
            string Extension = fuPic.FileName.Split('.')[fuPic.FileName.Split('.').Length - 1];
            //新檔案名稱
            string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
            fuPic.SaveAs(Server.MapPath(String.Format("~/UploadFiles/Images/{0}", fileName)));
            My.WebForm.GenerateThumbnailImage(fileName, fuPic.PostedFile.InputStream, Server.MapPath("~/UploadFiles/Images"), "S", 69, 50);
            ModulePublish.AddParameter("picUrl", fileName);

        }

        ModulePublish.AddParameter("classID", ddlClass1.SelectedValue);
        //ModulePublish.AddParameter("OrgID", ddlOrg.SelectedValue);
        //ModulePublish.AddParameter("OrgNames", ddlOrg.SelectedItem.Text);
        //ModulePublish.AddParameter("updater", person.name);
        //ModulePublish.AddParameter("updaterUnit", person.organization);
        //ModulePublish.AddParameter("lastupdated", DateTime.Now.ToString());
        //不填結束日期時，設定一個800年後的日期
        if (string.IsNullOrEmpty(endDate.Text))
        {
            ModulePublish.AddParameter("endDate", "2800/1/1");
        }
        ModulePublish.UpdateById(Request["ID"]);

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["ID"]);
        ModuleContents.AddParameter("article", article.Text);
        ModuleContents.Update("publishID=@publishID");


        Response.Redirect(String.Format("Discusses_List.aspx?ModuleID={0}&page={1}&grade_id={2}", Request["ModuleID"], Request["page"], Request["grade_id"]));
    }

    protected void ddlFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFile.SelectedValue == "檔案上傳")
        {
            fuFile.Visible = true;
            fileUrl.Visible = false;
        }
        else
        {
            fuFile.Visible = false;
            fileUrl.Visible = true;
        }


    }
}