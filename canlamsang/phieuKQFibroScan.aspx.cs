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

public partial class phieuKQFibroScan : System.Web.UI.Page
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
            string sqlKQ = string.Format(@" select convert(varchar(10), cls.ngaykham, 103) as NgayThang,cls.giatrichung,bn.ngaysinh,chandoan=kbcls.chandoansobo,KQDieuTri=cls.ketqua,tenBSChiDinh=TenBSChiDinh,BSCLS=bs.tenbacsi,tenbenhnhan,mabenhnhan,bn.diachi,
										kbcls.chandoansobo,tuoi=[dbo].kb_GetTuoi(bn.ngaysinh),cls.soID madangkyCLS,GioiTinh=dbo.GetGioiTinh(bn.gioitinh) from benhnhan bn
                                        left join dieutricanlamsan cls on cls.idbenhnhan=bn.idbenhnhan
										left join khambenhcanlamsan kbcls on kbcls.idbenhnhan=cls.idbenhnhan and kbcls.madangkyCLS=cls.soID
                                        left join bacsi bs on bs.idbacsi=cls.idbacsi
                                        left join bacsi bss on bs.idbacsi=kbcls.idbacsichidinh
                                        left join chandoansobo cd on cd.maphieucls=kbcls.maphieucls and cls.idphongkhambenh=cd.idkhoaphong
                                        where cls.idbenhnhan={0} and cls.iddieutricanlamsan={1} order by cls.ngaykham DESC", idbn, iddieutri);
            DataTable dtKQ = DataAcess.Connect.GetTable(sqlKQ);
            if (dtKQ != null)
            {
                string infoBN = "";
                infoBN += "  <table style=\"width:95%\">" + "\r\n";
                infoBN += "                 <tr>" + "\r\n";
                infoBN += "                     <td style=\"width:15%\">Patient ID:</td>" + "\r\n";
                infoBN += "                     <td style=\"width:50%\">" + dtKQ.Rows[0]["mabenhnhan"].ToString() + "</td>" + "\r\n";
                infoBN += "                     <td style=\"width:17%\">Date of Scan:</td>" + "\r\n";
                infoBN += "                     <td style=\"width:25%\">" + dtKQ.Rows[0]["NgayThang"].ToString() + "</td>" + "\r\n";
                infoBN += "                 </tr>" + "\r\n";
                infoBN += "                 <tr>" + "\r\n";
                infoBN += "                     <td style=\"width: 15%\">Name:</td>" + "\r\n";
                infoBN += "                     <td style=\"width:50%\">" + dtKQ.Rows[0]["tenbenhnhan"].ToString() + "</td>" + "\r\n";
                infoBN += "                     <td style=\"width:15%\">Indication:</td>" + "\r\n";
                infoBN += "                     <td></td>" + "\r\n";
                infoBN += "                 </tr>" + "\r\n";
                      infoBN += "                 <tr>" + "\r\n";
                      infoBN += "                     <td style=\"width:15%\">Birth Date:</td>" + "\r\n";
                      infoBN += "                     <td style=\"width:50%\">" + dtKQ.Rows[0]["ngaysinh"].ToString() + "</td>" + "\r\n";
                infoBN += "                     <td style=\"width: 15%\">Sex:</td>" + "\r\n";
                infoBN += "                     <td style=\"width:20%\">" + dtKQ.Rows[0]["gioitinh"].ToString() + "</td>" + "\r\n";
                infoBN += "                 </tr>" + "\r\n";
                infoBN += "                </table>" + "\r\n";
                divBenhNhan.InnerHtml = infoBN;
                lblScore.Text = "YOUR FIBROSCAN® SCORE (Median LSM)is: ";
                lblGiaTriChung.Text="&nbsp;"+dtKQ.Rows[0]["giatrichung"].ToString()+" KPa";
                giatrichung.Value = dtKQ.Rows[0]["giatrichung"].ToString();
                divKQ.InnerHtml = dtKQ.Rows[0]["KQDieuTri"].ToString();
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
