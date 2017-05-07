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
using System.Drawing.Printing;

public partial class index : Genaratepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string IsQPTBH = Request.QueryString["IsQPTBH"];
        string IsQPTDV = Request.QueryString["IsQPTDV"];
        string IsKhoaDuoc = Request.QueryString["IsKhoaDuoc"];
        if(IsKhoaDuoc=="1")
            Page.Title = "QLBV- Khoa dược";
        if (IsQPTBH == "1")
        {
            Page.Title = "QLBV- Q.P.T.BH";
            divPhanHe.InnerText = "Phân hệ PHÁT THUỐC BẢO HIỂM";
        }
        if (IsQPTDV == "1")
        {
            Page.Title = "QLBV- Q.P.T.DV";
            divPhanHe.InnerText = "Phân hệ PHÁT THUỐC DỊCH VỤ";
        }
        LoadMenu();
    }
    private void LoadMenu()
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
