using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class uscmenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Phan tich Menu
        if (IsPostBack) return;
        string IsQPTBH = Request.QueryString["IsQPTBH"];
        string IsQPTDV = Request.QueryString["IsQPTDV"];
        string IsKhoaDuoc = Request.QueryString["IsKhoaDuoc"];

        #region Save Group
        if (IsKhoaDuoc == "1")
            SysParameter.UserLogin.SaveGroup(this.Page, "7");
        if (IsQPTBH == "1")
            SysParameter.UserLogin.SaveGroup(this.Page, "8");
        if (IsQPTDV == "1")
            SysParameter.UserLogin.SaveGroup(this.Page, "9");
        #endregion
       
        string GroupID = SysParameter.UserLogin.GroupID(this.Page);
        if (GroupID == "7")         IsKhoaDuoc = "1";
        if (GroupID == "8")         IsQPTBH = "1";
        if (GroupID == "9")         IsQPTDV = "1";

        if (IsKhoaDuoc == "1")
        {
            SetVisible(this.Menu1, "PHIEUXUATTHEOTOA", false);
            SetVisible(this.Menu1, "KIEMTRADICHVU", false);
            SetVisible(this.Menu1, "DANHSACHPHIEUNHAPCHUYENKHO", false);
            SetVisible(this.Menu1, "DANHSACHTOATHUOCDACAPPHAT", false);
            SetVisible(this.Menu1, "DANHSACHBNDAKIEMTRA", false);
            SetVisible(this.Menu1, "CHITIETNHAPXUATTON_QPT", false);
            SetVisible(this.Menu1, "PHIEUYCLANH", false);
            SetVisible(this.Menu1, "PHIEUYCTRA", false);
            SetVisible(this.Menu1, "BANGGIATHUOC_view", true);
            SetVisible(this.Menu1, "phanbothuoc", true);
            SetVisible(this.Menu1, "phanbohoachat", true);
            SetVisible(this.Menu1, "phanbodungcu", true);
            SetVisible(this.Menu1, "phanbovtyt", true);
            SetVisible(this.Menu1, "suabanggia", true);

        }
        else
        {
            SetVisible(this.Menu1, "PHIEUNHAPKHO", false);
            SetVisible(this.Menu1, "PHIEUXUATLE", false);
            SetVisible(this.Menu1, "PHIEUXUATCHUYEN", false);
            SetVisible(this.Menu1, "PHIEUXUATTRANHACUNGCAP", false);
            SetVisible(this.Menu1, "CHITIETNHAPXUATTON_KD", false);
            SetVisible(this.Menu1, "BIENBANKIEMKE", false);
            SetVisible(this.Menu1, "BIENBANKIEMNHAP", false);
            SetVisible(this.Menu1, "DUTRUTHUOCTHEONAM", false);
            SetVisible(this.Menu1, "DUTRUTHUOCTHEOTHANG", false);
            SetVisible(this.Menu1, "BAOCAOSUDUNGTHUOC", false);
            SetVisible(this.Menu1, "BAOCAOSUDUNGTHUOCGAYNGHIEN", false);
            SetVisible(this.Menu1, "BAOCAOSUDUNGTHUOCHUONGTAMTHAN", false);
            SetVisible(this.Menu1, "BAOCAOSUDUNGTHUOCKHANGSINH", false);

            SetVisible(this.Menu1, "BAOCAOSUDUNGVATTUYTE", false);
            SetVisible(this.Menu1, "BAOCAOSUDUNGHOACHAT", false);
            SetVisible(this.Menu1, "BAOCAOSUDUNGTHUOCNOITRU", false);

            SetVisible(this.Menu1, "DMKHO", false);
            SetVisible(this.Menu1, "DMHANGSANXUAT", false);
            SetVisible(this.Menu1, "DMNUOCSANXUAT", false);
            SetVisible(this.Menu1, "DMNHACUNGCAP", false);
            SetVisible(this.Menu1, "DMDOITUONG", false);
            SetVisible(this.Menu1, "THAMSOHETHONG", false);
            SetVisible(this.Menu1, "DMDONVITINH", false);
            SetVisible(this.Menu1, "DMCACHDUNG", false);

            SetVisible(this.Menu1, "DUYETYEUCAU", false);
            SetVisible(this.Menu1, "DUYETYEUCAU_", false);
            SetVisible(this.Menu1, "DUYETPHIEULINH", false);
            SetVisible(this.Menu1, "DSPHIEUYEUCAUTRA_BN", false);
            SetVisible(this.Menu1, "DSPHIEUYEUCAUTRA_DU", false);
            SetVisible(this.Menu1, "DSPHIEUYEUCAUTRA_TUTRUC", false);

            SetVisible(this.Menu1, "DANHSACHPHIEUNHAP", false);
            SetVisible(this.Menu1, "DANHSACHCHITIETPHIEUNHAP", false);
            SetVisible(this.Menu1, "DANHSACHPHIEUXUAT", false);
            SetVisible(this.Menu1, "DANHSACHPHIEUNHAPXUAT", false);
            SetVisible(this.Menu1, "DANHSACHTHUOC", false);
            SetVisible(this.Menu1, "DANHSACHHOACHAT", false);
            SetVisible(this.Menu1, "DANHSACHVATTUYTE", false);
            SetVisible(this.Menu1, "BANGGIATHUOC_view", false);
            SetVisible(this.Menu1, "suabanggia", true);
            SetVisible(this.Menu1, "DANHSATCHKIEMDUYETTHIEU", false);

        }

        if (IsQPTBH == "1")
        {
            SetVisible(this.Menu1, "DMTHUOC_QPTBH", true);
            SetVisible(this.Menu1, "DMTHUOC", false);
            SetVisible(this.Menu1, "DMHOACHAT", false);
            SetVisible(this.Menu1, "DMVATTUYTE", false);
            SetVisible(this.Menu1, "DMPHANNHOM", false);
            SetVisible(this.Menu1, "DMNHOMTHUOC", false);
            SetVisible(this.Menu1, "PHIEUYCLANH", true);
            SetVisible(this.Menu1, "PHIEUYCTRA", true);
            SetVisible(this.Menu1, "phanbothuoc", false);
            SetVisible(this.Menu1, "phanbohoachat", false);
            SetVisible(this.Menu1, "phanbodungcu", false);
            SetVisible(this.Menu1, "phanbovtyt", false);
            SetVisible(this.Menu1, "suabanggia", false);
            SetVisible(this.Menu1, "DANHSATCHKIEMDUYETTHIEU", false);
        }
        else
        {
            SetVisible(this.Menu1, "DMTHUOC_QPTBH", false);
            SetVisible(this.Menu1, "DMTHUOC", true);
        }

        #endregion

        
    }
    #region Function Cực hay - Permsion-Visble Menu
    private MenuItem ItemOf(string ValueName, MenuItem item)
    {
        if (item.Value.ToLower() == ValueName.ToLower()) return item;
        if (item.ChildItems.Count == 0) return null;
        for (int i = 0; i < item.ChildItems.Count; i++)
        {
            MenuItem itemI = ItemOf(ValueName, item.ChildItems[i]);
            if (itemI != null) return itemI;
        }

        return null;
    }
    private MenuItem ItemOf(string ValueName, Menu item)
    {
        for (int i = 0; i < item.Items.Count; i++)
        {
            MenuItem itemI = ItemOf(ValueName, item.Items[i]);
            if (itemI != null) return itemI;
        }

        return null;
    }
    private void CheckPermision(MenuItem Item, string ValueName, string PermisionName)
    {
        if (!StaticData.HavePermision(this.Page, PermisionName))
        {
            MenuItem menu = this.ItemOf(ValueName, Item);
            if (menu != null)
            {
                menu.Text = "";
                menu.ImageUrl = "";
                MenuItem mnParent = menu.Parent;
                if (mnParent != null)
                {
                    mnParent.ChildItems.Remove(menu);
                }
            }
        }

    }
    private void CheckPermision(Menu Item, string ValueName, string PermisionName)
    {
        if (!StaticData.HavePermision(this.Page, PermisionName))
        {
            MenuItem menu = this.ItemOf(ValueName, Item);
            if (menu != null)
            {
                menu.Text = "";
                menu.ImageUrl = "";
                MenuItem mnParent = menu.Parent;
                if (mnParent != null)
                {
                    mnParent.ChildItems.Remove(menu);
                }
            }
        }

    }
    private void SetVisible(MenuItem Item, string ValueName, bool IsShow)
    {
        if (!IsShow)
        {
            MenuItem menu = this.ItemOf(ValueName, Item);
            if (menu != null)
            {
                menu.Text = "";
                menu.ImageUrl = "";
                MenuItem mnParent = menu.Parent;
                if (mnParent != null)
                {
                    mnParent.ChildItems.Remove(menu);
                }
            }
        }

    }
    private void SetVisible(Menu Item, string ValueName, bool IsShow)
    {
        if (!IsShow)
        {
            MenuItem menu = this.ItemOf(ValueName, Item);
            if (menu != null)
            {
                menu.Text = "";
                menu.ImageUrl = "";
                MenuItem mnParent = menu.Parent;
                if (mnParent != null)
                {
                    mnParent.ChildItems.Remove(menu);
                }
            }
        }

    }
    #endregion
    
}