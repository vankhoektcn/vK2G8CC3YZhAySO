
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

public partial class indexXQuang : Genaratepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PlaceHolder1.Controls.Add(LoadControl("~/XQuang/uscmenu.ascx"));
    }
}
