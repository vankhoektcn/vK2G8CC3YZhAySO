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

public partial class VaiTroBSPhauThuat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY tenvaitro) AS STT,vt.*,ek.tenekipcamo from VaiTroBSPhauThuat vt left join EkipCaMo ek
on vt.idekipmo=ek.idekipmo";
            Page.DataBind();
            gettable(HiddenField2.Value);
            //Button1.Attributes.Add("OnClientClick", "loadDropDownListidekipmo()");
            LoadEkip();
        }
    }
    public void LoadEkip()
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from ekipCaMo");
        idekipmo.SetDataDropList(dt, "idekipmo", "tenekipcamo", "0", "--------Chọn Ekip--------");
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
                HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY tenvaitro) AS STT,vt.*,ek.tenekipcamo from VaiTroBSPhauThuat vt left join EkipCaMo ek
on vt.idekipmo=ek.idekipmo where  " + HiddenField1.Value;
                gettable(HiddenField2.Value);
            }
            catch { } HiddenField1.Value = "";
        }
        else
        {
            string sql = "";
            if (tenvaitro.Text_TextBox.Trim() != "")
            {
                sql += " and tenvaitro like N'%" + tenvaitro.Text_TextBox + "%' ";
            }
            if (idekipmo.SelectedValue != "0")
            {
                sql += "  and vt.idekipmo = '" + idekipmo.SelectedValue + "' ";
            }
            if (GhiChu.Text_TextBox.Trim() != "")
            {
                sql += " and vt.GhiChu like N'%" + GhiChu.Text_TextBox + "%' ";
            }
            HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY tenvaitro) AS STT,vt.*,ek.tenekipcamo from VaiTroBSPhauThuat vt left join EkipCaMo ek
on vt.idekipmo=ek.idekipmo where 1=1 " + sql;
            gettable(HiddenField2.Value);
        }
    }
}

