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

public partial class uscMenu : System.Web.UI.UserControl
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        

        string NhomND =   SysParameter.UserLogin.GroupID(this.Page);

        string TenMenu = "uscMenuNhaThuocDV";
        switch (NhomND)
        {
            case "8": TenMenu = "uscMenuNhaThuocBHYT"; break;
            case "7": TenMenu = "uscMenuKhoaDuoc"; break;
            case "10": TenMenu = "uscMenuNhaThuocNoiTru"; break;
        }
       menu.Controls.Add(LoadControl(TenMenu + ".ascx"));

        
    }

    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        if (e.Item.NavigateUrl.Contains(""))
        {
            e.Item.Target = "_blank";
        }

    }
}
