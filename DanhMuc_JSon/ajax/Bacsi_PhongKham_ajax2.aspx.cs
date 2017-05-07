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

public partial class Bacsi_PhongKham_ajax : System.Web.UI.Page
{
    protected DataProcess s_Bacsi_PhongKham()
    {
        DataProcess Bacsi_PhongKham = new DataProcess("Bacsi_PhongKham");
        Bacsi_PhongKham.data("IDChiTiet", Request.QueryString["idkhoachinh"]);
        Bacsi_PhongKham.data("idbacsi", Request.QueryString["idbacsi"]);
        Bacsi_PhongKham.data("idphongkhambenh", Request.QueryString["idphongkhambenh"]);
        return Bacsi_PhongKham;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_Bacsi_PhongKham(); break;
            case "xoa": Xoa_Bacsi_PhongKham(); break;
            case "TimKiem": TimKiem(); break;
            case "idbacsiSearch": idbacsiSearch(); break;
            case "idphongkhambenhSearch": idphongkhambenhSearch(); break;
        }
    }
    private void idbacsiSearch()
    {
        DataTable table = DataProcess.GetTable("select * from bacsi ");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenbacsi"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idphongkhambenhSearch()
    {
        DataTable table = DataProcess.GetTable("select * from phongkhambenh ");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenphongkhambenh"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoa_Bacsi_PhongKham()
    {
        try
        {
            DataProcess process = s_Bacsi_PhongKham();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IDChiTiet"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_Bacsi_PhongKham()
    {
        try
        {
            DataProcess process = s_Bacsi_PhongKham();
            if (process.getData("IDChiTiet") != null && process.getData("IDChiTiet") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDChiTiet"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IDChiTiet"));
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
        bool search = Userlogin_new.HavePermision(this, "Bacsi_PhongKham_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "Bacsi_PhongKham_Add");
            bool delete = Userlogin_new.HavePermision(this, "Bacsi_PhongKham_Delete");
            bool edit = Userlogin_new.HavePermision(this, "Bacsi_PhongKham_Edit");
            DataProcess process = s_Bacsi_PhongKham();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IDChiTiet),T.*
                   ,A.tenbacsi
                   ,B.tenphongkhambenh
                               from Bacsi_PhongKham T
                    left join bacsi  A on T.idbacsi=A.idbacsi
                    left join phongkhambenh  B on T.idphongkhambenh=B.idphongkhambenh
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}


