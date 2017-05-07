<%@ WebHandler Language="C#" Class="sys_login" %>

using System;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
public class sys_login : IHttpHandler
{
    JavaScriptSerializer _jsserial = new JavaScriptSerializer();
    public void ProcessRequest(HttpContext context)
    {
        string action = context.Request["flag"];
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
            if (!dtLogin.Rows[0]["matkhau"].ToString().Trim().ToLower().Equals(password))
            {
                _message = "Mật khẩu không đúng.";
            }
            else
            {
                _message = "1";
                _req.Cookies["User"].Value = dtLogin.Rows[0]["username"].ToString();
                _req.Cookies["User"].Expires.AddDays(1);
               
            }
           
        }
        else
        {
            _message = "Tên đăng nhập không đúng.";
        }
        _req.Clear();
        _req.Write(_jsserial.Serialize(_message));
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}