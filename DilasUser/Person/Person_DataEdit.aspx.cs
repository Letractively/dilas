using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Person_Person_DataEdit : System.Web.UI.Page
{
    EasyDataProvide _people = new EasyDataProvide("People");
    EasyDataProvide _telephone = new EasyDataProvide("Telephone");
    EasyDataProvide _address = new EasyDataProvide("Address");
    EasyDataProvide _account = new EasyDataProvide("Account");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Show();
        }
    }

    private void Show()
    {
        ViewState["tel"] = "";
        ViewState["address"] = "";
        DataRow row = _people.FillPlaceHolderControlsById((new Person()).people_id);
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
        DPeople dPeople = new DStudent((new Person()).people_id);
        username.Text = dPeople.Account;
        emailAddress.Text = dPeople.Email;

        myPhoto.ImageUrl = row["myPhoto"].ToString() == "" ? (row["gender"].ToString() == "True" ? "~/images/Male90x85.jpg" : "~/images/FeMale90x85.jpg") : String.Format("{0}/{1}/{2}/M{3}", ConfigurationManager.AppSettings["FileUploadPath"], (new Person()).School_id, row["id"], row["myPhoto"]);



    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        string areaID = "";
        string telID = "";

        //新增或修改電話
        _telephone.AddParameter("areaCode", areaCode.Value);
        _telephone.AddParameter("numberCode", numberCode.Value);

        if (string.IsNullOrEmpty(ViewState["tel"].ToString()))
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

        //更新Pepole
        EasyDataProvide People = new EasyDataProvide("People");
        People.SetPlaceHolderFormQuest();
        People.AddParameter("address_id", telID);
        People.AddParameter("telephone_id", areaID);
        string Path = GetMyPath();
        string filePic = "";
        if (fuMyPhoto.HasFile)
        {
            string PicExtension = fuMyPhoto.FileName.Split('.')[fuMyPhoto.FileName.Split('.').Length - 1];
            //新檔案名稱
            filePic = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, PicExtension);

            fuMyPhoto.SaveAs(String.Format("{0}/{1}", Path, filePic));
            My.WebForm.GenerateThumbnailImage(filePic, fuMyPhoto.PostedFile.InputStream, Path, "M", 90, 85);
            My.WebForm.GenerateThumbnailImage(filePic, fuMyPhoto.PostedFile.InputStream, Path, "S", 54, 61);

            People.AddParameter("myPhoto", filePic);
        }


        People.UpdateById((new Person()).people_id);

        //更新帳號

        _account.AddParameter("password", FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"));
        _account.AddParameter("emailAddress", emailAddress.Text);
        _account.AddParameter("people_id", (new Person()).people_id);
        _account.UpdateById((new Person()).people_id);
        My.WebForm.doJavaScript("alert('修改成功');location.href='Person_DataEdit.aspx'");

        
    }

    private string GetMyPath()
    {
        Person person = new Person();
        string Path = ConfigurationManager.AppSettings["FileUploadPath"].ToString();

        System.IO.DirectoryInfo directory = new DirectoryInfo(Server.MapPath(String.Format("{0}/{1}", Path, person.School_id)));
        if (!directory.Exists)
        {
            directory.Create();
        }
        System.IO.DirectoryInfo directory1 = new DirectoryInfo(Server.MapPath(String.Format("{0}/{1}/{2}", Path, person.School_id, person.people_id)));
        if (!directory1.Exists)
        {
            directory1.Create();
        }

        return Server.MapPath(String.Format("{0}/{1}/{2}", Path, person.School_id, person.people_id));
    }
}