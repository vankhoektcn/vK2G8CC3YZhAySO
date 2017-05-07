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
using System.Text;

public partial class ChanDoanICD_ajax : System.Web.UI.Page
{
    protected DataProcess s_ChanDoanICD()
    {
        DataProcess ChanDoanICD = new DataProcess("ChanDoanICD");
        ChanDoanICD.data("IDICD", Request.QueryString["idkhoachinh"]);
        ChanDoanICD.data("SoTT", Request.QueryString["SoTT"]);
        ChanDoanICD.data("IDChuongICD", Request.QueryString["IDChuongICD"]);
        ChanDoanICD.data("IDNhomICD", Request.QueryString["IDNhomICD"]);
        ChanDoanICD.data("MaICD", Request.QueryString["MaICD"]);
        ChanDoanICD.data("MoTa", Request.QueryString["MoTa"]);
        ChanDoanICD.data("EnglishName", Request.QueryString["EnglishName"]);
        return ChanDoanICD;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_ChanDoanICD(); break;
            case "xoa": Xoa_ChanDoanICD(); break;
            case "TimKiem": TimKiem(); break;
            case "IDChuongICDSearch": IDChuongICDSearch(); break;
            case "IDNhomICDSearch": IDNhomICDSearch(); break;
        }
    }
    private void IDChuongICDSearch()
    {
        DataTable table = DataProcess.GetTable("select * from ChuongICD ");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenChuongICD"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IDNhomICDSearch()
    {
        DataTable table = DataProcess.GetTable("select * from NhomICD ");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenNhomICD"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoa_ChanDoanICD()
    {
        try
        {
            DataProcess process = s_ChanDoanICD();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IDICD"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_ChanDoanICD()
    {
        try
        {
            DataProcess process = s_ChanDoanICD();
            if (process.getData("IDICD") != null && process.getData("IDICD") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDICD"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDICD"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void TimKiem()
    {
        bool search = Userlogin_new.HavePermision(this, "ChanDoanICD_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "ChanDoanICD_Add");
            bool delete = Userlogin_new.HavePermision(this, "ChanDoanICD_Delete");
            bool edit = Userlogin_new.HavePermision(this, "ChanDoanICD_Edit");
            DataProcess process = s_ChanDoanICD();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IDICD),T.*
                   ,A.TenChuongICD
                   ,B.TenNhomICD
                               from ChanDoanICD T
                    left join ChuongICD  A on T.IDChuongID=A.IDChuongICD
                    left join NhomICD  B on T.IDNhomICD=B.IDNhomICD
                  where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}


