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

using CrystalDecisions.CrystalReports.Engine;
using DataAcess;
using iTextSharp.text.pdf;

public partial class frmInMaVach : System.Web.UI.Page
{
    private ReportDocument crystalReport = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadReport();
        }
    }
    private void LoadReport()
    {
        string MaBenhNhan = Request.QueryString["MaBenhNhan"];
        if (string.IsNullOrEmpty(MaBenhNhan))
        {
            string IdBenhNhan = Request.QueryString["IdBenhNhan"];
            if (string.IsNullOrEmpty(IdBenhNhan))
            {
                StaticData.MsgBox(this, "Không có thông tin bệnh nhân !");
                return;
            }
            DataTable bn = DataAcess.Connect.GetTable("select mabenhnhan from benhnhan where idbenhnhan ='"+IdBenhNhan+"'");
            if (bn== null || bn.Rows.Count==0)
            {
                StaticData.MsgBox(this, "Không tìm thấy bệnh nhân !");
                return;
            }
            MaBenhNhan = bn.Rows[0]["mabenhnhan"].ToString();
        }
        //DataTable dtmavach = DataAcess.Connect.GetTable("SELECT MaBenhNhan='',MaVach= CONVERT(IMAGE,'') where 1=2");
        crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("../report/MaVach.rpt"));
        //crystalReport.SetParameterValue("@MaBenhNhan", MaBenhNhan);
        iTextSharp.text.pdf.Barcode128 barcode = new iTextSharp.text.pdf.Barcode128();
        barcode.ChecksumText = false;
        barcode.Code = MaBenhNhan;
        DataTable dtmavach = new DataTable();
        DataRow R = dtmavach.NewRow();
        System.Drawing.Image bmp = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
        Byte[] arrByte = (Byte[])System.ComponentModel.TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
        dtmavach.Columns.Add("MaBenhNhan", "".GetType());
        R["MaBenhNhan"] = MaBenhNhan;
        dtmavach.Columns.Add("MaVach", arrByte.GetType());
        R["MaVach"] = arrByte;
        dtmavach.Rows.Add(R);
        //DataRow R1 = dtmavach.NewRow();
        //R1["MaBenhNhan"] = MaBenhNhan;
        //R1["MaVach"] = arrByte;
        //dtmavach.Rows.Add(R1);

        crystalReport.SetDataSource(dtmavach);
        this.crptView.ReportSource = crystalReport;
        this.crptView.DataBind();
        //crystalReport.SetDataSource(dt);
    }
}
