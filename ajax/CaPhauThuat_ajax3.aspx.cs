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

public partial class CaPhauThuat_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Them": InsertCaPhauThuat(); break;
            case "Sua": UpdateCaPhauThuat(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableBSPhauThuat": LuuTableBSPhauThuat(); break;
            case "loadTableBSPhauThuat": loadTableBSPhauThuat(); break;
            case "loadTableThuoc": loadTableThuoc(); break;
            //ngay 20/10/2011
            case "loadTableThuocKho2": loadTableThuocKho2(); break;
            case "luuTableLoaithuocKho2": LuuTableLoaithuocKho2(); break;
            //end
            //ngay 18/10/2011
            case "loadTableCLS": loadTableCLS(); break;
            case "luuTableCLS": LuuTableCLS(); break;
            case "timkiemCLS": TimKiemCLS(); break;
            // end
            // ngay 21/10/2011
            case "xoaCLS": XoaCLS(); break;
            case "timkiemPhuongPhapVoCam": timkiemPhuongPhapVoCam(); break;
            //end
            case "xoa": XoaCaPhauThuat(); break;
            case "xoaBSPhauThuat": XoaBSPhauThuat(); break;
            case "xoaThuoc": XoaThuoc(); break;
            case "DropDownList_idPhongPhauThuat": LoadDropDownList_idPhongPhauThuat(); break;
            case "timkiemBN": TimKiemBN(); break;
            case "timkiemNV": TimKiemNV(); break;
            case "timkiemThuoc": TimKiemThuoc(); break;
            case "timkiemgoiphauthuat": Timkiemgoiphauthuat(); break;
            case "luuTableLoaithuoc": LuuTableLoaithuoc(); break;
        }
    }

    public void timkiemPhuongPhapVoCam()
    {
        DataTable table = DataAcess.Connect.GetTable("select top 50 * from PhuongPhapVoCam where TenPhuongPhapVoCam like N'" + Request.QueryString["q"] + "%'");
        string html = "";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += table.Rows[i]["TenPhuongPhapVoCam"] + "|" + Environment.NewLine;
        }
        Response.Clear();
        Response.Write(html);
    }

    public void TimKiemThuoc()
    {
        string sql = "";
        if (Request.QueryString["loaithuoc"] != null)
        {
            sql += " and loaithuocid='" + Request.QueryString["loaithuoc"].ToString() + "'";
        }
        DataTable table = DataAcess.Connect.GetTable("select top 50 * from thuoc where tenthuoc like N'" + Request.QueryString["q"] + "%'" + sql);
        string html = "";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += table.Rows[i]["tenthuoc"] + "|" + table.Rows[i]["iddvt"] + "|" + table.Rows[i]["duongdung"] + "|" + Environment.NewLine;
        }
        Response.Clear();
        Response.Write(html);
    }

    public void TimKiemCLS()
    {
        string sql = "";
        if (Request.QueryString["idgoiphauthuat"] != null)
        {
            sql += " and c.tengoiphauthuat=N'" + Request.QueryString["idgoiphauthuat"].ToString() + "'";
        }
        DataTable table = DataAcess.Connect.GetTable("select top 50 * from ChiTietCLSGoiPhauThuat a left join banggiadichvu b on b.idbanggiadichvu = a.idcanlamsang left join goiphauthuat c on c.idgoiphauthuat = a.idgoiphauthuat where tendichvu like N'%" + Request.QueryString["q"] + "%'" + sql);
        string html = "";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += table.Rows[i]["tendichvu"] + "|" + table.Rows[i]["madichvu"] + "|" + table.Rows[i]["idloaiphauthuat"] + "|" + Environment.NewLine;
        }
        Response.Clear();
        Response.Write(html);
    }


    public void Timkiemgoiphauthuat()
    {
        DataTable table = DataAcess.Connect.GetTable("select top 50 * from goiphauthuat where tengoiphauthuat like N'" + Request.QueryString["q"] + "%'");
        string html = "";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += table.Rows[i]["tengoiphauthuat"] + "|" + Environment.NewLine;
        }
        Response.Clear();
        Response.Write(html);
    }

    public void TimKiemBN()
    {
        string html = "";
        string sql = " 1=1 ";
        if (Request.QueryString["loai"].ToString() == "tenbenhnhan")
        {
            sql += " and tenbenhnhan like N'%" + Request.QueryString["q"].ToString() + "%'";
        }
        else
        {
            sql += " and mabenhnhan like N'" + Request.QueryString["q"].ToString() + "%'";
        }
        DataTable table = DataAcess.Connect.GetTable("select top 50 *,[dbo].[GetGioiTinh](gioitinh) as GioiTinh1 from benhnhan where " + sql);
        //for (int i = 0; i < table.Rows.Count; i++)
        //{
        //    html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div><div style='float:left;width:30%'>" + table.Rows[i]["mabenhnhan"].ToString() + 
        //        "</div><div style='float:left;width:70%'>" + table.Rows[i]["tenbenhnhan"].ToString() + "</div><div style='float:left;width:30%'>" + table.Rows[i]["ngaysinh"].ToString() + 
        //        "</div></div>", table.Rows[i]["mabenhnhan"].ToString(), table.Rows[i]["ngaysinh"].ToString(),table.Rows[i]["tenbenhnhan"].ToString(), Environment.NewLine);
        //}

        foreach (DataRow h in table.Rows)
        {
            //html += table.Rows[i][1] + "|" + table.Rows[i][0] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + Environment.NewLine;
            html += string.Format("{0}|{1}|{2}|{3}", "<div>"
          + "<div style=\"width:14%;height:30px;float:left\" >" + h["mabenhnhan"] + "</div>"
          + "<div style=\"width:25%;height:30px;float:left\" >" + h["tenbenhnhan"] + "</div>"
          + "<div style=\"width:10%;height:30px;float:left\" >" + h["ngaysinh"] + "</div>"
          + "<div style=\"width:5%;height:30px;float:left\" >" + h["GioiTinh1"] + "</div>"
          + "<div >" + h["DiaChi"] + "</div>"
          + "</div>", h["mabenhnhan"], h["tenbenhnhan"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
    }
    public void TimKiemNV()
    {
        string html = "";
        string sql = " 1=1 ";
        if (Request.QueryString["loai"].ToString() == "tennhanvien")
        {
            sql += " and tennhanvien like N'%" + Request.QueryString["q"].ToString() + "%'";
        }
        else
        {
            sql += " and manhanvien like N'" + Request.QueryString["q"].ToString() + "%'";
        }

        DataTable table = DataAcess.Connect.GetTable("select top 50 * from nhanvien where " + sql);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += string.Format("{0}|{1}|{2}|{3}", "<div><div style='float:left;width:30%'>" + table.Rows[i]["manhanvien"].ToString() + "</div><div style='float:left;width:70%'>" + table.Rows[i]["tennhanvien"].ToString() + "</div></div>", table.Rows[i]["manhanvien"].ToString(), table.Rows[i]["tennhanvien"].ToString(), Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
    }

    // luon luon chi co 2 truong la id va value
    private void LoadDropDownList_idPhongPhauThuat()
    {
        DataTable table = NhanSu_Process.KB_Phong.GetTable("select * from KB_Phong where dichvuKCB=2003 ");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {

                    html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y][2].ToString();

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaCaPhauThuat()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete CaPhauThuat where idCaPhauThuat=" + idkhoachinh;
            bool ok = NhanSu_Process.CaPhauThuat.ExecSQL(sql);
            if (ok)
            {
                Response.Clear(); Response.Write(idkhoachinh);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }

    private void XoaBSPhauThuat()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete BSPhauThuat where idBSPhauThuat=" + idkhoachinh;
            bool ok = NhanSu_Process.BSPhauThuat.ExecSQL(sql);
            if (ok)
            {
                Response.Clear(); Response.Write(idkhoachinh);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }
    private void XoaThuoc()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete thuocphauthuat where idthuocphauthuat=" + idkhoachinh;
            bool ok = NhanSu_Process.BSPhauThuat.ExecSQL(sql);
            if (ok)
            {
                Response.Clear(); Response.Write(idkhoachinh);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }
    private void XoaCLS()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete CLSPhauthuat where idCLSPhauThuat=" + idkhoachinh;
            bool ok = NhanSu_Process.CLSPhauThuat.ExecSQL(sql);
            if (ok)
            {
                Response.Clear(); Response.Write(idkhoachinh);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }
    private void setTimKiem()
    {
        string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
        DataTable table = NhanSu_Process.CaPhauThuat.GetTable("select idCaPhauThuat,maBenhNhan,tenbenhnhan,tengoiphauthuat,idPhongPhauThuat,NgayPhauThuat,trongoi,BinhThuong,ChiChu,sovaovien from CaPhauThuat a left join benhnhan b on a.idbenhnhan = b.idbenhnhan left join goiphauthuat c on c.idgoiphauthuat = a.idgoiphauthuat  where idCaPhauThuat = " + idkhoachinh);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Columns.Count; y++)
                {
                    try
                    {
                        if (y != 9)
                            html += DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "@";
                        else
                        {
                            html += table.Rows[0][y].ToString() + "@";
                        }
                    }
                    catch (Exception)
                    {
                        html += table.Rows[0][y].ToString() + "@";
                    }
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    private void TimKiem()
    {
        string sql = "1=1";
        if (Request.QueryString["idCaPhauThuat"] != null && Request.QueryString["idCaPhauThuat"].ToString() != "")
        {
            sql += " and idCaPhauThuat = '" + Request.QueryString["idCaPhauThuat"] + "'";
        }
        if (Request.QueryString["idBenhNhan"] != null && Request.QueryString["idBenhNhan"].ToString() != "")
        {
            sql += " and maBenhNhan = '" + Request.QueryString["idBenhNhan"] + "'";
        }
        if (Request.QueryString["idPhongPhauThuat"] != null && Request.QueryString["idPhongPhauThuat"].ToString() != "0")
        {
            sql += " and idPhongPhauThuat = '" + Request.QueryString["idPhongPhauThuat"] + "'";
        }
        if (Request.QueryString["NgayPhauThuat"] != null)
        {
            string NgayPhauThuat = "";
            if (Request.QueryString["NgayPhauThuat"].ToString() != "")
            {
                string[] ngaythangcurent3 = Request.QueryString["NgayPhauThuat"].ToString().Split('/');
                NgayPhauThuat = ngaythangcurent3[1] + "/" + ngaythangcurent3[0] + "/" + ngaythangcurent3[2];
                sql += " and NgayPhauThuat >= '" + NgayPhauThuat + "'";
            }
        } if (Request.QueryString["trongoi"] != null && Request.QueryString["trongoi"].ToString() != "")
        {
            sql += " and trongoi = '" + Request.QueryString["trongoi"] + "'";
        }
        if (Request.QueryString["BinhThuong"] != null && Request.QueryString["BinhThuong"].ToString() != "")
        {
            sql += " and BinhThuong = '" + Request.QueryString["BinhThuong"] + "'";
        }
        if (Request.QueryString["ChiChu"] != null && Request.QueryString["ChiChu"].ToString() != "")
        {
            sql += " and ChiChu like N'%" + Request.QueryString["ChiChu"] + "%'";
        }
        if (Request.QueryString["sovaovien"] != null && Request.QueryString["sovaovien"].ToString() != "")
        {
            sql += " and sovaovien like N'%" + Request.QueryString["sovaovien"] + "%'";
        }
        string SelectTim = @"select SoVaoVien,idCaPhauThuat,a.idBenhNhan,b.tenbenhnhan,idPhongPhauThuat,tenphong,NgayPhauThuat,DichVu=[dbo].[NS_ChuoiPhauThuatTheoCa](a.idcaphauthuat)
        ,case when a.trongoi=1 then N'Trọn gói' else N'Bình thường' end as LoaiGoi
        ,trongoi,BinhThuong,ChiChu from CaPhauThuat a left join benhnhan b on a.idbenhnhan=b.idbenhnhan
	        left join KB_Phong p on a.idPhongPhauThuat=p.id where " + sql;
        //DataTable table = Process.CaPhauThuat.GetTable("select idCaPhauThuat,a.idBenhNhan,a.tenbenhnhan,idPhongPhauThuat,NgayPhauThuat,trongoi,BinhThuong,ChiChu from CaPhauThuat a left join benhnhan b on a.idbenhnhan=b.idbenhnhan where " + sql);
        DataTable table = NhanSu_Process.CaPhauThuat.GetTable(SelectTim);
        string html = "";
        html += "<table name=\"tablefind\" id=\"tablefind\" border=\"1\" align=\"center\" width=\"100%\">";
        html += "<tr style='background-color:#4D67A2;color:white;font-weight:bold'>";
        html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoVaoVien") + "</td>";
        html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenBenhNhan") + "</td>";
        html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("PhongPhauThuat") + "</td>";
        html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayPhauThuat") + "</td>";
        html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenPhauThuat") + "</td>";
        html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("LoaiGoi") + "</td>";
        //html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("BinhThuong") + "</td>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr id=\"background\" style='cursor:pointer;color:gray' onclick=\"setControlFind('" + table.Rows[i]["idCaPhauThuat"].ToString() + "','" + hsLibrary.clDictionaryDB.sGetValueLanguage("update") + "')\">";
                    html += "<td>" + table.Rows[i]["SoVaoVien"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["tenbenhnhan"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["tenphong"].ToString() + "</td>";
                    if (table.Rows[i]["NgayPhauThuat"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(table.Rows[i]["NgayPhauThuat"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                    }
                    else { html += "<td>" + table.Rows[i]["NgayPhauThuat"].ToString() + "</td>"; }
                    html += "<td>" + table.Rows[i]["DichVu"].ToString() + "</td>";
                    html += "<td>" + table.Rows[i]["LoaiGoi"].ToString() + "</td>";
                    //html += "<td>" + table.Rows[i]["BinhThuong"].ToString() + "</td>";
                    html += "</tr>";
                }
                html += "</table>";
                Response.Clear(); Response.Write(html);
                return;
            }
        }
        else
        {
            Response.Clear(); Response.Write("");
        }
    }
    private void InsertCaPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idBenhNhan = "";
            if (Request.QueryString["idBenhNhan"] != null)
            {
                DataTable table = DataAcess.Connect.GetTable("select top 1 * from benhnhan where mabenhnhan = N'" + Request.QueryString["idBenhNhan"].ToString() + "'");
                if (table.Rows.Count > 0)
                {
                    idBenhNhan = table.Rows[0]["idbenhnhan"].ToString();
                }
                else
                {
                    Response.Clear(); Response.Write("");
                    return;
                }

            }
            string idGoiPhauThuat = "";
            if (Request.QueryString["idgoiphauthuat"] != null)
            {
                DataTable table = DataAcess.Connect.GetTable("select top 50 * from goiphauthuat where tengoiphauthuat like N'" + Request.QueryString["idgoiphauthuat"].ToString() + "%'");
                if (table.Rows.Count > 0)
                    idGoiPhauThuat = table.Rows[0]["idgoiphauthuat"].ToString();
                else
                {
                    Response.Clear(); Response.Write("");
                    return;
                }
            }
            string idPhongPhauThuat = "";
            if (Request.QueryString["idPhongPhauThuat"] != null)
            {
                idPhongPhauThuat = Request.QueryString["idPhongPhauThuat"].ToString();
            } string NgayPhauThuat = "";
            if (Request.QueryString["NgayPhauThuat"].ToString() != "")
            {
                string[] ngaythangcurent3 = Request.QueryString["NgayPhauThuat"].ToString().Split('/');
                NgayPhauThuat = ngaythangcurent3[1] + "/" + ngaythangcurent3[0] + "/" + ngaythangcurent3[2];
            } string trongoi = "";
            if (Request.QueryString["trongoi"] != null)
            {
                trongoi = Request.QueryString["trongoi"].ToString();
            } string BinhThuong = "";
            if (Request.QueryString["BinhThuong"] != null)
            {
                BinhThuong = Request.QueryString["BinhThuong"].ToString();
            } string ChiChu = "";
            if (Request.QueryString["ChiChu"] != null)
            {
                ChiChu = Request.QueryString["ChiChu"].ToString().Trim();
                string SelectVoCam = "select * from PhuongPhapVoCam where TenPhuongPhapVoCam=N'" + ChiChu + "'";
                DataTable dtVoCam = DataAcess.Connect.GetTable(SelectVoCam);
                if (dtVoCam.Rows.Count == 0 && Request.QueryString["ChiChu"].ToString().Trim() != "") //Thêm mới
                {
                    string idVoCam = DataAcess.Connect.GetTable("select isnull(Max(idPhuongPhapVoCam),0)+1 as maxid from PhuongPhapVoCam").Rows[0][0].ToString();
                    string InsertVC = @"insert into PhuongPhapVoCam(idPhuongPhapVoCam,TenPhuongPhapVoCam)
                    values(" + idVoCam + ",N'" + ChiChu + "')";
                    bool ktInsertVC = DataAcess.Connect.ExecSQL(InsertVC);
                }
            }
            string sovaovien = "";
            if (Request.QueryString["sovaovien"] != null)
            {
                sovaovien = Request.QueryString["sovaovien"].ToString();
            }
            NhanSu_Process.CaPhauThuat tempTT = NhanSu_Process.CaPhauThuat.Insert_Object(idBenhNhan, idPhongPhauThuat, idGoiPhauThuat, NgayPhauThuat, trongoi, BinhThuong, ChiChu, sovaovien);
            if (tempTT != null)
            {
                Response.Clear(); Response.Write(tempTT.idCaPhauThuat);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");


    }
    private void UpdateCaPhauThuat()
    {
        try
        {
            char[] splitter = { '/' };
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string idBenhNhan = "";
            if (Request.QueryString["idBenhNhan"] != null)
            {
                DataTable table = DataAcess.Connect.GetTable("select top 1 * from benhnhan where mabenhnhan = N'" + Request.QueryString["idBenhNhan"].ToString() + "'");
                if (table.Rows.Count > 0)
                {
                    idBenhNhan = table.Rows[0]["idbenhnhan"].ToString();
                }
                else
                {
                    Response.Clear(); Response.Write("");
                    return;
                }

            } string idPhongPhauThuat = "";
            if (Request.QueryString["idPhongPhauThuat"] != null)
            {
                idPhongPhauThuat = Request.QueryString["idPhongPhauThuat"].ToString();
            }
            string idGoiPhauThuat = "";
            if (Request.QueryString["idgoiphauthuat"] != null)
            {
                DataTable table = DataAcess.Connect.GetTable("select top 50 * from goiphauthuat where tengoiphauthuat like N'" + Request.QueryString["idgoiphauthuat"].ToString() + "%'");
                if (table.Rows.Count > 0)
                    idGoiPhauThuat = table.Rows[0]["idgoiphauthuat"].ToString();
                else
                {
                    Response.Clear(); Response.Write("");
                    return;
                }
            }
            string NgayPhauThuat = "";
            if (Request.QueryString["NgayPhauThuat"].ToString() != "")
            {
                string[] ngaythangcurent3 = Request.QueryString["NgayPhauThuat"].ToString().Split('/');
                NgayPhauThuat = ngaythangcurent3[1] + "/" + ngaythangcurent3[0] + "/" + ngaythangcurent3[2];
            } string trongoi = "";
            if (Request.QueryString["trongoi"] != null)
            {
                trongoi = Request.QueryString["trongoi"].ToString();
            } string BinhThuong = "";
            if (Request.QueryString["BinhThuong"] != null)
            {
                BinhThuong = Request.QueryString["BinhThuong"].ToString();
            } string ChiChu = "";
            //if (Request.QueryString["ChiChu"] != null)
            //{
            //    ChiChu = Request.QueryString["ChiChu"].ToString();
            //}
            if (Request.QueryString["ChiChu"] != null)
            {
                ChiChu = Request.QueryString["ChiChu"].ToString().Trim();
                string SelectVoCam = "select * from PhuongPhapVoCam where TenPhuongPhapVoCam=N'" + ChiChu + "'";
                DataTable dtVoCam = DataAcess.Connect.GetTable(SelectVoCam);
                if (dtVoCam.Rows.Count == 0 && Request.QueryString["ChiChu"].ToString().Trim() != "") //Thêm mới
                {
                    string idVoCam = DataAcess.Connect.GetTable("select isnull(Max(idPhuongPhapVoCam),0)+1 as maxid from PhuongPhapVoCam").Rows[0][0].ToString();
                    string InsertVC = @"insert into PhuongPhapVoCam(idPhuongPhapVoCam,TenPhuongPhapVoCam)
                    values(" + idVoCam + ",N'" + ChiChu + "')";
                    bool ktInsertVC = DataAcess.Connect.ExecSQL(InsertVC);
                }
            }
            string sovaovien = "";
            if (Request.QueryString["sovaovien"] != null)
            {
                sovaovien = Request.QueryString["sovaovien"].ToString();
            }
            NhanSu_Process.CaPhauThuat temp = NhanSu_Process.CaPhauThuat.Create_CaPhauThuat(idkhoachinh);
            bool ok = temp.Save_Object(idBenhNhan, idPhongPhauThuat, idGoiPhauThuat, NgayPhauThuat, trongoi, BinhThuong, ChiChu, sovaovien);
            if (ok)
            {
                Response.Clear(); Response.Write(idkhoachinh);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }
    public void LuuTableBSPhauThuat()
    {
        try
        {
            if (Request.QueryString["idNhanVien"].ToString() != "")
            {
                string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                char[] splitter = { '/' };
                string idCaPhauThuat = "";
                if (Request.QueryString["idCaPhauThuat"] != null)
                {
                    idCaPhauThuat = Request.QueryString["idCaPhauThuat"].ToString();
                } string idVaiTroBSPThuat = "";
                string idLoaiPhauThuat = "";
                if (Request.QueryString["idVaiTroBSPThuat"] != null)
                {
                    //set idVaiTroBSPThuat chính là IdchitietPCBSPT
                    idLoaiPhauThuat = Request.QueryString["idLoaiPhauThuat"].ToString();
                    idVaiTroBSPThuat = Request.QueryString["idVaiTroBSPThuat"].ToString();
                    string sqlLoai_VT = "select IdchitietPCBSPT from chitietPhuCapbacSiPhauThuat where idloaiphauthuat=" + idLoaiPhauThuat + " and idvaitroBSPT=" + idVaiTroBSPThuat + "";
                    DataTable dtCTVT = DataAcess.Connect.GetTable(sqlLoai_VT);
                    if (dtCTVT.Rows.Count > 0)
                        idVaiTroBSPThuat = dtCTVT.Rows[0]["IdchitietPCBSPT"].ToString();
                    else
                        idVaiTroBSPThuat = "0";
                }

                string idNhanVien = "";
                if (Request.QueryString["idNhanVien"] != null)
                {
                    DataTable table = DataAcess.Connect.GetTable("select top 1 * from nhanvien where manhanvien = N'" + Request.QueryString["idNhanVien"].ToString() + "'");
                    if (table.Rows.Count > 0)
                    {
                        idNhanVien = table.Rows[0]["idnhanvien"].ToString();
                    }
                    else
                    {
                        Response.Clear(); Response.Write("");
                        return;
                    }

                } if (!idkhoachinh.Trim().Equals(""))
                {
                    NhanSu_Process.BSPhauThuat temp = NhanSu_Process.BSPhauThuat.Create_BSPhauThuat(idkhoachinh);
                    bool ok = temp.Save_Object(idCaPhauThuat, idVaiTroBSPThuat, idNhanVien);
                    if (ok)
                    {
                        Response.Clear(); Response.Write(idkhoachinh);
                        return;
                    }
                }
                else
                {
                    NhanSu_Process.BSPhauThuat tempTT = NhanSu_Process.BSPhauThuat.Insert_Object(idCaPhauThuat, idVaiTroBSPThuat, idNhanVien);
                    if (tempTT != null)
                    {
                        Response.Clear(); Response.Write(tempTT.idBSPhauThuat);
                        return;
                    }
                }
            }
            else
            {
                Response.Clear(); Response.Write("");
            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }
    public void loadTableBSPhauThuat()
    {
        string sql = "";
        sql += Request.QueryString["idkhoachinh"].ToString();
        DataTable table = NhanSu_Process.BSPhauThuat.GetTable("select * from BSPhauThuat a left join nhanvien b on a.idnhanvien = b.idnhanvien where idCaPhauThuat='" + sql + "'");
        DataTable table2 = NhanSu_Process.VaiTroBSPhauThuat.GetTable("select * from VaiTroBSPhauThuat ");
        string html = "";
        html += "<table id=\"gridBSPhauthuat\" align=\"center\" width=\"100%\" bgcolor=\"white\" >";
        html += "<tr style='background-color:#4473ca;height:30px'>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>STT</td>";
        html += "<td></td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("mabacsy") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenbacsy") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idVaiTroBSPThuat") + "</td>";
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td align='center'>" + (i + 1) + "</td>";
                html += "<td><a onclick='if(flagtable){tablegrid=\"gridBSPhauthuat\";};xoaontable(this.name,this)' name='" + table.Rows[i]["idBSPhauThuat"].ToString() + "'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td  style='width:100px'><input id='maNhanVien_" + (i + 1) + "' style='width:98%' disabled='true' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridBSPhauthuat\";}chuyenform(this);timkiemNV(this,\"manhanvien\");' onkeydown='chuyendong(this);' value='" + table.Rows[i]["maNhanVien"].ToString() + "'/></td>";
                html += "<td  style='width:600px'><input id='tenNhanVien_" + (i + 1) + "' style='width:98%' disabled='true' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridBSPhauthuat\";};chuyenform(this);timkiemNV(this,\"tennhanvien\");' onkeydown='chuyendong(this);' value='" + table.Rows[i]["tenNhanVien"].ToString() + "'/></td>";
                html += "<td><select id='idVaiTroBSPThuat_" + (i + 1) + "' disabled='true' style='width:100%' onfocus='if(flagtable){tablegrid=\"gridBSPhauthuat\";}'>";
                for (int ii = 0; ii < table2.Rows.Count; ii++)
                {
                    if (table.Rows[i]["idchitietPCBSPT"].ToString() != "0" && table.Rows[i]["idchitietPCBSPT"].ToString() != "")
                    {
                        DataTable tableVaiTroK = NhanSu_Process.VaiTroBSPhauThuat.GetTable("select VT.* from VaiTroBSPhauThuat vt left join CHITIETPHUCAPBACSIPHAUTHUAT ct on ct.idvaitroBSPT=vt.idVaiTroBS where ct.idchitietPCBSPT=" + table.Rows[i]["idchitietPCBSPT"].ToString() + "");
                        if (tableVaiTroK.Rows[0][0].ToString() == table2.Rows[ii][0].ToString())
                        {

                            html += "<option selected value='" + tableVaiTroK.Rows[0][0] + "'>" + tableVaiTroK.Rows[0][1] + "</option>";

                        }
                        else
                            html += "<option  value='" + table2.Rows[ii][0] + "'>" + table2.Rows[ii][1] + "</option>";
                    }
                    else
                    {
                        html += "<option value='" + table2.Rows[ii][0] + "'>" + table2.Rows[ii][1] + "</option>";
                    }
                }
                html += "</select></td>";
                html += "<td><input type='hidden' value='" + table.Rows[i]["idBSPhauThuat"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        else
        {
            table.Rows.Add(table.NewRow());
            html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
            html += "<td align='center'>1</td>";
            html += "<td><a onclick='if(flagtable){tablegrid=\"gridBSPhauthuat\";};xoaontable(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td style='width:100px'><input id='maNhanVien_1' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridBSPhauthuat\";};chuyenform(this);timkiemNV(this,\"manhanvien\");' onkeydown='chuyendong(this);' value=''/></td>";
            html += "<td style='width:600px'><input id='tenNhanVien_1' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridBSPhauthuat\";};chuyenform(this);timkiemNV(this,\"tennhanvien\");' onkeydown='chuyendong(this);' value=''/></td>";
            html += "<td><select id='idVaiTroBSPThuat_1' style='width:100%' onfocus='if(flagtable){tablegrid=\"gridBSPhauthuat\";};' >";
            for (int ii = 0; ii < table2.Rows.Count; ii++)
            {
                html += "<option value='" + table2.Rows[ii][0] + "'>" + table2.Rows[ii][1] + "</option>";
            }
            html += "</select></td>";
            html += "<td><input type='hidden' value=''/></td>";
            html += "</tr>";
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }
    private void loadTableThuoc()
    {
        string sql = "";
        sql += Request.QueryString["idkhoachinh"].ToString();
        DataTable table = NhanSu_Process.ThuocPhauThuat.GetTable("select * from thuocphauthuat a left join thuoc b on a.idthuoc = b.idthuoc where idkho=1 and idcaphauthuat=' " + sql + "'");
        DataTable tableLoaithuoc = Process.Thuoc_LoaiThuoc.GetTable("select * from thuoc_loaithuoc");
        DataTable table2 = NhanSu_Process.VaiTroBSPhauThuat.GetTable("select * from VaiTroBSPhauThuat ");
        DataTable tableDVT = Process.Thuoc_DonViTinh.GetTable("select * from Thuoc_DonViTinh ");
        string html = "";
        html += "<table id=\"gridLoaithuoc\" align=\"center\" width=\"100%\" bgcolor=\"white\" >";
        html += "<tr style='background-color:#4473ca;height:30px'>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>STT</td>";
        html += "<td></td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaithuoc") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("cachdung") + "</td>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                    html += "<td align='center'>" + (i + 1) + "</td>";
                    html += "<td><a onclick='if(flagtable){tablegrid=\"gridLoaithuoc\";};xoaontableThuoc(this.name,this)' name='" + table.Rows[i]["idthuocphauthuat"].ToString() + "'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                    html += "<td><select id='loaithuoc_1' style='width:80px' disabled='true' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";}'>";
                    for (int ii = 0; ii < tableLoaithuoc.Rows.Count; ii++)
                    {
                        if (table.Rows[i]["loaithuocid"].ToString() == tableLoaithuoc.Rows[ii][0].ToString())
                        {
                            html += "<option selected value='" + tableLoaithuoc.Rows[ii][0] + "'>" + tableLoaithuoc.Rows[ii][2] + "</option>";
                        }
                        else
                        {
                            html += "<option value='" + tableLoaithuoc.Rows[ii][0] + "'>" + tableLoaithuoc.Rows[ii][2] + "</option>";
                        }
                    }
                    html += "</select></td>";

                    html += "<td style='width:500px'><input id='tenthuoc_1' disabled='true' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";};chuyenform(this);timkiemThuoc(this);' onkeydown='chuyendong(this);' value='" + table.Rows[i]["tenthuoc"].ToString() + "'/></td>";
                    html += "<td style='width:100px'><input id='soluong_1' disabled='true' style='width:98%' type='text' onfocusout='chuyenformout(this);' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";};chuyenform(this);' onkeydown='chuyendong(this);' value='" + table.Rows[i]["soluongthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                    html += "<td><select id='dvt_1' disabled='true' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";}'/>";
                    for (int ii = 0; ii < tableDVT.Rows.Count; ii++)
                    {
                        if (table.Rows[i]["iddvt"].ToString() == tableDVT.Rows[ii][0].ToString())
                        {
                            html += "<option selected value='" + tableDVT.Rows[ii][0] + "'>" + tableDVT.Rows[ii][1] + "</option>";
                        }
                        else
                        {
                            html += "<option value='" + tableDVT.Rows[ii][0] + "'>" + tableDVT.Rows[ii][1] + "</option>";
                        }
                    }
                    html += "</select></td>";
                    html += "<td style='width:100px'><input id='cachdung_1' disabled='true' style='width:98%' type='text' onfocusout='chuyenformout(this);' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";};chuyenform(this);' onkeydown='chuyendong(this);' value='" + table.Rows[i]["cachdungthuoc"].ToString() + "'/></td>";
                    html += "<td><input type='hidden' value='" + table.Rows[i]["idthuocphauthuat"] + "'/></td>";
                    html += "</tr>";

                }
            }
            else
            {
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td align='center'>1</td>";
                html += "<td><a onclick='if(flagtable){tablegrid=\"gridLoaithuoc\";};xoaontableThuoc(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><select id='loaithuoc_1' style='width:80px' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";}'>";
                for (int ii = 0; ii < tableLoaithuoc.Rows.Count; ii++)
                {
                    html += "<option value='" + tableLoaithuoc.Rows[ii][0] + "'>" + tableLoaithuoc.Rows[ii][2] + "</option>";
                }
                html += "</select></td>";

                html += "<td style='width:500px'><input id='tenthuoc_1' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";};chuyenform(this);timkiemThuoc(this);' onkeydown='chuyendong(this);' value=''/></td>";
                html += "<td style='width:100px'><input id='soluong_1' style='width:98%' type='text' onfocusout='chuyenformout(this);' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";};chuyenform(this);' onkeydown='chuyendong(this);' value='' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><select id='dvt_1' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";}'/>";
                for (int ii = 0; ii < tableDVT.Rows.Count; ii++)
                {
                    html += "<option value='" + tableDVT.Rows[ii][0] + "'>" + tableDVT.Rows[ii][1] + "</option>";
                }
                html += "</select></td>";
                html += "<td style='width:100px'><input id='cachdung_1' style='width:98%' type='text' onfocusout='chuyenformout(this);' onfocus='if(flagtable){tablegrid=\"gridLoaithuoc\";};chuyenform(this);' onkeydown='chuyendong(this);' value=''/></td>";
                html += "<td><input type='hidden' value=''/></td>";
                html += "</tr>";
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }

    private void loadTableThuocKho2()
    {
        string sql = "";
        sql += Request.QueryString["idkhoachinh"].ToString();
        DataTable table = NhanSu_Process.ThuocPhauThuat.GetTable("select * from thuocphauthuat a left join thuoc b on a.idthuoc = b.idthuoc where idkho=2 and  idcaphauthuat=' " + sql + "'");
        DataTable tableLoaithuoc = Process.Thuoc_LoaiThuoc.GetTable("select * from thuoc_loaithuoc");
        DataTable table2 = NhanSu_Process.VaiTroBSPhauThuat.GetTable("select * from VaiTroBSPhauThuat ");
        DataTable tableDVT = Process.Thuoc_DonViTinh.GetTable("select * from Thuoc_DonViTinh ");
        string html = "";
        html += "<table id=\"gridLoaithuocKho2\" align=\"center\" width=\"100%\" bgcolor=\"white\" >";
        html += "<tr style='background-color:#4473ca;height:30px'>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>STT</td>";
        html += "<td></td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaithuoc") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenthuoc") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("soluong") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("dvt") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("cachdung") + "</td>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                    html += "<td align='center'>" + (i + 1) + "</td>";
                    html += "<td><a onclick='if(flagtable){tablegrid=\"gridLoaithuocKho2\";};xoaontableThuoc(this.name,this)' name='" + table.Rows[i]["idthuocphauthuat"].ToString() + "'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                    html += "<td><select id='loaithuoc_1' style='width:80px' disabled='true' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";}'>";
                    for (int ii = 0; ii < tableLoaithuoc.Rows.Count; ii++)
                    {
                        if (table.Rows[i]["loaithuocid"].ToString() == tableLoaithuoc.Rows[ii][0].ToString())
                        {
                            html += "<option selected value='" + tableLoaithuoc.Rows[ii][0] + "'>" + tableLoaithuoc.Rows[ii][2] + "</option>";
                        }
                        else
                        {
                            html += "<option value='" + tableLoaithuoc.Rows[ii][0] + "'>" + tableLoaithuoc.Rows[ii][2] + "</option>";
                        }
                    }
                    html += "</select></td>";

                    html += "<td style='width:500px'><input id='tenthuoc_1' disabled='true' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";};chuyenform(this);timkiemThuoc(this);' onkeydown='chuyendong(this);' value='" + table.Rows[i]["tenthuoc"].ToString() + "'/></td>";
                    html += "<td style='width:100px'><input id='soluong_1' disabled='true' style='width:98%' type='text' onfocusout='chuyenformout(this);' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";};chuyenform(this);' onkeydown='chuyendong(this);' value='" + table.Rows[i]["soluongthuoc"].ToString() + "' onblur='TestSo(this,false,false);'/></td>";
                    html += "<td><select id='dvt_1' disabled='true' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";}'/>";
                    for (int ii = 0; ii < tableDVT.Rows.Count; ii++)
                    {
                        if (table.Rows[i]["iddvt"].ToString() == tableDVT.Rows[ii][0].ToString())
                        {
                            html += "<option selected value='" + tableDVT.Rows[ii][0] + "'>" + tableDVT.Rows[ii][1] + "</option>";
                        }
                        else
                        {
                            html += "<option value='" + tableDVT.Rows[ii][0] + "'>" + tableDVT.Rows[ii][1] + "</option>";
                        }
                    }
                    html += "</select></td>";
                    html += "<td style='width:100px'><input id='cachdung_1' disabled='true' style='width:98%' type='text' onfocusout='chuyenformout(this);' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";};chuyenform(this);' onkeydown='chuyendong(this);' value='" + table.Rows[i]["cachdungthuoc"].ToString() + "'/></td>";
                    html += "<td><input type='hidden' value='" + table.Rows[i]["idthuocphauthuat"] + "'/></td>";
                    html += "</tr>";

                }
            }
            else
            {
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td align='center'>1</td>";
                html += "<td><a onclick='if(flagtable){tablegrid=\"gridLoaithuocKho2\";};xoaontableThuoc(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><select id='loaithuoc_1' style='width:80px' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";}'>";
                for (int ii = 0; ii < tableLoaithuoc.Rows.Count; ii++)
                {
                    html += "<option value='" + tableLoaithuoc.Rows[ii][0] + "'>" + tableLoaithuoc.Rows[ii][2] + "</option>";
                }
                html += "</select></td>";

                html += "<td style='width:500px'><input id='tenthuoc_1' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";};chuyenform(this);timkiemThuoc(this);' onkeydown='chuyendong(this);' value=''/></td>";
                html += "<td style='width:100px'><input id='soluong_1' style='width:98%' type='text' onfocusout='chuyenformout(this);' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";};chuyenform(this);' onkeydown='chuyendong(this);' value='' onblur='TestSo(this,false,false);'/></td>";
                html += "<td><select id='dvt_1' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";}'/>";
                for (int ii = 0; ii < tableDVT.Rows.Count; ii++)
                {
                    html += "<option value='" + tableDVT.Rows[ii][0] + "'>" + tableDVT.Rows[ii][1] + "</option>";
                }
                html += "</select></td>";
                html += "<td style='width:100px'><input id='cachdung_1' style='width:98%' type='text' onfocusout='chuyenformout(this);' onfocus='if(flagtable){tablegrid=\"gridLoaithuocKho2\";};chuyenform(this);' onkeydown='chuyendong(this);' value=''/></td>";
                html += "<td><input type='hidden' value=''/></td>";
                html += "</tr>";
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }

    private void LuuTableLoaithuoc()
    {
        try
        {
            if (Request.QueryString["tenthuoc"].ToString() != "")
            {
                string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                char[] splitter = { '/' };
                string idCaPhauThuat = "";
                if (Request.QueryString["idCaPhauThuat"] != null)
                {
                    idCaPhauThuat = Request.QueryString["idCaPhauThuat"].ToString();
                }
                string idthuoc = "";
                if (Request.QueryString["tenthuoc"] != null)
                {
                    DataTable tableThuoc = DataAcess.Connect.GetTable("select top 1 * from thuoc where tenthuoc = N'" + Request.QueryString["tenthuoc"].ToString() + "'");
                    if (tableThuoc.Rows.Count > 0)
                    {
                        idthuoc = tableThuoc.Rows[0]["idthuoc"].ToString();
                    }
                    else
                    {
                        Response.Clear(); Response.Write("");
                        return;
                    }

                } string soluong = "";
                if (Request.QueryString["soluong"] != null)
                {
                    soluong = Request.QueryString["soluong"].ToString();
                }

                string cachdung = "";
                if (Request.QueryString["cachdung"] != null)
                {
                    cachdung = Request.QueryString["cachdung"].ToString();
                } if (!idkhoachinh.Trim().Equals(""))
                {
                    NhanSu_Process.ThuocPhauThuat temp = NhanSu_Process.ThuocPhauThuat.Create_ThuocPhauThuat(idkhoachinh);
                    bool ok = temp.Save_Object(idCaPhauThuat, idthuoc, soluong, cachdung, "1");
                    if (ok)
                    {
                        Response.Clear(); Response.Write(idkhoachinh);
                        return;
                    }
                }
                else
                {
                    NhanSu_Process.ThuocPhauThuat tempTT = NhanSu_Process.ThuocPhauThuat.Insert_Object(idCaPhauThuat, idthuoc, soluong, cachdung, "1");
                    if (tempTT != null)
                    {
                        Response.Clear(); Response.Write(tempTT.idThuocPhauThuat);
                        return;
                    }
                }
            }
            else
            {
                Response.Clear(); Response.Write("");

            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }

    private void LuuTableLoaithuocKho2()
    {
        try
        {
            if (Request.QueryString["tenthuoc"].ToString() != "")
            {
                string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                char[] splitter = { '/' };
                string idCaPhauThuat = "";
                if (Request.QueryString["idCaPhauThuat"] != null)
                {
                    idCaPhauThuat = Request.QueryString["idCaPhauThuat"].ToString();
                }
                string idthuoc = "";
                if (Request.QueryString["tenthuoc"] != null)
                {
                    DataTable tableThuoc = DataAcess.Connect.GetTable("select top 1 * from thuoc where tenthuoc = N'" + Request.QueryString["tenthuoc"].ToString() + "'");
                    if (tableThuoc.Rows.Count > 0)
                    {
                        idthuoc = tableThuoc.Rows[0]["idthuoc"].ToString();
                    }
                    else
                    {
                        Response.Clear(); Response.Write("");
                        return;
                    }

                } string soluong = "";
                if (Request.QueryString["soluong"] != null)
                {
                    soluong = Request.QueryString["soluong"].ToString();
                }

                string cachdung = "";
                if (Request.QueryString["cachdung"] != null)
                {
                    cachdung = Request.QueryString["cachdung"].ToString();
                } if (!idkhoachinh.Trim().Equals(""))
                {
                    NhanSu_Process.ThuocPhauThuat temp = NhanSu_Process.ThuocPhauThuat.Create_ThuocPhauThuat(idkhoachinh);
                    bool ok = temp.Save_Object(idCaPhauThuat, idthuoc, soluong, cachdung, "2");
                    if (ok)
                    {
                        Response.Clear(); Response.Write(idkhoachinh);
                        return;
                    }
                }
                else
                {
                    NhanSu_Process.ThuocPhauThuat tempTT = NhanSu_Process.ThuocPhauThuat.Insert_Object(idCaPhauThuat, idthuoc, soluong, cachdung, "2");
                    if (tempTT != null)
                    {
                        Response.Clear(); Response.Write(tempTT.idThuocPhauThuat);
                        return;
                    }
                }
            }
            else
            {
                Response.Clear(); Response.Write("");

            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }

    private void loadTableCLS()
    {
        string sql = "";
        sql += Request.QueryString["idkhoachinh"].ToString();
        DataTable table = NhanSu_Process.CLSPhauThuat.GetTable("select * from CLSPhauThuat a left join ChiTietCLSGoiPhauThuat b on b.idchitietCLSPhauThuat = a.idchitietCLSPhauThuat left join banggiadichvu c on c.idbanggiadichvu = b.idcanlamsang where a.idcaphauthuat=' " + sql + "'");
        DataTable tableloaiphauthuat = NhanSu_Process.LoaiPhauThuat.GetTable("select * from loaiphauthuat ");

        string html = "";
        html += "<table id=\"gridCLS\" align=\"center\" width=\"100%\" bgcolor=\"white\" >";
        html += "<tr style='background-color:#4473ca;height:30px'>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>STT</td>";
        html += "<td></td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maphauthuat") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenphauthuat") + "</td>";
        html += "<td style='border:1px solid #d0d0d0;color:white;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("loaiphauthuat") + "</td>";

        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                    html += "<td style='width:30px' align='center'>" + (i + 1) + "</td>";
                    html += "<td style='width:30px'><a onclick='if(flagtable){tablegrid=\"gridCLS\";};xoaontableCLS(this.name,this)' name='" + table.Rows[i]["idCLSPhauThuat"].ToString() + "'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                    html += "<td style='width:100px'><input id='macls_1' disabled='true' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridCLS\";};chuyenform(this);' onkeydown='chuyendong(this);' value='" + table.Rows[i]["madichvu"].ToString() + "'/></td>";
                    html += "<td style='width:500px'><input id='tencls_1' disabled='true' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridCLS\";};chuyenform(this);timkiemCLS(this);' onkeydown='chuyendong(this);' value='" + table.Rows[i]["tendichvu"].ToString() + "'/></td>";
                    html += "<td><select id='loaiphauthuat_1' disabled='true' onfocus='if(flagtable){tablegrid=\"gridCLS\";}' style='width:90%'/>";
                    for (int ii = 0; ii < tableloaiphauthuat.Rows.Count; ii++)
                    {
                        if (table.Rows[i]["idloaiphauthuat"].ToString() == tableloaiphauthuat.Rows[ii][0].ToString())
                        {
                            html += "<option selected value='" + tableloaiphauthuat.Rows[ii][0] + "'>" + tableloaiphauthuat.Rows[ii][1] + "</option>";
                        }
                        else
                        {
                            html += "<option value='" + tableloaiphauthuat.Rows[ii][0] + "'>" + tableloaiphauthuat.Rows[ii][1] + "</option>";
                        }
                    }
                    html += "</select></td>";
                    html += "<td><input type='hidden' value='" + table.Rows[i]["idCLSPhauThuat"] + "'/></td>";
                    html += "</tr>";

                }
            }
            else
            {
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td style='width:30px' align='center'>1</td>";
                html += "<td style='width:30px'><a onclick='if(flagtable){tablegrid=\"gridCLS\";};xoaontableCLS(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td style='width:100px'><input id='macls_1' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridCLS\";};chuyenform(this);' onkeydown='chuyendong(this);' value=''/></td>";
                html += "<td style='width:500px'><input id='tencls_1' style='width:98%' type='text' onfocusout='chuyenformout(this);flagchuyendong = false;' onfocus='if(flagtable){tablegrid=\"gridCLS\";};chuyenform(this);timkiemCLS(this);' onkeydown='chuyendong(this);' value=''/></td>";
                html += "<td><select id='loaiphauthuat_1' onfocus='if(flagtable){tablegrid=\"gridCLS\";}' style='width:90%'/>";
                for (int ii = 0; ii < tableloaiphauthuat.Rows.Count; ii++)
                {

                    html += "<option value='" + tableloaiphauthuat.Rows[ii][0] + "'>" + tableloaiphauthuat.Rows[ii][1] + "</option>";

                }
                html += "</select></td>";
                html += "<td><input type='hidden' value=''/></td>";
                html += "</tr>";
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }

    private void LuuTableCLS()
    {
        try
        {
            if (Request.QueryString["tencls"].ToString() != "")
            {
                string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                char[] splitter = { '/' };
                string idCaPhauThuat = "";
                if (Request.QueryString["idCaPhauThuat"] != null)
                {
                    idCaPhauThuat = Request.QueryString["idCaPhauThuat"].ToString();
                }
                string idbanggiadichvu = "";

                if (Request.QueryString["tencls"] != null)
                {
                    DataTable tableCLS = DataAcess.Connect.GetTable("select top 1 * from ChiTietCLSGoiPhauThuat a left join banggiadichvu b on a.idcanlamsang = b.idbanggiadichvu where tendichvu = N'" + Request.QueryString["tencls"].ToString() + "'");
                    if (tableCLS.Rows.Count > 0)
                    {
                        idbanggiadichvu = tableCLS.Rows[0]["idchitietCLSPhauThuat"].ToString();
                        if (Request.QueryString["idLoaiPhauThuat"] != null && Request.QueryString["idLoaiPhauThuat"].ToString() != "")
                        {
                            string sql = "UPDATE dbo.ChiTietCLSGoiPhauThuat SET idloaiphauthuat=" + Request.QueryString["idLoaiPhauThuat"].ToString() + " WHERE idchitietCLSPhauThuat=" + idbanggiadichvu;
                            DataAcess.Connect.ExecSQL(sql);
                        }

                    }
                    else
                    {
                        Response.Clear(); Response.Write("");
                        return;
                    }

                }

                if (!idkhoachinh.Trim().Equals(""))
                {
                    NhanSu_Process.CLSPhauThuat temp = NhanSu_Process.CLSPhauThuat.Create_CLSPhauThuat(idkhoachinh);
                    bool ok = temp.Save_Object(idbanggiadichvu, idCaPhauThuat);
                    if (ok)
                    {
                        Response.Clear(); Response.Write(idkhoachinh);
                        return;
                    }
                }
                else
                {
                    NhanSu_Process.CLSPhauThuat tempTT = NhanSu_Process.CLSPhauThuat.Insert_Object(idbanggiadichvu, idCaPhauThuat);
                    if (tempTT != null)
                    {
                        Response.Clear(); Response.Write(tempTT.idCLSPhauThuat);
                        return;
                    }
                }
            }
            else
            {
                Response.Clear(); Response.Write("");

            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }
}


