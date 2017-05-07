using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
// for mavach
using iTextSharp.text.pdf;
using System.Drawing;
using System.ComponentModel;

public partial class noitru_BaoCao_TT_rptDanhsachhaophi : System.Web.UI.Page
{

    private ReportDocument R;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
            String txttieude = "Danh sách hao phí bệnh nhân";
            String khoa = "Nội-Ngoại tổng quát";
            String Sophieu = "";
            String ngay = DateTime.Now.Day.ToString();
            String thang = DateTime.Now.Month.ToString();
            String nam = DateTime.Now.Year.ToString();
            string idkhoa = "0";
            int idctdkk = 0;
            if (Request.QueryString["idctdkk"] != null)
            {
                idctdkk = Convert.ToInt32(Request.QueryString["idctdkk"].ToString());

            }
            if (Request.QueryString["idkhoa"] != null)
            {
                idkhoa = Request.QueryString["idkhoa"].ToString();
            }
            if (idkhoa != "0" && idctdkk != 0)
            {
                //load report
                string sqlBN = @"select tenbenhnhan, diachi,ngaysinh ,tenkhoa=(select isnull((select tenphongkhambenh from phongkhambenh where idphongkhambenh='"+idkhoa+@"'),''))
,ngayvaovien=(select top 1 convert(varchar(10),ngayvaovien,103)+' '+ convert(varchar(10),ngayvaovien,108) from benhnhannoitru where idchitietdangkykham ='"+idctdkk+@"' order by ngayvaovien asc)
,ngayravien=convert(varchar(10),getdate(),103)+' '+ convert(varchar(10),getdate(),108)
,chandoan=(select '('+MaICD +') '+ MoTa from chandoanicd cd inner join khambenh kb on kb.ketluan=cd.idicd and kb.idkhambenh = 
	(select top 1 idkhambenh from khambenh where idchitietdangkykham ='"+idctdkk+@"' and ketluan >0 order by ngaykham desc)
)
from benhnhan where idbenhnhan =isnull((select top 1 idbenhnhan from khambenh where idchitietdangkykham ='"+idctdkk+@"'),0)
";
                DataTable dtBN = DataAcess.Connect.GetTable(sqlBN);
                R = new ReportDocument();
                R.Load(Server.MapPath("Report/rptdanhmucvattutieuhao.rpt"));

                DataTable dtThuoc = LoadDtDetail(idkhoa.ToString(),idctdkk.ToString());
                if (dtThuoc.Rows.Count == 0)
                {
                    //StaticData.MsgBox(this,"Bệnh nhân này không có Hao phí !");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "dffd", "ClosePage();", true);
                    return;
                }

                #region ma vach

                string mabenhnhan = dtThuoc.Rows[0]["mabenhnhan"].ToString();
                Barcode128 barcode = new Barcode128();
                barcode.ChecksumText = false;
                barcode.Code = mabenhnhan;
                Image bmp = barcode.CreateDrawingImage(Color.Black, Color.White);
                Byte[] arrByte = (Byte[])TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
                for(int i=0;i<dtThuoc.Rows.Count;i++)
                    dtThuoc.Rows[i]["logo"] = arrByte;

                #endregion

                R.SetDataSource(dtThuoc);

                #region parameter
                khoa = dtBN.Rows[0]["tenkhoa"].ToString();
                R.SetParameterValue("txtheader", txttieude);
                R.SetParameterValue("@tenbenhnhan", dtBN.Rows[0]["tenbenhnhan"].ToString());
                R.SetParameterValue("@ngaysinh", dtBN.Rows[0]["ngaysinh"].ToString());
                R.SetParameterValue("@diachi", dtBN.Rows[0]["diachi"].ToString());
                
                R.SetParameterValue("khoa", khoa);
                R.SetParameterValue("ngay", ngay);
                R.SetParameterValue("thang", thang);
                R.SetParameterValue("nam", nam);
                R.SetParameterValue("sophieu", Sophieu);
                R.SetParameterValue("@NgayVaoVien", dtBN.Rows[0]["ngayvaovien"].ToString());
                R.SetParameterValue("@NgayRaVien", dtBN.Rows[0]["ngayravien"].ToString());
                R.SetParameterValue("@ChanDoan", dtBN.Rows[0]["chandoan"].ToString());
                //R.SetParameterValue("@idkhoa", idkhoa);
                #region nvk tính tổng tiền
                double tongtien = 0;
                for (int i = 0; i < dtThuoc.Rows.Count; i++)
                {
                    tongtien += Double.Parse(dtThuoc.Rows[i]["ngaysinh"].ToString());
                }
                #endregion
                R.SetParameterValue("@nvk_TongTien", StaticData.FormatNumberOption(tongtien,",",".",false));
                #endregion
                CrystalReportViewer1.ReportSource = R;
                CrystalReportViewer1.DataBind();

            }
        //}
    }
    private DataTable LoadDtDetail(string idkhoa,string idctdkkham)
    {
        string sql = @"
                select *,sotien= round(ngaysinh1,0),ngaysinh= round(ngaysinh1,0),logo= convert(image,''),logo1 =(select top 1 logo_Image from TieuDeCty) from 
                (
                select tenbenhnhan=convert(nvarchar(20),isnull(sum(ctx.soluong),sum(soluongke))),bn.mabenhnhan,bn.diachi, tt.idthuoc
                ,tenkho=case when k.nvk_loaikho=2 then k.tenkho else k2.tenkho end
                ,t.tenthuoc,convert(nvarchar(20),isnull(sum(ctx.soluong),sum(soluongke))) as soluong,dongia=isnull(ctx.dongia,0)
--                    ,ngaysinh=isnull(sum(ctx.soluong),sum(soluongke)) * isnull(ctx.dongia,0),donvitinh=dvt.tendvt
                    ,ngaysinh1= isnull(sum(ctx.soluong),sum(soluongke)) * isnull(ctx.dongia,0) + (isnull(sum(ctx.soluong),sum(soluongke)) * isnull(ctx.dongia,0))* ctx.vat/100
                from khambenh kb inner join chitietbenhnhantoathuoc tt on tt.idkhambenh =kb.idkhambenh
				                inner join thuoc t on t.idthuoc = tt.idthuoc
				                left join  thuoc_donvitinh dvt on dvt.id=t.iddvt
				                inner join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan
                            inner join chitietphieuxuatkho ctx on ctx.idchitietbenhnhantoathuoc=tt.idchitietbenhnhantoathuoc
			                inner join PHIEUXUATKHO px on px.idphieuxuat= ctx.idphieuxuat
                                left join khothuoc k on px.idkho=k.idkho
                                left join khothuoc k2 on px.idkho2=k2.idkho
                where kb.idchitietdangkykham ='" + idctdkkham + @"' and kb.idphongkhambenh ='" + idkhoa + @"' and isnull(tt.isHaoPhi,0)=1
                 and (k.nvk_loaikho=2 or k2.nvk_loaikho=3)
                group by bn.tenbenhnhan,bn.mabenhnhan,bn.diachi,bn.ngaysinh, tt.idthuoc,k.nvk_loaikho,k.TenKho,k2.TenKho,t.tenthuoc,dvt.tendvt,ctx.dongia,ctx.vat--,logo,logo1
				having  isnull(sum(ctx.soluong),sum(soluongke))>0
                ) as nvk
                ";
        DataTable table = DataAcess.Connect.GetTable(sql);
        return table;
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }
}
