using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TIN;

/// <summary>
/// DPeople 的摘要描述
/// </summary>
public  class DPeople
{
    protected EasyDataProvide _people = new EasyDataProvide("People");
    protected EasyDataProvide _account = new EasyDataProvide("Account");
    protected string _pepoleID;
    protected DataRow _pepleRow;
    

    #region "建構函式"
    public DPeople()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }
    //public DPeople(string account)
    //{
    //    _account.AddParameter("username", account);
    //    DataRow row = _account.GetSingleRow("username=@username");
    //    if (row == null) throw new System.ArgumentException("User doesn't find ");
    //    _pepoleID = Convert.ToInt16(row["people_id"]);
    //    _pepleRow = _people.GetById(_pepoleID.ToString());
    //}
    public DPeople(string pepoleId)
    {
        _pepoleID = pepoleId;
        _pepleRow = _people.GetById(_pepoleID.ToString());
    }
    #endregion


    #region "登入帳號"
    /// <summary>
    /// 登入帳號
    /// </summary>
    public string Account
    {
        get
        {
            _account.AddParameter("people_id",_pepoleID.ToString());
            DataRow accountRow = _account.GetSingleRow("people_id=@people_id");
            if (accountRow == null) return "";
            return accountRow["username"].ToString();
        }


    }
    #endregion


    #region "聯絡用E-mail"
    /// <summary>
    /// 聯絡用E-mail
    /// </summary>
    public string Email
    {
        get
        {
            DataRow accountRow = _account.GetSingleRow("people_id=@people_id");
            if (accountRow == null) return "";
            return accountRow["emailAddress"].ToString();
        }

    }
    #endregion

    #region "電話"
    /// <summary>
    /// 電話
    /// </summary>
    public string Phone
    {
        get
        {
            EasyDataProvide telephone = new EasyDataProvide("Telephone");
            DataRow telRow = telephone.GetById(_pepleRow["telephone_id"].ToString());
            if (telRow == null) return "";
            return String.Format("{0}-{1}", telRow["areaCode"].ToString(), telRow["numberCode"].ToString());
        }
    }
    #endregion


    #region  "地址"
    /// <summary>
    /// 地址
    /// </summary>
    public string Address
    {
        get
        {
            EasyDataProvide address = new EasyDataProvide("Address");
            DataRow areaRow = address.GetById(_pepleRow["address_id"].ToString());
            if (areaRow == null) return "";
            return String.Format("{0}{1}{2}{3}", areaRow["zip"].ToString(), areaRow["city"].ToString(), areaRow["division"].ToString(), areaRow["address"].ToString());
        }


    }
    #endregion


    #region " 學校名稱"
    /// <summary>
    /// 學校名稱
    /// </summary>
    public string SchoolName
    {
        get
        {
            EasyDataProvide _people_School = new EasyDataProvide("People_School");
            _people_School.AddParameter("people_id", _pepoleID.ToString());
            DataRow people_SchoolRow = _people_School.GetSingleRow("people_id=@people_id");
            if (people_SchoolRow == null) return "";

            EasyDataProvide School = new EasyDataProvide("School");
            DataRow schoolRow = School.GetById(people_SchoolRow["school_id"].ToString());
            return schoolRow["name"].ToString();
        }


    }
    #endregion

    #region " 學校名稱ID"
    /// <summary>
    /// 學校名稱
    /// </summary>
    public string SchoolID
    {
        get
        {
            EasyDataProvide _people_School = new EasyDataProvide("People_School");
            _people_School.AddParameter("people_id", _pepoleID.ToString());
            DataRow people_SchoolRow = _people_School.GetSingleRow("people_id=@people_id");
            if (people_SchoolRow == null) return "";
            return people_SchoolRow["school_id"].ToString();
           
        }


    }

    
    #endregion

    public DataRow GetBaseRow()
    {
        EasyDataProvide People = new EasyDataProvide("People");
        DataRow row = People.GetById(_pepoleID);
        return row;
    }

    
}