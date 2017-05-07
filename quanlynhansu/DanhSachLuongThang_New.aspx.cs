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
using System.Globalization;

public partial class DanhSachLuongThang_New : Page
{
    clsTongHopTienLuong THNC = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //idthang.InnerHtml = "THÔNG TIN CHẤM CÔNG THÁNG " + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            //ddlthang.SelectedIndex = ddlthang.Items.IndexOf(ddlthang.Items.FindByValue(DateTime.Now.Month.ToString()));
            //BindListNam();
            //ddlnam.SelectedIndex = ddlnam.Items.IndexOf(ddlnam.Items.FindByValue(DateTime.Now.Year.ToString()));
            //listidnhanvien.Value = "";
            //LoadDataChongCong("");
            BindListPhongBan();
            BindListNam();
            BindListNhanVien();
            ddlThang.SelectedValue = DateTime.Now.Month.ToString();
            ddlNam.SelectedValue = DateTime.Now.Year.ToString();
            //txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
        else
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ds", "new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));", true);
        }
    }

    #region My Code KH@
    private void BindListBangLuong()
    {
        string PhongIn = "";
        string CaIn = "";
        string idNhanVienin = "";
        string listNV = "";
        int thang=0;
        int nam = 0;
        if (ddlThang.SelectedIndex > -1)
            thang =StaticData.ParseInt(ddlThang.SelectedValue);
        if (ddlNam.SelectedIndex > -1)
            nam = StaticData.ParseInt(ddlNam.SelectedValue);
        if (true)
        {
            
            string NgayIn = "";// And convert(varchar,tc.ngaytangca,103)='" + txtNgay.Text.Trim() + "'";

            if (ddlPhongBan.SelectedValue != "0")
                PhongIn = " and pb.idphongban=" + ddlPhongBan.SelectedValue;
            if (ddlLoaiNV.SelectedValue != "-1")
                PhongIn += " and nv.LoaiNhanVien=" + ddlLoaiNV.SelectedValue;
            if (ddlNhanVien.SelectedValue != "0")
                idNhanVienin = " and nv.idnhanvien=" + ddlNhanVien.SelectedValue;

            listNV = ""
+ " select *,ThucNhan=TongLuongThuong+TongLuongTruc+TongLuongLamThem+TienPhuCapTrachNhiem+TienPhuCapDocHai+TienPhuCapHienVat+TienPhuCapBoiDuong +TongTienNgoaiGio + QuyTienLuong+PCK" + "\r\n"
//+ " -TruVoKyLuat " + "\r\n"
+ "-(TienBHXH+TienBHYT+TienBHTN+ThueTNCN) from" + "\r\n"
+ "  (" + "\r\n"
+ "  select ROW_NUMBER ( ) OVER(ORDER BY tennhanvien) AS STT" + "\r\n"
+ "                   ,nv.idnhanvien,manhanvien,tennhanvien,tenphongban" + "\r\n"
+ "  ,chucvu=cv.tenchucvu,ngayvao=hd.ngaybatdau,luongcoban=round(convert(real,isnull(hd.mucluongcoban,0)),0) " + "\r\n"
+ "  ,soGioThang=hd.giolam" + "\r\n"
+ "  ,LuongCBGio=hd.luongCB +'/'+convert(varchar,hd.HeSoLCB) " + "\r\n"
+ "  ,SoNgayPC=[dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien,"+thang.ToString()+","+nam.ToString()+")" + "\r\n"
+ "  ,SoNgayPK=[dbo].[GetSoNgayNhanVienPhepKhongLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,LuongMotNgay=[dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,TongLuongThuong= [dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")*([dbo].[GetSoNgayNhanVienLamThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")+[dbo].[GetSoNgayNhanVienNghiLe](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")+[dbo].[NS_GetSoNgayTrucTinhThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ") + [dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + "))" + "\r\n"
//+ "  ,TongLuongThuong= ([dbo].[GetSoNgayNhanVienLamThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")+[dbo].[GetSoNgayNhanVienNghiLe](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")+[dbo].[GetSoNgayNhanVienNghiBu](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ") + [dbo].[GetSoNgayNhanVienPhepCoLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + "))" + "\r\n"

+ "  ,TongLuongTruc=[dbo].[GetSoTienCaTruc](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")"
+ " - [dbo].[NS_GetSoNgayTrucTinhThuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")"
+ " * (select isnull( (select top 1 ct.tientruc from bangchamcongtheongay cc "
+ "	inner join catruc  ct on ct.idcatruc=cc.idcatruc where idnhanvien=nv.idnhanvien ),0))"
+ "  ,TongLuongLamThem=([dbo].[GetLuongNuaNgayNhanVien] (nv.idnhanvien) * [dbo].[GetSoNgayNhanVienLamThemNuaNgay](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")) +([dbo].[GetLuongMotNgayNhanVien] (nv.idnhanvien) * [dbo].[GetSoNgayNhanVienLamThemMotNgay](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + "))" + "\r\n"
+ "  ,TongTienNgoaiGio=[dbo].[NS_TongTienLamNgoaiGio] (nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"

+ "  ,TruVoKyLuat=[dbo].[GetSoNgayNhanVienVoKyLuat](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")* [dbo].[LuongMotNgayNhanVien](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ") " + "\r\n"
+ "  ,TienBHXH=dbo.[GetTienBHXH_NhanVien](nv.idnhanvien)" + "\r\n"
+ "  ,TienBHYT=[dbo].[GetTienBHYT_NhanVien](nv.idnhanvien)" + "\r\n"
+ "  ,TienBHTN=[dbo].[GetTienBHTN_NhanVien](nv.idnhanvien)" + "\r\n"
+ "  ,ThueTNCN= [dbo].[ThueTNCN_NhanVien](nv.idnhanvien)" + "\r\n"
+ "  ,TienPhuCapTrachNhiem=[dbo].[NS_GetPhuCapDocHai_TN](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ",2)" + "\r\n"
+ "  ,TienPhuCapDocHai=[dbo].[NS_GetPhuCapDocHai_TN](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ",1)" + "\r\n"
+ "  ,TienPhuCapHienVat=[dbo].[NS_GetPhuCapHienVat](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,TienPhuCapBoiDuong=[dbo].[NS_GetPhuCapBoiDuongSanPham](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ " ,QuyTienLuong=[dbo].[NS_GetQuyTienLuong](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ " ,PCK=[dbo].[NS_GetPhuCapKhac](nv.idnhanvien," + thang.ToString() + "," + nam.ToString() + ")" + "\r\n"
+ "  ,TienThuong=0" + "\r\n"
+ "  ,TienPhat=0" + "\r\n"
+ "  " + "\r\n"
+ "  from NhanVien NV left join phongban pb on pb.idphongban=nv.idphongban " + "\r\n"
+ "  left join hopdong hd on hd.idnhanvien=nv.idnhanvien" + "\r\n"
        + "  and hd.idhopdong=(select top 1 idhopdong from hopdong "
        + "  where idnhanvien=nv.idnhanvien and status=1 "
        + "  order by idhopdong desc)"
        + " and hd.status=1 "
+ "  left join chucvu cv on cv.idchucvu=nv.idchucvu" + "\r\n"
+ "  " + "\r\n"
+ "  where  nv.status=1 "+PhongIn+idNhanVienin+" " + "\r\n"
+ "  ) abc" + "\r\n";
                            //    + " " + PhongIn + " " + CaIn + "" + idNhanVienin + NgayIn;
        }
        else
        {
            listNV = ""
+" " + "\r\n"
+" select ROW_NUMBER ( ) OVER(ORDER BY tennhanvien) AS STT" + "\r\n"
+"                  ,nv.idnhanvien,manhanvien,tennhanvien,tenphongban" + "\r\n"
+" ,chucvu=cv.tenchucvu,ngayvao=hd.ngaybatdau,luongcoban=isnull(hd.mucluongcoban,0)" + "\r\n"
+" ,soGioThang=hd.giolam" + "\r\n"
+ " ,LuongCBGio=hd.mucluongcoban +'/'+convert(varchar,hd.giolam) " + "\r\n"
+" ,luongmotgio=isnull((select top 1 luongmotgio from bangchamcong where idnhanvien=nv.idnhanvien),hd.mucluongcoban/hd.giolam)" + "\r\n"
+" ,luongmotgioham=dbo.GetLuongMotGioNhanVien(nv.idnhanvien,8,2011)" + "\r\n"
+" " + "\r\n"
+" ,SoNgayNghi=0" + "\r\n"
+" ,sogiolamca=dbo.GetSoGioLamCaNhanVien(nv.idnhanvien,8,2011)" + "\r\n"
+" ,TongLuongTheoCaLe=isnull((select top 1 luongmotgio from bangchamcong where idnhanvien=nv.idnhanvien and idphanca<>0),hd.mucluongcoban/hd.giolam) * dbo.GetSoGioLamCaNhanVien(nv.idnhanvien,8,2011)" + "\r\n"
+" ,TongLuongTheoCa=convert(int,isnull((select top 1 luongmotgio from bangchamcong where idnhanvien=nv.idnhanvien and idphanca<>0),hd.mucluongcoban/hd.giolam) * dbo.GetSoGioLamCaNhanVien(nv.idnhanvien,8,2011))" + "\r\n"
+" ,TongLuongTheoCaham=convert(int,dbo.GetLuongMotGioNhanVien(nv.idnhanvien,8,2011) * dbo.GetSoGioLamCaNhanVien(nv.idnhanvien,8,2011))" + "\r\n"
+" " + "\r\n"
+" ,sogiolamtangca=dbo.[GetSoGioLamTangCaNhanVien](nv.idnhanvien,8,2011)" + "\r\n"
+" ,TongLuongTangCa=dbo.GetLuongMotGioNhanVien(nv.idnhanvien,8,2011) * dbo.[GetSoGioLamTangCaNhanVien](nv.idnhanvien,8,2011)" + "\r\n"
+ " ,TienBHXH=dbo.[GetTienBHXH_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,TienBHYT=[dbo].[GetTienBHYT_NhanVien](nv.idnhanvien)" + "\r\n"
+ "  ,TienBHTN=[dbo].[GetTienBHTN_NhanVien](nv.idnhanvien)" + "\r\n"
+ " ,ThueTNCN= [dbo].[ThueTNCN_NhanVien](nv.idnhanvien)" + "\r\n"
+" ,TienPhuCapTrachNhiem=100000" + "\r\n"
+" ,TienPhuCapCongViec=200000" + "\r\n"
+" ,TienThuong=0" + "\r\n"
+" ,TienPhat=0" + "\r\n"
+" ,TongLuongChuaBH=convert(int,dbo.GetLuongMotGioNhanVien(nv.idnhanvien,8,2011) * dbo.GetSoGioLamCaNhanVien(nv.idnhanvien,8,2011)) + " + "\r\n"
+" 	dbo.GetLuongMotGioNhanVien(nv.idnhanvien,8,2011) * dbo.[GetSoGioLamTangCaNhanVien](nv.idnhanvien,8,2011) " + "\r\n"
+" 	+ 100000 + 200000" + "\r\n"
+" ,ThucNhan=convert(int,dbo.GetLuongMotGioNhanVien(nv.idnhanvien,8,2011) * dbo.GetSoGioLamCaNhanVien(nv.idnhanvien,8,2011)) + " + "\r\n"
+" 	dbo.GetLuongMotGioNhanVien(nv.idnhanvien,8,2011) * dbo.[GetSoGioLamTangCaNhanVien](nv.idnhanvien,8,2011) " + "\r\n"
+ " 	+ 100000 + 200000 - (dbo.[GetTienBHXH_NhanVien](nv.idnhanvien) + [dbo].[GetTienBHYT_NhanVien](nv.idnhanvien) + [dbo].[ThueTNCN_NhanVien](nv.idnhanvien))-- cuối:BHYT " + "\r\n"
+ " " + "\r\n"
+" from NhanVien NV left join phongban pb on pb.idphongban=nv.idphongban " + "\r\n"
+" inner join hopdong hd on hd.idnhanvien=nv.idnhanvien" + "\r\n"
+" left join chucvu cv on cv.idchucvu=nv.idchucvu" + "\r\n"
+" " + "\r\n"
+" where hd.status=1 and nv.status=1" + "\r\n";
                     //   + " " + PhongIn + " " + CaIn + "" + idNhanVienin ;
        }
        DataTable dt = DataAcess.Connect.GetTable(listNV);
        //if (dt != null && dt.Rows.Count > 0)
        //{
        showstatus.Visible = true;
        dgr.DataSource = dt;
        dgr.DataBind();
        //}
        if (dt.Rows.Count > 0)
        {
            txtThangHidden.Value = ddlThang.SelectedValue;
            txtNamHidden.Value = ddlNam.SelectedValue;
            lbThangNam.Text = "Tháng " + ddlThang.SelectedValue + "/" + ddlNam.SelectedValue;
            btnExcel.Visible = true;
        }
        else
        {
            txtThangHidden.Value = "";
            txtNamHidden.Value = "";
            lbThangNam.Text = "";
            btnExcel.Visible = false;
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
    private void BindListNam()
    {

        for (int i = 2011; i <= StaticData.NamGioiHan; i++)
        {
            ddlNam.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    private void BindListNhanVien()
    {
        string PhongBanIn = "";
        if (ddlPhongBan.SelectedValue != "0")
            PhongBanIn = "  and idphongban=" + ddlPhongBan.SelectedValue;
        if (ddlLoaiNV.SelectedValue != "-1")
            PhongBanIn += "  and nhanvien.LoaiNhanVien=" + ddlLoaiNV.SelectedValue;
        string sql = "select * from nhanvien where nhanvien.status=1 " + PhongBanIn + " order by tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        //if (dt.Rows.Count != 0)
        //{
            StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "tennhanvien", "------Chọn Nhân Viên------");
        //}
    }
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }

        }

    }
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        int idNhanVien;

        idNhanVien = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        //StaticData.MsgBox(this,"Chi tiết cho xem j nhỉ ?!!!. Tháng/Năm:"+txtThangHidden.Value +"/"+txtNamHidden.Value);
        string LinkName = "frpt_ChiTietLuong_New.aspx?IdNhanVien=" + idNhanVien.ToString() + "&Thang=" + txtThangHidden.Value + "&Nam=" + txtNamHidden.Value + "";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mak", "window.open (\"" + LinkName + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no')", true);
    }

    private string LayHeSoTheoIdTangCa(string idTangCa)
    {
        string heso = "1";
        string sql = "select hesoluong from tangca tc inner join loaitangca ltc on ltc.idloaitangca=tc.idloaitangca where idtangca=" + idTangCa;
        DataTable dtHs = DataAcess.Connect.GetTable(sql);
        if (dtHs.Rows.Count > 0)
            heso = dtHs.Rows[0][0].ToString();
        return heso;
    }

    private double TinhSoGio(string giovao, string giora)
    {
        double sogio = 0;
        string[] arr1 = giovao.Split(':');

        int gio = int.Parse(arr1[0]);
        double phut = int.Parse(arr1[1]);
        double sogiovao = gio + (double)(phut / 60);
        string[] arr2 = giora.Split(':');

        int gior = int.Parse(arr2[0]);
        double phutr = int.Parse(arr2[1]);
        double sogiora = gior + (double)(phutr / 60);
        sogio = sogiora - sogiovao;
        return sogio;
    }
    private bool KiemTraGio(string tugio, string dengio)
    {
        int giovao;
        int phutvao;
        string[] arr = tugio.Split(':');
        if (arr.Length == 2)
        {
            try
            {
                giovao = int.Parse(arr[0]);
                if (giovao < 0 || giovao > 23)
                    return false;
                phutvao = int.Parse(arr[1]);
                if (phutvao < 0 || phutvao > 59)
                    return false;
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Giờ vào không hợp lệ !");
                return false;
            }
        }
        else
        {
            StaticData.MsgBox(this, "Giờ vào không hợp lệ !");
            return false;
        }
        arr = dengio.Split(':');
        if (arr.Length == 2)
        {
            try
            {
                int gio = int.Parse(arr[0]);
                if (gio < 0 || gio > 23)
                    return false;
                if (gio < giovao)
                    return false;
                int phut = int.Parse(arr[1]);
                if (phut < 0 || phut > 59)
                    return false;
                if (gio == giovao)
                    if (phutvao < phut)
                        return false;
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Giờ vào không hợp lệ !");
                return false;
            }
        }
        else
        {
            StaticData.MsgBox(this, "Giờ vào không hợp lệ !");
            return false;
        }
        return true;
    }
    protected void btnGetDanhSach_Click(object sender, EventArgs e)
    {
        BindListBangLuong();
    }
    #endregion my code
    protected void ddlPhongBan_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindListNhanVien();
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        //if (dgr.Items.Count > 0)
        //{
        //    string filename = "Bang luong Nhan Vien thang " + txtThangHidden.Value + "/" + txtNamHidden.Value;
        //    string tcty = "BỆNH VIỆN MINH ĐỨC";
        //    string khoa = "Phòng Nhân Sự";
        //    string header = "BẢNG LƯƠNG NHÂN VIÊN THÁNG " + txtThangHidden.Value + "/" + txtNamHidden.Value;
        //    string strNhanSu = "GĐ.Nhân Sự";
        //    clsExport.exprortToExcelDataGrid(filename, tcty, khoa, header, dgr, strNhanSu);
        //}
        //else
        //{
        //    StaticData.MsgBox(this, "Chưa có danh sách lương !");
        //}
        if (dgr.Items.Count > 0)
        {
        int thang = StaticData.ParseInt(ddlThang.SelectedValue);
        int nam = StaticData.ParseInt(ddlNam.SelectedValue);
         THNC= new clsTongHopTienLuong();
        THNC.thang = thang.ToString();
        THNC.nam = nam.ToString();
        THNC.LoaiNhanVien = ddlLoaiNV.SelectedValue;
        THNC.idNhanVien = ddlNhanVien.SelectedValue;
        THNC.phongban = ddlPhongBan.SelectedValue.ToString();

        THNC.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(THNC_AfterExportToExcel);
        THNC.ExportToExcel();
        }
        else
        {
            StaticData.MsgBox(this, "Chưa có danh sách lương !");
        }
    }
    void THNC_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" + THNC.OutputFileName + "\",'_blank')</script>");
    }
    protected void ddlLoaiNV_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindListNhanVien();
    }
}
