using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DilasUser_ContactBook_ContactBook_SelectChildren : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Person myPerson = new Person();
            //驗證身份
            if (myPerson.Role != Person.LoginRole.Parent)
            {
                Response.Redirect("~/Default.aspx");
            }
            Show();
        }
    }

    private void Show()
    {
        DParent parent=new DParent((new Person()).people_id);
        DataTable dt = parent.GetMyChildrens();
        DataList1.DataSource = dt;
        DataList1.DataBind();

       

    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        HyperLink hlPhoto = (HyperLink) e.Item.FindControl("hlPhoto");
        DataRowView row = (DataRowView)e.Item.DataItem;
        hlPhoto.ImageUrl = row["myPhoto"].ToString() == "" ? (row["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, row["id"], row["myPhoto"]); ;
    }
}