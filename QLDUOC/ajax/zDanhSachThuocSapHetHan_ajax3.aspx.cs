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

public partial class zDanhSachThuocSapHetHan_ajax : System.Web.UI.Page
{
    protected DataProcess s_zDanhSachThuocSapHetHan()
    {
        DataProcess zDanhSachThuocSapHetHan = new DataProcess("zDanhSachThuocSapHetHan");
        zDanhSachThuocSapHetHan.data("IdDanhSach", Request.QueryString["idkhoachinh"]);
        zDanhSachThuocSapHetHan.data("NgayXetHH", Request.QueryString["NgayXetHH"]);
        zDanhSachThuocSapHetHan.data("IdLoaiThuoc", Request.QueryString["IdLoaiThuoc"]);
        zDanhSachThuocSapHetHan.data("IdKho", Request.QueryString["IdKho"]);
        zDanhSachThuocSapHetHan.data("SoNgay", Request.QueryString["SoNgay"]);
        zDanhSachThuocSapHetHan.data("SoThang", Request.QueryString["SoThang"]);
        return zDanhSachThuocSapHetHan;
    }
    protected DataProcess s_zDanhSachThuocSapHetHan_ChiTiet()
    {
        DataProcess zDanhSachThuocSapHetHan_ChiTiet = new DataProcess("zDanhSachThuocSapHetHan_ChiTiet");
        zDanhSachThuocSapHetHan_ChiTiet.data("IDChiTiet", Request.QueryString["idkhoachinh"]);
        zDanhSachThuocSapHetHan_ChiTiet.data("IdDanhSach", Request.QueryString["IdDanhSach"]);
        zDanhSachThuocSapHetHan_ChiTiet.data("TENTHUOC", Request.QueryString["TENTHUOC"]);
        zDanhSachThuocSapHetHan_ChiTiet.data("HOATCHAT", Request.QueryString["HOATCHAT"]);
        zDanhSachThuocSapHetHan_ChiTiet.data("TENDVT", Request.QueryString["TENDVT"]);
        zDanhSachThuocSapHetHan_ChiTiet.data("NGAYNHAP", Request.QueryString["NGAYNHAP"]);
        zDanhSachThuocSapHetHan_ChiTiet.data("LOSANXUAT", Request.QueryString["LOSANXUAT"]);
        zDanhSachThuocSapHetHan_ChiTiet.data("NGAYHETHAN", Request.QueryString["NGAYHETHAN"]);
        zDanhSachThuocSapHetHan_ChiTiet.data("SOLUONGTON", Request.QueryString["SOLUONGTON"]);
        return zDanhSachThuocSapHetHan_ChiTiet;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SavezDanhSachThuocSapHetHan(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablezDanhSachThuocSapHetHan_ChiTiet": LuuTablezDanhSachThuocSapHetHan_ChiTiet(); break;
            case "loadTablezDanhSachThuocSapHetHan_ChiTiet": loadTablezDanhSachThuocSapHetHan_ChiTiet(); break;
            case "xoa": XoazDanhSachThuocSapHetHan(); break;
            case "xoazDanhSachThuocSapHetHan_ChiTiet": XoazDanhSachThuocSapHetHan_ChiTiet(); break;
            case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
            case "IdKhoSearch": IdKhoSearch(); break;
            case "InitData": InitData(); break;
        }
    }

    private void IdLoaiThuocSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_LoaiThuoc ");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenLoai"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdKhoSearch()
    {
        StaticData.IdKhoSearch(this);
    }
    private void XoazDanhSachThuocSapHetHan()
    {
        try
        {
            DataProcess process = s_zDanhSachThuocSapHetHan();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("IdDanhSach"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void XoazDanhSachThuocSapHetHan_ChiTiet()
    {
        try
        {
            DataProcess process = s_zDanhSachThuocSapHetHan_ChiTiet();
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
    private void setTimKiem()
    {
        if (StaticData.HavePermision(this, "zDanhSachThuocSapHetHan_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 T.*
                   ,mkv_IdLoaiThuoc = A.TenLoai
                   ,mkv_IdKho = B.tenkho
                               from zDanhSachThuocSapHetHan T
                    left join Thuoc_LoaiThuoc  A on T.IdLoaiThuoc=A.LoaiThuocID
                    left join khothuoc  B on T.IdKho=B.idkho
 where T.IdDanhSach ='" + idkhoachinh + "'");
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

    private void TimKiem()
    {
        if (StaticData.HavePermision(this, "zDanhSachThuocSapHetHan_Search"))
        {
            DataProcess process = s_zDanhSachThuocSapHetHan();
            string NgayXetHH = process.getData("NgayXetHH");
            string IdLoaiThuoc = process.getData("IdLoaiThuoc");
            string SoNgay = process.getData("SoNgay");
            NgayXetHH = StaticData.CheckDate(NgayXetHH);
            DataAcess.Connect.ExecSQL("DELETE zDanhSachThuocSapHetHan_chitiet");
            DataAcess.Connect.ExecSQL("DELETE zDanhSachThuocSapHetHan");
            process.Insert();
            string idDanhSach = process.getData("IdDanhSach");
            string sqlSelect = @"
                                INSERT INTO zDanhSachThuocSapHetHan_chitiet(
                                                    IdDanhSach
                                                    ,TENTHUOC
                                                    ,HOATCHAT
                                                    ,TENDVT
                                                    ,NGAYNHAP
                                                    ,LOSANXUAT
                                                    ,NGAYHETHAN
                                                    ,SOLUONG
                                                    ,SOLUONGXUAT
                                                    ,SOLUONGTON
                                                    )
                            SELECT 
                                  " + idDanhSach + @",
                                  C.TENTHUOC,
                                  C.congthuc as HOATCHAT,
	                              D.TENDVT,
                                  NGAYNHAP=A.NGAYTHANG_NHAP,
                                   LOSANXUAT=A.losanxuat,
                                  NGAYHETHAN=A.ngayhethan,
                                  A.SOLUONG
                                  ,SOLUONGXUAT=ISNULL( (SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUNHAPKHO=A.IDCHITIETPHIEUNHAPKHO AND IDKHO_XUAT=A.IDKHO_NHAP),0)
                                  ,SOLUONGTON=0
                            FROM chitietphieunhapkho A
                            LEFT JOIN thuoc C ON A.idthuoc=C.idthuoc
                            LEFT JOIN Thuoc_DonViTinh D ON C.iddvt=D.Id
                            WHERE 1=1  and a.soluong >isnull((select sum(soluong) from chitietphieuxuatkho where idchitietphieunhapkho =a.idchitietphieunhapkho),0)
                            " + (!string.IsNullOrEmpty(process.getData("IdKho")) && process.getData("IdKho") != "0" ? " and A.idkho_NHAP=" + process.getData("IdKho") : "") + @"
                                   AND convert(INT,A.ngayhethan-'" + NgayXetHH + "')<=" + SoNgay+ @"
                                   --AND convert(INT,A.ngayhethan-'" + NgayXetHH + @"')>=0
                                     AND A.NGAYTHANG_NHAP>='2013-07-29 13:30:00' 
            "
                           + (!string.IsNullOrEmpty(process.getData("IdLoaiThuoc")) && process.getData("IdLoaiThuoc") != "0" ? " AND C.LOAITHUOCID=" + process.getData("IdLoaiThuoc") : "")
                           + @" ORDER BY C.TENTHUOC,A.NGAYTHANG_NHAP";

            DataAcess.Connect.ExecSQL(sqlSelect);


            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IdDanhSach),T.*
                                 ,A.tenkho
                               from zDanhSachThuocSapHetHan T
                               left join khothuoc  A on T.IdKho=A.idkho
                              where IdDanhSach=" + idDanhSach);

            
           

            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdDanhSach") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayXetHH") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKho") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoNgay") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoThang") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["IdDanhSach"].ToString() + "')\">");
                        html.Append("<td>" + DataProcess.sGetDate(table.Rows[i]["NgayXetHH"].ToString(), false, true) + "</td>");
                        html.Append("<td>" + table.Rows[i]["tenkho"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["SoNgay"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["SoThang"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                }
                html.Append("</table>");
                html.Append(process.Paging());
                Response.Clear(); Response.Write(html);
                return;
            }
            else
            {
                Response.StatusCode = 500;
            }
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }

    private void SavezDanhSachThuocSapHetHan()
    {
        try
        {
            DataProcess process = s_zDanhSachThuocSapHetHan();
            if (process.getData("IdDanhSach") != null && process.getData("IdDanhSach") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdDanhSach"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("IdDanhSach"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablezDanhSachThuocSapHetHan_ChiTiet()
    {
        try
        {
            DataProcess process = s_zDanhSachThuocSapHetHan_ChiTiet();
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
    public void loadTablezDanhSachThuocSapHetHan_ChiTiet()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENTHUOC") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("HOATCHAT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TENDVT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYNHAP") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LOSANXUAT") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYHETHAN") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOLUONGTON") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = StaticData.HavePermision(this, "zDanhSachThuocSapHetHan_ChiTiet_Add");
        bool search = StaticData.HavePermision(this, "zDanhSachThuocSapHetHan_ChiTiet_Search");
        if (search)
        {
            DataProcess process = s_zDanhSachThuocSapHetHan_ChiTiet();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.IDChiTiet),T.*
                   ,A.NgayXetHH
                               from zDanhSachThuocSapHetHan_ChiTiet T
                    left join zDanhSachThuocSapHetHan  A on T.IdDanhSach=A.IdDanhSach
          where T.IdDanhSach='" + process.getData("IdDanhSach") + "'");


            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["SOLUONGTON"] = double.Parse(table.Rows[i]["SOLUONG"].ToString()) - double.Parse(table.Rows[i]["SOLUONGXUAT"].ToString());
            }
            table.DefaultView.RowFilter = "SOLUONGTON>0";
            table = table.DefaultView.ToTable();



            if (table.Rows.Count > 0)
            {
                paging = process.Paging("zDanhSachThuocSapHetHan_ChiTiet");
                bool delete = StaticData.HavePermision(this, "zDanhSachThuocSapHetHan_ChiTiet_Delete");
                bool edit = StaticData.HavePermision(this, "zDanhSachThuocSapHetHan_ChiTiet_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='TENTHUOC' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TENTHUOC"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='HOATCHAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["HOATCHAT"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='TENDVT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TENDVT"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='NGAYNHAP' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + DataProcess.sGetDate(table.Rows[i]["NGAYNHAP"].ToString(), false, true) + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + "/></td>"); html.Append("<td><input mkv='true' id='LOSANXUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["LOSANXUAT"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='NGAYHETHAN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + DataProcess.sGetDate(table.Rows[i]["NGAYHETHAN"].ToString(), false, true) + "' onblur='TestDate(this)' " + (!edit ? "disabled" : "") + "/></td>"); html.Append("<td><input mkv='true' id='SOLUONGTON' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SOLUONGTON"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["IDChiTiet"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='TENTHUOC' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
            html.Append("<td><input mkv='true' id='HOATCHAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
            html.Append("<td><input mkv='true' id='TENDVT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
            html.Append("<td><input mkv='true' id='NGAYNHAP' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)'/></td>");
            html.Append("<td><input mkv='true' id='LOSANXUAT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>");
            html.Append("<td><input mkv='true' id='NGAYHETHAN' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)'/></td>");
            html.Append("<td><input mkv='true' id='SOLUONGTON' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
    //───────────────────────────────────────────────────────────────────────────────────────  
    private void InitData()
    {
        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        html.AppendLine("<data id=\"NgayXetHH\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("</root>");
        Response.Clear();
        Response.Write(html.ToString().Replace("&", "&amp;"));
    }
    //───────────────────────────────────────────────────────────────────────────────────────  
}


