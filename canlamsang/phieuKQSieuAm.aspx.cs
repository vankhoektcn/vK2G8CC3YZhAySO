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

public partial class canlamsang_phieuKQSieuAm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadTenCty();
        loadKQSieuAm();
    }
    private void loadTenCty()
    {
        //DataTable dtCty = Process.TieuDeCty.dtGetAll();
        //spCty.InnerHtml = "PHÒNG KHÁM CHẨN ĐOÁN Y KHOA";
        //spDC.InnerHtml = "Địa chỉ:" + dtCty.Rows[0]["DiaChi"].ToString();
        //spDT.InnerHtml = "Điện thoại:" + dtCty.Rows[0]["DienThoai"].ToString() + "* Fax:" + dtCty.Rows[0]["Fax"].ToString();
        //spHeader.InnerHtml = "KẾT QUẢ SIÊU ÂM BỤNG";
    }
    private void loadKQSieuAm()
    {
        try
        {
            int idbn = StaticData.ParseInt(Request.QueryString["idbn"].ToString());
            int iddieutri = StaticData.ParseInt(Request.QueryString["id"].ToString());
            string sqlKQ = string.Format(@" select chandoan=kbcls.chandoansobo,KQSieuAm=cls.ketqua,tenBSChiDinh=TenBSChiDinh,BSCLS=bs.tenbacsi,tenbenhnhan,mabenhnhan,bn.diachi,
										kbcls.chandoansobo,tuoi=[dbo].kb_GetTuoi(bn.ngaysinh),cls.soID madangkyCLS,GioiTinh=dbo.GetGioiTinh(bn.gioitinh) from benhnhan bn
                                        left join dieutricanlamsan cls on cls.idbenhnhan=bn.idbenhnhan
										left join khambenhcanlamsan kbcls on kbcls.idbenhnhan=cls.idbenhnhan and kbcls.madangkyCLS=cls.soID
                                        left join bacsi bs on bs.idbacsi=cls.idbacsi
                                        --left join chandoansobo cd on cd.maphieucls=kbcls.maphieucls and cls.idphongkhambenh=cd.idkhoaphong
                                        where cls.idbenhnhan={0} and cls.iddieutricanlamsan={1} order by cls.ngaykham DESC", idbn, iddieutri);
            DataTable dtKQ = DataAcess.Connect.GetTable(sqlKQ);
            if (dtKQ != null)
            {
                string infoBN = "";
                infoBN = "<table  width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" rules=\"all\" style=\"text-align:top\">";
                infoBN += "<tr>";
                infoBN += "<td style=\"width:50%;font-weight:normal;font-size:24px;border:1px solid #000000; border-bottom: none;height:35px\">&nbsp;Họ tên BN:<b>&nbsp; " + dtKQ.Rows[0]["tenbenhnhan"].ToString() + "</b> </td>";
                infoBN += "<td style=\"width:50%;line-height:110%;font-weight:normal;;font-size:24px;border:1px solid #000000; border-bottom: none;height:35px\">&nbsp;Tuổi:&nbsp;" + dtKQ.Rows[0]["Tuoi"].ToString() + "<span style=\"padding-left:20%\">Giới tính :&nbsp;" + dtKQ.Rows[0]["GioiTinh"].ToString() + "</span></td></tr>";
                infoBN += "<td style=\"width:40%;font-weight:normal;font-size:24px;border:1px solid #000000; border-bottom: none;height:35px\">&nbsp;Mã CLS:&nbsp;" + dtKQ.Rows[0]["madangkyCLS"].ToString() + "</td>";
                infoBN += "<td style=\"width:60%;line-height:110%;font-weight:normal;;font-size:24px;border:1px solid #000000; border-bottom: none;height:35px\">&nbsp;Địa chỉ:&nbsp;" + dtKQ.Rows[0]["DiaChi"].ToString() + "</td></tr>";
                infoBN += "<td style=\"width:50%;line-height:110%;width:400px;font-size:24px;font-weight:normal;border:1px solid #000000; border-bottom: none;height:40px\">&nbsp;BS Chỉ định:&nbsp;&nbsp;" + dtKQ.Rows[0]["tenBSChiDinh"].ToString() + "</td>";
                infoBN += "<td style=\"width:50%;font-weight:normal;border:1px solid #000000;border-bottom: none;font-size:24px;height:35px\">&nbsp;BS Siêu âm:&nbsp;" + dtKQ.Rows[0]["BSCLS"].ToString() + "</td></tr>";
                infoBN += "<td style=\"width:100%;font-weight:normal;font-size:24px;border:1px solid #000000;border-bottom: none; height:35px\" colspan=\"2\"><b><u>&nbsp;Chẩn đoán:</u></b>&nbsp;" + dtKQ.Rows[0]["chandoan"].ToString() + "</td></tr>";
                infoBN += "</table>";
                divBenhNhan.InnerHtml = infoBN;
                lblKQ.InnerHtml = dtKQ.Rows[0]["KQSieuAm"].ToString();
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
