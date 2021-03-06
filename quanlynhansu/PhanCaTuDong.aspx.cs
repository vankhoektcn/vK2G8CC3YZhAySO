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
public partial class PhanCaTuDong : System.Web.UI.Page
{
   string strSearch;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            strSearch = "";
            BinListThietLapCa();
            BindListLoaiTangCa();
            BindListPhongBan();
            
            pnl1.Visible = false;
            txtNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtNgayHienTai.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            BinListThietLapCa();
            btnLuu.Attributes.Add("display","none");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "LoadThoiGianCa();", true);
        }
    }
    private void BindListLoaiTangCa()
    {
        string sql = "select * from calamviec where status=1";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlLoaiTangCa, dt, "idcalamviec", "tencalamviec", "------Chọn ca------");
            
        }
    }
    private void BindListPhongBan()
    {
        string sql = "select * from phongban where status=1";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlPhongBan, dt, "idphongban", "tenphongban", "------Chọn phòng ban------");
            //ddlPhongBan.DataSource = dt;
            //ddlPhongBan.DataTextField = "tenphongban";
            //ddlPhongBan.DataValueField = "idphongban";
            //ddlPhongBan.DataBind();
            //ddlPhongBan.Items.Insert(0, "------Chọn phòng ban------");
        }
    }
    private void BinListThietLapCa()
    {
        string select = ""
+ " select" + "\r\n"
+ " idcalamviec, tencalamviec ,tugio ,dengio,ngay, count(idnhanvien) as sonhanvien, xoa" + "\r\n"
+ " from" + "\r\n"
+ " ( " + "\r\n"
+ " select clv.idcalamviec" + "\r\n"
+ "  ,tencalamviec" + "\r\n"
+ "  ,tugio" + "\r\n"
+ "  ,dengio" + "\r\n"
+ "  ,ngay=convert(varchar,pc.ngaythangnam,103)" + "\r\n"
+ "  ,pc.idnhanvien" + "\r\n"
+ "  ,case when isnull((select top 1 idphanca from bangchamcong where idphanca=pc.idphanca),0)=0 then N'Xóa' else null end as xoa " + "\r\n"
+ "  from phanca pc left join calamviec clv on clv.idcalamviec=pc.idcalamviec" + "\r\n"
+ "  ) abc" + "\r\n"
+ " group by abc.idcalamviec,abc.ngay,tencalamviec,tugio ,dengio, xoa" + "\r\n"
+ " order by convert(datetime,abc.ngay,103) desc" + "\r\n";
        DataTable dtCTPhieuVOVAN_DKMmatDay=null;
        dtCTPhieuVOVAN_DKMmatDay = DataAcess.Connect.GetTable(select);
        dgr.DataSource = dtCTPhieuVOVAN_DKMmatDay;
        dgr.DataBind();
    }
    
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/khambenh/PhanNhomBacSi.aspx");
    }
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        int idCaLamViec;
        idCaLamViec = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string NgayLamCa = ((Label)e.Item.Cells[1].FindControl("lbNgayLamca")).Text.Trim();
        //Thông tin Tang ca
        string selectPhanCa = "select pc.*,convert(varchar,ngaythangnam,103)as ngay from PhanCa pc where convert(varchar,ngaythangnam,103)='"+NgayLamCa+"' and pc.idcalamviec=" + idCaLamViec;
        DataTable dtPhanCa = DataAcess.Connect.GetTable(selectPhanCa);
        if (dtPhanCa.Rows.Count > 0)
        {
            ddlLoaiTangCa.SelectedValue = dtPhanCa.Rows[0]["idcalamviec"].ToString();
            //ddlTuGio.SelectedIndex = ddlTuGio.Items.IndexOf(ddlTuGio.Items.FindByText(dtTC.Rows[0]["tugio"].ToString().Trim()));
            //ddlDenGio.SelectedIndex = ddlDenGio.Items.IndexOf(ddlDenGio.Items.FindByText(dtTC.Rows[0]["dengio"].ToString().Trim()));

            txtNgay.Text = dtPhanCa.Rows[0]["ngay"].ToString();
            txtDenNgay.Text = dtPhanCa.Rows[0]["ngay"].ToString();
            //Thông tin Nhan vien
            string listID = "";

            for (int i = 0; i < dtPhanCa.Rows.Count; i++)
                listID += dtPhanCa.Rows[i]["idnhanvien"] + ",";
            listIdNV.Value = listID;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_mskh", "showKQCLS();", true);  //không tác dụng
            string selectGio = "select * from CalamViec where idcalamviec="+ddlLoaiTangCa.SelectedValue;
            DataTable dtGio = DataAcess.Connect.GetTable(selectGio);
            txtTuGio.Value = dtGio.Rows[0]["tugio"].ToString().Trim();
            txtDenGio.Value = dtGio.Rows[0]["dengio"].ToString().Trim();
            txtidTangCa.Value = idCaLamViec.ToString();
            btnLuu.Visible = false;
            btnUpDate.Visible = true;
        }
    }
    public void DelTangCa(object s, DataGridCommandEventArgs e)
    {
        int idcalamviec;
        idcalamviec = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        string NgayLamCa = ((Label)e.Item.Cells[1].FindControl("lbNgayLamca")).Text.Trim();
        string sqlDelete = "delete from  phanca  where convert(varchar,ngaythangnam,103)='" + NgayLamCa + "' and idcalamviec=" + idcalamviec;
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BinListThietLapCa();
        }
        else
            StaticData.MsgBox(this, "Có lỗi khi xóa !");

    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnDel"));
            btn.Attributes.Add("onclick", "return ConfirmDelete();");
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //e.Item.Cells[8].Text = StaticData.FormatNumber(e.Item.Cells[8].Text, false).ToString();
            }
        }

    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BinListThietLapCa();
    }
    #endregion    
    protected void btnTim_Click(object sender, EventArgs e)
    {
        string select = "";
        string Search="";
        if (txtNgay.Text.Trim() != "" && txtDenNgay.Text.Trim() != "")
        {
            try
            {
                DateTime date = DateTime.ParseExact(txtNgay.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                DateTime date1 = DateTime.ParseExact(txtDenNgay.Text.Trim(), new string[] { "dd/MM/yyyy" }, CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                Search =" and pc.ngaythangnam >='"+StaticData.CheckDate(txtNgay.Text.Trim())+"' and pc.ngaythangnam <'"+StaticData.CheckDate(txtDenNgay.Text.Trim())+ " 23:59:59'";
            }
            catch (Exception)
            {
                StaticData.MsgBox(this,"Ngày tháng không hợp lệ !");
                return;
            }
        }
        if (ddlLoaiTangCa.SelectedValue != "0")
            Search += " and pc.idcalamviec="+ddlLoaiTangCa.SelectedValue;
            select = ""
+ " select" + "\r\n"
+ " idcalamviec, tencalamviec ,tugio ,dengio,ngay, count(idnhanvien) as sonhanvien, xoa" + "\r\n"
+ " from" + "\r\n"
+ " ( " + "\r\n"
+ " select clv.idcalamviec" + "\r\n"
+ "  ,tencalamviec" + "\r\n"
+ "  ,tugio" + "\r\n"
+ "  ,dengio" + "\r\n"
+ "  ,ngay=convert(varchar,pc.ngaythangnam,103)" + "\r\n"
+ "  ,pc.idnhanvien" + "\r\n"
+ "  ,case when isnull((select top 1 idphanca from bangchamcong where idphanca=pc.idphanca),0)=0 then N'Xóa' else null end as xoa " + "\r\n"
+ "  from phanca pc left join calamviec clv on clv.idcalamviec=pc.idcalamviec where 1=1 "+Search+"" + "\r\n"
+ "  ) abc" + "\r\n"
+ " group by abc.idcalamviec,abc.ngay,tencalamviec,tugio ,dengio, xoa" + "\r\n"
+ " order by convert(datetime,abc.ngay,103) desc" + "\r\n";
        DataTable dtCTPhieuVOVAN_DKMmatDay = null;
        dtCTPhieuVOVAN_DKMmatDay = DataAcess.Connect.GetTable(select);
        dgr.DataSource = dtCTPhieuVOVAN_DKMmatDay;
        dgr.DataBind();
    }
}
