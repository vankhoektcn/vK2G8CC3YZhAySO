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
 
 public partial class DanhMucTaiSanDuBi_ajax : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Them": InsertDanhMucTaiSanDuBi(); break;
             case "Sua": UpdateDanhMucTaiSanDuBi(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": XoaDanhMucTaiSanDuBi(); break;
         }
     }
 
     private void XoaDanhMucTaiSanDuBi()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
             string sql = "delete DanhMucTaiSanDuBi where danh_muc_tsdb_id=" + idkhoachinh;
             bool ok = KT_Profess.DanhMucTaiSanDuBi.ExecSQL(sql);
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
         DataTable table = KT_Profess.DanhMucTaiSanDuBi.GetTable("select danh_muc_tsdb_id,phieu_nhap_id,MaTS_db,TenTaiSan_db,HangSX,NamSX,NguyenGia,NgayNhap,TKNguyenGia,TKDoiUng from DanhMucTaiSanDuBi where danh_muc_tsdb_id = " + idkhoachinh);
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
 
     private void InsertDanhMucTaiSanDuBi()
     {
         try
         {
             char[] splitter = {'/'};
          string phieu_nhap_id = "";
            if(Request.QueryString["phieu_nhap_id"] != null){
           phieu_nhap_id = Request.QueryString["phieu_nhap_id"].ToString(); 
}          string MaTS_db = "";
            if(Request.QueryString["MaTS_db"] != null){
           MaTS_db = Request.QueryString["MaTS_db"].ToString(); 
}          string TenTaiSan_db = "";
            if(Request.QueryString["TenTaiSan_db"] != null){
           TenTaiSan_db = Request.QueryString["TenTaiSan_db"].ToString(); 
}          string HangSX = "";
            if(Request.QueryString["HangSX"] != null){
           HangSX = Request.QueryString["HangSX"].ToString(); 
}          string NamSX = "";
            if(Request.QueryString["NamSX"] != null){
           NamSX = Request.QueryString["NamSX"].ToString(); 
}          string NguyenGia = "";
            if(Request.QueryString["NguyenGia"] != null){
           NguyenGia = Request.QueryString["NguyenGia"].ToString(); 
}          string NgayNhap = "";
            if(Request.QueryString["NgayNhap"].ToString() != ""){
             string[] ngaythangcurent7 = Request.QueryString["NgayNhap"].ToString().Split(splitter);
             NgayNhap = ngaythangcurent7[1] +"/"+ ngaythangcurent7[0] +"/"+ ngaythangcurent7[2];
}          string TKNguyenGia = "";
            if(Request.QueryString["TKNguyenGia"] != null){
           TKNguyenGia = Request.QueryString["TKNguyenGia"].ToString(); 
}          string TKDoiUng = "";
            if(Request.QueryString["TKDoiUng"] != null){
           TKDoiUng = Request.QueryString["TKDoiUng"].ToString(); 
} 
             KT_Profess.DanhMucTaiSanDuBi tempTT = KT_Profess.DanhMucTaiSanDuBi.Insert_Object(phieu_nhap_id,MaTS_db,TenTaiSan_db,HangSX,NamSX,NguyenGia,NgayNhap,TKNguyenGia,TKDoiUng);
             if (tempTT!=null)
             {
                         Response.Clear();Response.Write(tempTT.danh_muc_tsdb_id);
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
 
 
     }
     private void UpdateDanhMucTaiSanDuBi()
     {
         try
         {
             char[] splitter = {'/'};
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
          string phieu_nhap_id = "";
            if(Request.QueryString["phieu_nhap_id"] != null){
           phieu_nhap_id = Request.QueryString["phieu_nhap_id"].ToString(); 
}          string MaTS_db = "";
            if(Request.QueryString["MaTS_db"] != null){
           MaTS_db = Request.QueryString["MaTS_db"].ToString(); 
}          string TenTaiSan_db = "";
            if(Request.QueryString["TenTaiSan_db"] != null){
           TenTaiSan_db = Request.QueryString["TenTaiSan_db"].ToString(); 
}          string HangSX = "";
            if(Request.QueryString["HangSX"] != null){
           HangSX = Request.QueryString["HangSX"].ToString(); 
}          string NamSX = "";
            if(Request.QueryString["NamSX"] != null){
           NamSX = Request.QueryString["NamSX"].ToString(); 
}          string NguyenGia = "";
            if(Request.QueryString["NguyenGia"] != null){
           NguyenGia = Request.QueryString["NguyenGia"].ToString(); 
}          string NgayNhap = "";
            if(Request.QueryString["NgayNhap"].ToString() != ""){
             string[] ngaythangcurent7 = Request.QueryString["NgayNhap"].ToString().Split(splitter);
             NgayNhap = ngaythangcurent7[1] +"/"+ ngaythangcurent7[0] +"/"+ ngaythangcurent7[2];
}          string TKNguyenGia = "";
            if(Request.QueryString["TKNguyenGia"] != null){
           TKNguyenGia = Request.QueryString["TKNguyenGia"].ToString(); 
}          string TKDoiUng = "";
            if(Request.QueryString["TKDoiUng"] != null){
           TKDoiUng = Request.QueryString["TKDoiUng"].ToString(); 
} 
             KT_Profess.DanhMucTaiSanDuBi temp = KT_Profess.DanhMucTaiSanDuBi.Create_DanhMucTaiSanDuBi(idkhoachinh);
             bool ok = temp.Save_Object(phieu_nhap_id,MaTS_db,TenTaiSan_db,HangSX,NamSX,NguyenGia,NgayNhap,TKNguyenGia,TKDoiUng);
             if (ok)
             {                 
                         Response.Clear();Response.Write(idkhoachinh);
                         if (TKNguyenGia != "")
                         {
                             string sql1 = "";
                             sql1 = "if exists (select * from danhmuctaisandubi where tknguyengia like '" + 211 + "%') ";
                             sql1 += " insert danhmuctaisan(phieu_nhap_id,mats,tentaisan,hangsx,namsx,nguyengia,ngaynhap,tknguyengia,tkdoiung)";
                             sql1 += " values('"+phieu_nhap_id+"','"+MaTS_db+"','"+TenTaiSan_db+"','N"+HangSX+"','"+NamSX+"',"+NguyenGia+",'"+NgayNhap+"','"+TKNguyenGia+"','"+TKDoiUng+"')";
                             string sql2 = "";
                             sql2 = "delete danhmuctaisandubi where tknguyengia like '" + 211 + "%'";
                             DataAcess.Connect.ExecSQL(sql1);
                             DataAcess.Connect.ExecSQL(sql2);
                         }
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 }
 
 
