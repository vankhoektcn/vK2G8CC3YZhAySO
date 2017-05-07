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

public partial class ketoan_QuanLyChungTu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDanhSachChungTu();
    }
    private void LoadDanhSachChungTu()
    {
        string str = "select * from SoChungTu";
        //DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        DataTable dt = DataAcess.Connect.GetTable(str);
        GViewChungTu.DataSource = dt;
        GViewChungTu.DataBind();
    }
    protected void dgr_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
