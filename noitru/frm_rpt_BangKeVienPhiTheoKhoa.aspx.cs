using System;
using System.Data;
using System.Configuration;
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

public partial class frm_rpt_BangKeVienPhiTheoKhoa : System.Web.UI.Page
{
    private ReportDocument report;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetReport();
    }
    private void GetReport()
    {
        #region Tạo Data Source
        string idchitietdangkykham = Request.QueryString["idchitietdangkykham"].ToString();
        DataTable dtkb = DataAcess.Connect.GetTable("select top 1 kb.*,bn.mabenhnhan from khambenh kb left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan where idchitietdangkykham="+idchitietdangkykham);
        string sqlSelect = @"select * 
,DieuDuongTruongKhoa=isnull((select nv.tennhanvien from nhanvien nv left join chucvu cv on nv.idchucvu=cv.idchucvu left join phongban pb on pb.idphongban =nv.idphongban
            where cv.machucvu like N'DDTK' and pb.tenphongban =abc.khoaGroup),N'')
,TongChiPhiKhoa=[dbo].[NVK_TongChiPhi_TheoKhoa](abc.idchitietdangkykham,abc.idkhoa)
,TienHoanLaiKhoa=[dbo].[NVK_TienHoanTra_TheoKhoa](abc.idchitietdangkykham,abc.idkhoa)
from (select *,chungtu=null,ngay=null,khoaGroup=isnull((select tenphongkhambenh from phongkhambenh where idphongkhambenh =idkhoa),'')from DBO.[NVK_Mau02_TheoKhoa](" + idchitietdangkykham + @") where noidung is not null
) as abc order by khoaGroup,stt
";
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        ReportDocument report = new ReportDocument();
        report.Load(Server.MapPath("RPT_tonghopthanhtoanVP.rpt"));
        #endregion

        DataSet ds = new DataSet();
        #region ma vach
        string mabenhnhan = dtkb.Rows[0]["mabenhnhan"].ToString();
        iTextSharp.text.pdf.Barcode128 barcode = new iTextSharp.text.pdf.Barcode128();
        barcode.ChecksumText = false;
        barcode.Code = mabenhnhan;
        DataTable dtmavach = new DataTable();
        bool dkPK = (StaticData.GetParameter("sysBarcode") == "1");
        if (dkPK == true)
        {

            DataRow R = dtmavach.NewRow();
            System.Drawing.Image bmp = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
            Byte[] arrByte = (Byte[])System.ComponentModel.TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
            dtmavach.Columns.Add("MaVachKhoe", arrByte.GetType());
            R["MaVachKhoe"] = arrByte;
            dtmavach.Rows.Add(R);
        }
        #endregion
        dtmavach.TableName = "dtmavach";
        ds.Tables.Add(dtmavach);
        dt.TableName = "dtBangKeChiPhiTheoKhoa";
        ds.Tables.Add(dt);
        report.SetDataSource(ds);
        #region Report tiêu đề

        DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
        if (dtTieuDeCty != null)
            report.OpenSubreport("crpt_ThongTinDonVi.rpt").SetDataSource(dtTieuDeCty);
        #endregion
        #region set Parameter
        #region Chuẩn bị tham số
        string sqlBN = @"select 
tenbenhnhan,tuoi=[dbo].[kb_GetTuoi](NgaySinh)
,gioitinh=dbo.GetGioiTinh(gioitinh)
,diachi,dienthoai,chandoan=''
,sonhapvien=isnull((select top 1 sovaovien from khambenh where idchitietdangkykham="+idchitietdangkykham+@" and isnull(sovaovien,'')<>''),'')
,ngaynhapvien=isnull((select top 1 ngaydangky from dangkykham dk left join chitietdangkykham ct on ct.iddangkykham=dk.iddangkykham where idchitietdangkykham=" + idchitietdangkykham + @"),null)
,ngayxuatvien=getdate()
,sohoso=mabenhnhan
from benhnhan where idbenhnhan =" + dtkb.Rows[0]["idbenhnhan"].ToString();
        DataTable dtBN = DataAcess.Connect.GetTable(sqlBN);
        string tenbenhnhan = dtBN.Rows[0]["tenbenhnhan"].ToString();
        string tuoi = dtBN.Rows[0]["tuoi"].ToString();
        string gioitinh = dtBN.Rows[0]["gioitinh"].ToString();
        string diachi = dtBN.Rows[0]["diachi"].ToString();
        string dienthoai = dtBN.Rows[0]["dienthoai"].ToString();
        string chandoan = dtBN.Rows[0]["chandoan"].ToString();
        string sonhapvien = dtBN.Rows[0]["sonhapvien"].ToString();
        string ngaynhapvien = dtBN.Rows[0]["ngaynhapvien"].ToString();
        string ngayxuatvien = dtBN.Rows[0]["ngayxuatvien"].ToString();
        string sohoso = dtBN.Rows[0]["sohoso"].ToString();
        DateTime ngayHT = DateTime.Now;
        string thoigianin = ngayHT.ToString("HH:mm") + " ngày " + ngayHT.ToString("dd/MM/yyyy");
        #endregion
        report.SetParameterValue("@MaVachMaBenhNhan", dtkb.Rows[0]["mabenhnhan"]);
        report.SetParameterValue("tenbenhnhan", tenbenhnhan);
        report.SetParameterValue("tuoi", tuoi);
        report.SetParameterValue("gioitinh", gioitinh);
        report.SetParameterValue("diachi", diachi);
        report.SetParameterValue("dienthoai", dienthoai);
        report.SetParameterValue("chandoan", chandoan);
        report.SetParameterValue("sonhapvien", sonhapvien);
        report.SetParameterValue("ngaynhapvien",ngaynhapvien);
        report.SetParameterValue("ngayxuatvien", ngayxuatvien);
        report.SetParameterValue("thoigianin",thoigianin);
        report.SetParameterValue("sohoso", sohoso);
        thanhtoanvienphi.ReportSource = report;
        thanhtoanvienphi.DataBind();
        #endregion
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
