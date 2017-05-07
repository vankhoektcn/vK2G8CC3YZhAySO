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
 
 public partial class HS_DANHSACHTRAKQCLS_ajax : System.Web.UI.Page
 {
     protected DataProcess s_HS_DANHSACHTRAKQCLS()
     {
             DataProcess HS_DANHSACHTRAKQCLS = new DataProcess("HS_DANHSACHTRAKQCLS"); 
             HS_DANHSACHTRAKQCLS.data("ID",Request.QueryString["idkhoachinh"]);
             HS_DANHSACHTRAKQCLS.data("MAPHIEUCLS",Request.QueryString["MAPHIEUCLS"]);
             HS_DANHSACHTRAKQCLS.data("NGAYTHU",Request.QueryString["NGAYTHU"]);
             HS_DANHSACHTRAKQCLS.data("MABENHNHAN",Request.QueryString["MABENHNHAN"]);
             HS_DANHSACHTRAKQCLS.data("TENBENHNHAN",Request.QueryString["TENBENHNHAN"]);
             HS_DANHSACHTRAKQCLS.data("NGAYSINH",Request.QueryString["NGAYSINH"]);
             HS_DANHSACHTRAKQCLS.data("TENGIOITINH",Request.QueryString["TENGIOITINH"]);
             HS_DANHSACHTRAKQCLS.data("TENBACSI",Request.QueryString["TENBACSI"]);
             HS_DANHSACHTRAKQCLS.data("PHONG",Request.QueryString["PHONG"]);
             HS_DANHSACHTRAKQCLS.data("NHOMCLS",Request.QueryString["NHOMCLS"]);
             HS_DANHSACHTRAKQCLS.data("ISDATRA",Request.QueryString["ISDATRA"]);
            return HS_DANHSACHTRAKQCLS;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "luuTable": LuuTable_HS_DANHSACHTRAKQCLS();break ;
             case "xoa": Xoa_HS_DANHSACHTRAKQCLS(); break;
              case "TimKiem": TimKiem(); break;
         }
     }
 
     private void Xoa_HS_DANHSACHTRAKQCLS()
     {
         try
         {
                DataProcess process = s_HS_DANHSACHTRAKQCLS();
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
 
     private void LuuTable_HS_DANHSACHTRAKQCLS()
     {
         try
         {
              DataProcess process = s_HS_DANHSACHTRAKQCLS();
             if (process.getData("ID") != null && process.getData("ID") != "")
             {
             bool ok = process.Update();
             if (ok)
             {
                 if ( StaticData.IsCheck( process.getData("ISDATRA")))
                 {
                     string NowDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                     string sqlSelect = "SELECT * FROM KHAMBENHCANLAMSAN WHERE MAPHIEUCLS=(SELECT MAPHIEUCLS FROM HS_DANHSACHTRAKQCLS WHERE ID=" + process.getData("ID") + ")";
                     DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
                     if (dt != null && dt.Rows.Count > 0)
                     {
                         string MaPhieuCLS = dt.Rows[0]["MaPhieuCLS"].ToString();
                         string IdBenhNhan = dt.Rows[0]["IdBenhNhan"].ToString();
                         string NgayThu = dt.Rows[0]["NgayThu"].ToString();
                         string IdKhoaDangKy = dt.Rows[0]["IdKhoaDangKy"].ToString();
                         string IdKhamBenh = dt.Rows[0]["IdKhamBenh"].ToString();
                         bool ISDATRAKQ_OLD = StaticData.IsCheck(dt.Rows[0]["ISDATRAKQ"].ToString());
                         if (ISDATRAKQ_OLD == false)
                         {
                             if (IdKhamBenh == "0" || IdKhamBenh == "")
                             {
                                 if (IdKhoaDangKy == "") IdKhoaDangKy = "0";
                                 string sqlSaveDKK = @" UPDATE CHITIETDANGKYKHAM SET NgayTraKQCLS='" + NowDate + "'  WHERE YEAR(NGAYDANGKY_CHITIET)=YEAR('" + NgayThu + @"')
																			AND MONTH(NGAYDANGKY_CHITIET)=MONTH('" + NgayThu + @"')
																			AND DAY(NGAYDANGKY_CHITIET)=DAY('" + NgayThu + @"')
																			AND IDKHOA=" + IdKhoaDangKy + @"
																			AND IDBENHNHAN_CHITIET=" + IdBenhNhan;
                                 bool ok_ctdkk = DataAcess.Connect.ExecSQL(sqlSaveDKK);
                             }
                             else
                             {
                                 string sqlSaveKhamBenh = " UPDATE KHAMBENH SET NgayTraKQCLS='" + NowDate + "' WHERE IDKHAMBENH=" + IdKhamBenh;
                                 bool ok_KB = DataAcess.Connect.ExecSQL(sqlSaveKhamBenh);
                             }

                             string sqlSave2 = "UPDATE KHAMBENHCANLAMSAN SET ISDATRAKQ=1,THOIGIANTRAKQ='"+NowDate+"' WHERE  ISNULL(ISDATRAKQ,0)=0 AND   MAPHIEUCLS='" + MaPhieuCLS + "'";
                             bool ok2 = DataAcess.Connect.ExecSQL(sqlSave2);
                         }
                     }
                      
                 }

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
     private void TimKiem()
     {
         bool search = StaticData.HavePermision(this, "HS_DANHSACHTRAKQCLS_Search");
         if (search)
         {
             DataProcess process = s_HS_DANHSACHTRAKQCLS();
             string NgayThu = process.getData("NGAYTHU");
             NgayThu = StaticData.CheckDate(NgayThu);
             string TENBENHNHAN = process.getData("TENBENHNHAN");
             string MABENHNHAN = process.getData("MABENHNHAN");
             string sqlSelect = @"DELETE HS_DANHSACHTRAKQCLS
                                INSERT INTO HS_DANHSACHTRAKQCLS
                                SELECT  *
                                FROM 
                                (
                                (
			                                select DISTINCT  MAPHIEUCLS,
								                                NGAYTHU=CONVERT(NVARCHAR(20),NGAYTHU,103),
								                                MABENHNHAN,
								                                TENBENHNHAN,
								                                T2.NGAYSINH,
								                                TENGIOITINH=DBO.GETGIOITINH(T2.GIOITINH),
								                                TENBACSI,
								                                PHONG=DBO.HS_TENPHONG(T3.PHONGID),
								                                NHOMCLS=DBO.KB_GETTENPHONGCLS(T.MAPHIEUCLS,T.IDBENHNHAN)
								                                ,ISDATRA=ISNULL(T.ISDATRAKQ,0)
			                                 FROM KHAMBENHCANLAMSAN T
				                                  LEFT JOIN BENHNHAN T2 ON T.IDBENHNHAN=T2.IDBENHNHAN
				                                  LEFT JOIN KHAMBENH T3 ON T.IDKHAMBENH=T3.IDKHAMBENH
				                                  LEFT JOIN BACSI T4 ON T3.IDBACSI=T4.IDBACSI
			                                WHERE NGAYTHU>='" + NgayThu+@"' AND NGAYTHU<='"+NgayThu+@" 23:59:59'
					                                AND DATHU=1
					                                AND ISNULL(T.IDKHAMBENH,0)<>0
					                                AND T3.IDPHONGKHAMBENH=1"
                                           +(MABENHNHAN!=null &&MABENHNHAN!="" ? " AND T2.MABENHNHAN LIKE '"+MABENHNHAN+@"'" :"")
                                           + (TENBENHNHAN != null && TENBENHNHAN != "" ? " AND  T2.TENBENHNHAN LIKE N'%" + TENBENHNHAN + @"'" : "")
                                 + @"
                                                    
                                 )
                                UNION ALL
                                (          
		                                select DISTINCT  MAPHIEUCLS,
							                                NGAYTHU=CONVERT(NVARCHAR(20),NGAYTHU,103),
							                                MABENHNHAN,
							                                TENBENHNHAN,
							                                T2.NGAYSINH,
							                                TENGIOITINH=DBO.GETGIOITINH(T2.GIOITINH),
							                                TENBACSI,
							                                PHONG=N'Tự Đăng ký',
							                                NHOMCLS=DBO.KB_GETTENPHONGCLS(T.MAPHIEUCLS,T.IDBENHNHAN)
							                                ,ISDATRA=ISNULL(T.ISDATRAKQ,0)
		                                 FROM KHAMBENHCANLAMSAN T
			                                  LEFT JOIN BENHNHAN T2 ON T.IDBENHNHAN=T2.IDBENHNHAN
			                                  LEFT JOIN BACSI T4 ON T.IDBACSI=T4.IDBACSI
		                                WHERE NGAYTHU>='" + NgayThu+@"' AND NGAYTHU<='"+NgayThu+@" 23:59:59'
				                                AND DATHU=1
				                                AND ISNULL(T.IDKHAMBENH,0)=0
				                                AND ISNULL( T.IDKHOADANGKY,1)=1"
                                           +(MABENHNHAN!=null &&MABENHNHAN!="" ? " AND T2.MABENHNHAN LIKE '"+MABENHNHAN+@"'" :"")
                                           + (TENBENHNHAN != null && TENBENHNHAN != "" ? " AND  T2.TENBENHNHAN LIKE N'%" + TENBENHNHAN + @"'" : "")
                                 +@"
                                )
                                 ) AS TB";
                            DataAcess.Connect.ExecSQL(sqlSelect);
     
                         bool add = Userlogin_new.HavePermision(this, "HS_DANHSACHTRAKQCLS_Add");
                         bool delete = Userlogin_new.HavePermision(this, "HS_DANHSACHTRAKQCLS_Delete");
                          bool edit = Userlogin_new.HavePermision(this, "HS_DANHSACHTRAKQCLS_Edit");
                          
                                 process.EnablePaging = false;
                                         DataTable table = process.Search(@"select STT=row_number() over (order by T.ID),T.*
                                                                        from HS_DANHSACHTRAKQCLS T");
                                 Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table,add,edit,delete));
             }
             else{
                 Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
          }
     }
 }
 
 
