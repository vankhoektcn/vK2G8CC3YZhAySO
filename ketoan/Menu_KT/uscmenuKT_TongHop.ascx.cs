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

public partial class uscmenuKT_BaoCaoTaiChinh : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "chungtutonghop");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTH_PHIEU_KE_TOAN3_Xem"))
            {
                items[i].Text = "";
                items[i].ImageUrl = "";
            }
        }
        ///////////////////
        i = tim(items, "DNcongthucketchuyen");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_CongThucKC_Xem"))
            {
                items[i].Text = "";
                items[i].ImageUrl = "";
            }
        }
        //sub menu
        i = tim(items, "hinhthucnhatkychung");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_SoNhatKiChung_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "sonhatkychung", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_SoChiTietTK_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "sochitiettaikhoan", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_NhatKyThuTien_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "sonhatkythutien", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_NhatKyChiTien_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "sonhatkychitien", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_ChungTuGhiSo_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "chungtughiso", i);
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
