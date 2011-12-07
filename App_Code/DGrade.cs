using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using TIN;

/// <summary>
/// DGrade 的摘要描述
/// </summary>
public class DGrade
{
    EasyDataProvide _grade = new EasyDataProvide("Grade");
    readonly SqlConnection _connection;
    public DGrade()
    {
        _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    }
    #region "根據班級編號取得班級完整名稱如:XX國小X年X班"
    /// <summary>
    /// 根據班級編號取得班級完整名稱如:XX國小X年X班
    /// </summary>
    /// <param name="gradeId">班級編號</param>
    /// <returns>班級完整名稱</returns>
    public string GetFullGradeNameById(int gradeId)
    {
        DataRow row = _grade.GetById(gradeId.ToString());
        //取得學校名稱
        DSchool dSchool = new DSchool();
        String schoolAllName = dSchool.GetNameBySchoolId(row["school_id"].ToString());


        //取得班級名稱
        String gradeAllName = String.Format("{0}年{1}班", row["currentYear"], row["name"]);

        return schoolAllName + gradeAllName;

    }
    #endregion
    

    #region "根據班級編號取得班級名稱如:X年X班"
    /// <summary>
    /// 根據班級編號取得班級名稱如:X年X班
    /// </summary>
    /// <param name="gradeId">班級編號</param>
    /// <returns>班級完整名稱</returns>
    public string GetShortGradeNameById(int gradeId)
    {
        DataRow row = _grade.GetById(gradeId.ToString());

        //取得班級名稱
        return String.Format("{0}年{1}班", row["currentYear"], row["name"]);


    }
    #endregion
    

    #region "利用班級編號取得該班學生人數"
    /// <summary>
    /// 利用班級編號取得該班學生人數
    /// </summary>
    /// <param name="gradeId">班級編號</param>
    /// <returns>班級學生人數</returns>
    public string GetGradeCountById(int gradeId)
    {
        EasyDataProvide GradeStudent = new EasyDataProvide("GradeStudent");

        GradeStudent.AddParameter("grade_id", gradeId.ToString());
        int count = GradeStudent.GetRowCount("grade_id=@grade_id");
        return count.ToString();
    }
    #endregion

    #region "取得書櫃列表"
    public DataTable GeGradeFullNameListBySchoolID(string schoolId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GeGradeFullNameListBySchoolID.sql"));


        //搜尋字串
        string searchString = "Enable=1";
        if (schoolId != "-1")
        {
            searchString += " and  BookCase.school_id=@schoolId ";
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    #endregion
}