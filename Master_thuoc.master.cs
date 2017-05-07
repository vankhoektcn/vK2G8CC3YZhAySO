using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class MasterPage_thuoc : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      /* if (Session["werwerweoruwe"] == null)
        {
            Response.Write("<script>window.open(\"\",\"_parent\",\"\");window.close();window.open(location.href,\"_blank\",\"location=0,menubar=0,resizable=1,scrollbars=1,status=0,toolbar=0\")</script>");
            Session["werwerweoruwe"] = "werwer";
        }*/
        string dkmenu = Request.QueryString["dkmenu"];
        LoadMenu();
    }
    private void LoadMenu()
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"].ToString();
            PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
        }
        catch (Exception ex)
        {
        }
    }
}
