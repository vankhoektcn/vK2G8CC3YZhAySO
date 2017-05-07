using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAcess;
using SysParameter;

/// <summary>
/// Date:23-10-2011
/// </summary>
public partial class frp_ThongKeDoanhThu : Page
{
    private ExportToExcel.Profess_ExportToExcelByCode doanhThu;
    private double tienCLS;
    private double tienHU;
    private double tienRaVien;
    private double tienSo;
    private double tienTU;
    private double tienXe;
    private double tienkham;
    private double tienthuoc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTuNgay.Text = Connect.d_SystemDate().ToString("dd/MM/yyyy");
            txtDenNgay.Text = Connect.d_SystemDate().ToString("dd/MM/yyyy");
            tbTongTien.Visible = false;
            loadNguoiDung();
        }
        loadData();

        string dkMenu = Request.QueryString["dkmenu"];
        plcMenu.Controls.Add(LoadControl("~/" + dkMenu + "/uscmenu.ascx"));

    }

    private void loadData()
    {
        string tungay = StaticData.CheckDate(txtTuNgay.Text);
        string denngay = StaticData.CheckDate(txtDenNgay.Text);
        string IdNguoiThu = ddlNguoiDung.SelectedValue;
        string sql = null;
        clsDoanhThuNguoiDung_1807 processR = new clsDoanhThuNguoiDung_1807(tungay, denngay, IdNguoiThu, this.ddlNguoiDung.SelectedItem.Text);
        sql = processR.GetSQL();
    
         
                DataTable dtDoanThu = Connect.GetTable(sql);
        if (dtDoanThu == null)
        {
            return;
        }
        else
        {
            dtDoanThu.DefaultView.Sort = "MAPHIEUDANGKY";
            if(dtDoanThu.Columns.IndexOf("stt")==-1){
                dtDoanThu.Columns.Add("stt");
            }
            dtDoanThu = dtDoanThu.DefaultView.ToTable();
            for (int i = 0; i < dtDoanThu.Rows.Count; i++)
                dtDoanThu.Rows[i]["stt"] = i + 1;
            tbTongTien.Visible = true;
            dgrDanhSach.DataSource = dtDoanThu;
            dgrDanhSach.DataBind();
        }
    }

    private void loadNguoiDung()
    {
        string current_idBacSi = UserLogin.IdBacSi(this);
        string sql = @" 
                        (select IDNGUOIDUNG,TENNGUOIDUNG from nguoidung where nhomID=2 or nhomid=12
                        )
                        UNION 
                        (
                        SELECT DISTINCT  IDNGUOIDUNG=0, TENNGUOITHU AS TENGNUOIDUNG FROM HS_DSDATHU
                        )
                         ";
        DataTable dt = Connect.GetTable(sql);
        if (dt != null)
        {
            dt.DefaultView.Sort = "TENNGUOIDUNG ASC ,IDNGUOIDUNG DESC ";
            dt = dt.DefaultView.ToTable();
            dt.Columns.Add("IsTrung", sql.GetType());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int n = StaticData.int_Search(dt, "TENNGUOIDUNG='" + dt.Rows[i]["TENNGUOIDUNG"].ToString() + "'");
                if (n != i)
                {
                    dt.Rows[i]["IdNguoiDung"] = dt.Rows[n]["IdNguoiDung"].ToString();
                    dt.Rows[i]["IsTrung"] = "1";
                }
                else
                    dt.Rows[i]["IsTrung"] = "0";
                #region if idnguoidung vẫn = 0
                if (dt.Rows[i]["IdNguoiDung"].ToString().Trim().Equals("0"))
                {
                    dt.Rows[i]["IdNguoiDung"] = DataAcess.Connect.GetTable("select isnull((select idnguoidung from nguoidung where tennguoidung =N'" + dt.Rows[i]["TENNGUOIDUNG"] + "'),0)").Rows[0][0];
                }
                #endregion

            }
            dt.DefaultView.RowFilter = "IsTrung=0";
            dt = dt.DefaultView.ToTable();
        }
        StaticData.FillCombo(ddlNguoiDung, dt, "idnguoidung", "tennguoidung", "Chọn người dùng");
    }

    protected void txtLayDS_Click(object sender, EventArgs e)
    {
        loadData();
    }

    protected void btnExcel_Click1(object sender, EventArgs e)
    {
        string tungay = StaticData.CheckDate(txtTuNgay.Text);
        string denngay = StaticData.CheckDate(txtDenNgay.Text);
        string nguoidung = ddlNguoiDung.SelectedValue;
        
            clsDoanhThuNguoiDung_1807 temp1 = new clsDoanhThuNguoiDung_1807(tungay, denngay, nguoidung, this.ddlNguoiDung.SelectedItem.Text);
            this.doanhThu = temp1;
        

        doanhThu.AfterExportToExcel += doanhThu_AfterExportToExcel;
        doanhThu.ExportToExcel();
    }

    private void doanhThu_AfterExportToExcel()
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "window.open (\"" + "../ReportOutput/" + doanhThu.OutputFileName + "\",'_blank');", true);
        //Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" +
        //               doanhThu.OutputFileName + "\",'_blank')</script>");
    }

    public void dgrDanhSach_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        switch (e.Item.ItemType)
        {
            case ListItemType.AlternatingItem:
            case ListItemType.Item:
                tienkham += StaticData.ParseFloat(e.Item.Cells[3].Text);
                tienSo += StaticData.ParseFloat(e.Item.Cells[4].Text);
                tienCLS += StaticData.ParseFloat(e.Item.Cells[5].Text);
                tienthuoc += StaticData.ParseFloat(e.Item.Cells[6].Text);
                tienTU += StaticData.ParseFloat(e.Item.Cells[7].Text);
                tienHU += StaticData.ParseFloat(e.Item.Cells[8].Text);
                tienXe += StaticData.ParseFloat(e.Item.Cells[9].Text);
                tienRaVien += StaticData.ParseFloat(e.Item.Cells[10].Text);
                break;
            case ListItemType.Footer:
                lblHeader.Text = @"Tổng tiền:";
                lblTienKham.Text = string.Format("{0:0,00}", tienkham);
                lblTienSo.Text = string.Format("{0:0,00}", tienSo);
                lblCLS.Text = string.Format("{0:0,00}", tienCLS);
                lblTienThuoc.Text = string.Format("{0:0,00}", tienthuoc);
                lblTamUng.Text = string.Format("{0:0,00}", tienTU);
                lblHoanUng.Text = ""; //string.Format("{0:0,00}", tienHU);
                lblTienXe.Text = ""; // string.Format("{0:0,00}", tienXe);
                lblRaVien.Text = "";
                string.Format("{0:0,00}", tienRaVien);
                break;
        }
    }
}