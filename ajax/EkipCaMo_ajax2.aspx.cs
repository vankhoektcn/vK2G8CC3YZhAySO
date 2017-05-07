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

public partial class EkipCaMo_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable(); break;
            case "xoa": XoaEkipCaMo(); break;
        }
    }

    private void XoaEkipCaMo()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete EkipCaMo where idekipmo=" + idkhoachinh;
            bool ok = NhanSu_Process.EkipCaMo.ExecSQL(sql);
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
            string tenekipcamo = "";
            if (Request.QueryString["tenekipcamo"] != null)
            {
                tenekipcamo = Request.QueryString["tenekipcamo"].ToString();
            } string phamtramekipmo = "";
            if (Request.QueryString["phamtramekipmo"] != null)
            {
                phamtramekipmo = Request.QueryString["phamtramekipmo"].ToString();
            } string tienekipmo = "";
            if (Request.QueryString["tienekipmo"] != null)
            {
                tienekipmo = Request.QueryString["tienekipmo"].ToString();
            } string ghichu = "";
            if (Request.QueryString["ghichu"] != null)
            {
                ghichu = Request.QueryString["ghichu"].ToString();
            } if (!idkhoachinh.Trim().Equals(""))
            {
                NhanSu_Process.EkipCaMo temp = NhanSu_Process.EkipCaMo.Create_EkipCaMo(idkhoachinh);
                bool ok = temp.Save_Object(temp.idekipmo, tenekipcamo, phamtramekipmo, tienekipmo, ghichu);
                if (ok)
                {
                    Response.Clear(); Response.Write(idkhoachinh);
                    return;
                }
            }
            else
            {
                NhanSu_Process.EkipCaMo tempTT = NhanSu_Process.EkipCaMo.Insert_Object(DataAcess.Connect.GetTable("SELECT TOP 1  a from (SELECT TOP 1 idekipmo+1 as a FROM EkipCaMo ORDER BY idekipmo DESC union select 1 as a)as a order by a desc").Rows[0][0].ToString(), tenekipcamo, phamtramekipmo, tienekipmo, ghichu);
                if (tempTT != null)
                {
                    Response.Clear(); Response.Write(tempTT.idekipmo);
                    return;
                }
            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }
}


