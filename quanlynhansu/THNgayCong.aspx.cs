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
using System.Data.SqlClient;
public partial class THNgayCong :Page
{
    clsTHNgayCong THNC = null;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            pnl1.Visible = false;
            loadBangTHNgayCong();
            BindListNam();
            BindListThang();
            BindListPhongBan();
            ddlThang.SelectedValue = DateTime.Now.Month.ToString();
            ddlNam.SelectedValue = DateTime.Now.Year.ToString();
        }
    }
    private void BindListNam()
    {

        for (int i = 2011; i <= StaticData.NamGioiHan; i++)
        {
            ddlNam.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    private void BindListThang()
    {

        for (int i = 1; i <= 12; i++)
        {
            ddlThang.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    private void loadBangTHNgayCong()
    {
        int thang =0;
        int nam = 0;
        string phongban = "";
        if (ddlThang.SelectedIndex > -1)
            thang = StaticData.ParseInt(ddlThang.SelectedValue);
        if (ddlNam.SelectedIndex > -1)
            nam = StaticData.ParseInt(ddlNam.SelectedValue);
        if(ddlPhong.SelectedValue.ToString()!="0")
        {
            phongban= "   and pb.idphongban='"+ddlPhong.SelectedValue+"'";
        }
        if (ddlLoaiNV.SelectedValue.ToString() != "-1")
        {
            phongban += "   and nv.LoaiNhanVien='" + ddlLoaiNV.SelectedValue+"'";
        }
            string sql = ""
                 + " select STT=row_number() over (order by abc.tennhanvien), abc.* from" + "\r\n"
                + "   (" + "\r\n"
                + "   select DISTINCT " + "\r\n"
                + "                    tennhanvien" + "\r\n"
                + "   ,ngayvao=hd.ngaybatdau,luongcoban=hd.mucluongcoban" + "\r\n"
                + "   ,soGioThang=hd.giolam" + "\r\n"
                + "   ,NgayThuong=(select count(ngaythuong) from bangchamcongtheongay where idnhanvien=nv.idnhanvien and ngaythuong=1 and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")" + "\r\n"
                + "   ,NgayTruc=(select count(ngaytruc) from bangchamcongtheongay where ngaytruc=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")" + "\r\n"
                + "   ,LuongCBGio=hd.luongCB +'/'+convert(varchar,hd.HeSoLCB) " + "\r\n"
                + "   ,SoNgayPC=[dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
                + "   ,SoNgayPK=[dbo].[GetSoNgayNhanVienPhepKhongLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
              + "   ,NgayNuaBuoi=(select count(LamThemNuaNgay) from bangchamcongtheongay where LamThemNuaNgay=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + " )" + "\r\n"
                + "   ,LamThemMotNgay=(select count(LamThemMotNgay) from bangchamcongtheongay where LamThemMotNgay=1 and idnhanvien=nv.idnhanvien)  " + "\r\n"
                + "   ,NghiBu=(select count(NghiBu) from bangchamcongtheongay where NghiBu=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")  " + "\r\n"
                + "   ,NghiOm=(select count(NghiOm) from bangchamcongtheongay where NghiOm=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")  " + "\r\n"
                + "   ,NghiLe=(select count(NghiLe) from bangchamcongtheongay where NghiLe=1 and idnhanvien=nv.idnhanvien and Month(ngaycong)=" + thang.ToString() + " and year(ngaycong)=" + nam.ToString() + ")  " + "\r\n"
                + "   ,NgoaiGio=[dbo].[NS_SoGioLamNgoaiGio] (nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
                + "   ,LuongMotNgay=[dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
               + "   ,PhepNam=12  - [dbo].[GetSoNgayNhanVienPhepKhongLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
                + "  ,nv.idnhanvien,manhanvien" + "\r\n"
                + "     from NhanVien NV left join bangchamcongtheongay c on c.idnhanvien=nv.idnhanvien " + "\r\n"
                + "   inner join hopdong hd on hd.idnhanvien=nv.idnhanvien" + "\r\n"
                + "   inner join phongban pb on nv.idphongban=pb.idphongban" + "\r\n"
                + "   where hd.status=1 and nv.status=1 and Month(c.ngaycong)=" + thang.ToString() + " and year(c.ngaycong)=" + nam.ToString() + "" + "\r\n"
                + "   "+phongban+"" + "\r\n"
                + "   ) abc" + "\r\n"
                + " " + "\r\n";
      DataTable dt = DataAcess.Connect.GetTable(sql);
      dgr.DataSource = dt;
      dgr.DataBind();
    }
    private void BindListPhongBan()
    {
        string idnd = SysParameter.UserLogin.UserID(this);
        string sql = "";
        if (idnd != null && idnd != "0")
        {
            if (SysParameter.UserLogin.GroupID(this) != null && SysParameter.UserLogin.GroupID(this) != "4" && SysParameter.UserLogin.GroupID(this) != "16")
            {
                sql = ""
                + " select a.* from phongban a " + "\r\n"
                + " left join nhanvien b on b.idphongban = a.idphongban " + "\r\n"
                + " left join nguoidung c on c.idnhanvien=b.idnhanvien" + "\r\n"
                + " where a.status=1 and c.idnguoidung=" + idnd + " ORder by tenphongban" + "\r\n"
                + " " + "\r\n";
            }
            else
            {
                sql = "select * from phongban where status=1 ORder by tenphongban";
            }
        }
        else
        {
            sql = "select * from phongban where status=1 ORder by tenphongban";
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count >= 0)
        {
            StaticData.FillCombo(ddlPhong, dt, "idphongban", "tenphongban", "------Chọn phòng ban------");
            if (ddlPhong.Items.Count > 1)
            {
                ddlPhong.SelectedIndex = 1;
            }
        }

    }
    protected void btnLuuPhuCap_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Response.Redirect("PhuCapDocHai.aspx");
    }
    protected void ddlPhongBan_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btnGetDanhSach_Click(object sender, EventArgs e)
    {
        loadBangTHNgayCong();
    }
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
      

    }
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
       int thang = StaticData.ParseInt(ddlThang.SelectedValue);
        int nam = StaticData.ParseInt(ddlNam.SelectedValue);
        THNC = new clsTHNgayCong();
        THNC.thang = thang.ToString();
        THNC.nam = nam.ToString();
        //THNC.
        THNC.phongban = ddlPhong.SelectedValue.ToString();
        THNC.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(THNC_AfterExportToExcel);
        THNC.ExportToExcel();
    }
    void THNC_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" +THNC.OutputFileName + "\",'_blank')</script>");
    }
}
