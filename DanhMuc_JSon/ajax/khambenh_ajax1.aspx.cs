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
 
 public partial class khambenh_ajax : System.Web.UI.Page
 {
     protected DataProcess s_khambenh()
     {
             DataProcess khambenh = new DataProcess("khambenh");
             khambenh.data("idkhambenh", Request.QueryString["idkhambenh"]);
             khambenh.data("ngaykham",Request.QueryString["ngaykham"]);
             khambenh.data("idphongkhambenh","1");
             khambenh.data("IsDaCLS", Request.QueryString["IsDaCLS"]);
             khambenh.data("IsHaveCLS", "1");// chỉ lấy khám bệnh có chỉ định cls

            return khambenh;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "KetThucCLS": KetThucCLS(); break;
             case "setTimKiem": setTimKiem(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     
   
 
     private void setTimKiem()
     {
             if (Userlogin_new.HavePermision(this, "khambenh_Search"))
                     {
                     string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                     DataTable table = DataProcess.GetTable(@"select STT=row_number() over (order by T.idkhambenh),T.*
                                                               ,MABENHNHAN,TENBENHNHAN,T2.NGAYSINH,TENGIOITINH=DBO.GETGIOITINH(T2.GIOITINH),TENBACSI,KHOA=TENPHONGKHAMBENH
                                                                ,PHONG=DBO.HS_TENPHONG(T.PHONGID)
                                                               from khambenh T
                                                                LEFT JOIN BENHNHAN T2 ON T.IDBENHNHAN=T2.IDBENHNHAN
                                                                LEFT JOIN PHONGKHAMBENH T3 ON T.IDPHONGKHAMBENH=T3.IDPHONGKHAMBENH
                                                                LEFT JOIN BACSI T4 ON T.IDBACSI=T4.IDBACSI
                                                                WHERE T.IDKHAMBENH=" +idkhoachinh
                                                             );
                     Response.Clear();
                     Response.Write(DataProcess.JSONDataTable_Parameters(table));
                 }
             else
                     {
                         Response.Write("Bạn không có quyền xem dữ liệu");
                         Response.StatusCode = 500;
                     }
     }

     private void KetThucCLS()
     {
         try
         {
             DataProcess process = s_khambenh();
             if (process.getData("idkhambenh") != null && process.getData("idkhambenh") != "")
             {
                 string SQL = "UPDATE KHAMBENH SET IsDaCLS=1 WHERE IDKHAMBENH=" + process.getData("idkhambenh");
                bool ok= DataAcess.Connect.ExecSQL(SQL);
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
                Response.Write(process.getData("idkhambenh"));
                return;
             }
             Response.StatusCode = 500;
         }
         catch (Exception)
         {
             Response.StatusCode = 500;
         }
     }
     private void TimKiem()
     {
        if (Userlogin_new.HavePermision(this, "khambenh_Search"))
         {
                DataProcess process = s_khambenh();
                process.EnablePaging = false;

                string sqlSelect = @"select STT=row_number() over (order by T.idkhambenh),T.*
                                                   ,MABENHNHAN,TENBENHNHAN,T2.NGAYSINH,TENGIOITINH=DBO.GETGIOITINH(T2.GIOITINH),TENBACSI,KHOA=TENPHONGKHAMBENH
                                                    ,PHONG=DBO.HS_TENPHONG(T.PHONGID)
                                                   from khambenh T
                                                    LEFT JOIN BENHNHAN T2 ON T.IDBENHNHAN=T2.IDBENHNHAN
                                                    LEFT JOIN PHONGKHAMBENH T3 ON T.IDPHONGKHAMBENH=T3.IDPHONGKHAMBENH
                                                    LEFT JOIN BACSI T4 ON T.IDBACSI=T4.IDBACSI
                                                    where " + process.sWhere();
                string MABENHNHAN = Request.QueryString["MABENHNHAN"];
                string TenBenhNhan = Request.QueryString["TENBENHNHAN"];
                if (MABENHNHAN != null && MABENHNHAN != "")
                    sqlSelect += " AND T2.MABENHNHAN LIKE N'%" + MABENHNHAN + "%'";
                if (TenBenhNhan != null && TenBenhNhan != "")
                    sqlSelect += " AND (T2.TENBENHNHAN LIKE N'%" + TenBenhNhan + "%' OR T2.NameNotSign LIKE '%" + StaticData.s_GetNameNotSign(TenBenhNhan) + "%')";

                 DataTable table = process.Search(sqlSelect );
                    Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table));
         }
         else
         {
             Response.Write("Bạn không có quyền xem dữ liệu.");
         }
     }
 }
 
 
