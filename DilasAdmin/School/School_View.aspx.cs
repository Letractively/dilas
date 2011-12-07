using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtensionMethods;
using TIN;

public partial class School_View : System.Web.UI.Page
{
    EasyDataProvide _school = new EasyDataProvide("School");
    EasyDataProvide _telephone = new EasyDataProvide("Telephone");
    EasyDataProvide _address = new EasyDataProvide("Address");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //驗證身份
            Person myPerson = new Person();
            if (myPerson.Role != Person.LoginRole.Administrator)
            {
                Response.Redirect("~/Default.aspx");
            }
            //只有總管才可以停用與編輯

            if (myPerson.Role == Person.LoginRole.Administrator)
            {
                PublishTab1.isOpenEditTab = true;

            }
            Show();
        }
    }

    private void Show()
    {
        ViewState["tel"] = "";
        ViewState["address"] = "";
        DataRow row = _school.FillPlaceHolderControlsById(Request["id"]);
        if (row == null) return;

        DataRow telRow = _telephone.GetById(row["telephone_id"].ToString());
        if (telRow != null)
        {
            telephone_id.Text = String.Format("({0}){1}", telRow["areaCode"], telRow["numberCode"]);
        }

        DataRow areaRow = _address.GetById(row["address_id"].ToString());
        if (areaRow != null)
        {
            address_id.Text = String.Format("{0}{1}{2}{3}", areaRow["zip"], areaRow["city"], areaRow["division"], areaRow["address"]);

        }
        description.Text = My.WebForm.TXT2HTML(description.Text);
        enable.Text = enable.Text.ToScodeEnableName();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("School_Edit.aspx?id=" + Request["id"]);
    }
}