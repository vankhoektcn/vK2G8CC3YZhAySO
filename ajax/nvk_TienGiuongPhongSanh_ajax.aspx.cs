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
using Microsoft.Office;

public partial class nvk_TienGiuongPhongSanh_ajax : System.Web.UI.Page
{
    protected DataProcess nvk_chanDoanNhapKhoa()
    {
        DataProcess nvk_chanDoanNhapKhoa = new DataProcess("nvk_chanDoanNhapKhoa");
        nvk_chanDoanNhapKhoa.data("idCdNhapKhoa", Request.QueryString["idkhoachinh"]);
        nvk_chanDoanNhapKhoa.data("idnoitru", Request.QueryString["idnoitru"]);
        nvk_chanDoanNhapKhoa.data("idicd", Request.QueryString["idicd"]);
        return nvk_chanDoanNhapKhoa;
    }
    protected DataProcess nvk_benhnhannoitru(string idnoitru,string idTuKhoa,string idkhoaNhap, string idctdkk, string idKBgoc, string idkhambenh,
        string idbenhnhan,string isChonTrongNgay,string isNhapKhoa, string isChoSanh)
    {
        DataProcess nvk_benhnhannoitru = new DataProcess("BenhNhanNoiTru");
        nvk_benhnhannoitru.data("IdNoiTru", idnoitru);
        #region ngày nhập khoa
        string ngaynhap = Request.QueryString["txtNgayNhap"].ToString();
        if (Request.QueryString["txtGioNhap"].ToString().Equals(""))
            ngaynhap +=" "+ DateTime.Now.ToString("HH:mm");
        else
            ngaynhap +=" "+ Request.QueryString["txtGioNhap"].ToString();
        #endregion
        nvk_benhnhannoitru.data("NgayVaoVien", ngaynhap);
        nvk_benhnhannoitru.data("NhapTuKhoa", idTuKhoa);

        nvk_benhnhannoitru.data("IdKhoaNoiTru", idkhoaNhap);
        nvk_benhnhannoitru.data("IdChiTietDangKyKham", idctdkk);
        nvk_benhnhannoitru.data("IdKhamBenhGoc", idKBgoc);

        nvk_benhnhannoitru.data("IdBenhNhan", idbenhnhan);
        nvk_benhnhannoitru.data("IdPhongNoiTru", Request.QueryString["selPhongNhap"]);
        nvk_benhnhannoitru.data("IdGiuong", Request.QueryString["selGiuongNhap"]);

        //nvk_benhnhannoitru.data("GhiChu", Request.QueryString["idnoitru"]);
        //nvk_benhnhannoitru.data("ListIdCD", Request.QueryString["idnoitru"]);
        nvk_benhnhannoitru.data("GiaGiuong", Request.QueryString["txtGiaGiuong"].Replace(",", ""));

        nvk_benhnhannoitru.data("IsDaNhap", "1");
        nvk_benhnhannoitru.data("IdKhamBenhNhap", idkhambenh);
        nvk_benhnhannoitru.data("idbacsiNhap", Request.QueryString["idbacsi"]);

        nvk_benhnhannoitru.data("iddieuduongNhap", Request.QueryString["iddieuduong"]);
        nvk_benhnhannoitru.data("isChonTrongNgay", isChonTrongNgay);
        //nvk_benhnhannoitru.data("isChonNgaysau", Request.QueryString["idicd"]);

        //nvk_benhnhannoitru.data("songay", Request.QueryString["idnoitru"]);
        nvk_benhnhannoitru.data("isNhapKhoa", isNhapKhoa);
        nvk_benhnhannoitru.data("isChoSanh", isChoSanh);
        return nvk_benhnhannoitru;
    }

    protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "btnTimKiem_click": btnTimKiem_click(); break;
             case "TienGiuong_Click": TienGiuong_Click(); break;
             case "nvk_LoadGiuongNhapTheoPhong": nvk_LoadGiuongNhapTheoPhong(); break;
             case "nvk_LoadGiaTheoGiuong": nvk_LoadGiaTheoGiuong(); break;
             case "ChanDoansearch": ChanDoansearch(); break;
             case "xoanvk_chanDoanNhapKhoa": xoanvk_chanDoanNhapKhoa(); break;
             case "btnLuuNhapKhoa_Click": btnLuuNhapKhoa_Click(); break;
             case "nvk_luutableChanDoanNhapKhoa": nvk_luutableChanDoanNhapKhoa(); break;

             case "VaoChoSanh_Click": VaoChoSanh_Click(); break;
             case "TT_BenhnhanXuatKhoa": TT_BenhnhanXuatKhoa(); break;
         }
     }
    //Lưu chân đoán nhập khoa
    private void nvk_luutableChanDoanNhapKhoa()
    {
        try
        {
            DataProcess process = nvk_chanDoanNhapKhoa();
            if (process.getData("idicd").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }
            if (process.getData("idCdNhapKhoa") != null && process.getData("idCdNhapKhoa") != "" && process.getData("idCdNhapKhoa") != "0")
            {                
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idCdNhapKhoa"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idCdNhapKhoa"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    // lưu/ cập nhật thông tin nhập khoa (gồm nhập nội, nhập chờ)
    private void btnLuuNhapKhoa_Click()
    {
        #region khai báo tham số QueryString
        string idkhoa = Request.QueryString["idkhoa"];
        string idkhambenh = Request.QueryString["idkhambenh"];
        string idnoitru =  Request.QueryString["idnoitru"];
        string txtNgayNhap = Request.QueryString["txtNgayNhap"];
        string txtGioNhap = Request.QueryString["txtGioNhap"];
        string IsLuuCho = Request.QueryString["IsLuuCho"]; //xác đinh loại nhập khoa IsLuuCho=1 là nhập chờ (VD: chờ sanh)
        string selPhongNhap =Request.QueryString["selPhongNhap"];
        string selGiuongNhap = Request.QueryString["selGiuongNhap"];
        string txtGiaGiuong = Request.QueryString["txtGiaGiuong"].Replace(",","");
        string idbacsi = Request.QueryString["idbacsi"];
        string iddieuduong = Request.QueryString["iddieuduong"];
        string cbTinhTienTrongNgay = Request.QueryString["cbTinhTienTrongNgay"];
        #endregion
        #region xét giá trị tham số khác
        #region ngày nhập khoa
        string ngaynhap = Request.QueryString["txtNgayNhap"].ToString();
        if (string.IsNullOrEmpty(txtGioNhap))
            txtGioNhap =DateTime.Now.ToString("HH:mm");
        #endregion
        string sqlInFo = @"select idphongkhambenh,idchitietdangkykham,idkbG=isnull((select top 1 idkhambenh where idchitietdangkykham =kb.idkhambenh order by idkhambenh desc),0)
                        ,kb.idbenhnhan
                         from khambenh kb where idkhambenh ='" +idkhambenh+"'";
        DataTable dtInFo = DataAcess.Connect.GetTable(sqlInFo);
        if (dtInFo == null || dtInFo.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write(""); return;
        }
        string idTuKhoa = dtInFo.Rows[0]["idphongkhambenh"].ToString();
        string idchitietdangkykham = dtInFo.Rows[0]["idchitietdangkykham"].ToString();
        string idKBGoc = dtInFo.Rows[0]["idkbG"].ToString(); ;
        string idbenhnhan = dtInFo.Rows[0]["idbenhnhan"].ToString();
        string isChonNgay= cbTinhTienTrongNgay.Equals("true") ? "1" : "0";
        #endregion
        #region using DataProcess (Not Use)
        //DataProcess benhnhannoitru = nvk_benhnhannoitru(idnoitru, idTuKhoa, idkhoa, idchitietdangkykham, idKBGoc, idkhambenh, idbenhnhan, isChonNgay, "1", "0");
        //if (benhnhannoitru.getData("IdNoiTru") != null && benhnhannoitru.getData("IdNoiTru") != "" && benhnhannoitru.getData("IdNoiTru") != "0")
        //{
        //    bool ok = benhnhannoitru.Update();
        //    if (ok)
        //    {
        //        Response.Clear(); Response.Write(benhnhannoitru.getData("IdNoiTru"));
        //        return;
        //    }
        //}
        //else
        //{
        //    //string newIdNoiTru = DataAcess.Connect.GetTable("select isnull((select max(idnoitru)+1 from benhnhannoitru),1)").Rows[0][0].ToString();
        //    //benhnhannoitru.data("IdNoiTru", newIdNoiTru);
        //    bool ok = benhnhannoitru.Insert();
        //    if (ok)
        //    {
        //        Response.Clear(); Response.Write(benhnhannoitru.getData("IdNoiTru"));
        //        return;
        //    }
        //}
        //Response.Clear();
        //Response.Write("");
        #endregion

        #region using sqlCommand ( Use)
        bool ok = false;
        if (!string.IsNullOrEmpty(idnoitru) && !idnoitru.Equals("0"))
        {
            string sqlUpdate = @"
                        update BenhNhanNoiTru set
                             NgayVaoVien='" + StaticData.CheckDate(ngaynhap) +" "+ txtGioNhap+ @"'
                            ,NhapTuKhoa='" + idTuKhoa + @"'
                            ,IdKhoaNoiTru='" + idkhoa + @"'
                            ,IdChiTietDangKyKham='" + idchitietdangkykham + @"'
                            ,IdKhamBenhGoc='" + idKBGoc + @"'
                            ,IdBenhNhan='" + idbenhnhan + @"'
                            ,IdPhongNoiTru='" + selPhongNhap + @"'
                            ,IdGiuong='" + selGiuongNhap + @"'
                            ,GiaGiuong='" + txtGiaGiuong + @"'
                            ,IsDaNhap='1'
                            ,IdKhamBenhNhap='" + idkhambenh + @"'
                            ,idbacsiNhap='" + idbacsi + @"'
                            ,iddieuduongNhap='" + iddieuduong + @"'
                            ,isChonTrongNgay='" + isChonNgay + @"'
                            --,isChonNgaysau=''
                            --,songay=''
                            ,isNhapKhoa='1'
                            ,isChoSanh='"+IsLuuCho+@"'
                        where idnoitru='" + idnoitru + "'";
            ok = DataAcess.Connect.ExecSQL(sqlUpdate);
            if (!ok)
            {
                Response.Clear(); Response.Write(idnoitru);
                return;
            }
        }
        else
        {
            string sqlInsert = @"
                                insert into BenhNhanNoiTru(
                                        NgayVaoVien
                                        ,NhapTuKhoa
                                        ,IdKhoaNoiTru
                                        ,IdChiTietDangKyKham
                                        ,IdKhamBenhGoc
                                        ,IdBenhNhan
                                        ,IdPhongNoiTru
                                        ,IdGiuong
                                        ,GhiChu
                                        ,GiaGiuong
                                        ,IsDaNhap
                                        ,IdKhamBenhNhap
                                        ,idbacsiNhap
                                        ,iddieuduongNhap
                                        ,isChonTrongNgay
                                        ,isChonNgaysau
                                        ,songay
                                        ,isNhapKhoa
                                        ,isChoSanh)
                        values(
                            '" + StaticData.CheckDate(ngaynhap) + " " + txtGioNhap + @"'
                            ,'" + idTuKhoa + @"'
                            ,'" + idkhoa + @"'
                            ,'" + idchitietdangkykham + @"'
                            ,'" + idKBGoc + @"'
                            ,'" + idbenhnhan + @"'
                            ,'" + selPhongNhap + @"'
                            ,'" + selGiuongNhap + @"'
                            ,null
                            ,'" + txtGiaGiuong + @"'
                            ,'1'
                            ,'" + idkhambenh + @"'
                            ,'" + idbacsi + @"'
                            ,'" + iddieuduong + @"'
                            ,'" + isChonNgay + @"'
                            ,null
                            ,null
                            ,'1'
                            ,'" + IsLuuCho + @"')";
            ok = DataAcess.Connect.ExecSQL(sqlInsert);
            if (!ok)
            {
                Response.Clear(); Response.Write("");
                return;
            }
            idnoitru = DataAcess.Connect.GetTable("select isnull((select max(idnoitru) from benhnhannoitru),0)").Rows[0][0].ToString();
        }
        #region cập nhật trạng thái check tính giường
        if (isChonNgay.Equals("1"))
        {
            bool ktTTG = StaticData.NVK_CapNhatTinhTrangGiuong(txtNgayNhap, idchitietdangkykham, idnoitru, "0");
        }
        #endregion
            Response.Clear(); Response.Write(idnoitru);
        #endregion
    }
    //xóa chẩn đoán nhập khoa
    private void xoanvk_chanDoanNhapKhoa()
    {
        try
        {
            DataProcess process = nvk_chanDoanNhapKhoa();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idCdNhapKhoa"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    //tìm kiếm chẩn đoán
    private void ChanDoansearch()
    {
        string IsMaICD = Request.QueryString["IsMaICD"];
        string TenSearch = Request.QueryString["q"];
        string sql = @"select top 20 idicd,maicd,mota from chandoanicd where ";
        if (IsMaICD.Equals("1"))
            sql += " maicd like N'" + TenSearch + "%'";
        else
            sql += " mota like N'%" + TenSearch + "%'";
        DataTable table = DataAcess.Connect.GetTable(sql);

        string html = "";
        html = string.Format("{0}|{1}|{2}|{3}|{4}", ""
       + "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
       + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >MaICD</div>"
       + "<div style=\"width:55%;height:30px;color:#000;font-weight:bold;float:left\" >Mô tả</div>"
       + "</div>", "", "", "", Environment.NewLine);
        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div>"
        + "<div style=\"width:15%;height:30px;float:left\" >" + (i + 1) + "</div>"
        + "<div style=\"width:30%;height:30px;float:left\" >" + h["maicd"] + "</div>"
        + "<div style=\"width:55%;height:30px;float:left\" >" + h["mota"] + "</div>"
         + "</div>", h["idicd"], h["maicd"], h["mota"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    //tìm kiếm bệnh nhân chờ nhập khoa
    private void btnTimKiem_click()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idkhoa = Request.QueryString["idkhoa"];
        string mabenhnhan = Request.QueryString["mabenhnhan"];
        string tenbenhnhan = Request.QueryString["tenbenhnhan"];
        string tungay = Request.QueryString["tungay"];
        string denngay = Request.QueryString["denngay"];
        if (idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("Chưa xác định khoa !");
            return;
        }
        string sqlChoNhap = @"
            select *,ngayxetnhap=convert(varchar(10),ngayxetnhap1,103)+' '+ convert(varchar(5),ngayxetnhap1,108)

             from (
                   select bn.idbenhnhan,abc.idchitietdangkykham
			            ,idnoitru=''
                        -- nội dung hiển thị             
                        ,BN.MABENHNHAN
                        ,BN.TENBENHNHAN
                        ,BN.DIACHI
                        ,BN.DIENTHOAI
                        ,Gioi = case when isnull(gioitinh,0)=0 then N'Nam' else N'Nữ' end
                        ,namsinh = ngaysinh
			            ,ngayXetNhap1=isnull((select top 1 ngayvaovien from benhnhannoitru where idchitietdangkykham =abc.idchitietdangkykham order by ngayvaovien asc),0)
                        ,chuyentu =phong.maso +'-'+phong.tenphong
                        ,giuongnam =isnull((select top 1 GiuongCode from kb_giuong where GiuongId =isnull((select top 1 IdGiuong from benhnhannoitru where idchitietdangkykham =abc.idchitietdangkykham order by ngayvaovien desc),0)),'')
		            from (select distinct idchitietdangkykham,idbenhnhan  from benhnhannoitru where ischosanh =1) as abc
			            inner join  chitietdangkykham ctdkk on abc.idchitietdangkykham= ctdkk.idchitietdangkykham 
			            left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
                        left join kb_phong phong on ctdkk.phongid=phong.id
			            inner join benhnhan bn on bn.idbenhnhan =abc.idbenhnhan
            ) as nvk where 1=1 ";//abc.ngayXetNhap1 >='" + DateTime.Now.ToString("yyyy/MM/dd") + "' and abc.ngayXetNhap1 <='" + DateTime.Now.ToString("yyyy/MM/dd") + " 23:59:59'";
        #region nvk_dieukienSQL
        string nvk_dk = "";
        if (!mabenhnhan.Equals(""))
            nvk_dk += " and nvk.mabenhnhan like N'%" + mabenhnhan + "%'";
        if (!tenbenhnhan.Equals(""))
            nvk_dk += " and nvk.tenbenhnhan like N'%" + tenbenhnhan + "%'";
        //if (!tungay.Equals(""))
        //    nvk_dk += " and nvk.ngayXetNhap1 >='" + StaticData.CheckDate(tungay) + "'";
        //if (!denngay.Equals(""))
        //    nvk_dk += " and nvk.ngayXetNhap1 <='" + StaticData.CheckDate(denngay) + " 23:59:59'";
        sqlChoNhap += nvk_dk + " order by ngayXetNhap1 desc";
        #endregion
        DataTable dtChoNhap = DataAcess.Connect.GetTable(sqlChoNhap);
        if (dtChoNhap != null)
        {
            html.Append(nvk_htmlTableBenhNhan_Giuong(dtChoNhap,idkhoa));
        }
        else
            html.Append("Lỗi khi load danh sách chờ !");
        Response.Clear();
        Response.Write(html);
    }
    // load giường nhập theo phòng
    private void nvk_LoadGiuongNhapTheoPhong()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idkhoa = Request.QueryString["idkhoa"];
        string idphong = Request.QueryString["idphong"];
        string GiaGiuong = "0";
        html.Append(LoadGiuongNhap(idkhoa, idphong, "0", ref GiaGiuong, true) + @"
                                <span class='spanText'>| Giá giường :</span><span class='spanText' id='spGiaGiuong'><input id='txtGiaGiuong' type='text' style='width: 80px;text-align:Right' value='" + GiaGiuong + @"' /></span>");
        Response.Clear();
        Response.Write(html);
    }
    //load giá giường
    private void nvk_LoadGiaTheoGiuong()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        string idgiuong = Request.QueryString["idgiuong"];
        string GiaGiuong = DataAcess.Connect.GetTable(@"select giagiuong=isnull(
                    (select top 1 giaDV from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid
                     where g.giuongid='"+idgiuong+@"' order by banggiagiuongid desc)
                    ,0)").Rows[0][0].ToString();
        Response.Clear();
        Response.Write(GiaGiuong);
    }
    #region thông tin bệnh nhân xuất khoa
    private void TT_BenhnhanXuatKhoa()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idctdkk = Request.QueryString["idctdkk"];
        string sqlBN = @"
                    select mabenhnhan,tenbenhnhan,ngaysinh,gioitinh=dbo.getgioitinh(gioitinh)
        ,ngaynhapvien=isnull((select top 1 convert(varchar(10),ngayvaovien,103) +' ' + convert(varchar(5),ngayvaovien,108) from benhnhannoitru where idchitietdangkykham='" + idctdkk + @"' order by ngayvaovien asc),'')
        ,GiuongNam=isnull( (select top 1 giuongcode from kb_giuong where giuongid in(select top 1 idgiuong from benhnhannoitru where idchitietdangkykham='" + idctdkk + @"' order by ngayvaovien desc)),'')

                    from  benhnhan bn inner join dangkykham dk on dk.idbenhnhan=bn.idbenhnhan 
                            inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
                     where ct.idchitietdangkykham='" + idctdkk + "'  ";
        DataTable dtBN = DataAcess.Connect.GetTable(sqlBN);
        if (dtBN.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("Lỗi khi load thông tin bệnh nhân !"); return;
        }
        html.Append(@"
        <div id='divFather' style='width: 99%;'>
                <fieldset class='fieldset_Father'>
                    <div id='divTimKiem' class='divControl' style='text-align:left'>
                        <fieldset class='fieldset_CT'>
                            <legend class='legend_CT'>Thông tin bệnh nhân</legend>");
        string table_Bn = nvk_tableBenhNhan(dtBN);
        html.Append(table_Bn);
        html.Append(@"</fieldset>
                    </div>
                </fieldset>
        </div>");
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region view tiền giường sanh
    private void TienGiuong_Click()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();

        #region getqueryString
        string idkhoa = Request.QueryString["idkhoa"];
        if (idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("Chưa xác định khoa !");
            return;
        }
        string idctdkk = Request.QueryString["idctdkk"];
        
        #endregion

        #region thông tin bệnh nhân
        string sqlBN = @"
                    select mabenhnhan,tenbenhnhan,ngaysinh,gioitinh=dbo.getgioitinh(gioitinh)
        ,ngaynhapvien=isnull((select top 1 convert(varchar(10),ngayvaovien,103) +' ' + convert(varchar(5),ngayvaovien,108) from benhnhannoitru where idchitietdangkykham='" + idctdkk + @"' order by ngayvaovien asc),'')
        ,GiuongNam=isnull( (select top 1 giuongcode from kb_giuong where giuongid in(select top 1 idgiuong from benhnhannoitru where idchitietdangkykham='" + idctdkk + @"' order by ngayvaovien desc)),'')

                    from  benhnhan bn inner join dangkykham dk on dk.idbenhnhan=bn.idbenhnhan 
                            inner join chitietdangkykham ct on ct.iddangkykham =dk.iddangkykham 
                     where ct.idchitietdangkykham='" + idctdkk+"'  ";
        DataTable dtBN = DataAcess.Connect.GetTable(sqlBN);
        if (dtBN.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("Lỗi khi load thông tin bệnh nhân !"); return;
        }
        string qr_ngaynhap = dtBN.Rows[0]["ngaynhapvien"].ToString();
        string qr_phong = dtBN.Rows[0]["GiuongNam"].ToString();
        #endregion

        #region nội dung
        string NoiDungTienGiuong = "";
        html.Append(@"
        <div id='divFather' style='width: 99%;'>
                <fieldset class='fieldset_Father'>
                    <div id='divTimKiem' class='divControl' style='text-align:left'>
                        <fieldset class='fieldset_CT'>
                            <legend class='legend_CT'>Thông tin bệnh nhân</legend>");
        string table_Bn = nvk_tableBenhNhan(dtBN);
        html.Append(table_Bn);
//          html.Append(@"    <span class='spanText'>| Mã bệnh nhân:</span><span class='spanText_Blue'>"+dtBN.Rows[0]["mabenhnhan"]+@"</span>
//                            <span class='spanText'>| Tên bệnh nhân :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["tenbenhnhan"] + @"</span>
//                            <span class='spanText'>| Ngày sinh :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["ngaysinh"] + @"</span>
//                            <span class='spanText'>| Giới tính :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["gioitinh"] + @"</span><br/>
//                            <span class='spanText'>| Ngày nhập :</span><span class='spanText_Blue'>" + qr_ngaynhap + @"</span>
//                            <span class='spanText'>| Giường :</span><span class='spanText_Blue'>" + qr_phong + @"</span>");
         html.Append(@"</fieldset>
                    </div>");
        html.Append(@"
                    <div class='divContent'>
                        <fieldset class='fieldset_TTNK'>
                           <legend class='legend_TTNK'>Thông tin tiền giường</legend>
                             <div id='diTienGiuong' style='width:100%;text-align:left;background-color: #D4D0C8;padding-bottom:15px'>
                        " + StaticData.nvk_ThongTinTienGiuong(idctdkk, idkhoa) + @"
                             </div>
                        </fieldset>
                    </div>
                </fieldset>
            </div>
");

        #endregion
        Response.Clear();
        Response.Write(html);
    }
    #region table thông tin bệnh nhân
    private string nvk_tableBenhNhan(DataTable dt)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTableBenhNhan\">";
        html += "<tr>";
        html += "<th>Mã Bệnh Nhân</th>";
        html += "<th>Tên bệnh nhân</th>";
        html += "<th>Ngày sinh</th>";
        html += "<th>Giới tính</th>";
        html += "<th>Ngày nhập</th>";
        html += "<th>Giường</th>";
        html += "</tr>";
        if (dt != null && dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td style='text-align:left;color:blue;font-weight:bold;'>" + dt.Rows[0]["mabenhnhan"] + "</td>";
                html += "<td style='text-align:left;color:blue;font-weight:bold;'>" + dt.Rows[0]["tenbenhnhan"] + "</td>";
                html += "<td style='text-align:center;color:blue;font-weight:bold;'>" + dt.Rows[0]["ngaysinh"] + "</td>";
                html += "<td style='text-align:center;color:blue;font-weight:bold;'>" + dt.Rows[0]["gioitinh"] + "</td>";
                html += "<td style='text-align:center;color:blue;font-weight:bold;'>" + dt.Rows[0]["ngaynhapvien"] + "</td>";
                html += "<td style='text-align:center;color:blue;font-weight:bold;'>" + dt.Rows[0]["giuongnam"] + "</td>";                
                html += "</tr>";
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
    #endregion
    #endregion
    #region view chờ sanh
    private void VaoChoSanh_Click()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();

        #region getqueryString
        string idkhoa = Request.QueryString["idkhoa"];
        if (idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("Chưa xác định khoa !");
            return;
        }
        string idnoitru = Request.QueryString["idnoitru"];
        string idkhambenh = Request.QueryString["idkhambenh"];
        #endregion

        #region thông tin bệnh nhân
        string sqlBN = @"
                    select mabenhnhan,tenbenhnhan,ngaysinh,gioitinh=dbo.getgioitinh(gioitinh)
                    ,tenkhoaxetnhap=isnull((select top 1 tenphongkhambenh from phongkhambenh where idphongkhambenh =kb.idphongkhambenh),'')
                    ,tenkhoanoitru=isnull((select top 1 tenphongkhambenh from phongkhambenh where idphongkhambenh='" + idkhoa + @"'),'')
                    ,ngaychonhap=convert(varchar(10),ngaykham,103)+' '+convert(varchar(5),ngaykham,108)
                    ,chandoanxetnhap='('+cd.maicd+')'+cd.mota
                    from khambenh kb inner join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan
                    left join chandoanicd cd on cd.idicd=convert(int,kb.ketluan)
                     where kb.idkhambenh='" + idkhambenh + "'  ";
        DataTable dtBN = DataAcess.Connect.GetTable(sqlBN);
        if (dtBN.Rows.Count == 0)
        {
            Response.Clear();
            Response.Write("Lỗi khi load thông tin bệnh nhân !"); return;
        }
        #endregion
        #region khai báo tham số
        string NgayNhapKhoa = DateTime.Now.ToString("dd/MM/yyyy");
        string GioNhapKhoa = DateTime.Now.ToString("HH:mm");

        string tableCdPh = "";
        DataTable dtCDPH = DataAcess.Connect.GetTable("select ct.*,cd.maicd,cd.mota from nvk_chanDoanNhapKhoa ct inner join chandoanicd cd on cd.idicd=ct.idicd where ct.idnoitru='" + idnoitru + "'");
        tableCdPh = strTableChanDoanPhoiHop(dtCDPH);

        string idPhongNhap = "0";
        string idGiuongNhap = "0";
        string GiaGiuongNhap = "0";
        string idBacSi = "0";
        string idDieuDuong = "0";
        string tenBacSi = "";
        string tenDieuDuong = "";
        string strCheckNguyenNgay = "";

        string strCheckTinhGiuong = "";
        string strDisableTG = "disabled";
        #endregion

        #region chuẩn bị tham số
        if (!idnoitru.Equals("") && !idnoitru.Equals("0"))
        {
            string sqlDaNhap = @"select idnoitru,ngaynhap103=convert(varchar(10),ngayvaovien,103),gionhap103=convert(varchar(5),ngayvaovien,108)
                    ,idphongnoitru,idGiuong,GiaGiuong,idBacSiNhap,idDieuDuongNhap,isNgaychon=isnull(convert(int,ischontrongngay),0)
                    ,tenBacSi=bs.tenBacSi,tenDieuDuong=nv.tennhanvien
                    from benhnhannoitru nt left join bacsi bs on bs.idbacsi=nt.idBacSiNhap
                        left join nhanvien nv on nv.idnhanvien=nt.idDieuDuongNhap
                    where idnoitru='" + idnoitru + "'  and isdanhap=1 and  isnhapkhoa=1";
            DataTable dtDaNhap = DataAcess.Connect.GetTable(sqlDaNhap);
            if (dtDaNhap.Rows.Count > 0)
            {
                NgayNhapKhoa = dtDaNhap.Rows[0]["ngaynhap103"].ToString();
                GioNhapKhoa = dtDaNhap.Rows[0]["gionhap103"].ToString();

                idPhongNhap = dtDaNhap.Rows[0]["idphongnoitru"].ToString();
                idGiuongNhap = dtDaNhap.Rows[0]["idGiuong"].ToString();
                GiaGiuongNhap = dtDaNhap.Rows[0]["GiaGiuong"].ToString();
                idBacSi = dtDaNhap.Rows[0]["idBacSiNhap"].ToString();
                idDieuDuong = dtDaNhap.Rows[0]["idDieuDuongNhap"].ToString();
                tenBacSi = dtDaNhap.Rows[0]["tenBacSi"].ToString();
                tenDieuDuong = dtDaNhap.Rows[0]["tenDieuDuong"].ToString();
                strCheckNguyenNgay = dtDaNhap.Rows[0]["isNgaychon"].ToString().Equals("1") ? "checked" : "";

                strCheckTinhGiuong = (GiaGiuongNhap.Equals("") || GiaGiuongNhap.Equals("0")) ? "" : "checked";
                strDisableTG = (GiaGiuongNhap.Equals("") || GiaGiuongNhap.Equals("0")) ? "disabled" : "";
                //strCheckTinhGiuong = "checked";
            }
        }
        #endregion

        #region nội dung
        html.Append(@"
        <div id='divFather' style='width: 99%;'>
                <fieldset class='fieldset_Father'>
                    <div id='divTimKiem' class='divControl' style='text-align:left'>
                        <fieldset class='fieldset_CT'>
                            <legend class='legend_CT'>Thông tin bệnh nhân</legend>
                            <span class='spanText'>| Mã bệnh nhân:</span><span class='spanText_Blue'>" + dtBN.Rows[0]["mabenhnhan"] + @"</span>
                            <span class='spanText'>| Tên bệnh nhân :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["tenbenhnhan"] + @"</span>
                            <span class='spanText'>| Ngày sinh :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["ngaysinh"] + @"</span>
                            <span class='spanText'>| Giới tính :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["gioitinh"] + @"</span><br/>
                            <span class='spanText'>| Khoa cho nhập :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["tenkhoaxetnhap"] + @"</span>
                            <span class='spanText'>| Ngày cho nhập :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["ngaychonhap"] + @"</span>
                            <span class='spanText'>| Chẩn đoán cho nhập :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["chandoanxetnhap"] + @"</span>
                        </fieldset>
                    </div>
                    <div class='divContent'>
                        <fieldset class='fieldset_TTNK'>
                                <legend class='legend_TTNK'>Thông Tin Chờ Sanh</legend>
                                <div id='divNhapHauSan' runat='server' style='width:100%;text-align:left;background-color: #ABCDEF;padding-bottom:15px'>
            <span class='spanText'>| Khoa Nhập :</span><span class='spanText_Blue'>" + dtBN.Rows[0]["tenkhoanoitru"] + @"</span>
            <span class='spanText'>| Ngày nhâp :</span>
                <input mkv='true' id='txtNgayNhap' type='text'  onfocus='$(this).datepick();' onblur='nvk_testDate_this(this);'  style='width: 80px;' value='" + NgayNhapKhoa + @"' />
                <input mkv='true' id='txtGioNhap' type='text' style='width: 40px;' value='" + GioNhapKhoa + @"'  />");// #D4D0C8,#AABBCC,#CAE3FF
        //            html.Append(@"<span class='spanText'>Chẩn đoán :</span>
        //                <input type='hidden' id='ListCDNhap' value='' />");
        //html.Append("<input id=\"txtMaICD\" type='text' onfocus=\"LoadChanDoanNhap('txtMaICD',1)\" style='width: 40px;' />");
        //html.Append("<input id='txtMoTaICD' type='text' onfocus=\"LoadChanDoanNhap('txtMoTaICD',0)\" style='width: 300px;' /><span class='spanText'>(theo ICD10)</span>");
        html.Append("<br/>");
        html.Append("<span class='spanText'>| Chẩn đoán nhập khoa :</span>");
        html.Append(tableCdPh);
        html.Append(@"
            <span class='spanText' id='spTinhTienGiuong'>
                   <input  mkv='true' type='checkbox' id='cbTinhGiuongCho'  onclick='OnCheck_TinhGiuongCho(this)' " + strCheckTinhGiuong + @"/><span style='color:Red;font-weight:bold;'>Tính tiền giường</span>
            </span>
            <br/>
            <span class='spanText' id='spThongTinGiuong'>
                            <span class='spanText'>| Chọn giường :</span><span class='spanText' id='spGiuongNhap'>" + LoadGiuongChoSanh(idkhoa,idGiuongNhap, ref GiaGiuongNhap, false,strDisableTG) + @"
                                <span class='spanText'>| Giá giường :</span><span class='spanText' id='spGiaGiuong'><input  mkv='true' id='txtGiaGiuong' type='text' style='width: 80px;text-align:Right' value='" + GiaGiuongNhap + @"' "+strDisableTG+@" /></span>
                            </span>
                            <input  mkv='true' type='checkbox' id='cbTinhTienTrongNgay' " + strCheckNguyenNgay + @"/><span style='color:Red;font-weight:bold;'>Tính nguyên ngày</span>
            </span>
            <br/>
                            <span class='spanText'>| Bác sĩ :</span>
                                <input mkv='true' id='idbacsi' type='hidden'  value='" + idBacSi + @"'  />
                                <input mkv='true' id='mkv_idbacsi'  value='" + tenBacSi + @"'  type='text' onfocus='chuyenphim(this);idbacsisearch(this);' class='down_select_hover' style='width: 215px' />
                            <span class='spanText'>| Điều dưỡng :</span>
                                <input mkv='true' id='iddieuduong' type='hidden'  value='" + idDieuDuong + @"'  />
                                <input mkv='true' id='mkv_iddieuduong'  value='" + tenDieuDuong + @"'  type='text' onfocus='chuyenphim(this);iddieuduongsearch(this);' class='down_select_hover' style='width: 150px' />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </div>
            <span id='spDangLuuNhap' class='spanText'  style='width:100%;text-align:center'></span>
            <br/>
            <span class='spanText'  style='width:100%;' align:center>
                <input id='btnLuuNhapKhoa' class='button_1' type='button' style='width: 80px;' onclick='btnLuuNhapKhoa_Click(" + idkhoa + "," + idkhambenh + @",1)' value='Lưu' />
                <input id='btnDongNhapKhoa' class='button_1' type='button' style='width: 80px;' onclick='btnDongNhapKhoa_Click()' value='Đóng' />
                <input mkv='true' id='idCdNhapKhoa' type='hidden' value='" + idnoitru + @"' />
            </span>
                        </fieldset>
                    </div>
                </fieldset>
            </div>
        ");
        #endregion
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region Luu nhập Hậu Sản
    #endregion
    #region Lưu Chờ Sanh
    #endregion

    #region nvk_Function Call
    #region load phòng giường nhập khoa
    private string LoadPhongNhap(string idkhoa, string idPhongNhap)
    {
        string htmlSelect = @"<select  mkv='true' id='selPhongNhap' style='width:180px' onchange='nvk_LoadGiuongNhapTheoPhong(this," + idkhoa + ")'>";
        string sqlPhong = @"select p.*,MaTen=MaSo+'-'+TenPhong from kb_phong p left join banggiadichvu bg on bg.idbanggiadichvu=p.dichvukcb
left join phongkhambenh k on k.idphongkhambenh=bg.idphongkhambenh where isphongnoitru=1 and k.idphongkhambenh=" + idkhoa + " AND id<>61  order by TenPhong ";
        DataTable dtPhong = DataAcess.Connect.GetTable(sqlPhong);
        for(int i=0;i<dtPhong.Rows.Count;i++)
        {
            if (dtPhong.Rows[i]["id"].ToString().Equals(idPhongNhap))
                htmlSelect += "<option value='" + dtPhong.Rows[i]["id"] + "' selected>" + dtPhong.Rows[i]["MaTen"] + "</option>";
            else
                htmlSelect += "<option value='" + dtPhong.Rows[i]["id"] + "'>" + dtPhong.Rows[i]["MaTen"] + "</option>";
        }
        htmlSelect += @"</select >";
        return htmlSelect;
    }
    private string LoadGiuongNhap(string idkhoa,string idphong, string idGiuongNhap,ref string GiaGiuong,bool IsChonPhong)
    {
        string htmlSelect = @"<select  mkv='true' id='selGiuongNhap' style='width:150px'  onchange='nvk_LoadGiaTheoGiuong(this," + idkhoa + ")'>";
        if (idphong.Equals("0") || idphong.Equals(""))
            idphong = DataAcess.Connect.GetTable(@"select idphong= isnull(
                    (select top 1 id from kb_phong p left join banggiadichvu bg on bg.idbanggiadichvu=p.dichvukcb
                    left join phongkhambenh k on k.idphongkhambenh=bg.idphongkhambenh where isphongnoitru=1 and k.idphongkhambenh='"+idkhoa+@"'  order by TenPhong )
                    ,0)").Rows[0][0].ToString();
        string sqlGiuong = @"select giuongid,giuongcode from kb_giuong where isnull(nvk_isGiuongCho,0)=0 and idphong='" + idphong+"'";
        DataTable dtGiuong = DataAcess.Connect.GetTable(sqlGiuong);
        for (int i = 0; i < dtGiuong.Rows.Count; i++)
        {
            if (!IsChonPhong && dtGiuong.Rows[i]["giuongid"].ToString().Equals(idGiuongNhap))
            {
                htmlSelect += "<option value='" + dtGiuong.Rows[i]["giuongid"] + "' selected>" + dtGiuong.Rows[i]["giuongcode"] + "</option>";
                if (GiaGiuong.Equals("0"))
                    GiaGiuong = DataAcess.Connect.GetTable(@"select giagiuong=isnull(
                        (select top 1 giaDV from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid
                         where g.giuongid='" + dtGiuong.Rows[i]["giuongid"] + @"' order by banggiagiuongid desc)
                        ,0)").Rows[0][0].ToString();
            }
            else
                htmlSelect += "<option value='" + dtGiuong.Rows[i]["giuongid"] + "'>" + dtGiuong.Rows[i]["giuongcode"] + "</option>";
        }
        if (GiaGiuong.Equals("0") && dtGiuong.Rows.Count > 0)
            GiaGiuong = DataAcess.Connect.GetTable(@"select giagiuong=isnull(
                    (select top 1 giaDV from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid
                     where g.giuongid='" + dtGiuong.Rows[0]["giuongid"] + @"' order by banggiagiuongid desc)
                    ,0)").Rows[0][0].ToString();
        htmlSelect += @"</select >";
        return htmlSelect;
    }
    #endregion

    #region load giường chờ sanh
    private string LoadGiuongChoSanh(string idkhoa, string idGiuongNhap, ref string GiaGiuong, bool IsChonPhong, string strDisableTG)
    {
        string htmlSelect = @"<select  mkv='true' id='selGiuongNhap' "+strDisableTG+" style='width:150px'  onchange='nvk_LoadGiaTheoGiuong(this," + idkhoa + ")'>";
        string sqlGiuong = @"select giuongid,giuongcode from kb_giuong where isnull(nvk_isGiuongCho,0)=1 ";
        DataTable dtGiuong = DataAcess.Connect.GetTable(sqlGiuong);
        for (int i = 0; i < dtGiuong.Rows.Count; i++)
        {
            if (!IsChonPhong && dtGiuong.Rows[i]["giuongid"].ToString().Equals(idGiuongNhap))
            {
                htmlSelect += "<option value='" + dtGiuong.Rows[i]["giuongid"] + "' selected>" + dtGiuong.Rows[i]["giuongcode"] + "</option>";
                if (GiaGiuong.Equals("0"))
                    GiaGiuong = DataAcess.Connect.GetTable(@"select giagiuong=isnull(
                        (select top 1 giaDV from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid
                         where g.giuongid='" + dtGiuong.Rows[i]["giuongid"] + @"' order by banggiagiuongid desc)
                        ,0)").Rows[0][0].ToString();
            }
            else
                htmlSelect += "<option value='" + dtGiuong.Rows[i]["giuongid"] + "'>" + dtGiuong.Rows[i]["giuongcode"] + "</option>";
        }
        if (GiaGiuong.Equals("0") && dtGiuong.Rows.Count > 0)
            GiaGiuong = DataAcess.Connect.GetTable(@"select giagiuong=isnull(
                    (select top 1 giaDV from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid
                     where g.giuongid='" + dtGiuong.Rows[0]["giuongid"] + @"' order by banggiagiuongid desc)
                    ,0)").Rows[0][0].ToString();
        htmlSelect += @"</select >";
        return htmlSelect;
    }
    #endregion
    #region stTable chẩn đoán phối hợp
    private string strTableChanDoanPhoiHop(DataTable dt)
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        html.Append("<table class='jtable' id=\"gridTableCDPH\" style='width:300px'>");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaICD") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("MoTaICD") + "</th>");
        //html.Append("<th></th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        if (dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + (i+1) + "</td>");
                html.Append("<td><a onclick='xoaontableCDPH(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                html.Append("<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idicd"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='" + dt.Rows[i]["MaICD"] + "' class='down_select' style='width:80px'/></td>");
                html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='" + dt.Rows[i]["mota"] + "' class='down_select' style='width:320px'/></td>");
                //html.Append("<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>");
                html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[i]["idCdNhapKhoa"] + "'/></td>");
                html.Append("</tr>");
            }
        }
        html.Append("<tr>");
        html.Append("<td>" + (dt.Rows.Count + 1) + "</td>");
        html.Append("<td><a onclick='xoaontableCDPH(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
        html.Append("<td><input mkv='true' id='idicd' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idicd' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,1)' value='' class='down_select' style='width:80px'/></td>");
        html.Append("<td><input mkv='true' id='mkv_idicdMoTa' type='text' onfocusout='chuyenformout(this)' onfocus='ChanDoansearch(this,0)' value='' class='down_select' style='width:320px'/></td>");
        //html.Append("<td><input id='mkvDown' type='text'  value='' style='width:10px'  onkeydown=\"chuyendongPH(this);\" /></td>");
        html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
        html.Append("</tr>");


        //html.Append("<tr><td></td><td></td></tr>");
        html.Append("</table>");
        return html.ToString();
    }
    #endregion

    #region table danh sách nhập khoa

    private string nvk_htmlTableBenhNhan_Giuong(DataTable table,string idkhoa)
    {
        string html = "";
        string ParaIdKhoaSan = StaticData.GetParameter("nvk_idkhoasan");
        if (string.IsNullOrEmpty(ParaIdKhoaSan))
            ParaIdKhoaSan="3";
        #region header table nhập khoa
        html += "<table class='jtable' id=\"gridTabledsNhapKhoa\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th style='width:60px'></th>";

        html += "<th style='width:110px'>Mã bệnh nhân</th>";
        html += "<th style='width:150px'>Tên bệnh nhân</th>";
        html += "<th>Địa chỉ</th>";
        html += "<th>Điện thoại</th>";
        html += "<th>Giới tính</th>";
        html += "<th>Ngày sinh</th>";
        html += "<th>Ngày cho nhập</th>";
        html += "<th>Nhập từ</th>";
        html += "<th>Giường</th>";
        html += "</tr>";
        #endregion
        #region nội dung bênh nhân chờ nhập khoa
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1) + "</td>";
            html += @"<td>";

            //html += "<input type='button' value='Tiền Giường' style='width:85px;height:25px;background: #E15625;color:white;font-weight: bold;position:relative'  onclick=\"DongTienGiuong_Click('" + table.Rows[i]["idchitietdangkykham"].ToString() + "','" + table.Rows[i]["idbenhnhan"] + "','" + table.Rows[i]["ngayxetnhap"] + "','" + table.Rows[i]["giuongnam"] + "');\"/>";
            html += "<input type='button' value='Tiền Giường' style='width:85px;height:25px;background: #E15625;color:white;font-weight: bold;position:relative'  onclick=\"DongTienGiuong_Click('" + table.Rows[i]["idchitietdangkykham"].ToString() + "');\"/>";

            html += @"</td>";
            html += "<td>" + table.Rows[i]["mabenhnhan"] + "</td>";
            html += "<td>" + table.Rows[i]["tenbenhnhan"] + "</td>";
            html += "<td>" + table.Rows[i]["diachi"] + "</td>";
            html += "<td>" + table.Rows[i]["dienthoai"] + "</td>";
            html += "<td>" + table.Rows[i]["gioi"] + "</td>";
            html += "<td>" + table.Rows[i]["namsinh"] + "</td>";
            html += "<td>" + table.Rows[i]["ngayxetnhap"] + "</td>";
            html += "<td>" + table.Rows[i]["chuyentu"] + "</td>";
            html += "<td>" + table.Rows[i]["giuongnam"] + "</td>";
            html += "</tr>";
        }
        #endregion
        #region đóng table
        html += "</table>";
        #endregion
        return html;
    }
    #endregion
    #endregion

}
 
 
