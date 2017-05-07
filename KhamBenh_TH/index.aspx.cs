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
using System.Drawing.Printing;

public partial class index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (StaticData.ParseInt(SysParameter.UserLogin.UserID(this)) == 0)
        //{
        //    Session.RemoveAll();
        //    Response.Redirect("../pagehome.aspx");
        //}
        //else { 

        //}
        if (SysParameter.UserLogin.UserID(this) != null)
        {
            Session.Remove("idnguoidung");
        }
        Page.Title = "QLBV-  Khám Bệnh";
    }
}
