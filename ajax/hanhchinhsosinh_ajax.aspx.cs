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

public partial class hanhchinh_ajax : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "setTimKiem": setTimKiem(); break;
         }
     }
     private void setTimKiem()
     {
         string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
         DataTable table = DataAcess.Connect.GetTable(@"SELECT 
             D.TENPHONGKHAMBENH AS KHOA
            ,C.SOVAOVIEN AS sovaovien
            ,MAYT =''
            ,A.TENBENHNHAN AS tenbenhnhan
            ,A.NGAYSINH AS ngaysinh
            ,ISNULL([dbo].[kb_GetTuoi](A.NGAYSINH),'') AS tuoi
            ,case when A.gioitinh =0  then 1 else 0 end AS nam
            ,case when A.gioitinh =1  then 1 else 0 end as nu
            ,A.NGHENGHIEP AS nghenghiep
            , A.DANTOC AS DanToc
            ,A.QUOCTICH AS QuocTich
            ,sonha = ''
            ,THONPHO=''
            ,G.TENPHUONGXA AS phuongxaid
            ,F.QUANHUYENNAME AS quanhuyenid
            ,E.TINHNAME AS tinhid
            ,A.NOICONGTAC AS noicongtac
            ,case when A.LOAI =1  then 1 else 0 end AS bhyt
            ,case when A.LOAI =2  then 1 else 0 end as thuphi
            ,case when A.LOAI =3  then 1 else 0 end AS mien
            ,case when A.LOAI is null  then 1 else 0 end AS khac
            ,A.NGAYHETHAN AS ngayhethan
            ,ISNULL(SUBSTRING(A.SOBHYT,1,3),'') AS BH1
            ,ISNULL(SUBSTRING(A.SOBHYT,4,2),'') AS BH2
            ,ISNULL(SUBSTRING(A.SOBHYT,6,2),'') AS BH3
            ,ISNULL(SUBSTRING(A.SOBHYT,8,3),'') AS BH4
            ,ISNULL(SUBSTRING(A.SOBHYT,11,5),'') AS BH5
            ,ISNULL(A.NGUOILH + ' ,','') as NguoiLH
            ,ISNULL(A.DIACHILH,'') AS DiaChiLH
            ,ISNULL(A.DIENTHOAILH,'') AS DienThoaiLH
            ,ISNULL(DATEPART(HH,C.NGAYKHAM),'') AS giotiepnhan
            ,ISNULL(DATEPART(mm,C.NGAYKHAM),'') AS phuttiepnhan
            ,ISNULL(C.NGAYKHAM,'') AS ngaytiepnhan
            ,A.CHANDOANSOBO AS chandoansobo
            ,CASE WHEN A.NOIGIOITHIEU IS NULL THEN 0 ELSE 1 END AS  YTE
            ,CASE WHEN A.NOIGIOITHIEU IS NULL THEN 1 ELSE 0 END AS TUDEN
            ,B.LYDO AS LYDOVAOVIEN
            ,NGAYTHU =''
            FROM BENHNHAN A
            LEFT JOIN DANGKYKHAM B ON B.IDBENHNHAN=A.IDBENHNHAN
            LEFT JOIN KHAMBENH C ON C.IDDANGKYKHAM=B.IDDANGKYKHAM
            LEFT JOIN PHONGKHAMBENH D ON D.IDPHONGKHAMBENH = C.IDPHONGKHAMBENH
            LEFT JOIN TINH E ON E.TINHID=A.TINHID
            LEFT JOIN QUANHUYEN F ON F.QUANHUYENID=A.QUANHUYENID
            LEFT JOIN PHUONGXA G ON G.PHUONGXAID=A.PHUONGXAID
            WHERE IDKHAMBENH = '"+idkhoachinh+"'");
          string html = ""; 
         html += "<root>";
         html += Environment.NewLine;
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
 
                 for (int y = 0; y < table.Columns.Count; y++)
                 {

                     try
                     {
                         html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(DataProcess.sGetSaveValue(table.Rows[0][y].ToString(), "date")).ToString("dd/MM/yyyy") + "</data>";
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
 
 }
 
 
