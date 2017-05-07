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

public partial class quanlynhansu_inHopDong : System.Web.UI.Page
{
    string strIdHopDong = "";   
    ReportDocument crystalReport;  
    protected void Page_Load(object sender, EventArgs e)
    {
        crystalReport = new ReportDocument();
        if (Request.QueryString["idHopDong"] != null && Request.QueryString["idHopDong"].ToString()!="")
            strIdHopDong = Request.QueryString["idHopDong"];
        bindReport();
    }
    void bindReport()
    {       
        crystalReport.Load(Server.MapPath("report/crptHopDong.rpt"));
        string sql = ""
        + " select tendonvi=(select tendonvi from congty)" + "\r\n"
        + " 	,giamdoc=(select tennhanvien from nhanvien where idchucvu=1)" + "\r\n"
        + " 	,quoctichgiamdoc=(select tenquoctich from nhanvien nv left join quoctich qt on qt.idquoctich=nv.quoctich where idchucvu=1)" + "\r\n"
        + " 	,chucvu=(select tenchucvu from chucvu where idchucvu=1)" + "\r\n"
        + " 	,daidiencho=(select tendonvi from congty)" + "\r\n"
        + " 	,dienthoaigiamdoc=(select dienthoai from nhanvien where idchucvu=1)" + "\r\n"
        + " 	,nv.tennhanvien,quoctichnhanvien=qt.tenquoctich" + "\r\n"
        + " 	,ngaysinhnv=(datepart(day,nv.ngaysinh)),noisinhnhanvien=nv.noisinh" + "\r\n"
        + " 	,nghenghiepnv=nv.nghenghiep,nv.diachithuongtru" + "\r\n"
        + " 	,cmtNV=nv.cmnd,ngaycapcmtnv=convert(varchar,nv.ngaycapcmnd,103)" + "\r\n"
        + " 	,noicapcmtnv=nv.noicapcmnd,solaodongnv=nv.solaodong" + "\r\n"
        + " 	,ngaycapsld=convert(varchar,nv.ngaycapsld,103),nv.noicapsld" + "\r\n"
        + " 	,ngaybdhopdong=convert(varchar,hd.ngaybatdau,103),ngaykthopdong=convert(varchar,hd.ngayketthuc,103)" + "\r\n"
        + " 	,ngaybdthuviec=convert(varchar,hd.thuviectungay,103),ngayktthuviec=convert(varchar,hd.thuviecdenngay,103)" + "\r\n"
        + " 	,hd.diadiemlamviec,chucdanhchuyenmon=hd.chuyenmon" + "\r\n"
        + " 	,chucvuhopdong=cv.tenchucvu,congviechopdong=hd.motacongviec" + "\r\n"
        + " 	,thoigiolamviec=(select thoigiolamviec from congty)" + "\r\n"
        + " 	,hd.dungculamviec,nv.phuongtiendilai" + "\r\n"
        + " 	,luonghopdong=hd.mucluongcoban" + "\r\n"
        + " 	,hinhthuctraluong=(select hinhthuctraluong from congty)" + "\r\n"
        + " 	,ngaytraluong=(select ngaytraluong from congty)" + "\r\n"
        + " 	,chedonangluong=(select top 1 chedonangluong from congty)" + "\r\n"
        + " 	,trangbibaoholaodong=(select top 1 baoholaodong from congty)" + "\r\n"
        + " 	,chedodaotao=(select top 1 chedodaotao from congty)" + "\r\n"
        + " 	,thoathuankhac=(select top 1 thoathuankhac from congty)" + "\r\n"
        + " 	,ngayhieuluc=convert(varchar,hd.ngaybatdau,103)" + "\r\n"
        + " 	,diadiemhopdong=hd.noiky" + "\r\n"
        + " 	,ngayhopdong=convert(varchar,hd.ngayky,103)" + "\r\n"
        + " 	,diachigiamdoc=(select diachitamtru from nhanvien where idchucvu=1)" + "\r\n"
        + " 	,thangsinhnv=(datepart(Month,nv.ngaysinh))" + "\r\n"
        + " 	,namsinhnv=(datepart(year,nv.ngaysinh))" + "\r\n"
        + " 	,chedonghingoi=(select top 1 chedonghingoi from congty)" + "\r\n"
        + " 	,baohiemyte=(select top 1 baohiemyte from congty)" + "\r\n"
        + " from hopdong hd " + "\r\n"
        + " left join nhanvien nv on hd.idnhanvien=nv.idnhanvien" + "\r\n"
        + " left join quoctich qt on qt.idquoctich=nv.quoctich" + "\r\n"
        + " left join chucvu cv on cv.idchucvu=nv.idchucvu" + "\r\n"
        + " where hd.idhopdong="+strIdHopDong + "\r\n"
        + " " + "\r\n";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        CrystalReportViewer1.ReportSource = crystalReport;
        CrystalReportViewer1.DataBind();
        crystalReport.SetParameterValue("tendonvi",tb.Rows[0]["tendonvi"].ToString());
        crystalReport.SetParameterValue("giamdoc", tb.Rows[0]["giamdoc"].ToString());
        crystalReport.SetParameterValue("quoctichgiamdoc", tb.Rows[0]["quoctichgiamdoc"].ToString());
        crystalReport.SetParameterValue("daidiencho", tb.Rows[0]["daidiencho"].ToString());
        crystalReport.SetParameterValue("dienthoaigiamdoc", tb.Rows[0]["dienthoaigiamdoc"].ToString());
        crystalReport.SetParameterValue("tennhanvien", tb.Rows[0]["tennhanvien"].ToString());
        crystalReport.SetParameterValue("quoctichnhanvien", tb.Rows[0]["quoctichnhanvien"].ToString());
        crystalReport.SetParameterValue("ngaysinhnv", tb.Rows[0]["ngaysinhnv"].ToString());
        crystalReport.SetParameterValue("noisinhnhanvien", tb.Rows[0]["noisinhnhanvien"].ToString());
        crystalReport.SetParameterValue("nghenghiepnv", tb.Rows[0]["nghenghiepnv"].ToString());
        crystalReport.SetParameterValue("diachithuongtru", tb.Rows[0]["diachithuongtru"].ToString());
        crystalReport.SetParameterValue("cmtNV", tb.Rows[0]["cmtNV"].ToString());
        crystalReport.SetParameterValue("ngaycapcmtnv", tb.Rows[0]["ngaycapcmtnv"].ToString());
        crystalReport.SetParameterValue("noicapcmtnv", tb.Rows[0]["solaodongnv"].ToString());
        crystalReport.SetParameterValue("ngaycapsld", tb.Rows[0]["ngaycapsld"].ToString());
        crystalReport.SetParameterValue("noicapsld", tb.Rows[0]["noicapsld"].ToString());
        crystalReport.SetParameterValue("ngaybdhopdong", tb.Rows[0]["ngaybdhopdong"].ToString());
        crystalReport.SetParameterValue("ngaykthopdong", tb.Rows[0]["ngaykthopdong"].ToString());
        crystalReport.SetParameterValue("ngaybdthuviec", tb.Rows[0]["ngayktthuviec"].ToString());
        crystalReport.SetParameterValue("chucdanhchuyenmon", tb.Rows[0]["chucdanhchuyenmon"].ToString());
        crystalReport.SetParameterValue("chucvuhopdong", tb.Rows[0]["chucvuhopdong"].ToString());
        crystalReport.SetParameterValue("congviechopdong", tb.Rows[0]["congviechopdong"].ToString());
        crystalReport.SetParameterValue("thoigiolamviec", tb.Rows[0]["thoigiolamviec"].ToString());
        crystalReport.SetParameterValue("dungculamviec", tb.Rows[0]["dungculamviec"].ToString());
        crystalReport.SetParameterValue("luonghopdong", tb.Rows[0]["luonghopdong"].ToString());
        crystalReport.SetParameterValue("hinhthuctraluong", tb.Rows[0]["hinhthuctraluong"].ToString());
        crystalReport.SetParameterValue("ngaytraluong", tb.Rows[0]["ngaytraluong"].ToString());
        crystalReport.SetParameterValue("chedonangluong", tb.Rows[0]["chedonangluong"].ToString());
        crystalReport.SetParameterValue("trangbibaoholaodong", tb.Rows[0]["trangbibaoholaodong"].ToString());
        crystalReport.SetParameterValue("chedodaotao", tb.Rows[0]["chedodaotao"].ToString());
        crystalReport.SetParameterValue("thoathuankhac", tb.Rows[0]["thoathuankhac"].ToString());
        crystalReport.SetParameterValue("ngayhieuluc", tb.Rows[0]["ngayhieuluc"].ToString());
        crystalReport.SetParameterValue("diadiemhopdong", tb.Rows[0]["diadiemhopdong"].ToString());
        crystalReport.SetParameterValue("ngayhopdong", tb.Rows[0]["ngayhopdong"].ToString());
        crystalReport.SetParameterValue("tienthuong", "");
        crystalReport.SetParameterValue("so", "");
        crystalReport.SetParameterValue("chucvu", tb.Rows[0]["chucvu"].ToString());
        crystalReport.SetParameterValue("diachigiamdoc", tb.Rows[0]["diachigiamdoc"].ToString());
        crystalReport.SetParameterValue("thangsinhnv", tb.Rows[0]["thangsinhnv"].ToString());
        crystalReport.SetParameterValue("namsinhnv", tb.Rows[0]["namsinhnv"].ToString());
        crystalReport.SetParameterValue("solaodongnv", tb.Rows[0]["solaodongnv"].ToString());
        crystalReport.SetParameterValue("ngayktthuviec", tb.Rows[0]["ngayktthuviec"].ToString());
        crystalReport.SetParameterValue("diadiemlamviec", tb.Rows[0]["diadiemlamviec"].ToString());
        crystalReport.SetParameterValue("phuongtiendilai", tb.Rows[0]["phuongtiendilai"].ToString());
        crystalReport.SetParameterValue("chedonghingoi", tb.Rows[0]["chedonghingoi"].ToString());
        crystalReport.SetParameterValue("baohiemyte", tb.Rows[0]["baohiemyte"].ToString());
        string sqlPhuCap = "select tenphucap from phucap";
        DataTable tbPhuCap = DataAcess.Connect.GetTable(sqlPhuCap);
        string strPhuCapGom = "";
        foreach (DataRow h in tbPhuCap.Rows)
        {
            strPhuCapGom+= h["tenphucap"].ToString()+",";
        }
        crystalReport.SetParameterValue("phucapgom",strPhuCapGom);
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        crystalReport.Clone();
        crystalReport.Dispose();
        CrystalReportViewer1.Dispose();
        GC.Collect();
    }
    protected void form_unload(object sender, EventArgs e)
    {
        crystalReport.Close();
        crystalReport.Dispose();
        crystalReport = null;
        CrystalReportViewer1.Dispose();
        CrystalReportViewer1 = null;
        GC.Collect();
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
