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

public partial class uscmenuKT_TienMat : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "Quản Lý");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuThuHoaDon_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieuthuhoadon", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiHoaDon_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieuchihoadon", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiHoaDon_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieuchihoadon", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_ThuKhac_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieuthukhac", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuChiKhac_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieuchikhac", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_PhieuThanhToanTamUng_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "phieutttamung", i);
            }
        }
        i = tim(items, "Bao cao");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_BaoCaoDoanhThu_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "baocaodoanhthu", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_SoQuyTM_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "soquytienmat", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_DanhSachPhieuChi_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhsachphieuthu", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_DanhSachPhieuThu_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhsachphieuchi", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTM_KTTM_DanhSachPhieuThanhTTUng_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhsachphieuTTtamung", i);
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
