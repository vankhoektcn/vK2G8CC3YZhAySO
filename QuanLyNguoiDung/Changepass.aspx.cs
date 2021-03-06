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

public partial class changepass : Genaratepage
{
    private string  userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        userID = SysParameter.UserLogin.UserID(this);
        if (!this.IsPostBack)
        {
            if (userID == null || userID == "")
            {
                Response.Redirect("~/pagehome.aspx");
            }
            else
            {
                DataTable DT = DataAcess.Connect.GetTable("SELECT * FROM NGUOIDUNG WHERE IDNGUOIDUNG=" + this.userID);
                if (DT == null || DT.Rows.Count == 0) return;
                txtUser.Text = DT.Rows[0][Profess.TBLS.tbl_nguoidung.username.ToString()].ToString();
            }
        }

    }
   
    protected void btnChangePass_Click(object sender, EventArgs e)
    {
              if (txtNewPass.Text.Trim() != txtConfirmPass.Text.Trim())
                {
                   StaticData.MsgBox(this, "Xác nhận mật khẩu xác nhận phải giống mật khẩu mới. Vui lòng kiểm tra lại!");
                    btnHomePage.Visible = false;
                  return;
                 }

            DataTable dt =  DataAcess.Connect.GetTable("select * from nguoidung where    matkhau='" + txtOldPass.Text + "' AND IDNGUOIDUNG="+this.userID );
            if (dt == null || dt.Rows.Count == 0)
                {
                   StaticData.MsgBox(this, "Tên đăng nhập hoặc mật khẩu cũ chưa chính xác. Vui lòng kiểm tra lại!");
                    btnHomePage.Visible = false;
                }

               
                    bool kq = DataAcess.Connect.ExecSQL("update nguoidung set matkhau='" + txtNewPass.Text + "' , username='" + txtUser.Text + "' where IDNGUOIDUNG="+this.userID);
                    if (kq == false)
                    {
                       StaticData.MsgBox(this, "Có lỗi trong quá trình thay đổi mật khẩu!");
                        btnHomePage.Visible = false;
                    }
                    else
                    {
                       StaticData.MsgBox(this, "Thay đổi mật khẩu thành công!");
                        btnHomePage.Visible = true;
                    }
         
         
        
    }
    protected void btnHomePage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pagehome.aspx");
    }
}
