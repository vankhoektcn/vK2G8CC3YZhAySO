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
 
 public partial class kcb_sosinh_ajax : System.Web.UI.Page
 {
     protected DataProcess s_kcb_sosinh()
     {
             DataProcess kcb_sosinh = new DataProcess("kcb_sosinh");
             kcb_sosinh.data("idkcbsosinh", Request.QueryString["idkcbsosinh"]);
             kcb_sosinh.data("idkhambenh",Request.QueryString["idkhambenhgoc"]);
             kcb_sosinh.data("idbacsi", Request.QueryString["idbacsi"]);
             kcb_sosinh.data("ngayvaovien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaovien"]) ? "00" : Request.QueryString["giovaovien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaovien"]) ? "00" : Request.QueryString["phutvaovien"]) + " " + Request.QueryString["ngayvaovien"], "datetime"));
             kcb_sosinh.data("tructiepvaocapcuu", Request.QueryString["tructiepvaocapcuu"]);
             kcb_sosinh.data("tructiepvaoKKB", Request.QueryString["tructiepvaoKKB"]);
             kcb_sosinh.data("tructiepvaokhoa", Request.QueryString["tructiepvaokhoa"]);
             kcb_sosinh.data("coquangioithieu", Request.QueryString["coquangioithieu"]);
             kcb_sosinh.data("tuden", Request.QueryString["tuden"]);
             kcb_sosinh.data("khac", Request.QueryString["khac"]);
             kcb_sosinh.data("vaovienlan", Request.QueryString["vaovienlan"]);
             kcb_sosinh.data("vaokhoa", Request.QueryString["vaokhoa"]);
             kcb_sosinh.data("thoigianvaokhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaokhoa"]) ? "00" : Request.QueryString["giovaokhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaokhoa"]) ? "00" : Request.QueryString["phutvaokhoa"]) + " " + Request.QueryString["thoigianvaokhoa"], "datetime"));
             kcb_sosinh.data("songaydieutri", Request.QueryString["songaydieutri"]);
             kcb_sosinh.data("chuyentukhoa", Request.QueryString["chuyentukhoa"]);
             kcb_sosinh.data("thoigianchuyentukhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoa"]) ? "00" : Request.QueryString["giochuyentukhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoa"]) ? "00" : Request.QueryString["phutchuyentukhoa"]) + " " + Request.QueryString["thoigianchuyentukhoa"], "datetime"));
             kcb_sosinh.data("songaydieutritukhoa", Request.QueryString["songaydieutritukhoa"]);
             kcb_sosinh.data("denkhoathunhat", Request.QueryString["denkhoathunhat"]);
             kcb_sosinh.data("thoigianchuyentukhoathunhat", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathunhat"]) ? "00" : Request.QueryString["giochuyentukhoathunhat"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathunhat"]) ? "00" : Request.QueryString["phutchuyentukhoathunhat"]) + " " + Request.QueryString["thoigianchuyentukhoathunhat"], "datetime"));
             kcb_sosinh.data("songaydieutrikhoathunhat", Request.QueryString["songaydieutrikhoathunhat"]);
             kcb_sosinh.data("denkhoathuhai", Request.QueryString["denkhoathuhai"]);
             kcb_sosinh.data("thoigianchuyentukhoathuhai", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathuhai"]) ? "00" : Request.QueryString["giochuyentukhoathuhai"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathuhai"]) ? "00" : Request.QueryString["phutchuyentukhoathuhai"]) + " " + Request.QueryString["thoigianchuyentukhoathuhai"], "datetime"));
             kcb_sosinh.data("songaydieutrikhoathuhai", Request.QueryString["songaydieutrikhoathuhai"]);
             kcb_sosinh.data("chuyenvientuyentren", Request.QueryString["chuyenvientuyentren"]);
             kcb_sosinh.data("chuyenvientuyenduoi", Request.QueryString["chuyenvientuyenduoi"]);
             kcb_sosinh.data("chuyenvienCK", Request.QueryString["chuyenvienCK"]);
             kcb_sosinh.data("chuyenvienden", Request.QueryString["chuyenvienden"]);
             kcb_sosinh.data("ngayravien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["gioravien"]) ? "00" : Request.QueryString["gioravien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutravien"]) ? "00" : Request.QueryString["phutravien"]) + " " + Request.QueryString["ngayravien"], "datetime"));
             kcb_sosinh.data("ravien", Request.QueryString["ravien"]);
             kcb_sosinh.data("xinve", Request.QueryString["xinve"]);
             kcb_sosinh.data("bove", Request.QueryString["bove"]);
             kcb_sosinh.data("duave", Request.QueryString["duave"]);
             kcb_sosinh.data("tongsongaydieutri",Request.QueryString["tongsongaydieutri"]);
             kcb_sosinh.data("cd_noichuyenden",Request.QueryString["cd_noichuyenden"]);
             kcb_sosinh.data("cd_manoichuyenden",Request.QueryString["cd_manoichuyenden"]);
             kcb_sosinh.data("cd_noiKKBCapCuu",Request.QueryString["cd_noiKKBCapCuu"]);
             kcb_sosinh.data("cd_manoiKKBCapCuu",Request.QueryString["cd_manoiKKBCapCuu"]);
             kcb_sosinh.data("cd_khivaokhoadieutri",Request.QueryString["cd_khivaokhoadieutri"]);
             kcb_sosinh.data("cd_makhoadieutri",Request.QueryString["cd_makhoadieutri"]);
             kcb_sosinh.data("cd_thuthuat",Request.QueryString["cd_thuthuat"]);
             kcb_sosinh.data("cd_phauthuat",Request.QueryString["cd_phauthuat"]);
             kcb_sosinh.data("cd_benhchinh",Request.QueryString["cd_benhchinh"]);
             kcb_sosinh.data("cd_mabenhchinh",Request.QueryString["cd_mabenhchinh"]);
             kcb_sosinh.data("cd_benhkemtheo",Request.QueryString["cd_benhkemtheo"]);
             kcb_sosinh.data("cd_mabenhkemtheo",Request.QueryString["cd_mabenhkemtheo"]);
             kcb_sosinh.data("cd_taibien",Request.QueryString["cd_taibien"]);
             kcb_sosinh.data("cd_bienchung",Request.QueryString["cd_bienchung"]);
             kcb_sosinh.data("tt_khoi",Request.QueryString["tt_khoi"]);
             kcb_sosinh.data("tt_giam",Request.QueryString["tt_giam"]);
             kcb_sosinh.data("tt_khongthaydoi",Request.QueryString["tt_khongthaydoi"]);
             kcb_sosinh.data("tt_nanghon",Request.QueryString["tt_nanghon"]);
             kcb_sosinh.data("tt_tuvong",Request.QueryString["tt_tuvong"]);
             kcb_sosinh.data("tt_lanhtinh",Request.QueryString["tt_lanhtinh"]);
             kcb_sosinh.data("tt_nghingo",Request.QueryString["tt_nghingo"]);
             kcb_sosinh.data("tt_actinh",Request.QueryString["tt_actinh"]);
             kcb_sosinh.data("tt_thoigiantuvong", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["tt_giotuvong"]) ? "00" : Request.QueryString["tt_giotuvong"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["tt_phuttuvong"]) ? "00" : Request.QueryString["tt_phuttuvong"]) + " " + Request.QueryString["tt_thoigiantuvong"], "datetime"));
             kcb_sosinh.data("tt_tuvongdobenh",Request.QueryString["tt_tuvongdobenh"]);
             kcb_sosinh.data("tt_tuvongdotaibien",Request.QueryString["tt_tuvongdotaibien"]);
             kcb_sosinh.data("tt_tuvongkhac",Request.QueryString["tt_tuvongkhac"]);
             kcb_sosinh.data("tt_tuvongtrong24h",Request.QueryString["tt_tuvongtrong24h"]);
             kcb_sosinh.data("tt_tuvongsau24h",Request.QueryString["tt_tuvongsau24h"]);
             kcb_sosinh.data("tt_nguyennhantuvong",Request.QueryString["tt_nguyennhantuvong"]);
             kcb_sosinh.data("tt_manguyennhantuvong",Request.QueryString["tt_manguyennhantuvong"]);
             kcb_sosinh.data("tt_khamtuthi",Request.QueryString["tt_khamtuthi"]);
             kcb_sosinh.data("tt_chandoangiaiphaututhi",Request.QueryString["tt_chandoangiaiphaututhi"]);
             kcb_sosinh.data("tt_magiaiphaututhi",Request.QueryString["tt_magiaiphaututhi"]);
             kcb_sosinh.data("hb_dienbienbenh",Request.QueryString["hb_dienbienbenh"]);
             kcb_sosinh.data("hb_oivo",Request.QueryString["hb_oivo"]);
             kcb_sosinh.data("hb_ngayoivo", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["hb_giooivo"]) ? "00" : Request.QueryString["hb_giooivo"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["hb_phutoivo"]) ? "00" : Request.QueryString["hb_phutoivo"]) + " " + Request.QueryString["hb_ngayoivo"], "datetime"));
             kcb_sosinh.data("hb_mausac",Request.QueryString["hb_mausac"]);
             kcb_sosinh.data("hb_dethuong",Request.QueryString["hb_dethuong"]);
             kcb_sosinh.data("hb_canthiep",Request.QueryString["hb_canthiep"]);
             kcb_sosinh.data("hb_ngayde", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["hb_giode"]) ? "00" : Request.QueryString["hb_giode"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["hb_phutde"]) ? "00" : Request.QueryString["hb_phutde"]) + " " + Request.QueryString["hb_ngayde"], "datetime"));
             kcb_sosinh.data("hb_lydocanthiep",Request.QueryString["hb_lydocanthiep"]);
             kcb_sosinh.data("hb_ttradoi_khocngay",Request.QueryString["hb_ttradoi_khocngay"]);
             kcb_sosinh.data("hb_ttradoi_ngat",Request.QueryString["hb_ttradoi_ngat"]);
             kcb_sosinh.data("hb_ttradoi_khac",Request.QueryString["hb_ttradoi_khac"]);
             kcb_sosinh.data("hb_hotennguoidobenh",Request.QueryString["hb_hotennguoidobenh"]);
             kcb_sosinh.data("hb_apgar1phut",Request.QueryString["hb_apgar1phut"]);
             kcb_sosinh.data("hb_apgar5phut",Request.QueryString["hb_apgar5phut"]);
             kcb_sosinh.data("hb_apgar10phut",Request.QueryString["hb_apgar10phut"]);
             kcb_sosinh.data("hb_cannang",Request.QueryString["hb_cannang"]);
             kcb_sosinh.data("hb_ttdinhduongsausinh",Request.QueryString["hb_ttdinhduongsausinh"]);
             kcb_sosinh.data("hb_hs_hutdich",Request.QueryString["hb_hs_hutdich"]);
             kcb_sosinh.data("hb_hs_xoaboptim",Request.QueryString["hb_hs_xoaboptim"]);
             kcb_sosinh.data("hb_hs_theoxy",Request.QueryString["hb_hs_theoxy"]);
             kcb_sosinh.data("hb_hs_noikhiquan",Request.QueryString["hb_hs_noikhiquan"]);
             kcb_sosinh.data("hb_hs_bapbangoxy",Request.QueryString["hb_hs_bapbangoxy"]);
             kcb_sosinh.data("hb_hs_khac",Request.QueryString["hb_hs_khac"]);
             kcb_sosinh.data("kb_hotennguoichuyen",Request.QueryString["kb_hotennguoichuyen"]);
             kcb_sosinh.data("kb_ditatbamsinh",Request.QueryString["kb_ditatbamsinh"]);
             kcb_sosinh.data("kb_cohaumon",Request.QueryString["kb_cohaumon"]);
             kcb_sosinh.data("kb_cutheditat",Request.QueryString["kb_cutheditat"]);
             kcb_sosinh.data("kb_tinhhinhvaokhoa",Request.QueryString["kb_tinhhinhvaokhoa"]);
             kcb_sosinh.data("kb_th_can",Request.QueryString["kb_th_can"]);
             kcb_sosinh.data("kb_th_chieudai",Request.QueryString["kb_th_chieudai"]);
             kcb_sosinh.data("kb_th_vongdau",Request.QueryString["kb_th_vongdau"]);
             kcb_sosinh.data("kb_tinhtrangtoanthan",Request.QueryString["kb_tinhtrangtoanthan"]);
             kcb_sosinh.data("kb_tt_nhietdo",Request.QueryString["kb_tt_nhietdo"]);
             kcb_sosinh.data("kb_tt_nhiptho",Request.QueryString["kb_tt_nhiptho"]);
             kcb_sosinh.data("kb_sd_honghao",Request.QueryString["kb_sd_honghao"]);
             kcb_sosinh.data("kb_sd_xanhtai",Request.QueryString["kb_sd_xanhtai"]);
             kcb_sosinh.data("kb_sd_vang",Request.QueryString["kb_sd_vang"]);
             kcb_sosinh.data("kb_sd_tim",Request.QueryString["kb_sd_tim"]);
             kcb_sosinh.data("kb_sd_khac",Request.QueryString["kb_sd_khac"]);
             kcb_sosinh.data("kb_hh_nhiptho",Request.QueryString["kb_hh_nhiptho"]);
             kcb_sosinh.data("kb_hh_nghephoi",Request.QueryString["kb_hh_nghephoi"]);
             kcb_sosinh.data("kb_hh_sosilverman",Request.QueryString["kb_hh_sosilverman"]);
             kcb_sosinh.data("kb_tm_nhiptim",Request.QueryString["kb_tm_nhiptim"]);
             kcb_sosinh.data("kb_bung",Request.QueryString["kb_bung"]);
             kcb_sosinh.data("kb_sinhducngoai",Request.QueryString["kb_sinhducngoai"]);
             kcb_sosinh.data("kb_xuongkhop",Request.QueryString["kb_xuongkhop"]);
             kcb_sosinh.data("kb_tk_phanxa",Request.QueryString["kb_tk_phanxa"]);
             kcb_sosinh.data("kb_tk_truongcoluc",Request.QueryString["kb_tk_truongcoluc"]);
             kcb_sosinh.data("kb_xetnghiemcls",Request.QueryString["kb_xetnghiemcls"]);
             kcb_sosinh.data("kb_tomtatbenhan",Request.QueryString["kb_tomtatbenhan"]);
             kcb_sosinh.data("kb_chidinhtheodoi",Request.QueryString["kb_chidinhtheodoi"]);
             kcb_sosinh.data("tk_quatrinhbenhly",Request.QueryString["tk_quatrinhbenhly"]);
             kcb_sosinh.data("tk_ketquacanlamsan",Request.QueryString["tk_ketquacanlamsan"]);
             kcb_sosinh.data("tk_phuongphapdieutri",Request.QueryString["tk_phuongphapdieutri"]);
             kcb_sosinh.data("tk_tinhtrangravien",Request.QueryString["tk_tinhtrangravien"]);
             kcb_sosinh.data("tk_huongdieutritieptheo",Request.QueryString["tk_huongdieutritieptheo"]);
            return kcb_sosinh;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": Savekcb_sosinh(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": Xoakcb_sosinh(); break;
         }
     }
 
     private void Xoakcb_sosinh()
     {
         try
         {
                DataProcess process = s_kcb_sosinh();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkcbsosinh"));
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
            RIGHT( CONVERT(VARCHAR(13),hb_ngayoivo,120),2) as hb_giooivo,RIGHT( CONVERT(VARCHAR(16),hb_ngayoivo,120),2) as hb_phutoivo,
            RIGHT( CONVERT(VARCHAR(13),hb_ngayde,120),2) as hb_giode,RIGHT( CONVERT(VARCHAR(16),hb_ngayde,120),2) as hb_phutde,
            
             A.*,B.LYDO AS lydovaovien from kcb_sosinh A
            LEFT JOIN KHAMBENH C ON C.idkhambenh=A.idkhambenh
            LEFT JOIN DANGKYKHAM B ON B.IDBENHNHAN=C.IDBENHNHAN
            where A.idkhambenh='" + idkhoachinh + "'");
         string html = ""; html += "<root>";
         html += Environment.NewLine;
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 html += "<data id=\"idkcbsosinh\">" + table.Rows[0]["idkcbsosinh"] + "</data>";
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
 
  
     private void Savekcb_sosinh()
     {
         try
         {
              DataProcess process = s_kcb_sosinh();
             if (process.getData("idkcbsosinh") != null && process.getData("idkcbsosinh") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkcbsosinh"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkcbsosinh"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 }
 
 
