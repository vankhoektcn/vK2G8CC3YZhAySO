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

public partial class loainghiphep_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Them": Insertloainghiphep(); break;
            case "Sua": Updateloainghiphep(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoaloainghiphep(); break;
        }
    }

    private void Xoaloainghiphep()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete loainghiphep where idnghiphep=" + idkhoachinh;
            bool ok = NhanSu_Process.loainghiphep.ExecSQL(sql);
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
        DataTable table = NhanSu_Process.loainghiphep.GetTable("select idnghiphep,tennghiphep from loainghiphep where idnghiphep = " + idkhoachinh);
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

    private void Insertloainghiphep()
    {
        try
        {
            char[] splitter = { '/' };
            string tennghiphep = Request.QueryString["tennghiphep"].ToString();

            NhanSu_Process.loainghiphep tempTT = NhanSu_Process.loainghiphep.Insert_Object(tennghiphep);
            if (tempTT != null)
            {
                Response.Clear(); Response.Write(tempTT.idnghiphep);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");


    }
    private void Updateloainghiphep()
    {
        try
        {
            char[] splitter = { '/' };
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string tennghiphep = Request.QueryString["tennghiphep"].ToString();

            NhanSu_Process.loainghiphep temp = NhanSu_Process.loainghiphep.Create_loainghiphep(idkhoachinh);
            bool ok = temp.Save_Object(tennghiphep);
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


