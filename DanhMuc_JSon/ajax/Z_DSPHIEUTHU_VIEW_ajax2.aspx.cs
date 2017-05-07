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

public partial class Z_DSPHIEUTHU_VIEW_ajax : System.Web.UI.Page
{
    protected DataProcess s_Z_DSPHIEUTHU_VIEW()
    {
        DataProcess Z_DSPHIEUTHU_VIEW = new DataProcess("Z_DSPHIEUTHU_VIEW");
        Z_DSPHIEUTHU_VIEW.data("ID", Request.QueryString["idkhoachinh"]);
        Z_DSPHIEUTHU_VIEW.data("MAPHIEU", Request.QueryString["MAPHIEU"]);
        Z_DSPHIEUTHU_VIEW.data("IDBENHNHAN", Request.QueryString["IDBENHNHAN"]);
        Z_DSPHIEUTHU_VIEW.data("mabenhnhan", Request.QueryString["mabenhnhan"]);
        Z_DSPHIEUTHU_VIEW.data("tenbenhnhan", Request.QueryString["tenbenhnhan"]);
        Z_DSPHIEUTHU_VIEW.data("ngaysinh", Request.QueryString["ngaysinh"]);
        Z_DSPHIEUTHU_VIEW.data("TONGTIEN", Request.QueryString["TONGTIEN"]);
        Z_DSPHIEUTHU_VIEW.data("NOIDUNGTHU", Request.QueryString["NOIDUNGTHU"]);
        Z_DSPHIEUTHU_VIEW.data("tennguoithu", Request.QueryString["tennguoithu"]);
        Z_DSPHIEUTHU_VIEW.data("HuyPhieu", Request.QueryString["HuyPhieu"]);
        Z_DSPHIEUTHU_VIEW.data("IsDaHuy", Request.QueryString["IsDaHuy"]);
        Z_DSPHIEUTHU_VIEW.data("LyDoHuy", Request.QueryString["LyDoHuy"]);
        Z_DSPHIEUTHU_VIEW.data("NgayHuy", Request.QueryString["NgayHuy"]);
        Z_DSPHIEUTHU_VIEW.data("TenNguoiHuy", Request.QueryString["TenNguoiHuy"]);
        Z_DSPHIEUTHU_VIEW.data("Khoa", Request.QueryString["Khoa"]);
        Z_DSPHIEUTHU_VIEW.data("USERID", Request.QueryString["USERID"]);
        return Z_DSPHIEUTHU_VIEW;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "TimKiem": TimKiem(); break;
            case "XacNhanHuy": XacNhanHuy(); break;
        }
    }
    private void TimKiem()
    {
        string NgayThuPhi = StaticData.CheckDate(Request.QueryString["ngaythu"]);
        string MaPhieu = Request.QueryString["maphieu"];
        string MaBenhNhan = Request.QueryString["MaBenhNhan"];
        string TenBenhNhan = Request.QueryString["TenBenhNhan"];
        string USERID = SysParameter.UserLogin.UserID(this);
        string strSQL = @"
                            DECLARE @TUNGAY DATETIME
                            DECLARE @DENNGAY DATETIME
                            SET @TUNGAY='" + NgayThuPhi + @"'
                            SET @DENNGAY='" + NgayThuPhi + " 23:59:59" + @"'
                            DELETE FROM Z_DSPHIEUTHU_VIEW WHERE USERID=" + USERID + @"
                            INSERT INTO Z_DSPHIEUTHU_VIEW                            
                            SELECT DISTINCT MAPHIEU
                                    ,IDBENHNHAN
		                            ,MABENHNHAN
		                            ,TENBENHNHAN
		                            ,NGAYSINH
		                            ,TONGTIEN=(SELECT SUM(ABS(TONGTIEN *(100-isnull(chietkhau,0))/100 )) FROM HS_DSDATHU WHERE MAPHIEU=T.MAPHIEU)
		                            ,NOIDUNGTHU=(CASE WHEN ISNULL(NOIDUNGTHU,'')='' AND LOAITHU='PHIKHAM' THEN N'PHÍ KHÁM' ELSE NOIDUNGTHU END)
		                            ,TENNGUOITHU
		                            ,HUYPHIEU=(CASE WHEN ISNULL(ISDAHUY,0)=0 THEN N'HỦY' ELSE N'ĐÃ HỦY' END)
		                            ,ISDAHUY=ISNULL(ISDAHUY,0)
		                            ,LYDOHUY
		                            ,NGAYHUY
		                            ,TENNGUOIHUY
		                            ,KHOA=(SELECT TOP 1 KHOA FROM HS_DSDATHU WHERE MAPHIEU=T.MAPHIEU AND ISNULL(KHOA,'')<>'')
		                            ,USERID=" + USERID + @"
                            FROM HS_DSDATHU T
                            WHERE 1=1";
        if (MaPhieu != null && MaPhieu != "")
        {
            strSQL += " AND MAPHIEU='" + MaPhieu + @"'";
        }
        if (MaBenhNhan != null && MaBenhNhan != "")
            strSQL += " AND MABENHNHAN='" + MaBenhNhan + @"'";
        if (TenBenhNhan != null && TenBenhNhan != "")
            strSQL += " AND (dbo.untiengviet(LOWER(tenbenhnhan)) LIKE N'%" + TenBenhNhan + @"' or tenbenhnhan like N'%" + TenBenhNhan + "')";
        if (NgayThuPhi != null && NgayThuPhi != "")
        {
            strSQL += " AND T.SYSDATE>=@TUNGAY AND T.SYSDATE<=@DENNGAY";
        }
        strSQL += @" ORDER BY MAPHIEU";
        DataAcess.Connect.ExecSQL(strSQL);
        DataProcess process = s_Z_DSPHIEUTHU_VIEW();
        process.EnablePaging = false;
        DataTable table = process.Search(@"select STT=row_number() over (order by T.ID),T.*
                               from Z_DSPHIEUTHU_VIEW T
                             where USERID=" + USERID);
        Response.Clear();
        Response.Write(DataProcess.JSONDataTable_Parameters(table));
    }
    private void XacNhanHuy()
    {
        string maphieu = Request.QueryString["maphieu"];
        string lydo = Request.QueryString["lydo"];
        string tennguoihuy = SysParameter.UserLogin.FullName(this);
        string SQL_AllowHuyPhieu = @"SELECT DBO.zChoPhepHuyPhieu('" + maphieu + "')";
        DataTable dtAllow = DataAcess.Connect.GetTable(SQL_AllowHuyPhieu);
        string alert = "";
        if (dtAllow == null || dtAllow.Rows.Count == 0)
        {
            alert = "Có lỗi khi thao tác hủy";
            Response.Write("0" + "|" + alert);
            return;
        }
        alert = dtAllow.Rows[0][0].ToString();
        if (alert != "")
        {
            Response.Write("1" + "|" + alert);
            return;
        }
        string SQL_HuyPhieu = @" EXEC DBO.zHS_HuyPhieuThu '" + maphieu + "',N'" + lydo + "',N'" + tennguoihuy + "'";
        bool ok = DataAcess.Connect.ExecSQL(SQL_HuyPhieu);
        if (ok)
        {
            Response.Write("-1" + "|" + "Đã hủy thành công" + "|" + tennguoihuy);
            return;
        }
    }
}


