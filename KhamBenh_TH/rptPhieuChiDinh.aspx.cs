using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text.pdf;

public partial class KhamBenh_TH_rptPhieuChiDinh : System.Web.UI.Page
{
    private ReportDocument report = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        loadreport(idkhambenh);
        //if (!IsPostBack)
        //{
        //    string idkhoa = Request.QueryString["idkhoa"];
        //    if (idkhoa == null || idkhoa == "" || idkhoa != "1")
        //    {
        //        DataTable dtTest = DataAcess.Connect.GetTable("select idphongkhambenh,DATHU from khambenhcanlamsan a inner join khambenh b on a.idkhambenh=b.idkhambenh where a.idkhambenh= "+idkhambenh);
        //        if (dtTest != null && dtTest.Rows.Count > 0 && dtTest.Rows[0]["idphongkhambenh"].ToString()!="1"  && StaticData.IsCheck( dtTest.Rows[0]["DATHU"].ToString())==false)
        //        {
        //            string sqlUpdate = "UPDATE KHAMBENHCANLAMSAN SET DATHU=1,THUCTHU=1 WHERE IDKHAMBENH=" + idkhambenh;
        //            bool ok = DataAcess.Connect.ExecSQL(sqlUpdate);
        //        }
        //    }
        //}
    }
    private DataTable loaddv(string idkhambenh)
    {
        string idDangkykham = Request.QueryString["iddangkykham"];
        if (!string.IsNullOrEmpty(idDangkykham))
        {
            string sqlDK = @"
                SELECT	 
	                DOITUONG=(CASE WHEN DKK.LOAIKHAMID<>1 THEN NULL ELSE (CASE WHEN DKK.LOAIKHAMID=1 AND  ISNULL(B.ISSUDUNGCHOBH,0)=1  AND  ISNULL(CT.ISBHYT,0)=1 THEN N'BHYT' ELSE N'DỊCH VỤ' END) END)             
                    ,TENCHIDINH= B.TENDICHVU
                    ,SL=ISNULL(CT.SOLUONG,0)
                    ,CHANDOAN=NULL
                    ,MAPHIEUKHAM=NULL
                    ,NGAYKHAM=dkk.ngaydangky
                    ,E.TENPHONGKHAMBENH
                    ,TENNHOM='(' + REPLACE( TENNHOMCD,N'DỊCH VỤ',N'DỊCH VỤ KỸ THUẬT') + (CASE WHEN DKK.LOAIKHAMID<>1 THEN  ''   ELSE ( CASE WHEN ISNULL(B.ISSUDUNGCHOBH,0)=1  AND  ISNULL(cT.ISBHYT,0)=1 THEN N'-BHYT' ELSE N'-DỊCH VỤ' END ) END )+')'
                    ,HOTENBS=NULL
                    ,MaVach=CONVERT(IMAGE,NULL)
                    ,MACH=NULL
                    ,HUYETAP1=NULL
                    ,HUYETAP2=NULL
                    ,nvk_phong= NULL
                    ,B.idphongkhambenh,CT.idchitietdangkykham
                    ,MAPHIEUCLS=BN.MABENHNHAN
                FROM DANGKYKHAM DKK 
	                LEFT JOIN CHITIETDANGKYKHAM CT ON DKK.IDDANGKYKHAM=CT.IDDANGKYKHAM
	                LEFT JOIN BANGGIADICHVU B ON CT.IDBANGGIADICHVU=B.IDBANGGIADICHVU
	                LEFT JOIN BENHNHAN BN ON DKK.IDBENHNHAN=BN.IDBENHNHAN                       
	                LEFT JOIN PHONGKHAMBENH E ON E.IDPHONGKHAMBENH=B.IDPHONGKHAMBENH
                WHERE  DKK.IDDANGKYKHAM='" + idDangkykham+"'";
            DataTable dtDK = DataAcess.Connect.GetTable(sqlDK);
            return dtDK;
        }
        string IsAll = Request.QueryString["IsAll"];
        #region before 31-10 nvk edit
        string sql = @"SELECT	 
		            	DOITUONG=(CASE WHEN DKK.LOAIKHAMID<>1 THEN NULL ELSE (CASE WHEN DKK.LOAIKHAMID=1 AND  ISNULL(B.ISSUDUNGCHOBH,0)=1  AND  ISNULL(A.ISBHYT_SAVE,0)=1 THEN N'BHYT' ELSE N'DỊCH VỤ' END) END)             
		                        ,TENCHIDINH= case when isnull(a.ghichu,'')<> '' then B.TENDICHVU +' ('+ a.ghichu +')' else B.TENDICHVU end
		                        ,SL=ISNULL(A.SOLUONG,0)
		                        ,CHANDOAN=ISNULL(C.CHANDOANBANDAU,DBO.[nvk_ListMoTaChanDoan_1KhamBenh](C.IDKHAMBENH))
		                        --,maicd=ISNULL(C.CHANDOANBANDAU,nvk_ListMaChanDoan_1KhamBenh(C.IDKHAMBENH))
		                        ,C.MAPHIEUKHAM
		                        ,C.NGAYKHAM
                                ,E.TENPHONGKHAMBENH
                                ,TENNHOM='(' + REPLACE( TENNHOMCD,N'DỊCH VỤ',N'DỊCH VỤ KỸ THUẬT') + (CASE WHEN DKK.LOAIKHAMID<>1 THEN  ''   ELSE ( CASE WHEN ISNULL(B.ISSUDUNGCHOBH,0)=1  AND  ISNULL(A.ISBHYT_SAVE,0)=1 THEN N'-BHYT' ELSE N'-DỊCH VỤ' END ) END )+')'
                                ,HOTENBS=G.TENBACSI
                                ,MaVach=CONVERT(IMAGE,NULL)
                                ,SH.MACH
                                ,SH.HUYETAP1
                                ,SH.HUYETAP2
                                ,nvk_phong= (CASE WHEN ISNULL(C.PHONGID,0)<>0 THEN DBO.HS_TENPHONG(C.PHONGID) ELSE    isnull(
								    (select top 1 tenphong from benhnhannoitru nn inner join kb_phong pp on pp.id=nn.idphongnoitru  where idchitietdangkykham =c.idchitietdangkykham order by ngayvaovien desc)
								    ,0
								        ) END)
                                ,c.idphongkhambenh,c.idchitietdangkykham
                                ,A.MAPHIEUCLS
                        FROM KHAMBENHCANLAMSAN A
                        LEFT JOIN BANGGIADICHVU B ON A.IDCANLAMSAN=B.IDBANGGIADICHVU
                        LEFT JOIN KHAMBENH C ON A.IDKHAMBENH=C.IDKHAMBENH
                        LEFT JOIN DANGKYKHAM DKK ON C.IDDANGKYKHAM=DKK.IDDANGKYKHAM
                          LEFT JOIN BENHNHAN D ON C.IDBENHNHAN=D.IDBENHNHAN                       
                        LEFT JOIN PHONGKHAMBENH E ON E.IDPHONGKHAMBENH=ISNULL(C.IDKHOA,C.IDPHONGKHAMBENH)
                        LEFT JOIN PHONGKHAMBENH F ON F.IDPHONGKHAMBENH=B.IDPHONGKHAMBENH 
                        LEFT JOIN BACSI G ON C.IDBACSI=G.IDBACSI
                        LEFT JOIN SINHHIEU SH ON C.IDKHAMBENH=SH.IDKHAMBENH
                     WHERE  ISNULL(A.dahuy,0)=0 AND  A.IDKHAMBENH='" + idkhambenh + "' ";
        #endregion
      
        if (!StaticData.IsCheck(IsAll))
            sql += " AND( ISNULL(A.DATHU,0)=0   AND ISNULL(A.ISBNDATRA,0)=0)";
       
        string isdvkt = Request.QueryString["isdvkt"];
        if (isdvkt == "1")
        {
            sql += " and ISNULL(B.ISDVKT,0)=1";
        }
        else if(isdvkt=="0")
        {

            sql += " and ISNULL(B.ISDVKT,0)=0";
        }
        string nvk_IdKbCls = Request.QueryString["nvk_IdKbCls"];
        if (nvk_IdKbCls != null && nvk_IdKbCls != "")
        {
            sql += " AND A.IDKHAMBENHCANLAMSAN IN (" + nvk_IdKbCls + ")";
        }
        DataTable dtSRC = DataAcess.Connect.GetTable(sql);
        if (isdvkt == "1")
        {
            for (int i = 0; i < dtSRC.Rows.Count; i++)
            {
                if (dtSRC.Rows[i]["TENNHOM"].ToString() == "(DỊCH VỤ KỸ THUẬT)")
                {
                    dtSRC.Rows[i]["TENNHOM"] = "";
                }
            }
        }
        return dtSRC;
    }
    private void loadreport(string idkhambenh)
    {
        try
        {

            DataSet ds = new DataSet();
            report = new ReportDocument();
            const string TenReport = "rptPhieuChiDinh";
            DataTable dt = loaddv(idkhambenh);
            if (dt == null || dt.Rows.Count == 0)
            { StaticData.MsgBox(this, "Không load đươc thông tin phiếu chỉ định!"); return; }
            DataTable dtBn = StaticData_HS.nvk_thongTimBaohiemBy_idctdkk(dt.Rows[0]["idchitietdangkykham"].ToString());
            report.Load(Server.MapPath("ReportDesign/" + TenReport + ".rpt"));
            #region Report tiêu đề
            DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
            if (dtTieuDeCty != null)
                report.OpenSubreport("crpt_ThongTinDonVi.rpt").SetDataSource(dtTieuDeCty);
            string tieude = dtTieuDeCty.Rows[0]["Ten_Cty"].ToString();
            string[] slp = tieude.Split('-');
            string til = slp[0];
            string subtil = (slp.Length > 1 ? slp[1] : "");
            ((TextObject)report.OpenSubreport("crpt_ThongTinDonVi.rpt").ReportDefinition.ReportObjects["txtTitle"]).Text = til;
            #endregion
            dt.TableName = "dtPhieuChiDinh";
            ds.Tables.Add(dt);
            report.SetDataSource(ds);
            #region {TACH CHUOI}
            if (dtBn.Rows.Count > 0 && dtBn.Rows[0]["sobhyt"].ToString() != "")
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
            if (dtBn.Rows.Count == 0 || dtBn.Rows[0]["loai"].ToString() != "1" || dtBn.Rows[0]["sobhyt"].ToString().Trim() == "")
            {
                report.SetParameterValue("noidangky", "");
                report.SetParameterValue("manoidangky", "");
                report.SetParameterValue("tungay", "");
                report.SetParameterValue("denngay", "");
                report.SetParameterValue("sobhyt", "");
                report.SetParameterValue("checkbhyt", "");
                report.SetParameterValue("checkthe", "V");
                report.SetParameterValue("checkdungtuyen", "");
                report.SetParameterValue("checktraituyen", "");
            }
            else
            {
                report.SetParameterValue("noidangky", dtBn.Rows[0]["noidangkykcb"].ToString());
                report.SetParameterValue("manoidangky", dtBn.Rows[0]["MaDangKy_KCB_bandau"].ToString());
                report.SetParameterValue("tungay", string.Format("{0:dd/MM/yyyy}", dtBn.Rows[0]["ngaybatdau"]));
                report.SetParameterValue("denngay", string.Format("{0:dd/MM/yyyy}", dtBn.Rows[0]["ngayhethan"]));
                report.SetParameterValue("sobhyt", dtBn.Rows[0]["sobhyt"].ToString());
                if (dtBn.Rows[0]["loai"].ToString() == "1")
                {
                    report.SetParameterValue("checkbhyt", "a");
                    if (dtBn.Rows[0]["CapCuu"].ToString() == "a" || dtBn.Rows[0]["CapCuu"].ToString() == "1" || dtBn.Rows[0]["CapCuu"].ToString().ToLower() == "true")
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
                    report.SetParameterValue("checkbhyt", "");
                report.SetParameterValue("checkthe", "");
            }

            if (dtBn.Rows.Count > 0 && dtBn.Rows[0]["tengioitinh"].ToString().ToLower() == "nam")
            {
                report.SetParameterValue("checknam", "a");
                report.SetParameterValue("checknu", "");
            }
            else
            {
                report.SetParameterValue("checknam", "");
                report.SetParameterValue("checknu", "a");
            }
            if (dtBn.Rows.Count == 0 || dtBn.Rows[0]["CapCuu"].ToString() == "a" || dtBn.Rows[0]["CapCuu"].ToString() == "1" || dtBn.Rows[0]["CapCuu"].ToString().ToLower() == "true")
            {
                report.SetParameterValue("checkcapcuu", "a");
            }
            else
            {
                report.SetParameterValue("checkcapcuu", "");
            }
            #region ma vach
            string mabenhnhan = dtBn.Rows.Count > 0 ? dtBn.Rows[0]["mabenhnhan"].ToString() : "";
            Barcode128 barcode = new Barcode128();
            barcode.ChecksumText = false;
            barcode.Code = mabenhnhan;
            Image bmp = barcode.CreateDrawingImage(Color.Black, Color.White);
            Byte[] arrByte = (Byte[])TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                dt.Rows[k]["MaVach"] = arrByte;
            }
            #endregion
            report.SetParameterValue("songay", "");
            report.SetParameterValue("tenbenhnhan", dtBn.Rows[0]["tenbenhnhan"].ToString().ToUpper());
            report.SetParameterValue("diachi", dtBn.Rows[0]["diachi"].ToString());
            ((TextObject)report.ReportDefinition.ReportObjects["txtPhongKham"]).Text = dt.Rows[0]["TENPHONGKHAMBENH"].ToString();
            ((TextObject)report.ReportDefinition.ReportObjects["txtHoTenBN"]).Text = dtBn.Rows[0]["tenbenhnhan"].ToString().ToUpper();
            if (dtBn.Rows.Count > 0 && dt.Rows[0]["idphongkhambenh"].ToString().Equals(StaticData.GetParameter("nvk_idkhoacapcuu")))
            {

                ((TextObject)report.ReportDefinition.ReportObjects["tennguoichidinh"]).Text = "Người chỉ định";
            }
            if (dtBn.Rows.Count > 0 && dt.Rows[0]["idphongkhambenh"].ToString().Equals(StaticData.GetParameter("nvk_idkhoakhambenh")))
            {
                ((TextObject)report.ReportDefinition.ReportObjects["tennguoichidinh"]).Text = "Bác sĩ chỉ định";
                ((TextObject)report.ReportDefinition.ReportObjects["hotenbs"]).Text = dt.Rows[0]["HOTENBS"].ToString().ToUpper();
            }
            if (dt.Rows[0]["huyetap1"].ToString() != "" && dt.Rows[0]["huyetap2"].ToString() != "")
            {
                ((TextObject)report.ReportDefinition.ReportObjects["huyetap"]).Text = "Huyết áp: " + dt.Rows[0]["huyetap1"].ToString() + "/" + dt.Rows[0]["huyetap2"].ToString() + " mmHg";
            }
            if (dt.Rows[0]["nvk_phong"].ToString() != "0")
            {
                ((TextObject)report.ReportDefinition.ReportObjects["tenphong"]).Text = dt.Rows[0]["nvk_phong"].ToString();
            }
            if (dt.Rows[0]["mach"].ToString() != "")
            {
                ((TextObject)report.ReportDefinition.ReportObjects["mach"]).Text = "Mạch: " + dt.Rows[0]["mach"].ToString();
            }
            string isdvkt = Request.QueryString["isdvkt"];
            if (isdvkt == "1")
            {
                ((TextObject)report.ReportDefinition.ReportObjects["txtTitle"]).Text = "PHIẾU CHỈ ĐỊNH DỊCH VỤ KỸ THUẬT";
            }
            else if (isdvkt == "0")
            {
                ((TextObject)report.ReportDefinition.ReportObjects["txtTitle"]).Text = "PHIẾU CHỈ ĐỊNH CẬN LÂM SÀNG";
            }
            else
                ((TextObject)report.ReportDefinition.ReportObjects["txtTitle"]).Text = "PHIẾU CHỈ ĐỊNH CẬN LÂM SÀNG - DỊCH VỤ KỸ THUẬT";

            if (!string.IsNullOrEmpty(Request.QueryString["iddangkykham"]))
            {
                ((TextObject)report.ReportDefinition.ReportObjects["txtTitle"]).Text = "PHIẾU BÁO THU PHÍ KHÁM";
                ((TextObject)report.ReportDefinition.ReportObjects["txtChanDoan"]).Text = "";
            }
            report.SetParameterValue("chandoan", dt.Rows[0]["chandoan"].ToString());
            report.SetParameterValue("namsinh", dtBn.Rows[0]["ngaysinh"].ToString());
            report.SetParameterValue("mabenhnhan", dt.Rows[0]["MAPHIEUCLS"].ToString());
            report.SetParameterValue("ngayvaovien", dtBn.Rows[0]["ngaybatdau"].ToString());
            report.SetParameterValue("giovaovien", dtBn.Rows[0]["giovaovien"].ToString());
            report.SetParameterValue("ngayravien", dtBn.Rows[0]["ngayxuatvien"].ToString());
            report.SetParameterValue("gioravien", dtBn.Rows[0]["gioravien"].ToString());
            report.SetParameterValue("noichuyenden", dtBn.Rows[0]["noigioithieu"].ToString());
            DateTime NgayKham = DateTime.Parse(dt.Rows[0]["NgayKham"].ToString());
            report.SetParameterValue("ngaythangnam", "Ngày " + NgayKham.ToString("dd") + " tháng " + NgayKham.ToString("MM") + " năm " + NgayKham.ToString("yyyy") + "");
            report.SetParameterValue("mauso", "01/BV");
            crvPhieuChiDinh.ReportSource = report;
            crvPhieuChiDinh.DataBind();
        }
        catch (Exception)
        {
            StaticData.MsgBox(this,"Không có nội dung");
        }
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
