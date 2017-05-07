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
 
 public partial class DanhMucCCDC_ajax : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Them": InsertDanhMucCCDC(); break;
             case "Sua": UpdateDanhMucCCDC(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": XoaDanhMucCCDC(); break;
         }
     }
 
     private void XoaDanhMucCCDC()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
             string sql = "delete DanhMucCCDC where ccdc_id=" + idkhoachinh;
             bool ok = KT_Profess.DanhMucCCDC.ExecSQL(sql);
             if (ok)
             {
                         Response.Clear();Response.Write(idkhoachinh);
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
         string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
         DataTable table = KT_Profess.DanhMucCCDC.GetTable("select ccdc_id,phieu_nhap_id,ma_ccdc,ten_ccdc,hang_sx,nam_sx,nguyen_gia,ngay_nhap,ngay_khau_hao,so_thang_khau_hao,Tk_ccdc,Tk_doi_ung,tk_chi_phi,tk_phan_bo,phieu_xuat_id from DanhMucCCDC where ccdc_id = " + idkhoachinh);
         string html = "";
         if(table !=null){if (table.Rows.Count > 0)
         {
             for (int y = 0; y < table.Columns.Count; y++)
             {
                 try
                 {
 
                     html += DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "@";
                 }
                 catch (Exception)
                 {
                     html += table.Rows[0][y].ToString() + "@";
                 }
             }
         }}
                 Response.Clear();Response.Write(html);
     }
 
     private void InsertDanhMucCCDC()
     {
         try
         {
             char[] splitter = {'/'};
          string phieu_nhap_id = "";
            if(Request.QueryString["phieu_nhap_id"] != "null"){
           phieu_nhap_id = Request.QueryString["phieu_nhap_id"].ToString(); 
}          string ma_ccdc = "";
            if(Request.QueryString["ma_ccdc"] != "null"){
           ma_ccdc = Request.QueryString["ma_ccdc"].ToString(); 
}          string ten_ccdc = "";
            if(Request.QueryString["ten_ccdc"] != "null"){
           ten_ccdc = Request.QueryString["ten_ccdc"].ToString(); 
}          string hang_sx = "";
            if(Request.QueryString["hang_sx"] != "null"){
           hang_sx = Request.QueryString["hang_sx"].ToString(); 
}          string nam_sx = "";
            if(Request.QueryString["nam_sx"] != "null"){
           nam_sx = Request.QueryString["nam_sx"].ToString(); 
}          string nguyen_gia = "";
            if(Request.QueryString["nguyen_gia"] != "null"){
           nguyen_gia = Request.QueryString["nguyen_gia"].ToString(); 
}          string ngay_nhap = "";
            if(Request.QueryString["ngay_nhap"].ToString() != ""){
             string[] ngaythangcurent7 = Request.QueryString["ngay_nhap"].ToString().Split(splitter);
             ngay_nhap = ngaythangcurent7[1] +"/"+ ngaythangcurent7[0] +"/"+ ngaythangcurent7[2];
}          string ngay_khau_hao = "";
            if(Request.QueryString["ngay_khau_hao"].ToString() != ""){
             string[] ngaythangcurent8 = Request.QueryString["ngay_khau_hao"].ToString().Split(splitter);
             ngay_khau_hao = ngaythangcurent8[1] +"/"+ ngaythangcurent8[0] +"/"+ ngaythangcurent8[2];
}          string so_thang_khau_hao = "";
            if(Request.QueryString["so_thang_khau_hao"] != "null"){
           so_thang_khau_hao = Request.QueryString["so_thang_khau_hao"].ToString(); 
}          string Tk_ccdc = "";
            if(Request.QueryString["Tk_ccdc"] != "null"){
           Tk_ccdc = Request.QueryString["Tk_ccdc"].ToString(); 
}          string Tk_doi_ung = "";
            if(Request.QueryString["Tk_doi_ung"] != "null"){
           Tk_doi_ung = Request.QueryString["Tk_doi_ung"].ToString(); 
}          string tk_chi_phi = "";
            if(Request.QueryString["tk_chi_phi"] != "null"){
           tk_chi_phi = Request.QueryString["tk_chi_phi"].ToString(); 
}          string tk_phan_bo = "";
            if(Request.QueryString["tk_phan_bo"] != "null"){
           tk_phan_bo = Request.QueryString["tk_phan_bo"].ToString(); 
}          string phieu_xuat_id = "";
            if(Request.QueryString["phieu_xuat_id"] != "null"){
           phieu_xuat_id = Request.QueryString["phieu_xuat_id"].ToString(); 
} 
             KT_Profess.DanhMucCCDC tempTT = KT_Profess.DanhMucCCDC.Insert_Object(phieu_nhap_id,ma_ccdc,ten_ccdc,hang_sx,nam_sx,nguyen_gia,ngay_nhap,ngay_khau_hao,so_thang_khau_hao,Tk_ccdc,Tk_doi_ung,tk_chi_phi,tk_phan_bo,phieu_xuat_id);
             if (tempTT!=null)
             {
                         Response.Clear();Response.Write(tempTT.ccdc_id);
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
 
 
     }
     private void UpdateDanhMucCCDC()
     {
         try
         {
             char[] splitter = {'/'};
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
          string phieu_nhap_id = "";
            if(Request.QueryString["phieu_nhap_id"] != "null"){
           phieu_nhap_id = Request.QueryString["phieu_nhap_id"].ToString(); 
}          string ma_ccdc = "";
            if(Request.QueryString["ma_ccdc"] != "null"){
           ma_ccdc = Request.QueryString["ma_ccdc"].ToString(); 
}          string ten_ccdc = "";
            if(Request.QueryString["ten_ccdc"] != "null"){
           ten_ccdc = Request.QueryString["ten_ccdc"].ToString(); 
}          string hang_sx = "";
            if(Request.QueryString["hang_sx"] != "null"){
           hang_sx = Request.QueryString["hang_sx"].ToString(); 
}          string nam_sx = "";
            if(Request.QueryString["nam_sx"] != "null"){
           nam_sx = Request.QueryString["nam_sx"].ToString(); 
}          string nguyen_gia = "";
            if(Request.QueryString["nguyen_gia"] != "null"){
           nguyen_gia = Request.QueryString["nguyen_gia"].ToString(); 
}          string ngay_nhap = "";
            if(Request.QueryString["ngay_nhap"].ToString() != ""){
             string[] ngaythangcurent7 = Request.QueryString["ngay_nhap"].ToString().Split(splitter);
             ngay_nhap = ngaythangcurent7[1] +"/"+ ngaythangcurent7[0] +"/"+ ngaythangcurent7[2];
}          string ngay_khau_hao = "";
            if(Request.QueryString["ngay_khau_hao"].ToString() != ""){
             string[] ngaythangcurent8 = Request.QueryString["ngay_khau_hao"].ToString().Split(splitter);
             ngay_khau_hao = ngaythangcurent8[1] +"/"+ ngaythangcurent8[0] +"/"+ ngaythangcurent8[2];
}          string so_thang_khau_hao = "";
            if(Request.QueryString["so_thang_khau_hao"] != "null"){
           so_thang_khau_hao = Request.QueryString["so_thang_khau_hao"].ToString(); 
}          string Tk_ccdc = "";
            if(Request.QueryString["Tk_ccdc"] != "null"){
           Tk_ccdc = Request.QueryString["Tk_ccdc"].ToString(); 
}          string Tk_doi_ung = "";
            if(Request.QueryString["Tk_doi_ung"] != "null"){
           Tk_doi_ung = Request.QueryString["Tk_doi_ung"].ToString(); 
}          string tk_chi_phi = "";
            if(Request.QueryString["tk_chi_phi"] != "null"){
           tk_chi_phi = Request.QueryString["tk_chi_phi"].ToString(); 
}          string tk_phan_bo = "";
            if(Request.QueryString["tk_phan_bo"] != "null"){
           tk_phan_bo = Request.QueryString["tk_phan_bo"].ToString(); 
}          string phieu_xuat_id = "";
            if(Request.QueryString["phieu_xuat_id"] != "null"){
           phieu_xuat_id = Request.QueryString["phieu_xuat_id"].ToString(); 
} 
             KT_Profess.DanhMucCCDC temp = KT_Profess.DanhMucCCDC.Create_DanhMucCCDC(idkhoachinh);
             bool ok = temp.Save_Object(phieu_nhap_id,ma_ccdc,ten_ccdc,hang_sx,nam_sx,nguyen_gia,ngay_nhap,ngay_khau_hao,so_thang_khau_hao,Tk_ccdc,Tk_doi_ung,tk_chi_phi,tk_phan_bo,phieu_xuat_id);
             if (ok)
             {
                         Response.Clear();Response.Write(idkhoachinh);
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 }
 
 
