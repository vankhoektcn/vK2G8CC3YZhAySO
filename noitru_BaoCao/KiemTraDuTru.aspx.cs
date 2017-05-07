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

public partial class noitru_BaoCao_KiemTraDuTru : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadMenu();
    }
    private void LoadMenu()
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"].ToString();
            if (Request.QueryString["editHaoPhi"] == null || Request.QueryString["editHaoPhi"].ToString()=="0")
                PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
            else
                PlaceHolder1.Controls.Add(LoadControl("../DanhMuc_JSon/uscmenu.ascx"));
        }
        catch (Exception ex)
        {
        }
    }
}
