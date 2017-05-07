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

public partial class ChiTietPhuCapBacSiPhauThuat_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Them": InsertChiTietPhuCapBacSiPhauThuat(); break;
            case "Sua": UpdateChiTietPhuCapBacSiPhauThuat(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": XoaChiTietPhuCapBacSiPhauThuat(); break;
            case "DropDownList_idloaiphauthuat": LoadDropDownList_idloaiphauthuat(); break;
            case "DropDownList_idvaitroBSPT": LoadDropDownList_idvaitroBSPT(); break;
        }
    }

    // luon luon chi co 2 truong la id va value
    private void LoadDropDownList_idloaiphauthuat()
    {
        DataTable table = NhanSu_Process.LoaiPhauThuat.GetTable("select * from LoaiPhauThuat ");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {

                    html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y][1].ToString();

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    // luon luon chi co 2 truong la id va value
    private void LoadDropDownList_idvaitroBSPT()
    {
        DataTable table = NhanSu_Process.VaiTroBSPhauThuat.GetTable("select * from VaiTroBSPhauThuat ");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {

                    html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y][1].ToString();

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaChiTietPhuCapBacSiPhauThuat()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete ChiTietPhuCapBacSiPhauThuat where idchitietPCBSPT=" + idkhoachinh;
            bool ok = NhanSu_Process.ChiTietPhuCapBacSiPhauThuat.ExecSQL(sql);
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

    private void setTimKiem()
    {
        string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
        DataTable table = NhanSu_Process.ChiTietPhuCapBacSiPhauThuat.GetTable("select idchitietPCBSPT,idloaiphauthuat,idvaitroBSPT,phantramphucap,tienphucap,ghichu from ChiTietPhuCapBacSiPhauThuat where idchitietPCBSPT = " + idkhoachinh);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Columns.Count; y++)
                {
                    try
                    {

                        html += DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "@";
                    }
                    catch (Exception)
                    {
                        html += table.Rows[0][y].ToString() + "@";
                    }
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    private void InsertChiTietPhuCapBacSiPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idloaiphauthuat = "";
            if (Request.QueryString["idloaiphauthuat"] != null)
            {
                idloaiphauthuat = Request.QueryString["idloaiphauthuat"].ToString();
            } string idvaitroBSPT = "";
            if (Request.QueryString["idvaitroBSPT"] != null)
            {
                idvaitroBSPT = Request.QueryString["idvaitroBSPT"].ToString();
            } string phantramphucap = "";
            if (Request.QueryString["phantramphucap"] != null)
            {
                phantramphucap = Request.QueryString["phantramphucap"].ToString();
            } string tienphucap = "";
            if (Request.QueryString["tienphucap"] != null)
            {
                tienphucap = Request.QueryString["tienphucap"].ToString();
            } string ghichu = "";
            if (Request.QueryString["ghichu"] != null)
            {
                ghichu = Request.QueryString["ghichu"].ToString();
            }
            NhanSu_Process.ChiTietPhuCapBacSiPhauThuat tempTT = NhanSu_Process.ChiTietPhuCapBacSiPhauThuat.Insert_Object(DataAcess.Connect.GetTable("SELECT TOP 1  a from (SELECT TOP 1 idchitietPCBSPT+1 as a FROM ChiTietPhuCapBacSiPhauThuat ORDER BY idchitietPCBSPT DESC union select 1 as a)as a order by a desc").Rows[0][0].ToString(), idloaiphauthuat, idvaitroBSPT, phantramphucap, tienphucap, ghichu);
            if (tempTT != null)
            {
                Response.Clear(); Response.Write(tempTT.idchitietPCBSPT);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");


    }
    private void UpdateChiTietPhuCapBacSiPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string idloaiphauthuat = "";
            if (Request.QueryString["idloaiphauthuat"] != null)
            {
                idloaiphauthuat = Request.QueryString["idloaiphauthuat"].ToString();
            } string idvaitroBSPT = "";
            if (Request.QueryString["idvaitroBSPT"] != null)
            {
                idvaitroBSPT = Request.QueryString["idvaitroBSPT"].ToString();
            } string phantramphucap = "";
            if (Request.QueryString["phantramphucap"] != null)
            {
                phantramphucap = Request.QueryString["phantramphucap"].ToString();
            } string tienphucap = "";
            if (Request.QueryString["tienphucap"] != null)
            {
                tienphucap = Request.QueryString["tienphucap"].ToString();
            } string ghichu = "";
            if (Request.QueryString["ghichu"] != null)
            {
                ghichu = Request.QueryString["ghichu"].ToString();
            }
            NhanSu_Process.ChiTietPhuCapBacSiPhauThuat temp = NhanSu_Process.ChiTietPhuCapBacSiPhauThuat.Create_ChiTietPhuCapBacSiPhauThuat(idkhoachinh);
            bool ok = temp.Save_Object(temp.idchitietPCBSPT, idloaiphauthuat, idvaitroBSPT, phantramphucap, tienphucap, ghichu);
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
}


