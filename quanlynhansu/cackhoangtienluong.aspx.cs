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

public partial class cackhoangtienluong : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            SetValueEmpty();
            DataTable dt = LoaDdataEdit();
            SetValueEditPC(dt);
            
        }
    }
    #region "U Function"
    
    private void SetValueEditPC(DataTable dtSRC)
    {
        if (dtSRC != null && dtSRC.Rows.Count > 0)
        {
            txtnew.Value = "1";
            txtluongtangca.Text = dtSRC.Rows[0]["luongtangcatrengio"].ToString();
            txtluongngaychunhat.Text = dtSRC.Rows[0]["luongngaychunhat"].ToString();
            idsetting.Value = dtSRC.Rows[0]["idsetting"].ToString();
        }
        else
        {
            txtnew.Value = "0";
            txtluongtangca.Text = "10000";
            txtluongngaychunhat.Text = "40000";
        }
    }

    private DataTable LoaDdataEdit()
    {
        string strSQL = "SELECT p.* FROM setting p ORDER BY idsetting DESC";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }

  
    private bool CheckValid(int isadd)
    {
        if (txtluongtangca.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập số tiền lương tăng ca trên một giờ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtmachucvu");
            return false;
        }
        if (txtluongngaychunhat.Text == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập số tiền lương ngày chủ nhật. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txttenchucvu");
            return false;
        }
        return true;
    }
    private void SetValueEmpty()
    {
        txtluongtangca.Text = "10000";
        txtluongngaychunhat.Text = "40000";        
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
            if (StaticData.ParseInt(txtnew.Value) == 0)
            {
                //Them moi
                string strsql = "INSERT INTO setting (luongngaychunhat, luongtangcatrengio) VALUES (" + StaticData.ParseInt(txtluongngaychunhat.Text) + "," + StaticData.ParseInt(txtluongtangca.Text) + ")";
                DataAcess.Connect.ExecSQL(strsql);
                StaticData.MsgBox(this, "Đã cập nhật thành công.");
            }
            else
            {
                //Update
                string strsql = "UPDATE setting SET luongngaychunhat = " + StaticData.ParseInt(txtluongngaychunhat.Text) + ", luongtangcatrengio =" + StaticData.ParseInt(txtluongtangca.Text);
                strsql += " WHERE idsetting = " + StaticData.ParseInt(idsetting.Value);
                DataAcess.Connect.ExecSQL(strsql);
                StaticData.MsgBox(this, "Đã cập nhật thành công.");
            }
        }
    }
       
    #endregion    
}
