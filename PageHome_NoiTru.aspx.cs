using System;
using System.Data;
using System.Web.UI;
using DataAcess;
using Process;
using Profess;
using SysParameter;

public partial class PageHome_NoiTru : Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
       // StaticData.Update_Parameter();
        #region Nếu chưa đăng nhập IsLogin=0 hoặc IsLogin=null
        
        #endregion
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
    #region lbLogin_Click
    protected void lbKhoaNgoai_Click(object sender, EventArgs e)
        {
                Response.Redirect("khoangoai/index.aspx");
        }
    #endregion
}