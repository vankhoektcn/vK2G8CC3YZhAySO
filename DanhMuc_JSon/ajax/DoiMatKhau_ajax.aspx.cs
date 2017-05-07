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

public partial class ajax_DoiMatKhau_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luu": LuuMatKhauMoi(); break;
        }
    }
    private void LuuMatKhauMoi()
    {
        string userid = SysParameter.UserLogin.UserID(this);
        string oldpass = (Request.QueryString["oldpass"] == null ? "" : Request.QueryString["oldpass"]);
        string newpass = Request.QueryString["newpass"];
        string sql = "select * from nguoidung where idnguoidung='" + userid + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count > 0)
        {
            if (!dt.Rows[0]["matkhau"].ToString().Trim().ToUpper().Equals(oldpass.ToUpper()))
            {
                Response.Write("1");
            }
            else
            {
                bool ok = DataAcess.Connect.ExecSQL("UPDATE nguoidung SET matkhau='" + newpass + "'"
                   + " WHERE idnguoidung='" + userid + "'");
                if (ok)
                    Response.Write("2");
                else
                    Response.Write("3");
            }
        }
        else
        {
            Response.Write("4");
        }
    }
}
