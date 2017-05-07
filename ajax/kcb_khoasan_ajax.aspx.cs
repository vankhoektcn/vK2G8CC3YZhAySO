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

public partial class kcb_khoasan_ajax : System.Web.UI.Page
 {
     protected DataProcess s_kcb_khoasan()
     {
         DataProcess kcb_khoasan = new DataProcess("kcb_khoasan");
         kcb_khoasan.data("idkcbkhoasan", Request.QueryString["idkcbkhoasan"]);
         kcb_khoasan.data("idkhambenh", Request.QueryString["idkhambenhgoc"]);
         kcb_khoasan.data("idbacsi", Request.QueryString["idbacsi"]);
         kcb_khoasan.data("ngayvaovien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaovien"]) ? "00" : Request.QueryString["giovaovien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaovien"]) ? "00" : Request.QueryString["phutvaovien"]) + " " + Request.QueryString["ngayvaovien"], "datetime"));
         kcb_khoasan.data("tructiepvaocapcuu", Request.QueryString["tructiepvaocapcuu"]);
         kcb_khoasan.data("tructiepvaoKKB", Request.QueryString["tructiepvaoKKB"]);
         kcb_khoasan.data("tructiepvaokhoa", Request.QueryString["tructiepvaokhoa"]);
         kcb_khoasan.data("coquangioithieu", Request.QueryString["coquangioithieu"]);
         kcb_khoasan.data("tuden", Request.QueryString["tuden"]);
         kcb_khoasan.data("khac", Request.QueryString["khac"]);
         kcb_khoasan.data("vaovienlan", Request.QueryString["vaovienlan"]);
         kcb_khoasan.data("vaokhoa", Request.QueryString["vaokhoa"]);
         kcb_khoasan.data("thoigianvaokhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaokhoa"]) ? "00" : Request.QueryString["giovaokhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaokhoa"]) ? "00" : Request.QueryString["phutvaokhoa"]) + " " + Request.QueryString["thoigianvaokhoa"], "datetime"));
         kcb_khoasan.data("songaydieutri", Request.QueryString["songaydieutri"]);
         kcb_khoasan.data("chuyentukhoa", Request.QueryString["chuyentukhoa"]);
         kcb_khoasan.data("thoigianchuyentukhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoa"]) ? "00" : Request.QueryString["giochuyentukhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoa"]) ? "00" : Request.QueryString["phutchuyentukhoa"]) + " " + Request.QueryString["thoigianchuyentukhoa"], "datetime"));
         kcb_khoasan.data("songaydieutritukhoa", Request.QueryString["songaydieutritukhoa"]);
         kcb_khoasan.data("denkhoathunhat", Request.QueryString["denkhoathunhat"]);
         kcb_khoasan.data("thoigianchuyentukhoathunhat", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathunhat"]) ? "00" : Request.QueryString["giochuyentukhoathunhat"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathunhat"]) ? "00" : Request.QueryString["phutchuyentukhoathunhat"]) + " " + Request.QueryString["thoigianchuyentukhoathunhat"], "datetime"));
         kcb_khoasan.data("songaydieutrikhoathunhat", Request.QueryString["songaydieutrikhoathunhat"]);
         kcb_khoasan.data("denkhoathuhai", Request.QueryString["denkhoathuhai"]);
         kcb_khoasan.data("thoigianchuyentukhoathuhai", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathuhai"]) ? "00" : Request.QueryString["giochuyentukhoathuhai"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathuhai"]) ? "00" : Request.QueryString["phutchuyentukhoathuhai"]) + " " + Request.QueryString["thoigianchuyentukhoathuhai"], "datetime"));
         kcb_khoasan.data("songaydieutrikhoathuhai", Request.QueryString["songaydieutrikhoathuhai"]);
         kcb_khoasan.data("chuyenvientuyentren", Request.QueryString["chuyenvientuyentren"]);
         kcb_khoasan.data("chuyenvientuyenduoi", Request.QueryString["chuyenvientuyenduoi"]);
         kcb_khoasan.data("chuyenvienCK", Request.QueryString["chuyenvienCK"]);
         kcb_khoasan.data("chuyenvienden", Request.QueryString["chuyenvienden"]);
         kcb_khoasan.data("ngayravien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["gioravien"]) ? "00" : Request.QueryString["gioravien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutravien"]) ? "00" : Request.QueryString["phutravien"]) + " " + Request.QueryString["ngayravien"], "datetime"));
         kcb_khoasan.data("ravien", Request.QueryString["ravien"]);
         kcb_khoasan.data("xinve", Request.QueryString["xinve"]);
         kcb_khoasan.data("bove", Request.QueryString["bove"]);
         kcb_khoasan.data("duave", Request.QueryString["duave"]);
         kcb_khoasan.data("tongsongaydieutri", Request.QueryString["tongsongaydieutri"]);
         kcb_khoasan.data("cd_noichuyenden", Request.QueryString["cd_noichuyenden"]);
         kcb_khoasan.data("cd_manoichuyenden", Request.QueryString["cd_manoichuyenden"]);
         kcb_khoasan.data("cd_noiKKBCapCuu", Request.QueryString["cd_noiKKBCapCuu"]);
         kcb_khoasan.data("cd_manoiKKBCapCuu", Request.QueryString["cd_manoiKKBCapCuu"]);
         kcb_khoasan.data("cd_lucnaode", Request.QueryString["cd_lucnaode"]);
         kcb_khoasan.data("cd_malucde", Request.QueryString["cd_malucde"]);
         kcb_khoasan.data("cd_ngayde", Request.QueryString["cd_ngayde"]);
         kcb_khoasan.data("cd_ngoithai", Request.QueryString["cd_ngoithai"]);
         kcb_khoasan.data("cd_cachthucde", Request.QueryString["cd_cachthucde"]);
         kcb_khoasan.data("cd_kiemsoattucung", Request.QueryString["cd_kiemsoattucung"]);
         kcb_khoasan.data("cd_iskiemsoattucung", Request.QueryString["cd_iskiemsoattucung"]);
         kcb_khoasan.data("cd_taibien", Request.QueryString["cd_taibien"]);
         kcb_khoasan.data("cd_bienchung", Request.QueryString["cd_bienchung"]);
         kcb_khoasan.data("cd_phauthuat", Request.QueryString["cd_phauthuat"]);
         kcb_khoasan.data("cd_gayme", Request.QueryString["cd_gayme"]);
         kcb_khoasan.data("cd_nhiemkhuan", Request.QueryString["cd_nhiemkhuan"]);
         kcb_khoasan.data("cd_khac", Request.QueryString["cd_khac"]);
         kcb_khoasan.data("cd_capcuu", Request.QueryString["cd_capcuu"]);
         kcb_khoasan.data("cd_chudong", Request.QueryString["cd_chudong"]);
         kcb_khoasan.data("cd_chandoantruocphauthuat", Request.QueryString["cd_chandoantruocphauthuat"]);
         kcb_khoasan.data("cd_machandoantruocphauthuat", Request.QueryString["cd_machandoantruocphauthuat"]);
         kcb_khoasan.data("cd_chandoansauphauthuat", Request.QueryString["cd_chandoansauphauthuat"]);
         kcb_khoasan.data("cd_machandoansauphauthuat", Request.QueryString["cd_machandoansauphauthuat"]);
         kcb_khoasan.data("cd_phuongphapphauthuat", Request.QueryString["cd_phuongphapphauthuat"]);
         kcb_khoasan.data("cd_donthai", Request.QueryString["cd_donthai"]);
         kcb_khoasan.data("cd_dathai", Request.QueryString["cd_dathai"]);
         kcb_khoasan.data("cd_trai", Request.QueryString["cd_trai"]);
         kcb_khoasan.data("cd_gai", Request.QueryString["cd_gai"]);
         kcb_khoasan.data("cd_song", Request.QueryString["cd_song"]);
         kcb_khoasan.data("cd_chet", Request.QueryString["cd_chet"]);
         kcb_khoasan.data("cd_divat", Request.QueryString["cd_divat"]);
         kcb_khoasan.data("cd_cannang", Request.QueryString["cd_cannang"]);
         kcb_khoasan.data("cd_songaydieutrisauphauthuat", Request.QueryString["cd_songaydieutrisauphauthuat"]);
         kcb_khoasan.data("cd_solanphauthuat", Request.QueryString["cd_solanphauthuat"]);
         kcb_khoasan.data("tt_khoi", Request.QueryString["tt_khoi"]);
         kcb_khoasan.data("tt_giam", Request.QueryString["tt_giam"]);
         kcb_khoasan.data("tt_khongthaydoi", Request.QueryString["tt_khongthaydoi"]);
         kcb_khoasan.data("tt_nanghon", Request.QueryString["tt_nanghon"]);
         kcb_khoasan.data("tt_chuyenvien", Request.QueryString["tt_chuyenvien"]);
         kcb_khoasan.data("tt_tuvong", Request.QueryString["tt_tuvong"]);
         kcb_khoasan.data("tt_lanhtinh", Request.QueryString["tt_lanhtinh"]);
         kcb_khoasan.data("tt_nghingo", Request.QueryString["tt_nghingo"]);
         kcb_khoasan.data("tt_actinh", Request.QueryString["tt_actinh"]);
         kcb_khoasan.data("tt_thoigiantuvong", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["tt_giotuvong"]) ? "00" : Request.QueryString["tt_giotuvong"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["tt_phuttuvong"]) ? "00" : Request.QueryString["tt_phuttuvong"]) + " " + Request.QueryString["tt_thoigiantuvong"], "datetime"));
         kcb_khoasan.data("tt_tuvongdobenh", Request.QueryString["tt_tuvongdobenh"]);
         kcb_khoasan.data("tt_tuvongdotaibien", Request.QueryString["tt_tuvongdotaibien"]);
         kcb_khoasan.data("tt_tuvongkhac", Request.QueryString["tt_tuvongkhac"]);
         kcb_khoasan.data("tt_tuvongtrong24h", Request.QueryString["tt_tuvongtrong24h"]);
         kcb_khoasan.data("tt_tuvongsau24h", Request.QueryString["tt_tuvongsau24h"]);
         kcb_khoasan.data("tt_nguyennhantuvong", Request.QueryString["tt_nguyennhantuvong"]);
         kcb_khoasan.data("tt_manguyennhantuvong", Request.QueryString["tt_manguyennhantuvong"]);
         kcb_khoasan.data("tt_khamtuthi", Request.QueryString["tt_khamtuthi"]);
         kcb_khoasan.data("tt_chandoangiaiphaututhi", Request.QueryString["tt_chandoangiaiphaututhi"]);
         kcb_khoasan.data("tt_magiaiphaututhi", Request.QueryString["tt_magiaiphaututhi"]);
         kcb_khoasan.data("hb_kinhcuoitungay", Request.QueryString["hb_kinhcuoitungay"]);
         kcb_khoasan.data("hb_kinhcuoidenngay", Request.QueryString["hb_kinhcuoidenngay"]);
         kcb_khoasan.data("hb_tuoithai", Request.QueryString["hb_tuoithai"]);
         kcb_khoasan.data("hb_khamtai", Request.QueryString["hb_khamtai"]);
         kcb_khoasan.data("hb_tiemphonguonvan", Request.QueryString["hb_tiemphonguonvan"]);
         kcb_khoasan.data("hb_duoctiem", Request.QueryString["hb_duoctiem"]);
         kcb_khoasan.data("hb_batdauchuyenda", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyenda"]) ? "00" : Request.QueryString["giochuyenda"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyenda"]) ? "00" : Request.QueryString["phutchuyenda"]) + " " + Request.QueryString["hb_batdauchuyenda"], "datetime"));
         kcb_khoasan.data("hb_dauhieulucdau", Request.QueryString["hb_dauhieulucdau"]);
         kcb_khoasan.data("hb_bienchuyen", Request.QueryString["hb_bienchuyen"]);
         kcb_khoasan.data("hb_tiensubenhbanthan", Request.QueryString["hb_tiensubenhbanthan"]);
         kcb_khoasan.data("hb_tiensubenhgiadinh", Request.QueryString["hb_tiensubenhgiadinh"]);
         kcb_khoasan.data("hb_batdauthaykinh", Request.QueryString["hb_batdauthaykinh"]);
         kcb_khoasan.data("hb_tuoibatdauthaykinh", Request.QueryString["hb_tuoibatdauthaykinh"]);
         kcb_khoasan.data("hb_tinhchatkinhnguyet", Request.QueryString["hb_tinhchatkinhnguyet"]);
         kcb_khoasan.data("hb_chukykinh", Request.QueryString["hb_chukykinh"]);
         kcb_khoasan.data("hb_luongkinh", Request.QueryString["hb_luongkinh"]);
         kcb_khoasan.data("hb_laychongnam", Request.QueryString["hb_laychongnam"]);
         kcb_khoasan.data("hb_tuoilaychong", Request.QueryString["hb_tuoilaychong"]);
         kcb_khoasan.data("hb_nhungbenhkhoasandadieutri", Request.QueryString["hb_nhungbenhkhoasandadieutri"]);
         kcb_khoasan.data("kb_toantrang", Request.QueryString["kb_toantrang"]);
         kcb_khoasan.data("kb_tuanhoan", Request.QueryString["kb_tuanhoan"]);
         kcb_khoasan.data("kb_hohap", Request.QueryString["kb_hohap"]);
         kcb_khoasan.data("kb_tieuhoa", Request.QueryString["kb_tieuhoa"]);
         kcb_khoasan.data("kb_tietnieu", Request.QueryString["kb_tietnieu"]);
         kcb_khoasan.data("kb_cacbophankhac", Request.QueryString["kb_cacbophankhac"]);
         kcb_khoasan.data("kb_bungcoseocu", Request.QueryString["kb_bungcoseocu"]);
         kcb_khoasan.data("kb_hinhdangTC", Request.QueryString["kb_hinhdangTC"]);
         kcb_khoasan.data("kb_tuthe", Request.QueryString["kb_tuthe"]);
         kcb_khoasan.data("kb_chieucao", Request.QueryString["kb_chieucao"]);
         kcb_khoasan.data("kb_vongbung", Request.QueryString["kb_vongbung"]);
         kcb_khoasan.data("kb_concoTC", Request.QueryString["kb_concoTC"]);
         kcb_khoasan.data("kb_timthai", Request.QueryString["kb_timthai"]);
         kcb_khoasan.data("kb_vu", Request.QueryString["kb_vu"]);
         kcb_khoasan.data("kb_chisobishop", Request.QueryString["kb_chisobishop"]);
         kcb_khoasan.data("kb_amho", Request.QueryString["kb_amho"]);
         kcb_khoasan.data("kb_amdao", Request.QueryString["kb_amdao"]);
         kcb_khoasan.data("kb_tangsinhmon", Request.QueryString["kb_tangsinhmon"]);
         kcb_khoasan.data("kb_cotucung", Request.QueryString["kb_cotucung"]);
         kcb_khoasan.data("kb_phanphu", Request.QueryString["kb_phanphu"]);
         kcb_khoasan.data("kb_oiphong", Request.QueryString["kb_oiphong"]);
         kcb_khoasan.data("kb_oidet", Request.QueryString["kb_oidet"]);
         kcb_khoasan.data("kb_oiquale", Request.QueryString["kb_oiquale"]);
         kcb_khoasan.data("kb_thoigianoivo", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giooivo"]) ? "00" : Request.QueryString["giooivo"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutoivo"]) ? "00" : Request.QueryString["phutoivo"]) + " " + Request.QueryString["kb_thoigianoivo"], "datetime"));
         kcb_khoasan.data("kb_oivotunhien", Request.QueryString["kb_oivotunhien"]);
         kcb_khoasan.data("kb_bamoi", Request.QueryString["kb_bamoi"]);
         kcb_khoasan.data("kb_mausacnuocoi", Request.QueryString["kb_mausacnuocoi"]);
         kcb_khoasan.data("kb_luongnuocoi", Request.QueryString["kb_luongnuocoi"]);
         kcb_khoasan.data("kb_ngoi", Request.QueryString["kb_ngoi"]);
         kcb_khoasan.data("kb_the", Request.QueryString["kb_the"]);
         kcb_khoasan.data("kb_kieuthe", Request.QueryString["kb_kieuthe"]);
         kcb_khoasan.data("kb_dolotcao", Request.QueryString["kb_dolotcao"]);
         kcb_khoasan.data("kb_dolotchuc", Request.QueryString["kb_dolotchuc"]);
         kcb_khoasan.data("kb_dolotchat", Request.QueryString["kb_dolotchat"]);
         kcb_khoasan.data("kb_dolotlot", Request.QueryString["kb_dolotlot"]);
         kcb_khoasan.data("kb_duongkinhhave", Request.QueryString["kb_duongkinhhave"]);
         kcb_khoasan.data("kb_canlamsan", Request.QueryString["kb_canlamsan"]);
         kcb_khoasan.data("kb_chandoankhivaokhoa", Request.QueryString["kb_chandoankhivaokhoa"]);
         kcb_khoasan.data("kb_phanbiet", Request.QueryString["kb_phanbiet"]);
         kcb_khoasan.data("kb_tienluong", Request.QueryString["kb_tienluong"]);
         kcb_khoasan.data("kb_huongdieutri", Request.QueryString["kb_huongdieutri"]);
         kcb_khoasan.data("kb_phuongphapchinh", Request.QueryString["kb_phuongphapchinh"]);
         kcb_khoasan.data("td_vaobuongdeluc", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["td_giovaobuongdeluc"]) ? "00" : Request.QueryString["td_giovaobuongdeluc"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["td_phutvaobuongdeluc"]) ? "00" : Request.QueryString["td_phutvaobuongdeluc"]) + " " + Request.QueryString["td_vaobuongdeluc"], "datetime"));
         kcb_khoasan.data("td_idnguoitheodoi", Request.QueryString["td_idnguoitheodoi"]);
         kcb_khoasan.data("td_chudanhnguoitheodoi", Request.QueryString["td_chudanhnguoitheodoi"]);
         kcb_khoasan.data("td_deluc", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["td_giodeluc"]) ? "00" : Request.QueryString["td_giodeluc"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["td_phutdeluc"]) ? "00" : Request.QueryString["td_phutdeluc"]) + " " + Request.QueryString["td_deluc"], "datetime"));
         kcb_khoasan.data("td_apgar1phut", Request.QueryString["td_apgar1phut"]);
         kcb_khoasan.data("td_apgar5phut", Request.QueryString["td_apgar5phut"]);
         kcb_khoasan.data("td_apgar10phut", Request.QueryString["td_apgar10phut"]);
         kcb_khoasan.data("td_cannang", Request.QueryString["td_cannang"]);
         kcb_khoasan.data("td_cao", Request.QueryString["td_cao"]);
         kcb_khoasan.data("td_vongdau", Request.QueryString["td_vongdau"]);
         kcb_khoasan.data("td_donthaitrai", Request.QueryString["td_donthaitrai"]);
         kcb_khoasan.data("td_donthaigai", Request.QueryString["td_donthaigai"]);
         kcb_khoasan.data("td_dathaitrai", Request.QueryString["td_dathaitrai"]);
         kcb_khoasan.data("td_dathaigai", Request.QueryString["td_dathaigai"]);
         kcb_khoasan.data("td_tatbamsinh", Request.QueryString["td_tatbamsinh"]);
         kcb_khoasan.data("td_cohaumon", Request.QueryString["td_cohaumon"]);
         kcb_khoasan.data("td_cuthetatbamsinh", Request.QueryString["td_cuthetatbamsinh"]);
         kcb_khoasan.data("td_tinhtrang", Request.QueryString["td_tinhtrang"]);
         kcb_khoasan.data("td_xuly", Request.QueryString["td_xuly"]);
         kcb_khoasan.data("td_rauboc", Request.QueryString["td_rauboc"]);
         kcb_khoasan.data("td_rauso", Request.QueryString["td_rauso"]);
         kcb_khoasan.data("td_rausoluc", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["td_giorausoluc"]) ? "00" : Request.QueryString["td_giorausoluc"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["td_phutrausoluc"]) ? "00" : Request.QueryString["td_phutrausoluc"]) + " " + Request.QueryString["td_rausoluc"], "datetime"));
         kcb_khoasan.data("td_cachsorau", Request.QueryString["td_cachsorau"]);
         kcb_khoasan.data("td_matmang", Request.QueryString["td_matmang"]);
         kcb_khoasan.data("td_matmui", Request.QueryString["td_matmui"]);
         kcb_khoasan.data("td_banhrau", Request.QueryString["td_banhrau"]);
         kcb_khoasan.data("td_raucannang", Request.QueryString["td_raucannang"]);
         kcb_khoasan.data("td_raucuonco", Request.QueryString["td_raucuonco"]);
         kcb_khoasan.data("td_cuongraudai", Request.QueryString["td_cuongraudai"]);
         kcb_khoasan.data("td_rauchaymau", Request.QueryString["td_rauchaymau"]);
         kcb_khoasan.data("td_luongmau", Request.QueryString["td_luongmau"]);
         kcb_khoasan.data("td_kiemsoatucung", Request.QueryString["td_kiemsoatucung"]);
         kcb_khoasan.data("td_xulyketqua", Request.QueryString["td_xulyketqua"]);
         kcb_khoasan.data("td_niemmac", Request.QueryString["td_niemmac"]);
         kcb_khoasan.data("td_degiuong", Request.QueryString["td_degiuong"]);
         kcb_khoasan.data("td_forceps", Request.QueryString["td_forceps"]);
         kcb_khoasan.data("td_giachut", Request.QueryString["td_giachut"]);
         kcb_khoasan.data("td_PT", Request.QueryString["td_PT"]);
         kcb_khoasan.data("td_dechihuy", Request.QueryString["td_dechihuy"]);
         kcb_khoasan.data("td_khac", Request.QueryString["td_khac"]);
         kcb_khoasan.data("td_lydocanthiep", Request.QueryString["td_lydocanthiep"]);
         kcb_khoasan.data("td_khongrachtangsinhmon", Request.QueryString["td_khongrachtangsinhmon"]);
         kcb_khoasan.data("td_rachtangsinhmon", Request.QueryString["td_rachtangsinhmon"]);
         kcb_khoasan.data("td_cattangsinhmon", Request.QueryString["td_cattangsinhmon"]);
         kcb_khoasan.data("td_phuongphapkhau", Request.QueryString["td_phuongphapkhau"]);
         kcb_khoasan.data("td_somuikhau", Request.QueryString["td_somuikhau"]);
         kcb_khoasan.data("td_khongrachcotucung", Request.QueryString["td_khongrachcotucung"]);
         kcb_khoasan.data("td_rachcotucung", Request.QueryString["td_rachcotucung"]);
         kcb_khoasan.data("td_chandoantruocphauthuat", Request.QueryString["td_chandoantruocphauthuat"]);
         kcb_khoasan.data("td_chandoansauphauthuat", Request.QueryString["td_chandoansauphauthuat"]);
         kcb_khoasan.data("td_taibienPT", Request.QueryString["td_taibienPT"]);
         kcb_khoasan.data("td_bienchung", Request.QueryString["td_bienchung"]);
         kcb_khoasan.data("td_doPT", Request.QueryString["td_doPT"]);
         kcb_khoasan.data("td_dogayme", Request.QueryString["td_dogayme"]);
         kcb_khoasan.data("td_donhiemkhuan", Request.QueryString["td_donhiemkhuan"]);
         kcb_khoasan.data("td_lydokhac", Request.QueryString["td_lydokhac"]);
         kcb_khoasan.data("td_huongdieutri", Request.QueryString["td_huongdieutri"]);
         return kcb_khoasan;
     }
     protected DataProcess s_KCB_PhuongPhapDieuTri()
     {
         DataProcess KCB_PhuongPhapDieuTri = new DataProcess("KCB_PhuongPhapDieuTri");
         KCB_PhuongPhapDieuTri.data("idphuongphapdieutri", Request.QueryString["idkhoachinh"]);
         KCB_PhuongPhapDieuTri.data("idkcbkhoasan", Request.QueryString["idkcbkhoasan"]);
         KCB_PhuongPhapDieuTri.data("thoigiandieutri", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giodieutri"]) ? "00" : Request.QueryString["giodieutri"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutdieutri"]) ? "00" : Request.QueryString["phutdieutri"]) + " " + Request.QueryString["thoigiandieutri"], "datetime"));
         KCB_PhuongPhapDieuTri.data("phuongphap", Request.QueryString["phuongphap"]);
         KCB_PhuongPhapDieuTri.data("bacsiphauthuat", Request.QueryString["bacsiphauthuat"]);
         KCB_PhuongPhapDieuTri.data("bacsigayme", Request.QueryString["bacsigayme"]);
         return KCB_PhuongPhapDieuTri;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": Savekcb_khoasan(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": Xoakcb_khoasan(); break;
             case "xoaKCB_PhuongPhapDieuTri": XoaKCB_PhuongPhapDieuTri(); break;
             case "luuTableKCB_PhuongPhapDieuTri": LuuTableKCB_PhuongPhapDieuTri(); break;
             case "loadTableKCB_PhuongPhapDieuTri": loadTableKCB_PhuongPhapDieuTri(); break;
         }
     }
 
     private void Xoakcb_khoasan()
     {
         try
         {
                DataProcess process = s_kcb_khoasan();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkcbkhoasan"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
     private void XoaKCB_PhuongPhapDieuTri()
     {
         try
         {
             DataProcess process = new DataProcess("KCB_PhuongPhapDieuTri");
             process.data("idkcbkhoasan", Request.QueryString["idkcbkhoasan"]);
             bool ok = process.Delete();
             if (ok)
             {
                 Response.Clear(); Response.Write(process.getData("idkcbkhoasan"));
                 return;
             }
         }
         catch
         {
         }
         Response.StatusCode = 500;
     }
 
     private void setTimKiem()
     {
         string idkhoachinh = Request.QueryString["idkhambenhgoc"].ToString();
         DataTable table = DataAcess.Connect.GetTable(@"select 
            RIGHT( CONVERT(VARCHAR(13),ngayvaovien,120),2) as giovaovien,RIGHT( CONVERT(VARCHAR(16),ngayvaovien,120),2) as phutvaovien,
            RIGHT( CONVERT(VARCHAR(13),thoigianvaokhoa,120),2) as giovaokhoa,RIGHT( CONVERT(VARCHAR(16),thoigianvaokhoa,120),2) as phutvaokhoa,
            RIGHT( CONVERT(VARCHAR(13),thoigianchuyentukhoa,120),2) as giochuyentukhoa,RIGHT( CONVERT(VARCHAR(16),thoigianchuyentukhoa,120),2) as phutchuyentukhoa,
            RIGHT( CONVERT(VARCHAR(13),thoigianchuyentukhoathunhat,120),2) as giochuyentukhoathunhat,RIGHT( CONVERT(VARCHAR(16),thoigianchuyentukhoathunhat,120),2) as phutchuyentukhoathunhat,
            RIGHT( CONVERT(VARCHAR(13),thoigianchuyentukhoathuhai,120),2) as giochuyentukhoathuhai,RIGHT( CONVERT(VARCHAR(16),thoigianchuyentukhoathuhai,120),2) as phutchuyentukhoathuhai,
            RIGHT( CONVERT(VARCHAR(13),ngayravien,120),2) as gioravien,RIGHT( CONVERT(VARCHAR(16),ngayravien,120),2) as phutravien,
            RIGHT( CONVERT(VARCHAR(13),tt_thoigiantuvong,120),2) as tt_giotuvong,RIGHT( CONVERT(VARCHAR(16),tt_thoigiantuvong,120),2) as tt_phuttuvong,
            RIGHT( CONVERT(VARCHAR(13),kb_thoigianoivo,120),2) as giooivo,RIGHT( CONVERT(VARCHAR(16),kb_thoigianoivo,120),2) as phutoivo,
            RIGHT( CONVERT(VARCHAR(13),td_vaobuongdeluc,120),2) as td_giovaobuongdeluc,RIGHT( CONVERT(VARCHAR(16),td_vaobuongdeluc,120),2) as td_phutvaobuongdeluc,
            RIGHT( CONVERT(VARCHAR(13),td_deluc,120),2) as td_giodeluc,RIGHT( CONVERT(VARCHAR(16),td_deluc,120),2) as td_phutdeluc,
            RIGHT( CONVERT(VARCHAR(13),td_rausoluc,120),2) as td_giorausoluc,RIGHT( CONVERT(VARCHAR(16),td_rausoluc,120),2) as td_phutrausoluc,
             A.*,B.LYDO AS lydovaovien from kcb_khoasan A
            LEFT JOIN KHAMBENH C ON C.idkhambenh=A.idkhambenh
            LEFT JOIN DANGKYKHAM B ON B.IDBENHNHAN=C.IDBENHNHAN
            where A.idkhambenh='" + idkhoachinh+"'");
          string html = ""; html += "<root>";
          
         html += Environment.NewLine;
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 html += "<data id=\"idkcbkhoasan\">" + table.Rows[0]["idkcbkhoasan"] + "</data>";
                 for (int y = 0; y < table.Columns.Count; y++)
                 {
                     try
                     {
                         html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
                     }
                     catch (Exception)
                     {
                         html += "<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>";
                     }
                     html += Environment.NewLine;
                 }
             }
         }
         html += "</root>";
         Response.Clear();
         Response.Write(html);
     }
 

     private void Savekcb_khoasan()
     {
         try
         {
             DataProcess process = s_kcb_khoasan();
             if (process.getData("idkcbkhoasan") != null && process.getData("idkcbkhoasan") != "")
             {
                 bool ok = process.Update();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idkcbkhoasan"));
                     return;
                 }
             }
             else
             {
                 bool ok = process.Insert();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idkcbkhoasan"));
                     return;
                 }
             }
         }
         catch { }
         Response.StatusCode = 500;

     }
     public void LuuTableKCB_PhuongPhapDieuTri()
     {
         try
         {
             DataProcess process = s_KCB_PhuongPhapDieuTri();
             if (process.getData("idphuongphapdieutri") != null && process.getData("idphuongphapdieutri") != "")
             {
                 bool ok = process.Update();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idphuongphapdieutri"));
                     return;
                 }
             }
             else
             {
                 bool ok = process.Insert();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idphuongphapdieutri"));
                     return;
                 }
             }
         }
         catch
         {
         }
         Response.StatusCode = 500;
     }
     public void loadTableKCB_PhuongPhapDieuTri()
     {
         DataProcess process = s_KCB_PhuongPhapDieuTri();
         process.Page = Request.QueryString["page"];
         DataTable table = process.Search(@"select STT=row_number() over (order by T.idphuongphapdieutri),T.*
                ,RIGHT( CONVERT(VARCHAR(13),thoigiandieutri,120),2) as giodieutri,RIGHT( CONVERT(VARCHAR(16),thoigiandieutri,120),2) as phutdieutri                   
                ,A.idkhambenh
                               from KCB_PhuongPhapDieuTri T
                    left join kcb_khoasan  A on T.idkcbkhoasan=A.idkcbkhoasan
          where T.idkcbkhoasan='" + process.getData("idkcbkhoasan") + "'");
         string html = "";
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
         html += "<th>STT</th>";
         html += "<th></th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thoigiandieutri") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("phuongphap") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("bacsiphauthuat") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("bacsigayme") + "</th>";
         html += "<th></th>";
         html += "</tr>";
         if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
                 html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                 html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                 if (table.Rows[i]["thoigiandieutri"].ToString() != "")
                 {
                     html += "<td  style='width:230px'><input mkv='true' id='giodieutri' onfocus='chuyendong(this);' type='text'  style='width:10%' value='" + table.Rows[i]["giodieutri"] + "'/><input mkv='true' onfocus='chuyendong(this);' id='phutdieutri' type='text'  style='width:10%' value='" + table.Rows[i]["phutdieutri"] + "'/><input mkv='true' id='thoigiandieutri' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + DateTime.Parse(table.Rows[i]["thoigiandieutri"].ToString()).ToString("dd/MM/yyyy") + "' onblur='TestDate(this)' /></td>";
                 }
                 else
                 {
                     html += "<td  style='width:230px'><input mkv='true' id='giodieutri' onfocus='chuyendong(this);' type='text'  style='width:10%' value='" + table.Rows[i]["giodieutri"] + "'/><input mkv='true' onfocus='chuyendong(this);' id='phutdieutri' type='text'  style='width:10%' value='" + table.Rows[i]["phutdieutri"] + "'/><input mkv='true' id='thoigiandieutri' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + table.Rows[i]["thoigiandieutri"].ToString() + "' onblur='TestDate(this)' /></td>";
                 }
                 html += "<td><input mkv='true' id='phuongphap' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["phuongphap"].ToString() + "' /></td>";
                 html += "<td><input mkv='true' id='bacsiphauthuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["bacsiphauthuat"].ToString() + "' /></td>";
                 html += "<td><input mkv='true' id='bacsigayme' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["bacsigayme"].ToString() + "' /></td>";
                 html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idphuongphapdieutri"].ToString() + "'/></td>";
                 html += "</tr>";
             }
         }
         else
         {
             html += "<tr>";
             html += "<td>1</td>";
             html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
             html += "<td  style='width:230px'><input mkv='true' id='giodieutri' onfocus='chuyendong(this);' type='text'  style='width:10%'/><input mkv='true' onfocus='chuyendong(this);' id='phutdieutri' type='text'  style='width:10%'/><input mkv='true' id='thoigiandieutri' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)'/></td>";
             html += "<td><input mkv='true' id='phuongphap' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
             html += "<td><input mkv='true' id='bacsiphauthuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
             html += "<td><input mkv='true' id='bacsigayme' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
             html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
             html += "</tr>";
         }
         html += "<tr><td></td><td></td></tr>";
         html += "</table>";
         html += process.Paging("KCB_PhuongPhapDieuTri");
         Response.Clear(); Response.Write(html);
     }
 }
 
 
