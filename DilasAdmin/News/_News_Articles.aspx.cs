using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Articles : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
            EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
            DataRow row = ModulePublish.GetById(Request["ID"]);
            ViewState["title"] = row["title"];
            //if (!DataLayer.IsInRole("admins", User.Identity.Name))
            //{
            //    if (row["beSelect"].ToString() != "0") //���O�ۤv�o�G��
            //    {
            //        btnSure.Visible = false;
            //    }

            //}
        }
    }

    private void show()
    {
        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["ID"]);
        ModuleContents.FillContentPlaceHolderControls("publishID=@publishID");
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["ID"]);
        DataRow row = ModuleContents.GetSingleRow("publishID=@publishID");
        ModuleContents.SetPlaceHolderFormQuest();
        if (row == null)
        {
            ModuleContents.Insert();
        }
        else
        {
            //DataLayer.setBehaviour("�ʺA�o���t��", "�ק�" + ViewState["title"]);
            ModuleContents.Update("publishID=@publishID");
        }

        Response.Redirect("_News_Files.aspx?ModuleID=" + Request["ModuleID"] + "&ID=" + Request["ID"]);
    }
}