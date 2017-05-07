using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text.pdf;

public partial class KhamBenh_TH_rptInPK : System.Web.UI.Page
{
    private ReportDocument report = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string iddangkykham = Request.QueryString["iddangkykham"];
            loadreport(iddangkykham);
       }
    }
    private void loadreport(string iddangkykham)
    {

        DataSet ds = new DataSet();
        report = new ReportDocument();
        const string TenReport = "phikham";
        string sql = @"SELECT top 1
            b.idbenhnhan,
            b.mabenhnhan,
            b.tenbenhnhan,
            b.diachi,TuoiBN=DBO.KB_Tuoi(B.NgaySinh),
            tengioitinh=dbo.getgioitinh(b.gioitinh),
            b.gioitinh,
            b.ngaysinh,
            b.chungminhthu,
            b.ngaytiepnhan,
            b.dienthoai,
            bnbh.sobhyt,
            bnbh.ngaybatdau,
            bnbh.ngayhethan,
            bnbh.DungTuyen,
            noigioithieu=ngt.TENNOIDANGKY,
            noidangkykcb=ndk.TENNOIDANGKY,
			MaDangKy_KCB_bandau=ndk.MADANGKY,
            NOICONGTAC=B.NOICONGTAC
            ,TenPhongKhamBenh=N'Cấp cứu'
             FROM    dangkykham dk
                    left join benhnhan_bhyt bnbh on bnbh.IDBENHNHAN_BH=dk.IDBENHNHAN_BH
			        left join KB_NOIDANGKYKB ndk on ndk.IDNOIDANGKY= bnbh.IdNoiDangKyBH
			        left join KB_NOIDANGKYKB ngt on ngt.IDNOIDANGKY= bnbh.IdNoiGioiThieu
                    LEFT JOIN BENHNHAN B ON dk.IdBenhNhan=B.IdBenhNhan
					
            WHERE dk.iddangkykham='" + iddangkykham+@"'
			order by dk.ngaydangky desc";
        DataTable dtBn = DataAcess.Connect.GetTable(sql);
        report.Load(Server.MapPath("ReportDesign/phikham.rpt"));
        #region Report tiêu đề
        DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
        if (dtTieuDeCty != null)
            report.OpenSubreport("crpt_ThongTinDonVi.rpt").SetDataSource(dtTieuDeCty);
        string tieude = dtTieuDeCty.Rows[0]["Ten_Cty"].ToString();
        string[] slp = tieude.Split('-');
        string til = slp[0];
        string subtil = (slp.Length > 1 ? slp[1] : "");
        //((TextObject)report.OpenSubreport("crpt_ThongTinDonVi.rpt").ReportDefinition.ReportObjects["txtTitle"]).Text = til;
        #endregion
        #region {TACH CHUOI}
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
            report.SetParameterValue("BHYT1", bhyt1);
            report.SetParameterValue("BHYT2", bhyt2);
            report.SetParameterValue("BHYT3", bhyt3);
            report.SetParameterValue("BHYT4", bhyt4);
            report.SetParameterValue("BHYT5", bhyt5);
            report.SetParameterValue("BHYT6", bhyt6);
        }
        else
        {
            report.SetParameterValue("BHYT1", "");
            report.SetParameterValue("BHYT2", "");
            report.SetParameterValue("BHYT3", "");
            report.SetParameterValue("BHYT4", "");
            report.SetParameterValue("BHYT5", "");
            report.SetParameterValue("BHYT6", "");
        }

        #endregion
        if (dtBn.Rows[0]["sobhyt"].ToString().Trim()=="")
        {
            report.SetParameterValue("noidangky", "");
            //report.SetParameterValue("manoidangky", "");
            report.SetParameterValue("tungay", "");
            report.SetParameterValue("denngay", "");
            //report.SetParameterValue("sobhyt", "");
            report.SetParameterValue("checkbhyt", "");
            //report.SetParameterValue("checkthe", "V");
            report.SetParameterValue("checkdungtuyen", "");
            report.SetParameterValue("checktraituyen", "");
        }
        else
        {
            report.SetParameterValue("noidangky", dtBn.Rows[0]["noidangkykcb"].ToString());
            //report.SetParameterValue("manoidangky", dtBn.Rows[0]["MaDangKy_KCB_bandau"].ToString());
            report.SetParameterValue("tungay", string.Format("{0:dd/MM/yyyy}",dtBn.Rows[0]["ngaybatdau"]));
            report.SetParameterValue("denngay",string.Format("{0:dd/MM/yyyy}",dtBn.Rows[0]["ngayhethan"]));
            //report.SetParameterValue("sobhyt", dtBn.Rows[0]["sobhyt"].ToString());
            //if (dtBn.Rows[0]["loai"].ToString() == "1")
            //{
            report.SetParameterValue("checkbhyt", "a");
            //    if (dtBn.Rows[0]["CapCuu"].ToString() == "a" || dtBn.Rows[0]["CapCuu"].ToString() == "1" || dtBn.Rows[0]["CapCuu"].ToString().ToLower() == "true")
            //    {
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
            //    }
            //    else
            //    {
            //        if (dtBn.Rows[0]["dungtuyen"].ToString() == "Y")
            //        {
            //            report.SetParameterValue("checkdungtuyen", "a");
            //            report.SetParameterValue("checktraituyen", "");
            //        }
            //        else
            //        {
            //            report.SetParameterValue("checkdungtuyen", "");
            //            report.SetParameterValue("checktraituyen", "a");
            //        }
            //    }
            //}
            //else
                //report.SetParameterValue("checkbhyt", "");
            //report.SetParameterValue("checkthe", "");
        }

        if (dtBn.Rows[0]["tengioitinh"].ToString().ToLower() == "nam")
        {
            report.SetParameterValue("checknam", "a");
            report.SetParameterValue("checknu", "");
        }
        else
        {
            report.SetParameterValue("checknam", "");
            report.SetParameterValue("checknu", "a");
        }
        //if (dtBn.Rows[0]["CapCuu"].ToString() == "a" || dtBn.Rows[0]["CapCuu"].ToString() == "1" || dtBn.Rows[0]["CapCuu"].ToString().ToLower() == "true")
        //{
          report.SetParameterValue("checkcapcuu", "a");
        //}
        //else
        //{
        //    report.SetParameterValue("checkcapcuu", "");
        //}
        //#region ma vach
        //string mabenhnhan = dtBn.Rows[0]["mabenhnhan"].ToString();
        //Barcode128 barcode = new Barcode128();
        //barcode.ChecksumText = false;
        //barcode.Code = mabenhnhan;
        //Image bmp = barcode.CreateDrawingImage(Color.Black, Color.White);
        //Byte[] arrByte = (Byte[])TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
        //for (int k = 0; k < dt.Rows.Count; k++)
        //{
        //    dt.Rows[k]["MaVach"] = arrByte;
        //}
        //#endregion
        //report.SetParameterValue("songay", "");
        report.SetParameterValue("tenbenhnhan", dtBn.Rows[0]["tenbenhnhan"].ToString().ToUpper());
        report.SetParameterValue("diachi", dtBn.Rows[0]["diachi"].ToString());
        ((TextObject)report.ReportDefinition.ReportObjects["txtPhongKham"]).Text = dtBn.Rows[0]["TenPhongKhamBenh"].ToString();
        //((TextObject)report.ReportDefinition.ReportObjects["txtHoTenBN"]).Text = dtBn.Rows[0]["tenbenhnhan"].ToString().ToUpper();
       
        report.SetParameterValue("namsinh", dtBn.Rows[0]["ngaysinh"].ToString());
        //report.SetParameterValue("mabenhnhan", dt.Rows[0]["MAPHIEUCLS"].ToString());
        
        report.SetParameterValue("noichuyenden", dtBn.Rows[0]["noigioithieu"].ToString());
        //report.SetParameterValue("ngaythangnam", "Ngày " + NgayKham.ToString("dd") + " tháng " + NgayKham.ToString("MM") + " năm " + NgayKham.ToString("yyyy") + "");
        //report.SetParameterValue("mauso", "01/BV");
        crvPhieuChiDinh.ReportSource = report;
        crvPhieuChiDinh.DataBind();
    }
    protected void crvPhieuChiDinh_Unload(object sender, EventArgs e)
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
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(report);
    }
    #endregion
}
