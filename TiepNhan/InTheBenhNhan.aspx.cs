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
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
using System.Text;

public partial class nhanbenh_InTheBenhNhan : Genaratepage
{
    string mabenhnhan = "";
    ReportDocument crystalReport;
    protected void Page_Load(object sender, EventArgs e)
    {
        mabenhnhan = Request.QueryString["mabenhnhan"];// Session["maBN"].ToString(); ;
        if (!string.IsNullOrEmpty(mabenhnhan))
        {
            if (!IsPostBack)
            {
                loadReport(mabenhnhan);
            }
            else
            {
                loadReport(mabenhnhan);
            }
        }
    }

    //load report in the benh nhan --duphuoc 10/11/2010
    private void loadReport(string mabenhnhan)
    {
        #region Init Report
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../report/crptTheBenhNhan.rpt"));
        #endregion
        #region Thong tin benh nhan = dtbenhnhan
        string sql = "select mabenhnhan, diachi, ngaytiepnhan, tenbenhnhan,ngaysinh,ngaysinh as ns from benhnhan where mabenhnhan = '"+mabenhnhan+"'";
        DataTable dtbenhnhan = DataAcess.Connect.GetTable(sql);
        iTextSharp.text.pdf.Barcode128 barcode = new iTextSharp.text.pdf.Barcode128();
        barcode.ChecksumText = false;
        barcode.Code = dtbenhnhan.Rows[0]["mabenhnhan"].ToString();
        System.Drawing.Image bmp = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
        Byte[] arrByte = (Byte[])System.ComponentModel.TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
        dtbenhnhan.Columns.Add("hinhmavach", arrByte.GetType());
        dtbenhnhan.Rows[0]["hinhmavach"] = arrByte;


        //hienthi.Text = "<div  align=center>";
        //hienthi.Text += "<img src='../images/thevantam.png' width=300>";
        //hienthi.Text += "<div style='height:50px;'>&nbsp;</div><img src='PhieuDangKyKham/mavach.ashx?mabenhnhan=" + dtbenhnhan.Rows[0]["mabenhnhan"] + "'>";
        //hienthi.Text += "<br><span style='letter-spacing:2px;'>" + dtbenhnhan.Rows[0]["mabenhnhan"] + "</span>";
        //hienthi.Text += "</div>";
       // hienthi.Text = dtbenhnhan.Rows[0]["mabenhnhan"] + "" + s;

        if (dtbenhnhan.Rows[0]["ns"] == DBNull.Value)
        {
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtNS"]).Text = "";
        }
        else
        {
            ((TextObject)crystalReport.ReportDefinition.ReportObjects["txtNS"]).Text=dtbenhnhan.Rows[0]["ns"].ToString();
        }
        #endregion
        #region Thong tin DonVi = dtCompanyInfor
        string sqlSelectCompanyInfor = "SELECT  top 1 * from TieuDeCty";
        DataTable dtCompanyInfor = DataAcess.Connect.GetTable(sqlSelectCompanyInfor);
        string tieude = dtCompanyInfor.Rows[0]["Ten_Cty"].ToString();
        string[] slp = tieude.Split('-');
        string til = slp[0];
        string subtil = (slp.Length > 1 ? slp[1] : "");
        //((TextObject)crystalReport.ReportDefinition.ReportObjects["txtSubtitle"]).Text = subtil;
        //((TextObject)crystalReport.ReportDefinition.ReportObjects["txtTitle"]).Text = til;
        #endregion
        #region DataSource= dtBenhNhan+dtCompanyInfor
        DataTable dt = new DataTable();
        for (int i = 0; i < dtbenhnhan.Columns.Count; i++)
        {
            dt.Columns.Add(dtbenhnhan.Columns[i].ColumnName, dtbenhnhan.Columns[i].DataType);
        }
        for (int i = 0; i < dtCompanyInfor.Columns.Count; i++)
        {
            dt.Columns.Add(dtCompanyInfor.Columns[i].ColumnName, dtCompanyInfor.Columns[i].DataType);
        }
        DataRow R = dt.NewRow();
            R["ID_TT"]= dtCompanyInfor.Rows[0]["ID_TT"] ; 
            R["Ten_Cty"]= dtCompanyInfor.Rows[0]["Ten_Cty"] ; 
            R["DiaChi"]= dtCompanyInfor.Rows[0]["DiaChi"] ;
            R["DienThoai"] = "Đt: " + dtCompanyInfor.Rows[0]["DienThoai"] + "  -   Fax: " + dtCompanyInfor.Rows[0]["Fax"]; 
            R["Fax"]= dtCompanyInfor.Rows[0]["Fax"] ; 
            R["SoThue"]= dtCompanyInfor.Rows[0]["SoThue"] ;
            R["Email"] = "Email: " +dtCompanyInfor.Rows[0]["Email"]; 
            R["Website"]= "Website: "+dtCompanyInfor.Rows[0]["Website"] ; 
            R["Logo"]= dtCompanyInfor.Rows[0]["Logo"] ; 
            R["Logo_image"]= dtCompanyInfor.Rows[0]["Logo_image"] ; 

            R["hinhmavach"]= dtbenhnhan.Rows[0]["hinhmavach"];
            R["mabenhnhan"] = dtbenhnhan.Rows[0]["mabenhnhan"];
            R["tenbenhnhan"] = dtbenhnhan.Rows[0]["tenbenhnhan"].ToString().ToUpper();
            R["ngaytiepnhan"] = dtbenhnhan.Rows[0]["ngaytiepnhan"];
            dt.Rows.Add(R);

        #endregion
        #region Set Report Souce

        crystalReport.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = crystalReport;
        
        CrystalReportViewer1.DataBind();
        #endregion
    }
    
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    //protected void btnin_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        Session["ctrl"] = hienthi;
    //        PrintView.PrintCall(Page);
    //    }
    //    catch
    //    { }
    //}
    
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(crystalReport);
    }
    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(form_unload);
    }
    #endregion
}
