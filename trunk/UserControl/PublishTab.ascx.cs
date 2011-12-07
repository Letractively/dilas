using System;
using System.Text;
using System.Web.UI;

public partial class UserControl_PublishTab : UserControl
{
    public int tab { get; set; }
    public string FunctionName { get; set; }

    private bool _IsOpenEditTab;
    public bool isOpenEditTab
    {
        get
        {
            return _IsOpenEditTab;
        }
        set
        {
            _IsOpenEditTab = value;
        }
    }
    private bool _IsOpenFun1Tab;
    public bool isOpenFun1Tab
    {
        get
        {
            return _IsOpenFun1Tab;
        }
        set
        {
            _IsOpenFun1Tab = value;
        }
    }
    private bool _IsOpenFun2Tab;
    public bool isOpenFun2Tab
    {
        get
        {
            return _IsOpenFun2Tab;
        }
        set
        {
            _IsOpenFun2Tab = value;
        }
    }
    private bool _IsOpenFun3Tab;
    public bool isOpenFun3Tab
    {
        get
        {
            return _IsOpenFun3Tab;
        }
        set
        {
            _IsOpenFun3Tab = value;
        }
    }
    private bool _IsOpenFun4Tab;
    public bool isOpenFun4Tab
    {
        get
        {
            return _IsOpenFun4Tab;
        }
        set
        {
            _IsOpenFun4Tab = value;
        }
    }
    private bool _IsOpenFun5Tab;
    public bool isOpenFun5Tab
    {
        get
        {
            return _IsOpenFun5Tab;
        }
        set
        {
            _IsOpenFun5Tab = value;
        }
    }
   

    private string _BaseTabName;
    public string BaseTabName
    {
        get
        {
            return _BaseTabName;
        }
        set
        {
            _BaseTabName = value;
        }
    }
    private string _EditTabName;
    public string EditTabName
    {
        get
        {
            return _EditTabName;
        }
        set
        {
            _EditTabName = value;
        }
    }
    private string _Fun1TabName;
    public string Fun1TabName
    {
        get
        {
            return _Fun1TabName;
        }
        set
        {
            _Fun1TabName = value;
        }
    }
    private string _Fun2TabName;
    public string Fun2TabName
    {
        get
        {
            return _Fun2TabName;
        }
        set
        {
            _Fun2TabName = value;
        }
    }
    private string _Fun3TabName;
    public string Fun3TabName
    {
        get
        {
            return _Fun3TabName;
        }
        set
        {
            _Fun3TabName = value;
        }
    }

    private string _Fun4TabName;
    public string Fun4TabName
    {
        get
        {
            return _Fun4TabName;
        }
        set
        {
            _Fun4TabName = value;
        }
    }

    private string _Fun5TabName;
    public string Fun5TabName
    {
        get
        {
            return _Fun5TabName;
        }
        set
        {
            _Fun5TabName = value;
        }
    }

    private string _BaseTabURL;
    public string BaseTabURL
    {
        get
        {
            return _BaseTabURL;
        }
        set
        {
            _BaseTabURL = value;
        }
    }
    private string _Fun1TabURL;
    public string Fun1TabURL
    {
        get
        {
            return _Fun1TabURL;
        }
        set
        {
            _Fun1TabURL = value;
        }
    }
    private string _Fun2TabURL;
    public string Fun2TabURL
    {
        get
        {
            return _Fun2TabURL;
        }
        set
        {
            _Fun2TabURL = value;
        }
    }
    private string _Fun3TabURL;
    public string Fun3TabURL
    {
        get
        {
            return _Fun3TabURL;
        }
        set
        {
            _Fun3TabURL = value;
        }
    }

    private string _Fun4TabURL;
    public string Fun4TabURL
    {
        get
        {
            return _Fun4TabURL;
        }
        set
        {
            _Fun4TabURL = value;
        }
    }

    private string _Fun5TabURL;
    public string Fun5TabURL
    {
        get
        {
            return _Fun5TabURL;
        }
        set
        {
            _Fun5TabURL = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //FunctionName 的預設值
            if (FunctionName == null)
                FunctionName = "Publish";

            StringBuilder tabStringBuilder = new StringBuilder("<ul id=\"menu\">");

            if (tab == 1)
            {
                tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("{0}_View.aspx?id={1}&page={2}", FunctionName,  Request["id"],Request["page"]),
                                           BaseTabName ?? "檢視資料"));
            }
            else
            {
                tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("{0}_View.aspx?id={1}&page={2}", FunctionName,  Request["id"],Request["page"]),
                                           BaseTabName ?? "檢視資料"));
            }

            if (isOpenEditTab)
            {
                if (tab == 2)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("{0}_Edit.aspx?id={1}&page={2}", FunctionName,  Request["id"],Request["page"]), EditTabName ?? "編輯資料"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("{0}_Edit.aspx?id={1}&page={2}", FunctionName,  Request["id"],Request["page"]),
                                               EditTabName ?? "編輯資料"));
                }
            }


            if (isOpenFun1Tab)
            {
            
                if (tab == 3)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName,Fun1TabURL??"Fun1", Request["id"],Request["page"]), Fun1TabName ?? "附加功能1"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun1TabURL ?? "Fun1", Request["id"], Request["page"]),
                                               Fun1TabName ?? "附加功能1"));
                }
            }
            if (isOpenFun2Tab)
            {
           
                if (tab == 4)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun2TabURL ?? "Fun2", Request["id"], Request["page"]), Fun2TabName ?? "附加功能2"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun2TabURL ?? "Fun2", Request["id"], Request["page"]),
                                               Fun2TabName ?? "附加功能2"));
                }
            }

            if (isOpenFun3Tab)
            {

                if (tab == 5)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun3TabURL ?? "Fun3", Request["id"], Request["page"]), Fun3TabName ?? "附加功能3"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun3TabURL ?? "Fun3", Request["id"], Request["page"]),
                                               Fun3TabName ?? "附加功能3"));
                }
            }

            if (isOpenFun4Tab)
            {

                if (tab == 6)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun4TabURL ?? "Fun4", Request["id"], Request["page"]), Fun4TabName ?? "附加功能4"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun4TabURL ?? "Fun4", Request["id"], Request["page"]),
                                               Fun4TabName ?? "附加功能4"));
                }
            }

            if (isOpenFun5Tab)
            {

                if (tab == 7)
                {
                    tabStringBuilder.Append(string.Format("<li id=\"single\"><a href=\"{0}\"><b>{1}</b></a></li>",
                                               String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun5TabName ?? "Fun5", Request["id"], Request["page"]), Fun5TabURL ?? "附加功能5"));
                }
                else
                {
                    tabStringBuilder.Append(string.Format("<li><a href=\"{0}\"><b>{1}</b></a></li>", String.Format("_{0}_{1}.aspx?id={2}&page={3}", FunctionName, Fun5TabURL ?? "Fun5", Request["id"], Request["page"]),
                                               Fun5TabName ?? "附加功能5"));
                }
            }

            tabStringBuilder.Append("</ul>");
            Literal1.Text = tabStringBuilder.ToString();
        }
    }
}