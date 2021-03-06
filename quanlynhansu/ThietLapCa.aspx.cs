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

public partial class NhanSu_ThietLapCa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindCaLamViec();
            bindPhongBan();
            bindGrid();
        }
    }
    void bindPhongBan()
    {
        DataTable tb = DataAcess.Connect.GetTable("select idphongban,tenphongban from phongban where status=1");
        StaticData.FillCombo(ddlPhongBan, tb, "idphongban", "tenphongban", "Chọn phòng ban");
    }
    void bindCaLamViec()
    {
        DataTable tb = DataAcess.Connect.GetTable("select idcalamviec,tencalamviec from calamviec where status=1");
        StaticData.FillCombo(ddlCaLamViec, tb, "idcalamviec", "tencalamviec", "Chọn ca");
    }
    protected void bindGrid()
    {
        string sql = ""
        + " select idthietlapca,tenphongban,tlc.ngaythu,convert(varchar,tungay,103)as tungay,convert(varchar,denngay,103)as denngay,tencalamviec,sonhanvien" + "\r\n"
        + " from thietlapca tlc" + "\r\n"
        + " left join phongban pb on pb.idphongban=tlc.idphongban" + "\r\n"
        + " left join calamviec clv on clv.idcalamviec=tlc.idcalamviec" + "\r\n"
        + " where tlc.status=1" + "\r\n"
        + " order by idthietlapca desc" + "\r\n";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        gidThietLapCa.DataSource = tb;
        gidThietLapCa.DataBind();
    }
    protected void setThietLapCa(DataTable dt)
    {
        if (dt.Rows.Count <= 0) return;
        txtidThietLapCa.Text = dt.Rows[0]["idthietlapca"].ToString().Trim();
        ddlPhongBan.SelectedValue = dt.Rows[0]["idphongban"].ToString();
        txtNgayThu.Text = dt.Rows[0]["ngaythu"].ToString();
        txtTuNgay.Text = dt.Rows[0]["tungay"].ToString();
        txtDenNgay.Text = dt.Rows[0]["denngay"].ToString();
        ddlCaLamViec.SelectedValue = dt.Rows[0]["idcalamviec"].ToString();
        txtSoNhanVien.Text = dt.Rows[0]["sonhanvien"].ToString();
    }
    protected int CreateId()
    {
        string sql = "select max(idthietlapca) from thietlapca";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        if (tb.Rows.Count <= 0 || tb.Rows[0][0].ToString() == "") return 1;
        return int.Parse(tb.Rows[0][0].ToString()) + 1;
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (ddlPhongBan.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa chọn phòng ban');", true);
            return;
        }
        if (ddlCaLamViec.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa chọn ca');", true);
            return;
        }        
        if (txtidThietLapCa.Text == "")
        {
            int idPC = CreateId();
            NhanSu_Process.ThietLapCa clv = NhanSu_Process.ThietLapCa.Insert_Object(idPC.ToString(), ddlPhongBan.SelectedValue.ToString(), txtNgayThu.Text.Trim()
            ,StaticData.CheckDate(txtTuNgay.Text.Trim()),StaticData.CheckDate(txtDenNgay.Text.Trim()),ddlCaLamViec.SelectedValue.ToString(),txtSoNhanVien.Text.Trim(), "1");
            if (clv == null)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        else
        {
            NhanSu_Process.ThietLapCa update = new NhanSu_Process.ThietLapCa();
            update.idthietlapca = txtidThietLapCa.Text.Trim();
            bool kq= update.Save_Object(txtidThietLapCa.Text.Trim(), ddlPhongBan.SelectedValue.ToString(), txtNgayThu.Text.Trim()
            , txtTuNgay.Text.Trim(), txtDenNgay.Text.Trim(), ddlCaLamViec.SelectedValue.ToString(), txtSoNhanVien.Text.Trim(), "1");
            if (!kq)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        bindGrid();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        txtidThietLapCa.Text = "";
        txtDenNgay.Text = "";
        txtNgayThu.Text = "";
        txtSoNhanVien.Text = "";
        txtTuNgay.Text = "";
        txtDenNgay.Text = "";
        ddlCaLamViec.SelectedIndex = 1;
        ddlPhongBan.SelectedIndex = 1;
    }
    protected void btnXoan_Click(object sender, EventArgs e)
    {
        NhanSu_Process.ThietLapCa update = new NhanSu_Process.ThietLapCa();
        update.idthietlapca = txtidThietLapCa.Text.Trim();
        update.Update_status("0");
        bindGrid();
    }
    protected void bntTim_Click(object sender, EventArgs e)
    {
        string strS = ""
        + " select idthietlapca,tenphongban,tlc.ngaythu,convert(varchar,tungay,103)as tungay,convert(varchar,denngay,103)as denngay,tencalamviec,sonhanvien" + "\r\n"
        + " from thietlapca tlc" + "\r\n"
        + " left join phongban pb on pb.idphongban=tlc.idphongban" + "\r\n"
        + " left join calamviec clv on clv.idcalamviec=tlc.idcalamviec" + "\r\n"
        + " where tlc.status=1" + "\r\n";
        if (ddlPhongBan.SelectedIndex>0) strS += " and tlc.idphongban = '" + ddlPhongBan.SelectedValue + "'";
        if (ddlCaLamViec.SelectedIndex > 0) strS += " and tlc.idcalamviec = '" + ddlCaLamViec.SelectedValue + "'";
        if (txtDenNgay.Text.Trim() != "") strS += " and tlc.denngay ='" +StaticData.CheckDate(txtDenNgay.Text.Trim()) + "'";
        if (txtTuNgay.Text.Trim() != "") strS += " and tlc.tungay ='" + StaticData.CheckDate(txtTuNgay.Text.Trim()) + "'";
        if (txtNgayThu.Text.Trim() != "") strS += " and tlc.ngaythu='" + txtNgayThu.Text.Trim() + "'";
        if (txtSoNhanVien.Text.Trim() != "") strS += " and tlc.sonhanvien='" + txtSoNhanVien.Text.Trim() + "'";
        strS += " order by idthietlapca ";
        DataTable tb = DataAcess.Connect.GetTable(strS);
        if (tb.Rows.Count < 1) return;
        else if (tb.Rows.Count == 1) { setThietLapCa(tb); gidThietLapCa.DataSource = tb; gidThietLapCa.DataBind(); }
        else { gidThietLapCa.DataSource = tb; gidThietLapCa.DataBind(); }
    }
    protected void gidThietLapCa_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = gidThietLapCa.DataKeys[e.NewSelectedIndex].Value.ToString();
        DataTable dt = NhanSu_Process.ThietLapCa.dtSearchByidthietlapca(id);
        setThietLapCa(dt);
    }
    protected void gidThietLapCa_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NhanSu_Process.ThietLapCa update = new NhanSu_Process.ThietLapCa();
        update.idthietlapca = gidThietLapCa.DataKeys[e.RowIndex].Value.ToString();
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
        string filename = "DSTangCa";
        string tcty = "BỆNH VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH NHÂN VIÊN ĐĂNG KÝ TĂNG CA";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcel(filename, tcty, khoa, header, gidThietLapCa, strNhanSu);
    }
}
