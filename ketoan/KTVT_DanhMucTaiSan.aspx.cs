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

public partial class DanhMucTaiSan : System.Web.UI.Page
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
        string sql = "select *,ROW_NUMBER() OVER (ORDER BY danh_muc_ts_id) AS STT from DanhMucTaiSan";
        return sql;
    }
    private void Search()
    {
        string NgayNhaps = "";
        try
        {
            NgayNhaps = NgayNhap.Text_TextBox.Split('/')[1] + "/" + NgayNhap.Text_TextBox.Split('/')[0] + "/" + NgayNhap.Text_TextBox.Split('/')[2];
        }
        catch { }
        string NgayKhauHaos = "";
        try
        {
            NgayKhauHaos = NgayKhauHao.Text_TextBox.Split('/')[1] + "/" + NgayKhauHao.Text_TextBox.Split('/')[0] + "/" + NgayKhauHao.Text_TextBox.Split('/')[2];
        }
        catch { }
        string sql = "";
        if (phieu_nhap_id.Text_TextBox.Trim() != "0" && phieu_nhap_id.Text_TextBox.Trim() != "0.0" && phieu_nhap_id.Text_TextBox.Trim() != "")
        {
            sql += " and phieu_nhap_id = '" + phieu_nhap_id.Text_TextBox.Replace(",", "") + "'";
        }
        if (MaTS.Text_TextBox.Trim() != "")
        {
            sql += " and MaTS like N'%" + MaTS.Text_TextBox + "%' ";
        }
        if (TenTaiSan.Text_TextBox.Trim() != "")
        {
            sql += " and TenTaiSan like N'%" + TenTaiSan.Text_TextBox + "%' ";
        }
        if (HangSX.Text_TextBox.Trim() != "")
        {
            sql += " and HangSX like N'%" + HangSX.Text_TextBox + "%' ";
        }
        if (NamSX.Text_TextBox.Trim() != "0" && NamSX.Text_TextBox.Trim() != "0.0" && NamSX.Text_TextBox.Trim() != "")
        {
            sql += " and NamSX = '" + NamSX.Text_TextBox.Replace(",", "") + "'";
        }
        if (NguyenGia.Text_TextBox.Trim() != "0" && NguyenGia.Text_TextBox.Trim() != "0.0" && NguyenGia.Text_TextBox.Trim() != "")
        {
            sql += " and NguyenGia = '" + NguyenGia.Text_TextBox.Replace(",", "") + "'";
        }
        if (KhauHaoLK.Text_TextBox.Trim() != "0" && KhauHaoLK.Text_TextBox.Trim() != "0.0" && KhauHaoLK.Text_TextBox.Trim() != "")
        {
            sql += " and KhauHaoLK = '" + KhauHaoLK.Text_TextBox.Replace(",", "") + "'";
        }
        if (NgayNhap.Text_TextBox.Trim() != "")
        {
            sql += " and NgayNhap >= '" + NgayNhaps + "' ";
        }
        if (NgayKhauHao.Text_TextBox.Trim() != "")
        {
            sql += " and NgayKhauHao >= '" + NgayKhauHaos + "' ";
        }
        if (SoNamKH.Text_TextBox.Trim() != "0" && SoNamKH.Text_TextBox.Trim() != "0.0" && SoNamKH.Text_TextBox.Trim() != "")
        {
            sql += " and SoNamKH = '" + SoNamKH.Text_TextBox.Replace(",", "") + "'";
        }
        if (TKNguyenGia.Text_TextBox.Trim() != "")
        {
            sql += " and TKNguyenGia like N'%" + TKNguyenGia.Text_TextBox + "%' ";
        }
        if (TKKhauHao.Text_TextBox.Trim() != "")
        {
            sql += " and TKKhauHao like N'%" + TKKhauHao.Text_TextBox + "%' ";
        }
        if (TKDoiUng.Text_TextBox.Trim() != "")
        {
            sql += " and TKDoiUng like N'%" + TKDoiUng.Text_TextBox + "%' ";
        }
        if (TKChiPhi.Text_TextBox.Trim() != "")
        {
            sql += " and TKChiPhi like N'%" + TKChiPhi.Text_TextBox + "%' ";
        }
        HiddenField2.Value = sqlSearch() + " where 1=1 " + sql;
        gettable(HiddenField2.Value);
    }
}

