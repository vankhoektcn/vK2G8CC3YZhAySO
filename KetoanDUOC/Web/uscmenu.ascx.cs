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

public partial class uscmenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Phan tich Menu
        if (IsPostBack) return;       

            SetVisible(this.Menu1, "PHIEUXUATTHEOTOA", false);
            SetVisible(this.Menu1, "BANGGIATHUOC_BH", false);
            SetVisible(this.Menu1, "DANHSACHPHIEUNHAPCHUYENKHO", false);
            SetVisible(this.Menu1, "PHIEUNHAPKHO", false);
            SetVisible(this.Menu1, "PHIEUXUATLE", false);
            SetVisible(this.Menu1, "PHIEUXUATCHUYEN", false);
            SetVisible(this.Menu1, "PHIEUXUATTRANHACUNGCAP", false);
            SetVisible(this.Menu1, "DUYETYEUCAU", false);
            SetVisible(this.Menu1, "QUANLY", false);
                
        #endregion
        
    }
    #region Function Cực hay - Permsion-Visble Menu
    private MenuItem ItemOf(string ValueName, MenuItem item)
    {
        if (item.Value.ToLower() == ValueName.ToLower()) return item;
        if (item.ChildItems.Count == 0) return null;
        for (int i = 0; i < item.ChildItems.Count; i++)
        {
            MenuItem itemI = ItemOf(ValueName, item.ChildItems[i]);
            if (itemI != null) return itemI;
        }

        return null;
    }
    private MenuItem ItemOf(string ValueName, Menu item)
    {
        for (int i = 0; i < item.Items.Count; i++)
        {
            MenuItem itemI = ItemOf(ValueName, item.Items[i]);
            if (itemI != null) return itemI;
        }

        return null;
    }
    private void CheckPermision(MenuItem Item, string ValueName, string PermisionName)
    {
        if (!StaticData.HavePermision(this.Page, PermisionName))
        {
            MenuItem menu = this.ItemOf(ValueName, Item);
            if (menu != null)
            {
                menu.Text = "";
                menu.ImageUrl = "";
                MenuItem mnParent = menu.Parent;
                if (mnParent != null)
                {
                    mnParent.ChildItems.Remove(menu);
                }
            }
        }

    }
    private void CheckPermision(Menu Item, string ValueName, string PermisionName)
    {
        if (!StaticData.HavePermision(this.Page, PermisionName))
        {
            MenuItem menu = this.ItemOf(ValueName, Item);
            if (menu != null)
            {
                menu.Text = "";
                menu.ImageUrl = "";
                MenuItem mnParent = menu.Parent;
                if (mnParent != null)
                {
                    mnParent.ChildItems.Remove(menu);
                }
            }
        }

    }
    private void SetVisible(MenuItem Item, string ValueName, bool IsShow)
    {
        if (!IsShow)
        {
            MenuItem menu = this.ItemOf(ValueName, Item);
            if (menu != null)
            {
                menu.Text = "";
                menu.ImageUrl = "";
                MenuItem mnParent = menu.Parent;
                if (mnParent != null)
                {
                    mnParent.ChildItems.Remove(menu);
                }
            }
        }

    }
    private void SetVisible(Menu Item, string ValueName, bool IsShow)
    {
        if (!IsShow)
        {
            MenuItem menu = this.ItemOf(ValueName, Item);
            if (menu != null)
            {
                menu.Text = "";
                menu.ImageUrl = "";
                MenuItem mnParent = menu.Parent;
                if (mnParent != null)
                {
                    mnParent.ChildItems.Remove(menu);
                }
            }
        }

    }
    #endregion
    
}