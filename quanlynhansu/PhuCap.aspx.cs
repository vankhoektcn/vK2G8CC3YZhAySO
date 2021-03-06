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

public partial class NhanSu_PhuCap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) bindGrid();
    }
    protected void bindGrid()
    {
        DataTable tb = DataAcess.Connect.GetTable("select idphucap,tenphucap from danhmucphucap where status=1 order by tenphucap");
        gidPhuCap.DataSource = tb;
        gidPhuCap.DataBind();
    }
    protected void setPhuCap(DataTable dt)
    {
        if (dt.Rows.Count <= 0) return;
        txtidPhuCap.Text = dt.Rows[0]["idphucap"].ToString();
        txtTenPC.Text = dt.Rows[0]["tenphucap"].ToString();      
    }   
    protected int CreateId()
    {
        string sql = "select max(idphucap) from danhmucphucap";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        if (tb.Rows.Count <= 0 || tb.Rows[0][0].ToString() == "") return 1;
        return int.Parse(tb.Rows[0][0].ToString()) + 1;
    }   
    protected void gidPhuCap_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = gidPhuCap.DataKeys[e.NewSelectedIndex].Value.ToString();
        DataTable dt = NhanSu_Process.DanhMucPhuCap.dtSearchByidPhuCap(id);
        setPhuCap(dt);
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (txtTenPC.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Tên phụ cấp chưa nhập');", true);
            return;
        }       
        if (txtidPhuCap.Text == "")
        {
            int idPC = CreateId();
            NhanSu_Process.DanhMucPhuCap clv = NhanSu_Process.DanhMucPhuCap.Insert_Object(idPC.ToString(), txtTenPC.Text.Trim(),"1");
            if (clv == null)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        else
        {
            NhanSu_Process.DanhMucPhuCap update = new NhanSu_Process.DanhMucPhuCap();
            update.idPhuCap = txtidPhuCap.Text.Trim();
            bool kq= update.Save_Object(txtidPhuCap.Text.Trim(), txtTenPC.Text.Trim(),"1");
            if (!kq)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        bindGrid();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        txtidPhuCap.Text = "";
        txtTenPC.Text = "";
       
    }
    protected void btnXoan_Click(object sender, EventArgs e)
    {
        NhanSu_Process.DanhMucPhuCap update = new NhanSu_Process.DanhMucPhuCap();
        update.idPhuCap = txtidPhuCap.Text.Trim();
        update.Update_status("0");
        bindGrid();
    }
    protected void bntTim_Click(object sender, EventArgs e)
    {
        string strS = "select idphucap,tenphucap from danhmucphucap where status=1";
        if (txtTenPC.Text.Trim() != "") strS += " and tenphucap like N'%" + txtTenPC.Text.Trim() + "%'";       
        strS += " order by tenphucap ";
        DataTable tb = DataAcess.Connect.GetTable(strS);
        if (tb.Rows.Count < 1) return;
        else if (tb.Rows.Count == 1) { setPhuCap(tb); gidPhuCap.DataSource = tb; gidPhuCap.DataBind(); }
        else { gidPhuCap.DataSource = tb; gidPhuCap.DataBind(); }
    }
    protected void gidPhuCap_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NhanSu_Process.DanhMucPhuCap update = new NhanSu_Process.DanhMucPhuCap();
        update.idPhuCap = gidPhuCap.DataKeys[e.RowIndex].Value.ToString();
        update.Update_status("0");
        bindGrid();
    }
}
