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

public partial class CapCuu_uscmenu_NhanBenh : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        bool a = (StaticData.GetParameter("sysCheckReceipt") == "1");
            MenuItemCollection items = this.Menu1.Items;

            for (int i = 0; i < items.Count; i++)
            {
                
                for (int j = 0; j < items[i].ChildItems.Count; j++)
                {
                    
                    if (a == true)
                    {

                        //if (items[i].ChildItems[j].Value == "DSPTDV")
                        //{
                        //    items[i].ChildItems[j].Text = "Danh s&#225;ch phiếu báo thu dịch vụ&#160;&#160;";
                        //}
                        //if (items[i].ChildItems[j].Value == "DSPTCLS")
                        //{
                        //    items[i].ChildItems[j].Text = "Danh s&#225;ch phiếu báo thu CLS &#160;&#160;";
                        //}
                        if (items[i].ChildItems[j].Value == "SH")
                        {
                            items[i].ChildItems[j].Text = "";
                            //items[i].ChildItems[j].Enabled = false;
                        }

                    }
                    else
                    {
                        //if (items[i].ChildItems[j].Value == "DSPTDV")
                        //{
                        //    items[i].ChildItems[j].Text = "Danh s&#225;ch phiếu thu dịch vụ&#160;&#160;";
                        //}
                        //if (items[i].ChildItems[j].Value == "DSPTCLS")
                        //{
                        //    items[i].ChildItems[j].Text = "Danh s&#225;ch phiếu thu CLS &#160;&#160;";
                        //}
                      
                    }

                }
            }
           
       // Menu1.MenuItemClick += new MenuEventHandler(Menu1_MenuItemClick);
    }


    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        string y = e.Item.Text;
        MenuItemCollection items = this.Menu1.Items;

        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items[i].ChildItems.Count; j++)
            {
                
                if (items[i].ChildItems[j].Selected == true)
                {
                 //   Response.Write("<script>alert('asds');</script>");
                }
            }
        }
    }
}
