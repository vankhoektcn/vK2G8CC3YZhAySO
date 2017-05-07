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

public partial class zBaoCaoBNDieuTriNoitru_ajax : System.Web.UI.Page
{
    protected DataProcess s_zBaoCaoBNDieuTriNoitru()
    {
        DataProcess zBaoCaoBNDieuTriNoitru = new DataProcess("zBaoCaoBNDieuTriNoitru");
        zBaoCaoBNDieuTriNoitru.data("ID", Request.QueryString["idkhoachinh"]);
        zBaoCaoBNDieuTriNoitru.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        zBaoCaoBNDieuTriNoitru.data("mabenhnhan", Request.QueryString["mabenhnhan"]);
        zBaoCaoBNDieuTriNoitru.data("tenbenhnhan", Request.QueryString["tenbenhnhan"]);
        zBaoCaoBNDieuTriNoitru.data("chandoan", Request.QueryString["chandoan"]);
        zBaoCaoBNDieuTriNoitru.data("BHYT", Request.QueryString["BHYT"]);
        zBaoCaoBNDieuTriNoitru.data("DICHVU", Request.QueryString["DICHVU"]);
        return zBaoCaoBNDieuTriNoitru;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "setTimKiem": setTimKiem(); break;
            case "TimKiem": TimKiem(); break;
            case "setDefault": setDefault(); break;
            case "XuatExcel": XuatExcel(); break;
        }
    }


    private void setTimKiem()
    {
        if (Profess.Userlogin.HavePermision(this, "zBaoCaoBNDieuTriNoitru_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.ID,T.*
                               from zBaoCaoBNDieuTriNoitru T
 where T.ID ='" + idkhoachinh + "'");
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }
    private string getStingSql()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string tungay = Request.QueryString["tungay"];
        string tugio = Request.QueryString["tugio"];
        string denngay = Request.QueryString["denngay"];
        string dengio = Request.QueryString["dengio"];
        string mabenhnhan = Request.QueryString["mabenhnhan"];
        string tenbenhnhan = Request.QueryString["tenbenhnhan"];
        string loaikham = Request.QueryString["loaikham"];
        string where = " nt.idKhoaNoiTru='" + idkhoa + "' and nt.NgayVaoVien >='" + StaticData.CheckDate(tungay) + " " + tugio + "' and nt.NgayVaoVien <='" + StaticData.CheckDate(denngay) + " " + dengio + "'";
        string where1 = "";
        if (!string.IsNullOrEmpty(mabenhnhan))
            where1 += " and bn.mabenhnhan ='" + mabenhnhan + "'";
        if (!string.IsNullOrEmpty(tenbenhnhan))
            where1 += " and bn.tenbenhnhan like N'%" + tenbenhnhan + "%'";
        if (!string.IsNullOrEmpty(loaikham) && !loaikham.Equals("0"))
        {
            where1 += " and dkk.loaikhamid ='" + loaikham + "'";
        }
        string sql = @"
            select STT=row_number() over (order by tenbenhnhan),TenBenhNhan,ChanDoan='('+MACHANDOAN+') '+TENCHANDOAN
	            ,BHYT= case when dkk.LoaiKhamid =1 then 'a' else '' end
	            ,DICHVU= case when dkk.LoaiKhamid =2 then 'a' else '' end
                ,mabenhnhan
	            ,A.idchitietdangkykham
            from 
            (select distinct ctdkk.iddangkykham,ctdkk.idchitietdangkykham from benhnhannoitru nt inner join chitietdangkykham ctdkk on ctdkk.idchitietdangkykham= nt.idchitietdangkykham 
            where " + where + @") 
            as A inner join dangkykham dkk on dkk.iddangkykham =A.iddangkykham 
            inner join hs_benhnhanbhdongtien hs on hs.id=dkk.IdBenhBHDongTien
            inner join benhnhan bn on bn.idbenhnhan =dkk.idbenhnhan
            where 1=1 " + where1 + "";
        return sql;
    }
    private void TimKiem()
    {
        string sql = getStingSql();
        DataTable table = DataAcess.Connect.GetTable(sql);
        string head = "\"\":\"\""
            + ",\"MABENHNHAN\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("mabenhnhan") + "\""
            + ",\"TENBENHNHAN\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenbenhnhan") + "\""
            + ",\"CHANDOAN\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("chandoan") + "\""
            + ",\"BHYT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("BHYT") + "\""
            + ",\"DICHVU\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DICHVU") + "\""
   + "";
        Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, head));

    }
    private void setDefault()
    {
        StringBuilder html = new StringBuilder();
        html.AppendLine("<root>");
        html.AppendLine("<data id=\"tungay\">01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + "</data>");
        html.AppendLine("<data id=\"tugio\">00:00</data>");
        html.AppendLine("<data id=\"denngay\">" + DateTime.Now.ToString("dd/MM/yyyy") + "</data>");
        html.AppendLine("<data id=\"dengio\">23:59</data>");
        html.AppendLine("</root>");
        Response.Clear();
        Response.Write(html);
        return;
    }
    //───────────────────────────────────────────────────────────────────────────────────────  
    private BaoCaoBNDieuTriNoiTru NXTReport = null;
    private void XuatExcel()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string tungay = Request.QueryString["tungay"];
        string tugio = Request.QueryString["tugio"];
        string denngay = Request.QueryString["denngay"];
        string dengio = Request.QueryString["dengio"];
        string tenkhoa = DataAcess.Connect.GetTable("select isnull((select upper(tenphongkhambenh) from phongkhambenh where idphongkhambenh ='"+idkhoa+"'),'')").Rows[0][0].ToString();
        string tungaydenngay = "";
        if (tugio.Equals("00:00") && dengio.Equals("23:59"))
            tungaydenngay = StaticData.TimeDescription(StaticData.CheckDate(tungay), StaticData.CheckDate(denngay));
        else
            tungaydenngay = "Từ ngày " + tungay + " " + tugio + " đến ngày " + denngay + " " + dengio;
        NXTReport = new BaoCaoBNDieuTriNoiTru();
        NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
        NXTReport.strSql = getStingSql();
        NXTReport.TenKhoa = tenkhoa;
        NXTReport.tuNgayDenNgay = tungaydenngay;
        NXTReport.ExportToExcel();
    }
    void NXTReport_AfterExportToExcel()
    {
        Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
    }
}


