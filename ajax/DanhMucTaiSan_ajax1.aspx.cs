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
 
 public partial class DanhMucTaiSan_ajax : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Them": InsertDanhMucTaiSan(); break;
             case "Sua": UpdateDanhMucTaiSan(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": XoaDanhMucTaiSan(); break;
         }
     }
 
     private void XoaDanhMucTaiSan()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
             string sql = "delete DanhMucTaiSan where danh_muc_ts_id=" + idkhoachinh;
             bool ok = KT_Profess.DanhMucTaiSan.ExecSQL(sql);
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
         DataTable table = KT_Profess.DanhMucTaiSan.GetTable("select danh_muc_ts_id,phieu_nhap_id,MaTS,TenTaiSan,HangSX,NamSX,NguyenGia,KhauHaoLK,NgayNhap,NgayKhauHao,SoNamKH,TKNguyenGia,TKKhauHao,TKDoiUng,TKChiPhi from DanhMucTaiSan where danh_muc_ts_id = " + idkhoachinh);
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
 
     private void InsertDanhMucTaiSan()
     {
         try
         {
             char[] splitter = {'/'};
          string phieu_nhap_id = "";
            if(Request.QueryString["phieu_nhap_id"] != null){
           phieu_nhap_id = Request.QueryString["phieu_nhap_id"].ToString(); 
}          string MaTS = "";
            if(Request.QueryString["MaTS"] != null){
           MaTS = Request.QueryString["MaTS"].ToString(); 
}          string TenTaiSan = "";
            if(Request.QueryString["TenTaiSan"] != null){
           TenTaiSan = Request.QueryString["TenTaiSan"].ToString(); 
}          string HangSX = "";
            if(Request.QueryString["HangSX"] != null){
           HangSX = Request.QueryString["HangSX"].ToString(); 
}          string NamSX = "";
            if(Request.QueryString["NamSX"] != null){
           NamSX = Request.QueryString["NamSX"].ToString(); 
}          string NguyenGia = "";
            if(Request.QueryString["NguyenGia"] != null){
           NguyenGia = Request.QueryString["NguyenGia"].ToString(); 
}          string KhauHaoLK = "";
            if(Request.QueryString["KhauHaoLK"] != null){
           KhauHaoLK = Request.QueryString["KhauHaoLK"].ToString(); 
}          string NgayNhap = "";
            if(Request.QueryString["NgayNhap"].ToString() != ""){
             string[] ngaythangcurent8 = Request.QueryString["NgayNhap"].ToString().Split(splitter);
             NgayNhap = ngaythangcurent8[1] +"/"+ ngaythangcurent8[0] +"/"+ ngaythangcurent8[2];
}          string NgayKhauHao = "";
            if(Request.QueryString["NgayKhauHao"].ToString() != ""){
             string[] ngaythangcurent9 = Request.QueryString["NgayKhauHao"].ToString().Split(splitter);
             NgayKhauHao = ngaythangcurent9[1] +"/"+ ngaythangcurent9[0] +"/"+ ngaythangcurent9[2];
}          string SoNamKH = "";
            if(Request.QueryString["SoNamKH"] != null){
           SoNamKH = Request.QueryString["SoNamKH"].ToString(); 
}          string TKNguyenGia = "";
            if(Request.QueryString["TKNguyenGia"] != null){
           TKNguyenGia = Request.QueryString["TKNguyenGia"].ToString(); 
}          string TKKhauHao = "";
            if(Request.QueryString["TKKhauHao"] != null){
           TKKhauHao = Request.QueryString["TKKhauHao"].ToString(); 
}          string TKDoiUng = "";
            if(Request.QueryString["TKDoiUng"] != null){
           TKDoiUng = Request.QueryString["TKDoiUng"].ToString(); 
}          string TKChiPhi = "";
            if(Request.QueryString["TKChiPhi"] != null){
           TKChiPhi = Request.QueryString["TKChiPhi"].ToString(); 
}          string TKChiPhiKhac = "";
            if(Request.QueryString["TKChiPhiKhac"] != null){
           TKChiPhiKhac = Request.QueryString["TKChiPhiKhac"].ToString(); 
} 
             KT_Profess.DanhMucTaiSan tempTT = KT_Profess.DanhMucTaiSan.Insert_Object(phieu_nhap_id,MaTS,TenTaiSan,HangSX,NamSX,NguyenGia,KhauHaoLK,NgayNhap,NgayKhauHao,SoNamKH,TKNguyenGia,TKKhauHao,TKDoiUng,TKChiPhi,TKChiPhiKhac);
             if (tempTT!=null)
             {
                         Response.Clear();Response.Write(tempTT.danh_muc_ts_id);
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
 
 
     }
     private void UpdateDanhMucTaiSan()
     {
         try
         {
             char[] splitter = {'/'};
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
          string phieu_nhap_id = "";
            if(Request.QueryString["phieu_nhap_id"] != null){
           phieu_nhap_id = Request.QueryString["phieu_nhap_id"].ToString(); 
}          string MaTS = "";
            if(Request.QueryString["MaTS"] != null){
           MaTS = Request.QueryString["MaTS"].ToString(); 
}          string TenTaiSan = "";
            if(Request.QueryString["TenTaiSan"] != null){
           TenTaiSan = Request.QueryString["TenTaiSan"].ToString(); 
}          string HangSX = "";
            if(Request.QueryString["HangSX"] != null){
           HangSX = Request.QueryString["HangSX"].ToString(); 
}          string NamSX = "";
            if(Request.QueryString["NamSX"] != null){
           NamSX = Request.QueryString["NamSX"].ToString(); 
}          string NguyenGia = "";
            if(Request.QueryString["NguyenGia"] != null){
           NguyenGia = Request.QueryString["NguyenGia"].ToString(); 
}          string KhauHaoLK = "";
            if(Request.QueryString["KhauHaoLK"] != null){
           KhauHaoLK = Request.QueryString["KhauHaoLK"].ToString(); 
}          string NgayNhap = "";
            if(Request.QueryString["NgayNhap"].ToString() != ""){
             string[] ngaythangcurent8 = Request.QueryString["NgayNhap"].ToString().Split(splitter);
             NgayNhap = ngaythangcurent8[1] +"/"+ ngaythangcurent8[0] +"/"+ ngaythangcurent8[2];
}          string NgayKhauHao = "";
            if(Request.QueryString["NgayKhauHao"].ToString() != ""){
             string[] ngaythangcurent9 = Request.QueryString["NgayKhauHao"].ToString().Split(splitter);
             NgayKhauHao = ngaythangcurent9[1] +"/"+ ngaythangcurent9[0] +"/"+ ngaythangcurent9[2];
}          string SoNamKH = "";
            if(Request.QueryString["SoNamKH"] != null){
           SoNamKH = Request.QueryString["SoNamKH"].ToString(); 
}          string TKNguyenGia = "";
            if(Request.QueryString["TKNguyenGia"] != null){
           TKNguyenGia = Request.QueryString["TKNguyenGia"].ToString(); 
}          string TKKhauHao = "";
            if(Request.QueryString["TKKhauHao"] != null){
           TKKhauHao = Request.QueryString["TKKhauHao"].ToString(); 
}          string TKDoiUng = "";
            if(Request.QueryString["TKDoiUng"] != null){
           TKDoiUng = Request.QueryString["TKDoiUng"].ToString(); 
}          string TKChiPhi = "";
            if(Request.QueryString["TKChiPhi"] != null){
           TKChiPhi = Request.QueryString["TKChiPhi"].ToString(); 
}          string TKChiPhiKhac = "";
            if(Request.QueryString["TKChiPhiKhac"] != null){
           TKChiPhiKhac = Request.QueryString["TKChiPhiKhac"].ToString(); 
} 
             KT_Profess.DanhMucTaiSan temp = KT_Profess.DanhMucTaiSan.Create_DanhMucTaiSan(idkhoachinh);
             bool ok = temp.Save_Object(phieu_nhap_id,MaTS,TenTaiSan,HangSX,NamSX,NguyenGia,KhauHaoLK,NgayNhap,NgayKhauHao,SoNamKH,TKNguyenGia,TKKhauHao,TKDoiUng,TKChiPhi,TKChiPhiKhac);
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
 
 
