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

public partial class ChiTietPhuCapBacSiPhauThuat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY TenLoaiPhauThuat,tenvaitro) AS STT,TenLoaiPhauThuat,tenvaitro,ct.* from ChiTietPhuCapBacSiPhauThuat ct left join LoaiPhauThuat lp
on ct.idLoaiPhauThuat=lp.idloaiphauthuat
left join vaitroBSPhauThuat vt on vt.idvaiTroBS=ct.idvaiTroBSPT";
            Page.DataBind();
            gettable(HiddenField2.Value);
            LoadDSLoaiPhauThuat();
            LoadDSVaiTroPhauThuat();
        }
    }

    public void LoadDSVaiTroPhauThuat()
    {
        DataTable dt = DataAcess.Connect.GetTable("select idvaiTroBS,tenvaitro from vaitroBSPhauThuat order by tenvaitro");
        idvaitroBSPT.SetDataDropList(dt, "idvaiTroBS", "tenvaitro", "0", "--------Chọn vai trò phẫu thuật --------");
    }
    public void LoadDSLoaiPhauThuat()
    {
        DataTable dt = DataAcess.Connect.GetTable("select idLoaiPhauThuat,tenloaiphauthuat from LoaiPhauThuat");
        idloaiphauthuat.SetDataDropList(dt, "idLoaiPhauThuat", "tenloaiphauthuat", "0", "--------Chọn loại phẫu thuật --------");
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
                HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY TenLoaiPhauThuat,tenvaitro) AS STT,TenLoaiPhauThuat,tenvaitro,ct.* from ChiTietPhuCapBacSiPhauThuat ct left join LoaiPhauThuat lp
on ct.idLoaiPhauThuat=lp.idloaiphauthuat
left join vaitroBSPhauThuat vt on vt.idvaiTroBS=ct.idvaiTroBSPT where  " + HiddenField1.Value;
                gettable(HiddenField2.Value);
            }
            catch { } HiddenField1.Value = "";
        }
        else
        {
            string sql = "";
            if (idloaiphauthuat.SelectedValue != "0")
            {
                sql += "  and ct.idloaiphauthuat = '" + idloaiphauthuat.SelectedValue + "' ";
            }
            if (idvaitroBSPT.SelectedValue != "0")
            {
                sql += "  and ct.idvaitroBSPT = '" + idvaitroBSPT.SelectedValue + "' ";
            }
            if (phantramphucap.Text_TextBox.Trim() != "0" && phantramphucap.Text_TextBox.Trim() != "0.0" && phantramphucap.Text_TextBox.Trim() != "")
            {
                sql += " and phantramphucap = '" + phantramphucap.Text_TextBox.Replace(",", "") + "'";
            }
            if (tienphucap.Text_TextBox.Trim() != "0" && tienphucap.Text_TextBox.Trim() != "0.0" && tienphucap.Text_TextBox.Trim() != "")
            {
                sql += " and tienphucap = '" + tienphucap.Text_TextBox.Replace(",", "") + "'";
            }
            if (ghichu.Text_TextBox.Trim() != "")
            {
                sql += " and ct.ghichu like N'%" + ghichu.Text_TextBox + "%' ";
            }
            HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY TenLoaiPhauThuat,tenvaitro) AS STT,TenLoaiPhauThuat,tenvaitro,ct.* from ChiTietPhuCapBacSiPhauThuat ct left join LoaiPhauThuat lp
on ct.idLoaiPhauThuat=lp.idloaiphauthuat
left join vaitroBSPhauThuat vt on vt.idvaiTroBS=ct.idvaiTroBSPT where 1=1 " + sql;
            gettable(HiddenField2.Value);
        }
    }
}

