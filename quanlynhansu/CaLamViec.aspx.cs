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

public partial class CaLamViec : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        bindGrid();
    }


    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (txttenCaLamviec.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Tên ca làm việc chưa nhập');", true);
            return;
        }
        if(txtidCaLamviec.Text=="")
        {
            int idCLV=CreateIdCLV();            
            NhanSu_Process.CaLamViec clv = NhanSu_Process.CaLamViec.Insert_Object(idCLV.ToString(), txttenCaLamviec.Text, txtngauThu.Text, txttuGio.Text, txtdenGio.Text,"1");
            if (clv == null)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        else
        {
            NhanSu_Process.CaLamViec update = new NhanSu_Process.CaLamViec();            
            update.idcalamviec = txtidCaLamviec.Text;
            bool kq= update.Save_Object(txtidCaLamviec.Text, txttenCaLamviec.Text, txtngauThu.Text, txttuGio.Text, txtdenGio.Text,"1");
            if (!kq)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), null, "alert('Đã có lỗi trong quá trình lưu');", true);
        }
        bindGrid();
    }
    protected int CreateIdCLV()
    {
        string sql = "select max(idcalamviec) from calamviec";
        DataTable tb = DataAcess.Connect.GetTable(sql);
        if (tb.Rows.Count <= 0 || tb.Rows[0][0].ToString()=="") return 1;        
        return int.Parse(tb.Rows[0][0].ToString())+1;
    }
    protected void bindGrid()
    {
        DataTable tb = DataAcess.Connect.GetTable("select 'Mã'=idcalamviec,'Tên Ca'=tencalamviec,'Ngày thu'=ngaythu,'Từ giờ'=tugio,'Đến giờ'=dengio  from calamviec where status=1");
        gidCaLamViec.DataSource = tb;
        gidCaLamViec.DataBind();
    }
    
    protected void setCaLamViec(DataTable dt)
    {
        if (dt.Rows.Count <= 0) return;
        txtidCaLamviec.Text = dt.Rows[0]["Mã"].ToString();
        txttenCaLamviec.Text = dt.Rows[0]["Tên Ca"].ToString();
        txtngauThu.Text = dt.Rows[0]["Ngày thu"].ToString();
        txttuGio.Text = dt.Rows[0]["Từ giờ"].ToString();
        txtdenGio.Text = dt.Rows[0]["Đến giờ"].ToString();        
    }
    

    protected void gidCaLamViec_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string strS = "select 'Mã'=idcalamviec,'Tên Ca'=tencalamviec,'Ngày thu'=ngaythu,'Từ giờ'=tugio,'Đến giờ'=dengio from calamviec where status=1";
        strS += " and idcalamviec='" + gidCaLamViec.Rows[e.NewSelectedIndex].Cells[2].Text + "'";
        DataTable tb = DataAcess.Connect.GetTable(strS);
        setCaLamViec(tb);
    }

    protected void gidCaLamViec_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        NhanSu_Process.CaLamViec update = new NhanSu_Process.CaLamViec();
        if(e.RowIndex!=-1)
        update.idcalamviec = gidCaLamViec.Rows[e.RowIndex].Cells[2].Text;
        update.Update_status("0");
        bindGrid();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        txtidCaLamviec.Text = "";
        txttenCaLamviec.Text = "";
        txtngauThu.Text = "";
        txttuGio.Text = "";
        txtdenGio.Text = "";      

    }
    protected void bntTim_Click(object sender, EventArgs e)
    {
        string strS = "select 'Mã'=idcalamviec,'Tên Ca'=tencalamviec,'Ngày thu'=ngaythu,'Từ giờ'=tugio,'Đến giờ'=dengio from calamviec where status=1";        
        if (txttenCaLamviec.Text != "") strS += " and tencalamviec like N'%" + txttenCaLamviec.Text.Trim() + "%'";
        if (txtngauThu.Text != "") strS += " and ngaythu=N'" + txtngauThu.Text.Trim() + "'";
        if (txttuGio.Text != "") strS += " and tugio='" + txttuGio.Text.Trim() + "'";
        if (txtdenGio.Text != "") strS += " and dengio='" + txtdenGio.Text.Trim() + "'";
        DataTable tb = DataAcess.Connect.GetTable(strS);
        if (tb.Rows.Count < 1) return;
        else if (tb.Rows.Count == 1) { setCaLamViec(tb); gidCaLamViec.DataSource = tb; gidCaLamViec.DataBind(); }
        else { gidCaLamViec.DataSource = tb; gidCaLamViec.DataBind(); }
        
        
    }
    protected void btnXoan_Click(object sender, EventArgs e)
    {
        NhanSu_Process.CaLamViec update = new NhanSu_Process.CaLamViec();
        update.idcalamviec = txtidCaLamviec.Text;
        update.Update_status("0");
        bindGrid();
    }
}
