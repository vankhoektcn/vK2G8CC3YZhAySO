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
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
public partial class nvk_baoCaoTraThuoc : Genaratepage
{
    public static Application ExApp;
    public static Workbook TasWBook;
    public static Worksheet TasWSheet;

    private string idkhoa;
    private int songay = 0;
    private string NVK_SQLCot;
    private System.Data.DataTable dtBaoCao;
    protected void Page_Load(object sender, EventArgs e)
    {
        divNoiDungBaoCao.InnerHtml = "";
        LoadMenu();
        idkhoa = Request.QueryString["idkhoa"];
        if (!this.IsPostBack)
        {
            if (Request.QueryString["isTongHop"] != null && Request.QueryString["isTongHop"].ToString().Equals("1"))
            {
                string NgayHienTai = DateTime.Now.ToString("dd/MM/yyyy");
                txtTuNgay.Value = NgayHienTai;
                txtDenNgay.Value = NgayHienTai;
                txtTuGio.Value = "00:00"; txtTuGio.Visible = true;
                txtDenGio.Value = "23:59"; txtDenGio.Visible = true;
                btnLayBaoCao.Visible = false;
                divHeader.InnerText = "TỔNG HỢP BỆNH NHÂN TRẢ THUỐC,VTYT...";
            }
            else
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
        System.Data.DataTable dt = DataAcess.Connect.GetTable("select * from khothuoc where idkhoa='" + this.idkhoa + "'");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(this.ddlKho, dt, "idkho", "tenkho", "Tất cả kho");
        }
    }
    private void bindLoaiThuoc()
    {
        System.Data.DataTable dt = DataAcess.Connect.GetTable("select * from Thuoc_LoaiThuoc");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(this.ddlLoaiThuoc, dt, "LoaithuocID", "TenLoai", "Tất cả các nhóm ");
        }
    }
    protected void btnLayBaoCao_ServerClick(object sender, EventArgs e)
    {
        dtBaoCao = getViewTable_3011();
        System.Data.DataTable dt_CotNgay = DataAcess.Connect.GetTable(NVK_SQLCot);
        if (dtBaoCao == null )
        {
            StaticData.MsgBox(this, "Không lấy được báo cáo ! Liên hệ admin.");
            return;
        }
        if (dtBaoCao.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không có nội dung y lệnh trả trong khoảng thời gian này !");
            return;
        }
        divNoiDungBaoCao.InnerHtml = nvk_getHtmlNoiDungBaoCao(dt_CotNgay);
    }
    protected void btnXuatExcell_ServerClick(object sender, EventArgs e)
    {
        //divNoiDungBaoCao.InnerHtml = "<span style='height: auto; width: 100%;text-align:center; color: Red; font-weight: bold;font-style:italic' class='Tieude'> Đang lấy báo cáo.....<img id='imgLoading' src='../images/processing.gif' /></span>";
        if (Request.QueryString["isTongHop"] != null && Request.QueryString["isTongHop"].ToString().Equals("1"))
        {
            tongHopTraThuoc_Excell_0901();
            return;
        }
        dtBaoCao = getViewTable_3011();
        if (dtBaoCao == null)
        {
            StaticData.MsgBox(this, "Không lấy được báo cáo ! Liên hệ admin.");
            return;
        }
        if (dtBaoCao.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không có nội dung y lệnh trả trong khoảng thời gian này !");
            return;
        }
        System.Data.DataTable dt_CotNgay = DataAcess.Connect.GetTable(NVK_SQLCot);
        string html = nvk_getHtmlNoiDungBaoCao(dt_CotNgay);
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=dsYLenhTrongNgay" + txtTuNgay.Value + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        string ngay = "Ngày " + txtTuNgay.Value;
        Response.Write(style);
        //Response.Output.Write("<div style=\"font-weight:bold; font-size:13px;\" align=left>BV Đa Khoa Minh Đức</div>");
        //Response.Output.Write("<div style=\"font-weight:bold; font-size:13px;\" align=left>Khoa Sản</div>");
        //Response.Output.Write("<div style=\"font-weight:bold; font-size:13px;\" align=left>" + ngay + "</div>");

        //Response.Output.Write("<div style=\"font-weight:bold; font-size:17px;color:Red\" align=center>TỔNG HỢP Y LỆNH</div>");
        //Response.Output.Write("<div style=\"font-weight:bold; font-size:15px;\" align=center>" + ngay + "</div>");
        Response.Output.Write(html);
        Response.Flush();
        Response.End();
        //divNoiDungBaoCao.InnerHtml = "";
    }
    private string nvk_getHtmlNoiDungBaoCao(System.Data.DataTable dt_CotNgay)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();

        #region tham số tiêu đề
        string TenBenhVien = "BỆNH VIỆN ĐA KHOA MINH ĐỨC";
        string Khoa_Kho = DataAcess.Connect.GetTable("select isnull((select tenphongkhambenh from phongkhambenh where idphongkhambenh ='" + idkhoa + "'),'')").Rows[0][0].ToString();
        if (ddlKho.SelectedValue != "0")
            Khoa_Kho += " - " + ddlKho.SelectedItem.Text;
        string TieuDeBaoCao = "BÁO CÁO Y LỆNH TRẢ ";
        if (ddlLoaiThuoc.SelectedValue != "0")
            TieuDeBaoCao += ddlLoaiThuoc.SelectedItem.Text;
        else
            TieuDeBaoCao += "THUỐC, VTYT,...";
        TieuDeBaoCao += " (TỪ " + txtTuNgay.Value + " " + txtTuGio.Value + " - " + txtDenNgay.Value + " " + txtDenGio.Value + ")";
        #endregion

        #region html Inner
        #region html nội dung (thân) báo cáo
        html.Append(@"<table class='tableTraThuoc' width='100%' bordercolor='#333' border=1 style='border-collapse:collapse;' cellpadding=3 cellspacing=0>");

        #region các dòng tiêu đề
        int SoCot=dtBaoCao.Columns.Count;
        html.Append("<tr><td  colspan='" + SoCot + "' align='left'><span class='sp_Blue_Bold'  style='font-size: 16px;font-weight:bold;color:Blue;'>" + TenBenhVien + "</span></td></tr>");
        html.Append("<tr><td  colspan='" + SoCot + "' align='left'><span class='sp_Blue_Bold'  style='font-size: 16px;font-weight:bold;color:Blue;'>" + Khoa_Kho + "</span></td></tr>");
        html.Append("<tr><td  colspan='" + SoCot + "' align='center'><span class='sp_Blue_Bold'  style='font-size: 22px;font-weight:bold;color:Blue;'>" + TieuDeBaoCao + "</span></td></tr>");
        html.Append("<tr><td  colspan='" + SoCot + "' align='center'><span class='sp_Blue_Bold'  style='font-size: 22px;font-weight:bold;color:Blue;'></span></td></tr>");

        #endregion

        #region 2 dòng đầu tiên tên, ngày tháng - loại dùng
        html.Append(@"<tr>");
        html.Append(@"
                        <td><span class='sp_Red_Bold' style='color:Green;font-weight:bold;'>Thuốc - Hàm lượng</span></td>
                        <td><span class='sp_Red_Bold' style='color:Green;font-weight:bold;'>Đvt</span></td>");
        if (dt_CotNgay == null || dt_CotNgay.Rows.Count == 0) return "";
        for (int i = 0; i < dt_CotNgay.Rows.Count; i++)
        {
            html.Append(@"
                        <td  colspan='1' align='center' style='color:Red;font-weight:bold;'><span class='sp_Red_Bold' >" + dt_CotNgay.Rows[i][0] + "</span></td>");
        }
        html.Append(@"<td><span class='sp_Red_Bold' style='color:Green;font-weight:bold;'>Tổng cộng</span></td>");
        html.Append(@"</tr>");

        #endregion

        #region các dòng nội dung
        for (int i = 0; i < dtBaoCao.Rows.Count; i++)
        {
            html.Append(@"<tr>");
            html.Append(@"<td  align='left'><span class='sp_Black_Bold' style='text-align:left' >" + dtBaoCao.Rows[i]["tenthuoc"] + "</span></td>");
            html.Append(@"<td><span class='sp_Black_Bold' >" + dtBaoCao.Rows[i]["donvitinh"] + "</span></td>");
            float Tong_i = 0;
            for (int j = 3; j < dtBaoCao.Columns.Count; j++)
            {
                float Sl_i_j = StaticData.ParseFloat(dtBaoCao.Rows[i][j]);
                Tong_i += Sl_i_j;
                if (Sl_i_j == 0)
                    html.Append(@"<td></td>");
                else
                    html.Append(@"<td>" + Sl_i_j + "</td>");
            }
            html.Append(@"<td><span class='sp_Red_Bold' style='color:Black;font-weight:bold;'>"+Tong_i+"</span></td>");
            html.Append(@"</tr>");
        }
        #endregion

        html.Append(@"</table>");

        #endregion

        #endregion
        return html.ToString();
    }
    private System.Data.DataTable getViewTable_3011() 
    {
        string tuNgay126 = StaticData.CheckDate(txtTuNgay.Value);
        string denNgay126 = StaticData.CheckDate(txtDenNgay.Value);
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
            string NgayInFor = this.DatetimeToString126(DayFor);
            string Ngay_i103_04 = this.DatetimeToString103_10_notSign(DayFor).Substring(0, 8);
            NVK_SQL += @"
                ,_" + Ngay_i103_04 + @"=0.0
                ";
            if(i<songay)
                NVK_SQLCot += @" select ngay='" + DatetimeToString103_10(DayFor) + @"' 
                union all
                ";
            DayFor = DayFor.AddDays(1);
        }
        NVK_SQLCot += @" select ngay='" + DatetimeToString103_10(DayFor.AddDays(-1)) + @"'";
        string LoaiThuoc_in="";
        if (!this.ddlLoaiThuoc.SelectedValue.Equals("") && !this.ddlLoaiThuoc.SelectedValue.Equals("0"))
            LoaiThuoc_in = @" and t.loaithuocid=" + ddlLoaiThuoc.SelectedValue + @"";
        string idkhothuoc_in = "";
        if (!this.ddlKho.SelectedValue.Equals("") && !this.ddlKho.SelectedValue.Equals("0"))
            idkhothuoc_in = " and ct.idkho='" + ddlKho.SelectedValue + "'";
        NVK_SQL += @"
        from thuoc t left join category ca on t.cateid=ca.cateid 
            left join thuoc_donvitinh dvt on dvt.id=t.iddvt
            where 1=1 "+LoaiThuoc_in+@" 
        and idthuoc in
        (
         select distinct idthuoc from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh
         where isnull(ct.soluongtra,0)>0 and isnull(kb.maphieukham,'') <> 'pkxk' and kb.idphongkhambenh =" + this.idkhoa + " " + idkhothuoc_in + @" 
                and (
                            (kb.ngaykham>='" + tuNgay126 + @"' and kb.ngaykham<='" + denNgay126 + @" 23:59:58:999' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				        or ( ngayDuTruThuoc>='" + tuNgay126 + @"' and  ngayDuTruThuoc<='" + denNgay126 + @" 23:58:59:999' )
			        )
         )";
        String nvk_orderIn=" order by isnull(dvt.nvk_UuTienYL,1000),tenthuoc";
        if(rd_OdABC.Checked)
            nvk_orderIn = " order by tenthuoc";
        NVK_SQL += nvk_orderIn;

        System.Data.DataTable table = DataAcess.Connect.GetTable(NVK_SQL);
        System.Data.DataTable dt_ChiTiet = getTable_SuDung_ChiTiet(idkhoa, LoaiThuoc_in, idkhothuoc_in, tuNgay126, denNgay126);
        if (table == null || dt_ChiTiet == null)
            return null;
        System.Data.DataTable table_Excell = getTable_XuatExcell(table, dt_ChiTiet);
        return table_Excell;
    }

    private System.Data.DataTable getTable_SuDung_ChiTiet(string idkhoa, string LoaiThuoc_in, string idkhothuoc_in, string tuNgay126, string denNgay126)
    {
        string sql_ct = @"
        select idthuoc,tenthuoc,donvitinh,nvk_UuTienYL,ngayChiDinh103,nvk_loaiCD,soluong=sum(soluongtra) from (

        select  ct.idthuoc,tenthuoc,donvitinh=dvt.tenDVT,nvk_UuTienYL=isnull(dvt.nvk_UuTienYL,1000)
            ,soluongtra
            ,ngayChiDinh103= convert(varchar(10),kb.ngaykham,103)
            ,nvk_loaiCD= case when isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='' then '_'+convert(varchar(2),kb.ngaykham,103)+substring(convert(varchar(10),kb.ngaykham,103),4,2 )+substring(convert(varchar(10),kb.ngaykham,103),7,4 )
						else '_'+convert(varchar(2),kb.ngaydutruthuoc,103)+substring(convert(varchar(10),kb.ngaydutruthuoc,103),4,2 )+substring(convert(varchar(10),kb.ngaydutruthuoc,103),7,4 ) end
        from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh
	        inner join thuoc t on t.idthuoc =ct.idthuoc
            inner join khothuoc k on k.idkho=ct.idkho
	        left join thuoc_donvitinh dvt on dvt.id=t.iddvt
             where isnull(ct.soluongtra,0)>0  " + LoaiThuoc_in + " and isnull(kb.maphieukham,'') <> 'pkxk' and kb.idphongkhambenh ='" + idkhoa + "' " + idkhothuoc_in + @"  
                        and (   (kb.ngaykham>='" + tuNgay126 + @"' and kb.ngaykham<='" +denNgay126+@" 23:59:58:999' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				            or ( ngayDuTruThuoc>='"+tuNgay126+"' and  ngayDuTruThuoc<='"+denNgay126+ @" 23:58:59:999' )
			            )
        ) as nvk
        group by idthuoc,tenthuoc,donvitinh,nvk_UuTienYL,ngayChiDinh103,nvk_loaiCD
        order by nvk_UuTienYL,tenthuoc
        ";
        System.Data.DataTable dtCT = DataAcess.Connect.GetTable(sql_ct);
        return dtCT;
    }
    private System.Data.DataTable getTable_XuatExcell(System.Data.DataTable dtKhung, System.Data.DataTable dtChiTiet)
    {
        for (int i = 0; i < dtKhung.Rows.Count; i++)
        {
            DataView dvTempt = new DataView(dtChiTiet.Copy());
            dvTempt.RowFilter = "idthuoc ="+dtKhung.Rows[i]["idthuoc"].ToString()+"";
            System.Data.DataTable dtCt_i = dvTempt.ToTable();
            for (int j = 0; j < dtCt_i.Rows.Count; j++)
            {
                string tencot = dtCt_i.Rows[j]["nvk_loaiCD"].ToString();
                dtKhung.Rows[i][tencot] = dtCt_i.Rows[j]["soluong"];
            }
        }
        return dtKhung;
    }

    #region Tổng hợp trả thuốc, vtyt...
    private void tongHopTraThuoc_Excell_0901()
    {
        #region điều kiện tổng hợp
        string idkhoa = Request.QueryString["idkhoa"] != null ? Request.QueryString["idkhoa"] : "0";
        string TuNgay_Gio = StaticData.CheckDate(txtTuNgay.Value.Trim()) + " " + txtTuGio.Value.Trim();
        string DenNgay_Gio = StaticData.CheckDate(txtDenNgay.Value.Trim()) + " " + txtDenGio.Value.Trim();
        string nvk_dk = "  and isnull(soluongtra,0)>0 and kb.idphongkhambenh=" + idkhoa + "";
        if (!ddlKho.SelectedValue.Equals("0"))
            nvk_dk += " and ct.idkho='" + ddlKho.SelectedValue + "' ";
        if (!ddlLoaiThuoc.SelectedValue.Equals("0"))
            nvk_dk += " and isnull(t.loaithuocid,1)='" + ddlLoaiThuoc.SelectedValue + "' ";
        //nvk_dk += " and ngaykham >='" + TuNgay_Gio + "' and ngaykham <='" + DenNgay_Gio + @"' ";
        nvk_dk += " and (  (kb.ngaykham>='" + TuNgay_Gio + @"' and kb.ngaykham<='" + DenNgay_Gio + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
				            or ( ngayDuTruThuoc>='" + TuNgay_Gio + "' and  ngayDuTruThuoc<='" + DenNgay_Gio + @"' )
			            )";
        string nvk_orderIn = " order by nvk_UuTienYL,tenthuoc";
        if (rd_OdABC.Checked)
            nvk_orderIn = " order by tenthuoc";
        #endregion 

        System.Data.DataTable dt_Thuoc = dtThuocTongHop(nvk_dk, nvk_orderIn);
        if (dt_Thuoc == null || dt_Thuoc.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không có Y lệnh !"); return;
        }
        string listIdBn = ListIdBenhNhan(nvk_dk);
        System.Data.DataTable dt_YLenh = dtChiTietTongHop(dt_Thuoc, nvk_dk, idkhoa,listIdBn);
        if (dt_YLenh == null)
        {
            StaticData.MsgBox(this, "Không lấy được báo cáo ! Liên hệ admin.");
            return;
        }
        if (dt_YLenh.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không có nội dung y lệnh trả trong khoảng thời gian này !");
            return;
        }
        //divNoiDungBaoCao.InnerHtml = "";
        xuatExcellTongHopTra(dt_Thuoc, dt_YLenh);
    }

    private System.Data.DataTable dtThuocTongHop(string dk, string orderIn)
    {
        string sql_Thuoc = @"select * from (
        select distinct idColumn=t.idthuoc,MaThuoc='('+donvitinh+')'+TenThuoc,TenThuoc,nvk_UuTienYL=isnull(dvt.nvk_UuTienYL,1000),pk.tenphongkhambenh
        from chitietbenhnhantoathuoc ct inner join thuoc t on t.idthuoc=ct.idthuoc left join thuoc_donvitinh dvt on dvt.id=t.iddvt
            inner join khambenh kb on kb.idkhambenh=ct.idkhambenh inner join phongkhambenh pk on pk.idphongkhambenh =kb.idphongkhambenh
        where isnull(kb.maphieukham,'') <> 'pkxk' " + dk + @"
        ) as abc
        " + orderIn + @"
        ";
        System.Data.DataTable dt_Thuoc = DataAcess.Connect.GetTable(sql_Thuoc);
        return dt_Thuoc;
    }
    private string ListIdBenhNhan(string dk)
    {
        string sql_bn = @"
        select distinct kb.idbenhnhan
        from chitietbenhnhantoathuoc ct inner join thuoc t on t.idthuoc=ct.idthuoc 
            inner join khambenh kb on kb.idkhambenh=ct.idkhambenh inner join phongkhambenh pk on pk.idphongkhambenh =kb.idphongkhambenh
        where isnull(kb.maphieukham,'') <> 'pkxk' " + dk + @"
        ";
        System.Data.DataTable dt_bn = DataAcess.Connect.GetTable(sql_bn);
        string list_bn = "";
        if (dt_bn != null && dt_bn.Rows.Count > 0)
        {
            for (int i = 0; i < dt_bn.Rows.Count; i++)
            {
                list_bn += dt_bn.Rows[i]["idbenhnhan"].ToString()+",";
            }
            list_bn = list_bn.TrimEnd(',');
            return list_bn;
        }
        else
        {
            return "0";
        }
    }
    private System.Data.DataTable dtChiTietTongHop(System.Data.DataTable dt_Thuoc, string nvkDK, string idkhoa, string ListId_BenhNhan)
    {
        string sql_YLenh = @"
            select stt=row_number()over(order by bn.idbenhnhan),bn.idbenhnhan
            ,Phong = replace(replace(tenphong,N'Nội ',''),N'Ngoại ',''),Phong1=tenphong,Giuong=giuongcode
            ,MaBenhNhan=bn.mabenhnhan,TenBenhNhan=bn.TenBenhNhan+' ('+dbo.GetNamSinh(bn.ngaysinh )+')'";
        for (int j = 0; j < dt_Thuoc.Rows.Count; j++)
        {
            sql_YLenh += @",SoLuongThuoc_int_" + j + @"=isnull(
                (select sum(isnull(soluongtra,0)) from chitietbenhnhantoathuoc ct
                        inner join khambenh kb on kb.idkhambenh=ct.idkhambenh
                        left join thuoc t on t.idthuoc =ct.idthuoc
                   where isnull(kb.maphieukham,'') <> 'pkxk' and  
		                ct.idthuoc='" + dt_Thuoc.Rows[j]["idColumn"] + @"'  and kb.idbenhnhan=bn.idbenhnhan
                        "+nvkDK+@"
                )
                ,0)";
        }
        sql_YLenh += @"from   benhnhan bn left join benhnhannoitru nt on nt.idbenhnhan=bn.idbenhnhan
        and nt.idnoitru in(select top 1 idnoitru from benhnhannoitru where idbenhnhan =bn.idbenhnhan and idkhoanoitru="+idkhoa+@" order by NgayVaoVien desc) 
                        left join kb_giuong g on g.giuongid=nt.idgiuong left join  kb_phong p on g.idphong=p.id
                        where bn.idbenhnhan in(" + ListId_BenhNhan + @")
    order by phong,tenbenhnhan ";
        System.Data.DataTable dt_YLenh = DataAcess.Connect.GetTable(sql_YLenh);
        return dt_YLenh;
    }
    private void xuatExcellTongHopTra(System.Data.DataTable dt_Thuoc, System.Data.DataTable dt_YLenh)
    {
        string nvk_KhoangNgay = "Từ ngày " + txtTuNgay.Value.Trim() + " " + txtTuGio.Value.Trim() + "   Đến ngày " + txtDenNgay.Value.Trim() + " " + txtDenGio.Value.Trim();
        try
        {
            int startRow = 1;
            TastStartExcel("tonghopylenhTra" + DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() );
            int pos = startRow + 3;
            Worksheet ws = TasWSheet;
            #region Header
            ws.Name = "tonghopylenh" + DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString();
            ws.get_Range("A" + Conversions.ToString((int)(pos - 3)) + ":D" + Conversions.ToString((int)(pos - 3)), Missing.Value).Merge(Missing.Value);
            ws.get_Range("A" + Conversions.ToString((int)(pos - 3)), Missing.Value).set_Value(Missing.Value, "BV Đa Khoa Minh Đức");
            ws.get_Range("A" + Conversions.ToString((int)(pos - 3)), Missing.Value).Font.Bold = true;
            ws.get_Range("A" + Conversions.ToString((int)(pos - 3)), Missing.Value).Font.Size = 14;

            ws.get_Range("A" + Conversions.ToString((int)(pos - 2)) + ":D" + Conversions.ToString((int)(pos - 2)), Missing.Value).Merge(Missing.Value);
            string tenkhoaYlenh = dt_Thuoc.Rows[0]["tenphongkhambenh"].ToString();
            if (ddlKho.SelectedValue.Equals("0"))
                tenkhoaYlenh = tenkhoaYlenh + " :" + ddlKho.SelectedItem.Text;
            else
                tenkhoaYlenh = ddlKho.SelectedItem.Text;
            ws.get_Range("A" + Conversions.ToString((int)(pos - 2)), Missing.Value).set_Value(Missing.Value, tenkhoaYlenh);
            ws.get_Range("A" + Conversions.ToString((int)(pos - 2)), Missing.Value).Font.Bold = true;
            ws.get_Range("A" + Conversions.ToString((int)(pos - 2)), Missing.Value).Font.Size = 12;

            //canh trái 4 ô đầu
            ws.get_Range("A" + Conversions.ToString((int)(pos - 1)) + ":D" + Conversions.ToString((int)(pos - 1)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignLeft;

            //hien thi tong hop y lenh
            ws.get_Range("A" + Conversions.ToString((int)(pos)) + ":" + getcomlumnname(dt_Thuoc.Rows.Count + 5) + "" + Conversions.ToString((int)(pos)), Missing.Value).Merge(Missing.Value);
            ws.get_Range("A" + Conversions.ToString((int)(pos)), Missing.Value).set_Value(Missing.Value, "Tổng hợp y lệnh trả (" + ddlLoaiThuoc.SelectedItem.Text + ")");
            ws.get_Range("A" + Conversions.ToString((int)(pos)), Missing.Value).Font.Bold = true;
            ws.get_Range("A" + Conversions.ToString((int)(pos)), Missing.Value).Font.Size = 24;
            ws.get_Range("A" + Conversions.ToString((int)(pos)) + ":I" + Conversions.ToString((int)(pos)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //hien thi ngay thang 
            ws.get_Range("A" + Conversions.ToString((int)(pos + 1)) + ":" + getcomlumnname(dt_Thuoc.Rows.Count + 5) + "" + Conversions.ToString((int)(pos + 1)), Missing.Value).Merge(Missing.Value);
            ws.get_Range("A" + Conversions.ToString((int)(pos + 1)), Missing.Value).set_Value(Missing.Value, nvk_KhoangNgay);
            ws.get_Range("A" + Conversions.ToString((int)(pos + 1)), Missing.Value).Font.Bold = true;
            ws.get_Range("A" + Conversions.ToString((int)(pos + 1)), Missing.Value).Font.Size = 12;
            ws.get_Range("A" + Conversions.ToString((int)(pos + 1)) + ":I" + Conversions.ToString((int)(pos + 1)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            #endregion

            //thuc hien tao content 

            #region dòng  tiêu đề
            #region tiêu đề stt,phòng, giường, tên bệnh nhân
            //column Stt
            ws.get_Range("A" + Conversions.ToString((int)(pos + 2)) + ":A" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range("A" + Conversions.ToString(pos + 2) + ":A" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            ws.get_Range("A" + Conversions.ToString(pos + 2), Missing.Value).set_Value(Missing.Value, "STT");
            ws.get_Range("A" + Conversions.ToString(pos + 2), Missing.Value).Font.Bold = true;
            NewLateBinding.LateSetComplex(ws.Columns["A", Missing.Value], null, "ColumnWidth", new object[] { 3 }, null, null, false, true);
            ws.get_Range("A" + Conversions.ToString(pos + 2) + ":A" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);

            //column phong
            ws.get_Range("B" + Conversions.ToString((int)(pos + 2)) + ":B" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range("B" + Conversions.ToString(pos + 2) + ":B" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            ws.get_Range("B" + Conversions.ToString(pos + 2), Missing.Value).set_Value(Missing.Value, "Phòng");
            ws.get_Range("B" + Conversions.ToString((int)(pos + 2)), Missing.Value).Orientation = 90;
            ws.get_Range("B" + Conversions.ToString(pos + 2), Missing.Value).Font.Bold = true;
            NewLateBinding.LateSetComplex(ws.Columns["B", Missing.Value], null, "ColumnWidth", new object[] { 5 }, null, null, false, true);
            ws.get_Range("B" + Conversions.ToString(pos + 2) + ":B" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            //cot giuong
            ws.get_Range("C" + Conversions.ToString((int)(pos + 2)) + ":C" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range("C" + Conversions.ToString(pos + 2) + ":C" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            ws.get_Range("C" + Conversions.ToString(pos + 2), Missing.Value).set_Value(Missing.Value, "Giường");
            ws.get_Range("C" + Conversions.ToString((int)(pos + 2)), Missing.Value).Orientation = 90;
            ws.get_Range("C" + Conversions.ToString((int)(pos + 2)), Missing.Value).Font.Bold = true;
            NewLateBinding.LateSetComplex(ws.Columns["C", Missing.Value], null, "ColumnWidth", new object[] { 5 }, null, null, false, true);
            ws.get_Range("C" + Conversions.ToString(pos + 2) + ":C" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            //cot ho va ten 
            ws.get_Range("D" + Conversions.ToString((int)(pos + 2)) + ":D" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range("D" + Conversions.ToString(pos + 2) + ":D" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            ws.get_Range("D" + Conversions.ToString(pos + 2), Missing.Value).set_Value(Missing.Value, "Họ và tên bệnh nhân");
            ws.get_Range("D" + Conversions.ToString(pos + 2), Missing.Value).Font.Bold = true;
            NewLateBinding.LateSetComplex(ws.Columns["D", Missing.Value], null, "ColumnWidth", new object[] { 35 }, null, null, false, true);
            ws.get_Range("D" + Conversions.ToString(pos + 2) + ":D" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            #endregion

            //ten thuoc lap tu day 
            #region tiêu đề tên  thuốc
            int vitribatdau = 4;
            for (int m = 0; m < dt_Thuoc.Rows.Count; m++)
            {
                ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString((int)(pos + 2)) + ":" + getcomlumnname(vitribatdau) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
                ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString(pos + 2), Missing.Value).set_Value(Missing.Value, dt_Thuoc.Rows[m]["tenthuoc"].ToString());
                ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString((int)(pos + 2)), Missing.Value).Orientation = 90;
                ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString((int)(pos + 2)), Missing.Value).Font.Bold = true;

                NewLateBinding.LateSetComplex(ws.Columns[getcomlumnname(vitribatdau), Missing.Value], null, "ColumnWidth", new object[] { 8 }, null, null, false, true);
                ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
                vitribatdau++;
            }
            #endregion
            //tim cot tiep theo

            //cot da thuc hien 
            #region tiêu đề DD thuc hien,BN ky ten
            ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString((int)(pos + 2)) + ":" + getcomlumnname(vitribatdau) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString(pos + 2), Missing.Value).set_Value(Missing.Value, "ĐD thực hiện");
            ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString(pos + 2), Missing.Value).Font.Bold = true;
            ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString((int)(pos + 2)), Missing.Value).Orientation = 90;
            NewLateBinding.LateSetComplex(ws.Columns[getcomlumnname(vitribatdau), Missing.Value], null, "ColumnWidth", new object[] { 8 }, null, null, false, true);
            ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            //benh nhan ky ten 
            ws.get_Range(getcomlumnname(vitribatdau + 1) + Conversions.ToString((int)(pos + 2)) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range(getcomlumnname(vitribatdau + 1) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            ws.get_Range(getcomlumnname(vitribatdau + 1) + Conversions.ToString(pos + 2), Missing.Value).set_Value(Missing.Value, "BN ký tên");
            ws.get_Range(getcomlumnname(vitribatdau + 1) + Conversions.ToString(pos + 2), Missing.Value).Font.Bold = true;
            ws.get_Range(getcomlumnname(vitribatdau + 1) + Conversions.ToString((int)(pos + 2)), Missing.Value).Orientation = 90;
            NewLateBinding.LateSetComplex(ws.Columns[getcomlumnname(vitribatdau + 1), Missing.Value], null, "ColumnWidth", new object[] { 8 }, null, null, false, true);
            ws.get_Range(getcomlumnname(vitribatdau + 1) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
            ////format 
            ws.get_Range(getcomlumnname(0) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range(getcomlumnname(0) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).WrapText = 1;
            ws.get_Range(getcomlumnname(0) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Borders.LineStyle = 1;
            ws.get_Range(getcomlumnname(0) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).VerticalAlignment = XlVAlign.xlVAlignCenter;
            //thuc hien insert thong tin 
            #endregion
            #endregion

            #region nội dung table chitiet y lệnh
            int sodongtieptheo = 0;
            for (int mk = 0; mk < dt_YLenh.Rows.Count; mk++)
            {


                //so thu tu
                ws.get_Range(getcomlumnname(0) + Conversions.ToString((int)(mk + 7)) + ":" + getcomlumnname(0) + "" + Conversions.ToString((int)(mk + 7)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ws.get_Range(getcomlumnname(0) + Conversions.ToString(mk + 7) + ":" + getcomlumnname(0) + "" + Conversions.ToString((int)(mk + 7)), Missing.Value).Merge(Missing.Value);
                ws.get_Range(getcomlumnname(0) + Conversions.ToString(mk + 7), Missing.Value).set_Value(Missing.Value, (mk + 1).ToString());
                ws.get_Range(getcomlumnname(0) + Conversions.ToString(mk + 7), Missing.Value).RowHeight = 45;
                //phong 
                ws.get_Range(getcomlumnname(1) + Conversions.ToString(mk + 7), Missing.Value).set_Value(Missing.Value, string.Format("{0:0}", dt_YLenh.Rows[mk]["Phong"]));
                //giuong
                ws.get_Range(getcomlumnname(2) + Conversions.ToString(mk + 7), Missing.Value).set_Value(Missing.Value, dt_YLenh.Rows[mk]["Giuong"]);
                //ten benh nhan 
                ws.get_Range(getcomlumnname(3) + Conversions.ToString(mk + 7), Missing.Value).set_Value(Missing.Value, dt_YLenh.Rows[mk]["TenBenhNhan"]);
                //
                sodongtieptheo++;
                for (int socot = 0; socot < dt_Thuoc.Rows.Count; socot++)
                {
                    //cot thuoc
                    string SoThuoc = dt_YLenh.Rows[mk]["SoLuongThuoc_int_" + socot].ToString().Trim().Equals("0") ? "" : dt_YLenh.Rows[mk]["SoLuongThuoc_int_" + socot].ToString().Trim();
                    ws.get_Range(getcomlumnname(4 + socot) + Conversions.ToString(mk + 7), Missing.Value).set_Value(Missing.Value, SoThuoc);

                }
                ws.get_Range("A" + Conversions.ToString(mk + 7) + ":" + getcomlumnname(dt_Thuoc.Rows.Count + 5) + "" + Conversions.ToString((int)(mk + 7)), Missing.Value).Borders.LineStyle = 1;

            }
            ws.get_Range("A7:" + getcomlumnname(3 + dt_Thuoc.Rows.Count) + Conversions.ToString(dt_YLenh.Rows.Count + 6), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignLeft;
            ws.get_Range("A7:" + getcomlumnname(3 + dt_Thuoc.Rows.Count) + Conversions.ToString(dt_YLenh.Rows.Count + 6), Missing.Value).VerticalAlignment = XlVAlign.xlVAlignCenter;

            #endregion
            //cot du lieu tong cong 
            #region tổng cộng
            ws.get_Range(getcomlumnname(3) + Conversions.ToString(sodongtieptheo + 7), Missing.Value).set_Value(Missing.Value, "TỔNG CỘNG");
            ws.get_Range(getcomlumnname(3) + Conversions.ToString(sodongtieptheo + 7), Missing.Value).Font.Bold = true;
            ws.get_Range(getcomlumnname(0) + Conversions.ToString(sodongtieptheo + 7) + ":" + getcomlumnname(3) + "" + Conversions.ToString((int)(sodongtieptheo + 7)), Missing.Value).Merge(Missing.Value);
            for (int j = 0; j < dt_Thuoc.Rows.Count; j++)
            {
                float TongThuoc_j = 0;
                for (int i = 0; i < dt_YLenh.Rows.Count; i++)
                {
                    TongThuoc_j += StaticData.ParseFloat(dt_YLenh.Rows[i]["SoLuongThuoc_int_" + j]);
                }
                ws.get_Range(getcomlumnname(j + 4) + Conversions.ToString(sodongtieptheo + 7), Missing.Value).set_Value(Missing.Value, StaticData.FormatNumberOption(TongThuoc_j, ",", ".", true));
                ws.get_Range(getcomlumnname(j + 4) + Conversions.ToString(sodongtieptheo + 7), Missing.Value).Font.Bold = true;
                //set border 
                ws.get_Range("A" + Conversions.ToString(sodongtieptheo + 7) + ":" + getcomlumnname(dt_Thuoc.Rows.Count + 5) + "" + Conversions.ToString((int)(sodongtieptheo + 7)), Missing.Value).Borders.LineStyle = 1;
            }
            #endregion

            #region lưu file - mở file tại client
            int number = RandomNumber(0, 10000);
            string nvkFile = txtTuNgay.Value.Replace('/', ' ') + "_";
            string pathFile = Server.MapPath(@"~\ReportOutput\" + "tonghopylenhTra" + nvkFile + number + ".xls");

            TasWBook.SaveAs(pathFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, false, false, false, false, false);
            TasWBook.Close(false, false, false);
            ExApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(TasWBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ExApp);

            FileInfo file = new FileInfo(pathFile);
            if (file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=" + "tonghopylenh" + DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + number + ".xls");
                Response.AddHeader("Content-Type", "application/Excel");
                Response.ContentType = "application/vnd.xls";
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.End();
            }
            #endregion

            ws = null;
        }
        catch (Exception)
        {
            StaticData.MsgBox(this, "Không thể xuất Excel. Vui lòng kiểm tra lại Excel trên máy !");
            return;
        }
    }

    protected string getcomlumnname(int vitri)
    {
        //tu A_Z
        int vitrimoi = 0;
        String[] MANGKYTU ={ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        if (vitri <= 25)
        {
            return MANGKYTU[vitri];
        }
        else
        {
            int solan = (int)vitri / 26;
            if (solan == 1)
                solan = 0;
            if (vitri > 26)
            {
                if (solan > 1)
                {
                    //if so lan ==2 

                    vitrimoi = (int)vitri % 26;
                    solan = solan - 1;
                }
                else
                {
                    vitrimoi = (vitri / 1) - 26;
                }
            }
            if (vitri == 25)
                vitrimoi = 25;
            return MANGKYTU[solan] + MANGKYTU[vitrimoi];
        }
    }
    protected void TastStartExcel([Optional, DefaultParameterValue("Sheet1")] string SheetName)
    {
        try
        {
            ExApp = new ApplicationClass();
            ExApp.StandardFont = "Arial";
            ExApp.StandardFontSize = 10;
            TasWBook = ExApp.Workbooks.Add(Missing.Value);

            TasWSheet = (Worksheet)ExApp.Worksheets["Sheet1"];
            TasWSheet.Name = SheetName;
            ExApp.Visible = false;

        }
        catch (Exception ex)
        {
            throw new Exception("Có lỗi xảy ra :" + ex.Message);

        }
    }
    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    #endregion
}
