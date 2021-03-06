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

public partial class bienlai_CapCuu_ajax : System.Web.UI.Page
 {
     
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "TimKiem": TimKiem(); break;
         }
     }

     private void TimKiem()
     {
         DataProcess process = new DataProcess("bienlai");
         process.Page = Request.QueryString["page"];

         DataTable tablekhambenh = DataAcess.Connect.GetTable("select iddangkykham from khambenh where idkhambenh='" + Request.QueryString["idkhambenhgoc"] + "'");

         string iddangkykham = tablekhambenh.Rows.Count > 0 ? tablekhambenh.Rows[0][0].ToString() : "0";
         DataTable table = process.Search(@"SELECT 
                ROW_NUMBER() OVER  (ORDER BY SOBIENLAI) AS STT, 
                NGAYTHANG,
                KYHIEU,
                QUYENSO,
                SOBIENLAI,
                NOIDUNGTHU,
                SOTIEN
                FROM (
                  (
                    SELECT convert(varchar(10),A.NGAYDANGKY, 103) AS NGAYTHANG,KYHIEU='',QUYENSO='',A.MAPHIEUDANGKY AS SOBIENLAI,B.NOIDUNG AS NOIDUNGTHU,
                    (SELECT ISNULL( SUM(DONGIA),0) FROM CHITIETDANGKYKHAM WHERE IDDANGKYKHAM=" + iddangkykham + @") AS SOTIEN
                    FROM DANGKYKHAM A
                    LEFT JOIN SOCHUNGTU B ON B.SOPHIEUCT=A.MAPHIEUDANGKY
                left join CHITIETDANGKYKHAM ctdkk  on ctdkk.iddangkykham=a.iddangkykham
                    WHERE A.IDDANGKYKHAM=" + iddangkykham+ @"
                and ctdkk.idchitietdangkykham not in (select idchitietdangkykham from khambenh left join banggiadichvu on idbanggiadichvu=idDVphongchuyenden where huongdieutri=13 and madichvu='3000') 

                  )
                UNION ALL
                  (
                    SELECT convert(varchar(10),A.NGAYTHU, 103) AS NGAYTHANG,KYHIEU='',QUYENSO='',A.MAPHIEUCLS AS SOBIENLAI,B.NOIDUNG AS NOIDUNGTHU,
                     ISNULL( SUM(A.DONGIA),0)  AS SOTIEN
                    FROM KHAMBENHCANLAMSAN A
                    LEFT JOIN SOCHUNGTU B ON B.SOPHIEUCT=A.MAPHIEUCLS
                    LEFT JOIN KHAMBENH C ON C.IDKHAMBENH=A.IDKHAMBENH
                    WHERE C.IDDANGKYKHAM=" + iddangkykham + @" GROUP BY A.NGAYTHU,A.MAPHIEUCLS,B.NOIDUNG
                  )
                UNION ALL
                  (
                    SELECT convert(varchar(10),A.NGAYTAMUNG, 103) AS NGAYTHANG,KYHIEU='',QUYENSO='',B.SOPHIEUCT AS SOBIENLAI,N'Thu tạm ứng' AS NOIDUNGTHU,
                    ISNULL( SUM(A.SOTIEN),0)  AS SOTIEN
                    FROM TAMUNG A
                    LEFT JOIN SOCHUNGTU B ON B.STT=A.SOCTTU
                    WHERE A.IDDANGKYKHAM=" + iddangkykham + @" GROUP BY A.NGAYTAMUNG,B.SOPHIEUCT,B.NOIDUNG
                  )
                )ABC ");
         string html = "";
         html += process.Paging();
         html += "<table class='jtable' id=\"gridTable\">";
         html += "<tr>";
         html += "<th>STT</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NGAYTHANG") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("KYHIEU") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("QUYENSO") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOBIENLAI") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NOIDUNGTHU") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SOTIEN") + "</th>";
         html += "</tr>";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                     html += "<tr>";
                     html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                     html += "<td>" + table.Rows[i]["NGAYTHANG"].ToString() + "</td>";
                     html += "<td>" + table.Rows[i]["KYHIEU"].ToString() + "</td>";
                     html += "<td>" + table.Rows[i]["QUYENSO"].ToString() + "</td>";
                     html += "<td>" + table.Rows[i]["SOBIENLAI"].ToString() + "</td>";
                     html += "<td>" + table.Rows[i]["NOIDUNGTHU"].ToString() + "</td>";
                     html += "<td>" + table.Rows[i]["SOTIEN"].ToString() + "</td>";
                     html += "</tr>";
                 }
             }
         }
         html += "</table>";
         html += process.Paging();
         Response.Clear(); Response.Write(html);
     }
        
    
 }
 
 
