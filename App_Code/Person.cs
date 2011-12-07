using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Newtonsoft.Json;

/// <summary>
/// Person 的摘要描述
/// </summary>
[JsonObject(MemberSerialization.OptIn)]
public class SPerson
{
    private string _Account;
    [JsonProperty]
    public string account
    {
        get
        {
            return _Account;
        }
        set
        {
            _Account = value;
        }
    }

    private string _people_id;
    [JsonProperty]
    public string people_id
    {
        get
        {
            return _people_id;
        }
        set
        {
            _people_id = value;
        }
    }
    
    private string _Name;
    [JsonProperty]
    public string name
    {
        get
        {
            return _Name;
        }
        set
        {
            _Name = value;
        }
    }


    private string _Permission;
    [JsonProperty]
    public string Permission
    {
        get
        {
            return _Permission;
        }
        set
        {
            _Permission = value;
        }
    }

    private string _Email;
    [JsonProperty]
    public string email
    {
        get
        {
            return _Email;
        }
        set
        {
            _Email = value;
        }
    }

    private string _Role;
    [JsonProperty]
    public string Role
    {
        get
        {
            return _Role;
        }
        set
        {
            _Role = value;
        }
    }
    private string _School_id;
    [JsonProperty]
    public string School_id
    {
        get
        {
            return _School_id;
        }
        set
        {
            _School_id = value;
        }
    }

}

public class Person
{
    private string _Account;

    public string account
    {
        get
        {
            return _Account;
        }
    }

    private string _people_id;

    public string people_id
    {
        get
        {
            return _people_id;
        }
    }
    
    private string _Name;
    public string name
    {
        get
        {
            return _Name;
        }
    }

   

    private string _Permission;
    public string permission
    {
        get
        {
            return _Permission;
        }
    }

    private string _Email;
    public string email
    {
        get
        {
            return _Email;
        }
    }

    private LoginRole _Role;
    public LoginRole Role
    {
        get
        {
            return _Role;
        }
    }

    private string _School_id;
    public string School_id
    {
        get
        {
            return _School_id;
        }
    }

    public Person()
    {
        //取得UserData
        string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
        SPerson Myperson = JsonConvert.DeserializeObject<SPerson>(strUserData);
        _Account = Myperson.account;
        _people_id = Myperson.people_id;
        _Email = Myperson.email;
        _Name = Myperson.name;
        _Permission = Myperson.Permission;
        _School_id = Myperson.School_id;
        switch (Myperson.Role)
        {
            case "0":
                _Role = LoginRole.Teacher;
                break;
            case "1":
                _Role = LoginRole.Student;
                break;
            case "2":
                _Role = LoginRole.Parent;
                break;
            case "3":
                _Role = LoginRole.SchoolAdmin;
                break;
            case "4":
                _Role = LoginRole.Administrator;
                break;

        }

    }

    public  enum LoginRole
    {
        Teacher=0,
        Student=1,
        Parent= 2,
        SchoolAdmin=3,
        Administrator=4
    }

}