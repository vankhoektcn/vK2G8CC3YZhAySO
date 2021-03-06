using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class index1 : System.Web.UI.Page//System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CurThang"] = DateTime.Now.Month.ToString();
        Session["CurNam"] = DateTime.Now.Year.ToString();
        if (!IsPostBack)
        {
            LoadPage();
        }
    }
    private void LoadPage()
    { 
        string strSQL="";
        string html = "";
        Session["tennguoidung"] = SysParameter.UserLogin.FullName(this);
        Session["idnguoidung"] = SysParameter.UserLogin.UserID(this);
        string role = SysParameter.UserLogin.GroupID(this);
        string strtennguoidung = "";
        if (Session["tennguoidung"] == null)
            Response.Redirect("../login.aspx");
        int iidnguoidung = Convert.ToInt16(Session["idnguoidung"]);
        string strktkho = "", strktmh = "", strktbh = "", strkttm = "", strktnh = "", strhtdm="";
        string strktpt = "", strktpr = "", strktts = "", strktth = "", strbctc = "", strbcthue = "",strkttscd="";
        //strSQL = " Select a.* From NhomNSD a join ChiTietNhomNSD b on a.IDNhom=b.IDNhom Where b.IDNguoiDung=" + iidnguoidung;
        //DataTable dt = mdlCommonFunction.LoadDataTable(strSQL, conn);
        //if (dt != null && dt.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
                //if (dt.Rows[i]["TenGroup"].ToString() == "KTKHO")
                    strktkho = "KTKHO";
              //  if (dt.Rows[i]["TenGroup"].ToString() == "KTMH")
                    strktmh = "KTMH";
               // if (dt.Rows[i]["TenGroup"].ToString() == "KTBH")
                    strktbh = "KTBH";
              //  if (dt.Rows[i]["TenGroup"].ToString() == "KTTM")
                    strkttm = "KTTM";
              //  if (dt.Rows[i]["TenGroup"].ToString() == "KTNH")
                    strktnh = "KTNH";
              //  if (dt.Rows[i]["TenGroup"].ToString() == "KTPT")
                    strktpt = "KTPT";
              //  if (dt.Rows[i]["TenGroup"].ToString() == "KTPR")
                    strktpr = "KTPR";
             //   if (dt.Rows[i]["TenGroup"].ToString() == "KTTS")
                    strktts = "KTTS";
               // if (dt.Rows[i]["TenGroup"].ToString() == "KTTH")
                    strktth = "KTTH";
              //  if (dt.Rows[i]["TenGroup"].ToString() == "BCTC")
                    strbctc = "BCTC";
              // if (dt.Rows[i]["TenGroup"].ToString() == "BCTTHUE")
                    strbcthue = "BCTTHUE";
             //   if (dt.Rows[i]["TenGroup"].ToString() == "HTDM")
                    strhtdm = "HTDM";
                    strkttscd = "TSCD";
           // }
       // }
        html ="<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> ";
        html+="  <tr> ";
        html+="      <td width=\"10%\">&nbsp;</td> ";
        if (strhtdm == "HTDM")
            html += "      <td class=\"menu\" style=\"width: 376px\"><img src=\"../images/customer.gif\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;&nbsp;<a href = \"../ketoan/ketoan_hethong.aspx?dkmenu=kthethong\"><b>HỆ THỐNG </b></a></td> ";
        if (strkttm == "KTTM")
            html+="      <td class=\"menu\" style=\"width: 225px\"><img src=\"../images/money.gif\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;&nbsp;<a href = \"../ketoan/ketoantienmat.aspx\"><b>KẾ TOÁN TIỀN MẶT</b></a></td> ";
        if (strktth == "KTTH")
            html+="      <td class=\"menu\" style=\"width: 260px\"><img src=\"../images/bacsi1.png\" width=\"48\" height=\"48\"  align=\"middle\"/>&nbsp;<a href = \"../ketoan/ketoantonghop.aspx\"><b>KT TỔNG HỢP</b></a></td> ";
        html+="      <td width=\"5%\">&nbsp;</td> ";
        html+="    </tr> ";
        html+="    <tr> ";
        html+="      <td colspan=\"5\"><p>&nbsp;</p>                                                                                 </td> ";
        html+="  </tr> ";
        html+="  <tr> ";
        html+="      <td>&nbsp;</td> ";
        if (strktkho =="KTKHO")
            html += "      <td class=\"menu\" style=\"width: 376px\"><img src=\"../images/kho.gif\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;&nbsp;<a href = \"../ketoan/hethongdanhmuc.aspx\"><b>HỆ THỐNG DANH MỤC </b></a></td> ";
        if (strktnh == "KTNH")
            html+="      <td class=\"menu\" nowrap=\"nowrap\" style=\"width: 225px\"><img src=\"../images/user.png\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;&nbsp;<a href = \"../ketoan/ketoannganhang.aspx\"><b><span style=\"font-size: 9pt\">KẾ TOÁN NGÂN HÀNG </span></b><!--</a>--></td> ";
        if (strbctc == "BCTC")
            html+="      <td class=\"menu\" align=\"left\" style=\"width: 260px\"><img src=\"../images/chungtu.gif\" width=\"48\" height=\"48\" align=\"middle\"/><a href = \"../ketoan/BaoCaoTaiChinh.aspx\"><b>BÁO CÁO TÀI CHÍNH </b></a></td> ";
        html+="      <td>&nbsp;</td> ";
        html+="    </tr> ";
	    html+="    <tr> ";
        html+="      <td colspan=\"5\"><p>&nbsp;</p>                                                                                </td> ";
        html+="    </tr> ";
	    html+="    <tr> ";
        html+="      <td>&nbsp;</td> ";
        if (strktmh == "KTMH")
            html += "      <td class=\"menu\" align=\"left\" style=\"width: 376px\"><img src=\"../images/bacsi1.png\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;&nbsp;<a href = \"../ketoan/ketoanhoadondichvu.aspx\"><b>HÓA ĐƠN DV </b></a></td> ";
        if (strktpt == "KTPT")
            html += "      <td class=\"menu\" align=\"left\" style=\"width: 260px\"><img src=\"../images/bacsi1.png\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;<a href = \"../ketoan/ketoancongno.aspx\" <b>KT CÔNG NỢ </b><!--</a>--></td> ";
        if (strbcthue == "BCTTHUE")
            html+="      <td class=\"menu\" align=\"left\" style=\"width: 260px\"><img src=\"../images/chungtu.gif\" width=\"48\" height=\"48\" align=\"middle\"/><a href = \"../ketoan/baocaothue.aspx\"><b>BÁO CÁO THUẾ</b></a></td> ";
        html+="      <td>&nbsp;</td> ";
        html+="    </tr> ";
        html+="    <tr> ";
        html+="      <td colspan=\"5\"><p>&nbsp;</p>                                                                                </td> ";
        html+="    </tr> ";
        html+="    <tr> ";
        html+="      <td>&nbsp;</td> ";
        if (strktbh == "KTBH")
            html += "      <td class=\"menu\" style=\"width: 376px\"><img src=\"../images/khuvuc.png\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;&nbsp;<a href = \"../ketoan/ketoantaisan.aspx\"><b>KẾ TOÁN TSCĐ </b></a></td> ";
        if (strktpr == "KTPR")
            html += "      <td class=\"menu\" nowrap=\"nowrap\" style=\"width: 225px\"><img src=\"../images/user.png\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;&nbsp;<a href = \"../ketoan/ketoancongcudungcu.aspx\"><b>KẾ TOÁN CCDC</b></a></td> ";
        if (strktpr == "KTPR")
            html += "      <td class=\"menu\" nowrap=\"nowrap\" style=\"width: 225px\"><img src=\"../images/user.png\" width=\"48\" height=\"48\" align=\"middle\"/>&nbsp;&nbsp;<a href = \"../KetoanDUOC/Web/index.aspx\"><b>KẾ TOÁN DƯỢC</b></a></td> ";
              
        html+="      <td>&nbsp;</td> ";
        html+="    </tr> ";
        html+="    <tr> ";
        html+="      <td colspan=\"5\" style=\"height: 16px\"><p>&nbsp;</p>                                                                                </td> ";
        html+="  </tr> ";
        html+="  </table> ";
        pageload.InnerHtml = html;
    }
}
