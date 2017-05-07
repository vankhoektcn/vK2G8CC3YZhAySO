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

public partial class menu_ketoantonghop : System.Web.UI.UserControl
{
    public static SqlConnection conn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = data.getConn();
        conn.Open();
        LoadMenu_TongHop();
    }

    private void LoadMenu_TongHop()
    {
        string strSQL = "";
        if (data.ParseInt(Session["idnguoidung"]) == 0 || Session["idnguoidung"] == null)
            Response.Redirect("../login.aspx");
        else
        {
            strSQL = " Select a.* From NhomNSD a join ChiTietNhomNSD b on a.idNhom=b.idNhom Where b.idNguoiDung=" + Session["idnguoidung"];            
            DataTable dt = DataAcess.Connect.GetTable(strSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                Menu1.FindItem("m_login").Enabled = false;
                Menu1.FindItem("m_01").Enabled = false;
                Menu1.FindItem("m_phatsinh").Enabled = false;
                Menu1.FindItem("m_02").Enabled = false;
                Menu1.FindItem("m_ketchuyen").Enabled = false;
                Menu1.FindItem("m_03").Enabled = false;
                Menu1.FindItem("m_dongbo").Enabled = false;
                Menu1.FindItem("m_04").Enabled = false;
                Menu1.FindItem("m_candoikt").Enabled = false;
                Menu1.FindItem("m_05").Enabled = false;
                Menu1.FindItem("m_baocao").Enabled = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["TenGroup"].ToString() == "CTPS")
                    {
                        Menu1.FindItem("m_phatsinh").Enabled = true;
                    }
                    if (dt.Rows[i]["TenGroup"].ToString() == "KC")
                    {
                        Menu1.FindItem("m_ketchuyen").Enabled = true;
                    }
                    if (dt.Rows[i]["TenGroup"].ToString() == "DB")
                    {
                        Menu1.FindItem("m_dongbo").Enabled = true;
                    }
                    if (dt.Rows[i]["TenGroup"].ToString() == "CDKT")
                    {
                        Menu1.FindItem("m_candoikt").Enabled = true;
                    }
                    if (dt.Rows[i]["TenGroup"].ToString() == "BCTH")
                    {
                        Menu1.FindItem("m_baocao").Enabled = true;
                    }
                }
            }
        }
    }
}
