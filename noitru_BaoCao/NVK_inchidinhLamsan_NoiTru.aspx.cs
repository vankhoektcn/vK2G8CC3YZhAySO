using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using DataAcess;
using iTextSharp.text.pdf;

public partial class NVK_inchidinhLamsan_NoiTru : Page
{
    private ReportDocument crystalReport;
    private string idPhieuhuy = "";

    protected void Page_Load(object sender, EventArgs e)
    {
       
        string idkhambenh = Request.QueryString["idkhambenh"];
        if (idkhambenh != null)
        {
            idPhieuhuy = idkhambenh;
            load();
        }
    }

    private void load()
    {
        DataTable dtsrc = loadphieuchi();
        if (dtsrc == null)
        {
            StaticData.MsgBox(this, "Không lấy được báo cáo");
            return;
        }
        if (dtsrc.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không có dòng chỉ định nào");
            return;
        }
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../noitru_BaoCao/rpt_nvk_ChiDinhDichVu.rpt"));

        #region ma vach

        string mabenhnhan = dtsrc.Rows[0]["mabenhnhan"].ToString();
        Barcode128 barcode = new Barcode128();
        barcode.ChecksumText = false;
        barcode.Code = mabenhnhan;
        Image bmp = barcode.CreateDrawingImage(Color.Black, Color.White);
        Byte[] arrByte = (Byte[]) TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof (Byte[]));
        //dtsrc.Columns.Add("mavach", arrByte.GetType());
        dtsrc.Rows[0]["logo"] = arrByte;

        #endregion

        crystalReport.SetDataSource(dtsrc);
        string sqlSelectCompanyInfor = "SELECT  top 1 * from TieuDeCty";
        DataTable dtCompanyInfor = Connect.GetTable(sqlSelectCompanyInfor);
        crystalReport.SetParameterValue("TenCty", dtCompanyInfor.Rows[0]["Ten_Cty"].ToString());
        crystalReport.SetParameterValue("DiaChi", dtCompanyInfor.Rows[0]["DiaChi"].ToString());
        crystalReport.SetParameterValue("DienThoai", dtCompanyInfor.Rows[0]["DienThoai"].ToString());
        crystalReport.SetParameterValue("Email", dtCompanyInfor.Rows[0]["Email"].ToString());
        crystalReport.SetParameterValue("Website", dtCompanyInfor.Rows[0]["Website"].ToString());
        crystalReport.SetParameterValue("Fax", dtCompanyInfor.Rows[0]["Fax"].ToString());
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
        //if (dtsrc != null && dtsrc.Rows.Count > 0)
        //{
        //    double tongtien = 0;
        //    for (int i = 0; i < dtsrc.Rows.Count; i++)
        //    {
        //        tongtien += Convert.ToDouble(dtsrc.Rows[i]["dongia"]);
        //    }
        //    string str_SO = new clsDocSo.clsDocSo().ChuyenSo(tongtien.ToString());
        //    ((TextObject) crystalReport.ReportDefinition.ReportObjects["txttenbacsichidinh"]).Text = "";
        //}
        string tieude = dtCompanyInfor.Rows[0]["Ten_Cty"].ToString();
        string[] slp = tieude.Split('-');
        string til = slp[0];
        string subtil = (slp.Length > 1 ? slp[1] : "");
        ((TextObject) crystalReport.ReportDefinition.ReportObjects["txtTitle"]).Text = til;
        #region tiêu đề report
        int loaiTieuDe = 1;
        for (int j = 0; j < dtsrc.Rows.Count; j++)
        {
            if (!dtsrc.Rows[j]["idphongkhambenh"].ToString().Equals("7"))
            {
                if (loaiTieuDe == 2)
                    loaiTieuDe = 3;
                else
                    loaiTieuDe = 1;
                ; break; 
            }
        }
        if (Request.QueryString["nvk_loaiDC"] != null)
        {
            string nvkLoaiDC=Request.QueryString["nvk_loaiDC"].ToString().Trim().ToLower();
            if (nvkLoaiDC.Equals("dv"))
                loaiTieuDe = 4;
            else if (nvkLoaiDC.Equals("cls"))
                loaiTieuDe = 5;
        }
        if (loaiTieuDe == 3)
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtHeader"]).Text = "PHIẾU CHỈ ĐỊNH CẬN LÂM SÀNG - THỦ THUẬT";
        else if (loaiTieuDe == 2)
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtHeader"]).Text = "PHIẾU CHỈ ĐỊNH THỦ THUẬT";
        else if (loaiTieuDe == 4)
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtHeader"]).Text = "PHIẾU CHỈ ĐỊNH DỊCH VỤ";
        else if (loaiTieuDe == 5)
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtHeader"]).Text = "PHIẾU CHỈ ĐỊNH CẬN LÂM SÀNG";
        else
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtHeader"]).Text = "PHIẾU CHỈ ĐỊNH CẬN LÂM SÀNG - DỊCH VỤ";
        #endregion
        #region load thông tin chẩn đoán
        // chuẩn đoán xác định
        string chandoanXD = DataAcess.Connect.GetTable("select cdxd=isnull((select '('+maicd+')'+mota from chandoanicd where idicd='" + dtsrc.Rows[0]["ketluan"] + "'),'')").Rows[0][0].ToString();
        crystalReport.SetParameterValue("@ChanDoanXD", chandoanXD);
        // chuẩn đoán Phối hợp
        DataTable tablephoihop =DataAcess.Connect.GetTable("select * from chandoanphoihop ph left join chandoanicd cd on cd.idicd = ph.idicd  where idkhambenh=" +idPhieuhuy);
        string chandoanPH = "";
        if (tablephoihop != null && tablephoihop.Rows.Count > 0)
        {
            for (int i = 0; i < tablephoihop.Rows.Count; i++)
            {
                chandoanPH += " (" + tablephoihop.Rows[i]["maicd"] + ")" + tablephoihop.Rows[i]["mota"] + " ;";
            }
        }
        crystalReport.SetParameterValue("@ChanDoanPH", chandoanPH);
        #endregion
        string TenBSCD = DataAcess.Connect.GetTable("select cdxd=isnull((select tenbacsi from bacsi  where idbacsi ='" + dtsrc.Rows[0]["idbacsiKB"] + "'),'')").Rows[0][0].ToString();
        if (Request.QueryString["idkhoa"] != null)
        {
            if (Request.QueryString["idkhoa"].ToString().Trim().Equals(StaticData.GetParameter("nvk_idkhoacapcuu")))
            {
                ((TextObject)crystalReport.ReportDefinition.ReportObjects["Text13"]).Text = "Người chỉ định";                
                //((TextObject)crystalReport.ReportDefinition.ReportObjects["txttenbacsichidinh"]).Text = TenBSCD;
            }
            else
                ((TextObject)crystalReport.ReportDefinition.ReportObjects["txttenbacsichidinh"]).Text = TenBSCD;
        }
    }

    private DataTable loadphieuchi()
    {
        string TrangThaiThu = Request.QueryString["TrangThaiThu"];
        if (string.IsNullOrEmpty(TrangThaiThu))
            TrangThaiThu = "0";
        string LoaiBN = "";

        string sql = "";
        DataTable dtBN =
            Connect.GetTable(
                @"select loai
        ,maphieucls=isnull((select top 1 maphieucls from khambenhcanlamsan where idkhambenh=a.idkhambenh),0)
        from khambenh a left join benhnhan b on a.idbenhnhan=b.idbenhnhan
             where a.idkhambenh='" +idPhieuhuy+"'");
        string MaPhieuclsK = dtBN.Rows[0]["maphieucls"].ToString();
        if (MaPhieuclsK == "" || MaPhieuclsK == "0" && idPhieuhuy != "")
        {
            DataTable dtMaPhieu =
                Connect.GetTable("select top 1 maphieucls from khambenhcanlamsan where idkhambenhcanlamsan='" +
                                 idPhieuhuy + "'");
            if (dtMaPhieu != null && dtMaPhieu.Rows.Count > 0)
                MaPhieuclsK = dtMaPhieu.Rows[0][0].ToString();
            else
            {
                StaticData.MsgBox(this, "Không lấy được báo cáo");
                return null;
            }
        }

        #region nvk nvk_LoaiDC, idkbcls
        string nvkLoaiDC = "";
        if (Request.QueryString["nvk_loaiDC"] != null)
        {
            string nvkDC = Request.QueryString["nvk_loaiDC"].ToString().Trim().ToLower();
            if (nvkDC.Equals("dv"))
                nvkLoaiDC = " and banggiadichvu.idphongkhambenh in (select idphongkhambenh from phongkhambenh where maphongkhambenh =N'DVKTKHAC')";
            else if (nvkDC.Equals("cls"))
                nvkLoaiDC = " and banggiadichvu.idphongkhambenh in (select idphongkhambenh from phongkhambenh where maphongkhambenh <> N'DVKTKHAC' and loaiphong=1)"; 
        }
        string nvkIdKBCLS = "";
        if (Request.QueryString["nvk_IdKbCls"] != null)
        {
            string nvk_Idkbcls = Request.QueryString["nvk_IdKbCls"];
            nvk_Idkbcls = nvk_Idkbcls.TrimEnd(',').TrimStart(',');
            if (nvk_Idkbcls.Equals(""))
                nvk_Idkbcls = "0";
            nvkIdKBCLS = " and khambenhcanlamsan.idkhambenhcanlamsan in (" + nvk_Idkbcls + ")";
        }
        #endregion
        if (Request.QueryString["listIdClsCu"] == null)
        {
            LoaiBN = dtBN.Rows[0][0].ToString();
            if (LoaiBN == "1")
            {
                string DathuBHYT = StaticData.GetParameter("DathuBHYT");

                TrangThaiThu = DathuBHYT;
            }
            sql =
                "SELECT idbacsiKB=khambenh.idbacsi,khambenh.ketluan,banggiadichvu.idphongkhambenh,banggiadichvu.idbanggiadichvu,bs.tenbacsi as tenbs,benhnhan.mabenhnhan, benhnhan.tenbenhnhan, benhnhan.diachi, benhnhan.dienthoai,gioitinh=dbo.getgioitinh(benhnhan.gioitinh)";
            sql +=
                @",DBO.GetNamSinh( benhnhan.ngaysinh) as NgaySinh
            ,dongia= khambenhcanlamsan.soluong

            , khambenh.ngaykham,tendichvu= banggiadichvu.tendichvu,benhnhan.sobhyt,  ";
            sql +=
                " benhnhan.ngayhethan, tenbacsi ,Logo=(select top 1 logo_Image from TieuDeCty) FROM         khambenhcanlamsan INNER JOIN ";
            sql += " khambenh ON khambenhcanlamsan.idkhambenh = khambenh.idkhambenh INNER JOIN ";
            sql += " benhnhan ON khambenh.idbenhnhan = benhnhan.idbenhnhan INNER JOIN  ";
            sql += " banggiadichvu ON khambenhcanlamsan.idcanlamsan = banggiadichvu.idbanggiadichvu ";
            sql += " left JOIN bacsi bs ON khambenh.idbacsi = bs.idbacsi ";
            sql += " where 1=1 and khambenhcanlamsan.idkhambenh=" + StaticData.ParseInt(idPhieuhuy) + " " + nvkLoaiDC + nvkIdKBCLS+ "";
                //  and  khambenhcanlamsan.dathu=" + TrangThaiThu + "
        }
        else
        {
            #region else
            sql =
                "SELECT     bs.tenbacsi as tenbs,benhnhan.mabenhnhan, benhnhan.tenbenhnhan, benhnhan.diachi, benhnhan.dienthoai, (select gioitinh from(  ";
            sql += " select N'Nữ' as gioitinh,benhnhan.idbenhnhan from benhnhan where gioitinh=1 union all ";
            sql += " select N'Nam' as gioitinh,benhnhan.idbenhnhan from benhnhan where gioitinh=0)as a  ";
            sql += " Where idbenhnhan = benhnhan.idbenhnhan) as gioitinh,  ";
            sql +=
                "DBO.GetNamSinh( benhnhan.ngaysinh) as NgaySinh, dongia= khambenhcanlamsan.soluong, khambenh.ngaykham,tendichvu= banggiadichvu.tendichvu,benhnhan.sobhyt,  ";
            sql +=
                " benhnhan.ngayhethan, tenbacsi ,Logo=(select top 1 logo_Image from TieuDeCty) FROM         khambenhcanlamsan INNER JOIN ";
            sql += " khambenh ON khambenhcanlamsan.idkhambenh = khambenh.idkhambenh INNER JOIN ";
            sql += " benhnhan ON khambenh.idbenhnhan = benhnhan.idbenhnhan INNER JOIN  ";
            sql += " banggiadichvu ON khambenhcanlamsan.idcanlamsan = banggiadichvu.idbanggiadichvu ";
            sql += " left JOIN bacsi bs ON khambenh.idbacsi = bs.idbacsi ";
            sql += " where 1=1 " + nvkLoaiDC + nvkIdKBCLS + " and khambenhcanlamsan.maphieucls='" + MaPhieuclsK + "'  and khambenh.idkhambenh=" +
                   idPhieuhuy;
            string idclscu = Request.QueryString["listIdClsCu"].TrimStart(';', ',').TrimEnd(';', ',').Replace(";", ",");

            if (idclscu != "0" || idclscu!="")
            {
                sql += "union all(";
                sql +=
                   "SELECT     bs.tenbacsi as tenbs,benhnhan.mabenhnhan, benhnhan.tenbenhnhan, benhnhan.diachi, benhnhan.dienthoai, (select gioitinh from(  ";
                sql += " select N'Nữ' as gioitinh,benhnhan.idbenhnhan from benhnhan where gioitinh=1 union all ";
                sql += " select N'Nam' as gioitinh,benhnhan.idbenhnhan from benhnhan where gioitinh=0)as a  ";
                sql += " Where idbenhnhan = benhnhan.idbenhnhan) as gioitinh,  ";
                sql +=
                    "DBO.GetNamSinh( benhnhan.ngaysinh) as NgaySinh, dongia= khambenhcanlamsan.soluong, khambenh.ngaykham,tendichvu= banggiadichvu.tendichvu,benhnhan.sobhyt,  ";
                sql +=
                    " benhnhan.ngayhethan, tenbacsi ,Logo=(select top 1 logo_Image from TieuDeCty) FROM         khambenhcanlamsan INNER JOIN ";
                sql += " khambenh ON khambenhcanlamsan.idkhambenh = khambenh.idkhambenh INNER JOIN ";
                sql += " benhnhan ON khambenh.idbenhnhan = benhnhan.idbenhnhan INNER JOIN  ";
                sql += " banggiadichvu ON khambenhcanlamsan.idcanlamsan = banggiadichvu.idbanggiadichvu ";
                sql += " left JOIN bacsi bs ON khambenh.idbacsi = bs.idbacsi ";
                sql += " where 1=1 and  khambenhcanlamsan.maphieucls not in ('" + MaPhieuclsK + "' ) and khambenh.idkhambenh=" +
                       idPhieuhuy;
                sql += " and  banggiadichvu.idbanggiadichvu in(" + idclscu + ")";
                sql += ")";
            }
            #endregion
        }
        DataTable dtSRC = Connect.GetTable(sql);
        if (dtSRC != null)
        {
            dtSRC.Columns.Add("STT1", sql.GetType());
            dtSRC.Columns.Add("STT2", sql.GetType());
            dtSRC.Columns.Add("TenDichVu1", sql.GetType());
            dtSRC.Columns.Add("TenDichVu2", sql.GetType());
            dtSRC.Columns.Add("IsR", sql.GetType());
            dtSRC.Columns.Add("Lan2", sql.GetType());

            string MaxRowOfCDCLS = StaticData.MaxRowOfCDCLS;
            if (string.IsNullOrEmpty(MaxRowOfCDCLS) || MaxRowOfCDCLS == "0")
                MaxRowOfCDCLS = "12";
            int nMaxRow = 12;
            if (StaticData.IsNumber(MaxRowOfCDCLS))
                nMaxRow = int.Parse(MaxRowOfCDCLS);
            for (int i = 0; i < dtSRC.Rows.Count; i++)
            {
                string stemp = (i + 1).ToString();
                if (stemp.Length == 1) stemp = "0" + stemp;
                dtSRC.Rows[i]["STT1"] = stemp;
                dtSRC.Rows[i]["TenDichVu1"] = dtSRC.Rows[i]["TenDichVu"].ToString();
                dtSRC.Rows[i]["IsR"] = "0";
            }
            if (dtSRC.Rows.Count > nMaxRow)
            {
                int n = nMaxRow;
                int m = n;
                for (int j = 0; j < n; j++)
                {
                    if (m < dtSRC.Rows.Count)
                    {
                        string stemp = (m + 1).ToString();
                        if (stemp.Length == 1) stemp = "0" + stemp;
                        dtSRC.Rows[j]["STT2"] = stemp;
                        dtSRC.Rows[j]["TenDichVu2"] = dtSRC.Rows[m]["TenDichVu"].ToString();
                        dtSRC.Rows[m]["IsR"] = "1";
                        dtSRC.Rows[j]["Lan2"] = dtSRC.Rows[m]["dongia"].ToString();
                        m++;
                    }
                }
                dtSRC.DefaultView.RowFilter = "IsR=0";
                dtSRC = dtSRC.DefaultView.ToTable();
            }
        }

        return dtSRC;
    }

    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }

    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }

    protected void Ctrhuehongbs_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
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