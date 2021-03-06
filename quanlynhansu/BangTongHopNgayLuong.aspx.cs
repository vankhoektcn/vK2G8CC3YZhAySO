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
public partial class BangTongHopNgayLuong : Page
{

    clsBangTongHopNgayLuong THNC;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            BindListPhongBan();
            //BindListNhanVien();
            BindListNam();
            ddlThang.SelectedValue = DateTime.Now.Month.ToString();
            ddlNam.SelectedValue = DateTime.Now.Year.ToString();
            pnl1.Visible = false;
        }
    }
    private void BindListPhongBan()
    {
        string sql = "select * from phongban where status=1 ORder by tenphongban";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlPhongBan, dt, "idphongban", "tenphongban", "------Chọn phòng ban------");
        }
    }
//    private void BindListNhanVien()
//    {
//        string PhongBanIn = "";
//        if (ddlPhongBan.SelectedValue != "0")
//            PhongBanIn = " and nv.idphongban=" + ddlPhongBan.SelectedValue;
//        string sql = @"select nv.idnhanvien,nv.tennhanvien from nhanvien nv
//            where nv.status=1
//            and nv.idnhanvien in (select hd.idnhanvien from hopdong hd
//             where nv.idnhanvien=hd.idnhanvien and hd.status=1) 
//            " + PhongBanIn + @"
//            order by nv.tennhanvien";
//        DataTable dt = DataAcess.Connect.GetTable(sql);
//        if (dt.Rows.Count != 0)
//        {
//            StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "tennhanvien","----Chọn nhân viên----");
//        }
//    }
    private void BindListNam()
    {

        for (int i = 2011; i <= StaticData.NamGioiHan; i++)
        {
            ddlNam.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    
  
    void THNC_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + THNC.OutputFileName + "\",'_blank')</script>");
    }
    protected void btnGetDanhSach_Click(object sender, EventArgs e)
    {
        string filename = "Danh sach phu cap hien vat thang " + txtThangHidden.Value + "/" + txtNamHidden.Value;
        string tcty = "BỆNH VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH PHỤ CẤP HIỆN VẬT THÁNG " + txtThangHidden.Value + "/" + txtNamHidden.Value;
        string strNhanSu = "GĐ.Nhân Sự";
        string thang = ddlThang.SelectedValue;
        string nam = ddlNam.SelectedValue;
        THNC = new clsBangTongHopNgayLuong();
        THNC.thang = thang;
        THNC.nam = nam;
        THNC.phongban = ddlPhongBan.SelectedValue.ToString();
        THNC.LoaiNhanVien = ddlLoaiNV.SelectedValue.ToString();
        THNC.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(THNC_AfterExportToExcel);
        THNC.ExportToExcel();
    }
}
