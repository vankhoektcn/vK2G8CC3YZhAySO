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

public partial class tiepnhanbn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "QLBV-Tiếp nhận";
        setViewControl();
    }
    private void setViewControl()
    {
        //inMaVach.Visible = true;// StaticData.IsCheck(StaticData.GetParameter("isInTheBN"));
        //inTheBN.Visible = true;// StaticData.IsCheck(StaticData.GetParameter("isInMaVachBN"));
    }
}

