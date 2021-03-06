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
public partial class ThietLapTangCa : System.Web.UI.Page
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
        }
        else
        {
            BinListThietLapCa();
            btnLuu.Attributes.Add("display","none");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "showKQCLS();", true);
        }
    }
    private void BindListLoaiTangCa()
    {
        string sql = "select * from loaitangca where status=1";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlLoaiTangCa, dt, "idloaitangca", "tenloaitangca", "------Chọn loại ca------");
            
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
        string select = " select tc.idtangca,tenloaitangca,ngaytangca,tugio,dengio,sogiotangca,count(idchitiettangca) as sonhanvien,convert(varchar,ngaytangca,103)as ngay"
            +" ,case when isnull((select top 1 idtangca from bangchamcong where idtangca=tc.idtangca),0)=0 then N'Xóa' else null end as xoa "
        +" from tangca tc left join loaitangca ltc on ltc.idloaitangca=tc.idloaitangca "
        +" left join chitiettangca CTTC on tc.idtangca= CTTC.idtangca where 1=1 " + strSearch;
        select += " group by tc.idtangca,tenloaitangca,ngaytangca,tugio,dengio,sogiotangca,convert(varchar,ngaytangca,103) order by ngaytangca";
        DataTable dtCTPhieuVOVAN_DKMmatDay = DataAcess.Connect.GetTable(select);
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
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        //Thông tin Tang ca
        string selectTangCa = "select tc.*,convert(varchar,ngaytangca,103)as ngay from tangca tc where tc.idtangca="+imaphong;
        DataTable dtTC = DataAcess.Connect.GetTable(selectTangCa);
        if (dtTC.Rows.Count > 0)
        {
            ddlLoaiTangCa.SelectedValue = dtTC.Rows[0]["idloaitangca"].ToString();
            //ddlTuGio.SelectedIndex = ddlTuGio.Items.IndexOf(ddlTuGio.Items.FindByText(dtTC.Rows[0]["tugio"].ToString().Trim()));
            //ddlDenGio.SelectedIndex = ddlDenGio.Items.IndexOf(ddlDenGio.Items.FindByText(dtTC.Rows[0]["dengio"].ToString().Trim()));

            txtNgay.Text = dtTC.Rows[0]["ngay"].ToString();
            txtDenGio.Value= dtTC.Rows[0]["dengio"].ToString().Trim();
            txtTuGio.Value = dtTC.Rows[0]["tugio"].ToString().Trim();
            //Thông tin Nhan vien
            string listID = "";
            DataTable dtCTTC = DataAcess.Connect.GetTable("select distinct idnhanvien from chitiettangca where idtangca=" + imaphong);
            if (dtCTTC.Rows.Count > 0)
            {
                for (int i = 0; i < dtCTTC.Rows.Count; i++)
                    listID += dtCTTC.Rows[i][0] + ",";
            }
            listIdNV.Value = listID;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "showKQCLS();", true);
            txtidTangCa.Value = imaphong.ToString();
            btnUpDate.Visible = true; btnLuu.Visible = false;
        }
    }
    public void DelTangCa(object s, DataGridCommandEventArgs e)
    {
        int imaphong;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        // Kiểm tra đã chấm công hay chưa
        string checkExist = "select * from bangchamcong where idtangca= "+imaphong;
        DataTable dtExist = DataAcess.Connect.GetTable(checkExist);
        if (dtExist.Rows.Count > 0)
        {
            StaticData.MsgBox(this,"Không thể xóa tăng ca vì đã được chấm công !");
            return;
        }
        bool delCT = DataAcess.Connect.ExecSQL("delete from chitiettangca where idtangca="+imaphong);
        string sqlDelete = "delete from  tangca  where idtangca=" + imaphong;
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
}
