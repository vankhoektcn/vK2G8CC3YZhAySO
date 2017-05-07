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

public partial class ketoan_KTTM_DanhSachPhieuChi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select taikhoan from danhmuctk where taikhoan like '141%' order by taikhoan ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(drl_tknh, dt, "taikhoan", "taikhoan");
    }
}
