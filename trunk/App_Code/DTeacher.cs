using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TIN;

/// <summary>
/// DTeacher 的摘要描述
/// </summary>
public class DTeacher : DPeople
{
    
    public DTeacher()
        : base()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    //public DTeacher(string account)
    //    : base(account)
    //{



    //}
    public DTeacher(string pepoleId)
        : base(pepoleId)
    {

    }

    /// <summary>
    /// 正式 or 代課
    /// </summary>
    public string Rank
    {
        get
        {
            EasyDataProvide teacher = new EasyDataProvide("Teacher");
            DataRow teacherRow = teacher.GetById(_pepoleID.ToString());
            if (teacherRow == null) return "";

            return teacherRow["rank"].ToString() == "False" ? "正式" : "代課";
        }


    }


    /// <summary>
    /// 等級(False:正式，True:代課)
    /// </summary>
    public string RankValue
    {
        get
        {
            EasyDataProvide teacher = new EasyDataProvide("Teacher");
            DataRow teacherRow = teacher.GetById(_pepoleID.ToString());
            if (teacherRow == null) return "";

            return teacherRow["rank"].ToString();
        }


    }

    /// <summary>
    /// 取得老師授課所有班級列表
    /// </summary>
    /// <returns>老師授課所有班級列表</returns>
    public DataTable GetGradeList()
    {
        EasyDataProvide V_Teacher_Grade = new EasyDataProvide("V_Teacher_Grade");
        V_Teacher_Grade.AddParameter("teacher_id", _pepoleID.ToString());
        DataTable dt = V_Teacher_Grade.GetData("teacher_id=@teacher_id");
        return dt;
    }

    /// <summary>
    /// 取得級任老師授課所有班級列表
    /// </summary>
    /// <returns>取得級任老師授課所有班級列表</returns>
    public DataTable GetMasterGradeList()
    {
        EasyDataProvide V_Teacher_Grade = new EasyDataProvide("V_Teacher_Grade");
        V_Teacher_Grade.AddParameter("teacher_id", _pepoleID.ToString());
        DataTable dt = V_Teacher_Grade.GetData("teacher_id=@teacher_id and classify=0");
        return dt;
    }

}