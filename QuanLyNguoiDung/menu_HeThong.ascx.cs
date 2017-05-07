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

public partial class menu_HeThong1 : System.Web.UI.UserControl
{
     
    protected void Page_Load(object sender, EventArgs e)
    {
      if (SysParameter.UserLogin.GroupID(this.Page) != null)
        {
            string dd = SysParameter.UserLogin.GroupID(this.Page).ToString();
            if (dd != "8" && dd!="4")
            {
                MenuItemCollection items = this.Menu1.Items;
                for (int i = 0; i < items.Count; i++)
                {
                    for (int j = 0; j < items[i].ChildItems.Count; j++)
                    {
                       
                        if (items[i].ChildItems[j].Value == "NLVBS")
                        {
                            items[i].ChildItems[j].Enabled = false;
                        }
                        else
                        {
                            //to do
                        }
                    }
                      
                }
               
            }
        }
    }

    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {
        
        
    }
}
