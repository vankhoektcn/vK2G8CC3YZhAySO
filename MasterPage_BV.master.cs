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

public partial class MasterPage_BV : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dkMenu = "" + ""; 
        if (Request.QueryString["dkMenu"] != null && dkMenu == "") 
            dkMenu = Request.QueryString["dkMenu"].ToString();

        if (dkMenu == "") dkMenu = "thuphi";
        if (dkMenu == "thuphi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
        }
        else if (dkMenu == "thongke")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/thongke/uscmenu.ascx"));
        }
        else if (dkMenu == "kb")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
        }
        else if (dkMenu == "tiepnhan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        }
        else if (dkMenu == "cls")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        }
        else if (dkMenu == "capcuu")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/capcuu/uscmenu.ascx"));
        }
        else if (dkMenu == "khoanoi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khoanoi/uscmenu.ascx"));
        }
        else if (dkMenu == "khoangoai")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khoangoai/uscmenu.ascx"));
        }
        else if (dkMenu == "khoasan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khoasan/uscmenu.ascx"));
        }
        else if (dkMenu == "phukhoa")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/PhuKhoa/uscmenu.ascx"));
        }

    }
}
