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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      /* if (Session["werwerweoruwe"] == null)
        {
            Response.Write("<script>window.open(\"\",\"_parent\",\"\");window.close();window.open(location.href,\"_blank\",\"location=0,menubar=0,resizable=1,scrollbars=1,status=0,toolbar=0\")</script>");
            Session["werwerweoruwe"] = "werwer";
        }*/
        //string dkMenu = Request.QueryString["dkMenu"];

        //if (dkMenu == "kb")
        //{
        //    PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
        //}
        //if (dkMenu == "kbDichVu")
        //{
        //    PlaceHolder1.Controls.Add(LoadControl("~/DichVu/uscmenu.ascx"));
        //}
        //if (dkMenu == "tiepnhan")
        //{
        //    PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        //}
        //string dkMenu = Request.QueryString["dkMenu"];
        //if (dkMenu != null && dkMenu != "")
        //{
        //    PlaceHolder1.Controls.Add(LoadControl("~/" + dkMenu + "/uscmenu.ascx"));
        //}
    }
}
