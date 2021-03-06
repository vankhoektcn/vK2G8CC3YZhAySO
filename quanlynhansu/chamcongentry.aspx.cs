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
using System.Data.SqlClient;
using System.Globalization;

public partial class chamcongentry : Page
{
    protected void Page_Load(object sender, EventArgs e)
     {
         if (!IsPostBack)
         {
             //idthang.InnerHtml = "THÔNG TIN CHẤM CÔNG THÁNG " + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
             //ddlthang.SelectedIndex = ddlthang.Items.IndexOf(ddlthang.Items.FindByValue(DateTime.Now.Month.ToString()));
             //BindListNam();
             //ddlnam.SelectedIndex = ddlnam.Items.IndexOf(ddlnam.Items.FindByValue(DateTime.Now.Year.ToString()));
             //listidnhanvien.Value = "";
             //LoadDataChongCong("");
             BindListPhongBan();
             BindListCaLamViec();
             BindListNhanVien();
             txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
             
         }
         else
         {
             ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ds", "new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));", true);
         } 
     }
    #region " 19012010"
    private void BindListNam()
    {
        ddlnam.Items.Clear();
        ddlnam.Items.Add(new ListItem("--Năm--", "0"));
        for (int i = StaticData.ParseInt(DateTime.Now.Year.ToString()) - 5; i <= StaticData.ParseInt(DateTime.Now.Year.ToString()) + 10; i++)
        {
            ddlnam.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ddlnam.DataBind();
    }
    private string LoadCacNgayTrongThang(int ithang, int inam)
    {
        string skq = "";
        int isongay = StaticData.GetSoNgay(ithang, inam);
        idngay.Value = isongay.ToString();
        skq += "<table cellspacing=\"1\" cellpadding=\"1\" rules=\"all\" border=\"1\" style=\"border-color:Silver;border-width:1px;border-style:solid;width:100%;border-collapse:collapse;\"><tr>";
        skq += "<td style = \"width: 170px\" class = \"ptext\" align = \"center\"><b>HỌ TÊN</b></td>";
        skq += "<td style = \"width: 40px\" class = \"ptext\" align = \"center\"></td>";
        for (int i = 1; i <= isongay; i++)
        {
            if (i >= 10)
                skq += "<td style = \"width: 30px\" class = \"ptext\" align = \"center\"><b>" + i.ToString() + "</b></td>";
            else
                skq += "<td style = \"width: 30px\" class = \"ptext\" align = \"center\"><b>&nbsp;" + i.ToString() + "</b></td>";
        }
        skq += "<td style = \"width: 50px\" class = \"ptext\" align = \"center\" nowrap = \"nowrap\"></td>";
        skq += "<td style = \"width: 50px\" class = \"ptext\" align = \"center\" nowrap = \"nowrap\"><b>TC(h)</b></td>";
        skq += "<td style = \"width: 100px\" class = \"ptext\" align = \"center\" nowrap = \"nowrap\"><b>TIỀN LƯƠNG</b></td>";
        skq += "<td style = \"width: 50px\" class = \"ptext\" align = \"center\" nowrap = \"nowrap\"><b>CN(h)</b></td>";
        skq += "<td style = \"width: 100px\" class = \"ptext\" align = \"center\" nowrap = \"nowrap\"><b>TỔNG LƯƠNG</b></td>";
        skq += "</tr>";
        skq += LoadChiTietChamCong(isongay, ithang, inam);
        skq += "</table>";
        return skq;
    }

    private string LoadChiTietChamCong(int isongay, int ithang, int inam)
    {
        string strSQL = "SELECT cn.* ";
        strSQL += " FROM phongkhambenh cn ";
        strSQL += " WHERE 1=1 AND ishoptac = 0 ORDER BY tenphongkhambenh";

        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        string schitiet = "";
        for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
        {
            if (i % 2 == 0)
            {
                schitiet += "<tr align=\"left\" valign=\"middle\" >";
                schitiet += "<td style=\"white-space:nowrap; background-color:#FFFFFF\" colspan = \"" + (isongay+7).ToString() + "\"><b>" + dtCTPhieu.Rows[i]["tenphongkhambenh"].ToString().ToUpper() + "</b></td></td>";
                schitiet += "</tr>";
            }
            else
            {
                schitiet += "<tr align=\"left\" valign=\"middle\">";
                schitiet += "<td style=\"white-space:nowrap; background-color:#FFFFFF\" colspan = \"" + (isongay+7).ToString() + "\"><b>" + dtCTPhieu.Rows[i]["tenphongkhambenh"].ToString().ToUpper() + "</b></td></td>";
                schitiet += "</tr>";

            }
            schitiet += LoadChiTietThongTinChamCong(StaticData.ParseInt(dtCTPhieu.Rows[i]["idphongkhambenh"]), isongay, ithang, inam);
        }
        return schitiet;
    }

    private string LoadChiTietThongTinChamCong(int idphongkhambenh, int isongay, int ithang, int inam)
    {
        string skq = "", sqlchild = "", slistid = "";
        int iluongcn = 0, iluongtc = 0;
        string sql = "SELECT TOP 1 * FROM setting ORDER BY idsetting DESC";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            iluongcn = StaticData.ParseInt(dt.Rows[0]["luongngaychunhat"]);
            iluongtc = StaticData.ParseInt(dt.Rows[0]["luongtangcatrengio"]);
        }
        sqlchild += "Select idbacsi, tenbacsi, dbo.TongSoGioLamViec(idbacsi, " + ithang + "," + inam + ") as tonggiolamviec, ";
        sqlchild += " Round(dbo.TongSoGioLamViec(idbacsi, " + ithang + "," + inam + ")/26*luongcoban/8, 0) as luongthang, ";
        sqlchild += " dbo.TongGioTangCa(idbacsi, " + ithang + "," + inam + ") as tonggiotangca, ";
        sqlchild += " dbo.TongGioTangCa(idbacsi, " + ithang + "," + inam + ")*" + iluongtc + " as luongtangca, ";
        sqlchild += " dbo.TongGioLamChuNhat(idbacsi, " + ithang + "," + inam + ") as tonggiolamchunhat, ";
        sqlchild += " dbo.TongGioLamChuNhat(idbacsi, " + ithang + "," + inam + ")*" + (iluongcn/4) + " as luongchunhat ";
        sqlchild += " From bacsi nv ";
        sqlchild += " where  1 = 1 AND isthoiviec = 0 AND nv.idphongkhambenh = " + idphongkhambenh.ToString();
        sqlchild += " ORDER BY tenbacsi ";

        DataTable dtchild =  DataAcess.Connect.GetTable(sqlchild);
        if (dtchild != null && dtchild.Rows.Count > 0)
        {
            //string schk = "";
            for (int i = 0; i < dtchild.Rows.Count; i++)
            {
                slistid = slistid + dtchild.Rows[i]["idbacsi"].ToString() + ",";

                skq += "<tr class=\"dgrHeader\" onmouseover=\"this.style.backgroundColor=#FFFFFF\" onmouseout=\"this.style.backgroundColor=#FF0000\">";
                skq += "<td class = \"ptext\" nowrap = \"nowrap\">" + dtchild.Rows[i]["tenbacsi"].ToString() + "</td>";
                skq += "<td style = \"width: 40px\" class = \"ptext\" align = \"right\">Glv</td>";
                for (int j = 1; j <= isongay; j++)
                {
                    skq += "<td style=\"width:30px;white-space:nowrap;\">";
                    skq += "<input type = \"text\" style = \"width:15px; text-align:right\" value = \"" + GetGioLamViecTrenNgay(j, ithang, inam, StaticData.ParseInt(dtchild.Rows[i]["idbacsi"])).ToString() + "\" id = \"ngaycong_" + dtchild.Rows[i]["idbacsi"] + "_" + j + ithang + inam + "\" title=\"Ngày công " + j + "/" + ithang + "/" + inam + "\">";
                    skq += "</td>";
                }
                skq += "<td class = \"ptext\" align = \"right\" nowrap = \"nowrap\">&nbsp;" + dtchild.Rows[i]["tenbacsi"] + "</td>";
                skq += "<td class = \"ptext\" align = \"center\" nowrap = \"nowrap\">";
                skq += "<input style = \"width: 30px; text-align:right\" title=\"Tổng giờ làm việc\" type = \"text\" id = \"tcngaycong_" + dtchild.Rows[i]["idbacsi"] + "_" + ithang + inam + "\" value = \"" + dtchild.Rows[i]["tonggiolamviec"] + "\"> h";
                skq += "</td>";
                skq += "<td style = \"width: 100px\" class = \"ptext\" align = \"right\">" + StaticData.FormatNumber(dtchild.Rows[i]["luongthang"], false).ToString() + "</td>";
                skq += "<td style = \"width: 50px\" class = \"ptext\" align = \"right\"><input type = \"text\"  style = \"width: 30px; text-align:right\" title = \"Tổng giờ làm chủ nhật\" value = \"" + dtchild.Rows[i]["tonggiolamchunhat"] + "\"></td>";
                skq += "<td style = \"width: 120px\" class = \"ptext\" align = \"right\">" + StaticData.FormatNumber(StaticData.ParseFloat(dtchild.Rows[i]["luongthang"]) + StaticData.ParseFloat(dtchild.Rows[i]["luongtangca"]) + StaticData.ParseFloat(dtchild.Rows[i]["luongchunhat"]), false).ToString() + "</td>";
                skq += "</tr>";

                skq += "<tr bgcolor = \"#FFFFFF\" onmouseover=\"this.style.backgroundColor=#FFFFFF\" onmouseout=\"this.style.backgroundColor=#FF0000\">";
                skq += "<td class = \"ptext\">&nbsp;</td>";
                skq += "<td style = \"width: 40px\" class = \"ptext\" align = \"right\">Gtc</td>";
                for (int j = 1; j <= isongay; j++)
                {
                    skq += "<td style=\"width:30px;white-space:nowrap;\">";
                    skq += "<input type = \"text\" style = \"width:15px; text-align:right\" value = \"" + GetGioTangCaTrenNgay(j, ithang, inam, StaticData.ParseInt(dtchild.Rows[i]["idbacsi"])).ToString() + "\" id = \"giotangca_" + dtchild.Rows[i]["idbacsi"] + "_" + j + ithang + inam + "\" title=\"Giờ tăng ca " + j + "/" + ithang + "/" + inam + "\">";
                    skq += "</td>";
                }
                skq += "<td style = \"width: 50px\" class = \"ptext\" align = \"center\" nowrap = \"nowrap\">&nbsp;</td>";
                skq += "<td class = \"ptext\" align = \"center\" nowrap = \"nowrap\">";
                skq += "<input style = \"width: 30px; text-align:right\" title=\"Tổng giờ tăng ca\" type = \"text\" id = \"tcgiotangca_" + dtchild.Rows[i]["idbacsi"] + "_" + ithang + inam + "\" value = \"" + dtchild.Rows[i]["tonggiotangca"] + "\"> h";
                skq += "</td>";
                skq += "<td style = \"width: 120px\" class = \"ptext\" align = \"right\">" + StaticData.FormatNumber(dtchild.Rows[i]["luongtangca"], false).ToString() + "</td>";
                skq += "<td style = \"width: 50px\" class = \"ptext\" align = \"right\">" + StaticData.FormatNumber(dtchild.Rows[i]["luongchunhat"], false).ToString() + "</td>";
                skq += "<td style = \"width: 120px\" class = \"ptext\" align = \"center\"></td>";
                skq += "</tr>";
            }
        }
        else
            skq += "<tr><td style=\"width:100%; height:18px;white-space:nowrap;\" align=\"left\" colspan = \"" + (isongay + 2) + "\"><span class = \"ptext\">&nbsp;Không có nhân viên.</td></td></tr>";
        if (slistid != "")
            slistid = slistid.TrimEnd(',');
        if (slistid != "")
            if (listidnhanvien.Value != "")
                listidnhanvien.Value = listidnhanvien.Value + "," + slistid;
            else
                listidnhanvien.Value = listidnhanvien.Value + slistid;
        return skq;
    }
    private void LoadDataChongCong(string sngaycong)
    {
        chitietchamcong.InnerHtml = LoadCacNgayTrongThang(StaticData.ParseInt(ddlthang.SelectedValue), StaticData.ParseInt(ddlnam.SelectedValue));
    }

    private string GetGioLamViecTrenNgay(int ingay, int ithang, int inam, int idnhanvien)
    {
        string skq = "0";
        string ssql = "SELECT dbo.GetGioLamViecTrenNgay(" + ingay + "," + ithang + "," + inam + "," + idnhanvien + ") as kq";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt != null && dt.Rows.Count > 0)
            skq = dt.Rows[0]["kq"].ToString();
        return skq;
    }

    private string GetGioTangCaTrenNgay(int ingay, int ithang, int inam, int idnhanvien)
    {
        string skq = "0";
        string ssql = "SELECT dbo.GetGioTangCaTrenNgay(" + ingay + "," + ithang + "," + inam + "," + idnhanvien + ") as kq";
        DataTable dt = DataAcess.Connect.GetTable(ssql);
        if (dt != null && dt.Rows.Count > 0)
            skq = dt.Rows[0]["kq"].ToString();
        return skq;
    }
    //private string LoadChiTietChamCong(int idphongkham, string ngaycong)
    //{
    //    string sqlchild = "", skq = "", slistid = "";
    //    sqlchild += "Select nv.*, tenchucvu, ngay, isnull(giovao, 7) as giovao, isnull(phutvaosang, 30) as phutvao, isnull(nghisang, 11) as gionghisang, isnull(phutnghisang, 30) as phutnghisang, ";
    //    sqlchild += " isnull(giovaochieu, 13) as giovaochieu, isnull(phutvaochieu, 0) as phutvaochieu, isnull(nghichieu, 17) as giora, isnull(phutnghichieu, 0) as phutra, isnull(heso, 1) as heso ";
    //    sqlchild += " From bacsi nv LEFT JOIN bangchamcong bcc ON nv.idbacsi = bcc.nhanvienid AND bcc.ngay='" + StaticData.CheckDate(ngaycong).ToString() + "' ";
    //    sqlchild += " INNER JOIN chucvu cv ON nv.idchucvu = cv.idchucvu ";
    //    sqlchild += " where  1 = 1 AND isthoiviec = 0 AND nv.idphongkhambenh = " + idphongkham.ToString();
    //    sqlchild += " ORDER BY tenbacsi ";

    //    DataTable dtchild = DataAcess.Connect.GetTable(sqlchild, conn);
    //    skq += "<table tabindex=\"12\" cellspacing=\"1\" cellpadding=\"1\" rules=\"all\" border=\"1\" id=\"dgr\" style=\"border-color:Silver;border-width:1px;border-style:solid;width:100%;border-collapse:collapse;\">";
    //    if (dtchild != null && dtchild.Rows.Count > 0)
    //    {
    //        //string schk = "";
    //        for (int i = 0; i < dtchild.Rows.Count; i++)
    //        {
    //            skq += "<tr class=\"dgrHeader\" onmouseover=\"this.style.backgroundColor=#FFFFFF\" onmouseout=\"this.style.backgroundColor=#FF0000\"><td style=\"width:23%; height:50px;white-space:nowrap;\">&nbsp;" + dtchild.Rows[i]["tenbacsi"].ToString() + "</td>";
    //            skq += "</tr>";
    //            slistid = slistid + dtchild.Rows[i]["idbacsi"].ToString() + ",";
    //        }
    //    }
    //    else
    //        skq += "<tr><td style=\"width:100%; height:16px;white-space:nowrap;\" align=\"left\"><span class = \"ptext\">&nbsp;Không có nhân viên.</td></td></tr>";
    //    skq += "</table>";
    //    if (slistid != "")
    //        slistid = slistid.TrimEnd(',');
    //    if (slistid != "")
    //        if (listidnhanvien.Value != "")
    //            listidnhanvien.Value = listidnhanvien.Value + "," + slistid;
    //        else
    //            listidnhanvien.Value = listidnhanvien.Value + slistid;
    //    return skq;
    //}
    #endregion
    #region My Code KH@
    private void BindListChamCong()
    {
        string PhongIn = "";
        string CaIn = "";
        string idNhanVienin = "";
        try
        {
            //DateTime d = DateTime.Parse("08/18/2011");
            DateTime date = DateTime.ParseExact(txtNgay.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
        }
        catch (Exception)
        {
            StaticData.MsgBox(this,"Vui lòng chọn ngày tháng hợp lệ !");
            return;
        }
        string NgayIn = " And convert(varchar,pc.ngaythangnam,103)='"+txtNgay.Text.Trim()+"'";
        
        if (ddlPhongBan.SelectedValue != "0")
            PhongIn = " and pb.idphongban=" + ddlPhongBan.SelectedValue;
        if (ddlCaLamViec.SelectedValue != "0")
            CaIn = " and clv.idcalamviec=" + ddlCaLamViec.SelectedValue;
        if (ddlNhanVien.SelectedValue != "0")
            idNhanVienin = " and nv.idnhanvien=" + ddlNhanVien.SelectedValue;

        string listNV = "select ROW_NUMBER ( ) OVER(ORDER BY tenphongban,tennhanvien) AS STT,nv.idnhanvien,pc.idphanca,manhanvien,tennhanvien,tenphongban,tencalamviec,tugio,dengio "
                      + " from phanca pc left join nhanvien nv on pc.idnhanvien=nv.idnhanvien "
                      + " left join calamviec clv on clv.idcalamviec= pc.idcalamviec "
                      + " left join phongban pb on nv.idphongban=pb.idphongban where pc.status=1 "
        + " "+PhongIn+" "+ CaIn +""+ idNhanVienin +NgayIn;
        DataTable dt = DataAcess.Connect.GetTable(listNV);
        //if (dt != null && dt.Rows.Count > 0)
        //{
        showstatus.Visible = true;
            dgr.DataSource = dt;
            dgr.DataBind();
            if (dt.Rows.Count > 0)
                btnLuuChamCong.Visible = true;
            else
                btnLuuChamCong.Visible = false;
        //}
    }

    private void BindListPhongBan()
    {
        string sql = "select * from phongban ORder by tenphongban";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlPhongBan, dt, "idphongban", "tenphongban", "------Chọn phòng ban------");
        }
    }
    private void BindListCaLamViec()
    {
        string sql = "select * from CaLamViec order by tencalamviec";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlCaLamViec, dt, "idcalamviec", "tencalamviec", "------Chọn ca làm việc------");
        }
    }
    private void BindListNhanVien()
    {
        string PhongBanIn = "";
        if (ddlPhongBan.SelectedValue != "0")
            PhongBanIn = " where idphongban=" + ddlPhongBan.SelectedValue;
        string sql = "select * from nhanvien " + PhongBanIn + "  order by tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "tennhanvien", "------Chọn Nhân Viên------");
        }
    }
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }
           
        }

    }
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        listidnhanvien.Value = "";
        LoadDataChongCong(""); 
    }
    protected void btnLuuChamCong_Click(object sender, EventArgs e)
    {
        //Kiểm tra giờ 
        showstatus.Style.Add("display", "");
        foreach (DataGridItem grid in dgr.Items)
        {
            CheckBox nghi=((CheckBox)grid.Cells[8].FindControl("checkNghi"));
            if (nghi.Checked == false)
            {
                bool kt = KiemTraGio(((TextBox)grid.Cells[3].FindControl("txtTuGio")).Text.Trim(), ((TextBox)grid.Cells[3].FindControl("txtDenGio")).Text.Trim());
                if (!kt)
                {
                    StaticData.MsgBox(this,"Giờ ra vào không hợp lệ");
                    return;
                }
            }
        }
        foreach (DataGridItem grid in dgr.Items)
        {
            string idnhanvien = grid.Cells[1].Text;
            string idphanca = grid.Cells[9].Text;
            string selectTonTai = "select * from bangchamcong where idnhanvien="+idnhanvien+" and idphanca="+idphanca+" and convert(varchar,ngaychamcong,103)='" + txtNgay.Text.Trim() + "'";
            DataTable dtExit = DataAcess.Connect.GetTable(selectTonTai);
            CheckBox nghi = ((CheckBox)grid.Cells[8].FindControl("checkNghi"));
            if (nghi.Checked == true)// nghỉ làm 
            {
                string ngayChamCong = StaticData.CheckDate(txtNgay.Text);
                string idBangChamCong = StaticData.MaxIdNhanSuTheoTable("BangChamCong", "idChamCong");
                if (dtExit.Rows.Count == 0)
                {
                    NhanSu_Process.BangChamCong BCC = NhanSu_Process.BangChamCong.Insert_Object(idBangChamCong
                    , idnhanvien.ToString(), idphanca.ToString(), ngayChamCong
                    , null, null, "1", "0", null
                    , "1", "1","0");
                    if (BCC == null)
                    {
                        StaticData.MsgBox(this, "Có lỗi xảy ra trong khi lưu chấm công. Vui lòng kiểm tra lại.");
                        return;
                    }
                }
                else
                {
                    NhanSu_Process.BangChamCong BCC = new NhanSu_Process.BangChamCong();
                        BCC.idChamCong= dtExit.Rows[0][0].ToString();
                    bool ktBCC= BCC.Save_Object(BCC.idChamCong
                    , idnhanvien.ToString(), idphanca.ToString(), ngayChamCong
                    , null, null, "1", "0", null
                    , "1", "1","0");
                    if (!ktBCC)
                    {
                        StaticData.MsgBox(this, "Có lỗi xảy ra trong khi lưu chấm công. Vui lòng kiểm tra lại.");
                        return;
                    }
                }
            }
            else  //có làm
            {
                //Tính Số giờ
                #region Tính Số giờ
                string GioVao = ((TextBox)grid.Cells[3].FindControl("txtTuGio")).Text.Trim();
                string GioRa = ((TextBox)grid.Cells[3].FindControl("txtDenGio")).Text.Trim();
                double sogio = TinhSoGio(GioVao,GioRa);
                #endregion Tính Số giờ
                //end tinh so gio
                //Tính Lương một giờ
                #region Tính Lương một giờ
                DataTable dtLuongCB = DataAcess.Connect.GetTable(" select mucluongcoban,giolam from hopdong where idnhanvien="+idnhanvien+" ");
                if (dtLuongCB.Rows.Count == 0)
                    continue; //không lưu Nhân viên chưa coa hợp đồng
                double LuongMotGio = StaticData.ParseFloat(dtLuongCB.Rows[0][0].ToString()) / StaticData.ParseFloat(dtLuongCB.Rows[0][1].ToString());
                //LuongMotGio= Math.Round(LuongMotGio);  // làm tròn lương 1 giờ
                #endregion end Tính Lương một giờ
                
                //End tính Lương một giờ
                //Lưu chấm công
                string ngayChamCong = StaticData.CheckDate(txtNgay.Text);
                string idBangChamCong = StaticData.MaxIdNhanSuTheoTable("BangChamCong", "idChamCong");
                if (dtExit.Rows.Count == 0)
                {
                    NhanSu_Process.BangChamCong BCC = NhanSu_Process.BangChamCong.Insert_Object(idBangChamCong
                    , idnhanvien.ToString(), idphanca.ToString(), ngayChamCong
                    , GioVao, GioRa, "0", sogio.ToString(), LuongMotGio.ToString()
                    , "1", "1","0");
                    if (BCC == null)
                    {
                        StaticData.MsgBox(this, "Có lỗi xảy ra trong khi lưu chấm công. Vui lòng kiểm tra lại.");
                        return;
                    }
                }
                else
                {
                    NhanSu_Process.BangChamCong BCC = new NhanSu_Process.BangChamCong();
                    BCC.idChamCong = dtExit.Rows[0][0].ToString();
                    bool ktBCC = BCC.Save_Object(BCC.idChamCong
                    , idnhanvien.ToString(), idphanca.ToString(), ngayChamCong
                    , GioVao, GioRa, "0", sogio.ToString(), LuongMotGio.ToString()
                    , "1", "1","0");
                    if (!ktBCC)
                    {
                        StaticData.MsgBox(this, "Có lỗi xảy ra trong khi lưu chấm công. Vui lòng kiểm tra lại.");
                        return;
                    }
                }
            }
        }
        StaticData.MsgBox(this,"Đã lưu chấm công thành công !");
        showstatus.Style.Add("display", "none");
    }
    private double TinhSoGio(string giovao, string giora)
    {
        double sogio = 0;
        string[] arr1 = giovao.Split(':');
        
                int gio = int.Parse(arr1[0]);
                double phut = int.Parse(arr1[1]);
        double sogiovao = gio + (double)(phut / 60);
        string[] arr2 = giora.Split(':');

                int gior = int.Parse(arr2[0]);
                double phutr = int.Parse(arr2[1]);
        double sogiora = gior + (double)(phutr / 60);
        sogio = sogiora - sogiovao;
        return sogio;
    }
    private bool KiemTraGio(string tugio,string dengio)
    {
        int giovao;
        int phutvao;
        string [] arr = tugio.Split(':');
        if (arr.Length == 2)
        {
            try
            {
                 giovao = int.Parse(arr[0]);
                if (giovao < 0 || giovao > 23)
                    return false;
                 phutvao = int.Parse(arr[1]);
                if (phutvao < 0 || phutvao > 59)
                    return false;
            }
            catch (Exception)
            {
                StaticData.MsgBox(this,"Giờ vào không hợp lệ !");
                return false;
            }
        }
        else
        {
            StaticData.MsgBox(this,"Giờ vào không hợp lệ !");
            return false;
        }
        arr = dengio.Split(':');
        if (arr.Length == 2)
        {
            try
            {
                int gio = int.Parse(arr[0]);
                if (gio < 0 || gio > 23)
                    return false;
                if (gio < giovao)
                    return false;
                int phut = int.Parse(arr[1]);
                if (phut < 0 || phut > 59)
                    return false;
                if (gio == giovao)
                    if (phutvao < phut)
                        return false;
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Giờ vào không hợp lệ !");
                return false;
            }
        }
        else
        {
            StaticData.MsgBox(this, "Giờ vào không hợp lệ !");
            return false;
        }
        return true;
    }
    protected void btnGetDanhSach_Click(object sender, EventArgs e)
    {
        BindListChamCong();
    }
    #endregion my code
    protected void ddlPhongBan_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindListNhanVien();
    }
}
