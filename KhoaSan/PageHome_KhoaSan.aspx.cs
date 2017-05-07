using System;
using System.Data;
using System.Web.UI;
using DataAcess;
using Process;
using Profess;
using SysParameter;

public partial class PageHome_KhoaSan : Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }
    #endregion
    #region Page Unload
    void pagehome_Unload(object sender, EventArgs e)
    {
       
    }

    #endregion
    #region lb Click
    protected void lbKhoaNgoai_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx?dkmenu=phongsanh");
        }
    #endregion
}