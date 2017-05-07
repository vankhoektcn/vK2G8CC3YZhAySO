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
using System.Data.SqlClient;

public partial class MasterPageThuPhi_New : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      /* if (Session["werwerweoruwe"] == null)
        {
            Response.Write("<script>window.open(\"\",\"_parent\",\"\");window.close();window.open(location.href,\"_blank\",\"location=0,menubar=0,resizable=1,scrollbars=1,status=0,toolbar=0\")</script>");
            Session["werwerweoruwe"] = "werwer";
        }*/
        //if (!IsPostBack)
        //{
            string dkmenu = Request.QueryString["dkmenu"];
            if (dkmenu != null && dkmenu != "")
            {
                if (dkmenu == "capcuu")
                    PlaceHolder1.Controls.Add(LoadControl("~/capcuu/uscmenu.ascx"));
                if (dkmenu == "khoanoi")
                    PlaceHolder1.Controls.Add(LoadControl("~/khoanoi/uscmenu.ascx"));
                if (dkmenu == "khoangoai")
                    PlaceHolder1.Controls.Add(LoadControl("~/khoangoai/uscmenu.ascx"));
                if (dkmenu == "khoasan")
                    PlaceHolder1.Controls.Add(LoadControl("~/khoasan/uscmenu.ascx"));
                if (dkmenu == "phukhoa")
                    PlaceHolder1.Controls.Add(LoadControl("~/phukhoa/uscmenu.ascx"));
                if (dkmenu == "quanlyND")
                    PlaceHolder1.Controls.Add(LoadControl("~/QuanLyNguoiDung/menu_HeThong.ascx"));
                if (dkmenu == "tiepnhan")
                    PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
                if (dkmenu == "phukhoa")
                    PlaceHolder1.Controls.Add(LoadControl("~/PhuKhoa/uscmenu.ascx"));
                if (dkmenu == "kb")
                    PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
                if (dkmenu == "thuphi")
                    PlaceHolder1.Controls.Add(LoadControl("~/thuvienphi/uscmenu.ascx"));
                //if (dkmenu == "thongke")
                //    PlaceHolder1.Controls.Add(LoadControl("~/thongke/uscmenu.ascx"));

            //}
            //else
            //    PlaceHolder1.Controls.Add(LoadControl("~/usercontrols/uscmenu.ascx"));
        }
    }
}
