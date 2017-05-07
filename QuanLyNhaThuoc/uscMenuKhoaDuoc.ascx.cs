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

public partial class uscMenuKhoaDuoc : System.Web.UI.UserControl
{
 
    protected void Page_Load(object sender, EventArgs e)
    {

        
        
    }

    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        if (e.Item.NavigateUrl.Contains(""))
        {
            e.Item.Target = "_blank";
        }
        //System.Web.HttpContext.Current.Response.Write("<script language='javascript ></script>");
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        string value = Menu1.SelectedValue.ToString();
        if (value == "exit")
        {
            Response.Redirect(StaticData_thuoc.PageHomeLink);
        }
    }
}
