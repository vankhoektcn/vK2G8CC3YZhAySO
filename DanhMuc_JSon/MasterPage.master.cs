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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"];
            if (dkmenu != null && dkmenu != "")
                pMain.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
            else
                pMain.Controls.Add(LoadControl("uscmenu.ascx"));
        }
        catch (Exception)
        { }
    }
}
