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

public partial class catruc_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable(); break;
            case "xoa": Xoacatruc(); break;
        }
    }

    private void Xoacatruc()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete catruc where idcatruc=" + idkhoachinh;
            bool ok = NhanSu_Process.catruc.ExecSQL(sql);
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
            string tencatruc = Request.QueryString["tencatruc"].ToString();
            string tientruc = Request.QueryString["tientruc"].ToString();
            string ghichu = Request.QueryString["ghichu"].ToString();
            if (!idkhoachinh.Trim().Equals(""))
            {
                NhanSu_Process.catruc temp = NhanSu_Process.catruc.Create_catruc(idkhoachinh);
                bool ok = temp.Save_Object(tencatruc, tientruc, ghichu);
                if (ok)
                {
                    Response.Clear(); Response.Write(idkhoachinh);
                    return;
                }
            }
            else
            {
                NhanSu_Process.catruc tempTT = NhanSu_Process.catruc.Insert_Object(tencatruc, tientruc, ghichu);
                if (tempTT != null)
                {
                    Response.Clear(); Response.Write(tempTT.idcatruc);
                    return;
                }
            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }
}


