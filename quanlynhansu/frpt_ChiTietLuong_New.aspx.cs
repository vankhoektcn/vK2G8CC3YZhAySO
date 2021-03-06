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
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
using System.Text.RegularExpressions;


public partial class frpt_ChiTietLuong_New : Page
{
    private ReportDocument report;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListPhongBan();
            BindListNam();
            BindListNhanVien();
            ddlNam.SelectedValue = DateTime.Now.Year.ToString();
            ddlThang.SelectedValue = DateTime.Now.Month.ToString();
            if (Request.QueryString["Thang"] != null && Request.QueryString["Nam"] != null && Request.QueryString["IdNhanVien"].ToString() != null)
            {
                ddlThang.SelectedValue = Request.QueryString["Thang"].ToString();
                ddlNam.SelectedValue = Request.QueryString["Nam"].ToString();
                ddlNhanVien.SelectedValue = Request.QueryString["IdNhanVien"].ToString();
            }
        }
        string dkmenu = "" + "";  if (Request.QueryString["dkmenu"]!=null &&  dkmenu == "")  dkmenu = Request.QueryString["dkmenu"].ToString();
        if (dkmenu == "")     dkmenu = "thuphi";

        
            PlaceHolder1.Controls.Add(LoadControl("uscmenu.ascx"));
            
            GetReport();
    }

    private void BindListPhongBan()
    {
        string sql = "select * from phongban where status=1 ORder by tenphongban";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlPhongBan, dt, "idphongban", "tenphongban", "------Chọn phòng ban------");
        }
    }
    private void BindListNam()
    {

        for (int i = 2011; i <= StaticData.NamGioiHan; i++)
        {
            ddlNam.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    private void BindListNhanVien()
    {
        string PhongBanIn = "";
        if (ddlPhongBan.SelectedValue != "0")
            PhongBanIn = " and nv.idphongban=" + ddlPhongBan.SelectedValue;
        string sql = @"select nv.idnhanvien,nv.tennhanvien from nhanvien nv
            where nv.status=1
            and nv.idnhanvien in (select hd.idnhanvien from hopdong hd
             where nv.idnhanvien=hd.idnhanvien and hd.status=1) 
            " + PhongBanIn + @"
            order by nv.tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "tennhanvien");
        }
    }

    protected void ddlPhongBan_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindListNhanVien();
    }
    protected void btnLayBaoCao_Click(object sender, EventArgs e)
    {
        GetReport();
    }
    private void GetReport()
    {
        string tuN =ddlThang.SelectedValue;
        string denN =ddlNam.SelectedValue;
        string Mabacsi = "";

        string sql = ""
+ " select round(ROW_NUMBER ( ) OVER(ORDER BY convert(datetime,bcc.ngaycong,103)),0) AS STT" + "\r\n"
+ " ,Ngay=convert(varchar,bcc.ngaycong,103)" + "\r\n"
+ " ,case when isnull(bcc.NgayThuong,0)=1 then 'a' else null end as Thuong " + "\r\n"
+ " ,case when isnull(bcc.NgayTruc,0)=1 then 'a' else null end as Truc" + "\r\n"
+ " ,case when isnull(bcc.PhepKhongLuong,0)=1 then 'a' else null end as PK" + "\r\n"
+ " ,case when isnull(bcc.PhepCoLuong,0)=1 then 'a' else null end as PC" + "\r\n"
+ " ,case when isnull(bcc.LamThemNuaNgay,0)=1 then 'a' else null end as LT" + "\r\n"
+ " ,case when isnull(bcc.LamThemMotNgay,0)=1 then 'a' else null end as LT1" + "\r\n"
+ " ,case when isnull(bcc.NghiOm,0)=1 then 'a' else null end as NghiOm" + "\r\n"
+ " ,case when isnull(bcc.VoKyLuat,0)=1 then 'a' else null end as VoKyLuat" + "\r\n"
+ " ,case when isnull(bcc.NghiBu,0)=1 then 'a' else null end as NghiBu" + "\r\n"
+ " ,case when isnull(bcc.NghiLe,0)=1 then 'a' else null end as NghiLe" + "\r\n"
+ " ,GhiChu=''" + "\r\n"
+ " ,ThanhTien=[dbo].[NS_LuongTheoNgay](bcc.idnhanvien,bcc.ngaycong)" + "\r\n"
+ " ,HeSoLCB=hd.HeSoLCB" + "\r\n"
+ " ,LuongMotNgay=[dbo].[LuongMotNgayNhanVien](bcc.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " from BangChamCongTheoNgay bcc left join hopdong hd on bcc.idnhanvien= hd.idnhanvien where 1=1 " + "\r\n";
        if (ddlNhanVien.SelectedValue != "0")
            sql += " and bcc.idnhanvien=" + ddlNhanVien.SelectedValue + "\r\n";
        sql += " and month(ngaycong)="+ddlThang.SelectedValue+" and year(ngaycong)="+ddlNam.SelectedValue+"";
       

        //DataTable dtTieuDeCty = Process.TieuDeCty.dtGetAll();
        string TenCty1 = "";
        string TenCty2 = "";
        //if (dtTieuDeCty != null && dtTieuDeCty.Rows.Count != 0)
        //{
            string sTemp = "Minh Đức-Phòng nhân sự";// dtTieuDeCty.Rows[dtTieuDeCty.Rows.Count - 1][Profess.TBLS.tbl_TieuDeCty.Ten_Cty.ToString()].ToString();
            string[] arrSTemp = sTemp.Split('-');
            if (arrSTemp.Length > 1)
                TenCty1 = "";// arrSTemp[0];
            //TenCty2 = arrSTem//p[1];

        //}


        DataTable dtSource = DataAcess.Connect.GetTable(sql);
        report = new ReportDocument();
        report.Load(Server.MapPath("report/ChiTietLuong_New.rpt"));
        #region SubReport
        string sqlSub = ""
+ " select distinct idnhanvien,ngay=convert(varchar,ngaylamthem,103)" + "\r\n"
+ " ,ChuoiGio=dbo.NS_ChuoiGIOLAMTHEM_TheoNgay(idnhanvien,ngaylamthem)" + "\r\n"
+ " ,SoGio=[dbo].[NS_SoGioLamNgoaiGio_MotNgay](idnhanvien,ngaylamthem)" + "\r\n"
+ " ,Column3=[dbo].[NS_CongMotGio_NgoaiGio](idnhanvien,month(ngaylamthem),year(ngaylamthem))" + "\r\n"
+ " ,TongTienNgay=[dbo].[NS_TongTienLamNgoaiGio_MotNgay](idnhanvien,ngaylamthem)" + "\r\n"
+ " ,TongGioThang=[dbo].[NS_SoGioLamNgoaiGio](idnhanvien,month(ngaylamthem),year(ngaylamthem))" + "\r\n"
+ " from lamthemgio where idnhanvien="+ddlNhanVien.SelectedValue+" and month(ngaylamthem)="+ddlThang.SelectedValue+" and year(ngaylamthem)="+ddlNam.SelectedValue+"" + "\r\n";
        DataTable dtSourceSub = DataAcess.Connect.GetTable(sqlSub);

        report.OpenSubreport("ChiTietLamNgoaiGio.rpt").SetDataSource(dtSourceSub);
        //report.OpenSubreport("ChiTietLamNgoaiGio.rpt").ReportDefinition.SetParameterValue("TongSoGio", dtSourceSub.Rows[0]["TongGioThang"].ToString());
        if (dtSourceSub.Rows.Count >0)
        ((TextObject)report.OpenSubreport("ChiTietLamNgoaiGio.rpt").ReportDefinition.ReportObjects["txtTongSoGio"]).Text = dtSourceSub.Rows[0]["TongGioThang"].ToString();
        #endregion
        
        report.SetDataSource(dtSource);
        R.ReportSource = report;
        ////((TextObject)report.ReportDefinition.ReportObjects["txtThuQuy"]).Text =  StaticData.NguoiThuQuy;
        ////((TextObject)report.ReportDefinition.ReportObjects["txtPhuTrachTT"]).Text = StaticData.NguoiPhuTrachTT;
        string TenNguoiDung = SysParameter.UserLogin.FullName(this);
        //Lấy thông tin Nhân viên,lương nhân viên.
        string sqlNV = ""
+ " select tennhanvien,nv.idnhanvien" + "\r\n"
+ " ,manhanvien" + "\r\n"
+ " ,gioitinh" + "\r\n"
+ " ,ngaysinh=convert(varchar,ngaysinh,103)" + "\r\n"
+ " ,ngayvaolam=convert(varchar,hd.ngaybatdau,103)" + "\r\n"
+ " ,LuongCB=hd.LuongCB" + "\r\n"
+ " ,GioLam=hd.HeSoLCB" + "\r\n"
+ " ,TienBHXH=dbo.[GetTienBHXH_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,TienBHYT=[dbo].[GetTienBHYT_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,TienBHTN=[dbo].[GetTienBHTN_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,TienTTNCN= [dbo].[ThueTNCN_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,TienPhuCapDocHai=[dbo].[NS_GetPhuCapDocHai_TN](nv.idnhanvien,"+ddlThang.SelectedValue+","+ddlThang.SelectedValue+",1)" + "\r\n"
+ " ,TienPhuCapTN=[dbo].[NS_GetPhuCapDocHai_TN](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlThang.SelectedValue + ",2)" + "\r\n"
+ " ,TienPhuCapHienVat=[dbo].[NS_GetPhuCapHienVat](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TienPhuCapBoiDuong=[dbo].[NS_GetPhuCapBoiDuongSanPham](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,QuyTienLuong=[dbo].[NS_GetQuyTienLuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"

+ " ,TienThuong=0" + "\r\n"
+ " ,TienPhat=0" + "\r\n"
+ " ,TongThuong=[dbo].[GetSoNgayNhanVienLamThuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongTruc=[dbo].[GetSoNgayNhanVienTruc](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongPK=[dbo].[GetSoNgayNhanVienPhepKhongLuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongPC=[dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongLT=[dbo].[GetSoNgayNhanVienLamThemNuaNgay](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongLT1=[dbo].[GetSoNgayNhanVienLamThemMotNgay](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongNghiOm=[dbo].[GetSoNgayNhanVienNghiOm](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongVoKyLuat=[dbo].[GetSoNgayNhanVienVoKyLuat](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongNghiBu=[dbo].[GetSoNgayNhanVienNghiBu](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongNghiLe=[dbo].[GetSoNgayNhanVienNghiLe](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ "  ,TongTienNgoaiGio=[dbo].[NS_TongTienLamNgoaiGio] (nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ "  ,PCK=[dbo].[NS_GetPhuCapKhac] (nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " ,TongTienLam=[dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")*([dbo].[GetSoNgayNhanVienLamThuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")+[dbo].[GetSoNgayNhanVienNghiLe](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")+[dbo].[NS_GetSoNgayTrucTinhThuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") + [dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + "))" + "\r\n"
//+ " + [dbo].[GetSoNgayNhanVienTruc](nv.idnhanvien," + ddlThang.SelectedValue + "," +  ddlNam.SelectedValue + ")* isnull((select top 1 GiaTriMuc from ChiTietPhuCap_NhanVien where idnhanvien=nv.idnhanvien and idphucap=4),0)" + "\r\n"
    + " + [dbo].[GetSoTienCaTruc](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")"
    + " - [dbo].[NS_GetSoNgayTrucTinhThuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")"
    + " * (select isnull( (select top 1 ct.tientruc from bangchamcongtheongay cc "
+ "	inner join catruc  ct on ct.idcatruc=cc.idcatruc where idnhanvien=nv.idnhanvien ),0))"
//
//+ " + nv.idnhanvien * ([dbo].[GetSoNgayNhanVienLamThemNuaNgay](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") +[dbo].[GetSoNgayNhanVienLamThemMotNgay](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + "))" + "\r\n"
    + " +( [dbo].[GetLuongNuaNgayNhanVien] (nv.idnhanvien) * [dbo].[GetSoNgayNhanVienLamThemNuaNgay](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") )+([dbo].[GetLuongMotNgayNhanVien] (nv.idnhanvien) * [dbo].[GetSoNgayNhanVienLamThemMotNgay](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + "))" + "\r\n"
            //
//+ " - [dbo].[GetSoNgayNhanVienVoKyLuat](nv.idnhanvien," + ddlThang.SelectedValue + "," +  ddlNam.SelectedValue + ")* [dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + ddlThang.SelectedValue + "," +  ddlNam.SelectedValue + ") " + "\r\n"
+ " ,TongLuongThucNhan=[dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")*([dbo].[GetSoNgayNhanVienLamThuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")+[dbo].[GetSoNgayNhanVienNghiLe](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")+[dbo].[NS_GetSoNgayTrucTinhThuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") + [dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + "))" + "\r\n"
//+ " + [dbo].[GetSoNgayNhanVienTruc](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")* isnull((select top 1 GiaTriMuc from ChiTietPhuCap_NhanVien where idnhanvien=nv.idnhanvien and idphucap=4),0)" + "\r\n"
+ " + [dbo].[GetSoTienCaTruc](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")"
+ " - [dbo].[NS_GetSoNgayTrucTinhThuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")"
+ " * (select isnull( (select top 1 ct.tientruc from bangchamcongtheongay cc "
+ "	inner join catruc  ct on ct.idcatruc=cc.idcatruc where idnhanvien=nv.idnhanvien ),0))"
//
+ " +( [dbo].[GetLuongNuaNgayNhanVien] (nv.idnhanvien) * [dbo].[GetSoNgayNhanVienLamThemNuaNgay](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") )+([dbo].[GetLuongMotNgayNhanVien] (nv.idnhanvien) * [dbo].[GetSoNgayNhanVienLamThemMotNgay](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + "))" + "\r\n"
+ " + [dbo].[NS_TongTienLamNgoaiGio] (nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"

+ " + [dbo].[NS_GetPhuCapDocHai_TN](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ",2)" + "\r\n"
+ " + [dbo].[NS_GetPhuCapDocHai_TN](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ",1)" + "\r\n"
+ " + [dbo].[NS_GetPhuCapHienVat](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " + [dbo].[NS_GetPhuCapBoiDuongSanPham](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " + [dbo].[NS_GetQuyTienLuong](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
+ " + [dbo].[NS_GetPhuCapKhac](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")" + "\r\n"
//+ " - [dbo].[GetSoNgayNhanVienVoKyLuat](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")* [dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") " + "\r\n"
+ " - (dbo.[GetTienBHXH_NhanVien](nv.idnhanvien) + dbo.[GetTienBHTN_NhanVien](nv.idnhanvien) + [dbo].[GetTienBHYT_NhanVien](nv.idnhanvien) + [dbo].[ThueTNCN_NhanVien](nv.idnhanvien))" + "\r\n"
+ " from nhanvien nv inner join hopdong hd on hd.idnhanvien=nv.idnhanvien" + "\r\n"
+ " where 1=1 and nv.idnhanvien="+ddlNhanVien.SelectedValue+"" + "\r\n"
+ " " + "\r\n";
        DataTable dtLuongNV = DataAcess.Connect.GetTable(sqlNV);
        clsDocSo.clsDocSo docSo = new clsDocSo.clsDocSo();
        
        if (dtLuongNV.Rows.Count > 0)
        {
            report.SetParameterValue("@ThangNam", "Tháng " + ddlThang.SelectedValue + "/" + ddlNam.SelectedValue);
            report.SetParameterValue("@TenNhanVien", dtLuongNV.Rows[0]["tennhanvien"].ToString());
            report.SetParameterValue("@MaNhanVien", dtLuongNV.Rows[0]["manhanvien"].ToString());
            //string Gioi = "";
            report.SetParameterValue("@GioiTinh", dtLuongNV.Rows[0]["gioitinh"].ToString()=="1" ? "Nữ" : "Nam");
            report.SetParameterValue("@NgaySinh", dtLuongNV.Rows[0]["ngaysinh"].ToString());
            report.SetParameterValue("@NgayVaoLam", dtLuongNV.Rows[0]["ngayvaolam"].ToString());
            report.SetParameterValue("@LuongCB/Gio", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["LuongCB"].ToString(), ",", ".", false) + "VNĐ /" + dtLuongNV.Rows[0]["GioLam"].ToString());

            report.SetParameterValue("TongThuong", dtLuongNV.Rows[0]["TongThuong"].ToString());
            report.SetParameterValue("TongTruc", dtLuongNV.Rows[0]["TongTruc"].ToString());
            report.SetParameterValue("TongPK", dtLuongNV.Rows[0]["TongPK"].ToString());
            report.SetParameterValue("TongPC", dtLuongNV.Rows[0]["TongPC"].ToString());
            report.SetParameterValue("TongLT", dtLuongNV.Rows[0]["TongLT"].ToString());
            report.SetParameterValue("TongLT1", dtLuongNV.Rows[0]["TongLt1"].ToString());
            report.SetParameterValue("TongNghiOm", dtLuongNV.Rows[0]["TongNghiOm"].ToString());
            report.SetParameterValue("TongVoKyLuat", dtLuongNV.Rows[0]["TongVoKyLuat"].ToString());
            report.SetParameterValue("TongNghiBu", dtLuongNV.Rows[0]["TongNghiBu"].ToString());
            report.SetParameterValue("TongNghiLe", dtLuongNV.Rows[0]["TongNghiLe"].ToString());
            report.SetParameterValue("@TongTienLam", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TongTienLam"].ToString(), ",", ".", false));

            report.SetParameterValue("@TienBHXH", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienBHXH"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienBHYT", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienBHYT"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienBHTN", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienBHTN"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienTTNCN", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienTTNCN"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienPhuCapDocHai", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienPhuCapDocHai"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienPhuCapHienVat", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienPhuCapHienVat"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienPhuCapBoiDuong", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienPhuCapBoiDuong"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienPhuCapTN", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienPhuCapTN"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienQuyTienLuong", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["QuyTienLuong"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@PCK", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["PCK"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienThuong", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienThuong"], ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TienPhat", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienPhat"], ",", ".", false) + " VNĐ");
            report.SetParameterValue("@TongLuongThucNhan", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TongLuongThucNhan"].ToString(), ",", ".", false) + " VNĐ");
            report.SetParameterValue("TienChu", docSo.ChuyenSo(dtLuongNV.Rows[0]["TongLuongThucNhan"].ToString()));
        }
        this.R.DataBind();
    }


    protected void R_Unload(object sender, EventArgs e)
    {
        if (report != null)
        {
            report.Dispose();
            report = null;
            R.Dispose();
            report = null;
            GC.Collect();
        }
    }
    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(R_Unload);
    }
    #endregion
}
