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

public partial class nvk_frm_KhamNgoaiTru_ajax : System.Web.UI.Page
 {
     private string IdBangGiaDV = null;
     private double tongtien = 0;
     protected DataProcess s_benhnhan()
     {
             DataProcess benhnhan = new DataProcess("benhnhan");
             benhnhan.data("idbenhnhan", Request.QueryString["idkhoachinh"]);
             benhnhan.data("mabenhnhan",Request.QueryString["mabenhnhan"]);
             benhnhan.data("tenbenhnhan",Request.QueryString["tenbenhnhan"]);
            return benhnhan;
     }
     protected DataProcess s_DangKyKham()
     {
         DataProcess dangkykham = new DataProcess("dangkykham");
         string tungay = StaticData.CheckDate(Request.QueryString["tungay"]);
         string denngay = StaticData.CheckDate(Request.QueryString["denngay"]);
         dangkykham.data("ngaydangky", tungay);
        // dangkykham.data("ngaydangky",denngay);
         return dangkykham;
     }
    protected DataProcess s_chitietbenhnhantoathuoc()
    {
        DataProcess chitietbenhnhantoathuoc = new DataProcess("chitietbenhnhantoathuoc");
        chitietbenhnhantoathuoc.data("idchitietbenhnhantoathuoc", Request.QueryString["idkhoachinh"]);
        chitietbenhnhantoathuoc.data("idbenhnhantoathuoc", Request.QueryString["idbenhnhantoathuoc"]);
        chitietbenhnhantoathuoc.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietbenhnhantoathuoc.data("soluongbanra", Request.QueryString["soluongbanra"]);
        chitietbenhnhantoathuoc.data("dongia", Request.QueryString["dongia"]);
        chitietbenhnhantoathuoc.data("ngayuong", Request.QueryString["ngayuong"]);
        chitietbenhnhantoathuoc.data("moilanuong", Request.QueryString["moilanuong"]);
        chitietbenhnhantoathuoc.data("donvidung", Request.QueryString["donvidung"]);
        chitietbenhnhantoathuoc.data("ghichu", Request.QueryString["ghichu"]);
        chitietbenhnhantoathuoc.data("bacsixoa", Request.QueryString["bacsixoa"]);
        chitietbenhnhantoathuoc.data("quaythuocxoa", Request.QueryString["quaythuocxoa"]);
        chitietbenhnhantoathuoc.data("thoigiandung", Request.QueryString["thoigiandung"]);
        chitietbenhnhantoathuoc.data("tenNgaydung", Request.QueryString["tenNgaydung"]);
        chitietbenhnhantoathuoc.data("thanhtien", Request.QueryString["thanhtien"]);
        chitietbenhnhantoathuoc.data("heso", Request.QueryString["heso"]);
        chitietbenhnhantoathuoc.data("IdThuoc1", Request.QueryString["IdThuoc1"]);
        chitietbenhnhantoathuoc.data("idkhambenh", Request.QueryString["idkhambenh"]);
        chitietbenhnhantoathuoc.data("idkho", Request.QueryString["idkho"]);
        chitietbenhnhantoathuoc.data("DoiTuongThuocID", Request.QueryString["DoiTuongThuocID"]);
        chitietbenhnhantoathuoc.data("SoLuongTheoDonVi", Request.QueryString["soluongke"]);
        string SoLuongKe = "0";
        if (Request.QueryString["idthuoc"] != null && Request.QueryString["soluongke"] != null)
            SoLuongKe = getSoLuongKe(Request.QueryString["idthuoc"], Request.QueryString["soluongke"]);
        chitietbenhnhantoathuoc.data("soluongke", SoLuongKe);
        string SoLuongTra = "0";
        if (Request.QueryString["idthuoc"] != null && Request.QueryString["soluongtra"] != null)
            SoLuongTra = getSoLuongTra(Request.QueryString["idthuoc"], Request.QueryString["soluongtra"]);
        chitietbenhnhantoathuoc.data("soluongtra", SoLuongTra);
        //chitietbenhnhantoathuoc.data("soluongtra", Request.QueryString["soluongtra"]);
        return chitietbenhnhantoathuoc;
    }
    private string getSoLuongKe(string idthuoc, string SoLuongNhap)
    {
        if (idthuoc == "" || SoLuongNhap == "")
            return "0";
        string SoLuong = SoLuongNhap;
        string sqlThuoc = @"select case when isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then " + SoLuongNhap + @"
                            else convert(float," + SoLuongNhap + @")/convert(float,isnull(SoLuong1donvi,1)) end as SoLuongTraVe
                        from thuoc where idthuoc=" + idthuoc + "";
        DataTable dtSoLuong = DataAcess.Connect.GetTable(sqlThuoc);
        if (dtSoLuong != null && dtSoLuong.Rows.Count > 0)
            SoLuong = dtSoLuong.Rows[0]["SoLuongTraVe"].ToString();
        return SoLuong;
    }
    private string getSoLuongTra(string idthuoc, string SoLuongTra)
    {
        if (idthuoc == "" || SoLuongTra == "")
            return "0";
        string SoLuong = SoLuongTra;
        string sqlThuoc = @"select case when isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then " + SoLuongTra + @"
                            else convert(float," + SoLuongTra + @")/convert(float,isnull(SoLuong1donvi,1)) end as SoLuongTraVe
                        from thuoc where idthuoc=" + idthuoc + "";
        DataTable dtSoLuong = DataAcess.Connect.GetTable(sqlThuoc);
        if (dtSoLuong != null && dtSoLuong.Rows.Count > 0)
            SoLuong = dtSoLuong.Rows[0]["SoLuongTraVe"].ToString();
        return SoLuong;
    }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "LoadBangKeThuocTuTruc": nvk_loadTablechitietbenhnhantoathuoc(); break;
              //case "luuhoantra": luuhoantra(); break; 
         }
     }
    protected void nvk_LoadBangKeThuocTuTruc()
     {
         string nvk_idkhambenh = Request.QueryString["idkhambenh"];
         string sql = @"SELECT distinct dk.iddangkykham,dk.maphieudangky,dk.ngaydangky,t.idbenhnhan,
					T.tenbenhnhan,[dbo].[KB_GET_SOTIENBNPHAITRA_DKK](dk.idbenhnhan,dk.iddangkykham) as sotienthu  
                    FROM benhnhan T
					inner join dangkykham dk ON dk.idbenhnhan = T.idbenhnhan 
                    WHERE dk.iddangkykham='" + nvk_idkhambenh + "'";
         DataTable dt= DataAcess.Connect.GetTable(sql);
         string html = "";
         html += "<strong style=\"color:Blue;font-size:larger;font-weight:bold\">HOÀN TRẢ TIỀN ĐĂNG KÝ KHÁM</strong>";
         html += "<table class='jtable' id=\"hoantra\" border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\">";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Người thực hiện :<input type=\"hidden\" mkv=\"true\" id=\"hdIdNguoiDung\" value='" + SysParameter.UserLogin.UserID(this) + "'/></td>";
         html += "<td align=\"left\" style=\"width:100%\"><input style=\"width:300px\" type=\"text\" readonly=\"true\" id=\"tenNguoiDung\" value='" + SysParameter.UserLogin.FullName(this) + "'/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Tên bệnh nhân : <input type=\"hidden\" mkv=\"true\" id=\"idbenhnhan\" value='" + dt.Rows[0]["idbenhnhan"] + "'/></td>";
         html += "<td align=\"left\" style=\"width:100%\"><input style=\"width:300px\" mkv=\"true\" readonly=\"true\" type=\"text\" id=\"tenbenhnhan\" value='" + dt.Rows[0]["tenbenhnhan"] + "'/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Mã phiếu :</td>";
         html += "<td align=\"left\" style=\"width:100%\"><input style=\"width:300px\" type=\"text\" mkv=\"true\" readonly=\"true\" id=\"maphieu\" mkv=\"true\" value='" + dt.Rows[0]["maphieudangky"] + "'/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Số tiền : </td>";
         html += "<td align=\"left\" style=\"width:100%\"><input style=\"width:300px\"  type=\"text\" mkv=\"true\" id=\"sotien\" value='" + dt.Rows[0]["sotienthu"] + "'/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Nội dung: </td>";
         html += "<td align=\"left\" style=\"width:100%\"><input style=\"width:300px\"  type=\"text\" mkv=\"true\" id=\"noidung\" value='Hoàn trả phí khám bệnh'/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Lý do: </td>";
         html += "<td align=\"left\" style=\"width:100%\"><input style=\"width:300px\" mkv=\"true\" type=\"text\" id=\"lydo\" mkv=\"true\" /></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"center\" style=\"width:20%\" colspan=\"2\">";
         html += "<input type=\"button\" id=\"btnLuu\" value=\"Đồng ý\" onclick=\"LuuHoanTra('" + nvk_idkhambenh + "');\"/>";
             html += "<input type=\"button\" id=\"btnHuy\" value=\"Đóng\" onclick=\"Dong();\" />";
             html += "</td>";
         html += "</tr>";
         html += "</table>";
         Response.Write(html);
     }
    public void nvk_loadTablechitietbenhnhantoathuoc()
    {
        bool isadmin = false;
        if (SysParameter.UserLogin.GroupID(this) == "4")
            isadmin = true;
        DataProcess process = s_chitietbenhnhantoathuoc();
        string nvk_idkhambenh = process.getData("idkhambenh");
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        string sql = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc)
                --,nvk_TT_DaTra= isnull((SELECT top 1 idchitietbenhnhantoathuoc FROM NVK_Thuoc_ChiTietYCTra_bntt WHERE isnull(isDaTra,0)=1 and idchitietbenhnhantoathuoc=T.idchitietbenhnhantoathuoc ),0)
                --,nvk_TT_YCTraChuaN= isnull((SELECT top 1 idchitietbenhnhantoathuoc FROM NVK_Thuoc_ChiTietYCTra_bntt WHERE isnull(isDaTra,0)=0 and idchitietbenhnhantoathuoc=T.idchitietbenhnhantoathuoc ),0)
                --,nvk_TT_DaDuyet= isnull((SELECT top 1 idchitietbenhnhantoathuoc FROM chitietphieuxuatkho WHERE idchitietbenhnhantoathuoc =t.idchitietbenhnhantoathuoc),0)
                --,nvk_TT_YCChuaD= isnull((SELECT top 1 idchitietbenhnhantoathuoc from NVK_Thuoc_ChiTietYCXuat where idchitietbenhnhantoathuoc  =t.idchitietbenhnhantoathuoc),0)
                ,nvk_TT_TH=
                isnull((SELECT top 1 idchitietbenhnhantoathuoc FROM NVK_Thuoc_ChiTietYCTra_bntt WHERE isnull(isDaTra,0)=1 and idchitietbenhnhantoathuoc=T.idchitietbenhnhantoathuoc )
                ,
	                 isnull((SELECT top 1 idchitietbenhnhantoathuoc FROM NVK_Thuoc_ChiTietYCTra_bntt WHERE isnull(isDaTra,0)=0 and idchitietbenhnhantoathuoc=T.idchitietbenhnhantoathuoc )
	                ,
		                isnull((SELECT top 1 idchitietbenhnhantoathuoc FROM chitietphieuxuatkho WHERE idchitietbenhnhantoathuoc =t.idchitietbenhnhantoathuoc)
		                ,
		                isnull((SELECT top 1 idchitietbenhnhantoathuoc from NVK_Thuoc_ChiTietYCXuat where idchitietbenhnhantoathuoc  =t.idchitietbenhnhantoathuoc),0)
		                )
	                )
                )
                ,T.*
                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
                                ,dt.TenDoiTuong
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongke else isnull(SoLuongTheoDonVi,0) end as SoLuongDonVi
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then t.soluongTra else isnull(t.soluongTra,0)*isnull(SoLuong1donvi,0)  end as TraTheoDonVi
,case when  isnull(SoLuong1donvi,1)=1 or SoLuong1donvi=0 then N'' else N'/'+convert(varchar,SoLuong1donvi)+TenDonVi end as DonViCoBan

                               from chitietbenhnhantoathuoc T
                                left join thuoc a on a.idthuoc=t.idthuoc
                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
                            left join khothuoc k on k.idkho = T.idkho
                            left join thuoc_doituongthuoc dt on dt.DoiTuongThuocID = t.DoiTuongThuocID
          where T.idkhambenh='" + process.getData("idkhambenh") + "'";
        DataTable table = process.Search(sql);
        string html = "";
        html +="<div id='tableAjax_chitietbenhnhanTraThuoc'>";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Loại</th>";
        html += "<th>Đối tượng</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>";
        //html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayuong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("moilanuong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string strDisabled = table.Rows[i]["nvk_TT_TH"].ToString().Equals("0") ? "" : "Disabled";
                html += "<tr>";
                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                html += @"<td>";
                //if(isadmin)
                html += "<a  onclick='xoaontable(this)' >" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a>" ;
                //html += strDisabled.Equals("") ? "<a  onclick='xoaontable(this)' >" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a>" : "";
                html += "</td>";
                html += "<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>";
                //
                html += "<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='" + table.Rows[i]["TenDoiTuong"].ToString() + "' class='down_select'/></td>";
                //
                html += "<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='" + table.Rows[i]["tenkho"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idthuoc' type='text' " + strDisabled + " onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>";
                html += @"<td><input mkv='true' style='width:30px;text-align:right' id='soluongke'  type='text' " + strDisabled + "  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoLuongDonVi"].ToString() + @"' onblur='TestSo(this,false,false);'/>
<input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value='" + table.Rows[i]["DonViCoBan"].ToString() + @"'/>
                    </td>";
                //html += "<td><input mkv='true' style='width:20px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["TraTheoDonVi"].ToString() + "' onblur='TestSo(this,false,false);ktrasltra(this);'/></td>";
                html += "<td><input mkv='true' style='width:50px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:50px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["moilanuong"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + (table.Rows.Count + 1) + "</td>";
        html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
        html += "<td><input  id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>";
        //
        html += "<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='' class='down_select'/></td>";
        //
        html += "<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='' class='down_select'/></td>";
        html += @"<td><input mkv='true' style='width:30px' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'>
            <input mkv='true' style='width:50px;height:10px;text-align:left' disabled='true' id='DonViCoBan' type='text' value=''/>
            </td>";
        //html += "<td><input mkv='true' style='width:30px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);ktrasltra(this);' /></td>";
        html += "<td><input mkv='true' style='width:50px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:50px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:100px'/></td>";
        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";
        html += "<tr><td></td><td></td></tr>";
        html += @"</table>";
        html += @"</div>";
        html += process.Paging("chitietbenhnhantoathuoc");
        string sqlBN = " select idbenhnhan=isnull((select idbenhnhan from khambenh where idkhambenh='" + process.getData("idkhambenh") + "'),0)";
        string idbenhnhan_nvk = DataAcess.Connect.GetTable(sqlBN).Rows[0]["idbenhnhan"].ToString();
        html += @"
        <div class='div-Out' style='width: 96%'>
            <div class='div-Left' style='text-transform: uppercase'>
            </div>
            <div class='div-Right' style='width: 80%;'>";
        #region cho phép lưu toa ?
        if (table.Rows.Count > 0)
        {
            string tinhTrangYc = DataAcess.Connect.GetTable("SELECT TINHTRANG=DBO.NVK_TINHTRANGYEUCAUTOATHUOC('"+nvk_idkhambenh+"')").Rows[0][0].ToString();
            if (tinhTrangYc.Equals("1"))
                html += @"<input id='luuCLS' type='button' value='Lưu Toa' style='width: 100px' onclick='SaveToaThuocTT_Click(" + process.getData("idkhambenh") + "," + idbenhnhan_nvk + @")'/>";
            else
            {
                html += @"<input id='luuCLS' type='button' value='Lưu mới' style='width: 100px' onclick='SaveToaThuocTT_Click(" + process.getData("idkhambenh") + "," + idbenhnhan_nvk + @")'/>";
                if (tinhTrangYc.Equals("2"))
                    html += @"<input id='luuCLS' type='button' value='Đã YC' style='width: 100px;color:Red'/>";
                else if (tinhTrangYc.Equals("3"))
                    html += @"<input id='nvkLoadTraThuoc' type='button' value='Trả thuốc' style='width: 100px;color:Red'
                    onclick='LoadTraThuoc_Click(" + nvk_idkhambenh + ",this)' />";
                else if (tinhTrangYc.Equals("4"))
                    html += @"<input id='luuCLS' type='button' value='Đã YC trả' style='width: 100px;color:Red'/>";
                else if (tinhTrangYc.Equals("5"))
                    html += @"<input id='luuCLS' type='button' value='Đã trả' style='width: 100px;color:Red'/>";
            }
        }
        else
            html += @"<input id='luuCLS' type='button' value='Lưu Toa' style='width: 100px' onclick='SaveToaThuocTT_Click(" + process.getData("idkhambenh") + "," + idbenhnhan_nvk + @")'/>";
        #endregion
        //<input id='luuCLS' type='button' value='Lưu' style='width: 100px' onclick='SaveToaThuocTT_Click(" + process.getData("idkhambenh") + "," + idbenhnhan_nvk + @")'/>
        html += @"
                <input id='incls' type='button' value='In toa thuoc' style='width: 120px' onclick='InToaThuocTT_Click(" + process.getData("idkhambenh") + @")'/>
                <input mkv='true' id='idKhamBenhTTTT' value='" + process.getData("idkhambenh") + @"' type='hidden' />
            </div>
        </div>";
        //string sqlDuTru = "select DuTru103=isnull(convert(varchar(10),ngayDuTruThuoc,103),''),* from khambenh where idkhambenh=" + process.getData("idkhambenh") + "";
        //DataTable dtDT = DataAcess.Connect.GetTable(sqlDuTru);
        //if (dtDT != null && !dtDT.Rows[0]["DuTru103"].ToString().Equals(""))
        //    html += "@@1@@" + dtDT.Rows[0]["DuTru103"].ToString().Trim();
        //else
        //    html += "@@0@@ ";
        Response.Clear(); Response.Write(html);
    }
 }
 
 
