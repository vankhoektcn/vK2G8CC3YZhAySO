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
public partial class QLDUOC_Web_frmTheKho : System.Web.UI.Page
{
    ReportDocument R;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindkho();
            this.txtTuNgay.Text = DateTime.Now.ToString("01/MM/yyyy");
            this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            bindLoaiThuoc();
        }
        else
        {
            loaddanhsach(ddlkho.SelectedValue, txtTuNgay.Text, txtDenNgay.Text, this.txtTenThuoc.Text);
        }

    }
    private void bindLoaiThuoc()
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from Thuoc_LoaiThuoc");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(this.chbLoaiThuoc, dt, "LoaithuocID", "TenLoai", "Tất nhóm ");
            chbLoaiThuoc.SelectedValue = "1";

        }
    }

    #region bind kho thuoc
    private void bindkho()
    {
        DataTable dt = StaticData.dtGetKho(this, false);
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddlkho, dt, "idkho", "tenkho", "----------Chọn kho-----------");
            this.ddlkho.SelectedValue = StaticData.MacDinhKhoNhapMuaID;
            this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    #endregion

    #region get don vi tinh
    private string getiddonvitinh(string idthuoc)
    {
        DataTable dt = DataAcess.Connect.GetTable("select iddvt from thuoc where idthuoc = " + idthuoc);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt.Rows[0]["iddvt"].ToString();
        }
        else
        {
            return null;
        }
    }
    #endregion
    #region get ten kho
    private string gettenkho(string idkho)
    {
        DataTable dt = DataAcess.Connect.GetTable("select tenkho from khothuoc where idkho = " + idkho);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt.Rows[0]["tenkho"].ToString();
        }
        else
        {
            return null;
        }
    }
    #endregion



    private void loaddanhsach(string idkho, string tungay, string denngay, string tenthuoc)
    {
        if (idkho == null || idkho == "") idkho = "0";
        string idthuoc = null;
        if (tenthuoc != null && tenthuoc != "")
            idthuoc = DataAcess.Connect.GetTable("SELECT IDTHUOC FROM THUOC WHERE ISTHUOCBV=1 AND  TENTHUOC=N'" + tenthuoc + "'").Rows[0][0].ToString();
        if (idthuoc == null || idthuoc == "") idthuoc = "0";
        string sqlthekho = "";
        string LoaiBieuMauThe = StaticData.GetParameter("BieuMauTheKho");
        if (LoaiBieuMauThe == "1")
        {
            sqlthekho = "select * from dbo.Thuoc_TheKho_Multi_Mau1 ('" + idkho + "', '" + StaticData.CheckDate(tungay) + "', '" + StaticData.CheckDate(denngay) + " 23:59:59', '" + idthuoc + "') order by tenkho, tenthuoc, ngaychungtu";
        }
        else
            sqlthekho = "select * from dbo.[Thuoc_TheKho_Multi_Mau2] ('" + idkho + "', '" + StaticData.CheckDate(tungay) + "', '" + StaticData.CheckDate(denngay) + " 23:59:59', '" + idthuoc + "') order by tenkho, tenthuoc, ngaychungtu";

        DataTable dtthekho = DataAcess.Connect.GetTable(sqlthekho);
        if (dtthekho != null && dtthekho.Rows.Count > 0)
        {
            #region so luong ton
            int slton = 0;
            // if (dtthekho.Columns.IndexOf("SLDK") == -1)
            // dtthekho.Columns.Add("SLDK", slton.GetType());
            //  dtthekho.Rows[0]["SLDK"] = slton;
            DataTable dtTemp = dtthekho.DefaultView.ToTable(true, "IDKHO", "IDTHUOC");
            foreach (DataRow r in dtTemp.Rows)
            {
                DataRow[] rows = dtthekho.Select(string.Format("IDKHO={0} and IDTHUOC={1}", r["IDKHO"], r["IDTHUOC"]), "NGAYCHUNGTU ASC");
                for (int i = 0; i < rows.Length; i++)
                {
                    if (i == 0)
                    {
                        rows[i]["soluongton"] = StaticData.ParseFloat(rows[i]["SLDK"]) + StaticData.ParseFloat(rows[i]["soluongnhap"]) - StaticData.ParseFloat(rows[i]["soluongxuat"]);
                    }
                    else
                    {
                        rows[i]["soluongton"] = StaticData.ParseFloat(rows[i - 1]["soluongton"]) + StaticData.ParseFloat(rows[i]["soluongnhap"]) - StaticData.ParseFloat(rows[i]["soluongxuat"]);
                        slton = StaticData.ParseInt(dtthekho.Rows[i]["soluongton"]);
                    }
                }
            }
            #endregion
            R = new ReportDocument();
            string TenReport = "";

            if (LoaiBieuMauThe == "2")
                TenReport = "CrptDesign/crpt_TheKho_Multi_Mau2.rpt";
            else
                TenReport = "CrptDesign/crpt_TheKho_Multi_Mau1.rpt";

            R.Load(Server.MapPath(TenReport));
            R.SetDataSource(dtthekho);
            string DonViTinh = "";
            string HoatChat = "";
            #region Report tiêu đề
            DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
            string tieude = dtTieuDeCty.Rows[0]["Ten_Cty"].ToString();
            string[] slp = tieude.Split('-');
            string til = slp[0];
            string subtil = (slp.Length >= 2 ? slp[1] : "");
            if (LoaiBieuMauThe == "2")
            {
                if (dtTieuDeCty != null)
                    R.OpenSubreport("crpt_thongtindonvi1.rpt").SetDataSource(dtTieuDeCty);
                ((TextObject)R.OpenSubreport("crpt_thongtindonvi1.rpt").ReportDefinition.ReportObjects["txtTitle"]).Text = til + subtil;
            }
            else if (LoaiBieuMauThe == "1")
            {
                if (dtTieuDeCty != null)
                    R.OpenSubreport("crpt_ThongTinDonVi2.rpt").SetDataSource(dtTieuDeCty);
                ((TextObject)R.OpenSubreport("crpt_ThongTinDonVi2.rpt").ReportDefinition.ReportObjects["txtSubtitle"]).Text = subtil;
                ((TextObject)R.OpenSubreport("crpt_ThongTinDonVi2.rpt").ReportDefinition.ReportObjects["txtTitle"]).Text = til;
            }
            R.SetParameterValue("slton", slton);
            string TimeDescription = StaticData.TimeDescription(StaticData.CheckDate(tungay), StaticData.CheckDate(denngay));
            R.SetParameterValue("TimeDescription", TimeDescription);
            R.SetParameterValue("makho", idkho);
            R.SetParameterValue("tenkho", (gettenkho(idkho) == null ? "" : gettenkho(idkho)));
            R.SetParameterValue("tenthuoc", this.txtTenThuoc.Text);
            R.SetParameterValue("sodudauky", 0);
            if (LoaiBieuMauThe == "2")
            {
                R.SetParameterValue("DonViTinh", DonViTinh);
                R.SetParameterValue("HoatChat", HoatChat);
            }

            #endregion
            CrystalReportViewer1.ReportSource = R;
            CrystalReportViewer1.DataBind();
        }
    }

    #region get so du dau ky
    private string getsodudauky(string idkho, string tungay, string idthuoc, string iddvt)
    {
        string sql = "select dbo.thuoc_sodudauky (" + idkho + ", '" + tungay + "', '" + idthuoc + "', '" + iddvt + "') as sodudauky";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            return dt.Rows[0][0].ToString();
        }
        else
        {
            return null;
        }
    }
    #endregion
    protected void btnTim_Click(object sender, EventArgs e)
    {
        loaddanhsach(ddlkho.SelectedValue, txtTuNgay.Text, txtDenNgay.Text, this.txtTenThuoc.Text);
    }
    protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
    {
        if (R != null)
        {
            R.Clone();
            R.Dispose();
            CrystalReportViewer1.Dispose();
            GC.Collect();
        }
    }

    protected void form_unload(object sender, EventArgs e)
    {
        if (R != null)
        {
            R.Clone();
            R.Dispose();
            R = null;
            CrystalReportViewer1.Dispose();
            CrystalReportViewer1 = null;
            GC.Collect();
        }
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
