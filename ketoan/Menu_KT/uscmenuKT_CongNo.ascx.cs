using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class uscmenuKT_CongNo : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "Bao cao");
        if (i > -1)
        {
            int k = 0;
            k = tim(items[i], "công nợ khách hàng");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanCN_KTCN_Khach_Hang_TH_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items[i], "tonghopcongnokhachhang", k);
                }
                if (!StaticData.HavePermision(this.Page, "KeToanCN_KTCN_Khach_Hang_CT_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items[i], "chitietcongnokhachhang", k);
                }
            }
            k = tim(items[i], "công nợ nhà cung cấp");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanCN_KTCN_NhaCungCap_TH_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items[i], "tonghopcongnoNCC", k);
                }
                if (!StaticData.HavePermision(this.Page, "KeToanCN_KTCN_NhaCungCap_CT_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items[i], "chitietcongnoNCC", k);
                }
            }
        }
    }
    protected int tim(MenuItemCollection item, string value)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].Value == value)
            {
                return i;
            }
        }
        return -1;
    }
    protected int tim(MenuItem item, string value)
    {
        for (int i = 0; i < item.ChildItems.Count; i++)
        {
            if (item.ChildItems[i].Value == value)
            {
                return i;
            }
        }
        return -1;
    }
}
