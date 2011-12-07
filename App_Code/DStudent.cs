using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TIN;

/// <summary>
/// DStudent 的摘要描述
/// </summary>
public class DStudent : DPeople
{
    private String _gradeName;
    private String _gradeID;
    private string _currentYear;
    private String _seatNumber;
    private String _studentNumber;
    public DStudent()
        : base()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    #region "班級年級、名稱、ID、座號"
    /// <summary>
    /// 班級年級、名稱、ID、座號
    /// </summary>
    public DStudent(string peopleId)
        : base(peopleId)
    {
        EasyDataProvide gradeStudent = new EasyDataProvide("GradeStudent");
        gradeStudent.AddParameter("student_id", peopleId);
        DataRow gradeStudentRow = gradeStudent.GetSingleRow("student_id=@student_id");
        if (gradeStudentRow != null)
        {
            _gradeID = gradeStudentRow["grade_id"].ToString();
            EasyDataProvide Grade = new EasyDataProvide("Grade");
            DataRow gradeRow = Grade.GetById(gradeStudentRow["grade_id"].ToString());
            if (gradeRow == null) return;
            _currentYear = gradeRow["currentYear"].ToString();
            _gradeName = gradeRow["name"].ToString();
            
        }

        if (gradeStudentRow != null) _seatNumber = gradeStudentRow["seatNumber"].ToString();

        EasyDataProvide student = new EasyDataProvide("Student");
        student.AddParameter("id", peopleId);
        DataRow studentRow = student.GetSingleRow("id=@id");
        if (studentRow != null)
        {
            _studentNumber = studentRow["studentNumber"].ToString();
        }
        

    }
    #endregion


    #region "取得班級名稱Property"
    /// <summary>
    /// 取得班級名稱Property"
    /// </summary>
    public string GradeName
    {
        get
        {
            return _gradeName;

        }
    }
    #endregion

    #region "取得班級ID Property"
    /// <summary>
    /// 取得班級ID Property"
    /// </summary>
    public string GradeID
    {
        get
        {
            return _gradeID;

        }
    }
    #endregion

    #region "取得班級年級Property"
    /// <summary>
    /// 取得班級年級Property"
    /// </summary>
    public string CurrentYear
    {
        get
        {
            return _currentYear;

        }
    }
    #endregion

    #region "取得班級全名Property,例如:X年X班"
    /// <summary>
    /// 取得班級全名Property,例如:X年X班"
    /// </summary>
    public string GradeAllName
    {
        get
        {
            return _currentYear + "年" + _gradeName + "班";

        }
    }
    #endregion

    #region "取得學生座號"
    /// <summary>
    /// 取得學生座號Property"
    /// </summary>
    public string SeatNumber
    {
        get
        {
            return _seatNumber;

        }
    }
    #endregion

    #region "取得學生學號"
    /// <summary>
    /// 取得學生學號Property"
    /// </summary>
    public string StudentNumber
    {
        get
        {
            return _studentNumber;

        }
    }
    #endregion
}