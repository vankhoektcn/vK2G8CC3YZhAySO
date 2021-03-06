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
using CrystalDecisions.Shared;
using DataAcess;

public partial class thongke_fr_rptBangTongHopKQSucKhoeTheoCty : System.Web.UI.Page
{
    ReportDocument R;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Idcty = "";
        string fromdate = "";
        string todate = "";
        
        if (!string.IsNullOrEmpty(Request.QueryString["Idcty"]))
        {
            Idcty = Request.QueryString["Idcty"].ToString().Trim();
            Idcty.TrimEnd();
        }
        if (!string.IsNullOrEmpty(Request.QueryString["datefrom"]))
            fromdate = Request.QueryString["datefrom"].ToString();
        if (!string.IsNullOrEmpty(Request.QueryString["dateto"]))
        {
            todate = Request.QueryString["dateto"].ToString();            
        }
        if (!IsPostBack)
        {
            string nguoiLapPara = StaticData.GetParameter("nvk_TenNguoiLap") == null ? "" : StaticData.GetParameter("nvk_TenNguoiLap");
            txtNguoiLap.Value = nguoiLapPara;
            string truongDoanPara = StaticData.GetParameter("nvk_TenTruongDoan") == null ? "" : StaticData.GetParameter("nvk_TenTruongDoan");
            txtTruongDoan.Value = truongDoanPara;
            string ghiChuTruongDoanPara = StaticData.GetParameter("nvk_GhiChuTruongDoan") == null ? "" : StaticData.GetParameter("nvk_GhiChuTruongDoan");
            txtGhiChu.Value = ghiChuTruongDoanPara;
        }
        LoadReport(Idcty, fromdate, todate);
    }
    private void LoadReport(string Idcty, string fromdate, string todate)
    {
        //string sfrom = "from benhnhan B INNER JOIN      KB_CongTy C ON B.idcongty = C.idcongty RIGHT OUTER JOIN sinhhieu S ON B.idbenhnhan = S.idbenhnhan RIGHT OUTER JOIN khambenh K ON B.idbenhnhan = K.idbenhnhan WHERE     (B.idcongty = '" + Idcty + "') AND (K.ngaykham BETWEEN CONVERT(DATETIME, '" + fromdate + "', 102) AND CONVERT(DATETIME, '" + todate + " 23:59:59', 102)) ";
        string sfrom = @"from benhnhan B INNER JOIN      KB_CongTy C ON B.idcongty = C.idcongty 
                            left JOIN khambenh K ON B.idbenhnhan = K.idbenhnhan 
                            left JOIN sinhhieu S ON k.iddangkykham = S.iddangkykham
                        WHERE     (B.idcongty = '" + Idcty + "') AND (K.ngaykham BETWEEN CONVERT(DATETIME, '" + fromdate + "', 102) AND CONVERT(DATETIME, '" + todate + " 23:59:59', 102)) ";
        string sql = @"select  B.tenbenhnhan, ngaysinh=k.ketluan, gioitinh=b.mabenhnhan, S.chieucao, S.cannang, S.mach, C.tencty, dando=k.HuongGiaiQ, B.idcongty,
        huyetap=k.xnk_text,S.huyetap1, huyetap2=k.ghichuhuongdieutri,   MatTrai=N'MT:'+k.Mattrai, MatPhai=N'MP:'+k.MatPhai, 
        TMH=k.ketluan1, RHM=k.ketluan2, S.NgoaiDaLieu,  SieuAm=k.sab_text, XNMau=k.isxnmau_text,
        XNNuocTieu=k.isxnnt_text, DienTim=k.clsk_text, XQ=k.xqp_text, PhanLoai=K.LoaiSK, PhuKhoa=k.klspk, K.ngaykham, 
        FromDate=CONVERT(DATETIME, '"+fromdate+@"', 102),
        ToDate=CONVERT(DATETIME, '" + todate + @"', 102),
        TongNhanVien=(select count(K.idbenhnhan) " + sfrom + @"),
        TongNam=(select count(K.idbenhnhan)  " + sfrom + @" and B.gioitinh=0), 
        TongNu=(select count(K.idbenhnhan) " + sfrom + @" and B.gioitinh=1), 
        TongLoai1=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=1), 
        TongNamLoai1=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=1 and B.gioitinh=0), 
        TongNuLoai1=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=1 and B.gioitinh=1), 

        TongLoai2=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=2), 
        TongNamLoai2=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=2 and B.gioitinh=0), 
        TongNuLoai2=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=2 and B.gioitinh=1), 

        TongLoai3=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=3), 
        TongNamLoai3=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=3 and B.gioitinh=0), 
        TongNuLoai3=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=3 and B.gioitinh=1), 

        TongLoai4=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=4), 
        TongNamLoai4=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=4 and B.gioitinh=0), 
        TongNuLoai4=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=4 and B.gioitinh=1), 

        TongLoai5=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=5), 
        TongNamLoai5=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=5 and B.gioitinh=0), 
        TongNuLoai5=(select count(K.idbenhnhan) " + sfrom + @" and K.LoaiSK=5 and B.gioitinh=1), 

        case when gioitinh=0 then B.ngaysinh else '' end as Nam,
        case when gioitinh=1 then B.ngaysinh else '' end as Nu,
        case when K.LoaiSK=1 then 'x' else '' end as case1,
        case when K.LoaiSK=2 then 'x' else '' end as case2,
        case when K.LoaiSK=3 then 'x' else '' end as case3,
        case when K.LoaiSK=4 then 'x' else '' end as case4,
        case when K.LoaiSK=5 then 'x' else '' end as case5 
        " + sfrom + @"
        order by b.mabenhnhan
        ";


        DataTable dt = DataAcess.Connect.GetTable(sql);
        R = new ReportDocument();
        string TenReport = "rpTongHopKQSucKhoeCtyrpt";
        R.Load(Server.MapPath(TenReport + ".rpt"));

        DataSet ds = new DataSet();
        if (dt != null && dt.Rows.Count > 0)
        {

            DataTable dtTieuDeCty = Connect.GetTable("SELECT * FROM TIEUDECTY");
            if (dtTieuDeCty != null)
                R.OpenSubreport("crpt_thongtindonvi.rpt").SetDataSource(dtTieuDeCty);
            string tieude = dtTieuDeCty.Rows[0]["Ten_Cty"].ToString();
            string[] slp = tieude.Split('-');
            string til = slp[0];
            string subtil = (slp.Length > 1 ? slp[1] : "");
            //((TextObject)R.OpenSubreport("crpt_ThongTinDonVi.rpt").ReportDefinition.ReportObjects["txtSubtitle"]).Text = subtil;
            ((TextObject)R.OpenSubreport("crpt_thongtindonvi.rpt").ReportDefinition.ReportObjects["txtTitle"]).Text = til;
            #region report sub "rpTongHopKhuyenNghiKham.rpt"
            string sqlKhuyenN = @"select *,phantram=convert(varchar,round((convert(float,SoLuot)/convert(float,TongKN) * 100),1))+' %'
                from (
	                select Tong=(select count(*) from khambenh a inner join benhnhan b on b.idbenhnhan=a.idbenhnhan where B.idcongty = '" + Idcty + "' and isnull(idHuongGiaiQuyet,0)>0 and  ngaykham BETWEEN CONVERT(DATETIME, '" + fromdate + "', 102) AND CONVERT(DATETIME, '" + todate + @" 23:59:59', 102))
	                ,TongKN=(select count(*) from khambenh a inner join benhnhan b on b.idbenhnhan=a.idbenhnhan where B.idcongty = '" + Idcty + "' and ngaykham BETWEEN CONVERT(DATETIME, '" + fromdate + "', 102) AND CONVERT(DATETIME, '" + todate + @" 23:59:59', 102))
	                ,NoiDungKhuyenNghi=N'Có '+convert(nvarchar,count(*))+N' nhân viên cần '+tenHuongGiaiQuyet,SoLuot =count(*),idHuongGiaiQuyet
	                from khambenh kb 
	                inner join DM_HuongGiaiQuyet h on h.id=kb.idHuongGiaiQuyet
                    inner join benhnhan bn on bn.idbenhnhan =kb.idbenhnhan
                where Bn.idcongty = '" + Idcty + "' and ngaykham BETWEEN CONVERT(DATETIME, '" + fromdate + "', 102) AND CONVERT(DATETIME, '" + todate + @" 23:59:59', 102)
	                group by idHuongGiaiQuyet,tenHuongGiaiQuyet
                ) as tb";
            DataTable dtKhuyenNghi= DataAcess.Connect.GetTable(sqlKhuyenN);
            if (dtKhuyenNghi != null && dtKhuyenNghi.Rows.Count>0)
            {
                R.OpenSubreport("rpTongHopKhuyenNghiKham.rpt").SetDataSource(dtKhuyenNghi);
                ((TextObject)R.OpenSubreport("rpTongHopKhuyenNghiKham.rpt").ReportDefinition.ReportObjects["txtTongCongKhuyenNghi"]).Text = "Tổng cộng có " + dtKhuyenNghi.Rows[0]["Tong"].ToString() + " nhân viên có khuyến nghị cần theo dõi sức khỏe, khám chuyên khoa và điều trị:";
                ((TextObject)R.OpenSubreport("rpTongHopKhuyenNghiKham.rpt").ReportDefinition.ReportObjects["txtNguoiLap"]).Text = txtNguoiLap.Value;
                ((TextObject)R.OpenSubreport("rpTongHopKhuyenNghiKham.rpt").ReportDefinition.ReportObjects["txtTruongDoan"]).Text = txtTruongDoan.Value;
                ((TextObject)R.OpenSubreport("rpTongHopKhuyenNghiKham.rpt").ReportDefinition.ReportObjects["txtLoiDanTruongDoan"]).Text = txtGhiChu.Value;
            }
            #endregion

            clsDocSo.clsDocSo docSo = new clsDocSo.clsDocSo();
            dt.TableName = "KQTKSKTheoCty";
            ds.Tables.Add(dt);
            R.SetDataSource(ds);
            rptThongKe.ReportSource = R;
            rptThongKe.DataBind();

            #region set Parameter
            double TongNhanVien = double.Parse(dt.Rows[0]["TongNhanVien"].ToString());
            double PtLoaiI = Math.Round(double.Parse(dt.Rows[0]["TongLoai1"].ToString()) / TongNhanVien * 100, 1);
            double PtLoaiII = Math.Round(double.Parse(dt.Rows[0]["TongLoai2"].ToString()) / TongNhanVien * 100, 1);
            double PtLoaiIII = Math.Round(double.Parse(dt.Rows[0]["TongLoai3"].ToString()) / TongNhanVien * 100, 1);
            double PtLoaiIV = Math.Round(double.Parse(dt.Rows[0]["TongLoai4"].ToString()) / TongNhanVien * 100, 1);
            double PtLoaiV = Math.Round(double.Parse(dt.Rows[0]["TongLoai5"].ToString()) / TongNhanVien * 100, 1);
            R.SetParameterValue("@PTLoaiI", "Chiếm " + PtLoaiI + " %");
            R.SetParameterValue("@PTLoaiII", "Chiếm " + PtLoaiII + " %");
            R.SetParameterValue("@PTLoaiIII", "Chiếm " + PtLoaiIII + " %");
            R.SetParameterValue("@PTLoaiIV", "Chiếm " + PtLoaiIV + " %");
            R.SetParameterValue("@PTLoaiV", "Chiếm " + PtLoaiV + " %");
            #endregion
        }
        else
        {
            Response.Write("không có dữ liệu");
        }

        
    }
    protected void btnBaoCao_Click(object sender, EventArgs e)
    {

    }
}
