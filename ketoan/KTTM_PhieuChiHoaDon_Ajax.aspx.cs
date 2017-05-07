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

public partial class ketoan_KTTM_PhieuChiHoaDon_Ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = data.escape(Request.QueryString["do"]);
        switch (action)
        {
            case "LoadDanhSachHoaDonPhieuChi": LoadDanhSachHoaDonPhieuChi(); break;
            case "LoadDanhSachHoaDonPhieuUyNhiemChi": LoadDanhSachHoaDonPhieuUyNhiemChi(); break;
            case "LoadDanhSachNhaCungCap": LoadDanhSachNhaCungCap(); break;
            case "LuuPhieuThu": LuuPhieuThu(); break;
            case "LuuChiTietPhieuThuHoaDon": LuuChiTietPhieuThuHoaDon(); break;
            case "XoaPhieuThu": XoaPhieuThu(); break;
            case "XoaChiTietPhieuThu": XoaChiTietPhieuThu(); break;
            case "XoaSoCaiBySoPT": XoaSoCaiBySoPT(); break;
            case "LuuSoCai_PhieuThuHoaDon": LuuSoCai_PhieuThuHoaDon(); break;
            case "ChiTietPhieuThuHoaDon": ChiTietPhieuThuHoaDon(); break;
            case "DanhSachPhieuThuOfKhachHang": DanhSachPhieuThuOfKhachHang(); break;
        }

    }
    public void LoadDanhSachHoaDonPhieuChi()
    {
        string MaKhachHang = Request.QueryString["MaNCC"];
        string sql = @"select * from( 
            select IdNhapVT=0,pn.IdPhieuNhap,So_HD=pn.sohoadon,Ngay_Lap_HD=convert(varchar,pn.ngayhoadon,103),TK_Co=pn.tkco
            ,nguyente=sum(isnull(ctpn.thanhtien,0)),Tong_Tien=sum(isnull(ctpn.thanhtien,0)),diengiai=pn.ghichu
            ,thanhtientruocthue=sum(isnull(thanhtientruocthue,0)),pn.tkvat,tienthue=sum(isnull(ctpn.tienthue,0)),pn.soseri
            ,pn.vat
            from phieunhapkho pn
            inner join chitietphieunhapkho ctpn on pn.idphieunhap=ctpn.idphieunhap
            inner join nhacungcap ncc on ncc.nhacungcapid=pn.nhacungcapid
            where idloainhap=1 and ncc.manhacungcap='" + MaKhachHang + @"' and  not exists(select phieu_chi_ct_id from phieu_chi_ct
	              where idphieunhapkho=pn.idphieunhap)
                and  not exists(select idphieunhapkho from Uy_Nhiem_Chi_CT
	              where idphieunhapkho=pn.idphieunhap)
            group by pn.sohoadon,convert(varchar,pn.ngayhoadon,103),pn.tkco,pn.ghichu,pn.IdPhieuNhap,pn.tkvat,pn.soseri,pn.vat
            union all
            select IdNhapVT=vt.Phieu_Nhap_Id,IdPhieuNhap=0,So_HD=vt.so_hd,Ngay_Lap_HD=convert(varchar,vt.Ngay_Lap_HD,103),vt.TK_Co
            ,nguyente=sum(isnull(vtct.tong_tien,0)),Tong_Tien=sum(isnull(vtct.tong_tien,0)),diengiai=vt.dien_giai
            ,thanhtientruocthue=sum(isnull(thanh_tien-tienchietkhau,0)),vt.tkvat,tienthue=sum(isnull(vtct.tien_thue,0))
            ,soseri=vt.so_seri,vt.vat
            from phieu_nhap_vt vt
            inner join phieu_nhap_vt_ct vtct on vt.phieu_nhap_id=vtct.phieu_nhap_id
            where vt.ma_ncc='" + MaKhachHang + @"' and not exists(select phieu_chi_ct_id from phieu_chi_ct
	            where phieu_nhap_vt_id=vt.phieu_nhap_id)
             and  not exists(select idphieunhapkho from Uy_Nhiem_Chi_CT
              where phieu_nhap_vt_id=vt.phieu_nhap_id)
            group by vt.so_hd,convert(varchar,vt.Ngay_Lap_HD,103),vt.TK_Co,vt.dien_giai,vt.Phieu_Nhap_Id,vt.tkvat,vt.so_seri,vt.vat
            )temp order by Ngay_Lap_HD desc";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string result = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            result += "|" + dt.Rows[i]["So_HD"] + "&" + dt.Rows[i]["TK_Co"] + "&" + dt.Rows[i]["Ngay_Lap_HD"] + "&" + dt.Rows[i]["Tong_Tien"] + "&" + dt.Rows[i]["nguyente"] + "&" + dt.Rows[i]["diengiai"] + "&" + dt.Rows[i]["IdNhapVT"] + "&" + dt.Rows[i]["IdPhieuNhap"] + "&" + dt.Rows[i]["thanhtientruocthue"] + "&" + dt.Rows[i]["tkvat"] + "&" + dt.Rows[i]["tienthue"] + "&" + dt.Rows[i]["soseri"] + "&" + dt.Rows[i]["vat"];
        }
        Response.Write(result);
    }
    public void LoadDanhSachHoaDonPhieuUyNhiemChi()
    {
        string MaKhachHang = Request.QueryString["MaNCC"];
        string NgayLap = Request.QueryString["NgayLap"];
        string sqldk = " where 1=1";
        if (!string.IsNullOrEmpty(MaKhachHang) && !string.IsNullOrEmpty(NgayLap))
            sqldk += " and manhacungcap='" + MaKhachHang + "' and convert(varchar(10),Ngay_Lap_HD,111)='" + StaticData.CheckDate_kt(NgayLap) + "'";
        else
            if (!string.IsNullOrEmpty(MaKhachHang) && string.IsNullOrEmpty(NgayLap))
            sqldk += " and manhacungcap='" + MaKhachHang + "'";
        else
            if (!string.IsNullOrEmpty(NgayLap) && string.IsNullOrEmpty(MaKhachHang))
                sqldk += " and convert(varchar(10),Ngay_Lap_HD,111)='" + StaticData.CheckDate_kt(NgayLap) + "'";            
                
        string sql = @"select * from( 
            select IdNhapVT=0,pn.IdPhieuNhap,ncc.manhacungcap,ncc.tennhacungcap,So_HD=pn.sohoadon,Ngay_Lap_HD=convert(varchar,pn.ngayhoadon,111),TK_Co=pn.tkco
            ,nguyente=sum(isnull(ctpn.thanhtien,0)),Tong_Tien=sum(isnull(ctpn.thanhtien,0)),diengiai=pn.ghichu
            ,thanhtientruocthue=sum(isnull(thanhtientruocthue,0)),pn.tkvat,tienthue=sum(isnull(ctpn.tienthue,0)),pn.soseri
            ,pn.vat
            from phieunhapkho pn
            inner join chitietphieunhapkho ctpn on pn.idphieunhap=ctpn.idphieunhap
            inner join nhacungcap ncc on ncc.nhacungcapid=pn.nhacungcapid
            where  idloainhap=1 and  not exists(select phieu_chi_ct_id from phieu_chi_ct
	              where idphieunhapkho=pn.idphieunhap)
                and  not exists(select idphieunhapkho from Uy_Nhiem_Chi_CT
	              where idphieunhapkho=pn.idphieunhap)
            group by pn.sohoadon,convert(varchar,pn.ngayhoadon,111),pn.tkco,pn.ghichu,pn.IdPhieuNhap,pn.tkvat,pn.soseri,pn.vat,ncc.manhacungcap,ncc.tennhacungcap
            union all
            select IdNhapVT=vt.Phieu_Nhap_Id,IdPhieuNhap=0,ncc.manhacungcap,ncc.tennhacungcap,So_HD=vt.so_hd,Ngay_Lap_HD=convert(varchar,vt.Ngay_Lap_HD,111),vt.TK_Co
            ,nguyente=sum(isnull(vtct.tong_tien,0)),Tong_Tien=sum(isnull(vtct.tong_tien,0)),diengiai=vt.dien_giai
            ,thanhtientruocthue=sum(isnull(thanh_tien-tienchietkhau,0)),vt.tkvat,tienthue=sum(isnull(vtct.tien_thue,0))
            ,soseri=vt.so_seri,vt.vat
            from phieu_nhap_vt vt
            inner join phieu_nhap_vt_ct vtct on vt.phieu_nhap_id=vtct.phieu_nhap_id
			left join nhacungcap ncc on vt.ma_ncc=ncc.manhacungcap
            where  not exists(select phieu_chi_ct_id from phieu_chi_ct
	            where phieu_nhap_vt_id=vt.phieu_nhap_id)
             and  not exists(select idphieunhapkho from Uy_Nhiem_Chi_CT
              where phieu_nhap_vt_id=vt.phieu_nhap_id)
            group by vt.so_hd,convert(varchar,vt.Ngay_Lap_HD,111),vt.TK_Co,vt.dien_giai,vt.Phieu_Nhap_Id,vt.tkvat,vt.so_seri,vt.vat,ncc.manhacungcap,ncc.tennhacungcap
            )temp "+sqldk+@"  order by Ngay_Lap_HD desc";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        string result = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            result += "|" + dt.Rows[i]["manhacungcap"] + "&" + dt.Rows[i]["tennhacungcap"] + "&" + dt.Rows[i]["TK_Co"] + "&" + dt.Rows[i]["So_HD"] + "&" + dt.Rows[i]["soseri"] + "&" + dt.Rows[i]["Ngay_Lap_HD"] + "&" + dt.Rows[i]["diengiai"] + "&" + dt.Rows[i]["thanhtientruocthue"] + "&" + dt.Rows[i]["vat"] + "&" + dt.Rows[i]["tkvat"] + "&" + dt.Rows[i]["tienthue"] + "&" + dt.Rows[i]["Tong_Tien"] + "&" + dt.Rows[i]["IdNhapVT"] + "&" + dt.Rows[i]["IdPhieuNhap"];
        }
        Response.Write(result);
    }
    public void LoadDanhSachNhaCungCap()
    {
        string Key = Request.QueryString["q"];
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";

        html += Environment.NewLine;
        try
        {
            sql = "select NhaCungCapId,MaNhaCungCap,TenNhaCungCap from NhaCungCap ";
            if (type == "txtMaNCC" && !string.IsNullOrEmpty(Key))
                sql += " where MaNhaCungCap  LIKE '" + Key + "%'";
            else
                if (type == "txtTenNCC" && !string.IsNullOrEmpty(Key))
                {
                    sql += "  Where TenNhaCungCap  LIKE '%" + Key + "%'";
                }
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                html += "<div style=\"width: 300px; border-color: Black; border-width: 2px\">";
                html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
                html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Mã nhà cung cấp</div>";
                html += "<div style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên nhà cung cấp</div>";
                html += "</div>";
                html += "</div>|||";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "<div onmouseout=\"this.bgColor='#285de3'\" onmouseover=\"this.bgColor='#66CCCC'\" style=\"cursor: pointer\" onclick=\"setChonNCC('" + dt.Rows[i]["NhaCungCapId"] + "','" + dt.Rows[i]["MaNhaCungCap"] + "','" + dt.Rows[i]["TenNhaCungCap"] + "')\">";
                    html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["MaNhaCungCap"] + "</p>";
                    html += "<p style=\"width: 150px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenNhaCungCap"] + "</p>";
                    html += "</div>|" + dt.Rows[i]["NhaCungCapId"] + "|" + dt.Rows[i]["MaNhaCungCap"] + "|" + dt.Rows[i]["TenNhaCungCap"];
                    html += Environment.NewLine;
                }
            }
            else
                html = "";

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    public void LuuPhieuThu()
    {
        DataTable tbptid = DataAcess.Connect.GetTable("select phieu_chi_id from phieu_chi where so_phieu_chi='" + Request.QueryString["SoPT"] + "'");
        string PhieuThuID = "";
        if (tbptid.Rows.Count > 0)
            PhieuThuID = tbptid.Rows[0][0].ToString();
        else
            PhieuThuID = "null";
        ////////////////////////////
        string SoPT = "";
        if (Request.QueryString["do"].ToString() != "TimKiem")
        {
            if (PhieuThuID == "null")
            {
                SoPT = Xulychuoi("PCA", "phieu_chi", "so_phieu_chi");
            }
            else
            {
                SoPT = Request.QueryString["SoPT"];
            }
        }
        else SoPT = Request.QueryString["SoPT"];

        string Ma_kt = "";
        if (Request.QueryString["do"].ToString() != "TimKiem")
        {
            if (PhieuThuID == "null")
            {
                Ma_kt = Xulychuoi("PCB", "phieu_chi", "ma_kt");
            }
            else
            {
            }
        }
        string NgayThu = Request.QueryString["NgayThu"];
        string MaKH = Request.QueryString["MaKH"];
        string NguoiNop = Request.QueryString["NguoiNop"];
        string DienGiai = Request.QueryString["DienGiai"];
        string TKNo = Request.QueryString["TKNo"];
        string Tien = Request.QueryString["Tien"];
        string ngoai_te_id = Request.QueryString["ngoai_te_id"];
        string ty_gia = Request.QueryString["ty_gia"];
        string UserDau = SysParameter.UserLogin.UserName(this);
        string UserCuoi = SysParameter.UserLogin.UserName(this);
        string Status = Request.QueryString["Status"];

        string sql = "exec spPhieu_Chi_Save " + PhieuThuID + ", '" + SoPT + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayThu) + "','" + MaKH + "',N'" + NguoiNop + "',N'" + DienGiai + "','" + TKNo + "'," + ngoai_te_id + "," + ty_gia + "," + Tien.Replace(".","") + ",null,N'" + UserDau + "',N'" + UserCuoi + "','1','" + Ma_kt + "'";
        bool rs = DataAcess.Connect.ExecSQL(sql);
        if (rs)
            Response.Write(1);
        else
            Response.Write(0);
    }
    private string Xulychuoi(string LoaiPhieu, string Bangluu, string Maphieu)
    {
        string Xuatkq, chuoi, Tiepdaungu, Isnum;

        //Lay ma chung tu
        string sqllayma = "select Ma_ct_in, Isnum from DSManHinh where Ma_ct = '" + LoaiPhieu + "'";
        DataTable dtma = DataAcess.Connect.GetTable(sqllayma);
        Tiepdaungu = dtma.Rows[0]["Ma_ct_in"].ToString();
        Isnum = dtma.Rows[0]["Isnum"].ToString();
        //Kiem tra bang luu
        string sql = "select top 1 " + Maphieu + " from " + Bangluu + " where " + Maphieu + " Like '" + Tiepdaungu
            + "%' and isnumeric( substring(" + Maphieu + ", " + Isnum + ",2))=1 order by " + Maphieu + " DESC";
        DataTable dt = DataAcess.Connect.GetTable(sql);

        if (dt.Rows.Count == 0)
        {
            Xuatkq = Tiepdaungu + "0001";
        }
        else
        {
            chuoi = dt.Rows[0][Maphieu].ToString();
            String Str = chuoi;
            string strLetter = "";
            string strDigit = "";
            int length = Str.Length;
            if ("" != Str)
            {
                for (int i = 0; i < length; i++)
                {
                    if (!Char.IsDigit(Str[i]))
                        strLetter += Str[i];
                    else
                        strDigit += Str[i];
                }
            }

            chuoi = strDigit.Replace(Tiepdaungu, "");
            Int64 so = Convert.ToInt64(chuoi) + 1;
            if (so < 10)
            {
                Xuatkq = Tiepdaungu + "000" + so;
            }
            else if (so < 100)
            {
                Xuatkq = Tiepdaungu + "00" + so;
            }
            else if (so < 1000)
            {
                Xuatkq = Tiepdaungu + "0" + so;
            }
            else
            {
                Xuatkq = Tiepdaungu + so;
            }
        }
        //string thang = DateTime.Now.Month.ToString();
        //string nam = DateTime.Now.Year.ToString().Substring(2, 2);
        return Xuatkq;
    }
    public void LuuChiTietPhieuThuHoaDon()
    {
        try
        {

            DataTable tbsopt = DataAcess.Connect.GetTable("select top 1 so_phieu_chi from phieu_chi order by phieu_chi_id desc");
            string SoPT = "";
            if (Request.QueryString["SoPT"] == "" || Request.QueryString["SoPT"] == null)
            {
                if (tbsopt.Rows.Count > 0)
                    SoPT = tbsopt.Rows[0][0].ToString();
            }
            else
                SoPT = Request.QueryString["SoPT"].ToString();
            ////////////////////////////
            string IDPhieuThuCT_list = Request.QueryString["IDPhieuThuCT"];
            string[] IDPhieuThuCT = IDPhieuThuCT_list.Split(';');

            string TKCo_list = Request.QueryString["TKCo"];
            string[] TKCo = TKCo_list.Split(';');

            string SoHD_list = Request.QueryString["SoHD"];
            string[] SoHD = SoHD_list.Split(';');

            string NgayLapHD_list = Request.QueryString["NgayLapHD"];
            string[] NgayLapHD = NgayLapHD_list.Split(';');

            string TienTrenHD_list = Request.QueryString["TienTrenHD"];
            string[] TienTrenHD = TienTrenHD_list.Split(';');

            string valueDienGiai_list = Request.QueryString["valueDienGiai"];
            string[] valueDienGiai = valueDienGiai_list.Split(';');

            string valueIdNhapVT_list = Request.QueryString["valueIdNhapVT"];
            string[] valueIdNhapVT = valueIdNhapVT_list.Split(';');

            string valueIdPhieuNhap_list = Request.QueryString["valueIdPhieuNhap"];
            string[] valueIdPhieuNhap = valueIdPhieuNhap_list.Split(';');
            bool rs = false;
            for (int i = 0; i < SoHD.Length; i++)
            {
                if (SoHD[i] != "")
                {
                    string sql1 = "exec spPhieu_Chi_Ct_Save  " + Int64.Parse(IDPhieuThuCT[i]) + ",'" + SoPT + "','" + TKCo[i] + "',null,null,null,null,null,null,'" + SoHD[i] + "',null,'" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "'," + TienTrenHD[i] + ",null,null,null,N'"+valueDienGiai[i]+"',0,'"+valueIdPhieuNhap[i]+"','"+valueIdNhapVT[i]+"'";
                    rs = DataAcess.Connect.ExecSQL(sql1);
                }
            }

            if (rs)
            {
                Response.Write(1);
            }
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }
    }
    public void XoaPhieuThu()
    {
        try
        {
            string SoPhieuThu = Request.QueryString["SoPhieuThu"];
            string sql = "exec spPhieu_Thu_Delete  '" + SoPhieuThu + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql);
            if (rs)
                Response.Write(1);
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }
    }
    public void XoaChiTietPhieuThu()
    {
        try
        {
            string SoPT = Request.QueryString["SoPT"];
            string sql1 = "select so_hd from Phieu_thu_ct where so_phieu_thu='" + SoPT + "'";
            DataTable table = DataAcess.Connect.GetTable(sql1);
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string SoHD = table.Rows[i][0].ToString();
                    string sqlUpdate = "update Hoa_Don_DV set status = 0 where so_hd = '" + SoHD + "'";
                    DataAcess.Connect.ExecSQL(sqlUpdate);
                }
            }
            string sql2 = "exec spPhieu_Thu_Ct_Delete '" + SoPT + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql2);
            if (rs)
            {
                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }

    }
    public void XoaSoCaiBySoPT()
    {
        try
        {
            string SoPT = Request.QueryString["SoPT"];
            string sql1 = "exec spSo_Cai_Delete '" + SoPT + "'";
            bool rs = DataAcess.Connect.ExecSQL(sql1);
            if (rs)
            {
                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch
        {
            Response.Write(0);
        }

    }
    public void LuuSoCai_PhieuThuHoaDon()
    {
        try
        {
            DataTable tbsopt = DataAcess.Connect.GetTable("select top 1 so_phieu_chi from phieu_chi order by phieu_chi_id desc");
            string SoPT = "";
            if (Request.QueryString["SoPT"] == "" || Request.QueryString["SoPT"] == null)
            {
                if (tbsopt.Rows.Count > 0)
                    SoPT = tbsopt.Rows[0][0].ToString();
            }
            else
                SoPT = Request.QueryString["SoPT"].ToString();
            /////////////////
            string NgayThu = Request.QueryString["NgayThu"];
            string TKNo = Request.QueryString["TKNo"];
            string TKCo_list = Request.QueryString["TKCo"];
            string MaKH = Request.QueryString["MaKH"];
            string DienGiai = Request.QueryString["DienGiai"];
            string TienTrenHD_list = Request.QueryString["TienTrenHD"];
            string SoHD_list = Request.QueryString["SoHD"];
            string NgayLapHD_list = Request.QueryString["NgayLapHD"];

            string[] TKCo = TKCo_list.Split(';');
            string[] TienTrenHD = TienTrenHD_list.Split(';');
            string[] SoHD = SoHD_list.Split(';');
            string[] NgayLapHD = NgayLapHD_list.Split(';');
            bool rs = false;
            for (int i = 0; i < SoHD.Length; i++)
            {
                if (SoHD[i] != "")
                {
                    string sql1 = "spPhieu_Chi_HD_So_Cai_Save null,'" + SoPT + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayThu) + "','" + TKNo + "','" + TKCo[i] + "','" + MaKH + "','" + DienGiai + "'," + TienTrenHD[i] + ",'" + SoHD[i] + "','" + mdlCommonFunction.ChangeDateTo_MM_dd(NgayLapHD[i]) + "'";
                    rs = DataAcess.Connect.ExecSQL(sql1);
                }
            }
            if (rs)
            {
                Response.Write(1);

            }
            else
                Response.Write(0);
        }
        catch (Exception e)
        {
            Response.Write(0);
        }

    }
    public void ChiTietPhieuThuHoaDon()
    {
        DataTable tbsopt = DataAcess.Connect.GetTable("select top 1 so_phieu_chi from phieu_chi order by phieu_chi_id desc");
        //string SoPT = Request["SoPT"];

        string SoPT = "";

        if (Request.QueryString["SoPT"] == "" || Request.QueryString["SoPT"] == null)
        {
            if (tbsopt.Rows.Count > 0)
                SoPT = tbsopt.Rows[0][0].ToString();
        }
        else
            SoPT = Request.QueryString["SoPT"].ToString();
        //string sql = "select So_HD,convert(varchar,Ngay_Lap_HD,103)Ngay_Lap_HD,TK_Co,nguyente=tong_tien/ty_gia,Tong_Tien from Hoa_Don_DV where status = 0 and  ma_kh='" + MaKhachHang + "' order by Ngay_Lap_HD desc";
        string sql = @"select phieu_chi_ct_id,tk_co,ct.tk_no,so_hd,convert(varchar,ngay_lap_hd,103)ngay_lap_hd
                ,nguyente=tien_tren_hd/ty_gia,tongtien = tien_tren_hd,p.ma_kt
                ,p.phieu_chi_id ,ty_gia = case when (isnull(p.ty_gia,-1)=-1 or p.ty_gia=0) 
                then (select top 1 ty_gia from dmngoaite) else p.ty_gia end 
                ,ngoaiteid = case when (isnull(p.ty_gia,-1)=-1 or p.ty_gia=0) 
                then (select top 1 ngoai_te_id from dmngoaite) else p.loai_nt end 
                ,ten_nt = case when (isnull(p.ty_gia,-1)=-1 or p.ty_gia=0) 
                then (select top 1 ten_nt from dmngoaite) 
                else(select ten_nt from dmngoaite where ngoai_te_id = p.loai_nt) end,
                 p.ma_kt,
                ct.dien_giai,ct.idphieunhapkho,ct.phieu_nhap_vt_id 
                from phieu_chi_ct ct 
                left join phieu_chi p on ct.so_phieu_chi=p.so_phieu_chi where ct.so_phieu_chi = '" + SoPT+@"' 
                group by phieu_chi_ct_id,tk_co,so_hd,ngay_lap_hd
                ,tien_tren_hd,p.ty_gia,p.ma_kt,p.phieu_chi_id,p.loai_nt,ct.dien_giai,ct.idphieunhapkho,ct.phieu_nhap_vt_id,ct.tk_no";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_ct_id"] + "&" + row["tk_no"] + "&" + row["so_hd"] + "&" + row["ngay_lap_hd"] + "&" + row["nguyente"].ToString() + "&" + row["tongtien"].ToString() + "&" + SoPT + "&" + row["ma_kt"] + "&" + row["phieu_chi_id"] + "&" + row["ngoaiteid"] + "&" + row["ten_nt"] + "&" + row["ty_gia"] + "&" + row["dien_giai"] + "&" + row["phieu_nhap_vt_id"] + "&" + row["idphieunhapkho"];
            }
            Response.Write(rs);
        }
    }
    public void DanhSachPhieuThuOfKhachHang()
    {
        string idPhieuThu = Request["idPhieuThu"];
        string sql = @"select  phieu_chi_id,so_phieu_chi,convert(varchar,ngay_chi,103)ngay_thu,ma_kh=pt.ma_ncc,
            tenkhachhang=ncc.tennhacungcap,nguoi_nop=pt.nguoi_giao,dien_giai,tk_no=pt.tk_co,tien  
            from Phieu_chi pt 
            left join nhacungcap ncc on  pt.ma_ncc = ncc.manhacungcap  
            where phieu_chi_id ='"+idPhieuThu+"'";
        DataTable table = DataAcess.Connect.GetTable(sql);
        string rs = "";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {//phieu_thu_id,so_phieu_thu,ngay_thu,ma_kh,dien_giai,tk_no,tien
                DataRow row = table.Rows[i];
                rs += "|" + row["phieu_chi_id"] + "&" + row["so_phieu_chi"] + "&" + row["ngay_thu"] + "&" + row["ma_kh"] + "&" + row["tenkhachhang"] + "&" + row["nguoi_nop"] + "&" + row["dien_giai"] + "&" + row["tk_no"] + "&" + row["tien"];
            }
            Response.Write(rs);
        }
    }
}
