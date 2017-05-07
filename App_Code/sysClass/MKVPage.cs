using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

public class MKVPage : System.Web.UI.Page
{
    public MKVPage()
    {
        this.Load += new EventHandler(MKVPage_Load);
        
        
    }
    void MKVPage_Load(object sender, EventArgs e)
    {
        CheckLogin(); 
    }
    public void CheckLogin()
    {
        string UserID = SysParameter.UserLogin.UserID(this);
        if (UserID == null || UserID == "" || UserID == "0")
        {
            try
            {
                Response.Redirect("../login.aspx");
            }
            catch (Exception)
            {
                 
            }
        }
    }

}

