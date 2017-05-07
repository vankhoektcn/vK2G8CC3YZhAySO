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

public partial class benhnhan_ajax : System.Web.UI.Page
{
    protected DataProcess s_benhnhan()
    {
        DataProcess benhnhan = new DataProcess("benhnhan");
        benhnhan.data("idbenhnhan", Request.QueryString["idkhoachinh"]);
        benhnhan.data("mabenhnhan", Request.QueryString["mabenhnhan"]);
        benhnhan.data("tenbenhnhan", Request.QueryString["tenbenhnhan"]);
        benhnhan.data("idloaiuutien", Request.QueryString["idloaiuutien"]);
        benhnhan.data("diachi", Request.QueryString["diachi"]);
        benhnhan.data("dienthoai", Request.QueryString["dienthoai"]);
        benhnhan.data("gioitinh", Request.QueryString["gioitinh"]);
        benhnhan.data("ngaysinh", Request.QueryString["ngaysinh"]);
        benhnhan.data("chungminhthu", Request.QueryString["chungminhthu"]);
        benhnhan.data("loai", Request.QueryString["loai"]);
        benhnhan.data("tiensubenhnhan", Request.QueryString["tiensubenhnhan"]);
        benhnhan.data("tinhtrangbandau", Request.QueryString["tinhtrangbandau"]);
        benhnhan.data("sobhyt", Request.QueryString["sobhyt"]);
        benhnhan.data("ngaybatdau", Request.QueryString["ngaybatdau"]);
        benhnhan.data("ngayhethan", Request.QueryString["ngayhethan"]);
        benhnhan.data("thongtinbaotin", Request.QueryString["thongtinbaotin"]);
        benhnhan.data("tencongty", Request.QueryString["tencongty"]);
        benhnhan.data("thongtincongty", Request.QueryString["thongtincongty"]);
        benhnhan.data("idloaibh", Request.QueryString["idloaibh"]);
        benhnhan.data("nghenghiep", Request.QueryString["nghenghiep"]);
        benhnhan.data("noicongtac", Request.QueryString["noicongtac"]);
        benhnhan.data("noigioithieu", Request.QueryString["noigioithieu"]);
        benhnhan.data("noidangkykcb", Request.QueryString["noidangkykcb"]);
        benhnhan.data("chandoansobo", Request.QueryString["chandoansobo"]);
        benhnhan.data("ngaytiepnhan", Request.QueryString["ngaytiepnhan"]);
        benhnhan.data("DungTuyen", Request.QueryString["DungTuyen"]);
        benhnhan.data("email", Request.QueryString["email"]);
        benhnhan.data("NguoiLH", Request.QueryString["NguoiLH"]);
        benhnhan.data("DiaChiLH", Request.QueryString["DiaChiLH"]);
        benhnhan.data("DienThoaiLH", Request.QueryString["DienThoaiLH"]);
        benhnhan.data("tenDN", Request.QueryString["tenDN"]);
        benhnhan.data("matKhau", Request.QueryString["matKhau"]);
        benhnhan.data("noicapbhyt", Request.QueryString["noicapbhyt"]);
        benhnhan.data("MaDangKy_KCB_bandau", Request.QueryString["MaDangKy_KCB_bandau"]);
        benhnhan.data("NameNotSign", Request.QueryString["NameNotSign"]);
        benhnhan.data("tinhid", Request.QueryString["tinhid"]);
        benhnhan.data("quanhuyenid", Request.QueryString["quanhuyenid"]);
        benhnhan.data("phuongxaid", Request.QueryString["phuongxaid"]);
        benhnhan.data("sonha", Request.QueryString["sonha"]);
        benhnhan.data("idNoiGioiThieu", Request.QueryString["idNoiGioiThieu"]);
        benhnhan.data("SoThang", Request.QueryString["SoThang"]);
        benhnhan.data("quoctich", Request.QueryString["quoctich"]);
        benhnhan.data("dantoc", Request.QueryString["dantoc"]);
        benhnhan.data("MucHuongBH", Request.QueryString["MucHuongBH"]);
        benhnhan.data("isgiaychuyen", Request.QueryString["isgiaychuyen"]);
        benhnhan.data("IsCapCuu", Request.QueryString["IsCapCuu"]);
        benhnhan.data("IsDungTuyen", Request.QueryString["IsDungTuyen"]);
        benhnhan.data("sobh1", Request.QueryString["sobh1"]);
        benhnhan.data("sobh2", Request.QueryString["sobh2"]);
        benhnhan.data("sobh3", Request.QueryString["sobh3"]);
        benhnhan.data("sobh4", Request.QueryString["sobh4"]);
        benhnhan.data("sobh5", Request.QueryString["sobh5"]);
        benhnhan.data("sobh6", Request.QueryString["sobh6"]);
        benhnhan.data("SOTT", Request.QueryString["SOTT"]);
        benhnhan.data("SoTuoi", Request.QueryString["SoTuoi"]);
        benhnhan.data("lidovaovien", Request.QueryString["lidovaovien"]);
        benhnhan.data("IdNoiDangKyBH", Request.QueryString["IdNoiDangKyBH"]);
        return benhnhan;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savebenhnhan(); break;
            case "setTimKiem": setTimKiem(); break;
            case "xoa": Xoabenhnhan(); break;
            case "TimKiem": TimKiem(); break;
        }
    }

    private void Xoabenhnhan()
    {
        try
        {
            DataProcess process = s_benhnhan();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idbenhnhan"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void setTimKiem()
    {
        if (StaticData.HavePermision(this, "benhnhan_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataAcess.Connect.GetTable(@"select top 1 T.*
                               from benhnhan T
 where T.idbenhnhan ='" + idkhoachinh + "'");
            StringBuilder html = new StringBuilder();
            html.AppendLine("<root>");
            html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {

                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DataProcess.sGetDate(table.Rows[0][y].ToString(), false, true) + "</data>");
                    }
                }
            }
            html.AppendLine("</root>");
            Response.Clear();
            Response.Write(html.ToString().Replace("&", "&amp;"));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }

    private void Savebenhnhan()
    {
        try
        {
            DataProcess process = s_benhnhan();
            if (process.getData("idbenhnhan") != null && process.getData("idbenhnhan") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idbenhnhan"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idbenhnhan"));
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
        if (StaticData.HavePermision(this, "benhnhan_Search"))
        {
            DataProcess process = s_benhnhan();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idbenhnhan),T.*
                               from benhnhan T
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append(process.Paging());
            html.Append("<table class='jtable' id=\"gridTable\">");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("mabenhnhan") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenbenhnhan") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("diachi") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dienthoai") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("gioitinh") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaysinh") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idbenhnhan"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["mabenhnhan"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tenbenhnhan"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["diachi"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["dienthoai"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["gioitinh"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["ngaysinh"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                }
            }
            html.Append("</table>");
            html.Append(process.Paging());
            Response.Clear(); Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
}


