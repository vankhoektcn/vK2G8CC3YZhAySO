using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using DataAcess;


public partial class frm_rpt_ChiPhiDongChiTra_new : Page
{
    private ReportDocument report;
    public string idphieutt = "";
    public string maphieukham = "";
    public double TOTALPHUTHU = 0;
    public double BNTRA = 0;
    public string nvk_KhoaKham = "";
    public string nvk_idbenhnhan = "";
    public string nvk_idctdkk = "";
    private string nvk_listMaIcd = "";
    private string nvk_listMoTaIcd = "";
    private string SoNgayDieuTri = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        idphieutt = Request.QueryString["idphieutt"];
        if (idphieutt == null || idphieutt == "")
        {
            string idchitietdangkykham = Request.QueryString["idchitietdangkykham"];
            if (idchitietdangkykham == null || idchitietdangkykham == "")
            {
                return;
            }
            string sqlSelect = " SELECT IDBENHBHDONGTIEN FROM CHITIETDANGKYKHAM A INNER JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM WHERE A.IDCHITIETDANGKYKHAM=" + idchitietdangkykham;
            DataTable dtBNBHDT = DataAcess.Connect.GetTable(sqlSelect);
            if (dtBNBHDT == null || dtBNBHDT.Rows.Count == 0 ||dtBNBHDT.Rows[0][0].ToString()=="") return;
            idphieutt = dtBNBHDT.Rows[0][0].ToString();
        }
        Page.Title = "BẢNG KÊ CHI PHÍ ĐỒNG CHI TRA";
        loadReport();

    }
    private DataTable nvk_dtBN(string idbnbhdt, ref string NgayKham)
    {
        DataTable dtBN = StaticData_HS.nvk_thongTimBaohiemBy_idbnbhdt(idbnbhdt);
        if (dtBN == null || dtBN.Rows.Count == 0)
        { StaticData.MsgBox(this, "Không load đươc thông tin phiếu khám !"); return null; }
        maphieukham = dtBN.Rows[0][0].ToString();
        NgayKham = dtBN.Rows[0]["NgayTinhBH_Thuc"].ToString();
        nvk_KhoaKham = dtBN.Rows[0]["TenKhoa"].ToString();
        nvk_idbenhnhan = dtBN.Rows[0]["idbenhnhan"].ToString();
        nvk_idctdkk = dtBN.Rows[0]["idchitietdangkykham"].ToString();
       string NgayNhapVien = dtBN.Rows[0]["NgayNhapVien"].ToString();
       string NgayXuatVien = dtBN.Rows[0]["NgayXuatVien"].ToString();
       DateTime dNgayNhapVien = DateTime.Parse(DateTime.Parse(NgayNhapVien).ToString("yyyy-MM-dd 00:00:00"));
       DateTime dNgayXuatVien = DateTime.Parse(DateTime.Parse(NgayXuatVien).ToString("yyyy-MM-dd 23:59:59"));
       TimeSpan time_SoNgayDT = (TimeSpan)(dNgayXuatVien - dNgayNhapVien);
       SoNgayDieuTri = ((int)time_SoNgayDT.TotalDays).ToString();
        return dtBN;
    }
    private DataTable loadDV()
    {
        string IdBenhNhanBHDongTien = "";
        try
        {
            IdBenhNhanBHDongTien = idphieutt.ToString();
            if (IdBenhNhanBHDongTien == null || IdBenhNhanBHDongTien == "") return null;
        }
        catch
        {
            StaticData.MsgBox(this, "Lỗi bạn chưa chọn bệnh nhân cần thanh toán");
            Response.Write("KHÔNG CÓ DỮ LIỆU");
        }
        string sql = "select * from [dbo].[func_rpt_MauDongChiTra](" + IdBenhNhanBHDongTien + ") order by g,phongkham,SOTT_DV";

        DataTable dt = Connect.GetTable(sql);
        return dt;
    }
 

    private void loadReport()
    {
        DataSet ds = new DataSet();
        report = new ReportDocument();
        const string TenReport = "rpt_ChiPhiDongChiTra_new";
        string sNgayKham = null;
        DataTable dt = loadDV();
        DataTable dtBn = nvk_dtBN(idphieutt.ToString(), ref sNgayKham);
        if (dt == null || dt.Rows.Count == 0)
        { StaticData.MsgBox(this, "Không load đươc thông tin phiếu khám !"); return; }
        report.Load(Server.MapPath("ReportDesign/" + TenReport + ".rpt"));
        dt.TableName = "chiphikhambenh";
        ds.Tables.Add(dt);
        report.SetDataSource(ds);
        #region {TACH CHUOI} - SOBHYT

        if (dtBn.Rows[0]["sobhyt"].ToString() != "")
        {
            string BHYT = dtBn.Rows[0]["sobhyt"].ToString();
            string bhyt1 = "";
            string bhyt2 = "";
            string bhyt3 = "";
            string bhyt4 = "";
            string bhyt5 = "";
            string bhyt6 = "";
            if (BHYT.Length > 10)
            {
                bhyt1 = BHYT.Substring(0, 2);
                bhyt2 = BHYT.Substring(2, 1);
                bhyt3 = BHYT.Substring(3, 2);
                bhyt4 = BHYT.Substring(5, 2);
                bhyt5 = BHYT.Substring(7, 3);
                bhyt6 = BHYT.Substring(10, 5);
            }
            report.SetParameterValue("@bh1", bhyt1);
            report.SetParameterValue("@bh2", bhyt2);
            report.SetParameterValue("@bh3", bhyt3);
            report.SetParameterValue("@bh4", bhyt4);
            report.SetParameterValue("@bh5", bhyt5);
            report.SetParameterValue("@bh6", bhyt6);
        }
        else
        {
            report.SetParameterValue("@bh1", "");
            report.SetParameterValue("@bh2", "");
            report.SetParameterValue("@bh3", "");
            report.SetParameterValue("@bh4", "");
            report.SetParameterValue("@bh5", "");
            report.SetParameterValue("@bh6", "");
        }

        #endregion
        //Khoe
        if (dtBn.Rows[0]["loai"].ToString() != "1" || dtBn.Rows[0]["sobhyt"].ToString().Trim() == "")
        {
            report.SetParameterValue("noidangky", "");
            report.SetParameterValue("manoidangky", "");
            report.SetParameterValue("tungay", "");
            report.SetParameterValue("denngay", "");
            report.SetParameterValue("sobhyt", "");
            report.SetParameterValue("checkbhyt", "");
            report.SetParameterValue("checkthe", "a");
            report.SetParameterValue("checkdungtuyen", "");
            report.SetParameterValue("checktraituyen", "");
        }
        else
        {
            report.SetParameterValue("noidangky", dtBn.Rows[0]["noidangkykcb"].ToString());
            report.SetParameterValue("manoidangky", dtBn.Rows[0]["MaDangKy_KCB_bandau"].ToString());
            report.SetParameterValue("tungay", (dtBn.Rows[0]["ngaybatdau"].ToString()!="" ? DateTime.Parse( dtBn.Rows[0]["ngaybatdau"].ToString()).ToString("dd/MM/yyyy") :""));
            report.SetParameterValue("denngay",(dtBn.Rows[0]["ngayhethan"].ToString()!="" ? DateTime.Parse(dtBn.Rows[0]["ngayhethan"].ToString()).ToString("dd/MM/yyyy") :""));
            report.SetParameterValue("sobhyt", dtBn.Rows[0]["sobhyt"].ToString());
            if (dtBn.Rows[0]["loai"].ToString() == "1")
            {
                report.SetParameterValue("checkbhyt", "a");
                if (dtBn.Rows[0]["capcuu"].ToString() == "a")
                {
                    report.SetParameterValue("checkdungtuyen", "");
                    report.SetParameterValue("checktraituyen", "");
                }
                else
                {
                    if (dtBn.Rows[0]["dungtuyen"].ToString() == "Y")
                    {
                        report.SetParameterValue("checkdungtuyen", "a");
                        report.SetParameterValue("checktraituyen", "");
                    }
                    else
                    {
                        report.SetParameterValue("checkdungtuyen", "");
                        report.SetParameterValue("checktraituyen", "a");
                    }
                }
            }
            else
            {
                report.SetParameterValue("checkbhyt", "");
            }
            report.SetParameterValue("checkthe", "");
        }

        if (dt.Rows[0]["nvk_gioitinh"].ToString().ToLower() == "nam")
        {
            report.SetParameterValue("checknam", "a");
            report.SetParameterValue("checknu", "");
        }
        else
        {
            report.SetParameterValue("checknam", "");
            report.SetParameterValue("checknu", "a");
        }
        if (StaticData.IsCheck( dtBn.Rows[0]["capcuu"].ToString()))
        {
            report.SetParameterValue("checkcapcuu", "a");
        }
        else
        {
            report.SetParameterValue("checkcapcuu", "");
        }

        report.SetParameterValue("songay", SoNgayDieuTri);
        string TenChanDoan = null;
        string MaChanDoan = null;
        StaticData_HS.nvk_setTongHopChanDoan(idphieutt.ToString(),false, ref MaChanDoan, ref TenChanDoan);
        report.SetParameterValue("@nvk_chandoan", TenChanDoan);
        report.SetParameterValue("@nvk_MaIcd", MaChanDoan);
        report.SetParameterValue("namsinh", dtBn.Rows[0]["ngaysinh"]);
        report.SetParameterValue("mabenhnhan", dtBn.Rows[0]["mabenhnhan"]);
        report.SetParameterValue("gioravien", dtBn.Rows[0]["gioravien"]);
        report.SetParameterValue("nguoilap", SysParameter.UserLogin.FullName(this));
        DateTime NgayKham = DateTime.Parse(sNgayKham);
        report.SetParameterValue("ngaythangnam", "Ngày " + NgayKham.ToString("dd") + " tháng " + NgayKham.ToString("MM") + " năm " + NgayKham.ToString("yyyy") + "");
        report.SetParameterValue("mauso", "01/BV");
        report.SetParameterValue("@nvk_khoaKham", nvk_KhoaKham);

        string MaSoHoSo = dt.Rows[0]["MASOHOSO"].ToString();
        report.SetParameterValue("MaSoHoSo", MaSoHoSo);
        string TyLe = "("+ dt.Rows[0]["TyLe"].ToString()+"%)";
        report.SetParameterValue("@TyLe", TyLe);
        chiphikhambenh.ReportSource = report;
        chiphikhambenh.DataBind();
    }

    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(report);
    }

    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(report);
    }
    #region khoi tao va giai phong bo nho

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }

    private void InitialComponent()
    {
        Unload += form_unload;
    }

    #endregion
}