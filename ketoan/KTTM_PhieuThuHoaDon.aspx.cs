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

public partial class ketoan_KTTM_PhieuThuHoaDon : System.Web.UI.Page
{
    string idPhieuThuHoaDon = "";
    string SoPhieuThu = "";
    string MaKH = "";
    string dkmenu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["idPhieuThu"])&&!string.IsNullOrEmpty(Request.QueryString["idPhieuThu"]))
        {
            idPhieuThuHoaDon = Request.QueryString["idPhieuThu"];
            SoPhieuThu = Request.QueryString["SoPT"];
            MaKH = Request.QueryString["MaKH"];
        }
        
          Page page = HttpContext.Current.Handler as Page;
          ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "loadData();", true);

        //Phân quyền
        
        
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        txtNgayLapPhieuThu.Value = DateTime.Now.Date.ToString("dd/MM/yyyy");
       // txtMaPT.Value = mdlCommonFunction.TaoMaSoPhieu("PTHD", "Phieu_Thu", "So_Phieu_Thu", "TuNgay", txtNgayLapPhieuThu.Value.Substring(3, 2).ToString(), "TuNgay",DataAcess.Connect.Conn);
        //string typeHoaDon = SoPhieuThu.Substring(0, 4);

       
        //string typeKhachHang = MaKH.Substring(0, 2);
        //if (typeKhachHang == "BN")
        //{
        //    LoadPhieuThuHoaDon();
        //}
        //else
        //if (typeKhachHang == "KH")
        //{
        //    LoadPhieuThuKhac();
        //}
   
    }
    public void LoadPhieuThuHoaDon()
    {
        //DataTable tablePhieuThu = PhieuThuHoaDon.getPhieuThuofBenhNhanByID(idPhieuThuHoaDon);
        //if (tablePhieuThu!=null)
        //{
        //    for (int i = 0; i < tablePhieuThu.Rows.Count; i++)
        //    {
              
            
                
        //    }
           
       
       
        //}
    }
    public void LoadPhieuThuKhac()
    {
        //DataTable tablePhieuThu = tablePhieuThu = PhieuThuHoaDon.getPhieuThuofKhachHangByID(idPhieuThuHoaDon);
    }
    
}
