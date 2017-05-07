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

public partial class bacsi_ajax : System.Web.UI.Page
{
    protected DataProcess s_bacsi()
    {
        DataProcess bacsi = new DataProcess("bacsi");
        bacsi.data("idbacsi", Request.QueryString["idkhoachinh"]);
        bacsi.data("mabacsi", Request.QueryString["mabacsi"]);
        bacsi.data("tenbacsi", Request.QueryString["tenbacsi"]);
        bacsi.data("dienthoai", Request.QueryString["dienthoai"]);
        bacsi.data("diachi", Request.QueryString["diachi"]);
        bacsi.data("gioitinh", Request.QueryString["gioitinh"]);
        bacsi.data("idphongkhambenh", Request.QueryString["idphongkhambenh"]);
        bacsi.data("username", Request.QueryString["username"]);
        bacsi.data("pass", Request.QueryString["pass"]);
        bacsi.data("idchucvu", Request.QueryString["idchucvu"]);
        bacsi.data("ngaysinh", Request.QueryString["ngaysinh"]);
        bacsi.data("luongcoban", Request.QueryString["luongcoban"]);
        bacsi.data("isthoiviec", Request.QueryString["isthoiviec"]);
        bacsi.data("pthh", Request.QueryString["pthh"]);
        bacsi.data("ptcd", Request.QueryString["ptcd"]);
        bacsi.data("ghichu", Request.QueryString["ghichu"]);
        bacsi.data("IsBSNgoaiVien", Request.QueryString["IsBSNgoaiVien"]);
        return bacsi;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_bacsi(); break;
            case "xoa": Xoa_bacsi(); break;
            case "TimKiem": TimKiem(); break;
            case "idphongkhambenhSearch": idphongkhambenhSearch(); break;
        }
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
    private void Xoa_bacsi()
    {
        try
        {
            DataProcess process = s_bacsi();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idbacsi"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_bacsi()
    {
        try
        {
            DataProcess process = s_bacsi();
            if (process.getData("idbacsi") != null && process.getData("idbacsi") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idbacsi"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idbacsi"));
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
        bool search = Userlogin_new.HavePermision(this, "bacsi_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "bacsi_Add");
            bool delete = Userlogin_new.HavePermision(this, "bacsi_Delete");
            bool edit = Userlogin_new.HavePermision(this, "bacsi_Edit");
            DataProcess process = s_bacsi();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idbacsi),T.*
                   ,A.tenphongkhambenh
                               from bacsi T
                    left join phongkhambenh  A on T.idphongkhambenh=A.idphongkhambenh
          where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}


