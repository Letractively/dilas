﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class DilasUser_Discusses_Discusses_Class : System.Web.UI.Page
{
    EasyDataProvide _ModuleClass = new EasyDataProvide("ModuleClass");


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Show();
        }
    }

    private void Show()
    {
        _ModuleClass.AddParameter("moduleID", Request["ModuleID"]);
        _ModuleClass.AddParameter("OrgID", Request["grade_id"]);
        DataTable dt = _ModuleClass.GetData("[moduleID] = @moduleID and OrgID=@OrgID", "ORDER BY [listNum]");
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtAdd.Text.Trim() == "")
        {
            return;
        }

        EasyDataProvide ModuleClass = new EasyDataProvide("ModuleClass");
        ModuleClass.AddParameter("className", txtAdd.Text);
        ModuleClass.AddParameter("OrgID", Request["grade_id"]);
        ModuleClass.AddParameter("moduleID", Request["ModuleID"]);

        ModuleClass.Insert();
        txtAdd.Text = "";
        Show();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (DataControlField col in GridView1.Columns)
            {
                if (col.HeaderText == "刪除")
                {
                    e.Row.Cells[GridView1.Columns.IndexOf(col)].Attributes.Add("onclick",
                                          "javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;");
                }
            }

        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            string id = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
            TextBox listNum = (TextBox)row.FindControl("listNum");
            _ModuleClass.AddParameter("listNum", listNum.Text);
            _ModuleClass.UpdateById(id);

        }
        Show();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Show();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        TextBox TextBox1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
        _ModuleClass.AddParameter("className", TextBox1.Text);
        _ModuleClass.UpdateById(id);
        GridView1.EditIndex = -1;
        Show();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Show();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        _ModuleClass.DeleteById(id);
        Show();
    }
}
