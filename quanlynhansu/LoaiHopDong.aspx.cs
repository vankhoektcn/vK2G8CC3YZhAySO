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

public partial class NhanSu_LoaiHopDong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) bindGrid();
    }
    protected void bindGrid()
    {
        DataTable tb = DataAcess.Connect.GetTable("select *  from loaihopdong where status=1 order by tenloaihopdong");
        gidLoaiHD.DataSource = tb;
        gidLoaiHD.DataBind();
    }
    protected void setLoaiHD(DataTable dt)
    {
        if (dt.Rows.Count <= 0) return;
        txtidLoaiHD.Text = dt.Rows[0]["idloaihopdong"].ToString();
        txtTenLoaiHD.Text = dt.Rows[0]["tenloaihopdong"].ToString();
        txtGhiChu.Text = dt.Rows[0]["ghichu"].ToString();       
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (txtTenLoaiHD.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null,"alert('Tên loại hợp đồng chưa nhập');", true);
            return;
        }
        if (txtidLoaiHD.Text == "")
        {    int idLHD = CreateId();
             NhanSu_Process.LoaiHopDong clv = NhanSu_Process.LoaiHopDong.Insert_Object(idLHD.ToString(), txtTenLoaiHD.Text.Trim(), txtGhiChu.Text.Trim(), "1");
             if (clv == null)
                 ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        else
        {
            NhanSu_Process.LoaiHopDong update = new NhanSu_Process.LoaiHopDong();
            update.idloaihopdong = txtidLoaiHD.Text;
            bool kq= update.Save_Object(txtidLoaiHD.Text.Trim(), txtTenLoaiHD.Text.Trim(), txtGhiChu.Text.Trim(), "1");
            if (!kq)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        bindGrid();
    }
    protected int CreateId()
    {
        string sql = "select max(idloaihopdong) from loaihopdong";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        if (tb.Rows.Count <= 0 || tb.Rows[0][0].ToString() == "") return 1;
        return int.Parse(tb.Rows[0][0].ToString()) + 1;
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        txtidLoaiHD.Text = "";
        txtGhiChu.Text = "";
        txtTenLoaiHD.Text = "";
    }
    protected void btnXoan_Click(object sender, EventArgs e)
    {
        NhanSu_Process.LoaiHopDong update = new NhanSu_Process.LoaiHopDong();
        update.idloaihopdong = txtidLoaiHD.Text;
        update.Update_status("0");
        bindGrid();
    }
    protected void bntTim_Click(object sender, EventArgs e)
    {
        string strS = "select * from loaihopdong where status=1";        
        if (txtTenLoaiHD.Text != "") strS += " and tenloaihopdong like N'%" + txtTenLoaiHD.Text.Trim() + "%'";
        if (txtGhiChu.Text != "") strS += " and ghichu=N'" + txtGhiChu.Text.Trim() + "'";
        strS += " order by tenloaihopdong ";
        DataTable tb = DataAcess.Connect.GetTable(strS);
        if (tb.Rows.Count < 1) return;
        else if (tb.Rows.Count == 1) { setLoaiHD(tb); gidLoaiHD.DataSource = tb; gidLoaiHD.DataBind(); }
        else { gidLoaiHD.DataSource = tb; gidLoaiHD.DataBind(); }
    }
    protected void gidLoaiHD_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sua")
        {
            string id = e.CommandArgument.ToString();
            DataTable dt = NhanSu_Process.LoaiHopDong.dtSearchByidloaihopdong(id);
            setLoaiHD(dt);
        }
    }
    protected void gidLoaiHD_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NhanSu_Process.LoaiHopDong update = new NhanSu_Process.LoaiHopDong();
        update.idloaihopdong = gidLoaiHD.DataKeys[e.RowIndex].Value.ToString(); 
        update.Update_status("0");
        bindGrid();
    }
    protected void gidLoaiHD_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = gidLoaiHD.DataKeys[e.NewSelectedIndex].Value.ToString();
        DataTable dt = NhanSu_Process.LoaiHopDong.dtSearchByidloaihopdong(id);        
        setLoaiHD(dt);
    }
}
