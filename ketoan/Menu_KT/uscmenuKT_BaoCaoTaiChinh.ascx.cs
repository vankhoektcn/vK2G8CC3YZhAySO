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
        i = tim(items, "baocaotaichinhCDTK");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTC_BCTC_BangCanDoi_TK_Xem"))
            {
                items[i].Text = "";
                items[i].ImageUrl = "";
            }
        }
        i = tim(items, "Bao cao");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTC_BangCanDoiKT_Xem"))
            {
                items[i].Text = "";
                items[i].ImageUrl = "";
            }
        }
        i = tim(items, "danhsachthongke");
        if (i > -1)
        {
            if (!StaticData.HavePermision(this.Page, "KeToanTC_BCTC_KetQuaHoatDongKD_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "Kết quả hoạt động kinh doanh", i);
            }
            if (!StaticData.HavePermision(this.Page, "KeToanTC_BCTC_LuuChuyenTienTe_Xem"))
            {
                sysPhanQuyen.XemSubMenu(this.Page, items, "Báo cáo lưu chuyển tiền tệ", i);
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
