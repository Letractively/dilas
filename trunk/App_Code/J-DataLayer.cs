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
    readonly SqlConnection _connection;

    #region "建構子"
    /// <summary>
    /// 建構子，預設使用web.config裡連線字串名稱為ConnectionString
    /// </summary>
    public DataLayer()
    {
        _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    }
    /// <summary>
    /// 建構子，傳入SqlConnection物件
    /// </summary>
    /// <param name="conn">傳入SqlConnection物件</param>
    public DataLayer(SqlConnection conn)
    {
        _connection = conn;
    }
    /// <summary>
    /// 建構子，傳入連線字串
    /// </summary>
    /// <param name="connectionString"></param>
    public DataLayer(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }
    #endregion

    #region "登入"
    /// <summary>
    /// 登入
    /// </summary>
    /// <param name="account">帳號</param>
    /// <param name="password">密碼</param>
    /// <returns></returns>
    public DataRow Login(string account, string password)
    {
        password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/Login.sql"));

        //實做連線和命令字串
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar, 50);
        sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar, 50);
        sqlCommand.Parameters["@username"].Value = account;
        sqlCommand.Parameters["@password"].Value = password;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));

        return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

    }
    #endregion

    public DataTable GetCityDivision()
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetCityDivision.sql"));


        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public DataTable GetSchoolList(string division, string name, string enable, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetSchoolList.sql"));


        //搜尋字串
        string searchString = "";
        if (division != "-1")
        {
            searchString += " and  Address.division=@division ";
        }

        if (enable != "-1")
        {
            searchString += " and School.enable=@enable ";
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and ([name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@division", SqlDbType.NVarChar);
        sqlCommand.Parameters["@division"].Value = division;

        sqlCommand.Parameters.Add("@enable", SqlDbType.NChar);
        sqlCommand.Parameters["@enable"].Value = enable;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

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

    public int GetSchoolListCount(string division, string name, string enable)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetSchoolListCount.sql"));


        //搜尋字串
        string searchString = "";
        if (division != "-1")
        {
            searchString += " and  Address.division=@division ";
        }

        if (enable != "-1")
        {
            searchString += " and School.enable=@enable ";
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and ([name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@division", SqlDbType.NVarChar);
        sqlCommand.Parameters["@division"].Value = division;

        sqlCommand.Parameters.Add("@enable", SqlDbType.NChar);
        sqlCommand.Parameters["@enable"].Value = enable;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }

    #region "取得教師列表"

    /// <summary>
    /// 取得教師列表
    /// </summary>
    /// <param name="schoolId">不搜尋填-1</param>
    /// <param name="name">不搜尋填空白</param>
    /// <param name="gender">不搜尋填-1</param>
    /// <param name="rank">不搜尋填-1</param>
    /// <param name="searchText">不搜尋填空白</param>
    /// <param name="searchId">搜尋編號（不搜尋填空白）</param>
    /// <param name="pageSize">一頁有幾筆</param>
    /// <param name="currentPage">目前第幾筆</param>
    /// <returns></returns>
    public DataTable GetTeacherList(string schoolId, string name, string gender, string rank, string searchText, string searchId, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetTeacherList.sql"));


        //搜尋字串
        string searchString = String.Format("{0} and People.role=0 ", searchText);
        if (schoolId != "-1")
        {
            searchString += " and  School.id=@schoolId ";
        }

        if (gender != "-1")
        {
            searchString += " and People.gender=@gender ";
        }
        if (rank != "-1")
        {
            searchString += " and Teacher.rank=@rank ";
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (People.[name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@searchId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@searchId"].Value = searchId;

        sqlCommand.Parameters.Add("@gender", SqlDbType.NChar);
        sqlCommand.Parameters["@gender"].Value = gender;

        sqlCommand.Parameters.Add("@rank", SqlDbType.NChar);
        sqlCommand.Parameters["@rank"].Value = rank;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

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

    #region "取得教師列表Count"

    /// <summary>
    /// 取得教師列表Count
    /// </summary>
    /// <param name="schoolId">不搜尋填-1</param>
    /// <param name="name">不搜尋填空白</param>
    /// <param name="gender">不搜尋填-1</param>
    /// <param name="rank">不搜尋填-1</param>
    /// <param name="searchText">不搜尋填空白</param>
    /// <param name="searchId">搜尋編號（不搜尋填空白）</param>
    /// <returns></returns>
    public int GetTeacherListCount(string schoolId, string name, string gender, string rank, string searchText, string searchId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetTeacherListCount.sql"));


        //搜尋字串
        string searchString = String.Format("{0} and People.role=0 ", searchText);
        if (schoolId != "-1")
        {
            searchString += " and  School.id=@schoolId ";
        }

        if (gender != "-1")
        {
            searchString += " and People.gender=@gender ";
        }
        if (rank != "-1")
        {
            searchString += " and Teacher.rank=@rank ";
        }

        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (People.[name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@searchId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@searchId"].Value = searchId;

        sqlCommand.Parameters.Add("@gender", SqlDbType.NChar);
        sqlCommand.Parameters["@gender"].Value = gender;

        sqlCommand.Parameters.Add("@rank", SqlDbType.NChar);
        sqlCommand.Parameters["@rank"].Value = rank;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;



        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }
    #endregion

    #region "依照GradeID取得老師列表"
    /// <summary>
    /// 依照GradeID取得老師列表
    /// </summary>
    /// <param name="GradeID">班級編號(必填)</param>
    /// <returns></returns>
    public DataTable GetTeacherByGradeID(string GradeID)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetTeacherByGradeID.sql"));


        //搜尋字串
        string searchString = "";

        searchString += " and  GradeTeacher.grade_id=@GradeID ";



        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@GradeID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@GradeID"].Value = GradeID;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "依照GradeID取得老師課程列表"
    /// <summary>
    /// 依照GradeID取得老師課程列表
    /// </summary>
    /// <param name="GradeID">班級編號(必填)</param>
    /// <returns></returns>
    public DataTable GetTeacherCourseByGradeID(string GradeID)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetTeacherCourseByGradeID.sql"));


        //搜尋字串
        string searchString = "";

        searchString += " and GradeCourseSubject.grade_id=@GradeID ";



        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@GradeID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@GradeID"].Value = GradeID;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得家長列表"
    public DataTable GetParentList(string schoolId, string name, string gender, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetParentList.sql"));


        //搜尋字串
        string searchString = " and People.role=2 ";
        if (schoolId != "-1")
        {
            searchString += " and  School.id=@schoolId ";
        }

        if (gender != "-1")
        {
            searchString += " and People.gender=@gender ";
        }


        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (People.[name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@gender", SqlDbType.NChar);
        sqlCommand.Parameters["@gender"].Value = gender;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;

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

    #region "取得家長列表Count"
    public int GetParentListCount(string schoolId, string name, string gender)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetParentListCount.sql"));


        //搜尋字串
        string searchString = " and People.role=2 ";
        if (schoolId != "-1")
        {
            searchString += " and  School.id=@schoolId ";
        }

        if (gender != "-1")
        {
            searchString += " and People.gender=@gender ";
        }


        if (!string.IsNullOrEmpty(name))
        {
            searchString += " and (People.[name] LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@gender", SqlDbType.NChar);
        sqlCommand.Parameters["@gender"].Value = gender;

        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar);
        sqlCommand.Parameters["@name"].Value = name;



        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }
    #endregion

    #region"取得課程的完整名稱"

    /// <summary>
    /// 取得課程的完整名稱
    /// </summary>
    /// <param name="fitGradeYear">適用年級</param>
    /// <param name="semesterTerm">0:上學期 1:下學期</param>
    /// <param name="searchText">不搜尋填空白</param>
    /// <param name="searchId">搜尋編號（不搜尋填空白）</param>
    /// <returns></returns>
    public DataTable GetCourseFullName(string fitGradeYear, string semesterTerm, string searchText, string searchId, string school_id)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetCourseFullName.sql"));


        //搜尋字串
        //搜尋字串
        string searchString = searchText;
        if (fitGradeYear != "-1")
        {
            searchString += " and  CourseSubject.fitGradeYear=@fitGradeYear ";
        }

        if (semesterTerm != "-1")
        {
            searchString += " and CourseSubject.semesterTerm=@semesterTerm ";
        }


        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數

        sqlCommand.Parameters.Add("@fitGradeYear", SqlDbType.Int);
        sqlCommand.Parameters["@fitGradeYear"].Value = fitGradeYear;

        sqlCommand.Parameters.Add("@semesterTerm", SqlDbType.Int);
        sqlCommand.Parameters["@semesterTerm"].Value = semesterTerm;

        sqlCommand.Parameters.Add("@searchId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@searchId"].Value = searchId;

        sqlCommand.Parameters.Add("@school_id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@school_id"].Value = school_id;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    #endregion

    public DataTable GetTimeTableDatabyGradeId(string gradeId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetTimeTableDatabyGradeId.sql"));


        //搜尋字串
        string searchString = "";

        searchString += " and TimeTable.grade_id=@GradeID ";



        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@GradeID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@GradeID"].Value = gradeId;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    #region "取得我的書籤for學生（預設與自訂與未分類）"
    /// <summary>
    /// 取得我的書籤for學生（預設與自訂與未分類）
    /// </summary>
    /// <param name="peopleId">peopleId</param>
    /// <returns></returns>
    public DataTable GetMyTabsForStudent(string peopleId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetMyTabsForStudent.sql"));


        //搜尋字串
        string searchString = "";

        searchString += "and people_id=@peopleId ";



        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@peopleId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@peopleId"].Value = peopleId;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得我的書籤for老師（自訂與未分類）"
    /// <summary>
    /// 取得我的書籤for老師（自訂與未分類）
    /// </summary>
    /// <param name="peopleId">peopleId</param>
    /// <returns></returns>
    public DataTable GetMyTabsForTeacher(string peopleId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetMyTabsForTeacher.sql"));


        //搜尋字串
        string searchString = "";

        searchString += "and people_id=@peopleId ";

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@peopleId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@peopleId"].Value = peopleId;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得我的書櫃 for 老師"
    /// <summary>
    /// 取得我的書櫃 for 老師
    /// </summary>
    /// <param name="peopleId">peopleId</param>
    /// <returns></returns>
    public DataTable GetMyBookCaseForTeacher(string peopleId)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetMyBookCaseForTeacher.sql"));


        //搜尋字串
        string searchString = "";

        searchString += "and BookCase.people_id=@peopleId ";



        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@peopleId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@peopleId"].Value = peopleId;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得我的書櫃 for 學生"

    /// <summary>
    /// 取得我的書櫃 for 學生
    /// </summary>
    /// <param name="peopleId">peopleId</param>
    /// <param name="grade_id">班級編號</param>
    /// <returns></returns>
    public DataTable GetMyBookCaseForStudent(string peopleId, string grade_id)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetMyBookCaseForStudent.sql"));


        //搜尋字串
         string searchString1 = "and BookCaseGrade.grade_id= " + grade_id;

         string searchString2 = "and BookCase.people_id= '" + peopleId + "'";



        commandString = commandString.Replace("/*--where begin 1--*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString1));

        commandString = commandString.Replace("/*--where begin 2--*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString2));



        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得聯絡簿裡學生列表"

    /// <summary>
    /// 取得聯絡簿裡學生列表
    /// </summary>
    /// <param name="contactBookDate">聯絡簿日期</param>
    /// <param name="grade_id">班級編號</param>
    /// <returns></returns>
    public DataTable GetContactBookStudentList(string contactBookDate, string grade_id, string contactBook_id)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetContactBookStudentList.sql"));



        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@contactBookDate", SqlDbType.SmallDateTime);
        sqlCommand.Parameters["@contactBookDate"].Value = contactBookDate;

        sqlCommand.Parameters.Add("@grade_id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@grade_id"].Value = grade_id;

        sqlCommand.Parameters.Add("@contactBook_id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@contactBook_id"].Value = contactBook_id;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得某班最新一筆聯絡簿資料"

    /// <summary>
    /// 取得某班最新一筆聯絡簿資料
    /// </summary>
    /// <param name="contactBookDate">聯絡簿日期</param>
    /// <param name="grade_id">班級編號</param>
    /// <param name="activity">空白 0:false 1:true</param>
    /// <returns></returns>
    public DataRow GetTop1ContentBook(string contactBookDate, string grade_id,string activity)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetTop1ContentBook.sql"));
        string searchString = "";
        if(!string.IsNullOrEmpty(contactBookDate.Trim()) )
        {
            searchString += " and [date]=@contactBookDate ";
        }
        if (!string.IsNullOrEmpty(grade_id))
        {
            searchString += " and [grade_id]=@grade_id ";
        }
        if (!string.IsNullOrEmpty(activity))
        {
            searchString += " and [activity]=@activity ";
        }

        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@contactBookDate", SqlDbType.NVarChar);
        sqlCommand.Parameters["@contactBookDate"].Value = contactBookDate;

        sqlCommand.Parameters.Add("@grade_id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@grade_id"].Value = grade_id;

        sqlCommand.Parameters.Add("@activity", SqlDbType.NVarChar);
        sqlCommand.Parameters["@activity"].Value = activity;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        DataRow dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        return dataRow;
    }
    #endregion

    #region "取得聯絡簿裡學生回應列表"

    /// <summary>
    /// 取得聯絡簿裡學生回應列表
    /// </summary>
    /// <param name="student_id">學生編號</param>
    /// <returns></returns>
    public DataTable GetContactBookMessageByStudent(string student_id)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetContactBookMessageByStudent.sql"));
        string searchString = "";
        if (!string.IsNullOrEmpty(student_id))
        {
            searchString += " and [StudentContactBookMessage].[student_id]=@student_id ";
        }
        
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@student_id", SqlDbType.NVarChar);
        sqlCommand.Parameters["@student_id"].Value = student_id;



        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得書櫃列表"
    public DataTable GetBookCaseList(string schoolId, string subject, string gender, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetBookCaseList.sql"));


        //搜尋字串
        string searchString = " and publicLevel=2 ";
        if (schoolId != "-1")
        {
            searchString += " and  BookCase.school_id=@schoolId ";
        }

        if (gender != "-1")
        {
            searchString += " and BookCaseGrade.grade_id=@gender ";
        }


        if (!string.IsNullOrEmpty(subject))
        {
            searchString += " and (AttachmentFile.subject LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@gender", SqlDbType.NChar);
        sqlCommand.Parameters["@gender"].Value = gender;

        sqlCommand.Parameters.Add("@subject", SqlDbType.NVarChar);
        sqlCommand.Parameters["@subject"].Value = subject;

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

    #region "取得書櫃列表Count"
    public int GetBookCaseListCount(string schoolId, string subject, string gender)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetBookCaseListCount.sql"));


        //搜尋字串
        string searchString = " and publicLevel=2 ";
        if (schoolId != "-1")
        {
            searchString += " and  BookCase.school_id=@schoolId ";
        }

        if (gender != "-1")
        {
            searchString += " and BookCaseGrade.grade_id=@gender ";
        }


        if (!string.IsNullOrEmpty(subject))
        {
            searchString += " and (AttachmentFile.subject LIKE '%' + @name + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@schoolId", SqlDbType.NVarChar);
        sqlCommand.Parameters["@schoolId"].Value = schoolId;

        sqlCommand.Parameters.Add("@gender", SqlDbType.NChar);
        sqlCommand.Parameters["@gender"].Value = gender;

        sqlCommand.Parameters.Add("@subject", SqlDbType.NVarChar);
        sqlCommand.Parameters["@subject"].Value = subject;



        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }
    #endregion

    public DataTable GetDiscussesReply(string publishID)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetDiscussesReply.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@publishID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@publishID"].Value = publishID;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    #region "後台動態發布系統列表"

    /// <summary>
    /// 後台動態發布系統列表
    /// </summary>
    /// <param name="moduleId">moduleID</param>
    /// <param name="orgId">機關編號</param>
    /// <param name="pClassId">第一層編號</param>
    /// <param name="title">標題關鍵字</param>
    /// <param name="sortMethed">排序方式</param>
    /// <param name="litimDate">是否顯示開始時間與結束時間</param>
    /// <param name="pageSize">一頁幾筆</param>
    /// <param name="currentPage">第幾頁</param>
    /// <returns>DataTable</returns>
    public DataTable GetPublishList(string moduleId, string orgId, string pClassId, string title, SortMethed sortMethed, bool litimDate, int pageSize, int currentPage)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetPublishList.sql"));
        if (litimDate) //顯示開始時間與結束時間
        {
            commandString = commandString.Replace("where 1=1", "where 1=1 AND (GetDate() Between startDate AND DATEADD(DAY,1,endDate))");
        }
        if (sortMethed == SortMethed.OrderBylistNum) //排序方式
        {
            commandString = commandString.Replace("ORDER BY ModulePublish.initDate desc", "ORDER BY ModulePublish.listNum asc");
        }
        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(moduleId))
        {
            searchString += " and  ModulePublish.moduleID=@moduleID ";
        }
        if (!string.IsNullOrEmpty(orgId))
        {
            searchString += " and  CHARINDEX(@orgID,ModulePublish.OrgID)<>0 ";
        }
        if (!string.IsNullOrEmpty(pClassId))
        {
            searchString += " and  ModulePublish.classID=@pClassID ";
        }
        if (!string.IsNullOrEmpty(title))
        {
            searchString += " and ([title] LIKE '%' + @title + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleId;
        sqlCommand.Parameters.Add("@start", SqlDbType.Int);
        sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
        sqlCommand.Parameters.Add("@end", SqlDbType.Int);
        sqlCommand.Parameters["@end"].Value = currentPage * pageSize;
        sqlCommand.Parameters.Add("@orgID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@orgID"].Value = orgId;
        sqlCommand.Parameters.Add("@pclassID", SqlDbType.NVarChar, 10);
        sqlCommand.Parameters["@pclassID"].Value = pClassId;
        sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar);
        sqlCommand.Parameters["@title"].Value = title;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }

    public int GetPublishListCount(string moduleId, string orgId, string pClassId, string title, SortMethed sortMethed, bool litimDate)
    {

        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetPublishListCount.sql"));
        if (litimDate) //顯示開始時間與結束時間
        {
            commandString = commandString.Replace("where 1=1", "where 1=1 AND (GetDate() Between startDate AND DATEADD(DAY,1,endDate))");
        }
        if (sortMethed == SortMethed.OrderBylistNum) //排序方式
        {
            commandString = commandString.Replace("ORDER BY ModulePublish.initDate desc", "ORDER BY ModulePublish.listNum asc");
        }

        //搜尋字串
        string searchString = "";
        if (!string.IsNullOrEmpty(moduleId))
        {
            searchString += " and  ModulePublish.moduleID=@moduleID ";
        }
        if (!string.IsNullOrEmpty(orgId))
        {
            searchString += " and  CHARINDEX(@orgID,ModulePublish.OrgID)<>0 ";
        }
        if (!string.IsNullOrEmpty(pClassId))
        {
            searchString += " and  ModulePublish.classID=@pClassID ";
        }
        if (!string.IsNullOrEmpty(title))
        {
            searchString += " and ([title] LIKE '%' + @title + '%') "; ;
        }
        commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@moduleID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@moduleID"].Value = moduleId;
        sqlCommand.Parameters.Add("@orgID", SqlDbType.NVarChar);
        sqlCommand.Parameters["@orgID"].Value = orgId;
        sqlCommand.Parameters.Add("@pclassID", SqlDbType.NVarChar, 10);
        sqlCommand.Parameters["@pclassID"].Value = pClassId;
        sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar);
        sqlCommand.Parameters["@title"].Value = title;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
    }

    public enum SortMethed
    {
        OrderByInitDate,
        OrderBylistNum
    }

    #endregion

    #region " 取得單獨設定權限的人與角色列表，不含屬於角色的人"
    /// <summary>
    /// 取得單獨設定權限的人與角色列表，不含屬於角色的人
    /// </summary>
    /// <returns>取得單獨設定權限的人與角色列表</returns>
    public DataTable GetPermissionList()
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetAccountAndRoleList.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //sqlCommand.Parameters.Add("@organization", SqlDbType.NVarChar, 10);
        //sqlCommand.Parameters["@organization"].Value = organization;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得所屬群組列表"
    /// <summary>
    /// 取得所屬群組列表
    /// </summary>
    /// <returns>取得單獨設定權限的人與角色列表</returns>
    public DataTable GetRoleMapAccount(string RoleID)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetRoleMapAccount.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@roleID", SqlDbType.Int);
        sqlCommand.Parameters["@roleID"].Value = RoleID;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得屬於哪一些群組"
    /// <summary>
    /// 取得所屬群組列表
    /// </summary>
    /// <returns>取得單獨設定權限的人與角色列表</returns>
    public DataTable GetRoleByAccount(string account)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetRoleByAccount.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@account", SqlDbType.NVarChar);
        sqlCommand.Parameters["@account"].Value = account;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得挑群組人員資料"
    /// <summary>
    /// 取得所屬群組列表
    /// </summary>
    /// <returns>取得單獨設定權限的人與角色列表</returns>
    public DataTable GetSelectRoleUser(string RoleID)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetSelectRoleUser.sql"));
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        sqlCommand.Parameters.Add("@roleID", SqlDbType.Int);
        sqlCommand.Parameters["@roleID"].Value = RoleID;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        return dataTable;
    }
    #endregion

    #region "取得權限字串"
    /// <summary>
    /// 取得權限字串
    /// </summary>
    /// <param name="userID">userID</param>
    /// <returns>string</returns>
    public string GetPermissionStringByID(string userID)
    {
        string commandString = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Code/SQL/GetPermissionStringByID.SQL"));
        //搜尋字串
        SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
        //處裡參數
        sqlCommand.Parameters.Add("@userID", SqlDbType.Int);
        sqlCommand.Parameters["@userID"].Value = userID;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill((dataTable));
        StringBuilder PermissionString = new StringBuilder();
        //找出不重覆權限加入PermissionString
        foreach (DataRow row in dataTable.Rows)
        {
            string[] arrTemp = row["permission"].ToString().Split(',');
            foreach (string perm in arrTemp)
            {
                if (PermissionString.ToString().IndexOf(perm) == -1)
                {
                    PermissionString.Append(perm + ",");
                }
            }
        }


        return PermissionString.ToString();
    }
    #endregion


    #region "動態消息點閱數+1"
    public void ModulePublish_UpdateCountsPlus(string ID)
    {
        SqlCommand myCommand = new SqlCommand("ModulePublish_UpdateCountsPlus", _connection);
        //宣告命令型態為StoredProcedure
        myCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter parameterUserName = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
        parameterUserName.Value = ID;
        myCommand.Parameters.Add(parameterUserName);
        _connection.Open();
        myCommand.ExecuteNonQuery();
        _connection.Close();




    }
    #endregion

    #region "網頁內容點閱數+1"
    public void WebArticle_UpdateCountsPlus(string ID)
    {
        SqlCommand myCommand = new SqlCommand("WebArticle_UpdateCountsPlus", _connection);
        //宣告命令型態為StoredProcedure
        myCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter parameterUserName = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
        parameterUserName.Value = ID;
        myCommand.Parameters.Add(parameterUserName);
        _connection.Open();
        myCommand.ExecuteNonQuery();
        _connection.Close();




    }
    #endregion



}