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
 
 public partial class kcb_khoangoai_ajax : System.Web.UI.Page
 {
     protected DataProcess s_kcb_khoangoai()
     {
         DataProcess kcb_khoangoai = new DataProcess("kcb_khoangoai");
         kcb_khoangoai.data("idkcbkhoangoai", Request.QueryString["idkcbkhoangoai"]);
         kcb_khoangoai.data("idkhambenh", Request.QueryString["idkhambenhgoc"]);
         kcb_khoangoai.data("idbacsi", Request.QueryString["idbacsi"]);
         kcb_khoangoai.data("ngayvaovien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaovien"]) ? "00" : Request.QueryString["giovaovien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaovien"]) ? "00" : Request.QueryString["phutvaovien"]) + " " + Request.QueryString["ngayvaovien"], "datetime"));
         kcb_khoangoai.data("tructiepvaocapcuu", Request.QueryString["tructiepvaocapcuu"]);
         kcb_khoangoai.data("tructiepvaoKKB", Request.QueryString["tructiepvaoKKB"]);
         kcb_khoangoai.data("tructiepvaokhoa", Request.QueryString["tructiepvaokhoa"]);
         kcb_khoangoai.data("coquangioithieu", Request.QueryString["coquangioithieu"]);
         kcb_khoangoai.data("tuden", Request.QueryString["tuden"]);
         kcb_khoangoai.data("khac", Request.QueryString["khac"]);
         kcb_khoangoai.data("vaovienlan", Request.QueryString["vaovienlan"]);
         kcb_khoangoai.data("vaokhoa", Request.QueryString["vaokhoa"]);
         kcb_khoangoai.data("thoigianvaokhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giovaokhoa"]) ? "00" : Request.QueryString["giovaokhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutvaokhoa"]) ? "00" : Request.QueryString["phutvaokhoa"]) + " " + Request.QueryString["thoigianvaokhoa"], "datetime"));
         kcb_khoangoai.data("songaydieutri", Request.QueryString["songaydieutri"]);
         kcb_khoangoai.data("chuyentukhoa", Request.QueryString["chuyentukhoa"]);
         kcb_khoangoai.data("thoigianchuyentukhoa", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoa"]) ? "00" : Request.QueryString["giochuyentukhoa"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoa"]) ? "00" : Request.QueryString["phutchuyentukhoa"]) + " " + Request.QueryString["thoigianchuyentukhoa"], "datetime"));
         kcb_khoangoai.data("songaydieutritukhoa", Request.QueryString["songaydieutritukhoa"]);
         kcb_khoangoai.data("denkhoathunhat", Request.QueryString["denkhoathunhat"]);
         kcb_khoangoai.data("thoigianchuyentukhoathunhat", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathunhat"]) ? "00" : Request.QueryString["giochuyentukhoathunhat"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathunhat"]) ? "00" : Request.QueryString["phutchuyentukhoathunhat"]) + " " + Request.QueryString["thoigianchuyentukhoathunhat"], "datetime"));
         kcb_khoangoai.data("songaydieutrikhoathunhat", Request.QueryString["songaydieutrikhoathunhat"]);
         kcb_khoangoai.data("denkhoathuhai", Request.QueryString["denkhoathuhai"]);
         kcb_khoangoai.data("thoigianchuyentukhoathuhai", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["giochuyentukhoathuhai"]) ? "00" : Request.QueryString["giochuyentukhoathuhai"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutchuyentukhoathuhai"]) ? "00" : Request.QueryString["phutchuyentukhoathuhai"]) + " " + Request.QueryString["thoigianchuyentukhoathuhai"], "datetime"));
         kcb_khoangoai.data("songaydieutrikhoathuhai", Request.QueryString["songaydieutrikhoathuhai"]);
         kcb_khoangoai.data("chuyenvientuyentren", Request.QueryString["chuyenvientuyentren"]);
         kcb_khoangoai.data("chuyenvientuyenduoi", Request.QueryString["chuyenvientuyenduoi"]);
         kcb_khoangoai.data("chuyenvienCK", Request.QueryString["chuyenvienCK"]);
         kcb_khoangoai.data("chuyenvienden", Request.QueryString["chuyenvienden"]);
         kcb_khoangoai.data("ngayravien", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["gioravien"]) ? "00" : Request.QueryString["gioravien"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["phutravien"]) ? "00" : Request.QueryString["phutravien"]) + " " + Request.QueryString["ngayravien"], "datetime"));
         kcb_khoangoai.data("ravien", Request.QueryString["ravien"]);
         kcb_khoangoai.data("xinve", Request.QueryString["xinve"]);
         kcb_khoangoai.data("bove", Request.QueryString["bove"]);
         kcb_khoangoai.data("duave", Request.QueryString["duave"]);
         kcb_khoangoai.data("tongsongaydieutri", Request.QueryString["tongsongaydieutri"]);
         kcb_khoangoai.data("cd_noichuyenden", Request.QueryString["cd_noichuyenden"]);
         kcb_khoangoai.data("cd_manoichuyenden", Request.QueryString["cd_manoichuyenden"]);
         kcb_khoangoai.data("cd_noiKKBCapCuu", Request.QueryString["cd_noiKKBCapCuu"]);
         kcb_khoangoai.data("cd_manoiKKBCapCuu", Request.QueryString["cd_manoiKKBCapCuu"]);
         kcb_khoangoai.data("cd_khivaokhoadieutri", Request.QueryString["cd_khivaokhoadieutri"]);
         kcb_khoangoai.data("cd_makhoadieutri", Request.QueryString["cd_makhoadieutri"]);
         kcb_khoangoai.data("cd_taibien", Request.QueryString["cd_taibien"]);
         kcb_khoangoai.data("cd_bienchung", Request.QueryString["cd_bienchung"]);
         kcb_khoangoai.data("cd_dophauthuat", Request.QueryString["cd_dophauthuat"]);
         kcb_khoangoai.data("cd_dogayme", Request.QueryString["cd_dogayme"]);
         kcb_khoangoai.data("cd_donhiemkhuan", Request.QueryString["cd_donhiemkhuan"]);
         kcb_khoangoai.data("cd_khac", Request.QueryString["cd_khac"]);
         kcb_khoangoai.data("cd_tongsongaydieutrisauphauthuat", Request.QueryString["cd_tongsongaydieutrisauphauthuat"]);
         kcb_khoangoai.data("cd_tongsolanphauthuat", Request.QueryString["cd_tongsolanphauthuat"]);
         kcb_khoangoai.data("cd_benhchinh", Request.QueryString["cd_benhchinh"]);
         kcb_khoangoai.data("cd_mabenhchinh", Request.QueryString["cd_mabenhchinh"]);
         kcb_khoangoai.data("cd_nguyennhanbenhchinh", Request.QueryString["cd_nguyennhanbenhchinh"]);
         kcb_khoangoai.data("cd_manguyennhanbenhchinh", Request.QueryString["cd_manguyennhanbenhchinh"]);
         kcb_khoangoai.data("cd_benhkemtheo", Request.QueryString["cd_benhkemtheo"]);
         kcb_khoangoai.data("cd_mabenhkemtheo", Request.QueryString["cd_mabenhkemtheo"]);
         kcb_khoangoai.data("cd_chandoantruocphauthuat", Request.QueryString["cd_chandoantruocphauthuat"]);
         kcb_khoangoai.data("cd_machandoantruocphauthuat", Request.QueryString["cd_machandoantruocphauthuat"]);
         kcb_khoangoai.data("cd_chandoansauphauthuat", Request.QueryString["cd_chandoansauphauthuat"]);
         kcb_khoangoai.data("cd_machandoansauphauthuat", Request.QueryString["cd_machandoansauphauthuat"]);
         kcb_khoangoai.data("tt_khoi", Request.QueryString["tt_khoi"]);
         kcb_khoangoai.data("tt_giam", Request.QueryString["tt_giam"]);
         kcb_khoangoai.data("tt_khongthaydoi", Request.QueryString["tt_khongthaydoi"]);
         kcb_khoangoai.data("tt_nanghon", Request.QueryString["tt_nanghon"]);
         kcb_khoangoai.data("tt_tuvong", Request.QueryString["tt_tuvong"]);
         kcb_khoangoai.data("tt_lanhtinh", Request.QueryString["tt_lanhtinh"]);
         kcb_khoangoai.data("tt_nghingo", Request.QueryString["tt_nghingo"]);
         kcb_khoangoai.data("tt_actinh", Request.QueryString["tt_actinh"]);
         kcb_khoangoai.data("tt_thoigiantuvong", DataProcess.sGetSaveValue((string.IsNullOrEmpty(Request.QueryString["tt_giotuvong"]) ? "00" : Request.QueryString["tt_giotuvong"]) + ":" + (string.IsNullOrEmpty(Request.QueryString["tt_phuttuvong"]) ? "00" : Request.QueryString["tt_phuttuvong"]) + " " + Request.QueryString["tt_thoigiantuvong"], "datetime"));
         kcb_khoangoai.data("tt_tuvongdobenh", Request.QueryString["tt_tuvongdobenh"]);
         kcb_khoangoai.data("tt_tuvongdotaibien", Request.QueryString["tt_tuvongdotaibien"]);
         kcb_khoangoai.data("tt_tuvongkhac", Request.QueryString["tt_tuvongkhac"]);
         kcb_khoangoai.data("tt_tuvongtrong24h", Request.QueryString["tt_tuvongtrong24h"]);
         kcb_khoangoai.data("tt_tuvongtrong48h", Request.QueryString["tt_tuvongtrong48h"]);
         kcb_khoangoai.data("tt_tuvongtrong72h", Request.QueryString["tt_tuvongtrong72h"]);
         kcb_khoangoai.data("tt_nguyennhantuvong", Request.QueryString["tt_nguyennhantuvong"]);
         kcb_khoangoai.data("tt_manguyennhantuvong", Request.QueryString["tt_manguyennhantuvong"]);
         kcb_khoangoai.data("tt_khamtuthi", Request.QueryString["tt_khamtuthi"]);
         kcb_khoangoai.data("tt_chandoangiaiphaututhi", Request.QueryString["tt_chandoangiaiphaututhi"]);
         kcb_khoangoai.data("tt_magiaiphaututhi", Request.QueryString["tt_magiaiphaututhi"]);
         kcb_khoangoai.data("hb_quatrinhbenhly", Request.QueryString["hb_quatrinhbenhly"]);
         kcb_khoangoai.data("hb_tiensubenhbanthan", Request.QueryString["hb_tiensubenhbanthan"]);
         kcb_khoangoai.data("hb_diung", Request.QueryString["hb_diung"]);
         kcb_khoangoai.data("hb_thoigiandiung", Request.QueryString["hb_thoigiandiung"]);
         kcb_khoangoai.data("hb_nghienmatuy", Request.QueryString["hb_nghienmatuy"]);
         kcb_khoangoai.data("hb_thoigiannghienmatuy", Request.QueryString["hb_thoigiannghienmatuy"]);
         kcb_khoangoai.data("hb_nghienruoubia", Request.QueryString["hb_nghienruoubia"]);
         kcb_khoangoai.data("hb_thoigiannghienruoubia", Request.QueryString["hb_thoigiannghienruoubia"]);
         kcb_khoangoai.data("hb_nghienthuocla", Request.QueryString["hb_nghienthuocla"]);
         kcb_khoangoai.data("hb_thoigiannghienthuocla", Request.QueryString["hb_thoigiannghienthuocla"]);
         kcb_khoangoai.data("hb_nghienthuoclao", Request.QueryString["hb_nghienthuoclao"]);
         kcb_khoangoai.data("hb_thoigiannghienthuoclao", Request.QueryString["hb_thoigiannghienthuoclao"]);
         kcb_khoangoai.data("hb_lydokhac", Request.QueryString["hb_lydokhac"]);
         kcb_khoangoai.data("hb_thoigianlydokhac", Request.QueryString["hb_thoigianlydokhac"]);
         kcb_khoangoai.data("hb_tiensubenhgiadinh", Request.QueryString["hb_tiensubenhgiadinh"]);
         kcb_khoangoai.data("kb_toanthan", Request.QueryString["kb_toanthan"]);
         kcb_khoangoai.data("kb_benhngoaikhoa", Request.QueryString["kb_benhngoaikhoa"]);
         kcb_khoangoai.data("kb_tuanhoan", Request.QueryString["kb_tuanhoan"]);
         kcb_khoangoai.data("kb_hohap", Request.QueryString["kb_hohap"]);
         kcb_khoangoai.data("kb_tieuhoa", Request.QueryString["kb_tieuhoa"]);
         kcb_khoangoai.data("kb_thantietnieusinhduc", Request.QueryString["kb_thantietnieusinhduc"]);
         kcb_khoangoai.data("kb_thankinh", Request.QueryString["kb_thankinh"]);
         kcb_khoangoai.data("kb_cosuongkhop", Request.QueryString["kb_cosuongkhop"]);
         kcb_khoangoai.data("kb_taimuihong", Request.QueryString["kb_taimuihong"]);
         kcb_khoangoai.data("kb_ranghammat", Request.QueryString["kb_ranghammat"]);
         kcb_khoangoai.data("kb_mat", Request.QueryString["kb_mat"]);
         kcb_khoangoai.data("kb_noitietdinhduong", Request.QueryString["kb_noitietdinhduong"]);
         kcb_khoangoai.data("kb_canlamsan", Request.QueryString["kb_canlamsan"]);
         kcb_khoangoai.data("kb_benhan", Request.QueryString["kb_benhan"]);
         kcb_khoangoai.data("chandoankhivaokhoa", Request.QueryString["chandoankhivaokhoa"]);
         kcb_khoangoai.data("benhchinh", Request.QueryString["benhchinh"]);
         kcb_khoangoai.data("benhkemtheo", Request.QueryString["benhkemtheo"]);
         kcb_khoangoai.data("phanbiet", Request.QueryString["phanbiet"]);
         kcb_khoangoai.data("tienluong", Request.QueryString["tienluong"]);
         kcb_khoangoai.data("huongdieutri", Request.QueryString["huongdieutri"]);
         kcb_khoangoai.data("tk_quatrinhbenhly", Request.QueryString["tk_quatrinhbenhly"]);
         kcb_khoangoai.data("tk_ketquacanlamsan", Request.QueryString["tk_ketquacanlamsan"]);
         kcb_khoangoai.data("tk_phuongphapdieutri", Request.QueryString["tk_phuongphapdieutri"]);
         kcb_khoangoai.data("tk_tinhtrangravien", Request.QueryString["tk_tinhtrangravien"]);
         kcb_khoangoai.data("tk_huongdieutritieptheo", Request.QueryString["tk_huongdieutritieptheo"]);
         kcb_khoangoai.data("tk_idphuongphapdieutri", Request.QueryString["tk_idphuongphapdieutri"]);
         return kcb_khoangoai;
     }
     protected DataProcess s_KCB_PhuongPhapDieuTri()
     {
         DataProcess KCB_PhuongPhapDieuTri = new DataProcess("KCB_PhuongPhapDieuTri");
         KCB_PhuongPhapDieuTri.data("idphuongphapdieutri", Request.QueryString["idkhoachinh"]);
         KCB_PhuongPhapDieuTri.data("idkcbkhoangoai", Request.QueryString["idkcbkhoangoai"]);
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
             case "Luu": Savekcb_khoangoai(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": Xoakcb_khoangoai(); break;
             case "xoaKCB_PhuongPhapDieuTri": XoaKCB_PhuongPhapDieuTri(); break;
             case "luuTableKCB_PhuongPhapDieuTri": LuuTableKCB_PhuongPhapDieuTri(); break;
             case "loadTableKCB_PhuongPhapDieuTri": loadTableKCB_PhuongPhapDieuTri(); break;
         }
     }
 
     private void Xoakcb_khoangoai()
     {
         try
         {
                DataProcess process = s_kcb_khoangoai();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("idkcbkhoangoai"));
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
             process.data("idkcbkhoangoai", Request.QueryString["idkcbkhoangoai"]);
             bool ok = process.Delete();
             if (ok)
             {
                 Response.Clear(); Response.Write(process.getData("idkcbkhoangoai"));
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
            
             A.*,B.LYDO AS lydovaovien from kcb_khoangoai A
            LEFT JOIN KHAMBENH C ON C.idkhambenh=A.idkhambenh
            LEFT JOIN DANGKYKHAM B ON B.IDBENHNHAN=C.IDBENHNHAN
            where A.idkhambenh='" + idkhoachinh+"'");
          string html = ""; html += "<root>";
          
         html += Environment.NewLine;
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 html += "<data id=\"idkcbkhoangoai\">" + table.Rows[0]["idkcbkhoangoai"] + "</data>";
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
 

     private void Savekcb_khoangoai()
     {
         try
         {
             DataProcess process = s_kcb_khoangoai();
             if (process.getData("idkcbkhoangoai") != null && process.getData("idkcbkhoangoai") != "")
             {
                 bool ok = process.Update();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idkcbkhoangoai"));
                     return;
                 }
             }
             else
             {
                 bool ok = process.Insert();
                 if (ok)
                 {
                     Response.Clear(); Response.Write(process.getData("idkcbkhoangoai"));
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
                    left join kcb_khoangoai  A on T.idkcbkhoangoai=A.idkcbkhoangoai
          where T.idkcbkhoangoai='" + process.getData("idkcbkhoangoai") + "'");
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
 
 
