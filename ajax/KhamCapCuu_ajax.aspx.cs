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

public partial class KhamCapCuu_ajax : System.Web.UI.Page
{
    protected DataProcess s_khambenh()
    {
        DataProcess khambenh = new DataProcess("khambenh");
        khambenh.data("idkhambenh", Request.QueryString["idkhoachinh"]);
        khambenh.data("maphieukham", Request.QueryString["maphieukham"]);
        khambenh.data("ngaykham", Request.QueryString["ngaykham"]);
        khambenh.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        khambenh.data("iddangkykham", Request.QueryString["iddangkykham"]);
        khambenh.data("idbacsi", Request.QueryString["idbacsi"]);
        khambenh.data("trieuchung", Request.QueryString["trieuchung"]);
        khambenh.data("benhsu", Request.QueryString["benhsu"]);
        khambenh.data("chandoanbandau", Request.QueryString["chandoanbandau"]);
        khambenh.data("ketluan", Request.QueryString["ketluan"]);
        khambenh.data("ketluan1", Request.QueryString["ketluan1"]);
        khambenh.data("ketluan2", Request.QueryString["ketluan2"]);
        khambenh.data("huongdieutri", Request.QueryString["huongdieutri"]);
        khambenh.data("phongkhamchuyenden", Request.QueryString["phongkhamchuyenden"]);
        khambenh.data("ghichuhuongdieutri", Request.QueryString["ghichuhuongdieutri"]);
        khambenh.data("chidinhbacsi", Request.QueryString["chidinhbacsi"]);
        khambenh.data("dando", Request.QueryString["dando"]);
        khambenh.data("noidungtaikham", Request.QueryString["noidungtaikham"]);
        khambenh.data("ngayhentaikham", Request.QueryString["ngayhentaikham"]);
        khambenh.data("hoantat", Request.QueryString["hoantat"]);
        khambenh.data("idphongkhambenh", Request.QueryString["idphongkhambenh"]);
        khambenh.data("TienSu", Request.QueryString["TienSu"]);
        khambenh.data("SoPhieuTT", Request.QueryString["SoPhieuTT"]);
        khambenh.data("idPhongChuyenDen", Request.QueryString["idPhongChuyenDen"]);
        khambenh.data("thuChuyenPhong", Request.QueryString["thuChuyenPhong"]);
        khambenh.data("idDVPhongChuyenDen", Request.QueryString["idDVPhongChuyenDen"]);
        khambenh.data("IdChiTietDangKyKham", Request.QueryString["IdChiTietDangKyKham"]);
        khambenh.data("ChanDoanTuyenDuoi", Request.QueryString["ChanDoanTuyenDuoi"]);
        khambenh.data("isNoiTru","0");
        khambenh.data("idkhambenhgoc", Request.QueryString["idkhambenhgoc"]);
        khambenh.data("IdDieuDuong", Request.QueryString["IdDieuDuong"]);
        //khambenh.data("sovaovien", (!string.IsNullOrEmpty(Request.QueryString["sovaovien"]) ? Request.QueryString["sovaovien"] : StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())));
        return khambenh;
    }
    protected DataProcess s_chitietbenhnhantoathuoc()
    {
        DataProcess chitietbenhnhantoathuoc = new DataProcess("chitietbenhnhantoathuoc");
        chitietbenhnhantoathuoc.data("idchitietbenhnhantoathuoc", Request.QueryString["idkhoachinh"]);
        chitietbenhnhantoathuoc.data("idbenhnhantoathuoc", Request.QueryString["idbenhnhantoathuoc"]);
        chitietbenhnhantoathuoc.data("idthuoc", Request.QueryString["idthuoc"]);
        chitietbenhnhantoathuoc.data("soluongke", Request.QueryString["soluongke"]);
        chitietbenhnhantoathuoc.data("soluongbanra", Request.QueryString["soluongbanra"]);
        chitietbenhnhantoathuoc.data("dongia", Request.QueryString["dongia"]);
        chitietbenhnhantoathuoc.data("ngayuong", Request.QueryString["ngayuong"]);
        chitietbenhnhantoathuoc.data("moilanuong", Request.QueryString["moilanuong"]);
        chitietbenhnhantoathuoc.data("donvidung", Request.QueryString["donvidung"]);
        chitietbenhnhantoathuoc.data("ghichu", Request.QueryString["ghichu"]);
        chitietbenhnhantoathuoc.data("bacsixoa", Request.QueryString["bacsixoa"]);
        chitietbenhnhantoathuoc.data("quaythuocxoa", Request.QueryString["quaythuocxoa"]);
        chitietbenhnhantoathuoc.data("thoigiandung", Request.QueryString["thoigiandung"]);
        chitietbenhnhantoathuoc.data("tenNgaydung", Request.QueryString["tenNgaydung"]);
        chitietbenhnhantoathuoc.data("thanhtien", Request.QueryString["thanhtien"]);
        chitietbenhnhantoathuoc.data("heso", Request.QueryString["heso"]);
        chitietbenhnhantoathuoc.data("IdThuoc1", Request.QueryString["IdThuoc1"]);
        chitietbenhnhantoathuoc.data("idkhambenh", Request.QueryString["idkhambenh"]);
        chitietbenhnhantoathuoc.data("idkho", Request.QueryString["idkho"]);
        chitietbenhnhantoathuoc.data("soluongtra", Request.QueryString["soluongtra"]);
        chitietbenhnhantoathuoc.data("DoiTuongThuocID", Request.QueryString["DoiTuongThuocID"]);
        return chitietbenhnhantoathuoc;
    }
    protected DataProcess s_khambenhcanlamsan()
    {
        DataProcess khambenhcanlamsan = new DataProcess("khambenhcanlamsan");
        khambenhcanlamsan.data("idkhambenhcanlamsan", Request.QueryString["idkhoachinh"]);
        khambenhcanlamsan.data("idcanlamsan", Request.QueryString["idcanlamsan"]);
        khambenhcanlamsan.data("idkhambenh", Request.QueryString["idkhambenh"]);
        khambenhcanlamsan.data("dongia", Request.QueryString["dongia"]);
        khambenhcanlamsan.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        khambenhcanlamsan.data("maphieucls", Request.QueryString["maphieucls"]);
        khambenhcanlamsan.data("soluong", Request.QueryString["soluong"]);
        khambenhcanlamsan.data("chietkhau", Request.QueryString["chietkhau"]);
        khambenhcanlamsan.data("thanhtien", Request.QueryString["thanhtien"]);
        khambenhcanlamsan.data("ghichu", Request.QueryString["ghichu"]);
        khambenhcanlamsan.data("dathu", Request.QueryString["dathu"]);
        return khambenhcanlamsan;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savekhambenh(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablechitietbenhnhantoathuoc": LuuTablechitietbenhnhantoathuoc(); break;
            case "luuTablekhambenhcanlamsan": LuuTablekhambenhcanlamsan(); break;
            case "loadTablechitietbenhnhantoathuoc": loadTablechitietbenhnhantoathuoc(); break;
            case "loadTablekhambenhcanlamsan": loadTablekhambenhcanlamsan(); break;
            case "xoa": Xoakhambenh(); break;
            case "xoachitietbenhnhantoathuoc": Xoachitietbenhnhantoathuoc(); break;
            case "xoakhambenhcanlamsan": Xoakhambenhcanlamsan(); break;
            case "chandoanbandausearch": chandoanbandausearch(); break;
            case "huongdieutrisearch": huongdieutrisearch(); break;
            case "huongdieutrisearch_KhamcapCuu": huongdieutrisearch_KhamcapCuu(); break;
            case "huongdieutrisearch_KhamKhoaSan": huongdieutrisearch_KhamKhoaSan(); break;
            case "ghichuhuongdieutriSearch": ghichuhuongdieutriSearch(); break;    
            case "idthuocsearch": idthuocsearch(); break;
            case "idcanlamsansearch": idcanlamsansearch(); break;
            //case "idbacsisearch": idbacsisearch(); break;
            case "idkhosearch": idkhosearch(); break;
            case "loaithuocidsearch": loaithuocidsearch(); break;
            case "giuongsearch": giuongsearch(); break;
            case "khoakhambenhSearch": khoakhambenhSearch(); break;
            case "banggiadichvuSearch": banggiadichvuSearch(); break;
            case "phongkhambenhSearch": phongkhambenhSearch(); break;
            case "Loadsauhuongdieutri": Loadsauhuongdieutri(); break;
            case "Setsauhuongdieutri": Setsauhuongdieutri(); break;
            case "SethuongdieutriTheoDoiCapCuu": SethuongdieutriTheoDoiCapCuu(); break;
            case "ChonCLS": ChonCLS(); break;
            case "GetDSCLS": GetDSCLS(); break;
            case "loadTableAjaxDSkhambenh": loadTableAjaxDSkhambenh(); break;
            case "IdDieuDuongsearch": IdDieuDuongsearch(); break;
            case "xuatkho": xuatkho(); break;
            case "loadTablechandoanphoihop": loadTablechandoanphoihop(); break;
        }
    }

    private void xuatkho()
    {
        string idkhambenh = Request.QueryString["idkhoachinh"];
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string iddieuduong = Request.QueryString["iddieuduong"];
        myInsertPhieuXuatKho.XuatTheoToa(null,idkhambenh);
    }
    private void GetDSCLS()
    {
        try
        {
            string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");
            string IdKhambenh = (Request.QueryString["IdKhambenh"] != null ? Request.QueryString["IdKhambenh"].ToString() : "");
            string slvack = Request.QueryString["slvack"];
            string LoaiBN = (Request.QueryString["LoaiBN"] != null ? Request.QueryString["LoaiBN"].ToString() : "");
            if (IdKhambenh != "")
            {
                DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,A.IdBenhNhan FROM KHAMBENH A LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN WHERE A.IDKHAMBENH=" + IdKhambenh);
                if (dtBN != null && dtBN.Rows.Count > 0)
                {
                    LoaiBN = dtBN.Rows[0][0].ToString();
                    IdBenhNhan = dtBN.Rows[0]["IdBenhNhan"].ToString();
                }
            }
            string listidcanlamsan = Request.QueryString["listID"];
            listidcanlamsan = listidcanlamsan.TrimEnd(',').Replace("on,", "");
            string[] arridcls = listidcanlamsan.Split(',');
            int length = arridcls.Length;

            string[] arrslvack = slvack.Split('@');

            string html = "";
            if (listidcanlamsan.Trim() == "")
            {
               listidcanlamsan = "''";
            }
            string sqlSelectBangGiaDichVu = " select STT=row_number() over (order by A.idbanggiadichvu),A.idbanggiadichvu, B.tenphongkhambenh,A.TenNhom,A.tendichvu,A.giadichvu,A.GiaBH,A.PhuThuBH,A.idphongkhambenh,dongia=DBO.KB_GETSOTIEN_BNTra(a.idbanggiadichvu," + IdBenhNhan + ")" + "\r\n"
                            + " 				from banggiadichvu a" + "\r\n"
                            + " 				left join phongkhambenh b on a.idphongkhambenh=b.idphongkhambenh" + "\r\n"
                            + " WHERE loaiphong = 1 and a.idbanggiadichvu in (" + listidcanlamsan + ")";
            DataTable dt = DataAcess.Connect.GetTable(sqlSelectBangGiaDichVu);
            html = tableCLS(dt, arrslvack, false);
            Response.Clear();
            Response.Write(html);
        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }

    private void ChonCLS()
    {
        bool dautien = (Request.QueryString["dautien"] != null ? true : false);
        string IdBenhNhan = (Request.QueryString["IdBenhNhan"] != null ? Request.QueryString["IdBenhNhan"].ToString() : "");

        string IdKhambenh = (Request.QueryString["IdKhambenh"] != null ? Request.QueryString["IdKhambenh"].ToString() : "");
        string LoaiBN = (Request.QueryString["LoaiBN"] != null ? Request.QueryString["LoaiBN"].ToString() : "");
        if (IdKhambenh != "")
        {
            DataTable dtBN = DataAcess.Connect.GetTable("SELECT LOAI,a.idbenhnhan FROM KHAMBENH A LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN WHERE A.IDKHAMBENH=" + IdKhambenh);
            if (dtBN != null && dtBN.Rows.Count > 0)
            {
                LoaiBN = dtBN.Rows[0][0].ToString();
                IdBenhNhan = dtBN.Rows[0]["idbenhnhan"].ToString();
            }
        }
        string DonGiaName = "BNPhaiTra";
        //if (LoaiBN != "" && LoaiBN != "0")
        //{
        //    if (LoaiBN != "2") DonGiaName = "GiaBH";
        //}


        string listidcanlamsan = Request.QueryString["listID"];
        string[] arridcls = listidcanlamsan.Split(',');
        //Khoe 2007
        string IdKhoaKhoe = "0";
        if (dautien == true && listidcanlamsan != "" && arridcls.Length > 1 && listidcanlamsan != ",")
            IdKhoaKhoe = DataAcess.Connect.GetTable("select idphongkhambenh from banggiadichvu where idbanggiadichvu=" + arridcls[0]).Rows[0][0].ToString();
        listidcanlamsan = listidcanlamsan.TrimEnd(',');
        string swhere = "";
        int idpkb = StaticData.ParseInt(Request.QueryString["idpkb"]);
        if (IdKhoaKhoe != "0") idpkb = StaticData.ParseInt(IdKhoaKhoe);
        //string tenNhom = Request.QueryString["tN"];
        if (idpkb == 0)
        {

        }
        else
        {
            swhere = " and Bg.idphongkhambenh=" + idpkb + " ";
        }
        string html = "";
        string selectIDDVNhomCLS = "select tenNhom,dbo.[GetIdBanggiaDVByNhomCLS](n.nhomId) as idDV from KB_NhomCLS n where status='true' order by n.tenNhom";
        DataTable arrIDDVNhomCLS = DataAcess.Connect.GetTable(selectIDDVNhomCLS);
        html += "Tên nhóm CLS :";
        if (arrIDDVNhomCLS.Rows.Count != 0 && arrIDDVNhomCLS != null)
        {

            for (int i = 0; i < arrIDDVNhomCLS.Rows.Count; i++)
            {
                html += "<input  type=\"button\" style=\"cusor:pointer\" onclick=\"ChonCLS(this,'" + arrIDDVNhomCLS.Rows[i]["idDV"].ToString() + "');\" name=\"rbnSearchNhom\" value=\"" + arrIDDVNhomCLS.Rows[i]["tenNhom"].ToString() + "\"/>";
                html += "&nbsp;";
            }
            html += "<br/>";
        }
        string selectTenPhong = "select tenphongkhambenh,pkb.idphongkhambenh from phongkhambenh pkb where loaiphong=1 order by pkb.idphongkhambenh";
        DataTable arrT = DataAcess.Connect.GetTable(selectTenPhong);
        html += "Tên Khoa/Phòng:";
        for (int i = 0; i < arrT.Rows.Count; i++)
        {

            html += "<input  style=\"width:auto\" type=\"button\" onclick=\"ChonCLS(this,null,'" + arrT.Rows[i]["idphongkhambenh"].ToString() + "');\" name=\"rbnSearch\" value=\"" + arrT.Rows[i]["tenphongkhambenh"].ToString() + "\"/>";

        }

        //}

        html += "<table class='jtable' border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\">";


        //string sqlSelectTenNhom = ""
        //                            + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh" + "\r\n"
        //                            + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
        //                            + " where  bg.idphongkhambenh= " + idpkb + " AND   loaiphong=1 " + swhere + " " + "\r\n";
        string sqlSelectTenNhom = ""
                                   + " select  distinct bg.tennhom, pkb.idphongkhambenh,pkb.tenphongkhambenh,isnull(TTUUCapCuu_Nhom,1000) as TTUU" + "\r\n"
                                   + " from banggiadichvu bg left join phongkhambenh pkb on bg.idphongkhambenh = pkb.idphongkhambenh" + "\r\n"
                                   + " where  bg.idphongkhambenh= " + idpkb + " AND   loaiphong=1 " + swhere + " " + "\r\n"
       + " --and isnull(TTUUCapCuu_Nhom,1000)<>1000 " + "\r\n"
       + " order by TTUU    " + "\r\n";


        DataTable arrT1 = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
        int mkvclick = 0;
        if (arrT1 != null && arrT1.Rows.Count != 0)
        {
            if (arrT1.Rows.Count >= 4)
            {
                string tenPKB = arrT1.Rows[0]["tenphongkhambenh"].ToString();
                string tenN = "";

                for (int i = 0; i < arrT1.Rows.Count; i++)
                {
                    tenN = tenN + arrT1.Rows[i]["tennhom"].ToString() + ",";
                    string t = arrT1.Rows[i]["tennhom"].ToString();
                    string tNext = "";
                    if (i < arrT1.Rows.Count - 1)
                    {
                        tNext = arrT1.Rows[i + 1]["tennhom"].ToString();
                    }
                    else
                        tNext = arrT1.Rows[i]["tennhom"].ToString();
                    html += "<td align=\"left\" style=\"width:20%\" class=\"ptext\" >";

                    html += "<a style=\"cusor:pointer\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";
                    if (((i + 1) % 4) == 0)
                    {
                        html += "</tr>";
                    }


                }
                tenN = tenN.TrimEnd(',');
                //if (swhere != "")
                //{
                //    html += "<td align=\"left\"  style=\"width:30%\" class=\"ptext\" >";
                //    html += "<a href=\"#\" style=\"color:green\" onclick=\"setAllDV('" + idDVPKB + "','" + tenN + "'," + idpkb + ");\" name=\"rbnSearchAll\" >" + tenPKB + " Tổng hợp" + "</a>";
                //    html += "</td>";
                //}
            }
            else
            {
                string tenPKB = arrT1.Rows[0]["tenphongkhambenh"].ToString();
                string tenN = "";
                for (int i = 0; i < arrT1.Rows.Count; i++)
                {
                    tenN = tenN + arrT1.Rows[i]["tennhom"].ToString() + ",";
                    string t = arrT1.Rows[i]["tennhom"].ToString();
                    string tNext = "";
                    if (i < arrT1.Rows.Count - 1)
                    {
                        tNext = arrT1.Rows[i + 1]["tennhom"].ToString();
                    }
                    else
                        tNext = arrT1.Rows[i]["tennhom"].ToString();
                    html += "<td align=\"left\"  style=\"width:30%\" class=\"ptext\" >";

                    html += "<a style=\"cusor:pointer\" onclick=\"javascript:$('#mkv" + mkvclick + "').focus();\">" + t + "</a>";
                    mkvclick++;
                    html += "</td>";

                }
                tenN = tenN.TrimEnd(',');
                //if (swhere != "")
                //{
                //    html += "<td align=\"left\"  style=\"width:30%\" class=\"ptext\" >";
                //    html += "<a href=\"#\" style=\"color:green\" onclick=\"setAllDV('" + idDVPKB + "','" + tenN + "'," + idpkb + ");\" name=\"rbnSearchAll\" >" + tenPKB + " Tổng hợp" + "</a>";
                //    html += "</td>";
                //}
            }
        }

        html += "</tr>";



        html += "</table>";


        string idDVCLSByTN = "";

        DataTable arr = DataAcess.Connect.GetTable(sqlSelectTenNhom);
        int mkv = 0;
        foreach (DataRow h in arr.Rows)
        {
            html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\" class='jtable'>";
            string t = h["tennhom"].ToString();
            string idBNinSelect = IdBenhNhan != "" ? "," + IdBenhNhan : ",0";
            //string sqlSelectIDDVByTN = ""
            //    + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.GiaBH,A.PhuThuBH,BNPhaiTra=DBO.KB_GETSOTIEN_BNTra(a.idbanggiadichvu" + idBNinSelect + ") " + "\r\n"
            //    + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "'"
            //    + " and a.idphongkhambenh='" + idpkb + "'"
            //    + " order by A.tendichvu" + "\r\n"
            //    + "  " + "\r\n";
            string sqlSelectIDDVByTN = ""
                + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.GiaBH,A.PhuThuBH,BNPhaiTra=DBO.KB_GETSOTIEN_BNTra(a.idbanggiadichvu" + idBNinSelect + ") " + "\r\n"
                + " ,isnull(TTUTCapCuu_DV,1000) as TTUT" + "\r\n"
                + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "'"
                + " and a.idphongkhambenh='" + idpkb + "'"
                + " --and isnull(TTUTCapCuu_DV,1000)<>1000 " + "\r\n"
            + " order by TTUT, A.tendichvu " + "\r\n"
                + "  " + "\r\n";
            DataTable arrIDDVByTN = DataAcess.Connect.GetTable(sqlSelectIDDVByTN);
            foreach (DataRow idDVByTN in arrIDDVByTN.Rows)
            {
                idDVCLSByTN = idDVCLSByTN + idDVByTN["idbanggiadichvu"].ToString() + ",";
            }
            html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" width=\"100%\">";
            string t1 = Request.QueryString["checkTN"];
            if (Request.QueryString["checkTN"] != null && Request.QueryString["checkTN"] != "")
            {

                int dk = 0;
                string[] arrTenNhom = t1.Split(',');
                for (int i = 0; i < arrTenNhom.Length; i++)
                {
                    string tam = arrTenNhom[i].ToString();
                    if (t == tam)
                    {
                        html += "<th align=\"left\" width='20px'>&nbsp;<input checked id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                        dk = 1;
                        break;
                    }
                    else
                    {
                        dk = 0;
                    }
                }
                if (dk == 0)
                {
                    html += "<th align=\"left\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
                }


            }
            else
            {
                html += "<th align=\"right\" width='20px'>&nbsp;<input id=\"chkCheckAll\" style=\"border-color:red;border-style:groove;\" onclick=\"checkAllCLS(this);\" type=\"checkbox\" /></th>";
            }
            html += "<th  align=\"left\" width=\"70%\" class=\"ptext\" ><input style=\"width:auto\" type=\"button\" id=\"mkv" + mkv + "\" style=\"font-weight:bold\" value=\"" + t + "\"/></th>";
            html += "<th  width=\"10%\" forecolor=\"Blue\" align=\"left\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;Đơn giá</th>";
            //html += "<td  width=\"10%\" align=\"center\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;forecolor=\"Blue\";\" class=\"ptext\" >&nbsp;Số lượng</td>";
            html += "</tr>";
            mkv++;
            //string sqlSelectTenDV = ""
            //  + " select A.idbanggiadichvu,A.tendichvu,A.giadichvu,A.GiaBH,A.PhuThuBH ,BNPhaiTra=DBO.KB_GETSOTIEN_BNTra(a.idbanggiadichvu," + IdBenhNhan + ")" + "\r\n"
            //  + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "'"
            //  + " and a.idphongkhambenh='" + idpkb + "'"
            //  + " order by A.tendichvu" + "\r\n"
            //  + "  " + "\r\n";
            string sqlSelectTenDV = ""
              + " select A.idbanggiadichvu,A.tendichvu,isnull(A.giadichvu,0) as giadichvu,isnull(A.GiaBH,0) as GiaBH,isnull(A.PhuThuBH,0)PhuThuBH ,BNPhaiTra=DBO.KB_GETSOTIEN_BNTra(a.idbanggiadichvu," + IdBenhNhan + ")" + "\r\n"
              + " ,isnull(TTUTCapCuu_DV,1000) as TTUT" + "\r\n"
              + " from banggiadichvu a where A.tennhom = N'" + h["tennhom"] + "'"
              + " and a.idphongkhambenh='" + idpkb + "'"
              + " --and isnull(TTUTCapCuu_DV,1000)<>1000 " + "\r\n"
            + " order by TTUT, A.tendichvu " + "\r\n"
              + "  " + "\r\n";
            idDVCLSByTN = "";
            DataTable arrTenDV = DataAcess.Connect.GetTable(sqlSelectTenDV);
            {
                if (arrTenDV.Rows.Count != 0)
                {
                    foreach (DataRow tenDV in arrTenDV.Rows)
                    {


                        int dk = 0;
                        html += "<tr width=\"100%\">";
                        string id = tenDV["idbanggiadichvu"].ToString();
                        for (int i = 0; i < arridcls.Length; i++)
                        {
                            string tam = arridcls[i].ToString();
                            if (id == tam)
                            {
                                html += "<td align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" checked  type=\"checkbox\" /></td>";
                                dk = 1;
                                break;
                            }
                            else
                            {
                                dk = 0;
                            }
                        }
                        if (dk == 1)
                        {

                        }
                        else
                        {
                            html += "<td align=\"right\">&nbsp;<input id=\"chkIDDVCLS\" onclick=\"setChonDichVuCLS(this)\" value=\"" + tenDV["idbanggiadichvu"] + "\" type=\"checkbox\" /></td>";
                        }

                        html += "<td width=\"70%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" align=\"left\" style='text-align:left'>&nbsp;" + tenDV["tendichvu"] + "</td>";
                        html += "<td width=\"20%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px\">" + StaticData.FormatNumber(tenDV[DonGiaName], false).ToString() + "</td>";
                        //html += "<td width=\"10%\" align=\"center\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;1</td>";
                        html += "</tr>";
                    }

                }
            }
            html += "</table>";
        }

        Response.Clear();
        Response.Write(html);
    }

    private void Loadsauhuongdieutri()
    {
        string html = "";
        string huongdieutri = Request.QueryString["huongdieutri"];

        if (huongdieutri == "4")
        {

            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("denbv") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='ghichuhuongdieutri' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_ghichuhuongdieutri' type='text' onfocus='chuyenphim(this);ghichuhuongdieutriSearch(this);'" + "\r\n"
    + "                         class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
        }
        else if (huongdieutri == "12" || huongdieutri == "1" || huongdieutri == "18")
        {
            #region mặc định Khoa
            string IdKhoa = ""; string TenKhoa = "";
            try
            {
                DataTable dtKhoa = DataAcess.Connect.GetTable("select * from phongkhambenh where idphongkhambenh='" + Request.QueryString["idkhoa"] + "'");
                if (dtKhoa != null && dtKhoa.Rows.Count > 0)
                {
                    IdKhoa = dtKhoa.Rows[0]["idphongkhambenh"].ToString();
                    TenKhoa = dtKhoa.Rows[0]["tenphongkhambenh"].ToString();
                }
            }
            catch (Exception ex) { }
            #endregion
            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("khoakhambenh") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='khoakhambenh' value='"+IdKhoa+"' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_khoakhambenh'  value='" + TenKhoa + "' type='text' onfocus='chuyenphim(this);khoakhambenhSearch(this,\"" + huongdieutri + "\");'" + "\r\n"
    + "                         class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
            #region mặc định dịch vụ
            string idDichVu = ""; string TenDichVu = "";
            try
            {
                string dk = "";
                if (Request.QueryString["huongdieutri"] == "18")
                    dk = " and madichvu in ('3000')";                
                else
                    dk = " and madichvu not in('3000','3001')";
                DataTable dtKhoa = DataAcess.Connect.GetTable("select * from banggiadichvu where  idbanggiadichvu <> 1790 and  idphongkhambenh='" + Request.QueryString["idkhoa"] + "' " + dk);
                if (dtKhoa != null && dtKhoa.Rows.Count > 0)
                {
                    idDichVu = dtKhoa.Rows[0]["idbanggiadichvu"].ToString();
                    TenDichVu = dtKhoa.Rows[0]["tendichvu"].ToString();
                }
            }
            catch (Exception ex) { }
            #endregion
            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("dichvu") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='idDVPhongChuyenDen' value='"+idDichVu+"' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_idDVPhongChuyenDen' value='"+TenDichVu+"' type='text' onfocus='chuyenphim(this);banggiadichvuSearch(this);'" + "\r\n"
    + "                         class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("phong") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='idPhongChuyenDen' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_idPhongChuyenDen' type='text' onfocus='chuyenphim(this);phongkhambenhSearch(this);' class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
        }
        else if (huongdieutri == "8")
        {
            html += " <div class='div-Out'>" + "\r\n"
    + "                 <div class='div-Left' style='color:green'>" + "\r\n"
    + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("khoakhambenh") + "" + "\r\n"
    + "                 </div>" + "\r\n"
    + "                 <div class='div-Right'>" + "\r\n"
    + "                     <input mkv='true' id='phongkhamchuyenden' type='hidden' />" + "\r\n"
    + "                     <input mkv='true' id='mkv_phongkhamchuyenden' type='text' onfocus='chuyenphim(this);khoakhambenhSearch(this,\"" + huongdieutri + "\");'" + "\r\n"
    + "                         class='down_select_hover' style='width: 90%' />" + "\r\n"
    + "                 </div>" + "\r\n"
    + "             </div>" + "\r\n";
        }
        else
        {

        }
        Response.Clear();
        Response.Write(html);
    }


    private void Setsauhuongdieutri()
    {
        string html = "";
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string idkhambenhgoc = Request.QueryString["idkhambenhgoc"];
        string dk = "";
        if (!string.IsNullOrEmpty(idkhoachinh))
            dk = " KB.IDKHAMBENH='" + idkhoachinh + "'";
        else
            dk = " KB.IDKHAMBENH='" + idkhambenhgoc + "'";
        DataTable table = DataAcess.Connect.GetTable(@"SELECT top 1 
            KB.*,
            P.TENPHONG AS TENPHONG,
            h.tenhuongdieutri as mkv_huongdieutri,
            bv.tenbenhvien as mkv_ghichuhuongdieutri,
            bg.tendichvu as mkv_idDVPhongChuyenDen
        ,pk.idphongkhambenh,pk.tenphongkhambenh
        ,kb.phongkhamchuyenden,tenphongNT= pk1.tenphongkhambenh
            FROM Khambenh kb 
            LEFT JOIN KB_PHONG P ON P.id=KB.idPhongChuyenDen
            left join kb_huongdieutri h on h.huongdieutriid = kb.huongdieutri
            left join benhvien bv on bv.idbenhvien = kb.ghichuhuongdieutri
            left join banggiadichvu bg on bg.idbanggiadichvu = kb.idDVPhongChuyenDen
        left join phongkhambenh pk on pk.idphongkhambenh=bg.idphongkhambenh
    left join phongkhambenh pk1 on pk1.idphongkhambenh=kb.phongkhamchuyenden
            WHERE " + dk);
        if (table.Rows.Count > 0)
        {
            string huongdieutri = table.Rows[0]["huongdieutri"].ToString();
            if (huongdieutri == "4")
            {

                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("denbv") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"ghichuhuongdieutri\" type=\"hidden\" value='" + table.Rows[0]["ghichuhuongdieutri"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_ghichuhuongdieutri\" type=\"text\" onfocus=\"chuyenphim(this);ghichuhuongdieutriSearch(this);\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" value='" + table.Rows[0]["mkv_ghichuhuongdieutri"] + "'/>" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
            }
            else if (huongdieutri == "12" || huongdieutri == "1" || huongdieutri == "18" )
            {
                string dk2 = "";
                if (Request.QueryString["huongdieutri"] == "1")
                    dk2 = " and idphongkhambenh <> 15";
                else 
                    dk2 = " and idphongkhambenh = 15";
                DataTable tablekhoakhambenh = DataAcess.Connect.GetTable("SELECT * FROM phongkhambenh where loaiphong=0 " + dk2);

                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("khoakhambenh") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"khoakhambenh\" type=\"hidden\" value='" + table.Rows[0]["IDPHONGKHAMBENH"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_khoakhambenh\" type=\"text\" value='" + table.Rows[0]["tenphongkhambenh"] + "' onfocus=\"chuyenphim(this);khoakhambenhSearch(this,'" + huongdieutri + "');\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" />" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("dichvu") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"idDVPhongChuyenDen\" type=\"hidden\" value='" + table.Rows[0]["idDVPhongChuyenDen"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_idDVPhongChuyenDen\" type=\"text\" value='" + table.Rows[0]["mkv_idDVPhongChuyenDen"] + "' onfocus=\"chuyenphim(this);banggiadichvuSearch(this);\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" />" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("phong") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"idPhongChuyenDen\" type=\"hidden\" value='" + table.Rows[0]["idPhongChuyenDen"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_idPhongChuyenDen\" type=\"text\" value='" + table.Rows[0]["TENPHONG"] + "' onfocus=\"chuyenphim(this);phongkhambenhSearch(this);\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" />" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
            }
            else if (huongdieutri == "8")
            {
                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("khoakhambenh") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"phongkhamchuyenden\" type=\"hidden\" value='" + table.Rows[0]["phongkhamchuyenden"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_phongkhamchuyenden\" type=\"text\" value='" + table.Rows[0]["tenphongNT"] + "' onfocus=\"chuyenphim(this);khoakhambenhSearch(this,'" + huongdieutri + "');\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" />" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
            }
            else
            {

            }
        }
        Response.Clear();
        Response.Write(html);
    }
    //
    private void SethuongdieutriTheoDoiCapCuu()
    {
        string html = "";
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string idkhambenhgoc = Request.QueryString["idkhambenhgoc"];
        string dk = "";
        if (!string.IsNullOrEmpty(idkhoachinh))
            dk = " KB.IDKHAMBENH='" + idkhoachinh + "'";
        else
            dk = " KB.IDKHAMBENH='" + idkhambenhgoc + "'";
        DataTable table = DataAcess.Connect.GetTable(@"SELECT top 1 
            KB.*,
            P.TENPHONG AS TENPHONG,
            h.tenhuongdieutri as mkv_huongdieutri,
            bv.tenbenhvien as mkv_ghichuhuongdieutri,
            bg.tendichvu as mkv_idDVPhongChuyenDen
        ,pk.idphongkhambenh,pk.tenphongkhambenh
        ,kb.phongkhamchuyenden,tenphongNT= pk1.tenphongkhambenh
            FROM Khambenh kb 
            LEFT JOIN KB_PHONG P ON P.id=KB.idPhongChuyenDen
            left join kb_huongdieutri h on h.huongdieutriid = kb.huongdieutri
            left join benhvien bv on bv.idbenhvien = kb.ghichuhuongdieutri
            left join banggiadichvu bg on bg.idbanggiadichvu = kb.idDVPhongChuyenDen
        left join phongkhambenh pk on pk.idphongkhambenh=bg.idphongkhambenh
    left join phongkhambenh pk1 on pk1.idphongkhambenh=kb.phongkhamchuyenden
            WHERE " + dk);
        if (table.Rows.Count > 0)
        {
            string huongdieutri = table.Rows[0]["huongdieutri"].ToString();
            string TenHuongDieuTri = DataAcess.Connect.GetTable("SELECT tenhuongdieutri FROM kb_huongdieutri where huongdieutriid in (" + huongdieutri + @")").Rows[0]["tenhuongdieutri"].ToString();

                html += " <div class=\"div-Out\">" + "\r\n"
        + "                 <div class=\"div-Left\" style='color:green'>" + "\r\n"
        + "                     " + hsLibrary.clDictionaryDB.sGetValueLanguage("denbv") + "" + "\r\n"
        + "                 </div>" + "\r\n"
        + "                 <div class=\"div-Right\">" + "\r\n"
        + "                     <input mkv=\"true\" id=\"ghichuhuongdieutri\" type=\"hidden\" value='" + table.Rows[0]["ghichuhuongdieutri"] + "'/>" + "\r\n"
        + "                     <input mkv=\"true\" id=\"mkv_ghichuhuongdieutri\" type=\"text\" onfocus=\"chuyenphim(this);ghichuhuongdieutriSearch(this);\"" + "\r\n"
        + "                         class=\"down_select_hover\" style=\"width: 90%\" value='" + table.Rows[0]["mkv_ghichuhuongdieutri"] + "'/>" + "\r\n"
        + "                 </div>" + "\r\n"
        + "             </div>" + "\r\n";
                html = "<input mkv=\"true\" id=\"huongdieutri\" value='" + huongdieutri + "' type=\"hidden\" /> "
        + "        <input mkv=\"true\" id=\"mkv_huongdieutri\" value='" + TenHuongDieuTri + "' type=\"text\" onfocus=\"chuyenphim(this);huongdieutrisearch(this);\" "
        + "            class=\"down_select_hover\" style=\"width: 90%\" />";
        }
        Response.Clear();
        Response.Write(html);
    }
    //
    private void Xoakhambenh()
    {
        try
        {
            DataProcess process = s_khambenh();
            bool ok = process.Delete();
            if (ok)
            {
                DataAcess.Connect.Exec("delete from kb_giuongphieuthanhtoan where idptt = " + process.getData("idkhambenh"));
                Response.Clear(); Response.Write(process.getData("idkhambenh"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void chandoanbandausearch()
    {
        string where = "";
        if (Request.QueryString["loaiicd"].ToString() == "maicd")
        {
            where = " maicd like N'%" + Request.QueryString["q"] + "%'";
        }
        else
        {
            where = " mota like N'%" + Request.QueryString["q"] + "%'";
        }
        DataTable table = DataAcess.Connect.GetTable("SELECT top 20 * FROM chandoanicd where "+where);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString()+" - "+table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void ghichuhuongdieutriSearch()
    {
        string TenBV = Request.QueryString["q"].ToString();
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM benhvien where tenbenhvien like N'%"+TenBV+"%'");
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
    private void IdDieuDuongsearch()
    {
        string TenDieuDuong = Request.QueryString["q"].ToString();
        DataTable table = DataAcess.Connect.GetTable("select * from nguoidung where nhomid = 7 and tennguoidung like N'%" + TenDieuDuong+ "%'");
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
    
    private void idkhosearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select idkho,tenkho from khothuoc where idkhoa = (select idphongkhambenh from khambenh where idkhambenh='"+Request.QueryString["idkhambenhgoc"]+"')");
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
    private void khoakhambenhSearch()
    {
        string dk = "";
        if (Request.QueryString["huongdieutri"] == "1")
            dk = " and idphongkhambenh <> 15";
        else if (Request.QueryString["huongdieutri"] == "18" || Request.QueryString["huongdieutri"] == "12")
            dk = " and idphongkhambenh = 15";
        else
            dk = " and maphongkhambenh in('02','03','04')";
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM phongkhambenh where loaiphong=0 " + dk);
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
    private void banggiadichvuSearch()
    {
        string dk = "";
        if (Request.QueryString["huongdieutri"] == "18")
            dk = " and madichvu in ('3000')";
        else if (Request.QueryString["huongdieutri"] == "8" && Request.QueryString["khoakhambenh"]=="2")//Khoa Ngoại
            dk = " and madichvu  in('3002')";
        else if (Request.QueryString["huongdieutri"] == "8" && Request.QueryString["khoakhambenh"] == "3")//Khoa Sản
            dk = " and madichvu  in('3003')";
        else if (Request.QueryString["huongdieutri"] == "8" && Request.QueryString["khoakhambenh"] == "4")//Khoa Nội
            dk = " and madichvu  in('3004')";
        else
            dk = " and madichvu <> '3000' and madichvu <> '3001'";
        string sql = "SELECT * FROM banggiadichvu where idbanggiadichvu <> 1790 and idphongkhambenh='" + Request.QueryString["khoakhambenh"] + "' " + dk + "";
        DataTable table = DataAcess.Connect.GetTable(sql);
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
    private void phongkhambenhSearch()
    {
        string dkLoaiBN = "";
        try {
            string idbenhnhan = Request.QueryString["idbenhnhan"];
            string loaibn = DataAcess.Connect.GetTable("select loaiBN=isnull((select loai from benhnhan where idbenhnhan ='" + idbenhnhan + "'),0)").Rows[0]["loaiBN"].ToString();
            if (loaibn.Equals("2"))
                dkLoaiBN = " and loaiBN =0 ";
            else if (loaibn.Equals("1"))
                dkLoaiBN = " and loaiBN =0 ";
        }
        catch (Exception ex) { }
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM kb_phong where dichvukcb='" + Request.QueryString["banggiadichvu"] + "' "+dkLoaiBN+"");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + " - " + table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void giuongsearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT a.giuongid,a.giuongcode,b.giadv FROM kb_giuong a left join kb_banggiagiuong b on a.giuongid = b.giuongid");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += "<div style='float:left;width:70%'>" + table.Rows[i][1].ToString() + "</div>" + "<div style='float:left;width:30%'>" + table.Rows[i][2].ToString() + "</div>" + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][2].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idcanlamsansearch()
    {
        DataTable table = DataAcess.Connect.GetTable(@"SELECT top 20 * FROM banggiadichvu  left join phongkhambenh on phongkhambenh.idphongkhambenh=banggiadichvu.idphongkhambenh
 where loaiphong=1 and  tendichvu like N'" + Request.QueryString["q"] + "%'");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString() + "|" + table.Rows[i][4].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void loaithuocidsearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT top 20 * FROM thuoc_loaithuoc");
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
    private void idthuocsearch()
    {
        string idKho = Request.QueryString["idkho"];
        if (idKho == "") idKho = StaticData.MacDinhKhoNhapMuaID;
        string loaithuocid = "";
        if (Request.QueryString["loaithuocid"].ToString() != "")
            loaithuocid = " and B.loaithuocid = " + Request.QueryString["loaithuocid"];
        string sqlThuoc = @"SELECT top 20 B.idthuoc
                                    ,B.tenthuoc
                                    ,B.sttindm05
                                    ,B.iddvt
                                    ,B.congthuc
                                    ,B.TTHoatChat
                                    ,SLTON=DBO.Thuoc_TonKho_new_1910(DBO.Thuoc_Top1IDthuoc( B.IDTHUOC),GETDATE()," + idKho + @") 
                                    ,C.TenDVt
                                    ,Top1IDthuoc=DBO.Thuoc_Top1IDthuoc( B.IDTHUOC)
                                 From     thuoc B 
                            LEFT JOIN THUOC_DONVITINH C ON B.IDDVT=C.ID
                            WHERE 1=1 and B.tenthuoc like N'" + Request.QueryString["q"] + "%' "+loaithuocid+""
                            + " ORDER BY B.TENTHUOC,B.TTHOATCHAT,B.CONGTHUC";

        DataTable table = DataAcess.Connect.GetTable(sqlThuoc);
        table.DefaultView.RowFilter = "Top1IDthuoc=IDThuoc";
        table = table.DefaultView.ToTable();

        string html = "";
        html = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", ""
       + "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
       + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Biệt dược</div>"
       + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >TT HC</div>"
       + "<div style=\"width:30%;height:30px;color:#000;font-weight:bold;float:left\" >Hoạt chất</div>"
       + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left;\" >ĐVT</div>"
       + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >SLTon </div>"
       + "</div>", "", "", "", "", "", Environment.NewLine);
        for (int i = 0; i < table.Rows.Count; i++)
        {

            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", "<div>"
        + "<div style=\"width:5%;height:30px;float:left\" >" + i + 1 + "</div>"
        + "<div style=\"width:30%;height:30px;float:left\" >" + h["tenthuoc"] + "</div>"
        + "<div style=\"width:10%;height:30px;float:left\" >" + h["TTHoatChat"] + "</div>"
        + "<div style=\"width:30%;height:30px;float:left\" >" + h["congthuc"] + "</div>"
        + "<div style=\"width:10%;height:30px;float:left\" >" + h["TenDVT"] + "</div>"
        + "<div style=\"width:15%;height:30px;float:left\" >" + h["SLTON"] + "</div>"
         + "</div>", h["idthuoc"], h["congthuc"], h["iddvt"], h["tenthuoc"], h["sttindm05"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void huongdieutrisearch()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM kb_huongdieutri where huongdieutriid in (3,4,11,12,13,14,16,17,18) order by tenhuongdieutri");
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
    private void huongdieutrisearch_KhamcapCuu()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM kb_huongdieutri where huongdieutriid in (3,4,11,12,13,14,16,8,18) order by tenhuongdieutri ");
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
    private void huongdieutrisearch_KhamKhoaSan()
    {
        DataTable table = DataAcess.Connect.GetTable("SELECT * FROM kb_huongdieutri where huongdieutriid in (3,4,11,13,14,8) order by tenhuongdieutri ");
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
    private void Xoachitietbenhnhantoathuoc()
    {
        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void Xoakhambenhcanlamsan()
    {
        try
        {
            DataProcess process = s_khambenhcanlamsan();
            string idKhamBenhCLS = process.getData("idkhambenhcanlamsan");
            string sqlCLS = "select isnull(dathu,0) as TinhTrangDathu,isnull(dahuy,0) as TinhTrangDaHuy,* from khambenhcanlamsan where idkhambenhcanlamsan=" + idKhamBenhCLS;
            DataTable dtCLS = DataAcess.Connect.GetTable(sqlCLS);
            if (dtCLS.Rows[0]["TinhTrangDathu"].ToString() == "1" || dtCLS.Rows[0]["TinhTrangDathu"].ToString() == "True")
                if (dtCLS.Rows[0]["TinhTrangDaHuy"].ToString() == "0" || dtCLS.Rows[0]["TinhTrangDaHuy"].ToString() == "False")
                    return;
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
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
        string idkhoachinh = Request.QueryString["idkhoachinh"];
        string idkhambenhgoc = Request.QueryString["idkhambenhgoc"];
        string dk = "";
        if (!string.IsNullOrEmpty(idkhoachinh))
            dk = " KB.IDKHAMBENH='" + idkhoachinh + "'";
        else
            dk = " KB.IDKHAMBENH='" + idkhambenhgoc + "'";
        DataTable table = DataAcess.Connect.GetTable(@"SELECT top 1 
            KB.*,
            BN.IDBENHNHAN AS idbenhnhan,
            K.TENPHONGKHAMBENH AS TENKHOA,
            P.TENPHONG AS TENPHONG,
            BN.TENBENHNHAN AS TENBENHNHAN,
    BN.mabenhnhan AS mabenhnhan,
            BN.NGAYSINH AS NGAYSINH,
            case BN.GIOITINH when 0 then N'Nam' else N'Nữ' end AS GIOITINH,
            icd.mota as mkv_ketluan,
            g.tengiuong as mkv_giuong,
            g.dongia as giagiuong,
            h.tenhuongdieutri as mkv_huongdieutri,
            nd.tennguoidung as mkv_IdDieuDuong,
            bs.tenbacsi as mkv_idbacsi,
            MACH =(SELECT TOP 1 MACH FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC ),
            NHIETDO =(SELECT TOP 1 NHIETDO FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC ),
            HUYETAP =(SELECT TOP 1 CONVERT(NVARCHAR(10),HUYETAP1)+'/'+ CONVERT(NVARCHAR(10),HUYETAP2) AS HUYETAP FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC ),
            NHIPTHO =(SELECT TOP 1 NHIPTHO FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC ),
            CANNANG =(SELECT TOP 1 CANNANG FROM SINHHIEU WHERE IDDANGKYKHAM=KB.IDDANGKYKHAM ORDER BY IDSINHHIEU DESC )
            FROM BENHNHAN BN 
            LEFT JOIN KHAMBENH KB ON KB.IDBENHNHAN=BN.IDBENHNHAN
            LEFT JOIN PHONGKHAMBENH K ON K.IDPHONGKHAMBENH=KB.IDPHONGKHAMBENH
            LEFT JOIN KB_PHONG P ON P.id=KB.idPhongChuyenDen
            left join kb_giuongphieuthanhtoan g on g.idptt=kb.idkhambenh
            left join kb_huongdieutri h on h.huongdieutriid = kb.huongdieutri
            left join nguoidung nd on nd.idnguoidung = kb.iddieuduong
            left join chandoanicd icd on icd.idicd=kb.ketluan
            left join bacsi bs on bs.idbacsi = kb.idbacsi
            WHERE " + dk);
        string html = "";
        html += "<root>";
        if (!string.IsNullOrEmpty(idkhoachinh))
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

    private void Savekhambenh()
    {
        try
        {
            DataProcess process = s_khambenh();
            if (process.getData("huongdieutri") == "8" || process.getData("huongdieutri") == "12" || process.getData("huongdieutri") == "13")
            {
                string idchitietdangkykham = process.getData("idchitietdangkykham");

                DataTable dtSVV = DataAcess.Connect.GetTable("select isnull(sovaovien,0) as SoVV,* from khambenh where idchitietdangkykham =" + idchitietdangkykham);
                bool ChuaCoSoVaoVien = true;
                int Dong = 0;
                for (int i = 0; i < dtSVV.Rows.Count; i++)
                {
                    if (dtSVV.Rows[i]["SoVV"].ToString() != "0" && dtSVV.Rows[i]["SoVV"].ToString() != "")
                    { ChuaCoSoVaoVien = false; Dong = i; }
                }
                string SoVVien = "";
                if (dtSVV.Rows.Count > 0) SoVVien = dtSVV.Rows[Dong]["SoVV"].ToString();
                if (ChuaCoSoVaoVien)
                    process.data("sovaovien", StaticData.NewSoVaoVien(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));
                else
                    process.data("sovaovien", SoVVien);
            }
            DataProcess pro = new DataProcess("kb_giuongphieuthanhtoan");
            pro.data("tengiuong", Request.QueryString["mkv_giuong"]);
            pro.data("donvi", "Ngay");
            pro.data("soluong", "1");
            pro.data("dongia", Request.QueryString["giagiuong"]);
            pro.data("thanhtien", Request.QueryString["giagiuong"]);


            DataProcess cdphoihop = new DataProcess("chandoanphoihop");
            cdphoihop.data("idkhambenh",Request.QueryString["idkhoachinh"]);
            cdphoihop.Delete();

            string idcdphoihop = Request.QueryString["idicd"];
            
            if (process.getData("idkhambenh") != null && process.getData("idkhambenh") != "")
            {
                bool ok = process.Update();
                if (!ok)
                {
                    Response.StatusCode = 500;
                    return;
                }
            }
            else
            {
                process.data("ngaykham",DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("dd/MM/yyyy HH:mm"));
                process.data("maphieukham",StaticData.CreateIDTheoThuTu("PKB","khambenh","maphieukham","idkhambenh"));
                
                bool ok = process.Insert();
                if (!ok)
                {

                    Response.StatusCode = 500;
                    return;
                }
            }
            //luu chuan doan phoi hop
            if (idcdphoihop != null && idcdphoihop != "")
            {
                string[] arrCDPH = idcdphoihop.Split(',');
                if (idcdphoihop != "" && idcdphoihop != "0")
                {
                    for (int i = 0; i < arrCDPH.Length; i++)
                    {
                        cdphoihop.data("id", Request.QueryString["id"]);
                        cdphoihop.data("idkhambenh", Request.QueryString["idkhoachinh"]);
                        cdphoihop.data("idicd", arrCDPH[i]);
                        DataTable dtPH = DataAcess.Connect.GetTable("select maicd from chandoanicd where idicd=" + arrCDPH[i] + "");
                        string MaCDPH = "";
                        if (dtPH != null && dtPH.Rows.Count > 0)
                            MaCDPH = dtPH.Rows[0]["maicd"].ToString();
                        cdphoihop.data("maicd", MaCDPH);
                        cdphoihop.Insert();
                    }
                }
            }
            pro.data("idptt", process.getData("idkhambenh"));
            if (DataAcess.Connect.GetTable("select idgiuong from kb_giuongphieuthanhtoan where idptt='" + process.getData("idkhambenh") + "'").Rows.Count > 0)
            {
                pro.Update("idptt");
            }
            else
            {
                pro.Insert();
            }
            Response.Clear(); Response.Write(process.getData("idkhambenh"));
            return;
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablechitietbenhnhantoathuoc()
    {

        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            if (process.getData("idthuoc").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }
            if (process.getData("idchitietbenhnhantoathuoc") != null && process.getData("idchitietbenhnhantoathuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    #region Kiem Tra insert Tính BH

                    string sqlBN = @"select loai,iscapcuu=dbo.funct_IsCapCuu(iddangkykham)
        ,CoBenhAn=isnull((select top 1 huongdieutri from khambenh where idchitietdangkykham= kb.idchitietdangkykham and huongdieutri in(8,12,13)),0)
        from khambenh kb left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan
                    where kb.idkhambenh=" + process.getData("idkhambenh") + "";
                    DataTable dtbn = DataAcess.Connect.GetTable(sqlBN);
                    if (dtbn != null && dtbn.Rows.Count > 0 && dtbn.Rows[0]["loai"].ToString() == "1" && dtbn.Rows[0]["iscapcuu"].ToString() == "1" && dtbn.Rows[0]["CoBenhAn"].ToString() == "0")
                    {
                        DataTable dtLoad = DataAcess.Connect.GetTable(@"select top 1 *,convert(varchar(10),ngaydangky,111) as Ngay FROM  daNgkykham dkk left join khambenh kb on kb.iddangkykham=dkk.iddangkykham  where kb.idkhambenh=" + process.getData("idkhambenh"));
                        string NgayDangKyKham = StaticData.ConvertDayToyyyyMMdd(dtLoad.Rows[0]["Ngay"].ToString(), "yyyy/MM/dd");
                        string sqlUpdate_KB_TINH_TONGTIEN_BNPHAITRA = " EXEC KB_TINH_TONGTIEN_BNPHAITRA " + dtLoad.Rows[0]["idbenhnhan"].ToString() + ",'" + NgayDangKyKham + "'";
                        bool ktBH = DataAcess.Connect.ExecSQL(sqlUpdate_KB_TINH_TONGTIEN_BNPHAITRA);
                        if (!ktBH) { StaticData.MsgBox(this, "Lỗi BH KH2 !"); }
                    }
                    #endregion
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    #region Kiem Tra insert Tính BH
                    string sqlBN = @"select loai,iscapcuu=dbo.funct_IsCapCuu(iddangkykham)
        ,CoBenhAn=isnull((select top 1 huongdieutri from khambenh where idchitietdangkykham= kb.idchitietdangkykham and huongdieutri in(8,12,13)),0)
        from khambenh kb left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan
                    where kb.idkhambenh=" + process.getData("idkhambenh") + "";
                    DataTable dtbn = DataAcess.Connect.GetTable(sqlBN);
                    if (dtbn != null && dtbn.Rows.Count > 0 && dtbn.Rows[0]["loai"].ToString() == "1" && dtbn.Rows[0]["iscapcuu"].ToString() == "1" && dtbn.Rows[0]["CoBenhAn"].ToString() == "0")
                    {
                        DataTable dtLoad = DataAcess.Connect.GetTable(@"select top 1 *,convert(varchar(10),ngaydangky,111) as Ngay FROM  daNgkykham dkk left join khambenh kb on kb.iddangkykham=dkk.iddangkykham  where kb.idkhambenh=" + process.getData("idkhambenh"));
                        string NgayDangKyKham = StaticData.ConvertDayToyyyyMMdd(dtLoad.Rows[0]["Ngay"].ToString(), "yyyy/MM/dd");
                        string sqlUpdate_KB_TINH_TONGTIEN_BNPHAITRA = " EXEC KB_TINH_TONGTIEN_BNPHAITRA " + dtLoad.Rows[0]["idbenhnhan"].ToString() + ",'" + NgayDangKyKham + "'";
                        bool ktBH = DataAcess.Connect.ExecSQL(sqlUpdate_KB_TINH_TONGTIEN_BNPHAITRA);
                        if (!ktBH) { StaticData.MsgBox(this, "Lỗi BH KH2 !"); }
                    }
                    #endregion
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablechitietbenhnhantoathuocKhamCapCuu()
    {

        try
        {
            DataProcess process = s_chitietbenhnhantoathuoc();
            if (process.getData("idthuoc").Trim() == "")
            {
                Response.StatusCode = 500;
                return;
            }
            if (process.getData("idchitietbenhnhantoathuoc") != null && process.getData("idchitietbenhnhantoathuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietbenhnhantoathuoc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTablekhambenhcanlamsan()
    {
        try
        {
            DataProcess process = s_khambenhcanlamsan();
            if (process.getData("idkhambenhcanlamsan") != null && process.getData("idkhambenhcanlamsan") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                    return;
                }
            }
            else
            {
                string NgayKham = DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("yyyy/MM/dd HH:mm");
                process.data("NgayKham", DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("dd/MM/yyyy HH:mm"));
                process.data("maphieucls", StaticData.NewSoChungTu(NgayKham, "Tên BN chăm sóc", "Thu phí CLS phiếu chăm sóc", "0"));
                process.data("dathu", "0");
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idkhambenhcanlamsan"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTablechitietbenhnhantoathuoc()
    {
        DataProcess process = s_chitietbenhnhantoathuoc();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
                                ,dt.TenDoiTuong
                               from chitietbenhnhantoathuoc T
                                left join thuoc a on a.idthuoc=t.idthuoc
                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
                            left join khothuoc k on k.idkho = T.idkho
                            left join thuoc_doituongthuoc dt on dt.DoiTuongThuocID = t.DoiTuongThuocID
          where T.idkhambenh='" + process.getData("idkhambenh") + "'");
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th></th>";
        html += "<th>Đối tượng</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayuong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("moilanuong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>";
                //
                html += "<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["DoiTuongThuocID"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='" + table.Rows[i]["TenDoiTuong"].ToString() + "' class='down_select'/></td>";
                //
                html += "<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='" + table.Rows[i]["tenkho"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongke"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongtra"].ToString() + "' onblur='TestSo(this,false,false);ktrasltra(this);'/></td>";
                html += "<td><input mkv='true' style='width:70px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:70px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["moilanuong"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + (table.Rows.Count + 1) + "</td>";
        html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
        html += "<td><input  id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>";
        //
        html += "<td><input mkv='true' id='doituongthuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_doituongthuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);doituongthuocidsearch(this)' value='' class='down_select'/></td>";
        //
        html += "<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'></td>";
        html += "<td><input mkv='true' style='width:30px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);ktrasltra(this);' /></td>";
        html += "<td><input mkv='true' style='width:70px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:70px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:100px'/></td>";
        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging("chitietbenhnhantoathuoc");
        Response.Clear(); Response.Write(html);
    }
    public void loadTablechitietbenhnhantoathuocKhamCapCuu()
    {
        DataProcess process = s_chitietbenhnhantoathuoc();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idchitietbenhnhantoathuoc),T.*
                                ,b.loaithuocid,b.tenloai,a.tenthuoc,k.tenkho
                               from chitietbenhnhantoathuoc T
                                left join thuoc a on a.idthuoc=t.idthuoc
                            left join thuoc_loaithuoc b on a.loaithuocid=b.loaithuocid
                            left join khothuoc k on k.idkho = T.idkho
          where T.idkhambenh='" + process.getData("idkhambenh") + "'");
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idkho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongke") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluongtra") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngayuong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("moilanuong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["loaithuocid"].ToString() + "' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='" + table.Rows[i]["tenloai"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='" + table.Rows[i]["tenkho"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='" + table.Rows[i]["tenthuoc"].ToString() + "' class='down_select'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongke"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:30px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["soluongtra"].ToString() + "' onblur='TestSo(this,false,false);ktrasltra(this);'/></td>";
                html += "<td><input mkv='true' style='width:70px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:70px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["moilanuong"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["ghichu"].ToString() + "' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietbenhnhantoathuoc"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + (table.Rows.Count + 1) + "</td>";
        html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
        html += "<td><input  id='loaithuocid' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input id='mkv_loaithuocid' type='text' onfocusout='chuyenformout(this)' style='width:70px' onfocus='chuyenphim(this);loaithuocidsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idkho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idkhosearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='idthuoc' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idthuoc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idthuocsearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' style='width:30px' id='soluongke' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'></td>";
        html += "<td><input mkv='true' style='width:30px' id='soluongtra' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);ktrasltra(this);' /></td>";
        html += "<td><input mkv='true' style='width:70px' id='ngayuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);'/></td>";
        html += "<td><input mkv='true' style='width:70px' id='moilanuong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' style='width:100px'/></td>";
        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging("chitietbenhnhantoathuoc");
        Response.Clear(); Response.Write(html);
    }
    public void loadTablekhambenhcanlamsan()
    {
        DataProcess process = s_khambenhcanlamsan();
        process.NumberRow = "10000";
        process.Page = Request.QueryString["page"];
        DataTable table = process.Search(@"select STT=row_number() over (order by T.idkhambenhcanlamsan),T.*
                                ,a.tendichvu,a.idbanggiadichvu
                               from khambenhcanlamsan T
                                left join banggiadichvu a on t.idcanlamsan=a.idbanggiadichvu
          where T.idkhambenh=" + (process.getData("idkhambenh") == "" ? "null" : "'" + process.getData("idkhambenh") + "'"));
        string html = "";
        html += tableCLS(table, null, true);
        html += process.Paging("khambenhcanlamsan");
        Response.Clear(); 
        Response.Write(html);
    }
    public void loadTableAjaxDSkhambenh()
    {
        if (Request.QueryString["idkhambenhgoc"].ToString() != "")
        {
            DataProcess process = new DataProcess("khambenh");
            process.data("idkhambenhgoc", Request.QueryString["idkhambenhgoc"]);
            process.Page = Request.QueryString["page"];
            process.NumberRow = "50";
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idkhambenh),
		    T.IdKhamBenh,
		    Ngaykham,
		    chandoan=T2.Mota,
            dienbien=trieuchung,
            T3.TenGiuong,
            YLenh=DBO.KB_GetYLenh(t.idKhamBenh),
		    T4.TenBacSi,
            DieuDuong=  T5.TenNguoiDung 
	    from khambenh t
	       left join ChanDoanICD T2 on t.KetLuan=t2.IdICD
		    left join KB_GiuongPhieuThanhToan T3 on t.idkhambenh=t3.IdPTT
           left join bacsi t4 on t.idbacsi=t4.idbacsi
		    left join nguoidung t5 on t.iddieuduong=t5.idnguoidung
        where T.idkhambenhgoc='" + process.getData("idkhambenhgoc") + "'");
            string html = "";
            html += process.Paging("DSkhambenh");
            html += "<table class='jtable' id=\"gridTabledskb\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Ngaykham") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("chandoan") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dienbien") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenGiuong") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("YLenh") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenBacSi") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DieuDuong") + "</th>";
            html += "</tr>";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr style='cursor:pointer;' onclick=\"setControlFind('" + table.Rows[i]["idkhambenh"].ToString() + "');\">";
                        html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["Ngaykham"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["chandoan"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["dienbien"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["TenGiuong"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["YLenh"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["TenBacSi"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["DieuDuong"].ToString() + "</td>";
                        html += "</tr>";
                    }
                }
            }
            html += "</table>";
            html += process.Paging("DSkhambenh");
            Response.Clear(); Response.Write(html);
        }
        else
            Response.StatusCode = 500;
    }
    public void loadTablechandoanphoihop()
    {


        DataProcess process = new DataProcess("chandoanphoihop");
        process.data("idkhambenh", Request.QueryString["idkhambenh"]);
        DataTable table = process.Search(@"select STT=row_number() over (order by T.id),
      A.mota,a.idicd,a.maicd from chandoanphoihop T
            left join chandoanicd A on A.idicd = T.idicd
            where T.idkhambenh='" + process.getData("idkhambenh") + @"'
            ");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<div style='text-align:right;float:left;width:400px;height:30px'>";
                    html += "<a style='cursor:pointer' onclick='$(this).parent().remove();'>Xoá</a> -- ";
                    html += "<input type='hidden' mkv='true' id='idicd' value='" + table.Rows[i]["idicd"].ToString() + "'/>";
                    html += table.Rows[i]["maicd"].ToString() + " - " + table.Rows[i]["mota"].ToString();
                    html += "</div>";
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }


//    public void loadTablechandoanphoihop()
//    {
        

//        DataProcess process = new DataProcess("chandoanphoihop");
//        process.data("idkhambenh",Request.QueryString["idkhambenh"]);
//        DataTable table = process.Search(@"select STT=row_number() over (order by T.id),
//		    A.mota,a.idicd,a.maicd from chandoanphoihop T
//            left join chandoanicd A on A.idicd = T.idicd
//            where T.idkhambenh='"+process.getData("idkhambenh")+@"'
//            ");
//            string html = "";
//            html += process.Paging("chandoanphoihop");
//            html += "<table id=\"gridTablechandoanphoihop\">";
//            if (table != null)
//            {
//                if (table.Rows.Count > 0)
//                {
//                    for (int i = 0; i < table.Rows.Count; i++)
//                    {
//                        html += "<tr>";
//                        html += "<td><input type='hidden' mkv='true' id='idicd' value='" + table.Rows[i]["idicd"].ToString() + "'></input></td>";
//                        html += "<td>" + table.Rows[i]["maicd"].ToString() + " - " + table.Rows[i]["mota"].ToString() + "</td>";
//                        html += "</tr>";
//                    }
//                }
//            }
//            html += "<tr><td></td></tr>";
//            html += "</table>";
//            html += process.Paging("chandoanphoihop");
//            Response.Clear(); Response.Write(html);
//    }
    private string tableCLS(DataTable dt, string[] arrslvack, bool idkhambenhcls)
    {
        string html = "";
        html += "<table class='jtable' id=\"gridTablecls\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idcanlamsan") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("chietkhau") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("thanhtien") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (dt.Rows.Count != 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ck = 0;
                int sl = 1;
                if (arrslvack != null)
                {
                    for (int y = 0; y < arrslvack.Length; y++)
                    {
                        if (arrslvack[y].Split('^')[0].ToString() == dt.Rows[i]["idbanggiadichvu"].ToString() && (int.Parse(arrslvack[y].Split('^')[1].ToString()) > 1 || int.Parse(arrslvack[y].Split('^')[2].ToString()) > 0))
                        {
                            ck = int.Parse(arrslvack[y].Split('^')[2].ToString());
                            sl = int.Parse(arrslvack[y].Split('^')[1].ToString());
                            break;
                        }
                    }
                }
                try
                {
                    ck = int.Parse(dt.Rows[i]["chietkhau"].ToString());
                    sl = int.Parse(dt.Rows[i]["soluong"].ToString());
                }
                catch{}
                int thanhtien = sl * int.Parse(dt.Rows[i]["dongia"].ToString());
                html += "<tr>";
                html += "<td>" + dt.Rows[i]["stt"] + "</td>";
                html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["idbanggiadichvu"] + "' onblur='TestSo(this,false,false);'/><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='" + dt.Rows[i]["tendichvu"] + "' class='down_select'/></td>";
                html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + sl + "' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:70px'/></td>";
                html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + dt.Rows[i]["dongia"] + "' onblur='TestSo(this,false,false);thanhtiencls(this);'/></td>";
                html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ck + "' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:70px'/></td>";

                html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + ((thanhtien - (thanhtien * ck) / 100)).ToString() + "' /></td>";
                html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
                html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + (idkhambenhcls ? dt.Rows[i]["idkhambenhcanlamsan"] : "") + "'/></td>";
                html += "</tr>";
            }
        }
        html += "<tr>";
        html += "<td>" + (dt.Rows.Count + 1) + "</td>";
        html += "<td><a onclick='xoaontablecls(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
        html += "<td><input mkv='true' id='idcanlamsan' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /><input mkv='true' id='mkv_idcanlamsan' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);idcanlamsansearch(this)' value='' class='down_select'/></td>";
        html += "<td><input mkv='true' id='soluong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);'  style='width:70px'/></td>";
        html += "<td><input mkv='true' id='dongia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='TestSo(this,false,false);thanhtiencls(this);' /></td>";
        html += "<td><input mkv='true' id='chietkhau' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='0' onblur='thanhtiencls(this);'  style='width:70px'/></td>";

        html += "<td><input mkv='true' id='thanhtien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";

        html += "<td><input mkv='true' id='ghichu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
        html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
        html += "</tr>";

        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        return html;
    }
}


