using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Discusses_Discusses_Insert : System.Web.UI.Page
{
    readonly DataLayer _dl = new DataLayer();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["GUID"] = Guid.NewGuid().ToString();
            //ShowOrg();
            ShowClass1();
            if (ddlClass1.Items.Count == 0)
            {
                My.WebForm.doJavaScript("alert('尚未建立類別，請先建立類別，謝謝！');location.href='Discusses_List.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + ViewState["GUID"] + "&grade_id=" + Request["grade_id"] + "'");
            }
            if (Session[Request["ModuleID"] + "Class1"] != null)
            {
                ddlClass1.SelectedValue = Session[Request["ModuleID"] + "Class1"].ToString();
            }
            initDate.Text = DateTime.Now.ToString("d");
            startDate.Text = DateTime.Now.ToString("d");
        }
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

        ModulePublish.AddParameter("id", ViewState["GUID"].ToString());
        ModulePublish.AddParameter("moduleID", Request["ModuleID"]);
        ModulePublish.AddParameter("OrgID", Request["grade_id"]);
        //ModulePublish.AddParameter("OrgNames", ddlOrg.SelectedItem.Text);
        ModulePublish.AddParameter("classID", ddlClass1.SelectedValue);
        ModulePublish.AddParameter("poster", person.people_id);



        //不填結束日期時，設定一個800年後的日期
        if (string.IsNullOrEmpty(endDate.Text))
        {
            ModulePublish.AddParameter("endDate", "2800/1/1");
        }


        //if (DataLayer.IsInRole("admins", HttpContext.Current.User.Identity.Name))
        //{
        //    ModulePublish.addParameter("beSelect", "1"); //admin 群組發佈的
        //}
        ModulePublish.Insert();

        //EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        //ModuleContents.AddParameter("publishID", ViewState["GUID"].ToString());
        //ModuleContents.AddParameter("article", article.Text);
        //ModuleContents.Insert();
        Session[Request["ModuleID"] + "Class1"] = ddlClass1.SelectedValue;
        Response.Redirect("Discusses_List.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + ViewState["GUID"] + "&grade_id=" + Request["grade_id"]);


    }
}
