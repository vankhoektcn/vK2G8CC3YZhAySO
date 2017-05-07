using System.Data;
using DataAcess;

//───────────────────────────────────────────────────────────────────────────────────────

namespace NTH_Process
{
    public class khambenh : Connect
    {
        public static string sTableName = "khambenh";
        private static DataTable dt_khambenh;
        public static bool Change_dt_khambenh = true;
        public static bool AllowAutoChange = true;
        public string ChanDoanTuyenDuoi;
        public string IdChiTietDangKyKham;
        public string IdDieuDuong;
        public string IsDaRaVien;
        public string SoPhieuTT;
        public string TienSu;
        public string benhsu;
        public string chandoanbandau;
        public string chidinhbacsi;
        public string dando;
        public string ghichuhuongdieutri;
        public string hoantat;
        public string huongdieutri;
        public string idDVPhongChuyenDen;
        public string idPhongChuyenDen;
        public string idbacsi;
        public string idbenhnhan;
        public string iddangkykham;
        public string idkhambenh;
        public string idkhambenhgoc;
        public string idphongkhambenh;
        public string isNoiTru;
        public string isdathanhtoan;
        public string ketluan;
        public string ketluan1;
        public string ketluan2;
        public string maphieukham;
        public string ngayhentaikham;
        public string ngaykham;
        public string noidungtaikham;
        public string numberRow;
        public string page;
        public string phongkhamchuyenden;
        public string sovaovien;
        public string thuChuyenPhong;
        public string tinhtrangtaikham;
        public string trieuchung;

        #region DataColumn Name ;

        public static string cl_idkhambenh = "idkhambenh";
        public static string cl_idkhambenh_VN = "idkhambenh";
        public static string cl_maphieukham = "maphieukham";
        public static string cl_maphieukham_VN = "maphieukham";
        public static string cl_ngaykham = "ngaykham";
        public static string cl_ngaykham_VN = "ngaykham";
        public static string cl_idbenhnhan = "idbenhnhan";
        public static string cl_idbenhnhan_VN = "idbenhnhan";
        public static string cl_iddangkykham = "iddangkykham";
        public static string cl_iddangkykham_VN = "iddangkykham";
        public static string cl_idbacsi = "idbacsi";
        public static string cl_idbacsi_VN = "idbacsi";
        public static string cl_trieuchung = "trieuchung";
        public static string cl_trieuchung_VN = "trieuchung";
        public static string cl_benhsu = "benhsu";
        public static string cl_benhsu_VN = "benhsu";
        public static string cl_chandoanbandau = "chandoanbandau";
        public static string cl_chandoanbandau_VN = "chandoanbandau";
        public static string cl_ketluan = "ketluan";
        public static string cl_ketluan_VN = "ketluan";
        public static string cl_ketluan1 = "ketluan1";
        public static string cl_ketluan1_VN = "ketluan1";
        public static string cl_ketluan2 = "ketluan2";
        public static string cl_ketluan2_VN = "ketluan2";
        public static string cl_huongdieutri = "huongdieutri";
        public static string cl_huongdieutri_VN = "huongdieutri";
        public static string cl_phongkhamchuyenden = "phongkhamchuyenden";
        public static string cl_phongkhamchuyenden_VN = "phongkhamchuyenden";
        public static string cl_ghichuhuongdieutri = "ghichuhuongdieutri";
        public static string cl_ghichuhuongdieutri_VN = "ghichuhuongdieutri";
        public static string cl_chidinhbacsi = "chidinhbacsi";
        public static string cl_chidinhbacsi_VN = "chidinhbacsi";
        public static string cl_dando = "dando";
        public static string cl_dando_VN = "dando";
        public static string cl_noidungtaikham = "noidungtaikham";
        public static string cl_noidungtaikham_VN = "noidungtaikham";
        public static string cl_ngayhentaikham = "ngayhentaikham";
        public static string cl_ngayhentaikham_VN = "ngayhentaikham";
        public static string cl_hoantat = "hoantat";
        public static string cl_hoantat_VN = "hoantat";
        public static string cl_idphongkhambenh = "idphongkhambenh";
        public static string cl_idphongkhambenh_VN = "idphongkhambenh";
        public static string cl_TienSu = "TienSu";
        public static string cl_TienSu_VN = "TienSu";
        public static string cl_SoPhieuTT = "SoPhieuTT";
        public static string cl_SoPhieuTT_VN = "SoPhieuTT";
        public static string cl_idPhongChuyenDen = "idPhongChuyenDen";
        public static string cl_idPhongChuyenDen_VN = "idPhongChuyenDen";
        public static string cl_thuChuyenPhong = "thuChuyenPhong";
        public static string cl_thuChuyenPhong_VN = "thuChuyenPhong";
        public static string cl_idDVPhongChuyenDen = "idDVPhongChuyenDen";
        public static string cl_idDVPhongChuyenDen_VN = "idDVPhongChuyenDen";
        public static string cl_IdChiTietDangKyKham = "IdChiTietDangKyKham";
        public static string cl_IdChiTietDangKyKham_VN = "IdChiTietDangKyKham";
        public static string cl_ChanDoanTuyenDuoi = "ChanDoanTuyenDuoi";
        public static string cl_ChanDoanTuyenDuoi_VN = "ChanDoanTuyenDuoi";
        public static string cl_isNoiTru = "isNoiTru";
        public static string cl_isNoiTru_VN = "isNoiTru";
        public static string cl_idkhambenhgoc = "idkhambenhgoc";
        public static string cl_idkhambenhgoc_VN = "idkhambenhgoc";
        public static string cl_sovaovien = "sovaovien";
        public static string cl_sovaovien_VN = "sovaovien";
        public static string cl_IdDieuDuong = "IdDieuDuong";
        public static string cl_IdDieuDuong_VN = "IdDieuDuong";
        public static string cl_IsDaRaVien = "IsDaRaVien";
        public static string cl_IsDaRaVien_VN = "IsDaRaVien";
        public static string cl_isdathanhtoan = "isdathanhtoan";
        public static string cl_isdathanhtoan_VN = "isdathanhtoan";
        public static string cl_tinhtrangtaikham = "tinhtrangtaikham";
        public static string cl_tinhtrangtaikham_VN = "tinhtrangtaikham";

        #endregion;

//───────────────────────────────────────────────────────────────────────────────────────
        public khambenh()
        {
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public khambenh(
            string sidkhambenh,
            string smaphieukham,
            string sngaykham,
            string sidbenhnhan,
            string siddangkykham,
            string sidbacsi,
            string strieuchung,
            string sbenhsu,
            string schandoanbandau,
            string sketluan,
            string sketluan1,
            string sketluan2,
            string shuongdieutri,
            string sphongkhamchuyenden,
            string sghichuhuongdieutri,
            string schidinhbacsi,
            string sdando,
            string snoidungtaikham,
            string sngayhentaikham,
            string shoantat,
            string sidphongkhambenh,
            string sTienSu,
            string sSoPhieuTT,
            string sidPhongChuyenDen,
            string sthuChuyenPhong,
            string sidDVPhongChuyenDen,
            string sIdChiTietDangKyKham,
            string sChanDoanTuyenDuoi,
            string sisNoiTru,
            string sidkhambenhgoc,
            string ssovaovien,
            string sIdDieuDuong,
            string sIsDaRaVien,
            string sisdathanhtoan,
            string stinhtrangtaikham)
        {
            idkhambenh = sidkhambenh;
            maphieukham = smaphieukham;
            ngaykham = sngaykham;
            idbenhnhan = sidbenhnhan;
            iddangkykham = siddangkykham;
            idbacsi = sidbacsi;
            trieuchung = strieuchung;
            benhsu = sbenhsu;
            chandoanbandau = schandoanbandau;
            ketluan = sketluan;
            ketluan1 = sketluan1;
            ketluan2 = sketluan2;
            huongdieutri = shuongdieutri;
            phongkhamchuyenden = sphongkhamchuyenden;
            ghichuhuongdieutri = sghichuhuongdieutri;
            chidinhbacsi = schidinhbacsi;
            dando = sdando;
            noidungtaikham = snoidungtaikham;
            ngayhentaikham = sngayhentaikham;
            hoantat = shoantat;
            idphongkhambenh = sidphongkhambenh;
            TienSu = sTienSu;
            SoPhieuTT = sSoPhieuTT;
            idPhongChuyenDen = sidPhongChuyenDen;
            thuChuyenPhong = sthuChuyenPhong;
            idDVPhongChuyenDen = sidDVPhongChuyenDen;
            IdChiTietDangKyKham = sIdChiTietDangKyKham;
            ChanDoanTuyenDuoi = sChanDoanTuyenDuoi;
            isNoiTru = sisNoiTru;
            idkhambenhgoc = sidkhambenhgoc;
            sovaovien = ssovaovien;
            IdDieuDuong = sIdDieuDuong;
            IsDaRaVien = sIsDaRaVien;
            isdathanhtoan = sisdathanhtoan;
            tinhtrangtaikham = stinhtrangtaikham;
        }

        public khambenh(DataView dv, int pos)
        {
            idkhambenh = dv[pos][0].ToString();
            maphieukham = dv[pos][1].ToString();
            ngaykham = dv[pos][2].ToString();
            idbenhnhan = dv[pos][3].ToString();
            iddangkykham = dv[pos][4].ToString();
            idbacsi = dv[pos][5].ToString();
            trieuchung = dv[pos][6].ToString();
            benhsu = dv[pos][7].ToString();
            chandoanbandau = dv[pos][8].ToString();
            ketluan = dv[pos][9].ToString();
            ketluan1 = dv[pos][10].ToString();
            ketluan2 = dv[pos][11].ToString();
            huongdieutri = dv[pos][12].ToString();
            phongkhamchuyenden = dv[pos][13].ToString();
            ghichuhuongdieutri = dv[pos][14].ToString();
            chidinhbacsi = dv[pos][15].ToString();
            dando = dv[pos][16].ToString();
            noidungtaikham = dv[pos][17].ToString();
            ngayhentaikham = dv[pos][18].ToString();
            hoantat = dv[pos][19].ToString();
            idphongkhambenh = dv[pos][20].ToString();
            TienSu = dv[pos][21].ToString();
            SoPhieuTT = dv[pos][22].ToString();
            idPhongChuyenDen = dv[pos][23].ToString();
            thuChuyenPhong = dv[pos][24].ToString();
            idDVPhongChuyenDen = dv[pos][25].ToString();
            IdChiTietDangKyKham = dv[pos][26].ToString();
            ChanDoanTuyenDuoi = dv[pos][27].ToString();
            isNoiTru = dv[pos][28].ToString();
            idkhambenhgoc = dv[pos][29].ToString();
            sovaovien = dv[pos][30].ToString();
            IdDieuDuong = dv[pos][31].ToString();
            IsDaRaVien = dv[pos][32].ToString();
            isdathanhtoan = dv[pos][33].ToString();
            tinhtrangtaikham = dv[pos][34].ToString();
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static khambenh Create_khambenh(string sidkhambenh)
        {
            DataTable dt = dtSearchByidkhambenh(sidkhambenh);
            if (dt != null && dt.Rows.Count > 0)
                return new khambenh(dt.DefaultView, 0);
            return null;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        private static string s_Select()
        {
            return " SELECT T.* FROM khambenh AS T";
        }

//───────────────────────────────────────────────────────────────────────────────────────
        private string SQLSelect()
        {
            string sqlselect = " SELECT stt= row_number() over (order by idkhambenh),T.* FROM khambenh AS T WHERE";
            if (maphieukham != null && maphieukham != "")
                sqlselect += " AND maphieukham LIKE N'%" + maphieukham + "%'";
            if (ngaykham != null && ngaykham != "")
                sqlselect += " AND ngaykham LIKE '%" + ngaykham + "%'";
            if (idbenhnhan != null && idbenhnhan != "" && idbenhnhan != "0" && idbenhnhan != "0.0")
                sqlselect += " AND idbenhnhan =" + idbenhnhan;
            if (iddangkykham != null && iddangkykham != "" && iddangkykham != "0" && iddangkykham != "0.0")
                sqlselect += " AND iddangkykham =" + iddangkykham;
            if (idbacsi != null && idbacsi != "" && idbacsi != "0" && idbacsi != "0.0")
                sqlselect += " AND idbacsi =" + idbacsi;
            if (trieuchung != null && trieuchung != "")
                sqlselect += " AND trieuchung LIKE '%" + trieuchung + "%'";
            if (benhsu != null && benhsu != "")
                sqlselect += " AND benhsu LIKE N'%" + benhsu + "%'";
            if (chandoanbandau != null && chandoanbandau != "")
                sqlselect += " AND chandoanbandau LIKE N'%" + chandoanbandau + "%'";
            if (ketluan != null && ketluan != "")
                sqlselect += " AND ketluan LIKE N'%" + ketluan + "%'";
            if (ketluan1 != null && ketluan1 != "")
                sqlselect += " AND ketluan1 LIKE N'%" + ketluan1 + "%'";
            if (ketluan2 != null && ketluan2 != "")
                sqlselect += " AND ketluan2 LIKE N'%" + ketluan2 + "%'";
            if (huongdieutri != null && huongdieutri != "" && huongdieutri != "0" && huongdieutri != "0.0")
                sqlselect += " AND huongdieutri =" + huongdieutri;
            if (phongkhamchuyenden != null && phongkhamchuyenden != "" && phongkhamchuyenden != "0" &&
                phongkhamchuyenden != "0.0")
                sqlselect += " AND phongkhamchuyenden =" + phongkhamchuyenden;
            if (ghichuhuongdieutri != null && ghichuhuongdieutri != "")
                sqlselect += " AND ghichuhuongdieutri LIKE N'%" + ghichuhuongdieutri + "%'";
            if (chidinhbacsi != null && chidinhbacsi != "")
                sqlselect += " AND chidinhbacsi LIKE '%" + chidinhbacsi + "%'";
            if (dando != null && dando != "")
                sqlselect += " AND dando LIKE '%" + dando + "%'";
            if (noidungtaikham != null && noidungtaikham != "")
                sqlselect += " AND noidungtaikham LIKE N'%" + noidungtaikham + "%'";
            if (ngayhentaikham != null && ngayhentaikham != "")
                sqlselect += " AND ngayhentaikham LIKE '%" + ngayhentaikham + "%'";
            if (hoantat != null && hoantat != "" && hoantat != "0" && hoantat != "0.0")
                sqlselect += " AND hoantat =" + hoantat;
            if (idphongkhambenh != null && idphongkhambenh != "" && idphongkhambenh != "0" && idphongkhambenh != "0.0")
                sqlselect += " AND idphongkhambenh =" + idphongkhambenh;
            if (TienSu != null && TienSu != "")
                sqlselect += " AND TienSu LIKE '%" + TienSu + "%'";
            if (SoPhieuTT != null && SoPhieuTT != "")
                sqlselect += " AND SoPhieuTT LIKE N'%" + SoPhieuTT + "%'";
            if (idPhongChuyenDen != null && idPhongChuyenDen != "" && idPhongChuyenDen != "0" &&
                idPhongChuyenDen != "0.0")
                sqlselect += " AND idPhongChuyenDen =" + idPhongChuyenDen;
            if (thuChuyenPhong != null && thuChuyenPhong != "" && thuChuyenPhong != "0" && thuChuyenPhong != "0.0")
                sqlselect += " AND thuChuyenPhong =" + thuChuyenPhong;
            if (idDVPhongChuyenDen != null && idDVPhongChuyenDen != "" && idDVPhongChuyenDen != "0" &&
                idDVPhongChuyenDen != "0.0")
                sqlselect += " AND idDVPhongChuyenDen =" + idDVPhongChuyenDen;
            if (IdChiTietDangKyKham != null && IdChiTietDangKyKham != "" && IdChiTietDangKyKham != "0" &&
                IdChiTietDangKyKham != "0.0")
                sqlselect += " AND IdChiTietDangKyKham =" + IdChiTietDangKyKham;
            if (ChanDoanTuyenDuoi != null && ChanDoanTuyenDuoi != "")
                sqlselect += " AND ChanDoanTuyenDuoi LIKE N'%" + ChanDoanTuyenDuoi + "%'";
            if (isNoiTru != null && isNoiTru != "")
                sqlselect += " AND isNoiTru ='" + isNoiTru + "'";
            if (idkhambenhgoc != null && idkhambenhgoc != "" && idkhambenhgoc != "0" && idkhambenhgoc != "0.0")
                sqlselect += " AND idkhambenhgoc =" + idkhambenhgoc;
            if (sovaovien != null && sovaovien != "")
                sqlselect += " AND sovaovien LIKE N'%" + sovaovien + "%'";
            if (IdDieuDuong != null && IdDieuDuong != "" && IdDieuDuong != "0" && IdDieuDuong != "0.0")
                sqlselect += " AND IdDieuDuong =" + IdDieuDuong;
            if (IsDaRaVien != null && IsDaRaVien != "")
                sqlselect += " AND IsDaRaVien ='" + IsDaRaVien + "'";
            if (isdathanhtoan != null && isdathanhtoan != "")
                sqlselect += " AND isdathanhtoan ='" + isdathanhtoan + "'";
            if (tinhtrangtaikham != null && tinhtrangtaikham != "" && tinhtrangtaikham != "0" &&
                tinhtrangtaikham != "0.0")
                sqlselect += " AND tinhtrangtaikham =" + tinhtrangtaikham;
            sqlselect = sqlselect.Replace("WHERE AND", "WHERE");
            int n = sqlselect.IndexOf("WHERE");
            if (n == sqlselect.Length - 5) sqlselect = sqlselect.Remove(n, 5);
            return sqlselect;
        }

//───────────────────────────────────────────────────────────────────────────────────────

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidkhambenh(string sidkhambenh)
        {
            string sqlSelect = s_Select() + " WHERE idkhambenh  =" + sidkhambenh + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidkhambenh(string sidkhambenh, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE idkhambenh" + sMatch + sidkhambenh + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBymaphieukham(string smaphieukham)
        {
            string sqlSelect = s_Select() + " WHERE maphieukham  Like N'%" + smaphieukham + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByngaykham(string sngaykham)
        {
            string sqlSelect = s_Select() + " WHERE ngaykham  =" + sngaykham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByngaykham(string sngaykham, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE ngaykham" + sMatch + sngaykham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidbenhnhan(string sidbenhnhan)
        {
            string sqlSelect = s_Select() + " WHERE idbenhnhan  =" + sidbenhnhan + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidbenhnhan(string sidbenhnhan, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE idbenhnhan" + sMatch + sidbenhnhan + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByiddangkykham(string siddangkykham)
        {
            string sqlSelect = s_Select() + " WHERE iddangkykham  =" + siddangkykham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByiddangkykham(string siddangkykham, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE iddangkykham" + sMatch + siddangkykham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidbacsi(string sidbacsi)
        {
            string sqlSelect = s_Select() + " WHERE idbacsi  =" + sidbacsi + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidbacsi(string sidbacsi, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE idbacsi" + sMatch + sidbacsi + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBytrieuchung(string strieuchung)
        {
            string sqlSelect = s_Select() + " WHERE trieuchung  Like '%" + strieuchung + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBybenhsu(string sbenhsu)
        {
            string sqlSelect = s_Select() + " WHERE benhsu  Like N'%" + sbenhsu + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBychandoanbandau(string schandoanbandau)
        {
            string sqlSelect = s_Select() + " WHERE chandoanbandau  Like N'%" + schandoanbandau + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByketluan(string sketluan)
        {
            string sqlSelect = s_Select() + " WHERE ketluan  Like N'%" + sketluan + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByketluan1(string sketluan1)
        {
            string sqlSelect = s_Select() + " WHERE ketluan1  Like N'%" + sketluan1 + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByketluan2(string sketluan2)
        {
            string sqlSelect = s_Select() + " WHERE ketluan2  Like N'%" + sketluan2 + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByhuongdieutri(string shuongdieutri)
        {
            string sqlSelect = s_Select() + " WHERE huongdieutri  =" + shuongdieutri + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByhuongdieutri(string shuongdieutri, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE huongdieutri" + sMatch + shuongdieutri + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByphongkhamchuyenden(string sphongkhamchuyenden)
        {
            string sqlSelect = s_Select() + " WHERE phongkhamchuyenden  =" + sphongkhamchuyenden + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByphongkhamchuyenden(string sphongkhamchuyenden, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE phongkhamchuyenden" + sMatch + sphongkhamchuyenden + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByghichuhuongdieutri(string sghichuhuongdieutri)
        {
            string sqlSelect = s_Select() + " WHERE ghichuhuongdieutri  Like N'%" + sghichuhuongdieutri + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBychidinhbacsi(string schidinhbacsi)
        {
            string sqlSelect = s_Select() + " WHERE chidinhbacsi  Like '%" + schidinhbacsi + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBydando(string sdando)
        {
            string sqlSelect = s_Select() + " WHERE dando  Like '%" + sdando + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBynoidungtaikham(string snoidungtaikham)
        {
            string sqlSelect = s_Select() + " WHERE noidungtaikham  Like N'%" + snoidungtaikham + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByngayhentaikham(string sngayhentaikham)
        {
            string sqlSelect = s_Select() + " WHERE ngayhentaikham  =" + sngayhentaikham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByngayhentaikham(string sngayhentaikham, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE ngayhentaikham" + sMatch + sngayhentaikham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByhoantat(string shoantat)
        {
            string sqlSelect = s_Select() + " WHERE hoantat  =" + shoantat + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByhoantat(string shoantat, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE hoantat" + sMatch + shoantat + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidphongkhambenh(string sidphongkhambenh)
        {
            string sqlSelect = s_Select() + " WHERE idphongkhambenh  =" + sidphongkhambenh + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidphongkhambenh(string sidphongkhambenh, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE idphongkhambenh" + sMatch + sidphongkhambenh + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByTienSu(string sTienSu)
        {
            string sqlSelect = s_Select() + " WHERE TienSu  Like '%" + sTienSu + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBySoPhieuTT(string sSoPhieuTT)
        {
            string sqlSelect = s_Select() + " WHERE SoPhieuTT  Like N'%" + sSoPhieuTT + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidPhongChuyenDen(string sidPhongChuyenDen)
        {
            string sqlSelect = s_Select() + " WHERE idPhongChuyenDen  =" + sidPhongChuyenDen + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidPhongChuyenDen(string sidPhongChuyenDen, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE idPhongChuyenDen" + sMatch + sidPhongChuyenDen + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBythuChuyenPhong(string sthuChuyenPhong)
        {
            string sqlSelect = s_Select() + " WHERE thuChuyenPhong  =" + sthuChuyenPhong + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBythuChuyenPhong(string sthuChuyenPhong, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE thuChuyenPhong" + sMatch + sthuChuyenPhong + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidDVPhongChuyenDen(string sidDVPhongChuyenDen)
        {
            string sqlSelect = s_Select() + " WHERE idDVPhongChuyenDen  =" + sidDVPhongChuyenDen + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidDVPhongChuyenDen(string sidDVPhongChuyenDen, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE idDVPhongChuyenDen" + sMatch + sidDVPhongChuyenDen + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdChiTietDangKyKham(string sIdChiTietDangKyKham)
        {
            string sqlSelect = s_Select() + " WHERE IdChiTietDangKyKham  =" + sIdChiTietDangKyKham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdChiTietDangKyKham(string sIdChiTietDangKyKham, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IdChiTietDangKyKham" + sMatch + sIdChiTietDangKyKham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByChanDoanTuyenDuoi(string sChanDoanTuyenDuoi)
        {
            string sqlSelect = s_Select() + " WHERE ChanDoanTuyenDuoi  Like N'%" + sChanDoanTuyenDuoi + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByisNoiTru(string sisNoiTru)
        {
            string sqlSelect = s_Select() + " WHERE isNoiTru  =" + sisNoiTru + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByisNoiTru(string sisNoiTru, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE isNoiTru" + sMatch + sisNoiTru + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidkhambenhgoc(string sidkhambenhgoc)
        {
            string sqlSelect = s_Select() + " WHERE idkhambenhgoc  =" + sidkhambenhgoc + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByidkhambenhgoc(string sidkhambenhgoc, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE idkhambenhgoc" + sMatch + sidkhambenhgoc + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBysovaovien(string ssovaovien)
        {
            string sqlSelect = s_Select() + " WHERE sovaovien  Like N'%" + ssovaovien + "%'";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdDieuDuong(string sIdDieuDuong)
        {
            string sqlSelect = s_Select() + " WHERE IdDieuDuong  =" + sIdDieuDuong + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIdDieuDuong(string sIdDieuDuong, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IdDieuDuong" + sMatch + sIdDieuDuong + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsDaRaVien(string sIsDaRaVien)
        {
            string sqlSelect = s_Select() + " WHERE IsDaRaVien  =" + sIsDaRaVien + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByIsDaRaVien(string sIsDaRaVien, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE IsDaRaVien" + sMatch + sIsDaRaVien + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByisdathanhtoan(string sisdathanhtoan)
        {
            string sqlSelect = s_Select() + " WHERE isdathanhtoan  =" + sisdathanhtoan + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchByisdathanhtoan(string sisdathanhtoan, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE isdathanhtoan" + sMatch + sisdathanhtoan + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBytinhtrangtaikham(string stinhtrangtaikham)
        {
            string sqlSelect = s_Select() + " WHERE tinhtrangtaikham  =" + stinhtrangtaikham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearchBytinhtrangtaikham(string stinhtrangtaikham, string sMatch)
        {
            string sqlSelect = s_Select() + " WHERE tinhtrangtaikham" + sMatch + stinhtrangtaikham + "";
            DataTable dt = GetTable(sqlSelect);
            return dt;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static DataTable dtSearch(string sidkhambenh
                                         , string smaphieukham
                                         , string sngaykham
                                         , string sidbenhnhan
                                         , string siddangkykham
                                         , string sidbacsi
                                         , string strieuchung
                                         , string sbenhsu
                                         , string schandoanbandau
                                         , string sketluan
                                         , string sketluan1
                                         , string sketluan2
                                         , string shuongdieutri
                                         , string sphongkhamchuyenden
                                         , string sghichuhuongdieutri
                                         , string schidinhbacsi
                                         , string sdando
                                         , string snoidungtaikham
                                         , string sngayhentaikham
                                         , string shoantat
                                         , string sidphongkhambenh
                                         , string sTienSu
                                         , string sSoPhieuTT
                                         , string sidPhongChuyenDen
                                         , string sthuChuyenPhong
                                         , string sidDVPhongChuyenDen
                                         , string sIdChiTietDangKyKham
                                         , string sChanDoanTuyenDuoi
                                         , string sisNoiTru
                                         , string sidkhambenhgoc
                                         , string ssovaovien
                                         , string sIdDieuDuong
                                         , string sIsDaRaVien
                                         , string sisdathanhtoan
                                         , string stinhtrangtaikham
            )
        {
            string sqlselect = s_Select() + " WHERE";
            if (sidkhambenh != null && sidkhambenh != "")
                sqlselect += " AND idkhambenh =" + sidkhambenh;
            if (smaphieukham != null && smaphieukham != "")
                sqlselect += " AND maphieukham LIKE N'%" + smaphieukham + "%'";
            if (sngaykham != null && sngaykham != "")
                sqlselect += " AND ngaykham LIKE '%" + sngaykham + "%'";
            if (sidbenhnhan != null && sidbenhnhan != "")
                sqlselect += " AND idbenhnhan =" + sidbenhnhan;
            if (siddangkykham != null && siddangkykham != "")
                sqlselect += " AND iddangkykham =" + siddangkykham;
            if (sidbacsi != null && sidbacsi != "")
                sqlselect += " AND idbacsi =" + sidbacsi;
            if (strieuchung != null && strieuchung != "")
                sqlselect += " AND trieuchung LIKE '%" + strieuchung + "%'";
            if (sbenhsu != null && sbenhsu != "")
                sqlselect += " AND benhsu LIKE N'%" + sbenhsu + "%'";
            if (schandoanbandau != null && schandoanbandau != "")
                sqlselect += " AND chandoanbandau LIKE N'%" + schandoanbandau + "%'";
            if (sketluan != null && sketluan != "")
                sqlselect += " AND ketluan LIKE N'%" + sketluan + "%'";
            if (sketluan1 != null && sketluan1 != "")
                sqlselect += " AND ketluan1 LIKE N'%" + sketluan1 + "%'";
            if (sketluan2 != null && sketluan2 != "")
                sqlselect += " AND ketluan2 LIKE N'%" + sketluan2 + "%'";
            if (shuongdieutri != null && shuongdieutri != "")
                sqlselect += " AND huongdieutri =" + shuongdieutri;
            if (sphongkhamchuyenden != null && sphongkhamchuyenden != "")
                sqlselect += " AND phongkhamchuyenden =" + sphongkhamchuyenden;
            if (sghichuhuongdieutri != null && sghichuhuongdieutri != "")
                sqlselect += " AND ghichuhuongdieutri LIKE N'%" + sghichuhuongdieutri + "%'";
            if (schidinhbacsi != null && schidinhbacsi != "")
                sqlselect += " AND chidinhbacsi LIKE '%" + schidinhbacsi + "%'";
            if (sdando != null && sdando != "")
                sqlselect += " AND dando LIKE '%" + sdando + "%'";
            if (snoidungtaikham != null && snoidungtaikham != "")
                sqlselect += " AND noidungtaikham LIKE N'%" + snoidungtaikham + "%'";
            if (sngayhentaikham != null && sngayhentaikham != "")
                sqlselect += " AND ngayhentaikham LIKE '%" + sngayhentaikham + "%'";
            if (shoantat != null && shoantat != "")
                sqlselect += " AND hoantat =" + shoantat;
            if (sidphongkhambenh != null && sidphongkhambenh != "")
                sqlselect += " AND idphongkhambenh =" + sidphongkhambenh;
            if (sTienSu != null && sTienSu != "")
                sqlselect += " AND TienSu LIKE '%" + sTienSu + "%'";
            if (sSoPhieuTT != null && sSoPhieuTT != "")
                sqlselect += " AND SoPhieuTT LIKE N'%" + sSoPhieuTT + "%'";
            if (sidPhongChuyenDen != null && sidPhongChuyenDen != "")
                sqlselect += " AND idPhongChuyenDen =" + sidPhongChuyenDen;
            if (sthuChuyenPhong != null && sthuChuyenPhong != "")
                sqlselect += " AND thuChuyenPhong =" + sthuChuyenPhong;
            if (sidDVPhongChuyenDen != null && sidDVPhongChuyenDen != "")
                sqlselect += " AND idDVPhongChuyenDen =" + sidDVPhongChuyenDen;
            if (sIdChiTietDangKyKham != null && sIdChiTietDangKyKham != "")
                sqlselect += " AND IdChiTietDangKyKham =" + sIdChiTietDangKyKham;
            if (sChanDoanTuyenDuoi != null && sChanDoanTuyenDuoi != "")
                sqlselect += " AND ChanDoanTuyenDuoi LIKE N'%" + sChanDoanTuyenDuoi + "%'";
            if (sisNoiTru != null && sisNoiTru != "")
                sqlselect += " AND isNoiTru =" + sisNoiTru;
            if (sidkhambenhgoc != null && sidkhambenhgoc != "")
                sqlselect += " AND idkhambenhgoc =" + sidkhambenhgoc;
            if (ssovaovien != null && ssovaovien != "")
                sqlselect += " AND sovaovien LIKE N'%" + ssovaovien + "%'";
            if (sIdDieuDuong != null && sIdDieuDuong != "")
                sqlselect += " AND IdDieuDuong =" + sIdDieuDuong;
            if (sIsDaRaVien != null && sIsDaRaVien != "")
                sqlselect += " AND IsDaRaVien =" + sIsDaRaVien;
            if (sisdathanhtoan != null && sisdathanhtoan != "")
                sqlselect += " AND isdathanhtoan =" + sisdathanhtoan;
            if (stinhtrangtaikham != null && stinhtrangtaikham != "")
                sqlselect += " AND tinhtrangtaikham =" + stinhtrangtaikham;
            sqlselect = sqlselect.Replace("WHERE AND", "WHERE");
            int n = sqlselect.IndexOf("WHERE");
            if (n == sqlselect.Length - 5) sqlselect = sqlselect.Remove(n, 5);
            return GetTable(sqlselect);
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public DataTable dtSearch()
        {
            if (page == null || page == "")
                page = "1";
            if (numberRow == null || numberRow == "")
                numberRow = "100";

            string sql = "select * from(" + SQLSelect() + ") abc where stt between (" + page + "-1)*" + numberRow +
                         "+1 and " + page + " * " + numberRow;
            return GetTable(sql);
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public string Paging()
        {
            int sumRow = GetTable(SQLSelect()).Rows.Count;

            if (page == null || page == "")
                page = "1";
            if (numberRow == null || numberRow == "")
                numberRow = "100";

            int sodongpaging = sumRow/int.Parse(numberRow);
            int sodongdu = sumRow%int.Parse(numberRow);
            if (sodongdu != 0)
            {
                sodongpaging = sodongpaging + 1;
            }
            string html = "";
            html += "<div style='padding-bottom:20px;width:90%;margin:auto;display:table'>";
            for (int i = 1; i <= sodongpaging; i++)
            {
                if (int.Parse(page) != i)
                {
                    html +=
                        "<a style='float:left;color:green;cursor:pointer;padding-Left:5px;padding-Right:5px;text-decoration:underline' onclick=\"Find(this,'" +
                        i + "')\">" + i + "</a>";
                }
                else
                {
                    html += "<span style='float:left;color:red'>" + i + "</span>";
                }
            }
            html += "</div>";
            return html;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static khambenh Insert_Object(
            string smaphieukham
            , string sngaykham
            , string sidbenhnhan
            , string siddangkykham
            , string sidbacsi
            , string strieuchung
            , string sbenhsu
            , string schandoanbandau
            , string sketluan
            , string sketluan1
            , string sketluan2
            , string shuongdieutri
            , string sphongkhamchuyenden
            , string sghichuhuongdieutri
            , string schidinhbacsi
            , string sdando
            , string snoidungtaikham
            , string sngayhentaikham
            , string shoantat
            , string sidphongkhambenh
            , string sTienSu
            , string sSoPhieuTT
            , string sidPhongChuyenDen
            , string sthuChuyenPhong
            , string sidDVPhongChuyenDen
            , string sIdChiTietDangKyKham
            , string sChanDoanTuyenDuoi
            , string sisNoiTru
            , string sidkhambenhgoc
            , string ssovaovien
            , string sIdDieuDuong
            , string sIsDaRaVien
            , string sisdathanhtoan
            , string stinhtrangtaikham
            )
        {
            string tem_smaphieukham = hsSqlTool.sGetSaveValue(smaphieukham, "nvarchar");
            string tem_sngaykham = hsSqlTool.sGetSaveValue(sngaykham, "datetime");
            string tem_sidbenhnhan = hsSqlTool.sGetSaveValue(sidbenhnhan, "int");
            string tem_siddangkykham = hsSqlTool.sGetSaveValue(siddangkykham, "int");
            string tem_sidbacsi = hsSqlTool.sGetSaveValue(sidbacsi, "int");
            string tem_strieuchung = hsSqlTool.sGetSaveValue(strieuchung, "ntext");
            string tem_sbenhsu = hsSqlTool.sGetSaveValue(sbenhsu, "nvarchar");
            string tem_schandoanbandau = hsSqlTool.sGetSaveValue(schandoanbandau, "nvarchar");
            string tem_sketluan = hsSqlTool.sGetSaveValue(sketluan, "varchar");
            string tem_sketluan1 = hsSqlTool.sGetSaveValue(sketluan1, "varchar");
            string tem_sketluan2 = hsSqlTool.sGetSaveValue(sketluan2, "varchar");
            string tem_shuongdieutri = hsSqlTool.sGetSaveValue(shuongdieutri, "tinyint");
            string tem_sphongkhamchuyenden = hsSqlTool.sGetSaveValue(sphongkhamchuyenden, "int");
            string tem_sghichuhuongdieutri = hsSqlTool.sGetSaveValue(sghichuhuongdieutri, "nvarchar");
            string tem_schidinhbacsi = hsSqlTool.sGetSaveValue(schidinhbacsi, "ntext");
            string tem_sdando = hsSqlTool.sGetSaveValue(sdando, "ntext");
            string tem_snoidungtaikham = hsSqlTool.sGetSaveValue(snoidungtaikham, "nvarchar");
            string tem_sngayhentaikham = hsSqlTool.sGetSaveValue(sngayhentaikham, "smalldatetime");
            string tem_shoantat = hsSqlTool.sGetSaveValue(shoantat, "tinyint");
            string tem_sidphongkhambenh = hsSqlTool.sGetSaveValue(sidphongkhambenh, "int");
            string tem_sTienSu = hsSqlTool.sGetSaveValue(sTienSu, "ntext");
            string tem_sSoPhieuTT = hsSqlTool.sGetSaveValue(sSoPhieuTT, "nvarchar");
            string tem_sidPhongChuyenDen = hsSqlTool.sGetSaveValue(sidPhongChuyenDen, "int");
            string tem_sthuChuyenPhong = hsSqlTool.sGetSaveValue(sthuChuyenPhong, "int");
            string tem_sidDVPhongChuyenDen = hsSqlTool.sGetSaveValue(sidDVPhongChuyenDen, "int");
            string tem_sIdChiTietDangKyKham = hsSqlTool.sGetSaveValue(sIdChiTietDangKyKham, "bigint");
            string tem_sChanDoanTuyenDuoi = hsSqlTool.sGetSaveValue(sChanDoanTuyenDuoi, "nvarchar");
            string tem_sisNoiTru = hsSqlTool.sGetSaveValue(sisNoiTru, "bit");
            string tem_sidkhambenhgoc = hsSqlTool.sGetSaveValue(sidkhambenhgoc, "bigint");
            string tem_ssovaovien = hsSqlTool.sGetSaveValue(ssovaovien, "nvarchar");
            string tem_sIdDieuDuong = hsSqlTool.sGetSaveValue(sIdDieuDuong, "bigint");
            string tem_sIsDaRaVien = hsSqlTool.sGetSaveValue(sIsDaRaVien, "bit");
            string tem_sisdathanhtoan = hsSqlTool.sGetSaveValue(sisdathanhtoan, "bit");
            string tem_stinhtrangtaikham = hsSqlTool.sGetSaveValue(stinhtrangtaikham, "int");

            string sqlSave = " INSERT INTO khambenh(" +
                             "maphieukham,"
                             + "ngaykham,"
                             + "idbenhnhan,"
                             + "iddangkykham,"
                             + "idbacsi,"
                             + "trieuchung,"
                             + "benhsu,"
                             + "chandoanbandau,"
                             + "ketluan,"
                             + "ketluan1,"
                             + "ketluan2,"
                             + "huongdieutri,"
                             + "phongkhamchuyenden,"
                             + "ghichuhuongdieutri,"
                             + "chidinhbacsi,"
                             + "dando,"
                             + "noidungtaikham,"
                             + "ngayhentaikham,"
                             + "hoantat,"
                             + "idphongkhambenh,"
                             + "TienSu,"
                             + "SoPhieuTT,"
                             + "idPhongChuyenDen,"
                             + "thuChuyenPhong,"
                             + "idDVPhongChuyenDen,"
                             + "IdChiTietDangKyKham,"
                             + "ChanDoanTuyenDuoi,"
                             + "isNoiTru,"
                             + "idkhambenhgoc,"
                             + "sovaovien,"
                             + "IdDieuDuong,"
                             + "IsDaRaVien,"
                             + "isdathanhtoan,"
                             + "tinhtrangtaikham) VALUES("
                             + tem_smaphieukham + ","
                             + tem_sngaykham + ","
                             + tem_sidbenhnhan + ","
                             + tem_siddangkykham + ","
                             + tem_sidbacsi + ","
                             + tem_strieuchung + ","
                             + tem_sbenhsu + ","
                             + tem_schandoanbandau + ","
                             + tem_sketluan + ","
                             + tem_sketluan1 + ","
                             + tem_sketluan2 + ","
                             + tem_shuongdieutri + ","
                             + tem_sphongkhamchuyenden + ","
                             + tem_sghichuhuongdieutri + ","
                             + tem_schidinhbacsi + ","
                             + tem_sdando + ","
                             + tem_snoidungtaikham + ","
                             + tem_sngayhentaikham + ","
                             + tem_shoantat + ","
                             + tem_sidphongkhambenh + ","
                             + tem_sTienSu + ","
                             + tem_sSoPhieuTT + ","
                             + tem_sidPhongChuyenDen + ","
                             + tem_sthuChuyenPhong + ","
                             + tem_sidDVPhongChuyenDen + ","
                             + tem_sIdChiTietDangKyKham + ","
                             + tem_sChanDoanTuyenDuoi + ","
                             + tem_sisNoiTru + ","
                             + tem_sidkhambenhgoc + ","
                             + tem_ssovaovien + ","
                             + tem_sIdDieuDuong + ","
                             + tem_sIsDaRaVien + ","
                             + tem_sisdathanhtoan + ","
                             + tem_stinhtrangtaikham + ")";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                khambenh newkhambenh = new khambenh();
                newkhambenh.idkhambenh =
                    GetTable(" SELECT TOP 1 idkhambenh FROM khambenh ORDER BY idkhambenh DESC ").Rows[0][0].ToString();
                newkhambenh.maphieukham = smaphieukham;
                newkhambenh.ngaykham = sngaykham;
                newkhambenh.idbenhnhan = sidbenhnhan;
                newkhambenh.iddangkykham = siddangkykham;
                newkhambenh.idbacsi = sidbacsi;
                newkhambenh.trieuchung = strieuchung;
                newkhambenh.benhsu = sbenhsu;
                newkhambenh.chandoanbandau = schandoanbandau;
                newkhambenh.ketluan = sketluan;
                newkhambenh.ketluan1 = sketluan1;
                newkhambenh.ketluan2 = sketluan2;
                newkhambenh.huongdieutri = shuongdieutri;
                newkhambenh.phongkhamchuyenden = sphongkhamchuyenden;
                newkhambenh.ghichuhuongdieutri = sghichuhuongdieutri;
                newkhambenh.chidinhbacsi = schidinhbacsi;
                newkhambenh.dando = sdando;
                newkhambenh.noidungtaikham = snoidungtaikham;
                newkhambenh.ngayhentaikham = sngayhentaikham;
                newkhambenh.hoantat = shoantat;
                newkhambenh.idphongkhambenh = sidphongkhambenh;
                newkhambenh.TienSu = sTienSu;
                newkhambenh.SoPhieuTT = sSoPhieuTT;
                newkhambenh.idPhongChuyenDen = sidPhongChuyenDen;
                newkhambenh.thuChuyenPhong = sthuChuyenPhong;
                newkhambenh.idDVPhongChuyenDen = sidDVPhongChuyenDen;
                newkhambenh.IdChiTietDangKyKham = sIdChiTietDangKyKham;
                newkhambenh.ChanDoanTuyenDuoi = sChanDoanTuyenDuoi;
                newkhambenh.isNoiTru = sisNoiTru;
                newkhambenh.idkhambenhgoc = sidkhambenhgoc;
                newkhambenh.sovaovien = ssovaovien;
                newkhambenh.IdDieuDuong = sIdDieuDuong;
                newkhambenh.IsDaRaVien = sIsDaRaVien;
                newkhambenh.isdathanhtoan = sisdathanhtoan;
                newkhambenh.tinhtrangtaikham = stinhtrangtaikham;
                return newkhambenh;
            }
            else return null;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public khambenh Insert_Object()
        {
            string tem_smaphieukham = hsSqlTool.sGetSaveValue(maphieukham, "nvarchar");
            string tem_sngaykham = hsSqlTool.sGetSaveValue(ngaykham, "datetime");
            string tem_sidbenhnhan = hsSqlTool.sGetSaveValue(idbenhnhan, "int");
            string tem_siddangkykham = hsSqlTool.sGetSaveValue(iddangkykham, "int");
            string tem_sidbacsi = hsSqlTool.sGetSaveValue(idbacsi, "int");
            string tem_strieuchung = hsSqlTool.sGetSaveValue(trieuchung, "ntext");
            string tem_sbenhsu = hsSqlTool.sGetSaveValue(benhsu, "nvarchar");
            string tem_schandoanbandau = hsSqlTool.sGetSaveValue(chandoanbandau, "nvarchar");
            string tem_sketluan = hsSqlTool.sGetSaveValue(ketluan, "varchar");
            string tem_sketluan1 = hsSqlTool.sGetSaveValue(ketluan1, "varchar");
            string tem_sketluan2 = hsSqlTool.sGetSaveValue(ketluan2, "varchar");
            string tem_shuongdieutri = hsSqlTool.sGetSaveValue(huongdieutri, "tinyint");
            string tem_sphongkhamchuyenden = hsSqlTool.sGetSaveValue(phongkhamchuyenden, "int");
            string tem_sghichuhuongdieutri = hsSqlTool.sGetSaveValue(ghichuhuongdieutri, "nvarchar");
            string tem_schidinhbacsi = hsSqlTool.sGetSaveValue(chidinhbacsi, "ntext");
            string tem_sdando = hsSqlTool.sGetSaveValue(dando, "ntext");
            string tem_snoidungtaikham = hsSqlTool.sGetSaveValue(noidungtaikham, "nvarchar");
            string tem_sngayhentaikham = hsSqlTool.sGetSaveValue(ngayhentaikham, "smalldatetime");
            string tem_shoantat = hsSqlTool.sGetSaveValue(hoantat, "tinyint");
            string tem_sidphongkhambenh = hsSqlTool.sGetSaveValue(idphongkhambenh, "int");
            string tem_sTienSu = hsSqlTool.sGetSaveValue(TienSu, "ntext");
            string tem_sSoPhieuTT = hsSqlTool.sGetSaveValue(SoPhieuTT, "nvarchar");
            string tem_sidPhongChuyenDen = hsSqlTool.sGetSaveValue(idPhongChuyenDen, "int");
            string tem_sthuChuyenPhong = hsSqlTool.sGetSaveValue(thuChuyenPhong, "int");
            string tem_sidDVPhongChuyenDen = hsSqlTool.sGetSaveValue(idDVPhongChuyenDen, "int");
            string tem_sIdChiTietDangKyKham = hsSqlTool.sGetSaveValue(IdChiTietDangKyKham, "bigint");
            string tem_sChanDoanTuyenDuoi = hsSqlTool.sGetSaveValue(ChanDoanTuyenDuoi, "nvarchar");
            string tem_sisNoiTru = hsSqlTool.sGetSaveValue(isNoiTru, "bit");
            string tem_sidkhambenhgoc = hsSqlTool.sGetSaveValue(idkhambenhgoc, "bigint");
            string tem_ssovaovien = hsSqlTool.sGetSaveValue(sovaovien, "nvarchar");
            string tem_sIdDieuDuong = hsSqlTool.sGetSaveValue(IdDieuDuong, "bigint");
            string tem_sIsDaRaVien = hsSqlTool.sGetSaveValue(IsDaRaVien, "bit");
            string tem_sisdathanhtoan = hsSqlTool.sGetSaveValue(isdathanhtoan, "bit");
            string tem_stinhtrangtaikham = hsSqlTool.sGetSaveValue(tinhtrangtaikham, "int");

            string sqlSave = " INSERT INTO khambenh(" +
                             "maphieukham,"
                             + "ngaykham,"
                             + "idbenhnhan,"
                             + "iddangkykham,"
                             + "idbacsi,"
                             + "trieuchung,"
                             + "benhsu,"
                             + "chandoanbandau,"
                             + "ketluan,"
                             + "ketluan1,"
                             + "ketluan2,"
                             + "huongdieutri,"
                             + "phongkhamchuyenden,"
                             + "ghichuhuongdieutri,"
                             + "chidinhbacsi,"
                             + "dando,"
                             + "noidungtaikham,"
                             + "ngayhentaikham,"
                             + "hoantat,"
                             + "idphongkhambenh,"
                             + "TienSu,"
                             + "SoPhieuTT,"
                             + "idPhongChuyenDen,"
                             + "thuChuyenPhong,"
                             + "idDVPhongChuyenDen,"
                             + "IdChiTietDangKyKham,"
                             + "ChanDoanTuyenDuoi,"
                             + "isNoiTru,"
                             + "idkhambenhgoc,"
                             + "sovaovien,"
                             + "IdDieuDuong,"
                             + "IsDaRaVien,"
                             + "isdathanhtoan,"
                             + "tinhtrangtaikham) VALUES("
                             + tem_smaphieukham + ","
                             + tem_sngaykham + ","
                             + tem_sidbenhnhan + ","
                             + tem_siddangkykham + ","
                             + tem_sidbacsi + ","
                             + tem_strieuchung + ","
                             + tem_sbenhsu + ","
                             + tem_schandoanbandau + ","
                             + tem_sketluan + ","
                             + tem_sketluan1 + ","
                             + tem_sketluan2 + ","
                             + tem_shuongdieutri + ","
                             + tem_sphongkhamchuyenden + ","
                             + tem_sghichuhuongdieutri + ","
                             + tem_schidinhbacsi + ","
                             + tem_sdando + ","
                             + tem_snoidungtaikham + ","
                             + tem_sngayhentaikham + ","
                             + tem_shoantat + ","
                             + tem_sidphongkhambenh + ","
                             + tem_sTienSu + ","
                             + tem_sSoPhieuTT + ","
                             + tem_sidPhongChuyenDen + ","
                             + tem_sthuChuyenPhong + ","
                             + tem_sidDVPhongChuyenDen + ","
                             + tem_sIdChiTietDangKyKham + ","
                             + tem_sChanDoanTuyenDuoi + ","
                             + tem_sisNoiTru + ","
                             + tem_sidkhambenhgoc + ","
                             + tem_ssovaovien + ","
                             + tem_sIdDieuDuong + ","
                             + tem_sIsDaRaVien + ","
                             + tem_sisdathanhtoan + ","
                             + tem_stinhtrangtaikham + ")";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                khambenh newkhambenh = new khambenh();
                newkhambenh.idkhambenh =
                    GetTable(" SELECT TOP 1 idkhambenh FROM khambenh ORDER BY idkhambenh DESC ").Rows[0][0].ToString();
                newkhambenh.maphieukham = maphieukham;
                newkhambenh.ngaykham = ngaykham;
                newkhambenh.idbenhnhan = idbenhnhan;
                newkhambenh.iddangkykham = iddangkykham;
                newkhambenh.idbacsi = idbacsi;
                newkhambenh.trieuchung = trieuchung;
                newkhambenh.benhsu = benhsu;
                newkhambenh.chandoanbandau = chandoanbandau;
                newkhambenh.ketluan = ketluan;
                newkhambenh.ketluan1 = ketluan1;
                newkhambenh.ketluan2 = ketluan2;
                newkhambenh.huongdieutri = huongdieutri;
                newkhambenh.phongkhamchuyenden = phongkhamchuyenden;
                newkhambenh.ghichuhuongdieutri = ghichuhuongdieutri;
                newkhambenh.chidinhbacsi = chidinhbacsi;
                newkhambenh.dando = dando;
                newkhambenh.noidungtaikham = noidungtaikham;
                newkhambenh.ngayhentaikham = ngayhentaikham;
                newkhambenh.hoantat = hoantat;
                newkhambenh.idphongkhambenh = idphongkhambenh;
                newkhambenh.TienSu = TienSu;
                newkhambenh.SoPhieuTT = SoPhieuTT;
                newkhambenh.idPhongChuyenDen = idPhongChuyenDen;
                newkhambenh.thuChuyenPhong = thuChuyenPhong;
                newkhambenh.idDVPhongChuyenDen = idDVPhongChuyenDen;
                newkhambenh.IdChiTietDangKyKham = IdChiTietDangKyKham;
                newkhambenh.ChanDoanTuyenDuoi = ChanDoanTuyenDuoi;
                newkhambenh.isNoiTru = isNoiTru;
                newkhambenh.idkhambenhgoc = idkhambenhgoc;
                newkhambenh.sovaovien = sovaovien;
                newkhambenh.IdDieuDuong = IdDieuDuong;
                newkhambenh.IsDaRaVien = IsDaRaVien;
                newkhambenh.isdathanhtoan = isdathanhtoan;
                newkhambenh.tinhtrangtaikham = tinhtrangtaikham;
                return newkhambenh;
            }
            else return null;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Save_Object(string smaphieukham
                                , string sngaykham
                                , string sidbenhnhan
                                , string siddangkykham
                                , string sidbacsi
                                , string strieuchung
                                , string sbenhsu
                                , string schandoanbandau
                                , string sketluan
                                , string sketluan1
                                , string sketluan2
                                , string shuongdieutri
                                , string sphongkhamchuyenden
                                , string sghichuhuongdieutri
                                , string schidinhbacsi
                                , string sdando
                                , string snoidungtaikham
                                , string sngayhentaikham
                                , string shoantat
                                , string sidphongkhambenh
                                , string sTienSu
                                , string sSoPhieuTT
                                , string sidPhongChuyenDen
                                , string sthuChuyenPhong
                                , string sidDVPhongChuyenDen
                                , string sIdChiTietDangKyKham
                                , string sChanDoanTuyenDuoi
                                , string sisNoiTru
                                , string sidkhambenhgoc
                                , string ssovaovien
                                , string sIdDieuDuong
                                , string sIsDaRaVien
                                , string sisdathanhtoan
                                , string stinhtrangtaikham
            )
        {
            string tem_smaphieukham = hsSqlTool.sGetSaveValue(smaphieukham, "nvarchar");
            string tem_sngaykham = hsSqlTool.sGetSaveValue(sngaykham, "datetime");
            string tem_sidbenhnhan = hsSqlTool.sGetSaveValue(sidbenhnhan, "int");
            string tem_siddangkykham = hsSqlTool.sGetSaveValue(siddangkykham, "int");
            string tem_sidbacsi = hsSqlTool.sGetSaveValue(sidbacsi, "int");
            string tem_strieuchung = hsSqlTool.sGetSaveValue(strieuchung, "ntext");
            string tem_sbenhsu = hsSqlTool.sGetSaveValue(sbenhsu, "nvarchar");
            string tem_schandoanbandau = hsSqlTool.sGetSaveValue(schandoanbandau, "nvarchar");
            string tem_sketluan = hsSqlTool.sGetSaveValue(sketluan, "varchar");
            string tem_sketluan1 = hsSqlTool.sGetSaveValue(sketluan1, "varchar");
            string tem_sketluan2 = hsSqlTool.sGetSaveValue(sketluan2, "varchar");
            string tem_shuongdieutri = hsSqlTool.sGetSaveValue(shuongdieutri, "tinyint");
            string tem_sphongkhamchuyenden = hsSqlTool.sGetSaveValue(sphongkhamchuyenden, "int");
            string tem_sghichuhuongdieutri = hsSqlTool.sGetSaveValue(sghichuhuongdieutri, "nvarchar");
            string tem_schidinhbacsi = hsSqlTool.sGetSaveValue(schidinhbacsi, "ntext");
            string tem_sdando = hsSqlTool.sGetSaveValue(sdando, "ntext");
            string tem_snoidungtaikham = hsSqlTool.sGetSaveValue(snoidungtaikham, "nvarchar");
            string tem_sngayhentaikham = hsSqlTool.sGetSaveValue(sngayhentaikham, "smalldatetime");
            string tem_shoantat = hsSqlTool.sGetSaveValue(shoantat, "tinyint");
            string tem_sidphongkhambenh = hsSqlTool.sGetSaveValue(sidphongkhambenh, "int");
            string tem_sTienSu = hsSqlTool.sGetSaveValue(sTienSu, "ntext");
            string tem_sSoPhieuTT = hsSqlTool.sGetSaveValue(sSoPhieuTT, "nvarchar");
            string tem_sidPhongChuyenDen = hsSqlTool.sGetSaveValue(sidPhongChuyenDen, "int");
            string tem_sthuChuyenPhong = hsSqlTool.sGetSaveValue(sthuChuyenPhong, "int");
            string tem_sidDVPhongChuyenDen = hsSqlTool.sGetSaveValue(sidDVPhongChuyenDen, "int");
            string tem_sIdChiTietDangKyKham = hsSqlTool.sGetSaveValue(sIdChiTietDangKyKham, "bigint");
            string tem_sChanDoanTuyenDuoi = hsSqlTool.sGetSaveValue(sChanDoanTuyenDuoi, "nvarchar");
            string tem_sisNoiTru = hsSqlTool.sGetSaveValue(sisNoiTru, "bit");
            string tem_sidkhambenhgoc = hsSqlTool.sGetSaveValue(sidkhambenhgoc, "bigint");
            string tem_ssovaovien = hsSqlTool.sGetSaveValue(ssovaovien, "nvarchar");
            string tem_sIdDieuDuong = hsSqlTool.sGetSaveValue(sIdDieuDuong, "bigint");
            string tem_sIsDaRaVien = hsSqlTool.sGetSaveValue(sIsDaRaVien, "bit");
            string tem_sisdathanhtoan = hsSqlTool.sGetSaveValue(sisdathanhtoan, "bit");
            string tem_stinhtrangtaikham = hsSqlTool.sGetSaveValue(stinhtrangtaikham, "int");

            string sqlSave = " UPDATE khambenh SET " + "maphieukham =" + tem_smaphieukham + ","
                             + "ngaykham =" + tem_sngaykham + ","
                             + "idbenhnhan =" + tem_sidbenhnhan + ","
                             + "iddangkykham =" + tem_siddangkykham + ","
                             + "idbacsi =" + tem_sidbacsi + ","
                             + "trieuchung =" + tem_strieuchung + ","
                             + "benhsu =" + tem_sbenhsu + ","
                             + "chandoanbandau =" + tem_schandoanbandau + ","
                             + "ketluan =" + tem_sketluan + ","
                             + "ketluan1 =" + tem_sketluan1 + ","
                             + "ketluan2 =" + tem_sketluan2 + ","
                             + "huongdieutri =" + tem_shuongdieutri + ","
                             + "phongkhamchuyenden =" + tem_sphongkhamchuyenden + ","
                             + "ghichuhuongdieutri =" + tem_sghichuhuongdieutri + ","
                             + "chidinhbacsi =" + tem_schidinhbacsi + ","
                             + "dando =" + tem_sdando + ","
                             + "noidungtaikham =" + tem_snoidungtaikham + ","
                             + "ngayhentaikham =" + tem_sngayhentaikham + ","
                             + "hoantat =" + tem_shoantat + ","
                             + "idphongkhambenh =" + tem_sidphongkhambenh + ","
                             + "TienSu =" + tem_sTienSu + ","
                             + "SoPhieuTT =" + tem_sSoPhieuTT + ","
                             + "idPhongChuyenDen =" + tem_sidPhongChuyenDen + ","
                             + "thuChuyenPhong =" + tem_sthuChuyenPhong + ","
                             + "idDVPhongChuyenDen =" + tem_sidDVPhongChuyenDen + ","
                             + "IdChiTietDangKyKham =" + tem_sIdChiTietDangKyKham + ","
                             + "ChanDoanTuyenDuoi =" + tem_sChanDoanTuyenDuoi + ","
                             + "isNoiTru =" + tem_sisNoiTru + ","
                             + "idkhambenhgoc =" + tem_sidkhambenhgoc + ","
                             + "sovaovien =" + tem_ssovaovien + ","
                             + "IdDieuDuong =" + tem_sIdDieuDuong + ","
                             + "IsDaRaVien =" + tem_sIsDaRaVien + ","
                             + "isdathanhtoan =" + tem_sisdathanhtoan + ","
                             + "tinhtrangtaikham =" + tem_stinhtrangtaikham + " WHERE idkhambenh=" +
                             hsSqlTool.sGetSaveValue(idkhambenh, "int identity");
            ;
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                maphieukham = smaphieukham;
                ngaykham = sngaykham;
                idbenhnhan = sidbenhnhan;
                iddangkykham = siddangkykham;
                idbacsi = sidbacsi;
                trieuchung = strieuchung;
                benhsu = sbenhsu;
                chandoanbandau = schandoanbandau;
                ketluan = sketluan;
                ketluan1 = sketluan1;
                ketluan2 = sketluan2;
                huongdieutri = shuongdieutri;
                phongkhamchuyenden = sphongkhamchuyenden;
                ghichuhuongdieutri = sghichuhuongdieutri;
                chidinhbacsi = schidinhbacsi;
                dando = sdando;
                noidungtaikham = snoidungtaikham;
                ngayhentaikham = sngayhentaikham;
                hoantat = shoantat;
                idphongkhambenh = sidphongkhambenh;
                TienSu = sTienSu;
                SoPhieuTT = sSoPhieuTT;
                idPhongChuyenDen = sidPhongChuyenDen;
                thuChuyenPhong = sthuChuyenPhong;
                idDVPhongChuyenDen = sidDVPhongChuyenDen;
                IdChiTietDangKyKham = sIdChiTietDangKyKham;
                ChanDoanTuyenDuoi = sChanDoanTuyenDuoi;
                isNoiTru = sisNoiTru;
                idkhambenhgoc = sidkhambenhgoc;
                sovaovien = ssovaovien;
                IdDieuDuong = sIdDieuDuong;
                IsDaRaVien = sIsDaRaVien;
                isdathanhtoan = sisdathanhtoan;
                tinhtrangtaikham = stinhtrangtaikham;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Save_Object()
        {
            string tem_smaphieukham = hsSqlTool.sGetSaveValue(maphieukham, "nvarchar");
            string tem_sngaykham = hsSqlTool.sGetSaveValue(ngaykham, "datetime");
            string tem_sidbenhnhan = hsSqlTool.sGetSaveValue(idbenhnhan, "int");
            string tem_siddangkykham = hsSqlTool.sGetSaveValue(iddangkykham, "int");
            string tem_sidbacsi = hsSqlTool.sGetSaveValue(idbacsi, "int");
            string tem_strieuchung = hsSqlTool.sGetSaveValue(trieuchung, "ntext");
            string tem_sbenhsu = hsSqlTool.sGetSaveValue(benhsu, "nvarchar");
            string tem_schandoanbandau = hsSqlTool.sGetSaveValue(chandoanbandau, "nvarchar");
            string tem_sketluan = hsSqlTool.sGetSaveValue(ketluan, "varchar");
            string tem_sketluan1 = hsSqlTool.sGetSaveValue(ketluan1, "varchar");
            string tem_sketluan2 = hsSqlTool.sGetSaveValue(ketluan2, "varchar");
            string tem_shuongdieutri = hsSqlTool.sGetSaveValue(huongdieutri, "tinyint");
            string tem_sphongkhamchuyenden = hsSqlTool.sGetSaveValue(phongkhamchuyenden, "int");
            string tem_sghichuhuongdieutri = hsSqlTool.sGetSaveValue(ghichuhuongdieutri, "nvarchar");
            string tem_schidinhbacsi = hsSqlTool.sGetSaveValue(chidinhbacsi, "ntext");
            string tem_sdando = hsSqlTool.sGetSaveValue(dando, "ntext");
            string tem_snoidungtaikham = hsSqlTool.sGetSaveValue(noidungtaikham, "nvarchar");
            string tem_sngayhentaikham = hsSqlTool.sGetSaveValue(ngayhentaikham, "smalldatetime");
            string tem_shoantat = hsSqlTool.sGetSaveValue(hoantat, "tinyint");
            string tem_sidphongkhambenh = hsSqlTool.sGetSaveValue(idphongkhambenh, "int");
            string tem_sTienSu = hsSqlTool.sGetSaveValue(TienSu, "ntext");
            string tem_sSoPhieuTT = hsSqlTool.sGetSaveValue(SoPhieuTT, "nvarchar");
            string tem_sidPhongChuyenDen = hsSqlTool.sGetSaveValue(idPhongChuyenDen, "int");
            string tem_sthuChuyenPhong = hsSqlTool.sGetSaveValue(thuChuyenPhong, "int");
            string tem_sidDVPhongChuyenDen = hsSqlTool.sGetSaveValue(idDVPhongChuyenDen, "int");
            string tem_sIdChiTietDangKyKham = hsSqlTool.sGetSaveValue(IdChiTietDangKyKham, "bigint");
            string tem_sChanDoanTuyenDuoi = hsSqlTool.sGetSaveValue(ChanDoanTuyenDuoi, "nvarchar");
            string tem_sisNoiTru = hsSqlTool.sGetSaveValue(isNoiTru, "bit");
            string tem_sidkhambenhgoc = hsSqlTool.sGetSaveValue(idkhambenhgoc, "bigint");
            string tem_ssovaovien = hsSqlTool.sGetSaveValue(sovaovien, "nvarchar");
            string tem_sIdDieuDuong = hsSqlTool.sGetSaveValue(IdDieuDuong, "bigint");
            string tem_sIsDaRaVien = hsSqlTool.sGetSaveValue(IsDaRaVien, "bit");
            string tem_sisdathanhtoan = hsSqlTool.sGetSaveValue(isdathanhtoan, "bit");
            string tem_stinhtrangtaikham = hsSqlTool.sGetSaveValue(tinhtrangtaikham, "int");

            string sqlSave = " UPDATE khambenh SET ";
            if (tem_smaphieukham != null)
                sqlSave += "maphieukham =" + tem_smaphieukham + ",";
            if (tem_sngaykham != null)
                sqlSave += "ngaykham =" + tem_sngaykham + ",";
            if (tem_sidbenhnhan != null)
                sqlSave += "idbenhnhan =" + tem_sidbenhnhan + ",";
            if (tem_siddangkykham != null)
                sqlSave += "iddangkykham =" + tem_siddangkykham + ",";
            if (tem_sidbacsi != null)
                sqlSave += "idbacsi =" + tem_sidbacsi + ",";
            if (tem_strieuchung != null)
                sqlSave += "trieuchung =" + tem_strieuchung + ",";
            if (tem_sbenhsu != null)
                sqlSave += "benhsu =" + tem_sbenhsu + ",";
            if (tem_schandoanbandau != null)
                sqlSave += "chandoanbandau =" + tem_schandoanbandau + ",";
            if (tem_sketluan != null)
                sqlSave += "ketluan =" + tem_sketluan + ",";
            if (tem_sketluan1 != null)
                sqlSave += "ketluan1 =" + tem_sketluan1 + ",";
            if (tem_sketluan2 != null)
                sqlSave += "ketluan2 =" + tem_sketluan2 + ",";
            if (tem_shuongdieutri != null)
                sqlSave += "huongdieutri =" + tem_shuongdieutri + ",";
            if (tem_sphongkhamchuyenden != null)
                sqlSave += "phongkhamchuyenden =" + tem_sphongkhamchuyenden + ",";
            if (tem_sghichuhuongdieutri != null)
                sqlSave += "ghichuhuongdieutri =" + tem_sghichuhuongdieutri + ",";
            if (tem_schidinhbacsi != null)
                sqlSave += "chidinhbacsi =" + tem_schidinhbacsi + ",";
            if (tem_sdando != null)
                sqlSave += "dando =" + tem_sdando + ",";
            if (tem_snoidungtaikham != null)
                sqlSave += "noidungtaikham =" + tem_snoidungtaikham + ",";
            if (tem_sngayhentaikham != null)
                sqlSave += "ngayhentaikham =" + tem_sngayhentaikham + ",";
            if (tem_shoantat != null)
                sqlSave += "hoantat =" + tem_shoantat + ",";
            if (tem_sidphongkhambenh != null)
                sqlSave += "idphongkhambenh =" + tem_sidphongkhambenh + ",";
            if (tem_sTienSu != null)
                sqlSave += "TienSu =" + tem_sTienSu + ",";
            if (tem_sSoPhieuTT != null)
                sqlSave += "SoPhieuTT =" + tem_sSoPhieuTT + ",";
            if (tem_sidPhongChuyenDen != null)
                sqlSave += "idPhongChuyenDen =" + tem_sidPhongChuyenDen + ",";
            if (tem_sthuChuyenPhong != null)
                sqlSave += "thuChuyenPhong =" + tem_sthuChuyenPhong + ",";
            if (tem_sidDVPhongChuyenDen != null)
                sqlSave += "idDVPhongChuyenDen =" + tem_sidDVPhongChuyenDen + ",";
            if (tem_sIdChiTietDangKyKham != null)
                sqlSave += "IdChiTietDangKyKham =" + tem_sIdChiTietDangKyKham + ",";
            if (tem_sChanDoanTuyenDuoi != null)
                sqlSave += "ChanDoanTuyenDuoi =" + tem_sChanDoanTuyenDuoi + ",";
            if (tem_sisNoiTru != null)
                sqlSave += "isNoiTru =" + tem_sisNoiTru + ",";
            if (tem_sidkhambenhgoc != null)
                sqlSave += "idkhambenhgoc =" + tem_sidkhambenhgoc + ",";
            if (tem_ssovaovien != null)
                sqlSave += "sovaovien =" + tem_ssovaovien + ",";
            if (tem_sIdDieuDuong != null)
                sqlSave += "IdDieuDuong =" + tem_sIdDieuDuong + ",";
            if (tem_sIsDaRaVien != null)
                sqlSave += "IsDaRaVien =" + tem_sIsDaRaVien + ",";
            if (tem_sisdathanhtoan != null)
                sqlSave += "isdathanhtoan =" + tem_sisdathanhtoan + ",";
            if (tem_stinhtrangtaikham != null)
                sqlSave += "tinhtrangtaikham =" + tem_stinhtrangtaikham + ",";
            sqlSave += " WHERE idkhambenh=" + hsSqlTool.sGetSaveValue(idkhambenh, "int identity");
            ;
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────

        public static DataTable dtGetAll()
        {
            string sqlSelect = " SELECT * FROM khambenh ";
            return GetTable(sqlSelect);
        }

//───────────────────────────────────────────────────────────────────────────────────────

        public static DataTable get_khambenh()
        {
            if (dt_khambenh == null || Change_dt_khambenh)
            {
                dt_khambenh = dtGetAll();
                Change_dt_khambenh = true && AllowAutoChange;
            }
            return dt_khambenh;
        }

        #region Update DataColumn  

        public bool Update_idkhambenh(string sidkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET idkhambenh='" + sidkhambenh + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                idkhambenh = sidkhambenh;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_maphieukham(string smaphieukham)
        {
            string sqlSave = " UPDATE khambenh SET maphieukham='N" + smaphieukham + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                maphieukham = smaphieukham;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_ngaykham(string sngaykham)
        {
            string sqlSave = " UPDATE khambenh SET ngaykham='" + sngaykham + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                ngaykham = sngaykham;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_idbenhnhan(string sidbenhnhan)
        {
            string sqlSave = " UPDATE khambenh SET idbenhnhan='" + sidbenhnhan + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                idbenhnhan = sidbenhnhan;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_iddangkykham(string siddangkykham)
        {
            string sqlSave = " UPDATE khambenh SET iddangkykham='" + siddangkykham + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                iddangkykham = siddangkykham;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_idbacsi(string sidbacsi)
        {
            string sqlSave = " UPDATE khambenh SET idbacsi='" + sidbacsi + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                idbacsi = sidbacsi;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_trieuchung(string strieuchung)
        {
            string sqlSave = " UPDATE khambenh SET trieuchung='" + strieuchung + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                trieuchung = strieuchung;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_benhsu(string sbenhsu)
        {
            string sqlSave = " UPDATE khambenh SET benhsu='N" + sbenhsu + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                benhsu = sbenhsu;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_chandoanbandau(string schandoanbandau)
        {
            string sqlSave = " UPDATE khambenh SET chandoanbandau='N" + schandoanbandau + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                chandoanbandau = schandoanbandau;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_ketluan(string sketluan)
        {
            string sqlSave = " UPDATE khambenh SET ketluan='N" + sketluan + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                ketluan = sketluan;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_ketluan1(string sketluan1)
        {
            string sqlSave = " UPDATE khambenh SET ketluan1='N" + sketluan1 + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                ketluan1 = sketluan1;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_ketluan2(string sketluan2)
        {
            string sqlSave = " UPDATE khambenh SET ketluan2='N" + sketluan2 + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                ketluan2 = sketluan2;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_huongdieutri(string shuongdieutri)
        {
            string sqlSave = " UPDATE khambenh SET huongdieutri='" + shuongdieutri + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                huongdieutri = shuongdieutri;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_phongkhamchuyenden(string sphongkhamchuyenden)
        {
            string sqlSave = " UPDATE khambenh SET phongkhamchuyenden='" + sphongkhamchuyenden + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                phongkhamchuyenden = sphongkhamchuyenden;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_ghichuhuongdieutri(string sghichuhuongdieutri)
        {
            string sqlSave = " UPDATE khambenh SET ghichuhuongdieutri='N" + sghichuhuongdieutri + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                ghichuhuongdieutri = sghichuhuongdieutri;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_chidinhbacsi(string schidinhbacsi)
        {
            string sqlSave = " UPDATE khambenh SET chidinhbacsi='" + schidinhbacsi + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                chidinhbacsi = schidinhbacsi;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_dando(string sdando)
        {
            string sqlSave = " UPDATE khambenh SET dando='" + sdando + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                dando = sdando;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_noidungtaikham(string snoidungtaikham)
        {
            string sqlSave = " UPDATE khambenh SET noidungtaikham='N" + snoidungtaikham + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                noidungtaikham = snoidungtaikham;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_ngayhentaikham(string sngayhentaikham)
        {
            string sqlSave = " UPDATE khambenh SET ngayhentaikham='" + sngayhentaikham + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                ngayhentaikham = sngayhentaikham;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_hoantat(string shoantat)
        {
            string sqlSave = " UPDATE khambenh SET hoantat='" + shoantat + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                hoantat = shoantat;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_idphongkhambenh(string sidphongkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET idphongkhambenh='" + sidphongkhambenh + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                idphongkhambenh = sidphongkhambenh;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_TienSu(string sTienSu)
        {
            string sqlSave = " UPDATE khambenh SET TienSu='" + sTienSu + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                TienSu = sTienSu;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_SoPhieuTT(string sSoPhieuTT)
        {
            string sqlSave = " UPDATE khambenh SET SoPhieuTT='N" + sSoPhieuTT + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                SoPhieuTT = sSoPhieuTT;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_idPhongChuyenDen(string sidPhongChuyenDen)
        {
            string sqlSave = " UPDATE khambenh SET idPhongChuyenDen='" + sidPhongChuyenDen + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                idPhongChuyenDen = sidPhongChuyenDen;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_thuChuyenPhong(string sthuChuyenPhong)
        {
            string sqlSave = " UPDATE khambenh SET thuChuyenPhong='" + sthuChuyenPhong + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                thuChuyenPhong = sthuChuyenPhong;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_idDVPhongChuyenDen(string sidDVPhongChuyenDen)
        {
            string sqlSave = " UPDATE khambenh SET idDVPhongChuyenDen='" + sidDVPhongChuyenDen + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                idDVPhongChuyenDen = sidDVPhongChuyenDen;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IdChiTietDangKyKham(string sIdChiTietDangKyKham)
        {
            string sqlSave = " UPDATE khambenh SET IdChiTietDangKyKham='" + sIdChiTietDangKyKham +
                             "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                IdChiTietDangKyKham = sIdChiTietDangKyKham;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_ChanDoanTuyenDuoi(string sChanDoanTuyenDuoi)
        {
            string sqlSave = " UPDATE khambenh SET ChanDoanTuyenDuoi='N" + sChanDoanTuyenDuoi + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                ChanDoanTuyenDuoi = sChanDoanTuyenDuoi;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_isNoiTru(string sisNoiTru)
        {
            string sqlSave = " UPDATE khambenh SET isNoiTru='" + sisNoiTru + "' WHERE idkhambenh='" + idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                isNoiTru = sisNoiTru;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_idkhambenhgoc(string sidkhambenhgoc)
        {
            string sqlSave = " UPDATE khambenh SET idkhambenhgoc='" + sidkhambenhgoc + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                idkhambenhgoc = sidkhambenhgoc;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_sovaovien(string ssovaovien)
        {
            string sqlSave = " UPDATE khambenh SET sovaovien='N" + ssovaovien + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                sovaovien = ssovaovien;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IdDieuDuong(string sIdDieuDuong)
        {
            string sqlSave = " UPDATE khambenh SET IdDieuDuong='" + sIdDieuDuong + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                IdDieuDuong = sIdDieuDuong;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_IsDaRaVien(string sIsDaRaVien)
        {
            string sqlSave = " UPDATE khambenh SET IsDaRaVien='" + sIsDaRaVien + "' WHERE idkhambenh='" + idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                IsDaRaVien = sIsDaRaVien;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_isdathanhtoan(string sisdathanhtoan)
        {
            string sqlSave = " UPDATE khambenh SET isdathanhtoan='" + sisdathanhtoan + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                isdathanhtoan = sisdathanhtoan;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public bool Update_tinhtrangtaikham(string stinhtrangtaikham)
        {
            string sqlSave = " UPDATE khambenh SET tinhtrangtaikham='" + stinhtrangtaikham + "' WHERE idkhambenh='" +
                             idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            if (OK)
            {
                tinhtrangtaikham = stinhtrangtaikham;
            }
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────

        #endregion

        #region Update DataColumn  Static 

        public static bool Update_maphieukham(string smaphieukham, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET maphieukham='N" + smaphieukham + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_ngaykham(string sngaykham, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET ngaykham='" + sngaykham + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_idbenhnhan(string sidbenhnhan, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET idbenhnhan='" + sidbenhnhan + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_iddangkykham(string siddangkykham, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET iddangkykham='" + siddangkykham + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_idbacsi(string sidbacsi, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET idbacsi='" + sidbacsi + "' WHERE idkhambenh='" + s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_trieuchung(string strieuchung, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET trieuchung='" + strieuchung + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_benhsu(string sbenhsu, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET benhsu='N" + sbenhsu + "' WHERE idkhambenh='" + s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_chandoanbandau(string schandoanbandau, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET chandoanbandau='N" + schandoanbandau + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_ketluan(string sketluan, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET ketluan='N" + sketluan + "' WHERE idkhambenh='" + s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_ketluan1(string sketluan1, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET ketluan1='N" + sketluan1 + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_ketluan2(string sketluan2, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET ketluan2='N" + sketluan2 + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_huongdieutri(string shuongdieutri, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET huongdieutri='" + shuongdieutri + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_phongkhamchuyenden(string sphongkhamchuyenden, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET phongkhamchuyenden='" + sphongkhamchuyenden + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_ghichuhuongdieutri(string sghichuhuongdieutri, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET ghichuhuongdieutri='N" + sghichuhuongdieutri + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_chidinhbacsi(string schidinhbacsi, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET chidinhbacsi='" + schidinhbacsi + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_dando(string sdando, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET dando='" + sdando + "' WHERE idkhambenh='" + s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_noidungtaikham(string snoidungtaikham, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET noidungtaikham='N" + snoidungtaikham + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_ngayhentaikham(string sngayhentaikham, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET ngayhentaikham='" + sngayhentaikham + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_hoantat(string shoantat, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET hoantat='" + shoantat + "' WHERE idkhambenh='" + s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_idphongkhambenh(string sidphongkhambenh, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET idphongkhambenh='" + sidphongkhambenh + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_TienSu(string sTienSu, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET TienSu='" + sTienSu + "' WHERE idkhambenh='" + s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_SoPhieuTT(string sSoPhieuTT, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET SoPhieuTT='N" + sSoPhieuTT + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_idPhongChuyenDen(string sidPhongChuyenDen, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET idPhongChuyenDen='" + sidPhongChuyenDen + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_thuChuyenPhong(string sthuChuyenPhong, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET thuChuyenPhong='" + sthuChuyenPhong + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_idDVPhongChuyenDen(string sidDVPhongChuyenDen, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET idDVPhongChuyenDen='" + sidDVPhongChuyenDen + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IdChiTietDangKyKham(string sIdChiTietDangKyKham, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET IdChiTietDangKyKham='" + sIdChiTietDangKyKham +
                             "' WHERE idkhambenh='" + s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_ChanDoanTuyenDuoi(string sChanDoanTuyenDuoi, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET ChanDoanTuyenDuoi='N" + sChanDoanTuyenDuoi + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_isNoiTru(string sisNoiTru, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET isNoiTru='" + sisNoiTru + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_idkhambenhgoc(string sidkhambenhgoc, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET idkhambenhgoc='" + sidkhambenhgoc + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_sovaovien(string ssovaovien, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET sovaovien='N" + ssovaovien + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IdDieuDuong(string sIdDieuDuong, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET IdDieuDuong='" + sIdDieuDuong + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_IsDaRaVien(string sIsDaRaVien, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET IsDaRaVien='" + sIsDaRaVien + "' WHERE idkhambenh='" + s_idkhambenh +
                             "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_isdathanhtoan(string sisdathanhtoan, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET isdathanhtoan='" + sisdathanhtoan + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
        public static bool Update_tinhtrangtaikham(string stinhtrangtaikham, string s_idkhambenh)
        {
            string sqlSave = " UPDATE khambenh SET tinhtrangtaikham='" + stinhtrangtaikham + "' WHERE idkhambenh='" +
                             s_idkhambenh + "' ";
            bool OK = Exec(sqlSave) == 1 ? true : false;
            return OK;
        }

//───────────────────────────────────────────────────────────────────────────────────────
//───────────────────────────────────────────────────────────────────────────────────────

        #endregion

        //───────────────────────────────────────────────────────────────────────────────────────
    }
}