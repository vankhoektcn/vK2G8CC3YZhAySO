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

public partial class CLSPhauThuat_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable(); break;
            case "xoa": XoaCLSPhauThuat(); break;
            case "timkiemCLS": TimkiemCLS(); break;
        }
    }

    private void TimkiemCLS()
    {
        string sql = "";

        DataTable table = DataAcess.Connect.GetTable("select top 50 tendichvu,idbanggiadichvu from banggiadichvu where tendichvu like N'" + Request.QueryString["q"] + "%'" + sql);
        string html = "";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += table.Rows[i][0] + "|" + table.Rows[i][1] + "|" + Environment.NewLine;
        }
        Response.Clear();
        Response.Write(html);
    }

    private void XoaCLSPhauThuat()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete CLSPhauThuat where idCLSPhauThuat=" + idkhoachinh;
            bool ok = NhanSu_Process.CLSPhauThuat.ExecSQL(sql);
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
            string idchitietCLSPhauThuat = "";
            if (Request.QueryString["idchitietCLSPhauThuat"] != null)
            {
                idchitietCLSPhauThuat = Request.QueryString["idchitietCLSPhauThuat"].ToString();
            } string idcaphauthuat = "";
            if (Request.QueryString["idcaphauthuat"] != null)
            {
                idcaphauthuat = Request.QueryString["idcaphauthuat"].ToString();
            } if (!idkhoachinh.Trim().Equals(""))
            {
                NhanSu_Process.CLSPhauThuat temp = NhanSu_Process.CLSPhauThuat.Create_CLSPhauThuat(idkhoachinh);
                bool ok = temp.Save_Object(idchitietCLSPhauThuat, idcaphauthuat);
                if (ok)
                {
                    Response.Clear(); Response.Write(idkhoachinh);
                    return;
                }
            }
            else
            {
                NhanSu_Process.CLSPhauThuat tempTT = NhanSu_Process.CLSPhauThuat.Insert_Object(idchitietCLSPhauThuat, idcaphauthuat);
                if (tempTT != null)
                {
                    Response.Clear(); Response.Write(tempTT.idCLSPhauThuat);
                    return;
                }
            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }
}


