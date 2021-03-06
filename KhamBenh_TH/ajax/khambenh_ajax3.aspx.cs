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
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
public partial class khambenh_ajax : System.Web.UI.Page
{
    protected DataProcess s_khambenh()
    {
        DataProcess KHAMBENH = new DataProcess("KHAMBENH");
        KHAMBENH.data("idkhambenh", Request.QueryString["idkhoachinh"]);
        KHAMBENH.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        KHAMBENH.data("IdKhoa", Request.QueryString["IdKhoa"]);
        KHAMBENH.data("Giuong", Request.QueryString["Giuong"]);
        KHAMBENH.data("ngaykham", DataProcess.sGetValidDate(Request.QueryString["ngaykham_gio"], Request.QueryString["ngaykham_phut"], Request.QueryString["ngaykham"]));
        KHAMBENH.data("TGXuatVien", DataProcess.sGetValidDate(Request.QueryString["gioravien"], Request.QueryString["phutravien"], Request.QueryString["TGXuatVien"]));
        KHAMBENH.data("ketluan", Request.QueryString["idchandoan"]);
        KHAMBENH.data("PhongID", Request.QueryString["PhongID"]);
        KHAMBENH.data("DichVuKCBID", Request.QueryString["DichVuKCBID"]);
        KHAMBENH.data("IdChiTietDangKyKham", Request.QueryString["IdChiTietDangKyKham"]);
        KHAMBENH.data("iddangkykham", Request.QueryString["iddangkykham"]);
        KHAMBENH.data("IdBacSi", Request.QueryString["IdBacSi"]);
        KHAMBENH.data("isNoiTru", Request.QueryString["isNoiTru"]);
        KHAMBENH.data("IdChuyenPK", Request.QueryString["IdChuyenPK"]);
        KHAMBENH.data("IdkhoaChuyen", Request.QueryString["IdkhoaChuyen"]);
        KHAMBENH.data("trieuchung", Request.QueryString["trieuchung"]);
        KHAMBENH.data("benhsu", Request.QueryString["benhsu"]);
        KHAMBENH.data("TienSu", Request.QueryString["tiensu"]);
        KHAMBENH.data("IsXuatVien", Request.QueryString["IsXuatVien"]);
        KHAMBENH.data("IsChuyenPhongCoPhi", Request.QueryString["IsChuyenPhongCoPhi"]);
        KHAMBENH.data("ngayhentaikham", Request.QueryString["ngayhentaikham"]);
        KHAMBENH.data("songayratoa", Request.QueryString["songayratoa"]);
        KHAMBENH.data("dando", Request.QueryString["loidan"]);
        KHAMBENH.data("iskhongkham", Request.QueryString["iskhongkham"]);
        KHAMBENH.data("ischovekt", Request.QueryString["ischovekt"]);
        KHAMBENH.data("ischuyenvien", Request.QueryString["ischuyenvien"]);
        KHAMBENH.data("idbenhvienchuyen", Request.QueryString["idbenhvienchuyen"]);
        KHAMBENH.data("IdBacSi2", Request.QueryString["IdBacSi2"]);
        KHAMBENH.data("IsBSMoiKham", Request.QueryString["IsBSMoiKham"]);
        KHAMBENH.data("chandoanbandau", Request.QueryString["chandoanbandau"]);
        KHAMBENH.data("idchandoantuyenduoi", Request.QueryString["idchandoantuyenduoi"]);
        KHAMBENH.data("MoTaCD_edit", Request.QueryString["mkv_mota"]);
        KHAMBENH.data("ChanDoanTuyenDuoi", Request.QueryString["mkv_mota_idchandoantuyenduoi"]);
        KHAMBENH.data("IsTieuPhauRoiVe", Request.QueryString["IsTieuPhauRoiVe"]);
        KHAMBENH.data("ghichu", Request.QueryString["ghichu"]);
        KHAMBENH.data("SoTTChuyenP", Request.QueryString["SoTTChuyenP"]);
        return KHAMBENH;
    }
    protected DataProcess s_chitietbenhnhantoathuoc()
    {
        DataProcess chitietbenhnhantoathuoc = new DataProcess("chitietbenhnhantoathuoc");
        chitietbenhnhantoathuoc.data("idchitietbenhnhantoathuoc", Request.QueryString["idkhoachinh"]);
        chitietbenhnhantoathuoc.data("idbenhnhantoathuoc", Request.QueryString["idbenhnhantoathuoc"]);
        chitietbenhnhantoathuoc.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietbenhnhantoathuoc.data("soluongke", Request.QueryString["soluongke"]);
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
        chitietbenhnhantoathuoc.data("soluongtra", Request.QueryString["soluongtra"]);
        chitietbenhnhantoathuoc.data("IsDaYeuCau", Request.QueryString["IsDaYeuCau"]);
        chitietbenhnhantoathuoc.data("IsDaXuatTra", Request.QueryString["IsDaXuatTra"]);
        chitietbenhnhantoathuoc.data("DoiTuongThuocID", Request.QueryString["DoiTuongThuocID"]);
        chitietbenhnhantoathuoc.data("isdathu", Request.QueryString["isdathu"]);
        chitietbenhnhantoathuoc.data("SoLuongTheoDonVi", Request.QueryString["SoLuongTheoDonVi"]);
        chitietbenhnhantoathuoc.data("cachdung", Request.QueryString["cachdung"]);
        chitietbenhnhantoathuoc.data("isdahuy", Request.QueryString["isdahuy"]);
        chitietbenhnhantoathuoc.data("ngayratoa", DataProcess.sGetValidDate(Request.QueryString["gioravien"], Request.QueryString["phutravien"], Request.QueryString["TGXuatVien"]));
        chitietbenhnhantoathuoc.data("TienThucthu", Request.QueryString["TienThucthu"]);
        chitietbenhnhantoathuoc.data("idcachdung", Request.QueryString["idcachdung"]);
        chitietbenhnhantoathuoc.data("iddvt", Request.QueryString["iddvt"]);
        chitietbenhnhantoathuoc.data("istuan", Request.QueryString["istuan"]);
        chitietbenhnhantoathuoc.data("isngay", Request.QueryString["isngay"]);
        chitietbenhnhantoathuoc.data("issang", Request.QueryString["issang"]);
        chitietbenhnhantoathuoc.data("istrua", Request.QueryString["istrua"]);
        chitietbenhnhantoathuoc.data("ischieu", Request.QueryString["ischieu"]);
        chitietbenhnhantoathuoc.data("istoi", Request.QueryString["istoi"]);
        chitietbenhnhantoathuoc.data("iddvdung", Request.QueryString["iddvdung"]);
        chitietbenhnhantoathuoc.data("cateid", Request.QueryString["cateid"]);
        chitietbenhnhantoathuoc.data("IsBHYT_Save", Request.QueryString["IsBHYT_Save"]);
        chitietbenhnhantoathuoc.data("IsHaoPhi", Request.QueryString["ishaophi"]);
        chitietbenhnhantoathuoc.data("slton", Request.QueryString["slton"]);
        return chitietbenhnhantoathuoc;
    }
    protected DataProcess s_khambenhcanlamsan()
    {
        DataProcess khambenhcanlamsan = new DataProcess("khambenhcanlamsan");
        khambenhcanlamsan.data("idkhambenhcanlamsan", Request.QueryString["idkhoachinh"]);
        khambenhcanlamsan.data("idcanlamsan", Request.QueryString["idcanlamsan"]);
        khambenhcanlamsan.data("idkhambenh", Request.QueryString["idkhambenh"]);
        khambenhcanlamsan.data("dongia", Request.QueryString["dongia"]);
        khambenhcanlamsan.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        khambenhcanlamsan.data("ngaythu", DataProcess.sGetValidDate(Request.QueryString["ngaykham_gio"], Request.QueryString["ngaykham_phut"], Request.QueryString["ngaykham"]));
        khambenhcanlamsan.data("maphieucls", Request.QueryString["maphieucls"]);
        khambenhcanlamsan.data("soluong", Request.QueryString["soluong"]);
        khambenhcanlamsan.data("chietkhau", Request.QueryString["chietkhau"]);
        khambenhcanlamsan.data("thanhtien", Request.QueryString["thanhtien"]);
        khambenhcanlamsan.data("ghichu", Request.QueryString["ghichu"]);
        khambenhcanlamsan.data("iddangkycls", Request.QueryString["iddangkycls"]);
        khambenhcanlamsan.data("IsBHYT_Save", Request.QueryString["IsBHYT_Save"]);

        return khambenhcanlamsan;
    }
    protected DataProcess s_sinhhieu()
    {
        DataProcess kb_sinhhieu = new DataProcess("sinhhieu");
        kb_sinhhieu.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        kb_sinhhieu.data("ngaydo", Request.QueryString["ngaydo"]);
        kb_sinhhieu.data("mach", Request.QueryString["mach"]);
        kb_sinhhieu.data("nhietdo", Request.QueryString["nhietdo"]);
        kb_sinhhieu.data("huyetap1", Request.QueryString["huyetap1"]);
        kb_sinhhieu.data("huyetap2", Request.QueryString["huyetap2"]);
        kb_sinhhieu.data("nhiptho", Request.QueryString["nhiptho"]);
        kb_sinhhieu.data("chieucao", Request.QueryString["chieucao"]);
        kb_sinhhieu.data("cannang", Request.QueryString["cannang"]);
        kb_sinhhieu.data("BMI", Request.QueryString["BMI"]);
        kb_sinhhieu.data("IdKhamBenh", Request.QueryString["idkhoachinh"]);
        return kb_sinhhieu;
    }
    protected DataProcess s_chanDoanPhoiHop()
    {
        DataProcess chandoanphoihop = new DataProcess("chandoanphoihop");
        chandoanphoihop.data("id", Request.QueryString["idkhoachinh"]);
        chandoanphoihop.data("idkhambenh", Request.QueryString["idkhambenh"]);
        chandoanphoihop.data("idicd", Request.QueryString["idicd"]);
        string MoTaCD_edit = Request.QueryString["mkv_idicdMoTa"];
        chandoanphoihop.data("MoTaCD_edit", MoTaCD_edit);
        return chandoanphoihop;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savekhambenh(); break;
            case "setTimKiem": setTimKiem(); break;
            case "setTimKiem_KhamMoi": setTimKiem_KhamMoi(); break;
            case "setTimKiem_KhamMoiChuyenPhong": setTimKiem_KhamMoiChuyenPhong(); break;
            case "luuTablechitietbenhnhantoathuoc": LuuTablechitietbenhnhantoathuoc(); break;
            case "luuTablekhambenhcanlamsan": LuuTablekhambenhcanlamsan(); break;
            case "loadTablechitietbenhnhantoathuoc": loadTablechitietbenhnhantoathuoc(); break;
            case "loadTablekhambenhcanlamsan": loadTablekhambenhcanlamsan(); break;
            case "xoa": Xoakhambenh(); break;
            case "xoachitietbenhnhantoathuoc": Xoachitietbenhnhantoathuoc(); break;
            case "xoakhambenhcanlamsan": Xoakhambenhcanlamsan(); break;
            case "chandoanbandausearch": chandoanbandausearch(); break;
            case "idthuocsearch": idthuocsearch(); break;
            case "idcanlamsansearch": idcanlamsansearch(); break;
            case "idbacsisearch": idbacsisearch(); break;
            case "loaithuocidsearch": loaithuocidsearch(); break;
            case "IdkhoaChuyenSearch": IdkhoaChuyenSearch(); break;
            case "banggiadichvuSearch": banggiadichvuSearch(); break;
            case "phongkhambenhSearch": phongkhambenhSearch(); break;
            case "ChonCLS": ChonCLS(); break;
            case "GetDSCLS": GetDSCLS(); break;
            case "loadTablechandoanphoihop": loadTablechandoanphoihop(); break;
            case "luuTongTienKham": luuTongTienKham(); break;
            case "idkhoasearch": idkhoasearch(); break;
            case "idphongsearch": idphongsearch(); break;
            case "cateidsearch": cateidsearch(); break;
            case "iddvtsearch": iddvtsearch(); break;
            case "iddvdungvsearch": iddvdungvsearch(); break;
            case "idcachdungsearch": idcachdungsearch(); break;
            case "TinhSoNgayRaToa": TinhSoNgayRaToa(); break;
            case "LoadChanDoanMoTaICD": LoadChanDoanMoTaICD(); break;
            case "LoadChanDoanMaICD": LoadChanDoanMaICD(); break;
            case "checkHSBA": checkHSBA(); break;
            case "ChonTT": ChonTT(); break;
            case "GetDSTT": GetDSTT(); break;
            case "loadbenhvien": loadbenhvien(); break;
            case "idkhoxuatsearch": idkhoxuatsearch(); break;
            case "xuatthuoc": xuatthuoc(); break;
            case "xuatvtyt": xuatvtyt(); break;
            case "HuyCLS": HuyCLS(); break;
            case "checkpass": checkpass(); break;
            case "ChanDoansearch": ChanDoansearch(); break;
            case "XoaCDPH": XoaCDPH(); break;
            case "LuuCDPH": LuuCDPH(); break;
            case "ShowDSCLSTDK": ShowDSCLSTDK(); break;
            case "ChonclsThuongquy": ChonclsThuongquy(); break;
            case "setCSLThuongQuy": setCSLThuongQuy(); break;
            case "chonToaThuocMau": chonToaThuocMau(); break;
            case "setToaThuocMau": setToaThuocMau(); break;
            case "MakeSoVaoVien": MakeSoVaoVien(); break;
            case "getListSLTON": GetListSLTon_RealTime(); break;
        }
    }
    #region cls_thuongquy-toathuocmau
    private void chonToaThuocMau()
    {
        string sqlSelect = string.Format(@"select STT=row_number() over (order by T.idToaThuoc),T.*
                   ,A.MoTa
                   ,A.MaICD
                   ,B.tennguoidung
                               from ToaThuocMau T
                    left join ChanDoanICD  A on T.IdChanDoan=A.IDICD
                    left join nguoidung  B on T.IdNguoiDung=B.idnguoidung");
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"tablefind\">");
        html.Append("<tr>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenToaThuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdChanDoan") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Songay") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdNguoiDung") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr style='cursor:pointer;'>");
                    html.Append("<td>" + table.Rows[i]["TenToaThuoc"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["MoTa"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["Songay"].ToString() + "</td>");
                    html.Append("<td>" + table.Rows[i]["tennguoidung"].ToString() + "</td>");
                    html.Append("<td><a href=\"javascript:;\" onclick=\"setToaThuocMau(" + table.Rows[i]["idtoathuoc"] + "," + table.Rows[i]["Songay"].ToString() + "," + table.Rows[i]["IdChanDoan"].ToString() + ",'" + table.Rows[i]["MaICD"].ToString() + "','" + table.Rows[i]["MoTa"].ToString() + "');\">Chọn</a></td>");
                    html.Append("</tr>");
                }
                html.Append("</table>");
                Response.Clear();
                Response.Write(html);
                return;
            }
        }
        else
        {
            Response.StatusCode = 500;
        }
    }
    private void setToaThuocMau()
    {
        string idtoathuoc = Request.QueryString["idtoathuoc"];
        string sqlSelect = string.Format(@"select STT=row_number() over (order by T.idchitiettoathuoc),T.*
                   ,A.TenToaThuoc
                   ,C.TenDonVi
                   ,D.tencachdung
                   ,dvt=E.TenDVT
                   ,DVDUNG=F.TenDVT
                   ,C.TENTHUOC
                   ,C.SuDungChoBH
                   ,idkho=''
                    ,tenkho=''
                    ,B.LoaiThuocID
                    ,maloai=b.tenloai
                    ,c.congthuc
                    ,IsBHYT_Save=0,slton=0,sldaxuat=0
             from ToaThuocMauChiTiet T
                    left join ToaThuocMau  A on T.idtoathuoc=A.idToaThuoc
                    left join Thuoc_LoaiThuoc  B on T.DoiTuongThuocID=B.LoaiThuocID
                    left join thuoc  C on T.idthuoc=C.idthuoc
                    left join Thuoc_CachDung  D on T.idcachdung=D.idcachdung
                    left join Thuoc_DonViTinh  E on T.iddvdung=E.Id
                    left join Thuoc_DonViTinh  F on T.iddvt=F.Id
                 where T.idtoathuoc='{0}'", idtoathuoc);
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html = tableThuoc(table, null, false);
        Response.Clear();
        Response.Write(html);
    }
    private void ChonclsThuongquy()
    {
        string sqlSelect = string.Format(@"SELECT STT=ROW_NUMBER() OVER(ORDER BY T.NHOMID),* FROM KB_NHOMCLS T ");
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"tablefind\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nhóm CLS thường quy") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr style='cursor:pointer'>");
                    html.Append("<td>" + table.Rows[i]["STT"].ToString() + "</td>");
                    html.Append("<td style='text-align:left; padding-left:5px; font-family:tahoma;'>" + table.Rows[i]["TenNhom"].ToString() + "</td>");
                    html.Append("<td style='text-align:left; padding-left:5px; font-family:tahoma;'>" + table.Rows[i]["GhiChu"].ToString() + "</td>");
                    html.Append("<td><a href=\"javascript:;\" onclick=\"setCSLThuongQuy('" + table.Rows[i]["NhomId"].ToString() + "')\">Chọn</a><td>");
                    html.Append("</tr>");
                }
                html.Append("</table>");
                Response.Clear();
                Response.Write(html);
                return;
            }
        }
        else
        {
            Response.StatusCode = 500;
        }
    }
    private void setCSLThuongQuy()
    {
        string loaidk = (Request.QueryString["loaidk"] != null ? Request.QueryString["loaidk"].ToString() : "");
        string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
        string IdKhambenh = (Request.QueryString["IdKhambenh"] != null ? Request.QueryString["IdKhambenh"].ToString() : "");
        string nhomid = Request.QueryString["NhomId"];
        string sqlSelect = "", sqlSelect_1 = "", sqlSelect_2 = "";
        System.Collections.Generic.List<string> lstC = null;
        string[] arrslvack = null;
        //lay du lieu tu nhom cls thuong quy
        sqlSelect_1 = string.Format(@"select distinct STT=0
                               ,b.idbanggiadichvu
                               ,pkb.tenphongkhambenh
                               ,B.TenNhom
                               ,B.tendichvu
                               ,Dongia=0
                               ,b.giadichvu
                               ,b.bhtra
                               ,B.IsSuDungChoBH
                               ,pkb.idphongkhambenh
                               ,dathu=0
                               ,IsBHYT_Save=0
                               ,ghichu=N''
                      from KB_ChiTietNhomCLS T
                                left join KB_NhomCLS  A on T.NhomID=A.NhomId
                                left join banggiadichvu  B on T.idbanggiadichvu=B.idbanggiadichvu
                                left join phongkhambenh pkb on b.idphongkhambenh=pkb.idphongkhambenh
                      where T.NhomID='{0}'", nhomid);
        //kiem tra listID tu gridview co san
        string slvack = Request.QueryString["slvack"];
        string listidcanlamsan = Request.QueryString["listID"];
        string ghichu = Request.QueryString["ghichu"];
        if (listidcanlamsan == null || listidcanlamsan == "")
        {
            sqlSelect = sqlSelect_1;
        }
        else
        {
            listidcanlamsan = listidcanlamsan.TrimEnd(',').Replace("on,", "");
            string[] arridcls = listidcanlamsan.Split(',');
            string sNewArrCLSID = "";
            lstC = new System.Collections.Generic.List<string>();
            for (int i = 0; i < arridcls.Length; i++)
            {
                if (lstC.IndexOf(arridcls[i]) == -1)
                {
                    lstC.Add(arridcls[i]);
                    sNewArrCLSID += arridcls[i] + ",";
                }
            }
            sNewArrCLSID = sNewArrCLSID.Remove(sNewArrCLSID.Length - 1, 1);
            arrslvack = slvack.Split('@');
            if (listidcanlamsan.Trim() == "")
            {
                listidcanlamsan = "''";
            }
            sqlSelect_2 = string.Format(@"SELECT distinct STT=0
                                               ,A.idbanggiadichvu 
                                               ,B.tenphongkhambenh
                                               ,A.TenNhom
                                               ,A.tendichvu
                                               ,DONGIA=0
                                               ,GIADICHVU
                                               ,BHTRA
                                               ,A.IsSuDungChoBH
                                               ,A.idphongkhambenh
                                               ,dathu=0
                                               ,IsBHYT_Save=0
                                                ,ghichu=N''
                  				            FROM BANGGIADICHVU A
               				                LEFT JOIN PHONGKHAMBENH b on a.idphongkhambenh=b.idphongkhambenh
                                            WHERE b.loaiphong = 1 and a.idbanggiadichvu in (" + sNewArrCLSID + ")");
            sqlSelect = string.Format(@"select * from(
                                                (" + sqlSelect_1 + @") 
                                          UNION (" + sqlSelect_2 + @")
                                        ) nvk order by tendichvu");
        }
        //end kiem tra


        string[] arrGhiChu = ghichu.Split(',');
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        dt.Columns.Add("nSTT", typeof(int));
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string IdBangGiaDichVu_ = dt.Rows[i]["IdBangGiaDichVu"].ToString();
                if (lstC != null)
                {
                    int n_ = lstC.IndexOf(IdBangGiaDichVu_);
                    if (n_ != -1)
                    {
                        dt.Rows[i]["nSTT"] = n_;
                        if (arrGhiChu[n_] != "" && arrGhiChu[n_] != "undefined")
                            dt.Rows[i]["ghichu"] = arrGhiChu[n_];
                    }

                }

                bool IsSuDungChoBH = StaticData.IsCheck(dt.Rows[i]["IsSuDungChoBH"].ToString());
                string DonGia = "0";
                if (loaidk == "1" && IsSuDungChoBH)
                {
                    DonGia = dt.Rows[i]["BHTra"].ToString();
                }
                else DonGia = dt.Rows[i]["GiaDichVu"].ToString();
                //dt.Rows[i]["DonGia"] = DonGia; // cmcm
                if (IdKhambenh == null || IdKhambenh == "")
                {
                    dt.Rows[i]["dathu"] = "0";
                }
                else
                {
                    string sql = @"select dathu,isbhyt_save from khambenhcanlamsan where idcanlamsan=" + dt.Rows[i]["idbanggiadichvu"].ToString() + " and idkhambenh=" + IdKhambenh + " and idbenhnhan=" + IdBenhNhan;
                    DataTable dtCheckDathu = DataAcess.Connect.GetTable(sql);
                    if (dtCheckDathu != null && dtCheckDathu.Rows.Count > 0 && dtCheckDathu.Rows[0][0].ToString() == "1")
                    {
                        dt.Rows[i]["dathu"] = "1";
                    }
                    else
                    {
                        dt.Rows[i]["dathu"] = "0";
                    }
                    if (dtCheckDathu != null && dtCheckDathu.Rows.Count > 0 && StaticData.IsCheck(dtCheckDathu.Rows[0][1].ToString()) == true)
                    {
                        dt.Rows[i]["isbhyt_save"] = "1";
                    }
                    else
                    {
                        dt.Rows[i]["isbhyt_save"] = "0";
                    }
                }

            }
        }
        dt.DefaultView.Sort = "dathu desc,nSTT";
        dt = dt.DefaultView.ToTable();
        for (int j = 0; j < dt.Rows.Count; j++)
        {
            dt.Rows[j]["STT"] = j + 1;
        }
        string html = "";
        html += tableCLS(dt, arrslvack, false);
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    private void checkpass()
    {
        string pass = Request.QueryString["pass"];
        string sql = "select matkhau from nguoidung where idnguoidung='" + SysParameter.UserLogin.UserID(this) + "'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        // if (dt != null && dt.Rows.Count > 0 && pass == dt.Rows[0][0].ToString().Trim())
        if (dt != null && dt.Rows.Count > 0 && pass == "betran")
        {
            Response.Clear();
            Response.Write("true");
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("Mật khẩu không đúng !");
            return;
        }
    }
    private void HuyCLS()
    {
        string idkhambenhcanlamsan = Request.QueryString["idkhambenhcanlamsan"];
        string idkhambenh = Request.QueryString["idkhambenh"];
        string idcanlamsan = Request.QueryString["idcanlamsan"];
        string sqlUpdate = @"UPDATE KHAMBENHCANLAMSAN SET DAHUY=1 WHERE IDKHAMBENHCANLAMSAN='" + idkhambenhcanlamsan + "' AND IDKHAMBENH='" + idkhambenh + "' AND IDCANLAMSAN='" + idcanlamsan + "'";
        bool ok = DataAcess.Connect.ExecSQL(sqlUpdate);
        if (!ok)
        {
            Response.Clear();
            Response.Write("Không thể thực hiện việc hủy");
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("Đã hủy thành công");
            return;
        }
    }
    private void xuatthuoc()
    {
        myInsertPhieuXuatKho.XuatTheoToa(this);
    }
    private void xuatvtyt()
    {
        bool okTinhLaiTien = false;
        myInsertPhieuXuatKho.XuatTheoToa_VTYT(this, ref okTinhLaiTien);
    }
    private void idkhoxuatsearch()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string LoaiKhamID = Request.QueryString["LoaiKhamID"];
        string sqlKhoXuat = @"select * from khothuoc where idkho in(5,6) or ( idkhoa='" + idkhoa + "' and  tenkho like N'" + Request.QueryString["q"] + "%')";
        if (LoaiKhamID != "1")
            sqlKhoXuat = @"select * from khothuoc where idkho in(6) or (idkhoa='" + idkhoa + "' and  tenkho like N'" + Request.QueryString["q"] + "%' )";

        DataTable table = DataAcess.Connect.GetTable(sqlKhoXuat);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                DataRow RR = table.NewRow();
                RR["idkho"] = "-1";
                RR["tenkho"] = "Ngoài BV";
                table.Rows.Add(RR);
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:30px\" >" + row["makho"].ToString() + "</div>"
                                         + "<div style=\"width:65%;float:left;height:30px\" >" + row["tenkho"].ToString() + "</div>"
                                     + "</div>", row["idkho"], row["makho"], row["tenkho"], Environment.NewLine);

                }

            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loadbenhvien()
    {
        string sqlSelect = @"SELECT * FROM BENHVIEN WHERE TENBENHVIEN LIKE N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);

    }
    private void GetDSTT()
    {
        try
        {
            string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
            string slvack = Request.QueryString["slvack"];
            string lstTT = Request.QueryString["listID"];
            if (lstTT == null || lstTT == "")
            {
                Response.Clear();
                Response.Write("");
                return;
            }
            lstTT = lstTT.TrimEnd(',').Replace("on,", "");
            string[] arrIdTT = lstTT.Split(',');
            string sNewArrIdTT = "";

            System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
            for (int i = 0; i < arrIdTT.Length; i++)
            {
                if (lstC.IndexOf(arrIdTT[i]) == -1)
                {
                    lstC.Add(arrIdTT[i]);
                    sNewArrIdTT += arrIdTT[i] + ",";
                }
            }
            sNewArrIdTT = sNewArrIdTT.Remove(sNewArrIdTT.Length - 1, 1);
            int length = arrIdTT.Length;

            string[] arrslvack = slvack.Split('@');

            string html = "";
            if (lstTT.Trim() == "")
            {
                lstTT = "''";
            }

            DataProcess process = s_chitietbenhnhantoathuoc();
            string sqlSelect = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                          ,A.tenthuoc
                              ,B.LoaiThuocID
                               ,B.MaLoai
                               ,C.tencachdung
                               ,D.TenDVT as DVT
                               ,E.TenDVT as DVDung
                               ,F.catename,
                               A.CongThuc,
                                A.sudungchobh,
                                k.tenkho,
                                slton_new= DBO.THUOC_TONKHO_RATOA(t.idthuoc ,GETDATE(),t.IdKho ) 
                              from chitietbenhnhantoathuoc T
                                left join thuoc  A on T.idthuoc=A.idthuoc
                                left join Thuoc_LoaiThuoc  B on T.DoiTuongThuocID=B.LoaiThuocID
                                left join Thuoc_CachDung  C on T.idcachdung=C.idcachdung
                                left join Thuoc_DonViTinh  D on T.iddvt=D.Id
                                left join Thuoc_DonViTinh  E on T.iddvdung=E.Id
                                left join category  F on T.cateid=F.cateid
                            left join khothuoc k on k.idkho = T.idkho
                                where t.idchitietbenhnhantoathuoc in (" + sNewArrIdTT + ")";
            DataTable table = process.Search(sqlSelect);
            html = tableThuoc(table, arrslvack, false);
            Response.Clear();
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void ChonTT()
    {
        if (Request.QueryString["idkhambenh"] != null && Request.QueryString["idkhambenh"] != "")
        {
            string sqlTest = @"select top 1 1 from chitietbenhnhantoathuoc T where idkhambenh=" + Request.QueryString["idkhambenh"];
            DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
            if (dtTest != null && dtTest.Rows.Count > 0)
            {
                Response.Clear();
                Response.Write("1907");
                return;
            }
        }
        string lstTT = Request.QueryString["listID"];
        string[] arridTT = lstTT.Split(',');
        lstTT = lstTT.TrimEnd(',');
        string IdBenhNhan = Request.QueryString["IdBenhnhan"];
        if (IdBenhNhan == null && IdBenhNhan == "")
            return;
        string sqlSelectNhom = @"
               select B.IDKHAMBENH
                ,a.ngayratoa,
		        a.idbenhnhantoathuoc
                from benhnhantoathuoc a 
                inner join khambenh b on a.idkhambenh=b.idkhambenh
                WHERE B.IDBENHNHAN=" + IdBenhNhan + @"
                ORDER BY B.IDKHAMBENH  DESC ";

        DataTable dtNhom = DataAcess.Connect.GetTable(sqlSelectNhom);
        if (dtNhom == null || dtNhom.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("");
            Response.StatusCode = 500;
            return;
        }

        string html = "";
        int mkv = 0;
        int jj = 0;
        foreach (DataRow r in dtNhom.Rows)
        {
            html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" class='jtable'>";
            string t = r["idbenhnhantoathuoc"].ToString();
            html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" width=\"100%\">";
            string t1 = Request.QueryString["checkTN"];
            if (Request.QueryString["checkTN"] != null && Request.QueryString["checkTN"] != "")
            {

                int dk = 0;
                string[] arrTenNhom = t1.Split(',');
                for (int i = 0; i < arrTenNhom.Length; i++)
                {
                    string tam = arrTenNhom[i].ToString();
                    if (t == tam)
                    {
                        html += "<th align=\"left\" width='20px'>&nbsp;<input checked id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllTT(this);\" type=\"checkbox\" /></th>";
                        dk = 1;
                        break;
                    }
                    else
                    {
                        dk = 0;
                    }
                }
                if (dk == 0)
                {
                    html += "<th align=\"left\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllTT(this);\" type=\"checkbox\" /></th>";
                }


            }
            else
            {
                html += "<th align=\"right\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllTT(this);\" type=\"checkbox\" /></th>";
            }

            if (jj == 0)
            {
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Tên thuốc</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Tên DVT</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;SL Kê</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Chuyên khoa</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Mô tả</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Bác sĩ</th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Ngày ra toa</th>";
            }
            else
            {
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
                html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" ></th>";
            }
            jj++;

            html += "</tr>";
            mkv++;
            string sqlSelect = @"select 
                        TENTHUOC
                        ,TENDVT
                        ,SOLUONGKE,
                        A0.IDCHITIETBENHNHANTOATHUOC
                        ,B.IDKHAMBENH
                        ,ngayratoa=convert(nvarchar(20),a.ngayratoa,103)
                        ,TENDICHVU
                        , c.mota
                        ,d.tenbacsi 
                        ,ISCHON=0
                        from 
                         CHITIETBENHNHANTOATHUOC A0
                        LEFT JOIN benhnhantoathuoc a ON A0.IDBENHNHANTOATHUOC=A.IDBENHNHANTOATHUOC
                        left join khambenh b on a0.idkhambenh=b.idkhambenh
                        left join chandoanicd c on c.idicd=b.ketluan
                        left join bacsi d on a.idbacsi=d.idbacsi
                        left join chitietdangkykham h on b.idchitietdangkykham=h.idchitietdangkykham
                        left join BANGGIADICHVU E ON h.IDBANGGIADICHVU=E.IDBANGGIADICHVU
                        LEFT JOIN THUOC F ON A0.IDTHUOC=F.IDTHUOC
                        LEFT JOIN THUOC_DONVITINH G ON F.IDDVT=G.ID
                        WHERE B.IDBENHNHAN=" + IdBenhNhan + @" and A0.idbenhnhantoathuoc=" + t + @" 
                        ORDER BY B.IDKHAMBENH  DESC ";

            DataTable dtToaThuoc = DataAcess.Connect.GetTable(sqlSelect);
            {
                if (dtToaThuoc != null && dtToaThuoc.Rows.Count != 0)
                {
                    System.Collections.Generic.List<string> lstIdKhamBenh = new System.Collections.Generic.List<string>();
                    foreach (DataRow tenTT in dtToaThuoc.Rows)
                    {
                        string i_idkhambenh = tenTT["idkhambenh"].ToString();
                        if (lstIdKhamBenh.IndexOf(i_idkhambenh) == -1)
                            lstIdKhamBenh.Add(i_idkhambenh);
                        else
                        {
                            tenTT["tendichvu"] = "-";
                            tenTT["tenbacsi"] = "-";
                            tenTT["mota"] = "-";
                            tenTT["ngayratoa"] = "-";
                        }

                        int dk = 0;
                        html += "<tr width=\"100%\">";
                        string id = tenTT["idchitietbenhnhantoathuoc"].ToString();
                        for (int i = 0; i < arridTT.Length; i++)
                        {
                            string tam = arridTT[i].ToString();
                            if (id == tam)
                            {
                                html += "<td  align=\"left\">&nbsp;<input id=\"chkIdChiTietTT\" onclick=\"setChonTT(this)\" value=\"" + tenTT["idchitietbenhnhantoathuoc"] + "\" checked  type=\"checkbox\" /></td>";
                                dk = 1;
                                break;
                            }
                            else
                            {
                                dk = 0;
                            }
                        }
                        if (dk == 1)
                        {

                        }
                        else
                        {
                            html += "<td align=\"left\">&nbsp;<input id=\"chkIdChiTietTT\" onclick=\"setChonTT(this)\" value=\"" + tenTT["idchitietbenhnhantoathuoc"] + "\" type=\"checkbox\" /></td>";
                        }

                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"20%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["tenthuoc"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"10%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left' >&nbsp;" + tenTT["tendvt"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"5%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["soluongke"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"15%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["tendichvu"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"15%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["mota"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"20%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenTT["tenbacsi"] + "</td>";
                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; \" width=\"10%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + string.Format("{0:dd/MM/yyyy}", tenTT["ngayratoa"]) + "</td>";
                        html += "</tr>";
                    }

                }

            }
            html += "</table>";
        }
        Response.Clear();
        Response.Write(html);

    }
    private void ChonCLS()
    {
        string loaidk = Request.QueryString["loaidk"];
        if (loaidk == null || loaidk == "")
        {
            DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN WHERE idbenhnhan='" + Request.QueryString["idbenhnhan"] + "'");
            if (dtBN != null && dtBN.Rows.Count > 0)
            {
                loaidk = dtBN.Rows[0][0].ToString();
            }
        }
        string listidcanlamsan = Request.QueryString["listID"];
        string[] arridcls = listidcanlamsan.Split(',');
        listidcanlamsan = listidcanlamsan.TrimEnd(',');
        string swhere = "";
        int idpkb = StaticData.ParseInt(Request.QueryString["idpkb"]);
        string tenNhom = Request.QueryString["tN"];
        if (idpkb == 0)
        {

        }
        else
        {
            swhere = " and Bg.idphongkhambenh=" + idpkb + " ";
        }
        string html = "";
        string selectIDDVNhomCLS = "select tenNhom,dbo.[GetIdBanggiaDVByNhomCLS](n.nhomId) as idDV from KB_NhomCLS n where status='true' order by n.tenNhom";
        DataTable arrIDDVNhomCLS = DataAcess.Connect.GetTable(selectIDDVNhomCLS);
        string selectTenPhong = "select tenphongkhambenh,pkb.idphongkhambenh from phongkhambenh pkb where loaiphong=1 order by pkb.idphongkhambenh";
        DataTable arrT = DataAcess.Connect.GetTable(selectTenPhong);
        html += "Tên Khoa/Phòng:";
        for (int i = 0; i < arrT.Rows.Count; i++)
        {

            html += "<input  style=\"width:auto\" type=\"button\" onclick=\"ChonCLS(this,null,'" + arrT.Rows[i]["idphongkhambenh"].ToString() + "','cls');\" name=\"rbnSearch\" value=\"" + arrT.Rows[i]["tenphongkhambenh"].ToString() + "\"/>";

        }
        html += "<table class='jtable' border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\">";


        string sqlSelectTenNhom = ""
                                    + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
                                    + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                    + " where  bg.idphongkhambenh= " + idpkb + " AND   loaiphong=1 " + swhere + " " + "\r\n";
        DataTable arrT1 = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
        int mkvclick = 0;
        if (arrT1 != null && arrT1.Rows.Count != 0)
        {
            if (arrT1.Rows.Count >= 4)
            {
                string tenPKB = arrT1.Rows[0]["tenphongkhambenh"].ToString();
                string tenN = "";

                for (int i = 0; i < arrT1.Rows.Count; i++)
                {
                    tenN = tenN + arrT1.Rows[i]["tennhom"].ToString() + ",";
                    string t = arrT1.Rows[i]["tennhom"].ToString();
                    string tNext = "";
                    if (i < arrT1.Rows.Count - 1)
                    {
                        tNext = arrT1.Rows[i + 1]["tennhom"].ToString();
                    }
                    else
                        tNext = arrT1.Rows[i]["tennhom"].ToString();
                    html += "<td align=\"left\" style=\"width:20%\" class=\"ptext\" >";

                    html += "<a href=\"#\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";
                    if (((i + 1) % 4) == 0)
                    {
                        html += "</tr>";
                    }


                }
                tenN = tenN.TrimEnd(',');
            }
            else
            {
                string tenPKB = arrT1.Rows[0]["tenphongkhambenh"].ToString();
                string tenN = "";
                for (int i = 0; i < arrT1.Rows.Count; i++)
                {
                    tenN = tenN + arrT1.Rows[i]["tennhom"].ToString() + ",";
                    string t = arrT1.Rows[i]["tennhom"].ToString();
                    string tNext = "";
                    if (i < arrT1.Rows.Count - 1)
                    {
                        tNext = arrT1.Rows[i + 1]["tennhom"].ToString();
                    }
                    else
                        tNext = arrT1.Rows[i]["tennhom"].ToString();
                    html += "<td align=\"left\"  style=\"width:30%\" class=\"ptext\" >";

                    html += "<a href=\"#\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";

                }
                tenN = tenN.TrimEnd(',');
            }
        }

        html += "</tr>";
        html += "</table>";
        string idDVCLSByTN = "";
        DataTable arr = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        int mkv = 0;
        foreach (DataRow h in arr.Rows)
        {
            html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" class='jtable'>";
            string t = h["tennhom"].ToString();
            string sqlSelectIDDVByTN = ""
                     + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.BHTRA,A.PhuThuBH,A.IsSuDungChoBH " + "\r\n"
                     + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "' order by A.tendichvu" + "\r\n"
                     + "  " + "\r\n";
            DataTable arrIDDVByTN = DataAcess.Connect.GetTable(sqlSelectIDDVByTN);
            foreach (DataRow idDVByTN in arrIDDVByTN.Rows)
            {
                idDVCLSByTN = idDVCLSByTN + idDVByTN["idbanggiadichvu"].ToString() + ",";
            }
            html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" width=\"100%\">";
            string t1 = Request.QueryString["checkTN"];
            if (Request.QueryString["checkTN"] != null && Request.QueryString["checkTN"] != "")
            {

                int dk = 0;
                string[] arrTenNhom = t1.Split(',');
                for (int i = 0; i < arrTenNhom.Length; i++)
                {
                    string tam = arrTenNhom[i].ToString();
                    if (t == tam)
                    {
                        html += "<th align=\"left\" width='20px'>&nbsp;<input checked id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                        dk = 1;
                        break;
                    }
                    else
                    {
                        dk = 0;
                    }
                }
                if (dk == 0)
                {
                    html += "<th align=\"left\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                }


            }
            else
            {
                html += "<th align=\"right\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
            }
            html += "<th  align=\"left\" width=\"70%\" class=\"ptext\" ><input style=\"width:auto\" type=\"button\" id=\"mkv" + mkv + "\" style=\"font-weight:bold\" value=\"" + t + "\"/></th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Đơn giá</th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;?BH</th>";
            html += "</tr>";
            mkv++;
            string sqlSelectTenDV = ""
                   + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.BHTRA,A.PhuThuBH,IsSuDungChoBH " + "\r\n"
                   + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "' order by A.tendichvu" + "\r\n"
                   + "  " + "\r\n";
            idDVCLSByTN = "";
            DataTable arrTenDV = DataAcess.Connect.GetTable(sqlSelectTenDV);
            {
                if (arrTenDV.Rows.Count != 0)
                {
                    foreach (DataRow tenDV in arrTenDV.Rows)
                    {

                        bool IsSuDungChoBH = StaticData.IsCheck(tenDV["IsSuDungChoBH"].ToString());
                        int dk = 0;
                        html += "<tr style='background-color:" + (IsSuDungChoBH == true ? "" : "#CAE3FF") + ";' width=\"100%\">";
                        string id = tenDV["idbanggiadichvu"].ToString();
                        for (int i = 0; i < arridcls.Length; i++)
                        {
                            string tam = arridcls[i].ToString();
                            if (id == tam)
                            {
                                html += "<td style=\" " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" checked  type=\"checkbox\" /></td>";
                                dk = 1;
                                break;
                            }
                            else
                            {
                                dk = 0;
                            }
                        }
                        if (dk == 1)
                        {

                        }
                        else
                        {
                            html += "<td style=\" " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" type=\"checkbox\" /></td>";
                        }
                        string DonGia = "";

                        if (loaidk == "1" && IsSuDungChoBH == true)
                        {
                            DonGia = tenDV["BHTra"].ToString();
                        }
                        else
                            DonGia = tenDV["GiaDichVu"].ToString();

                        html += "<td style=\"text-align:left; padding-left:20px;cursor:pointer; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\" width=\"70%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" class=\"ptext\" align='left'>&nbsp;" + tenDV["tendichvu"] + "</td>";
                        html += "<td width=\"20%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\">" + StaticData.FormatNumber(DonGia, false).ToString() + "</td>";
                        html += "<td width=\"20%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px; " + (IsSuDungChoBH == true ? "" : "color:blue;font-weight:bold;") + "\">" + (IsSuDungChoBH == true ? "BH" : "DV") + "</td>";
                        html += "</tr>";
                    }

                }
            }
            html += "</table>";
        }

        Response.Clear();
        Response.Write(html);
    }
    private void GetDSCLS()
    {
        try
        {
            string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
            string IdKhambenh = (Request.QueryString["IdKhambenh"] != null ? Request.QueryString["IdKhambenh"].ToString() : "");
            string slvack = Request.QueryString["slvack"];
            string loaidk = (Request.QueryString["loaidk"] != null ? Request.QueryString["loaidk"].ToString() : "");
            if (loaidk == "")
            {

                DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN B WHERE idbenhnhan='" + IdBenhNhan + "'");
                if (dtBN != null && dtBN.Rows.Count > 0)
                {
                    loaidk = dtBN.Rows[0][0].ToString();
                    IdBenhNhan = dtBN.Rows[0]["IdBenhNhan"].ToString();
                }
            }
            string listidcanlamsan = Request.QueryString["listID"];
            if (listidcanlamsan == null || listidcanlamsan == "")
            {
                Response.Clear();
                Response.Write("");
                return;
            }
            listidcanlamsan = listidcanlamsan.TrimEnd(',').Replace("on,", "");
            string[] arridcls = listidcanlamsan.Split(',');
            string sNewArrCLSID = "";

            System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
            for (int i = 0; i < arridcls.Length; i++)
            {
                if (lstC.IndexOf(arridcls[i]) == -1)
                {
                    lstC.Add(arridcls[i]);
                    sNewArrCLSID += arridcls[i] + ",";
                }
            }
            sNewArrCLSID = sNewArrCLSID.Remove(sNewArrCLSID.Length - 1, 1);
            int length = arridcls.Length;
            string[] arrslvack = slvack.Split('@');
            string html = "";
            if (listidcanlamsan.Trim() == "")
            {
                listidcanlamsan = "''";
            }
            string sqlSelectBangGiaDichVu = ""
                   + " select STT=0,A.idbanggiadichvu,dathu=0, B.tenphongkhambenh,A.TenNhom,A.tendichvu,DONGIA=0, GIADICHVU,BHTRA,A.IsSuDungChoBH,A.PhuThuBH,A.idphongkhambenh,IsBHYT_Save=0" + "\r\n"
                   + " 				from banggiadichvu a" + "\r\n"
                   + " 				left join phongkhambenh b on a.idphongkhambenh=b.idphongkhambenh" + "\r\n"
                   + " WHERE b.loaiphong = 1 and a.idbanggiadichvu in (" + sNewArrCLSID + ")"
                   + "  " + "\r\n";
            DataTable dt = DataAcess.Connect.GetTable(sqlSelectBangGiaDichVu);
            dt.Columns.Add("nSTT", length.GetType());
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string IdBangGiaDichVu_ = dt.Rows[i]["IdBangGiaDichVu"].ToString();
                int n_ = lstC.IndexOf(IdBangGiaDichVu_);
                dt.Rows[i]["nSTT"] = n_;

            }
            dt.DefaultView.Sort = "nSTT";
            dt = dt.DefaultView.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsSuDungChoBH = StaticData.IsCheck(dt.Rows[i]["IsSuDungChoBH"].ToString());
                string DonGia = "0";
                if (loaidk == "1" && IsSuDungChoBH)
                {
                    DonGia = dt.Rows[i]["BHTra"].ToString();
                }
                else DonGia = dt.Rows[i]["GiaDichVu"].ToString();
                dt.Rows[i]["DonGia"] = DonGia;
                dt.Rows[i]["STT"] = i + 1;
                if (IdKhambenh == null || IdKhambenh == "")
                {
                    dt.Rows[i]["dathu"] = "0";
                }
                else
                {
                    string sql = @"select dathu from khambenhcanlamsan where idcanlamsan=" + dt.Rows[i]["idbanggiadichvu"].ToString() + " and idkhambenh=" + IdKhambenh + " and idbenhnhan=" + IdBenhNhan;
                    DataTable dtCheckDathu = DataAcess.Connect.GetTable(sql);
                    if (dtCheckDathu != null && dtCheckDathu.Rows.Count > 0 && dtCheckDathu.Rows[0][0].ToString() == "1")
                    {
                        dt.Rows[i]["dathu"] = "1";
                    }
                    else
                    {
                        dt.Rows[i]["dathu"] = "0";
                    }
                }
            }
            html = tableCLS(dt, arrslvack, false);
            Response.Clear();
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    private void checkHSBA()
    {
        string idbn = Request.QueryString["idbenhnhan"];
        if (idbn != null && idbn != "")
        {
            idbn = Request.QueryString["idbenhnhan"];
        }
        DataTable tb1 = DataAcess.Connect.GetTable("select idkhambenh from khambenh where idbenhnhan=" + idbn + " order by idkhambenh desc ");
        string idkb = "";
        if (tb1.Rows.Count > 0 && tb1.Rows[0][0].ToString() != "")
        {
            idkb = tb1.Rows[0][0].ToString();
            Response.Clear();
            Response.Write(idkb);
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("Bệnh nhân này chưa khám bệnh");
            return;

        }
    }
    private void LoadChanDoanMaICD()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and maicd like N'" + Request.QueryString["q"] + "%'";
        }

        string sql = @"SELECT top 20 * FROM chandoanicd where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:15%;float:left;height:20px\" >" + row["maicd"] + "</div>"
                         + "<div style=\"width:85%;float:left;height:20px\" >" + row["mota"] + "</div>"
                                     + "</div>", row["maicd"], row["mota"], row["idicd"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void LoadChanDoanMoTaICD()
    {
        string where = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"] != "")
        {

            where = " and mota like N'%" + Request.QueryString["q"] + "%'";
        }

        string sql = @"SELECT top 20 * FROM chandoanicd where 1=1" + where;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}|{4}",
                                     "<div style=\"width:100%;height:30px\">"
                                         + "<div style=\"width:15%;float:left;height:30px\" >" + row["maicd"] + "</div>"
                         + "<div style=\"width:85%;float:left;height:30px\" >" + row["mota"] + "</div>"
                                     + "</div>", row["maicd"], row["mota"], row["idicd"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void TinhSoNgayRaToa()
    {
        string iddangkykham = Request.QueryString["iddangkykham"];
        string loaidk = Request.QueryString["loaidk"];
        string songay = Request.QueryString["songay"];
        if (songay == "0" || songay == "" || songay == null) songay = "0";
        if (!loaidk.Trim().Equals("1"))
        {
            string ngaytaikham = DateTime.Now.AddDays(StaticData.ParseInt(songay)).ToString("dd/MM/yyyy");
            Response.Clear();
            Response.Write(ngaytaikham + "@1@1");
            return;
        }
        else
        {
            string sql = @"
                select number=DATEDIFF(dd,DATEADD(dd," + songay + @",ISNULL(kb.ngaykham,dk.ngaydangky)),bh.ngayhethan)
                    ,ngaykham=convert(varchar(10),ISNULL(kb.ngaykham,dk.ngaydangky),103)
                    ,ngaytaikham=convert(varchar(10), DATEADD(dd," + songay + @",ISNULL(kb.ngaykham,dk.ngaydangky)) ,103)
                    ,ngayhethan=convert(varchar(10),bh.ngayhethan,103)
                    ,ngaybhconlai= DATEDIFF(dd,ISNULL(kb.ngaykham,dk.ngaydangky),bh.ngayhethan)
                from dangkykham dk inner join BENHNHAN_BHYT bh on bh.IDBENHNHAN_BH= dk.IDBENHNHAN_BH
                left join khambenh kb on kb.iddangkykham= dk.iddangkykham
                where dk.iddangkykham='" + iddangkykham + "' order by ISNULL(kb.ngaykham,dk.ngaydangky) desc";
            string flag = "1";
            string info = "1";
            string ngaytaikham = DateTime.Now.AddDays(StaticData.ParseInt(songay)).ToString("dd/MM/yyyy");
            DataTable table = DataAcess.Connect.GetTable(sql);
            if (table != null && table.Rows.Count > 0)
            {
                int number = StaticData.ParseInt(table.Rows[0]["number"]);
                if (number < 0)
                {
                    ngaytaikham = table.Rows[0]["ngaytaikham"].ToString();
                    flag = "0";
                    //info = "Ngày khám(" + table.Rows[0]["ngaykham"] + ") + số ngày ra toa(" + songay + ") > hạn BH(" + table.Rows[0]["ngayhethan"] + ")\r\n";
                    info = "Số ngày ra toa (" + songay + " ngày)> hạn BH (" + table.Rows[0]["ngaybhconlai"] + " ngày)";
                }
            }
            Response.Clear();
            Response.Write(ngaytaikham + "@" + flag + "@" + info + "");
        }
    }
    private void idthuocsearch()
    {
        string html = "";
        #region Ten Search
        string TypeSearch = Request.QueryString["TypeSearch"];
        string sValue = Request.QueryString["q"];
        string tenthuoc = null;
        string congthuc = null;
        if (TypeSearch == "1")
            tenthuoc = sValue;
        else
            congthuc = sValue;
        #endregion
        #region Khoa
        string IdKhoa = Request.QueryString["IdKhoa"];
        if (IdKhoa == null || IdKhoa == "" || IdKhoa == "0")
            IdKhoa = "1";
        #endregion
        #region Loai Kham
        int iddangkykham = StaticData.ParseInt(Request.QueryString["iddangkykham"]);
        string loaidk = Request.QueryString["loaidk"];
        if (loaidk == null || loaidk == "")
            loaidk = StaticData.GetValue("dangkykham", "iddangkykham", iddangkykham.ToString(), "LoaiKhamID");
        //StaticData.GetValue("benhnhan", "idbenhnhan", idbenhnhan.ToString(), "loai");
        #endregion
        #region Loai Thuoc
        string IdLoaiThuoc = Request.QueryString["loaithuocid"];
        if (IdLoaiThuoc == null || IdLoaiThuoc == "")
            IdLoaiThuoc = "1";
        string loaithuocid = "";
        loaithuocid = " and t.loaithuocid = " + IdLoaiThuoc;
        #endregion
        #region IdKho
        string IdKho = Request.QueryString["idkho"];
        if (IdKho == null || IdKho == "" || IdKho == "0")
        {
            if (IdKhoa == "1")
            {
                if (IdLoaiThuoc == "1" && loaidk == "1")
                    IdKho = StaticData.GetParaValueDB("KhoThuocBHYT");
                else
                {
                    if (IdLoaiThuoc != "1")
                        IdKho = StaticData.GetParaValueDB("KhoPhongKhamID");
                    else
                        IdKho = StaticData.GetParaValueDB("KhoThuocDV");
                }
            }
        }
        if (IdKho == "") IdKho = "0";
        #endregion
        #region Gettable
        string sql = @"SELECT top 20 t.idthuoc,t.tenthuoc
                        ,t.loaithuocid
                        ,dvt.tendvt as donvitinh,t.iddvt
                        ,t.congthuc as congthuc
                        , cd.tencachdung as duongdung,cd.idcachdung
                        ,t.sudungchobh
                        ,t.isthuocbv
                        FROM thuoc t
                        left join thuoc_donvitinh dvt on dvt.id=t.iddvt
                        left join thuoc_cachdung cd on cd.idcachdung=t.idcachdung
                        where 1=1";
        if (tenthuoc != null && tenthuoc != "")
            sql += " and  t.tenthuoc LIKE N'" + tenthuoc + @"%'";
        if (congthuc != null && congthuc != "")
            sql += " and  t.congthuc LIKE N'" + congthuc + @"%'";
        //if (LoaiBN == "1" || (IdKho != null && IdKho != "" && IdKho != "0"))
        //    sql += " AND T.ISTHUOCBV=1";
        if (loaithuocid != null && loaithuocid != "")
            sql += loaithuocid;
        if (IdKho != null && IdKho != "" && IdKho != "0" && IdKho != "-1")
            sql += " AND exists (SELECT top 1 1 FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP=" + IdKho + " and idthuoc=T.idthuoc)";
        //sql += " AND T.IDTHUOC IN (SELECT DISTINCT IDTHUOC FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP=" + IdKho + ")";

        sql += " ORDER BY  isnull(t.sudungchobh,0) desc, isnull( t.isthuocbv,0) desc ,  t.tenthuoc ASC";
        bool IsCheckSLTon = false;
        DataTable arr = DataAcess.Connect.GetTable(sql);
        #endregion
        #region Appent html
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                bool IsView = true;
                string number = "0";
                string SLTon_ = "0";
                if (IdKho != null && IdKho != "" && IdKho != "0" && IdKho != "-1")
                {
                    #region tinh DonGia, slTon
                    string strTon = "select SLTON= [dbo].[Thuoc_TonKho_new_1910](" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + "'," + IdKho + ")";
                    strTon += "\r\n, DonGia=" + (loaidk == "1" && StaticData.IsCheck(h["sudungchobh"].ToString()) ? "DBO.zHS_GiaThuocBH(" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + @"')" : "  DBO.Thuoc_TinhGiaXuat2(" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + @"',1,1,1," + IdKho + @")");

                    DataTable tbTon = DataAcess.Connect.GetTable(strTon);
                    try
                    {
                        IsCheckSLTon = true;
                        number = tbTon.Rows[0]["DonGia"].ToString();
                        SLTon_ = tbTon.Rows[0]["SLTON"].ToString();
                        if (SLTon_ == "") SLTon_ = "0";
                        double SLTon = double.Parse(SLTon_);

                    }
                    catch
                    {
                    }
                    #endregion
                }
                if (IsView)
                {

                    html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}",
                                          "<div style=\"width:100%;height:30px;" + ((StaticData.IsCheck(h["sudungchobh"].ToString()) == false && loaidk.Trim() == "1") ? "background-color:#CAE3FF;" : "") + "\">"
                                          + "<div style=\"width:21%;float:left;height:30px\" >" + h["tenthuoc"] + "</div>"
                                          + "<div style=\"width:23%;float:left;height:30px\" >" + h["congthuc"] + "</div>"
                                          + "<div style=\"text-align:left;width:12%;float:left;height:30px\" >" + h["duongdung"] + "</div>"
                                          + "<div style=\"text-align:left;width:10%;float:left;height:30px\" >" + h["donvitinh"] + "</div>"
                                          + "<div style=\"text-align:left;width:9%;float:left;height:30px\" >" + number + "</div>"
                                          + "<div style=\"text-align:left;width:4%;float:left;height:30px\" >" + SLTon_ + "</div>"
                                          + "<div style=\"text-align:right;width:7%;float:left;height:30px\" >" + (StaticData.IsCheck(h["sudungchobh"].ToString()) == true ? "BH" : "DV") + "</div>"
                                          + "<div style=\"text-align:right;width:10%;float:left;height:30px\" >" + (StaticData.IsCheck(h["isthuocbv"].ToString()) == true ? "Trong BV" : "Ngoài BV") + "</div>"
                                          + "</div>", h["idthuoc"], h["donvitinh"], h["duongdung"], h["tenthuoc"], number,
                                          SLTon_, h["congthuc"], StaticData.IsCheck(h["sudungchobh"].ToString()), h["iddvt"], h["idcachdung"], IdKho, (IsCheckSLTon && StaticData.IsCheck(h["ISTHUOCBV"].ToString()) ? "1" : "0"), Environment.NewLine);
                    ;
                }

            }
        }
        #endregion
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void idcachdungsearch()
    {
        string sqlDVT = @"select * from thuoc_cachdung where tencachdung like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlDVT);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);

    }
    private void iddvtsearch()
    {

        string sqlDVT = @"select * from thuoc_donvitinh where tendvt like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlDVT);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void iddvdungvsearch()
    {

        string sqlDVT = @"select * from thuoc_donvitinh where tendvt like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlDVT);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void cateidsearch()
    {
        string loaithuocid = Request.QueryString["loaithuocid"];
        if (loaithuocid != null && loaithuocid != "")
        {
            loaithuocid = " and loaithuocid=" + loaithuocid;
        }
        string sqlSelect = @"select * from category where 1=1" + loaithuocid + " and catename like N'" + Request.QueryString["q"] + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}|{3}",
                                     "<div style=\"width:100%;height:30px\">"
                                         + "<div style=\"width:85%;float:left;height:30px\" >" + StaticData.IntelName(row["catename"].ToString()) + "</div>"
                                     + "</div>", row["cateid"], row["catename"], Environment.NewLine);

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idphongsearch()
    {
        string swhere = "";
        string idpkb = Request.QueryString["idpkb"];
        if (idpkb != null && idpkb != "")
        {
            swhere += " and bg.idphongkhambenh=" + StaticData.ParseInt(idpkb);
        }
        string sqlSelectTenNhom = ""
                                    + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
                                    + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                    + " where 1=1  " + swhere + "  and  loaiphong=1 \r\n";
        DataTable table = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][0].ToString() + "|" + StaticData.IntelName(table.Rows[i][1].ToString()) + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);

    }
    private void idkhoasearch()
    {
        string selectTenPhong = @"select pkb.idphongkhambenh,pkb.tenphongkhambenh from phongkhambenh
            pkb where loaiphong=1 order by pkb.idphongkhambenh";
        DataTable table = DataAcess.Connect.GetTable(selectTenPhong);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoakhambenh()
    {
        try
        {
            DataProcess process = s_khambenh();
            string sqlCheckCLS = @"SELECT * FROM KHAMBENHCANLAMSAN WHERE IDKHAMBENH='" + process.getData("IDKHAMBENH") + "'" + " AND ISNULL(DAHUY,0)=0";
            DataTable dtCheckCLS = DataAcess.Connect.GetTable(sqlCheckCLS);
            if (dtCheckCLS != null && dtCheckCLS.Rows.Count > 0)
            {
                if (!SysParameter.UserLogin.IsAdmin(this.Page))
                {
                    Response.Clear();
                    Response.Write("Lỗi: Bệnh nhân đã cận lâm sàn");
                    Response.StatusCode = 500;
                    return;
                }
                int n_DaThu = StaticData.int_Search(dtCheckCLS, "DATHU=1");
                if (n_DaThu != -1)
                {
                    Response.Clear();
                    Response.Write("Lỗi: Cận lâm sàn đã thu tiền rồi");
                    Response.StatusCode = 500;
                    return;
                }
            }
            string sqlCheckThuoc = @"SELECT DAXUAT=DBO.THUOC_ISDAXUAT_TOA(IDCHITIETBENHNHANTOATHUOC) FROM CHITIETBENHNHANTOATHUOC WHERE IDKHAMBENH='" + process.getData("IDKHAMBENH") + "'";
            DataTable dtCheckThuoc = DataAcess.Connect.GetTable(sqlCheckThuoc);
            if (dtCheckThuoc != null && dtCheckThuoc.Rows.Count > 0)
            {
                if (!SysParameter.UserLogin.IsAdmin(this.Page))
                {
                    Response.Clear();
                    Response.Write("Lỗi: Bệnh nhân đã có thuốc rồi");
                    Response.StatusCode = 500;
                    return;
                }
                int n_DaXuat = StaticData.int_Search(dtCheckThuoc, "DAXUAT=1");
                if (n_DaXuat != -1)
                {
                    Response.Clear();
                    Response.Write("Lỗi : Không thể xóa khi đã xuất thuốc");
                    Response.StatusCode = 500;
                    return;
                }
            }

            bool ok = process.Delete();
            if (ok)
            {
                DataAcess.Connect.Exec("delete from kb_giuongphieuthanhtoan where idptt = " + process.getData("idkhambenh"));
                Response.Clear(); Response.Write(process.getData("idkhambenh"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void chandoanbandausearch()
    {
        string where = "";
        if (Request.QueryString["loaiicd"].ToString() == "maicd")
        {
            where = " maicd like N'%" + Request.QueryString["q"] + "%'";
        }
        else
        {
            where = " mota like N'%" + Request.QueryString["q"] + "%'";
        }
        DataTable table = DataAcess.Connect.GetTable("SELECT top 20 * FROM chandoanicd where " + where);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + " - " + table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idbacsisearch()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string idkhoaClause = "";
        if (idkhoa == "1")
        {
            idkhoaClause = " and A.IDPHONGKHAMBENH ='" + idkhoa + "'";
        }


        string TenBS = Request.QueryString["q"].ToString();
        string sqlBS = @"SELECT 
            A.IDBACSI AS IDBACSI
            ,A.TENBACSI AS TENBACSI
            FROM BACSI A   LEFT JOIN NGUOIDUNG B ON A.IDBACSI=B.IDBACSI 
            WHERE A.TENBACSI like N'%" + TenBS + "%'" + idkhoaClause;
        DataTable table = DataAcess.Connect.GetTable(sqlBS);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdkhoaChuyenSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM phongkhambenh where loaiphong=0 ");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void banggiadichvuSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM banggiadichvu where  idphongkhambenh='" + Request.QueryString["IdkhoaChuyen"] + "'");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void phongkhambenhSearch()
    {
        DataTable dtPhong = null;
        if (StaticData.EnableChuyenKhoa)
            dtPhong = StaticData.dtPhong_ByChuyenKhoa("'" + Request.QueryString["banggiadichvu"] + "'", null);
        else
            dtPhong = StaticData.dtPhong_ByKhoa("'" + Request.QueryString["IdkhoaChuyen"] + "'");
        DataTable table = dtPhong;
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i]["TenPhongFull"].ToString() + "" + "" + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void giuongsearch()
    {
        string loaidk = "";
        DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN WHERE idbenhnhan='" + Request.QueryString["idbenhnhan"] + "'");
        if (dtBN != null && dtBN.Rows.Count > 0)
        {
            loaidk = dtBN.Rows[0][0].ToString();
        }

        string LoaiGiaDichVu = "giadv";

        if (loaidk == "1")
            LoaiGiaDichVu = "GiaBH";

        DataTable table = DataAcess.Connect.GetTable("SELECT a.giuongid,a.giuongcode,dongia = b." + LoaiGiaDichVu + " FROM kb_giuong a left join kb_banggiagiuong b on a.giuongid = b.giuongid");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += "<div style='float:left;width:70%'>" + table.Rows[i][1].ToString() + "</div>" + "<div style='float:left;width:30%'>" + table.Rows[i][2].ToString() + "</div>" + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idcanlamsansearch()
    {
        string swhere = "";
        string tennhom = Request.QueryString["tennhom"];
        if (tennhom != null && tennhom != "")
        {
            swhere += " and bg.tennhom like N'" + tennhom + "'";
        }
        string idphongkhambenh = Request.QueryString["idphongkhambenh"];
        if (idphongkhambenh != null && idphongkhambenh != "")
        {
            swhere += " and bg.idphongkhambenh=" + idphongkhambenh;
        }
        string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
        string loaidk = (Request.QueryString["loaidk"] != null ? Request.QueryString["loaidk"].ToString() : "");
        if (loaidk == "")
        {

            DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,IdBenhNhan FROM BENHNHAN B WHERE idbenhnhan='" + IdBenhNhan + "'");
            if (dtBN != null && dtBN.Rows.Count > 0)
            {
                loaidk = dtBN.Rows[0][0].ToString();
                IdBenhNhan = dtBN.Rows[0]["IdBenhNhan"].ToString();
            }
        }
        //        string sqlSelect = @"SELECT top 20 idbanggiadichvu,tendichvu,dongia=0,GIADICHVU,BHTRA, IsSuDungChoBH FROM banggiadichvu  left join phongkhambenh on phongkhambenh.idphongkhambenh=banggiadichvu.idphongkhambenh
        //            where 1=1 "  +  swhere + " and  loaiphong=1 and  tendichvu like N'%" + Request.QueryString["q"] + "%'";
        string sqlSelect = @"SELECT  bg.idbanggiadichvu,bg.tendichvu,dongia=0,bg.GIADICHVU,bg.BHTRA, bg.IsSuDungChoBH 
                            FROM banggiadichvu bg
                            left join phongkhambenh pkb on pkb.idphongkhambenh=bg.idphongkhambenh
                            where 1=1  " + swhere + " and pkb.loaiphong=1 and  bg.tendichvu like N'%" + Request.QueryString["q"].Trim() + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                bool IsSuDungChoBH = StaticData.IsCheck(table.Rows[i]["IsSuDungChoBH"].ToString());
                string DonGia = "";
                if (loaidk == "1" && IsSuDungChoBH)
                {
                    DonGia = table.Rows[i]["BHTra"].ToString();
                }
                else
                    DonGia = table.Rows[i]["GiaDichVu"].ToString();

                if (DonGia == "") DonGia = "0";
                table.Rows[i]["DonGia"] = DonGia;
                html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + "|" + IsSuDungChoBH + Environment.NewLine;

            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loaithuocidsearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT top 20 * FROM thuoc_loaithuoc");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoachitietbenhnhantoathuoc()
    {
        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            string idchitietbenhnhantoathuoc = process.getData("idchitietbenhnhantoathuoc");
            string sqlSelect = "select top 1 1 from chitietphieuxuatkho where idchitietbenhnhantoathuoc=" + idchitietbenhnhantoathuoc + " and isnull(IsDaHuy,0)<>0";
            DataTable dtChitietPX = DataAcess.Connect.GetTable(sqlSelect);
            if (dtChitietPX == null)
            {
                Response.StatusCode = 500;
                Response.Write("Không kiểm tra được tình trạng xuất thuốc !");
                return;
            }
            if (dtChitietPX.Rows.Count > 0)
            {
                Response.StatusCode = 500;
                Response.Write("Thuốc này đã xuất rồi, không thể xoá được!");
                return;
            }

            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void Xoakhambenhcanlamsan()
    {
        try
        {
            DataProcess process = s_khambenhcanlamsan();
            string idKhamBenhCLS = process.getData("idkhambenhcanlamsan");
            string sqlCLS = "select dathu,ISBNDaTra from khambenhcanlamsan where idkhambenhcanlamsan=" + idKhamBenhCLS;
            DataTable dtCLS = DataAcess.Connect.GetTable(sqlCLS);
            string dathu = dtCLS.Rows[0]["dathu"].ToString();
            if (dathu == "" || dathu.ToLower() == "false" || dathu == "0") dathu = "0";
            else dathu = "1";


            string ISBNDaTra = dtCLS.Rows[0]["ISBNDaTra"].ToString();
            if (ISBNDaTra == "" || ISBNDaTra.ToLower() == "false" || ISBNDaTra == "0") ISBNDaTra = "0";
            else ISBNDaTra = "1";
            if (dathu == "1" || ISBNDaTra == "1")
            {
                Response.StatusCode = 500;
                Response.Write("Dịch vụ kĩ thuật này được thu tiền rồi !");
                return;

            }
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void AddStringToHTML(DataTable table, ref string html)
    {
        if (table == null || table.Rows.Count == 0) return;
        DateTime dNow = DateTime.Now;
        for (int y = 0; y < table.Columns.Count; y++)
        {
            try
            {
                if (table.Columns[y].GetType() == dNow.GetType() || table.Columns[y].ColumnName.ToLower() == "ngaykham" || table.Columns[y].ColumnName.ToLower() == "ngayhentaikham")
                {
                    html += "<data id='" + table.Columns[y].ToString() + "'>" + (table.Rows[0][y].ToString() != "" ? DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") : "") + "</data>";
                }
                else
                    html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
            }
            catch (Exception)
            {

            }
            html += Environment.NewLine;
        }
    }
    private void setTimKiem()
    {
        string IdBacSi = SysParameter.UserLogin.IdBacSi(this);
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string dk = "";
        dk = " KB.idkhambenh='" + idkhoachinh + "'";
        string sqlSelect = @"SELECT  
            IdKhoa = isnull(kb.idkhoa,3),IdChiTietDangKyKham = kb.idchitietdangkykham,
            iddangkykham=kb.iddangkykham,
            PhongID = kb.phongid,TGXuatVien=convert(nvarchar(20),TGXUATVIEN,103),idchandoan=kb.ketluan,
            DichVuKCBID = kb.DichVuKCBID,
            --ListIdThuocKhamBenhKhac=dbo.KB_ListIDTHUOC_KhamBenhKhac(kb.iddangkykham,kb.idkhambenh),
            kb.IdChuyenPK,
			kb.idbacsi,kb.trieuchung,kb.benhsu,
            kb.tiensu,
            BN.IDBENHNHAN AS idbenhnhan,
            RIGHT( CONVERT(VARCHAR(13),tgxuatvien,120),2) as gioravien,RIGHT( CONVERT(VARCHAR(16),tgxuatvien,120),2) as phutravien,
            BN.TENBENHNHAN AS tenbenhnhan,
            BN.mabenhnhan AS mabenhnhan,
            bn.diachi,
            BN.NGAYSINH AS NGAYSINH,
            ngaykham = isnull(kb.ngaykham,getdate()),
            mkv_idchandoan=cd.maicd,
            mkv_mota =isnull(kb.MoTaCD_edit,cd.mota),
            mkv_IdChuyenPK =dbo.HS_TenPhong( kb.idchuyenpk),
            mkv_idDVPhongChuyenDen =chuyenkhoa_Chuyen.TenDichVu,
            mkv_IdkhoaChuyen =Khoa_Chuyen.TenPhongKhamBenh
            ,IdkhoaChuyen
            ,idDVPhongChuyenDen
            ,IsXuatVien
            ,GIOITINH=dbo.GetGioiTinh(Bn.GioiTinh),
            bs.tenbacsi as mkv_idbacsi,
            SH.MACH ,
            SH.NHIETDO ,
            SH.HUYETAP1 ,
            SH.HUYETAP2 ,
            SH.NHIPTHO ,
            SH.CANNANG ,
            SH.CHIEUCAO,
            SH.BMI,
            IsChuyenPhongCoPhi,
            TENKHOA=K2.TENPHONGKHAMBENH,
            TENPHONG=DBO.HS_TENPHONG(KB.PHONGID),
            songayratoa=KB.songayratoa,KB.ngayhentaikham,
            loidan=KB.dando,
            KB.ischovekt,
            KB.ischuyenvien,
            KB.idbenhvienchuyen,
            KB.iskhongkham,
            KB.idbacsi2,
            mkv_idbenhvienchuyen =bv.tenbenhvien,
            mkv_idbacsi2 =bs2.tenbacsi,
            kb.IsBSMoiKham,
            kb.chandoanbandau,
            kb.idchandoantuyenduoi,
            mkv_idchandoantuyenduoi=cdtd.maicd,
            mkv_mota_idchandoantuyenduoi=isnull(kb.chandoantuyenduoi,cdtd.mota),
            loaidk=DK.LoaiKhamID,
            sobhyt=upper(BHYT.SOBHYT),
            ngaybatdau=convert(varchar(10),BHYT.NGAYBATDAU,103)+' '+convert(varchar(5),BHYT.NGAYBATDAU,108),
            ngayhethan=convert(varchar(10),BHYT.NGAYHETHAN,103)+' '+convert(varchar(5),BHYT.NGAYHETHAN,108),
            NoiDangKyKCB=KCB.TENNOIDANGKY,
            IsDungTuyen=BHYT.IsDungTuyen,
            SOVAOVIEN1=DBO.zHS_GetSoVaoVienFromKB(KB.IDKHAMBENH)
           ,NgayDangKy=convert(varchar, dk.ngaydangky, 108) +' , '+ convert(varchar, dk.ngaydangky, 103)
            ,ngaykham_gio=LEFT( convert(varchar, KB.NGAYKHAM, 108),2)
            ,ngaykham_phut=RIGHT( LEFT(convert(varchar, KB.NGAYKHAM, 108),5),2)
           ,ghichu=kb.ghichu
           ,KB.isNoiTru
           ,isNgoaiTru=( CASE WHEN ISNULL( KB.isNoiTru,0)=0 THEN 1 ELSE 0 END)
           ,SoTTChuyenP=KB.SoTTChuyenP
            ,IDBENHNHANBHDONGTIEN=DK.IDBENHBHDONGTIEN
            FROM KHAMBENH KB
            LEFT JOIN BENHNHAN BN  ON KB.IDBENHNHAN=BN.IDBENHNHAN
			left join chitietdangkykham ct on ct.idchitietdangkykham = kb.idchitietdangkykham
			left join dangkykham dk on dk.iddangkykham = ct.iddangkykham
            left join bacsi bs on bs.idbacsi = kb.idbacsi
            left join kb_phong phong_chuyen on phong_chuyen.id = kb.idchuyenpk
            left join BANGGIADICHVU ChuyenKhoa_chuyen on ChuyenKhoa_chuyen.idbanggiadichvu = phong_chuyen.DichVuKCB
            left join PHONGKHAMBENH Khoa_chuyen on Khoa_chuyen.idphongkhambenh = kb.idkhoachuyen
            left join SINHHIEU SH on SH.IDDANGKYKHAM=dk.iddangkykham
            LEFT JOIN PHONGKHAMBENH K2 ON KB.IDKHOA=K2.IDPHONGKHAMBENH
            LEFT JOIN KB_PHONG P2 ON KB.PHONGID=P2.ID
            LEFT JOIN BENHNHAN_BHYT BHYT ON DK.IDBENHNHAN_BH=BHYT.IDBENHNHAN_BH
            LEFT JOIN KB_NOIDANGKYKB KCB ON BHYT.IDNOIDANGKYBH=KCB.IDNOIDANGKY
            left join benhvien bv on bv.idbenhvien = kb.idbenhvienchuyen
            left join chandoanicd cd on cd.idicd=kb.ketluan
            left join chandoanicd cdtd on cdtd.idicd=kb.idchandoantuyenduoi
            left join bacsi bs2 on kb.idbacsi2=bs2.idbacsi
            WHERE " + dk;
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<root>";
        if (!string.IsNullOrEmpty(idkhoachinh))
            html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
        html += Environment.NewLine;
        this.AddStringToHTML(table, ref html);
        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    private void setTimKiem_KhamMoi()
    {
        string IdBacSi = SysParameter.UserLogin.IdBacSi(this);
        string NgayKham = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string GioKham = DateTime.Now.ToString("HH");
        string PhutKham = DateTime.Now.ToString("mm");

        string idchitietdangkykham = Request.QueryString["idchitietdangkykham"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string dk = "";
        dk = " ct.idchitietdangkykham='" + idchitietdangkykham + "'";
        string sqlSelect = @"SELECT top 1 
			IdChiTietDangKyKham = ct.idchitietdangkykham,
            iddangkykham=ct.iddangkykham,
            PhongID = ct.phongid,IdKhoa = b.idphongkhambenh,
            DichVuKCBID = a.DichVuKCB,
            --ListIdThuocKhamBenhKhac=dbo.KB_ListIDTHUOC_KhamBenhKhac(dk.iddangkykham,null),
            BN.IDBENHNHAN AS idbenhnhan,
            BN.TENBENHNHAN AS tenbenhnhan,
            BN.mabenhnhan AS mabenhnhan,
            bn.diachi,
            BN.NGAYSINH AS NGAYSINH,
            loaidk = dk.LoaiKhamID,
            idbacsi = '" + IdBacSi + @"',
            mkv_idbacsi = (select tenbacsi from bacsi where idbacsi='" + IdBacSi + @"'),
            ngaykham = '" + NgayKham + @"',
            GIOITINH=dbo.GetGioiTinh(bn.GioiTinh),
            SH.MACH ,
            SH.NHIETDO ,
            SH.HUYETAP1 ,
            SH.HUYETAP2 ,
            SH.NHIPTHO ,
            SH.CANNANG ,
            SH.CHIEUCAO,
            SH.BMI,
            TENKHOA=c.tenphongkhambenh,
            TENPHONG=dbo.hs_tenphong(ct.phongid),
            sobhyt=upper(BHYT.SOBHYT),
            ngaybatdau=BHYT.NGAYBATDAU,
            ngayhethan=BHYT.NGAYHETHAN,
            NoiDangKyKCB=KCB.TENNOIDANGKY,
            IsDungTuyen=BHYT.IsDungTuyen
            ,NgayDangKy=convert(varchar, dk.ngaydangky, 108) +' , '+ convert(varchar, dk.ngaydangky, 103)
            ,ngaykham_gio='" + GioKham + @"'
            ,ngaykham_phut='" + PhutKham + @"'
            ,IDBENHNHANBHDONGTIEN=DK.IDBENHBHDONGTIEN
            FROM 
			chitietdangkykham ct
			left join dangkykham dk on ct.iddangkykham = dk.iddangkykham 
			left join BENHNHAN BN  on dk.idbenhnhan = bn.idbenhnhan
			left join kb_phong a on a.id = ct.phongid
			left join banggiadichvu b on a.dichvukcb = b.idbanggiadichvu
			left join phongkhambenh c on c.idphongkhambenh = b.idphongkhambenh
            left join SINHHIEU SH on SH.IDDANGKYKHAM=dk.iddangkykham
             LEFT JOIN BENHNHAN_BHYT BHYT ON DK.IDBENHNHAN_BH=BHYT.IDBENHNHAN_BH
            LEFT JOIN KB_NOIDANGKYKB KCB ON BHYT.IDNOIDANGKYBH=KCB.IDNOIDANGKY
            WHERE bn.idbenhnhan = '" + idbenhnhan + "' and " + dk;
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<root>";
        html += Environment.NewLine;
        this.AddStringToHTML(table, ref html);
        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    private void setTimKiem_KhamMoiChuyenPhong()
    {
        string IdBacSi = SysParameter.UserLogin.IdBacSi(this);
        string NgayKham = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string GioKham = DateTime.Now.ToString("HH");
        string PhutKham = DateTime.Now.ToString("mm");

        string idkhambenhchuyenphong = Request.QueryString["idkhambenhchuyenphong"];
        string sqlSelect = @"SELECT top 1 
            IdChiTietDangKyKham =ISNULL(G.IDCHITIETDANGKYKHAM,CT.IDCHITIETDANGKYKHAM),
            iddangkykham=dk.iddangkykham,
            PhongID = a.id,
            IdKhoa = K2.idphongkhambenh,
            DichVuKCBID = a.DichVuKCB,
            --ListIdThuocKhamBenhKhac=dbo.KB_ListIDTHUOC_KhamBenhKhac(dk.iddangkykham,null),
            BN.IDBENHNHAN AS idbenhnhan,
            BN.TENBENHNHAN AS tenbenhnhan,
            BN.mabenhnhan AS mabenhnhan,
            bn.diachi,
            BN.NGAYSINH AS NGAYSINH,
            loaidk = dk.LoaiKhamID,
            ngaykham = '" + NgayKham + @"',
            idbacsi = '" + IdBacSi + @"',
            mkv_idbacsi = (select tenbacsi from bacsi where idbacsi='" + IdBacSi + @"'),
            GIOITINH=dbo.GetGioiTinh(bn.GioiTinh),
            SH.MACH ,
            SH.NHIETDO ,
            SH.HUYETAP1 ,
            SH.HUYETAP2 ,
            SH.NHIPTHO ,
            SH.CANNANG ,
            SH.CHIEUCAO,
            SH.BMI,
            TENKHOA=K2.TENPHONGKHAMBENH,
            TENPHONG=DBO.HS_TENPHONG(KB.IdChuyenPK),
            KB.IDKHAMBENH,
            ischovekt=0,
            ischuyenvien=0,
            idbenhvienchuyen=NULL,
            iskhongkham=0,
            KB.idbacsi,
            mkv_idbenhvienchuyen = NULL,
            mkv_idbacsi =bs.tenbacsi,
            kb.ketluan,
            idchandoan=kb.ketluan,
            mkv_idchandoan=cd.maicd,
            mkv_mota =isnull(kb.MoTaCD_edit,cd.mota),
            kb.chandoanbandau,    
            kb.idchandoantuyenduoi,
            mkv_idchandoantuyenduoi=cdtd.maicd,
            mkv_mota_idchandoantuyenduoi=isnull(kb.chandoantuyenduoi,cdtd.mota),
            sobhyt=upper(BHYT.SOBHYT),
            ngaybatdau=BHYT.NGAYBATDAU,
            ngayhethan=BHYT.NGAYHETHAN,
            NoiDangKyKCB=KCB.TENNOIDANGKY,
            IsDungTuyen=BHYT.IsDungTuyen,
            SOVAOVIEN1=DBO.zHS_GetSoVaoVienFromKB(KB.IDKHAMBENH)
            ,NgayDangKy=convert(varchar, dk.ngaydangky, 108) +' , '+ convert(varchar, dk.ngaydangky, 103)
            ,ngaykham_gio='" + GioKham + @"'
            ,ngaykham_phut='" + PhutKham + @"'
           ,KB.isNoiTru
           ,isNgoaiTru=( CASE WHEN ISNULL( KB.isNoiTru,0)=0 THEN 1 ELSE 0 END)
            ,IDBENHNHANBHDONGTIEN=DK.IDBENHBHDONGTIEN
            FROM KHAMBENH KB
			LEFT JOIN chitietdangkykham ct ON KB.idchitietdangkykham=ct.idchitietdangkykham
			left join dangkykham dk on ct.iddangkykham = dk.iddangkykham
			left join BENHNHAN BN  on KB.idbenhnhan=bn.idbenhnhan
			left join kb_phong a on a.id = kb.idchuyenpk
			left join banggiadichvu b on ct.idbanggiadichvu = b.idbanggiadichvu
			left join phongkhambenh c on c.idphongkhambenh = b.idphongkhambenh
            left join SINHHIEU SH on SH.IDDANGKYKHAM=dk.iddangkykham
            LEFT JOIN KB_PHONG P2 ON KB.IdChuyenPK=P2.ID
            LEFT JOIN PHONGKHAMBENH K2 ON KB.IdkhoaChuyen=K2.IDPHONGKHAMBENH
            LEFT JOIN DANGKYKHAM F ON KB.IDKHAMBENH=F.IDKHAMBENH_CHUYEN
            LEFT JOIN CHITIETDANGKYKHAM G ON F.IDDANGKYKHAM=G.IDDANGKYKHAM
            LEFT JOIN BENHNHAN_BHYT BHYT ON DK.IDBENHNHAN_BH=BHYT.IDBENHNHAN_BH
            LEFT JOIN KB_NOIDANGKYKB KCB ON BHYT.IDNOIDANGKYBH=KCB.IDNOIDANGKY
            left join bacsi bs on kb.idbacsi=bs.idbacsi
            left join chandoanicd cd on kb.ketluan=cd.idicd
            left join chandoanicd cdtd on kb.idchandoantuyenduoi=cdtd.idicd
            WHERE kb.idkhambenh = '" + idkhambenhchuyenphong + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<root>";
        html += Environment.NewLine;
        this.AddStringToHTML(table, ref html);
        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }
    private void Savekhambenh()
    {
        try
        {
            DataProcess process = s_khambenh();
            #region Set IdDangKyKham,IdChiTietDangKyKham
            string iddangkykham = process.getData("iddangkykham");
            string idchitietdangkykham = process.getData("idchitietdangkykham");
            if (idchitietdangkykham == null || idchitietdangkykham == "")
            {
                idchitietdangkykham = Request.QueryString["idchitietdangkykham"];
                process.data("idchitietdangkykham", idchitietdangkykham);
            }
            if (idchitietdangkykham == null || idchitietdangkykham == "") return;
            if (iddangkykham == null || iddangkykham == "")
            {
                string sqlSelectDKK = "SELECT IDDANGKYKHAM FROM CHITIETDANGKYKHAM WHERE IDCHITIETDANGKYKHAM=" + idchitietdangkykham;
                DataTable dtDKK = DataAcess.Connect.GetTable(sqlSelectDKK);
                if (dtDKK != null && dtDKK.Rows.Count > 0)
                {
                    iddangkykham = dtDKK.Rows[0][0].ToString();
                    process.data("iddangkykham", iddangkykham);
                }
            }
            #endregion
            string UserID = SysParameter.UserLogin.UserID(this);
            if (Request.QueryString["tgxuatvien"] == null || Request.QueryString["tgxuatvien"].ToString() == "")
            {
                if (Request.QueryString["IdChuyenPK"] != null && Request.QueryString["IdChuyenPK"].ToString() != "")
                {
                    Response.Write("Thời gian Ra viện/chuyển khoa chưa chọn.");
                    Response.StatusCode = 500;
                    return;
                }
            }

            #region Add Extra Parameter
            process.data("MAPHIEUKHAM", process.getData("MAPHIEUKHAM"));
            process.data("IDPHONGKHAMBENH", process.getData("IdKhoa"));
            process.data("NGAYKHAM", process.getData("ngaykham"));
            process.data("IdPhong", process.getData("PhongID"));
            process.data("idPhongChuyenDen", process.getData("IdChuyenPK"));
            process.data("phongkhamchuyenden", process.getData("IdkhoaChuyen"));
            #endregion
            if (Request.QueryString["tgxuatvien"] != null)
            {
                string NgayXuatVien = Request.QueryString["tgxuatvien"].ToString();
                process.data("TGXUATVIEN", NgayXuatVien + " " + Request.QueryString["gioravien"] + ":" + Request.QueryString["phutravien"] + ":00");
            }
            if (Request.QueryString["idkhambenhchuyenphong"] != null && Request.QueryString["idkhambenhchuyenphong"].ToString() != "")
            {
                process.data("idkhambenhgoc", Request.QueryString["idkhambenhchuyenphong"]);

            }
            if (process.getData("idkhambenh") != null && process.getData("idkhambenh") != "")
            {

                #region Kiểm tra xem có phải từ trường hợp chuyển phòng thu phí ,sang hướng điều trị khác không hoặc chuyển sang phòng khách hay ko?
                string idchuyenpk = process.getData("IdChuyenPK");
                string IsChuyenPhongCoPhi = process.getData("IsChuyenPhongCoPhi");

                string sqlCTDKK_Chuyen = @"SELECT TOP 1 A.* FROM CHITIETDANGKYKHAM A
                                               LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                            WHERE B.IDKHAMBENH_CHUYEN=" + process.getData("idkhambenh");
                DataTable dtCTDKK_Chuyen = DataAcess.Connect.GetTable(sqlCTDKK_Chuyen);

                if (idchuyenpk == null
                    || idchuyenpk == ""
                    || idchuyenpk == "0"
                    || StaticData.IsCheck(IsChuyenPhongCoPhi) == false
                    || (dtCTDKK_Chuyen != null && dtCTDKK_Chuyen.Rows.Count > 0 && dtCTDKK_Chuyen.Rows[0]["PhongID"].ToString() != idchuyenpk)
                    )
                {

                    if (dtCTDKK_Chuyen != null && dtCTDKK_Chuyen.Rows.Count > 0)
                    {
                        string IsDaThu = dtCTDKK_Chuyen.Rows[0]["IsDathu"].ToString();
                        string IsBNDaTra = dtCTDKK_Chuyen.Rows[0]["IsBNDaTra"].ToString();
                        if (StaticData.IsCheck(IsDaThu) || StaticData.IsCheck(IsBNDaTra))
                        {

                            Response.Write("Đã thu phí chuyển phòng rồi, chỉ có thể hướng điều trị khi huỷ phiếu thu tương ứng");
                            Response.StatusCode = 500;
                            return;
                        }

                        if (idchuyenpk == null
                            || idchuyenpk == ""
                            || idchuyenpk == "0"
                            || StaticData.IsCheck(IsChuyenPhongCoPhi) == false
                            )
                        {
                            string sqlDeleteCTDKK_chuyen = "delete dangkykham where iddangkykham=" + dtCTDKK_Chuyen.Rows[0]["IdDangKyKham"].ToString() + "\r\n"
                                                          + " delete chitietdangkykham where iddangkykham=" + dtCTDKK_Chuyen.Rows[0]["IdDangKyKham"].ToString() + "";
                            bool delete_CTDKK_Chuyen = DataAcess.Connect.ExecSQL(sqlDeleteCTDKK_chuyen);
                            if (!delete_CTDKK_Chuyen)
                            {
                                Response.Write("Không thể huỷ đăng ký khám tự động được, liên hệ Admin");
                                Response.StatusCode = 500;
                                return;
                            }
                        }
                    }

                }
                #endregion
                // Nếu idchuyenpk != phòng chuyển hiện tại nhưng đã khám thì ko được chuyển phòng
                DataTable khambenhchuyenphong = DataAcess.Connect.GetTable("select top 1 idkhambenhchuyenphong,idchuyenpk from KHAMBENH where idkhambenh=" + Request.QueryString["idkhoachinh"] + "");
                DataTable ktracphongdakham = DataAcess.Connect.GetTable("select top 1 idkhambenh from KHAMBENH where idkhambenh='" + (khambenhchuyenphong.Rows.Count > 0 ? khambenhchuyenphong.Rows[0][0] : "") + "'");
                if (ktracphongdakham.Rows.Count > 0)
                {
                    if (khambenhchuyenphong.Rows[0][1].ToString().Trim() != "" && khambenhchuyenphong.Rows[0][1].ToString() != Request.QueryString["IdChuyenPK"])
                    {
                        Response.Write("Không thể chuyển phòng,Phòng chuyển đã khám.");
                        Response.StatusCode = 500;
                        return;
                    }
                }

                string IdkhoaChuyen = Request.QueryString["IdkhoaChuyen"];
                string IdChuyenPK = process.getData("IdChuyenPK");
                process.data("IdkhoaChuyen", (IdkhoaChuyen == null ? "0" : IdkhoaChuyen));
                process.data("IdChuyenPK", (IdChuyenPK == null ? "0" : IdChuyenPK));
                if (IdkhoaChuyen == null || IdkhoaChuyen == "" || IdkhoaChuyen == "0")
                    process.data("SoTTChuyenP", "");
                // Cập nhật idkhambenhgoc cho phiếu khám bệnh gốc đã chuyển phòng
                process.data("IdDieuDuong2", UserID);
                bool ok = process.Update();
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
            }
            else
            {

                process.data("IdDieuDuong", UserID);
                process.data("maphieukham", "");
                bool ok = process.Insert();
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
                if (Request.QueryString["idkhambenhchuyenphong"] != null && Request.QueryString["idkhambenhchuyenphong"].ToString() != "")
                {
                    DataProcess khambenhcp = new DataProcess("KHAMBENH");
                    khambenhcp.data("idkhambenh", Request.QueryString["idkhambenhchuyenphong"]);
                    khambenhcp.data("idkhambenhchuyenphong", process.getData("idkhambenh"));
                    khambenhcp.data("idkhambenhmoi", process.getData("idkhambenh"));
                    khambenhcp.Update();
                }

            }
            #region Lưu bác sĩ vào User người dùng
            string idBacSiDieuDuong = SysParameter.UserLogin.IdBacSi(this);
            //if (idBacSiDieuDuong == null || idBacSiDieuDuong == "" || idBacSiDieuDuong == "0")
            {

                string UserName = SysParameter.UserLogin.UserName(this);
                string FullName = SysParameter.UserLogin.FullName(this);
                string Rol = SysParameter.UserLogin.GroupID(this);
                string IdBacSi_Current = process.getData("idbacsi");
                SysParameter.UserLogin.SaveUserLogin(this, UserName, UserID, FullName, Rol, IdBacSi_Current);
            }
            #endregion
            #region luu sinh hieu
            DataProcess sinhieu = this.s_sinhhieu();
            string idSinhHieu = null;
            string sqlSelectSinhHieu = "SELECT TOP 1 IDSINHHIEU FROM SINHHIEU WHERE IDKHAMBENH=" + process.getData("idkhambenh");
            DataTable dtSH = DataAcess.Connect.GetTable(sqlSelectSinhHieu);
            if (dtSH != null && dtSH.Rows.Count > 0)
                idSinhHieu = dtSH.Rows[0][0].ToString();
            if ((sinhieu.getData("MACH") != null && sinhieu.getData("MACH") != "") || (sinhieu.getData("HUYETAP1") != null && sinhieu.getData("HUYETAP1") != ""))
            {
                if (idSinhHieu == null || idSinhHieu == "")
                {
                    sinhieu.data("Iddangkykham", iddangkykham);
                    sinhieu.data("idchitietdangkykham", idchitietdangkykham);
                    sinhieu.data("idkhambenh", process.getData("idkhambenh"));
                    sinhieu.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
                    sinhieu.data("ngaydo", process.getData("ngaykham"));
                    sinhieu.data("idkhoasinhhieu", process.getData("idkhoa"));
                    bool Insert_SH = sinhieu.Insert();
                }
                else
                {
                    sinhieu.data("idsinhhieu", idSinhHieu);
                    bool Update_SH = sinhieu.Update();
                }
            }
            #endregion
            Response.Clear(); Response.Write(process.getData("idkhambenh"));
            return;
        }
        catch
        {
            Response.StatusCode = 500;
        }
    }
    public void LuuTablechitietbenhnhantoathuoc()
    {
        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            #region Properties
            string idthuoc = Request.QueryString["idthuoc"];
            string tenthuoc = Request.QueryString["mkv_idthuoc"];
            string iddvt = Request.QueryString["iddvt"];
            string dvt = (Request.QueryString["mkv_iddvt"] == null ? "" : Request.QueryString["mkv_iddvt"]);
            string idcachdung = Request.QueryString["idcachdung"];
            string cachdung = (Request.QueryString["mkv_idcachdung"] == null ? "" : Request.QueryString["mkv_idcachdung"]);
            string congthuc = (Request.QueryString["mkv_congthuc"] == null ? "" : Request.QueryString["mkv_congthuc"]);
            string dvdung = (Request.QueryString["mkv_iddvdung"] == null ? "" : Request.QueryString["mkv_iddvdung"]);
            string loaithuocid = Request.QueryString["DoiTuongThuocID"];
            string loaithuoc = (Request.QueryString["mkv_DoiTuongThuocID"] == null ? "" : Request.QueryString["mkv_DoiTuongThuocID"]);
            #endregion
            #region Check IDThuoc
            string Message = null;
            string IdThuoc_Save = null;
            bool OK_CheckThuoc = StaticData.AutoCheckSaveThuoc(idthuoc, tenthuoc, iddvt, dvt, idcachdung, cachdung
                                                                , congthuc, dvdung, loaithuocid, loaithuoc
                                                                , ref Message, ref IdThuoc_Save);
            if (!OK_CheckThuoc || idthuoc == null || idthuoc == "" || idthuoc == "0")
            {
                Response.StatusCode = 500;
                Response.Write(Message);
                return;
            }
            if (idthuoc != IdThuoc_Save)
            {
                process.data("idthuoc", IdThuoc_Save);
            }
            #endregion
            string idkhambenh = process.getData("idkhambenh");
            string sqlKhamBenh = "SELECT * FROM KHAMBENH WHERE IDKHAMBENH=" + idkhambenh;
            DataTable dtKhamBenh = DataAcess.Connect.GetTable(sqlKhamBenh);
            string TGXuatVien = dtKhamBenh.Rows[0]["TGXuatVien"].ToString();
            TGXuatVien = DateTime.Parse(TGXuatVien).ToString("dd/MM/yyyy hh:mm:ss");
            DataProcess benhnhantoathuoc = new DataProcess("benhnhantoathuoc");
            benhnhantoathuoc.data("idkhambenh", process.getData("idkhambenh"));
            benhnhantoathuoc.data("ngayratoa", TGXuatVien);
            benhnhantoathuoc.data("idbenhnhan", dtKhamBenh.Rows[0]["idbenhnhan"].ToString());
            benhnhantoathuoc.data("idbacsi", dtKhamBenh.Rows[0]["idbacsi"].ToString());
            string idbenhnhantoathuoc = null;
            DataTable dtBNTT = DataAcess.Connect.GetTable("SELECT IDBENHNHANTOATHUOC FROM BENHNHANTOATHUOC WHERE IDKHAMBENH=" + process.getData("idkhambenh"));
            if (dtBNTT != null && dtBNTT.Rows.Count > 0)
                idbenhnhantoathuoc = dtBNTT.Rows[0][0].ToString();
            benhnhantoathuoc.data("idbenhnhantoathuoc", idbenhnhantoathuoc);

            if (idbenhnhantoathuoc == null || idbenhnhantoathuoc == "")
            {
                bool InsertBNTT = benhnhantoathuoc.Insert();
                if (InsertBNTT == true)
                {
                    idbenhnhantoathuoc = benhnhantoathuoc.getData("idbenhnhantoathuoc");
                    process.data("idbenhnhantoathuoc", idbenhnhantoathuoc);
                }
            }
            else
            {
                benhnhantoathuoc.data("ngayratoa", DateTime.Now.ToString("dd/MM/yyyy"));
                benhnhantoathuoc.Update();
                process.data("idbenhnhantoathuoc", idbenhnhantoathuoc);
            }
            if (process.getData("idchitietbenhnhantoathuoc") != null && process.getData("idchitietbenhnhantoathuoc") != "")
            {

                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {

                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablekhambenhcanlamsan()
    {
        try
        {


            string sysdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            DataProcess process = s_khambenhcanlamsan();
            string ngaythu = process.getData("ngaythu");
            string idkhambenhcanlamsan = process.getData("idkhambenhcanlamsan");

            if (process.getData("idcanlamsan") != null && process.getData("idcanlamsan") != "" && process.getData("idcanlamsan") != "0")
            {
                if (idkhambenhcanlamsan == null || idkhambenhcanlamsan == "")
                {


                    if (ngaythu == null || ngaythu == "")
                    {
                        ngaythu = sysdate;
                        process.data("ngaythu", sysdate);
                    }
                    string maphieucls = process.getData("maphieucls");
                    if (maphieucls == null || maphieucls == "")
                    {
                        string IdKhamBenh = process.getData("idkhambenh");
                        if (IdKhamBenh != null && IdKhamBenh != "")
                        {
                            string sqlPrev = "SELECT TOP 1 MAPHIEUCLS,IDDANGKYCLS FROM KHAMBENHCANLAMSAN WHERE IDKHAMBENH=" + IdKhamBenh + " AND  DATHU=0 ORDER BY IDKHAMBENHCANLAMSAN DESC";
                            DataTable dtPrev = DataAcess.Connect.GetTable(sqlPrev);
                            if (dtPrev != null && dtPrev.Rows.Count > 0)
                            {
                                maphieucls = dtPrev.Rows[0][0].ToString();
                                string iddangkycls_old = dtPrev.Rows[0][1].ToString(); ;
                                process.data("IDDANGKYCLS", iddangkycls_old);
                            }
                        }
                        if (maphieucls == null || maphieucls == "")
                        {
                            maphieucls = StaticData_HS.MaPhieuCLS_new();
                            string iddangkycls = "";
                            string idbacsi = Request.QueryString["idbacsi"];
                            string idbenhnhan = Request.QueryString["idbenhnhan"];
                            string sqlExecute = "INSERT INTO HS_DANGKYCLS(MAPHIEUCLS,NGAYDK,NGUOIDK,IDBENHNHAN) VALUES('" + maphieucls + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + idbacsi + "','" + idbenhnhan + "')";
                            bool OK_iddangkycls = DataAcess.Connect.ExecSQL(sqlExecute);
                            if (OK_iddangkycls)
                            {
                                sqlExecute = @"SELECT TOP 1 * FROM HS_DANGKYCLS WHERE IDBENHNHAN=" + idbenhnhan + " AND  MAPHIEUCLS='" + maphieucls + "' ORDER BY NGAYDK DESC";
                                DataTable dtcheck = DataAcess.Connect.GetTable(sqlExecute);
                                if (dtcheck != null && dtcheck.Rows.Count > 0)
                                {
                                    iddangkycls = dtcheck.Rows[0]["IDDANGKYCLS"].ToString();
                                    process.data("IDDANGKYCLS", iddangkycls);
                                }
                            }
                        }
                        process.data("maphieucls", maphieucls);
                    }
                }
                if (process.getData("idkhambenhcanlamsan") != "")
                {
                    bool ok = process.Update();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                        return;
                    }
                }
                else
                {
                    process.data("dathu", "0");
                    string NgayCDBS = Request.QueryString["NgayCDBS"];
                    string GioCDBS = Request.QueryString["GioCDBS"];
                    string PhutCDBS = Request.QueryString["PhutCDBS"];
                    if (NgayCDBS != null && NgayCDBS != "")
                        ngaythu = NgayCDBS + " " + GioCDBS + ":" + PhutCDBS;

                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                        return;
                    }
                }

            }

        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void luuTongTienKham()
    {
        string idkhambenh = Request.QueryString["idkhambenh"].ToString();
        bool IsChoVeKT = false;
        bool IsChuyenVien = false;
        bool iskhongkham = false;
        bool IsTieuPhauRoiVe = false;
        DataTable dtKhamBenh = DataAcess.Connect.GetTable(@"SELECT A.IsChoVeKT,A.IsChuyenVien,A.IdBenhVienChuyen,A.iskhongkham, A.IsTieuPhauRoiVe
                                                                ,A.IDKHOA,B.LoaiKhamID
                                                                FROM KHAMBENH A 
                                                                INNER JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                                            WHERE A.IDKHAMBENH=" + idkhambenh);
        if (dtKhamBenh != null && dtKhamBenh.Rows.Count > 0)
        {
            IsChoVeKT = StaticData.IsCheck(dtKhamBenh.Rows[0]["IsChoVeKT"].ToString());
            IsChuyenVien = StaticData.IsCheck(dtKhamBenh.Rows[0]["IsChuyenVien"].ToString());
            iskhongkham = StaticData.IsCheck(dtKhamBenh.Rows[0]["iskhongkham"].ToString());
            IsTieuPhauRoiVe = StaticData.IsCheck(dtKhamBenh.Rows[0]["IsTieuPhauRoiVe"].ToString());
        }
        #region IsHaveCLS

        string IsHaveCLS = "0";
        string sqlSelectCLS = @"Select top 1 IDKHAMBENH FROM KHAMBENHCANLAMSAN WHERE IDKHAMBENH=" + idkhambenh;
        DataTable dtCLS = DataAcess.Connect.GetTable(sqlSelectCLS);
        if (dtCLS != null && dtCLS.Rows.Count > 0)
        {
            IsHaveCLS = "1";
            bool ok_IsHaveCLS = DataAcess.Connect.ExecSQL("UPDATE KHAMBENH SET IsHaveCLS=" + IsHaveCLS + " WHERE IDKHAMBENH=" + idkhambenh);
        }
        #endregion
        #region IsTaiKham
        try
        {
            string sqlUpdateTaiKham = @"update khambenh set IsTaiKham=1
                                            where idkhambenh=" + idkhambenh + @"
                                                  and   exists (select top 1 idkhambenh
                                                            from khambenh a 
                                                            left join kb_phong b on a.phongid=b.id
                                                            where a.idkhambenh<khambenh.idkhambenh
                                                            and a.idbenhnhan=khambenh.idbenhnhan
                                                            and b.dichvukcb=( select dichvukcb from kb_phong where id=khambenh.phongid )  
                            
                                                            )";
            bool ok_UpdateIsTaiKham = DataAcess.Connect.ExecSQL(sqlUpdateTaiKham);
        }
        catch
        {
        }


        #endregion
        #region Hướng điều trị
        string LoaiKhamID = "2";
        string IdBenhNhan_BH = "NULL";
        string sqlSelect = @"select A.* ,
                                    B.LoaiKhamID,
                                    B.IDBENHNHAN_BH,SoTTChuyenP
                               from khambenh A
                               LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                            where idkhambenh=" + idkhambenh;

        DataTable dtKhambenh = DataAcess.Connect.GetTable(sqlSelect);
        if (dtKhambenh == null || dtKhambenh.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("");

        }
        LoaiKhamID = dtKhambenh.Rows[0]["LoaiKhamID"].ToString();
        IdBenhNhan_BH = dtKhambenh.Rows[0]["IDBENHNHAN_BH"].ToString();
        if (LoaiKhamID == "") LoaiKhamID = "2";
        if (IdBenhNhan_BH == "") IdBenhNhan_BH = "NULL";

        string huongdieutri = "5";
        string IdkhoaChuyen = dtKhambenh.Rows[0]["IdkhoaChuyen"].ToString();
        string IsChuyenPhongCoPhi = dtKhambenh.Rows[0]["IsChuyenPhongCoPhi"].ToString();
        #region Chuyển phòng
        string SoThuTuChuyenPhong = "";
        if (IdkhoaChuyen != null && IdkhoaChuyen != "" && IdkhoaChuyen != "0")
        {
            string IdChuyenPK = Request.QueryString["IdChuyenPK"];
            DataTable dtKhoaChuyen = DataAcess.Connect.GetTable("SELECT * FROM PHONGKHAMBENH WHERE IDPHONGKHAMBENH=" + IdkhoaChuyen);
            if (dtKhoaChuyen != null && dtKhoaChuyen.Rows.Count > 0 && StaticData.IsCheck(dtKhoaChuyen.Rows[0]["IsNoiTru"].ToString()))
            {
                huongdieutri = "8";
            }
            else
            {
                if (IdChuyenPK != null && IdChuyenPK != "" && IdChuyenPK != "0")
                {
                    if (IsChuyenPhongCoPhi.ToLower() == "true" || IsChuyenPhongCoPhi == "1")
                    {
                        huongdieutri = "7";
                        #region Lưu đăng ký khám, trường hợp yêu cầu chuyển phòng thu phí

                        string idbenhnhan = dtKhambenh.Rows[0]["IdBenhNhan"].ToString();
                        string NgayDangKy = dtKhambenh.Rows[0]["TGXuatVien"].ToString();
                        string PhongID_Chuyen = IdChuyenPK;
                        string sqlSelectChuyenKhoa = "SELECT TOP 1 * FROM KB_PHONG WHERE ID=" + PhongID_Chuyen;
                        DataTable dtChuyenKhoa = DataAcess.Connect.GetTable(sqlSelectChuyenKhoa);
                        if (dtChuyenKhoa == null || dtChuyenKhoa.Rows.Count == 0)
                        {
                            Response.Clear();
                            Response.Write("Chưa chọn phòng cần chuyển, sao tính được tiền");
                            Response.StatusCode = 500;
                            return;
                        }
                        string DichVuKCB = dtChuyenKhoa.Rows[0]["DichVuKCB"].ToString();

                        string sqlSelectDKK = "SELECT TOP 1 * FROM DANGKYKHAM WHERE IDKHAMBENH_CHUYEN=" + idkhambenh;
                        DataTable dtDKK = DataAcess.Connect.GetTable(sqlSelectDKK);
                        if (dtDKK == null)
                        {
                            Response.Clear();
                            Response.Write("Không thể kiểm tra đăng ký khám chuyển, liên hệ với Admin");
                            Response.StatusCode = 500;
                            return;
                        }
                        string sqlSaveDKK = null;
                        string sqlSaveCTDKK = null;
                        string IdDangKyKham_Chuyen = null;
                        if (dtDKK.Rows.Count == 0)
                        {
                            sqlSaveDKK = @"INSERT INTO DANGKYKHAM(idbenhnhan,NgayDangKy,IDKHAMBENH_CHUYEN,LoaiKhamID,IDBENHNHAN_BH)
                                              VALUES(" + idbenhnhan + ",'" + NgayDangKy + "'," + idkhambenh + "," + LoaiKhamID + "," + IdBenhNhan_BH + ")";
                            bool Ok_SaveDKK = DataAcess.Connect.ExecSQL(sqlSaveDKK);
                            if (!Ok_SaveDKK)
                            {
                                Response.Clear();
                                Response.Write("Không lưu đăng ký khám tự động, liên hệ với Admin");
                                Response.StatusCode = 500;
                                return;
                            }
                            dtDKK = DataAcess.Connect.GetTable(sqlSelectDKK);
                            IdDangKyKham_Chuyen = dtDKK.Rows[0][0].ToString();
                            string SoTT_DKK = StaticData_HS.GetSoThuTuDangKyKhamMoi(PhongID_Chuyen, NgayDangKy, true);
                            SoThuTuChuyenPhong = SoTT_DKK;
                            sqlSaveCTDKK = @"INSERT INTO CHITIETDANGKYKHAM(IDDANGKYKHAM,IDBANGGIADICHVU,PHONGID,SOTT,SOLUONG)
                                        VALUES (" + IdDangKyKham_Chuyen + "," + DichVuKCB + "," + PhongID_Chuyen + ",'" + SoTT_DKK + "',1)";
                            bool Insert_CTDKK = DataAcess.Connect.ExecSQL(sqlSaveCTDKK);
                            if (!Insert_CTDKK)
                            {
                                Response.Clear();
                                Response.Write("Không lưu chi tiết đăng ký khám tự động, liên hệ với Admin");
                                Response.StatusCode = 500;
                                return;
                            }
                            else
                            {
                                StaticData.TinhLaiTien_ByIdDangKyKham(IdDangKyKham_Chuyen);
                            }

                        }
                        else
                        {
                            IdDangKyKham_Chuyen = dtDKK.Rows[0][0].ToString();
                            string sqlSelectCTDKK = "SELECT TOP 1 * FROM CHITIETDANGKYKHAM WHERE IDDANGKYKHAM=" + IdDangKyKham_Chuyen;
                            DataTable dtCTDKK = DataAcess.Connect.GetTable(sqlSelectCTDKK);
                            if (dtCTDKK == null || dtCTDKK.Rows.Count == 0)
                            {
                                Response.Clear();
                                Response.Write("Không thể kiểm tra chi tiết đăng ký khám tự động, liên hệ với Admin");
                                Response.StatusCode = 500;
                                return;
                            }
                            string PhongID_Old = dtCTDKK.Rows[0]["PhongID"].ToString();
                            if (PhongID_Old != PhongID_Chuyen)
                            {
                                string IsDathu = dtCTDKK.Rows[0]["IsDaThu"].ToString();
                                string IsBNDaTra = dtCTDKK.Rows[0]["IsBNDaTra"].ToString();
                                if (StaticData.IsCheck(IsDathu) || StaticData.IsCheck(IsBNDaTra))
                                {
                                    Response.Clear();
                                    Response.Write("Đã thu phí chuyển phòng rồi,chỉ đổi phòng khác sau khi huỷ phiếu thu tương ứng");
                                    Response.StatusCode = 500;
                                    return;
                                }
                                string IdChiTietDangKyKham_chuyen = dtCTDKK.Rows[0][0].ToString();
                                string SoTT_DKK = StaticData_HS.GetSoThuTuDangKyKhamMoi(PhongID_Chuyen, NgayDangKy, true);
                                sqlSaveCTDKK = "UPDATE CHITIETDANGKYKHAM SET PHONGID=" + PhongID_Chuyen
                                                + " , IDBANGGIADICHVU=" + DichVuKCB
                                                + ", SOTT= '" + SoTT_DKK + "'"
                                                + " WHERE IDCHITIETDANGKYKHAM=" + IdChiTietDangKyKham_chuyen;
                                bool Update_CTDKK = DataAcess.Connect.ExecSQL(sqlSaveCTDKK);
                                if (!Update_CTDKK)
                                {
                                    Response.Clear();
                                    Response.Write("Không thể đổi phòng khác được");
                                    Response.StatusCode = 500;
                                    return;
                                }
                                else
                                {
                                    StaticData.TinhLaiTien_ByIdDangKyKham(IdDangKyKham_Chuyen);
                                }

                            }
                        }
                        #endregion
                    }

                    else
                    {
                        huongdieutri = "1";
                        string NgayKham = dtKhambenh.Rows[0]["NgayKham"].ToString();
                        string SoTTChuyenP_save = dtKhambenh.Rows[0]["SoTTChuyenP"].ToString();

                        if (SoTTChuyenP_save != null && SoTTChuyenP_save != "" && IdChuyenPK == dtKhambenh.Rows[0]["IdChuyenPK"].ToString())
                            SoThuTuChuyenPhong = SoTTChuyenP_save;
                        else
                        {
                            SoThuTuChuyenPhong = StaticData_HS.GetSoThuTuDangKyKhamMoi(IdChuyenPK, NgayKham, true);
                            DataAcess.Connect.ExecSQL("UPDATE KHAMBENH SET IdChuyenPK=" + IdChuyenPK + ", SoTTChuyenP='" + SoThuTuChuyenPhong + "'  WHERE IDKHAMBENH=" + idkhambenh);

                        }
                    }
                }
                else
                {
                    huongdieutri = "5";
                }
            }
        }
        #endregion
        #region khác
        else
        {
            string sqlSelectThuoc = @"
                    Select top 1 IDCHITIETBENHNHANTOATHUOC FROM CHITIETBENHNHANTOATHUOC WHERE IDKHAMBENH=" + idkhambenh;
            DataTable dtThuoc = DataAcess.Connect.GetTable(sqlSelectThuoc);
            if (dtThuoc != null && dtThuoc.Rows.Count > 0)
            {
                huongdieutri = "2";
            }
            else
            {
                if (IsHaveCLS == "1")
                {
                    huongdieutri = "6";
                }
            }
        }
        #endregion

        if (IsChoVeKT) huongdieutri = "3";
        else if (IsChuyenVien) huongdieutri = "4";
        else if (iskhongkham) huongdieutri = "20";
        else if (IsTieuPhauRoiVe) huongdieutri = "22";
        bool ok = DataAcess.Connect.ExecSQL("update khambenh set huongdieutri=" + huongdieutri + " where idkhambenh = " + idkhambenh);
        if (!ok)
        {
            Response.Clear();
            Response.Write("");
        }
        #region nvk cập nhật xuất khoa
        if (huongdieutri.Equals("8"))
        {
            string nvk_idctdkk = dtKhambenh.Rows[0]["idchitietdangkykham"].ToString();// DataAcess.Connect.GetTable("select isnull((select idchitietdangkykham from khambenh where idkhambenh='" + idkhambenh + "'),0)").Rows[0][0].ToString();
            string nvk_idkhoa = dtKhambenh.Rows[0]["idphongkhambenh"].ToString();
            if (!nvk_idkhoa.Equals(IdkhoaChuyen))
            {
                bool nvk_kt = nvk_CapNhatTinhTrangXuatKhoa(nvk_idctdkk, nvk_idkhoa, IdkhoaChuyen);
            }
        }
        #endregion

        string sqlSelectThuocBH = @"
                                Select top 1 IDCHITIETBENHNHANTOATHUOC 
                                        FROM CHITIETBENHNHANTOATHUOC A
                                        WHERE DBO.KB_ISTHUCSDBHYT2(A.IDCHITIETBENHNHANTOATHUOC)=1 AND  IDKHAMBENH=" + idkhambenh;
        DataTable dtThuocBH = DataAcess.Connect.GetTable(sqlSelectThuocBH);
        if (dtThuocBH != null && dtThuocBH.Rows.Count > 0)
        {
            DataAcess.Connect.GetTable("UPDATE KHAMBENH SET ISHAVETHUOCBH=1 WHERE IDKHAMBENH=" + idkhambenh);
        }
        else
        {
            DataAcess.Connect.GetTable("UPDATE KHAMBENH SET ISHAVETHUOCBH=0 WHERE IDKHAMBENH=" + idkhambenh);
        }
        bool OK_ISDAXUATTHUOC = DataAcess.Connect.ExecSQL("UPDATE KHAMBENH SET ISDAXUATTOATHUOC=DBO.HS_ISDAXUATTOATHUOC(IDKHAMBENH) WHERE IDKHAMBENH=" + idkhambenh);

        #endregion
        #region Tính tiền
        if (dtKhambenh.Rows[0]["IdKhoa"].ToString() == "1" && dtKhambenh.Rows[0]["LoaiKhamID"].ToString() != "1")
        {
            string sqlTinhTien = " EXEC ZHS_TONGTIENDV_CLS_BY_IDKHAMBENH " + idkhambenh;
            bool ok_TinhTienCLS = DataAcess.Connect.ExecSQL(sqlTinhTien);
        }
        else
        {
            bool ok_TinhTienAll = StaticData.TinhLaiTien_ByIdKhamBenh(idkhambenh);
        }
        #endregion
        Response.Clear();
        Response.Write("1" + ";" + SoThuTuChuyenPhong);
    }
    private bool nvk_CapNhatTinhTrangXuatKhoa(string idchitietdangkykham, string idkhoa, string idkhoaden)
    {
        string sql = "update benhnhannoitru set isdanhap=0,ischosanh=0 where idkhoanoitru='" + idkhoa + "' and idchitietdangkykham ='" + idchitietdangkykham + "'";
        bool kt_nvk = DataAcess.Connect.ExecSQL(sql);
        return kt_nvk;
    }
    public void loadTablechitietbenhnhantoathuoc()
    {
        DataProcess process = s_chitietbenhnhantoathuoc();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        string sqlSelect = @"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                                ,A.tenthuoc
                                ,B.LoaiThuocID
                               ,B.MaLoai
                               ,C.tencachdung
                               ,D.TenDVT as DVT
                               ,E.TenDVT as DVDung
                               ,F.catename,
                                F.CateId,
                                A.CongThuc,
                                A.sudungchobh,
                               tenkho=(case when t.idkho=-1 then N'Ngoài BV' else  k.tenkho end ),t.slton,sldaxuat=dbo.KB_SLTHUCXUAT(t.idchitietbenhnhantoathuoc)
                              ,idctYc= isnull((select top 1 idThuoc_ChiTietYeuCau from nvk_thuoc_chitietycxuat where idchitietbenhnhantoathuoc = t.idchitietbenhnhantoathuoc),0)
                            from chitietbenhnhantoathuoc T
                                left join thuoc  A on T.idthuoc=A.idthuoc
                                left join Thuoc_LoaiThuoc  B on isnull(a.loaithuocid,1)=B.LoaiThuocID
                                left join Thuoc_CachDung  C on T.idcachdung=C.idcachdung
                                left join Thuoc_DonViTinh  D on T.iddvt=D.Id
                                left join Thuoc_DonViTinh  E on T.iddvdung=E.Id
                                left join category  F on a.cateid=F.cateid
                         left join khothuoc k on k.idkho = T.idkho 
                    where T.idkhambenh='" + process.getData("idkhambenh") + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html = tableThuoc(table, null, true);
        Response.Clear();
        Response.Write(html);
    }
    private string tableThuoc(DataTable table, string[] arrslvack, bool idctbntt)
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string loaidk = Request.QueryString["loaidk"];
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th style='" + (idkhoa == "" ? "display:none" : "") + "'>Kho xuất</th>";
        html += "<th>Đối tượng</th>";
        html += "<th>Tên thuốc/VTYT/HC</th>";
        html += "<th>Hoạt chất</th>";
        html += "<th>ĐVT</th>";
        html += "<th>SL</th>";
        html += "<th>Cách dùng</th>";
        html += "<th>Ngày dùng</th>";
        html += "<th>Mỗi lần</th>";
        html += "<th>Đ.V Dùng</th>";
        html += "<th>Sáng</th>";
        html += "<th>Trưa</th>";
        html += "<th>Chiều</th>";
        html += "<th>Tối</th>";
        html += "<th>Ghi chú</th>";
        html += "<th>Dùng theo</th>";
        html += "<th " + (loaidk == "1" ? "" : "style='display:none;'") + ">?Trong dm</th>";
        html += "<th " + (loaidk == "1" ? "" : "style='display:none;'") + ">?Thỏa đk</th>";
        html += "<th>?Hao phí</th>";
        html += "<th>SL.Tồn</th>";
        html += "<th>Đã xuất</th>";
        html += "<th></th>";
        html += "</tr>";
        bool add = true;
        bool search = true; ;
        if (search)
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            process.Page = Request.QueryString["page"];

            if (table != null && table.Rows.Count > 0)
            {
                string slton_name = "slton";
                if (table.Columns.IndexOf("slton_new") != -1)
                    slton_name = slton_name = "slton_new";

                bool delete = true;
                bool edit = true;
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    string idkhoachinh = "";
                    if (arrslvack != null)
                    {
                        for (int y = 0; y < arrslvack.Length; y++)
                        {
                            if (arrslvack[y].Split('^')[0].ToString() == table.Rows[i]["idthuoc"].ToString() && (int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1 || arrslvack[y].Split('^')[2].ToString() != ""))
                            {

                                idkhoachinh = arrslvack[y].Split('^')[2].ToString();
                                break;
                            }
                        }
                    }
                    string disable_editThuoc = " disabled=disabled ";
                    try
                    {
                        if (table.Rows[i]["idctYc"].ToString().Equals("0"))
                            disable_editThuoc = "";
                    }
                    catch (Exception)
                    {
                        disable_editThuoc = " ";
                    }
                    bool IsSuDungChoBH = StaticData.IsCheck(table.Rows[i]["sudungchobh"].ToString());
                    bool IsBHYT_Save = StaticData.IsCheck(table.Rows[i]["IsBHYT_Save"].ToString());
                    edit = table.Columns.IndexOf("sldaxuat") != -1 && !string.IsNullOrEmpty(table.Rows[i]["sldaxuat"].ToString()) ? false : true;
                    html += "<tr style='background-color:" + (IsSuDungChoBH == true ? "" : "#CAE3FF") + ";'>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    bool isXoa = true;
                    if (edit == false && table.Rows[i]["idkho"].ToString() == StaticData.GetParameter("KhoThuocBHYT"))
                        isXoa = false;

                    html += "<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + (isXoa ? hsLibrary.clDictionaryDB.sGetValueLanguage("delete") : "") + "</a></td>";
                    html += "<td style='" + (idkhoa == "" ? "display:none" : "") + "'><input mkv='true' id='idkhoxuat' type='hidden' value='" + table.Rows[i]["idkho"] + "'/><input mkv='true' id='mkv_idkhoxuat' type='text'  type='text' onfocusout='chuyenformout(this)' onfocus='idkhoxuatsearch(this);' style='width:70px' value='" + table.Rows[i]["tenkho"].ToString() + "' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='DoiTuongThuocID' type='hidden' value='" + table.Rows[i]["LoaiThuocID"] + "'/><input mkv='true' id='mkv_DoiTuongThuocID' type='text' value='" + table.Rows[i]["MaLoai"].ToString() + "' onfocus='loaithuocidsearch(this);' style='width:70px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' " + disable_editThuoc + " id='mkv_idthuoc' type='text' value='" + table.Rows[i]["tenthuoc"].ToString() + "' onfocus='idthuocsearch(this,1);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='mkv_congthuc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this,2)'  value='" + table.Rows[i]["congthuc"].ToString() + "' class='down_select' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='iddvt' type='hidden' value='" + table.Rows[i]["iddvt"] + "'/><input mkv='true' id='mkv_iddvt' type='text' value='" + table.Rows[i]["DVT"].ToString() + "' onfocus='iddvtsearch(this);' style='width:50px; text-align:center;' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongke"].ToString() + "' style='width:30px' onblur='TestSo(this,false,false);CheckSLTON(this);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idcachdung' type='hidden' value='" + table.Rows[i]["idcachdung"] + "'/><input mkv='true' id='mkv_idcachdung'  type='text' value='" + table.Rows[i]["tencachdung"].ToString() + "' onfocus='idcachdungsearch(this);' style='width:30px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "'  style='width:30px' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  style='width:30px' value='" + table.Rows[i]["moilanuong"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='iddvdung' type='hidden' value='" + table.Rows[i]["iddvdung"] + "'/><input mkv='true' id='mkv_iddvdung' type='text' value='" + table.Rows[i]["DVDung"].ToString() + "' onfocus='iddvtsearch(this);'  style='width:50px' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='issang' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["issang"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='istrua' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istrua"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ischieu' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["ischieu"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='istoi' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istoi"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + table.Rows[i]["ghichu"].ToString() + "' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td>Ngày<input mkv='true' id='isngay' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["isngay"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/>Tuần<input mkv='true' id='istuan' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (table.Rows[i]["istuan"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='SuDungChoBH' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (IsSuDungChoBH ? "checked='checked' " : "") + " disabled='disabled' /></td>";
                    html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='IsBHYT_Save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + ((IsBHYT_Save && IsSuDungChoBH) ? "checked='checked' " + (!edit ? "disabled" : "") + "" : "disabled='disabled'") + " /></td>";
                    html += "<td><input mkv='true' id='ishaophi' type='checkbox' " + (StaticData.IsCheck(table.Rows[i]["ishaophi"].ToString()) ? "checked" : "") + " " + (!edit ? "disabled" : "") + " onblur='chuyenhuong(this);' /></td>";
                    html += "<td><input mkv='true' id='slton' type='text' onfocusout='chuyenformout(this)' style='width:50px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + (table.Columns.IndexOf(slton_name) != -1 ? table.Rows[i][slton_name].ToString() : "") + "' " + (1 == 1 ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='sldaxuat' type='text' onfocusout='chuyenformout(this)' style='width:20px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + (table.Columns.IndexOf("sldaxuat") != -1 ? table.Rows[i]["sldaxuat"].ToString() : "") + "' " + (1 == 1 ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idctbntt ? table.Rows[i]["idchitietbenhnhantoathuoc"] : idkhoachinh) + "'/><input mkv='true' id='idkho' type='hidden' value='" + table.Rows[i]["idkho"].ToString() + "'/></td>";
                    html += "<td><input mkv='false' id='IsCheckSLTon' type='hidden' value='" + (loaidk == "1" ? "1" : "0") + "'/></td>";

                    html += "</tr>";
                }
            }
        }
        if (add)
        {
            html += "<tr>";
            html += "<td>" + ((table.Rows.Count > 0 && table != null) ? table.Rows.Count + 1 : 1) + "</td>";
            html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td style='" + (idkhoa == "" ? "display:none" : "") + "'><input mkv='true' id='idkhoxuat' type='hidden' value='" + (idkhoa == "1" && loaidk == "1" ? "5" : "") + "'/><input mkv='true' id='mkv_idkhoxuat' type='text'  value='" + (idkhoa == "1" && loaidk == "1" ? "Q.P.T BHYT" : "") + "' onfocusout='chuyenformout(this)' onfocus='idkhoxuatsearch(this);' style='width:100px' class=\"down_select\" /></td>";
            html += "<td><input mkv='true' id='DoiTuongThuocID' type='hidden' value=''/><input mkv='true' id='mkv_DoiTuongThuocID' type='text' value='' onfocus='loaithuocidsearch(this);' style='width:70px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus='idthuocsearch(this,1);' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='mkv_congthuc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this,2)' value='' class='down_select'/></td>";
            html += "<td><input mkv='true' id='iddvt' type='hidden' value=''/><input mkv='true' id='mkv_iddvt' type='text' value='' onfocus='iddvtsearch(this);' style='width:50px; text-algin:center;' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:30px' value='' onblur='TestSo(this,false,false);CheckSLTON(this);' /></td>";
            html += "<td><input mkv='true' id='idcachdung' type='hidden' value=''/><input mkv='true' id='mkv_idcachdung' type='text' value='' onfocus='idcachdungsearch(this);'  style='width:50px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:40px' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);'  style='width:30px' value='' /></td>";
            html += "<td><input mkv='true' id='iddvdung' type='hidden' value=''/><input mkv='true' id='mkv_iddvdung' type='text' value='' onfocus='iddvtsearch(this);'  style='width:50px' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='issang' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='istrua' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='ischieu' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='istoi' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)'  style='width:70px' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='chuyenhuong(this);' /></td>";
            html += "<td>Ngày<input mkv='true' id='isngay' type='checkbox' checked='true'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' />Tuần<input mkv='true' id='istuan' type='checkbox'  onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='SuDungChoBH' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled='disabled' /></td>";
            html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='IsBHYT_Save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled='disabled' /></td>";
            html += "<td><input mkv='true' id='ishaophi' type='checkbox' onblur='chuyenhuong(this);' /></td>";
            html += "<td><input mkv='true' id='slton' type='text' onfocusout='chuyenformout(this)' style='width:50px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + "" + "' " + (1 == 1 ? "disabled" : "") + "/></td>";
            html += "<td><input mkv='true' id='sldaxuat' type='text' onfocusout='chuyenformout(this)' style='width:20px' onfocus='chuyendong(this);chuyenphim(this);' onblur='chuyenhuong(this);'  value='" + "" + "' " + (1 == 1 ? "disabled" : "") + "/></td>";
            html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/><input mkv='true' id='idkho' type='hidden' value=''/></td>";
            html += "<td><input mkv='false' id='IsCheckSLTon' type='hidden' value='" + (loaidk == "1" ? "1" : "0") + "'/></td>";

            html += "</tr>";
        }
        html += "<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
        html += "</table>";
        if (!search)
            html += "Bạn không có quyền xem.";

        return html;
    }
    public void loadTablekhambenhcanlamsan()
    {

        DataProcess process = s_khambenhcanlamsan();
        string IsChuyenPhong = Request.QueryString["IsChuyenPhong"];
        string idkhambenh = process.getData("idkhambenh");
        if (idkhambenh != null && idkhambenh != "" && idkhambenh != "0" && IsChuyenPhong == "1")
        {
            DataTable dtTT = DataAcess.Connect.GetTable("SELECT TOP 1 IDCHITIETBENHNHANTOATHUOC FROM CHITIETBENHNHANTOATHUOC WHERE IDKHAMBENH=" + idkhambenh);
            if (dtTT != null && dtTT.Rows.Count > 0)
                idkhambenh = "";
        }
        process.NumberRow = "10000";
        process.Page = Request.QueryString["page"];
        string sqlSelect = @"select STT=row_number() over (order by T.idkhambenhcanlamsan),T.*
                                ,a.tendichvu,a.idbanggiadichvu,a.IsSuDungChoBH,a.tennhom,a.idphongkhambenh,pkb.tenphongkhambenh
                               from khambenhcanlamsan T
                                left join banggiadichvu a on t.idcanlamsan=a.idbanggiadichvu
                                left join phongkhambenh pkb on a.idphongkhambenh=pkb.idphongkhambenh
          where T.idkhambenh=" + (idkhambenh == "" ? "null" : "'" + idkhambenh + "' and isnull(t.dahuy,0)=0");
        DataTable table = process.Search(sqlSelect);
        string html = "";
        html += tableCLS(table, null, true);
        Response.Clear();
        Response.Write(html);
    }
    public void loadTablechandoanphoihop()
    {

        DataProcess process = new DataProcess("chandoanphoihop");
        process.data("idkhambenh", Request.QueryString["idkhambenh"]);
        string sqll = @"select STT=row_number() over (order by T.id),t.id,
		    mota=isnull(t.MoTaCD_edit,a.mota),a.idicd,a.maicd from chandoanphoihop T
            left join chandoanicd A on A.idicd = T.idicd
            where T.idkhambenh='" + process.getData("idkhambenh") + @"'";
        DataTable table = process.Search(sqll);
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTableCDPH\" >");
        html.Append("<tr>");
        html.Append("<th style='width:3%'>STT</th>");
        html.Append("<th style='width:5%'></th>");
        html.Append("<th style='width:12%'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaICD") + "</th>");
        html.Append("<th style='width:80%'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MoTaICD") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = true;
        bool search = true;
        if (search)
        {
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + (i + 1) + "</td>");
                    html.Append("<td><a onclick='xoaontableCDPH(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idicd"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='" + table.Rows[i]["MaICD"] + "' class='down_select' /></td>");
                    html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='" + table.Rows[i]["mota"] + "' class='down_select' style='width:98%'/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["id"] + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>" + ((table.Rows.Count > 0 && table != null) ? table.Rows.Count + 1 : 1) + "</td>");
            html.Append("<td><a onclick='xoaontableCDPH(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='' class='down_select'/></td>");
            html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='' class='down_select' style='width:98%'/></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
            html.Append("</table>");
        }
        Response.Clear();
        Response.Write(html);
    }
    private string tableCLS(DataTable dt, string[] arrslvack, bool idkhambenhcls)
    {
        string html = "";
        string loaidk = Request.QueryString["loaidk"];
        html += "<table class='jtable' id=\"gridTablecls\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Khoa</th>";
        html += "<th>Tên nhóm</th>";
        html += "<th>Tên dịch vụ</th>";
        html += "<th>Số lượng</th>";
        html += "<th>Đơn giá</th>";
        html += "<th>Chiết khấu</th>";
        html += "<th>Thành tiền</th>";
        html += "<th>Ghi chú</th>";
        html += "<th  " + (loaidk == "1" ? "" : "style='display:none;'") + ">?Trong dm</th>";
        html += "<th  " + (loaidk == "1" ? "" : "style='display:none;'") + ">?Thỏa đk</th>";
        html += "<th></th>";
        html += "</tr>";
        if (dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                int ck = 0;
                int sl = 1;

                string idkhoachinh = "";
                if (arrslvack != null)
                {
                    for (int y = 0; y < arrslvack.Length; y++)
                    {
                        if (arrslvack[y].Split('^')[0].ToString() == dt.Rows[i]["idbanggiadichvu"].ToString() && (int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1 || int.Parse(arrslvack[y].Split('^')[2].ToString()) > 0 || arrslvack[y].Split('^')[3].ToString() != ""))
                        {
                            ck = int.Parse(arrslvack[y].Split('^')[2].ToString());
                            sl = int.Parse(arrslvack[y].Split('^')[1].ToString());
                            idkhoachinh = arrslvack[y].Split('^')[3].ToString();
                            break;
                        }
                    }
                }
                try
                {
                    ck = int.Parse(dt.Rows[i]["chietkhau"].ToString());
                    sl = int.Parse(dt.Rows[i]["soluong"].ToString());
                }
                catch { }
                double thanhtien = (dt.Rows[i]["dongia"].ToString() != "" ? sl * double.Parse(dt.Rows[i]["dongia"].ToString()) : 0); ;
                bool IsSuDungChoBH = StaticData.IsCheck(dt.Rows[i]["IsSuDungChoBH"].ToString());
                bool IsBHYT_Save = StaticData.IsCheck(dt.Rows[i]["IsBHYT_Save"].ToString());
                bool IsDathu = StaticData.IsCheck(dt.Rows[i]["dathu"].ToString());
                string isCheck = "";
                if (IsSuDungChoBH && IsDathu && IsBHYT_Save)
                {
                    isCheck += " checked disabled";
                }
                else if (IsSuDungChoBH && !IsDathu && !IsBHYT_Save)
                {
                    isCheck += " checked";
                }
                else if (!IsSuDungChoBH && !IsDathu && !IsBHYT_Save)
                {
                    isCheck += "disabled";
                }
                else if (IsDathu)
                {
                    isCheck += "disabled";
                }
                string ighichu = "";
                if (dt.Columns.IndexOf("ghichu") != -1)
                    ighichu = dt.Rows[i]["ghichu"].ToString();

                html += "<tr " + (IsSuDungChoBH == true ? "" : "style='background-color:#CAE3FF'") + " >";
                html += "<td>" + dt.Rows[i]["stt"] + "</td>";
                html += "<td><a onclick='xoaontablecls(this)'>Xoá</a></td>";
                html += "<td><input mkv='true' id='idkhoa' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idphongkhambenh"] + " ' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idkhoa' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhoasearch(this)' onblur='idkhoachange(this);' value='" + dt.Rows[i]["tenphongkhambenh"] + "'  style='width:90px' class='down_select' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='mkv_tennhom' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idphongsearch(this)' value='" + dt.Rows[i]["tennhom"] + "'  style='width:120px' class='down_select' " + (dt.Rows[i]["dathu"].ToString() == "1" ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idbanggiadichvu"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='" + dt.Rows[i]["tendichvu"] + "'  style='width:320px' class='down_select' " + (IsDathu ? "disabled='disabled'" : "") + " /></td>";
                html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + sl + "' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();'  style='width:30px' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["dongia"] + "' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();;' style='width:50px' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ck + "' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();'  style='width:30px' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ((thanhtien - (thanhtien * ck) / 100)).ToString() + "'  style='width:70px' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ighichu + "' " + (IsDathu ? "disabled='disabled'" : "") + "  /></td>";
                html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='SuDungChoBH' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (IsSuDungChoBH == true ? "checked='checked'" : "disabled='disabled'") + (IsDathu ? "disabled='disabled'" : "") + "   /></td>";
                html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='IsBHYT_Save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (IsBHYT_Save == true ? "checked='checked'" : "") + isCheck + "/></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : idkhoachinh) + "'/><a onclick='huyontablecls(this)'>Hủy</a></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + (dt.Rows.Count + 1) + "</td>";
        html += "<td><a onclick='xoaontablecls(this)'>Xoá</a></td>";
        html += "<td><input mkv='true' id='idkhoa' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idkhoa' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhoasearch(this)' value=''  style='width:90px' class='down_select'/></td>";
        html += "<td><input mkv='true' id='mkv_tennhom' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idphongsearch(this)' value=''  style='width:120px' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)'  style='width:320px' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls();'  style='width:30px'/></td>";
        html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls()' style='width:50px' /></td>";
        html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);tongtiencls()'  style='width:30px'/></td>";
        html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value=''  style='width:70px; text-algin:right' /></td>";
        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
        html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='SuDungChoBH' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled='disabled' /></td>";
        html += "<td " + (loaidk == "1" ? "" : "style='display:none;'") + "><input mkv='true' id='IsBHYT_Save' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' disabled='disabled'/></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/><a onclick='huyontablecls(this)'>Hủy</a></td>";
        html += "</tr>";
        html += "<tr ><td></td><td colspan='6' align='right' style='font-weight:bold; font-size:13px;'>Tổng Cộng</td><td style='font-weight:bold;text-align:right; font-size:14px; padding-right:5px;' colspan='2'></td><td></td><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
    private void ChanDoansearch()
    {
        string IsMaICD = Request.QueryString["IsMaICD"];
        string TenSearch = Request.QueryString["q"];
        string sql = @"select top 20 idicd,maicd,mota from chandoanicd where ";
        if (IsMaICD.Equals("1"))
            sql += " maicd like N'" + TenSearch + "%'";
        else
            sql += " mota like N'%" + TenSearch + "%'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        html = string.Format(""
              + "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:23px;padding-right:25px\">"
                    + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
                    + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >MaICD</div>"
                    + "<div style=\"width:55%;height:30px;color:#000;font-weight:bold;float:left\" >Mô tả</div>"
              + "</div>");
        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div>"
                       + "<div style=\"width:15%;height:30px;float:left\" >" + (i + 1) + "</div>"
                       + "<div style=\"width:30%;height:30px;float:left\" >" + h["maicd"] + "</div>"
                       + "<div style=\"width:55%;height:30px;float:left\" >" + h["mota"] + "</div>"
                    + "</div>", h["idicd"], h["maicd"], h["mota"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void XoaCDPH()
    {
        try
        {
            DataProcess process = s_chanDoanPhoiHop();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuCDPH()
    {
        try
        {
            DataProcess process = s_chanDoanPhoiHop();
            if (process.getData("idicd").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }
            if (process.getData("id") != null && process.getData("id") != "" && process.getData("id") != "0")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("id"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void ShowDSCLSTDK()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string NgayDangKy = DateTime.Now.ToString("yyyy-MM-dd");
        string idkhoadangky = Request.QueryString["idkhoa"];
        string sqlSelect = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY A.IDKHAMBENHCANLAMSAN ),TENKHOA=TENPHONGKHAMBENH,TENNHOM,TENDICHVU,SOLUONG=ISNULL(SOLUONG,1)
                            FROM KHAMBENHCANLAMSAN A
                            LEFT JOIN BANGGIADICHVU B ON A.IDCANLAMSAN=B.IDBANGGIADICHVU
                            LEFT JOIN PHONGKHAMBENH C ON B.IDPHONGKHAMBENH=C.IDPHONGKHAMBENH
                            WHERE  ISNULL(A.IDKHAMBENH,0)=0
                              AND A.IDBENHNHAN='" + idbenhnhan + @"'
                              AND ISNULL(A.DATHU,0)=1
                              AND ISNULL(A.DAHUY,0)=0
                              AND YEAR(NGAYTHU)=YEAR('" + NgayDangKy + @"')
                              AND MONTH(NGAYTHU)=MONTH('" + NgayDangKy + @"')
                              AND DAY(NGAYTHU)=DAY('" + NgayDangKy + @"')
                              AND idkhoadangky='" + idkhoadangky + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table == null || table.Rows.Count == 0)
        {
            Response.Write("");
            return;
        }
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable'>");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>Tên khoa</th>");
        html.Append("<th>Tên nhóm</th>");
        html.Append("<th>Tên dịch vụ </th>");
        html.Append("<th>Số lượng</th>");
        html.Append("</tr>");
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html.Append("<tr>");
            html.Append("<td>" + table.Rows[i]["STT"].ToString() + "</td>");
            html.Append("<td style='text-align:left; padding-left:10px'>" + table.Rows[i]["tenkhoa"].ToString() + "</td>");
            html.Append("<td style='text-align:left; padding-left:10px'>" + table.Rows[i]["tennhom"].ToString() + " </td>");
            html.Append("<td style='text-align:left; padding-left:10px'>" + table.Rows[i]["tendichvu"].ToString() + " </td>");
            html.Append("<td >" + table.Rows[i]["soluong"].ToString() + " </td>");
            html.Append("</tr>");
        }
        html.Append("</table");
        Response.Clear();
        Response.Write(html);
    }//end void
    //-------------------------------------------------------------------------------------------------------------------
    private void MakeSoVaoVien()
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        string idchitietdangkykham = Request.QueryString["idctdkk"];
        string IsNoiTru = Request.QueryString["IsNoiTru"];
        string SoVaoVien = StaticData_HS.GetSoVaoVien(idkhambenh, idchitietdangkykham, IsNoiTru);
        Response.Write(SoVaoVien);
    }
    //-------------------------------------------------------------------------------------------------------------------
    private void GetListSLTon_RealTime()
    {

        Dictionary<string, List<SLTON_RealTime>> _dic = new Dictionary<string, List<SLTON_RealTime>>();
        string lstIdThuoc = Request.QueryString["listThuoc"];
        string IdKhoa = Request.QueryString["idkhoa"];
        string loaidk = Request.QueryString["loaidk"];
        string[] lstId = lstIdThuoc.Split('@');
        List<SLTON_RealTime> _ls = new List<SLTON_RealTime>();
        for (int i = 0; i < lstId.Length; i++)
        {
            string lst = lstId[i].TrimEnd('|').TrimEnd('@');
            if (lst != "")
            {
                string idthuoc = lstId[i].Split('|')[0].ToString();
                if (idthuoc != null && idthuoc != "")
                {
                    string IdLoaiThuoc = lstId[i].Split('|')[2].ToString();
                    #region IdKho
                    string IdKho = lstId[i].Split('|')[1].ToString();
                    if (IdKho == null || IdKho == "" || IdKho == "0")
                    {
                        if (IdKhoa == "1")
                        {
                            if (IdLoaiThuoc == "1" && loaidk == "1")
                                IdKho = StaticData.GetParaValueDB("KhoThuocBHYT");
                            else
                            {
                                if (IdLoaiThuoc != "1")
                                    IdKho = StaticData.GetParaValueDB("KhoPhongKhamID");
                                else
                                    IdKho = StaticData.GetParaValueDB("KhoThuocDV");
                            }
                        }
                    }
                    if (IdKho == "") IdKho = "0";
                    #endregion
                    string SLTON_ = "0";
                    if (IdKho != "" && IdKho != "0" && IdKhoa != null && IdKho != "-1")
                    {
                        string SQL = @"SELECT DBO.THUOC_TONKHO_RATOA(" + idthuoc + ",GETDATE()," + IdKho + ")";
                        DataTable dtSLTon = DataAcess.Connect.GetTable(SQL);
                        if (dtSLTon != null && dtSLTon.Rows.Count > 0)
                        {
                            SLTON_ = dtSLTon.Rows[0][0].ToString();
                        }
                    }
                    SLTON_RealTime _SL = new SLTON_RealTime();
                    _SL.IdThuoc = idthuoc;
                    _SL.SLTon = SLTON_;
                    _ls.Add(_SL);
                }
            }
        }
        _dic.Add("_JSON", _ls);
        JavaScriptSerializer ser = new JavaScriptSerializer();
        Response.Write(ser.Serialize(_dic));
    }

}//end class
public class SLTON_RealTime
{
    private string _idthuoc;
    private string _slton;
    public string IdThuoc
    {
        get { return _idthuoc; }
        set { _idthuoc = value; }
    }
    public string SLTon
    {
        get { return _slton; }
        set { _slton = value; }
    }
}

