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
using System.Data.SqlClient;
public partial class Controls_txtMaVach : System.Web.UI.UserControl
{
    
    private string idBenhNhan;
    private string tableName;
    private DataTable table;
    private bool buttonTim;
    public delegate void NhanMaVachHandle();
    public event NhanMaVachHandle NhanMaVach;
    private  void OnNhanMaVach()
    {
        if (NhanMaVach != null)
        {
            NhanMaVach();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public bool VisibleButtonTim
    {
        get
        {
            return buttonTim;
        }
        set
        {
            if (value == true)
            {
                btnTim.Visible = true;
            }
            else
            {
                btnTim.Visible = false;
            }
        }
    }
    public string Text
    {
        get 
        {
            return txtMavach.Text;    
        }
        set
        {
            txtMavach.Text = value;
        }
    }

    public string TableName
    {
        get 
        {
            return tableName;
        }
        set
        {
            tableName = value;
        }
    }
 

    public string IDBenhNhan
    {
        get
        {
            if (idBenhNhan != null)
            {
                return idBenhNhan;
            }
            else
            {
                return "null";
            }
            
        }
        set
        {
            idBenhNhan = value;
        }
    }

    public DataTable dtSource
    {
        get
        {
            return table;
        }
        set
        {
            table = value;
        }
    }

    protected void txtMavach_TextChanged(object sender, EventArgs e)
    {
        string mavach = txtMavach.Text.Trim();
        string sql = "select * from benhnhan where mabenhnhan = '" + mavach + "'";
        table =DataAcess.Connect.GetTable(sql);
        if (table != null && table.Rows.Count > 0)
        {
            this.table = table;
            this.IDBenhNhan = table.Rows[0]["mabenhnhan"].ToString();
            //ps su kien gi do
            this.OnNhanMaVach();
        }
        else
        {
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Không tìm thấy bệnh nhân này');", true);
        
        }
    }
    protected void btnTim_Click(object sender, EventArgs e)
    {
        string mavach = txtMavach.Text.Trim();
        string sql = "select * from benhnhan where mabenhnhan = '" + mavach + "'";
        table = DataAcess.Connect.GetTable(sql);
        if (table != null && table.Rows.Count > 0)
        {
            this.table = table;
            this.IDBenhNhan = table.Rows[0]["mabenhnhan"].ToString();
            //ps su kien gi do
            this.OnNhanMaVach();
        }
        else
        {
            Response.Write("<script>alert('Không tìm thấy bệnh nhân này');</script>");
        }
    }
    
}
