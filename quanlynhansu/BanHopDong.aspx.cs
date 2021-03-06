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
public partial class BanHopDong : Page
{
    string idhopdong = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (Request.QueryString["idhopdong"] != null && Request.QueryString["idhopdong"].ToString() != "")
            {
                idhopdong = Request.QueryString["idhopdong"].ToString();
                txtidhopdong.Value = idhopdong;
            }
          
        }
        catch
        {
            return;   
        }
      
        if (!IsPostBack)
        {            
            LoadThongTinHopDong();           
        }
       

    }
    private void LoadThongTinHopDong()
    {       
        string sql = "select noidunghopdong from hopdong where status=1 and idhopdong='" + idhopdong + "'";
        DataTable tb=DataAcess.Connect.GetTable(sql);   
        if(tb.Rows.Count>0)
            txtHopDong.Value = tb.Rows[0]["noidunghopdong"].ToString();      
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (idhopdong != "" && idhopdong != "0")
        {
            string sql = "update hopdong set noidunghopdong=N'" + txtHopDong.Value.Replace("'","''") + "'  where idhopdong='" + idhopdong + "'";
            bool kq= DataAcess.Connect.ExecSQL(sql);
            if (kq)
                StaticData.MsgBox(this,"Lưu thành công");
            else StaticData.MsgBox(this, "Lưu không thành thành công");
        }       
    }
    protected void btnIn_Click(object sender, EventArgs e)
    {
        
    }

}
