using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class School_Edit : System.Web.UI.Page
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
            ViewState["tel"] = telRow["id"].ToString();
            areaCode.Value = telRow["areaCode"].ToString();
            numberCode.Value = telRow["numberCode"].ToString();
        }

        DataRow areaRow = _address.GetById(row["address_id"].ToString());
        if (areaRow != null)
        {
            ViewState["address"] = areaRow["id"].ToString();
            hidzip.Value = areaRow["zip"].ToString();
            address.Value = areaRow["address"].ToString();
        }





    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        string areaID = "";
        string telID = "";

        //新增或修改電話
        _telephone.AddParameter("areaCode", areaCode.Value);
        _telephone.AddParameter("numberCode", numberCode.Value);

        if (string.IsNullOrEmpty( ViewState["tel"].ToString()))
        {
            telID = _telephone.InsertReturnValue();
        }
        else
        {
            _telephone.UpdateById(ViewState["tel"].ToString());
            telID = ViewState["tel"].ToString();
        }

        //新增或修改地址
        _address.AddParameter("city", Request["city"]);
        _address.AddParameter("division", Request["division"]);
        _address.AddParameter("zip", Request["zip"]);
        _address.AddParameter("address", address.Value);
        if (string.IsNullOrEmpty(ViewState["address"].ToString()))
        {
            areaID = _address.InsertReturnValue();
        }
        else
        {
            _address.UpdateById(ViewState["address"].ToString());
            areaID = ViewState["address"].ToString();
        }
        
        //修改學校資料
        _school.SetPlaceHolderFormQuest();
        _school.RemoveParameter("id");
        _school.AddParameter("address_id", areaID);
        _school.AddParameter("telephone_id", telID);
        _school.UpdateById(Request["id"]);




        My.WebForm.doJavaScript("alert('修改成功');location.href='School_List.aspx'");
    }
}