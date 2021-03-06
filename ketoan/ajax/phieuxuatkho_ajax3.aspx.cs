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

public partial class phieuxuatkho_ajax : System.Web.UI.Page
{
    private string CreateMaPX()
    {
        string Key = "PX-000";
        string type = Request.QueryString["obj"];
        string sql = "";
        string html = "";

        html += Environment.NewLine;
        string kq, chuoi;
        sql = "select top 1 maphieuxuat from phieuxuatKho where maphieuxuat Like '%" + Key + "%' order by maphieuxuat DESC";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count == 0)
        {
            kq = Key + "0001";
        }
        else
        {
            chuoi = dt.Rows[0]["maphieuxuat"].ToString();
            chuoi = chuoi.Replace(Key, "");
            string[] s = chuoi.Split('/');
            int so = 0;
            try
            {
                so = Convert.ToInt32(s[0] + s[1]) + 1;
            }
            catch
            {
                so = Convert.ToInt32(s[0]) + 1;
            }

            if (so < 10)
            {
                kq = Key + "000" + so;
            }
            else if (so < 100)
            {
                kq = Key + "00" + so;
            }
            else if (so < 1000)
            {
                kq = Key + "0" + so;
            }
            else
            {
                kq = Key + so;
            }
        }
        return kq;
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
            + "%' and isnumeric( substring(" + Maphieu + ", " + Isnum + ", 2))=1 order by " + Maphieu + " DESC";
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
        //string thang = "";
        //thang = DateTime.Now.Month.ToString();
        //if (thang.Length == 1)
        //    thang = "0" + thang;
        //string nam = DateTime.Now.Year.ToString().Substring(2, 2);
        return Xuatkq;
    }
    
    protected DataProcess s_phieuxuatkho()
    {
        DataProcess phieuxuatkho = new DataProcess("phieuxuatkho");
        phieuxuatkho.data("idphieuxuat", Request.QueryString["idkhoachinh"]);
        if (Request.QueryString["do"].ToString() != "TimKiem")
        {
            if (Request.QueryString["idkhoachinh"] == "")
                phieuxuatkho.data("maphieuxuat", Xulychuoi("PXA", "phieuxuatkho", "maphieuxuat"));
            else
                phieuxuatkho.data("maphieuxuat", Request.QueryString["maphieuxuat"]);
        }
        else
            phieuxuatkho.data("maphieuxuat", Request.QueryString["maphieuxuat"]);
        //////////////////////////
        if (Request.QueryString["do"].ToString() != "TimKiem")
        {
            if (Request.QueryString["ma_kt"] == "")
                phieuxuatkho.data("ma_kt", Xulychuoi("PXB", "phieuxuatkho", "ma_kt"));
            else
                phieuxuatkho.data("ma_kt", Request.QueryString["ma_kt"]);
        }
        else phieuxuatkho.data("ma_kt", Request.QueryString["ma_kt"]);
        //////////////////////////
        if (Request.QueryString["do"].ToString() == "TimKiem")
            phieuxuatkho.data("ngaythang", StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngaythang"].ToString()));
        else
            phieuxuatkho.data("ngaythang", Request.QueryString["ngaythang"].ToString());

        phieuxuatkho.data("loai_ctid", Request.QueryString["loai_ctid"]);
        if (Request.QueryString["IDKhachHang"] == "" || Request.QueryString["IDKhachHang"] == null)
            phieuxuatkho.data("IDKhachHang", "0");
        else
            phieuxuatkho.data("IDKhachHang", Request.QueryString["IDKhachHang"]);
        //phieuxuatkho.data("IDKhachHang",Request.QueryString["IDKhachHang"]);
        phieuxuatkho.data("TKCo", Request.QueryString["TKCo"]);
        phieuxuatkho.data("ghichu", Request.QueryString["ghichu"]);
        if (Request.QueryString["do"] != "TimKiem")
        {
            if (Request.QueryString["ngoai_te_id"] == "" || Request.QueryString["ngoai_te_id"] == null)
                phieuxuatkho.data("ngoai_te_id", "0");
            else
                phieuxuatkho.data("ngoai_te_id", Request.QueryString["ngoai_te_id"]);
        }
        else
            phieuxuatkho.data("ngoai_te_id", "");
        //phieuxuatkho.data("ngoai_te_id",Request.QueryString["ngoai_te_id"].ToString());
        if (Request.QueryString["txtthanhtien"] == "" || Request.QueryString["txtthanhtien"] == null)
            phieuxuatkho.data("thanhtien", "0");
        else
            phieuxuatkho.data("thanhtien", Request.QueryString["txtthanhtien"]);
        //phieuxuatkho.data("thanhtien",Request.QueryString["thanhtien"]);
        if (Request.QueryString["idphongkhambenh"] == "" || Request.QueryString["idphongkhambenh"] == null)
            phieuxuatkho.data("idphongkhambenh", "0");
        else
            phieuxuatkho.data("idphongkhambenh", Request.QueryString["idphongkhambenh"]);

        phieuxuatkho.data("nguoinhan", Request.QueryString["nguoinhan"]);

        if (Request.QueryString["xuatcho"] == "" || Request.QueryString["xuatcho"] == null)
            phieuxuatkho.data("xuatcho", "0");
        else
            phieuxuatkho.data("xuatcho", Request.QueryString["xuatcho"]);

        if (Request.QueryString["idkho"] == "" || Request.QueryString["idkho"] == null)
            phieuxuatkho.data("idkho", "0");
        else
            phieuxuatkho.data("idkho", Request.QueryString["idkho"]);

        if (Request.QueryString["loaixuat"] == "" || Request.QueryString["loaixuat"] == null)
            phieuxuatkho.data("loaixuat", "0");
        else
            phieuxuatkho.data("loaixuat", Request.QueryString["loaixuat"]);

        phieuxuatkho.data("vat", Request.QueryString["vat"]);
        phieuxuatkho.data("ngayhoadon", Request.QueryString["ngayhoadon"]);
        phieuxuatkho.data("idnhacungcap", Request.QueryString["idnhacungcap"]);
        phieuxuatkho.data("idkho2", Request.QueryString["idkho2"]);
        if (Request.QueryString["idnguoixuat"] == "" || Request.QueryString["idnguoixuat"] == null)
            phieuxuatkho.data("idnguoixuat", "0");
        else
            phieuxuatkho.data("idnguoixuat", Request.QueryString["idnguoixuat"]);
        //phieuxuatkho.data("idnguoixuat",Request.QueryString["idnguoixuat"].ToString());
        if (Request.QueryString["IdBenhNhanToaThuoc"] == "" || Request.QueryString["IdBenhNhanToaThuoc"] == null)
            phieuxuatkho.data("IdBenhNhanToaThuoc", "0");
        else
            phieuxuatkho.data("IdBenhNhanToaThuoc", Request.QueryString["IdBenhNhanToaThuoc"]);
        //phieuxuatkho.data("IdBenhNhanToaThuoc",Request.QueryString["IdBenhNhanToaThuoc"]);
        phieuxuatkho.data("IsBHYT", Request.QueryString["IsBHYT"]);
        phieuxuatkho.data("SLPX", Request.QueryString["SLPX"]);
        phieuxuatkho.data("TKNo", Request.QueryString["TKNo"]);
        phieuxuatkho.data("TKNoKhac", Request.QueryString["TKNoKhac"]);
        phieuxuatkho.data("TKVAT", Request.QueryString["TKVAT"]);
        if (Request.QueryString["tigia"] == "" || Request.QueryString["tigia"] == null)
            phieuxuatkho.data("ty_gia", "0");
        else
            phieuxuatkho.data("ty_gia", Request.QueryString["tigia"]);
        return phieuxuatkho;
    }

    protected DataProcess s_chitietphieuxuatkho()
    {
        DataProcess chitietphieuxuatkho = new DataProcess("chitietphieuxuatkho");
        chitietphieuxuatkho.data("idchitietphieuxuat", Request.QueryString["idkhoachinh"]);
        if (Request.QueryString["idphieuxuat"] == "" || Request.QueryString["idphieuxuat"] == null)
            chitietphieuxuatkho.data("idphieuxuat", "0");
        else
            chitietphieuxuatkho.data("idphieuxuat", Request.QueryString["idphieuxuat"]);
        //chitietphieuxuatkho.data("idphieuxuat",Request.QueryString["idphieuxuat"]);
        if (Request.QueryString["idthuoc"] == "" || Request.QueryString["idthuoc"] == null)
            chitietphieuxuatkho.data("idthuoc", "0");
        else
            chitietphieuxuatkho.data("idthuoc", Request.QueryString["idthuoc"]);
        //chitietphieuxuatkho.data("idthuoc",Request.QueryString["idthuoc"]);
        if (Request.QueryString["tkco"] == null)
            chitietphieuxuatkho.data("tkco", "");
        else
            chitietphieuxuatkho.data("tkco", Request.QueryString["tkco"].ToString());
        chitietphieuxuatkho.data("losanxuat", Request.QueryString["losanxuat"]);
        chitietphieuxuatkho.data("ngayhethan", Request.QueryString["ngayhethan"]);
        if (Request.QueryString["idkho"] == "" || Request.QueryString["idkho"] == null)
            chitietphieuxuatkho.data("idkho", "0");
        else
            chitietphieuxuatkho.data("idkho", Request.QueryString["idkho"]);
        //chitietphieuxuatkho.data("idkho",Request.QueryString["idkho"]);
        if (Request.QueryString["dvt"] == "" || Request.QueryString["dvt"] == null)
            chitietphieuxuatkho.data("dvt", "0");
        else
            chitietphieuxuatkho.data("dvt", Request.QueryString["dvt"]);
        //chitietphieuxuatkho.data("dvt",Request.QueryString["dvt"]);
        if (Request.QueryString["soluong"] == "" || Request.QueryString["soluong"] == null)
            chitietphieuxuatkho.data("soluong", "0");
        else
            chitietphieuxuatkho.data("soluong", Request.QueryString["soluong"]);
        //chitietphieuxuatkho.data("soluong",Request.QueryString["soluong"]);
        if (Request.QueryString["dongiangoaite"] == "" || Request.QueryString["dongiangoaite"] == null)
            chitietphieuxuatkho.data("dongiangoaite", "0");
        else
            chitietphieuxuatkho.data("dongiangoaite", Request.QueryString["dongiangoaite"]);
        //chitietphieuxuatkho.data("dongiangoaite",Request.QueryString["dongiangoaite"]);
        if (Request.QueryString["dongia"] == "" || Request.QueryString["dongia"] == null)
            chitietphieuxuatkho.data("dongia", "0");
        else
            chitietphieuxuatkho.data("dongia", Request.QueryString["dongia"]);
        //chitietphieuxuatkho.data("dongia",Request.QueryString["dongia"]);
        if (Request.QueryString["thanhtien"] == "" || Request.QueryString["thanhtien"] == null)
            chitietphieuxuatkho.data("thanhtien", "0");
        else
            chitietphieuxuatkho.data("thanhtien", Request.QueryString["thanhtien"]);
        //chitietphieuxuatkho.data("thanhtien",Request.QueryString["thanhtien"]);
        if (Request.QueryString["vat"] == "" || Request.QueryString["vat"] == null)
            chitietphieuxuatkho.data("vat", "0");
        else
            chitietphieuxuatkho.data("vat", Request.QueryString["vat"]);
        //chitietphieuxuatkho.data("vat",Request.QueryString["vat"]);
        if (Request.QueryString["tienthue"] == "" || Request.QueryString["tienthue"] == null)
            chitietphieuxuatkho.data("tienthue", "0");
        else
            chitietphieuxuatkho.data("tienthue", Request.QueryString["tienthue"]);
        //chitietphieuxuatkho.data("tienthue",Request.QueryString["tienthue"]);
        if (Request.QueryString["tongtien"] == "" || Request.QueryString["tongtien"] == null)
            chitietphieuxuatkho.data("tongtien", "0");
        else
            chitietphieuxuatkho.data("tongtien", Request.QueryString["tongtien"]);
        //chitietphieuxuatkho.data("tongtien",Request.QueryString["tongtien"]);
        if (Request.QueryString["tienphi"] == "" || Request.QueryString["tienphi"] == null)
            chitietphieuxuatkho.data("tienphi", "0");
        else
            chitietphieuxuatkho.data("tienphi", Request.QueryString["tienphi"]);
        //chitietphieuxuatkho.data("tienphi",Request.QueryString["tienphi"]);
        if (Request.QueryString["idchitietphieunhapkho"] == "" || Request.QueryString["idchitietphieunhapkho"] == null)
            chitietphieuxuatkho.data("idchitietphieunhapkho", "0");
        else
            chitietphieuxuatkho.data("idchitietphieunhapkho", Request.QueryString["idchitietphieunhapkho"]);
        //chitietphieuxuatkho.data("idchitietphieunhapkho",Request.QueryString["idchitietphieunhapkho"]);
        if (Request.QueryString["idtu"] == "" || Request.QueryString["idtu"] == null)
            chitietphieuxuatkho.data("idtu", "0");
        else
            chitietphieuxuatkho.data("idtu", Request.QueryString["idtu"]);
        //chitietphieuxuatkho.data("idtu",Request.QueryString["idtu"]);
        if (Request.QueryString["idngan"] == "" || Request.QueryString["idngan"] == null)
            chitietphieuxuatkho.data("idngan", "0");
        else
            chitietphieuxuatkho.data("idngan", Request.QueryString["idngan"]);
        //chitietphieuxuatkho.data("idngan",Request.QueryString["idngan"]);
        if (Request.QueryString["sluongxuat"] == "" || Request.QueryString["sluongxuat"] == null)
            chitietphieuxuatkho.data("sluongxuat", "0");
        else
            chitietphieuxuatkho.data("sluongxuat", Request.QueryString["sluongxuat"]);
        //chitietphieuxuatkho.data("sluongxuat",Request.QueryString["sluongxuat"]);
        if (Request.QueryString["thanhtientruocthue"] == "" || Request.QueryString["thanhtientruocthue"] == null)
            chitietphieuxuatkho.data("thanhtientruocthue", "0");
        else
            chitietphieuxuatkho.data("thanhtientruocthue", Request.QueryString["thanhtientruocthue"]);
        //chitietphieuxuatkho.data("thanhtientruocthue",Request.QueryString["thanhtientruocthue"]);
        if (Request.QueryString["chietkhau"] == "" || Request.QueryString["chietkhau"] == null)
            chitietphieuxuatkho.data("chietkhau", "0");
        else
            chitietphieuxuatkho.data("chietkhau", Request.QueryString["chietkhau"]);
        //chitietphieuxuatkho.data("chietkhau",Request.QueryString["chietkhau"]);
        if (Request.QueryString["giavon"] != "" || Request.QueryString["giavon"] != null)
            chitietphieuxuatkho.data("giavon", "0");
        else
            chitietphieuxuatkho.data("giavon", Request.QueryString["giavon"]);
        //chitietphieuxuatkho.data("giavon",Request.QueryString["giavon"]);
        if (Request.QueryString["tienvon"] != "" || Request.QueryString["tienvon"] != null)
            chitietphieuxuatkho.data("tienvon", "0");
        else
            chitietphieuxuatkho.data("tienvon", Request.QueryString["tienvon"]);
        //chitietphieuxuatkho.data("tienvon",Request.QueryString["tienvon"]);
        if (Request.QueryString["tiensauchietkhau"] == "" || Request.QueryString["tiensauchietkhau"] == null)
            chitietphieuxuatkho.data("tiensauchietkhau", "0");
        else
            chitietphieuxuatkho.data("tiensauchietkhau", Request.QueryString["tiensauchietkhau"]);
        //chitietphieuxuatkho.data("tiensauchietkhau",Request.QueryString["tiensauchietkhau"]);
        if (Request.QueryString["tienchietkhau"] == "" || Request.QueryString["tienchietkhau"] == null)
            chitietphieuxuatkho.data("tienchietkhau", "0");
        else
            chitietphieuxuatkho.data("tienchietkhau", Request.QueryString["tienchietkhau"]);
        //chitietphieuxuatkho.data("tienchietkhau",Request.QueryString["tienchietkhau"]);
        if (Request.QueryString["IDCHITIETPHIEUYEUCAUXUATKHO"] == "" || Request.QueryString["IDCHITIETPHIEUYEUCAUXUATKHO"] == null)
            chitietphieuxuatkho.data("IDCHITIETPHIEUYEUCAUXUATKHO", "0");
        else
            chitietphieuxuatkho.data("IDCHITIETPHIEUYEUCAUXUATKHO", Request.QueryString["IDCHITIETPHIEUYEUCAUXUATKHO"]);
        //chitietphieuxuatkho.data("IDCHITIETPHIEUYEUCAUXUATKHO",Request.QueryString["IDCHITIETPHIEUYEUCAUXUATKHO"]);
        if (Request.QueryString["idchitietbenhnhantoathuoc"] != "" || Request.QueryString["idchitietbenhnhantoathuoc"] != null)
            chitietphieuxuatkho.data("idchitietbenhnhantoathuoc", "0");
        else
            chitietphieuxuatkho.data("idchitietbenhnhantoathuoc", Request.QueryString["idchitietbenhnhantoathuoc"]);
        //chitietphieuxuatkho.data("idchitietbenhnhantoathuoc",Request.QueryString["idchitietbenhnhantoathuoc"]);
        chitietphieuxuatkho.data("tkvat", Request.QueryString["tkvat"]);
        return chitietphieuxuatkho;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "DanhSachTaiKhoan_Jquery": DanhSachTaiKhoan_Jquery(); break;
            case "Luu": Savephieuxuatkho(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablechitietphieuxuatkho": LuuTablechitietphieuxuatkho(); break;
            case "loadTablechitietphieuxuatkho": loadTablechitietphieuxuatkho(); break;
            case "luuvasocai": luuvasocai();break ;                                
            case "xoa": Xoaphieuxuatkho(); break;
            case "xoachitietphieuxuatkho": Xoachitietphieuxuatkho(); break;
            case "loaivattuSearch": loaivattuSearch(); break;
            case "khachhangSearch": khachhangSearch(); break;
            case "makhachhangSearch": makhachhangSearch(); break;
            case "ngoaiteSearch": ngoaiteSearch(); break;
            case "nguoixuatSearch": nguoixuatSearch(); break;
            case "vattuSearch": vattuSearch(); break;
            case "tinhtien": tinhtien(); break;
            case "donvitinhSearch": donvitinhSearch(); break;
            case "khoSearch": khoSearch(); break;
            case "loainghiepvuSearch": loainghiepvuSearch(); break;
            case "chontoathuoc": ChonToaThuoc(); break;
            case "TestSoChungTu": TestSoChungTu(); break;
            case "lammoi": lammoi(); break;
            case "PageLoadNgoaiTe": PageLoadNgoaiTe(); break;
        }
    }
    private void PageLoadNgoaiTe()
    {
        DataTable table = DataAcess.Connect.GetTable("select top 1 ngoai_te_id,ten_nt, ty_gia from dmngoaite");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void lammoi()
    {
        DataTable table = DataAcess.Connect.GetTable("select top 1 ngoai_te_id,ten_nt,ty_gia from dmngoaite");
        string html = "";
        if (table.Rows.Count > 0)
            html = table.Rows[0]["ngoai_te_id"].ToString() + "|" + table.Rows[0]["ten_nt"].ToString() + "|" + table.Rows[0]["ty_gia"].ToString();
        else
            html = "0" + "|" + "VNĐ" + "|" + "1";
        Response.Clear();
        Response.Write(html);
    }
    private void TestSoChungTu()
    {
        string sqlsct = "select maphieuxuat from phieuxuatkho where maphieuxuat='" + Request.QueryString["ma_ct"].ToString() + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlsct);
        string html = "";
        if (table.Rows.Count > 0)
            html = "false";
        else
            html = "true";
        Response.Clear(); Response.Write(html);
    }
    private void loainghiepvuSearch()
    {
        string html = "Xuất bán lẻ|0" + Environment.NewLine;
        html += "Xuất theo toa DV|1" + Environment.NewLine;
        html += "Xuất theo toa BH|2";
        Response.Clear(); Response.Write(html);
    }
    private void khoSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select idkho,tenkho from khothuoc");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void donvitinhSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select id,tendvt from thuoc_donvitinh");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void tinhtien()
    {
        double thanhtien = 0;
        if (Request.QueryString["soluong"] != null && Request.QueryString["soluong"] != "")
        {
            if (Request.QueryString["dongia"] != null && Request.QueryString["dongia"] != "")
            {
                string soluong = Request.QueryString["soluong"];
                string dongia = Request.QueryString["dongia"];
                thanhtien = double.Parse(soluong) * double.Parse(dongia);
            }
        }
        Response.Clear();
        Response.Write(thanhtien.ToString());
    }
    private void vattuSearch()
    {
        try
        {
            string sqlvattu = "";
            if (Request.QueryString["idloaivattu"].ToString() == "0")
                sqlvattu = "select idthuoc,tenthuoc,ngayhethan,iddvt,donvitinh,tkkho,tkdoanhthu,tkgiavon from thuoc where isthuocbv='True'";
            if (Request.QueryString["idloaivattu"].ToString() == "1")
                sqlvattu = "select idthuoc,tenthuoc,ngayhethan,iddvt,donvitinh,tkkho,tkdoanhthu,tkgiavon where ishoachat='True'";
            if (Request.QueryString["idloaivattu"].ToString() == "2")
                sqlvattu = "select idthuoc,tenthuoc,ngayhethan,iddvt,donvitinh,tkkho,tkdoanhthu,tkgiavon where isvtyt='True'";

            DataTable table = DataAcess.Connect.GetTable(sqlvattu);
            string html = "";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += table.Rows[i]["tenthuoc"].ToString() + "|" + table.Rows[i]["idthuoc"].ToString() + "|" + table.Rows[i]["ngayhethan"].ToString() + "|" + table.Rows[i]["iddvt"].ToString() + "|" + table.Rows[i]["donvitinh"].ToString() + "|" + table.Rows[i]["tkkho"].ToString() + "|" + table.Rows[i]["tkdoanhthu"].ToString() + "|" + table.Rows[i]["tkgiavon"].ToString() + Environment.NewLine;
                    }
                }
            }
            Response.Clear(); Response.Write(html);
        }
        catch
        {
            Response.Clear(); Response.Write("");
        }
    }

    private void nguoixuatSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select idnguoidung,tennguoidung from nguoidung");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void ngoaiteSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select ten_nt,ngoai_te_id,ty_gia from dmngoaite");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    private void khachhangSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select tenkhachhang,makhachhang,diachi,idkhachhang from khachhang");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + "|" + table.Rows[i][3].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void makhachhangSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select tenkhachhang,makhachhang,diachi,idkhachhang from khachhang");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + "|" + table.Rows[i][3].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    private void loaivattuSearch()
    {
        string html = "Thuốc|0" + Environment.NewLine;
        html += "Hóa chất|1" + Environment.NewLine;
        html += "Vật tư y tế|2";
        Response.Clear(); Response.Write(html);

    }

    #region Load danh sach tai khoan
    public void DanhSachTaiKhoan_Jquery()
    {
        string key = Request.QueryString["q"];
        string idText = Request.QueryString["obj"];
        string sql = "";
        string html = "";
        //html += "|<div style =\"background-color: #4D67A2;height:20px\">";
        html += "|<div style=\"width: 350px; border-color: Black; border-width: 2px\">";
        html += "<div style=\"background-color:#5593DE; color:White;font-weight: bold\">";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tài khoản</div>";
        html += "<div style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\"> Tên tài khoản</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Chi tiết</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Tài khoản cấp cha</div>";
        html += "<div style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">Cấp</div>";
        html += "</div>|";

        html += Environment.NewLine;
        try
        {

            sql = "select TaiKhoan,TenTaiKhoan,ChiTiet,TKCapCha,Cap from DanhMucTK ";

            if (!string.IsNullOrEmpty(key))
                sql += "  where TaiKhoan  LIKE '" + key + "%' or TKCapCha   LIKE '" + key + "%'";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                html += "| <div style=\"cursor: pointer\" onclick=\"setChonTaiKhoan('" + dt.Rows[i]["TaiKhoan"] + "','" + idText + "')\">";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TaiKhoan"] + "</p>";
                html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TenTaiKhoan"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ChiTiet"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["TKCapCha"] + "</p>";
                html += "<p style=\"width: 50px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["Cap"] + "</p>";
                html += "</div>|" + dt.Rows[i]["TaiKhoan"];
                html += Environment.NewLine;
            }

            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }
    #endregion
    private void Xoaphieuxuatkho()
    {
        //try
        //{
        DataProcess process = s_phieuxuatkho();
        bool ok = process.Delete();
        if (ok)
        {
            Response.Clear(); Response.Write(process.getData("idphieuxuat"));
            return;
        }
        //}
        //catch
        //{
        //}
        Response.StatusCode = 500;
    }

    private void Xoachitietphieuxuatkho()
    {
        try
        {
            DataProcess process = s_chitietphieuxuatkho();
            bool ok = process.Delete();
            if (ok)
            {
                //Xóa record so_cai tương ứng
                int idchitietphieuxuatkho = int.Parse(Request.QueryString["idkhoachinh"].ToString());
                string[] parameterName1 = new string[2] { "@i", "@idchitietphieuxuatkho" };
                object[] parameterValues1 = new object[2] { "1", idchitietphieuxuatkho };
                bool ktsocai = DataAcess.Connect.ExecSQL("spNhapMuaDuoc_SoCai_Save", parameterName1, parameterValues1);
                //string sqlsocai = "exec [spNhapMuaDuoc_SoCai_Save] 0,'" + ma_ct + "','" + ngay_lap_ct + "','" + tk_no + "','" + tk_co + "','" + tk_thue + "','" + dien_giai + "','" + so_hd + "','" + so_seri + "','" + ngay_lap_hd + "'," + tien_thue + "," + tien_hang + ",'" + manhacungcap + "',0," + idchitietphieuxuatkho + "";
                //bool ktsocai = DataAcess.Connect.ExecSQL(sqlsocai);
                Response.Clear(); Response.Write(process.getData("idchitietphieuxuat"));
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
        //DataTable table = Process.phieuxuatkho.dtSearchByidphieuxuat(idkhoachinh);
        string sqlsettk = @"select pxk.*, nd.tennguoidung as mkv_idnguoixuat,kh.makhachhang,kh.tenkhachhang as mkv_IDKhachHang,kh.diachi
                ,ngoai_te_id = case when isnull(pxk.ngoai_te_id,-1)=-1 then (select top 1 ngoai_te_id from dmngoaite) else pxk.ngoai_te_id end
                ,ma_nt
                ,mkv_ngoai_te_id = case when isnull(pxk.ngoai_te_id,-1)=-1 then (select top 1 ten_nt from dmngoaite) else ten_nt end
                ,tigia = case when isnull(pxk.ty_gia,-1)=-1 then (select top 1 ty_gia from dmngoaite) else pxk.ty_gia end 
                ,mkv_idkho = kt.tenkho
                from phieuxuatkho pxk
                left join khachhang kh on pxk.idkhachhang=kh.idkhachhang
                left join dmngoaite nt on pxk.ngoai_te_id=nt.ngoai_te_id
                left join nguoidung nd on pxk.idnguoixuat = nd.idnguoidung
                left join vtytkho k on pxk.idkho = k.idkho
                left join khothuoc kt on pxk.idkho=kt.idkho 
                where idphieuxuat=" + idkhoachinh;
        DataTable table = DataAcess.Connect.GetTable(sqlsettk);
        string html = "";
        html += "<root>";
        html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
        html += Environment.NewLine;
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {

                for (int y = 0; y < table.Columns.Count; y++)
                {
                    try
                    {
                        html += "<data id='" + table.Columns[y].ToString() + "'>" + DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "</data>";
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

    private string showkhachhang(string idkhachhang)
    {
        if (idkhachhang != "")
        {
            string sqlkh = "select makhachhang,tenkhachhang,diachi from khachhang where idkhachhang = " + idkhachhang;
            DataTable table = DataAcess.Connect.GetTable(sqlkh);
            if (table.Rows.Count > 0)
                return table.Rows[0][0].ToString() + "|" + table.Rows[0][1].ToString() + "|" + table.Rows[0][2].ToString();
            else
                return "";
        }
        else
            return "";
    }
    private string showngoaite(string idngoaite)
    {
        if (idngoaite != "")
        {
            string sqlnt = "select ma_nt,ten_nt from dmngoaite where ngoai_te_id= 1";
            DataTable table = DataAcess.Connect.GetTable(sqlnt);
            if (table.Rows.Count > 0)
                return table.Rows[0][0].ToString() + "|" + table.Rows[0][1].ToString();
            else
                return "";
        }
        else
            return "";
    }
    private void TimKiem()
    {
        try
        {
            DataProcess process = s_phieuxuatkho();
            process.Page = Request.QueryString["page"];

            //string sqlsearch = @"select STT=row_number() over (order by T.idphieuxuat),T.*";
            //       sqlsearch = " from phieuxuatkho T where " + process.sWhere();
            string sqlsearch = "select * from phieuxuatkho";
            //sqlsearch += " and (select top 1 isnull(isthuocbv,'False') from chitietphieunhapkho ctp left join thuoc th on ctp.idthuoc=th.idthuoc where ctp.idphieunhap = T.idphieunhap) = 'True'";
            sqlsearch += " where maphieuxuat <> ''";
            if (Request.QueryString["maphieuxuat"] != "")
                sqlsearch += " and maphieuxuat = '" + Request.QueryString["maphieuxuat"].ToString() + "'";
            if (Request.QueryString["ngaythang"] != "" && Request.QueryString["txtdenngay"] == "")
                sqlsearch += " and ngaythang = '" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngaythang"].ToString()) + "'";
            if (Request.QueryString["ngaythang"] != "" && Request.QueryString["txtdenngay"] != "")
            {
                sqlsearch += " and ngaythang >= '" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngaythang"].ToString()) + "'";
                sqlsearch += " and ngaythang <= '" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["txtdenngay"].ToString()) + "'";
            }
            if (Request.QueryString["idkhachhang"] != "")
                sqlsearch += " and idkhachhang = " + Request.QueryString["idkhachhang"].ToString();
            if (Request.QueryString["tkno"] != "")
                sqlsearch += " and tkno = '" + Request.QueryString["tkno"].ToString() + "'";
            if (Request.QueryString["tkvat"] != "")
                sqlsearch += " and tkvat = '" + Request.QueryString["tkvat"].ToString() + "'";
            if (Request.QueryString["ghichu"] != "")
                sqlsearch += " and ghichu like N'%" + Request.QueryString["ghichu"].ToString() + "%'";
            //if (Request.QueryString["ngoai_te_id"] != "")
            //    sqlsearch += " and ngoai_te_id = " + Request.QueryString["ngoai_te_id"].ToString();
            if (Request.QueryString["idkho"] != "")
                sqlsearch += " and idkho = " + Request.QueryString["idkho"].ToString();
            if (Request.QueryString["idnguoixuat"] != "")
                sqlsearch += " and idnguoixuat = " + Request.QueryString["idnguoixuat"].ToString();


            DataTable table = DataAcess.Connect.GetTable(sqlsearch);
            string html = "";
            html += "<table class='jtable' id=\"tablefind\">";
            html += "<tr>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Lập") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số Chứng Từ") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã Khách Hàng") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên Khách Hàng") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Địa Chỉ") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TKNo") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TKVat") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngoại Tệ") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tỉ Giá") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>";
            html += "</tr>";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr onclick=\"setControlFind('" + table.Rows[i]["idphieuxuat"].ToString() + "')\">";
                        if (table.Rows[i]["ngaythang"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["ngaythang"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                        }
                        else
                        {
                            html += "<td>" + table.Rows[i]["ngaythang"].ToString() + "</td>";
                        }
                        html += "<td>" + table.Rows[i]["MaPhieuXuat"].ToString() + "</td>";
                        string[] khachhang = showkhachhang(table.Rows[i]["IDKhachHang"].ToString()).Split('|');
                        if (showkhachhang(table.Rows[i]["IDKhachHang"].ToString()) != "")
                        {
                            html += "<td>" + khachhang[0] + "</td>";
                            html += "<td>" + khachhang[1] + "</td>";
                            html += "<td>" + khachhang[2] + "</td>";
                        }
                        else
                        {
                            html += "<td>" + "" + "</td>";
                            html += "<td>" + "" + "</td>";
                            html += "<td>" + "" + "</td>";
                        }
                        html += "<td>" + table.Rows[i]["TKNo"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["TKVat"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["ghichu"].ToString() + "</td>";
                        string s = showngoaite(table.Rows[i]["ngoai_te_id"].ToString());
                        string[] ngoaite = showngoaite(table.Rows[i]["ngoai_te_id"].ToString()).Split('|');
                        if (showkhachhang(table.Rows[i]["ngoai_te_id"].ToString()) != "")
                        {
                            html += "<td>" + ngoaite[0] + "</td>";
                            html += "<td>" + ngoaite[1] + "</td>";
                        }
                        else
                        {
                            html += "<td>" + "" + "</td>";
                            html += "<td>" + "" + "</td>";
                        }
                        html += "<td>" + table.Rows[i]["thanhtien"].ToString() + "</td>";
                        html += "</tr>";
                    }
                    html += "</table>";
                    html += process.Paging();
                    Response.Clear(); Response.Write(html);
                    return;
                }
            }
            else
            {
                Response.StatusCode = 500;
            }
        }
        catch
        {
            Response.Clear(); Response.Write("");
            return;
        }

    }

    private void ChonToaThuoc()
    {
        DataProcess process = s_phieuxuatkho();
        process.Page = Request.QueryString["page"];

        string sqlsearch = @"select * from benhnhantoathuoc";
        DataTable table = DataAcess.Connect.GetTable(sqlsearch);
        string html = "";
        html += "<table class='jtable' id=\"tablefind\">";
        html += "<tr>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã Toa Thuốc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ID Khám Bệnh") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ID Bác Sĩ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ID Bệnh Nhân") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Ra Toa") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ID Nguoi Ban") + "</th>";

        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr onclick=\"setControlFind('" + table.Rows[i]["idbenhnhantoathuoc"].ToString() + "')\">";

                    html += "<td>" + table.Rows[i]["matoathuoc"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["idkhambenh"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["idbacsi"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["idbenhnhan"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["ngayratoa"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["idnguoiban"].ToString() + "</td>";
                    html += "</tr>";
                }
                html += "</table>";
                html += process.Paging();
                Response.Clear(); Response.Write(html);
                return;
            }
        }
        else
        {
            Response.StatusCode = 500;
        }
    }

    private void Savephieuxuatkho()
    {
        //try
        //{
        DataProcess process = s_phieuxuatkho();
        if (process.getData("idphieuxuat") != null && process.getData("idphieuxuat") != "")
        {
            bool ok = process.Update();
            if (ok)
            {
                string sqlupdateso_cai = @"update so_cai set ps_no=0,ps_co=0
                    where ma_ct = (select maphieuxuat from phieuxuatkho where isnull(isthue,0) <> 'True' and idphieuxuat=" + process.getData("idphieuxuat") + ")";
                bool checkso_cai = DataAcess.Connect.ExecSQL(sqlupdateso_cai);
                Response.Clear(); Response.Write(process.getData("idphieuxuat"));
                return;
            }
        }
        else
        {
            bool ok = process.Insert();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idphieuxuat"));
                return;
            }
        }
        //}
        //catch
        //{
        //}
        Response.StatusCode = 500;
    }

    public void luuvasocai()
    {
        string ma_ct = "";
        string ngay_nhap = "";
        string tk_no = "";
        string tk_ck = "";
        string tk_kho = "";
        string tk_thue = "";
        string tk_doanhthu = "";
        string tk_giavon = "";
        string dien_giai = "";
        string so_hd = "";
        string so_seri = "";
        string ngay_lap_hd = "";
        string makh = "";
        string thue_suat = "";
        ngay_nhap = Request.QueryString["ngaynhap"].ToString();
        tk_no = Request.QueryString["tkno"].ToString();
        thue_suat = Request.QueryString["thuesuat"].ToString();
        tk_ck = Request.QueryString["tknokhac"].ToString();
        ma_ct = Request.QueryString["ma_ct"].ToString();
        tk_ck = Request.QueryString["tknokhac"].ToString();
        tk_thue = Request.QueryString["tkvat"].ToString(); ;
        dien_giai = Request.QueryString["diengiai"].ToString();
        makh = Request.QueryString["makhachhang"].ToString();
        ngay_lap_hd = ngay_nhap;
        so_hd = "";
        so_seri = "";
        try
        {
            double tien_thue = 0;
            double tien_hang = 0;
            double tien_ck = 0;
            double tien_von = 0;
            //string ma_cc = "";
            string sql = "select b.tkco,tkgiavon,tkdoanhthu,sum(isnull(b.thanhtien,0))tienhang,sum(isnull(tienthue,0))tienthue,sum(isnull(tienvon,0))tienvon,sum(isnull(tienchietkhau,0))tienchietkhau ";
            sql += " from phieuxuatkho a inner join chitietphieuxuatkho b on a.idphieuxuat=b.idphieuxuat";
            sql += " where maphieuxuat='" + ma_ct.Trim() + "'";
            sql += " group by b.tkco,tkgiavon,tkdoanhthu ";
            DataTable dt = new DataTable();
            dt = DataAcess.Connect.GetTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tk_kho = dt.Rows[i]["tkco"].ToString();
                    tk_giavon = dt.Rows[i]["tkgiavon"].ToString();
                    tk_doanhthu = dt.Rows[i]["tkdoanhthu"].ToString();
                    tien_thue = Convert.ToDouble(dt.Rows[i]["tienthue"].ToString());
                    tien_hang = Convert.ToDouble(dt.Rows[i]["tienhang"].ToString());
                    tien_ck = Convert.ToDouble(dt.Rows[i]["tienchietkhau"].ToString());
                    tien_von = Convert.ToDouble(dt.Rows[i]["tienvon"].ToString());
                    //ma_cc = dt.Rows[i]["manhacungcap"].ToString();
                    string sqlexec = "Exec spPhieuXuatKhoDuoc_SoCai_Save '" + ma_ct + "','" + StaticData.CheckDate_kt(ngay_nhap) + "','" + tk_no + "','" + tk_doanhthu + "','" + tk_thue + "','" + tk_giavon + "','" + tk_kho + "','" + tk_ck + "',N'" + dien_giai + "','" + so_hd + "','" + "" + "','";
                    sqlexec += StaticData.CheckDate(ngay_lap_hd) + "'," + tien_thue + "," + tien_hang + "," + tien_ck + "," + tien_von + ",'" + makh + "','" + i + "','" + thue_suat + "'";
                    DataAcess.Connect.ExecSQL(sqlexec);
                }
            }
        }
        catch
        { }
    }
    public void LuuTablechitietphieuxuatkho()
    {        
        string tkgiavon1 = "";
        string tkdoanhthu1 = "";
        double tienvon1 = 0;
        double giavon1 = 0;
        int soluong1 = 0;
        tkgiavon1 = Request.QueryString["tkgiavon"].ToString();
        tkdoanhthu1 = Request.QueryString["tkdoanhthu"].ToString();
        soluong1 = int.Parse(Request.QueryString["soluong"].ToString());
        giavon1 = double.Parse(Request.QueryString["giavon"].ToString());
        tienvon1 = giavon1 * soluong1;
        string sqlupdate = "";


        DataProcess process = s_chitietphieuxuatkho();
        if (process.getData("idchitietphieuxuat") != null && process.getData("idchitietphieuxuat") != "")
        {
            bool ok = process.Update();
            sqlupdate = " update chitietphieuxuatkho set tkgiavon='" + tkgiavon1 + "', tkdoanhthu='" + tkdoanhthu1 + "', tienvon=" + tienvon1 + " where idchitietphieuxuat=" + process.getData("idchitietphieuxuat");
            DataAcess.Connect.ExecSQL(sqlupdate);
            if (ok)
            {
                
                Response.Clear(); Response.Write(process.getData("idchitietphieuxuat"));
                return;
            }
        }
        else
        {
            bool ok = process.Insert();
            if (ok)
            {                
                Response.Clear(); Response.Write(process.getData("idchitietphieuxuat"));
                return;
            }
        }
        
        Response.StatusCode = 500;
    }

    private string loadtenthuoc(string idthuoc)
    {
        try
        {
            string sqlthuoc = "select tenthuoc from thuoc where idthuoc=" + idthuoc;
            return DataAcess.Connect.GetTable(sqlthuoc).Rows[0][0].ToString();
        }
        catch
        {
            return "";
        }
    }

    private string loaivattu(string idthuoc)
    {
        string loaivt = "";
        if (idthuoc == "")
            return "";
        string sqlloaivt = "select isthuocbv,ishoachat,isvtyt from thuoc where idthuoc=" + idthuoc;
        DataTable table = DataAcess.Connect.GetTable(sqlloaivt);
        if (table.Rows.Count > 0)
        {
            if (table.Rows[0]["isthuocbv"].ToString() == "True")
                loaivt = "isthuocbv";
            if (table.Rows[0]["ishoachat"].ToString() == "True")
                loaivt = "ishoachat";
            if (table.Rows[0]["isvtyt"].ToString() == "True")
                loaivt = "isvtyt";
        }
        return loaivt;
    }
    private string donvitinh(string iddvt)
    {
        string dvt = "";
        if (iddvt == "")
            return "";
        string sqldvt = "select tendvt from thuoc_donvitinh where id=" + iddvt;
        DataTable table = DataAcess.Connect.GetTable(sqldvt);
        if (table.Rows.Count > 0)
        {
            dvt = table.Rows[0][0].ToString();
        }
        return dvt;
    }
    private string tygia(string idphieuxuat)
    {
        //try
        //{
        string sql = "select p.ty_gia from phieuxuatkho p left join dmngoaite d on p.ngoai_te_id=d.ngoai_te_id where idphieuxuat =" + idphieuxuat;
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table.Rows.Count > 0)
            return table.Rows[0][0].ToString();
        else
            return "";
        //}
        //catch
        //{
        //   return "";
        //}
    }
    private string loadNguyenTe(string thanhtien, string tygia)
    {
        try
        {
            if (thanhtien != "" && thanhtien != "0" && tygia != "" && tygia != "0")
            {
                double result = double.Parse(thanhtien) / double.Parse(tygia);
                return result.ToString();
            }
            else
                return "0";
        }
        catch
        {
            return "0";
        }
    }
    public void loadTablechitietphieuxuatkho()
    {
        DataProcess process = s_chitietphieuxuatkho();
        process.Page = Request.QueryString["page"];
        string sqlpxk = @"select STT=row_number() over (order by T.idchitietphieuxuat),T.*,px.maphieuxuat,px.ma_kt
                        ,taikhoanco = case when(isnull(T.tkco,'') <> '') then T.tkco else (select tkkho from thuoc where idthuoc=T.idthuoc) end
                        ,taikhoandoanhthu = case when(isnull(T.tkdoanhthu,'') <> '') then T.tkdoanhthu else (select tkdoanhthu from thuoc where idthuoc=T.idthuoc) end
                        ,taikhoangiavon = case when(isnull(T.tkgiavon,'') <> '') then T.tkgiavon else (select tkgiavon from thuoc where idthuoc=T.idthuoc) end
                        ,txtgiavon = case when(isnull(T.giavon,0) <> 0) then T.giavon else 0 end
						,losanxuat=(select top 1 losanxuat from chitietphieunhapkho where idthuoc=T.idthuoc)
                        ,ngayhethan=(select top 1 ngayhethan from chitietphieunhapkho where idthuoc=T.idthuoc)
                        from chitietphieuxuatkho T left join phieuxuatkho px on T.idphieuxuat=px.idphieuxuat
                        left join thuoc th on T.idthuoc=th.idthuoc
                        where T.idphieuxuat='" + process.getData("idphieuxuat") + "'";
        DataTable table = process.Search(sqlpxk);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Loại thuốc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên thuốc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage(" TK_có ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK_doanh thu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK_giá vốn") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Lô SX") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngày Hết Hạn") + "</th>";
        //html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ĐVT") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Giá Vốn") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số Lượng") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Chiết khấu(%)") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền chiết khấu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("vat(%)") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiền Thuế") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Nguyên tệ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thành tiền(VNĐ)") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                int k = i + 1;
                html += "<td>" + k.ToString() + "</td>";
                html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";

                html += "<td><input mkv='true' id='loaithuoc' value='' type='hidden' />";
                if (loaivattu(table.Rows[i]["idthuoc"].ToString()) == "isthuocbv")
                    html += "<input mkv='true' id='mkv_loaithuoc' value='Thuốc' type='text' onfocus='Find(this);chuyenphim(this);loaivattuSearch(this);' class='down_select'/></td>";
                if (loaivattu(table.Rows[i]["idthuoc"].ToString()) == "ishoachat")
                    html += "<input mkv='true' id='mkv_loaithuoc' value='Hóa chất' type='text' onfocus='Find(this);chuyenphim(this);loaivattuSearch(this);' class='down_select'/></td>";
                if (loaivattu(table.Rows[i]["idthuoc"].ToString()) == "isvtyt")
                    html += "<input mkv='true' id='mkv_loaithuoc' value='Vật tư y tế' type='text' onfocus='Find(this);chuyenphim(this);loaivattuSearch(this);' class='down_select'/></td>";
                //html += "<td><input mkv='true' id='idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);loaivattuSearch(this.id);' value=''/></td>";

                html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);vattuSearch(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "'/>";
                html += "<input mkv='true' id='mkv_idthuoc' type='text' onfocus='Find(this);chuyenphim(this);vattuSearch(this);' value='" + loadtenthuoc(table.Rows[i]["idthuoc"].ToString()) + "'/></td>";

                html += "<td><input mkv='true' id='tkco' type='text' onfocusout='chuyenformout(this)'  onfocus='Find(this);chuyenphim(this);ShowTaiKhoan1(this);' value='" + table.Rows[i]["taikhoanco"].ToString() + "'  style=\"width:100%;text-align:center\"/></td>";

                html += "<td><input mkv='true' id='tkdoanhthu' type='text' onfocusout='chuyenformout(this)'  onfocus='Find(this);chuyenphim(this);ShowTaiKhoan1(this);' value='" + table.Rows[i]["taikhoandoanhthu"].ToString() + "'   style=\"width:100%;text-align:center\"/></td>";
                html += "<td><input mkv='true' id='tkgiavon' type='text' onfocusout='chuyenformout(this)'  onfocus='Find(this);chuyenphim(this);ShowTaiKhoan1(this);' value='" + table.Rows[i]["taikhoangiavon"].ToString() + "'   style=\"width:100%;text-align:center\"/></td>";

                html += "<td><input mkv='true' id='losanxuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["losanxuat"].ToString() + "' /></td>";
                if (table.Rows[i]["ngayhethan"].ToString() != "")
                {
                    html += "<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + DateTime.Parse(table.Rows[i]["ngayhethan"].ToString()).ToString("dd/MM/yyyy") + "' onblur='TestDate(this)' /></td>";
                }
                else { html += "<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='Find(this);chuyendong(this);chuyenphim(this);$(this).datepick();' value='" + table.Rows[i]["ngayhethan"].ToString() + "' onblur='TestDate(this)' /></td>"; }
                //html += "<td><input mkv='true' id='idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' id='dvt' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);donvitinhSearch(this);' value='" + table.Rows[i]["dvt"].ToString() + "'/>";
                html += "<input mkv='true' id='mkv_dvt' type='text' onfocus='Find(this);chuyenphim(this);donvitinhSearch(this);' value='" + donvitinh(table.Rows[i]["dvt"].ToString()) + "' onblur='' class='down_select'/></td>";
                html += "<td><input mkv='true' id='giavon' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["txtgiavon"].ToString())) + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluong"].ToString() + "' onblur='TestSo(this,false,false);tinhtien(this);'/></td>";
                html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["dongia"].ToString())) + "' /></td>";

                html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["chietkhau"].ToString() + "' onblur='TestSo(this,false,false);tinhtien(this);'/></td>";
                try
                {
                    html += "<td><input mkv='true' id='tienchietkhau' type='text' readonly='readonly' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["tienchietkhau"].ToString())) + "' onblur='TestSo(this,false,false);'/></td>";
                }
                catch
                {
                    html += "<td><input mkv='true' id='tienchietkhau' type='text' readonly='readonly' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tienchietkhau"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                }

                html += "<td><input mkv='true' id='vat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["vat"].ToString() + "' onblur='TestSo(this,false,false);tinhtien(this);'/></td>";
                html += "<td><input mkv='true' id='tienthue' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["tienthue"].ToString())) + "'/></td>";
                //html += "<td><input mkv='true' id='tongtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tongtien"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' id='nguyente' type='text' readonly='readonly' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(loadNguyenTe(table.Rows[i]["thanhtien"].ToString(), tygia(table.Rows[i]["idphieuxuat"].ToString())))) + "' /></td>";
                html += "<td><input mkv='true' id='thanhtien' type='text' readonly='readonly' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["thanhtien"].ToString())) + "' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietphieuxuat"].ToString() + "'/>";
                ////////////////
                html += "<input mkv='true' id='txtmaphieuxuat' type='hidden' value='" + table.Rows[i]["maphieuxuat"].ToString() + "'/>";
                html += "<input mkv='true' id='txtma_kt' type='hidden' value='" + table.Rows[i]["ma_kt"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        else
        {
            html += "<tr>";
            html += "<td>1</td>";
            html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td><input mkv='true' id='loaithuoc' value='' type='hidden' />";
            html += "<input mkv='true' id='mkv_loaithuoc' value='' type='text' onfocus='Find(this);chuyenphim(this);loaivattuSearch(this);' class='down_select'/></td>";
            //html += "<td><input mkv='true' id='idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);loaivattuSearch(this.id);' value=''/></td>";
            html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);vattuSearch(this);' value=''/>";
            html += "<input mkv='true' id='mkv_idthuoc' type='text' onfocus='Find(this);chuyenphim(this);vattuSearch(this);' value='' /></td>";

            //html += "<td><input mkv='true' id='tkco' value='' type='hidden' />";
            //html += "<input mkv='true' id='mkv_tkco' value='' type='text' onfocus='Find(this);chuyenphim(this);ShowTaiKhoan1(this);' class='down_select'/></td>";
            html += "<td><input mkv='true' id='tkco' type='text' onfocusout='chuyenformout(this)' onfocus='Find(this);chuyenphim(this);ShowTaiKhoan1(this);' value=''  style=\"width:100%;text-align:center\"></td>";

            html += "<td><input mkv='true' id='tkdoanhthu' type='text' onfocusout='chuyenformout(this)' onfocus='Find(this);chuyenphim(this);ShowTaiKhoan1(this);' value=''  style=\"width:100%;text-align:center\"></td>";
            html += "<td><input mkv='true' id='tkgiavon' type='text' onfocusout='chuyenformout(this)' onfocus='Find(this);chuyenphim(this);ShowTaiKhoan1(this);' value=''  style=\"width:100%;text-align:center\"></td>";

            html += "<td><input mkv='true' id='losanxuat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' id='ngayhethan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);$(this).datepick();' onblur='TestDate(this)'/></td>";
            //html += "<td><input mkv='true' id='idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='dvt' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);donvitinhSearch(this);' value=''/>";
            html += "<input mkv='true' id='mkv_dvt' type='text' onfocus='Find(this);chuyenphim(this);donvitinhSearch(this);' value='' onblur='' class='down_select'/></td>";
            //html += "<td><input mkv='true' id='dvt' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);donvitinhSearch(this);' value=''/>";
            //html += "<td><input mkv='true' id='mkv_dvt' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);donvitinhSearch(this);' value='' onblur='TestSo(this,false,false);' class=''  class='down_select'/></td>";
            html += "<td><input mkv='true' id='giavon' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhtien(this);' /></td>";
            //html += "<td><input mkv='true' id='dongiangoaite' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhtien(this);' /></td>";
            html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";

            html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhtien(this);' /></td>";
            html += "<td><input mkv='true' id='tienchietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhtien(this);' /></td>";

            html += "<td><input mkv='true' id='vat' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);tinhtien(this);' /></td>";
            html += "<td><input mkv='true' id='tienthue' type='text' readonly='readonly' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            //html += "<td><input mkv='true' id='tongtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='nguyente' type='text' readonly='readonly' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' id='thanhtien' type='text' readonly='readonly' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
            html += "<input mkv='true' id='txtmaphieuxuat' type='hidden' value=''/>";
            html += "<input mkv='true' id='txtma_kt' type='hidden' value=''/></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging("chitietphieuxuatkho");
        Response.Clear(); Response.Write(html);
    }
}


