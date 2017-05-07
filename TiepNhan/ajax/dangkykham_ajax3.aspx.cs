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

public partial class dangkykham_ajax : System.Web.UI.Page
{
    protected DataProcess s_dangkykham()
    {
        DataProcess dangkykham = new DataProcess("dangkykham");
        dangkykham.data("iddangkykham", Request.QueryString["idkhoachinh"]);
        dangkykham.data("maphieudangky", Request.QueryString["maphieudangky"]);
        dangkykham.data("idbenhnhan", Request.QueryString["idbenhnhan"]);
        dangkykham.data("ngaydangky", DataProcess.sGetValidDate(Request.QueryString["giodk"], Request.QueryString["phutdk"], Request.QueryString["ngaydangky"]));
        dangkykham.data("idnguoidung", Request.QueryString["idnguoidung"]);
        dangkykham.data("idbacsichidinh", Request.QueryString["idbacsichidinh"]);
        dangkykham.data("iddieuduong", Request.QueryString["iddieuduong"]);
        dangkykham.data("dathu", Request.QueryString["dathu"]);
        dangkykham.data("ngayxacnhan", Request.QueryString["ngayxacnhan"]);
        dangkykham.data("dahuy", Request.QueryString["dahuy"]);
        dangkykham.data("LoaiKhamID", Request.QueryString["LoaiKhamID"].ToString().Split(',')[0]);
        dangkykham.data("STTDKK", Request.QueryString["STTDKK"]);
        dangkykham.data("IdNguoiThu", Request.QueryString["IdNguoiThu"]);
        dangkykham.data("MaPhieu", Request.QueryString["MaPhieu"]);
        dangkykham.data("IDBENHNHAN_BH", Request.QueryString["IDBENHNHAN_BH"]);
        return dangkykham;
    }
    protected DataProcess s_chitietdangkykham()
    {
        DataProcess chitietdangkykham = new DataProcess("chitietdangkykham");
        chitietdangkykham.data("idchitietdangkykham", Request.QueryString["idkhoachinh"]);
        chitietdangkykham.data("iddangkykham", Request.QueryString["iddangkykham"]);
        chitietdangkykham.data("idbanggiadichvu", Request.QueryString["idbanggiadichvu"]);
        chitietdangkykham.data("soluong", Request.QueryString["soluong"]);
        chitietdangkykham.data("dongia", Request.QueryString["dongia"]);
        chitietdangkykham.data("baohiemchi", Request.QueryString["baohiemchi"]);
        chitietdangkykham.data("giamgia", Request.QueryString["giamgia"]);
        chitietdangkykham.data("idbacsi", Request.QueryString["idbacsi"]);
        chitietdangkykham.data("dahuy", Request.QueryString["dahuy"]);
        chitietdangkykham.data("dakham", Request.QueryString["dakham"]);
        chitietdangkykham.data("idnguoithu", Request.QueryString["idnguoithu"]);
        chitietdangkykham.data("iddieuduong", Request.QueryString["iddieuduong"]);
        chitietdangkykham.data("PhongSo", Request.QueryString["PhongSo"]);
        chitietdangkykham.data("SoTT", Request.QueryString["SoTT"]);
        chitietdangkykham.data("PhongID", Request.QueryString["PhongID"]);
        chitietdangkykham.data("IsDaThu", Request.QueryString["IsDaThu"]);
        chitietdangkykham.data("SLBNCho", Request.QueryString["SLBNCho"]);
        chitietdangkykham.data("SLBNDK", Request.QueryString["SLBNDK"]);
        chitietdangkykham.data("IdKhamBenhCD", Request.QueryString["IdKhamBenhCD"]);
        chitietdangkykham.data("isNotThuPhiCapCuu", (StaticData.IsCheck(Request.QueryString["isNotThuPhiCapCuu"]) == true ? "1" : "0"));
        return chitietdangkykham;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": Savedangkykham(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTablechitietdangkykham": LuuTablechitietdangkykham(); break;
            case "loadTablechitietdangkykham": loadTablechitietdangkykham(); break;
            case "xoa": Xoadangkykham(); break;
            case "xoachitietdangkykham": Xoachitietdangkykham(); break;
            case "idbenhnhanSearch": idbenhnhanSearch(); break;
            case "idnguoidungSearch": idnguoidungSearch(); break;
            case "idbanggiadichvuSearch": idbanggiadichvuSearch(); break;
            case "PhongIDSearch": PhongIDSearch(); break;
            case "LaySoTT": LaySoTT(); break;
            case "LaySLBNCho": LaySLBNCho(); break;
            case "loaddsPhong": loaddsPhong(); break;
            case "HuyDKK": HuyDKK(); break;
            case "tinhlaitien": tinhlaitien(); break;
            case "IDBENHNHAN_BHSearch": IDBENHNHAN_BHSearch(); break;
            case "LoaiKhamIDsearch": LoaiKhamIDsearch(); break;
        }
    }
    private void tinhlaitien()
    {
        string iddangkykham = Request.QueryString["iddangkykham"];
        string dadangky = Request.QueryString["dadangky"];
        StaticData.TinhLaiTien_ByIdDangKyKham(iddangkykham,(dadangky=="1"? "0" :"1"));
        Response.Write("Tính tiền thành công");

    }
    private void loaddsPhong()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        string ngaydangky = Request.QueryString["ngaydangky"];
        string iddangkykham = Request.QueryString["iddangkykham"];

        string sqlCheck2 = @"select c.idbenhnhan,c.mabenhnhan,c.tenbenhnhan,
                    a.phongid,b.ngaydangky,tenphong=(select tenphong from kb_phong where id=a.phongid)
	                    from chitietdangkykham a 
	                    left join dangkykham b 
                        on a.iddangkykham=b.iddangkykham 
	                    left join benhnhan c 
                        on b.idbenhnhan=c.idbenhnhan
                        where ISNULL(A.DAHUY,0)=0 AND  convert(varchar(10),ngaydangky,103)='" + string.Format("{0:dd/MM/yyyy}", ngaydangky) + @"'
	                        and c.idbenhnhan=" + idbenhnhan + "";
        if (iddangkykham != null && iddangkykham != "" && iddangkykham != "0")
        {
            sqlCheck2 += " and b.iddangkykham <> '" + iddangkykham + "'";
        }
        DataTable dtCheckPhong2 = DataAcess.Connect.GetTable(sqlCheck2);
        if (dtCheckPhong2 != null && dtCheckPhong2.Rows.Count > 0)
        {
            string ss = "";
            for (int ii = 0; ii < dtCheckPhong2.Rows.Count; ii++)
            {
                ss += dtCheckPhong2.Rows[ii]["tenphong"].ToString() + ",";
            }
            Response.Clear();
            Response.Write(ss.TrimEnd(','));

        }

    }
    private bool kiemtradangkykham(string idbenhnhan, string ngaydangky, string arrphong, string AllowDKKThem, ref string alert)
    {


        string[] arr = arrphong.Split('@');
        System.Collections.Generic.List<string> lstPhong = new System.Collections.Generic.List<string>();
        for (int i = 0; i < arr.Length; i++)
        {
            if(arr[i].Split('^')[0]!="")   lstPhong.Add(arr[i].Split('^')[0]);
        }

        for (int i = 0; i < lstPhong.Count; i++)
        {
            string sI = lstPhong[i];
            int j = lstPhong.IndexOf(sI);
            if (j != i)
            {
                alert = "Không cho phép trùng phòng";
                return false;
            }
        }
        for (int i = 0; i < arr.Length - 1; i++)
        {
            #region checkphongdk
            string idphong = arr[i].Split('^')[0];
            string idchitietdangkykham = arr[i].Split('^')[1];
            string sqlCheck = @"select c.idbenhnhan,c.mabenhnhan,c.tenbenhnhan,a.phongid,b.ngaydangky,tenphong=(select tenphong from kb_phong where id=a.phongid)
	                        from chitietdangkykham a 
	                        left join dangkykham b 
                            on a.iddangkykham=b.iddangkykham 
	                        left join benhnhan c 
                            on b.idbenhnhan=c.idbenhnhan
                            where ISNULL(A.DAHUY,0)=0 AND  a.phongid=" + idphong + @"
	                            and convert(varchar(10),ngaydangky,103)='" + string.Format("{0:dd/MM/yyyy}", ngaydangky) + @"'
	                            and c.idbenhnhan=" + idbenhnhan;
            if (idchitietdangkykham != "" && idchitietdangkykham != "0")
                sqlCheck += " and a.idchitietdangkykham <> '" + idchitietdangkykham + "'";

            DataTable dtCheckPhong = DataAcess.Connect.GetTable(sqlCheck);
            if (dtCheckPhong != null && dtCheckPhong.Rows.Count > 0)
            {
                Response.Clear();
                Response.StatusCode = 500;
                alert += "Bệnh nhân đã đăng ký khám nội dung này trong ngày rồi";
                return false;
            }

            #endregion
        }
        return true;
    }
    private void LaySoTT()
    {
        string PhongID = Request.QueryString["PhongID"].ToString();
        string NgayDangKy = Request.QueryString["NgayDangKy"].ToString();
        NgayDangKy = StaticData.CheckDate(NgayDangKy);
        string IdBenhNhan = Request.QueryString["IdBenhNhan"].ToString();
        string Sott = StaticData_HS.GetSoThuTuDangKyKhamMoi(PhongID, NgayDangKy, false);

        Response.Write(Sott);
    }
    private void LaySLBNCho()
    {
        string PhongID = Request.QueryString["PhongID"].ToString();
        string NgayDangKy = Request.QueryString["NgayDangKy"].ToString();
        NgayDangKy = StaticData.CheckDate(NgayDangKy);
        string SLBNDaKham = StaticData.GetSLBNChoKham(PhongID, NgayDangKy);
        Response.Write(SLBNDaKham);
    }
    private void idbenhnhanSearch()
    {
        DataTable table = Process.benhnhan.dtGetAll();
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
    private void idnguoidungSearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select idnguoidung ,tennguoidung from nguoidung where idbacsi is null");
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
    private void idbanggiadichvuSearch()
    {
        if (!StaticData.EnableChuyenKhoa) return;
        DataTable table = DataAcess.Connect.GetTable("SELECT A.* FROM BANGGIADICHVU A LEFT JOIN PHONGKHAMBENH B ON A.IDPHONGKHAMBENH=B.IDPHONGKHAMBENH WHERE B.LOAIPHONG=0");
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
    private void PhongIDSearch()
    {
        string idkhoa = Request.QueryString["IdKhoa"];
        DataTable table = null;
        if (idkhoa != null && idkhoa != "")
        {
            table = StaticData.dtPhong_NgoaiTru_ByKhoa(idkhoa);
        }
        else
        {
            table = StaticData.dtPhong_NgoaiTru_ByKhoa("1");
        }
        DataRow R = table.NewRow();
        R[0] = -1;
        R["TenPhongFull"] = "Mua sổ";
        R["DichVuKCB"] = "628";
        table.Rows.InsertAt(R, 0);
        string html = "";

        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string Prev = "";
                    if (i == 0) Prev = "";
                    html += Prev + table.Rows[i]["TenPhongFull"].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoadangkykham()
    {
        try
        {
            DataProcess process = s_dangkykham();
            string IdDangKyKham = process.getData("iddangkykham");
            string sqlSelect = "SELECT COUNT(*) FROM CHITIETDANGKYKHAM WHERE  IDDANGKYKHAM=" + IdDangKyKham + " AND ( IsDaThu=1 OR ISBNDATRA=1 ) AND ISNULL(dahuy,0)=0";
            DataTable dtTest = DataAcess.Connect.GetTable(sqlSelect);
            if (dtTest != null && dtTest.Rows.Count != 0)
            {
                if (dtTest.Rows[0][0].ToString() != "0")
                {
                    Response.StatusCode = 500;
                    return;
                }
            }
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("iddangkykham"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void Xoachitietdangkykham()
    {
        try
        {
            DataProcess process = s_chitietdangkykham();
            string idchitietdangkykham = process.getData("idchitietdangkykham");
            string iddangkykham = Request.QueryString["iddangkykham"];
            if (iddangkykham == null || iddangkykham == "")
            {
                string sqlSelect = "SELECT IDDANGKYKHAM FROM CHITIETDANGKYKHAM WHERE IDCHITIETDANGKYKHAM=" + idchitietdangkykham;
                DataTable dtKK = DataAcess.Connect.GetTable(sqlSelect);
                if (dtKK == null || dtKK.Rows.Count == 0)
                {
                    Response.StatusCode = 500;
                    return;
                }
                iddangkykham = dtKK.Rows[0][0].ToString();
            }

            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idchitietdangkykham"));
                StaticData.TinhLaiTien_ByIdDangKyKham(iddangkykham);
                return;
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    private void setTimKiem()
    {//Userlogin_new.HavePermision(this, "dangkykham_Search")
        if (true)
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"];
            string idbenhnhan = Request.QueryString["idbenhnhan"];
            string ngaydangky = Request.QueryString["ngaydangky"];
            string LoaiKhamID = Request.QueryString["LoaiKhamID"];
            string IDBENHNHAN_BH = Request.QueryString["IDBENHNHAN_BH"];
            string SoBH = Request.QueryString["SoBH"];
            if (idkhoachinh == "") idkhoachinh = "0";
            DataTable table = Process.dangkykham.dtSearchByiddangkykham(idkhoachinh);
            string idnguoidung = SysParameter.UserLogin.UserID(this);
            string html = "";
            html += "<root>";

            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    DataTable dtLoaiKhamID = DataAcess.Connect.GetTable("SELECT ID,TENLOAI FROM KB_LOAIBN WHERE ID='" + table.Rows[0]["LoaiKhamID"] + "'");
                  //  html += "<data id=\"LoaiKhamID\">" + ((dtLoaiKhamID.Rows.Count > 0) ? dtLoaiKhamID.Rows[0][0] : "") + "</data>";
                    html += "<data id=\"mkv_LoaiKhamID\">" + ((dtLoaiKhamID.Rows.Count > 0) ? dtLoaiKhamID.Rows[0][1] : "") + "</data>";
                    html += "<data id=\"idkhoachinh\">" + idkhoachinh + "</data>";
                    DataTable DT_idbenhnhan = Process.benhnhan.dtSearchByidbenhnhan("'" + table.Rows[0]["idbenhnhan"] + "'");
                    html += "<data id=\"mabenhnhan\">" + ((DT_idbenhnhan.Rows.Count > 0) ? DT_idbenhnhan.Rows[0][1] : "") + "</data>";
                    html += "<data id=\"mkv_idbenhnhan\">" + ((DT_idbenhnhan.Rows.Count > 0) ? DT_idbenhnhan.Rows[0][2] : "") + "</data>";
                    DataTable DT_idnguoidung = Process.nguoidung.dtSearchByidnguoidung("'" + table.Rows[0]["idnguoidung"] + "'");
                    html += "<data id=\"mkv_idnguoidung\">" + ((DT_idnguoidung.Rows.Count > 0) ? DT_idnguoidung.Rows[0][1] : "") + "</data>";
                    DataTable dtSoBHYT = DataAcess.Connect.GetTable("SELECT SOBHYT FROM BENHNHAN_BHYT WHERE IDBENHNHAN_BH='" + table.Rows[0]["IDBENHNHAN_BH"] + "'");
                    html += "<data id=\"mkv_IDBENHNHAN_BH\">" + ((dtSoBHYT.Rows.Count > 0) ? dtSoBHYT.Rows[0][0] : "") + "</data>";

                    string NgayDangKySave = table.Rows[0]["NgayDangKy"].ToString();
                    DateTime dNgayDangKySave = DateTime.Parse(NgayDangKySave);
                    html += "<data id=\"giodk\">" + dNgayDangKySave .ToString("HH")+ "</data>";
                    html += "<data id=\"phutdk\">" + dNgayDangKySave.ToString("mm") + "</data>";
                    html += "<data id=\"giaydk\">" + dNgayDangKySave.ToString("ss") + "</data>";



                    string ngaytrinhthe = table.Rows[0]["ngaytrinhthe"].ToString();
                    if (ngaytrinhthe != null && ngaytrinhthe != "")
                    {
                        DateTime dngaytrinhthe = DateTime.Parse(ngaytrinhthe);
                        html += "<data id=\"giott\">" + dngaytrinhthe.ToString("HH") + "</data>";
                        html += "<data id=\"phuttt\">" + dngaytrinhthe.ToString("mm") + "</data>";
                    }


                    html += Environment.NewLine;
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
                else
                {
                    DataTable dtBenhNhan = Process.benhnhan.dtSearchByidbenhnhan("'" + idbenhnhan + "'");
                    if (dtBenhNhan != null && dtBenhNhan.Rows.Count > 0)
                    {
                        html += "<data id='idbenhnhan'>" + idbenhnhan + "</data>";
                        html += "<data id='mabenhnhan'>" + dtBenhNhan.Rows[0][1].ToString() + "</data>";
                        html += "<data id='mkv_idbenhnhan'>" + dtBenhNhan.Rows[0][2].ToString() + "</data>";
                        html += "<data id='ngaydangky'>" + ngaydangky + "</data>";


                        string NgayDangKySave =  StaticData.CheckDate(ngaydangky);
                        DateTime dNgayDangKySave = DateTime.Parse(NgayDangKySave + " "+ DateTime.Now.ToString("HH:mm:ss"));
                        html += "<data id=\"giodk\">" + dNgayDangKySave.ToString("HH") + "</data>";
                        html += "<data id=\"phutdk\">" + dNgayDangKySave.ToString("mm") + "</data>";
                        html += "<data id=\"giaydk\">" + dNgayDangKySave.ToString("ss") + "</data>";

                    }

                    DataTable dtNguoiDung = Process.nguoidung.dtSearchByidnguoidung("'" + idnguoidung + "'");
                    if (dtNguoiDung != null && dtNguoiDung.Rows.Count > 0)
                    {
                        html += "<data id='idnguoidung'>" + idnguoidung + "</data>";
                        html += "<data id='mkv_idnguoidung'>" + dtNguoiDung.Rows[0][1].ToString() + "</data>";

                    }

                    if (LoaiKhamID == "1")
                    {
                        html += "<data id=\"LoaiKhamID\">" + LoaiKhamID + "</data>";
                        html += "<data id=\"mkv_LoaiKhamID\">" + "Bảo hiểm" + "</data>";
                    }
                    else
                    {
                        html += "<data id=\"LoaiKhamID\">" + LoaiKhamID + "</data>";
                        html += "<data id=\"mkv_LoaiKhamID\">" + "Dịch Vụ" + "</data>";
                    }
                    html += "<data id=\"IDBENHNHAN_BH\">" + IDBENHNHAN_BH + "</data>";
                    html += "<data id=\"mkv_IDBENHNHAN_BH\">" + SoBH + "</data>";

                }
            }
            html += "</root>";
            Response.Clear();
            Response.Write(html);
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
        }
    }
    private void TimKiem()
    {
        /*Userlogin_new.HavePermision(this, "dangkykham_Search") */
        bool temp = true;
        if (temp)
        {
            DataProcess process = s_dangkykham();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.iddangkykham),T.*
                   ,TenBenhNhan
                               from dangkykham T
                    left join benhnhan  A on T.idbenhnhan=A.idbenhnhan
          where " + process.sWhere());
            string html = "";
            html += "<table class='jtable' id=\"tablefind\">";
            html += "<tr>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("iddangkykham") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphieudangky") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idbenhnhan") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ngaydangky") + "</th>";
            html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnguoidung") + "</th>";
            html += "</tr>";
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html += "<tr onclick=\"setControlFind('" + table.Rows[i]["iddangkykham"].ToString() + "')\">";
                        html += "<td>" + table.Rows[i]["maphieudangky"].ToString() + "</td>";
                        html += "<td>" + table.Rows[i]["TenBenhNhan"].ToString() + "</td>";
                        if (table.Rows[i]["ngaydangky"].ToString() != "")
                        {
                            html += "<td>" + DateTime.Parse(table.Rows[i]["ngaydangky"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                        }
                        else { html += "<td>" + table.Rows[i]["ngaydangky"].ToString() + "</td>"; }
                        html += "<td>" + table.Rows[i]["idnguoidung"].ToString() + "</td>";
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
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
    private void Savedangkykham()
    {
        try
        {
            DataProcess process = s_dangkykham();
            string NGAYTRINHTHE = DataProcess.sGetValidDate(Request.QueryString["giott"], Request.QueryString["phuttt"], Request.QueryString["NGAYTRINHTHE"]);
            if (NGAYTRINHTHE == null) NGAYTRINHTHE = "";
            process.data("NGAYTRINHTHE", NGAYTRINHTHE);
            

            string idbenhnhan = process.getData("idbenhnhan");
            string ngaydangky = process.getData("ngaydangky");
            string arrphong = Request.QueryString["arrphong"].TrimEnd('@');
            string AllowDKKThem = Request.QueryString["AllowDKKThem"];
            string falseAlert = "";
            bool ok_kiemtra = kiemtradangkykham(idbenhnhan, ngaydangky, arrphong, AllowDKKThem, ref falseAlert);
            if (!ok_kiemtra)
            {
                Response.Clear(); Response.Write(falseAlert);
                Response.StatusCode = 500;
                return;
            }


            if (process.getData("iddangkykham") != null && process.getData("iddangkykham") != "")
            {

                string ngaydangky1 = Request.QueryString["ngaydangky1"];
                string giodk1 = Request.QueryString["giodk"];
                string phutdk1 = Request.QueryString["phutdk"];
                string giaydk1 = Request.QueryString["giaydk"];
                if (ngaydangky1 != null && giodk1 != null && phutdk1 != null && giaydk1 != null && ngaydangky1 != "" && giodk1 != "" && phutdk1 != "" && giaydk1 != "")
                {
                    string ngaydangkysave = StaticData.CheckDate(ngaydangky1) + " " + giodk1 + ":" + phutdk1 + ":" + giaydk1;
                    DateTime d_ngaydangkysave=DateTime.Parse(ngaydangkysave);
                    string sqlSelect = @"SELECT NGAYTINHBH,NGAYTINHBH_THUC ,B.IDBENHBHDONGTIEN,A.TIENCLS,A.TIENTHUOC,A.TIENGIUONG
                                        FROM HS_BENHNHANBHDONGTIEN A
                                            INNER JOIN DANGKYKHAM B ON A.ID=B.IDBENHBHDONGTIEN
                                      WHERE B.IDDANGKYKHAM=" + process.getData("iddangkykham");
                    DataTable dtTest = DataAcess.Connect.GetTable(sqlSelect);
                    if (dtTest.Rows.Count > 0)
                    {
                        string NGAYTINHBH = dtTest.Rows[0]["NGAYTINHBH"].ToString();
                        string NGAYTINHBH_THUC = dtTest.Rows[0]["NGAYTINHBH_THUC"].ToString();
                        if (NGAYTINHBH_THUC == "") NGAYTINHBH_THUC = NGAYTINHBH;
                        DateTime dNGAYTINHBH = DateTime.Parse(NGAYTINHBH);
                        DateTime dNGAYTINHBH_THUC = DateTime.Parse(NGAYTINHBH_THUC);

                        if (d_ngaydangkysave.ToString("yyyy-MM-dd") != dNGAYTINHBH.ToString("yyyy-MM-dd") && dNGAYTINHBH_THUC.ToString("yyyy-MM-dd") != dNGAYTINHBH.ToString("yyyy-MM-dd"))
                        {
                            Response.Clear(); Response.Write("Không thể lưu ngày đăng ký khác ngày " + dNGAYTINHBH.ToString("yyyy-MM-dd")+ "\r\n Vì đã có thông tin khám thuộc ngày này");
                            Response.StatusCode = 500;
                            return;
                        }
                        if (d_ngaydangkysave > dNGAYTINHBH_THUC && dNGAYTINHBH_THUC.ToString("yyyy-MM-dd") != dNGAYTINHBH.ToString("yyyy-MM-dd"))
                        {
                            Response.Clear(); Response.Write("Không thể lưu ngày đăng ký >=" + dNGAYTINHBH_THUC.ToString("yyyy-MM-dd HH:mm:ss")+ "\r\n Vì đã có thông tin khám thuộc ngày này");
                            Response.StatusCode = 500;
                            return;
                        }
                        if (d_ngaydangkysave != dNGAYTINHBH)
                        {
                            string sqlSave2 = "UDPATE CHITIETDANGKYKHAM SET NGAYDANGKY_CHITIET='" + ngaydangkysave + "' WHERE IDDANGKYKHAM=" + process.getData("iddangkykham");
                            String sqlSave3 = "UPDATE HS_BENHNHANBHDONGTIEN SET NGAYTINHBH='" + ngaydangkysave + "'" + (dNGAYTINHBH_THUC == dNGAYTINHBH ? ",NGAYTINHBH_THUC='" + ngaydangkysave + "'" : "") + " WHERE ID=" + dtTest.Rows[0]["IDBENHBHDONGTIEN"].ToString();
                            bool OK2 = DataAcess.Connect.ExecSQL(sqlSave2);
                            bool OK3 = DataAcess.Connect.ExecSQL(sqlSave3);
                        }
                    }

                }
                string iddangkykham=process.getData("iddangkykham");
                string idloaikham_old = DataAcess.Connect.GetTable("SELECT LOAIKHAMID FROM DANGKYKHAM WHERE IDDANGKYKHAM=" + iddangkykham).Rows[0][0].ToString();

                bool ok = process.Update();
                if (ok)
                {
                    string LoaiKhamID = process.getData("LoaiKhamID");
                    if (LoaiKhamID != idloaikham_old)
                    {
                        string sqlTest1 = @"SELECT B.* FROM HS_BENHNHANBHDONGTIEN B 
                                                            INNER JOIN DANGKYKHAM A ON A.IDBENHBHDONGTIEN=B.ID 
                                                WHERE A.IDDANGKYKHAM=" +iddangkykham;
                        DataTable dt1 = DataAcess.Connect.GetTable(sqlTest1);
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                          
                            string IDBENHNHAN_BH_1=process.getData("IDBENHNHAN_BH");
                            string sqlUpdate1 = "UPDATE HS_BENHNHANBHDONGTIEN SET ISBHYT=" + (LoaiKhamID == "1" ? "1" : "0") + ",IDBENHNHAN_BH=" + IDBENHNHAN_BH_1 + " WHERE ID=" + dt1.Rows[0]["ID"].ToString();
                            bool Ok4 = DataAcess.Connect.ExecSQL(sqlUpdate1);
                          
                        }

                        if (LoaiKhamID == "1")
                        {
                            string sqlUpdateCLS = @"UPDATE KHAMBENHCANLAMSAN SET  IsBHYT_Save=1 WHERE IDKHAMBENH IN (SELECT IDKHAMBENH FROM KHAMBENH WHERE IDDANGKYKHAM=" + iddangkykham + @")
                                                    AND (SELECT IsSuDungChoBH FROM BANGGIADICHVU WHERE IDBANGGIADICHVU=KHAMBENHCANLAMSAN.IDCANLAMSAN)=1";
                            bool OK_CLS = DataAcess.Connect.ExecSQL(sqlUpdateCLS);


                            string sqlUpdateTHUOC = @"UPDATE CHITIETBENHNHANTOATHUOC SET  IsBHYT_Save=1 WHERE IDKHAMBENH IN (SELECT IDKHAMBENH FROM KHAMBENH WHERE IDDANGKYKHAM=" + iddangkykham + @")
                                                    AND (SELECT SuDungChoBH FROM THUOC WHERE IDTHUOC=CHITIETBENHNHANTOATHUOC.IDTHUOC)=1";
                            bool OK_THUOC = DataAcess.Connect.ExecSQL(sqlUpdateTHUOC);

                        }
                    }
                    Response.Clear(); Response.Write(process.getData("iddangkykham"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("iddangkykham"));
                    return;
                }
            }
        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    public void LuuTablechitietdangkykham()
    {
        try
        {
            DataProcess process = s_chitietdangkykham();
            string IdBenhNhan = Request.QueryString["IdBenhNhan"].ToString();
            string PhongID = process.getData("PhongID");
            string DichVuKCB = process.getData("IdBangGiaDichVu");
            string idkhoa = Request.QueryString["idkhoa"];
            if (DichVuKCB == null || DichVuKCB == "" && PhongID == "-1")
            {
                DichVuKCB = "628";
                process.data("IdBangGiaDichVu", DichVuKCB);
            }
            else
                if (DichVuKCB == null || DichVuKCB == "" && PhongID != "")
                {

                    DataTable dtDV = DataAcess.Connect.GetTable("SELECT DICHVUKCB FROM KB_PHONG WHERE ID=" + PhongID);
                    if (dtDV != null && dtDV.Rows.Count > 0)
                    {
                        DichVuKCB = dtDV.Rows[0][0].ToString();
                        process.data("IdBangGiaDichVu", DichVuKCB);
                    }
                }
            if (DichVuKCB == null || DichVuKCB == "")
            {
                Response.StatusCode = 500;
                return;

            }
            process.data("soluong", "1");
            process.data("idkhoa", idkhoa);
            string NgayDangKy = Request.QueryString["NgayDangKy"].ToString();
            NgayDangKy = StaticData.CheckDate(NgayDangKy);
          
            string SLBNCho = process.getData("SLBNCho");
            if (SLBNCho == null || SLBNCho == "")
            {
                SLBNCho = StaticData.GetSLBNChoKham(PhongID, NgayDangKy);
                if (SLBNCho != null && SLBNCho != "" && SLBNCho != "0") process.data("SLBNCho", SLBNCho);
            }

            string idchitietdangkykham=process.getData("idchitietdangkykham") ;
            if (idchitietdangkykham == null || idchitietdangkykham == "")
            {
                string sqlSelect1 = @"SELECT IDCHITIETDANGKYKHAM
                                        FROM CHITIETDANGKYKHAM WHERE IDBANGGIADICHVU=" + DichVuKCB + " AND IDDANGKYKHAM=" + process.getData("iddangkykham")
                                      + " AND ISNULL(DAHUY,0)=0";
                DataTable dt1 = DataAcess.Connect.GetTable(sqlSelect1);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    idchitietdangkykham = dt1.Rows[0][0].ToString();
                    process.data("idchitietdangkykham", idchitietdangkykham);
                }

            }

            if (idchitietdangkykham != null && idchitietdangkykham != "")
            {
                string PhongID1 = process.getData("PhongID");
                string SQLPREV = "SELECT PhongID FROM CHITIETDANGKYKHAM WHERE IDCHITIETDANGKYKHAM =" + idchitietdangkykham;
                DataTable dtTemp = DataAcess.Connect.GetTable(SQLPREV);
                if (dtTemp != null && dtTemp.Rows.Count > 0 && PhongID1 != dtTemp.Rows[0][0].ToString())
                {
                   string SoTT = StaticData_HS.GetSoThuTuDangKyKhamMoi(PhongID, NgayDangKy, true);
                    if (SoTT != null && SoTT != "" && SoTT != "0") process.data("SoTT", SoTT);
                }
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(idchitietdangkykham);
                    return;
                }
            }
            else
            {
                string SoTT = process.getData("SoTT");
                SoTT = StaticData_HS.GetSoThuTuDangKyKhamMoi(PhongID, NgayDangKy, true);
                if (SoTT != null && SoTT != "" && SoTT != "0") process.data("SoTT", SoTT);

                process.data("IsDaThu", "0");
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitietdangkykham"));
                    return;
                }
            }

        }
        catch
        {
            Response.StatusCode = 500;
        }

    }
    public void loadTablechitietdangkykham()
    {
        string paging = "";
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Phòng") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Chuyên khoa") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số TT") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Số BN chờ") + "</th>";
        html += "<th>" + "" + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Đã thu?") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Miễn phí khám?") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        bool add = true;// Userlogin_new.HavePermision(this, "chitietdangkykham_Add");
        bool search = true;// Userlogin_new.HavePermision(this, "chitietdangkykham_Search");
        DataProcess process = s_chitietdangkykham();
        process.Page = Request.QueryString["page"];
        string sqlSelect = @"select STT=row_number() over (order by T.idchitietdangkykham),T.*
                   ,TenDichVu=" + (StaticData.EnableChuyenKhoa == true ? " A.TENDICHVU" : "''") + @"
                   ,MaSo=ISNULL( dbo.HS_TenPhong(T.PhongID),N'Mua sổ')
                   ,Dathu=(CASE WHEN T.IsDaThu=1 OR T.ISBNDaTra=1 THEN 1 ELSE 0 END)
                    ,PhongID_md=isnull(t.phongid,0)
                    ,IsKhongKhamKB=(select top 1 ISNULL(iskhongkham,0) from khambenh where idchitietdangkykham=t.idchitietdangkykham)
                    ,IsDaHuy_TP=( case when EXISTS(SELECT TOP 1 1 FROM HS_DSDATHU WHERE NLOAITHU=1 AND IDCHITIETDANGKYKHAM=T.IDCHITIETDANGKYKHAM AND ISDAHUY=1)  then 1 else 0 end)
                    from chitietdangkykham T
                    left join banggiadichvu  A on T.idbanggiadichvu=A.idbanggiadichvu
                    left join KB_Phong  B on T.PhongID=B.Id
                    where isnull(T.dahuy,0)=0 and  T.iddangkykham='" + process.getData("iddangkykham") + "' AND ISNULL(T.ISKHONGKHAM,0)=0";
        DataTable table = process.Search(sqlSelect);
        if (search)
        {

            if (table.Rows.Count > 0)
            {
                paging = process.Paging("chitietdangkykham");
                bool delete = true;// Userlogin_new.HavePermision(this, "chitietdangkykham_Delete");
                bool edit = true;// Userlogin_new.HavePermision(this, "chitietdangkykham_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string IsKhongKhamKB = table.Rows[i]["IsKhongKhamKB"].ToString();
                    string HuyCommandName = "HỦY";
                    if (IsKhongKhamKB != "" && StaticData.IsCheck(IsKhongKhamKB) == false)
                        HuyCommandName = "";


                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    html += "<td><a style='font-weight:bolder;" + (!delete ? "color:#cfcfcf" : "") + "'" + (StaticData.IsCheck(table.Rows[i]["IsDaHuy_TP"].ToString()) == true ? " onclick=\"huyontablephikham(this,1);\">" : (StaticData.IsCheck(table.Rows[i]["Dathu"].ToString()) == false ? " onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" : "onclick='huyontablephikham(this,0);' >")) + HuyCommandName + " </a></td>";
                    html += "<td><input mkv='true' id='PhongID' type='hidden' value='" + table.Rows[i]["PhongID_md"] + "'/><input mkv='true' id='mkv_PhongID' type='text' value='" + table.Rows[i]["MaSo"].ToString() + "' onfocus='PhongIDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idbanggiadichvu' type='hidden' value='" + table.Rows[i]["idbanggiadichvu"] + "'/><input mkv='true' id='mkv_idbanggiadichvu' type='text' value='" + table.Rows[i]["TenDichVu"].ToString() + "' onfocus='idbanggiadichvuSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : (StaticData.EnableChuyenKhoa ? "" : "disabled")) + "/></td>";
                    html += "<td><input mkv='true' id='SoTT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SoTT"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='SLBNCho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + table.Rows[i]["SLBNCho"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + "/></td>";
                    html += "<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitietdangkykham"].ToString() + "'/>" + "</td>";
                    html += "<td><input mkv='false' id='IsDaThu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='" + (StaticData.IsCheck(table.Rows[i]["Dathu"].ToString()) ? "Đã thu" : "Chưa thu") + "' disabled" + "/></td>";
                    html += "<td align='center'><input mkv='true' id='isNotThuPhiCapCuu' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' " + (StaticData.IsCheck(table.Rows[i]["isNotThuPhiCapCuu"].ToString()) == true ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>";
                    html += "</tr>";
                }
            }
        }
        if (add)
        {

            html += "<tr>";
            html += "<td>1</td>";
            html += "<td><a style=\"font-weight:bolder;" + (!true ? "color:#cfcfcf" : "") + "\" onclick=\"xoaontable(this,true);\">" + "HỦY" + "</a></td>";
            html += "<td><input mkv='true' id='PhongID' type='hidden' value=''/><input mkv='true' id='mkv_PhongID' type='text' value='' onfocus='PhongIDSearch(this);' class=\"down_select\"/></td>";
            html += "<td><input mkv='true' id='idbanggiadichvu' type='hidden' value=''/><input mkv='true' id='mkv_idbanggiadichvu' type='text' value='' onfocus='idbanggiadichvuSearch(this);' class=\"down_select\"" + (!add ? "disabled" : (StaticData.EnableChuyenKhoa ? "" : "disabled")) + "/></td>";
            html += "<td><input mkv='true' id='SoTT' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";
            html += "<td><input mkv='true' id='SLBNCho' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='' onblur='TestSo(this,false,false);' /></td>";

            html += "<td><input mkv='false' id='idkhoachinh' type='hidden' value=''/></td>";
            html += "<td><input mkv='false' id='IsDaThu' type='text' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' value='Chưa thu' disabled /></td>";
            html += "<td align='center'><input mkv='true' id='isNotThuPhiCapCuu' type='checkbox' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' /></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>";
        html += "</table>";
        if (!search)
            html += "Bạn không có quyền xem.";
        else
            html += paging;
        Response.Clear(); Response.Write(html);
    }
    private void HuyDKK()
    {
        string IsDaHuyPhieuThu = Request.QueryString["IsDaHuyPhieuThu"];

        string idchitietdangkykham = Request.QueryString["idchitietdangkykham"];
        string idbanggiadichvu = Request.QueryString["idbanggiadichvu"];
        string sqlUpdate = @"UPDATE CHITIETDANGKYKHAM SET " + (IsDaHuyPhieuThu == "1" ? "dahuy=1" : " ISKHONGKHAM=1") + " WHERE IDCHITIETDANGKYKHAM='" + idchitietdangkykham + "' AND IDBANGGIADICHVU='" + idbanggiadichvu + "'";
        bool ok = DataAcess.Connect.ExecSQL(sqlUpdate);
        if (!ok)
        {
            Response.Clear();
            Response.Write("Không thể thực hiện việc hủy");
            return;
        }
        else
        {
            Response.Clear();
            Response.Write("Đã hủy thành công");
            return;
        }
    }
    private void IDBENHNHAN_BHSearch()
    {
        string sqlSelect = @"SELECT A.IDBENHNHAN_BH,A.SOBHYT,A.NGAYBATDAU,A.NGAYHETHAN,B.TENNOIDANGKY,A.ISDUNGTUYEN
                             FROM BENHNHAN_BHYT A LEFT JOIN KB_NOIDANGKYKB B ON A.IDNOIDANGKYBH=B.IDNOIDANGKY WHERE A.IDBENHNHAN='" + Request.QueryString["IDBENHNHAN"] + "'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null && table.Rows.Count > 0)
        {
            foreach (DataRow row in table.Rows)
            {
                html += string.Format("{0}|{1}|{2}|{3}",
                 "<div style=\"width:100%;height:20px\">"
                     + "<div style=\"width:20%;float:left;height:20px;\" >" + row["SOBHYT"] + "</div>"
                     + "<div style=\"width:35%;float:left;height:20px\" >" + row["TENNOIDANGKY"] + "</div>"
                     + "<div style=\"width:16%;float:left;height:20px\" >" + string.Format("{0:dd/MM/yyyy}", row["NGAYBATDAU"]) + "</div>"
                     + "<div style=\"width:13%;float:left;height:20px\" >" + string.Format("{0:dd/MM/yyyy}", row["NGAYHETHAN"]) + "</div>"
                     + "<div style=\"width:13%;float:left;height:20px; text-align:center;\" >" + (StaticData.IsCheck(row["ISDUNGTUYEN"].ToString()) ? "Đúng tuyến" : "Trái tuyến") + "</div>"
               + "</div>", row["IDBENHNHAN_BH"], row["SOBHYT"], Environment.NewLine);
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void LoaiKhamIDsearch()
    {
        DataTable table = DataAcess.Connect.GetTable("select * from kb_loaibn");
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
}


