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

public partial class BangChamCongTheoNgay : System.Web.UI.Page
{
    DataTable tablelamviec = null;
    DataTable tablengaynghi = null;
    DataTable tablegiolamthem = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        tablelamviec = DataAcess.Connect.GetTable("select * from catruc");
        tablengaynghi = DataAcess.Connect.GetTable("select * from loainghiphep");
        if (!IsPostBack)
        {
            BindListPhongBan();
            NgayCong.Value = DateTime.Now.ToString("dd/MM/yyyy");
        }
        Page.DataBind();
        string where = "";
        if (ddlPhongBan.SelectedValue != "0")
            where += " and nv.idphongban=" + ddlPhongBan.SelectedValue;
        if (ddlLoaiNhanVien.SelectedValue != "" && ddlLoaiNhanVien.SelectedValue != "0")
        {
            string tem = "1";
            if(ddlLoaiNhanVien.SelectedValue=="1")
                tem="0";
            where += " and isnull(nv.loainhanvien,0)="+tem;
        }
        if (idNguoiDung.Value.Trim() != "")
            where += " and nv.tennhanvien like'%" + idNguoiDung.Value.Trim() + "%'";
        string sql = "select *,ROW_NUMBER() OVER (ORDER BY idChamCongTheoNgay) AS STT from  nhanvien nv left join BangChamCongTheoNgay cc on nv.idnhanvien = cc.idnhanvien and ngaycong >= '"
            + StaticData.CheckDate(NgayCong.Value) + "' and ngaycong <= '"
            + StaticData.CheckDate(NgayCong.Value) 
            + "' where nv.status=1 " + where + "";
        HiddenField2.Value = sql;
        gettable(sql);
    }

    private void BindListPhongBan()
    {
        string idnd =SysParameter.UserLogin.UserID(this);
        string sql = "";
        if (idnd != null && idnd != "0")
        {
            if (SysParameter.UserLogin.GroupID(this) != null && SysParameter.UserLogin.GroupID(this) != "4" && SysParameter.UserLogin.GroupID(this) != "16")
            {
                sql = ""
                + " select a.* from phongban a " + "\r\n"
                + " left join nhanvien b on b.idphongban = a.idphongban " + "\r\n"
                + " left join nguoidung c on c.idnhanvien=b.idnhanvien" + "\r\n"
                + " where a.status=1 and c.idnguoidung=" + idnd + " ORder by tenphongban" + "\r\n"
                + " " + "\r\n";
            }
            else
            {
                sql = "select * from phongban where status=1 ORder by tenphongban";
            }
        }
        else
        {
            sql = "select * from phongban where status=1 ORder by tenphongban";
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count >= 0)
        {
            StaticData.FillCombo(ddlPhongBan, dt, "idphongban", "tenphongban", "------Chọn phòng ban------");
            if (ddlPhongBan.Items.Count>1)
            {
               ddlPhongBan.SelectedIndex = 1; 
            }
        }

    }
    protected void ddlPhongBan_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    public void gettable(string sql)
    {
        DataTable table = DataAcess.Connect.GetTable(sql);
        if (table!=null&& table.Rows.Count > 0)
        {
            gridTable.DataSource = table;
            gridTable.DataBind();
        }
       
    }
    protected void gridTable_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "if(this.style.backgroundColor != 'red'){this.style.backgroundColor='#F6EBCD'}");
            e.Row.Attributes.Add("onmouseout", "if(this.style.backgroundColor != 'red'){this.style.backgroundColor='White'}");
            tablegiolamthem = DataAcess.Connect.GetTable("select ROW_NUMBER() OVER (ORDER BY idlamthemgio) AS STT,* from lamthemgio where idnhanvien = '" + ((HiddenField)e.Row.Cells[2].FindControl("idnv")).Value + "' and ngaylamthem >= '" + NgayCong.Value.Split('/')[1] + "/" + NgayCong.Value.Split('/')[0] + "/" + NgayCong.Value.Split('/')[2] + "' and ngaylamthem <= '" + NgayCong.Value.Split('/')[1] + "/" + NgayCong.Value.Split('/')[0] + "/" + NgayCong.Value.Split('/')[2] + "'");
            
            
            DropDownList droplist1 =  (DropDownList)e.Row.FindControl("DropDownList1");
            
            droplist1.DataValueField = tablelamviec.Columns[0].ToString();
            droplist1.DataTextField = tablelamviec.Columns[1].ToString();
            droplist1.Items.Add(new ListItem("-- Chọn --", ""));
            droplist1.DataSource = tablelamviec;
            droplist1.DataBind();
            droplist1.SelectedValue = ((DataRowView)e.Row.DataItem)["idcatruc"].ToString();

            DropDownList droplist2 = (DropDownList)e.Row.FindControl("DropDownList2");
            

            droplist2.DataValueField = tablengaynghi.Columns[0].ToString();
            droplist2.DataTextField = tablengaynghi.Columns[1].ToString();
            droplist2.Items.Add(new ListItem("-- Chọn --", ""));
            droplist2.DataSource = tablengaynghi;
            droplist2.DataBind();
            droplist2.SelectedValue = ((DataRowView)e.Row.DataItem)["phepkhongluong"].ToString();

            DropDownList droplist3 = (DropDownList)e.Row.FindControl("DropDownList3");

            droplist3.DataValueField = tablengaynghi.Columns[0].ToString();
            droplist3.DataTextField = tablengaynghi.Columns[1].ToString();
            droplist3.Items.Add(new ListItem("-- Chọn --", ""));
            droplist3.DataSource = tablengaynghi;
            droplist3.DataBind();
            droplist3.SelectedValue = ((DataRowView)e.Row.DataItem)["phepcoluong"].ToString();
            if (tablegiolamthem.Rows.Count > 0)
            {
                ((GridView)e.Row.Cells[13].FindControl("GridView1")).DataSource = tablegiolamthem;
                ((GridView)e.Row.Cells[13].FindControl("GridView1")).DataBind();
            }
            else
            {
                DataRow row = tablegiolamthem.NewRow();
                tablegiolamthem.Rows.Add(row);
                ((GridView)e.Row.Cells[13].FindControl("GridView1")).DataSource = tablegiolamthem;
                ((GridView)e.Row.Cells[13].FindControl("GridView1")).DataBind();
                ((HtmlInputButton)e.Row.Cells[13].FindControl("displaygio")).Style.Add(HtmlTextWriterStyle.BackgroundColor, "red");
            }

        }
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    for (int i = 0; i < e.Row.Cells.Count; i++)
        //    {
        //        e.Row.Cells[i].Text = hsLibrary.clDictionaryDB.sGetValueLanguage(e.Row.Cells[i].Text);
        //    }
        //}
        
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
        string NgayCongs = "";
        try
        {
            NgayCongs = NgayCong.Value.Split('/')[1] + "/" + NgayCong.Value.Split('/')[0] + "/" + NgayCong.Value.Split('/')[2];
        }
        catch { }
        string where = "";
        if (ddlPhongBan.SelectedValue != "0")
            where += " and nv.idphongban=" + ddlPhongBan.SelectedValue;
        if (ddlLoaiNhanVien.SelectedValue != "" && ddlLoaiNhanVien.SelectedValue != "0")
        {
            string tem = "1";
            if (ddlLoaiNhanVien.SelectedValue == "1")
                tem = "0";
            where += " and isnull(nv.loainhanvien,0)=" + tem;
        }
        HiddenField2.Value = "select *,ROW_NUMBER() OVER (ORDER BY idChamCongTheoNgay) AS STT from  nhanvien nv left join BangChamCongTheoNgay cc on nv.idnhanvien = cc.idnhanvien and ngaycong >= '" + NgayCongs + "' and ngaycong <= '" + NgayCongs + "' where nv.status=1 and nv.tennhanvien like N'%" + idNguoiDung.Value + "%' " + where + "";
        gettable(HiddenField2.Value);
    }
}

