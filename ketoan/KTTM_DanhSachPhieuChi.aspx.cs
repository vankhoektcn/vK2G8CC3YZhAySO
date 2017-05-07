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
        txtTuNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
        txtDenNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
    }
}
