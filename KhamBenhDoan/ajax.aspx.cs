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
using System.Data.SqlClient;

public partial class khambenh_ajax : Genaratepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = StaticData.escape(Request.QueryString["do"]);
        switch (action)
        {
            case "getallbenhnhanKB": getallbenhnhanKB(); break;
            case "LuuKBNew": LuuKBNew(); break;
            case "ThongTinKhamBenhTuDien": ThongTinKhamBenhTuDien(); break;
            case "GetBNInfoMa": GetBenhNhanInfo(); break;
        }
    }
    private void getallbenhnhanKB()
    {
        //try
        //{
            string style = "";
            string NoiDungKCB = Request.QueryString["NoiDungKCB"].ToString();
            string PhongID = Request.QueryString["PhongID"].ToString();
            string NoiDungKCB_Clause = "";
            string PhongID_Clause = "";

            int IsKQCLS = StaticData.ParseInt(Request.QueryString["IsKQCLS"]);
            string LoaiBN = (Request.QueryString["LoaiBN"] != null ? Request.QueryString["LoaiBN"].ToString() : "0");
            string idbs = Request.QueryString["idbs"].ToString();
            string isDoan = Request.QueryString["isDoan"] == null ? "0" : Request.QueryString["idbs"].ToString();
            if (idbs == "" || idbs == "0")
                if (NoiDungKCB != "" && NoiDungKCB != "0")
                    NoiDungKCB_Clause += " AND DKK.idbanggiadichvu=" + NoiDungKCB;
            if (idbs == "" || idbs == "0")
                if (PhongID != "" && PhongID != "0")
                    PhongID_Clause += " AND DKK.PhongID=" + PhongID;

            string idpk = Request.QueryString["idpk"].ToString();
            if (IsKQCLS == 0)
            {
                if (idpk != "0" && idpk != "")
                    PhongID_Clause += " and kb.idphongkhambenh=" + idpk;
                if (idbs != "" && idbs != "0")
                    PhongID_Clause += " AND kb.idbacsi=" + idbs;
            }

            if (IsKQCLS == 1)
            {
                if (PhongID != "" && PhongID != "0")
                {
                    PhongID_Clause += " AND F.ID=" + PhongID;
                }
                else
                {
                    PhongID_Clause += "";
                }
            }
            string ngaycls = Request.QueryString["ngaytp"].ToString();
            string ngaytp = Request.QueryString["ngaytp"].ToString();
            string ngaytpTam = DateTime.Parse(StaticData.CheckDate(ngaytp)).ToString("yyyy-MM-dd");
            ngaytp = ngaytpTam;
            string strsql = "";
            string makb = StaticData.CreateIDTheoThuTuTN("PKB", "khambenh", "maphieukham", "idkhambenh", ngaytpTam);
            if (isDoan == "0")
            {
                strsql = @"SELECT * FROM 
                      ( 
                      (SELECT  distinct    B.IDBENHNHAN 
                                 ,C.TENBENHNHAN 
                                 ,C.MaBenhNhan 
                                 ,D.TenLoai AS LOAIBN 
                                ,NGAYDANGKY AS NGAYTHUDV 
                                 ,PHONGSO=F.MaSo 
                                 ,A.SoTT 
                                ,B.IDDANGKYKHAM,A.IdChiTietDangKyKham 
                               ,THUTU=E.THUTU 
                             ,UUTIEN=E.TenLoai 
                            ,idphongkhambenh=DBO.KB_GETIDPHONGKHAMBENH(A.IDCHITIETDANGKYKHAM) 
                         ,idkhambenh='',ngayCLS=''  
                                    ,TrangThai=N'Khám bệnh'
                                  FROM CHITIETDANGKYKHAM A
                                 LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                 LEFT JOIN BANGGIADICHVU A0 ON A.IDBANGGIADICHVU=A0.IDBANGGIADICHVU 
                                LEFT JOIN BENHNHAN C ON B.IDBENHNHAN=C.IDBENHNHAN 
                               LEFT JOIN KB_LOAIBN D ON C.LOAI=D.ID 
                               LEFT JOIN KB_LOAIUUTIEN E ON C.idloaiuutien=E.ID
                              LEFT JOIN KB_PHONG F ON A.PHONGID=F.ID
                              LEFT JOIN KB_PHONGKham pk ON pk.PHONGID=F.ID
	                    where a.idchitietdangkykham in (select top 10 idchitietdangkykham from chitietdangkykham order by idchitietdangkykham desc)
	                    )
                    ) AS TB
                    ORDER BY TrangThai,mabenhnhan";
            }
            else
            {
                strsql = @"SELECT * FROM 
                      ( 
                      (SELECT  distinct    B.IDBENHNHAN 
                                 ,C.TENBENHNHAN 
                                 ,C.MaBenhNhan 
                                 ,D.TenLoai AS LOAIBN 
                                ,NGAYDANGKY AS NGAYTHUDV 
                                 ,PHONGSO=F.MaSo 
                                 ,A.SoTT 
                                ,B.IDDANGKYKHAM,A.IdChiTietDangKyKham 
                               ,THUTU=E.THUTU 
                             ,UUTIEN=E.TenLoai 
                            ,idphongkhambenh=DBO.KB_GETIDPHONGKHAMBENH(A.IDCHITIETDANGKYKHAM) 
                         ,idkhambenh='',ngayCLS=''  
                                    ,TrangThai=N'Khám bệnh'
                                  FROM CHITIETDANGKYKHAM A
                                 LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                 LEFT JOIN BANGGIADICHVU A0 ON A.IDBANGGIADICHVU=A0.IDBANGGIADICHVU 
                                LEFT JOIN BENHNHAN C ON B.IDBENHNHAN=C.IDBENHNHAN 
                               LEFT JOIN KB_LOAIBN D ON C.LOAI=D.ID 
                               LEFT JOIN KB_LOAIUUTIEN E ON C.idloaiuutien=E.ID
                              LEFT JOIN KB_PHONG F ON A.PHONGID=F.ID
                              LEFT JOIN KB_PHONGKham pk ON pk.PHONGID=F.ID
	                    where 1=1 --a.idchitietdangkykham in (select top 10 idchitietdangkykham from chitietdangkykham order by idchitietdangkykham desc)
                            "+(PhongID != null && PhongID != "" && PhongID != "0" ? "AND A.PhongID=" + PhongID + "" : "")+@"
                            " + (idbs != "" && idbs != "0" ? " AND PK.idbacsi='" + idbs + "'" : "") + @"
	                    )
                    ) AS TB
                    ORDER BY TrangThai,mabenhnhan";
            }

            string sqlDS_KQCLS = "\r\n"
            + " SELECT DISTINCT bn.idbenhnhan,tenbenhnhan ,mabenhnhan,D.TenLoai AS LOAIBN " + "\r\n"
            + " ,ddk.NGAYDANGKY AS NGAYTHUDV " + "\r\n"
            + ",PHONGSO=F.MaSo " + "\r\n"
            + ",ct.SoTT " + "\r\n"
            + ",ddk.IDDANGKYKHAM,ct.IdChiTietDangKyKham " + "\r\n"
            + ",LUT.THUTU " + "\r\n"
            + ",LUT.TENLOAI as UUTIEN " + "\r\n"
            + ",kb.idphongkhambenh " + "\r\n"
            + ",kb.idkhambenh,kb.ngaykham as ngayCLS " + "\r\n"
            + ",TrangThai=N'Đã CLS' " + "\r\n"
            + "FROM " + "\r\n"
            + "KhamSucKhoe kb " + "\r\n"
            + "INNER JOIN benhnhan bn ON kb.idbenhnhan = bn.idbenhnhan " + "\r\n"
            + "inner join dangkykham ddk on ddk.iddangkykham=kb.iddangkykham " + "\r\n"
            + "left join chitietdangkykham ct ON ct.IDDANGKYKHAM=ddk.IDDANGKYKHAM " + "\r\n"
            + "LEFT JOIN KB_PHONG F ON ct.PHONGID=F.ID " + "\r\n"
            + "LEFT JOIN KB_LOAIBN D ON BN.LOAI=D.ID " + "\r\n"
            + "LEFT JOIN CHITIETDANGKYKHAM DKK ON KB.idchitietdangkykham=DKK.idchitietdangkykham " + "\r\n"
            + "LEFT JOIN KB_LOAIUUTIEN LUT ON LUT.ID=BN.IDLOAIUUTIEN " + "\r\n"
            + "  WHERE 1=1 and kb.idchitietdangkykham =ct.idchitietdangkykham " + NoiDungKCB_Clause + PhongID_Clause;
            //if (LoaiBN != "0" || LoaiBN != "")
            //    strsql += " AND BN.LOAI=" + LoaiBN;
            sqlDS_KQCLS += ""
            + " and convert(varchar,kb.ngaykham,103)='" + ngaycls + "' and" + "\r\n" //convert(varchar,kb.ngaykham,103)='" + ngaycls + "' and
            + "  isnull(kb.hoantat,0) = 0 "
            + @" --and kb.idkhambenh in (select distinct cls.idkhambenh from khambenhcanlamsan cls where cls.idkhambenh = kb.idkhambenh and not exists(select top 1 idkhambenhcanlamsan from khambenhcanlamsan where idkhambenhcanlamsan=cls.idkhambenhcanlamsan and isnull(dathu,0)=0) )
            order by bn.mabenhnhan
            ";
            if (IsKQCLS == 1)
            {
                strsql = sqlDS_KQCLS;
            }
            string html = "";
            html = "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" width=\"850\">";
            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"4%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Phòng</td>";
            html += "<td width=\"3%\" class=\"item\" style=\"color:white;font-weight:bold;\" >STT</td>";
            html += "<td width=\"35%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên bệnh nhân</td>";
            html += "<td width=\"20%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Mã BN</td>";
            //html += "<td width=\"15%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Loại BN</td>";
            //html += "<td width=\"20%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ưu tiên</td>";
            html += "<td width=\"18%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày ĐKK</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Trạng thái</td>";

            html += "</tr>";

            DataTable dt = DataAcess.Connect.GetTable(strsql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string sNgayThuDV = dt.Rows[i]["ngaythuDV"].ToString();
                if (sNgayThuDV != "")
                    sNgayThuDV = DateTime.Parse(sNgayThuDV).ToString("dd/MM/yyyy HH:mm:00");
                //Lấy thông tin BH,loại BN
                string oLoaiBenhNhan = "2";
                string SoNgayBaoHiem = "0";
                DataTable dtLoaiBN = DataAcess.Connect.GetTable("select loai,soNgayBH= convert(int, convert(datetime,isnull(ngayhethan,getdate()))- getdate()) from benhnhan WHERE idbenhnhan=" + dt.Rows[i]["idbenhnhan"].ToString());
                if (dtLoaiBN != null && dtLoaiBN.Rows.Count > 0)
                {
                    oLoaiBenhNhan = dtLoaiBN.Rows[0]["loai"].ToString();
                    SoNgayBaoHiem = dtLoaiBN.Rows[0]["soNgayBH"].ToString();
                }
                string loai = dt.Rows[i]["LoaiBN"].ToString();
                //if (LoaiBN == "0")
                //{
                if (loai == "Khám Bảo Hiểm")
                {
                    style = "style=\"color:blue\"";
                }
                else
                {
                    style = "";
                }
                //}
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\"  onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\"  onclick=\"LoadInFoBenhNhan('" + dt.Rows[i]["idbenhnhan"].ToString() + "','" + dt.Rows[i]["IDDangKyKham"].ToString() + "','" + dt.Rows[i]["IdChiTietDangKyKham"].ToString() + "','" + makb + "','" + oLoaiBenhNhan + "','" + SoNgayBaoHiem + "','" + dt.Rows[i]["idphongkhambenh"].ToString() + "')\">";
                html += "<td width=\"4%\" class=\"ptext\" " + style + " nowrap = \"nowrap\">" + dt.Rows[i]["PhongSo"] + "</td>";
                html += "<td width=\"3%\" class=\"ptext\" " + style + " nowrap = \"nowrap\">" + dt.Rows[i]["SoTT"] + "</td>";
                html += "<td width=\"35%\" class=\"ptext\" " + style + ">&nbsp;" + dt.Rows[i]["tenbenhnhan"] + "</td>";
                html += "<td width=\"20%\" class=\"ptext\" " + style + " nowrap = \"nowrap\">" + dt.Rows[i]["mabenhnhan"] + "</td>";
                //html += "<td width=\"15%\" class=\"ptext\" nowrap = \"nowrap\" " + style + ">" + dt.Rows[i]["LoaiBN"] + "</td>";
                //html += "<td width=\"20%\" class=\"ptext\" nowrap = \"nowrap\" " + style + ">" + dt.Rows[i]["uutien"] + "</td>";
                html += "<td width=\"18%\" class=\"ptext\" " + style + ">" + sNgayThuDV + "</td>";
                html += "<td width=\"10%\" class=\"ptext\" nowrap = \"nowrap\" " + style + ">" + dt.Rows[i]["TrangThai"] + "</td>";


                html += "</tr>";
            }
            html += "<tr><td colspan=\"5\"><br/></td></tr>";
            //html += "<tr><td colspan=\"3\" align=\"center\"><input type=\"button\" onclick=\"hideTip('tipvattu')\" value=\"Đóng\" style=\"width:80px\"></td></tr>";
            html += "</table>";
            Response.Clear();
            Response.Write(html);
        //}
        //catch (Exception)
        //{
        //    Response.Write("error");
        //}
    }
    //__________________________________________________________________________________________________________________________
    private void ThongTinKhamBenhTuDien()
    {
        string idchitietdangkykham = Request.QueryString["idchitietdangkykham"];
        string iddangkykham = Request.QueryString["iddangkykham"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        if (string.IsNullOrEmpty(idchitietdangkykham) || string.IsNullOrEmpty(iddangkykham) || string.IsNullOrEmpty(idbenhnhan))
        {
            Response.Clear();
            Response.Write("");
            return;
        }
        string sql = @"select idkhambenh=isnull(kb.idkhamsuckhoe,0)
,txtidbenhnhan=bn.idbenhnhan,txtLoaiBNhidden=dk.LoaiKhamID
,txtTenBenhNhan=bn.tenbenhnhan,txtGioiTinh=dbo.getgioitinh(bn.gioitinh),txtTuoi=bn.ngaysinh
,txtMaBenhNhan=bn.mabenhnhan,txtSoBHYT=bn.sobhyt,txtNgayHH=convert(varchar(10),bhyt.ngayhethan,103)
,txtSoDTBN=bn.dienthoai,txtDiaChi=bn.diachi,txtchieucao=sh.chieucao,txtmach=sh.mach,txtcannang=sh.cannang--,txthuyetap=isnull(huyetap1,0)+'/'+isnull(huyetap2,0)
,txtvongnguc=sh.vongnguc,txtnhietdo=sh.nhietdo,txtbmi=sh.BMI,txtnhiptho=sh.nhiptho
,txttimmach=kb.Timmach,txthohap=kb.Hohap,txttieuhoa=kb.Tieuhoa
,txtthantietlieusinhduc=kb.ThanTietNieuSinhDuc,txtthankinh=kb.Thankinh,txtcoxuongkhopcotsong=kb.CoxuongkhopCotsong
,txtdalieu=kb.Dalieu,txtklspk=kb.klspk,txtmtbt=kb.Mattrai,txtmpbt=kb.matphai,txtmtdk=kb.Mattraideokinh,txtmpdk=kb.Matphaideokinh
,txtklkm=ketluankhammat,txttaitraibt=kb.Taitrai,txttaiphaibt=kb.taiphai,txttaitraitt=kb.Taitraithitham,txttaiphaitt=kb.Taiphaithitham,txtmui=kb.mui
,txthong=kb.hong,txtkltmh=kb.ketluantmh,txtrhm1=kb.rhm1,txtrhm2=kb.rhm2,txtrhm3=kb.rhm3,txtrhm4=kb.rhm4,txtklrhm=kb.klrhm
,cbXetNghiemMau=convert(int,isnull(isxnmau,0)),cbXetNghiemNuocTieu=convert(int,isnull(isxnnt,0)),cbXetNghiemKhac=convert(int,isnull(xnk,0)),cbXQPhoi=convert(int,isnull(xqp,0)),cbSieuAmBung=convert(int,isnull(sab,0)),cbCLSKhac=convert(int,isnull(clsk,0))
,rdKhoeManh=case when kb.isBenh=1 then 0 else 1 end,rdMacBenh=convert(int,kb.isBenh),txtTenBenhMac=kb.TenBenhM
,rdLoai1=case when kb.LoaiSK=1 then 1 else 0 end,rdLoai2=case when kb.LoaiSK=2 then 1 else 0 end,rdLoai3=case when kb.LoaiSK=3 then 1 else 0 end
,rdLoai4=case when kb.LoaiSK=4 then 1 else 0 end,rdLoai5=case when kb.LoaiSK=5 then 1 else 0 end
,rdDuSucKhoe=case when kb.IsKoDuSucKhoe=1 then 0 else 1 end,rdKoDuSucKhoe=convert(int,kb.IsKoDuSucKhoe),txtTenCongViec=kb.tencongviec
,txtBSKetLuan=kb.BSKetLuan,txtHuongGiaiQ=kb.HuongGiaiQ,idHuongGiaiQuyet=isnull(kb.idHuongGiaiQuyet,0)
,isxnmau_text,isxnnt_text,xnk_text,xqp_text,sab_text,clsk_text
,NgoaiDaLieu=sh.NgoaiDaLieu,noiTQ=''
from benhnhan bn inner join dangkykham dk on dk.idbenhnhan =bn.idbenhnhan 
left join benhnhan_bhyt bhyt on bhyt.IDBENHNHAN_BH =dk.IDBENHNHAN_BH
inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham
left join khamsuckhoe kb on kb.idchitietdangkykham =ct.idchitietdangkykham 
	and idkhambenh =isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham =ct.idchitietdangkykham order by idkhambenh desc),0)
left join sinhhieu sh on sh.iddangkykham =dk.iddangkykham and idsinhhieu = isnull((select top 1 idsinhhieu from sinhhieu where iddangkykham =dk.iddangkykham order by idsinhhieu desc),0)
where ct.idchitietdangkykham  ='" + idchitietdangkykham + "' ";
        DataTable dtInfo = DataAcess.Connect.GetTable(sql);
        if (dtInfo != null && dtInfo.Rows.Count > 0)
        {
            System.Text.StringBuilder text = new System.Text.StringBuilder();
            for (int i = 0; i < dtInfo.Columns.Count;i++ )
            {
                text.Append(dtInfo.Columns[i].ColumnName+"="+dtInfo.Rows[0][i]+"&");
            }
            Response.Clear();
            Response.Write(text);
        }
        else
        {
            Response.Clear();
            Response.Write("");
            return;
        }
    }
    //__________________________________________________________________________________________________________________________
    private void LuuKBNew()
    {
        string idkhambenh = Request.QueryString["idkhambenh"].ToString();
        string idbenhnhan = Request.QueryString["idbenhnhan"].ToString();
        string idphongkham = Request.QueryString["idphongkham"].ToString();
        string osophieukham = Request.QueryString["sophieukham"].ToString();
        string ngaykham = Request.QueryString["ngaykham"].ToString();
        string[] date = ngaykham.Split('/');
        if (date.Length >= 3)
        {
            ngaykham = date[1].ToString() + "/" + date[0].ToString() + "/" + date[2].ToString();
        }
        string IdChiTietDangKyKham = Request.QueryString["IdChiTietDangKyKham"].ToString();
        string chieucao = Request.QueryString["chieucao"].ToString();
        string cannang = Request.QueryString["cannang"].ToString();
        string vongnguc = Request.QueryString["vongnguc"].ToString();
        string NgoaiDaLieu = Request.QueryString["NgoaiDaLieu"].ToString();
        //string vongnguc = Request.QueryString["vongnguc"].ToString();
        string bmi = Request.QueryString["bmi"].ToString();
        string mach = Request.QueryString["mach"].ToString();
        string huyetap = Request.QueryString["huyetap"].ToString();
        string nhietdo = Request.QueryString["nhietdo"].ToString();
        string nhiptho = Request.QueryString["nhiptho"].ToString();
        string timmach = Request.QueryString["timmach"].ToString();
        string hohap = Request.QueryString["hohap"].ToString();
        string tieuhoa = Request.QueryString["tieuhoa"].ToString();
        string thantietnieusinhduc = Request.QueryString["thantietnieusinhduc"].ToString();
        string thankinh = Request.QueryString["thankinh"].ToString();
        string noiTQ = Request.QueryString["noiTQ"].ToString();
        string coxuongkhopcotsong = Request.QueryString["coxuongkhopcotsong"].ToString();
        string dalieu = Request.QueryString["dalieu"].ToString();
        string sanphukhoa = Request.QueryString["sanphukhoa"].ToString();
        string mattrai = Request.QueryString["mattrai"].ToString();
        string mattraidk = Request.QueryString["mattraidk"].ToString();
        string matphai = Request.QueryString["matphai"].ToString();
        string matphaidk = Request.QueryString["matphaidk"].ToString();
        string klkm = Request.QueryString["klkm"].ToString();
        string taitrai = Request.QueryString["taitrai"].ToString();
        string taitraitt = Request.QueryString["taitraitt"].ToString();
        string taiphai = Request.QueryString["taiphai"].ToString();
        string taiphaitt = Request.QueryString["taiphaitt"].ToString();
        string mui = Request.QueryString["mui"].ToString();
        string hong = Request.QueryString["hong"].ToString();
        string kltmh = Request.QueryString["kltmh"].ToString();
        string rhm1 = Request.QueryString["rhm1"].ToString();
        string rhm2 = Request.QueryString["rhm2"].ToString();
        string rhm3 = Request.QueryString["rhm3"].ToString();
        string rhm4 = Request.QueryString["rhm4"].ToString();
        string klrhm = Request.QueryString["klrhm"].ToString();

        string isxnmau_text = Request.QueryString["isxnmau_text"].ToString();
        string isxnnt_text = Request.QueryString["isxnnt_text"].ToString();
        string xnk_text = Request.QueryString["xnk_text"].ToString();
        string xqp_text = Request.QueryString["xqp_text"].ToString();
        string sab_text = Request.QueryString["sab_text"].ToString();
        string clsk_text = Request.QueryString["clsk_text"].ToString();

        string iddangkykham = Request.QueryString["iddangkykham"].ToString();
        string idbacsi = Request.QueryString["idbacsi"].ToString();
        string sqlexist = @"select * from KhamSucKhoe where idKhamSucKhoe ='" + idkhambenh + "'";
        string sqlinsert = "";
        string insertsh = "";
        DataTable dt = DataAcess.Connect.GetTable(sqlexist);
        bool ok = false;
        string status = "0";
        if (dt != null && dt.Rows.Count == 0)
        {
            sqlinsert = @"insert into KhamSucKhoe (maphieukham,ngaykham,idbenhnhan,iddangkykham,idbacsi,ketluankhammat,ketluantmh,klrhm,idphongkhambenh,idchitietdangkykham,klspk,timmach,tieuhoa,hohap,thantietnieusinhduc,thankinh,coxuongkhopcotsong,dalieu,mattrai,matphai,mattraideokinh,matphaideokinh,taitrai,taiphai,taitraithitham,taiphaithitham,mui,hong,rhm,rhm1,rhm2,rhm3,rhm4,
            isxnmau_text ,
isxnnt_text ,
xnk_text ,
xqp_text ,
sab_text ,
clsk_text
            )";
            sqlinsert += @" values ('" + osophieukham + "','" + ngaykham + "','" + idbenhnhan + "','" + iddangkykham + "','" + idbacsi + "',N'" + klkm + "',N'" + kltmh + "',N'" + klrhm + "','" + idphongkham + "','" + IdChiTietDangKyKham + "',N'" + sanphukhoa + "',N'" + timmach + "',N'" + tieuhoa + "',N'" + hohap + "',N'" + thantietnieusinhduc + "',N'" + thankinh + "',N'" + coxuongkhopcotsong + "',N'" + dalieu + "',N'" + mattrai + "',N'" + matphai + "',N'" + mattraidk + "',N'" + matphaidk + "',N'" + taitrai + "',N'" + taiphai + "',N'" + taitraitt + "',N'" + taiphaitt + "',N'" + mui + "',N'" + hong + "',N'" + ("1 : " + rhm1 + " 2:" + rhm2 + " 3: " + rhm3 + " 4: " + rhm4) + "  KL: " + klrhm + "',N'" + rhm1 + "',N'" + rhm2 + "',N'" + rhm3 + "',N'" + rhm4 + @"',
N'"+isxnmau_text+@"',            
N'"+isxnnt_text+@"',            
N'"+xnk_text+@"',            
N'"+xqp_text+@"',            
N'"+sab_text+@"',            
N'" + clsk_text + @"'
            )";
            ok = DataAcess.Connect.ExecSQL(sqlinsert);
            if (ok)
            {
                string idkhambenh_new = DataAcess.Connect.GetTable("select max(idkhambenh) from khambenh").Rows[0][0].ToString();
                bool ktUp = UpdateCanLamSang_KetLuan(idkhambenh_new);
                if (ktUp)
                {
                    int idbn = int.Parse(idbenhnhan);
                    int sophieukham = int.Parse(iddangkykham);
                    UpdateTinhTrangDaKham(idbn, idphongkham, sophieukham);
                    status = DataAcess.Connect.GetTable("select isnull(max(idkhambenh),0) from khambenh").Rows[0][0].ToString();

                    insertsh = @" insert into sinhhieu(idbenhnhan,iddangkykham,ngaydo,mach,huyetap1,nhietdo,nhiptho,chieucao,cannang,bmi,idbacsi,vongnguc,NgoaiDaLieu)";
                    insertsh += " values(" + idbenhnhan + "," + iddangkykham + ",'" + ngaykham + "','" + mach + "','" + huyetap + "','" + nhietdo + "','" + nhiptho + "','" + chieucao + "','" + cannang + "','" + bmi + "'," + idbacsi + ",'" + vongnguc + "',N'" + NgoaiDaLieu + "')";
                    ok = DataAcess.Connect.ExecSQL(insertsh);
                }
                else
                {
                    DataAcess.Connect.ExecSQL("delete from khambenh where idkhambenh ='" + idkhambenh_new + "'");
                }
            }
        }
        else
        {
            #region update khambenh tự điền
            sqlinsert = @"update KhamSucKhoe set maphieukham='" + osophieukham + "',ngaykham='" + ngaykham + "',idbenhnhan='" + idbenhnhan + "',iddangkykham='" + iddangkykham + @"'
            ,idbacsi='" + idbacsi + "',ketluankhammat=N'" + klkm + "',ketluantmh=N'" + kltmh + "',klrhm=N'" + klrhm + "',idphongkhambenh='" + idphongkham + "',idchitietdangkykham='" + IdChiTietDangKyKham + @"'
            ,klspk=N'" + sanphukhoa + "',timmach=N'" + timmach + "',tieuhoa=N'" + tieuhoa + "',hohap=N'" + hohap + "',thantietnieusinhduc=N'" + thantietnieusinhduc + @"'
            ,thankinh=N'" + thankinh + "',coxuongkhopcotsong=N'" + coxuongkhopcotsong + "',dalieu=N'" + dalieu + "',mattrai=N'" + mattrai + "',matphai=N'" + matphai + @"'
            ,mattraideokinh=N'" + mattraidk + "',matphaideokinh=N'" + matphaidk + "',taitrai=N'" + taitrai + "',taiphai=N'" + taiphai + "',taitraithitham=N'" + taitraitt + @"'
            ,taiphaithitham=N'" + taiphaitt + "',mui=N'" + mui + "',hong=N'" + hong + "',rhm=N'" + ("1 : " + rhm1 + " 2:" + rhm2 + " 3: " + rhm3 + " 4: " + rhm4) + "  KL: " + klrhm + @"' 
            ,rhm1=N'"+ rhm1 +"',rhm2=N'"+ rhm2 +"',rhm3=N'"+ rhm3 +"',rhm4=N'"+ rhm4 + @"',
isxnmau_text =N'"+isxnmau_text+@"',
isxnnt_text =N'"+isxnnt_text+@"',
xnk_text =N'"+xnk_text+@"',
xqp_text =N'"+xqp_text+@"',
sab_text =N'"+sab_text+@"',
clsk_text =N'" + clsk_text + @"'
            where idKhamSucKhoe ='" + dt.Rows[0]["idkhambenh"].ToString() + "'";
            ok = DataAcess.Connect.ExecSQL(sqlinsert);
            if (ok)
            {
                bool ktUp = UpdateCanLamSang_KetLuan(dt.Rows[0]["idkhambenh"].ToString());
                if (ktUp)
                {
                    status = dt.Rows[0]["idkhambenh"].ToString();
                    #region sinh hieu
                    DataTable dtsh = DataAcess.Connect.GetTable("select * from sinhhieu where iddangkykham='" + iddangkykham + "' order by idsinhhieu desc");
                    if (dtsh != null && dtsh.Rows.Count == 0)
                    {
                        insertsh = @" insert into sinhhieu(idbenhnhan,iddangkykham,ngaydo,mach,huyetap1,nhietdo,nhiptho,chieucao,cannang,bmi,idbacsi,vongnguc,NgoaiDaLieu)";
                        insertsh += " values(" + idbenhnhan + "," + iddangkykham + ",'" + ngaykham + "','" + mach + "','" + huyetap + "','" + nhietdo + "','" + nhiptho + "','" + chieucao + "','" + cannang + "','" + bmi + "'," + idbacsi + ",'" + vongnguc + "',N'" + NgoaiDaLieu + "')";
                        ok = DataAcess.Connect.ExecSQL(insertsh);
                    }
                    else
                    {
                        insertsh = @" update sinhhieu set idbenhnhan='" + idbenhnhan + "',iddangkykham=" + iddangkykham + ",ngaydo='" + ngaykham + "',mach='" + mach + @"'
                                    ,huyetap1='" + huyetap + "',nhietdo='" + nhietdo + "',nhiptho='" + nhiptho + "',chieucao='" + chieucao + "',cannang='" + cannang + @"'
                                    ,bmi='" + bmi + "',idbacsi=" + idbacsi + ",vongnguc='" + vongnguc + "',NgoaiDaLieu=N'" + NgoaiDaLieu + "' where idsinhhieu='" + dtsh.Rows[0]["idsinhhieu"].ToString() + "'";
                        ok = DataAcess.Connect.ExecSQL(insertsh);
                    }
                    #endregion
                }
            }
            #endregion
        }
        Response.Clear();
        Response.Write(status);
    }
    //__________________________________________________________________________________________________________________________
    private bool UpdateCanLamSang_KetLuan(string idkhambenh)
    {
        #region thêm thông tin Cận Lâm Sàng + Kết luận
        #region para
        string isxnmau = (Request.QueryString["xnmau"] != null ? Request.QueryString["xnmau"].ToString() : "0");
        string isxnnt = (Request.QueryString["xnnt"] != null ? Request.QueryString["xnnt"].ToString() : "0");
        string xnk = (Request.QueryString["xnk"] != null ? Request.QueryString["xnk"].ToString() : "0");
        string xqp = (Request.QueryString["xqp"] != null ? Request.QueryString["xqp"].ToString() : "0");
        string sab = (Request.QueryString["sab"] != null ? Request.QueryString["sab"].ToString() : "0");
        string clsk = (Request.QueryString["clsk"] != null ? Request.QueryString["clsk"].ToString() : "0");
        string isBenh = (Request.QueryString["isBenh"] != null ? Request.QueryString["isBenh"].ToString() : "0");
        string TenBenhM = (Request.QueryString["TenBenhM"] != null ? Request.QueryString["TenBenhM"].ToString() : "");
        string LoaiSK = (Request.QueryString["LoaiSK"] != null ? Request.QueryString["LoaiSK"].ToString() : "0");
        string IsKoDuSucKhoe = (Request.QueryString["IsKoDuSucKhoe"] != null ? Request.QueryString["IsKoDuSucKhoe"].ToString() : "0");
        string tencongviec = (Request.QueryString["tencongviec"] != null ? Request.QueryString["tencongviec"].ToString() : "");
        string BSKetLuan = (Request.QueryString["BSKetLuan"] != null ? Request.QueryString["BSKetLuan"].ToString() : "0");
        string HuongGiaiQ = (Request.QueryString["HuongGiaiQ"] != null ? Request.QueryString["HuongGiaiQ"].ToString() : "0");
        string idHuongGiaiQuyet = (Request.QueryString["idHGQ"] != null ? Request.QueryString["idHGQ"].ToString() : "0");
        #endregion
        //string idkhambenh_new = DataAcess.Connect.GetTable("select max(idkhambenh) from khambenh").Rows[0][0].ToString();
        string sqlUp = @"update khambenh set isxnmau =" + isxnmau + @"
                                    ,isxnnt =" + isxnnt + @"
                                    ,xnk =" + xnk + @"
                                    ,xqp =" + xqp + @"
                                    ,sab =" + sab + @"
                                    ,clsk =" + clsk + @"
                                    ,isBenh =" + isBenh + @"
                                    ,TenBenhM =N'" + TenBenhM + @"'
                                    ,LoaiSK =" + LoaiSK + @"
                                    ,IsKoDuSucKhoe =" + IsKoDuSucKhoe + @"
                                    ,tencongviec =N'" + tencongviec + @"'
                                    ,BSKetLuan =N'" + BSKetLuan + @"'
                                    ,HuongGiaiQ =N'" + HuongGiaiQ + @"'
                                    ,idHuongGiaiQuyet ='" + idHuongGiaiQuyet + @"'
                                    where idkhambenh=" + idkhambenh + "";
        bool ktUp = DataAcess.Connect.ExecSQL(sqlUp);
        return ktUp;
        #endregion
    }
    //__________________________________________________________________________________________________________________________
    private void UpdateTinhTrangDaKham(int idbn, string iidPKB, int idphieudangkykham)
    {

        string sql = "";
        sql = @"update chitietdangkykham set dakham=1 where idchitietdangkykham in 
               (SELECT idchitietdangkykham 
                FROM dangkykham dk INNER JOIN chitietdangkykham ctdk ON dk.iddangkykham = ctdk.iddangkykham  LEFT JOIN BanggiaDichVu bg on ctdk.IdBanggiadichvu=bg.idbanggiadichvu
                WHERE bg.idphongkhambenh = " + iidPKB + " AND dk.idbenhnhan = " + idbn + " AND ctdk.dakham = 0 AND dk.iddangkykham = " + idphieudangkykham+@"
               )";
        bool kt = DataAcess.Connect.ExecSQL(sql);
    }
    //__________________________________________________________________________________________________________________________
    private void GetBenhNhanInfo()
    {
        string tenbn;
        tenbn = Request.QueryString["q"].ToString();
        string sql = @"select top 20 idbenhnhan,mabenhnhan,tenbenhnhan,b.dienthoai,b.diachi,CASE WHEN b.gioitinh=0 THEN N'Nữ' ELSE 'Nam' end  as gioitinh,ngaysinh
  FROM benhnhan b  WHERE b.tenbenhnhan like N'%" + tenbn + "%'";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string html = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += dt.Rows[i]["idbenhnhan"].ToString() + "/" + dt.Rows[i]["mabenhnhan"].ToString() + "/" + dt.Rows[i]["tenbenhnhan"].ToString() + Environment.NewLine;
            }

        }
        //Response.Clear();
        Response.Write(html);
    }
    //__________________________________________________________________________________________________________________________
}
