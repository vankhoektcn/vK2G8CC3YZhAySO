using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BienBangKiemNhap
/// </summary>
public class DsBaoCaoKhambenhnoitru : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TuNgay = "";
    public string DenNgay = "";
    private string idkhoa = "";
    private string TenKhoa = "";
    private string TongBenhNhanMoi = "";
    private string TongBNBH = "";
    private string TongBNThuong = "";
    private string TongBNDichVu = "";
    private string TongBenhAnMoi = "";
    private string BANoiKhoa = "";
    private string BANgoaiKhoa = "";
    private string BASanKhoa = "";
    private string BAPhuKhoa = "";
    private string BANgoaiTruSan = "";
    private string ChuyenPhong = "";
    private string ChuyenVien = "";
    private string ChuyenKhoa = "";
    private string XuatVien = "";
    private string ChoVe = "";
    private string BoVe = "";
    private string TuVong = "";
    private string Chu_sumBHYT = "";

    public DsBaoCaoKhambenhnoitru()
    {
    }
    public DsBaoCaoKhambenhnoitru(string TuNgay, string DenNgay,string idkhoa,string tenkhoa
        , string TongBenhNhanMoi,string TongBNBH,string TongBNThuong,string TongBNDichVu
        ,string TongBenhAnMoi,string BANoiKhoa,string BANgoaiKhoa,string BASanKhoa,string BAPhuKhoa,string BANgoaiTruSan
        , string ChuyenPhong, string ChuyenVien, string ChuyenKhoa, string XuatVien, string ChoVe, string BoVe, string TuVong
        )
    {
        this.TuNgay = TuNgay;
        this.DenNgay = DenNgay;
        this.idkhoa = idkhoa;
        this.TenKhoa = tenkhoa;
        this.TongBenhNhanMoi=TongBenhNhanMoi;
        this.TongBNBH=TongBNBH;
        this.TongBNThuong=TongBNThuong;
        this.TongBNDichVu=TongBNDichVu;
        this.TongBenhAnMoi=TongBenhAnMoi;
        this.BANoiKhoa=BANoiKhoa;
        this.BANgoaiKhoa=BANgoaiKhoa;
        this.BASanKhoa=BASanKhoa;
        this.BAPhuKhoa=BAPhuKhoa;
        this.BANgoaiTruSan=BANgoaiTruSan;
        this.ChuyenPhong=ChuyenPhong;
        this.ChuyenVien=ChuyenVien;
        this.ChuyenKhoa=ChuyenKhoa;
        this.XuatVien=XuatVien;
        this.ChoVe=ChoVe;
        this.BoVe=BoVe;
        this.TuVong=TuVong;
    }

    public override DataTable getViewTable() // bắt buộc
    {
        DataTable dtSource = null;
        string sqlSource = @"select  ROW_NUMBER() OVER (ORDER BY ngaykham) AS STT
,mabenhnhan,tenbenhnhan,NAMSINH=DBO.GetNamSinh(B.NGAYSINH)
,GIOITINH=DBO.GETGIOITINH(B.GIOITINH)
,SoBHYT,diachi,a.ngaykham,
a.sovaovien,KHOAChuyen=p1.TENPHONGKHAMBENH
,case when a.huongdieutri=8 or  a.huongdieutri=1  then h.tenhuongdieutri+'-'+ p2.TENPHONGKHAMBENH
              when a.huongdieutri=4 then isnull((select top 1 tenbenhvien from benhnhanxuatkhoa xk left join benhvien bv on xk.idBVchuyenden=bv.idbenhvien where idchitietdangkykham=a.idchitietdangkykham order by idxuatkhoa desc),'')
    else h.tenhuongdieutri end as KHOADen

 FROM khambenh a left join benhnhan b on b.idbenhnhan=a.idbenhnhan
            left join kb_loaibn g on g.id=b.loai
            left join phongkhambenh p1 on p1.idphongkhambenh=a.idphongkhambenh
            left join phongkhambenh p2 on p2.idphongkhambenh=a.phongkhamchuyenden
            left join kb_huongdieutri h on h.huongdieutriid=a.huongdieutri
where 1=1 and isnull(b.idbenhnhan,0)<>0 
and a.NGAYKHAM>='2012/04/01'  AND a.NGAYKHAM<='2012/04/10' and a.idphongkhambenh=15
and
(
 a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=3),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=4),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=8),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=11),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=12),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=13),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=14),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=16),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=17),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=18),0)
or a.idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=a.idchitietdangkykham and huongdieutri=19),0)
)";
        dtSource = DataAcess.Connect.GetTable(sqlSource);
        return dtSource;
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A11");
    }
    protected override string SetInputFileName()
    {
        return "DsBaoCaoKhambenhnoitru.xls";
    }
    protected override string SetOutputFileName()
    {
        return "DsBaoCaoKhambenhnoitru.xls";
    } 
    protected override System.Collections.Generic.List<string> SetListExcelHidenColumns()
    {
        return base.SetListExcelHidenColumns();
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("D3"));//Khoa
        lst.Add(GetCellIndex("D4"));//Khoảng ngày
        //lst.Add(GetCellIndex("J15"));//Ngày lập

        lst.Add(GetCellIndex("D5"));//loại bênh
        lst.Add(GetCellIndex("D6"));//bệnh án
        lst.Add(GetCellIndex("D7"));//hướng DT
        //lst.Add(GetCellIndex("G17"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        DateTime d = DateTime.Now;
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add("Khoa: "+this.TenKhoa);
        lst.Add((TuNgay == DenNgay ? (string.Format("Ngày {0:dd/MM/yyyy}", TuNgay)) : (string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", TuNgay, DenNgay))));        
        //lst.Add("Ngày " + d.ToString("dd") + " tháng " + d.ToString("MM") + "  năm " + d.ToString("yyyy"));

        lst.Add("Số bệnh nhân mới: "+TongBenhNhanMoi+"  trong đó BH:"+TongBNBH+"  Thường: "+TongBNThuong+" Dịch vụ: "+TongBNDichVu);//loại bệnh
        if(this.idkhoa=="15")
            lst.Add("Số bệnh án mới: "+TongBenhAnMoi+"  nội khoa: "+BANoiKhoa+"  ngoại khoa: "+BANgoaiKhoa);
        else if (this.idkhoa == "3")
            lst.Add("Số bệnh án mới: " + TongBenhAnMoi + "  sản khoa: " + BASanKhoa + "  phụ khoa: " + BAPhuKhoa+"  ngoại trú: "+BANgoaiTruSan);
        else
            lst.Add("Số bệnh án mới: " + TongBenhAnMoi);

        //Hướng ĐT
        lst.Add("Chuyển phòng: "+ChuyenPhong+"  chuyển viện: "+ChuyenVien+"  chuyển khoa: "+ChuyenKhoa+"  xuất viện: "+XuatVien+"  cho về: "+ChoVe+"  bỏ về: "+BoVe+"  tử vong: "+TuVong);
        return lst;
    }
    
    protected override bool SetIsSumByGroupValue()
    {
        return false;
    }
    
}
