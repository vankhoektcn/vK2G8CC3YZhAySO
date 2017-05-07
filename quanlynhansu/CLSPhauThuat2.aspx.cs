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

public partial class CLSPhauThuat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.DataBind();
            DataTable tableidcaphauthuat = DataAcess.Connect.GetTable("select * from GoiPhauThuat ");
            idcaphauthuat.SetDataDropList(tableidcaphauthuat, tableidcaphauthuat.Columns[0].ToString(), tableidcaphauthuat.Columns[1].ToString(), "", "-- Select One --");
            Search();
        }
    }

    public void gettable(string sql)
    {
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            gridTable.DataSource = table;
            gridTable.DataBind();
        }
        else
        {
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            gridTable.DataSource = table;
            gridTable.DataBind();
        }
    }
    protected void gridTable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable tablelist0 = DataAcess.Connect.GetTable("select * from GoiPhauThuat ");
        DropDownList DropDownList0 = (DropDownList)e.Row.Cells[0].FindControl("DropDownList2");
        if (DropDownList0 != null)
        {
            DropDownList0.DataValueField = "IDGoiPhauThuat";
            DropDownList0.DataTextField = tablelist0.Columns[1].ToString();
            DropDownList0.DataSource = tablelist0;
            DropDownList0.DataBind();
            DropDownList0.SelectedValue = ((DataRowView)e.Row.DataItem)["idcaphauthuat"].ToString();
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F6EBCD',this.style.cursor = 'pointer'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
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
    public bool checks(object text)
    {
        if (text == null) return false;
        if (text.ToString() == "1" || text.ToString().ToLower() == "true") return true;
        return false;
    }

    public string coverdate(object date)
    {
        return String.Format("{0:dd/MM/yyyy}", date);
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
            catch { }
            HiddenField1.Value = "";
        }
        else
        {
            Search();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        gettable(sqlSearch() + " where 1=2");
    }
    public string sqlSearch()
    {
        string sql = @"select *,ROW_NUMBER() OVER (ORDER BY idCLSPhauThuat) as stt from CLSPhauThuat cp
                left join goiphauthuat gp on gp.idgoiphauthuat=cp.idcaphauthuat
                left join banggiadichvu bg on bg.idbanggiadichvu = cp.idchitietCLSPhauThuat";
        return sql;
    }
    private void Search()
    {
        string sql = "";
        if (idchitietCLSPhauThuat.Text_TextBox.Trim() != "0" && idchitietCLSPhauThuat.Text_TextBox.Trim() != "" && idchitietCLSPhauThuat.Text_TextBox.Trim() != "0.0")
        {
            sql += " and bg.tendichvu like '" + idchitietCLSPhauThuat.Text_TextBox.Replace(",", "") + "%'";
        }
        if (idcaphauthuat.SelectedValue != "")
        {
            sql += "  and gp.idGoiPhauThuat = '" + idcaphauthuat.SelectedValue + "' ";
        }
        HiddenField2.Value = sqlSearch() + " where 1=1 " + sql;
        gettable(HiddenField2.Value);
    }
}
 
