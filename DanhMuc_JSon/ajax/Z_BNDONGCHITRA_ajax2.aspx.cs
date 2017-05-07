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

public partial class Z_BNDONGCHITRA_ajax : System.Web.UI.Page
{
    protected DataProcess s_Z_BANGKECHIPHI_VIEW()
    {
        DataProcess Z_BANGKECHIPHI_VIEW = new DataProcess("Z_BANGKECHIPHI_VIEW");
        Z_BANGKECHIPHI_VIEW.data("IDBANGKE", Request.QueryString["idkhoachinh"]);
        Z_BANGKECHIPHI_VIEW.data("Id", Request.QueryString["Id"]);
        Z_BANGKECHIPHI_VIEW.data("IdBenhNhan", Request.QueryString["IdBenhNhan"]);
        Z_BANGKECHIPHI_VIEW.data("mabenhnhan", Request.QueryString["mabenhnhan"]);
        Z_BANGKECHIPHI_VIEW.data("tenbenhnhan", Request.QueryString["tenbenhnhan"]);
        Z_BANGKECHIPHI_VIEW.data("ngaysinh", Request.QueryString["ngaysinh"]);
        Z_BANGKECHIPHI_VIEW.data("GIOITINH", Request.QueryString["GIOITINH"]);
        Z_BANGKECHIPHI_VIEW.data("sobhyt", Request.QueryString["sobhyt"]);
        Z_BANGKECHIPHI_VIEW.data("DungTuyen", Request.QueryString["DungTuyen"]);
        Z_BANGKECHIPHI_VIEW.data("NgayTinhBH", Request.QueryString["NgayTinhBH"]);
        Z_BANGKECHIPHI_VIEW.data("TongSoTien", Request.QueryString["TongSoTien"]);
        Z_BANGKECHIPHI_VIEW.data("BHTra", Request.QueryString["BHTra"]);
        Z_BANGKECHIPHI_VIEW.data("BNPhaiTra", Request.QueryString["BNPhaiTra"]);
        Z_BANGKECHIPHI_VIEW.data("BNDaTraChenhLechBHYT", Request.QueryString["BNDaTraChenhLechBHYT"]);
        Z_BANGKECHIPHI_VIEW.data("BNPhaiTraChenhLechBHYT", Request.QueryString["BNPhaiTraChenhLechBHYT"]);
        Z_BANGKECHIPHI_VIEW.data("IsNoiTru", Request.QueryString["IsNoiTru"]);
        Z_BANGKECHIPHI_VIEW.data("TenBV", Request.QueryString["TenBV"]);
        Z_BANGKECHIPHI_VIEW.data("IDCHITIETDANGKYKHAM", Request.QueryString["IDCHITIETDANGKYKHAM"]);
        return Z_BANGKECHIPHI_VIEW;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "TimKiem": TimKiem(); break;
        }
    }
    private void TimKiem()
    {
        bool search = true;// Userlogin_new.HavePermision(this, "Z_BNDONGCHITRA_Search");
        if (search)
        {
            string IsBNBH = Request.QueryString["IsBNBH"];
            string IsBNDV = Request.QueryString["IsBNDV"];
            string TuNgay = Request.QueryString["tungay"];
            string DenNgay = Request.QueryString["denngay"];
            string sTenBenhnhan = Request.QueryString["TENBENHNHAN"];
            string MaBenhNhan = Request.QueryString["MABENHNHAN"];
            TuNgay = StaticData.CheckDate(TuNgay) + " 00:00:00";
            DenNgay = StaticData.CheckDate(DenNgay) + " 23:59:59";
            string USERID = SysParameter.UserLogin.UserID(this);
            if (USERID == null || USERID == "") USERID = "0";
            string sqlselect = @"DELETE FROM Z_BANGKECHIPHI_VIEW WHERE USERID=" + USERID + @"
                                INSERT INTO Z_BANGKECHIPHI_VIEW
                                select A.Id 
		                               , A.IdBenhNhan
		                                ,mabenhnhan
		                                ,tenbenhnhan
		                                ,ngaysinh
		                                ,dbo.GetGioiTinh(B.gioitinh) AS GIOITINH 
		                                ,A.sobhyt
		                                ,Case A.DungTuyen when 'Y' then N'Đ.Tuyến' else N'Tr.Tuyến' end as DungTuyen
                                        ,NgayTinhBH =NGAYTINHBH
		                                , TongSoTien= TONGTIENDV 
                                        ,BHTra
		                                ,BNPhaiTra= TongTienBNPT 
                                        ,BNDaTraChenhLechBHYT= TongTienBNDaTra 
                                        ,BNPhaiTraChenhLechBHYT=TongTienBNPTConLai
                                        ,IsNoiTru=ISNULL(A.ISNOITRU,0)
                                        ,TenBV=(case when isnull(a.isnoitru,0) =1 then N'BV02' else N'BV01' end)
                                        ,IDCHITIETDANGKYKHAM=ISNULL(A.IDCHITIETDANGKYKHAM_LAST,0)
                                        ,USERID=" + USERID + @"
                                from HS_BenhNhanBHDongTien A
                                LEFT JOIN BENHNHAN B ON A.IdBenhNhan=B.idbenhnhan
                                WHERE ISNULL( A.ISBHYT,0)=" + (IsBNBH == "1" ? "1" : "0") + @" 
		                                 AND ( (NgayTinhBH>='" + TuNgay + @"' AND NgayTinhBH<='" + DenNgay + @"' ) OR (NgayTinhBH_THUC>='" + TuNgay + @"' AND NgayTinhBH_THUC<='" + DenNgay + @"'))
                                        --AND isnull( A.idkhambenh_last,0) <>0
                                 ";
            if (sTenBenhnhan != null && sTenBenhnhan != "")
                sqlselect += "AND (B.TenBenhNhan LIKE N'%" + sTenBenhnhan + @"%' OR B.NAMENOTSIGN LIKE N'%" + sTenBenhnhan + "%')";
            if (MaBenhNhan != null && MaBenhNhan != "")
                sqlselect += " AND B.MABENHNHAN='" + MaBenhNhan + "'";
            DataAcess.Connect.ExecSQL(sqlselect);
            DataProcess process = s_Z_BANGKECHIPHI_VIEW();
            process.data("USERID", USERID);
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.NgayTinhBH),T.*
                               from Z_BANGKECHIPHI_VIEW T
             where " + process.sWhere());
            Response.Clear();Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}


