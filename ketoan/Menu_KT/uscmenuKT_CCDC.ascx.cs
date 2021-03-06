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

public partial class uscmenuKT_CCDC : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_PhieuNhapCCDC3_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieunhapccdc", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_PhieuXuatCCDC3_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieuxuatccdc", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_KhauHaoCCDC_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "khauhaoccdc", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanCCDC_KTTSCD_PhanBoCCDC_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phanboccdc", i);
            }
        }
        i = tim(items, "Danh mục");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanCCDC_KTCCDC_DanhMucCCDC_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhmucccdc", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanCCDC_KTVT_BangTongHopNXT_VT1_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "Danh mục tài sản cố định", i);
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
