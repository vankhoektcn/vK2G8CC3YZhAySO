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

public partial class kcb_phukhoa_ajax : System.Web.UI.Page
 {
     protected DataProcess s_kcb_phukhoa()
     {
         DataProcess kcb_phukhoa = new DataProcess("kcb_phukhoa");
         kcb_phukhoa.data("idkcbphukhoa", Request.QueryString["idkcbphukhoa"]);
         kcb_phukhoa.data("idkhambenh", Request.QueryString["idkhambenhgoc"]);
         kcb_phukhoa.data("idbacsi", Request.QueryString["idbacsi"]);
         kcb_phukhoa.data("ngayvaovien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaovien"]) ? "00" : Request.QueryString["giovaovien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaovien"]) ? "00" : Request.QueryString["phutvaovien"]) + " " + Request.QueryString["ngayvaovien"], "datetime"));
         kcb_phukhoa.data("tructiepvaocapcuu", Request.QueryString["tructiepvaocapcuu"]);
         kcb_phukhoa.data("tructiepvaoKKB", Request.QueryString["tructiepvaoKKB"]);
         kcb_phukhoa.data("tructiepvaokhoa", Request.QueryString["tructiepvaokhoa"]);
         kcb_phukhoa.data("coquangioithieu", Request.QueryString["coquangioithieu"]);
         kcb_phukhoa.data("tuden", Request.QueryString["tuden"]);
         kcb_phukhoa.data("khac", Request.QueryString["khac"]);
         kcb_phukhoa.data("vaovienlan", Request.QueryString["vaovienlan"]);
         kcb_phukhoa.data("vaokhoa", Request.QueryString["vaokhoa"]);
         kcb_phukhoa.data("thoigianvaokhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaokhoa"]) ? "00" : Request.QueryString["giovaokhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaokhoa"]) ? "00" : Request.QueryString["phutvaokhoa"]) + " " + Request.QueryString["thoigianvaokhoa"], "datetime"));
         kcb_phukhoa.data("songaydieutri", Request.QueryString["songaydieutri"]);
         kcb_phukhoa.data("chuyentukhoa", Request.QueryString["chuyentukhoa"]);
         kcb_phukhoa.data("thoigianchuyentukhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoa"]) ? "00" : Request.QueryString["giochuyentukhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoa"]) ? "00" : Request.QueryString["phutchuyentukhoa"]) + " " + Request.QueryString["thoigianchuyentukhoa"], "datetime"));
         kcb_phukhoa.data("songaydieutritukhoa", Request.QueryString["songaydieutritukhoa"]);
         kcb_phukhoa.data("denkhoathunhat", Request.QueryString["denkhoathunhat"]);
         kcb_phukhoa.data("thoigianchuyentukhoathunhat", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathunhat"]) ? "00" : Request.QueryString["giochuyentukhoathunhat"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathunhat"]) ? "00" : Request.QueryString["phutchuyentukhoathunhat"]) + " " + Request.QueryString["thoigianchuyentukhoathunhat"], "datetime"));
         kcb_phukhoa.data("songaydieutrikhoathunhat", Request.QueryString["songaydieutrikhoathunhat"]);
         kcb_phukhoa.data("denkhoathuhai", Request.QueryString["denkhoathuhai"]);
         kcb_phukhoa.data("thoigianchuyentukhoathuhai", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathuhai"]) ? "00" : Request.QueryString["giochuyentukhoathuhai"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathuhai"]) ? "00" : Request.QueryString["phutchuyentukhoathuhai"]) + " " + Request.QueryString["thoigianchuyentukhoathuhai"], "datetime"));
         kcb_phukhoa.data("songaydieutrikhoathuhai", Request.QueryString["songaydieutrikhoathuhai"]);
         kcb_phukhoa.data("chuyenvientuyentren", Request.QueryString["chuyenvientuyentren"]);
         kcb_phukhoa.data("chuyenvientuyenduoi", Request.QueryString["chuyenvientuyenduoi"]);
         kcb_phukhoa.data("chuyenvienCK", Request.QueryString["chuyenvienCK"]);
         kcb_phukhoa.data("chuyenvienden", Request.QueryString["chuyenvienden"]);
         kcb_phukhoa.data("ngayravien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["gioravien"]) ? "00" : Request.QueryString["gioravien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutravien"]) ? "00" : Request.QueryString["phutravien"]) + " " + Request.QueryString["ngayravien"], "datetime"));
         kcb_phukhoa.data("ravien", Request.QueryString["ravien"]);
         kcb_phukhoa.data("xinve", Request.QueryString["xinve"]);
         kcb_phukhoa.data("bove", Request.QueryString["bove"]);
         kcb_phukhoa.data("duave", Request.QueryString["duave"]);
         kcb_phukhoa.data("tongsongaydieutri", Request.QueryString["tongsongaydieutri"]);
         kcb_phukhoa.data("cd_noichuyenden", Request.QueryString["cd_noichuyenden"]);
         kcb_phukhoa.data("cd_manoichuyenden", Request.QueryString["cd_manoichuyenden"]);
         kcb_phukhoa.data("cd_noiKKBCapCuu", Request.QueryString["cd_noiKKBCapCuu"]);
         kcb_phukhoa.data("cd_manoiKKBCapCuu", Request.QueryString["cd_manoiKKBCapCuu"]);
         kcb_phukhoa.data("cd_khivaokhoadieutri", Request.QueryString["cd_khivaokhoadieutri"]);
         kcb_phukhoa.data("cd_makhoadieutri", Request.QueryString["cd_makhoadieutri"]);
         kcb_phukhoa.data("cd_taibien", Request.QueryString["cd_taibien"]);
         kcb_phukhoa.data("cd_bienchung", Request.QueryString["cd_bienchung"]);
         kcb_phukhoa.data("cd_dophauthuat", Request.QueryString["cd_dophauthuat"]);
         kcb_phukhoa.data("cd_dogayme", Request.QueryString["cd_dogayme"]);
         kcb_phukhoa.data("cd_donhiemkhuan", Request.QueryString["cd_donhiemkhuan"]);
         kcb_phukhoa.data("cd_khac", Request.QueryString["cd_khac"]);
         kcb_phukhoa.data("cd_tongsongaydieutrisauphauthuat", Request.QueryString["cd_tongsongaydieutrisauphauthuat"]);
         kcb_phukhoa.data("cd_tongsolanphauthuat", Request.QueryString["cd_tongsolanphauthuat"]);
         kcb_phukhoa.data("cd_benhchinh", Request.QueryString["cd_benhchinh"]);
         kcb_phukhoa.data("cd_mabenhchinh", Request.QueryString["cd_mabenhchinh"]);
         kcb_phukhoa.data("cd_nguyennhanbenhchinh", Request.QueryString["cd_nguyennhanbenhchinh"]);
         kcb_phukhoa.data("cd_manguyennhanbenhchinh", Request.QueryString["cd_manguyennhanbenhchinh"]);
         kcb_phukhoa.data("cd_benhkemtheo", Request.QueryString["cd_benhkemtheo"]);
         kcb_phukhoa.data("cd_mabenhkemtheo", Request.QueryString["cd_mabenhkemtheo"]);
         kcb_phukhoa.data("cd_chandoantruocphauthuat", Request.QueryString["cd_chandoantruocphauthuat"]);
         kcb_phukhoa.data("cd_machandoantruocphauthuat", Request.QueryString["cd_machandoantruocphauthuat"]);
         kcb_phukhoa.data("cd_chandoansauphauthuat", Request.QueryString["cd_chandoansauphauthuat"]);
         kcb_phukhoa.data("cd_machandoansauphauthuat", Request.QueryString["cd_machandoansauphauthuat"]);
         kcb_phukhoa.data("tt_khoi", Request.QueryString["tt_khoi"]);
         kcb_phukhoa.data("tt_giam", Request.QueryString["tt_giam"]);
         kcb_phukhoa.data("tt_khongthaydoi", Request.QueryString["tt_khongthaydoi"]);
         kcb_phukhoa.data("tt_nanghon", Request.QueryString["tt_nanghon"]);
         kcb_phukhoa.data("tt_tuvong", Request.QueryString["tt_tuvong"]);
         kcb_phukhoa.data("tt_lanhtinh", Request.QueryString["tt_lanhtinh"]);
         kcb_phukhoa.data("tt_nghingo", Request.QueryString["tt_nghingo"]);
         kcb_phukhoa.data("tt_actinh", Request.QueryString["tt_actinh"]);
         kcb_phukhoa.data("tt_thoigiantuvong", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["tt_giotuvong"]) ? "00" : Request.QueryString["tt_giotuvong"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["tt_phuttuvong"]) ? "00" : Request.QueryString["tt_phuttuvong"]) + " " + Request.QueryString["tt_thoigiantuvong"], "datetime"));
         kcb_phukhoa.data("tt_tuvongdobenh", Request.QueryString["tt_tuvongdobenh"]);
         kcb_phukhoa.data("tt_tuvongdotaibien", Request.QueryString["tt_tuvongdotaibien"]);
         kcb_phukhoa.data("tt_tuvongkhac", Request.QueryString["tt_tuvongkhac"]);
         kcb_phukhoa.data("tt_tuvongtrong24h", Request.QueryString["tt_tuvongtrong24h"]);
         kcb_phukhoa.data("tt_tuvongtrong48h", Request.QueryString["tt_tuvongtrong48h"]);
         kcb_phukhoa.data("tt_tuvongtrong72h", Request.QueryString["tt_tuvongtrong72h"]);
         kcb_phukhoa.data("tt_nguyennhantuvong", Request.QueryString["tt_nguyennhantuvong"]);
         kcb_phukhoa.data("tt_manguyennhantuvong", Request.QueryString["tt_manguyennhantuvong"]);
         kcb_phukhoa.data("tt_khamtuthi", Request.QueryString["tt_khamtuthi"]);
         kcb_phukhoa.data("tt_chandoangiaiphaututhi", Request.QueryString["tt_chandoangiaiphaututhi"]);
         kcb_phukhoa.data("tt_magiaiphaututhi", Request.QueryString["tt_magiaiphaututhi"]);
         kcb_phukhoa.data("hb_quatrinhbenhly", Request.QueryString["hb_quatrinhbenhly"]);
         kcb_phukhoa.data("hb_tiensubenhbanthan", Request.QueryString["hb_tiensubenhbanthan"]);
         kcb_phukhoa.data("hb_tiensubenhgiadinh", Request.QueryString["hb_tiensubenhgiadinh"]);
         kcb_phukhoa.data("hb_batdauthaykinhnam", Request.QueryString["hb_batdauthaykinhnam"]);
         kcb_phukhoa.data("hb_batdauthaykinhotuoi", Request.QueryString["hb_batdauthaykinhotuoi"]);
         kcb_phukhoa.data("hb_tinhchatkinhnguyet", Request.QueryString["hb_tinhchatkinhnguyet"]);
         kcb_phukhoa.data("hb_chukykinhnguyet", Request.QueryString["hb_chukykinhnguyet"]);
         kcb_phukhoa.data("hb_songaythaykinh", Request.QueryString["hb_songaythaykinh"]);
         kcb_phukhoa.data("hb_luongkinh", Request.QueryString["hb_luongkinh"]);
         kcb_phukhoa.data("hb_kinhlancuoingay", Request.QueryString["hb_kinhlancuoingay"]);
         kcb_phukhoa.data("hb_daubung", Request.QueryString["hb_daubung"]);
         kcb_phukhoa.data("hb_daubungtruoc", Request.QueryString["hb_daubungtruoc"]);
         kcb_phukhoa.data("hb_daubungtrong", Request.QueryString["hb_daubungtrong"]);
         kcb_phukhoa.data("hb_daubungsau", Request.QueryString["hb_daubungsau"]);
         kcb_phukhoa.data("hb_laychongnam", Request.QueryString["hb_laychongnam"]);
         kcb_phukhoa.data("hb_tuoilaychong", Request.QueryString["hb_tuoilaychong"]);
         kcb_phukhoa.data("hb_hetkinhnam", Request.QueryString["hb_hetkinhnam"]);
         kcb_phukhoa.data("hb_hetkinhtuoi", Request.QueryString["hb_hetkinhtuoi"]);
         kcb_phukhoa.data("hb_benhphukhoadieutrikhac", Request.QueryString["hb_benhphukhoadieutrikhac"]);
         kcb_phukhoa.data("hb_tienthaiduthang", Request.QueryString["hb_tienthaiduthang"]);
         kcb_phukhoa.data("hb_tienthaisom", Request.QueryString["hb_tienthaisom"]);
         kcb_phukhoa.data("hb_tienthaisay", Request.QueryString["hb_tienthaisay"]);
         kcb_phukhoa.data("hb_tienthaisong", Request.QueryString["hb_tienthaisong"]);
         kcb_phukhoa.data("kb_daniemmac", Request.QueryString["kb_daniemmac"]);
         kcb_phukhoa.data("kb_hach", Request.QueryString["kb_hach"]);
         kcb_phukhoa.data("kb_vu", Request.QueryString["kb_vu"]);
         kcb_phukhoa.data("kb_tuanhoan", Request.QueryString["kb_tuanhoan"]);
         kcb_phukhoa.data("kb_hohap", Request.QueryString["kb_hohap"]);
         kcb_phukhoa.data("kb_tieuhoa", Request.QueryString["kb_tieuhoa"]);
         kcb_phukhoa.data("kb_thankinh", Request.QueryString["kb_thankinh"]);
         kcb_phukhoa.data("kb_cosuongkhop", Request.QueryString["kb_cosuongkhop"]);
         kcb_phukhoa.data("kb_thantietnieu", Request.QueryString["kb_thantietnieu"]);
         kcb_phukhoa.data("kb_khac", Request.QueryString["kb_khac"]);
         kcb_phukhoa.data("kb_dauhieusinhducthunhat", Request.QueryString["kb_dauhieusinhducthunhat"]);
         kcb_phukhoa.data("kb_moilon", Request.QueryString["kb_moilon"]);
         kcb_phukhoa.data("kb_moibe", Request.QueryString["kb_moibe"]);
         kcb_phukhoa.data("kb_amvat", Request.QueryString["kb_amvat"]);
         kcb_phukhoa.data("kb_amho", Request.QueryString["kb_amho"]);
         kcb_phukhoa.data("kb_mangtrinh", Request.QueryString["kb_mangtrinh"]);
         kcb_phukhoa.data("kb_tangsinhmon", Request.QueryString["kb_tangsinhmon"]);
         kcb_phukhoa.data("kb_amdao", Request.QueryString["kb_amdao"]);
         kcb_phukhoa.data("kb_cotucung", Request.QueryString["kb_cotucung"]);
         kcb_phukhoa.data("kb_thantucung", Request.QueryString["kb_thantucung"]);
         kcb_phukhoa.data("kb_phanphu", Request.QueryString["kb_phanphu"]);
         kcb_phukhoa.data("kb_cactuicung", Request.QueryString["kb_cactuicung"]);
         kcb_phukhoa.data("kb_xetnghiemcanlamsang", Request.QueryString["kb_xetnghiemcanlamsang"]);
         kcb_phukhoa.data("kb_tomtatbenhan", Request.QueryString["kb_tomtatbenhan"]);
         kcb_phukhoa.data("chandoankhivaokhoa", Request.QueryString["chandoankhivaokhoa"]);
         kcb_phukhoa.data("benhchinh", Request.QueryString["benhchinh"]);
         kcb_phukhoa.data("benhkemtheo", Request.QueryString["benhkemtheo"]);
         kcb_phukhoa.data("phanbiet", Request.QueryString["phanbiet"]);
         kcb_phukhoa.data("tienluong", Request.QueryString["tienluong"]);
         kcb_phukhoa.data("huongdieutri", Request.QueryString["huongdieutri"]);
         kcb_phukhoa.data("tk_quatrinhbenhly", Request.QueryString["tk_quatrinhbenhly"]);
         kcb_phukhoa.data("tk_ketquacanlamsan", Request.QueryString["tk_ketquacanlamsan"]);
         kcb_phukhoa.data("tk_phuongphapdieutri", Request.QueryString["tk_phuongphapdieutri"]);
         kcb_phukhoa.data("tk_tinhtrangravien", Request.QueryString["tk_tinhtrangravien"]);
         kcb_phukhoa.data("tk_huongdieutritieptheo", Request.QueryString["tk_huongdieutritieptheo"]);
         kcb_phukhoa.data("tk_idphuongphapdieutri", Request.QueryString["tk_idphuongphapdieutri"]);
         return kcb_phukhoa;
     }
     protected DataProcess s_KCB_PhuongPhapDieuTri()
     {
         DataProcess KCB_PhuongPhapDieuTri = new DataProcess("KCB_PhuongPhapDieuTri");
         KCB_PhuongPhapDieuTri.data("idphuongphapdieutri", Request.QueryString["idkhoachinh"]);
         KCB_PhuongPhapDieuTri.data("idkcbphukhoa", Request.QueryString["idkcbphukhoa"]);
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
             case "Luu": Savekcb_phukhoa(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": Xoakcb_phukhoa(); break;
             case "xoaKCB_PhuongPhapDieuTri": XoaKCB_PhuongPhapDieuTri(); break;
             case "luuTableKCB_PhuongPhapDieuTri": LuuTableKCB_PhuongPhapDieuTri(); break;
             case "loadTableKCB_PhuongPhapDieuTri": loadTableKCB_PhuongPhapDieuTri(); break;
         }
     }
 
     private void Xoakcb_phukhoa()
     {
         try
         {
                DataProcess process = s_kcb_phukhoa();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkcbphukhoa"));
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
             process.data("idkcbphukhoa", Request.QueryString["idkcbphukhoa"]);
             bool ok = process.Delete();
             if (ok)
             {
                 Response.Clear(); Response.Write(process.getData("idkcbphukhoa"));
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
            
             A.*,B.LYDO AS lydovaovien from kcb_phukhoa A
            LEFT JOIN KHAMBENH C ON C.idkhambenh=A.idkhambenh
            LEFT JOIN DANGKYKHAM B ON B.IDBENHNHAN=C.IDBENHNHAN
            where A.idkhambenh='" + idkhoachinh+"'");
          string html = ""; html += "<root>";
          
         html += Environment.NewLine;
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 html += "<data id=\"idkcbphukhoa\">" + table.Rows[0]["idkcbphukhoa"] + "</data>";
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
 

     private void Savekcb_phukhoa()
     {
         try
         {
             DataProcess process = s_kcb_phukhoa();
             if (process.getData("idkcbphukhoa") != null && process.getData("idkcbphukhoa") != "")
             {
                 bool ok = process.Update();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idkcbphukhoa"));
                     return;
                 }
             }
             else
             {
                 bool ok = process.Insert();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idkcbphukhoa"));
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
                    left join kcb_phukhoa  A on T.idkcbphukhoa=A.idkcbphukhoa
          where T.idkcbphukhoa='" + process.getData("idkcbphukhoa") + "'");
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
 
 
