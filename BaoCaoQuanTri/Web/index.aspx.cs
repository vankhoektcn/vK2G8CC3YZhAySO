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
        string IsQPTBH = Request.QueryString["IsQPTBH"];
        string IsQPTDV = Request.QueryString["IsQPTDV"];
        string IsKhoaDuoc = Request.QueryString["IsKhoaDuoc"];
        if(IsKhoaDuoc=="1")
            Page.Title = "QLBV- Khoa dược";
        if (IsQPTBH == "1")
            Page.Title = "QLBV- Q.P.T.BH";
        if (IsQPTDV == "1")
            Page.Title = "QLBV- Q.P.T.DV";

    }
}
