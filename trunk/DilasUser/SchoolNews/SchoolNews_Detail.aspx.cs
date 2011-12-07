using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_SchoolNews_SchoolNews_Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ModuleID = Request["ModuleID"];
            show();


        }
    }

    private void show()
    {
        EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
        DataRow row = ModulePublish.FillPlaceHolderControlsById(Request["ID"]);
       

        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["ID"]);
        DataRow rowArticle = ModuleContents.GetSingleRow("publishID=@publishID");
        if (rowArticle != null) article.Text =My.WebForm.TXT2HTML(rowArticle["article"].ToString()) ;

        EasyDataProvide ModuleFiles = new EasyDataProvide("ModuleFiles");
        ModuleFiles.AddParameter("publishID", Request["ID"].ToString());
        DataTable dt = ModuleFiles.GetData("publishID=@publishID", "order by listNum asc");
        dlFiles.DataSource = dt;
        dlFiles.DataBind();
    }
}