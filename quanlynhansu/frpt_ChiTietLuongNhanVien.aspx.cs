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


public partial class frpt_ChiTietLuongNhanVien : Page
{
    private ReportDocument report;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListPhongBan();
            BindListNam();
            BindListNhanVien();
        }
        string dkmenu = "" + "";  if (Request.QueryString["dkmenu"]!=null &&  dkmenu == "")  dkmenu = Request.QueryString["dkmenu"].ToString();
        if (dkmenu == "")     dkmenu = "thuphi";

        
            PlaceHolder1.Controls.Add(LoadControl("uscmenu.ascx"));
            if (Request.QueryString["Thang"] != null && Request.QueryString["Nam"] != null && Request.QueryString["IdNhanVien"].ToString()!=null)
            {
                ddlThang.SelectedValue = Request.QueryString["Thang"].ToString();
                ddlNam.SelectedValue = Request.QueryString["Nam"].ToString();
                ddlNhanVien.SelectedValue = Request.QueryString["IdNhanVien"].ToString();
                
            }
            GetReport();
    }

    private void BindListPhongBan()
    {
        string sql = "select * from phongban ORder by tenphongban";
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
            PhongBanIn = " ad idphongban=" + ddlPhongBan.SelectedValue;
        string sql = "select * from nhanvien inner join hopdong hd on nhanvien.idnhanvien=hd.idnhanvien where nhanvien.status=1 " + PhongBanIn + " order by tennhanvien";
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
+ " select * from " + "\r\n"
+ " (" + "\r\n"
+ " select idchamcong,LoaiCa='Lương làm ca'" + "\r\n"
+ " ,Ngay=convert(varchar,pc.ngaythangnam,103)" + "\r\n"
+ " ,TenCa=clv.tencalamviec" + "\r\n"
+ " ,GioVaoChuan=clv.tugio" + "\r\n"
+ " ,GioRaChuan=clv.dengio" + "\r\n"
+ " ,GioVao=bcc.GioVao" + "\r\n"
+ " ,GioRa=bcc.GioRa" + "\r\n"
+ " ,SoGioLam=bcc.SoGioCong" + "\r\n"
+ " ,HeSo=bcc.HeSoLuong" + "\r\n"
+ " ,LuongMotGio1=bcc.LuongMotGio" + "\r\n"
+ " ,LuongMotGio=convert(int,bcc.LuongMotGio)" + "\r\n"
+ " ,ThanhTien1=bcc.LuongMotGio * bcc.HeSoLuong * bcc.SoGioCong" + "\r\n"
+ " ,ThanhTien=convert(int,bcc.LuongMotGio * bcc.HeSoLuong * bcc.SoGioCong)" + "\r\n"
+ " " + "\r\n"
+ " from bangchamcong bcc inner join phanca pc on pc.idphanca= bcc.idphanca" + "\r\n"
+ " inner join calamviec clv on clv.idcalamviec=pc.idcalamviec" + "\r\n"
+ " where bcc.idnhanvien=" + ddlNhanVien.SelectedValue + " and month(NgayChamCong)="+ddlThang.SelectedValue+" and year(NgayChamCong)="+ddlNam.SelectedValue+" " + "\r\n"
+ " union " + "\r\n"
+ " " + "\r\n"
+ " select idchamcong,LoaiCa='Lương tăng ca'" + "\r\n"
+ " ,Ngay=convert(varchar,tc.ngaytangca,103)" + "\r\n"
+ " ,TenCa=ltc.tenloaitangca" + "\r\n"
+ " ,GioVaoChuan=tc.tugio" + "\r\n"
+ " ,GioRaChuan=tc.dengio" + "\r\n"
+ " ,GioVao=bcc.GioVao" + "\r\n"
+ " ,GioRa=bcc.GioRa" + "\r\n"
+ " ,SoGioLam=bcc.SoGioCong" + "\r\n"
+ " ,HeSo=bcc.HeSoLuong" + "\r\n"
+ " ,LuongMotGio1=bcc.LuongMotGio" + "\r\n"
+ " ,LuongMotGio=convert(int,bcc.LuongMotGio)" + "\r\n"
+ " ,ThanhTien1=bcc.LuongMotGio * bcc.HeSoLuong * bcc.SoGioCong" + "\r\n"
+ " ,ThanhTien=convert(int,bcc.LuongMotGio * bcc.HeSoLuong * bcc.SoGioCong)" + "\r\n"
+ " " + "\r\n"
+ " from bangchamcong bcc inner join chitiettangca cttc on cttc.idtangca= bcc.idtangca and cttc.idnhanvien=bcc.idnhanvien" + "\r\n"
+ " inner join tangca tc on cttc.idtangca=tc.idtangca" + "\r\n"
+ " inner join loaitangca ltc on ltc.idloaitangca=tc.idloaitangca" + "\r\n"
+ " where bcc.idnhanvien=" + ddlNhanVien.SelectedValue + " and month(NgayChamCong)=" + ddlThang.SelectedValue + " and year(NgayChamCong)=" + ddlNam.SelectedValue + " " + "\r\n"
+ " ) as A" + "\r\n"
+ " order by LoaiCa desc" + "\r\n";

       

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
        report.Load(Server.MapPath("report/rpt_ChiTietLuongNhanVien.rpt"));
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
+ " ,LuongCB=hd.mucluongcoban" + "\r\n"
+ " ,GioLam=hd.giolam" + "\r\n"
+ " ,TienBHXH=dbo.[GetTienBHXH_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,TienBHYT=[dbo].[GetTienBHYT_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,TienTTNCN= [dbo].[ThueTNCN_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,TienPhuCapCongCiec=500000" + "\r\n"
+ " ,TienPhuCapTN=400000" + "\r\n"
+ " ,TienThuong=0" + "\r\n"
+ " ,TienPhat=0" + "\r\n"
+ " ,TongLuongThucNhan=convert(int,dbo.GetLuongMotGioNhanVien(nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") * dbo.GetSoGioLamCaNhanVien(nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ")) + " + "\r\n"
+ "  	dbo.GetLuongMotGioNhanVien(nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") * dbo.[GetSoGioLamTangCaNhanVien](nv.idnhanvien," + ddlThang.SelectedValue + "," + ddlNam.SelectedValue + ") " + "\r\n"
+ "  	+ 500000 + 400000 - (dbo.[GetTienBHXH_NhanVien](nv.idnhanvien) + [dbo].[GetTienBHYT_NhanVien](nv.idnhanvien) + [dbo].[ThueTNCN_NhanVien](nv.idnhanvien))" + "\r\n"
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

            report.SetParameterValue("@TienBHXH", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienBHXH"].ToString(), ",", ".", true)+" VNĐ");
            report.SetParameterValue("@TienBHYT", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienBHYT"].ToString(), ",", ".", true) + " VNĐ");
            report.SetParameterValue("@TienTTNCN", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienTTNCN"].ToString(), ",", ".", true) + " VNĐ");
            report.SetParameterValue("@TienPhuCapCongViec", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienPhuCapCongCiec"].ToString(), ",", ".", true) + " VNĐ");
            report.SetParameterValue("@TienPhuCapTN", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienPhuCapTN"].ToString(), ",", ".", true) + " VNĐ");
            report.SetParameterValue("@TienThuong", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienThuong"], ",", ".", true) + " VNĐ");
            report.SetParameterValue("@TienPhat", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TienPhat"], ",", ".", true) + " VNĐ");
            report.SetParameterValue("@TongLuongThucNhan", StaticData.FormatNumberOption(dtLuongNV.Rows[0]["TongLuongThucNhan"].ToString(), ",", ".", true) + " VNĐ");
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
