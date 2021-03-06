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

public partial class uscmenuKT_HeThongDanhMuc : System.Web.UI.MobileControls.MobileUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItemCollection items = this.Menu1.Items;
        int i = 0;
        i = tim(items, "Danh mục");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanDM_KTDM_DanhMucNghiepVu_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhmucnghiepvu", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanDM_danhmuctaikhoan_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhmuctaikhoan", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanDM_danhmuckho_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhmuckho", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanDM_danhmucnhacungcap_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhmucnhacungcap", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanDM_danhmuckhachhang_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhmuckhachhang", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanDM_KTVT_DM_Vat_Tu_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhsachtscd_ccdc", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanDM_DMNgoaiTe_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhmucngoaite", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanDM_DMPhongBan_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "danhmucphongban", i);
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
