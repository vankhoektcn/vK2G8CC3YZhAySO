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

public partial class phieuKQXetNghiem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadKQSieuAm();
    }
    private void loadKQSieuAm()
    {
        try
        {
            //int idbn = StaticData.ParseInt(Request.QueryString["idbn"].ToString());
            int iddieutri = StaticData.ParseInt(Request.QueryString["id"].ToString());
            string sqlBN = string.Format(@"select chandoan=kbcls.chandoansobo,cls.ketqua,mabenhnhan,tenbenhnhan,bn.diachi,tuoi=right(bn.ngaysinh,4),cls.SoID,bn.dienthoai,cls.SoID madangkycls,
                                    GioiTinh=dbo.GetGioiTinh(bn.gioitinh),bacsi=TenBSChiDinh,
                                    kbcls.chandoansobo from benhnhan bn left join dieutricanlamsan cls on cls.idbenhnhan=bn.idbenhnhan
                                    left join khambenhcanlamsan kbcls on kbcls.idbenhnhan=cls.idbenhnhan and kbcls.madangkyCLS=cls.soID
                                    left join bacsi bs on bs.idbacsi=kbcls.idbacsichidinh
                                    where iddieutricanlamsan={0} order by cls.ngaykham DESC ", iddieutri);
            DataTable dtKQ = DataAcess.Connect.GetTable(sqlBN);
            if (dtKQ != null)
            {
                string infoBN = "";
                infoBN += "<table style=\"width:100%\">";
                infoBN += "<tr>";
                infoBN += "<td style=\"width:55%;font-weight:bold;font-size:22px;\">&nbsp;Họ tên BN&nbsp;:<b>&nbsp; " + dtKQ.Rows[0]["tenbenhnhan"].ToString() + "</b> </td>";
                infoBN += "<td style=\"padding-left:2%;width:55%;font-weight:bold;font-size:22px;\">&nbsp;Năm sinh&nbsp;:&nbsp;" + dtKQ.Rows[0]["Tuoi"].ToString() + "&nbsp;&nbsp;&nbsp;<span style=\"text-align:right\">Giới tính :&nbsp;" + dtKQ.Rows[0]["GioiTinh"].ToString() + "</span></td></tr>";
                infoBN += "<tr><td style=\"width:55%;font-weight:bold;font-size:22px;\">&nbsp;Mã CLS&nbsp;:&nbsp;" + dtKQ.Rows[0]["madangkycls"].ToString() + "</td>";
                infoBN += "<td style=\"padding-left:2%;width:50%;font-weight:bold;font-size:22px;\">&nbsp;Điện thoại&nbsp;:&nbsp;" + dtKQ.Rows[0]["dienthoai"].ToString() + "</td></tr>";
                infoBN += "<tr><td style=\"width:55%;font-weight:bold;font-size:22px;\">&nbsp;BS Chỉ định&nbsp;:&nbsp;&nbsp;" + dtKQ.Rows[0]["bacsi"].ToString() + "</td>";
                infoBN += "<td style=\"padding-left:2%;width:50%;font-weight:bold;font-size:22px;\">&nbsp;Chẩn đoán&nbsp;:&nbsp;" + dtKQ.Rows[0]["chandoan"].ToString() + "</td></tr>";
                infoBN += "</table>";
                divBenhNhan.InnerHtml = infoBN;
                lblKQ.InnerHtml = dtKQ.Rows[0]["ketqua"].ToString();
                //lblngay.InnerHtml = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");
                //lblBSLamCLS.InnerHtml = dtKQ.Rows[0]["BSCLS"].ToString();
            }
            else
            {
                StaticData.MsgBox(this, "Bệnh nhân không tồn tại!");
                return;
            }
        }
        catch
        {
            Response.Write("Bệnh nhân này chưa được đăng ký siêu âm");
            return;
        }
       
    }
}
