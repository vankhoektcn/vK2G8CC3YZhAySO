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


/// <summary>
/// Date : 05/09/2011
/// TRUONGNHAT -PC 
/// hutech.nhattruong@gmail.com
/// </summary>
public partial class rptXetNghiem_new : Genaratepage
{
    public string idphieutt;
    ReportDocument R;
    private string madangkls = "";
    private string idDV = "";
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            madangkls = Request.QueryString["madangkycls"].ToString();
            idDV = Request.QueryString["idDichVu"].ToString().TrimEnd(',');
        }
        catch
        {
            return;
        }
        getReport();

    }
    private DataTable loadBN()
    {
        string swhere = "";
        if (madangkls != "")
        {
            swhere = " where kq.madangkycls='" + madangkls + "'";
        }
        else if (idDV != "")
        {
            swhere = " where ct.idchitietdichvu in (" + idDV + ")";
        }
        string sqlBN = @"select DISTINCT TenBenhNhan,GioiTinh=dbo.GetGioiTinh(bn.gioitinh),
                    NamSinh=dbo.GetNamSinh(bn.ngaysinh),bn.DienThoai,kq.madangkycls MaDKCLS
                    , BSChiDinh= case when tenBSChiDinh like N'%Chọn bác sĩ %' then '' else tenBSChiDinh end
                    ,kbcls.chandoansobo ChanDoan,
                    kbcls.ngaythu ngaycls,ngcls=day(kbcls.ngaythu),tcls=month(kbcls.ngaythu),ncls=year(kbcls.ngaythu)
                    ,BSCLS=(SELECT TOP 1 bs.tenbacsi
				                    FROM ketqua_canlamsangchitiet ct
				                    LEFT JOIN BACSI bs ON bs.IDBACSI=CT.IDBBSCLS 
				                    WHERE kq.idketqua_canlamsang=ct.idketqua_canlamsang)
                    from ketqua_canlamsang kq
                    left join ketqua_canlamsangchitiet ct on ct.idketqua_canlamsang=kq.idketqua_canlamsang
                    left join khambenhcanlamsan kbcls on kbcls.madangkycls=kq.madangkycls
                    --left join bacsi bs on bs.idbacsi=kbcls.idbacsi                    
                    left join benhnhan bn on bn.idbenhnhan=kbcls.idbenhnhan" + swhere;

        DataTable dtBN = null;
        dtBN = DataAcess.Connect.GetTable(sqlBN);
        return dtBN;
    }
    private DataTable loadDichVu()
    {
        string swhere = "";
        if (madangkls != "" && idDV == "")
        {
            swhere = " WHERE KQ_CLS.MADANGKYCLS='" + madangkls + "'";
        }
        else if (idDV != "")
        {
            swhere = " where CLS_CT.idchitietdichvu in (" + idDV + ") and KQ_CLS.MADANGKYCLS='" + madangkls + "'";
        }
        string sqlDV = @"SELECT KQ_CLS.madangkycls MaDKCLS, BatThuong=CLS_CT.isBatThuong,DV.IDBANGGIADICHVU,DV.TENNHOM,DV.TENDICHVU,CLS_CT.KETQUA,GIATRIBT=CLS_CT.GIATRIBINHTHUONG,DV_CT.DONVI,
                    TENCHITIET,DV_CT.tennhom NhomCT,
                    SLCT= ISNULL(NULLIF( (SELECT COUNT(c.idchitietdichvu) FROM chitietdichvu c WHERE c.idbanggiadichvu=dv.idbanggiadichvu),0),1)
                    FROM ketqua_canlamsangchitiet CLS_CT
                    LEFT JOIN ketqua_canlamsang KQ_CLS ON CLS_CT.IDKETQUA_CANLAMSANG=KQ_CLS.IDKETQUA_CANLAMSANG
                    LEFT JOIN BANGGIADICHVU DV ON DV.IDBANGGIADICHVU=CLS_CT.IDBANGGIADICHVU
                    LEFT JOIN CHITIETDICHVU DV_CT ON DV_CT.IDCHITIETDICHVU=CLS_CT.IDCHITIETDICHVU" + swhere + "order by dv.tennhom,dv_ct.stt";
        //bo order dv.stt

        DataTable dtDV = null;
        dtDV = DataAcess.Connect.GetTable(sqlDV);
        return dtDV;
    }
    private void getReport()
    {
        R = new ReportDocument();
        string TenReport = "rptXetNghiem";
        string istieude = Request.QueryString["tieude"];
        if (istieude == "Y")
            TenReport = "rptXetNghiemTieuDe";
        DataSet ds = new DataSet();
        R.Load(Server.MapPath(TenReport + ".rpt"));
        if (TenReport == "rptXetNghiemTieuDe")
        {
            #region Report tiêu đề

            DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
            if (dtTieuDeCty != null)
            {
                R.OpenSubreport("subTieuDe").SetDataSource(dtTieuDeCty);
                ((TextObject)R.OpenSubreport("subTieuDe").ReportDefinition.ReportObjects["Text1"]).Text = dtTieuDeCty.Rows[0]["ten_cty"].ToString().ToUpper();
            }
            #endregion  
        }
        DataTable dtBN = loadBN();      
        dtBN.TableName = "dtXetNghiem_BN";
        ds.Tables.Add(dtBN);
        R.SetDataSource(dtBN);
        DataTable dtDV = loadDichVu();
        dtDV.TableName = "dtXetNghiem";
        ds.Tables.Add(dtDV);
        R.Subreports["subKQXetNghiem.rpt"].SetDataSource(dtDV);
        ((TextObject)(R.Subreports["subKQXetNghiem.rpt"].ReportDefinition.ReportObjects["NgayCLS"])).Text = "Ngày " + dtBN.Rows[0]["ngcls"] + " tháng " + dtBN.Rows[0]["tcls"] + " năm " + dtBN.Rows[0]["ncls"] + "";
        ((TextObject)(R.Subreports["subKQXetNghiem.rpt"].ReportDefinition.ReportObjects["BacSiCLS"])).Text = "Nguyễn Trương Quỳnh Nga";//dtBN.Rows[0]["BSCLS"].ToString();
      
        CrystalReportViewer1.ReportSource = R;
        CrystalReportViewer1.DataBind(); 
       
    }
    protected void report_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }
    #region khoi tao va giai phong bo nho
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }
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
