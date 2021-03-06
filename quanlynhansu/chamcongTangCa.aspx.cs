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

public partial class chamcongTangCa : Page
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
            BindListLoaiTangCa();
            BindListNhanVien();
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ds", "new Epoch('epoch_popup','popup',document.getElementById('txtNgay'));", true);
        }
    }

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
            StaticData.MsgBox(this, "Vui lòng chọn ngày tháng hợp lệ !");
            return;
        }
        string NgayIn = " And convert(varchar,tc.ngaytangca,103)='" + txtNgay.Text.Trim() + "'";

        if (ddlPhongBan.SelectedValue != "0")
            PhongIn = " and pb.idphongban=" + ddlPhongBan.SelectedValue;
        if (ddlCaLamViec.SelectedValue != "0")
            CaIn = " and ltc.idloaitangca=" + ddlCaLamViec.SelectedValue;
        if (ddlNhanVien.SelectedValue != "0")
            idNhanVienin = " and nv.idnhanvien=" + ddlNhanVien.SelectedValue;

        string listNV = " select ROW_NUMBER ( ) OVER(ORDER BY tenloaitangca,tennhanvien,tc.idtangca) AS STT" + "\r\n"
+ " ,nv.idnhanvien,tc.idtangca,manhanvien,tennhanvien,tenphongban,tenloaitangca,tugio,dengio" + "\r\n"
+ "                        from chitiettangca cttc" + "\r\n"
+ " 					inner join nhanvien nv on cttc.idnhanvien=nv.idnhanvien " + "\r\n"
+ " 					inner join phongban pb on nv.idphongban=pb.idphongban" + "\r\n"
+ "                     inner join tangca tc on tc.idtangca= cttc.idtangca " + "\r\n"
+ "                     inner join loaitangca ltc on ltc.idloaitangca=tc.idloaitangca" + "\r\n"
+ "  where tc.status=1 and ltc.status=1" + "\r\n "
        + " " + PhongIn + " " + CaIn + "" + idNhanVienin + NgayIn;
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
    private void BindListLoaiTangCa()
    {
        string sql = "select * from loaitangca order by tenloaitangca";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlCaLamViec, dt, "idloaitangca", "tenloaitangca", "------Chọn loại tăng ca------");
        }
    }
    private void BindListNhanVien()
    {
        string PhongBanIn = "";
        if (ddlPhongBan.SelectedValue != "0")
            PhongBanIn = " and idphongban=" + ddlPhongBan.SelectedValue;
        string sql = "select * from nhanvien where nhanvien.status=1 " + PhongBanIn + " order by tennhanvien";
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


    protected void btnLuuChamCong_Click(object sender, EventArgs e)
    {
        //Kiểm tra giờ 
        showstatus.Style.Add("display", "");
        foreach (DataGridItem grid in dgr.Items)
        {
            CheckBox nghi = ((CheckBox)grid.Cells[8].FindControl("checkNghi"));
            if (nghi.Checked == false)
            {
                bool kt = KiemTraGio(((TextBox)grid.Cells[3].FindControl("txtTuGio")).Text.Trim(), ((TextBox)grid.Cells[3].FindControl("txtDenGio")).Text.Trim());
                if (!kt)
                {
                    StaticData.MsgBox(this, "Giờ ra vào không hợp lệ");
                    showstatus.Style.Add("display", "none");
                    return;
                }
            }
        }
        foreach (DataGridItem grid in dgr.Items)
        {
            string idnhanvien = grid.Cells[1].Text;
            string idtangca = grid.Cells[9].Text;
            string heSoLuong = LayHeSoTheoIdTangCa(idtangca);
            string selectTonTai = "select * from bangchamcong where idnhanvien=" + idnhanvien + " and idtangca=" + idtangca + " and convert(varchar,ngaychamcong,103)='" + txtNgay.Text.Trim() + "'";
            DataTable dtExit = DataAcess.Connect.GetTable(selectTonTai);
            CheckBox nghi = ((CheckBox)grid.Cells[8].FindControl("checkNghi"));
            if (nghi.Checked == true)// nghỉ làm 
            {
                string ngayChamCong = StaticData.CheckDate(txtNgay.Text);
                string idBangChamCong = StaticData.MaxIdNhanSuTheoTable("BangChamCong", "idChamCong");
                if (dtExit.Rows.Count == 0)
                {
                    NhanSu_Process.BangChamCong BCC = NhanSu_Process.BangChamCong.Insert_Object(idBangChamCong
                    , idnhanvien.ToString(), "0", ngayChamCong
                    , null, null, "1", "0", null
                    , "1", "1",idtangca.ToString());
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
                    , idnhanvien.ToString(), "0", ngayChamCong
                    , null, null, "1", "0", null
                    , "1", "1",idtangca.ToString());
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
                double sogio = TinhSoGio(GioVao, GioRa);
                #endregion Tính Số giờ
                //end tinh so gio
                //Tính Lương một giờ
                #region Tính Lương một giờ
                DataTable dtLuongCB = DataAcess.Connect.GetTable(" select mucluongcoban,giolam from hopdong where idnhanvien=" + idnhanvien + " ");
                if (dtLuongCB.Rows.Count == 0)
                    continue; //không lưu Nhân viên chưa coa hợp đồng
                double LuongMotGio = StaticData.ParseFloat(dtLuongCB.Rows[0][0].ToString()) / StaticData.ParseFloat(dtLuongCB.Rows[0][1].ToString());
                //LuongMotGio = Math.Round(LuongMotGio);  // làm tròn lương 1 giờ
                #endregion end Tính Lương một giờ

                //End tính Lương một giờ
                //Lưu chấm công
                string ngayChamCong = StaticData.CheckDate(txtNgay.Text);
                string idBangChamCong = StaticData.MaxIdNhanSuTheoTable("BangChamCong", "idChamCong");
                if (dtExit.Rows.Count == 0)
                {
                    NhanSu_Process.BangChamCong BCC = NhanSu_Process.BangChamCong.Insert_Object(idBangChamCong
                    , idnhanvien.ToString(), "0", ngayChamCong
                    , GioVao, GioRa, "0", sogio.ToString(), LuongMotGio.ToString()
                    , heSoLuong, "1",idtangca.ToString());
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
                    , idnhanvien.ToString(), "0", ngayChamCong
                    , GioVao, GioRa, "0", sogio.ToString(), LuongMotGio.ToString()
                    , heSoLuong, "1",idtangca.ToString());
                    if (!ktBCC)
                    {
                        StaticData.MsgBox(this, "Có lỗi xảy ra trong khi lưu chấm công. Vui lòng kiểm tra lại.");
                        return;
                    }
                }
            }
        }
        StaticData.MsgBox(this, "Đã lưu chấm công thành công !");
        showstatus.Style.Add("display", "none");
    }
    private string LayHeSoTheoIdTangCa(string idTangCa)
    {
        string heso = "1";
        string sql = "select hesoluong from tangca tc inner join loaitangca ltc on ltc.idloaitangca=tc.idloaitangca where idtangca=" + idTangCa;
        DataTable dtHs = DataAcess.Connect.GetTable(sql);
        if (dtHs.Rows.Count > 0)
            heso = dtHs.Rows[0][0].ToString();
        return heso;
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
    private bool KiemTraGio(string tugio, string dengio)
    {
        int giovao;
        int phutvao;
        string[] arr = tugio.Split(':');
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
                StaticData.MsgBox(this, "Giờ vào không hợp lệ !");
                return false;
            }
        }
        else
        {
            StaticData.MsgBox(this, "Giờ vào không hợp lệ !");
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
