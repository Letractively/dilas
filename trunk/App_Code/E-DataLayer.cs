using System;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Text;


/// <summary>
/// DataLayer 的摘要描述
/// </summary>
public partial class DataLayer
{

    public DataTable GetGradeList(string schoolId, string name, string enable, string currentYear, string enrollYear, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetGradeList.sql"));


        //搜尋字串
        string searchString = "";
        if (schoolId != "-1")
        {
            searchString += " and  School.id=@schoolId ";
        }

        if (enable != "-1")
        {
            searchString += " and Grade.enable=@enable ";
        }

        if (currentYear != "-1")
        {
            searchString += " and Grade.currentYear=@currentYear ";
        }

        if (enrollYear != "-1")
        {
            searchString += " and Grade.enrollYear=@enrollYear ";
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (Grade.[name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@enable", SqlDbType.NChar);
        sqlCommand.Parameters["@enable"].Value = enable;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

        sqlCommand.Parameters.Add("@currentYear", SqlDbType.NChar);
        sqlCommand.Parameters["@currentYear"].Value = currentYear;

        sqlCommand.Parameters.Add("@enrollYear", SqlDbType.NVarChar);
        sqlCommand.Parameters["@enrollYear"].Value = enrollYear;

        //分頁用
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetGradeListCount(string schoolId, string name, string enable, string currentYear, string enrollYear)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetGradeListCount.sql"));


        //搜尋字串
        string searchString = "";
        if (schoolId != "-1")
        {
            searchString += " and  School.id=@schoolId ";
        }

        if (enable != "-1")
        {
            searchString += " and Grade.enable=@enable ";
        }

        if (currentYear != "-1")
        {
            searchString += " and Grade.currentYear=@currentYear ";
        }

        if (enrollYear != "-1")
        {
            searchString += " and Grade.enrollYear=@enrollYear ";
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (Grade.[name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@enable", SqlDbType.NChar);
        sqlCommand.Parameters["@enable"].Value = enable;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

        sqlCommand.Parameters.Add("@currentYear", SqlDbType.NChar);
        sqlCommand.Parameters["@currentYear"].Value = currentYear;

        sqlCommand.Parameters.Add("@enrollYear", SqlDbType.NVarChar);
        sqlCommand.Parameters["@enrollYear"].Value = enrollYear;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }

    public DataTable GetCourseSubjectList(string school_id, string name, string enable, string fitGradeYear, string semesterTerm, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetCourseSubjectList.sql"));


        //搜尋字串
        string searchString = "";

        if (school_id != "-1")
        {
            searchString += " and CourseSubject.school_id=@school_id ";
        }
        if (enable != "-1")
        {
            searchString += " and CourseSubject.enable=@enable ";
        }

        if (fitGradeYear != "-1")
        {
            searchString += " and CourseSubject.fitGradeYear=@fitGradeYear ";
        }

        if (semesterTerm != "-1")
        {
            searchString += " and CourseSubject.semesterTerm=@semesterTerm ";
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (CourseSubject.[name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數

        sqlCommand.Parameters.Add("@school_id", SqlDbType.NChar);
        sqlCommand.Parameters["@school_id"].Value = school_id;

        sqlCommand.Parameters.Add("@enable", SqlDbType.NChar);
        sqlCommand.Parameters["@enable"].Value = enable;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

        sqlCommand.Parameters.Add("@fitGradeYear", SqlDbType.NChar);
        sqlCommand.Parameters["@fitGradeYear"].Value = fitGradeYear;

        sqlCommand.Parameters.Add("@semesterTerm", SqlDbType.NVarChar);
        sqlCommand.Parameters["@semesterTerm"].Value = semesterTerm;

        //分頁用
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetCourseSubjectListCount(string school_id, string name, string enable, string fitGradeYear, string semesterTerm)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetCourseSubjectListCount.sql"));

        //搜尋字串
        string searchString = "";

        if (school_id != "-1")
        {
            searchString += " and CourseSubject.school_id=@school_id ";
        }
        if (enable != "-1")
        {
            searchString += " and CourseSubject.enable=@enable ";
        }

        if (fitGradeYear != "-1")
        {
            searchString += " and CourseSubject.fitGradeYear=@fitGradeYear ";
        }

        if (semesterTerm != "-1")
        {
            searchString += " and CourseSubject.semesterTerm=@semesterTerm ";
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (CourseSubject.[name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數
        sqlCommand.Parameters.Add("@school_id", SqlDbType.NChar);
        sqlCommand.Parameters["@school_id"].Value = school_id;

        sqlCommand.Parameters.Add("@enable", SqlDbType.NChar);
        sqlCommand.Parameters["@enable"].Value = enable;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

        sqlCommand.Parameters.Add("@fitGradeYear", SqlDbType.NChar);
        sqlCommand.Parameters["@fitGradeYear"].Value = fitGradeYear;

        sqlCommand.Parameters.Add("@semesterTerm", SqlDbType.NVarChar);
        sqlCommand.Parameters["@semesterTerm"].Value = semesterTerm;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }

    #region " 取得學生列表"

    /// <summary>
    /// 取得學生列表
    /// </summary>
    /// <param name="schoolId">不搜尋填-1</param>
    /// <param name="gradeId">不搜尋填-1</param>
    /// <param name="studentNumber">不搜尋填空白</param>
    /// <param name="name">不搜尋填空白</param>
    /// <param name="enable">不搜尋填-1</param>
    /// <param name="gender">不搜尋填-1</param>
    /// <param name="parentId">不搜尋填-1</param>
    /// <param name="searchText">不搜尋填空白</param>
    /// <param name="sortString">預設排序(initDate)填空白</param>
    /// <param name="pageSize">一頁有幾筆</param>
    /// <param name="currentPage">目前第幾筆</param>
    /// <returns></returns>
    public DataTable GetStudentList(string schoolId, string gradeId, string studentNumber, string name, string enable, string gender, string parentId, string searchText, string sortString, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetStudentList.sql"));


        //搜尋字串
        string searchString = String.Format("{0} and People.role=1 ", searchText);
        if (schoolId != "-1")
        {
            searchString += " and School.id=@schoolId ";
        }

        if (parentId != "-1")
        {
            searchString += " and parent_id=@parentId ";
        }

        if (gradeId != "-1")
        {
            searchString += " and Grade.id=@gradeId ";
        }

        if (gender != "-1")
        {
            searchString += " and People.gender=@gender ";
        }

        if (enable != "-1")
        {
            searchString += " and People.Enable=@enable ";
        }

        if (!string.IsNullOrEmpty(studentNumber))
        {
            searchString += " and (Student.[studentNumber] LIKE '%' + @studentNumber + '%') "; ;
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (People.[name] LIKE '%' + @name + '%') "; ;
        }

        if (!string.IsNullOrEmpty(sortString))
        {
            commandString = commandString.Replace("ORDER BY People.initDate desc", sortString);
        }
        

        if (!string.IsNullOrEmpty(sortString))
        {
            commandString = commandString.Replace("ORDER BY People.initDate desc", sortString);
        }



        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@gradeId", SqlDbType.NChar);
        sqlCommand.Parameters["@gradeId"].Value = gradeId;

        sqlCommand.Parameters.Add("@parentId", SqlDbType.NChar);
        sqlCommand.Parameters["@parentId"].Value = parentId;

        sqlCommand.Parameters.Add("@gender", SqlDbType.NChar);
        sqlCommand.Parameters["@gender"].Value = gender;

        sqlCommand.Parameters.Add("@studentNumber", SqlDbType.NVarChar);
        sqlCommand.Parameters["@studentNumber"].Value = studentNumber;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

        sqlCommand.Parameters.Add("@enable", SqlDbType.NChar);
        sqlCommand.Parameters["@enable"].Value = enable;

        //分頁用
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region " 取得學生列表Count"
    /// <summary>
    /// 取得學生列表Count
    /// </summary>
    /// <param name="schoolId">不搜尋填-1</param>
    /// <param name="gradeId">不搜尋填-1</param>
    /// <param name="studentNumber">不搜尋填空白</param>
    /// <param name="name">不搜尋填空白</param>
    /// <param name="enable">不搜尋填-1</param>
    /// <param name="gender">不搜尋填-1</param>
    /// <param name="parentId">不搜尋填-1</param>
    /// <param name="searchText">不搜尋填空白</param>
    /// <param name="sortString">預設排序(initDate)填空白</param>
    /// <returns></returns>
    public int GetStudentListCount(string schoolId, string gradeId, string studentNumber, string name, string enable, string gender, string parentId, string searchText, string sortString)

    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetStudentListCount.sql"));


        //搜尋字串
        string searchString = String.Format("{0} and People.role=1 ", searchText);
        if (schoolId != "-1")
        {
            searchString += " and School.id=@schoolId ";
        }

        if (gradeId != "-1")
        {
            searchString += " and Grade.id=@gradeId ";
        }

        if (parentId != "-1")
        {
            searchString += " and parent_id=@parentId ";
        }

        if (gender != "-1")
        {
            searchString += " and People.gender=@gender ";
        }

        if (enable != "-1")
        {
            searchString += " and People.Enable=@enable ";
        }

        if (!string.IsNullOrEmpty(studentNumber))
        {
            searchString += " and (Student.[studentNumber] LIKE '%' + @studentNumber + '%') "; ;
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (People.[name] LIKE '%' + @name + '%') "; ;
        }
        if (!string.IsNullOrEmpty(sortString))
        {
            commandString = commandString.Replace("ORDER BY People.initDate desc", sortString);
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@gradeId", SqlDbType.NChar);
        sqlCommand.Parameters["@gradeId"].Value = gradeId;

        sqlCommand.Parameters.Add("@parentId", SqlDbType.NChar);
        sqlCommand.Parameters["@parentId"].Value = parentId;

        sqlCommand.Parameters.Add("@gender", SqlDbType.NChar);
        sqlCommand.Parameters["@gender"].Value = gender;

        sqlCommand.Parameters.Add("@studentNumber", SqlDbType.NVarChar);
        sqlCommand.Parameters["@studentNumber"].Value = studentNumber;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

        sqlCommand.Parameters.Add("@enable", SqlDbType.NChar);
        sqlCommand.Parameters["@enable"].Value = enable;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }
    #endregion

    public string GetGradeCourseSubjectNameByID(string courseSubjectId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetGradeCourseSubjectNameByID.sql"));


        //搜尋字串
        string searchString = "";

        searchString += " and GradeCourseSubject.id=@courseSubjectId ";



        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@courseSubjectId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@courseSubjectId"].Value = courseSubjectId;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows[0]["CourseSubjectName"].ToString();
    }
   

    #region "取得指定班級書籤的書櫃列表"
    public DataTable GetBookCaseGradeList(string bookCase_id)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetBookCaseGradeListByBookCaseId.sql"));


        //搜尋字串
        string searchString = " ";
        searchString += "and bookCase_id=@bookCase_id ";

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數
        sqlCommand.Parameters.Add("@bookCase_id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@bookCase_id"].Value = bookCase_id;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "依照日期取得今日課表"
    /// <summary>
    /// 依照日期取得今日課表
    /// </summary>
    /// <param name="prepareDate">日期</param>
    /// <param name="gradeId">班級編號(必填)</param>
    /// <returns></returns>
    public DataTable GetClassSessionDataByDay(string prepareDate, string gradeId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetClassSessionDataByDay.sql"));


        //搜尋字串
        //string searchString = "";

        //searchString += " and  PrepareLesson.prepareDate=@prepareDate";

        //searchString += " and  TimeTable.grade_id=@gradeId ";

        //commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數

        sqlCommand.Parameters.Add("@prepareDate", SqlDbType.NVarChar);
        sqlCommand.Parameters["@prepareDate"].Value = prepareDate;

        sqlCommand.Parameters.Add("@gradeId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@gradeId"].Value = gradeId;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion


    #region "取得該校註冊年份清單"
    /// <summary>
    /// 取得該校註冊年份清單
    /// </summary>
    /// <param name="schoolId">學校編號(必填)</param>
    /// <returns></returns>
    public DataTable GetEnrollYearListBySchoolId(string schoolId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetEnrollYearList.sql"));



        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處理參數

        sqlCommand.Parameters.Add("@school_id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@school_id"].Value = schoolId;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion
}