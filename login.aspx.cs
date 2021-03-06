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
using System.IO;

public partial class login :Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StaticData.SetFocus(this, "txtdangnhap");
    }
    protected void bntdnt_Click(object sender, EventArgs e)
    {
			if(txtdangnhap.Text=="" || txtmatkhau.Text=="")return;
            string sql = "select ND.*,nn.nhomID, nn.isadmin as adminis from nguoidung ND left join nhomnguoidung nn on ND.nhomID = nn.nhomID where username='" + txtdangnhap.Text + "' and matkhau='" + txtmatkhau.Text + "'";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count != 0)
            {
                SysParameter.UserLogin.SaveUserLogin(this, dt.Rows[0]["username"].ToString(),
                                                     dt.Rows[0]["IdNguoiDung"].ToString(),
                                                     dt.Rows[0]["TenNguoiDung"].ToString(),
                                                     dt.Rows[0]["nhomID"].ToString(),
                                                     dt.Rows[0]["IdBacSi"].ToString()
                                                     );
                Response.Redirect("~/" + "pagehome.aspx?IsLogin=1");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script language='javascript'>alert('Tên đăng nhập hay mật khẩu không phù hợp. Xin thử lại');</script>");
                txtdangnhap.Focus();
            }
        
    }
}
