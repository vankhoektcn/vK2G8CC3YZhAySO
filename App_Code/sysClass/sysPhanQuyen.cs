using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Profess;

/// <summary>
/// Summary description for sysPhanQuyen
/// truongnn - 16/02/12
/// </summary>
public class sysPhanQuyen :Page
{
    public sysPhanQuyen()
    {        
        //
        // TODO: Add constructor logic here
        //        
    }
    //Xem cột số tiền,index : chỉ số cột số tiền
    public static void ThuPhi_XemSoTien(Page p,DataGrid grid,int index)
    {
        grid.Columns[index].Visible = Userlogin.HavePermision(p, "ThuPhi_SoTien") || Userlogin.HavePermision(p, "Admin") || SysParameter.UserLogin.IsAdmin(p);        
    }
    public static void ThuPhi_Xoa()
    {
    }
    public static void ThuPhi_Sua()
    {
    }
    public static void ThuPhi_Huy()
    {
    }

    //Phan quyen menu.
    public static void ThongKe_XemBaoCao(Page p,MenuItemCollection menu, string values)
    {
        bool check = Userlogin.HavePermision(p, "ThongKe_XemDoanhThu") || Userlogin.HavePermision(p, "Admin") || SysParameter.UserLogin.IsAdmin(p);
        for (int i = 0; i < menu.Count; i++)
        {
            if (menu[i].Value == values)
            {
                if (check != true)
                {
                    menu.RemoveAt(i);
                    int count = i - 1;
                    if (count < 0)
                    {
                        break;
                    }
                    else
                    {
                        if (menu[count].Value == "|")
                            menu.RemoveAt(count);
                    }
                }
                break;
            }
        }
    }
    public static void XemSubMenu(Page p, MenuItemCollection menu, string values,int index)
    {
        for (int i = 0; i < menu[index].ChildItems.Count; i++)
        {
            if (menu[index].ChildItems[i].Value == values)
            {
                menu[index].ChildItems.RemoveAt(i);
                break;
            }
        }
    }
    public static void XemSubMenu(Page p, MenuItem menuItem, string values, int index)
    {
        for (int j = 0; j < menuItem.ChildItems.Count; j++)
        {
            for (int i = 0; i < menuItem.ChildItems[j].ChildItems.Count; i++)
            {
                if (menuItem.ChildItems[j].ChildItems[i].Value == values)
                {
                    menuItem.ChildItems[j].ChildItems.RemoveAt(i);
                    break;
                }
            }
        }
    }
    public static void RemoveAllSubMenu(Page p, MenuItemCollection menu, int index)
    {
        for (int i = 0; i < menu[index].ChildItems.Count; i++)
        {
            menu[index].ChildItems.RemoveAt(i);
            break;
        }
    }
}
