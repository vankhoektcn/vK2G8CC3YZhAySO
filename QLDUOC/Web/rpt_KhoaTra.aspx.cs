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


public partial class QLDUOC_Web_rpt_KhoaTra : System.Web.UI.Page
{
    private profess_Rpt_khoatra bbkn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtNam.Value = DateTime.Now.Year.ToString();
            bindkho();
            this.bindLoaiThuoc(); this.ddlLoaiThuoc.SelectedValue = "1";
        }
    }
    private void bindLoaiThuoc()
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from Thuoc_LoaiThuoc");
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow DR1 = dt.NewRow();
            DR1[0] = StaticData.GetParameter("nvk_idLoaiThuocGayNghien") != null ? StaticData.GetParameter("nvk_idLoaiThuocGayNghien") : "5";
            DR1[1] = "THUOCGN";
            DR1[2] = "T.G.Nghiện";
            dt.Rows.Add(DR1);

            DataRow DR2 = dt.NewRow();
            DR2[0] = StaticData.GetParameter("nvk_idLoaiThuocHuongTamThan") != null ? StaticData.GetParameter("nvk_idLoaiThuocHuongTamThan") : "6";
            DR2[1] = "THUOCHTT";
            DR2[2] = "T.Hướng TT";
            dt.Rows.Add(DR2);
            StaticData.FillCombo(this.ddlLoaiThuoc, dt, "LoaithuocID", "TenLoai", "Tất cả các nhóm ");
        }
    }
    private void bindkho()
    {
        DataTable dt = tableKho();
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddlkho, dt, "idkho", "tenkho", "-------------Chọn kho------------");
            ddlkho.SelectedValue = StaticData.MacDinhKhoNhapMuaID;
        }
    }
    private DataTable tableKho()
    {
        return DataAcess.Connect.GetTable("select idkho,makho,tenkho=replace(tenkho,N'-tủ trực',''),idkhoa=isnull(idkhoa,0) from khothuoc where isnull(iskt,0)=0 and nvk_loaikho in(2,3) order by idkhoa,tenkho");//StaticData.dtGetKho2(this, true); 
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        //this.bbkn = new profess_Rpt_khoatra();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename=dsKhoaTraDuoc_" + ddlThang.Value + "-" + txtNam.Value + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        string ngay = "Ngày ";
        Response.Write(style);
        DataTable dtKho = tableKho();
        if (ddlkho.SelectedValue != "0" && ddlkho.SelectedValue != "")
            dtKho = DataAcess.Connect.GetTable("select idkho,makho,tenkho=replace(tenkho,N'-tủ trực',''),idkhoa=isnull(idkhoa,0) from khothuoc where idkho='" + ddlkho.SelectedValue + "'");
        bool isXuatTheoKhoa = false;
        if (Request.QueryString["XuatTheoKhoa"] != null && Request.QueryString["XuatTheoKhoa"].ToString().Equals("1"))
            isXuatTheoKhoa = true;
        DataTable dtBaoCao = tableBaoCao(dtKho, ddlLoaiThuoc.SelectedValue, txtTenThuoc.Text, ddlThang.Value, txtNam.Value, isXuatTheoKhoa);
        string html = nvk_getHtmlNoiDungBaoCao(dtKho, dtBaoCao, isXuatTheoKhoa);
        Response.Output.Write(html);
        Response.Flush();
        Response.End();
    }
    private DataTable tableBaoCao(DataTable dtKho, string doiTuong, string tenThuoc, string thang, string nam, bool isXuatTheoKhoa)
    {
        #region đối tượng thuốc
        string LoaiThuocIn = "";
        if (!doiTuong.Equals("0") && !doiTuong.Equals(""))
        {
            if (doiTuong == "1")
            {
                LoaiThuocIn = " and A.LoaiThuociD=1 and  isnull(a.IsTGN,0)=0  and isnull(a.IsTHTT,0)=0 ";
            }
            else if (doiTuong == StaticData.GetParameter("nvk_idLoaiThuocGayNghien"))
            {
                LoaiThuocIn = " and t.IsTGN=1";
            }
            else if (doiTuong == StaticData.GetParameter("nvk_idLoaiThuocHuongTamThan"))
            {
                LoaiThuocIn = " and t.IsTHTT=1";
            }
            else
                LoaiThuocIn = " and a.LoaiThuociD=" + doiTuong + "";
        }
        #endregion
        string sqlSelect = @"select thuoc=tenthuoc,TenDVT";
        for (int i = 0; i < dtKho.Rows.Count; i++)
        {
            if (isXuatTheoKhoa)
            {
                sqlSelect += @" 
            ,Xuat_" + dtKho.Rows[i]["IdKho"].ToString() + @"=
              ISNULL((SELECT SUM(A1.SOLUONG) FROM CHITIETPHIEUXUATKHO A1
                      LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                       WHERE b1.loaixuat=4 and b1.idkho2<>5 and isnull(b1.ISHONGVO,0)=0
                            and  B1.IDKHO=" + StaticData.GetParameter("nvk_idKhoDuoc") + @"
                            and B1.IDKHO2=" + dtKho.Rows[i]["IdKho"].ToString() + @"
                            AND month(ngaythang)='" + thang + "' AND year(NGAYTHANG)='" + nam + @"'
                          AND A1.IDTHUOC=a.idthuoc
                  ),0)";
            }
            else
            {
                sqlSelect += @" 
            ,tra_" + dtKho.Rows[i]["IdKho"].ToString() + @"=
              ISNULL((   SELECT SUM(ct.SOLUONG) FROM CHITIETPHIEUnhapKHO ct
                        inner JOIN PHIEUnhapKHO pn ON pn.IDPHIEUnhap=ct.IDPHIEUnhap
						inner join nvk_thuoc_phieuyctra yc on yc.sophieu=pn.sophieuyc
                         WHERE pn.idkho=" + StaticData.GetParameter("nvk_idKhoDuoc")
                            + @" AND month(ngaythang)='" + thang + @"'
                             AND year(NGAYTHANG)='" + nam + @"'
                             AND ct.IDTHUOC=a.idthuoc
                             AND pn.idloainhap=4
                             and yc.idphongkhambenh=" + dtKho.Rows[i]["IdKho"].ToString() + @"
                   ),0)";
            }
        }
        sqlSelect += @"
            from thuoc a
            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
            left join Thuoc_DonViTinh dvt on dvt.id=a.iddvt
            where a.isThuocBV=1
             " + LoaiThuocIn + " " + (tenThuoc == null || tenThuoc.Trim().Equals("") ? "" : " and A.tenthuoc like N'%" + tenThuoc + "%'") + " order by tenthuoc";
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        return dt;
    }
    private string nvk_getHtmlNoiDungBaoCao(System.Data.DataTable dtKho, System.Data.DataTable dtNoiDung, bool isXuatTheoKhoa)
    {
        if (dtNoiDung == null || dtNoiDung.Rows.Count == 0)
            return "Không tìm thấy báo cáo";
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append(@"<table class='tableBaoCao' width='100%' bordercolor='#333' border=1 style='border-collapse:collapse;' cellpadding=3 cellspacing=0>");

        #region các dòng header
        string TieuDeBaoCao = "";
        if (isXuatTheoKhoa)
            TieuDeBaoCao = "TỔNG SỐ LƯỢNG XUẤT " + (!ddlLoaiThuoc.SelectedValue.Equals("0") ? ddlLoaiThuoc.SelectedItem.Text.ToUpper() : "") + " CHO CÁC KHOA PHÒNG THÁNG " + ddlThang.Value + " NĂM " + txtNam.Value;
        else
            TieuDeBaoCao = "BÁO CÁO SỐ LƯỢNG " + (!ddlLoaiThuoc.SelectedValue.Equals("0") ? ddlLoaiThuoc.SelectedItem.Text.ToUpper() : "") + " CÁC KHOA TRẢ THÁNG " + ddlThang.Value + " NĂM " + txtNam.Value;
        int SoCot = dtNoiDung.Columns.Count + 2;
        html.Append("<tr><td  colspan='" + SoCot + "' align='left'><span class='sp_Blue_Bold'  style='font-size: 16px;color:Blue;'>BỆNH VIỆN ĐA KHOA MINH ĐỨC</span></td></tr>");
        html.Append("<tr><td  colspan='" + SoCot + "' align='left'><span class='sp_Blue_Bold'  style='font-size: 16px;color:Blue;'>KHOA DƯỢC</span></td></tr>");
        html.Append("<tr><td  colspan='" + SoCot + "' align='center'><span class='sp_Blue_Bold'  style='font-size: 22px;font-weight:bold;color:Purple;'>" + TieuDeBaoCao + "</span></td></tr>");
        html.Append("<tr><td  colspan='" + SoCot + "' align='center'><span class='sp_Blue_Bold'  style='font-size: 22px;font-weight:bold;color:Blue;'></span></td></tr>");
        #endregion
        #region dòng tiêu đề
        html.Append(@"<tr>");
        html.Append(@"
                        <td style='width:50px;height:auto'><span class='sp_Red_Bold' style='font-size: 16px;color:Green;font-weight:bold;'>Stt</span></td>
                        <td style='width:250px;height:auto'><span class='sp_Red_Bold' style='font-size: 16px;color:Green;font-weight:bold;'>Thuốc - Hàm lượng</span></td>
                        <td style='width:50px;height:auto'><span class='sp_Red_Bold' style='font-size: 16px;color:Green;font-weight:bold;'>Đvt</span></td>");
        #region Color Khoa
        string[] arrColor = { "Red", "Blue", "Purple", "Orange", "Green", "Brown" };
        string[] arrIdkho;
        DataTable dtKhoa = DataAcess.Connect.GetTable("select distinct idkhoa=isnull(idkhoa,0) from khothuoc where isnull(iskt,0)=0 and nvk_loaikho in(2,3) order by idkhoa");
        int vitri = 0;
        DataTable dtSetColor = new DataTable();
        string strType = "";
        for (int i = 0; i < dtKhoa.Rows.Count; i++)
        {
            dtSetColor.Columns.Add("K" + dtKhoa.Rows[i]["idkhoa"].ToString(), strType.GetType());
        }
        DataRow row = dtSetColor.NewRow();
        for (int i = 0; i < dtKhoa.Rows.Count; i++)
        {
            row[i] = arrColor[vitri];
            vitri++;
            if (vitri == 6)
                vitri = 0;
        }
        dtSetColor.Rows.Add(row);
        #endregion
        for (int i = 0; i < dtKho.Rows.Count; i++)
        {
            string Color = dtSetColor.Rows[0]["K" + dtKho.Rows[i]["idkhoa"].ToString()].ToString();
            html.Append(@"
                        <td align='center' style='color:" + Color + ";font-weight:bold;width:65px;height:auto'><span class='sp_Red_Bold' style='font-size: 16px;' >" + dtKho.Rows[i]["tenkho"] + "</span></td>");
        }
        html.Append(@"<td style='width:50px;height:auto'><span class='sp_Red_Bold' style='font-size: 16px;color:Green;font-weight:bold;'>Tổng cộng</span></td>");
        html.Append(@"</tr>");
        #endregion
        #region thân báo cáo
        for (int i = 0; i < dtNoiDung.Rows.Count; i++)
        {
            html.Append(@"<tr>");
            html.Append(@"<td align='center' style='font-size: 16px;' >" + (i + 1) + "</td>");
            html.Append(@"<td style='font-size: 16px;' > " + dtNoiDung.Rows[i]["thuoc"] + "</td>");
            html.Append(@"<td align='center' style='font-size: 16px;' > " + dtNoiDung.Rows[i]["TenDVT"] + "</td>");
            float tongCong = 0;
            for (int j = 2; j < dtNoiDung.Columns.Count; j++)
            {
                tongCong += StaticData.ParseFloat(dtNoiDung.Rows[i][j]);
                if (dtNoiDung.Rows[i][j].ToString().Equals("0"))
                    html.Append(@"<td></td>");
                else
                    html.Append(@"<td style='font-size: 16px;'>" + dtNoiDung.Rows[i][j] + "</td>");
            }
            html.Append(@"<td style='font-size: 16px;'>" + tongCong.ToString() + "</td>");
            html.Append(@"</tr>");
        }
        #endregion
        #region footer báo cáo
        html.Append("<tr><td  colspan='" + SoCot + "' align='center'><span class='sp_Blue_Bold'  style='font-size: 22px;font-weight:bold;color:Blue;'></span></td></tr>");
        html.Append(@"<tr>
                <td  colspan=2 align='center'><span  style='font-size: 16px;font-weight:bold;color:black;'>Người lập</span></td>
                " + ((SoCot - 5) <= 0 ? "" : "<td  colspan='" + (SoCot - 5) + "' align='left'></td>") + @"
                <td  colspan=3 align='center'><span  style='font-size: 16px;font-weight:bold;color:black;'>Trưởng khoa Dược</span></td>
            </tr>");
        html.Append(@"<tr>
                <td  colspan=2 align='center'><span  style='font-size: 16px;font-style:italic;color:black;'>(Ký, họ tên)</span></td>
                " + ((SoCot - 5) <= 0 ? "" : "<td  colspan='" + (SoCot - 5) + "' align='left'></td>") + @"
                <td  colspan=3 align='center'><span  style='font-size: 16px;font-style:italic;color:black;'>(Ký, họ tên)</span></td>
            </tr>");
        #endregion
        html.Append(@"</table>");
        return html.ToString();
    }
}
