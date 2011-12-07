using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolZone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Person myPerson = new Person();

            DPeople people = new DTeacher(myPerson.people_id);
            switch (myPerson.Role)
            {
                case Person.LoginRole.Teacher:
                    Response.Redirect("~/DilasUser/SchoolNews/SchoolNews_List.aspx?ModuleID=B01"); //學校公告
                    break;
                case Person.LoginRole.Student:
                    Response.Redirect("~/DilasUser/PrepareLesson/TodayLesson.aspx"); //班級塗鴉牆

                    break;
                case Person.LoginRole.Parent:
                    Response.Redirect("~/DilasUser/ContactBook/ContactBook_SelectChildren.aspx"); //聯絡簿
                    break;


                case Person.LoginRole.SchoolAdmin:
                    Response.Redirect("~/DilasAdmin/News/News_List.aspx?ModuleID=B01"); //學校公告
                    break;
                case Person.LoginRole.Administrator:
                    Response.Redirect("~/DilasAdmin/School/School_List.aspx"); //學校管理
                    break;
            }

        }
    }
}