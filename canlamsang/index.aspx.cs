
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

public partial class index : Genaratepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string nhomNguoi = SysParameter.UserLogin.GroupID(this).ToString();
        //if (nhomNguoi=="4")
        //{
        PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        //}
        //else if (nhomNguoi == "18")
        //{
        //    PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/menuLayMauThu.ascx"));
        //}
        //else if(nhomNguoi!="4"||nhomNguoi!="18")
        //{
        //PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/fullMenu.ascx"));
        //}
    }
}
