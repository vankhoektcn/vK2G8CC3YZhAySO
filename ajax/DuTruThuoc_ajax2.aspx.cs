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
using System.Text;
public partial class ajax_DuTruThuoc_ajax2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "loaithuocidsearch": loaithuocidsearch(); break;
            case "khothuocidsearch": khothuocidsearch(); break;
            case "LayDSDuTruThuoc": LayDSDuTruThuoc(); break;
            case "luuTableHaoPhiChiDinh": luuTableHaoPhiChiDinh(); break;
            case "LoadDSKhoaTreoThuoc": LoadDSKhoaTreoThuoc(); break;
            case "CapNhatIsXoaTreo": CapNhatIsXoaTreo(); break;

            case "LayDSDuTruBenhNhan": LayDSDuTruBenhNhan(); break;
            case "LoadDanhSachDuTruDuTruc": LoadDanhSachDuTruDuTruc(); break;
        }
    }
    private void loaithuocidsearch()
    {
        string sqlSelect = @"SELECT * FROM THUOC_LOAITHUOC";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;
            }
        }
        Response.Clear();
        Response.Write(html);
    }
    private void khothuocidsearch()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string sqlSelect = @"SELECT * FROM khothuoc where nvk_loaikho in (2,3) " + (idkhoa == null || idkhoa.Equals("") || idkhoa.Equals("0") ? "" : "  and idkhoa ='" + idkhoa + "'") + " ";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += table.Rows[i]["tenkho"].ToString() + "|" + table.Rows[i]["idkho"].ToString() + Environment.NewLine;
            }
        }
        Response.Clear();
        Response.Write(html);
    }
    private void LayDSDuTruThuoc()
    {
        string sqlSelect = @"SELECT NGAYKHAM=CONVERT(VARCHAR(10),NGAYKHAM,103)+' '+CONVERT(VARCHAR(5),NGAYKHAM,108)
                                 ,MABENHNHAN,TENBENHNHAN,T.TENTHUOC,DONVITINH=DVT.TENDVT
                                 ,SOLUONGKE,SOLUONGTRA
                                 ,NGAYDUTRU=CONVERT(VARCHAR(10),NGAYDUTRUTHUOC,103)
                                 ,ISXUATVIEN= CASE WHEN EXISTS (SELECT IDNOITRU FROM BENHNHANNOITRU
                                      WHERE IDCHITIETDANGKYKHAM =KB.IDCHITIETDANGKYKHAM and IdKhoaNoiTru=kb.idphongkhambenh AND ISDANHAP =1) THEN 0 ELSE 1 END
                                 ,k.tenkho,isYeuCau= convert(int,isnull(ct.isDaYeuCau,0))
                                ,IsHaoPhi= convert(int,isnull(ct.IsHaoPhi,0))
                                ,IsBHYT_Save= convert(int,isnull(ct.IsBHYT_Save,0))
                                ,sudungchobh= convert(int,isnull(t.sudungchobh,0))
                                ,ct.idchitietbenhnhantoathuoc
                                ,LoaiKhamID = isnull(dk.LoaiKhamID,2)
                            FROM KHAMBENH KB INNER JOIN BENHNHAN BN ON BN.IDBENHNHAN =KB.IDBENHNHAN
                                 INNER JOIN CHITIETBENHNHANTOATHUOC CT ON CT.IDKHAMBENH =KB.IDKHAMBENH
                                 INNER JOIN khothuoc K ON K.idkho =CT.idkho
                                 INNER JOIN THUOC T ON T.IDTHUOC =CT.IDTHUOC
                                 LEFT JOIN THUOC_DONVITINH DVT ON DVT.ID=T.IDDVT
                                 LEFT JOIN dangkykham dk on dk.iddangkykham = kb.iddangkykham
                            WHERE 1=1";
        string mabenhnhan = Request.QueryString["mabenhnhan"];
        if (mabenhnhan != null && mabenhnhan != "")
        {
            sqlSelect += "AND MABENHNHAN LIKE N'%" + mabenhnhan.Trim() + "%'";
        }
        string tenbenhnhan = Request.QueryString["tenbenhnhan"];
        if (tenbenhnhan != null && tenbenhnhan != "")
        {
            sqlSelect += " AND( TENBENHNHAN LIKE N'%" + tenbenhnhan.Trim() + "%' OR NAMENOTSIGN LIKE N'%" + StaticData.s_GetNameNotSign(tenbenhnhan.Trim()) + "%')";
        }
        string khothuocid = Request.QueryString["khothuocid"];
        if (khothuocid != null && khothuocid != "")
        {
            sqlSelect += " AND CT.idkho=" + khothuocid;
        }
        string loaithuocid = Request.QueryString["loaithuocid"];
        if (loaithuocid != null && loaithuocid != "")
        {
            sqlSelect += " AND T.LOAITHUOCID=" + loaithuocid;
        }
        string tenthuoc = Request.QueryString["tenthuoc"];
        if (tenthuoc != null && tenthuoc != "")
        {
            sqlSelect += " AND T.TENTHUOC LIKE N'%" + tenthuoc + "%'";
        }
        string idphongkhambenh = Request.QueryString["idphongkhambenh"];
        if (idphongkhambenh != null && idphongkhambenh != "")
        {
            sqlSelect += " AND KB.IDPHONGKHAMBENH=" + idphongkhambenh;
        }
        string tungay = Request.QueryString["tungay"];
        if (tungay != null && tungay != "")
        {
            tungay = StaticData.CheckDate(tungay);
        }
        string denngay = Request.QueryString["denngay"];
        if (denngay != null && denngay != "")
        {
            denngay = StaticData.CheckDate(denngay) +" 23:59:58:999";
        }
        string isDaYeuCau = Request.QueryString["dutru"];
        string editHaoPhi = Request.QueryString["edithaophi"];
        if (editHaoPhi == null || editHaoPhi.Equals("0") || editHaoPhi.Equals(""))
        {
            if (isDaYeuCau != null && isDaYeuCau != "")
            {
                if (!StaticData.IsCheck(isDaYeuCau))
                    sqlSelect += "  AND isnull(isDaYeuCau,0)=0";
                else
                    sqlSelect += "  AND isnull(isDaYeuCau,0) in(1,2)";
            }
        }
        sqlSelect += "  AND NGAYKHAM>='" + tungay + "' AND NGAYKHAM <='" + denngay + "'";
        sqlSelect += " order by tenthuoc,ngaykham";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        html.Append("<table id='gridTableDSChiDinh' class='jtable'>");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>Ngày chỉ định</th>");
        html.Append("<th>Mã bệnh nhân</th>");
        html.Append("<th>Tên bệnh nhân</th>");
        html.Append("<th>Tên thuốc</th>");
        html.Append("<th>ĐVT</th>");
        html.Append("<th>SL kê</th>");
        html.Append("<th>Kho</th>");
        html.Append("<th>Hao Phí?</th>");
        html.Append("<th>Tính BH?</th>");
        html.Append("<th>Ngày dự trù</th>");
        html.Append("<th>Yêu Cầu?</th>");
        html.Append("<th>SL trả</th>");
        html.Append("<th>X khoa  </th>");
        html.Append("</tr>");
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + (i + 1).ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["NGAYKHAM"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["MABENHNHAN"].ToString() + "</td>");
                html.Append("<td style='text-align:left'>" + table.Rows[i]["TENBENHNHAN"].ToString() + "</td>");
                html.Append("<td style='text-align:left'>" + table.Rows[i]["TENTHUOC"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["DONVITINH"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["SOLUONGKE"].ToString() + "</td>");
                html.Append("<td>" + table.Rows[i]["tenkho"].ToString() + "</td>");

                if (editHaoPhi == null || editHaoPhi.Equals("0") || editHaoPhi.Equals(""))
                {
                    html.Append("<td><input mkv='true' type='checkbox' id='IsHaoPhi' disabled " + (table.Rows[i]["IsHaoPhi"].ToString() == "1" ? "checked " : "") + " /></td>");
                    html.Append("<td><input mkv='true' type='checkbox' id='IsBHYT_Save' disabled " + (table.Rows[i]["IsBHYT_Save"].ToString() == "1" ? "checked " : "") + " /></td>");
                }
                else
                {
                    string disa_isBH = "disabled";
                    if (table.Rows[i]["LoaiKhamID"].ToString().Equals("1") && table.Rows[i]["sudungchobh"].ToString().Equals("1"))
                        disa_isBH = "";
                    html.Append("<td><input mkv='true' type='checkbox' id='IsHaoPhi' " + (table.Rows[i]["IsHaoPhi"].ToString() == "1" ? "checked " : "") + " /></td>");
                    html.Append("<td><input mkv='true' type='checkbox' id='IsBHYT_Save' "+disa_isBH+" " + (table.Rows[i]["IsBHYT_Save"].ToString() == "1" ? "checked " : "") + " /></td>");
                }
                html.Append("<td>" + table.Rows[i]["NGAYDUTRU"].ToString() + "</td>");
                html.Append("<td><input type='checkbox' " + (table.Rows[i]["isYeuCau"].ToString() == "1" || table.Rows[i]["isYeuCau"].ToString() == "2" ? "checked disabled" : "disabled") + " /></td>");
                html.Append("<td>" + table.Rows[i]["SOLUONGTRA"].ToString() + "</td>");
                html.Append(@"<td><input type='checkbox' " + (table.Rows[i]["ISXUATVIEN"].ToString() == "1" ? "checked disabled" : "disabled") + @" />
                    <input type='hidden' mkv='true' id='idkhoachinh' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + @"' />
                    </td>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr><td colspan='13'></td></tr>");
        html.Append("</table>");
        if (editHaoPhi != null && editHaoPhi.Equals("1"))
        {
            html.Append("<div style='width:100%;text-align:center'><input type='button' value='Lưu' style='width:100px;padding: 5px 4px;font-weight: bold;' onclick='LuuHaoPhiChiDinh()'/></div>");
        }
        Response.Clear();
        Response.Write(html);
    }

    private void luuTableHaoPhiChiDinh()
    {
        try
        {
            string idctbntt = Request.QueryString["idkhoachinh"];
            string IsHaoPhi = Request.QueryString["IsHaoPhi"];
            string IsBHYT_Save = Request.QueryString["IsBHYT_Save"];
            if (IsHaoPhi.Equals("true") || IsHaoPhi.Equals("1"))
                IsHaoPhi = "1";
            else
                IsHaoPhi = "0";
            IsBHYT_Save = StaticData.IsCheck(IsBHYT_Save) ? "1" : "0";
            string sql = "update chitietbenhnhantoathuoc set ishaophi='" + IsHaoPhi + "',IsBHYT_Save='" + IsBHYT_Save + "' where idchitietbenhnhantoathuoc= '" + idctbntt + "'";
            bool kt = DataAcess.Connect.ExecSQL(sql);
            if (IsHaoPhi.Equals("1"))
                sql = "update chitietphieuxuatkho set istinhtien =0 where idchitietbenhnhantoathuoc ='"+idctbntt+"'";
            else
                sql = "update chitietphieuxuatkho set istinhtien =1 where idchitietbenhnhantoathuoc ='" + idctbntt + "'";
            kt = DataAcess.Connect.ExecSQL(sql);
            if (kt)
            {
                Response.Clear(); Response.Write(idctbntt);
                return;
            }
        }
        catch (Exception)
        {

        }
        Response.StatusCode = 500;

    }
    #region Treo Thuốc
    private void LoadDSKhoaTreoThuoc()
    {
        string dkSql = "";
        string khothuocid = Request.QueryString["khothuocid"];
        if (khothuocid != null && khothuocid != "")
        {
            dkSql += " AND k.idkho=" + khothuocid;
        }
        string loaithuocid = Request.QueryString["loaithuocid"];
        if (loaithuocid != null && loaithuocid != "")
        {
            dkSql += " AND T.LOAITHUOCID=" + loaithuocid;
        }
        string tenthuoc = Request.QueryString["tenthuoc"];
        if (tenthuoc != null && tenthuoc != "")
        {
            dkSql += " AND T.TENTHUOC LIKE N'%" + tenthuoc + "%'";
        }
        string tungay = Request.QueryString["tungay"];
        if (tungay != null && tungay != "")
        {
            tungay = StaticData.CheckDate(tungay);
        }
        string denngay = Request.QueryString["denngay"];
        if (denngay != null && denngay != "")
        {
            denngay = StaticData.CheckDate(denngay) + " 23:59:58:999";
        }
        dkSql += "  AND tr.ngayTreo>='" + tungay + "' AND tr.ngayTreo <='" + denngay + "'";
        string sql_treo = @"select yc.idphieuyc,t.idthuoc,tr.idtreo_yc,tenthuoc,TenDVT,tenkho,ngaytreo=convert(varchar(10),tr.ngaytreo,103)+' '+convert(varchar(8),tr.ngaytreo,108),yc.sophieu,soluongtreo=sum(soluongtreo),isxoa=convert(int,tr.isxoa)
                 from nvk_khoatreoyc tr inner join nvk_khoatreoyc_chitiet ct on ct.idtreo_yc= tr.idtreo_yc
                inner join thuoc_phieuycxuat yc on yc.idphieuyc=tr.idphieuyc
                left join thuoc_chitietphieuycxuat ctyc on ctyc.idphieuyc =yc.idphieuyc and ctyc.idthuoc=tr.idthuoctreo
                inner join thuoc t on t.idthuoc =tr.idthuoctreo
                inner join thuoc_donvitinh dvt on dvt.id= t.iddvt
                inner join khothuoc k on k.idkho =tr.idkhotreo
                where (isxoa =0 or isNgDCapNhat=1)" + dkSql + @"
                        
                group by yc.idphieuyc,t.idthuoc,tr.idtreo_yc,tenkho,tenthuoc,TenDVT,tr.ngaytreo,yc.sophieu,tr.isxoa
                order by ngaytreo,tenthuoc";
        DataTable table = DataAcess.Connect.GetTable(sql_treo);
        StringBuilder html = new StringBuilder();
        html.Append("<table id='gridTableDSTreo' class='jtable'>");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>Tên thuốc treo</th>");
        html.Append("<th>Đvt</th>");
        html.Append("<th>Kho Treo</th>");
        html.Append("<th>Ngày treo</th>");
        html.Append("<th>Số phiếu YC treo</th>");
        html.Append("<th>SL Treo</th>");
        html.Append("<th>Đã Xóa?</th>");
        html.Append("</tr>");
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + (i + 1).ToString() + "</td>");
                if (table.Rows[i]["isxoa"].ToString() == "1")
                    html.Append("<td><a style='font-weight:bold;' id='linkPhucHoiTreo' onclick=\"CapNhatTreo('" + table.Rows[i]["idtreo_yc"].ToString() + "','0')\">Phục hồi</a></td>");
                else
                    html.Append("<td><a style='font-weight:bold;' id='linkPhucHoiTreo' onclick=\"CapNhatTreo('" + table.Rows[i]["idtreo_yc"].ToString() + "','1')\">Xóa</a></td>");
                html.Append("<td style='text-align:left'>" + table.Rows[i]["tenthuoc"].ToString() + "</td>");
                html.Append("<td style='text-align:left'>" + table.Rows[i]["TenDVT"].ToString() + "</td>");
                html.Append("<td style='text-align:left'>" + table.Rows[i]["tenkho"].ToString() + "</td>");
                html.Append("<td style='text-align:center'>" + table.Rows[i]["ngaytreo"].ToString() + "</td>");
                html.Append("<td style='text-align:center'>" + table.Rows[i]["sophieu"].ToString() + "</td>");
                html.Append("<td style='text-align:center'>" + table.Rows[i]["soluongtreo"].ToString() + "</td>");
                html.Append("<td><input mkv='true' type='checkbox' id='IsXoa' disabled " + (table.Rows[i]["isxoa"].ToString() == "1" ? "checked " : "") + " /></td>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr><th colspan='9'></th></tr>");
        html.Append("</table>");

        html.Append("<div style='width:100%;text-align:center'><input type='button' value='Lưu' style='width:100px;padding: 5px 4px;font-weight: bold;' onclick='LuuHaoPhiChiDinh()'/></div>");
        Response.Clear();
        Response.Write(html);
    }
    private void CapNhatIsXoaTreo()
    {
        try
        {
            string idtreoyc = Request.QueryString["idtreoyc"];
            string isxoa = Request.QueryString["isXoa"];

            string idNd=SysParameter.UserLogin.UserID(this);
            if(string.IsNullOrEmpty(idNd))
                idNd="0";
            string sql = "update nvk_khoatreoyc_chitiet set isxoatreo ='" + isxoa + "',isNgDCapNhat=1,idNguoiCapNhat="+idNd+" where idtreo_yc ='" + idtreoyc + "'";
            bool kt = DataAcess.Connect.ExecSQL(sql);
            sql = "update nvk_khoatreoyc set isxoa ='" + isxoa + "',isNgDCapNhat=1,idNguoiCapNhat=" + idNd + " where idtreo_yc ='" + idtreoyc + "'";
            kt = DataAcess.Connect.ExecSQL(sql);
            if (kt)
            {
                Response.Clear();
                Response.Write("1");
                return;
            }
        }
        catch (Exception)
        {
        }
        Response.Clear();
        Response.Write("");
    }
    #endregion
    //_____________________________________________________________________________________________________
    #region Call from noitru_BaoCao/KiemTraDuTru
    private void LayDSDuTruBenhNhan()
    {
        string idthuoc = Request.QueryString["idthuoc"];
        if (string.IsNullOrEmpty(idthuoc))
        {
            Response.Clear();
            Response.Write("Chưa chọn thuốc");
            return;
        }
        string editHaoPhi = "0";
        string sqlSelect = "select *  from dbo.nvk_chitietchidinhKHOBENHNHANchuaxuat('" + idthuoc + "') ORDER BY NGAYKHAM";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            html.Append("<table id='gridTableDSChiDinh' class='jtable'>");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>Kho</th>");
            html.Append("<th>Ngày Chỉ định</th>");
            html.Append("<th>Ngày Dự Trù</th>");
            html.Append("<th>Số lượng</th>");
            html.Append("<th>Mã BN</th>");
            html.Append("<th>Tên BN</th>");
            html.Append("<th>Phiếu YC</th>");
            html.Append("<th>Tình Trạng YC</th>");
            html.Append("</tr>");
            if (table.Rows.Count > 0)
            {
                double tong=0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + (i + 1).ToString() + "</td>");
                    html.Append("<td style='text-align:left'>" + table.Rows[i]["TENKHO"].ToString() + "</td>");
                    html.Append("<td style='text-align:center'>" + table.Rows[i]["NGAYKHAM103"].ToString() + "</td>");
                    html.Append("<td style='text-align:center'>" + table.Rows[i]["NGAYDUTRU103"].ToString() + "</td>");
                    html.Append("<td style='text-align:right'>" + table.Rows[i]["Soluong"].ToString() + "</td>");
                    html.Append("<td style='text-align:left'>" + table.Rows[i]["MABENHNHAN"].ToString() + "</td>");
                    html.Append("<td style='text-align:left'>" + table.Rows[i]["TENBENHNHAN"].ToString() + "</td>");
                    html.Append("<td style='text-align:left'>" + table.Rows[i]["SoPhieuYc"].ToString() + "</td>");
                    html.Append(@"<td style='text-align:left'>" + table.Rows[i]["tinhtrangPhieu"].ToString() + @"
                    <input type='hidden' mkv='true' id='idkhoachinh' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + @"' />
                    </td>");
                    html.Append("</tr>");
                    tong += double.Parse(table.Rows[i]["Soluong"].ToString());
                }
                html.Append("<tr>");
                html.Append("<td style='text-align:right;font-weight:bold' colspan='4'>TỔNG CỘNG:</td>");
                html.Append("<td style='text-align:right;font-weight:bold'>"+tong+"</td>");
                html.Append("<td colspan='4'></td>");
                html.Append("</tr>");

            }
            html.Append("<tr><td colspan='9'></td></tr>");
            html.Append("</table>");
        }
        Response.Clear();
        Response.Write(html);
    }
    //_____________________________________________________________________________________________________
    private void LoadDanhSachDuTruDuTruc()
    {
        string idthuoc = Request.QueryString["idthuoc"];
        if (string.IsNullOrEmpty(idthuoc))
        {
            Response.Clear();
            Response.Write("Chưa chọn thuốc");
            return;
        }
        string editHaoPhi = "0";
        string sqlSelect = "select *  from dbo.nvk_chitietyeucauTUTUTRUCchuaxuat('" + idthuoc + "') ORDER BY NGAYYC";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            html.Append("<table id='gridTableDSYEUCAU' class='jtable'>");
            html.Append("<tr>");
            html.Append("<th>STT</th>");
            html.Append("<th>Số phiếu YC</th>");
            html.Append("<th>Kho YC</th>");
            html.Append("<th>Ngày YC</th>");
            html.Append("<th>Loại YC</th>");
            html.Append("<th>Số lượng YC</th>");
            html.Append("<th>Tình trạng Phiếu</th>");
            html.Append("<th>Đã Xuất</th>");
            html.Append("</tr>");
            if (table.Rows.Count > 0)
            {
                double tong = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + (i + 1).ToString() + "</td>");
                    html.Append("<td style='text-align:left'>" + table.Rows[i]["SOPHIEU"].ToString() + "</td>");
                    html.Append("<td style='text-align:left'>" + table.Rows[i]["TENKHO"].ToString() + "</td>");
                    html.Append("<td style='text-align:center'>" + table.Rows[i]["NGAYYC103"].ToString() + "</td>");
                    html.Append("<td style='text-align:left'>" + table.Rows[i]["LOAIYC"].ToString() + "</td>");
                    html.Append("<td style='text-align:right'>" + table.Rows[i]["SOLUONGYC"].ToString() + "</td>");
                    html.Append("<td style='text-align:left'>" + table.Rows[i]["TINHTRANGDUYET"].ToString() + "</td>");
                    html.Append(@"<td style='text-align:right'>" + table.Rows[i]["XLXUAT"].ToString() + @"
                    <input type='hidden' mkv='true' id='idkhoachinh' value='" + table.Rows[i]["IDCHITIETPHIEUYC"].ToString() + @"' />
                    </td>");
                    html.Append("</tr>");
                    tong += double.Parse(table.Rows[i]["SOLUONGYC"].ToString());
                }
                html.Append("<tr>");
                html.Append("<td style='text-align:right;font-weight:bold' colspan='5'>TỔNG CỘNG:</td>");
                html.Append("<td style='text-align:right;font-weight:bold'>" + tong + "</td>");
                html.Append("<td colspan='2'></td>");
                html.Append("</tr>");

            }
            html.Append("<tr><td colspan='9'></td></tr>");
            html.Append("</table>");
        }
        Response.Clear();
        Response.Write(html);
    }
    #endregion
}
