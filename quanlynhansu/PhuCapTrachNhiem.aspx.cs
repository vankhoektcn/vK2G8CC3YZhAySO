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
public partial class PhuCapTrachNhiem : Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            BindListPhongBan();
            BindListNhanVien();
            BindListNam();
            ddlThang.SelectedValue = DateTime.Now.Month.ToString();
            ddlNam.SelectedValue = DateTime.Now.Year.ToString();
            LoadDanhSachPhuCap("");
            pnl1.Visible = false;
        }
    }
    private void BindListPhongBan()
    {
        string sql = "select * from phongban where status=1 ORder by tenphongban";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlPhongBan, dt, "idphongban", "tenphongban", "------Chọn phòng ban------");
        }
    }
    private void BindListNhanVien()
    {
        string PhongBanIn = "";
        if (ddlPhongBan.SelectedValue != "0")
            PhongBanIn = " and nv.idphongban=" + ddlPhongBan.SelectedValue;
        string sql = @"select nv.idnhanvien,nv.tennhanvien from nhanvien nv
            where nv.status=1
            and nv.idnhanvien in (select hd.idnhanvien from hopdong hd
             where nv.idnhanvien=hd.idnhanvien and hd.status=1) 
            " + PhongBanIn + @"
            order by nv.tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "tennhanvien","----Chọn nhân viên----");
        }
    }
    private void BindListNam()
    {

        for (int i = 2011; i <= StaticData.NamGioiHan; i++)
        {
            ddlNam.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }

    private void LoadDanhSachPhuCap(string where)
    {
        string sql = ""
            + " select ROW_NUMBER ( ) OVER(ORDER BY tennhanvien) AS STT" + "\r\n"
+ " , nv.idnhanvien,nv.tennhanvien,nv.manhanvien,pb.tenphongban,cv.tenchucvu as chucvu" + "\r\n"
+ " ,pc.idphucap,pc.tenphucap,ctpc.giatrimuc" + "\r\n"
+ " ,MucLuongCoBan=isnull((select top 1 luongCB from hopdong where idnhanvien=nv.idnhanvien order by idhopdong desc),0)" + "\r\n"
+ " ,TienPhucap=[dbo].[PhuCapDocHai_TN_NV_PC](nv.idnhanvien,2)" + "\r\n"
+ " ,TienPhucap1=isnull((select top 1 luongCB from hopdong where idnhanvien=nv.idnhanvien order by ngayky desc),0) * ctpc.giatrimuc" + "\r\n"
+ " from ChiTietPhuCap_NhanVien ctpc inner join nhanvien nv on nv.idnhanvien=ctpc.idnhanvien" + "\r\n"
+ " inner join danhmucphucap pc on pc.idphucap=ctpc.idphucap" + "\r\n"
+ " left join phongban pb on pb.idphongban=nv.idphongban" + "\r\n"
+ " left join chucvu cv on cv.idchucvu=nv.idchucvu" + "\r\n"
+ " where pc.idphucap=2 and nv.status=1 "+where+"" + "\r\n";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        dgr.DataSource = dt;
        dgr.DataBind();
        //}
        if (dt.Rows.Count > 0)
        {
            txtThangHidden.Value = ddlThang.SelectedValue;
            txtNamHidden.Value = ddlNam.SelectedValue;
            lbThangNam.Text = "Tháng " + ddlThang.SelectedValue + "/" + ddlNam.SelectedValue;
            btnExcel.Visible = true;
            btnLuuPhuCap.Visible = true;
        }
        else
        {
            txtThangHidden.Value = "";
            txtNamHidden.Value = "";
            lbThangNam.Text = "";
            btnExcel.Visible = false;
            btnLuuPhuCap.Visible = false;
        }
    }
    protected void btnLuuPhuCap_Click(object sender, EventArgs e)
    {
        if (dgr.Items.Count == 0)
            return;
        bool KetQua=true;
        string thang = txtThangHidden.Value;
        string nam = txtNamHidden.Value;
        for (int i = 0; i <= dgr.Items.Count - 1; i++)
        {
            string idNhanVien = ((TextBox)dgr.Items[i].FindControl("txtIdNhanVien")).Text;
            string idPhuCap = ((TextBox)dgr.Items[i].FindControl("txtIdPhuCap")).Text;
            string MucLuongCoBan = ((TextBox)dgr.Items[i].FindControl("txtMucLuongCoBan")).Text;
            string GiaTriMuc = ((TextBox)dgr.Items[i].FindControl("txtGiaTriMuc")).Text;
            string TienPhucap = ((TextBox)dgr.Items[i].FindControl("txtTienPhucap")).Text;
            string sqlExist = " select * from LichSuPhuCap where Thang="+thang+" and Nam="+nam+" and idNhanVien="+idNhanVien+" and idPhuCap="+idPhuCap+" ";
            DataTable dtLichSu = DataAcess.Connect.GetTable(sqlExist);
            if (dtLichSu.Rows.Count == 0)
            {
                NhanSu_Process.LichSuPhuCap LSPC = NhanSu_Process.LichSuPhuCap.Insert_Object(StaticData.MaxIdNhanSuTheoTable("LichSuPhuCap", "idLichSuPhuCap")
                    , idNhanVien, thang, nam, idPhuCap, MucLuongCoBan, GiaTriMuc, "0", "0", "0", TienPhucap);
                if (LSPC == null)
                {
                    StaticData.MsgBox(this, "Có lỗi khi lưu phụ cấp !");
                    return;
                }
            }
            else
            {
                NhanSu_Process.LichSuPhuCap LSPC = new NhanSu_Process.LichSuPhuCap();
                LSPC.idLichSuPhuCap = dtLichSu.Rows[0]["idLichSuPhuCap"].ToString();
                bool kt= LSPC.Save_Object(LSPC.idLichSuPhuCap
                    , idNhanVien, thang, nam, idPhuCap, MucLuongCoBan, GiaTriMuc, "0", "0", "0", TienPhucap);
                if (!kt)
                {
                    StaticData.MsgBox(this, "Có lỗi khi cập nhật phụ cấp !");
                    return;
                }
            }
        }
        StaticData.MsgBox(this, "Lưu phụ cấp thành công !");
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Response.Redirect("PhuCapDocHai.aspx");
    }
    protected void ddlPhongBan_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindListNhanVien();
    }
    protected void btnGetDanhSach_Click(object sender, EventArgs e)
    {
        string where = "";
        if (ddlPhongBan.SelectedValue != "0")
            where = " and pb.idphongban=" + ddlPhongBan.SelectedValue;
        if (ddlNhanVien.SelectedValue != "0")
            where = " and nv.idnhanvien=" + ddlNhanVien.SelectedValue;
        if (ddlThang.SelectedValue == DateTime.Now.Month.ToString() && ddlNam.SelectedValue == DateTime.Now.Year.ToString())
        {
            LoadDanhSachPhuCap(where);
        }
        else
        {
            string sql = ""
                + " select ROW_NUMBER ( ) OVER(ORDER BY tennhanvien) AS STT" + "\r\n"
    + " , nv.idnhanvien,nv.tennhanvien,nv.manhanvien,pb.tenphongban,cv.tenchucvu as chucvu" + "\r\n"
    + " ,pc.idphucap,pc.tenphucap,Lspc.MucPhuCap as giatrimuc" + "\r\n"
    + " ,MucLuongCoBan=LuongCB" + "\r\n"
    + " ,TienPhucap=Lspc.TongTienPhuCap" + "\r\n"
    + " --,TienPhucap1=isnull((select top 1 luongCB from hopdong where idnhanvien=nv.idnhanvien order by ngayky desc),0) * ctpc.giatrimuc" + "\r\n"
    + " from LichSuPhuCap Lspc inner join nhanvien nv on nv.idnhanvien=Lspc.idnhanvien" + "\r\n"
    + " inner join danhmucphucap pc on pc.idphucap=Lspc.idphucap" + "\r\n"
    + " left join phongban pb on pb.idphongban=nv.idphongban" + "\r\n"
    + " left join chucvu cv on cv.idchucvu=nv.idchucvu" + "\r\n"
    + " where pc.idphucap=2 and nv.status=1 " + where + " and Lspc.thang="+ddlThang.SelectedValue+" and Lspc.nam="+ddlNam.SelectedValue+"" + "\r\n";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            if (dt.Rows.Count == 0)
            {
                 sql = ""
            + " select ROW_NUMBER ( ) OVER(ORDER BY tennhanvien) AS STT" + "\r\n"
+ " , nv.idnhanvien,nv.tennhanvien,nv.manhanvien,pb.tenphongban,cv.tenchucvu as chucvu" + "\r\n"
+ " ,pc.idphucap,pc.tenphucap,ctpc.giatrimuc" + "\r\n"
+ " ,MucLuongCoBan=isnull((select top 1 luongCB from hopdong where idnhanvien=nv.idnhanvien order by idhopdong desc),0)" + "\r\n"
+ " ,TienPhucap=[dbo].[PhuCapDocHai_TN_NV_PC](nv.idnhanvien,2)" + "\r\n"
+ " ,TienPhucap1=isnull((select top 1 luongCB from hopdong where idnhanvien=nv.idnhanvien order by ngayky desc),0) * ctpc.giatrimuc" + "\r\n"
+ " from ChiTietPhuCap_NhanVien ctpc inner join nhanvien nv on nv.idnhanvien=ctpc.idnhanvien" + "\r\n"
+ " inner join danhmucphucap pc on pc.idphucap=ctpc.idphucap" + "\r\n"
+ " left join phongban pb on pb.idphongban=nv.idphongban" + "\r\n"
+ " left join chucvu cv on cv.idchucvu=nv.idchucvu" + "\r\n"
+ " where pc.idphucap=2 and nv.status=1 " + where + "" + "\r\n";
                 dt = DataAcess.Connect.GetTable(sql);
            }
            dgr.DataSource = dt;
            dgr.DataBind();
            //}
            if (dt.Rows.Count > 0)
            {
                txtThangHidden.Value = ddlThang.SelectedValue;
                txtNamHidden.Value = ddlNam.SelectedValue;
                lbThangNam.Text = "Tháng " + ddlThang.SelectedValue + "/" + ddlNam.SelectedValue;
                btnExcel.Visible = true;
                btnLuuPhuCap.Visible = true;
            }
            else
            {
                txtThangHidden.Value = "";
                txtNamHidden.Value = "";
                lbThangNam.Text = "";
                btnExcel.Visible = false;
                btnLuuPhuCap.Visible = false;
            }
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
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        int idNhanVien;

        idNhanVien = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string idPhuCap = ((TextBox)e.Item.Cells[8].FindControl("txtIdPhuCap")).Text;
        string MucLuongCoBan = ((TextBox)e.Item.Cells[9].FindControl("txtMucLuongCoBan")).Text;
        string GiaTriMuc = ((TextBox)e.Item.Cells[9].FindControl("txtGiaTriMuc")).Text;
        string TienPhucap = ((TextBox)e.Item.Cells[9].FindControl("txtTienPhucap")).Text;
        //StaticData.MsgBox(this,"Chi tiết cho xem j nhỉ ?!!!. Tháng/Năm:"+txtThangHidden.Value +"/"+txtNamHidden.Value);
        string LinkName = "";// "frpt_ChiTietLuongNhanVien.aspx?IdNhanVien=" + idNhanVien.ToString() + "&Thang=" + txtThangHidden.Value + "&Nam=" + txtNamHidden.Value + "";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mak", "window.open (\"" + LinkName + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no')", true);
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        if (dgr.Items.Count > 0)
        {
            string filename = "Danh sach phu cap trach nhiem thang " + txtThangHidden.Value + "/" + txtNamHidden.Value;
            string tcty = "BỆNH VIỆN MINH ĐỨC";
            string khoa = "Phòng Nhân Sự";
            string header = "DANH SÁCH PHỤ CẤP TRÁCH NHIỆM THÁNG " + txtThangHidden.Value + "/" + txtNamHidden.Value;
            string strNhanSu = "GĐ.Nhân Sự";
            clsExport.exprortToExcelDataGrid(filename, tcty, khoa, header, dgr, strNhanSu);
        }
        else
        {
            StaticData.MsgBox(this, "Chưa có danh sách phụ cấp !");
        }
    }
}
