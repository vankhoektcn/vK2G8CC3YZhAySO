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

public partial class GoiPhauThuat_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable(); break;
            case "xoa": XoaGoiPhauThuat(); break;
        }
    }

    private void XoaGoiPhauThuat()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete GoiPhauThuat where IDGoiPhauThuat=" + idkhoachinh;
            bool ok = NhanSu_Process.GoiPhauThuat.ExecSQL(sql);
            if (ok)
            {
                Response.Clear(); Response.Write(idkhoachinh);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }

    public void LuuTable()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            char[] splitter = { '/' };
            string TenGoiPhauThuat = "";
            if (Request.QueryString["TenGoiPhauThuat"] != null)
            {
                TenGoiPhauThuat = Request.QueryString["TenGoiPhauThuat"].ToString();
            } string GhiChu = "";
            if (Request.QueryString["GhiChu"] != null)
            {
                GhiChu = Request.QueryString["GhiChu"].ToString();
            } if (!idkhoachinh.Trim().Equals(""))
            {
                NhanSu_Process.GoiPhauThuat temp = NhanSu_Process.GoiPhauThuat.Create_GoiPhauThuat(idkhoachinh);
                bool ok = temp.Save_Object(TenGoiPhauThuat, GhiChu);
                if (ok)
                {
                    Response.Clear(); Response.Write(idkhoachinh);
                    return;
                }
            }
            else
            {
                NhanSu_Process.GoiPhauThuat tempTT = NhanSu_Process.GoiPhauThuat.Insert_Object(TenGoiPhauThuat, GhiChu);
                if (tempTT != null)
                {
                    Response.Clear(); Response.Write(tempTT.IDGoiPhauThuat);
                    return;
                }
            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }
}


