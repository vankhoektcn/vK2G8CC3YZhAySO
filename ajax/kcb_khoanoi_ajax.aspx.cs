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
 
 public partial class kcb_khoanoi_ajax : System.Web.UI.Page
 {
     protected DataProcess s_kcb_khoanoi()
     {
         DataProcess kcb_khoanoi = new DataProcess("kcb_khoanoi");
         kcb_khoanoi.data("idkcbkhoanoi", Request.QueryString["idkcbkhoanoi"]);
         kcb_khoanoi.data("idkhambenh", Request.QueryString["idkhambenhgoc"]);
         kcb_khoanoi.data("idbacsi", Request.QueryString["idbacsi"]);
         kcb_khoanoi.data("ngayvaovien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaovien"]) ? "00" : Request.QueryString["giovaovien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaovien"]) ? "00" : Request.QueryString["phutvaovien"]) + " " + Request.QueryString["ngayvaovien"], "datetime"));
         kcb_khoanoi.data("tructiepvaocapcuu", Request.QueryString["tructiepvaocapcuu"]);
         kcb_khoanoi.data("tructiepvaoKKB", Request.QueryString["tructiepvaoKKB"]);
         kcb_khoanoi.data("tructiepvaokhoa", Request.QueryString["tructiepvaokhoa"]);
         kcb_khoanoi.data("coquangioithieu", Request.QueryString["coquangioithieu"]);
         kcb_khoanoi.data("tuden", Request.QueryString["tuden"]);
         kcb_khoanoi.data("khac", Request.QueryString["khac"]);
         kcb_khoanoi.data("vaovienlan", Request.QueryString["vaovienlan"]);
         kcb_khoanoi.data("vaokhoa", Request.QueryString["vaokhoa"]);
         kcb_khoanoi.data("thoigianvaokhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaokhoa"]) ? "00" : Request.QueryString["giovaokhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaokhoa"]) ? "00" : Request.QueryString["phutvaokhoa"]) + " " + Request.QueryString["thoigianvaokhoa"], "datetime"));
         kcb_khoanoi.data("songaydieutri", Request.QueryString["songaydieutri"]);
         kcb_khoanoi.data("chuyentukhoa", Request.QueryString["chuyentukhoa"]);
         kcb_khoanoi.data("thoigianchuyentukhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoa"]) ? "00" : Request.QueryString["giochuyentukhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoa"]) ? "00" : Request.QueryString["phutchuyentukhoa"]) + " " + Request.QueryString["thoigianchuyentukhoa"], "datetime"));
         kcb_khoanoi.data("songaydieutritukhoa", Request.QueryString["songaydieutritukhoa"]);
         kcb_khoanoi.data("denkhoathunhat", Request.QueryString["denkhoathunhat"]);
         kcb_khoanoi.data("thoigianchuyentukhoathunhat", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathunhat"]) ? "00" : Request.QueryString["giochuyentukhoathunhat"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathunhat"]) ? "00" : Request.QueryString["phutchuyentukhoathunhat"]) + " " + Request.QueryString["thoigianchuyentukhoathunhat"], "datetime"));
         kcb_khoanoi.data("songaydieutrikhoathunhat", Request.QueryString["songaydieutrikhoathunhat"]);
         kcb_khoanoi.data("denkhoathuhai", Request.QueryString["denkhoathuhai"]);
         kcb_khoanoi.data("thoigianchuyentukhoathuhai", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathuhai"]) ? "00" : Request.QueryString["giochuyentukhoathuhai"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathuhai"]) ? "00" : Request.QueryString["phutchuyentukhoathuhai"]) + " " + Request.QueryString["thoigianchuyentukhoathuhai"], "datetime"));
         kcb_khoanoi.data("songaydieutrikhoathuhai", Request.QueryString["songaydieutrikhoathuhai"]);
         kcb_khoanoi.data("chuyenvientuyentren", Request.QueryString["chuyenvientuyentren"]);
         kcb_khoanoi.data("chuyenvientuyenduoi", Request.QueryString["chuyenvientuyenduoi"]);
         kcb_khoanoi.data("chuyenvienCK", Request.QueryString["chuyenvienCK"]);
         kcb_khoanoi.data("chuyenvienden", Request.QueryString["chuyenvienden"]);
         kcb_khoanoi.data("ngayravien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["gioravien"]) ? "00" : Request.QueryString["gioravien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutravien"]) ? "00" : Request.QueryString["phutravien"]) + " " + Request.QueryString["ngayravien"], "datetime"));
         kcb_khoanoi.data("ravien", Request.QueryString["ravien"]);
         kcb_khoanoi.data("xinve", Request.QueryString["xinve"]);
         kcb_khoanoi.data("bove", Request.QueryString["bove"]);
         kcb_khoanoi.data("duave", Request.QueryString["duave"]);
         kcb_khoanoi.data("tongsongaydieutri", Request.QueryString["tongsongaydieutri"]);
         kcb_khoanoi.data("cd_noichuyenden", Request.QueryString["cd_noichuyenden"]);
         kcb_khoanoi.data("cd_manoichuyenden", Request.QueryString["cd_manoichuyenden"]);
         kcb_khoanoi.data("cd_noiKKBCapCuu", Request.QueryString["cd_noiKKBCapCuu"]);
         kcb_khoanoi.data("cd_manoiKKBCapCuu", Request.QueryString["cd_manoiKKBCapCuu"]);
         kcb_khoanoi.data("cd_khivaokhoadieutri", Request.QueryString["cd_khivaokhoadieutri"]);
         kcb_khoanoi.data("cd_makhoadieutri", Request.QueryString["cd_makhoadieutri"]);
         kcb_khoanoi.data("cd_taibien", Request.QueryString["cd_taibien"]);
         kcb_khoanoi.data("cd_bienchung", Request.QueryString["cd_bienchung"]);
         kcb_khoanoi.data("cd_dophauthuat", Request.QueryString["cd_dophauthuat"]);
         kcb_khoanoi.data("cd_dogayme", Request.QueryString["cd_dogayme"]);
         kcb_khoanoi.data("cd_donhiemkhuan", Request.QueryString["cd_donhiemkhuan"]);
         kcb_khoanoi.data("cd_khac", Request.QueryString["cd_khac"]);
         kcb_khoanoi.data("cd_tongsongaydieutrisauphauthuat", Request.QueryString["cd_tongsongaydieutrisauphauthuat"]);
         kcb_khoanoi.data("cd_tongsolanphauthuat", Request.QueryString["cd_tongsolanphauthuat"]);
         kcb_khoanoi.data("cd_benhchinh", Request.QueryString["cd_benhchinh"]);
         kcb_khoanoi.data("cd_mabenhchinh", Request.QueryString["cd_mabenhchinh"]);
         kcb_khoanoi.data("cd_nguyennhanbenhchinh", Request.QueryString["cd_nguyennhanbenhchinh"]);
         kcb_khoanoi.data("cd_manguyennhanbenhchinh", Request.QueryString["cd_manguyennhanbenhchinh"]);
         kcb_khoanoi.data("cd_benhkemtheo", Request.QueryString["cd_benhkemtheo"]);
         kcb_khoanoi.data("cd_mabenhkemtheo", Request.QueryString["cd_mabenhkemtheo"]);
         kcb_khoanoi.data("cd_chandoantruocphauthuat", Request.QueryString["cd_chandoantruocphauthuat"]);
         kcb_khoanoi.data("cd_machandoantruocphauthuat", Request.QueryString["cd_machandoantruocphauthuat"]);
         kcb_khoanoi.data("cd_chandoansauphauthuat", Request.QueryString["cd_chandoansauphauthuat"]);
         kcb_khoanoi.data("cd_machandoansauphauthuat", Request.QueryString["cd_machandoansauphauthuat"]);
         kcb_khoanoi.data("tt_khoi", Request.QueryString["tt_khoi"]);
         kcb_khoanoi.data("tt_giam", Request.QueryString["tt_giam"]);
         kcb_khoanoi.data("tt_khongthaydoi", Request.QueryString["tt_khongthaydoi"]);
         kcb_khoanoi.data("tt_nanghon", Request.QueryString["tt_nanghon"]);
         kcb_khoanoi.data("tt_tuvong", Request.QueryString["tt_tuvong"]);
         kcb_khoanoi.data("tt_lanhtinh", Request.QueryString["tt_lanhtinh"]);
         kcb_khoanoi.data("tt_nghingo", Request.QueryString["tt_nghingo"]);
         kcb_khoanoi.data("tt_actinh", Request.QueryString["tt_actinh"]);
         kcb_khoanoi.data("tt_thoigiantuvong", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["tt_giotuvong"]) ? "00" : Request.QueryString["tt_giotuvong"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["tt_phuttuvong"]) ? "00" : Request.QueryString["tt_phuttuvong"]) + " " + Request.QueryString["tt_thoigiantuvong"], "datetime"));
         kcb_khoanoi.data("tt_tuvongdobenh", Request.QueryString["tt_tuvongdobenh"]);
         kcb_khoanoi.data("tt_tuvongdotaibien", Request.QueryString["tt_tuvongdotaibien"]);
         kcb_khoanoi.data("tt_tuvongkhac", Request.QueryString["tt_tuvongkhac"]);
         kcb_khoanoi.data("tt_tuvongtrong24h", Request.QueryString["tt_tuvongtrong24h"]);
         kcb_khoanoi.data("tt_tuvongtrong48h", Request.QueryString["tt_tuvongtrong48h"]);
         kcb_khoanoi.data("tt_tuvongtrong72h", Request.QueryString["tt_tuvongtrong72h"]);
         kcb_khoanoi.data("tt_nguyennhantuvong", Request.QueryString["tt_nguyennhantuvong"]);
         kcb_khoanoi.data("tt_manguyennhantuvong", Request.QueryString["tt_manguyennhantuvong"]);
         kcb_khoanoi.data("tt_khamtuthi", Request.QueryString["tt_khamtuthi"]);
         kcb_khoanoi.data("tt_chandoangiaiphaututhi", Request.QueryString["tt_chandoangiaiphaututhi"]);
         kcb_khoanoi.data("tt_magiaiphaututhi", Request.QueryString["tt_magiaiphaututhi"]);
         kcb_khoanoi.data("hb_quatrinhbenhly", Request.QueryString["hb_quatrinhbenhly"]);
         kcb_khoanoi.data("hb_tiensubenhbanthan", Request.QueryString["hb_tiensubenhbanthan"]);
         kcb_khoanoi.data("hb_diung", Request.QueryString["hb_diung"]);
         kcb_khoanoi.data("hb_thoigiandiung", Request.QueryString["hb_thoigiandiung"]);
         kcb_khoanoi.data("hb_nghienmatuy", Request.QueryString["hb_nghienmatuy"]);
         kcb_khoanoi.data("hb_thoigiannghienmatuy", Request.QueryString["hb_thoigiannghienmatuy"]);
         kcb_khoanoi.data("hb_nghienruoubia", Request.QueryString["hb_nghienruoubia"]);
         kcb_khoanoi.data("hb_thoigiannghienruoubia", Request.QueryString["hb_thoigiannghienruoubia"]);
         kcb_khoanoi.data("hb_nghienthuocla", Request.QueryString["hb_nghienthuocla"]);
         kcb_khoanoi.data("hb_thoigiannghienthuocla", Request.QueryString["hb_thoigiannghienthuocla"]);
         kcb_khoanoi.data("hb_nghienthuoclao", Request.QueryString["hb_nghienthuoclao"]);
         kcb_khoanoi.data("hb_thoigiannghienthuoclao", Request.QueryString["hb_thoigiannghienthuoclao"]);
         kcb_khoanoi.data("hb_lydokhac", Request.QueryString["hb_lydokhac"]);
         kcb_khoanoi.data("hb_thoigianlydokhac", Request.QueryString["hb_thoigianlydokhac"]);
         kcb_khoanoi.data("hb_tiensubenhgiadinh", Request.QueryString["hb_tiensubenhgiadinh"]);
         kcb_khoanoi.data("kb_toanthan", Request.QueryString["kb_toanthan"]);
         kcb_khoanoi.data("kb_benhngoaikhoa", Request.QueryString["kb_benhngoaikhoa"]);
         kcb_khoanoi.data("kb_tuanhoan", Request.QueryString["kb_tuanhoan"]);
         kcb_khoanoi.data("kb_hohap", Request.QueryString["kb_hohap"]);
         kcb_khoanoi.data("kb_tieuhoa", Request.QueryString["kb_tieuhoa"]);
         kcb_khoanoi.data("kb_thantietnieusinhduc", Request.QueryString["kb_thantietnieusinhduc"]);
         kcb_khoanoi.data("kb_thankinh", Request.QueryString["kb_thankinh"]);
         kcb_khoanoi.data("kb_cosuongkhop", Request.QueryString["kb_cosuongkhop"]);
         kcb_khoanoi.data("kb_taimuihong", Request.QueryString["kb_taimuihong"]);
         kcb_khoanoi.data("kb_ranghammat", Request.QueryString["kb_ranghammat"]);
         kcb_khoanoi.data("kb_mat", Request.QueryString["kb_mat"]);
         kcb_khoanoi.data("kb_noitietdinhduong", Request.QueryString["kb_noitietdinhduong"]);
         kcb_khoanoi.data("kb_canlamsan", Request.QueryString["kb_canlamsan"]);
         kcb_khoanoi.data("kb_benhan", Request.QueryString["kb_benhan"]);
         kcb_khoanoi.data("chandoankhivaokhoa", Request.QueryString["chandoankhivaokhoa"]);
         kcb_khoanoi.data("benhchinh", Request.QueryString["benhchinh"]);
         kcb_khoanoi.data("benhkemtheo", Request.QueryString["benhkemtheo"]);
         kcb_khoanoi.data("phanbiet", Request.QueryString["phanbiet"]);
         kcb_khoanoi.data("tienluong", Request.QueryString["tienluong"]);
         kcb_khoanoi.data("huongdieutri", Request.QueryString["huongdieutri"]);
         kcb_khoanoi.data("tk_quatrinhbenhly", Request.QueryString["tk_quatrinhbenhly"]);
         kcb_khoanoi.data("tk_ketquacanlamsan", Request.QueryString["tk_ketquacanlamsan"]);
         kcb_khoanoi.data("tk_phuongphapdieutri", Request.QueryString["tk_phuongphapdieutri"]);
         kcb_khoanoi.data("tk_tinhtrangravien", Request.QueryString["tk_tinhtrangravien"]);
         kcb_khoanoi.data("tk_huongdieutritieptheo", Request.QueryString["tk_huongdieutritieptheo"]);
         kcb_khoanoi.data("tk_idphuongphapdieutri", Request.QueryString["tk_idphuongphapdieutri"]);
         return kcb_khoanoi;
     }

     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": Savekcb_khoanoi(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": Xoakcb_khoanoi(); break;
         }
     }
 
     private void Xoakcb_khoanoi()
     {
         try
         {
                DataProcess process = s_kcb_khoanoi();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkcbkhoanoi"));
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
             A.*,B.LYDO AS lydovaovien from kcb_khoanoi A
            LEFT JOIN KHAMBENH C ON C.idkhambenh=A.idkhambenh
            LEFT JOIN DANGKYKHAM B ON B.IDBENHNHAN=C.IDBENHNHAN
            where A.idkhambenh='" + idkhoachinh + "'");
          string html = ""; html += "<root>";
          
         html += Environment.NewLine;
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 html += "<data id=\"idkcbkhoanoi\">" + table.Rows[0]["idkcbkhoanoi"] + "</data>";
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
 

     private void Savekcb_khoanoi()
     {
         try
         {
             DataProcess process = s_kcb_khoanoi();
             if (process.getData("idkcbkhoanoi") != null && process.getData("idkcbkhoanoi") != "")
             {
                 bool ok = process.Update();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idkcbkhoanoi"));
                     return;
                 }
             }
             else
             {
                 bool ok = process.Insert();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idkcbkhoanoi"));
                     return;
                 }
             }
         }
         catch { }
         Response.StatusCode = 500;

     }
     
 }
 
 
