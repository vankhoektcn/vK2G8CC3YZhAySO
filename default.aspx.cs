using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DataAcess;
using Process;
using Profess;
using SysParameter;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "QUẢN LÝ BỆNH VIỆN";
        Connect.WebPage = this;
        StaticData.P = this;
        string IsLogin = Request.QueryString["IsLogin"];
        lbLogin.ServerClick += new EventHandler(lbLogin_ServerClick);
        if (IsLogin == null || UserLogin.UserID(this) == "0")
        {
            head.InnerHtml = @"<script type='text/javascript'>
                                   $(document).ready(function(){
                                       $('#lbnIndex').attr('disabled',true);
                                       $('#lbnThuVienPhi').attr('disabled',true);
                                       $('#lbnkhambenh').attr('disabled',true);
                                       $('#lbnCLS').attr('disabled',true);
                                       $('#lbnKhoaSan').attr('disabled',true);
                                       $('#lbnCapCuu').attr('disabled',true);
                                       $('#lbnNoiTru').attr('disabled',true);
                                       $('#lbnKhoaPhauThuat').attr('disabled',true);
                                       $('#lbnKhoaDuoc').attr('disabled',true);
                                       $('#lbnThuocBH').attr('disabled',true);
                                       $('#lbnHanhChinh').attr('disabled',true);
                                       $('#lbnKeToan').attr('disabled',true);
                                       $('#lbnNhanSu').attr('disabled',true);
                                       $('#lbnThongKe').attr('disabled',true);
                                       $('#GiamDinhBHYT').attr('disabled',true);
                                       $('#lbnQuanLyND').attr('disabled',true);
                                       $('#lbnChangePass').attr('disabled',true);
                                       $('#lbnThuocDV ').attr('disabled',true);
                                       $('#lbSieuAm ').attr('disabled',true);
                                       $('#lbXQuang').attr('disabled',true);
                                   });
                               </script>";
            lbLogin.InnerHtml = "<u>Đ</u>ăng nhập";
            imgLogin.Src = "~/images/login.png";
        }
        else
        {
            this.lbLogin.InnerHtml = "<u>Đ</u>ăng xuất";
            imgLogin.Src = "~/images/logout.png";
            bool IsAdmin = Userlogin.HavePermision(this, "Admin");
            string GroupID = UserLogin.GroupID(this);
            string GroupName = "";
            if (GroupID != null && GroupID != "0" && GroupID != "")
            {
                DataTable dtTemp = Connect.GetTable("SELECT NAMENOTSIGN FROM NHOMNGUOIDUNG WHERE NHOMID=" + GroupID);
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    GroupName = dtTemp.Rows[0][0].ToString().ToLower();
                    if (GroupName.ToLower() == "admin") IsAdmin = true;
                }
            }
            bool a = !(IsAdmin || GroupName == "tiepnhan" || GroupName == "tiepnhanthuphi" || Userlogin.HavePermision(this, "TiepNhan"));
            bool b = !(IsAdmin || GroupName == "thuphi" || GroupName == "tiepnhanthuphi" || Userlogin.HavePermision(this, "ThuPhi"));
            bool c = !(IsAdmin || GroupName == "khambenh" || Userlogin.HavePermision(this, "KhamBenh"));
            bool d = !(IsAdmin || GroupName == "canlamsang" || Userlogin.HavePermision(this, "CanLamSang"));
            bool ee = !(IsAdmin || GroupName == "khoasan" || GroupName == "phukhoa" || GroupName == "tresosinh" || Userlogin.HavePermision(this, "khoasan") || Userlogin.HavePermision(this, "phukhoa") || Userlogin.HavePermision(this, "tresosinh"));
            bool f = !(IsAdmin || GroupName == "capcuu" || Userlogin.HavePermision(this, "capcuu"));
            bool g = !(IsAdmin || GroupName == "khoanoi" || GroupName == "khoangoai" || Userlogin.HavePermision(this, "khoanoi") || Userlogin.HavePermision(this, "khoangoai"));
            bool h = !(IsAdmin || GroupName == "phauthuat" || Userlogin.HavePermision(this, "phauthuat"));
            bool i = !(IsAdmin || GroupName == "khoaduoc" || Userlogin.HavePermision(this, "khoaduoc"));
            bool k = !(IsAdmin || GroupName == "nhathuocbh" || Userlogin.HavePermision(this, "NhaThuocBH"));
            bool l = !(IsAdmin || GroupName == "khohcqt" || Userlogin.HavePermision(this, "KhoHCQT"));
            bool m = !(IsAdmin || GroupName == "ketoan" || Userlogin.HavePermision(this, "KeToan"));
            bool n = !(IsAdmin || GroupName == "nhansu" || Userlogin.HavePermision(this, "nhansu"));
            bool o = !(IsAdmin || GroupName == "thongketonghop" || Userlogin.HavePermision(this, "ThongKeTongHop"));
            bool p = !(IsAdmin || GroupName == "GiamDinhBHYT" || Userlogin.HavePermision(this, "GiamDinhBHYT"));
            bool q = !(IsAdmin || GroupName == "user" || Userlogin.HavePermision(this, "user"));
            bool nhathuocdv = !(IsAdmin || GroupName == "nhathuocdv" || Userlogin_new.HavePermision(this, "nhathuocdv"));
            bool sieuam = !(IsAdmin || GroupName == "sieuam" || Userlogin_new.HavePermision(this, "sieuam"));
            bool xquang = !(IsAdmin || GroupName == "xquang" || Userlogin_new.HavePermision(this, "xquang"));
            head.InnerHtml = @"<script type='text/javascript'>
                                   $(document).ready(function(){
                                       $('#lbnIndex').attr('disabled'," + a.ToString().ToLower() + @");
                                       $('#lbnThuVienPhi').attr('disabled'," + b.ToString().ToLower() + @");
                                       $('#lbnkhambenh').attr('disabled'," + c.ToString().ToLower() + @");
                                       $('#lbnCLS').attr('disabled'," + d.ToString().ToLower() + @");
                                       $('#lbnKhoaSan').attr('disabled'," + ee.ToString().ToLower() + @");
                                       $('#lbnCapCuu').attr('disabled'," + f.ToString().ToLower() + @");
                                       $('#lbnNoiTru').attr('disabled'," + g.ToString().ToLower() + @");
                                       $('#lbnKhoaPhauThuat').attr('disabled'," + h.ToString().ToLower() + @");
                                       $('#lbnKhoaDuoc').attr('disabled'," + i.ToString().ToLower() + @");
                                       $('#lbnThuocBH').attr('disabled'," + k.ToString().ToLower() + @");
                                       $('#lbnHanhChinh').attr('disabled'," + l.ToString().ToLower() + @");
                                       $('#lbnKeToan').attr('disabled'," + m.ToString().ToLower() + @");
                                       $('#lbnNhanSu').attr('disabled'," + n.ToString().ToLower() + @");
                                       $('#lbnThongKe').attr('disabled'," + o.ToString().ToLower() + @");
                                       $('#GiamDinhBHYT').attr('disabled'," + p.ToString().ToLower() + @");
                                       $('#lbnQuanLyND').attr('disabled'," + q.ToString().ToLower() + @");
                                       $('#lbnChangePass').attr('disabled',false);
                                       $('#lbnThuocDV').attr('disabled'," + nhathuocdv.ToString().ToLower() + @");
                                       $('#lbSieuAm').attr('disabled'," + sieuam.ToString().ToLower() + @");
                                       $('#lbXQuang').attr('disabled'," + xquang.ToString().ToLower() + @");
                                   });
                               </script>";
        }

    }
    protected void lbLogin_ServerClick(object sender, EventArgs e)
    {
        string sUerID = UserLogin.UserID(this);
        if (sUerID == null || sUerID == "" || sUerID == "0" || Request.QueryString["IsLogin"] == null)
            Response.Redirect("sys_/sys_login.aspx");
        else
        {
            head.InnerHtml = @"<script type='text/javascript'>
                               $(document).ready(function(){
                                       $('#lbnIndex').attr('disabled',true);
                                       $('#lbnThuVienPhi').attr('disabled',true);
                                       $('#lbnkhambenh').attr('disabled',true);
                                       $('#lbnCLS').attr('disabled',true);
                                       $('#lbnKhoaSan').attr('disabled',true);
                                       $('#lbnCapCuu').attr('disabled',true);
                                       $('#lbnNoiTru').attr('disabled',true);
                                       $('#lbnKhoaPhauThuat').attr('disabled',true);
                                       $('#lbnKhoaDuoc').attr('disabled',true);
                                       $('#lbnThuocBH').attr('disabled',true);
                                       $('#lbnHanhChinh').attr('disabled',true);
                                       $('#lbnKeToan').attr('disabled',true);
                                       $('#lbnNhanSu').attr('disabled',true);
                                       $('#lbnThongKe').attr('disabled',true);
                                       $('#GiamDinhBHYT').attr('disabled',true);
                                       $('#lbnQuanLyND').attr('disabled',true);
                                       $('#lbnChangePass').attr('disabled',true);
                                       $('#lbnThuocDV ').attr('disabled',true);
                                       $('#lbSieuAm ').attr('disabled',true);
                                       $('#lbXQuang').attr('disabled',true);
                                 });
                             </script>";
            bool ok = UserLogin.RemoveLogin(this);
            Response.Cookies["User"].Value = null;
            this.lbLogin.InnerHtml = "<u>Đ</u>ăng nhập";
            imgLogin.Src = "~/images/login.png";
            string url = Request.Url.AbsoluteUri.Split('?')[0];
            Response.Redirect(url);
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        DisableClientCaching();
    }
    private void DisableClientCaching()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddYears(-1));
    }

}
