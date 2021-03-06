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
using System.Threading;

public partial class nvk_KhamThuongQuyDienBien : System.Web.UI.Page
{
    DataTable tablelamviec = null;
    DataTable tablengaynghi = null;
    DataTable tablegiolamthem = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        tablelamviec = DataAcess.Connect.GetTable("select * from catruc");
        tablengaynghi = DataAcess.Connect.GetTable("select * from loainghiphep");
        if (!IsPostBack)
        {
            BindListPhongBan();
            NgayCong.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

    private void BindListPhongBan()
    {
        string idnd =SysParameter.UserLogin.UserID(this);
        string sql = "select *  from phongkhambenh where isnull(loaiphong,0)=0";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count >= 0)
        {
            StaticData.FillCombo(ddlPhongBan, dt, "idphongkhambenh", "tenphongkhambenh", "------Chọn------");
            if (ddlPhongBan.Items.Count>1)
            {
               ddlPhongBan.SelectedValue =Request.QueryString["IdKhoa"]; 
            }
        }

    }
   
}

