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
using CrystalDecisions.CrystalReports.Engine;

public partial class frm_DS_ThuVienPhiTH : MKVPage
{
    private string dkMenu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            SetValueEmpty();
            StaticData.SetFocus(this, "txtMaBenhNhan");
            txtNgayBD.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        dkMenu = Request.QueryString["dkMenu"];
        if (dkMenu != null && dkMenu != "")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/" + dkMenu + "/uscmenu.ascx"));
        }

    }
    #region "U Function"
    private void BindListBenhNhan()
    {
        //if (!StaticData.HavePermision(this, "frm_DS_ThuVienPhiTH_Delete_Full"))
        //{
        //    if (txtMaBenhNhan.Text == "" && txtTenBenhNhan.Text == "")
        //    {
        //        return;
        //    }
        //}
        string NgayThuPhi = StaticData.CheckDate(this.txtNgayBD.Text);
        string strSQL = @" SELECT   DISTINCT STT=1,
                                    MAPHIEU,
                                    IDBENHNHAN,
                                    mabenhnhan,
                                    tenbenhnhan,
                                    ngaysinh,
                                    TONGTIEN=(select SUM(ABS(TONGTIEN)) from hs_dsdathu where maphieu=T.MaPhieu),
                                    tennguoithu,
                                    NOIDUNGTHU=(CASE WHEN ISNULL(NOIDUNGTHU,'')='' AND LOAITHU='PHIKHAM' THEN N'Phí khám' Else NOIDUNGTHU end),
                                    tennguoithu,
                                   (Case isnull(IsDaHuy,0) when 0 then N'Hủy' else N'Đã hủy' end) as HuyPhieu,
                                    IsDaHuy,
                                    LyDoHuy,
                                    NgayHuy,
                                    TenNguoiHuy,
                                    Khoa=(select top 1 khoa from hs_dsdathu where maphieu=t.maphieu and isnull(khoa,'')<>'')
                             FROM HS_DSDATHU T 
                          
                                WHERE 1=1";
        if (this.txtMaPhieu.Text != "")
        {
            strSQL += " and maphieu='" + txtMaPhieu.Text + @"'";

        }
        if (this.txtMaBenhNhan.Text != "")
            strSQL += " AND MABENHNHAN LIKE '%" + this.txtMaBenhNhan.Text + @"%'";
        if (this.txtTenBenhNhan.Text != "")
             strSQL += " AND (dbo.untiengviet(LOWER(tenbenhnhan)) LIKE N'%" + Convert.ToString(this.txtTenBenhNhan.Text).ToLower() + @"' or tenbenhnhan like N'%" + this.txtTenBenhNhan.Text.ToLower() + "')";

        if (NgayThuPhi != "")
        {
            strSQL += " AND YEAR( SysDate)=YEAR('" + NgayThuPhi + "')" + "\r\n";
            strSQL += " AND MONTH( SysDate)=MONTH('" + NgayThuPhi + "')" + "\r\n";
            strSQL += " AND DAY( SysDate)=DAY('" + NgayThuPhi + "')" + "\r\n";
        }

        strSQL += @"       ORDER BY MAPHIEU";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
        }
        dgr.DataSource = dt;
        dgr.DataBind();


    }
    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtNgayBD.Text = DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
    }
    #endregion
    #region "Grid Event"
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindListBenhNhan();
    }
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Huy")
        {

        }
        else
        {
            this.OpenLink("frm_rpt_InPhieuThuTH.aspx?MaPhieu=" + e.CommandArgument + "&InTrucTiep=0");
        }
    }
    #endregion
    private void OpenLink(string LinkName)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "window.open('" + LinkName + "');", true);
        //Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + LinkName + "\",'_blank')</script>");
    }
    protected void btnLayDS_Click(object sender, EventArgs e)
    {
        BindListBenhNhan();
    }
    protected void btnDongY_Click(object sender, EventArgs e)
    {
        try
        {
            string MaPhieu = "" + txtsophieu.Text;
            string sqlTest = "SELECT DBO.zChoPhepHuyPhieu('" + MaPhieu + "')";
            DataTable dtTest = DataAcess.Connect.GetTable(sqlTest);
            if (dtTest == null || dtTest.Rows.Count == 0)
            {
                StaticData.MsgAlert(this, "Không thể kiểm tra thông tin nên không thể huỷ được");
                return;
            }
            string sAlert = dtTest.Rows[0][0].ToString();
            if (sAlert != "")
            {
                StaticData.MsgAlert(this, sAlert);
                return;
            }
            string TenNguoiHuy = SysParameter.UserLogin.FullName(this);
            bool OK = DataAcess.Connect.ExecSQL(" EXEC DBO.zHS_HuyPhieuThu '" + MaPhieu + "',N'" + txtlydo.Text + "',N'" + TenNguoiHuy + "'");
            if (OK)
            {

                int row = int.Parse(this.txtRow.Value);
                row = row - 1;
                HtmlInputButton btn = (HtmlInputButton)this.dgr.Items[row].FindControl("btAction");
                btn.Value = "Đã huỷ";
                btn.Attributes.Add("class", "button");

                this.dgr.Items[row].Cells[10].Text = txtlydo.Text;
                this.dgr.Items[row].Cells[11].Text = TenNguoiHuy;

                txtlydo.Text = "";
                txtsophieu.Text = "";
            }


        }
        catch (Exception)
        {

        }

    }//end void
    protected void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        bool Allow = false;
        //if (StaticData.HavePermision(this, "TiepNhan_frm_DS_ThuVienPhiTH_Delete_Full"))
        //{
        //    Allow = true;
        //}

        //if (StaticData.HavePermision(this, "TiepNhan_frm_DS_ThuVienPhiTH_Delete"))
        //{
        //    Allow = true;
        //}
        Allow = true;

        HtmlInputButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            btn = (HtmlInputButton)e.Item.FindControl("btAction");
            if (btn.Value.Trim() == "Hủy")
            {
                btn.Attributes.Add("class", "button2");

            }
            else
            {
                btn.Attributes.Add("class", "button");
            }
            btn.Disabled = !Allow;
        }
    }
}//end class
