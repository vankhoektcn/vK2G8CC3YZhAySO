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

public partial class Hethong_PhanQuyenUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = @"SELECT IDNGUOIDUNG, NGUOIDUNG=USERNAME + ' - ' + TENNGUOIDUNG FROM NGUOIDUNG WHERE USERNAME !='ADMIN'";
            DropDownList1.DataSource = DataAcess.Connect.GetTable(sql);
            DropDownList1.DataValueField = "IDNGUOIDUNG";
            DropDownList1.DataTextField = "NGUOIDUNG";
            DropDownList1.DataBind();
            BindQuyen();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < ListBox1.Items.Count; i++)
        {
            if (ListBox1.Items[i].Selected)
            {
                ListBox2.Items.Add(new ListItem(ListBox1.Items[i].Text, ListBox1.Items[i].Value));
                ListBox1.Items.RemoveAt(i);
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < ListBox2.Items.Count; i++)
        {
            if (ListBox2.Items[i].Selected)
            {
                ListBox1.Items.Add(new ListItem(ListBox2.Items[i].Text, ListBox2.Items[i].Value));
                ListBox2.Items.RemoveAt(i);
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        addAllToList2();
    }

    private void addAllToList2()
    {
        if (ListBox1.Items.Count > 0)
        {
            int k = ListBox1.Items.Count - 1;
            ListBox2.Items.Add(new ListItem(ListBox1.Items[k].Text, ListBox1.Items[k].Value));
            ListBox1.Items.RemoveAt(k);
            addAllToList2();
        }
    }
    private void addAllToList1()
    {
        if (ListBox2.Items.Count > 0)
        {
            int k = ListBox2.Items.Count - 1;
            ListBox1.Items.Add(new ListItem(ListBox2.Items[k].Text, ListBox2.Items[k].Value));
            ListBox2.Items.RemoveAt(k);
            addAllToList1();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        addAllToList1();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (!StaticData.HavePermision(this, "PhanQuyenUser_Add"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), null, "$.mkv.myerror('Bạn không có quyền này!');", true);
            return;
        }
        string Id = DropDownList1.SelectedValue;
        bool OK1 = DataAcess.Connect.ExecSQL("DELETE FROM USERPROFILE WHERE USERID=" + Id);
        if (!OK1 == null)
        {
            DataAcess.Connect.RollBack();
            ScriptManager.RegisterStartupScript(this, this.GetType(), null, "$.mkv.myalert('Lưu thông tin thất bại',1000,'success');", true);
            return;
        }
        for (int i = 0; i < ListBox2.Items.Count; i++)
        {
            DataTable dt = DataAcess.Connect.GetTable("SELECT TOP 1 EPID FROM UserProfile ORDER BY EPID DESC");
            string newID = "1";
            if (dt == null)
            {
                DataAcess.Connect.RollBack();
                ScriptManager.RegisterStartupScript(this, this.GetType(), null, "$.mkv.myalert('Lưu thông tin thất bại',1000,'success');", true);
                return;
            }
            if (dt.Rows.Count != 0)
                newID = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            Profess.UserProfile Perm = Profess.UserProfile.Insert_Object(newID, Id, ListBox2.Items[i].Value, "1", "0");
            if (Perm == null)
            {
                DataAcess.Connect.RollBack();
                ScriptManager.RegisterStartupScript(this, this.GetType(), null, "$.mkv.myalert('Lưu thông tin thất bại',1000,'success');", true);
                return;
            }

        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), null, "$.mkv.myalert('Lưu thành công!',1000,'success');", true);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.AutoPostBack != false)
        {
            BindQuyen();
        }
    }
    private void BindQuyen()
    {
        ListBox1.DataSource = DataAcess.Connect.GetTable("select * from permision where permid not in(select permid from userprofile where userid='" + DropDownList1.SelectedValue + "') and status=1 order by permdesc");
        ListBox1.DataValueField = "permid";
        ListBox1.DataTextField = "permdesc";
        ListBox1.DataBind();
        ListBox2.DataSource = DataAcess.Connect.GetTable("select * from userprofile a left join permision b on a.permid=b.permid where userid='" + DropDownList1.SelectedValue + "'");
        ListBox2.DataValueField = "permid";
        ListBox2.DataTextField = "permdesc";
        ListBox2.DataBind();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedIndex == 1)
        {
            DropDownList1.AutoPostBack = false;
        }
        else { DropDownList1.AutoPostBack = true; }
    }
}
