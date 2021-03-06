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
using CrystalDecisions.CrystalReports.Engine;

public partial class rptPhieuKhamSucKhoe : System.Web.UI.Page
{
    ReportDocument R;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Phiếu khám SK";
        string ma = Request.QueryString["MaBN"].ToString();
        string isMau = Request.QueryString["isMau"].ToString();
        if (ma != null && ma != "")
        {
            if (isMau == "1")
            {
                LoadReport(ma);
            }

        }
    }

    private void LoadReport(string ma)
    {
        string sql = @"SELECT tenbenhnhan,b.ngaysinh,diachi, dienthoai, chungminhthu,kct.tencty,kct.diachicty,kct.dienthoaicty,case when gioitinh=0 then 'X' else '' end as nam,case when gioitinh=1 then 'X' else '' end as nu 
  FROM benhnhan b left JOIN KB_CongTy kct ON b.idcongty=kct.idcongty where mabenhnhan='" + ma + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        R = new ReportDocument();
        string TenReport = "ReportDesign/rpt_PhieuKhamSucKhoe";
        R.Load(Server.MapPath(TenReport + ".rpt"));
        R.SetParameterValue("MaBN", ma);
        if (dt.Rows[0]["ngaysinh"].ToString().Length > 4 && dt.Rows[0]["ngaysinh"].ToString().Length == 10)
        {
            string[] a = dt.Rows[0]["ngaysinh"].ToString().Split('/');
            R.SetParameterValue("Ngay", a[0].ToString());
            R.SetParameterValue("Thang", a[1].ToString());
            R.SetParameterValue("Namsinh", a[2].ToString());
        }
        else
        {
            R.SetParameterValue("Ngay", "");
            R.SetParameterValue("Thang", "");
            R.SetParameterValue("Namsinh", dt.Rows[0]["ngaysinh"].ToString());
        }
        R.SetParameterValue("DTCty", dt.Rows[0]["dienthoaicty"].ToString());
        R.SetParameterValue("TenCty", dt.Rows[0]["tencty"].ToString());
        R.SetParameterValue("DiaChiCty", dt.Rows[0]["diachicty"].ToString());
        R.SetParameterValue("Nam", dt.Rows[0]["nam"].ToString());
        R.SetParameterValue("Nu", dt.Rows[0]["nu"].ToString());
        R.SetParameterValue("FullName", dt.Rows[0]["tenbenhnhan"].ToString());
        R.SetParameterValue("DiaChiBN", dt.Rows[0]["diachi"].ToString());
        R.SetParameterValue("CMND", dt.Rows[0]["chungminhthu"].ToString());
        R.SetParameterValue("DTBN", dt.Rows[0]["dienthoai"].ToString());
        //R.SetParameterValue("@GiamDoc", "Nguyễn Văn Tâm");
        #region load Khám Lâm Sàn update thêm nên viết thêm Query 
        string strsql = @" select s.chieucao, s.cannang, s.huyetap1, s.huyetap2, s.vongnguc, s.BMI, s.mach, s.nhietdo, s.nhiptho, s.NgoaiDaLieu, s.MatTrai, s.MatPhai 
                        from sinhhieu s INNER JOIN benhnhan b ON s.idbenhnhan= b.idbenhnhan where b.mabenhnhan ='" + ma + "' ORDER BY idsinhhieu DESC  ";
        DataTable dtSUB = DataAcess.Connect.GetTable(strsql);
        if (dtSUB.Rows.Count > 0)
        {
            R.SetParameterValue("ChieuCao", dtSUB.Rows[0]["chieucao"].ToString());
            R.SetParameterValue("CanNang", dtSUB.Rows[0]["cannang"].ToString());
            R.SetParameterValue("VongNguc", dtSUB.Rows[0]["vongnguc"].ToString());
            R.SetParameterValue("ChisoBMI", dtSUB.Rows[0]["BMI"].ToString());
            R.SetParameterValue("Mach", dtSUB.Rows[0]["mach"].ToString());
            R.SetParameterValue("NhietDo", dtSUB.Rows[0]["nhietdo"].ToString());
            R.SetParameterValue("NhipTho", dtSUB.Rows[0]["nhiptho"].ToString());
            R.SetParameterValue("HuyetAp", dtSUB.Rows[0]["huyetap1"].ToString());
            R.SetParameterValue("HuyetAp1", dtSUB.Rows[0]["huyetap2"].ToString());
            R.SetParameterValue("DaLieu", dtSUB.Rows[0]["NgoaiDaLieu"].ToString());
            R.SetParameterValue("MatTrai", dtSUB.Rows[0]["MatTrai"].ToString());
            R.SetParameterValue("MatPhai", dtSUB.Rows[0]["MatPhai"].ToString());
        }
        else
        {
            R.SetParameterValue("ChieuCao", "");
            R.SetParameterValue("CanNang", "");
            R.SetParameterValue("VongNguc", "");
            R.SetParameterValue("ChisoBMI", "");
            R.SetParameterValue("Mach", "");
            R.SetParameterValue("NhietDo", "");
            R.SetParameterValue("NhipTho", "");
            R.SetParameterValue("HuyetAp", "");
            R.SetParameterValue("HuyetAp1", "");
            R.SetParameterValue("DaLieu", "");
            R.SetParameterValue("MatTrai", "");
            R.SetParameterValue("MatPhai", "");
        }
        #endregion
        #region  Load kham bẹnh update thêm nên viết thêm Query
        string strsqlKhambenh = "";
        strsqlKhambenh += "select dando=K.dandoksk, k.Timmach, k.Tieuhoa, k.Hohap, k.ThanTietNieuSinhDuc, k.Thankinh, k.CoxuongkhopCotsong, k.Dalieu,";
        strsqlKhambenh += " k.Mattrai, k.Matphai, k.Mattraideokinh, k.Matphaideokinh, k.Taitrai, k.Taiphai, k.Taitraithitham, ";
        strsqlKhambenh += " k.Taiphaithitham, k.Mui, k.Hong, k.RHM, k.klspk, k.ketluankhammat, k.ketluantmh, ";
        strsqlKhambenh += " case when k.LoaiSK=1 then 'a' else '' end as Loai1,";
        strsqlKhambenh += " case when k.LoaiSK=2 then 'a' else '' end as Loai2,";
        strsqlKhambenh += " case when k.LoaiSK=3 then 'a' else '' end as Loai3,";
        strsqlKhambenh += " case when k.LoaiSK=4 then 'a' else '' end as Loai4,";
        strsqlKhambenh += " case when k.LoaiSK=5 then 'a' else '' end as Loai5 ";
        strsqlKhambenh += @",isxnmau =case when isxnmau=1 then 'a' else '' end
                    ,isxnnt	=case when isxnnt=1 then 'a' else '' end
                    ,xnk =case when xnk=1 then 'a' else '' end
                    ,xqp =case when xqp=1 then 'a' else '' end
                    ,sab =case when sab=1 then 'a' else '' end
                    ,clsk =case when clsk=1 then 'a' else '' end
                    ,isKhoeManh =case when isnull(isBenh,0)=0 then 'a' else '' end
                    ,isBenh =case when isBenh=1 then 'a' else '' end
                    ,TenBenhM 
                    ,IsDuSucKhoe =case when isnull(IsKoDuSucKhoe,0)=0 then 'a' else '' end
                    ,IsKoDuSucKhoe =case when IsKoDuSucKhoe=1 then 'a' else '' end
                    ,tencongviec
                    ,BSKetLuan
                    ,HuongGiaiQ 
                    ,isxnmau_text
                    ,isxnnt_text
                    ,xnk_text
                    ,xqp_text
                    ,sab_text
                    ,clsk_text 
                    ";
        strsqlKhambenh += " from benhnhan b left JOIN khamsuckhoe k ON b.idbenhnhan =k.idbenhnhan where b.mabenhnhan ='" + ma + "' ORDER BY idkhambenh DESC"; ;
        DataTable dtkhambenh = DataAcess.Connect.GetTable(strsqlKhambenh);
        if (dtkhambenh.Rows.Count > 0)
        {
            R.SetParameterValue("Loai1", dtkhambenh.Rows[0]["Loai1"].ToString());
            R.SetParameterValue("Loai2", dtkhambenh.Rows[0]["Loai2"].ToString());
            R.SetParameterValue("Loai3", dtkhambenh.Rows[0]["Loai3"].ToString());
            R.SetParameterValue("Loai4", dtkhambenh.Rows[0]["Loai4"].ToString());
            R.SetParameterValue("Loai5", dtkhambenh.Rows[0]["Loai5"].ToString());
            R.SetParameterValue("DanDo", dtkhambenh.Rows[0]["dando"].ToString());
            R.SetParameterValue("Timmach", dtkhambenh.Rows[0]["Timmach"].ToString());
            R.SetParameterValue("Tieuhoa", dtkhambenh.Rows[0]["Tieuhoa"].ToString());
            R.SetParameterValue("Hohap", dtkhambenh.Rows[0]["Hohap"].ToString());
            R.SetParameterValue("ThanTieuLieuSinhDuc", dtkhambenh.Rows[0]["ThanTietNieuSinhDuc"].ToString());
            R.SetParameterValue("Thankinh", dtkhambenh.Rows[0]["Thankinh"].ToString());
            R.SetParameterValue("CoxuongkhopCotsong", dtkhambenh.Rows[0]["CoxuongkhopCotsong"].ToString());
            R.SetParameterValue("KQDalieu", dtkhambenh.Rows[0]["Dalieu"].ToString());
            R.SetParameterValue("KLMattrai", dtkhambenh.Rows[0]["Mattrai"].ToString());
            R.SetParameterValue("KLMatphai", dtkhambenh.Rows[0]["Matphai"].ToString());
            R.SetParameterValue("Mattraideokinh", dtkhambenh.Rows[0]["Mattraideokinh"].ToString());
            R.SetParameterValue("Matphaideokinh", dtkhambenh.Rows[0]["Matphaideokinh"].ToString());
            R.SetParameterValue("Taitrai", dtkhambenh.Rows[0]["Taitrai"].ToString());
            R.SetParameterValue("Taiphai", dtkhambenh.Rows[0]["Taiphai"].ToString());
            R.SetParameterValue("Taitraithitham", dtkhambenh.Rows[0]["Taitraithitham"].ToString());
            R.SetParameterValue("Taiphaithitham", dtkhambenh.Rows[0]["Taiphaithitham"].ToString());
            R.SetParameterValue("Mui", dtkhambenh.Rows[0]["Mui"].ToString());
            R.SetParameterValue("Hong", dtkhambenh.Rows[0]["Hong"].ToString());
            R.SetParameterValue("klspk", dtkhambenh.Rows[0]["klspk"].ToString());
            R.SetParameterValue("ketluankhammat", dtkhambenh.Rows[0]["ketluankhammat"].ToString());
            R.SetParameterValue("ketluantmh", dtkhambenh.Rows[0]["ketluantmh"].ToString());
            R.SetParameterValue("RHM", dtkhambenh.Rows[0]["RHM"].ToString());

            R.SetParameterValue("@xnm", dtkhambenh.Rows[0]["isxnmau"].ToString());
            R.SetParameterValue("@xnnt", dtkhambenh.Rows[0]["isxnnt"].ToString());
            R.SetParameterValue("@xnk", dtkhambenh.Rows[0]["xnk"].ToString());
            R.SetParameterValue("@xqp", dtkhambenh.Rows[0]["xqp"].ToString());
            R.SetParameterValue("@sab", dtkhambenh.Rows[0]["sab"].ToString());
            R.SetParameterValue("@clskhac", dtkhambenh.Rows[0]["clsk"].ToString());
            R.SetParameterValue("@KhoeManh", dtkhambenh.Rows[0]["isKhoeManh"].ToString());
            R.SetParameterValue("@MacBenh", dtkhambenh.Rows[0]["isBenh"].ToString());
            R.SetParameterValue("@TenBenh", "                                       " + dtkhambenh.Rows[0]["TenBenhM"].ToString());
            R.SetParameterValue("@DuSucKhoe", dtkhambenh.Rows[0]["IsDuSucKhoe"].ToString());
            R.SetParameterValue("@koDuSK", dtkhambenh.Rows[0]["IsKoDuSucKhoe"].ToString());
            R.SetParameterValue("@TenCongViec", dtkhambenh.Rows[0]["tencongviec"].ToString());
            //R.SetParameterValue("@BacSiKL", dtkhambenh.Rows[0]["BSKetLuan"].ToString());
            R.SetParameterValue("DanDo", dtkhambenh.Rows[0]["HuongGiaiQ"].ToString());

            R.SetParameterValue("@isxnmau_text", dtkhambenh.Rows[0]["isxnmau_text"].ToString());
            R.SetParameterValue("@isxnnt_text", dtkhambenh.Rows[0]["isxnnt_text"].ToString());
            R.SetParameterValue("@xnk_text", dtkhambenh.Rows[0]["xnk_text"].ToString());
            R.SetParameterValue("@xqp_text", dtkhambenh.Rows[0]["xqp_text"].ToString());
            R.SetParameterValue("@sab_text", dtkhambenh.Rows[0]["sab_text"].ToString());
            R.SetParameterValue("@clsk_text", dtkhambenh.Rows[0]["clsk_text"].ToString());

        }
        else
        {
            R.SetParameterValue("Loai1", "");
            R.SetParameterValue("Loai2", "");
            R.SetParameterValue("Loai3", "");
            R.SetParameterValue("Loai4", "");
            R.SetParameterValue("Loai5", "a");
            R.SetParameterValue("DanDo", "");
            R.SetParameterValue("Timmach", "");
            R.SetParameterValue("Tieuhoa", "");
            R.SetParameterValue("Hohap", "");
            R.SetParameterValue("ThanTieuLieuSinhDuc", "");
            R.SetParameterValue("Thankinh", "");
            R.SetParameterValue("CoxuongkhopCotsong", "");
            R.SetParameterValue("KQDalieu", "");
            R.SetParameterValue("KLMattrai", "");
            R.SetParameterValue("KLMatphai", "");
            R.SetParameterValue("Mattraideokinh", "");
            R.SetParameterValue("Matphaideokinh", "");
            R.SetParameterValue("Taitrai", "");
            R.SetParameterValue("Taiphai", "");
            R.SetParameterValue("Taitraithitham", "");
            R.SetParameterValue("Taiphaithitham", "");
            R.SetParameterValue("Mui", "");
            R.SetParameterValue("Hong", "");
            R.SetParameterValue("klspk", "");
            R.SetParameterValue("ketluankhammat", "");
            R.SetParameterValue("ketluantmh", "");
            R.SetParameterValue("RHM", "");

            R.SetParameterValue("@xnm", "");
            R.SetParameterValue("@xnnt", "");
            R.SetParameterValue("@xnk", "");
            R.SetParameterValue("@xqp", "");
            R.SetParameterValue("@sab", "");
            R.SetParameterValue("@clskhac", "");
            R.SetParameterValue("@KhoeManh", "");
            R.SetParameterValue("@MacBenh", "");
            R.SetParameterValue("@TenBenh", "");
            R.SetParameterValue("@DuSucKhoe", "");
            R.SetParameterValue("@koDuSK", "");
            R.SetParameterValue("@TenCongViec", "");
            //R.SetParameterValue("@BacSiKL", "");
            R.SetParameterValue("DanDo", "");

            R.SetParameterValue("@isxnmau_text", "");
            R.SetParameterValue("@isxnnt_text", "");
            R.SetParameterValue("@xnk_text", "");
            R.SetParameterValue("@xqp_text", "");
            R.SetParameterValue("@sab_text", "");
            R.SetParameterValue("@clsk_text", "");
        }
        #endregion
        CrystalReportViewer1.ReportSource = R;
        CrystalReportViewer1.DataBind();
    }
}
