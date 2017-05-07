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
using System.Web.Script.Serialization;
public partial class sys__ajax_sys_login : System.Web.UI.Page
{
    JavaScriptSerializer _jsserial = new JavaScriptSerializer();
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = HttpContext.Current.Request["flag"];
        switch (action)
        {
            case "checkUser": checkUser(); break;
        }
    }
    private void checkUser()
    {
        HttpResponse _req = HttpContext.Current.Response;
        string username = HttpContext.Current.Request["username"];
        string password = HttpContext.Current.Request["password"];
        string sqlSelect = @"SELECT * FROM NGUOIDUNG A LEFT JOIN NHOMNGUOIDUNG B ON A.NHOMID=B.NHOMID";
        string _message = "";
        if (username != null && username != "")
        {
            sqlSelect += " WHERE A.USERNAME='" + username + "'";

        }
        DataTable dtLogin = DataAcess.Connect.GetTable(sqlSelect);
        if (dtLogin != null && dtLogin.Rows.Count > 0)
        {
            if (!dtLogin.Rows[0]["matkhau"].ToString().Trim().ToUpper().Equals(password.ToUpper()))
            {
                _message = "Mật khẩu không đúng.";
            }
            else
            {
                _message = "1";
                _req.Cookies["User"].Value = dtLogin.Rows[0]["username"].ToString();
                _req.Cookies["User"].Expires.AddDays(1);
                SysParameter.UserLogin.SaveUserLogin(this, dtLogin.Rows[0]["username"].ToString(),
                                                 dtLogin.Rows[0]["IdNguoiDung"].ToString(),
                                                 dtLogin.Rows[0]["TenNguoiDung"].ToString(),
                                                 dtLogin.Rows[0]["nhomID"].ToString(),
                                                 dtLogin.Rows[0]["IdBacSi"].ToString()
                                                 );
            }

        }
        else
        {
            _message = "Tên đăng nhập không đúng.";
        }
        _req.Clear();
        _req.Write(_jsserial.Serialize(_message));
    }
}
