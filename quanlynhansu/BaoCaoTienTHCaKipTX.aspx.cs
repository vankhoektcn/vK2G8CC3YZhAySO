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
public partial class BaoCaoTienTHCaKipTX : Page
{
    clsBaoCaoTHCaKipTX THNC = null;
    string tungay = "";
    string denngay = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            BindListBSKoTX();
            txttungay.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtdenngay.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
        }
    }

    private void BindListBSKoTX()
    {
        string sql = @"SELECT DISTINCT bs.idNhanVien,nv.tennhanvien
FROM dbo.BSPhauThuat bs
LEFT JOIN dbo.NhanVien nv ON bs.idNhanVien = nv.idnhanvien
LEFT JOIN dbo.ChiTietPhuCapBacSiPhauThuat pc ON pc.idchitietPCBSPT=bs.idchitietPCBSPT
WHERE pc.idvaitroBSPT=1 and loainhanvien=0 
ORDER BY nv.tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count >= 0)
        {
            StaticData.FillCombo(ddlBSKoThuongXuyen, dt, "idnhanvien", "tennhanvien", "--BS phẫu thuật chính--");
        }

    }

    protected void btnGetDanhSach_Click(object sender, EventArgs e)
    {
        tungay = txttungay.Text;
        denngay =txtdenngay.Text ;
        THNC = new clsBaoCaoTHCaKipTX();
        THNC.tungay = tungay;
        THNC.denngay =denngay;
        THNC.idbacsichinh = ddlBSKoThuongXuyen.SelectedValue.ToString();
        THNC.AfterExportToExcel += new ExportToExcel.Profess_ExportToExcelByCode.AfterExportToExcelHandle(THNC_AfterExportToExcel);
        THNC.ExportToExcel();
    }

    void THNC_AfterExportToExcel()
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + "../ReportOutput/" +THNC.OutputFileName + "\",'_blank')</script>");
    }
}
