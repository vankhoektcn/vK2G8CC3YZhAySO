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
using Microsoft.Office.Interop.Excel;
using System.Reflection;
//using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;


public partial class nvk_YLenhNgoaiTruTheoBN : System.Web.UI.Page
{
    public static Application ExApp;
    public static Workbook TasWBook;
    public static Worksheet TasWSheet;

    private ReportDocument report;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadKhoThuoc();
            LoadLoaiThuoc();
            StaticData.SetFocus(this,"ddlLoaiThuoc");
        }
         //   GetReport(IsPostBack);
        if (hdListIdG.Value != "" && hdListIdG.Value != "0")
            divGiuongDaChon.InnerHtml = "<input type='button' value='Hiện BN' id='btnHienThiCTG'  onclick='setBenhNhan(0,0);'/><input type='button' value='Mới' id='btnClearCTG'  onclick='ClearDanhSachGiuong();'/>";
        else
            divGiuongDaChon.InnerHtml = "CHƯA CHỌN BỆNH NHÂN !";
        LoadMenu();
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
    private void LoadLoaiThuoc()
    {
        string sqlLK = "select * from thuoc_loaithuoc";
        System.Data.DataTable dtLK = DataAcess.Connect.GetTable(sqlLK);
        if (dtLK != null && dtLK.Rows.Count > 0)
            StaticData.FillCombo(ddlLoaiThuoc, dtLK, "loaithuocid", "tenloai");
    }
    private void LoadKhoThuoc()
    {
        string sqlLK = "select * from khothuoc where idkhoa='" + Request.QueryString["IdKhoa"] + "'";
        System.Data.DataTable dtLK = DataAcess.Connect.GetTable(sqlLK);
        if (dtLK != null && dtLK.Rows.Count > 0)
            StaticData.FillCombo(ddlKhoThuoc, dtLK, "idkho", "tenkho", "---Tất cả kho---");
    }
    private void LoadDanhSachPhong()
    {
        string sqlPhong = "select p.* from kb_PHONG p left join banggiadichvu bg on bg.idbanggiadichvu=p.DichVuKCB where  isPhongNoiTru=1 and bg.idphongkhambenh=" + Request.QueryString["idkhoa"] + " order by TenPhong";
        System.Data.DataTable dtPhong = DataAcess.Connect.GetTable(sqlPhong);
        string ListPhongHtml="";
        if (dtPhong.Rows.Count > 0)
        {
            for (int i = 0; i < dtPhong.Rows.Count; i++)
            {
                ListPhongHtml += @"<input type='button' id='" + dtPhong.Rows[i]["id"] + "' runat='server' onclick='Phong_click(this)' value='" + dtPhong.Rows[i]["TenPhong"].ToString() + @"' class='botton_Phong' style='' />";
                if ((i+1) % 10 == 0 || (i+1) % 10 == 5)
                    ListPhongHtml += "<br />";
            }
        }
        divChonGiuong.InnerHtml = ListPhongHtml;
    }
    //protected void btnXuatExcel_Click(object sender, EventArgs e)
    //{

    //}
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        string idkhoa = Request.QueryString["idkhoa"] != null ? Request.QueryString["idkhoa"] : "0";
        string nvk_MeNu = Request.QueryString["dkmenu"] != null ? Request.QueryString["dkmenu"] : "phongsanh";
        string TuNgay_Gio = StaticData.CheckDate(txtTuNgay.Text.Trim()) + " " + txtTuGio.Value.Trim();
        string DenNgay_Gio = StaticData.CheckDate(txtDenNgay.Text.Trim()) + " " + txtDenGio.Value.Trim();
        string nvk_KhoangNgay = "Từ ngày " + txtTuNgay.Text + " " + txtTuGio.Value.Trim() + "   Đến ngày " + txtDenNgay.Text + " " + txtDenGio.Value.Trim();
        if (hdListIdG.Value == "" || hdListIdG.Value == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn bệnh nhân. Hãy chọn bệnh nhân trước !"); return;
        }
#region chuẩn bị dữ liệu

        #region Danh sách Bệnh Nhân
        string ListId_BenhNhan = hdListIdG.Value;
        ListId_BenhNhan = ListId_BenhNhan.TrimEnd(',');
        #endregion

        #region Danh sách thuốc, Vtyt...
        string nvk_idKhoIn = "";
        if (!ddlKhoThuoc.SelectedValue.Equals("0"))
            nvk_idKhoIn = " and ct.idkho='"+ddlKhoThuoc.SelectedValue+"' ";
        //ddlKhoThuoc.SelectedItem.Text;
        #region LoaiYlenh
        string dkLoaiYL = "";
        if (ddlLoaiYLenh.SelectedValue.Equals("2"))// bổ sung, dự trù
            dkLoaiYL = " and isnull(kb.maphieukham,'')<>'pkxk'";
        if (ddlLoaiYLenh.SelectedValue.Equals("3"))// Toa ra viện
            dkLoaiYL = " and isnull(kb.maphieukham,'')='pkxk'";
        #endregion
        string sql_Thuoc = @"select * from (
        select distinct idColumn=t.idthuoc,MaThuoc='('+donvitinh+')'+TenThuoc,TenThuoc,dvt.nvk_UuTienYL,pk.tenphongkhambenh
        from chitietbenhnhantoathuoc ct inner join thuoc t on t.idthuoc=ct.idthuoc left join thuoc_donvitinh dvt on dvt.id=t.iddvt
        inner join khambenh kb on kb.idkhambenh=ct.idkhambenh  inner join phongkhambenh pk on pk.idphongkhambenh =kb.idphongkhambenh
        where isnull(t.loaithuocid,1)=" + ddlLoaiThuoc.SelectedValue + @" " + nvk_idKhoIn + " and kb.idphongkhambenh=" + idkhoa + dkLoaiYL+@"
        
            and (  ( ngaykham >='" + TuNgay_Gio + "' and ngaykham <='" + DenNgay_Gio + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
                or ( ngayDuTruThuoc >='" + TuNgay_Gio + "' and ngayDuTruThuoc <='" + DenNgay_Gio + @"' )
            )";
        if(nvk_MeNu.ToLower().Equals("phongsanh"))
            sql_Thuoc += @" and not exists (select idbenhnhan from benhnhannoitru where idbenhnhan=kb.idbenhnhan and isdanhap=1 and isnull(ischosanh,0)=0)";

        sql_Thuoc += @" and idbenhnhan in(" + ListId_BenhNhan + @")
) as abc
order by nvk_UuTienYL
        ";
        System.Data.DataTable dt_Thuoc = DataAcess.Connect.GetTable(sql_Thuoc);
        if (dt_Thuoc == null || dt_Thuoc.Rows.Count == 0)
        {
            StaticData.MsgBox(this,"Không có Y lệnh !"); return;
        }
        #endregion

        #region Chi tiết bệnh nhân y lệnh rỗng
        string sql_YLenh = @"
            select bn.idbenhnhan
            ,Phong=tenphong,Giuong=giuongcode,MaBenhNhan=bn.mabenhnhan,TenBenhNhan=bn.TenBenhNhan+' ('+dbo.GetNamSinh(bn.ngaysinh )+')'";
            for (int j = 0; j < dt_Thuoc.Rows.Count; j++)
            {
                sql_YLenh += @",SoLuongThuoc_int_" + j + @"=0.0
                    ";
//                sql_YLenh += @",SoLuongThuoc_int_"+j+ @"=isnull(
//                (select sum(isnull(soluongke,0)-isnull(soluongtra,0)) from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh where isnull(kb.maphieukham,'') <> 'pkxk' and 
//		                idthuoc='" + dt_Thuoc.Rows[j]["idColumn"] + @"'  and kb.idbenhnhan=bn.idbenhnhan  and kb.idphongkhambenh='" + idkhoa + "' "+nvk_idKhoIn+@"
//		                
//                    and (  ( ngaykham >='" + TuNgay_Gio + "' and ngaykham <='" + DenNgay_Gio + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
//                        or ( ngayDuTruThuoc >='" + TuNgay_Gio + "' and ngayDuTruThuoc <='" + DenNgay_Gio + @"' )
//                    )
//                )
//                ,0)";
            }
            sql_YLenh += @"
    from   benhnhan bn left join benhnhannoitru nt on nt.idbenhnhan=bn.idbenhnhan
--
 and nt.idnoitru in(select top 1 idnoitru from benhnhannoitru where idbenhnhan =bn.idbenhnhan order by NgayVaoVien desc) 
---
                        left join kb_giuong g on g.giuongid=nt.idgiuong left join  kb_phong p on g.idphong=p.id
    where  bn.idbenhnhan in(" + ListId_BenhNhan + @")";
            if (nvk_MeNu.ToLower().Equals("phongsanh"))
                sql_YLenh += @" and not exists (select idbenhnhan from benhnhannoitru where idbenhnhan=bn.idbenhnhan and isdanhap=1 and isnull(ischosanh,0)=0)";

            sql_YLenh += @"
    order by phong,tenbenhnhan ";
        System.Data.DataTable dt_YLenh = DataAcess.Connect.GetTable(sql_YLenh);
        #endregion

        #region Chi tiết bệnh nhân y lệnh thực
        if(dt_YLenh == null || dt_YLenh.Rows.Count==0)
        {
            StaticData.MsgBox(this, "Không có nội dung !"); return;
        }
        for (int i = 0; i < dt_YLenh.Rows.Count; i++)
        {
            for (int j = 0; j < dt_Thuoc.Rows.Count; j++)
            {
                string sql_Thuoc_j = @"select SoLuongThuoc_int_"+j+ @"=isnull(
                (select sum(isnull(soluongke,0)-isnull(soluongtra,0)) from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh where  
		                idthuoc='" + dt_Thuoc.Rows[j]["idColumn"] + @"'  and kb.idbenhnhan='"+dt_YLenh.Rows[i]["idbenhnhan"]+"'  and kb.idphongkhambenh='" + idkhoa + "' "+nvk_idKhoIn + dkLoaiYL +@"
		                
                    and (  ( ngaykham >='" + TuNgay_Gio + "' and ngaykham <='" + DenNgay_Gio + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
                        or ( ngayDuTruThuoc >='" + TuNgay_Gio + "' and ngayDuTruThuoc <='" + DenNgay_Gio + @"' )
                    )
                )
                ,0)";
                System.Data.DataTable dt_thuoc_j = DataAcess.Connect.GetTable(sql_Thuoc_j);
                if (dt_thuoc_j != null && dt_thuoc_j.Rows.Count > 0)
                    dt_YLenh.Rows[i][j+5] = dt_thuoc_j.Rows[0][0];
            }
        }
        #endregion

#endregion

#region xuat excel
        try
        {
            string TieuDeYLenh = "Tổng hợp y lệnh";
            int nvk_SoCotNgoaiThuoc = 5;
            int ColumnWidth_Detail = 8;
            if (nvk_MeNu.ToLower().Equals("capcuu"))
            {
                TieuDeYLenh = "Báo cáo sử dụng thuốc Cấp cứu";
                if(dt_YLenh.Rows.Count > 1)
                    nvk_SoCotNgoaiThuoc = 3;
                ColumnWidth_Detail = 3;
            }
            int startRow = 1;
            TastStartExcel("tonghopylenh" + DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString());
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
            if (ddlKhoThuoc.SelectedValue.Equals("0"))
                tenkhoaYlenh = tenkhoaYlenh + " :" + ddlKhoThuoc.SelectedItem.Text;
            else
                tenkhoaYlenh = ddlKhoThuoc.SelectedItem.Text;
            ws.get_Range("A" + Conversions.ToString((int)(pos - 2)), Missing.Value).set_Value(Missing.Value, tenkhoaYlenh);
            ws.get_Range("A" + Conversions.ToString((int)(pos - 2)), Missing.Value).Font.Bold = true;
            ws.get_Range("A" + Conversions.ToString((int)(pos - 2)), Missing.Value).Font.Size = 12;

            //ws.get_Range("A" + Conversions.ToString((int)(pos - 1)) + ":D" + Conversions.ToString((int)(pos - 1)), Missing.Value).Merge(Missing.Value);
            //ws.get_Range("A" + Conversions.ToString((int)(pos - 1)) + ":D" + Conversions.ToString((int)(pos - 1)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //ws.get_Range("A" + Conversions.ToString((int)(pos - 1)), Missing.Value).set_Value(Missing.Value, "Ngày " + DateTime.Now.Date.ToString("dd/MM/yyyy"));
            //ws.get_Range("A" + Conversions.ToString((int)(pos - 1)), Missing.Value).Font.Bold = true;
            //ws.get_Range("A" + Conversions.ToString((int)(pos - 1)), Missing.Value).Font.Size = 12;

            //canh trái 4 ô đầu
            ws.get_Range("A" + Conversions.ToString((int)(pos - 1)) + ":D" + Conversions.ToString((int)(pos - 1)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignLeft;

            //hien thi tong hop y lenh
            ws.get_Range("A" + Conversions.ToString((int)(pos)) + ":" + getcomlumnname(dt_Thuoc.Rows.Count + nvk_SoCotNgoaiThuoc) + "" + Conversions.ToString((int)(pos)), Missing.Value).Merge(Missing.Value);
            ws.get_Range("A" + Conversions.ToString((int)(pos)), Missing.Value).set_Value(Missing.Value, TieuDeYLenh);
            ws.get_Range("A" + Conversions.ToString((int)(pos)), Missing.Value).Font.Bold = true;
            ws.get_Range("A" + Conversions.ToString((int)(pos)), Missing.Value).Font.Size = 24;
            ws.get_Range("A" + Conversions.ToString((int)(pos)) + ":I" + Conversions.ToString((int)(pos)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //hien thi ngay thang 
            ws.get_Range("A" + Conversions.ToString((int)(pos + 1)) + ":" + getcomlumnname(dt_Thuoc.Rows.Count + nvk_SoCotNgoaiThuoc) + "" + Conversions.ToString((int)(pos + 1)), Missing.Value).Merge(Missing.Value);
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

                NewLateBinding.LateSetComplex(ws.Columns[getcomlumnname(vitribatdau), Missing.Value], null, "ColumnWidth", new object[] { ColumnWidth_Detail }, null, null, false, true);
                ws.get_Range(getcomlumnname(vitribatdau) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Merge(Missing.Value);
                vitribatdau++;
            }
            #endregion
            //tim cot tiep theo

            //cot da thuc hien 
            #region tiêu đề DD thuc hien,BN ky ten
            if (!nvk_MeNu.ToLower().Equals("capcuu") || dt_YLenh.Rows.Count == 1)
            {
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
            }
            else
                vitribatdau = vitribatdau - 2;
            #endregion

            ////format 
            //ws.get_Range(getcomlumnname(0) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //ws.get_Range(getcomlumnname(0) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).WrapText = 1;
            //ws.get_Range(getcomlumnname(0) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).Borders.LineStyle = 1;
            //ws.get_Range(getcomlumnname(0) + Conversions.ToString(pos + 2) + ":" + getcomlumnname(vitribatdau + 1) + "" + Conversions.ToString((int)(pos + 2)), Missing.Value).VerticalAlignment = XlVAlign.xlVAlignCenter;
            ws.get_Range("A6:" + getcomlumnname(vitribatdau + 1) + "6", Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range("A6:" + getcomlumnname(vitribatdau + 1) + "6", Missing.Value).WrapText = 1;
            ws.get_Range("A6:" + getcomlumnname(vitribatdau + 1) + "6", Missing.Value).Borders.LineStyle = 1;
            ws.get_Range("A6:" + getcomlumnname(vitribatdau + 1) + "6", Missing.Value).VerticalAlignment = XlVAlign.xlVAlignCenter;
            //thuc hien insert thong tin 
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
                //ws.get_Range(getcomlumnname(mk) + Conversions.ToString(mk + 7) + ":" + getcomlumnname(mk + 3) + "" + Conversions.ToString((int)(mk + 3)), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //ws.get_Range(getcomlumnname(mk) + Conversions.ToString(mk + 7) + ":" + getcomlumnname(mk + 7) + "" + Conversions.ToString((int)(mk + 8)), Missing.Value).WrapText = 1;
                //set border 
                ws.get_Range("A" + Conversions.ToString(mk + 7) + ":" + getcomlumnname(dt_Thuoc.Rows.Count + nvk_SoCotNgoaiThuoc) + "" + Conversions.ToString((int)(mk + 7)), Missing.Value).Borders.LineStyle = 1;

            }
            //ws.get_Range(getcomlumnname(4 + socot) + Conversions.ToString(mk + 7), Missing.Value).HorizontalAlignment = XlHAlign.xlHAlignLeft;
            //ws.get_Range(getcomlumnname(mk) + Conversions.ToString(mk + 7) + ":" + getcomlumnname(mk + 7) + "" + Conversions.ToString((int)(mk + 8)), Missing.Value).VerticalAlignment = XlVAlign.xlVAlignCenter;
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
            }
            ws.get_Range("A" + Conversions.ToString(sodongtieptheo + 7) + ":" + getcomlumnname(dt_Thuoc.Rows.Count + nvk_SoCotNgoaiThuoc) + "" + Conversions.ToString((int)(sodongtieptheo + 7)), Missing.Value).Borders.LineStyle = 1;
            #endregion

            #region lưu file - mở file tại client
            int number = RandomNumber(0, 10000);
            string nvkFile = txtTuNgay.Text.Replace('/', ' ') + "_";
            string pathFile = Server.MapPath(@"~\ReportOutput\" + "tonghopylenh" + nvkFile + number + ".xls");

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
#endregion

        #region nvk xuất excel html 
        //string ht = "";
        //ht += "<table width='100%' bordercolor=\"#333\" border=1 style=\"border-collapse:collapse;\" cellpadding=3 cellspacing=0>";
        //ht += "<tr><td rowspan=\"1\"></td><td colspan=2></td></tr>";
        //ht += "<tr style=\"background:#CCCCCC;height:100px\"><td style='width:30px;font-weight:bold; color: Blue' align='center'>STT</td><td style='width:50px;font-weight:bold; color: Blue' align='center'>Phòng</td><td style='width:50px;font-weight:bold; color: Blue' align='left'>Giường</td><td style='width:150px;font-weight:bold; color: Blue' align='center'>Họ Tên Bệnh Nhân</td>";
        //#region tên cột (tên thuốc)
        //for (int j = 0; j < dt_Thuoc.Rows.Count; j++)
        //{
        //    ht += @"<td style='width:60px;font-weight:bold; color: Blue;'>" + dt_Thuoc.Rows[j]["tenthuoc"] + "</td>";
        //}
        //ht += "<td style='width:60px;font-weight:bold; color: Red' align='center'>ĐD thực hiện</td>";
        //ht += "<td style='width:60px;font-weight:bold; color: Red' align='center'>BN ký tên</td>";
        //#endregion
        //ht += "</tr>";
        //#region nội dung y lệnh
        //for (int i = 0; i < dt_YLenh.Rows.Count;i++ )
        //{
        //    ht += "<tr style='height:70px'><td class=textmode>" + dt_YLenh.Rows[i]["stt"] + "</td><td class=textmode>" + string.Format("{0:0}", dt_YLenh.Rows[i]["Phong"]) + "</td><td  class=textmode>" + dt_YLenh.Rows[i]["Giuong"] + "</td><td  class=textmode>" + dt_YLenh.Rows[i]["TenBenhNhan"] + "</td>";
        //    for (int j = 0; j < dt_Thuoc.Rows.Count; j++)
        //    {
        //        if (dt_YLenh.Rows[i]["SoLuongThuoc_int_" + j].ToString().Trim().Equals("0"))
        //            ht += "<td style='width:60px' align='left'></td>";
        //        else
        //            ht += "<td style='width:60px' align='left'>" + dt_YLenh.Rows[i]["SoLuongThuoc_int_" + j] + "</td>";
        //    }
        //    ht += "<td style='width:60px' align='left'></td>";
        //    ht += "<td style='width:60px' align='left'></td>";
        //    ht += "</tr>";
        //}
        //#endregion
        //#region Tổng cộng
        //ht += "<tr><td class=textmode></td><td class=textmode></td><td  class=textmode></td><td  class=textmode style='font-weight:bold;' align='right'>TỔNG CỘNG :</td>";
        //for (int j = 0; j < dt_Thuoc.Rows.Count; j++)
        //{
        //    float TongThuoc_j = 0;
        //    for (int i = 0; i < dt_YLenh.Rows.Count; i++)
        //    {
        //        TongThuoc_j += StaticData.ParseFloat(dt_YLenh.Rows[i]["SoLuongThuoc_int_" + j]);
        //    }
        //    ht += "<td style='width:60px;font-weight:bold;' align='left'>" + StaticData.FormatNumberOption(TongThuoc_j, ",", ".", true) + "</td>";
        //}
        //ht += "<td style='width:60px' align='left'></td>";
        //ht += "<td style='width:60px' align='left'></td>";
        //ht += "</tr>";
        //#endregion
        //ht += "</table>";
        //Response.Clear();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition",
        //"attachment;filename=dsYLenhTrongNgay" + txtTuNgay.Text + ".xls");
        //Response.Charset = "";
        //Response.ContentType = "application/vnd.ms-excel";
        //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //string ngay = "Ngày " + txtTuNgay.Text;
        //Response.Write(style);
        //Response.Output.Write("<div style=\"font-weight:bold; font-size:13px;\" align=left>BV Đa Khoa Minh Đức</div>");
        //Response.Output.Write("<div style=\"font-weight:bold; font-size:13px;\" align=left>Khoa Sản</div>");
        //Response.Output.Write("<div style=\"font-weight:bold; font-size:13px;\" align=left>"+ngay+"</div>");

        //Response.Output.Write("<div style=\"font-weight:bold; font-size:17px;color:Red\" align=center>TỔNG HỢP Y LỆNH</div>");
        //Response.Output.Write("<div style=\"font-weight:bold; font-size:15px;\" align=center>" + ngay + "</div>");
        //Response.Output.Write(ht);
        //Response.Flush();
        //Response.End(); 
        #endregion
    }
    protected void R_Unload(object sender, EventArgs e)
    {
        if (report != null)
        {
            report.Clone();
            report.Dispose();
            R.Dispose();
            R = null;
            GC.Collect();
        }
    }

    private int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    protected void form_unload(object sender, EventArgs e)
    {
        if (report != null)
        {
           report.Clone();
            report.Dispose();
            report = null;
            //giai phong bo nho va kill excel process
            ExApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ExApp);
            ExApp = null;
            TasWBook = null;
            TasWSheet = null;
            //end kill
            GC.Collect();
        }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtTuNgay.Text = "anjsndaa";
    }

    protected void btnAutoClick_Click(object sender, EventArgs e)
    {

    }

    protected string getcomlumnname(int vitri)
    {
        //tu A_Z
        int vitrimoi = 0;
        String[] MANGKYTU ={ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        String[] makytu1 = MANGKYTU;
        String[] makytu2 = MANGKYTU;
        for (int i = 0; i < makytu2.Length; i++)
        {
            for (int j = 0; j < makytu2.Length; j++)
            {
                Array.Resize<String>(ref MANGKYTU, MANGKYTU.Length + 1);
                MANGKYTU[MANGKYTU.Length - 1] = makytu1[i].ToString() + makytu2[j].ToString();
            }
        }
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
}
