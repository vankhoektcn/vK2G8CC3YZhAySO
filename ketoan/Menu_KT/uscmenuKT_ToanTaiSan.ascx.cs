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

public partial class uscmenuKT_ToanTaiSan : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            int k = 0;
            k = tim(items, "Khấu hao");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_SoNhatKiChung_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "sonhatkychung", k);
                }
            }
            
        }
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            int k = 0;
            k = tim(items, "Khấu hao");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_SoNhatKiChung_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "sonhatkychung", k);
                }
            }

        }
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            int k = 0;
            k = tim(items, "Khấu hao");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_SoNhatKiChung_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "sonhatkychung", k);
                }
            }

        }
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            int k = 0;
            k = tim(items, "Khấu hao");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_SoNhatKiChung_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "sonhatkychung", k);
                }
            }

        }
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            int k = 0;
            k = tim(items, "Khấu hao");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTH_KTTH_SoNhatKiChung_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "sonhatkychung", k);
                }
            }
            k = tim(items, "nhapxuatvatru");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTSCD_PhieuNhapVT_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "nhapvattu", k);
                }
                if (!StaticData.HavePermision(this.Page, "KeToanTSCD_PhieuXuatVT_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "xuatvattu", k);
                }
            }
            k = tim(items, "Tăng giảm tài sản cố định");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_TangGiamTaiSan_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "Tăng giảm tài sản cố định", k);
                }
                if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_DanhSachTangGiamTaiSan_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "Báo cáo thanh lý nhượng bán TSCĐ", k);
                }
            }
            k = tim(items, "Phân bổ");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_PhanBoTSCD_Xem"))
                {
                    sysPhanQuyen.XemSubMenu(this.Page, items, "Phân bổ TSCD", k);
                }
            }
        }
        i = tim(items, "Danh muc");
        if (i > -1)
        {
            int k = 0;
            k = tim(items, "Danh mục tài sản cố định");
            if (k > -1)
            {
                if (!StaticData.HavePermision(this.Page, "KeToanTSCD_KTTSCD_DanhMucTaiSan_Xem"))
                {
                    items[i].Text = "";
                    items[i].ImageUrl = "";
                }
            }

        }
         */ 
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
