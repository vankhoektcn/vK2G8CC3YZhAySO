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

public partial class KTTM_DanhSachPhieuPhu_Khoa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ngaythu = StaticData.CheckDate_kt(txtngaythu.Value);
        string sql = "select distinct tennguoithu from hs_dsdathu where tennguoithu <>'' ";
        //where sysdate> dateadd(day,-1,'" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00') and sysdate <='" + StaticData.CheckDate_kt(ngaythu) + " 17:00:00'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(drl_nguoidung, dt, "tennguoithu", "tennguoithu");

        txtngaythu.Value = DateTime.Now.ToString("dd/MM/yyyy");
    }
}
