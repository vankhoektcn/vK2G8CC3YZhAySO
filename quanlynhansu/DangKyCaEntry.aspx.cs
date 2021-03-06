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

public partial class NhanSu_DangKyCaEntry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindCaLamViec();
            bindNhanVien();
            bindGrid();
        }
    }
    void bindCaLamViec()
    {
        DataTable tb = DataAcess.Connect.GetTable("select idcalamviec,tencalamviec from calamviec where status=1");
        StaticData.FillCombo(ddlCaLamViec, tb, "idcalamviec", "tencalamviec", "Chọn ca");
    }
    void bindNhanVien()
    {
        DataTable tb = DataAcess.Connect.GetTable("select idnhanvien,TENNHANVIEN from NHANVIEN where status=1");
        StaticData.FillCombo(ddlNhanVien, tb, "IDNHANVIEN", "TENNHANVIEN", "Chọn nhân viên");
    }
    protected void bindGrid()
    {
        string sql = ""
        + " select ROW_NUMBER() OVER (ORDER BY nv.idnhanvien) AS STT,iddangkyca,nv.tennhanvien,tencalamviec,thu" + "\r\n"
        + " from dangkyca dkc " + "\r\n"
        + " left join nhanvien nv on nv.idnhanvien=dkc.idnhanvien" + "\r\n"
        + " left join calamviec clv on clv.idcalamviec=dkc.idcalamviec" + "\r\n"
        + " where dkc.status=1" + "\r\n"
        //+ " order by iddangkyca desc" + "\r\n"
        + " " + "\r\n";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        gidDangKyCa.DataSource = tb;
        gidDangKyCa.DataBind();
    }
    protected void setDangKyCa(DataTable dt)
    {
        if (dt.Rows.Count <= 0) return;
        txtidDangKyCa.Text = dt.Rows[0]["iddangkyca"].ToString().Trim();
        ddlCaLamViec.SelectedValue = dt.Rows[0]["idcalamviec"].ToString();
        ddlNhanVien.SelectedValue = dt.Rows[0]["idnhanvien"].ToString();
        txtThu.Text = dt.Rows[0]["thu"].ToString();        
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (ddlNhanVien.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa chọn nhân viên');", true);
            return;
        }
        if (ddlCaLamViec.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Chưa chọn ca');", true);
            return;
        }
        if (txtidDangKyCa.Text == "")
        {
            string idPC = StaticData.MaxIdNhanSuTheoTable("dangkyca","iddangkyca");
            NhanSu_Process.DangKyCa clv = NhanSu_Process.DangKyCa.Insert_Object(idPC,ddlNhanVien.SelectedValue,ddlCaLamViec.SelectedValue,txtThu.Text.Trim(),"1");
            if (clv == null)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        else
        {
            NhanSu_Process.DangKyCa update = new NhanSu_Process.DangKyCa();
            update.iddangkyca = txtidDangKyCa.Text.Trim();
            bool kq= update.Save_Object(txtidDangKyCa.Text.Trim(), ddlNhanVien.SelectedValue, ddlCaLamViec.SelectedValue, txtThu.Text.Trim(), "1");
            if (!kq)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        bindGrid();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        ddlCaLamViec.SelectedIndex = 0;
        ddlNhanVien.SelectedIndex = 0;
        txtidDangKyCa.Text = "";
        txtThu.Text = "";
    }
    protected void btnXoan_Click(object sender, EventArgs e)
    {
        NhanSu_Process.DangKyCa update = new NhanSu_Process.DangKyCa();
        update.iddangkyca = txtidDangKyCa.Text.Trim();
        update.Update_status("0");
        bindGrid();
    }
    protected void bntTim_Click(object sender, EventArgs e)
    {
        string strS = ""
        + " select ROW_NUMBER()OVER (ORDER BY nv.idnhanvien) AS STT,iddangkyca,nv.tennhanvien,tencalamviec,thu,dkc.idcalamviec,dkc.idnhanvien" + "\r\n"
        + " from dangkyca dkc " + "\r\n"
        + " left join nhanvien nv on nv.idnhanvien=dkc.idnhanvien" + "\r\n"
        + " left join calamviec clv on clv.idcalamviec=dkc.idcalamviec" + "\r\n"
        + " where dkc.status=1" + "\r\n";
        if (ddlNhanVien.SelectedIndex > 0) strS += " and dkc.idnhanvien = '" + ddlNhanVien.SelectedValue + "'";
        if (ddlCaLamViec.SelectedIndex > 0) strS += " and dkc.idcalamviec = '" + ddlCaLamViec.SelectedValue + "'";
        if (txtThu.Text.Trim() != "") strS += " and thu ='" + txtThu.Text.Trim() + "'";       
        strS += " order by iddangkyca ";
        DataTable tb = DataAcess.Connect.GetTable(strS);
        if (tb.Rows.Count < 1) return;
        else if (tb.Rows.Count == 1) { setDangKyCa(tb); gidDangKyCa.DataSource = tb; gidDangKyCa.DataBind(); }
        else { gidDangKyCa.DataSource = tb; gidDangKyCa.DataBind(); }
    }

    protected void gidDangKyCa_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = gidDangKyCa.DataKeys[e.NewSelectedIndex].Value.ToString();
        DataTable dt = NhanSu_Process.DangKyCa.dtSearchByiddangkyca(id);
        setDangKyCa(dt);
    }
    protected void gidDangKyCa_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NhanSu_Process.DangKyCa update = new NhanSu_Process.DangKyCa();
        update.iddangkyca = gidDangKyCa.DataKeys[e.RowIndex].Value.ToString();
        update.Update_status("0");
        bindGrid();
    }
    //TRUONGNHAT-PC
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string filename = "DSHDNhanVien";
        string tcty = "BỆNH ĐA KHOA VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH NHÂN VIÊN ĐĂNG KÝ CA LÀM VIỆC";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcel(filename, tcty, khoa, header, gidDangKyCa, strNhanSu);
    }
}
