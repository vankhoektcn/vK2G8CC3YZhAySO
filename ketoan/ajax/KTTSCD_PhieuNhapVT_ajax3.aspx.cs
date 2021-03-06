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
 
 public partial class PHIEU_NHAP_VT_ajax : System.Web.UI.Page
 {
     private string TaoMa(string LoaiPhieu, string Bangluu, string Maphieu)
     {
         string Xuatkq, chuoi, Tiepdaungu, Isnum;
         //Lay ma chung tu
         string sqllayma = "select Ma_ct_in, Isnum from DSManHinh where Ma_ct = '" + LoaiPhieu + "'";
         DataTable dtma = DataAcess.Connect.GetTable(sqllayma);
         Tiepdaungu = dtma.Rows[0]["Ma_ct_in"].ToString();
         Isnum = dtma.Rows[0]["Isnum"].ToString();
         //Kiem tra bang luu
         string sql = "select top 1 " + Maphieu + " from " + Bangluu + " where " + Maphieu + " Like '" + Tiepdaungu
             + "%' and isnumeric( substring(" + Maphieu + ", " + Isnum + ", 2))=1 order by " + Maphieu + " DESC";
         DataTable dt = DataAcess.Connect.GetTable(sql);

         if (dt.Rows.Count == 0)
         {
             Xuatkq = Tiepdaungu + "0001";
         }
         else
         {
             chuoi = dt.Rows[0][Maphieu].ToString();
             String Str = chuoi;
             string strLetter = "";
             string strDigit = "";
             int length = Str.Length;
             if ("" != Str)
             {
                 for (int i = 0; i < length; i++)
                 {
                     if (!Char.IsDigit(Str[i]))
                         strLetter += Str[i];
                     else
                         strDigit += Str[i];
                 }
             }

             chuoi = strDigit.Replace(Tiepdaungu, "");
             Int64 so = Convert.ToInt64(chuoi) + 1;
             if (so < 10)
             {
                 Xuatkq = Tiepdaungu + "000" + so;
             }
             else if (so < 100)
             {
                 Xuatkq = Tiepdaungu + "00" + so;
             }
             else if (so < 1000)
             {
                 Xuatkq = Tiepdaungu + "0" + so;
             }
             else
             {
                 Xuatkq = Tiepdaungu + so;
             }
         }
         //string thang = "";
         //thang = DateTime.Now.Month.ToString();
         //if (thang.Length == 1)
         //    thang = "0" + thang;
         //string nam = DateTime.Now.Year.ToString().Substring(2, 2);
         return Xuatkq;
     }
     protected DataProcess s_PHIEU_NHAP_VT()
     {
             DataProcess PHIEU_NHAP_VT = new DataProcess("PHIEU_NHAP_VT"); 
             PHIEU_NHAP_VT.data("phieu_nhap_id",Request.QueryString["idkhoachinh"]);
             string khoa=Request.QueryString["idkhoachinh"];
             if (Request.QueryString["do"] != "TimKiem")
             {
                 if (Request.QueryString["idkhoachinh"] == "")
                 {
                     //PHIEU_NHAP_VT.data("so_phieu", TaoMa("PNTS", "phieu_nhap_vt", "so_phieu"));
                     //PHIEU_NHAP_VT.data("so_phieu", StaticDataKT.CreateMaKT("PN_TSCD","Phieu_Nhap_VT","So_Phieu"));
                     string ngaylap=Request.QueryString["ngay_nhap"].ToString ();
                     PHIEU_NHAP_VT.data("so_phieu", StaticData.TaoMaSoTuDongKT_TSCC("Phieu_nhap_vt", "so_phieu", "PN_TSCD", ngaylap));
                 }
                 else
                     PHIEU_NHAP_VT.data("so_phieu", Request.QueryString["so_phieu"]);
             }
             else
                PHIEU_NHAP_VT.data("so_phieu",Request.QueryString["so_phieu"]);
             if (Request.QueryString["do"].ToString() == "TimKiem")
             {
                if (Request.QueryString["ngay_nhap"] != "" && Request.QueryString["ngay_nhap"] != null)
                    PHIEU_NHAP_VT.data("ngay_nhap", StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_nhap"].ToString()));
                else
                    PHIEU_NHAP_VT.data("ngay_nhap", Request.QueryString["ngay_nhap"]);
             }
             else
                 PHIEU_NHAP_VT.data("ngay_nhap", Request.QueryString["ngay_nhap"]);
             PHIEU_NHAP_VT.data("ma_ncc",Request.QueryString["ma_ncc"]);
             PHIEU_NHAP_VT.data("tk_co",Request.QueryString["tk_co"]);
             PHIEU_NHAP_VT.data("dien_giai",Request.QueryString["dien_giai"]);
             PHIEU_NHAP_VT.data("so_hd",Request.QueryString["so_hd"]);
             if (Request.QueryString["do"].ToString() == "TimKiem")
             {
                 if (Request.QueryString["ngay_lap_hd"] != "" && Request.QueryString["ngay_lap_hd"] != null)
                     PHIEU_NHAP_VT.data("ngay_lap_hd", StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_lap_hd"].ToString()));
                 else
                     PHIEU_NHAP_VT.data("ngay_lap_hd", Request.QueryString["ngay_lap_hd"]);
             }
             else
                 PHIEU_NHAP_VT.data("ngay_lap_hd", Request.QueryString["ngay_lap_hd"]);

             if (Request.QueryString["do"].ToString() == "TimKiem")
             {
                 if (Request.QueryString["hanthanhtoan"] != "" && Request.QueryString["hanthanhtoan"] != null)
                     PHIEU_NHAP_VT.data("hanthanhtoan", StaticData.ConvertDDMMtoMMDD(Request.QueryString["hanthanhtoan"].ToString()));
                 else
                     PHIEU_NHAP_VT.data("hanthanhtoan", Request.QueryString["hanthanhtoan"]);
             }
             else
                 PHIEU_NHAP_VT.data("hanthanhtoan", Request.QueryString["hanthanhtoan"]);

             PHIEU_NHAP_VT.data("so_seri",Request.QueryString["so_seri"]);
             PHIEU_NHAP_VT.data("idkho",Request.QueryString["idkho"]);
             PHIEU_NHAP_VT.data("tkchietkhau",Request.QueryString["tkchietkhau"]);
             PHIEU_NHAP_VT.data("tkvat",Request.QueryString["tkvat"]);
             PHIEU_NHAP_VT.data("loai_nt",Request.QueryString["loai_nt"]);
             PHIEU_NHAP_VT.data("ty_gia",Request.QueryString["ty_gia"]);
             PHIEU_NHAP_VT.data("id_loaiphi",Request.QueryString["id_loaiphi"]);
             if (Request.QueryString["tongphi"] != "" && Request.QueryString["tongphi"] != null)
                PHIEU_NHAP_VT.data("tongphi",Request.QueryString["tongphi"].ToString().Replace(",",""));
             else
                PHIEU_NHAP_VT.data("tongphi", "");
             PHIEU_NHAP_VT.data("user_dau",Request.QueryString["user_dau"]);
             PHIEU_NHAP_VT.data("user_cuoi",Request.QueryString["user_cuoi"]);
             PHIEU_NHAP_VT.data("date_dau",Request.QueryString["date_dau"]);
             PHIEU_NHAP_VT.data("date_cuoi",Request.QueryString["date_cuoi"]);
            return PHIEU_NHAP_VT;
     }
     protected DataProcess s_PHIEU_NHAP_VT_CT()
     {
             DataProcess PHIEU_NHAP_VT_CT = new DataProcess("PHIEU_NHAP_VT_CT"); 
             PHIEU_NHAP_VT_CT.data("phieu_nhap_ct_id",Request.QueryString["idkhoachinh"]);
             PHIEU_NHAP_VT_CT.data("phieu_nhap_id",Request.QueryString["phieu_nhap_id"]);
             PHIEU_NHAP_VT_CT.data("ma_vt",Request.QueryString["ma_vt"]);
             PHIEU_NHAP_VT_CT.data("ten_vt",Request.QueryString["ten_vt"]);
             PHIEU_NHAP_VT_CT.data("ma_kho",Request.QueryString["ma_kho"]);
             PHIEU_NHAP_VT_CT.data("so_luong",Request.QueryString["so_luong"]);
             PHIEU_NHAP_VT_CT.data("don_gia",Request.QueryString["don_gia"]);
             PHIEU_NHAP_VT_CT.data("thanh_tien",Request.QueryString["thanh_tien"]);
             PHIEU_NHAP_VT_CT.data("thue_suat",Request.QueryString["thue_suat"]);
             PHIEU_NHAP_VT_CT.data("tien_thue",Request.QueryString["tien_thue"]);
             PHIEU_NHAP_VT_CT.data("tong_tien",Request.QueryString["tong_tien"]);
             PHIEU_NHAP_VT_CT.data("tk_no",Request.QueryString["tk_no"]);
             PHIEU_NHAP_VT_CT.data("tien_phi",Request.QueryString["tien_phi"]);
             PHIEU_NHAP_VT_CT.data("chietkhau",Request.QueryString["chietkhau"]);
             PHIEU_NHAP_VT_CT.data("tienchietkhau",Request.QueryString["tienchietkhau"]);
            return PHIEU_NHAP_VT_CT;
     }

     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": SavePHIEU_NHAP_VT(); break;
             case "TimKiem": TimKiem(); break;
             case "setTimKiem": setTimKiem(); break;
             case "luuTablePHIEU_NHAP_VT_CT": LuuTablePHIEU_NHAP_VT_CT();break ;
             case "loadTablePHIEU_NHAP_VT_CT": loadTablePHIEU_NHAP_VT_CT(); break;
             //case "xoa": XoaPHIEU_NHAP_VT(); break;
             case "xoa": XoaPHIEU_NHAP_VT_CT(); break;
             //case "xoaPHIEU_NHAP_VT_CT": XoaPHIEU_NHAP_VT_CT(); break;
             case "nhacungcapSearch": nhacungcapSearch(); break;
             case "DanhSachTaiKhoan_Jquery": DanhSachTaiKhoan_Jquery(); break;
             case "ngoaiteSearch": ngoaiteSearch(); break;
             case "loaiphiSearch": loaiphiSearch(); break;
             case "khoSearch": khoSearch(); break;
             case "loainghiepvuSearch": loainghiepvuSearch(); break;
             case "vattuSearch": vattuSearch(); break;
         }
     }

     private void vattuSearch()
     {
         string key = Request.QueryString["q"];
         string obj = Request.QueryString["obj"];
         string sql = "";
         if(obj=="ma_vt")
            sql = "select ma_vt,ten_vt,tk_kho,dvt from dm_vat_tu_kt where istscd=1 and ma_vt like N'"+key+"%'";
         else
            sql = "select ma_vt,ten_vt,tk_kho,dvt from dm_vat_tu_kt where istscd=1 and ten_vt like N'%" + key + "%'";
         DataTable table = DataAcess.Connect.GetTable(sql);
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                     html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + "|" + table.Rows[i][3].ToString() + Environment.NewLine;
                 }
             }
         }
         Response.Clear(); Response.Write(html);
     }
     private void loainghiepvuSearch()
     {
        DataTable table = DataAcess.Connect.GetTable("select manghiepvu,tennghiepvu,tkco,tkck,tkthue,vat from dmnghiepvu where manghiepvu='PN_TSCD'");
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                     html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + "|" + table.Rows[i][3].ToString() + "|" + table.Rows[i][4].ToString() + "|" + table.Rows[i][5].ToString() + Environment.NewLine;
                 }
             }
         }
         Response.Clear(); Response.Write(html);
     }
     private void khoSearch()
     {
         DataTable table = DataAcess.Connect.GetTable("select idkho,tenkho from khothuoc");
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                     html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + Environment.NewLine;
                 }
             }
         }
         Response.Clear(); Response.Write(html);
     }
     private void loaiphiSearch()
     {
         DataTable table = DataAcess.Connect.GetTable("select id_lp,tenloaiphi from dmloaiphi");
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {

                     html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + Environment.NewLine;
                 }
             }
         }
         Response.Clear(); Response.Write(html);
     }
     private void ngoaiteSearch()
     {
         DataTable table = DataAcess.Connect.GetTable("select ngoai_te_id,ten_nt,ty_gia from dmngoaite");
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {

                     html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;

                 }
             }
         }
         Response.Clear(); Response.Write(html);
     }
     #region Load danh sach tai khoan
     public void DanhSachTaiKhoan_Jquery()
     {
         string key = Request.QueryString["q"];
         string idText = Request.QueryString["obj"];
         string sql = "";
         string html = "";
         //html += "|<div style =\"background-color: #4D67A2;height:20px\">";
         html += "|<div style=\"width: 350px; border-color: Black; border-width: 2px\">";
         html += "<div style=\"background-color:#5593DE; color:Blue;font-weight: bold\">";
         html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tài khoản</div>";
         html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên tài khoản</div>";
         html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Chi tiết</div>";
         html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Tài khoản cấp cha</div>";
         html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Cấp</div>";
         html += "</div>|";

         html += Environment.NewLine;
         try
         {
             sql = "select TaiKhoan,TenTaiKhoan,ChiTiet,TKCapCha,Cap from DanhMucTK ";

             if (!string.IsNullOrEmpty(key))
                 sql += "  where TaiKhoan  LIKE '" + key + "%' or TKCapCha   LIKE '" + key + "%'";
             DataTable dt = DataAcess.Connect.GetTable(sql);
             for (int i = 0; i < dt.Rows.Count; i++)
             {

                 html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan('" + dt.Rows[i]["TaiKhoan"] + "','" + idText + "')\">";
                 html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TaiKhoan"] + "</p>";
                 html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenTaiKhoan"] + "</p>";
                 html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ChiTiet"] + "</p>";
                 html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TKCapCha"] + "</p>";
                 html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["Cap"] + "</p>";
                 html += "</div>|" + dt.Rows[i]["TaiKhoan"];
                 html += Environment.NewLine;
             }

             Response.Write(html);
         }
         catch (Exception)
         {
             Response.Write("error");
         }
     }
     #endregion
     private void nhacungcapSearch()
     {
         string sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap,DiaChi from NhaCungCap";
         if (Request.QueryString["mancc"] != null)
            sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap,DiaChi from NhaCungCap where manhacungcap like '%"+ Request.QueryString["q"] +"%'";
         if (Request.QueryString["tenncc"] != null)
            sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap,DiaChi from NhaCungCap where tennhacungcap like '%" + Request.QueryString["q"] + "%'";            
         DataTable table = DataAcess.Connect.GetTable(sql);
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {

                     html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + "|" + table.Rows[i][3].ToString() + Environment.NewLine;

                 }
             }
         }
         Response.Clear(); Response.Write(html);
     }
     
     private void XoaPHIEU_NHAP_VT()
     {
         try
         {
                DataProcess process = s_PHIEU_NHAP_VT();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("phieu_nhap_id"));
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
 
     private void XoaPHIEU_NHAP_VT_CT()
     {
         try
         {
             //Kiểm tra phiếu nhập đã được tạo phiếu xuất chưa
            DataTable tbpn = DataAcess.Connect.GetTable("select phieu_nhap_ct_id from phieu_nhap_vt_ct where phieu_nhap_id='" + Request.QueryString["idkhoachinh"] + "'");
            int count = 0;
            for (int i = 0; i < tbpn.Rows.Count; i++)
            {
                string sqldmts = "select mats from danhmuctaisan where phieu_nhap_ct_id='" + tbpn.Rows[i][0].ToString() + "' and (isnull(phieu_xuat_ct_id,0) != 0 or phieu_xuat_ct_id != '' )";
                DataTable tbdmts = DataAcess.Connect.GetTable(sqldmts);
                if (tbdmts.Rows.Count > 0)
                {
                    count++;
                    
                }
                bool ktdeletedmts = DataAcess.Connect.ExecSQL("delete from danhmuctaisan where phieu_nhap_ct_id='" + tbpn.Rows[0][0].ToString() + "'");
            }
            if (count == 0)
            {
                //DataProcess process = s_PHIEU_NHAP_VT_CT();
                //bool ok = process.Delete();
                string sqldeletect = "delete from phieu_nhap_vt_ct where phieu_nhap_id='" + Request.QueryString["idkhoachinh"] + "'";
                bool ok = DataAcess.Connect.ExecSQL(sqldeletect);
                if (ok)
                {
                    XoaPHIEU_NHAP_VT();
                    Response.Clear(); Response.Write(Request.QueryString["idkhoachinh"]);
                    return;
                }
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
         //DataTable table = Process.PHIEU_NHAP_VT.dtSearchByphieu_nhap_id(idkhoachinh);
         DataProcess process = s_PHIEU_NHAP_VT();
         process.Page = Request.QueryString["page"];
         string sqlsearch = @"select STT=row_number() over (order by T.phieu_nhap_id),T.*,dmlp.tenloaiphi as mkv_id_loaiphi             
            ,ncc.TenNhaCungCap as ten_ncc
            ,ncc.DiaChi as diachi_ncc
            ,kt.tenkho as mkv_idkho
            from PHIEU_NHAP_VT T left join dmloaiphi dmlp on T.id_loaiphi=dmlp.id_lp
            left join dmngoaite nt on T.loai_nt=nt.ngoai_te_id
            left join khothuoc kt on T.idkho=kt.idkho
            left join nhacungcap ncc on T.ma_ncc=ncc.manhacungcap
                                where " + process.sWhere();
         DataTable table = DataAcess.Connect.GetTable(sqlsearch);         
         string html = "";
         html += "<root>";
         html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
         html += Environment.NewLine;
         if (table != null)
         {
             if (table.Rows.Count > 0)
             { 
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
     private void TimKiem()
     {
         DataProcess process = s_PHIEU_NHAP_VT();
         process.Page = Request.QueryString["page"];
         string sqlsearch = @"select STT=row_number() over (order by T.phieu_nhap_id),T.*,dmlp.tenloaiphi as mkv_id_loaiphi 
                        from PHIEU_NHAP_VT T left join dmloaiphi dmlp on T.id_loaiphi=dmlp.id_lp
                                where " + process.sWhere();
         sqlsearch += " and (select top 1 tk_no from phieu_nhap_vt_ct where phieu_nhap_id=T.phieu_nhap_id) like '211%'";         
                 DataTable table = process.Search(sqlsearch);
         string html ="";
         html += "<table class='jtable' id=\"tablefind\">";
         html += "<tr>";
         //html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("phieu_nhap_id") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("so_phieu") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_nhap") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_ncc") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tk_co") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dien_giai") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("so_hd") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_lap_hd") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("so_seri") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkchietkhau") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tkvat") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loai_nt") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ty_gia") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("id_loaiphi") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("mkv_id_loaiphi") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tongphi") + "</th>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr onclick=\"setControlFind('" + table.Rows[i]["phieu_nhap_id"].ToString() + "')\">";
                         html += "<td>" + table.Rows[i]["so_phieu"].ToString() + "</td>";
                         if(table.Rows[i]["ngay_nhap"].ToString() != ""){
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngay_nhap"].ToString()).ToString("dd/MM/yyyy") + "</td>";}
                        else{html += "<td>" + table.Rows[i]["ngay_nhap"].ToString()+ "</td>";}
                         html += "<td>" + table.Rows[i]["ma_ncc"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["tk_co"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["dien_giai"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["so_hd"].ToString() + "</td>";
                         if(table.Rows[i]["ngay_lap_hd"].ToString() != ""){
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngay_lap_hd"].ToString()).ToString("dd/MM/yyyy") + "</td>";}
                        else{html += "<td>" + table.Rows[i]["ngay_lap_hd"].ToString()+ "</td>";}
                         html += "<td>" + table.Rows[i]["so_seri"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["idkho"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["tkchietkhau"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["tkvat"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["loai_nt"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["ty_gia"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["id_loaiphi"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["mkv_id_loaiphi"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["tongphi"].ToString() + "</td>";
                 html += "</tr>";
             }
             html += "</table>";
            html += process.Paging();
                     Response.Clear();Response.Write(html);
             return;
         }}
         else
         {
                     Response.StatusCode = 500;
         }
     }
 
     private void SavePHIEU_NHAP_VT()
     {
         //try
         //{
             string vat = "0";
             string tennguoigiao = "";
             string hanthanhtoan="NULL";
             if (!string.IsNullOrEmpty(Request.QueryString["hanthanhtoan"]))
                 hanthanhtoan = StaticData.CheckDate_kt(Request.QueryString["hanthanhtoan"]);
             else
                 hanthanhtoan = "NULL";
             if (!string.IsNullOrEmpty(Request.QueryString["ten_nguoi_giao"]))
                 tennguoigiao = Request.QueryString["ten_nguoi_giao"];
             else
                 tennguoigiao = "NULL";
             if ( !string.IsNullOrEmpty(Request.QueryString["vat"]))
                 vat = Request.QueryString["vat"].ToString();
              DataProcess process = s_PHIEU_NHAP_VT();                                         
             if (process.getData("phieu_nhap_id") != null && process.getData("phieu_nhap_id") != "")
             {
             bool ok = process.Update();
             if (ok)
             {                 
                 string updatepn = "update phieu_nhap_vt set hanthanhtoan='" + hanthanhtoan +"',ten_nguoi_giao=N'"+tennguoigiao+"',vat=" + vat + ",manghiepvu='" + Request.QueryString["manghiepvu"] + "' where phieu_nhap_id=" + Request.QueryString["idkhoachinh"];
                 bool ktpn = DataAcess.Connect.ExecSQL(updatepn);
                 Response.Clear();Response.Write(process.getData("phieu_nhap_id"));
                 return;
             }
            }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                 DataTable dt = DataAcess.Connect.GetTable("select top 1 phieu_nhap_id from phieu_nhap_vt order by phieu_nhap_id desc");
                 string phieunhapid = "0";
                 if (dt.Rows.Count > 0)
                     phieunhapid = dt.Rows[0][0].ToString();
                 string updatepn = "update phieu_nhap_vt set hanthanhtoan='" + hanthanhtoan + "',ten_nguoi_giao=N'" + tennguoigiao + "',vat=" + vat + ",manghiepvu='" + Request.QueryString["manghiepvu"] + "' where phieu_nhap_id=" + phieunhapid;
                 bool ktpn = DataAcess.Connect.ExecSQL(updatepn);
                         Response.Clear();Response.Write(process.getData("phieu_nhap_id"));
                 return;
             }
           }
         //}
         //catch
         //{
         //}
                     Response.StatusCode = 500;
     }

     public void LuuVaoSoCai()
     {
         string sophieunhap = "";
         string ngaynhap = "";
         string mancc = "";
         string sohoadon = "";
         string ngaylaphd = "";
         string soseri = "";
         string tkco = "";
         string tkchietkhau = "";
         string tkvat = "";
         string vat = "";
         string diengiai = "";
         //sophieunhap = Request.QueryString["so_phieu"];
         ngaynhap = Request.QueryString["ngay_nhap"];
         mancc = Request.QueryString["ma_ncc"];
         sohoadon = Request.QueryString["so_hd"];
         ngaylaphd = Request.QueryString["ngay_lap_hd"];
         soseri = Request.QueryString["so_seri"];
         tkco = Request.QueryString["tk_co"];
         tkchietkhau = Request.QueryString["tkchietkhau"];
         tkvat = Request.QueryString["tkvat"];
         vat = Request.QueryString["vat"];
         diengiai = Request.QueryString["dien_giai"];
         try
         {
             string tk_no = "";
             double tien_thue = 0;
             double tien_hang = 0;
             double tien_ck = 0;
             //string ma_cc = "";
             string sql = "select a.so_phieu,tk_no,sum(tien_thue)tienthue,sum(thanh_tien)tienhang,sum(tienchietkhau)tienck ";
             sql += " from phieu_nhap_vt a inner join phieu_nhap_vt_ct b on a.phieu_nhap_id=b.phieu_nhap_id  ";
             sql += " where tk_no is not null and a.phieu_nhap_id=" + Request.QueryString["phieu_nhap_id"] + "";
             sql += " group by  b.tk_no,a.so_phieu";
             DataTable dt = new DataTable();
             dt = DataAcess.Connect.GetTable(sql);
             if (dt != null && dt.Rows.Count > 0)
             {
                 sophieunhap=dt.Rows[0]["so_phieu"].ToString ();
                 for (int i = 0; i < dt.Rows.Count; i++)
                 {
                     tk_no = dt.Rows[i]["tk_no"].ToString();
                     tien_thue = Convert.ToDouble(dt.Rows[i]["tienthue"].ToString());
                     tien_hang = Convert.ToDouble(dt.Rows[i]["tienhang"].ToString());
                     tien_ck = Convert.ToDouble(dt.Rows[i]["tienck"].ToString());
                     //ma_cc = dt.Rows[i]["manhacungcap"].ToString();
                     string sqlexec = "Exec spPhieuNhapKhoDuoc_SoCai_Save '" + sophieunhap + "','" + StaticData.CheckDate_kt(ngaynhap) + "','" + tk_no + "','" + tkchietkhau + "','" + tkco + "','" + tkvat + "',N'" + diengiai + "','" + sohoadon + "','" + "" + "','";
                     sqlexec += StaticData.CheckDate(ngaynhap) + "'," + tien_thue + "," + tien_hang + "," + tien_ck + ",'" + mancc + "'," + i + "," + vat + "";
                     bool ktsc = DataAcess.Connect.ExecSQL(sqlexec);
                 }
             }
         }
         catch
         { }
     }

     public void LuuTablePHIEU_NHAP_VT_CT()
     {
         //try
         //{
         if (Request.QueryString["ma_vt"] != "")
         {
             string idkho = "0";
             if (Request.QueryString["idkho"] != "" && Request.QueryString["idkho"] != null)
                 idkho = Request.QueryString["idkho"].ToString();
             DataProcess process = s_PHIEU_NHAP_VT_CT();
             if (process.getData("phieu_nhap_ct_id") != null && process.getData("phieu_nhap_ct_id") != "")
             {
                 bool ok = process.Update();
                 if (ok)
                 {
                     //Update danh mục tài sản
                     string sqldmts = @"select phieu_nhap_ct_id,dmvt.tk_kho,dmvt.ten_vt,dmvt.nuoc_sx,nam_sx 
                        from phieu_nhap_vt_ct pnct left join dm_vat_tu_kt dmvt on pnct.ma_vt=dmvt.ma_vt where phieu_nhap_ct_id=" + Request.QueryString["idkhoachinh"] + " order by phieu_nhap_ct_id desc";
                     DataTable dtpnvtct = DataAcess.Connect.GetTable(sqldmts);

                     string sqlupdatedmts = "update danhmuctaisan set mats='" + Request.QueryString["ma_vt"] + "'";
                     sqlupdatedmts += ",tentaisan='" + Request.QueryString["ten_vt"] + "'";
                     sqlupdatedmts += ",hangsx=N'" + dtpnvtct.Rows[0]["nuoc_sx"].ToString() + "'";
                     if (dtpnvtct.Rows[0]["nam_sx"].ToString() != "")
                         sqlupdatedmts += ",namsx=" + dtpnvtct.Rows[0]["nam_sx"].ToString();
                     else
                         sqlupdatedmts += ",namsx=0";
                     sqlupdatedmts += ",sohoadonnhap='" + Request.QueryString["so_hd"] + "'";
                     if (Request.QueryString["ngay_lap_hd"] != "")
                         sqlupdatedmts += ",ngaylaphoadon='" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_lap_hd"].ToString()) + "'";
                     if (Request.QueryString["ngay_nhap"] != "")
                         sqlupdatedmts += ",ngaynhap='" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_nhap"].ToString()) + "'";
                     double nguyengia = 0;
                     double tongtien = 0;
                     double chiphi = 0;
                     double tienthue = 0;
                     int soluong=1;
                     if (!string.IsNullOrEmpty(Request.QueryString["so_luong"]))
                         soluong = int.Parse(Request.QueryString["so_luong"].ToString());
                     if (Request.QueryString["tong_tien"] != "")
                         tongtien = double.Parse(Request.QueryString["tong_tien"].ToString().Replace(",", ""));
                     if (!string.IsNullOrEmpty(Request.QueryString["tien_phi"]) )
                         chiphi = double.Parse(Request.QueryString["tien_phi"].ToString().Replace(",", ""));
                     
                     
                     nguyengia = (tongtien + chiphi) / soluong;
                     //sqlupdatedmts += ",nguyengia=" + nguyengia;
                     sqlupdatedmts += ",tknguyengia='" + dtpnvtct.Rows[0]["tk_kho"].ToString() + "'";
                     sqlupdatedmts += ",istscd=1";
                     sqlupdatedmts += " where phieu_nhap_ct_id=" + Request.QueryString["idkhoachinh"];

                     bool updatedmts = DataAcess.Connect.ExecSQL(sqlupdatedmts);
                     ///////
                     string updatethem = "update phieu_nhap_vt_ct set idkho=" + idkho + " where phieu_nhap_ct_id=" + Request.QueryString["idkhoachinh"];
                     bool ktupdatethem = DataAcess.Connect.ExecSQL(updatethem);
                     LuuVaoSoCai();
                     Response.Clear(); Response.Write(process.getData("phieu_nhap_ct_id"));
                     return;
                 }
             }
             else
             {
                 bool ok = process.Insert();
                 if (ok)
                 {
                     //Insert danh mục tài khoản
                     string sqldmts = @"select top 1 phieu_nhap_ct_id,dmvt.tk_kho,dmvt.ten_vt,dmvt.nuoc_sx,nam_sx 
                        from phieu_nhap_vt_ct pnct left join dm_vat_tu_kt dmvt on pnct.ma_vt=dmvt.ma_vt order by phieu_nhap_ct_id desc";
                     DataTable dtpnvtct = DataAcess.Connect.GetTable(sqldmts);
                     string sqlinsertdmts = "insert into danhmuctaisan(phieu_nhap_ct_id,MaTS,NgayLapHoaDon,NgayNhap,TKNguyenGia,idkho,soluong_hienco,istscd) values(" + dtpnvtct.Rows[0][0].ToString();
                     sqlinsertdmts += ",'" + Request.QueryString["ma_vt"] + "'";
                     double nguyengia = 0;
                     double tongtien = 0;
                     double chiphi = 0;
                     double soluong = 1;                     
                     try
                     {
                         soluong = double.Parse(Request.QueryString["so_luong"].ToString());
                     }
                     catch
                     {
                         soluong = 1;
                     }
                     if (soluong == 0)
                         soluong = 1;
                     if (!string.IsNullOrEmpty(Request.QueryString["tong_tien"]))
                         tongtien = double.Parse(Request.QueryString["tong_tien"].ToString().Replace(",", ""));
                     if (!string.IsNullOrEmpty(Request.QueryString["tien_phi"]))
                         chiphi = double.Parse(Request.QueryString["tien_phi"].ToString().Replace(",", ""));
                     
                     nguyengia = (tongtien + chiphi) / soluong;
                     //sqlinsertdmts += "," + nguyengia.ToString();
                    
                     if (!string.IsNullOrEmpty(Request.QueryString["ngay_lap_hd"]))
                         sqlinsertdmts += ",'" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_lap_hd"].ToString()) + "'";
                     if (!string.IsNullOrEmpty(Request.QueryString["ngay_nhap"]))
                         sqlinsertdmts += ",'" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_nhap"].ToString()) + "'";                    
                     sqlinsertdmts += ",'" + dtpnvtct.Rows[0]["tk_kho"].ToString() + "'";                     
                     //idkho, soluong_hienco
                     if (!string.IsNullOrEmpty(Request.QueryString["idkho"]))
                         sqlinsertdmts += "," + Request.QueryString["idkho"]; 
                     else
                         sqlinsertdmts += ",null";
                     if (!string.IsNullOrEmpty(Request.QueryString["so_luong"]))
                         sqlinsertdmts += "," + Request.QueryString["so_luong"]+",1)";
                     else
                         sqlinsertdmts += ",null,1)";
                     //neu chua co mats trong danh muc thi insert vao;neu co roi thi update soluong hien 
                     //kiem tra:
                     //string sqlmats = " select * from danhmuctaisan where mats='" + Request.QueryString["ma_vt"].ToString().Trim() + "'";
                     //DataTable dtts = DataAcess.Connect.GetTable(sqlmats);
                     //if (dtts != null && dtts.Rows.Count > 0)
                     //{
                     //    string sqlupdatesl = "";
                     //}
                     bool insertdmts = DataAcess.Connect.ExecSQL(sqlinsertdmts);
                     ////////////
                     DataTable tbupdatethem = DataAcess.Connect.GetTable("select top 1 phieu_nhap_ct_id from phieu_nhap_vt_ct order by phieu_nhap_ct_id desc");
                     string updatethem = "update phieu_nhap_vt_ct set idkho=" + idkho + " where phieu_nhap_ct_id=" + tbupdatethem.Rows[0][0].ToString();

                     bool ktupdatethem = DataAcess.Connect.ExecSQL(updatethem);
                     LuuVaoSoCai();
                     Response.Clear(); Response.Write(process.getData("phieu_nhap_ct_id"));
                     return;
                 }
             }
         }
             
         //}
         //catch
         //{
         //}
                     Response.StatusCode = 500;
     }

     public void loadTablePHIEU_NHAP_VT_CT()
    {
         DataProcess process = s_PHIEU_NHAP_VT_CT();
         string sqlsearch = @"select STT=row_number() over (order by T.phieu_nhap_ct_id),T.*,kt.tenkho,dmvt.dvt
                            from PHIEU_NHAP_VT_CT T left join khothuoc kt on T.idkho=kt.idkho
                            left join dm_vat_tu_kt dmvt on T.ma_vt=dmvt.ma_vt
                            where T.phieu_nhap_id='" + process.getData("phieu_nhap_id") + "'";
         process.Page = Request.QueryString["page"];
                 DataTable table = process.Search(sqlsearch);
         string html ="";
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
         html += "<th>STT</th>";
         html += "<th></th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã TS") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên Tài Sản") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ĐVT") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Kho") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK Nợ") + "</th>"; 
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số Lượng") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Chiết Khấu") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("T.Tiền CK") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("T.Tiền T.Thuế") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thuế Suất") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền Thuế") + "</th>";         
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền Phí") + "</th>";         
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tổng Tiền") + "</th>";
         html += "<th></th>";
         html += "</tr>";
         if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr>";
                 html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                 if (StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_PhieuNhapVT3_Xoa"))
                    html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                 else
                    html += "<td><a onclick='xoaontable(this)'></a></td>";
                 html += "<td><input mkv='true' id='ma_vt' type='text' onfocusout='chuyenformout(this)' onfocus='vattuSearch(this);' value='" + table.Rows[i]["ma_vt"].ToString() + "' style='width:100px;' /></td>";
                         html += "<td><input mkv='true' id='ten_vt' type='text' onfocusout='chuyenformout(this)' onfocus='vattuSearch1(this);' value='" + table.Rows[i]["ten_vt"].ToString() + "' /></td>";
                         html += "<td><input mkv='true' id='dvt' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='' value='" + table.Rows[i]["dvt"].ToString() + "' style='width:40px;' /></td>";
                         html += "<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' />";
                         html += "<input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='khoSearch1(this);' value='" + table.Rows[i]["tenkho"].ToString() + "' class='down_select' /></td>";

                         html += "<td><input mkv='true' id='tk_no' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan1(this);' value='" + table.Rows[i]["tk_no"].ToString() + "' style='width:40px;' /></td>";
                         html += "<td><input mkv='true' id='so_luong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["so_luong"].ToString() + "' onblur='tinhtien(this);' style='width:40px;'/></td>";
                         try
                         {
                             html += "<td><input mkv='true' id='don_gia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["don_gia"].ToString())) + "' onblur='tinhtien(this);' style='text-align:right;'/></td>";
                         }
                         catch
                         {
                             html += "<td><input mkv='true' id='don_gia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["don_gia"].ToString() + "' onblur=';tinhtien(this);' style='text-align:right;'/></td>";
                         }
                         html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["chietkhau"].ToString() + "' onblur='TestSo(this,false,false);tinhtien(this);' style='width:40px;' /></td>";
                         try
                         {
                             html += "<td><input mkv='true' id='tienchietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["tienchietkhau"].ToString())) + "' onblur='tinhtien(this);' style='text-align:right;'/></td>";
                         }
                         catch
                         {
                             html += "<td><input mkv='true' id='tienchietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tienchietkhau"].ToString() + "' onblur='tinhtien(this);' style='text-align:right;'/></td>";
                         }
                         try
                         {
                             html += "<td><input mkv='true' id='thanh_tien' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["thanh_tien"].ToString())) + "' onblur='' style='text-align:right;'/></td>";
                         }
                         catch
                         {
                             html += "<td><input mkv='true' id='thanh_tien' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["thanh_tien"].ToString() + "' onblur='' style='text-align:right;'/></td>";
                         }
                         html += "<td><input mkv='true' id='thue_suat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["thue_suat"].ToString() + "' onblur='tinhtien(this);' style='width:40px;'/></td>";
                         try
                         {
                             html += "<td><input mkv='true' id='tien_thue' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["tien_thue"].ToString())) + "' onblur='tinhtien(this);' style='text-align:right;'/></td>";
                         }
                         catch
                         {
                             html += "<td><input mkv='true' id='tien_thue' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tien_thue"].ToString() + "' onblur='tinhtien(this);' style='text-align:right;'/></td>";
                         }
                         try
                         {
                             html += "<td><input mkv='true' id='tien_phi' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["tien_phi"].ToString())) + "' onblur='tinhtien(this);' style='text-align:right;'/></td>";
                         }
                         catch
                         {
                             html += "<td><input mkv='true' id='tien_phi' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tien_phi"].ToString() + "' onblur='tinhtien(this);' style='text-align:right;'/></td>";
                         }
                         
                         try
                         {
                             html += "<td><input mkv='true' id='tong_tien' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["tong_tien"].ToString())) + "' onblur='TestSo(this,false,false);'/></td>";
                         }
                         catch
                         {
                             html += "<td><input mkv='true' id='tong_tien' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tong_tien"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                         }
                 html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["phieu_nhap_ct_id"].ToString() + "'/></td>";
                 html += "</tr>";
             }
         }
         else
         {
                 html += "<tr>";
                 html += "<td>1</td>";
                 if (StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_PhieuNhapVT3_Xoa"))
                    html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                 else
                    html += "<td><a onclick='xoaontable(this)'></a></td>";
                 html += "<td><input mkv='true' id='ma_vt' type='text' onfocusout='chuyenformout(this)' onfocus='vattuSearch(this);' value='' style='width:100px;' /></td>";
                 html += "<td><input mkv='true' id='ten_vt' type='text' onfocusout='chuyenformout(this)' onfocus='vattuSearch1(this);' value='' style='width:200px;' /></td>";
                         html += "<td><input mkv='true' id='dvt' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='' value='' style='width:40px;' /></td>";
                         html += "<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);' value='' />";
                         html += "<input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='khoSearch1(this);boidenchuoi(this);' value='' /></td>";

                         html += "<td><input mkv='true' id='tk_no' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);ShowTaiKhoan1(this);boidenchuoi(this);' value='' style='width:40px;' /></td>";
                         html += "<td><input mkv='true' id='so_luong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);' value='' onblur='tinhtien(this);' style='width:40px;' /></td>";
                         html += "<td><input mkv='true' id='don_gia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);boidenchuoi(this);' value='' onblur='tinhtien(this);' style='text-align:right;' /></td>";
                         html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);' value='' onblur='TestSo(this,false,false);tinhtien(this);' style='width:40px;' /></td>";
                         html += "<td><input mkv='true' id='tienchietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);' value='' onblur='tinhtien(this);' style='text-align:right;' /></td>";
                         html += "<td><input mkv='true' id='thanh_tien' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);' value='' onblur='' style='text-align:right;' /></td>";
                         html += "<td><input mkv='true' id='thue_suat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);' value='' onblur='tinhtien(this);' style='width:40px;-align:right' /></td>";
                         html += "<td><input mkv='true' id='tien_thue' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);' value='' onblur='tinhtien(this);' /></td>";
                         html += "<td><input mkv='true' id='tien_phi' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);boidenchuoi(this);' value='' onblur='tinhtien(this);' style='text-align:right;'' /></td>";
                         html += "<td><input mkv='true' id='tong_tien' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='' style='text-align:right;' /></td>";
                 html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
                 html += "</tr>";
         }
         html += "<tr><td></td><td></td></tr>";
         html += "</table>";
        html += process.Paging("PHIEU_NHAP_VT_CT");
                 Response.Clear();Response.Write(html);
     }
 }
 
 
