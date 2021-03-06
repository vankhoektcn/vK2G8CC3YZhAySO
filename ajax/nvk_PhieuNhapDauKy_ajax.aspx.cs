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

public partial class nvk_PhieuNhapDauKy_ajax : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Them": Insertphieunhapkho(); break;
             case "Sua": Updatephieunhapkho(); break;
             case "setTimKiem": setTimKiem(); break;
             case "luuTablechitietphieunhapkho": LuuTablechitietphieunhapkho();break ;
             case "loadTablechitietphieunhapkho": loadTablechitietphieunhapkho(); break;
             case "xoa": Xoaphieunhapkho(); break;
             case "xoachitietphieunhapkho": Xoachitietphieunhapkho(); break;
              case "droplist_idkho": LoadDropList_idkho(); break;
              case "droplist_idloaithuoc": LoadDropList_idloaithuoc(); break;
              case "getthuoc": getthuoc(); break;
              case "laybaocao": laybaocao(); break;
         }
     }
     profess_Rpt_SoDuDauKy p = null;
     private void laybaocao()
     {
         string IDKho = Request.QueryString["idkho"].ToString();
         string TuNgay = Request.QueryString["ngaythang"].ToString();
         string loaithuoc = Request.QueryString["idloaithuoc"].ToString();
         string tenthuoc = Request.QueryString["tenthuoc"].ToString();
         p = new profess_Rpt_SoDuDauKy();
         p.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(p_AfterExportToExcel);
         p.TuNgay = StaticData.CheckDate(TuNgay);
         p.IDKho = IDKho;
         p.loaithuoc = loaithuoc;
         p.TenThuoc = tenthuoc;
         p.TenKho =Thuoc_Process.khothuoc.dtSearchByidkho(IDKho).Rows[0][Profess.TBLS.tbl_khothuoc.tenkho.ToString()].ToString();
         p.TenLoaiThuoc = Thuoc_Process.Thuoc_LoaiThuoc.dtSearchByLoaiThuocID(loaithuoc).Rows[0]["tenloai"].ToString();
         p.ExportToExcel();

     }

     void p_AfterExportToExcel()
     {
         Response.Write("../ReportOutput/" + p.OutputFileName);
     }
     private void getthuoc()
     {
         string sql = "";
         if (Request.QueryString["q"] != null)
         {
             sql = Request.QueryString["q"];
         }       

         string html = "";
         string sqlSelect = @"select top 20 idthuoc,tenthuoc,iddvt,giamoinhat=isnull((select top 1 dongia from chitietphieunhapkho where isnull(dongia,0)>0 and idthuoc=t.idthuoc and idphieunhap in(select idphieunhap from phieunhapkho where idkho ='"+StaticData.MacDinhKhoNhapMuaID+@"')
	                            order by idchitietphieunhapkho desc
                            ),0)
                             from thuoc t where tenthuoc like '%" + sql + "%' and IsThuocBV=1";
         string idKho = (Request.QueryString["idkho"] != null ? Request.QueryString["idkho"].ToString() : "");
         string idloaithuoc = (Request.QueryString["idloaithuoc"] != null ? Request.QueryString["idloaithuoc"].ToString() : "");
         if (idloaithuoc != null && idloaithuoc != "")
         {
             sqlSelect += " and loaithuocid='" + idloaithuoc + "'";
         }
         sqlSelect += " order by tenthuoc ";
         DataTable table = DataAcess.Connect.GetTable(sqlSelect);
         for (int i = 0; i < table.Rows.Count; i++)
         {
             html += table.Rows[i][1] + "|" + table.Rows[i][0] + "|" + table.Rows[i][2] + "|" + table.Rows[i]["giamoinhat"] + Environment.NewLine;
         }
         Response.Clear();
         Response.Write(html);
         Response.End();
     }

     // luon luon chi co 2 truong la id va value
     private void LoadDropList_idkho()
     {
         string idkhoa = Request.QueryString["idkhoa"];
         if (idkhoa == null || idkhoa.Equals(""))
             idkhoa = "0";
         DataTable table = DataAcess.Connect.GetTable("select * from khothuoc where nvk_loaikho in(2) and idkhoa="+idkhoa+"");//Thuoc_Process.khothuoc.dtGetAll();
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int y = 0; y < table.Rows.Count; y++)
             {
 
                 html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y]["tenkho"].ToString();
 
             }
         }
     }
                Response.Clear(); Response.Write(html);
}
     private void LoadDropList_idloaithuoc()
     {
         DataTable table = Thuoc_Process.khothuoc.GetTable("select * from thuoc_loaithuoc ");
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int y = 0; y < table.Rows.Count; y++)
                 {

                     html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y][2].ToString();

                 }
             }
         }
         Response.Clear(); Response.Write(html);
     }
     private void Xoaphieunhapkho()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();

             string sqlTest = @"SELECT A.IDPHIEUXUAT
                                FROM CHITIETPHIEUXUATKHO A
                                LEFT JOIN CHITIETPHIEUNHAPKHO B ON A.IDCHITIETPHIEUNHAPKHO=B.IDCHITIETPHIEUNHAPKHO
                                WHERE B.IDPHIEUNHAP=" + idkhoachinh;

             DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
             if (dtTest != null && dtTest.Rows.Count > 0)
             {
                 Response.Clear(); Response.Write("");
                 return;
             }


             string sql_CHITIETPHIEUNHAPKHO = "delete CHITIETphieunhapkho where idphieunhap=" + idkhoachinh;
             bool ok1 = Thuoc_Process.phieunhapkho.ExecSQL(sql_CHITIETPHIEUNHAPKHO);
             if (ok1)
             {




                 string sql = "delete phieunhapkho where idphieunhap=" + idkhoachinh;
                 bool ok = Thuoc_Process.phieunhapkho.ExecSQL(sql);
                 if (ok)
                 {
                     Response.Clear(); Response.Write(idkhoachinh);
                     return;
                 }
             }

         }
         catch
         {
         }
         Response.Clear(); Response.Write("");
     }
 
     private void Xoachitietphieunhapkho()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();


             string sqlTest = "SELECT ISNULL( SUM(SOLUONG),0) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUNHAPKHO=" + idkhoachinh;
             DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
             if (dtTest != null && dtTest.Rows.Count > 0)
             {
                 string slXuat = dtTest.Rows[0][0].ToString();
                 float d_slXuat = float.Parse(slXuat);
                 if (d_slXuat > 0)
                 {
                     Response.Clear(); Response.Write("");
                     return;
                 }
             }


             string sql = "delete chitietphieunhapkho where idchitietphieunhapkho=" + idkhoachinh;
             bool ok = Thuoc_Process.chitietphieunhapkho.ExecSQL(sql);
             if (ok)
             {
                         Response.Clear();Response.Write(idkhoachinh);
                 return;
             }
         }
         catch
         {
                     
         }
         Response.Clear(); Response.Write("");
     }
     private void setTimKiem()
     {
         string sql = "1=1";
         if (Request.QueryString["idkho"] != null)
         {
             sql += " and idkho = '" + Request.QueryString["idkho"] + "'";
         }
         if (Request.QueryString["idloaithuoc"] != null)
         {
             sql += "  and exists (select idchitietphieunhapkho from chitietphieunhapkho ct inner join thuoc t on t.idthuoc =ct.idthuoc and t.loaithuocid='" + Request.QueryString["idloaithuoc"] + "' where idphieunhap =p.idphieunhap )";
         }
         string nvk_sqlDK = @"select distinct idphieunhap,ngaythang,idkho  from phieunhapkho p 
         where maphieunhap='Khaibaodauky' and " + sql;
         DataTable table = Thuoc_Process.phieunhapkho.GetTable(nvk_sqlDK);
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
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
             }
         }
         Response.Clear(); Response.Write(html);
     }
 
    

     private void Insertphieunhapkho()
     {
         try
         {
             char[] splitter = { '/' };
             string maphieunhap = "Khaibaodauky";
             string ngaythang = "";
             if (Request.QueryString["ngaythang"].ToString() != "")
             {
                 string[] ngaythangcurent2 = Request.QueryString["ngaythang"].ToString().Split(splitter);
                 ngaythang = ngaythangcurent2[1] + "/" + ngaythangcurent2[0] + "/" + ngaythangcurent2[2] + " " + DateTime.Now.ToString("HH:mm:ss");
             }           
             
              string idkho = Request.QueryString["idkho"].ToString();
             string nhacungcapid = "";
             string tennguoigiao = "";
             string kyhieuhoadon = "";
             string sohoadon = "";
             string ngayhoadon = "";
             string tkno = "";
             string tkco = "";
             string tkvat = "";
             string nhapcho = "";
             string ghichu = "Nhap dau ky";
             string vat = "0";
             string thanhtien = "0";
             string idkhachhang = "";
             string idnguoinhap = "";
             string idloainhap = "";
             string IsBHYT = "";
             string tienhang = "0";
             string tienvat = "0";
             string tongtien = "0";
             string ptn = "";
             string TrangThai = "1";
             string idphieuxuat = "";
             Thuoc_Process.phieunhapkho tempTT = Thuoc_Process.phieunhapkho.Insert_Object(maphieunhap,
                                                                                         ngaythang, 
                                                                                         idkho,
                                                                                         nhacungcapid, 
                                                                                         tennguoigiao, 
                                                                                         kyhieuhoadon, 
                                                                                         sohoadon,
                                                                                         ngayhoadon, 
                                                                                         tkno, 
                                                                                         tkco, 
                                                                                         tkvat,
                                                                                         nhapcho,
                                                                                         ghichu, 
                                                                                         vat,
                                                                                         thanhtien,
                                                                                         idkhachhang,
                                                                                         idnguoinhap,
                                                                                         idloainhap, 
                                                                                         IsBHYT, 
                                                                                         tienhang,
                                                                                         tienvat,
                                                                                         tongtien,
                                                                                         ptn,
                                                                                         TrangThai,
                                                                                         idphieuxuat,
                                                                                         null
                                                                                         );
             if (tempTT != null)
             {
                 Response.Clear(); Response.Write(tempTT.idphieunhap);
                 return;
             }
         }
         catch
         {
            
         }
         Response.Clear(); Response.Write("");

     }
     private void Updatephieunhapkho()
     {
         try
         {
             char[] splitter = { '/' };
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
             string maphieunhap = "Khaibaodauky";
             string ngaythang = "";
             if (Request.QueryString["ngaythang"].ToString() != "")
             {
                 string[] ngaythangcurent2 = Request.QueryString["ngaythang"].ToString().Split(splitter);
                 ngaythang = ngaythangcurent2[1] + "/" + ngaythangcurent2[0] + "/" + ngaythangcurent2[2] + " " + DateTime.Now.ToString("HH:mm:ss");
             }           
            
             Thuoc_Process.phieunhapkho temp = Thuoc_Process.phieunhapkho.Create_phieunhapkho(idkhoachinh);
             bool ok = temp.Save_Object(maphieunhap, ngaythang, temp.idkho, temp.nhacungcapid
                 , temp.tennguoigiao, temp.kyhieuhoadon, temp.sohoadon, temp.ngayhoadon, temp.tkno, temp.tkco,
                 temp.tkvat, temp.nhapcho, temp.ghichu, temp.vat, temp.thanhtien, temp.idkhachhang,
                 temp.idnguoinhap, temp.idloainhap, temp.IsBHYT, temp.tienhang, temp.tienvat
                 , temp.tongtien, temp.ptn, temp.TrangThai
                 ,temp.IdPhieuXuat,temp.nhacungcapid);
             if (ok)
             {
                 Response.Clear(); Response.Write(idkhoachinh);
                 return;
             }
         }
         catch
         {
            
         }
         Response.Clear(); Response.Write("");
     }
     public void LuuTablechitietphieunhapkho()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
             char[] splitter = { '/' };
             string idphieunhap = Request.QueryString["idphieunhap"].ToString();
             string idthuoc = Request.QueryString["idthuoc"].ToString();
             string soluong = Request.QueryString["soluong"].ToString().Replace(",","");
             string thanhtien = Request.QueryString["thanhtien"].ToString().Replace(",","");
             string dongia = Request.QueryString["dongia"].ToString().Replace(",","");
             try
             {
                 float k = float.Parse(thanhtien) / float.Parse(soluong);
                 dongia = Math.Round(k, 0).ToString();
             }
             catch (Exception) { }
             string chietkhau = "0";
             string vat = "0";
             string dgsauchietkhau = "0";
             string ngayhethan = "";
             if (Request.QueryString["ngayhethan"].ToString() != "")
             {
                 string[] ngaythangcurent2 = Request.QueryString["ngayhethan"].ToString().Split(splitter);
                 ngayhethan = ngaythangcurent2[1] + "/" + ngaythangcurent2[0] + "/" + ngaythangcurent2[2] + " " + DateTime.Now.ToString("HH:mm:ss");

             }
           
             string losanxuat = Request.QueryString["losanxuat"].ToString();
             string dongiaban = "0";
             string soluongthue = "0";
             string thue = "0";
             string soluongtang = "0";
             string idtu = "0";
             string idngan = "0";
             string soluongxuat = "0";
             string dvt = Request.QueryString["dvt"].ToString();

             string thanhtientruocthue = thanhtien;
             string tienthue = "0";
             string daapgia = "0";
             string heso = "0";
             string tiensauchietkhau = thanhtien;
             string tienchietkhau = "0";
             string Sltct = soluong;
             string IdChiTietPhieuXuatKho = "";
             if (!idkhoachinh.Trim().Equals(""))
             {
                 string sqlTest = "SELECT ISNULL( SUM(SOLUONG),0) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETPHIEUNHAPKHO=" + idkhoachinh;
                 DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
                 if (dtTest != null && dtTest.Rows.Count > 0)
                 {
                     string slXuat = dtTest.Rows[0][0].ToString();
                     float d_slXuat = float.Parse(slXuat);
                     float d_SLNhap = float.Parse(soluong);
                     if (d_slXuat > d_SLNhap)
                     {
                         Response.Clear(); Response.Write("");
                         return;
                     }
                 }

                 Thuoc_Process.chitietphieunhapkho temp = Thuoc_Process.chitietphieunhapkho.Create_chitietphieunhapkho(idkhoachinh);
                 bool ok = temp.Save_Object(idphieunhap, idthuoc, soluong, dongia, chietkhau, vat, dgsauchietkhau, ngayhethan, losanxuat, dongiaban, soluongthue, thue, soluongtang, idtu, idngan, soluongxuat, dvt, thanhtien, thanhtientruocthue, tienthue, daapgia, heso, tiensauchietkhau, tienchietkhau, Sltct, temp.IdChiTietPhieuXuatKho,null);
                 if (ok)
                 {
                     Response.Clear(); Response.Write(idkhoachinh);
                     return;
                 }
             }
             else
             {
                 Thuoc_Process.chitietphieunhapkho tempTT = Thuoc_Process.chitietphieunhapkho.Insert_Object(idphieunhap, idthuoc, soluong, dongia, chietkhau, vat, dgsauchietkhau, ngayhethan, losanxuat, dongiaban, soluongthue, thue, soluongtang, idtu, idngan, soluongxuat, dvt, thanhtien, thanhtientruocthue, tienthue, daapgia, heso, tiensauchietkhau, tienchietkhau, Sltct, IdChiTietPhieuXuatKho,null);
                 if (tempTT != null)
                 {
                     Response.Clear(); Response.Write(tempTT.idchitietphieunhapkho);
                     return;
                 }
             }
         }
         catch (Exception) { }
         Response.Clear(); Response.Write("");
     }
     public void loadTablechitietphieunhapkho()
     {
         string sql = "";
         string sotrang = "1";
         string tieuchimoi = "";
         if (Request.QueryString["sotrang"] != null && Request.QueryString["sotrang"].ToString() != "")
         {
             sotrang = Request.QueryString["sotrang"].ToString();
         }
         if (Request.QueryString["idloaithuoc"] != null && Request.QueryString["idloaithuoc"].ToString() != "")
         {
             tieuchimoi += " and b.loaithuocid = '" + Request.QueryString["idloaithuoc"] + "'";
         }
         if (Request.QueryString["tenthuoc"] != null && Request.QueryString["tenthuoc"].ToString() != "")
         {
             tieuchimoi += " and b.tenthuoc like N'" + Request.QueryString["tenthuoc"].ToString() + "%'";
         }

         sql += Request.QueryString["idkhoachinh"].ToString();
         DataTable table1 = DataAcess.Connect.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");//Profess.Thuoc_DonViTinh.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");
         string sqlSelect = @"select * from(
                select stt= row_number() over (order by idchitietphieunhapkho),idchitietphieunhapkho,
                 a.ngayhethan,a.losanxuat,a.dongia,a.soluong,b.tenthuoc,a.dvt,a.idthuoc,a.thanhtien
                from chitietphieunhapkho a  left join thuoc b on a.idthuoc=b.idthuoc
                where b.isthuocbv=1 and idphieunhap = '" + sql + "'" + tieuchimoi;

         string sqlAdd = " )abc where stt between (" + sotrang + "-1)*50+1 and " + sotrang + " * 50";

         string idKho = null;

         //if (Request.QueryString["idkho"] == null || Request.QueryString["idkho"].ToString() == "" || Request.QueryString["idkho"].ToString() == "0")
         //{
         //    if (Request.QueryString["idkhoachinh"].ToString() != "")
         //        idKho = DataAcess.Connect.GetTable("SELECT IDKHO FROM PHIEUNHAPKHO WHERE IDPHIEUNHAP=" + Request.QueryString["idkhoachinh"].ToString()).Rows[0][0].ToString();
         //}
         //else idKho = Request.QueryString["idkho"].ToString();


         //if (idKho != null && idKho != "")
         //{

         //    sqlSelect += "and a.idthuoc IN (SELECT   idthuoc from Thuoc_Kho where IdKHo=" + idKho + ")";
         //}

         sqlSelect += sqlAdd;

         DataTable table = Thuoc_Process.chitietphieunhapkho.GetTable(sqlSelect);
         string html = "";
         html += "<table id=\"gridTables\" border=\"1\" align=\"center\" width=\"100%\" bgcolor=\"white\">";
         html += "<tr style='background-color:blue;color:white;font-weight:bold;height:50px;text-align:center'>";
         html += "<td style='font-size:20px;font-weight:bold'>STT</td>";
         html += "<td></td>";
         html += "<td></td>";
         if (Request.QueryString["idloaithuoc"] != null && Request.QueryString["idloaithuoc"].ToString() != "")
         {
             DataTable table_loaithuoc = DataAcess.Connect.GetTable("select * from thuoc_loaithuoc where loaithuocid='" + Request.QueryString["idloaithuoc"].ToString() + "'");
             html += "<td style='font-size:20px;font-weight:bold'>" + table_loaithuoc.Rows[0]["tenloai"] + "</td>";
         }
         else
         {
             html += "<td style='font-size:20px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc") + "</td>";
         }
         html += "<td style='font-size:20px;font-weight:bold'>DVT</td>";
         html += "<td style='font-size:20px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("losanxuat") + "</td>";
         html += "<td style='font-size:20px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayhethan") + "</td>";
         html += "<td style='font-size:20px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</td>";
         html += "<td style='font-size:20px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</td>";

         html += "<td style='font-size:20px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</td>";

         if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                 html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                 html += "<td><a onclick='xoaontable(this.name,this)' name='" + table.Rows[i]["idchitietphieunhapkho"].ToString() + "'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                 html += "<td><input id='idthuoc_" + (i + 1) + "' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                 html += "<td><input id='tenthuoc_" + (i + 1) + "' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);timkiemthuoc(this);checkchuyenphim=true;' onkeydown='chuyendong(this);' value='" + table.Rows[i]["tenthuoc"].ToString() + "'/></td>";
                 html += "<td><select id='dvt_" + (i + 1) + "' />";
                 for (int ii = 0; ii < table1.Rows.Count; ii++)
                 {
                     if (table.Rows[i]["dvt"].ToString() == table1.Rows[ii][0].ToString())
                     {
                         html += "<option selected value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                     }
                     else
                     {
                         html += "<option value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                     }
                 }
                 html += "</select></td>";

                 html += "<td><input id='losanxuat_" + (i + 1) + "' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='" + table.Rows[i]["losanxuat"].ToString() + "' /></td>";
                 if (table.Rows[i]["ngayhethan"].ToString() != "")
                 {
                     html += "<td><input id='ngayhethan_" + (i + 1) + "' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='" + DateTime.Parse(table.Rows[i]["ngayhethan"].ToString()).ToString("dd/MM/yyyy") + "' onblur='TestDate(this)' /></td>";
                 }
                 else { html += "<td><input id='ngayhethan_" + (i + 1) + "' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='" + table.Rows[i]["ngayhethan"].ToString() + "' onblur='TestDate(this);Kiemngay(this);' /></td>"; }
                 html += "<td><input  style='width:80px;text-align:right'  id='soluong_" + (i + 1) + "' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='" + table.Rows[i]["soluong"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                 html += "<td><input  style='width:100px;text-align:right'  id='dongia_" + (i + 1) + "' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='" + table.Rows[i]["dongia"].ToString() + "' onblur='TestSo(this,false,true);tinhthanhtien(this);' /></td>";
                 html += "<td><input  style='width:100px;text-align:right'  id='thanhtien_" + (i + 1) + "' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='" + table.Rows[i]["thanhtien"].ToString() + "' onblur='TestSo(this,false,true);tinhdongia(this)'/></td>";

                 html += "<td><input type='hidden' value='" + table.Rows[i]["idchitietphieunhapkho"].ToString() + "'/></td>";
                 html += "</tr>";
             }
         }
         else
         {
             table.Rows.Add(table.NewRow());
             html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
             html += "<td>1</td>";
             html += "<td><a onclick='xoaontable(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
             html += "<td><input id='idthuoc_1' type='hidden'  /></td>";
             html += "<td><input id='tenthuoc_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);timkiemthuoc(this);checkchuyenphim=true;' onkeydown='chuyendong(this);' value='' /></td>";
             html += "<td><select id='dvt_1' />";
             for (int ii = 0; ii < table1.Rows.Count; ii++)
             {
                 html += "<option value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
             }
             html += "</select></td>";
             html += "<td><input id='losanxuat_1'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='' /></td>";
             html += "<td><input id='ngayhethan_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='' onblur='TestDate(this);Kiemngay(this);' /></td>";
             html += "<td><input style='width:80px' id='soluong_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='' onblur='TestSo(this,false,true);' /></td>";
             html += "<td><input style='width:100px' id='dongia_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='' onblur='TestSo(this,false,true);tinhthanhtien(this);' /></td>";
             html += "<td><input style='width:100px' id='thanhtien_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)' onkeydown='chuyendong(this);' value='' onblur='TestSo(this,false,true);tinhdongia(this)' /></td>";

             html += "<td><input type='hidden' value=''/></td>";
             html += "</tr>";
         }
         DataTable tablepaging = DataAcess.Connect.GetTable("select count(idchitietphieunhapkho) sodong from chitietphieunhapkho a  left join thuoc b on a.idthuoc=b.idthuoc where idphieunhap='" + sql + "' " + tieuchimoi + "");
         int sodongpaging = int.Parse(tablepaging.Rows[0][0].ToString()) / 50;
         int sodongdu = int.Parse(tablepaging.Rows[0][0].ToString()) % 50;
         if (sodongdu != 0)
         {
             sodongpaging = sodongpaging + 1;
         }
         html += "<tr><td></td><td></td><td colspan='7' align='center'>";
         for (int i = 1; i <= sodongpaging; i++)
         {
             if (sotrang != i.ToString())
             {
                 html += "<a style='color:blue;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"phantrang('" + i + "','" + Request.QueryString["idkhoachinh"].ToString() + "');\">" + i + "</a>";
             }
             else
             {
                 html += i;
             }
         }
         html += "</td></tr>";
         html += "</table>";
         Response.Clear(); Response.Write(html);
     }
 }