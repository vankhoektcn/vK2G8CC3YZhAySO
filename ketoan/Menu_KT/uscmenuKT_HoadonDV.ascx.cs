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

public partial class uscmenuKT_HoadonDV : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "quanly");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanHDDV_HDDV_XuatHoaDon_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "xuathoadon", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanHDDV_HDDV_DanhSachHoaDon_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhsachHD", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanHDDV_HDBH_XuatHoaDon_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "xuathoadon", i);
            }
        }
        i = tim(items, "danhsachbaocao");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanHDDV_HDDV_rptDoanhThuChiTiet_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "BCdoanhthuchitiet", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanHDDV_HDDV_rptDoanhThuTongHop_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "BCDTtheongay", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanHDDV_HDDV_rptDoanhThuTongHop2_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "BCdoanhthutonghop", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanHDDV_HDDV_rptDTTheoNguoiDung_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "BCDTtheonguoidung", i);
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
    protected void Menu1_DataBound(object sender, EventArgs e)
    {
        
    }
}
