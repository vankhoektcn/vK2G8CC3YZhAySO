﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class QLDUOC_Web_rpt_DuTruThuocYear : System.Web.UI.Page
{
    private profess_Rpt_DuTruThuoc bbkn = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindkho();
            txtNam.Text = (DateTime.Now.Year + 1).ToString();
        }
    }
    #region bind kho
    private void bindkho()
    {
        DataTable dt = StaticData.dtGetKho(this, false);
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
        this.bbkn = new profess_Rpt_DuTruThuoc();
        bbkn.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(bbkn_AfterExportToExcel);
        this.bbkn.TenThuoc = this.txtTenThuoc.Value;
        this.bbkn.IDKho = this.ddlkho.SelectedValue.ToString();
        this.bbkn.Year = this.txtNam.Text.Trim();
        this.bbkn.IsThuocGN = this.chbThuocGN.Checked;
        this.bbkn.IsThuocHTT = this.chbThuocHTT.Checked;
        bbkn.ExportToExcel();
    }
    void bbkn_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../../ReportOutput/" + bbkn.OutputFileName + "\",'_blank')</script>");
    }
}
