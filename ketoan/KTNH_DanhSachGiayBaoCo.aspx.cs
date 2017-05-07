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

public partial class KTNH_DanhSachGiayBaoCo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select taikhoankt from danhmuctknh";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(drl_tknh, dt, "taikhoankt", "taikhoankt", "Chọn TK ngân hàng");
    }
}
