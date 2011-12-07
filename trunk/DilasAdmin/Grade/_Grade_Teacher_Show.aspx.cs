using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasAdmin_Grade_Grade_Teacher_Show : System.Web.UI.Page
{
    private readonly DataLayer dl = new DataLayer();
    private const int PageSize = 15;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        Show();
    }

    private void Show()
    {
        string name = txtSearch.Text == "請輸入關鍵字" ? "" : txtSearch.Text;

        int totaleItems = dl.GetTeacherListCount((new Person()).School_id, name, "-1", "-1", " and People.id not in( select teacher_id from dbo.GradeTeacher where grade_id = @searchId )", Request["GradeId"]);
        Pagination1.totalitems = totaleItems;
        Pagination1.limit = PageSize;
        Pagination1.targetpage = "_Grade_Teacher_Show.aspx";
        //技巧:利用這種方式才可以呼叫usercontrol裡的public method
        UserControl_Pagination uc = Pagination1;
        uc.showPageControls();
        DataTable dt = dl.GetTeacherList((new Person()).School_id, name, "-1", "-1", " and People.id not in( select teacher_id from dbo.GradeTeacher  where grade_id = @searchId )", Request["GradeId"], PageSize, Request["page"] == null ? 1 : int.Parse(Request["page"]));
        gvList.DataSource = dt;
        gvList.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable TempDt = GetTempDataTable(); // get DataTable in session

        //get gvList Data
        foreach (GridViewRow Grow in gvList.Rows)
        {
            if (((CheckBox)Grow.FindControl("CheckBox1")).Checked)
            {
                string ID = gvList.DataKeys[Grow.RowIndex].Value.ToString();

                //判斷是否有重複
                DataRow[] sRow = TempDt.Select("id='" + ID + "'");
                if (sRow.Length == 0)
                {
                    DataRow row = TempDt.NewRow();
                    row["id"] = ID;
                    row["rank"] = ((Label)Grow.FindControl("lblRank")).Text;
                    row["name"] = Grow.Cells[2].Text;
                    row["gender"] = ((Label)Grow.FindControl("lblGender")).Text;
                    TempDt.Rows.Add(row);
                }


            }


        }
        Session["Datatable"] = TempDt; // save to session
        GridView1.DataSource = TempDt;
        GridView1.DataBind();
    }

    /// <summary>
    /// 取得session裡的tempDataTable,若是session裡面沒有，則在記憶體新增一個新的DataTable,若session裡面有則從session取出資料
    /// </summary>
    /// <returns>DataTable</returns>
    DataTable GetTempDataTable()
    {
        DataTable TempDt;
        if (Session["Datatable"] == null)
        {
            TempDt = new DataTable();
            TempDt.Columns.Add("id", typeof(string));
            TempDt.Columns.Add("rank", typeof(string));
            TempDt.Columns.Add("name", typeof(string));
            TempDt.Columns.Add("gender", typeof(string));
        }
        else
        {
            TempDt = (DataTable)Session["Datatable"];

        }
        return TempDt;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        EasyDataProvide GradeTeacher = new EasyDataProvide("GradeTeacher");
        foreach (GridViewRow row in GridView1.Rows)
        {
            string ID = GridView1.DataKeys[row.RowIndex].Value.ToString();
            GradeTeacher.AddParameter("teacher_id", ID);
            GradeTeacher.AddParameter("grade_id", Request["GradeId"].ToString());
            DropDownList ddlClassify = (DropDownList)row.FindControl("ddlClassify");
            GradeTeacher.AddParameter("classify", ddlClassify.SelectedValue);
            GradeTeacher.Insert();
        }

        Session["Datatable"] = null; //session 清空
        My.WebForm.doJavaScript("parent.tb_remove();parent.location.reload()");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable TempDt = GetTempDataTable(); // get DataTable in session
        TempDt.Rows.RemoveAt(e.RowIndex);
        Session["Datatable"] = TempDt; // save to session
        GridView1.DataSource = TempDt;
        GridView1.DataBind();
    }
   
}