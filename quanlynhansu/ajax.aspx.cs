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
using System.Globalization;

public partial class NhanSu_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["do"] != null && Request.QueryString["do"].ToString() != "")
        {
            string action = Request.QueryString["do"].ToString();
            switch (action)
            {
                case "LoadDSNV": loadDSNV(); break;
                case "showDSNV": showDSNV(); break;
                case "showKQCLS": showKQChonNhanVien(); break;
                case "LuuThietLapCa": LuuThietLapCa(); break;
                case "UpdateThietLapCa": UpdateThietLapCa(); break;
                case "LoadThoiGianCa": LoadThoiGianCa(); break;
                case "LuuPhanCaTuDong": LuuPhanCaTuDong(); break;
                case "CapNhatPhanCaTuDong": CapNhatPhanCaTuDong(); break;
            }
        }
    }
    void loadDSNV()
    {
        string htm = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", "",
             "<div style =\"background-color: #4D67A2;float:left;width:600px;width:100%;min-width:600px;height:30px\">"
                          + "<div style=\"width:25%;color:white;font-weight:bold;float:left\" >Tên nhân viên</div>"
                          + "<div style=\"width:15%;color:white;font-weight:bold;float:left\" >Mã NV</div>"
                          + "<div style=\"width:20%;color:white;font-weight:bold;float:left\" >Ngày sinh</div>"
                          + "<div style=\"width:30%;color:white;font-weight:bold;float:left\" >Địa chỉ thường trú</div>"
                          + "</div>","","","","", Environment.NewLine);
        string tenhanvien = Request.QueryString["q"].ToString();
        string sql1 = "select tennhanvien,convert(varchar,ngaysinh,103) as ngaysinh,idnhanvien,diachithuongtru"
            + ",manhanvien,TrinhDo,loainhanvien from nhanvien where status=1 and tennhanvien like N'%" + tenhanvien + "%'";
        DataTable tb = DataAcess.Connect.GetTable(sql1);
        if (tb.Rows.Count < 1)
        {
            Response.Clear();
            Response.Write(htm); ;
        }
        foreach (DataRow h in tb.Rows)
        {
            htm += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", h["tennhanvien"],
                           "<div style=\"float:left;width:600px;width:100%;min-width:600px;height:30px\">"
                                      + "<div style=\"width:25%;float:left;height:30px\" >&nbsp;" + h["tennhanvien"] +
                                      "</div>"
                                      + "<div style=\"width:15%;float:left;height:30px\" >" + h["manhanvien"] + "</div>"
                                      + "<div style=\"width:20%;float:left;height:30px\" >" + h["ngaysinh"] + "</div>"
                                      + "<div style=\"width:30%;float:left;height:30px\" >" +h["diachithuongtru"] + "</div>"                                                                         
                            + "</div>"
                         , h["idnhanvien"], h["TrinhDo"], h["manhanvien"], h["loainhanvien"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(htm);
    }
    private void showDSNV()
    {
        //Response.Write("Phần này hiển thị danh sách nhân viên");
        try
        {
            string listidNhanVien = Request.QueryString["listID"];
            string[] arridcls = listidNhanVien.Split(',');
            //Khoe 2007

            listidNhanVien = listidNhanVien.TrimEnd(',');
            string swhere = "";
            int idPhongBan = StaticData.ParseInt(Request.QueryString["idpb"]);
            if (idPhongBan == 0)
            {

            }
            else
            {
                swhere = " and pb.idphongban=" + idPhongBan + " ";
            }
            string html = "";
            string ischeckCaPhong="";
            string ListPhongCheckAll=Request.QueryString["txtListIdPhongCheckAll"].ToString().Trim();
            string [] arrListIdPhongCheck= ListPhongCheckAll.Split(',');
            for(int i=0;i<arrListIdPhongCheck.Length;i++)
            {
                if (arrListIdPhongCheck[i] == idPhongBan.ToString())
                {
                    ischeckCaPhong = "checked";
                    break;
                }
            }
            html += "<table border=\"0\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\">";
            string sqlSelectNhanVien = ""
              + " select * from nhanvien nv left join phongban pb on nv.idphongban=pb.idphongban where 1=1 " + swhere;
            DataTable arrTenNV = DataAcess.Connect.GetTable(sqlSelectNhanVien);
            {
                if (arrTenNV.Rows.Count != 0)
                {
                    html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" width=\"100%\">";
                    string listIDNVByPhong = "";
                    for (int i = 0; i < arrTenNV.Rows.Count; i++)
                    {
                        listIDNVByPhong += arrTenNV.Rows[i]["idnhanvien"].ToString() + ",";
                    }
                    listIDNVByPhong = listIDNVByPhong.TrimEnd(',');
                    html += "<td colspan=\"2\" align=\"left\">&nbsp;<input id=\"chkAllNvPhong\" onclick=\"setChonCaPhong('" + listIDNVByPhong + "'," + idPhongBan + ",this);\" value=\"\" " + ischeckCaPhong + "  type=\"checkbox\" />Chọn tất cả nhân viên trong phòng</td>";
                   // html += "<td colspan=\"2\" width=\"60%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >Tất cả Nhân Viên trong Phòng</td>";
                    // 
                    html += "</tr>";
                    foreach (DataRow tenNV in arrTenNV.Rows)
                    {
                        int dk = 0;

                        html += "<tr onmouseover=\"this.bgColor='#CAE3FF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" width=\"100%\">";

                        string id = tenNV["idnhanvien"].ToString();
                        for (int i = 0; i < arridcls.Length; i++)
                        {
                            string tam = arridcls[i].ToString();
                            if (id == tam)
                            {
                                html += "<td align=\"left\">&nbsp;<input id=\"chkIDNV\" onclick=\"setChonNhanVien(" + tenNV["idnhanvien"] + ",this)\" value=\"" + tenNV["idnhanvien"] + "\" checked  type=\"checkbox\" /></td>";
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
                            html += "<td align=\"left\">&nbsp;<input id=\"chkIDNV\" onclick=\"setChonNhanVien(" + tenNV["idnhanvien"] + ",this)\" value=\"" + tenNV["idnhanvien"] + "\" type=\"checkbox\" /></td>";
                        }

                        html += "<td width=\"60%\" onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" class=\"ptext\" >&nbsp;" + tenNV["tennhanvien"] + "</td>";
                        html += "<td width=\"30%\" class=\"ptext\" align = \"left\" style = \"padding-right:20px\">" + tenNV["tenphongban"] + "</td>";
                        html += "</tr>";
                    }

                }
            }
            html += "</table>";

            Response.Write(html);

        }
        catch (Exception)
        {
            Response.Write("error");
        }
    }

    private void showKQChonNhanVien()/// chỉ định cận lâm sàng
    {
        try
        {
            string listidNhanVien = Request.QueryString["listIDNV"];
            listidNhanVien = listidNhanVien.TrimEnd(',');
            string[] arridcls = listidNhanVien.Split(',');
            string html = "";
            html = "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" width=\"750px\">";

            html += "<tr style =\"background-color: #4D67A2\">";
            html += "<td width=\"5%\" class=\"item\" style=\"color:white;font-weight:bold;\" ></td>";
            html += "<td width=\"40%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên Nhân Viên</td>";
            html += "<td width=\"10%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày sinh</td>";
            html += "<td width=\"25%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Phòng ban</td>";
            html += "<td width=\"20%\" class=\"item\" style=\"color:white;font-weight:bold;\" >Chức vụ</td>";
            html += "</tr>";
            string selectNhanVien = "select *,convert(varchar,ngaysinh,103)as ngaysinhNV from nhanvien nv left join phongban pb on nv.idphongban=pb.idphongban "
            + "left join chucvu cv on cv.status=1 and cv.idchucvu=nv.idchucvu where nv.idnhanvien in(" + listidNhanVien + ")";
            DataTable dt = DataAcess.Connect.GetTable(selectNhanVien);
            if (dt != null && dt.Rows.Count != 0)
            {
                int tongSoNhanVien = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
                    html += "<td width=\"5%\" class=\"ptext\" >&nbsp;<a style=\"cursor:pointer;\" onclick=\"setChonNhanVien(" + dt.Rows[i]["idnhanvien"] + ",false);showKQCLS();\" style=\"color:black\">X</a></td>";
                    html += "<td width=\"40%\" class=\"ptext\" >&nbsp;" + dt.Rows[i]["tennhanvien"] + "</td>";
                    html += "<td width=\"10%\" class=\"ptext\" >&nbsp;" + dt.Rows[i]["ngaysinhNV"] + "</td>";
                    html += "<td width=\"25%\" class=\"ptext\" >&nbsp;" + dt.Rows[i]["tenphongban"] + "</td>";
                    html += "<td width=\"20%\" class=\"ptext\" align = \"right\" style = \"padding-right:20px\">" + dt.Rows[i]["tenchucvu"] + "</td>";
                    html += "</tr>"; //html += "<tr><td colspan=\"3\"><br/></td></tr>";
                    tongSoNhanVien += 1;
                }
                html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
                html += "<td width=\"5%\" class=\"ptext\" >&nbsp; </td>";
                html += "<td width=\"40%\" class=\"ptext\" >&nbsp; </td>";
                html += "<td width=\"10%\" class=\"ptext\" >&nbsp;</td>";
                html += "<td style=\"COLOR: #ff0066\" width=\"25%\" class=\"ptext\"  ><b>&nbsp;TỔNG SỐ NHÂN VIÊN:</b></td>";
                html += "<td style=\"COLOR: #ff0066\" width=\"20%\" class=\"ptext\" align = \"right\" style = \"padding-right:20px\"><b> " + tongSoNhanVien + " </b></td>";
                html += "</tr>"; //html += "<tr><td colspan=\"3\"><br/></td></tr>";

            }
            html += "</table>";
            Response.Write(html);
        }
        catch (Exception)
        {

            Response.Write("error");
        }
    }
    private void LuuThietLapCa()
    {
        try
        {
            string idLoaiTangCa = Request.QueryString["idLoaiTangCa"].ToString();
            string listIDNV = Request.QueryString["listIDNV"].ToString();
            string txtNgay = Request.QueryString["txtNgay"].ToString();
            string ddlTuGioText = Request.QueryString["ddlTuGioText"].ToString();
            string ddlDenGioText = Request.QueryString["ddlDenGioText"].ToString();
            string sogio = Request.QueryString["sogio"].ToString();
            listIDNV = listIDNV.TrimEnd(',');
            string[] arrlistIDNV = listIDNV.Split(',');
            string newIdTangCa = StaticData.MaxIdNhanSuTheoTable("tangca", "idtangca");
            NhanSu_Process.TangCa TangCa = NhanSu_Process.TangCa.Insert_Object(newIdTangCa
                , idLoaiTangCa, StaticData.CheckDate(txtNgay), ddlTuGioText
                , ddlDenGioText, sogio, "0", "0", "0", "1");
            if (TangCa != null)
            {
                for (int i = 0; i < arrlistIDNV.Length; i++)
                {
                    string newIdChiTietTangCa = StaticData.MaxIdNhanSuTheoTable("ChiTietTangCa", "idchitiettangca");
                    NhanSu_Process.ChiTietTangCa CTTC = NhanSu_Process.ChiTietTangCa.Insert_Object(newIdChiTietTangCa
                        , TangCa.idtangca, arrlistIDNV[i]);
                    if (CTTC == null)
                    {
                        Response.Write("0");//lỗi
                        return;
                    }
                }
            }
            Response.Write(TangCa.idtangca);//Lưu thành công
        }
        catch (Exception)
        {
            Response.Write("0");//lỗi
        }
    }

    private void UpdateThietLapCa()
    {
        try
        {
            string idTangCa = Request.QueryString["idTangCa"].ToString();
            string idLoaiTangCa = Request.QueryString["idLoaiTangCa"].ToString();
            string listIDNV = Request.QueryString["listIDNV"].ToString();
            string txtNgay = Request.QueryString["txtNgay"].ToString();
            string ddlTuGioText = Request.QueryString["ddlTuGioText"].ToString();
            string ddlDenGioText = Request.QueryString["ddlDenGioText"].ToString();
            string sogio = Request.QueryString["sogio"].ToString();
            listIDNV = listIDNV.TrimEnd(',');
            string[] arrlistIDNV = listIDNV.Split(',');
            //string newIdTangCa = StaticData.MaxIdNhanSuTheoTable("tangca", "idtangca");
            NhanSu_Process.TangCa TangCa = new NhanSu_Process.TangCa();
            TangCa.idtangca = idTangCa;
            bool ktUpdate = TangCa.Save_Object(idTangCa
                , idLoaiTangCa, StaticData.CheckDate(txtNgay), ddlTuGioText
                , ddlDenGioText, sogio, "0", "0", "0", "1");
            if (ktUpdate)
            {
                // Xóa danh sách nhân viên cũ
                bool ktdel = DataAcess.Connect.ExecSQL("delete from chitiettangca where idtangca=" + idTangCa);
                for (int i = 0; i < arrlistIDNV.Length; i++)
                {
                    string newIdChiTietTangCa = StaticData.MaxIdNhanSuTheoTable("ChiTietTangCa", "idchitiettangca");
                    NhanSu_Process.ChiTietTangCa CTTC = NhanSu_Process.ChiTietTangCa.Insert_Object(newIdChiTietTangCa
                        , TangCa.idtangca, arrlistIDNV[i]);
                    if (CTTC == null)
                    {
                        Response.Write("0");//lỗi
                        return;
                    }
                }
            }
            Response.Write(TangCa.idtangca);//Lưu thành công
        }
        catch (Exception)
        {
            Response.Write("0");//lỗi
        }
    }

    private void LoadThoiGianCa()
    {
        string idcalamviec = Request.QueryString["idcalamviec"].ToString();
        string sqlCaLamViec = " select * from calamviec where idcalamviec="+idcalamviec;
        DataTable dtCaLamViec = DataAcess.Connect.GetTable(sqlCaLamViec);
        if (dtCaLamViec == null || dtCaLamViec.Rows.Count == 0)
        {
            Response.Write("0");//lỗi
            return;
        }
        else
        {
            string ThoiGian = dtCaLamViec.Rows[0]["tugio"].ToString().Trim() + "," + dtCaLamViec.Rows[0]["dengio"].ToString().Trim();
            Response.Write(ThoiGian);//Đúng
        }
    }

    private void LuuPhanCaTuDong()
    {
        string idCaLamViec = Request.QueryString["idCaLamViec"].ToString().Trim();
        if (idCaLamViec == "0" || idCaLamViec == "")
        {
            Response.Write("0");//lỗi
            return;
        }
        string listIDNV = Request.QueryString["listIDNV"].ToString().Trim();
        string txtNgay = Request.QueryString["txtNgay"].ToString().Trim();
        if (!KiemTraNgayHopLe(txtNgay))
        {
            Response.Write("0");//lỗi
            return;
        }
        string txtDenNgay = Request.QueryString["txtDenNgay"].ToString().Trim();
        if (!KiemTraNgayHopLe(txtDenNgay))
        {
            Response.Write("0");//lỗi
            return;
        }
        if (KiemTraKhoangNgay(txtNgay, txtDenNgay) == false)
        {
            Response.Write("0");//lỗi
            return;
        }
        // Xử lý dữ liệu , Lưu Phân ca.
        listIDNV = listIDNV.TrimEnd(',');
        if (listIDNV == "")
        {
            Response.Write("0");//lỗi
            return;
        }
        string[] arrlistIDNV = listIDNV.Split(',');
        DateTime TuNgay = DateTime.ParseExact(txtNgay, new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        DateTime DenNgay = DateTime.ParseExact(txtDenNgay, new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        while (TuNgay<=DenNgay)
        {
            for(int i=0;i<arrlistIDNV.Length;i++)
            {
                string slqTonTaiPhanCa = "select * from phanca where idnhanvien=" + arrlistIDNV[i]+ " and convert(varchar,ngaythangnam,103)='" + TuNgay.ToString("dd/MM/yyyy") + "' and idcalamviec=" + idCaLamViec;
                DataTable dtPhanCa = DataAcess.Connect.GetTable(slqTonTaiPhanCa);
                if (dtPhanCa.Rows.Count == 0)
                {
                    string idPhanca = StaticData.MaxIdNhanSuTheoTable("PhanCa", "idphanca");
                    NhanSu_Process.PhanCa PC = NhanSu_Process.PhanCa.Insert_Object(idPhanca, arrlistIDNV[i], TuNgay.ToString("MM/dd/yyyy"), "", idCaLamViec, "1");
                    if (PC == null)
                    {
                        Response.Write("0");//lỗi
                        return;
                    }
                }
                else
                {
                    NhanSu_Process.PhanCa PC = new NhanSu_Process.PhanCa();
                    PC.idphanca = dtPhanCa.Rows[0]["idphanca"].ToString();
                    bool ktPC = PC.Save_Object(PC.idphanca, arrlistIDNV[i], TuNgay.ToString("MM/dd/yyyy"), "", idCaLamViec, "1");
                }
            }
            TuNgay = TuNgay.AddDays(1);
        }
    }

    private void CapNhatPhanCaTuDong()
    {
        string idCaLamViec = Request.QueryString["idCaLamViec"].ToString().Trim();
        if (idCaLamViec == "0" || idCaLamViec == "")
        {
            Response.Write("0");//lỗi
            return;
        }
        string listIDNV = Request.QueryString["listIDNV"].ToString().Trim();
        string txtNgay = Request.QueryString["txtNgay"].ToString().Trim();
        if (!KiemTraNgayHopLe(txtNgay))
        {
            Response.Write("0");//lỗi
            return;
        }
        string txtDenNgay = Request.QueryString["txtDenNgay"].ToString().Trim();
        if (!KiemTraNgayHopLe(txtDenNgay))
        {
            Response.Write("0");//lỗi
            return;
        }
        if (KiemTraKhoangNgay(txtNgay, txtDenNgay) == false)
        {
            Response.Write("0");//lỗi
            return;
        }
        // Xử lý dữ liệu , Lưu Phân ca.
        listIDNV = listIDNV.TrimEnd(',');
        
        string[] arrlistIDNV = listIDNV.Split(',');
        DateTime TuNgay = DateTime.ParseExact(txtNgay, new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        DateTime DenNgay = DateTime.ParseExact(txtDenNgay, new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        while (TuNgay <= DenNgay)
        {
            //Kiểm tra Nếu ngày cập nhật <= ngày hiện tại thì bỏ qua
            DateTime NgayHienTai=DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
            if (TuNgay <= NgayHienTai)
            {
                TuNgay = TuNgay.AddDays(1);
                continue;
            }
            //Xóa Phân ca cũ,thêm mới lại
            string DellPhanCa = "delete from phanca where  convert(varchar,ngaythangnam,103)='" + TuNgay.ToString("dd/MM/yyyy") + "' and idcalamviec=" + idCaLamViec; ;
            bool kt = DataAcess.Connect.ExecSQL(DellPhanCa);
            if (listIDNV != "")
            {
                for (int i = 0; i < arrlistIDNV.Length; i++)
                {
                    string idPhanca = StaticData.MaxIdNhanSuTheoTable("PhanCa", "idphanca");
                    NhanSu_Process.PhanCa PC = NhanSu_Process.PhanCa.Insert_Object(idPhanca, arrlistIDNV[i], TuNgay.ToString("MM/dd/yyyy"), "", idCaLamViec, "1");
                    if (PC == null)
                    {
                        Response.Write("0");//lỗi
                        return;
                    }
                }
            }
            TuNgay = TuNgay.AddDays(1);
        }
    }
    private bool KiemTraNgayHopLe(string NgayDMY)
    {
        bool kt = true;
        try
        {
            DateTime date = DateTime.ParseExact(NgayDMY, new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
        catch (Exception)
        {
            kt= false;
        }
        return kt;
    }
    private bool KiemTraKhoangNgay(string NgayBatDau, string NgayKetThuc)
    {
        try
        {
            DateTime date = DateTime.ParseExact(NgayBatDau, new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
            DateTime date1 = DateTime.ParseExact(NgayKetThuc, new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
            if (date1 < date)
                return false;
            else
                return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
