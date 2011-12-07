using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TIN;

/// <summary>
/// DParent 的摘要描述
/// </summary>
public class DParent : DPeople
{
    public DParent()
        : base()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public DParent(string pepoleId): base(pepoleId)
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }


    /// <summary>
    /// 職業
    /// </summary>
    public string Occupation
    {
        get
        {
            EasyDataProvide Parent = new EasyDataProvide("Parent");
            DataRow parentRow = Parent.GetById(_pepoleID.ToString());

            return parentRow["occupation"].ToString();
        }


    }

    public DataTable GetMyChildrens()
    {
        DataLayer dl=new DataLayer();
        Person myPersion=new Person();
        DataTable dt = dl.GetStudentList(base.SchoolID, "-1", "", "", "-1", "-1", _pepoleID, "", "order by StudentNumber asc", 70, 1);
        return dt;
    }


}