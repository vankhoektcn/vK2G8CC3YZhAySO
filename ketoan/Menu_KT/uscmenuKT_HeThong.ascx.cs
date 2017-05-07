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

public partial class uscmenuKT_HeThong : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "khaibaothamsohethong");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanHT_KTHT_ThamSoTuyChon_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "dsthamsotuychon", i);
            }
        }
        i = tim(items, "Bao cao");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanHT_KTHT_SoDuDauKyTaiKhoan_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "sodudaukytaikhoan", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanHT_KTHT_CongNoDauKy_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "congnodauky", i);
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
}
