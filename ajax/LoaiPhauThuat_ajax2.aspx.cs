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

public partial class LoaiPhauThuat_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable(); break;
            case "xoa": XoaLoaiPhauThuat(); break;
        }
    }

    private void XoaLoaiPhauThuat()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete LoaiPhauThuat where idloaiphauthuat=" + idkhoachinh;
            bool ok = NhanSu_Process.LoaiPhauThuat.ExecSQL(sql);
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
            string tenloaiphauthuat = "";
            if (Request.QueryString["tenloaiphauthuat"] != null)
            {
                tenloaiphauthuat = Request.QueryString["tenloaiphauthuat"].ToString();
            } string ghichu = "";
            if (Request.QueryString["ghichu"] != null)
            {
                ghichu = Request.QueryString["ghichu"].ToString();
            } if (!idkhoachinh.Trim().Equals(""))
            {
                NhanSu_Process.LoaiPhauThuat temp = NhanSu_Process.LoaiPhauThuat.Create_LoaiPhauThuat(idkhoachinh);
                bool ok = temp.Save_Object(temp.idloaiphauthuat, tenloaiphauthuat, ghichu);
                if (ok)
                {
                    Response.Clear(); Response.Write(idkhoachinh);
                    return;
                }
            }
            else
            {
                NhanSu_Process.LoaiPhauThuat tempTT = NhanSu_Process.LoaiPhauThuat.Insert_Object(DataAcess.Connect.GetTable("SELECT TOP 1  a from (SELECT TOP 1 idloaiphauthuat+1 as a FROM LoaiPhauThuat ORDER BY idloaiphauthuat DESC union select 1 as a)as a order by a desc").Rows[0][0].ToString(), tenloaiphauthuat, ghichu);
                if (tempTT != null)
                {
                    Response.Clear(); Response.Write(tempTT.idloaiphauthuat);
                    return;
                }
            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }
}


