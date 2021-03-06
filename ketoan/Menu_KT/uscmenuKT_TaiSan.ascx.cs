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

public partial class uscmenuKT_TaiSan : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_PhieuNhapVT3_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "nhaptaisan", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_PhieuXuatVT3_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "xuattaisan", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_Khauhaotaisan_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "Khấu hao tài sản cố định", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_PhanBoTSCD_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "Phân bổ", i);
            }
        }
        i = tim(items, "Danh muc");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_DanhMucTSCD_Xem"))
            {
                items[i].Text = "";
                items[i].ImageUrl = "";
            }
        }
        i = tim(items, "Bao cao");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTVT_BaoCaoKhauHaoTSCD_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "BaoCaoKhauHaoTSCD", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTVT_BangTongHopNXT_VT_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "BangTongHopNXVT", i);
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
