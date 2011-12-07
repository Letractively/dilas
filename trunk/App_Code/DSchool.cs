using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TIN;

/// <summary>
/// DSchool 的摘要描述
/// </summary>
public class DSchool
{
    EasyDataProvide _school = new EasyDataProvide("School");

    public DSchool()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    #region " 取得啟用中學校列表"
    /// <summary>
    /// 取得啟用中學校列表
    /// </summary>
    /// <returns>回傳啟用中學校列表</returns>
    public DataTable GetSchoolList()
    {
        DataTable dt = _school.GetData("enable='True'");
        return dt;
    }
    #endregion



    #region "根據SchoolId取得學校名稱"
    /// <summary>
    /// 根據SchoolId取得學校名稱
    /// </summary>
    /// <param name="schoolId">school 資料表的主索引</param>
    /// <returns>學校名稱</returns>
    public string GetNameBySchoolId(string schoolId)
    {
        DataRow row = _school.GetById(schoolId);
        if (row == null)
        {
            return "";
        }
        else
        {
            return row["name"].ToString();
        }

    }
    #endregion


}