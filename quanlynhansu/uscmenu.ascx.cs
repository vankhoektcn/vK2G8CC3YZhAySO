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

public partial class nhanbenh_uscmenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SysParameter.UserLogin.GroupID(this.Page) != null)
        {
            string dd = SysParameter.UserLogin.GroupID(this.Page).ToString();

            if (dd == "16" || dd == "4")
            {
                return;
            
            }
            else
            {
                enableitem();
            }

        }
    }
    protected void Menu1_MenuItemDataBound(object sender, MenuEventArgs e)
    {


    }
    private void enableitem()
    {


        MenuItemCollection items = this.Menu1.Items;
        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items[i].ChildItems.Count; j++)
            {

                if (items[i].ChildItems[j].Value == "cctn" || items[i].ChildItems[j].Value == "CCTH" )
                {
                    DataTable table = DataAcess.Connect.GetTable(@"select * from chucvu cv
                            left join nhanvien nv on nv.idchucvu = cv.idchucvu
                            left join nguoidung nd on nd.idnhanvien = nv.idnhanvien where nd.idnguoidung='" + SysParameter.UserLogin.UserID(this.Page) + "' and cv.chamcong=1");
                    if (table != null)
                    {
                        if (table.Rows.Count > 0)
                        {
                            items[i].ChildItems[j].Enabled = true;
                        }
                        else
                        {
                            items[i].ChildItems[j].Enabled = false;
                        }

                    }
                    else
                    {
                        items[i].ChildItems[j].Enabled = false;
                    }
                }
                else if (items[i].ChildItems[j].Value == "cccpt" || items[i].ChildItems[j].Value == "THBNPT")
                {
                      DataTable table1 = DataAcess.Connect.GetTable(@"select * from phongban pb
                            left join nhanvien nv on nv.idphongban = pb.idphongban
                            left join nguoidung nd on nd.idnhanvien = nv.idnhanvien where nd.idnguoidung='" + SysParameter.UserLogin.UserID(this.Page) + "' and pb.idphongban=38");
                    if (table1 != null )
                    {
                        if (table1.Rows.Count > 0)
                        {
                            items[i].ChildItems[j].Enabled = true;
                        }
                        else
                        {
                            items[i].ChildItems[j].Enabled = false;
                        }

                    }
                    else
                    {
                        items[i].ChildItems[j].Enabled = false;
                    }
                }
                else if (items[i].ChildItems[j].Value == "PTKoTX" || items[i].ChildItems[j].Value == "PTTX")
                {
                    DataTable table1 = DataAcess.Connect.GetTable(@"select * from phongban pb
                            left join nhanvien nv on nv.idphongban = pb.idphongban
                            left join nguoidung nd on nd.idnhanvien = nv.idnhanvien where nd.idnguoidung='" + SysParameter.UserLogin.UserID(this.Page) + "' and pb.idphongban=39");
                    if (table1 != null)
                    {
                        if (table1.Rows.Count > 0)
                        {
                            items[i].ChildItems[j].Enabled = true;
                        }
                        else
                        {
                            items[i].ChildItems[j].Enabled = false;
                        }

                    }
                    else
                    {
                        items[i].ChildItems[j].Enabled = false;
                    }
                }
                else 
                {
                    items[i].ChildItems[j].Enabled = false;
                }
            }

        }
    }
}
