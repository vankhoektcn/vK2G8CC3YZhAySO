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
            case "Them": InsertCLSPhauThuat(); break;
            case "Sua": UpdateCLSPhauThuat(); break;
            case "setTimKiem": setTimKiem(); break;
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

    private void setTimKiem()
    {
        string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
        DataTable table = NhanSu_Process.CLSPhauThuat.GetTable("select idCLSPhauThuat,idGoiPhauThuat,idCLS,tendichvu from CLSPhauThuat a left join banggiadichvu b on b.idbanggiadichvu = a.idcls where idCLSPhauThuat = " + idkhoachinh);
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

    private void InsertCLSPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idGoiPhauThuat = "";
            if (Request.QueryString["idGoiPhauThuat"] != null)
            {
                idGoiPhauThuat = Request.QueryString["idGoiPhauThuat"].ToString();
            } string idCLS = "";
            if (Request.QueryString["idCLS"] != null)
            {
                idCLS = Request.QueryString["idCLS"].ToString();
            }
            NhanSu_Process.CLSPhauThuat tempTT = NhanSu_Process.CLSPhauThuat.Insert_Object(idGoiPhauThuat, idCLS);
            if (tempTT != null)
            {
                Response.Clear(); Response.Write(tempTT.idCLSPhauThuat);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");


    }
    private void UpdateCLSPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string idGoiPhauThuat = "";
            if (Request.QueryString["idGoiPhauThuat"] != null)
            {
                idGoiPhauThuat = Request.QueryString["idGoiPhauThuat"].ToString();
            } string idCLS = "";
            if (Request.QueryString["idCLS"] != null)
            {
                idCLS = Request.QueryString["idCLS"].ToString();
            }
            NhanSu_Process.CLSPhauThuat temp = NhanSu_Process.CLSPhauThuat.Create_CLSPhauThuat(idkhoachinh);
            bool ok = temp.Save_Object(idGoiPhauThuat, idCLS);
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


