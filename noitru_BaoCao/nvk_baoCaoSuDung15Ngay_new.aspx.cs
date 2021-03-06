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
using System.Collections.Generic;
public partial class nvk_baoCaoSuDung15Ngay_new : Genaratepage
{
    private string idkhoa;
    private string strNgaySuDung = " kb.ngaykham ";
    private string strJonCTXuat = " left join ";
    private string strSoluong = " ISNULL(SOLUONGKE,0)-ISNULL(SOLUONGTRA,0) ";
    private int songay = 0;
    private string NVK_SQLCot;
    private DataTable dtBaoCao;
    private bool IsNuaCuoiThang = false; private int Thang_bc; private int Nam_bc; private int Ngay_CuoiThang; private int FirstDayInRange;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadMenu();
        idkhoa = Request.QueryString["idkhoa"];
        if (!this.IsPostBack)
        {
            if (DateTime.Now.Day <= 15)
            {
                txtTuNgay.Value = FirstDayOfMonth();
                txtDenNgay.Value = Day15thOfMonth();
            }
            else
            {
                txtTuNgay.Value = Day16thOfMonth();
                txtDenNgay.Value = LastDayOfMonth();
            }
            bindKhoThuoc();
            bindLoaiThuoc();
        }
    }
    private void LoadMenu()
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"].ToString();
            PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
        }
        catch (Exception ex)
        {
        }
    }
    private string FirstDayOfMonth()
    {
        string Ngay = "";
        string thang = DateTime.Now.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = DateTime.Now.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        Ngay = "01/" + thang + "/" + nam;
        return Ngay;
    }
    private string LastDayOfMonth()
    {
        string Ngay = "";
        string day = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString();
        if (day.Length < 2)
            day = "0" + day;
        string thang = DateTime.Now.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = DateTime.Now.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        Ngay = day + "/" + thang + "/" + nam;
        return Ngay;
    }
    private string Day15thOfMonth()
    {
        string Ngay = "";
        string thang = DateTime.Now.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = DateTime.Now.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        Ngay = "15/" + thang + "/" + nam;
        return Ngay;
    }
    private string Day16thOfMonth()
    {
        string Ngay = "";
        string thang = DateTime.Now.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = DateTime.Now.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        Ngay = "16/" + thang + "/" + nam;
        return Ngay;
    }
    private string DatetimeToString126(DateTime date)
    {
        string ngay = date.Day.ToString();
        if (ngay.Length < 2)
            ngay = "0" + ngay;
        string thang = date.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = date.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        return nam + "/" + thang + "/" + ngay;
    }
    private string DatetimeToString103_10(DateTime date)
    {
        string ngay = date.Day.ToString();
        if (ngay.Length < 2)
            ngay = "0" + ngay;
        string thang = date.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = date.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        return ngay +"/"+ thang;
    }
    private string DatetimeToString103_10_notSign(DateTime date)
    {
        string ngay = date.Day.ToString();
        if (ngay.Length < 2)
            ngay = "0" + ngay;
        string thang = date.Month.ToString();
        if (thang.Length < 2)
            thang = "0" + thang;
        string nam = date.Year.ToString();
        if (nam.Length < 2)
            nam = "0" + nam;
        return ngay + thang + nam;
    }
    private void bindKhoThuoc()
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from khothuoc where idkhoa='"+this.idkhoa+"'");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(this.ddlKho, dt, "idkho", "tenkho", "Tất cả kho");
        }
    }
    private void bindLoaiThuoc()
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from Thuoc_LoaiThuoc");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(this.ddlLoaiThuoc, dt, "LoaithuocID", "TenLoai", "Tất cả các nhóm ");
        }
    }
    protected void btnLayBaoCao_ServerClick(object sender, EventArgs e)
    {
        if (ddLoaiNgaySuDung.Value.Equals("ngayxuat"))
        {
            strNgaySuDung = " ctx.ngaythang_xuat ";
            strSoluong = " ctx.soluong ";
        }
        if (cbIsDaXuat.Checked)
            strJonCTXuat = " inner join ";
        bool isNgay_1Cot = false;
        if (this.idkhoa.Equals(StaticData.GetParameter("nvk_idkhoaphauthuat")))
            isNgay_1Cot = true;
        dtBaoCao = getViewTable_3011(isNgay_1Cot);
        DataTable dt_CotNgay = DataAcess.Connect.GetTable(NVK_SQLCot);
        if (dtBaoCao == null )
        {
            StaticData.MsgBox(this, "Không lấy được báo cáo ! Liên hệ admin.");
            return;
        }
        if (dtBaoCao.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không có nội dung sử dụng trong khoảng thời gian này !");
            return;
        }
        divNoiDungBaoCao.InnerHtml = nvk_getHtmlNoiDungBaoCao(dt_CotNgay, isNgay_1Cot);
    }
    protected void btnXuatExcell_ServerClick(object sender, EventArgs e)
    {
        if (ddLoaiNgaySuDung.Value.Equals("ngayxuat"))
        {
            strNgaySuDung = " ctx.ngaythang_xuat ";
            strSoluong = " ctx.soluong ";
        }
        if (cbIsDaXuat.Checked)
            strJonCTXuat = " inner join ";
        bool isNgay_1Cot = false;
        if (this.idkhoa.Equals(StaticData.GetParameter("nvk_idkhoaphauthuat")))
            isNgay_1Cot = true;
        dtBaoCao = getViewTable_3011(isNgay_1Cot);
        if (dtBaoCao == null)
        {
            StaticData.MsgBox(this, "Không lấy được báo cáo ! Liên hệ admin.");
            return;
        }
        if (dtBaoCao.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không có nội dung sử dụng trong khoảng thời gian này !");
            return;
        }
        DataTable dt_CotNgay = DataAcess.Connect.GetTable(NVK_SQLCot);
        string html = nvk_getHtmlNoiDungBaoCao(dt_CotNgay, isNgay_1Cot);
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=dsYLenhTrongNgay" + txtTuNgay.Value + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        string ngay = "Ngày " + txtTuNgay.Value;
        Response.Write(style);
        Response.Output.Write(html);
        Response.Flush();
        Response.End();
    }
    private string nvk_getHtmlNoiDungBaoCao(DataTable dt_CotNgay,bool isNgay1Cot)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();

        #region tham số tiêu đề
        string TenBenhVien = "BỆNH VIỆN ĐA KHOA MINH ĐỨC";
        string Khoa_Kho = DataAcess.Connect.GetTable("select isnull((select tenphongkhambenh from phongkhambenh where idphongkhambenh ='" + idkhoa + "'),'')").Rows[0][0].ToString();
        if (ddlKho.SelectedValue != "0")
            Khoa_Kho += " - " + ddlKho.SelectedItem.Text;
        string TieuDeBaoCao = "BÁO CÁO SỬ DỤNG ";
        if (ddlLoaiThuoc.SelectedValue != "0")
            TieuDeBaoCao += ddlLoaiThuoc.SelectedItem.Text.ToUpper();
        TieuDeBaoCao += " 15 NGÀY";
        string KhoangNgay = "Từ ngày " + txtTuNgay.Value+" "+ txtTuGio.Value + " đến " + txtDenNgay.Value + " "+txtDenGio.Value;
        #endregion

        #region html Inner
        #region html nội dung (thân) báo cáo
        html.Append(@"<table class='table15Ngay' width='100%' bordercolor='#333' border=1 style='border-collapse:collapse;' cellpadding=3 cellspacing=0>");

        #region các dòng tiêu đề
        int SoCot=dtBaoCao.Columns.Count + (IsNuaCuoiThang ? 2: 0);
        int CotRong_tieude= SoCot -11;
        string col_left = "4";
        string col_right = "7";
        if (isNgay1Cot)
        {
            col_left = "2";
            col_right = "3";
            CotRong_tieude = SoCot - 5;
        }
        html.Append(@"<tr><td  colspan='" + col_left + @"' align='left' style='border-right:none;'>
                <span class='sp_Blue_Bold'  style='font-weight:bold;color:Blue;'>Sở Y Tế Bến Tre</span><br/>
                <span class='sp_Blue_Bold'  style='font-weight:bold;color:Blue;'>" + TenBenhVien + @"</span><br/>
                <span class='sp_Blue_Bold'  style='font-weight:bold;color:Blue;'>" + Khoa_Kho + @"</span>
            </td>");
        html.Append(@"<td  colspan='" + (CotRong_tieude <8 ? 8:CotRong_tieude) + @"' align='center'>
                <span class='sp_Blue_Bold'  style='font-size: 22px;font-weight:bold;color:Blue;'>" + TieuDeBaoCao + @"</span><br/>
                <span class='sp_Blue_Bold'  style='font-weight:bold;font-style:italic;color:Blue;'>" + KhoangNgay + @"</span>
            </td>");
        html.Append(@"<td  colspan='"+col_right+@"' align='left'>
                <span class='sp_Blue_Bold'  style='font-weight:bold;color:Blue;'>MS: 16D/BV-01</span><br/>
                <span class='sp_Blue_Bold'  style='font-weight:bold;color:Blue;'>Số:..........</span>
            </td></tr>");

        //html.Append("<tr><td  colspan='" + SoCot + "' align='left'><span class='sp_Blue_Bold'  style='font-size: 16px;font-weight:bold;color:Blue;'>" + TenBenhVien + "</span></td></tr>");
        //html.Append("<tr><td  colspan='" + SoCot + "' align='left'><span class='sp_Blue_Bold'  style='font-size: 16px;font-weight:bold;color:Blue;'>" + Khoa_Kho + "</span></td></tr>");
        //html.Append("<tr><td  colspan='" + SoCot + "' align='center'><span class='sp_Blue_Bold'  style='font-size: 22px;font-weight:bold;color:Blue;'>" + TieuDeBaoCao + "</span></td></tr>");
        //html.Append("<tr><td  colspan='" + SoCot + "' align='center'><span class='sp_Blue_Bold'  style='font-size: 22px;font-weight:bold;color:Blue;'></span></td></tr>");

        #endregion

        #region 2 dòng đầu tiên tên, ngày tháng - loại dùng
        html.Append(@"<tr>");
        html.Append(@"
                        <td><span class='sp_Red_Bold' style='color:Green;font-weight:bold;'>Stt</span></td>
                        <td><span class='sp_Red_Bold' style='color:Green;font-weight:bold;'>Thuốc - Hàm lượng</span></td>
                        <td><span class='sp_Red_Bold' style='color:Green;font-weight:bold;'>Đvt</span></td>");
        if (dt_CotNgay == null || dt_CotNgay.Rows.Count == 0) return "";
        string colspan_Ngay = "colspan='3'";
        if (isNgay1Cot)
            colspan_Ngay = "";
        for (int i = 0; i < dt_CotNgay.Rows.Count; i++)
        {
            html.Append(@"
                        <td  "+colspan_Ngay+" align='center' style='color:Red;font-weight:bold;'><span class='sp_Red_Bold' >" + dt_CotNgay.Rows[i][0] + "</span></td>");
        }
        html.Append(@"<td "+(IsNuaCuoiThang? "colspan='3'":"")+"><span class='sp_Red_Bold' style='color:Green;font-weight:bold;'>Tổng cộng</span></td>");
        html.Append(@"</tr>");
        //Loại dùng
        if (!isNgay1Cot)
        {
            html.Append(@"<tr>");
            html.Append(@"<td><span ></span></td>
                      <td><span ></span></td>
                      <td><span ></span></td>");
            int viTri = 1;
            for (int i = 3; i < dtBaoCao.Columns.Count-3; i++)
            {
                string LoaiDung_i = "";
                if (viTri == 1)
                    LoaiDung_i = "HC";
                else if (viTri == 2)
                    LoaiDung_i = "BS";
                else if (viTri == 3)
                    LoaiDung_i = "T";
                if (viTri == 3)
                    viTri = 1;
                else
                    viTri++;
                html.Append(@"<td><span class='sp_Black_Bold' >" + LoaiDung_i + "</span></td>");
            }
            if (IsNuaCuoiThang)
            {
                html.Append(@"<td>CT</td>");
                html.Append(@"<td>DT</td>");
                html.Append(@"<td>TT</td>");
            }
            else
                html.Append(@"<td></td>");
            html.Append(@"</tr>");
        }
        #endregion

        #region các dòng nội dung
        for (int i = 0; i < dtBaoCao.Rows.Count; i++)
        {
            html.Append(@"<tr>");
            html.Append(@"<td  align='left'><span  style='color:Red;' >" + (i+1) + "</span></td>");
            html.Append(@"<td  align='left'><span class='sp_Black_Bold' style='text-align:left' >" + dtBaoCao.Rows[i]["tenthuoc"] + "</span></td>");
            html.Append(@"<td><span class='sp_Black_Bold' >" + dtBaoCao.Rows[i]["donvitinh"] + "</span></td>");
            float Tong_i = 0;
            for (int j = 3; j < dtBaoCao.Columns.Count-3; j++)
            {
                float Sl_i_j = StaticData.ParseFloat(dtBaoCao.Rows[i][j]);
                Tong_i += Sl_i_j;
                if (Sl_i_j == 0)
                    html.Append(@"<td></td>");
                else
                    html.Append(@"<td>" + Sl_i_j + "</td>");
            }
            html.Append(@"<td><span class='sp_Red_Bold' style='color:Black;font-weight:bold;'>"+Tong_i+"</span></td>");
            #region Tổng nửa đầu tháng, cả tháng
            if (IsNuaCuoiThang)
            {
                float Tong_NuaDau = StaticData.ParseFloat(dtBaoCao.Rows[i]["tongNuaDauThang"]);
                if (Tong_NuaDau != 0)
                {
                    html.Append(@"<td><span class='sp_Red_Bold' style='color:Black;font-weight:bold;'>" + Tong_NuaDau + "</span></td>");
                }
                else
                {
                    html.Append(@"<td><span class='sp_Red_Bold' style='color:Black;font-weight:bold;'></span></td>");
                }
                html.Append(@"<td><span class='sp_Red_Bold' style='color:Black;font-weight:bold;'>" + (Tong_i + Tong_NuaDau) + "</span></td>");
            }
            #endregion
            html.Append(@"</tr>");
        }
        #endregion
        #region dòng cộng khoản
        html.Append(@"<tr>");
        html.Append(@"<td  align='left'><span  style='color:Red;' ></span></td>");
        html.Append(@"<td  align='left'><span  style='font-style:italic;text-align:left' >Cộng khoản:</span></td>");
        html.Append(@"<td><span class='sp_Black_Bold' ></span></td>");
        for (int i = 3; i < dtBaoCao.Columns.Count-3; i++)
        {
            float Tong_i = 0;
            for (int j = 0; j < dtBaoCao.Rows.Count; j++)
            {
                float Sl_i_j = StaticData.ParseFloat(dtBaoCao.Rows[j][i]);
                if (Sl_i_j != 0)
                    Tong_i++;
            }
            if (Tong_i >0)
                html.Append(@"<td><span class='sp_Red_Bold' style='color:Black;font-weight:bold;'>" + Tong_i + "</span></td>");
            else
                html.Append(@"<td><span></span></td>");
        }
        html.Append(@"<td><span class='sp_Red_Bold' style='color:Black;font-weight:bold;'></span></td>");
        html.Append(@"</tr>");
        #endregion
        html.Append(@"</table>");

        #endregion

        #endregion
        return html.ToString();
    }
    private DataTable getViewTable_3011(bool isNgayCot1) 
    {
        string tuNgay126 = StaticData.CheckDate(txtTuNgay.Value)+" "+txtTuGio.Value;
        string denNgay126 = StaticData.CheckDate(txtDenNgay.Value) + " " + txtDenGio.Value;
        DateTime DayBD; DateTime DayKT;
        try
        {
            DayBD = DateTime.Parse(tuNgay126);
            DayKT = DateTime.Parse(denNgay126);
        }
        catch(Exception)
        {
            StaticData.MsgBox(this,"Ngày không hợp lệ !");
            return null;
        }
        //this.songay = DayKT.Day - DayBD.Day + 1;
        TimeSpan dd = DayKT - DayBD;
        this.songay = dd.Days + 1;
        DateTime DayFor = DayBD;
        string NVK_SQL = @"
    select idthuoc,tenthuoc,donvitinh=dvt.tenDVT ";

        for (int i = 1; i <= songay; i++)
        {
            if (i == 1)
                FirstDayInRange = DayFor.Day;
            string NgayInFor = this.DatetimeToString126(DayFor);
            string Ngay_i103_04 = this.DatetimeToString103_10_notSign(DayFor).Substring(0, 8);
            if (isNgayCot1)
            {
                NVK_SQL += @"
                ,N_" + Ngay_i103_04 + @"=0.0
                ";
            }
            else
            {
                NVK_SQL += @"
                ,HC_" + Ngay_i103_04 + @"=0.0
                ,BS_" + Ngay_i103_04 + @"=0.0
                ,T_" + Ngay_i103_04 + @"=0.0
                ";
            }
            if(i<songay)
                NVK_SQLCot += @" select ngay='" + DatetimeToString103_10(DayFor) + @"' 
                union all
                ";
            if (DayFor.Day == 20)
            {
                IsNuaCuoiThang = true;
                Thang_bc = DayFor.Month;
                Nam_bc = DayFor.Year;
                Ngay_CuoiThang = DateTime.DaysInMonth(Nam_bc, Thang_bc);
            }
            DayFor = DayFor.AddDays(1);
        }
        NVK_SQLCot += @" select ngay='" + DatetimeToString103_10(DayFor.AddDays(-1)) + @"'";
        string LoaiThuoc_in="";
        if (!this.ddlLoaiThuoc.SelectedValue.Equals("") && !this.ddlLoaiThuoc.SelectedValue.Equals("0"))
            LoaiThuoc_in = @" and t.loaithuocid=" + ddlLoaiThuoc.SelectedValue + @"";
        string idkhothuoc_in = "";
        if (!this.ddlKho.SelectedValue.Equals("") && !this.ddlKho.SelectedValue.Equals("0"))
            idkhothuoc_in = " and ct.idkho='" + ddlKho.SelectedValue + "'";

        #region use thuoc exists DAUTHANG and not exists CUOITHANG
        string sqlUnion = "";
        if (IsNuaCuoiThang)
        {
            sqlUnion = NVK_SQL + @"
                ,tongNuaDauThang=0.0,Loai=1,nvk_UuTienYL
            from thuoc t left join category ca on t.cateid=ca.cateid 
                left join thuoc_donvitinh dvt on dvt.id=t.iddvt
            where 1=1 " + LoaiThuoc_in + @" 
            and idthuoc in
                    (
                     select distinct ct.idthuoc from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh
            			"+strJonCTXuat+@" chitietphieuxuatkho ctx on ctx.idchitietbenhnhantoathuoc=ct.idchitietbenhnhantoathuoc
                     where kb.idphongkhambenh ='" + idkhoa + "' " + idkhothuoc_in + @"
	                     and (   (" + strNgaySuDung + ">='" + Nam_bc + "/" + Thang_bc + @"/01" + (txtTuGio.Value.Trim().Equals("") ? "" : " " + txtTuGio.Value + "") + @"'
				                             and " + strNgaySuDung + "<'" + Nam_bc + "/" + Thang_bc + @"/" + FirstDayInRange + @" " + (txtTuGio.Value.Trim().Equals("") ? "00:00:00" : txtTuGio.Value) + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				                                or ( ngayDuTruThuoc>='" + Nam_bc + "/" + Thang_bc + "/01" + (txtTuGio.Value.Trim().Equals("") ? "" : " " + txtTuGio.Value + "") + @"' and  ngayDuTruThuoc<'" + Nam_bc + "/" + Thang_bc + @"/" + FirstDayInRange + @" " + (txtTuGio.Value.Trim().Equals("") ? "00:00:00" : txtTuGio.Value) + @"' )
			                                )
                     )
            and idthuoc not in
                    (
                     select distinct ct.idthuoc from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh
            			"+strJonCTXuat+@" chitietphieuxuatkho ctx on ctx.idchitietbenhnhantoathuoc=ct.idchitietbenhnhantoathuoc
                     where kb.idphongkhambenh ='" + idkhoa + "' " + idkhothuoc_in + @"
	                     and (   (" + strNgaySuDung + ">='" + tuNgay126 + @"' and " + strNgaySuDung + "<'" + denNgay126 + @"" + (txtDenGio.Value.Trim().Equals("") ? " 23:59:58:999" : "") + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				                or ( ngayDuTruThuoc>='" + tuNgay126 + @"' and  ngayDuTruThuoc<'" + denNgay126 + @"" + (txtDenGio.Value.Trim().Equals("") ? " 23:59:58:999" : "") + @"' )
			                )
         )";
        }
        #endregion
        NVK_SQL += @"
          ,tongNuaDauThang=0.0,Loai=0,nvk_UuTienYL
        from thuoc t left join category ca on t.cateid=ca.cateid 
            left join thuoc_donvitinh dvt on dvt.id=t.iddvt
            where 1=1 " + LoaiThuoc_in+@" 
        and idthuoc in
        (
         select distinct ct.idthuoc from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh
			"+strJonCTXuat+@" chitietphieuxuatkho ctx on ctx.idchitietbenhnhantoathuoc=ct.idchitietbenhnhantoathuoc
         where kb.idphongkhambenh ='" + this.idkhoa + "' " + idkhothuoc_in + @"  
                and (   (" + strNgaySuDung + ">='" + tuNgay126 + @"' and " + strNgaySuDung + "<'" + denNgay126 + @"" + (txtDenGio.Value.Trim().Equals("") ? " 23:59:58:999" : "") + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				        or ( ngayDuTruThuoc>='" + tuNgay126 + @"' and  ngayDuTruThuoc<'" + denNgay126 + @"" + (txtDenGio.Value.Trim().Equals("") ? " 23:59:58:999" : "") + @"' )
			        )
         )";
        String nvk_orderIn=" order by "+(IsNuaCuoiThang?"Loai,":"")+"isnull(nvk_UuTienYL,1000),tenthuoc";
        if(rd_OdABC.Checked)
            nvk_orderIn = " order by " + (IsNuaCuoiThang ? "Loai," : "") + "tenthuoc";
        //NVK_SQL += nvk_orderIn;
        string last_sql = "";
        if (!IsNuaCuoiThang)
            last_sql = NVK_SQL + nvk_orderIn;
        else
        {
            last_sql = @"select * from  (
            " + NVK_SQL + @"
            union 
            (
              " + sqlUnion + @"
            ) ) as TB" + nvk_orderIn;
        }
        DataTable table = DataAcess.Connect.GetTable(last_sql);
        DataTable dt_ChiTiet = getTable_SuDung_ChiTiet(idkhoa, LoaiThuoc_in, idkhothuoc_in, tuNgay126, denNgay126,isNgayCot1);
        if (table == null || dt_ChiTiet == null)
            return null;
        DataTable table_Excell = getTable_XuatExcell(table, dt_ChiTiet, idkhothuoc_in);
        return table_Excell;
    }

    private DataTable getTable_SuDung_ChiTiet(string idkhoa, string LoaiThuoc_in, string idkhothuoc_in, string tuNgay126, string denNgay126,bool isNgay1cot_ct)
    {
        string sql_ct = @"
        select idthuoc,tenthuoc,donvitinh,nvk_UuTienYL,ngayChiDinh103,nvk_loaiCD,soluong=sum(soluong) from (

        select  ct.idthuoc,tenthuoc,donvitinh=dvt.tenDVT,nvk_UuTienYL=isnull(dvt.nvk_UuTienYL,1000)
            ,soluong="+ strSoluong +@"
            ,ngayChiDinh103= convert(varchar(10)," + strNgaySuDung + ",103)";
        if (isNgay1cot_ct)
        {
            sql_ct += @"
            ,nvk_loaiCD=case when isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='' then  'N_'+convert(varchar(2)," + strNgaySuDung + ",103)+substring(convert(varchar(10)," + strNgaySuDung + ",103),4,2 )+substring(convert(varchar(10)," + strNgaySuDung + @",103),7,4 )
						else 'N_'+convert(varchar(2),kb.ngaydutruthuoc,103)+substring(convert(varchar(10),kb.ngaydutruthuoc,103),4,2 )+substring(convert(varchar(10),kb.ngaydutruthuoc,103),7,4 ) end";
        }
        else
        {
            sql_ct += @"
            ,nvk_loaiCD= 
                case when NVK_LOAIKHO=2 and KB.NGAYDUTRUTHUOC is null then 'T_'+convert(varchar(2)," + strNgaySuDung + ",103)+substring(convert(varchar(10)," + strNgaySuDung + ",103),4,2 )+substring(convert(varchar(10)," + strNgaySuDung + @",103),7,4 )
                when  ISNULL(CONVERT(VARCHAR(10),KB.NGAYDUTRUTHUOC,103),'')='' AND NVK_LOAIKHO<>2 then 'BS_'+convert(varchar(2)," + strNgaySuDung + ",103)+substring(convert(varchar(10)," + strNgaySuDung + ",103),4,2 )+substring(convert(varchar(10)," + strNgaySuDung + @",103),7,4 )
                when  KB.NGAYDUTRUTHUOC is not null then 'HC_'+convert(varchar(2),kb.NGAYDUTRUTHUOC,103)+substring(convert(varchar(10),kb.NGAYDUTRUTHUOC,103),4,2 )+substring(convert(varchar(10),kb.NGAYDUTRUTHUOC,103),7,4 ) end ";
        }
        sql_ct += @"
        from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh
			"+strJonCTXuat+@" chitietphieuxuatkho ctx on ctx.idchitietbenhnhantoathuoc=ct.idchitietbenhnhantoathuoc
	        inner join thuoc t on t.idthuoc =ct.idthuoc
            inner join khothuoc k on k.idkho=ct.idkho
	        left join thuoc_donvitinh dvt on dvt.id=t.iddvt
             where 1=1  " + LoaiThuoc_in + " and kb.idphongkhambenh ='" + idkhoa + "' " + idkhothuoc_in + "  and (   (" + strNgaySuDung + ">='" + tuNgay126 + @"'
				         and " + strNgaySuDung + "<'" + denNgay126 + @"" + (txtDenGio.Value.Trim().Equals("") ? " 23:59:58:999" : "") + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				            or ( ngayDuTruThuoc>='" + tuNgay126 + "' and  ngayDuTruThuoc<'" + denNgay126 + @"" + (txtDenGio.Value.Trim().Equals("") ? " 23:59:58:999" : "") + @"' )
			            )
        ) as nvk
        group by idthuoc,tenthuoc,donvitinh,nvk_UuTienYL,ngayChiDinh103,nvk_loaiCD
        order by nvk_UuTienYL,tenthuoc
        ";
        DataTable dtCT = DataAcess.Connect.GetTable(sql_ct);
        return dtCT;
    }
    private DataTable getTable_XuatExcell(DataTable dtKhung, DataTable dtChiTiet, string idkhothuoc_in)
    {
        for (int i = 0; i < dtKhung.Rows.Count; i++)
        {
            DataView dvTempt = new DataView(dtChiTiet.Copy());
            dvTempt.RowFilter = "idthuoc ="+dtKhung.Rows[i]["idthuoc"].ToString()+"";
            DataTable dtCt_i = dvTempt.ToTable();
            for (int j = 0; j < dtCt_i.Rows.Count; j++)
            {
                string tencot = dtCt_i.Rows[j]["nvk_loaiCD"].ToString();
                dtKhung.Rows[i][tencot] = dtCt_i.Rows[j]["soluong"];
            }
            #region Tổng cộng nửa đầu tháng của món (nếu có)
            if (IsNuaCuoiThang)
            {
                string sql_tongNuaDauThang = "";
                sql_tongNuaDauThang = @"
                    select isnull(
                    (select sum("+ strSoluong +@") 
                        from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh =ct.idkhambenh
            			"+strJonCTXuat+@" chitietphieuxuatkho ctx on ctx.idchitietbenhnhantoathuoc=ct.idchitietbenhnhantoathuoc
                    where kb.idphongkhambenh ='" + idkhoa + "' " + idkhothuoc_in + "  and ct.idthuoc = '" + dtKhung.Rows[i]["idthuoc"] + @"'
	                     and (   (" + strNgaySuDung + ">='" + Nam_bc + "/" + Thang_bc + @"/01" + (txtTuGio.Value.Trim().Equals("") ? "" : " " + txtTuGio.Value + "") + @"'
				                             and " + strNgaySuDung + "<'" + Nam_bc + "/" + Thang_bc + @"/" + FirstDayInRange + @" " + (txtTuGio.Value.Trim().Equals("") ? "00:00:00" : txtTuGio.Value) + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				                                or ( ngayDuTruThuoc>='" + Nam_bc + "/" + Thang_bc + "/01" + (txtTuGio.Value.Trim().Equals("") ? "" : " " + txtTuGio.Value + "") + @"' and  ngayDuTruThuoc<'" + Nam_bc + "/" + Thang_bc + @"/" + FirstDayInRange + @" " + (txtTuGio.Value.Trim().Equals("") ? "00:00:00" : txtTuGio.Value) + @"' )
			                                )
                    ),0)
                    ";
                DataTable dt_tongNuaDauThang = DataAcess.Connect.GetTable(sql_tongNuaDauThang);
                dtKhung.Rows[i]["tongNuaDauThang"] = dt_tongNuaDauThang.Rows[0][0];
            }
            #endregion
        }
        return dtKhung;
    }
}
