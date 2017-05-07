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
 
 public partial class zBaoCaoSuDung15Ngay_ajax : System.Web.UI.Page
 {
     protected DataProcess s_zBaoCaoSuDung15Ngay()
     {
             DataProcess zBaoCaoSuDung15Ngay = new DataProcess("zBaoCaoSuDung15Ngay"); 
             zBaoCaoSuDung15Ngay.data("ID",Request.QueryString["idkhoachinh"]);
             zBaoCaoSuDung15Ngay.data("nYear",Request.QueryString["nYear"]);
             zBaoCaoSuDung15Ngay.data("nMonth",Request.QueryString["nMonth"]);
             zBaoCaoSuDung15Ngay.data("IsDauThang",Request.QueryString["IsDauThang"]);
             zBaoCaoSuDung15Ngay.data("IdKho",Request.QueryString["IdKho"]);
             zBaoCaoSuDung15Ngay.data("IdLoaiThuoc",Request.QueryString["IdLoaiThuoc"]);
            return zBaoCaoSuDung15Ngay;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Luu": SavezBaoCaoSuDung15Ngay(); break;
             case "TimKiem": TimKiem(); break;
             case "setTimKiem": setTimKiem(); break;
             case "xoa": XoazBaoCaoSuDung15Ngay(); break;
              case "IdKhoSearch": IdKhoSearch(); break;
              case "IdLoaiThuocSearch": IdLoaiThuocSearch(); break;
              case "InitData": InitData(); break;
              case "XuatExcel": XuatExcel(); break;
         }
     }
 
     private void IdKhoSearch()
     {
         string IdKhoa = Request.QueryString["IdKhoa"];
         string IdKho = Request.QueryString["IdKho"];
         string sqlSelectKho = "SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 ";
         if (IdKho != null && IdKho != "" && IdKho != "0")
             sqlSelectKho += " AND IDKHO=" + IdKho;
         else
             if (IdKhoa != null && IdKhoa != "" && IdKhoa != "0")
                 sqlSelectKho += " AND IDKHOa=" + IdKhoa;

         DataTable table = DataProcess.GetTable(sqlSelectKho);
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["tenkho"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void IdLoaiThuocSearch()
     {
         DataTable table = DataProcess.GetTable("select * from Thuoc_LoaiThuoc ");
         StringBuilder html = new StringBuilder();
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
 
                 html.AppendLine(table.Rows[i]["TenLoai"].ToString() + "|" + table.Rows[i][0].ToString());
 
             }
         }
     }
     Response.Clear();Response.Write(html);
}
     private void XoazBaoCaoSuDung15Ngay()
     {
         try
         {
                DataProcess process = s_zBaoCaoSuDung15Ngay();
                  bool ok = process.Delete();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ID"));
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
         DataTable table = DataProcess.GetTable(@"select top 1 T.*
                   ,mkv_IdKho = A.tenkho
                   ,mkv_IdLoaiThuoc = B.TenLoai
                               from zBaoCaoSuDung15Ngay T
                    left join khothuoc  A on T.IdKho=A.idkho
                    left join Thuoc_LoaiThuoc  B on T.IdLoaiThuoc=B.LoaiThuocID
 where T.ID ='"+idkhoachinh+"'");
          StringBuilder html = new StringBuilder(); html.AppendLine("<root>");
         html.AppendLine("<data id=\"idkhoachinh\">" + idkhoachinh + "</data>");

         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
 
                 for (int y = 0; y < table.Columns.Count; y++)
                 {
                         html.AppendLine("<data id='" + table.Columns[y].ToString() + "'>" + DataProcess.sGetDate(table.Rows[0][y].ToString(),false,true) + "</data>");
                 }
             }
         }
         html.AppendLine("</root>");
         Response.Clear();
         Response.Write(html.ToString().Replace("&", "&amp;"));
     }
 
     private void TimKiem()
     {
                DataProcess process = s_zBaoCaoSuDung15Ngay();
         process.Page = Request.QueryString["page"];
                 DataTable table = process.Search(@"select STT=row_number() over (order by T.ID),T.*
                   ,A.tenkho
                   ,B.TenLoai
                               from zBaoCaoSuDung15Ngay T
                    left join khothuoc  A on T.IdKho=A.idkho
                    left join Thuoc_LoaiThuoc  B on T.IdLoaiThuoc=B.LoaiThuocID
          where "+process.sWhere());
         StringBuilder html = new StringBuilder();
         html.Append("<table class='jtable' id=\"gridTable\">");
         html.Append("<tr>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ID") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nYear") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("nMonth") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IsDauThang") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKho") + "</th>");
         html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdLoaiThuoc") + "</th>");
         html.Append("</tr>");
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["ID"].ToString() + "')\">");
                         html.Append("<td>" + table.Rows[i]["nYear"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["nMonth"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["IsDauThang"].ToString() + "</td>");
                         html.Append("<td>" + table.Rows[i]["tenkho"].ToString()+ "</td>");
                         html.Append("<td>" + table.Rows[i]["TenLoai"].ToString()+ "</td>");
                 html.Append("</tr>");
             }
             html.Append("</table>");
            html.Append(process.Paging());
                     Response.Clear();Response.Write(html);
             return;
         }}
         else
         {
                     Response.StatusCode = 500;
         }
     }
     //───────────────────────────────────────────────────────────────────────────────────────         
     private void SavezBaoCaoSuDung15Ngay()
     {
         try
         {
              DataProcess process = s_zBaoCaoSuDung15Ngay();
             if (process.getData("ID") != null && process.getData("ID") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ID"));
                 return;
             }
           }
           else
           {
                bool ok =  process.Insert();
             if (ok)
             {
                         Response.Clear();Response.Write(process.getData("ID"));
                 return;
             }
           }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
     //───────────────────────────────────────────────────────────────────────────────────────  
     private void InitData()
     {
         
         StringBuilder html = new StringBuilder();
         html.AppendLine("<root>");
         html.AppendLine("<data id=\"nYear\">" + DateTime.Now.ToString("yyyy") + "</data>");
         html.AppendLine("<data id=\"nMonth\">" + DateTime.Now.ToString("MM") + "</data>");
         html.AppendLine("</root>");
         Response.Clear();
         Response.Write(html.ToString().Replace("&", "&amp;"));
     }
     //───────────────────────────────────────────────────────────────────────────────────────  
     private profess_Rpt_SuDung15Ngay NXTReport = null; 
     private void XuatExcel()
     {
         string LoaiThuocID = Request.QueryString["LoaiThuocID"];
         string IdKho = Request.QueryString["IdKho"];
         string nYear = Request.QueryString["nYear"];
         string nMonth = Request.QueryString["nMonth"];
         bool IsDauThang =StaticData.IsCheck( Request.QueryString["IsDauThang"]);
         string TenLoaiThuoc = Request.QueryString["TenLoaiThuoc"];
         string TenKho = Request.QueryString["TenKho"];

         NXTReport = new profess_Rpt_SuDung15Ngay();
         NXTReport.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(NXTReport_AfterExportToExcel);
         NXTReport.LoaiThuocID = LoaiThuocID;
         NXTReport.IdKho = IdKho;
         NXTReport.TenLoaiThuoc = TenLoaiThuoc;
         NXTReport.TenKho = TenKho;

         if (IsDauThang)
         {
             NXTReport.FromDate = nYear + "-" + nMonth + "-" + "01";
             NXTReport.ToDate = nYear + "-" + nMonth + "-" + "15";
         }
         else
         {
             NXTReport.FromDate = nYear + "-" + nMonth + "-" + "16";
             NXTReport.ToDate = nYear + "-" + nMonth + "-" + DateTime.DaysInMonth(int.Parse(nYear), int.Parse(nMonth)).ToString() + "";
         }
         NXTReport.ExportToExcel();

     }
     void NXTReport_AfterExportToExcel()
     {
         Response.Write("../../ReportOutput/" + NXTReport.OutputFileName);
     }
     //───────────────────────────────────────────────────────────────────────────────────────        
 }
 
 
