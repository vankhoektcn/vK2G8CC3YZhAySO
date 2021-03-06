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

public partial class BangChamCongTheoNgay_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable(); break;
            case "luuTable2": LuuTable2(); break;
            case "xoa": XoaBangChamCongTheoNgay(); break;
            case "droplist_idNhanVien": LoadDropList_idNhanVien(); break;
            case "getnhanvien": GetNhanVien(); break;
            case "xoagiolamthem": XoaLamThemGio(); break;
        }
    }

    private void XoaLamThemGio()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete lamthemgio where idlamthemgio=" + idkhoachinh;
            bool ok = NhanSu_Process.LamThemGio.ExecSQL(sql);
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

    private void GetNhanVien()
    {
        string NgayCong = "";
        if (Request.QueryString["ngaythang"].ToString() != "")
        {
            string[] ngaythangcurent1 = Request.QueryString["ngaythang"].ToString().Split('/');
            NgayCong = ngaythangcurent1[1] + "/" + ngaythangcurent1[0] + "/" + ngaythangcurent1[2];
        }
        DataTable table = NhanSu_Process.NhanVien.GetTable("select top 10 nv.idnhanvien,tennhanvien,ngaythuong,ngaytruc,phepkhongluong,phepcoluong,lamthemnuangay,lamthemmotngay,nghiom,vokyluat,nghibu,nghile,idChamCongTheoNgay,idcatruc  from  nhanvien nv left join BangChamCongTheoNgay cc on nv.idnhanvien = cc.idnhanvien and ngaycong >= '" + NgayCong + "' and ngaycong <= '" + NgayCong + "' where nv.status=1 and tennhanvien like N'%" + Request.QueryString["q"] + "%'");
        string html = "";

        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {
                    string html2 = "";
                    string htmldanhmuclamviec = "";
                    DataTable table2 = DataAcess.Connect.GetTable("select ROW_NUMBER() OVER (ORDER BY idlamthemgio) AS STT,* from lamthemgio where idnhanvien = '" + table.Rows[y][0].ToString() + "' and ngaylamthem >= '" + NgayCong + "' and ngaylamthem <= '" + NgayCong + "'");
                    DataTable tabledanhmuclamviec = DataAcess.Connect.GetTable("select * from catruc");
                    htmldanhmuclamviec += "<select style='width:80px'>";
                    htmldanhmuclamviec += "<option selected value='' style='width:90px'>-- Chọn --</option>";
                    if (tabledanhmuclamviec.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < tabledanhmuclamviec.Rows.Count; ii++)
                        {
                            if (table.Rows[y]["idcatruc"].ToString() == tabledanhmuclamviec.Rows[ii][0].ToString())
                            {
                                htmldanhmuclamviec += "<option selected value='" + tabledanhmuclamviec.Rows[ii][0] + "'>" + tabledanhmuclamviec.Rows[ii][1] + "</option>";
                            }
                            else
                            {
                                htmldanhmuclamviec += "<option value='" + tabledanhmuclamviec.Rows[ii][0] + "'>" + tabledanhmuclamviec.Rows[ii][1] + "</option>";
                            }
                        }
                    }
                    htmldanhmuclamviec += "</select>";
                    DataTable tablengaynghi = DataAcess.Connect.GetTable("select * from loainghiphep");
                    string htmlnghikhongluong = "";
                    htmlnghikhongluong += "<select style='width:80px'>";
                    htmlnghikhongluong += "<option selected value='' style='width:90px'>-- Chọn --</option>";
                    if (tablengaynghi.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < tablengaynghi.Rows.Count; ii++)
                        {
                            if (table.Rows[y]["phepkhongluong"].ToString() == tablengaynghi.Rows[ii][0].ToString())
                            {
                                htmlnghikhongluong += "<option selected value='" + tablengaynghi.Rows[ii][0] + "'>" + tablengaynghi.Rows[ii][1] + "</option>";
                            }
                            else
                            {
                                htmlnghikhongluong += "<option value='" + tablengaynghi.Rows[ii][0] + "'>" + tablengaynghi.Rows[ii][1] + "</option>";
                            }
                        }
                    }
                    htmlnghikhongluong += "</select>";
                    string htmlnghicoluong = "";
                    htmlnghicoluong += "<select style='width:80px'>";
                    htmlnghicoluong += "<option selected value='' style='width:90px'>-- Chọn --</option>";
                    if (tablengaynghi.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < tablengaynghi.Rows.Count; ii++)
                        {
                            if (table.Rows[y]["phepcoluong"].ToString() == tablengaynghi.Rows[ii][0].ToString())
                            {
                                htmlnghicoluong += "<option selected value='" + tablengaynghi.Rows[ii][0] + "'>" + tablengaynghi.Rows[ii][1] + "</option>";
                            }
                            else
                            {
                                htmlnghicoluong += "<option value='" + tablengaynghi.Rows[ii][0] + "'>" + tablengaynghi.Rows[ii][1] + "</option>";
                            }
                        }
                    }
                    htmlnghicoluong += "</select>";
                    if (table2.Rows.Count > 0)
                    {
                        html2 += "<input name=\"ctl00$body$gridTable$ctl08$displaygio\" type=\"button\" id=\"ctl00_body_gridTable_ctl08_displaygio\" value=\"...\" onclick=\"displaylamthemgio2(this);\" style=\"background-color:blue;\" />"
                              + "<div style=\"display:none;position:absolute;margin-left:-100px;margin-top:20px\">"
                              + "<div>"
                              + "<table cellspacing=\"0\" cellpadding=\"4\" rules=\"all\" border=\"1\" id=\"bacsyhiep_" + Request.QueryString["sodong"].ToString() + "\" style=\"background-color:White;border-color:#CC9966;border-width:1px;border-style:None;width:200px;border-collapse:collapse;\">"
                              + "<tr style=\"color:#FFFFCC;background-color:#990000;font-weight:bold;\">"
                              + "<th scope=\"col\">stt</th><th scope=\"col\">&nbsp;</th><th scope=\"col\">GioLamThem</th></tr>";
                        for (int i = 0; i < table2.Rows.Count; i++)
                        {
                            html2 += "<tr style=\"color:#330099;background-color:White;\">"
                               + "<td>" + (y + 1) + ""
                               + "</td><td>"
                               + "<a onkeydown=\"chuyendong(this);\" style='text-decoration: none; cursor: pointer;"
                               + "margin-right: 10px; color: green;' onclick=\"xoaontable2(this.name,this);\" name=\"" + table2.Rows[i]["idlamthemgio"].ToString() + "\">"
                               + "Xóa"
                               + "</a>"
                               + "</td><td style=\"width:250px;\">"
                               + "<input type=\"text\" onkeydown=\"chuyendong2(this);\" style=\"width: 50px; border: none\" onblur=\"checkTimes(this);\" title=\"Startime\" value='" + table2.Rows[i]["giobatdau"].ToString() + "' />"
                               + "<input type=\"text\" onkeydown=\"chuyendong2(this);\" style=\"width: 50px; border: none\" onblur=\"checkTimes(this);\" title=\"Endtime\" value='" + table2.Rows[i]["gioketthuc"].ToString() + "'/>"
                               + "</td>"
                               + "</tr>";

                        }
                    }
                    else
                    {
                        html2 += "<input name=\"ctl00$body$gridTable$ctl08$displaygio\" type=\"button\" id=\"ctl00_body_gridTable_ctl08_displaygio\" value=\"...\" onclick=\"displaylamthemgio2(this);\" style=\"background-color:red;\" />"
                              + "<div style=\"display:none;position:absolute;margin-left:-100px;margin-top:20px\">"
                              + "<div>"
                              + "<table cellspacing=\"0\" cellpadding=\"4\" rules=\"all\" border=\"1\" id=\"bacsyhiep_" + Request.QueryString["sodong"].ToString() + "\" style=\"background-color:White;border-color:#CC9966;border-width:1px;border-style:None;width:200px;border-collapse:collapse;\">"
                              + "<tr style=\"color:#FFFFCC;background-color:#990000;font-weight:bold;\">"
                              + "<th scope=\"col\">stt</th><th scope=\"col\">&nbsp;</th><th scope=\"col\">GioLamThem</th></tr>";
                        html2 += "<tr style=\"color:#330099;background-color:White;\">"
                              + "<td>1"
                              + "</td><td>"
                              + "<a onkeydown=\"chuyendong(this);\" style='text-decoration: none; cursor: pointer;"
                              + "margin-right: 10px; color: green;' onclick=\"xoaontable2(this.name,this);\" name=\"\">"
                              + "Xóa"
                              + "</a>"
                              + "</td><td style=\"width:250px;\">"
                              + "<input type=\"text\" onkeydown=\"chuyendong2(this);\" style=\"width: 50px; border: none\" onblur=\"checkTimes(this);\" title=\"Startime\"  />"
                              + "<input type=\"text\" onkeydown=\"chuyendong2(this);\" style=\"width: 50px; border: none\" onblur=\"checkTimes(this);\" title=\"Endtime\" />"
                              + "</td>"
                              + "</tr>";

                    }
                    html2 += "<tr style=\"color:#330099;background-color:#FFFFCC;\">"
                              + "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>"
                              + "</tr>"
                    + "</table>"
                   + "</div>"
                   + "</div>"
                    + "<tr style=\"color:#330099;background-color:#FFFFCC;\">"
                    + "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>"
                    + "</tr>"
                    + "</table>"
                    + "</div>"
                    + "</div>";
                    html += table.Rows[y][0].ToString() + "|" + table.Rows[y]["tennhanvien"].ToString() + "|" + table.Rows[y]["ngaythuong"].ToString().ToLower() + "|" + table.Rows[y]["ngaytruc"].ToString().ToLower() + "|" + htmlnghikhongluong + "|" + htmlnghicoluong + "|" + table.Rows[y]["lamthemnuangay"].ToString().ToLower() + "|" + table.Rows[y]["lamthemmotngay"].ToString().ToLower() + "|" + table.Rows[y]["nghiom"].ToString().ToLower() + "|" + table.Rows[y]["vokyluat"].ToString().ToLower() + "|" + table.Rows[y]["nghibu"].ToString().ToLower() + "|" + table.Rows[y]["nghile"].ToString().ToLower() + "|" + html2 + "|" + table.Rows[y]["idChamCongTheoNgay"].ToString().ToLower() + "|" + htmldanhmuclamviec + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    // luon luon chi co 2 truong la id va value
    private void LoadDropList_idNhanVien()
    {
        DataTable table = NhanSu_Process.NhanVien.GetTable("select * from NhanVien ");
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {

                    html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y]["tennhanvien"].ToString();

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaBangChamCongTheoNgay()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sql = "delete BangChamCongTheoNgay where idChamCongTheoNgay=" + idkhoachinh;
            bool ok = NhanSu_Process.BangChamCongTheoNgay.ExecSQL(sql);
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

    public void LuuTable()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            char[] splitter = { '/' };
            string NgayCong = "";
            if (Request.QueryString["NgayCong"].ToString() != "")
            {
                string[] ngaythangcurent1 = Request.QueryString["NgayCong"].ToString().Split(splitter);
                NgayCong = ngaythangcurent1[1] + "/" + ngaythangcurent1[0] + "/" + ngaythangcurent1[2];
            } string idNhanVien = Request.QueryString["idNhanVien"].ToString();
            string NgayThuong = Request.QueryString["NgayThuong"].ToString();
            string idcatruc = Request.QueryString["NgayTruc"].ToString();
            string ngaytruc = "false";
            if (idcatruc != "")
            {
                ngaytruc = "true";
            }
            string PhepKhongLuong = Request.QueryString["PhepKhongLuong"].ToString();
            string PhepCoLuong = Request.QueryString["PhepCoLuong"].ToString();
            string LamThemNuaNgay = Request.QueryString["LamThemNuaNgay"].ToString();
            string LamThemMotNgay = Request.QueryString["LamThemMotNgay"].ToString();
            string NghiOm = Request.QueryString["NghiOm"].ToString();
            string VoKyLuat = Request.QueryString["VoKyLuat"].ToString();
            string NghiBu = Request.QueryString["NghiBu"].ToString();
            string NghiLe = Request.QueryString["NghiLe"].ToString();
            string idNguoiDung = SysParameter.UserLogin.UserID(this);
            LuuGioLamThem(idNhanVien, NgayCong);
            if (!idkhoachinh.Trim().Equals(""))
            {
                NhanSu_Process.BangChamCongTheoNgay temp = NhanSu_Process.BangChamCongTheoNgay.Create_BangChamCongTheoNgay(idkhoachinh);
                bool ok = temp.Save_Object(temp.idChamCongTheoNgay, NgayCong, idNhanVien, NgayThuong, ngaytruc, PhepKhongLuong, PhepCoLuong, LamThemNuaNgay, LamThemMotNgay, NghiOm, VoKyLuat, NghiBu, NghiLe, idNguoiDung, idcatruc);
                if (ok)
                {
                    Response.Clear(); Response.Write(idkhoachinh);
                    return;
                }
            }
            else
            {
                NhanSu_Process.BangChamCongTheoNgay tempTT = NhanSu_Process.BangChamCongTheoNgay.Insert_Object(DataAcess.Connect.GetTable("SELECT TOP 1  a from (SELECT TOP 1 idChamCongTheoNgay+1 as a FROM BangChamCongTheoNgay ORDER BY idChamCongTheoNgay DESC union select 1 as a)as a order by a desc").Rows[0][0].ToString(), NgayCong, idNhanVien, NgayThuong, ngaytruc, PhepKhongLuong, PhepCoLuong, LamThemNuaNgay, LamThemMotNgay, NghiOm, VoKyLuat, NghiBu, NghiLe, idNguoiDung, idcatruc);
                if (tempTT != null)
                {
                    Response.Clear(); Response.Write(tempTT.idChamCongTheoNgay);
                    return;
                }
            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }

    private void LuuGioLamThem(string idnhanvien, string ngaylamthem)
    {
        string[] Giolamthem = Request.QueryString["Giolamthem"].ToString().Split('@');
        for (int i = 0; i < Giolamthem.Length - 1; i++)
        {
            string idkhoachinh = Giolamthem[i].Split('|')[2];
            string tugio = Giolamthem[i].Split('|')[0];
            string dengio = Giolamthem[i].Split('|')[1];
            if (tugio != "" || dengio != "")
            {
                DateTime dTuGio = new DateTime(2011, 09, 01, int.Parse(tugio.Split(':')[0]), int.Parse(tugio.Split(':')[1]), 0);
                DateTime dDenGio = new DateTime(2011, 09, 01, int.Parse(dengio.Split(':')[0]), int.Parse(dengio.Split(':')[1]), 0);
                TimeSpan KC = (TimeSpan)(dDenGio - dTuGio);
                double dSoGio = KC.TotalHours;

                if (!idkhoachinh.Trim().Equals(""))
                {
                    NhanSu_Process.LamThemGio temp = NhanSu_Process.LamThemGio.Create_LamThemGio(idkhoachinh);
                    bool ok = temp.Save_Object(idkhoachinh, idnhanvien, ngaylamthem, tugio, dengio, "", temp.status, dSoGio.ToString());
                }
                else
                {

                    NhanSu_Process.LamThemGio tempTT = NhanSu_Process.LamThemGio.Insert_Object(DataAcess.Connect.GetTable("SELECT TOP 1  a from (SELECT TOP 1 idlamthemgio+1 as a FROM lamthemgio ORDER BY idlamthemgio DESC union select 1 as a)as a order by a desc").Rows[0][0].ToString(), idnhanvien, ngaylamthem, tugio, dengio, "", "1", dSoGio.ToString());

                }
            }
        }
    }

    public void LuuTable2()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            char[] splitter = { '/' };
            string NgayCong = "";
            if (Request.QueryString["NgayCong"].ToString() != "")
            {
                string[] ngaythangcurent1 = Request.QueryString["NgayCong"].ToString().Split(splitter);
                NgayCong = ngaythangcurent1[1] + "/" + ngaythangcurent1[0] + "/" + ngaythangcurent1[2];
            } string idNhanVien = Request.QueryString["idNhanVien"].ToString();
            string NgayThuong = Request.QueryString["NgayThuong"].ToString();
            string idcatruc = Request.QueryString["NgayTruc"].ToString();
            string ngaytruc = "false";
            if (idcatruc != "")
            {
                ngaytruc = "true";
            }
            string PhepKhongLuong = Request.QueryString["PhepKhongLuong"].ToString();
            string PhepCoLuong = Request.QueryString["PhepCoLuong"].ToString();
            string LamThemNuaNgay = Request.QueryString["LamThemNuaNgay"].ToString();
            string LamThemMotNgay = Request.QueryString["LamThemMotNgay"].ToString();
            string NghiOm = Request.QueryString["NghiOm"].ToString();
            string VoKyLuat = Request.QueryString["VoKyLuat"].ToString();
            string NghiBu = Request.QueryString["NghiBu"].ToString();
            string NghiLe = Request.QueryString["NghiLe"].ToString();
            string idNguoiDung = SysParameter.UserLogin.UserID(this);
            LuuGioLamThem2(idNhanVien, NgayCong);
            DataTable tableluubangchamcong = DataAcess.Connect.GetTable("select top 1 * from bangchamcongtheongay where idnhanvien='" + idNhanVien + "' and ngaycong >= '" + NgayCong + "' and ngaycong <= '" + NgayCong + "'");
            if (tableluubangchamcong.Rows.Count > 0)
            {
                NhanSu_Process.BangChamCongTheoNgay temp = NhanSu_Process.BangChamCongTheoNgay.Create_BangChamCongTheoNgay(tableluubangchamcong.Rows[0]["idchamcongtheongay"].ToString());
                bool ok = temp.Save_Object(temp.idChamCongTheoNgay, NgayCong, idNhanVien, NgayThuong, ngaytruc, PhepKhongLuong, PhepCoLuong, LamThemNuaNgay, LamThemMotNgay, NghiOm, VoKyLuat, NghiBu, NghiLe, idNguoiDung, idcatruc);
                if (ok)
                {
                    Response.Clear(); Response.Write(idkhoachinh);
                    return;
                }
            }
            else
            {
                NhanSu_Process.BangChamCongTheoNgay tempTT = NhanSu_Process.BangChamCongTheoNgay.Insert_Object(DataAcess.Connect.GetTable("SELECT TOP 1  a from (SELECT TOP 1 idChamCongTheoNgay+1 as a FROM BangChamCongTheoNgay ORDER BY idChamCongTheoNgay DESC union select 1 as a)as a order by a desc").Rows[0][0].ToString(), NgayCong, idNhanVien, NgayThuong, ngaytruc, PhepKhongLuong, PhepCoLuong, LamThemNuaNgay, LamThemMotNgay, NghiOm, VoKyLuat, NghiBu, NghiLe, idNguoiDung, idcatruc);
                if (tempTT != null)
                {
                    Response.Clear(); Response.Write(tempTT.idChamCongTheoNgay);
                    return;
                }
            }
        }
        catch (Exception) { }
        Response.Clear(); Response.Write("");
    }

    private void LuuGioLamThem2(string idnhanvien, string ngaylamthem)
    {
        string[] Giolamthem = Request.QueryString["Giolamthem"].ToString().Split('@');
        for (int i = 0; i < Giolamthem.Length - 1; i++)
        {
            string idkhoachinh = Giolamthem[i].Split('|')[2];
            string tugio = Giolamthem[i].Split('|')[0];
            string dengio = Giolamthem[i].Split('|')[1];
            if (tugio != "" || dengio != "")
            {
                DateTime dTuGio = new DateTime(2011, 09, 01, int.Parse(tugio.Split(':')[0]), int.Parse(tugio.Split(':')[1]), 0);
                DateTime dDenGio = new DateTime(2011, 09, 01, int.Parse(dengio.Split(':')[0]), int.Parse(dengio.Split(':')[1]), 0);
                TimeSpan KC = (TimeSpan)(dDenGio - dTuGio);
                double dSoGio = KC.TotalHours;

                if (!idkhoachinh.Trim().Equals(""))
                {
                    NhanSu_Process.LamThemGio temp = NhanSu_Process.LamThemGio.Create_LamThemGio(idkhoachinh);
                    bool ok = temp.Save_Object(idkhoachinh, idnhanvien, ngaylamthem, tugio, dengio, "", temp.status, dSoGio.ToString());
                }
                else
                {

                    NhanSu_Process.LamThemGio tempTT = NhanSu_Process.LamThemGio.Insert_Object(DataAcess.Connect.GetTable("SELECT TOP 1  a from (SELECT TOP 1 idlamthemgio+1 as a FROM lamthemgio ORDER BY idlamthemgio DESC union select 1 as a)as a order by a desc").Rows[0][0].ToString(), idnhanvien, ngaylamthem, tugio, dengio, "", "1", dSoGio.ToString());

                }
            }
        }
    }
}


