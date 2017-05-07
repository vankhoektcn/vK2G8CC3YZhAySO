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

public partial class ChiTietCLSGoiPhauThuat_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Them": InsertChiTietCLSGoiPhauThuat(); break;
            case "Sua": UpdateChiTietCLSGoiPhauThuat(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": XoaChiTietCLSGoiPhauThuat(); break;
            case "DropDownList_idgoiphauthuat": LoadDropDownList_idgoiphauthuat(); break;
            case "DropDownList_idloaiphauthuat": LoadDropDownList_idloaiphauthuat(); break;
        }
    }

    // luon luon chi co 2 truong la id va value
    private void LoadDropDownList_idgoiphauthuat()
    {
        DataTable table = NhanSu_Process.GoiPhauThuat.GetTable("select * from GoiPhauThuat ");
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
    private void XoaChiTietCLSGoiPhauThuat()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete ChiTietCLSGoiPhauThuat where idchitietCLSPhauThuat=" + idkhoachinh;
            bool ok = NhanSu_Process.ChiTietCLSGoiPhauThuat.ExecSQL(sql);
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
        DataTable table = NhanSu_Process.ChiTietCLSGoiPhauThuat.GetTable("select idchitietCLSPhauThuat,idgoiphauthuat,idcanlamsang,idloaiphauthuat,giatrongoi,giabinhthuong,ghichu from ChiTietCLSGoiPhauThuat where idchitietCLSPhauThuat = " + idkhoachinh);
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

    private void InsertChiTietCLSGoiPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idgoiphauthuat = "";
            if (Request.QueryString["idgoiphauthuat"] != null)
            {
                idgoiphauthuat = Request.QueryString["idgoiphauthuat"].ToString();
            } string idcanlamsang = "";
            if (Request.QueryString["idcanlamsang"] != null)
            {
                idcanlamsang = Request.QueryString["idcanlamsang"].ToString();
            } string idloaiphauthuat = "";
            if (Request.QueryString["idloaiphauthuat"] != null)
            {
                idloaiphauthuat = Request.QueryString["idloaiphauthuat"].ToString();
            } string giatrongoi = "";
            if (Request.QueryString["giatrongoi"] != null)
            {
                giatrongoi = Request.QueryString["giatrongoi"].ToString();
            } string giabinhthuong = "";
            if (Request.QueryString["giabinhthuong"] != null)
            {
                giabinhthuong = Request.QueryString["giabinhthuong"].ToString();
            } string ghichu = "";
            if (Request.QueryString["ghichu"] != null)
            {
                ghichu = Request.QueryString["ghichu"].ToString();
            }
            NhanSu_Process.ChiTietCLSGoiPhauThuat tempTT = NhanSu_Process.ChiTietCLSGoiPhauThuat.Insert_Object(DataAcess.Connect.GetTable("SELECT TOP 1  a from (SELECT TOP 1 idchitietCLSPhauThuat+1 as a FROM ChiTietCLSGoiPhauThuat ORDER BY idchitietCLSPhauThuat DESC union select 1 as a)as a order by a desc").Rows[0][0].ToString(), idgoiphauthuat, idcanlamsang, idloaiphauthuat, giatrongoi, giabinhthuong, ghichu);
            if (tempTT != null)
            {
                Response.Clear(); Response.Write(tempTT.idchitietCLSPhauThuat);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");


    }
    private void UpdateChiTietCLSGoiPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string idgoiphauthuat = "";
            if (Request.QueryString["idgoiphauthuat"] != null)
            {
                idgoiphauthuat = Request.QueryString["idgoiphauthuat"].ToString();
            } string idcanlamsang = "";
            if (Request.QueryString["idcanlamsang"] != null)
            {
                idcanlamsang = Request.QueryString["idcanlamsang"].ToString();
            } string idloaiphauthuat = "";
            if (Request.QueryString["idloaiphauthuat"] != null)
            {
                idloaiphauthuat = Request.QueryString["idloaiphauthuat"].ToString();
            } string giatrongoi = "";
            if (Request.QueryString["giatrongoi"] != null)
            {
                giatrongoi = Request.QueryString["giatrongoi"].ToString();
            } string giabinhthuong = "";
            if (Request.QueryString["giabinhthuong"] != null)
            {
                giabinhthuong = Request.QueryString["giabinhthuong"].ToString();
            } string ghichu = "";
            if (Request.QueryString["ghichu"] != null)
            {
                ghichu = Request.QueryString["ghichu"].ToString();
            }
            NhanSu_Process.ChiTietCLSGoiPhauThuat temp = NhanSu_Process.ChiTietCLSGoiPhauThuat.Create_ChiTietCLSGoiPhauThuat(idkhoachinh);
            bool ok = temp.Save_Object(temp.idchitietCLSPhauThuat, idgoiphauthuat, idcanlamsang, idloaiphauthuat, giatrongoi, giabinhthuong, ghichu);
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


