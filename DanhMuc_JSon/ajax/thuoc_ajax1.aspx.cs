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
 using System.Text;
 
 public partial class thuoc_ajax : System.Web.UI.Page
 {
     profess_Rpt_Thuoc NXTReport = null;
     //________________________________________________________________________________
     protected DataProcess s_thuoc()
     {
             DataProcess thuoc = new DataProcess("thuoc"); 
             thuoc.data("idthuoc",Request.QueryString["idkhoachinh"]);
             thuoc.data("tenthuoc",Request.QueryString["tenthuoc"]);
             thuoc.data("congthuc",Request.QueryString["congthuc"]);
             thuoc.data("duongdung",Request.QueryString["duongdung"]);
             thuoc.data("idnhomthuoc",Request.QueryString["idnhomthuoc"]);
             thuoc.data("iddvt",Request.QueryString["iddvt"]);
             thuoc.data("LoaiThuocID",Request.QueryString["LoaiThuocID"]);
             thuoc.data("IsThuocBV","0");
             thuoc.data("CateID",Request.QueryString["CateID"]);
             thuoc.data("IdCachDung",Request.QueryString["IdCachDung"]);
             thuoc.data("HamLuong",Request.QueryString["HamLuong"]);
            return thuoc;
     }
     //________________________________________________________________________________
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": Savethuoc(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": Xoathuoc(); break;
              case "TimKiem": TimKiem(); break;
              case "idnhomthuocSearch": idnhomthuocSearch(); break;
              case "iddvtSearch": iddvtSearch(); break;
              case "LoaiThuocIDSearch": LoaiThuocIDSearch(); break;
              case "CateIDSearch": CateIDSearch(); break;
              case "IdCachDungSearch": IdCachDungSearch(); break;
              case "TenThuocSearch": TenThuocSearch(); break;
              case "XuatExcel": XuatExcel(); break;
              case "TenThuocSearch2": TenThuocSearch2(); break;
              case "ThayTheThuoc": ThayTheThuoc(); break;                    
         }
     }
     //________________________________________________________________________________
     private void TenThuocSearch()
     {

         string tenthuoc = Request.QueryString["q"];
         string loaithuocid = Request.QueryString["loaithuocid"];
         string sqlSelect = "SELECT IDTHUOC,TENTHUOC FROM THUOC WHERE ISNULL(ISTHUOCBV,0)=0";
         if (tenthuoc != null && tenthuoc != "")
             sqlSelect += " AND TENTHUOC LIKE N'%"+tenthuoc+"%'";
         if (loaithuocid != null && loaithuocid != "")
             sqlSelect += " AND ISNULL(LOAITHUOCID,1)=" + loaithuocid;

         sqlSelect += " ORDER BY TENTHUOC";
         DataTable table = DataAcess.Connect.GetTable(sqlSelect);




         StringBuilder html = new StringBuilder();
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {

                     html.AppendLine(table.Rows[i]["TenThuoc"].ToString() + "|" + table.Rows[i][0].ToString());

                 }
             }
         }
         Response.Clear(); Response.Write(html);
     }

     //________________________________________________________________________________
     private void TenThuocSearch2()
     {
         TenThuocSearch();
     }

     //________________________________________________________________________________
     private void idnhomthuocSearch()
     {
         string CateID = Request.QueryString["CateID"];
         if (CateID == null || CateID == "") return;
         string TenNhom = Request.QueryString["q"].ToString();
         DataTable table = DataAcess.Connect.GetTable("select * from nhomthuoc where cateid="+CateID +" AND TENNHOM LIKE N'%"+TenNhom+"%' ORDER BY TENNHOM ");
         if (table == null) return;
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][3].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
//________________________________________________________________________________
     private void iddvtSearch()
     {
         string tenDVT = Request.QueryString["q"]; DataTable table = DataAcess.Connect.GetTable("SELECT * FROM THUOC_DONVITINH WHERE TENDVT LIKE N'" + tenDVT + "%' ORDER BY TENDVT");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
//________________________________________________________________________________
     private void LoaiThuocIDSearch()
     {
         DataTable table = Thuoc_Process.Thuoc_LoaiThuoc .dtGetAll();
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
//________________________________________________________________________________
     private void CateIDSearch()
     {
         string loaithuocid = Request.QueryString["loaithuocid"];
         DataTable table = Thuoc_Process.category.dtSearchByloaithuocid(loaithuocid);
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
//________________________________________________________________________________
     private void IdCachDungSearch()
     {
         DataTable table = Process_2608.Thuoc_CachDung.dtGetAll();
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
//________________________________________________________________________________
     private void Xoathuoc()
     {
         try
         {
                DataProcess process = s_thuoc();
                string sqlTest = "SELECT * FROM CHITIETBENHNHANTOATHUOC WHERE IDTHUOC=" + process.getData("idthuoc");
                DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
                if (dtTest == null || dtTest.Rows.Count > 0)
                {
                    Response.StatusCode = 500;
                    return;
                }
                  bool ok = process.Delete();
                if (ok)
                {
                 Response.Clear();Response.Write(process.getData("idthuoc"));
                 return;
                }
         }
         catch
         {
             Response.StatusCode = 500;
         }
                 
     }
     //________________________________________________________________________________
     private void setTimKiem()
     {
                 if (StaticData.HavePermision(this, "thuoc_Search"))
                         {
                         string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                         DataTable table = Thuoc_Process.thuoc.dtSearchByidthuoc(idkhoachinh);
                         StringBuilder html = new StringBuilder();
                          html.AppendLine("<root>");
                         html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");
                        DataTable idnhomthuoc = Thuoc_Process.nhomthuoc .dtSearchByidnhomthuoc("'" + table.Rows[0]["idnhomthuoc"] + "'");
                         html.AppendLine("<data id=\"mkv_idnhomthuoc\">" + ((idnhomthuoc.Rows.Count > 0) ? idnhomthuoc.Rows[0]["tennhom"] : "") + "</data>");
                         DataTable iddvt = Process_2608.Thuoc_DonViTinh.dtSearchById("'" + table.Rows[0]["iddvt"] + "'");
                         html.AppendLine("<data id=\"mkv_iddvt\">" + ((iddvt.Rows.Count > 0) ? iddvt.Rows[0][1] : "") + "</data>");
                        DataTable LoaiThuocID = Thuoc_Process.Thuoc_LoaiThuoc .dtSearchByLoaiThuocID("'" + table.Rows[0]["LoaiThuocID"] + "'");
                         html.AppendLine("<data id=\"mkv_LoaiThuocID\">" + ((LoaiThuocID.Rows.Count > 0) ? LoaiThuocID.Rows[0][1] : "") + "</data>");
                        DataTable CateID = Thuoc_Process.category .dtSearchBycateid("'" + table.Rows[0]["CateID"] + "'");
                          html.AppendLine("<data id=\"mkv_CateID\">" + ((CateID.Rows.Count > 0) ? CateID.Rows[0][1] : "") + "</data>");
                        DataTable IdCachDung = Process_2608.Thuoc_CachDung.dtSearchByidcachdung("'" + table.Rows[0]["IdCachDung"] + "'");
                        html.AppendLine("<data id=\"mkv_IdCachDung\">" + ((IdCachDung.Rows.Count > 0) ? IdCachDung.Rows[0][1] : "") + "</data>");
                     if (table != null)
                     {
                         if (table.Rows.Count > 0)
                         {
             
                             for (int y = 0; y < table.Columns.Count; y++)
                             {
                                 try
                                 {
                                     html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>");
                                 }
                                 catch
                                 {
                                     html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + table.Rows[0][y].ToString() + "</data>");
                                 }
                             }
                         }
                     }
                     html.AppendLine("</root>");
                     Response.Clear();
                     Response.Write(html.ToString().Replace("&", "&amp;"));
                 }
             else
                     {
                         Response.Write("Bạn không có quyền xem dữ liệu");
                         Response.StatusCode = 500;
                     }
     }
     //________________________________________________________________________________
     private void Savethuoc()
     {
         try
         {
              DataProcess process = s_thuoc();
             if (process.getData("idthuoc") != null && process.getData("idthuoc") != "")
             {
               bool ok = process.Update();
               if (ok)
               {
                   //AutoComplete.RefreshAffer_SaveThuoc(process.getData("idthuoc"));

                 Response.Clear();Response.Write(process.getData("idthuoc"));
                 return;
               }
           }
           else
           {
                     bool ok =  process.Insert();
                     if (ok)
                     {
                         //AutoComplete.RefreshAffer_InsertThuoc(process.getData("idthuoc"));

                         Response.Clear();Response.Write(process.getData("idthuoc"));
                         return;
                     }
           }
         }
         catch
         {
             Response.StatusCode = 500;
         }
                    
     }
     //________________________________________________________________________________
     private void TimKiem()
     {
        if (StaticData.HavePermision(this, "thuoc_Search"))
         {
             string tenthuoc = Request.QueryString["tenthuoc"];
             string congthuc = Request.QueryString["congthuc"];
             string cateid = Request.QueryString["cateid"];
             string idnhomthuoc = Request.QueryString["idnhomthuoc"];
             string loaithuocid = Request.QueryString["loaithuocid"];
             string sqlSelect = @"select STT=row_number() over (order by T.TENTHUOC),T.*
                   ,B.tennhom
                   ,C.TenDVT
                   ,D.MaLoai
                   ,G.tencachdung
                   from thuoc T
                    left join nhomthuoc  B on T.idnhomthuoc=B.idnhomthuoc
                    left join Thuoc_DonViTinh  C on T.iddvt=C.Id
                    left join Thuoc_LoaiThuoc  D on T.LoaiThuocID=D.LoaiThuocID
                    left join category  F on T.CateID=F.cateid
                    left join Thuoc_CachDung  G on T.IdCachDung=G.idcachdung
                    where ISNULL(ISTHUOCBV,0)=0";
                 if (tenthuoc != null && tenthuoc != "")
                     sqlSelect += " AND T.TENTHUOC LIKE N'" + tenthuoc + "%'";
                 if (congthuc != null && congthuc != "")
                     sqlSelect += " AND T.congthuc LIKE N'" + congthuc + "%'";
                 if (cateid != null && cateid != "")
                     sqlSelect += " AND T.cateid = '" + cateid + "'";
                 if (idnhomthuoc != null && idnhomthuoc != "")
                     sqlSelect += " AND T.idnhomthuoc = '" + idnhomthuoc + "'";
                 if (loaithuocid != null && loaithuocid != "")
                     sqlSelect += " AND T.loaithuocid = '" + loaithuocid + "'";
                DataProcess process = s_thuoc();
                 process.Page = Request.QueryString["page"];
                 DataTable table = process.Search(sqlSelect);
         StringBuilder html = new StringBuilder();
         html.Append(process.Paging());
         html.Append("<table class='jtable' id=\"gridTable\">");
         html.Append("<tr>");
          html.Append("<th>STT</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc") + "</th>");
         if (loaithuocid == "1")
         {
             html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("congthuc") + "</th>");
         }
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("iddvt") + "</th>");
         html.Append("</tr>");
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                        html.Append("<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idthuoc"].ToString() + "')\">");
                         html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                         html.Append("<td align='LEFT'>" + table.Rows[i]["tenthuoc"].ToString() + "</td>");
                         if (loaithuocid == "1")
                         {
                             html.Append("<td align='LEFT'>" + table.Rows[i]["congthuc"].ToString() + "</td>");
                         }
                         html.Append("<td>" + table.Rows[i]["TenDVT"].ToString() + "</td>");
                        html.Append("</tr>");
             }}}
         html.Append("</table>");
         html.Append(process.Paging());
         Response.Clear(); Response.Write(html);
         }
         else
         {
             Response.Write("Bạn không có quyền xem dữ liệu.");
         }
     }//end void
     //________________________________________________________________________________
     private void XuatExcel()
     {
         string LoaiThuocID = Request.QueryString["LoaiThuocID"];
         string CateID = Request.QueryString["CateID"];
         string NhomThuocID = Request.QueryString["NhomThuocID"];
         string IsThuocBV = Request.QueryString["IsThuocBV"];
         NXTReport = new profess_Rpt_Thuoc();
         NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
         NXTReport.LoaiThuocID = LoaiThuocID;
         NXTReport.CateID = CateID;
         NXTReport.NhomThuocID = NhomThuocID;
         NXTReport.IsThuocBV = IsThuocBV;
         NXTReport.ExportToExcel();
             
     }
     void NXTReport_AfterExportToExcel()
     {
         Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
     }
//________________________________________________________________________________
     private void ThayTheThuoc()
     {
         string idthuoc_tt = Request.QueryString["idthuoc_tt"];
         string idthuoc = Request.QueryString["idthuoc"];
         if (idthuoc == null || idthuoc == "" || idthuoc_tt == null || idthuoc_tt == "")
         {
             Response.StatusCode = 500;
             Response.Write("0");
             return;
         }
         string sqlUpdate1 = "UPDATE CHITIETBENHNHANTOATHUOC SET IDTHUOC=" + idthuoc_tt + " WHERE IDTHUOC=" + idthuoc;
         string sqlDelete1 = "DELETE THUOC WHERE IDTHUOC=" + idthuoc;
         bool OK1 = DataAcess.Connect.ExecSQL(sqlUpdate1);
         if (!OK1)
         {
             Response.StatusCode = 500;
             Response.Write("0");
             return;
         }
         bool OK2 = DataAcess.Connect.ExecSQL(sqlDelete1);
         if (!OK2)
         {
             Response.StatusCode = 500;
             Response.Write("0");
             return;
         }
         Response.Write("1");
     }
     //________________________________________________________________________________
 }//end class
 
 
