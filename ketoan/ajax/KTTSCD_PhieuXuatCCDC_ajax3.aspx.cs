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

public partial class ketoan_ajax_KTTSCD_PhieuXuatCCDC_ajax3 : System.Web.UI.Page
{
    private string TaoMa(string LoaiPhieu, string Bangluu, string Maphieu)
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
    protected DataProcess s_PHIEU_XUAT_VT()
    {
        DataProcess PHIEU_XUAT_VT = new DataProcess("PHIEU_XUAT_VT");
        PHIEU_XUAT_VT.data("phieu_xuat_id", Request.QueryString["idkhoachinh"]);
        if (Request.QueryString["do"] != "TimKiem")
        {
            if (Request.QueryString["idkhoachinh"] == "")
            {
                //PHIEU_XUAT_VT.data("so_phieu", StaticDataKT.CreateMaKT("PX_CCDC", "Phieu_Xuat_VT", "So_Phieu"));
                string ngaylap=Request.QueryString["ngay_xuat"].ToString();
                PHIEU_XUAT_VT.data("so_phieu", StaticData.TaoMaSoTuDongKT_TSCC("Phieu_xuat_vt", "so_phieu", "PX_CCDC", ngaylap));
            }
            else
                PHIEU_XUAT_VT.data("so_phieu", Request.QueryString["so_phieu"]);
        }
        else
            PHIEU_XUAT_VT.data("so_phieu", Request.QueryString["so_phieu"]);
        if (Request.QueryString["do"] == "TimKiem")
        {
            if (Request.QueryString["ngay_xuat"] != "" && Request.QueryString["ngay_xuat"] != null)
                PHIEU_XUAT_VT.data("ngay_xuat", StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_xuat"].ToString()));
            else
                PHIEU_XUAT_VT.data("ngay_xuat", Request.QueryString["ngay_xuat"]);
        }
        else
            PHIEU_XUAT_VT.data("ngay_xuat", Request.QueryString["ngay_xuat"]);
        PHIEU_XUAT_VT.data("ma_phong", Request.QueryString["ma_phong"]);
        PHIEU_XUAT_VT.data("ten_phong", Request.QueryString["ten_phong"]);
        PHIEU_XUAT_VT.data("dien_giai", Request.QueryString["dien_giai"]);
        PHIEU_XUAT_VT.data("user_dau", Request.QueryString["user_dau"]);
        PHIEU_XUAT_VT.data("user_cuoi", Request.QueryString["user_cuoi"]);
        PHIEU_XUAT_VT.data("date_dau", Request.QueryString["date_dau"]);
        PHIEU_XUAT_VT.data("date_cuoi", Request.QueryString["date_cuoi"]);
        return PHIEU_XUAT_VT;
    }
    protected DataProcess s_PHIEU_XUAT_VT_CT()
    {
        DataProcess PHIEU_XUAT_VT_CT = new DataProcess("PHIEU_XUAT_VT_CT");
        PHIEU_XUAT_VT_CT.data("phieu_xuatct_id", Request.QueryString["idkhoachinh"]);
        PHIEU_XUAT_VT_CT.data("phieu_xuat_id", Request.QueryString["phieu_xuat_id"]);
        PHIEU_XUAT_VT_CT.data("ma_vt", Request.QueryString["ma_vt"]);
        PHIEU_XUAT_VT_CT.data("ten_vt", Request.QueryString["ten_vt"]);
        PHIEU_XUAT_VT_CT.data("idkho", Request.QueryString["idkho"]);
        PHIEU_XUAT_VT_CT.data("so_thang_pb", Request.QueryString["so_thang_pb"]);
        PHIEU_XUAT_VT_CT.data("tk_ccdc", Request.QueryString["tk_ccdc"]);
        PHIEU_XUAT_VT_CT.data("tk_chi_phi", Request.QueryString["tk_chi_phi"]);
        PHIEU_XUAT_VT_CT.data("tk_phan_bo", Request.QueryString["tk_phan_bo"]);
        PHIEU_XUAT_VT_CT.data("so_luong", Request.QueryString["so_luong"]);
        PHIEU_XUAT_VT_CT.data("don_gia", Request.QueryString["don_gia"]);
        PHIEU_XUAT_VT_CT.data("thanh_tien", Request.QueryString["thanh_tien"]);
        PHIEU_XUAT_VT_CT.data("tong_tien", Request.QueryString["tong_tien"]);
        return PHIEU_XUAT_VT_CT;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SavePHIEU_XUAT_VT(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablePHIEU_XUAT_VT_CT": LuuTablePHIEU_XUAT_VT_CT(); break;
            case "loadTablePHIEU_XUAT_VT_CT": loadTablePHIEU_XUAT_VT_CT(); break;
            //case "xoa": XoaPHIEU_XUAT_VT(); break;
            case "xoa": XoaPHIEU_XUAT_VT_CT(); break;
            //case "xoaPHIEU_XUAT_VT_CT": XoaPHIEU_XUAT_VT_CT(); break;
            case "vattuSearch": vattuSearch(); break;
            case "phongSearch": phongSearch(); break;
            case "DanhSachTaiKhoan_Jquery": DanhSachTaiKhoan_Jquery(); break;
        }
    }
    private void phongSearch()
    {
        string key = Request.QueryString["q"];
        string strsql = "";
        strsql = "select idphongkhambenh,idphongkhambenh,tenphongkhambenh from phongkhambenh where tenphongkhambenh like N'%" + key + "%'";
        DataTable table = DataAcess.Connect.GetTable(strsql);
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
    private void vattuSearch()
    {
        string key = Request.QueryString["q"];
        string idText = Request.QueryString["obj"];
        string html = "";
        //try
        //{
        string sqlvtsearch = @"select phieu_nhap_ct_id,mats,tentaisan
                ,convert(varchar(12),dmts.ngaynhap,103) as ngay_nhap
                ,so_phieu=(select so_phieu from phieu_nhap_vt_ct pnct left join phieu_nhap_vt pn on pnct.phieu_nhap_id=pn.phieu_nhap_id where pnct.phieu_nhap_ct_id = dmts.phieu_nhap_ct_id)
                ,dmts.nguyengia
                ,dmkt.tk_kho,dmkt.tk_chi_phi,dmkt.tk_khau_hao
                ,dmts.idkho,kt.tenkho
                ,dmts.soluong_hienco
                from danhmuctaisan dmts left join dm_vat_tu_kt dmkt on dmts.mats=dmkt.ma_vt
                left join khothuoc kt on dmts.idkho=kt.idkho
                where dmkt.tk_kho like '153%' and dmts.soluong_hienco > 0";
        if (key != "")
            sqlvtsearch += " and mats like '%" + key + "%'";
        DataTable dt = DataAcess.Connect.GetTable(sqlvtsearch);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            html += "<div>";
            html += "<p style=\"width: 90px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["mats"] + "</p>";
            html += "<p style=\"width: 200px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["tentaisan"] + "</p>";
            html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["so_phieu"] + "</p>";
            html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["ngay_nhap"] + "</p>";
            html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["soluong_hienco"] + "</p>";
            
            if(dt.Rows[i]["nguyengia"] != "")
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + String.Format("{0:0,0}", float.Parse(dt.Rows[i]["nguyengia"].ToString())) + "</p>";
            else
                html += "<p style=\"width: 100px; float: left; text-align: center; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["nguyengia"] + "</p>";

            html += "<p style=\"width: 100px; float: left; text-align: left; border-color: Blue; border-width: 2px\">" + dt.Rows[i]["tenkho"] + "</p>";
            html += "</div>";
            html += "|" + dt.Rows[i]["mats"];
            html += "|" + dt.Rows[i]["tentaisan"];
            html += "|" + dt.Rows[i]["so_phieu"];
            html += "|" + dt.Rows[i]["ngay_nhap"];
            html += "|" + dt.Rows[i]["nguyengia"];
            html += "|" + dt.Rows[i]["tk_kho"];
            html += "|" + dt.Rows[i]["tk_chi_phi"];
            html += "|" + dt.Rows[i]["tk_khau_hao"];
            //html += "|" + dt.Rows[i]["tien_phi"];
            html += "|" + dt.Rows[i]["idkho"];
            html += "|" + dt.Rows[i]["tenkho"];
            html += "|" + dt.Rows[i]["phieu_nhap_ct_id"];
            html += "|" + dt.Rows[i]["so_phieu"];
            html += "|" + dt.Rows[i]["soluong_hienco"];
            html += Environment.NewLine;
        }
        Response.Write(html);
        //}
        //catch (Exception)
        //{
        //    Response.Write("error");
        //}
        /*string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += table.Rows[i][0].ToString() + "|" + table.Rows[i][1].ToString() + "|" + table.Rows[i][2].ToString() + "|" + table.Rows[i][3].ToString() + "|" + table.Rows[i][4].ToString() + "|" + table.Rows[i][5].ToString() + "|" + table.Rows[i][6].ToString() + "|" + table.Rows[i][7].ToString() + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
         */
    }
    #region Load danh sach tai khoan
    public void DanhSachTaiKhoan_Jquery()
    {
        string key = Request.QueryString["q"];
        string idText = Request.QueryString["obj"];
        string sql = "";
        string html = "";
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
    private void XoaPHIEU_XUAT_VT()
    {
        try
        {
            DataProcess process = s_PHIEU_XUAT_VT();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("phieu_xuat_id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void XoaPHIEU_XUAT_VT_CT()
    {
        try
        {
            string sqlpxct="select phieu_xuatct_id,isnull(so_luong,0) from phieu_xuat_vt_ct where phieu_xuat_id='"+ Request.QueryString["idkhoachinh"] +"'";
            DataTable tbpxct = DataAcess.Connect.GetTable(sqlpxct);
            for (int i = 0; i < tbpxct.Rows.Count; i++)
            { 
                //Cập nhật lại số lượng trong danhmuctaisan
                string sqlsoluong = "update danhmuctaisan set phieu_xuat_ct_id=0,soluong_hienco=soluong_hienco+'" + tbpxct.Rows[i][1].ToString() + "' where phieu_xuat_ct_id='" + tbpxct.Rows[i][0].ToString() + "'";
                bool ktsoluong = DataAcess.Connect.ExecSQL(sqlsoluong);
            }
            //DataProcess process = s_PHIEU_XUAT_VT_CT();
            //bool ok = process.Delete();
            string sqldeletect = "delete from phieu_xuat_vt_ct where phieu_xuat_id='" + Request.QueryString["idkhoachinh"] + "'";
            bool ok = DataAcess.Connect.ExecSQL(sqldeletect);
            if (ok)
            {
                XoaPHIEU_XUAT_VT();
                Response.Clear(); Response.Write(Request.QueryString["idkhoachinh"]);
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
        DataTable table = KT_Profess.PHIEU_XUAT_VT.dtSearchByphieu_xuat_id(idkhoachinh);         
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

    private void TimKiem()
    {
        DataProcess process = s_PHIEU_XUAT_VT();
        process.Page = Request.QueryString["page"];
        DataTable table = process.Search(@"select STT=row_number() over (order by T.phieu_xuat_id),T.*
                               from PHIEU_XUAT_VT T
          where " + process.sWhere() + " and manghiepvu='PX_CCDC'");
        string html = "";
        html += "<table class='jtable' id=\"tablefind\">";
        html += "<tr>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("phieu_xuat_id") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("so_phieu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngay_xuat") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ma_phong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ten_phong") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dien_giai") + "</th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr onclick=\"setControlFind('" + table.Rows[i]["phieu_xuat_id"].ToString() + "')\">";
                    html += "<td>" + table.Rows[i]["so_phieu"].ToString() + "</td>";
                    if (table.Rows[i]["ngay_xuat"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngay_xuat"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                    }
                    else { html += "<td>" + table.Rows[i]["ngay_xuat"].ToString() + "</td>"; }
                    html += "<td>" + table.Rows[i]["ma_phong"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["ten_phong"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["dien_giai"].ToString() + "</td>";
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

    private void SavePHIEU_XUAT_VT()
    {
        //try
        //{
        string nguoinhan = "";
        nguoinhan = Request.QueryString["nguoi_nhan"];
        DataProcess process = s_PHIEU_XUAT_VT();
        if (process.getData("phieu_xuat_id") != null && process.getData("phieu_xuat_id") != "")
        {
            bool ok = process.Update();
            if (ok)
            {
                string updatepn = "update phieu_xuat_vt set manghiepvu='PX_CCDC' ,ten_nguoi_nhan=N'" + nguoinhan + "' where phieu_xuat_id=" + Request.QueryString["idkhoachinh"];
                bool ktpn = DataAcess.Connect.ExecSQL(updatepn);
                Response.Clear(); Response.Write(process.getData("phieu_xuat_id"));
                return;
            }
        }
        else
        {
            bool ok = process.Insert();
            if (ok)
            {
                DataTable dt = DataAcess.Connect.GetTable("select top 1 phieu_xuat_id from phieu_xuat_vt order by phieu_xuat_id desc");
                string phieuxuatid = "0";
                if (dt.Rows.Count > 0)
                    phieuxuatid = dt.Rows[0][0].ToString();
                string updatepn = "update phieu_xuat_vt set manghiepvu='PX_CCDC', ten_nguoi_nhan=N'" + nguoinhan + "' where phieu_xuat_id=" + phieuxuatid;
                bool ktpn = DataAcess.Connect.ExecSQL(updatepn);
                Response.Clear(); Response.Write(process.getData("phieu_xuat_id"));
                return;
            }
        }
        //}
        //catch
        //{
        //}
        Response.StatusCode = 500;
    }

    public void LuuTablePHIEU_XUAT_VT_CT()
    {
        //try
        //{
        if (Request.QueryString["ma_vt"] != "")
        {
            DataProcess process = s_PHIEU_XUAT_VT_CT();
            if (process.getData("phieu_xuatct_id") != null && process.getData("phieu_xuatct_id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    //Update danh muc tài sản
                    string sqlupdatedmts = "update danhmuctaisan";
                    if (!string.IsNullOrEmpty(Request.QueryString["ngay_xuat"]))
                        sqlupdatedmts += " set ngaykhauhao='" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_xuat"].ToString()) + "'";
                    else
                        sqlupdatedmts += " set ngaykhauhao=null";
                    if (!string.IsNullOrEmpty(Request.QueryString["so_thang_pb"]))
                        sqlupdatedmts += ",sonamkh=" + Request.QueryString["so_thang_pb"];
                    sqlupdatedmts += ",tkkhauhao='" + Request.QueryString["tk_phan_bo"] + "'";
                    sqlupdatedmts += ",tkchiphi='" + Request.QueryString["tk_chi_phi"] + "'";
                    sqlupdatedmts += ", nguyengia='" + Request.QueryString["tong_tien"].Replace(",","") + "'";
                    //Update số lượng
                    sqlupdatedmts += ",soluong_hienco=soluong_hienco-" + Request.QueryString["so_luong"];
                    sqlupdatedmts += ",isccdc=1 ";
                    //sqlupdatedmts += " where mats='" + Request.QueryString["ma_vt"] + "'";
                    //if (Request.QueryString["phieu_nhap_ct_id"] != "")
                    sqlupdatedmts += " where phieu_xuat_ct_id=" + Request.QueryString["idkhoachinh"];

                    bool updatedmts = DataAcess.Connect.ExecSQL(sqlupdatedmts);
                    /////////////////////////
                    Response.Clear(); Response.Write(process.getData("phieu_xuatct_id"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    //DataTable tbtknguyengia = DataAcess.Connect.GetTable("select top 1 tk_kho from dm_vat_tu_kt where ma_vt='"+ Request.QueryString["ma_vt"] +"'");
                    DataTable tbpxctid = DataAcess.Connect.GetTable("select top 1 phieu_xuatct_id from phieu_xuat_vt_ct order by phieu_xuatct_id desc");
                    //Update danh muc tài sản
                    string sqlupdatedmts = "update danhmuctaisan";
                    sqlupdatedmts += " set phieu_xuat_ct_id=" + tbpxctid.Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(Request.QueryString["ngay_xuat"]))
                        sqlupdatedmts += ",ngaykhauhao='" + StaticData.ConvertDDMMtoMMDD(Request.QueryString["ngay_xuat"].ToString()) + "'";
                    else
                        sqlupdatedmts += ",ngaykhauhao=null";
                    if (!string.IsNullOrEmpty(Request.QueryString["so_thang_pb"]))
                        sqlupdatedmts += ",sonamkh=" + Request.QueryString["so_thang_pb"];
                    //if(tbtknguyengia.Rows.Count>0)
                    //    sqlupdatedmts+=",tknguyengia='"+ tbtknguyengia.Rows[0][0].ToString() +"'";
                    sqlupdatedmts += ",tkkhauhao='" + Request.QueryString["tk_phan_bo"] + "'";
                    sqlupdatedmts += ",tkchiphi='" + Request.QueryString["tk_chi_phi"] + "'";
                    sqlupdatedmts += ", nguyengia='" + Request.QueryString["tong_tien"].Replace(",","") + "'";
                    //Update số lượng
                    sqlupdatedmts += ",soluong_hienco=soluong_hienco-" + Request.QueryString["so_luong"];
                    sqlupdatedmts += ",isccdc=1 ";
                    sqlupdatedmts += " where mats='" + Request.QueryString["ma_vt"] + "'";
                    if (Request.QueryString["phieu_nhap_ct_id"] != "")
                        sqlupdatedmts += " and phieu_xuat_ct_id=" + Request.QueryString["phieu_nhap_ct_id"];

                    bool updatedmts = DataAcess.Connect.ExecSQL(sqlupdatedmts);
                    /////////////////////////
                    Response.Clear(); Response.Write(process.getData("phieu_xuatct_id"));
                    return;
                }
            }
        }
            
        //}
        //catch
        //{
        //}
        Response.StatusCode = 500;
    }

    public void loadTablePHIEU_XUAT_VT_CT()
    {
        DataProcess process = s_PHIEU_XUAT_VT_CT();
        process.Page = Request.QueryString["page"];
        DataTable table = process.Search(@"select STT=row_number() over (order by T.phieu_xuatct_id),T.*,kt.tenkho
                               from PHIEU_XUAT_VT_CT T
            left join khothuoc kt on T.idkho=kt.idkho
          where T.phieu_xuat_id='" + process.getData("phieu_xuat_id") + "'");
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã CCDC") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên CCDC") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Kho") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số Tháng PB") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK CCDC") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK CP") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK KH") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số Lượng") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dongia") + "</th>";
        //html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thành Tiền") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tổng Tiền") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input mkv='true' style='width:100px' id='ma_vt' type='text' onfocusout='chuyenformout(this)' onfocus='vattuSearch(this);' value='" + table.Rows[i]["ma_vt"].ToString() + "' /></td>";
                html += "<td><input mkv='true' style='width:200px' id='ten_vt' type='text' onfocusout='chuyenformout(this)' onfocus='' value='" + table.Rows[i]["ten_vt"].ToString() + "' /></td>";
                html += "<td><input mkv='true'  id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["idkho"].ToString() + "' onblur='TestSo(this,false,false);'/>";
                html += "<input mkv='true' style='width:100px' id='mkv_idkho' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tenkho"].ToString() + "' onblur=''/></td>";
                html += "<td><input mkv='true' style='width:100px' id='so_thang_pb' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["so_thang_pb"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><input mkv='true' style='width:60px' id='tk_ccdc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tk_ccdc"].ToString() + "' /></td>";
                html += "<td><input mkv='true' style='width:50px' id='tk_chi_phi' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tk_chi_phi"].ToString() + "' /></td>";
                html += "<td><input mkv='true' style='width:50px' id='tk_phan_bo' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tk_phan_bo"].ToString() + "' /></td>";
                html += "<td><input mkv='true' style='width:80px;text-align:center' id='so_luong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["so_luong"].ToString() + "' onblur='testsoluong(this);TestSo(this,false,false);tinhtien(this);'/></td>";

                try
                {
                    html += "<td><input mkv='true' style='width:80px;text-align:center' id='don_gia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["don_gia"].ToString())) + "' onblur='tinhtien(this);'/></td>";
                }
                catch
                {
                    html += "<td><input mkv='true' style='width:80px;text-align:center' id='don_gia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["don_gia"].ToString() + "' onblur='tinhtien(this);'/></td>";
                }
                //html += "<td><input mkv='true' id='thanh_tien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["thanh_tien"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                try
                {
                    html += "<td><input mkv='true' style='width:100px;text-align:center' id='tong_tien' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + String.Format("{0:0,0}", float.Parse(table.Rows[i]["tong_tien"].ToString())) + "' onblur=''/></td>";
                }
                catch
                {
                    html += "<td><input mkv='true' id='tong_tien' style='width:100px;text-align:center'  readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["tong_tien"].ToString() + "' onblur=''/></td>";
                }
                html += "<td><input mkv='true' id='phieu_nhap_ct_id' type='hidden' value='' /><input mkv='true' id='soluong_hienco' type='hidden' value='' /><input mkv='true' id='so_phieu' type='hidden' value='' /><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["phieu_xuatct_id"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        else
        {
            html += "<tr>";
            html += "<td>1</td>";
            html += "<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td><input mkv='true' style='width:100px' id='ma_vt' type='text' onfocusout='chuyenformout(this)' onfocus='vattuSearch(this);' value='' /></td>";
            html += "<td><input mkv='true' style='width:200px' id='ten_vt' type='text' onfocusout='chuyenformout(this)' onfocus='' value='' /></td>";
            html += "<td><input mkv='true' style='width:100px' id='idkho' type='hidden' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' />";
            html += "<input mkv='true' style='width:100px' id='mkv_idkho' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='' /></td>";
            html += "<td><input mkv='true' style='width:100px;text-align:center;' id='so_thang_pb' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' style='width:60px' id='tk_ccdc' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' style='width:50px' id='tk_chi_phi' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' style='width:50px' id='tk_phan_bo' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' /></td>";
            html += "<td><input mkv='true' style='width:80px;text-align:center;' id='so_luong' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='testsoluong(this);TestSo(this,false,false);tinhtien(this);' /></td>";
            html += "<td><input mkv='true' style='width:80px;text-align:right;' id='don_gia' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='tinhtien(this);' /></td>";
            //html += "<td><input mkv='true' id='thanh_tien' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' style='width:100px;text-align:right;' id='tong_tien' readonly='readonly' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='' /></td>";
            html += "<td><input mkv='true' style='width:100px' id='phieu_nhap_ct_id' type='hidden' value='' /><input mkv='true' id='soluong_hienco' type='hidden' value='' /><input mkv='true' id='so_phieu' type='hidden' value='' /><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging("PHIEU_XUAT_VT_CT");
        Response.Clear(); Response.Write(html);
    }
}
