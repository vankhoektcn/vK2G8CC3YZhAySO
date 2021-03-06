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

public partial class uscmenuKT_NganHang : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanNH_KTNH_UyNhiemThu_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "uynhiemchi", i);
            }
            
        }
        i = tim(items, "Danh mục");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanNH_DanhMucTKNH_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "taikhoanNH", i);
            }
        }
        i = tim(items, "Bao cao");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanNH_KTNH_KTNH_SoTienGoiNganHang_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieuthukhac", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanNH_KTNH_DanhSachUyNhiemChi_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "DSgiaybaono", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanNH_KTNH_DanhSachGiayBaoCo_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "DSgiaybaoco", i);
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
