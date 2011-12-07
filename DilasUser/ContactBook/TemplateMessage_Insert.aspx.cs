using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_ContactBook_TemplateMessage_Insert : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person person = new Person();
            //驗證身份
            if (person.Role == Person.LoginRole.SchoolAdmin || person.Role == Person.LoginRole.Administrator ||
                person.Role == Person.LoginRole.Parent || person.Role == Person.LoginRole.Student)
            {
                Response.Redirect("~/Default.aspx");
            }
            
        }
    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Person person = new Person();
        EasyDataProvide TemplateMessage = new EasyDataProvide("TemplateMessage");
        TemplateMessage.AddParameter("messages", messages.Text);
        TemplateMessage.AddParameter("people_id", person.people_id);
        TemplateMessage.Insert();
        My.WebForm.doJavaScript("parent.tb_remove();parent.location.reload()");
    }
}