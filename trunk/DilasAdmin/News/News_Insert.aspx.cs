using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Insert : System.Web.UI.Page
{
    readonly DataLayer _dl = new DataLayer();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["GUID"] = Guid.NewGuid().ToString();
            //ShowOrg();
            ShowClass1();
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
        DataTable dtClass = ModuleClass.GetData(string.Format("moduleID='{0}'", Request["ModuleID"]));
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
        if (ddlFile.SelectedValue == "�ɮפW��")
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

        if (string.IsNullOrEmpty(article.Text))
        {
            My.WebForm.doJavaScript("alert('�Բӻ������i�H�ť�.');");
            return;
        }
        if (shortDescription.Text.Length >= 500)
        {
            My.WebForm.doJavaScript("alert('²�满�����i�H�W�L500�Ӧr.');");
            return;
        }
        Person person = new Person();

        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        ModulePublish.SetPlaceHolderFormQuest();
        //�B�z�W���ɮ�
        if (ddlFile.SelectedValue == "�ɮפW��" && fuFile.HasFile)
        {
            //���o���ɦW
            string Extension = fuFile.FileName.Split('.')[fuFile.FileName.Split('.').Length - 1];
            //�s�ɮצW��
            string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
            fuFile.SaveAs(Server.MapPath(String.Format("~/UploadFiles/Files/{0}", fileName)));
            ModulePublish.AddParameter("fileUrl", fileName);

        }

        //�B�z�W�ǹϤ�

        if (fuPic.HasFile)
        {
            if (fuPic.PostedFile.ContentType.IndexOf("image") == -1)
            {
                My.WebForm.doJavaScript("alert('�ɮ׫��A���~!');");
                return;
            }

            //���o���ɦW
            string Extension = fuPic.FileName.Split('.')[fuPic.FileName.Split('.').Length - 1];
            //�s�ɮצW��
            string fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
            fuPic.SaveAs(Server.MapPath(String.Format("~/UploadFiles/Images/{0}", fileName)));
            ModulePublish.AddParameter("picUrl", fileName);

        }

        ModulePublish.AddParameter("id", ViewState["GUID"].ToString());
        ModulePublish.AddParameter("moduleID", Request["ModuleID"]);
        ModulePublish.AddParameter("OrgID", person.School_id);
        //ModulePublish.AddParameter("OrgNames", ddlOrg.SelectedItem.Text);
        ModulePublish.AddParameter("classID", ddlClass1.SelectedValue);
        ModulePublish.AddParameter("poster", person.people_id);
       

        
        //���񵲧�����ɡA�]�w�@��800�~�᪺���
        if (string.IsNullOrEmpty(endDate.Text))
        {
            ModulePublish.AddParameter("endDate", "2800/1/1");
        }

       
        //if (DataLayer.IsInRole("admins", HttpContext.Current.User.Identity.Name))
        //{
        //    ModulePublish.addParameter("beSelect", "1"); //admin �s�յo�G��
        //}
        ModulePublish.Insert();

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", ViewState["GUID"].ToString());
        ModuleContents.AddParameter("article", article.Text);
        ModuleContents.Insert();
        Session[Request["ModuleID"] + "ddlOrg"] = ddlOrg.SelectedValue;
        Session[Request["ModuleID"] + "Class1"] = ddlClass1.SelectedValue;
        Response.Redirect("News_List.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + ViewState["GUID"]);


    }
}