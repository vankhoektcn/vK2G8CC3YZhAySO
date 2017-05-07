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

public partial class nvk_InToaXuatVien : Page
{
    string idPhieuhuy = "";
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
            idPhieuhuy = Request.QueryString["IdKhamBenh"].ToString();
            load();
    }
    void load()
    {
        if (Request.QueryString["IsToaRV"] != null)
            spTieuDeToaThuoc.InnerText = "Toa Thuốc Ra Viện";
        crystalReport = new ReportDocument();
        string ReportSourceName = "nvk_ToaThuocRaVien";
        crystalReport.Load(Server.MapPath("../noitru_BaoCao/Report/" + ReportSourceName + ".rpt"));
        DataTable dtsrc = nvk_LoadToaXuatVien();
        if (dtsrc.Rows.Count < 1) return;
        dtsrc.TableName = "SP_rpintoathuoc;1";
        DataSet ds = new DataSet();
        ds.Tables.Add(dtsrc);

        #region thông tin công ty not use 
        string sqlSelectCompanyInfor = "SELECT  top 1 * from TieuDeCty";
        DataTable dtCompanyInfor = DataAcess.Connect.GetTable(sqlSelectCompanyInfor);
        string tieude = dtCompanyInfor.Rows[0]["Ten_Cty"].ToString();
        string[] slp = tieude.Split('-');
        string til = slp[0];
        string subtil = (  slp.Length>1 ?  slp[1] :"");
        if(StaticData.LoaiToaThuoc=="1")
                    ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtSubtitle"]).Text = subtil;
        dtCompanyInfor.TableName = "command";
        ds.Tables.Add(dtCompanyInfor);
        #endregion
        DataTable nvk_dtInfo = loadThongtTinParamerter();

        #region ma vach
        string mabenhnhan = nvk_dtInfo.Rows[0]["mabenhnhan"].ToString();
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
            dtmavach.Columns.Add("mavach", arrByte.GetType());
            R["mavach"] = arrByte;
            dtmavach.Rows.Add(R);
        }
        dtmavach.TableName = "command_1";
        ds.Tables.Add(dtmavach);
        #endregion

        crystalReport.SetDataSource(ds);
        #region set parameter
        string ngaybatdau = nvk_dtInfo.Rows[0]["bhTu"].ToString();//String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["ngaybatdau"].ToString());
        string ngaykethuc = nvk_dtInfo.Rows[0]["bhDen"].ToString();//String.Format("{0:dd/MM/yyyy}", dt.Rows[0]["ngayhethan"].ToString());
        #region thông tin Bảo Hiểm
        string bhyt1 = "";
        string bhyt2 = "";
        string bhyt3 = "";
        string bhyt4 = "";
        string bhyt5 = "";
        string bhyt6 = "";
        string nvk_SoBH = nvk_dtInfo.Rows[0]["sobhyt"].ToString().Trim();
        if (ngaybatdau == "" || ngaykethuc == "" || nvk_SoBH.Equals("") || nvk_SoBH.Equals("0"))
        {
            crystalReport.SetParameterValue("txtThoiHanThe", "");
        }
        else
        {
            crystalReport.SetParameterValue("txtThoiHanThe", "" + ngaybatdau + "  đến  " + ngaykethuc);
            //string nvk_SoBH = nvk_TachChuoiBHYT_in(dt.Rows[0]["sobhyt"].ToString());
            bhyt1 = nvk_SoBH.Substring(0, 2);
            bhyt2 = nvk_SoBH.Substring(2, 1);
            bhyt3 = nvk_SoBH.Substring(3, 2);
            bhyt4 = nvk_SoBH.Substring(5, 2);
            bhyt5 = nvk_SoBH.Substring(7, 3);
            bhyt6 = nvk_SoBH.Substring(10, 5);
        }
        crystalReport.SetParameterValue("@bh1", bhyt1);
        crystalReport.SetParameterValue("@bh2", bhyt2);
        crystalReport.SetParameterValue("@bh3", bhyt3);
        crystalReport.SetParameterValue("@bh4", bhyt4);
        crystalReport.SetParameterValue("@bh5", bhyt5);
        crystalReport.SetParameterValue("@bh6", bhyt6);
         #endregion

        crystalReport.SetParameterValue("@nvk_khoaPhong", nvk_dtInfo.Rows[0]["TenKhoa_Phong"].ToString());
        crystalReport.SetParameterValue("@SoPhieu", nvk_dtInfo.Rows[0]["matoathuoc"].ToString());
        crystalReport.SetParameterValue("@nvk_doituong", nvk_dtInfo.Rows[0]["nvk_doituong"].ToString());
        crystalReport.SetParameterValue("@nvk_tenbenhnhan", nvk_dtInfo.Rows[0]["tenbenhnhan"].ToString());
        crystalReport.SetParameterValue("@nvk_mabenhnhan", nvk_dtInfo.Rows[0]["mabenhnhan"].ToString());
        crystalReport.SetParameterValue("@nvk_diachi", nvk_dtInfo.Rows[0]["diachi"].ToString());
        crystalReport.SetParameterValue("@nvk_dienthoai", nvk_dtInfo.Rows[0]["dienthoai"].ToString());
        crystalReport.SetParameterValue("@nvk_tuoi", nvk_dtInfo.Rows[0]["TuoiBN"].ToString());
        crystalReport.SetParameterValue("@nvk_gioi", nvk_dtInfo.Rows[0]["gioitinh"].ToString());

        crystalReport.SetParameterValue("@nvk_noiDkKcbBd", nvk_dtInfo.Rows[0]["nvk_noiDkKcbBd"].ToString());
        string nvk_chanDoan = nvk_dtInfo.Rows[0]["ChanDoan"].ToString();
        if (!nvk_dtInfo.Rows[0]["listMaCD"].ToString().Trim().Equals(""))
            nvk_chanDoan += " (" + nvk_dtInfo.Rows[0]["listMaCD"].ToString().Trim() + ")";
        crystalReport.SetParameterValue("@nvk_chanDoan", nvk_chanDoan);
        string strMach_ha = "";//nvk_dtInfo.Rows[0]["nvk_Mach_huyetAp"].ToString();
        crystalReport.SetParameterValue("@strMach_huyetAp", strMach_ha);
        crystalReport.SetParameterValue("@nvk_loiDan", nvk_dtInfo.Rows[0]["nvk_loiDan"].ToString());
        crystalReport.SetParameterValue("@nvk_tenbacsi", nvk_dtInfo.Rows[0]["tenbacsi"].ToString());
        crystalReport.SetParameterValue("NgayTaiKham", nvk_dtInfo.Rows[0]["NgayTaiKhamHen"].ToString());
        #endregion

        #region parameter in IF
        #endregion

        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind(); 
    }
    
    private DataTable nvk_LoadToaXuatVien()
    {
        string nvk_sql = @"
select t.tenthuoc,donvitinh=dvt.tendvt,ct.soluongke
,ketluan= case when isnull(t.congthuc,'')<>'' then '('+ t.congthuc + ')' else '' end
,ghichu1 =  DBO.KB_GetGhiChuToaThuoc2(ct.Idchitietbenhnhantoathuoc)
,ghichu = convert(varchar,isnull(ct.tenNgayDung,'')) +' '+ convert(varchar,isnull(ct.ngayuong,0)) +N' lần, mỗi lần '+ 
    convert(varchar,isnull(ct.moilanuong,0)) +' '+convert(varchar,isnull(dvt.tendvt,''))+' ' +DBO.KB_GetGhiChuToaThuoc2(ct.Idchitietbenhnhantoathuoc)
 from chitietbenhnhantoathuoc ct
inner join thuoc t on t.idthuoc =ct.idthuoc
left join thuoc_donvitinh dvt on dvt.id=t.iddvt
where ct.idkhambenh='"+idPhieuhuy+"'";
        DataTable dt = DataAcess.Connect.GetTable(nvk_sql);
        return dt;
    }
    private DataTable loadThongtTinParamerter()
    {
        string sql = string.Format(@"select stuff(a, len(a),1,'') mota
                                        from (select 
                                        (select isnull(icd.mota+',','')
                                        from chandoanphoihop ph
                                        left join chandoanicd icd on ph.idicd=icd.idicd
                                        left join benhnhantoathuoc tt on ph.idkhambenh=tt.idkhambenh
                                        where tt.idbenhnhantoathuoc={0} for xml path('')) as a) as abc", idPhieuhuy);
        string nvk_s = @"
        SELECT bnbh.ngaybatdau,bnbh.ngayhethan ,bhTu=convert(varchar(10),bnbh.ngaybatdau,103),bhDen=convert(varchar(10),bnbh.ngayhethan,103),nvk_noiDkKcbBd=ndk.tennoidangky
	        ,b.tenbenhnhan,b.mabenhnhan,b.sobhyt,gioitinh=dbo.getgioitinh(b.gioitinh),nghenghiep=nn.tennghenghiep,b.diachi,dantoc=dt.tendantoc,TuoiBN=DBO.KB_Tuoi(B.NgaySinh),dienthoai=b.dienthoai
            ,TenKhoa_Phong=isnull(tenphongkhambenh,'')+ isnull((select top 1 ' - '+ tenphong from kb_phong p inner join benhnhannoitru nt on nt.idphongnoitru=p.id and idkhoanoitru =kb.idphongkhambenh order by ngayvaovien desc),'')
            ,ChanDoan=dbo.[nvk_ListMoTaChanDoan_1KhamBenh]('"+idPhieuhuy+"'),listMaCD=dbo.[nvk_ListMaChanDoan_1KhamBenh]('"+idPhieuhuy+@"')
            ,bs.tenbacsi,nvk_loiDan=kb.dando
            ,nvk_Mach_huyetAp= case when isnull((select top 1 idsinhhieu from sinhhieu where idchitietdangkykham =kb.idchitietdangkykham),0)<>0
then N'Mạch : '+isnull((select top 1 convert(nvarchar,mach) from sinhhieu where idchitietdangkykham =kb.idchitietdangkykham order by ngaydo desc),'    ') +N' lần/phút, huyết áp: '
+isnull((select top 1 convert(nvarchar,huyetap1) from sinhhieu where idchitietdangkykham =kb.idchitietdangkykham order by ngaydo desc),'    ')+'/'+isnull((select top 1 convert(nvarchar,huyetap2) from sinhhieu where idchitietdangkykham =kb.idchitietdangkykham order by ngaydo desc),'    ')+N'  mmHg.'
else N'Mạch :........lần/phút, huyết áp: ......../........ mmHg.' end
            ,NgayTaiKham=case when ngayhentaikham is null then N'Tái khám ngày :......../......../20......nhớ mang theo đơn thuốc'
else N'Tái khám ngày : '+convert(nvarchar,day(ngayhentaikham))+'/'+convert(nvarchar,month(ngayhentaikham))+'/'+convert(nvarchar,year(ngayhentaikham))+N'  nhớ mang theo đơn thuốc' end
            ,NgayTaiKhamHen= case when (select top 1 NgayHenTaiKham from nvk_hentaikham where idKhamBenhHenTK=KB.IDKHAMBENH) is null  then N'Tái khám ngày :......../......../20......nhớ mang theo đơn thuốc'
else N'Tái khám ngày : '+convert(nvarchar,day((select top 1 NgayHenTaiKham from nvk_hentaikham where idKhamBenhHenTK=KB.IDKHAMBENH)))
+'/'+convert(nvarchar,month((select top 1 NgayHenTaiKham from nvk_hentaikham where idKhamBenhHenTK=KB.IDKHAMBENH)))
+'/'+convert(nvarchar,year((select top 1 NgayHenTaiKham from nvk_hentaikham where idKhamBenhHenTK=KB.IDKHAMBENH)))+N'  nhớ mang theo đơn thuốc' end

            ,nvk_doituong=case when b.loai=1 then N'BHYT' else N'Dịch vụ' end
            ,matoathuoc=isnull((select top 1 matoathuoc from benhnhantoathuoc where idkhambenh =kb.idkhambenh),'')
        FROM KHAMBENH kb inner JOIN BENHNHAN B ON kb.IdBenhNhan=B.IdBenhNhan
	         inner JOIN PhongKhamBenh C on kb.IDPHONGKHAMBENH=C.idphongkhambenh
	         LEFT JOIN CHANDOANICD CD ON kb.KETLUAN=CD.IDICD
             left join chitietdangkykham ctdk on kb.idchitietdangkykham=ctdk.idchitietdangkykham
           left join dangkykham dk on dk.iddangkykham=ctdk.iddangkykham
           left join benhnhan_bhyt bnbh on bnbh.idbenhnhan_bh=dk.idbenhnhan_bh
			left join KB_NOIDANGKYKB ndk on ndk.IDNOIDANGKY= bnbh.IdNoiDangKyBH
        left join nghenghiep nn on convert(varchar,nn.idnghenghiep)= b.nghenghiep
        left join dantoc dt on convert(varchar,dt.id)= b.dantoc
        left join bacsi bs ON kb.idbacsi = bs.idbacsi 
         Where kb.IDKHAMBENH='" + idPhieuhuy + "'";
        DataTable dt = DataAcess.Connect.GetTable(nvk_s);
        return dt;
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }

    protected void form_unload(object sender, EventArgs e)
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
        this.Unload += new EventHandler(form_unload);
    }
    #endregion
}



