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

public partial class NhanSu_DanhGiaCuoiNam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindNhanVien();
            bindXepLoai();
            bindGrid();
        }    
    }
    void bindNhanVien()
    {
        DataTable tb = DataAcess.Connect.GetTable("select idnhanvien,TENNHANVIEN from NHANVIEN where status=1");
        StaticData.FillCombo(ddlNhanVien, tb, "IDNHANVIEN", "TENNHANVIEN", "Chọn nhân viên");
    }
    void bindXepLoai()
    {
        DataTable tb = DataAcess.Connect.GetTable("select idxeploai,tenxeploai from xeploai where status=1");
        StaticData.FillCombo(ddlXepLoai, tb, "idxeploai", "tenxeploai", "Chọn xếp loại");
    }
    protected void bindGrid()
    {
        string sql = ""
        + " select ROW_NUMBER ( ) OVER(ORDER BY iddanhgia) AS STT,dg.iddanhgia,dg.idnhanvien,dg.idxeploai,tennhanvien,tenxeploai,dg.ghichu" + "\r\n"
        +" from danhgiacuoinam dg" + "\r\n"
        +" left join nhanvien nv on nv.idnhanvien=dg.idnhanvien" + "\r\n"
        +" left join xeploai xl on xl.idxeploai=dg.idxeploai" + "\r\n"
        +" where dg.status=1" + "\r\n"
        +" order by iddanhgia asc" + "\r\n";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        gidDanhGiaCuoiNam.DataSource = tb;
        gidDanhGiaCuoiNam.DataBind();
    }
    protected void setDanhGiaCuoiNam(DataTable dt)
    {
        if (dt.Rows.Count <= 0) return;
        txtidDanhGiaCuoiNam.Text = dt.Rows[0]["iddanhgia"].ToString().Trim();
        ddlXepLoai.SelectedValue = dt.Rows[0]["idxeploai"].ToString();
        ddlNhanVien.SelectedValue = dt.Rows[0]["idnhanvien"].ToString();
        txtGhiChu.Text = dt.Rows[0]["ghichu"].ToString();
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (ddlXepLoai.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa chọn xếp loại');", true);
            return;
        }
        if (ddlNhanVien.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa chọn nhân viên');", true);
            return;
        }
        if (txtidDanhGiaCuoiNam.Text == "")
        {
            string idPC = StaticData.MaxIdNhanSuTheoTable("danhgiacuoinam", "iddanhgia");
            NhanSu_Process.DanhGiaCuoiNam clv = NhanSu_Process.DanhGiaCuoiNam.Insert_Object(idPC, ddlNhanVien.SelectedValue,ddlXepLoai.SelectedValue,txtGhiChu.Text.Trim(), "1");
            if (clv == null)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        else
        {
            NhanSu_Process.DanhGiaCuoiNam update = new NhanSu_Process.DanhGiaCuoiNam();
            update.iddanhgia = txtidDanhGiaCuoiNam.Text.Trim();
            bool kq= update.Save_Object(txtidDanhGiaCuoiNam.Text.Trim(), ddlNhanVien.SelectedValue, ddlXepLoai.SelectedValue, txtGhiChu.Text.Trim(), "1");
            if (!kq)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        bindGrid();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        ddlXepLoai.SelectedIndex = 0;
        ddlNhanVien.SelectedIndex = 0;
        txtGhiChu.Text = "";
        txtidDanhGiaCuoiNam.Text = "";        
    }
    protected void btnXoan_Click(object sender, EventArgs e)
    {
        NhanSu_Process.DanhGiaCuoiNam update = new NhanSu_Process.DanhGiaCuoiNam();
        update.iddanhgia = txtidDanhGiaCuoiNam.Text.Trim();
        update.Update_status("0");
        bindGrid();
    }
    protected void bntTim_Click(object sender, EventArgs e)
    {
        string strS = ""
        + " select dg.iddanhgia,dg.idnhanvien,dg.idxeploai,tennhanvien,tenxeploai,dg.ghichu" + "\r\n"
        + " from danhgiacuoinam dg" + "\r\n"
        + " left join nhanvien nv on nv.idnhanvien=dg.idnhanvien" + "\r\n"
        + " left join xeploai xl on xl.idxeploai=dg.idxeploai" + "\r\n"
        + " where dg.status=1" + "\r\n";
        if (ddlNhanVien.SelectedIndex > 0) strS += " and dg.idnhanvien = '" + ddlNhanVien.SelectedValue + "'";
        if (ddlXepLoai.SelectedIndex > 0) strS += " and dg.idxeploai = '" + ddlXepLoai.SelectedValue + "'";
        if (txtGhiChu.Text.Trim() != "") strS += " and dg.ghichu like N'%" + txtGhiChu.Text.Trim() + "%'";
        strS += " order by iddanhgia desc" + "\r\n";
        DataTable tb = DataAcess.Connect.GetTable(strS);
        if (tb.Rows.Count < 1) return;
        else if (tb.Rows.Count == 1) { setDanhGiaCuoiNam(tb); gidDanhGiaCuoiNam.DataSource = tb; gidDanhGiaCuoiNam.DataBind(); }
        else { gidDanhGiaCuoiNam.DataSource = tb; gidDanhGiaCuoiNam.DataBind(); }
    }
    protected void gidDanhGiaCuoiNam_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = gidDanhGiaCuoiNam.DataKeys[e.NewSelectedIndex].Value.ToString();
        DataTable dt = NhanSu_Process.DanhGiaCuoiNam.dtSearchByiddanhgia(id);
        setDanhGiaCuoiNam(dt);
    }
    protected void gidDanhGiaCuoiNam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NhanSu_Process.DanhGiaCuoiNam update = new NhanSu_Process.DanhGiaCuoiNam();
        update.iddanhgia = gidDanhGiaCuoiNam.DataKeys[e.RowIndex].Value.ToString();
        update.Update_status("0");
        bindGrid();
    }
    //TRUONGNHAT-PC
    //XUAT DU LIEU RA EXCEL
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string filename = "DSHDNhanVien";
        string tcty = "BỆNH VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH ĐÁNH GIÁ NHÂN VIÊN CUỐI NĂM";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcel(filename, tcty, khoa, header, gidDanhGiaCuoiNam, strNhanSu);
    }
}
