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

public partial class nvk_KhamThuongQuyDienBien_ajax : System.Web.UI.Page
{
    protected DataProcess nvk_congBacSiKhambenh()
    {
        DataProcess nvk_congBacSiKhambenh = new DataProcess("nvk_congBacSiKhambenh");
        nvk_congBacSiKhambenh.data("idBacSiKhamBenh", Request.QueryString["idBacSiKhamBenh"]);
        nvk_congBacSiKhambenh.data("idbacsi", Request.QueryString["idbacsi"]);
        nvk_congBacSiKhambenh.data("ngaykham", Request.QueryString["ngaykham"]);
        nvk_congBacSiKhambenh.data("KhamThuongQuy", Request.QueryString["KhamThuongQuy"]);
        nvk_congBacSiKhambenh.data("GhiChu", Request.QueryString["GhiChu"]);
        nvk_congBacSiKhambenh.data("IdNguoiDung", SysParameter.UserLogin.UserID(this));
        nvk_congBacSiKhambenh.data("IdKhoaCham", Request.QueryString["IdKhoa"]);
        return nvk_congBacSiKhambenh;
    }
    protected DataProcess nvk_congBacSiKhambenhDienBien()
    {
        DataProcess nvk_congBacSiKhambenhDienBien = new DataProcess("nvk_congBacSiKhambenhDienBien");
        nvk_congBacSiKhambenhDienBien.data("idKhamDienBien", Request.QueryString["idKhamDienBien"]);
        nvk_congBacSiKhambenhDienBien.data("idBacSiKhamBenh", Request.QueryString["idBacSiKhamBenh"]);
        nvk_congBacSiKhambenhDienBien.data("idbenhnhanDB", Request.QueryString["idbenhnhanDB"]);
        nvk_congBacSiKhambenhDienBien.data("GhiChu", Request.QueryString["GhiChu"]);
        return nvk_congBacSiKhambenhDienBien;
    }
    protected DataProcess nvk_congBacSiKhambenhKhac()
    {
        DataProcess nvk_congBacSiKhambenhKhac = new DataProcess("nvk_congBacSiKhambenhKhac");
        nvk_congBacSiKhambenhKhac.data("idKhamDvKhac", Request.QueryString["idKhamDvKhac"]);
        nvk_congBacSiKhambenhKhac.data("idBacSiKhamBenh", Request.QueryString["idBacSiKhamBenh"]);
        nvk_congBacSiKhambenhKhac.data("idbenhnhanKhac", Request.QueryString["idbenhnhanKhac"]);
        nvk_congBacSiKhambenhKhac.data("idDvKham", Request.QueryString["idDvKham"]);
        nvk_congBacSiKhambenhKhac.data("GhiChu", Request.QueryString["GhiChu"]);
        return nvk_congBacSiKhambenhKhac;
    }
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

            //nvk case
            case "TimKiemBacSiKhamBenh": nvk_TimKiemBacSiKhamBenh(); break;

            case "getBacSiKhamBenh": nvk_getBacSiKhamBenh(); break;
            case "LuuTableBacSiKhamBenh": nvk_LuuTableBacSiKhamBenh(); break;

            case "getBenhNhanDienBien": nvk_getBenhNhanDienBien(); break;
            case "getDichVuKhac": nvk_getDichVuKhac(); break;

            case "xoaCongKhamBacSi": nvk_xoaCongKhamBacSi(); break;
            case "xoaKhamDienBien": nvk_xoaKhamDienBien(); break;
            case "xoaKhamDichVuKhac": nvk_xoaKhamDichVuKhac(); break;
        }
    }
    #region tìm kiếm nội dung công khám
    private void nvk_TimKiemBacSiKhamBenh()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string NgayCong = Request.QueryString["NgayCong"];
        string phongBan = Request.QueryString["phongBan"];
        string LoaiBacSi = Request.QueryString["LoaiBacSi"];
        string TenBacSi = Request.QueryString["TenBacSi"];
        string IdKhoa = Request.QueryString["IdKhoa"];
        string dkSql="";
        if (!LoaiBacSi.Equals("-1"))
            dkSql += " and isnull(bs.IsBSNgoaiVien,0)='" + LoaiBacSi + "'";
        if(!phongBan.Equals("0"))
            dkSql += " and bs.idphongkhambenh='"+phongBan+"'";
        if(!string.IsNullOrEmpty(TenBacSi))
            dkSql += " and bs.tenbacsi like N'%"+TenBacSi+"%'";
        string sqlCongKham = @"select bs.idbacsi,tenbacsi,ck.idBacSiKhamBenh,KhamThuongQuy=isnull(convert(int,ck.KhamThuongQuy),0),ck.GhiChu from
bacsi bs left join nvk_congBacSiKhambenh ck on bs.idbacsi =ck.idbacsi and convert(varchar(10),ngaykham,103)='" + NgayCong + @"' and IdKhoaCham='"+IdKhoa+@"'
where 1=1 " + dkSql + "";
        DataTable dtCongKham = DataAcess.Connect.GetTable(sqlCongKham);
        html.Append(@"
            <table class='jtable' id='tableBacSiKhamBenh' cellspacing='0' cellpadding='4' rules='all' style='background-color: #990000;
                border-color: #CC9966; border-width: 1px; border-style: None; width: 100%; border-collapse: collapse;'>
                <tr style='background-color: #4473ca; font-weight: bold; color: #CCCCFF'>
                    <th></th>
                    <th>Xóa</th>
                    <th>Bác Sĩ</th>
                    <th>Khám thường quy</th>
                    <th>Khám diễn biến</th>
                    <th>Khám dịch vụ khác</th>
                    <th></th>
                </tr>");
        int i = 0;
        #region chi tiết chấm công khám
        if (dtCongKham != null)
        {
            for (; i < dtCongKham.Rows.Count; i++)
            {
                html.Append(@"
                <tr style='color: #003399; background-color: White;'>
                    <td >" + (i + 1) + @"
                    </td>
                    <td >
                        <a onkeydown='chuyendong(this);' style='text-decoration: none; cursor: pointer; margin-right: 10px;
                            color: green;' onclick='xoaontabletableBacSiKhamBenh(this.name,this);' name='" + dtCongKham.Rows[i]["idBacSiKhamBenh"] + @"'>
                            " + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + @"
                        </a>
                    </td>
                    <td >
                        <input name='ctl00$body$gridTable$ctl09$Text1' type='text' id='ctl00_body_gridTable_ctl09_Text1' value='" + dtCongKham.Rows[i]["tenbacsi"] + @"'
                            style='width: 202px' onfocus='nvk_laylaichuyendong(this);' />
                        <input type='hidden' name='ctl00$body$gridTable$ctl09$idnv' id='ctl00_body_gridTable_ctl09_idnv' value='" + dtCongKham.Rows[i]["idbacsi"] + @"' />
                    </td>
                    <td >
                        <input type='checkbox' onkeydown='chuyendong(this);' " + (dtCongKham.Rows[i]["KhamThuongQuy"].ToString().Equals("1") ? "checked" : "") + @" style='width: 15px; border: none' />
                    </td>
                    <td >");
                #region nội dung khám diễn biến
                ///
                string sqlDB = @"
        select idKhamDienBien,idbenhnhanDB,GhiChu,bn.tenbenhnhan from nvk_congBacSiKhambenhDienBien db inner join benhnhan bn on bn.idbenhnhan=db.idbenhnhanDB
        where idBacSiKhamBenh ='" + dtCongKham.Rows[i]["idBacSiKhamBenh"] + "'";
                DataTable tableDB = DataAcess.Connect.GetTable(sqlDB);
                html.Append(strNoiDungKhamDienBien(tableDB, (i + 1)));
                ///
                #endregion
                html.Append(@"
                    </td>
                    <td >");
                #region nội dung khám Dịch Vụ khác
                string sqlDV = @"
    select idKhamDvKhac,idLoaiDvKham,GhiChu,bn.TenLoaiDV from nvk_congBacSiKhambenhKhac dv inner join nvk_LoaiDvBsKham bn on bn.idLoaiDichVuKham=dv.idLoaiDvKham
                        where idBacSiKhamBenh ='" + dtCongKham.Rows[i]["idBacSiKhamBenh"] + "'";
                DataTable tableDV = DataAcess.Connect.GetTable(sqlDV);
                html.Append(strNoiDungKhamDichVu(tableDV, (i + 1)));
                #endregion
                html.Append(@"
                    </td>
                    <td >
                        <input type='hidden' value='" + dtCongKham.Rows[i]["idBacSiKhamBenh"] + @"' />
                    </td>
                </tr>");
            }
        }
        #endregion
        html.Append( @"
                <tr style='color: #003399; background-color: White;'>
                    <td >"+(i+1)+@"
                    </td>
                    <td >
                        <a onkeydown='chuyendong(this);' style='text-decoration: none; cursor: pointer; margin-right: 10px;
                            color: green;' onclick='xoaontabletableBacSiKhamBenh(this.name,this);' name=''>
                            "+hsLibrary.clDictionaryDB.sGetValueLanguage("delete") +@"
                        </a>
                    </td>
                    <td >
                        <input name='ctl00$body$gridTable$ctl09$Text1' type='text' id='ctl00_body_gridTable_ctl09_Text1'
                            style='width: 202px' onfocus='nvk_laylaichuyendong(this);' />
                        <input type='hidden' name='ctl00$body$gridTable$ctl09$idnv' id='ctl00_body_gridTable_ctl09_idnv' />
                    </td>
                    <td >
                        <input type='checkbox' onkeydown='chuyendong(this);' style='width: 15px; border: none' />
                    </td>
                    <td >
                    </td>
                    <td >
                    </td>
                    <td >
                        <input type='hidden' />
                    </td>
                </tr>
            </table>");
        Response.Clear();
        Response.Write(html);
    }
    #endregion
    #region xóa
    // xóa công khám bác sĩ
    private void nvk_xoaCongKhamBacSi()
    {
        try
        {
            string sqlDel = "delete from nvk_congBacSiKhambenh where idBacSiKhamBenh='" + Request.QueryString["idkhoachinh"] + "'";
            bool kt = DataAcess.Connect.ExecSQL(sqlDel);
            sqlDel = "delete from nvk_congBacSiKhambenhDienBien where idBacSiKhamBenh='" + Request.QueryString["idkhoachinh"] + "'";
             kt = DataAcess.Connect.ExecSQL(sqlDel);
            sqlDel = "delete from nvk_congBacSiKhambenhKhac where idBacSiKhamBenh='" + Request.QueryString["idkhoachinh"] + "'";
             kt = DataAcess.Connect.ExecSQL(sqlDel);
            if (kt)
            { Response.Clear(); Response.Write("1"); }
            else
            { Response.Clear(); Response.Write(""); }
        }
        catch (Exception)
        {
            Response.StatusCode = 500;
        }
    }
    // xóa khám diễn biến
    private void nvk_xoaKhamDienBien()
    {
        try
        {
            string sqlDel = "delete from nvk_congBacSiKhambenhDienBien where idKhamDienBien='" + Request.QueryString["idkhoachinh"] + "'";
            bool kt = DataAcess.Connect.ExecSQL(sqlDel);
            if (kt)
            { Response.Clear();Response.Write("1"); }
            else
            { Response.Clear(); Response.Write(""); }
        }
        catch (Exception)
        {
            Response.StatusCode = 500;
        }
    }
    // xóa khám Dịch Vụ khác
    private void nvk_xoaKhamDichVuKhac()
    {
        try
        {
            string sqlDel = "delete from nvk_congBacSiKhambenhKhac where idKhamDvKhac='" + Request.QueryString["idkhoachinh"] + "'";
            bool kt = DataAcess.Connect.ExecSQL(sqlDel);
            if (kt)
            { Response.Clear(); Response.Write("1"); }
            else
            { Response.Clear(); Response.Write(""); }
        }
        catch (Exception)
        {
            Response.StatusCode = 500;
        }
    }
    #endregion
    //nvk function
    #region nvk function
    //search dịch vụ công khám khác
    private void nvk_getDichVuKhac()
    {
        string NgayCong = "";
        if (Request.QueryString["ngaythang"].ToString() != "")
        {
            string[] ngaythangcurent1 = Request.QueryString["ngaythang"].ToString().Split('/');
            NgayCong = ngaythangcurent1[1] + "/" + ngaythangcurent1[0] + "/" + ngaythangcurent1[2];
        }
        string sqlDV = "select idLoaiDichVuKham,MaLoai,TenLoaiDV from nvk_LoaiDvBsKham";
        DataTable table = NhanSu_Process.NhanVien.GetTable(sqlDV);
        string html = "";

        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {
                    html += table.Rows[y]["idLoaiDichVuKham"].ToString() + "|" + table.Rows[y]["TenLoaiDV"].ToString()
                        + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    //search bệnh nhân diễn biến
    private void nvk_getBenhNhanDienBien()
    {
        string NgayCong = "";
        if (Request.QueryString["ngaythang"].ToString() != "")
        {
            string[] ngaythangcurent1 = Request.QueryString["ngaythang"].ToString().Split('/');
            NgayCong = ngaythangcurent1[1] + "/" + ngaythangcurent1[0] + "/" + ngaythangcurent1[2];
        }
        string sql = "select top 10 ROW_NUMBER() OVER (ORDER BY tenbenhnhan) AS STT,idbenhnhan,mabenhnhan,tenbenhnhan,ngaysinh,diachi from  benhnhan where  tenbenhnhan like N'%" + Request.QueryString["q"] + "%'";
        DataTable table = NhanSu_Process.NhanVien.GetTable(sql);
        string html = "";
        html = string.Format("{0}|{1}|{2}|{3}", ""
      + "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:510px;height:30px;padding-right:25px\">"
      + "<div style=\"width:30px;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
      + "<div style=\"width:100px;height:30px;color:#000;font-weight:bold;float:left\" >Mã BN</div>"
      + "<div style=\"width:150px;height:30px;color:#000;font-weight:bold;float:left\" >Tên Bệnh Nhân</div>"
      + "<div style=\"width:80px;height:30px;color:#000;font-weight:bold;float:left\" >Năm sinh</div>"
      + "<div style=\"width:150px;height:30px;color:#000;font-weight:bold;float:left\" >Địa chỉ</div>"
      + "</div>", "", "", Environment.NewLine);
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {
                    html += string.Format("{0}|{1}|{2}|{3}", ""
      + "<div style='width:510px'>"
      + "<div style=\"width:30px;height:30px;float:left\" >" + table.Rows[y]["stt"] + "</div>"
      + "<div style=\"width:100px;height:30px;float:left\" >" + table.Rows[y]["mabenhnhan"] + "</div>"
      + "<div style=\"width:150px;height:30px;float:left\" >" + table.Rows[y]["tenbenhnhan"] + "</div>"
      + "<div style=\"width:80px;height:30px;float:left\" >" + table.Rows[y]["ngaysinh"] + "</div>"
      + "<div style=\"width:150px;height:30px;float:left\" >" + table.Rows[y]["diachi"] + "</div>"
      + "</div>", table.Rows[y]["idbenhnhan"].ToString(), table.Rows[y]["tenbenhnhan"].ToString(), Environment.NewLine);
                    //html += table.Rows[y]["idbenhhan"].ToString() + "|" + table.Rows[y]["tenbenhnhan"].ToString()
                    //    + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    // search bác sĩ
    private void nvk_getBacSiKhamBenh()
    {
        string NgayCong = DateTime.Now.ToString("dd/MM/yyyy");
        string IdKhoa = Request.QueryString["IdKhoa"];
        int sodong = StaticData.ParseInt(Request.QueryString["sodong"]);
        if (Request.QueryString["ngaythang"].ToString() != "")
        {
            //string[] ngaythangcurent1 = Request.QueryString["ngaythang"].ToString().Split('/');
            //NgayCong = ngaythangcurent1[1] + "/" + ngaythangcurent1[0] + "/" + ngaythangcurent1[2];
            NgayCong = Request.QueryString["ngaythang"];
        }
        string sqlBS = @"
select bs.idbacsi,bs.tenbacsi,ck.idBacSiKhamBenh,ck.KhamThuongQuy from bacsi bs left join nvk_congBacSiKhambenh ck on ck.idbacsi=bs.idbacsi and  convert(varchar(10),ngaykham,103)='" + NgayCong + @"' and IdKhoaCham ='"+IdKhoa+@"'
where  bs.tenbacsi like N'%" +Request.QueryString["q"]+"%'";
        DataTable table = NhanSu_Process.NhanVien.GetTable(sqlBS);
        string html = "";

        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int y = 0; y < table.Rows.Count; y++)
                {
                    // html2 (table khám diễn biến)
                    #region html2 (table khám diễn biến)
                    string html2 = "";
                    string sqlDB = @"
        select idKhamDienBien,idbenhnhanDB,GhiChu,bn.tenbenhnhan from nvk_congBacSiKhambenhDienBien db inner join benhnhan bn on bn.idbenhnhan=db.idbenhnhanDB
        where idBacSiKhamBenh ='" + table.Rows[y]["idBacSiKhamBenh"] + "'";
                    DataTable tableDB = DataAcess.Connect.GetTable(sqlDB);
                    html2 = strNoiDungKhamDienBien(tableDB,sodong);
                    #endregion
                    #region html3 (table khám dịch vụ khác)
                    string html3 = "";
                    string sqlDV = @"
    select idKhamDvKhac,idLoaiDvKham,GhiChu,bn.TenLoaiDV from nvk_congBacSiKhambenhKhac dv inner join nvk_LoaiDvBsKham bn on bn.idLoaiDichVuKham=dv.idLoaiDvKham
                        where idBacSiKhamBenh = isnull((select top 1 idBacSiKhamBenh from nvk_congBacSiKhambenh where convert(varchar(10),ngaykham,103)='" + NgayCong + "' and idbacsi='" + table.Rows[y]["idbacsi"] + "'),0)";
                    DataTable tableDV = DataAcess.Connect.GetTable(sqlDV);
                    html3 = strNoiDungKhamDichVu(tableDV,sodong);
                    #endregion

                    html += table.Rows[y]["idbacsi"].ToString() + "|" + table.Rows[y]["tenbacsi"].ToString() + "|"
                        + table.Rows[y]["KhamThuongQuy"].ToString().ToLower() //2 (data[2])
                        + "|" + html2//3
                        + "|" + html3 //4
                        + "|" + table.Rows[y]["idBacSiKhamBenh"].ToString().ToLower() //5
                        + Environment.NewLine;
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    // lưu Table Bacsikhambenh
    private void nvk_LuuTableBacSiKhamBenh()
    {
        try
        {
            bool kt = false;
            DataProcess process = nvk_congBacSiKhambenh();
            if (!string.IsNullOrEmpty(process.getData("idBacSiKhamBenh")) && !process.getData("idBacSiKhamBenh").Equals("0"))
            {
                #region cập nhật
                kt = process.Update();
                #endregion
            }
            else
            {
                #region lưu mới
                kt = process.Insert();
                #endregion
            }
            if (kt)
            {
                #region lưu/cập nhật khám diễn biến (nếu có)
                string ListDienBien = Request.QueryString["DienBien"];
                if (!string.IsNullOrEmpty(ListDienBien))
                {
                    string[] arrDienBien = ListDienBien.Split('@');
                    bool ktDelDB = DataAcess.Connect.ExecSQL("delete from nvk_congBacSiKhambenhDienBien where idBacSiKhamBenh='" + process.getData("idBacSiKhamBenh") + "'");
                    for (int i = 0; i < arrDienBien.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(arrDienBien[i]))
                        {
                            string[] arrRowDB = arrDienBien[i].Split('|');
                            if (!string.IsNullOrEmpty(arrRowDB[0]))
                            {
                                DataProcess process_DB = new DataProcess("nvk_congBacSiKhambenhDienBien");
                                process_DB.data("idKhamDienBien", arrRowDB[2]);
                                process_DB.data("idBacSiKhamBenh", process.getData("idBacSiKhamBenh"));
                                process_DB.data("idbenhnhanDB", arrRowDB[0]);
                                process_DB.data("GhiChu", arrRowDB[1]);
                                #region đồ bỏ đi
                                //if (!string.IsNullOrEmpty(process_DB.getData("idKhamDienBien")) && !process_DB.getData("idKhamDienBien").Equals("0"))
                                //{
                                //    process_DB.Update();
                                //}
                                //else
                                //{
                                //    DataTable dtDB = DataAcess.Connect.GetTable("select idKhamDienBien from nvk_congBacSiKhambenhDienBien where idBacSiKhamBenh='" + process_DB.getData("idBacSiKhamBenh") + "' and idbenhnhanDB='" + process_DB.getData("idbenhnhanDB") + "'");
                                //    if (dtDB.Rows.Count > 0)
                                //    {
                                //        process_DB.data("idKhamDienBien", dtDB.Rows[0]["idKhamDienBien"].ToString());
                                //        process_DB.Update();
                                //    }
                                //    else
                                //        process_DB.Insert();
                                //}
                                #endregion
                                process_DB.Insert();

                            }
                        }
                    }
                }
                #endregion
                #region lưu/cập nhật khám dịch vụ khác (nếu có)
                string ListDichVuKhac = Request.QueryString["DichVuKhac"];
                if (!string.IsNullOrEmpty(ListDichVuKhac))
                {
                    string[] arrDichVuKhac = ListDichVuKhac.Split('@');
                    bool delDV = DataAcess.Connect.ExecSQL("delete from nvk_congBacSiKhambenhKhac where idBacSiKhamBenh='" + process.getData("idBacSiKhamBenh") + "'");
                    for (int i = 0; i < arrDichVuKhac.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(arrDichVuKhac[i]))
                        {
                            string[] arrRowDV = arrDichVuKhac[i].Split('|');
                            if (!string.IsNullOrEmpty(arrRowDV[0]))  
                            {
                                DataProcess process_DV = new DataProcess("nvk_congBacSiKhambenhKhac");
                                process_DV.data("idKhamDvKhac", arrRowDV[2]);
                                process_DV.data("idBacSiKhamBenh", process.getData("idBacSiKhamBenh"));
                                process_DV.data("idLoaiDvKham", arrRowDV[0]);
                                process_DV.data("GhiChu", arrRowDV[1]);

                                process_DV.Insert();
                            }
                        }
                    }
                }
                #endregion
                Response.Clear(); Response.Write(process.getData("idBacSiKhamBenh"));
                return;
            }
            else
                Response.Clear(); Response.Write("");
        }
        catch (Exception)
        {
            Response.StatusCode = 500;           
        }
    }
    #endregion
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
        string sqlNV = @"select top 10 nv.idnhanvien,tennhanvien,ngaythuong,ngaytruc,phepkhongluong,phepcoluong,lamthemnuangay,lamthemmotngay,nghiom,vokyluat,nghibu,nghile,idChamCongTheoNgay,idcatruc  from  nhanvien nv left join BangChamCongTheoNgay cc on nv.idnhanvien = cc.idnhanvien and ngaycong >= '" + NgayCong + "' and ngaycong <= '" + NgayCong + "' where nv.status=1 and tennhanvien like N'%" + Request.QueryString["q"] + "%'";
        DataTable table = NhanSu_Process.NhanVien.GetTable(sqlNV);
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
                    html += table.Rows[y][0].ToString() + "|" + table.Rows[y]["tennhanvien"].ToString() + "|"
                        + table.Rows[y]["ngaythuong"].ToString().ToLower() + "|" + table.Rows[y]["ngaytruc"].ToString().ToLower()
                        + "|" + htmlnghikhongluong + "|" + htmlnghicoluong + "|" + table.Rows[y]["lamthemnuangay"].ToString().ToLower()
                        + "|" + table.Rows[y]["lamthemmotngay"].ToString().ToLower() + "|" + table.Rows[y]["nghiom"].ToString().ToLower()
                        + "|" + table.Rows[y]["vokyluat"].ToString().ToLower() + "|" + table.Rows[y]["nghibu"].ToString().ToLower()
                        + "|" + table.Rows[y]["nghile"].ToString().ToLower() + "|"
                        + html2 + "|" + table.Rows[y]["idChamCongTheoNgay"].ToString().ToLower()
                        + "|" + htmldanhmuclamviec + Environment.NewLine;
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
            if (idNhanVien.Equals("23"))
            {
                string val = "không lưu là sao";
            }
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





    // nvk function call
    #region nvk function call
    // nội dung khám diễn biến
    private string strNoiDungKhamDienBien(DataTable table,int sodong)
    {
        string html = "";
        if (table.Rows.Count > 0)
        {
            html += "<input name=\"ctl00$body$gridTable$ctl08$displaygio\" type=\"button\" id=\"ctl00_body_gridTable_ctl08_displaygio\" value=\"...\" onclick=\"nvk_displayBNDienBien(this);\" style=\"background-color:blue;\" />"
                  + "<div style=\"display:none;position:absolute;margin-left:-100px;margin-top:20px\">"
                  + "<div>"
                  + "<table cellspacing=\"0\" cellpadding=\"4\" rules=\"all\" border=\"1\" id='nvkTableDienBien_"+sodong+"' style=\"background-color:White;border-color:#CC9966;border-width:1px;border-style:None;width:300px;border-collapse:collapse;\">"
                  + "<tr style=\"color:#FFFFCC;background-color:#990000;font-weight:bold;\">"
                  + "<th scope=\"col\">stt</th><th scope=\"col\">&nbsp;</th><th scope=\"col\">Bệnh nhân</th><th scope=\"col\">Ghi chú</th></tr>";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr style=\"color:#330099;background-color:White;\">"
                   + "<td>" + (i + 1) + ""
                   + "</td><td>"
                   + "<a onkeydown=\"chuyendong(this);\" style='text-decoration: none; cursor: pointer;"
                   + "margin-right: 10px; color: green;' onclick=\"xoaontableDienBien(this.name,this);\" name=\"" + table.Rows[i]["idKhamDienBien"] + "\">"
                   + "Xóa"
                   + "</a>"
                   + "</td><td style=\"width:150px;\">"
                   + "<input type=\"text\"  onfocus='nvk_searchBNDB(this)' id='txtTenBNDB'  style=\"width: 150px; border:solid 1px Red\" title=\"Bệnh nhân\" value='" + table.Rows[i]["tenbenhnhan"] + "' />"
                   + "<input id='idbnDB' type='hidden' value='" + table.Rows[i]["idbenhnhanDB"] + "' />"
                + "</td><td style=\"width:100px;\">"
                + "<input type=\"text\" onkeydown=\"chuyendong2(this);\" style=\"width: 100px; border:solid 1px Blue\"  title=\"Ghi chú\" value='" + table.Rows[i]["GhiChu"] + "'/>"
                + "</td>"
                + "</tr>";

            }
        }
        else
        {
            #region chưa có khám diễn biến
            html += "<input name=\"ctl00$body$gridTable$ctl08$displaygio\" type=\"button\" id=\"ctl00_body_gridTable_ctl08_displaygio\" value=\"...\" onclick=\"nvk_displayBNDienBien(this);\" style=\"background-color:red;\" />"
                  + "<div style=\"display:none;position:absolute;margin-left:-100px;margin-top:20px\">"
                  + "<div>"
                  + "<table cellspacing=\"0\" cellpadding=\"4\" rules=\"all\" border=\"1\" id='nvkTableDienBien_" + sodong + "' style=\"background-color:White;border-color:#CC9966;border-width:1px;border-style:None;width:300px;border-collapse:collapse;\">"
                  + "<tr style=\"color:#FFFFCC;background-color:#990000;font-weight:bold;\">"
                  + "<th scope=\"col\">stt</th><th scope=\"col\">&nbsp;</th><th scope=\"col\">Bệnh nhân</th><th scope=\"col\">Ghi Chú</th></tr>";
            html += "<tr style=\"color:#330099;background-color:White;\">"
                  + "<td>1"
                  + "</td><td>"
                  + "<a onkeydown=\"chuyendong(this);\" style='text-decoration: none; cursor: pointer;"
                  + "margin-right: 10px; color: green;' onclick=\"xoaontableDienBien(this.name,this);\" name=\"\">"
                  + "Xóa"
                  + "</a>"
                  + "</td><td style=\"width:150px;\">"
                  + "<input type=\"text\" onfocus='nvk_searchBNDB(this)' id='txtTenBNDB' style=\"width: 150px; border:solid 1px Red\" title=\"Benh Nhan\"  />" //  onblur=\"checkTimes(this);\"
                  + "<input id='idbnDB' type='hidden' />"
            + "</td><td style=\"width:100px;\">"
            + "<input type=\"text\" onkeydown=\"chuyendong2(this);\" style=\"width: 100px; border:solid 1px Blue\" title=\"Ghi chú\" />"
            + "</td>"
            + "</tr>";
            #endregion
        }
        html += "<tr style=\"color:#330099;background-color:#FFFFCC;\">"
                  + "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>"
                  + "</tr>"
        + "</table>"
       + "</div>"
       + "</div>";
        return html;
    }
    // nội dung khám dịch vụ
    private string strNoiDungKhamDichVu(DataTable table, int sodong)
    {
        string html = "";
        if (table.Rows.Count > 0)
        {
            html += "<input name=\"ctl00$body$gridTable$ctl08$displayDVKhac\" type=\"button\" id=\"ctl00_body_gridTable_ctl08_displayDVKhac\" value=\"...\" onclick=\"nvk_displayKhamDichVuKhac(this);\" style=\"background-color:Green;\" />"
                  + "<div style=\"display:none;position:absolute;margin-left:-100px;margin-top:20px\">"
                  + "<div>"
                  + "<table cellspacing=\"0\" cellpadding=\"4\" rules=\"all\" border=\"1\" id='nvkTableDichVuKhac_"+sodong+"' style=\"background-color:White;border-color:#CC9966;border-width:1px;border-style:None;width:300px;border-collapse:collapse;\">"
                  + "<tr style=\"color:#FFFFCC;background-color:#990000;font-weight:bold;\">"
                  + "<th scope=\"col\">stt</th><th scope=\"col\">&nbsp;</th><th scope=\"col\">Dịch vụ khám</th><th scope=\"col\">Ghi chú</th></tr>";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr style=\"color:#330099;background-color:White;\">"
                   + "<td>" + (i + 1) + ""
                   + "</td><td>"
                   + "<a onkeydown=\"chuyendong(this);\" style='text-decoration: none; cursor: pointer;"
                   + "margin-right: 10px; color: green;' onclick=\"xoaontableDichVuKhac(this.name,this);\" name=\"" + table.Rows[i]["idKhamDvKhac"] + "\">"
                   + "Xóa"
                   + "</a>"
                   + "</td><td style=\"width:150px;\">"
                   + "<input type=\"text\"  onfocus='nvk_searchDichVuKhac(this)' id='txtTenDichVu'  style=\"width: 150px; border:solid 1px Red\"  title=\"Dịch vụ khám\" value='" + table.Rows[i]["TenLoaiDV"] + "' />"
                   + "<input id='idDVKhac' type='hidden' value='" + table.Rows[i]["idLoaiDvKham"] + "' />"
                + "</td><td style=\"width:100px;\">"
                + "<input type=\"text\" onkeydown=\"chuyendong2(this);\" style=\"width: 100px; border:solid 1px Blue\"  title=\"Ghi chú\" value='" + table.Rows[i]["GhiChu"] + "'/>"
                + "</td>"
                + "</tr>";

            }
        }
        else
        {
            #region chưa có khám dịch vụ
            html +=  "<input name=\"ctl00$body$gridTable$ctl08$displayDVKhac\" type=\"button\" id=\"ctl00_body_gridTable_ctl08_displayDVKhac\" value=\"...\" onclick=\"nvk_displayKhamDichVuKhac(this);\" style=\"background-color:Pink;\" />"
                  + "<div style=\"display:none;position:absolute;margin-left:-100px;margin-top:20px\">"
                  + "<div>"
                  + "<table cellspacing=\"0\" cellpadding=\"4\" rules=\"all\" border=\"1\" id='nvkTableDichVuKhac_" + sodong + "' style=\"background-color:White;border-color:#CC9966;border-width:1px;border-style:None;width:300px;border-collapse:collapse;\">"
                  + "<tr style=\"color:#FFFFCC;background-color:#990000;font-weight:bold;\">"
                  + "<th scope=\"col\">stt</th><th scope=\"col\">&nbsp;</th><th scope=\"col\">Dịch vụ khám</th><th scope=\"col\">Ghi Chú</th></tr>";
            html +=  "<tr style=\"color:#330099;background-color:White;\">"
                  + "<td>1"
                  + "</td><td>"
                  + "<a onkeydown=\"chuyendong(this);\" style='text-decoration: none; cursor: pointer;"
                  + "margin-right: 10px; color: green;' onclick=\"xoaontableDichVuKhac(this.name,this);\" name=\"\">"
                  + "Xóa"
                  + "</a>"
                  + "</td><td style=\"width:150px;\">"
                  + "<input type=\"text\" onfocus='nvk_searchDichVuKhac(this)' id='txtTenDichVu' style=\"width: 150px; border:solid 1px Red\" title=\"Dịch vụ khám\"  />" //  onblur=\"checkTimes(this);\"
                  + "<input id='idDVKhac' type='hidden' />"
            + "</td><td style=\"width:100px;\">"
            + "<input type=\"text\" onkeydown=\"chuyendong2(this);\" style=\"width: 100px; border:solid 1px Blue\" title=\"Ghi chú\" />"
            + "</td>"
            + "</tr>";
            #endregion
        }
        html +=  "<tr style=\"color:#330099;background-color:#FFFFCC;\">"
                  + "<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>"
                  + "</tr>"
        + "</table>"
       + "</div>"
       + "</div>";
        return html;
    }
    #endregion

    //end nvk function call
}


