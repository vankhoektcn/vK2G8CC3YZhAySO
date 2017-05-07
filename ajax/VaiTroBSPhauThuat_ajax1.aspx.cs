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

public partial class VaiTroBSPhauThuat_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Them": InsertVaiTroBSPhauThuat(); break;
            case "Sua": UpdateVaiTroBSPhauThuat(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": XoaVaiTroBSPhauThuat(); break;
            case "DropDownList_idekipmo": LoadDropDownList_idekipmo(); break;
        }
    }

    // luon luon chi co 2 truong la id va value
    private void LoadDropDownList_idekipmo()
    {
        DataTable table = NhanSu_Process.EkipCaMo.GetTable("select * from EkipCaMo ");
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
    private void XoaVaiTroBSPhauThuat()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete VaiTroBSPhauThuat where idVaiTroBS=" + idkhoachinh;
            bool ok = NhanSu_Process.VaiTroBSPhauThuat.ExecSQL(sql);
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
        DataTable table = NhanSu_Process.VaiTroBSPhauThuat.GetTable("select idVaiTroBS,tenvaitro,idekipmo,GhiChu from VaiTroBSPhauThuat where idVaiTroBS = " + idkhoachinh);
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

    private void InsertVaiTroBSPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string tenvaitro = "";
            if (Request.QueryString["tenvaitro"] != null)
            {
                tenvaitro = Request.QueryString["tenvaitro"].ToString();
            } string idekipmo = "";
            if (Request.QueryString["idekipmo"] != null)
            {
                idekipmo = Request.QueryString["idekipmo"].ToString();
            } string GhiChu = "";
            if (Request.QueryString["GhiChu"] != null)
            {
                GhiChu = Request.QueryString["GhiChu"].ToString();
            }
            NhanSu_Process.VaiTroBSPhauThuat tempTT = NhanSu_Process.VaiTroBSPhauThuat.Insert_Object(tenvaitro, idekipmo, GhiChu);
            if (tempTT != null)
            {
                Response.Clear(); Response.Write(tempTT.idVaiTroBS);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");


    }
    private void UpdateVaiTroBSPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string tenvaitro = "";
            if (Request.QueryString["tenvaitro"] != null)
            {
                tenvaitro = Request.QueryString["tenvaitro"].ToString();
            } string idekipmo = "";
            if (Request.QueryString["idekipmo"] != null)
            {
                idekipmo = Request.QueryString["idekipmo"].ToString();
            } string GhiChu = "";
            if (Request.QueryString["GhiChu"] != null)
            {
                GhiChu = Request.QueryString["GhiChu"].ToString();
            }
            NhanSu_Process.VaiTroBSPhauThuat temp = NhanSu_Process.VaiTroBSPhauThuat.Create_VaiTroBSPhauThuat(idkhoachinh);
            bool ok = temp.Save_Object(tenvaitro, idekipmo, GhiChu);
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


