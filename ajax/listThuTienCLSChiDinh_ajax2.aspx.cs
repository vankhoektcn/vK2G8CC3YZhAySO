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
 
 public partial class listThuTienCLSChiDinh_ajax2 : System.Web.UI.Page
 {
     private string IdBangGiaDV = null;
     private double tongtien = 0;
     protected DataProcess s_benhnhan()
     {
             DataProcess benhnhan = new DataProcess("benhnhan"); 
             benhnhan.data("idbenhnhan",Request.QueryString["idkhoachinh"]);
             benhnhan.data("mabenhnhan",Request.QueryString["mabenhnhan"]);
             benhnhan.data("tenbenhnhan",Request.QueryString["tenbenhnhan"]);
            return benhnhan;
     }
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "TimKiem": TimKiem(); break;
             case "ThuPhiDV": ThuPhiDV(); break;
             case "huyDangKy": huyDangKy(); break;
             case "huyDVKham": huyDVKham(); break;
             case "timKiemBS": timKiemBS(); break;
             case "hoantra": hoantra(); break;
             case "luuhoantra": luuhoantra(); break;
             case "CheckAllCLSHoanTra": nvk_CheckAllCLSHoanTra(); break;
         }
     }
     private void nvk_CheckAllCLSHoanTra()
     {
         string MaPhieuCLS = Request.QueryString["maPhieuCLSAll"];
         string CheckAll = Request.QueryString["CheckAll"];
         bool IsCheckAll = CheckAll == "true" ? true : false;
         string html = "aaaaaaa";
         string sqlListCLS = @"select cls.idkhambenhcanlamsan,bg.tendichvu";
             if (IsCheckAll)
                 sqlListCLS += @",tongtienPhieu=isnull((select sum(dongia*soluong) from khambenhcanlamsan where maphieucls=cls.maphieucls ),0)";
             else
                 sqlListCLS += @",tongtienPhieu=0";
             sqlListCLS += @" ,tongtienDV=(cls.dongia*cls.soluong)
                            ,IsHoanTraCLS=convert(int,isnull(IsHoanTraCLS,0)) from khambenhcanlamsan cls left join banggiadichvu bg on bg.idbanggiadichvu=cls.idcanlamsan where maphieucls='" + MaPhieuCLS + "'";
         string LisAllIdCLS = "";
         string LisIdCLSDaHoan = "";
         string LisIdCLSChuaHoan = "";
         DataTable dtListCLSAll=DataAcess.Connect.GetTable(sqlListCLS);
         if (dtListCLSAll != null && dtListCLSAll.Rows.Count > 0)
         {
             html=@"<fieldset><legend>Chọn dịch vụ hoàn trả</legend>";
             if (dtListCLSAll != null && dtListCLSAll.Rows.Count > 0)
             {
                 string strCheck = "";
                 if (IsCheckAll)
                     strCheck = "checked";
                 for (int i = 0; i < dtListCLSAll.Rows.Count; i++)
                 {
                     if (i == 0)
                     {
                         html += "<span style='color:Red;font-weight:bold'><input type='checkbox' "+strCheck+" id='cbAll' onclick=\"CheckAllCLS(this,'" + MaPhieuCLS + "')\" name='nhomCheckbox' value='checkAll' />&nbsp; Chọn tất cả</span><br/>";
                     }
                     html += @"<span><input type='checkbox' " + strCheck+ " id='" + dtListCLSAll.Rows[i]["idkhambenhcanlamsan"] + "' onclick='CheckChonCLS(this," + dtListCLSAll.Rows[i]["tongtienDV"] + ")' name='nhomCheckbox' value='" + dtListCLSAll.Rows[i]["idkhambenhcanlamsan"] + "' />&nbsp; " + dtListCLSAll.Rows[i]["tendichvu"] + "  (" + dtListCLSAll.Rows[i]["tongtienDV"] + @")</span><br/>";
                     LisAllIdCLS += dtListCLSAll.Rows[i]["idkhambenhcanlamsan"].ToString() + ",";
                 }
                 LisAllIdCLS = LisAllIdCLS.TrimEnd(',');
             }
             if (IsCheckAll)
                 LisIdCLSDaHoan = LisAllIdCLS;
             else
                 LisIdCLSChuaHoan = LisAllIdCLS;
              html+= @"
                </fieldset>
                <input type='hidden' id='lisIDClsHT' value='" + LisIdCLSDaHoan + @"'>
                <input type='hidden' id='LisCLSChuaHoan' value='" + LisIdCLSChuaHoan + @"'>";
              
              html += "~~" + dtListCLSAll.Rows[0]["tongtienPhieu"];
         }
         Response.Clear();
         Response.Write(html);
     }
     protected void hoantra()
     {
         string maphieuCLS = Request.QueryString["maphieuCLS"];
         string sql = @"SELECT distinct cls.maphieuCLS,t.idbenhnhan
                    ,iddangkykham=isnull((select top 1 iddangkykham from khambenh where idkhambenh in(select top 1 idkhambenh from khambenhcanlamsan where maphieucls='"+maphieuCLS+@"')),0)
					,T.tenbenhnhan,sum(cls.dongia * cls.soluong) as sotienthu  
                    FROM khambenhcanlamsan cls
					inner join benhnhan T on T.idbenhnhan=cls.idbenhnhan
                    WHERE cls.MaPhieuCLS='" + maphieuCLS+"'group by cls.maphieuCLS,t.idbenhnhan,T.tenbenhnhan";
         DataTable dt = DataAcess.Connect.GetTable(sql);
         string sqlListCLS = @"select cls.idkhambenhcanlamsan,bg.tendichvu,tongtienDaHoan=isnull((select sum(dongia*soluong) from khambenhcanlamsan where maphieucls=cls.maphieucls and isnull(IsHoanTraCLS,0)=1),0)
                            ,tongtienDV=(cls.dongia*cls.soluong)
                            ,IsHoanTraCLS=convert(int,isnull(IsHoanTraCLS,0)) from khambenhcanlamsan cls left join banggiadichvu bg on bg.idbanggiadichvu=cls.idcanlamsan where maphieucls='" + maphieuCLS + "'";
         string LisCLSDaHoan = ""; string LisCLSChuaHoan = "";
         DataTable dtListCLS=DataAcess.Connect.GetTable(sqlListCLS);
         if(dtListCLS != null && dtListCLS.Rows.Count>0)
         {
             for(int i=0;i<dtListCLS.Rows.Count;i++)
             {
                 if (StaticData.ParseInt(dtListCLS.Rows[i]["IsHoanTraCLS"]) == 1)
                    LisCLSDaHoan += dtListCLS.Rows[i]["idkhambenhcanlamsan"].ToString() + ",";
                 else
                    LisCLSChuaHoan += dtListCLS.Rows[i]["idkhambenhcanlamsan"].ToString() + ",";
             }
             LisCLSDaHoan = LisCLSDaHoan.TrimEnd(',');
             LisCLSChuaHoan = LisCLSChuaHoan.TrimEnd(',');
         }
         string html = "";
         if (dt != null && dt.Rows.Count > 0)
         {
             
             html = @"
<strong style='color:Blue;font-size:larger;font-weight:bold'>HOÀN TRẢ TIỀN CẬN LÂM SÀNG</strong>
<table class='jtable' id='hoantra' border='0' cellpadding='1' cellspacing='1' width='100%'> 
              <tr> 
              <td align='left' style='width:15%'>Người thực hiện :<input type='hidden' mkv='true' id='hdIdNguoiDung' value='" + SysParameter.UserLogin.UserID(this) + @"' style='width:5px'/></td> 
              <td align='left' style='width:30%'><input style='width:300px' type='text' readonly='true' id='tenNguoiDung' value='" + SysParameter.UserLogin.FullName(this) + @"'/></td> 
              <td align='left' style='width:15%'>Tên bệnh nhân : <input type='hidden' mkv='true' id='idbenhnhan' value='" + dt.Rows[0]["idbenhnhan"] + @"'  style='width:5px'/></td> 
              <td align='left' style='width:30%'><input style='width:300px' mkv='true' readonly='true' type='text' id='tenbenhnhan' value='" + dt.Rows[0]["tenbenhnhan"] + @"'/></td> 
              </tr> 
             
              <tr> 
              <td align='left' style='width:15%'>Mã phiếu :</td> 
              <td align='left' style='width:30%'><input style='width:300px' type='text' mkv='true' readonly='true' id='maphieu'  value='" + dt.Rows[0]["maphieuCLS"] + @"'/></td> 
              <td align='left' style='width:15%'>Số tiền : </td> 
              <td align='left' style='width:30%'><input style='width:300px'  type='text' mkv='true' id='sotien' onblur='TestSo(this,false,false);' value='" + dtListCLS.Rows[0]["tongtienDaHoan"] + @"'/></td> 
              </tr> 
               
              <tr> 
              <td align='left' style='width:15%; height: 26px;'>Nội dung: </td> 
              <td align='left' style='width:30%; height: 26px;'><input style='width:300px'  type='text' mkv='true' id='noidung' value='Hoàn trả phí CLS'/></td> 
              <td align='left' style='width:15%'>Lý do: </td> 
              <td align='left' style='width:30%'><input style='width:300px' mkv='true' type='text' id='lydo'  /></td> 
              </tr> 
            <tr> 
              <td align='left' style='width:100%' colspan='4'>
<span style='width:96%' id='spDSCLSHoanTra'>
                <fieldset><legend>Chọn dịch vụ hoàn trả</legend>";
             if (dtListCLS != null && dtListCLS.Rows.Count > 0)
             {
                 for (int i = 0; i < dtListCLS.Rows.Count; i++)
                 {
                     if (i == 0)
                     {
                         html += "<span style='color:Red;font-weight:bold'><input type='checkbox'  id='cbAll' onclick=\"CheckAllCLS(this,'" + maphieuCLS + "')\" name='nhomCheckbox' value='checkAll' />&nbsp; Chọn tất cả</span><br/>";
                     }
                     if (StaticData.ParseInt(dtListCLS.Rows[i]["IsHoanTraCLS"]) == 1)
                     html += @"<span><input type='checkbox' checked id='" + dtListCLS.Rows[i]["idkhambenhcanlamsan"] + "' onclick='CheckChonCLS(this," + dtListCLS.Rows[i]["tongtienDV"] + ")' name='nhomCheckbox' value='" + dtListCLS.Rows[i]["idkhambenhcanlamsan"] + "' />&nbsp; " + dtListCLS.Rows[i]["tendichvu"] + "  (" + dtListCLS.Rows[i]["tongtienDV"] + @")</span><br/>";
                     else
                     html += @"<span><input type='checkbox' id='" + dtListCLS.Rows[i]["idkhambenhcanlamsan"] + "' onclick='CheckChonCLS(this," + dtListCLS.Rows[i]["tongtienDV"] + ")' name='nhomCheckbox' value='" + dtListCLS.Rows[i]["idkhambenhcanlamsan"] + "' />&nbsp; " + dtListCLS.Rows[i]["tendichvu"] + "  (" + dtListCLS.Rows[i]["tongtienDV"] + @")</span><br/>";
                 }
             }
              html+= @"
                </fieldset>
                <input type='hidden' id='lisIDClsHT' value='" + LisCLSDaHoan + @"'>
                <input type='hidden' id='LisCLSChuaHoan' value='" + LisCLSChuaHoan + @"'>
</span>
              </td> 
              </tr> 
              <tr> 
              <td align='center' style='width:100%' colspan='4'> 
              <input type='button' id='btnLuu' value='Đồng ý' onclick='LuuHoanTra(" + dt.Rows[0]["iddangkykham"].ToString() + @");'/>
              <input type='button' id='btnHuy' value='Đóng' onclick='Dong();' /> 
              </td> 
              </tr> 
      </table>";
         }
         else
         {
             html = "Không tìm thấy dữ liệu !";
         }
         Response.Write(html);
     }
     protected void luuhoantra()
     {
         string nvk_lisIDClsHT = Request.QueryString["lisIDClsHT"];
         string nvk_LisCLSChuaHoan = Request.QueryString["LisCLSChuaHoan"];
         
         //if (string.IsNullOrEmpty(nvk_lisIDClsHT))
         //{
         //    Response.Write("");
         //    return;
         //}
         string idnguoidung = Request.QueryString["idnguoithu"];
         string idbenhnhan = Request.QueryString["idbenhnhan"];
         string maphieu = Request.QueryString["maphieu"];
         string sotien = Request.QueryString["sotien"];
         string noidung = Request.QueryString["noidung"];
         string lydo = Request.QueryString["lydo"];
         string iddangkykham = "0";
         if (Request.QueryString["iddangkykham"] != null)
             iddangkykham = Request.QueryString["iddangkykham"];
         //Kiem tra du lieu da ton tai hay chua,neu da ton tai chi can cap nhat len thoi
         //nguoc lai thi luu no vao
         string sql = "";
         string sqlCheck = "Select idHoanTra from TP_HoanTra where  maphieu='" + maphieu + "' and tableName='khambenhcanlamsan'";
         DataTable dtCheck = DataAcess.Connect.GetTable(sqlCheck);
         if (dtCheck != null && dtCheck.Rows.Count > 0)
         {
             sql = "UPDATE TP_HoanTra";
             sql += " SET [maPhieu] = '" + maphieu + "',idNguoiDung = '" + idnguoidung + "'";
             sql += ",idBenhNhan = '" + idbenhnhan + "',idDangKyKham ='" + iddangkykham + "',ngayHoanTra = '" + System.DateTime.Now.ToString() + "'";
             sql += " ,SoTien = '" + sotien + "',noiDung = N'" + noidung + "',lyDo =N'" + lydo + "'";
             sql += "  WHERE idHoanTra=" + dtCheck.Rows[0]["idHoanTra"].ToString();
         }
         else
         {
             sql = @"INSERT INTO [TP_HoanTra]
           ([maPhieu]
           ,[idNguoiDung]
           ,[idBenhNhan]
           ,[idDangKyKham]
           ,[ngayHoanTra]
           ,[SoTien]
           ,[noiDung]
           ,[lyDo]
           ,[tableName])
     VALUES
           ('" + maphieu + "','" + idnguoidung + "','" + idbenhnhan + "','" + iddangkykham + "','" + System.DateTime.Now.ToString() + "','" + sotien + "',N'" + noidung + "',N'" + lydo + "','khambenhcanlamsan')";

         }
         bool exc = DataAcess.Connect.ExecSQL(sql);
         if (exc == true)
         {
             bool ktUpdateCLS = false;
             nvk_lisIDClsHT = nvk_lisIDClsHT.TrimEnd(',');
             if (!string.IsNullOrEmpty(nvk_lisIDClsHT))
                 {
                     string update = "update khambenhcanlamsan set IsHoanTraCLS=1 where maphieucls='" + maphieu + "' and idkhambenhcanlamsan in ("+nvk_lisIDClsHT+")";//" + iddangkykham;
                     ktUpdateCLS = DataAcess.Connect.ExecSQL(update);
                 }
                 nvk_LisCLSChuaHoan = nvk_LisCLSChuaHoan.TrimEnd(',');
                 if (!string.IsNullOrEmpty(nvk_LisCLSChuaHoan))
                 {
                     string update = "update khambenhcanlamsan set IsHoanTraCLS=0 where maphieucls='" + maphieu + "' and idkhambenhcanlamsan in (" + nvk_LisCLSChuaHoan + ")";//" + iddangkykham;
                     ktUpdateCLS = DataAcess.Connect.ExecSQL(update);
                 }
             if(ktUpdateCLS)
                Response.Write("Đã hoàn trả thành công");
             else
                Response.Write("");
         }
         else
         {
             Response.Write("");
         }
     }
     //Load data bác sĩ
     protected void timKiemBS()
     {
         DataTable table = KB_Process.bacsi.dtGetAll();
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {

                     html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                 }
             }
         }

         Response.Clear(); Response.Write(html);
     }
     //huy dang ky dich vu
     protected void huyDangKy()
     {
         string idnguoithu = SysParameter.UserLogin.UserID(this);
         string kieuthaotac = Request.QueryString["kieuthaotac"];
         string idkhambenh = Request.QueryString["idkhambenh"];
         string maPhieuCLS = Request.QueryString["maphieuCLS"];
         string s = "select tennguoidung from nguoidung where idnguoidung=" + idnguoithu;
         string dtNguoiThu = DataAcess.Connect.GetTable(s).Rows[0]["tennguoidung"].ToString();
         string html = "";
         html += "<strong style=\"color:Blue;font-size:larger;font-weight:bold\">HỦY ĐĂNG KÝ DỊCH VỤ</strong>";
         html += "<table class='jtable' id=\"gridTable\" border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\">";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Người dùng :<input type=\"hidden\" id=\"hdIdNguoiDung\" value='"+idnguoithu+"'/></td>";
         html += "<td align=\"left\" style=\"width:100%\"><input readonly=\"true\" style=\"width:300px\" type=\"text\" id=\"tenNguoiDung\" value='" + dtNguoiThu + "'/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Ngày thực hiện : </td>";
         html += "<td align=\"left\" style=\"width:100%\"><input readonly=\"true\" style=\"width:300px\" type=\"text\" id=\"ngaythucHien\" value='" + DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyy") + "'/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Kiểu thao tác : </td>";
         html += "<td align=\"left\" style=\"width:100%\"><input style=\"width:300px\" type=\"text\" id=\"kieuthaotac\" value='" + kieuthaotac + "'/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"left\" style=\"width:20%\">Lý do : </td>";
         html += "<td align=\"left\" style=\"width:100%\"><input style=\"width:300px\" type=\"text\" id=\"lydo\"/></td>";
         html += "</tr>";
         html += "<tr>";
         html += "<td align=\"center\" style=\"width:20%\" colspan=\"2\">";
         //html += "<a id=\"btnHuy\"  onclick=\"Dong();\" >Đóng</a>";
         html += "<input type=\"button\" id=\"btnHuy\" value='Đóng' onclick=\"Dong();\" />";
         html += "<input type=\"button\" id=\"btnLuu\" value='Lưu' onclick=\"LuuHuyDangKy();\" />";
         html += " <input type=\"hidden\" mkv=\"true\" id=\"hdiddangkykham\" value='" + idkhambenh + "'/>";
         html += " <input type=\"hidden\" mkv=\"true\" id=\"maphieuCLS\" value='" + maPhieuCLS + "'/>";
         html+="</td>";
         html += "</tr>";
         html += "</table>";
         Response.Write(html);
     }
     #region Huy dang ky dich vu truong
     protected void huyDVKham()
     {
         string idkhambenh = Request.QueryString["idkhambenh"];
         string kieuthaotac = Request.QueryString["kieuthaotac"];
         string lydo = Request.QueryString["lydo"];
         Process.trangthailuutrudulieu.Insert_Object(SysParameter.UserLogin.UserID(this), DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "dangkykham", "idkhambenh", idkhambenh, lydo, kieuthaotac);
         int iddkk = StaticData.ParseInt(idkhambenh);
         string MaPhieuThu = Request.QueryString["maPhieuCLS"];
         string sqlCheckStatus = "select dahuy from khambenhcanlamsan where idkhambenh=" + iddkk + " and maphieuCLS='" + MaPhieuThu + "'";
         string checkStatus = DataAcess.Connect.GetTable(sqlCheckStatus).Rows[0][0].ToString();
         string sql = "";
         if (checkStatus == "False" || checkStatus == "0")
         {
             sql = "update khambenhcanlamsan set dahuy = 1 where idkhambenh=" + iddkk + " and maphieuCLS='" + MaPhieuThu + "'";
             bool exc = DataAcess.Connect.ExecSQL(sql);

             if (exc == true)
             {
                 Response.Write("Hủy phiếu thu thành công.");

             }
             else
             {
                 Response.Write("");
             }
         }
         else
         {
             sql = "update khambenhcanlamsan set dahuy = 0 where idkhambenh=" + iddkk + " and maphieuCLS='" + MaPhieuThu + "'";

             bool exc = DataAcess.Connect.ExecSQL(sql);

             if (exc == true)
             {
                Response.Write("Phục hồi phiếu thu thành công.");

             }
             else
             {
                 Response.Write("");
             }
         }
         try
         {
             DataTable dtLoad = DataAcess.Connect.GetTable(@"select top 1 *,convert(varchar(10),ngaydangky,111) as Ngay FROM  daNgkykham dkk left join khambenh kb on kb.iddangkykham=dkk.iddangkykham  where kb.idkhambenh=" + iddkk);
             string NgayDangKyKham = StaticData.ConvertDayToyyyyMMdd(dtLoad.Rows[0]["Ngay"].ToString(), "yyyy/MM/dd");
             string sqlUpdate_KB_TINH_TONGTIEN_BNPHAITRA = " EXEC KB_TINH_TONGTIEN_BNPHAITRA " + dtLoad.Rows[0]["idbenhnhan"].ToString() + ",'" + NgayDangKyKham + "'";
             bool ktBH = DataAcess.Connect.ExecSQL(sqlUpdate_KB_TINH_TONGTIEN_BNPHAITRA);
             if (!ktBH) { Response.Write( "Lỗi BH KH2 !"); }
         }
         catch (Exception)
         {
             Response.Write( "Lỗi BH KH1 !");
         }
         
     }
     #endregion
     #region Thu Phi Dich Vu Kham Benh
     private void ThuPhiDV()
     {
         string iddkk = Request.QueryString["idkhambenh"];
         string MaPhieuThu = Request.QueryString["maPhieuCLS"];

         //string sqlCheckStatus = "select top 1 dathu from khambenhcanlamsan where idkhambenh=" + iddkk + " and maphieucls='" + MaPhieuThu + "' order by idkhambenhcanlamsan desc";
         //string checkStatus = DataAcess.Connect.GetTable(sqlCheckStatus).Rows[0][0].ToString();
         //if (checkStatus == "False" || checkStatus == "0")
         //{
         string sql = "";
         string IdNguoiThu = SysParameter.UserLogin.UserID(this);

             if (IdNguoiThu == "0" || IdNguoiThu == "")
             {
                 Response.Write("");
                 return;
             }
             else
             {
                 sql = "update khambenhcanlamsan set dathu=1 , thucthu = 1,IdNguoiThu=" + IdNguoiThu + ",ngaythu=getdate()  where maphieuCLS='" + MaPhieuThu + "'";
             }
             bool exc = DataAcess.Connect.ExecSQL(sql);
             if (exc == true)
             {
                 Response.Write("1");
             }
             else
             {

                 Response.Write("");
             }
         //}
         //else
         //{
         //    Response.Write("");
         //}
     }
     #endregion
     private DataTable loadData(DataProcess process)
     {
         #region select du lieu
         string sWhere = "";
         string LoaiBN = "";
         string date=DataAcess.Connect.d_SystemDate().ToString("yyy-MM-dd");
         string tungay = Request.QueryString["tungay"];
         string denngay = Request.QueryString["denngay"];
         string mabenhnhan = Request.QueryString["mabenhnhan"];
         string maphieuCLS = Request.QueryString["maphieu"];
         string tenbenhnhan = Request.QueryString["tenbenhnhan"];
         string idbs = Request.QueryString["idbacsi"]; 
         LoaiBN = Request.QueryString["LoaiBN"];
         string thanhtien="";
         if (LoaiBN == "1")
         {
             thanhtien = @"TONGTIEN=(SELECT ThanhTien=sum(A1.SOLUONG *  DV.GiaBH)-sum(A1.SOLUONG *  DV.BHTra) FROM KHAMBENHCANLAMSAN A1 
										left join banggiadichvu dv on dv.idbanggiadichvu=A1.idcanlamsan
										 WHERE 
                     	                 DBO.KB_GETIDBENHNHAN(A1.IDKHAMBENHCANLAMSAN)=DBO.KB_GETIDBENHNHAN(kbcls.IDKHAMBENHCANLAMSAN)
                     			            AND A1.DAHUY=kbcls.DAHUY
                     			            AND A1.DATHU=kbcls.DATHU
                            	            AND A1.MAPHIEUCLS=kbcls.MAPHIEUCLS)";
         }
         else
         {
             thanhtien = @" TONGTIEN=(SELECT SUM(THANHTIEN) FROM KHAMBENHCANLAMSAN A1 
                     		             WHERE 
                     	                 DBO.KB_GETIDBENHNHAN(A1.IDKHAMBENHCANLAMSAN)=DBO.KB_GETIDBENHNHAN(kbcls.IDKHAMBENHCANLAMSAN)
                     			            AND A1.DAHUY=kbcls.DAHUY
                     			            AND A1.DATHU=kbcls.DATHU
                            	            AND A1.MAPHIEUCLS=kbcls.MAPHIEUCLS)";
         }
         sWhere += "";
         if (mabenhnhan!= "")
         {
             sWhere += " AND bn.mabenhnhan LIKE '%" + mabenhnhan + "%' ";
         }
         if (tenbenhnhan!= "")
         {
             sWhere += " AND bn.tenbenhnhan LIKE N'%" + tenbenhnhan + "%' ";
         }
         if (maphieuCLS != "")
         {
             sWhere += " AND kbcls.maphieuCLS LIKE '%" + maphieuCLS + "%' ";
         }
         if (tungay!= "" && denngay != "")
         {
             sWhere += " AND kb.ngaykham BETWEEN '" + StaticData.CheckDate(tungay) + " 00:00:00' AND '" + StaticData.CheckDate(denngay) + " 23:59:59' ";
         }
         string s = @"SELECT DISTINCT STT=1,bn.loai,dkk.iddangkykham,kbcls.maphieuCLS,kbcls.idkhambenh,kb.ngaykham, bn.idbenhnhan, bn.mabenhnhan, bn.tenbenhnhan, diachi, dienthoai,ngaysinh, idloaibh, 
                     case when isnull(bn.gioitinh,0)=0 then N'Nam' else N'Nữ' end as gioitinh,
                     case when isnull(kbcls.dathu,0)=0 then N'Chưa thu' else N'Đã thu' end as trangthai,
                     case when isnull(kbcls.dahuy,0)=0 then N'Hủy' else N'Phục hồi' end as huy,
                    case when isnull(dkk.ishoantra,0)=1 then N'Đã hoàn trả' else N'Hoàn trả' end as lbhoantra,
                     ngaysinh as tuoi,kb.idbacsi,
                    " + thanhtien+@"
                    FROM khambenhcanlamsan kbcls 
                    INNER JOIN khambenh kb ON kbcls.idkhambenh = kb.idkhambenh 
                    inner join dangkykham dkk on dkk.iddangkykham=kb.iddangkykham 
                    INNER JOIN benhnhan bn ON kb.idbenhnhan = bn.idbenhnhan 
                     LEFT JOIN KB_LOAIBN LBN ON LBN.ID=BN.LOAI 
                     WHERE isnull(kbcls.dahuy,0)=0 AND LBN.ISKHAMTRUOC=0 
                          " +sWhere+"  AND BN.LOAI=" + LoaiBN;
         DataTable table = DataAcess.Connect.GetTable(s);
         #endregion
         return table;
     }
     private void TimKiem()
     {

         DataProcess process = s_benhnhan();
         process.Page = Request.QueryString["page"];
         process.NumberRow = "50";
         DataTable table = loadData(process);
         string html ="";
                html += process.Paging();
         html += "<table class=\"ttable\" id=\"gridTable\">";
         html += "<tr>";
          html += "<th>STT</th>";
          html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("inphieu") + "</th>";
          html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("sua") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("hoantra") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("status") + "</th>";
         html += "<th style='width:70px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieu") + "</th>";
         html += "<th style='width:90px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("mabenhnhan") + "</th>";
         html += "<th style='width:150px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenbenhnhan") + "</th>";
         html += "<th style='width:70px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dienthoai") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("diachi") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("gioitinh") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaysinh") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaykham") + "</th>";
         html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tongtien") + "</th>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 tongtien +=StaticData.ParseFloat(table.Rows[i]["tongtien"]);
                 string dathu = table.Rows[i]["trangthai"].ToString();
                 string hoantra = table.Rows[i]["lbhoantra"].ToString();
                 html += "<tr>";
                 html += "<td>" + (i+1)+ "</td>";
                 if (dathu == "Đã thu" )
                 {
                     if (hoantra.ToString() == "Đã hoàn trả")
                     {
                         html += "<td><a onclick=\"InPhieuDangKyBaoHiem('" + table.Rows[i]["idkhambenh"].ToString() + "','" + table.Rows[i]["maphieuCLS"].ToString() + "','" + table.Rows[i]["loai"].ToString() + "')\" id='btnInPhieu' style=\"cursor:pointer\">In Phiếu</a></td>";
                         html += "<td></td>";//<a id=\"btnSua\" visible=\"true\" onclick=\"SuaPhieu('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["maphieuCLS"].ToString() + "','" + table.Rows[i]["idbacsi"].ToString() + "');\" style=\"cursor:pointer\">Sửa</a>
                         html += "<td><a  mkv='true'  style=\"cursor:pointer;\">" + table.Rows[i]["lbhoantra"].ToString() + "</a></td>";
                         html += "<td><a mkv='true' style=\"width:60px;cursor:pointer\">" + table.Rows[i]["trangthai"].ToString() + "</a></td>";
                     }
                     else
                     {
                         html += "<td><a onclick=\"InPhieuDangKyBaoHiem('" + table.Rows[i]["idkhambenh"].ToString() + "','" + table.Rows[i]["maphieuCLS"].ToString() + "','" + table.Rows[i]["loai"].ToString() + "')\" id='btnInPhieu' style=\"cursor:pointer\">In Phiếu</a></td>";
                         html += "<td></td>";//<a id=\"btnSua\" visible=\"true\" onclick=\"SuaPhieu('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["maphieuCLS"].ToString() + "','" + table.Rows[i]["idbacsi"].ToString() + "');\" style=\"cursor:pointer\">Sửa</a>
                         html += "<td><a  mkv='true' onclick=\"hoantra(this,'" + table.Rows[i]["maphieuCLS"].ToString() + "');\"  style=\"cursor:pointer;\">" + table.Rows[i]["lbhoantra"].ToString() + "</a></td>";
                         html += "<td><a mkv='true' style=\"width:60px;cursor:pointer\">" + table.Rows[i]["trangthai"].ToString() + "</a></td>";
                     }
                     
                 }
                 else
                 {
                     html += "<td></td>";
                     html += "<td><a id=\"btnSua\" onclick=\"SuaPhieu('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["maphieuCLS"].ToString() + "','" + table.Rows[i]["maphieuCLS"].ToString() + "');\" style=\"cursor:pointer\">Sửa</a></td>";
                     html += "<td><a  mkv='true' onclick=\"hoantra(this,'" + table.Rows[i]["maphieuCLS"].ToString() + "');\" style=\"cursor:pointer;\">" + table.Rows[i]["trangthai"].ToString() + "</a></td>";
                     html += "<td><a  mkv='true'  onclick=\"ThuPhiDV('" + table.Rows[i]["idkhambenh"].ToString() + "','" + table.Rows[i]["maphieuCLS"].ToString() + "','" + table.Rows[i]["loai"].ToString() + "');\" style=\"cursor:pointer\">" + table.Rows[i]["trangthai"].ToString() + "</a></td>";
                 }
                 
                 //html += "<td><input mkv='true' id='diachi' type='text' value='" + table.Rows[i]["status"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                 html += "<td>" + table.Rows[i]["maphieuCLS"].ToString() + "</td>";
                 html += "<td>" + table.Rows[i]["mabenhnhan"].ToString() + "</td>";
                 html += "<td style='text-align:left'>" + table.Rows[i]["tenbenhnhan"].ToString() + "</td>";
                 html += "<td>" + table.Rows[i]["dienthoai"].ToString() + "</td>";
                 html += "<td>" + table.Rows[i]["diachi"].ToString() + "</td>";
                 html += "<td>" + table.Rows[i]["gioitinh"].ToString()+ "</td>";
                 html += "<td>" + table.Rows[i]["ngaysinh"].ToString() + "</td>";
                 html+= "<td>" + string.Format("{0:dd/MM/yyyy hh:mm}" ,table.Rows[i]["ngaykham"])+ "</td>";
                 html += "<td>" + string.Format("{0:0,0}", table.Rows[i]["tongtien"]) + "</td>";
                                 html += "</tr>";
                             }}else{
                                 return;
                                
            }}
         html += "<tr><td></td><td></td></tr>";
         html += "<tr><td colspan=\"14\" style=\"text-align:right\">Tổng tiền : "+String.Format("{0:0,0 VNĐ}",tongtien)+"</td></tr>";
         html += "</table>";
         html += process.Paging();
         Response.Clear(); Response.Write(html);
     }
 }
 
 
