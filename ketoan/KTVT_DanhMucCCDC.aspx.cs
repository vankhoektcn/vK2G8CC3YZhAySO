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
using System.Threading;

public partial class DanhMucCCDC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.DataBind();
            Search();
        }
    }

    public void gettable(string sql)
    {
        DataTable table = DataAcess.Connect.GetTable(sql);
        gridTable.DataSource = table;
        gridTable.DataBind();
    }
    protected void gridTable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F6EBCD',this.style.cursor = 'pointer'");
            e.Row.Attributes.Add("ondblclick", "alert('not event')");
            e.Row.Attributes.Add("onclick", "setControlFind('" + gridTable.DataKeys[e.Row.RowIndex].Value.ToString() + "','" + hsLibrary.clDictionaryDB.sGetValueLanguage("update") + "')");
            if (e.Row.RowState != DataControlRowState.Alternate)
            {
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
            }
            else
            {
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#CAE3FF'");
            }
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Text = hsLibrary.clDictionaryDB.sGetValueLanguage(e.Row.Cells[i].Text);
            }
        }
    }
    protected void gridTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridTable.PageIndex = e.NewPageIndex;
        gettable(HiddenField2.Value);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value != "")
        {
            try
            {
                HiddenField2.Value = sqlSearch() + " where  " + HiddenField1.Value;
                gettable(HiddenField2.Value);
            }
            catch { } HiddenField1.Value = "";
        }
        else
        {
            Search();
        }
    }
    public string sqlSearch()
    {
        string sql = "select *,ROW_NUMBER() OVER (ORDER BY ccdc_id) AS STT from DanhMucCCDC";
        return sql;
    }
    private void Search()
    {
        string ngay_nhaps = "";
        try
        {
            ngay_nhaps = ngay_nhap.Text_TextBox.Split('/')[1] + "/" + ngay_nhap.Text_TextBox.Split('/')[0] + "/" + ngay_nhap.Text_TextBox.Split('/')[2];
        }
        catch { }
        string ngay_khau_haos = "";
        try
        {
            ngay_khau_haos = ngay_khau_hao.Text_TextBox.Split('/')[1] + "/" + ngay_khau_hao.Text_TextBox.Split('/')[0] + "/" + ngay_khau_hao.Text_TextBox.Split('/')[2];
        }
        catch { }
        string sql = "";
        if (phieu_nhap_id.Text_TextBox.Trim() != "0" && phieu_nhap_id.Text_TextBox.Trim() != "0.0" && phieu_nhap_id.Text_TextBox.Trim() != "")
        {
            sql += " and phieu_nhap_id = '" + phieu_nhap_id.Text_TextBox.Replace(",", "") + "'";
        }
        if (ma_ccdc.Text_TextBox.Trim() != "")
        {
            sql += " and ma_ccdc like N'%" + ma_ccdc.Text_TextBox + "%' ";
        }
        if (ten_ccdc.Text_TextBox.Trim() != "")
        {
            sql += " and ten_ccdc like N'%" + ten_ccdc.Text_TextBox + "%' ";
        }
        if (hang_sx.Text_TextBox.Trim() != "")
        {
            sql += " and hang_sx like N'%" + hang_sx.Text_TextBox + "%' ";
        }
        if (nam_sx.Text_TextBox.Trim() != "0" && nam_sx.Text_TextBox.Trim() != "0.0" && nam_sx.Text_TextBox.Trim() != "")
        {
            sql += " and nam_sx = '" + nam_sx.Text_TextBox.Replace(",", "") + "'";
        }
        if (nguyen_gia.Text_TextBox.Trim() != "0" && nguyen_gia.Text_TextBox.Trim() != "0.0" && nguyen_gia.Text_TextBox.Trim() != "")
        {
            sql += " and nguyen_gia = '" + nguyen_gia.Text_TextBox.Replace(",", "") + "'";
        }
        if (ngay_nhap.Text_TextBox.Trim() != "")
        {
            sql += " and ngay_nhap >= '" + ngay_nhaps + "' ";
        }
        if (ngay_khau_hao.Text_TextBox.Trim() != "")
        {
            sql += " and ngay_khau_hao >= '" + ngay_khau_haos + "' ";
        }
        if (so_thang_khau_hao.Text_TextBox.Trim() != "0" && so_thang_khau_hao.Text_TextBox.Trim() != "0.0" && so_thang_khau_hao.Text_TextBox.Trim() != "")
        {
            sql += " and so_thang_khau_hao = '" + so_thang_khau_hao.Text_TextBox.Replace(",", "") + "'";
        }
        if (Tk_ccdc.Text_TextBox.Trim() != "")
        {
            sql += " and Tk_ccdc like N'%" + Tk_ccdc.Text_TextBox + "%' ";
        }
        if (Tk_doi_ung.Text_TextBox.Trim() != "")
        {
            sql += " and Tk_doi_ung like N'%" + Tk_doi_ung.Text_TextBox + "%' ";
        }
        if (tk_chi_phi.Text_TextBox.Trim() != "")
        {
            sql += " and tk_chi_phi like N'%" + tk_chi_phi.Text_TextBox + "%' ";
        }
        if (tk_phan_bo.Text_TextBox.Trim() != "")
        {
            sql += " and tk_phan_bo like N'%" + tk_phan_bo.Text_TextBox + "%' ";
        }
        HiddenField2.Value = sqlSearch() + " where 1=1 " + sql;
        gettable(HiddenField2.Value);
    }
}

