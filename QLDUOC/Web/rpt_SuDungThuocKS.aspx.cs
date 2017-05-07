using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class QLDUOC_Web_rpt_SuDungThuocKS : System.Web.UI.Page
{
    private profess_Rpt_THSDThuoc_KS bbkn = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindkho();
            txtTuNgay.Value = DateTime.Now.ToString("01/MM/yyyy");
            txtDenNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    #region bind kho
    private void bindkho()
    {
        DataTable dt = StaticData.dtGetKho(this, true);
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddlkho, dt, "idkho", "tenkho", "-------------Chọn kho------------");
            ddlkho.SelectedValue = StaticData.MacDinhKhoNhapMuaID;
        }
    }
    #endregion
    #region get ten kho
    private string gettenkho(string idkho)
    {
        DataTable dt = DataAcess.Connect.GetTable("select tenkho from khothuoc where idkho = " + idkho);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt.Rows[0]["tenkho"].ToString();
        }
        else
        {
            return null;
        }
    }
    #endregion

    protected void btnTim_Click(object sender, EventArgs e)
    {
        this.bbkn = new profess_Rpt_THSDThuoc_KS();
        bbkn.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bbkn_AfterExportToExcel);
        this.bbkn.BietDuoc = this.txtTenThuoc.Value;
        this.bbkn.FromDate = StaticData.CheckDate(this.txtTuNgay.Value);
        this.bbkn.ToDate = StaticData.CheckDate(this.txtDenNgay.Value) + " 23:59:59";
        this.bbkn.BietDuoc = txtTenThuoc.Value.Trim();
        bbkn.ExportToExcel();
    }
    void bbkn_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../../ReportOutput/" + bbkn.OutputFileName + "\",'_blank')</script>");
    }

}
