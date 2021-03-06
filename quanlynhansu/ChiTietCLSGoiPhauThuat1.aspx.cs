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

public partial class ChiTietCLSGoiPhauThuat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY idchitietCLSPhauThuat) AS STT,TenGoiPhauThuat,TenDichVu,TenLoaiPhauThuat,ct.* from ChiTietCLSGoiPhauThuat ct left join GoiPhauThuat gp on ct.idgoiphauthuat=gp.idgoiphauthuat
left join bangGiaDichvu bg on ct.idcanlamsang=bg.idbanggiadichvu
left join LoaiPhauthuat lp on ct.idloaiphauthuat=lp.idloaiphauthuat";
            Page.DataBind();
            gettable(HiddenField2.Value);
            LoadDSGoiPhauThuat();
            LoadDSCLS();
            LoadDSLoaiPhauThuat();
        }
    }

    public void LoadDSGoiPhauThuat()
    {
        DataTable dt = DataAcess.Connect.GetTable("select idGoiPhauThuat,TenGoiPhauThuat from GoiPhauThuat");
        idgoiphauthuat.SetDataDropList(dt, "idGoiPhauThuat", "TenGoiPhauThuat", "0", "--------Chọn Gói phẫu thuật --------");
    }
    public void LoadDSCLS()
    {
        string sqlCLS = @"select idBangGiaDichVu,TenDichVu from bangGiaDichVu bg left join phongkhambenh pk on
bg.idphongkhambenh=pk.idphongkhambenh where LoaiPhong=1 order by tendichvu";
        DataTable dt = DataAcess.Connect.GetTable(sqlCLS);
        idcanlamsang.SetDataDropList(dt, "idBangGiaDichVu", "TenDichVu", "0", "--------Chọn DV CLS --------");
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
                HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY idchitietCLSPhauThuat) AS STT,TenGoiPhauThuat,TenDichVu,TenLoaiPhauThuat,ct.* from ChiTietCLSGoiPhauThuat ct left join GoiPhauThuat gp on ct.idgoiphauthuat=gp.idgoiphauthuat
left join bangGiaDichvu bg on ct.idcanlamsang=bg.idbanggiadichvu
left join LoaiPhauthuat lp on ct.idloaiphauthuat=lp.idloaiphauthuat where  " + HiddenField1.Value;
                gettable(HiddenField2.Value);
            }
            catch { } HiddenField1.Value = "";
        }
        else
        {
            string sql = "";
            if (idgoiphauthuat.SelectedValue != "0")
            {
                sql += "  and ct.idgoiphauthuat = '" + idgoiphauthuat.SelectedValue + "' ";
            }
            if (idcanlamsang.SelectedValue.Trim() != "0" )
            {
                sql += " and ct.idcanlamsang = '" + idcanlamsang.SelectedValue + "'";
            }
            if (idloaiphauthuat.SelectedValue != "0")
            {
                sql += "  and ct.idloaiphauthuat = '" + idloaiphauthuat.SelectedValue + "' ";
            }
            if (giatrongoi.Text_TextBox.Trim() != "0" && giatrongoi.Text_TextBox.Trim() != "0.0" && giatrongoi.Text_TextBox.Trim() != "")
            {
                sql += " and giatrongoi = '" + giatrongoi.Text_TextBox.Replace(",", "") + "'";
            }
            if (giabinhthuong.Text_TextBox.Trim() != "0" && giabinhthuong.Text_TextBox.Trim() != "0.0" && giabinhthuong.Text_TextBox.Trim() != "")
            {
                sql += " and giabinhthuong = '" + giabinhthuong.Text_TextBox.Replace(",", "") + "'";
            }
            if (ghichu.Text_TextBox.Trim() != "")
            {
                sql += " and ct.ghichu like N'%" + ghichu.Text_TextBox + "%' ";
            }
            HiddenField2.Value = @"select ROW_NUMBER() OVER (ORDER BY idchitietCLSPhauThuat) AS STT,TenGoiPhauThuat,TenDichVu,TenLoaiPhauThuat,ct.* from ChiTietCLSGoiPhauThuat ct left join GoiPhauThuat gp on ct.idgoiphauthuat=gp.idgoiphauthuat
left join bangGiaDichvu bg on ct.idcanlamsang=bg.idbanggiadichvu
left join LoaiPhauthuat lp on ct.idloaiphauthuat=lp.idloaiphauthuat where 1=1 " + sql;
            gettable(HiddenField2.Value);
        }
    }
}

