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
using System.IO;
public partial class frpt_DSBNDKham : MKVPage
{
    string strSearch;
    int idbnView = 0;
    string dkmenu = "tiepnhan";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SetValueEmpty();
            this.LoadData();
            StaticData.SetFocus(this, "txtMaBenhNhan");
            pnlDV.Visible = false;
            pnlKB.Visible = false;
            pnlCLS.Visible = false;
            if (Request.QueryString["idbn"] != null)
            {
                idbnView = int.Parse(Request.QueryString["idbn"]);
                BindListBenhNhan();
            }
        }
       
        dkmenu = Request.QueryString["dkMenu"];
        if (dkmenu == "KhamBenh_TH")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/KhamBenh_TH/uscmenu.ascx"));
        }

    }
    private void LoadData()
    {
        string idkhoa = Request.QueryString["idkhoa"];
        if (idkhoa == null || idkhoa == "")
            idkhoa = "1";
        DateTime sysdate = DataAcess.Connect.d_SystemDate();
        this.txtTuNgay.Text = sysdate.ToString("dd/MM/yyyy");
        this.txtDenNgay.Text = sysdate.ToString("dd/MM/yyyy");
        DataTable dt2 = DataAcess.Connect.GetTable("SELECT * FROM KB_LOAIBN");
        StaticData.FillCombo(this.cbLoaiBN, dt2, "Id", "TenLoai", "Loại BN");
        cbLoaiBN.SelectedIndex = 0;
        string sql1 = "select idbacsi,tenbacsi from bacsi";
        DataTable tb1 = DataAcess.Connect.GetTable(sql1);
        StaticData.FillCombo(ddlBS, tb1, "idbacsi", "tenbacsi", "-------Chọn Bác sĩ-------");
        DataTable tb2 = StaticData.dtPhong_ByKhoa(idkhoa);
        StaticData.FillCombo(ddPhongSo, tb2, "id", "tenphongfull", "-------Phòng------");
    }

    private void loadTTHCBN(int idbn)
    {
        string sql = "select * from benhnhan where idbenhnhan=" + idbn + "";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null && dt.Rows.Count != 0)
        {
            txtMaBenhNhan.Text = dt.Rows[0]["mabenhnhan"].ToString();
            txtDiaChi.Text = dt.Rows[0]["diachi"].ToString();
            txtDienThoai.Text = dt.Rows[0]["dienthoai"].ToString();
            txtTenBenhNhan.Text = dt.Rows[0]["tenbenhnhan"].ToString();
        }
    }

    #region "U Function"
    private DataTable dtGetList()
    {
        string TuNgay = "";
        if (this.txtTuNgay.Text != "") TuNgay = StaticData.CheckDate(this.txtTuNgay.Text);
        string DenNgay = "";
        if (this.txtDenNgay.Text.Trim() != "") DenNgay = StaticData.CheckDate(this.txtDenNgay.Text) + " 23:59:59";

        string strSQL = @" 
                                select ROW_NUMBER() OVER (ORDER BY TENBENHNHAN ) AS STT
                                ,TenPhong=dbo.hs_tenphong(f.phongid)
                                ,F.idkhambenh
                                ,c.mabenhnhan
                                ,c.tenbenhnhan
                                ,c.diachi
                                ,GioiTinh=dbo.getgioitinh(c.gioitinh)
                                ,c.dienthoai
                                ,namsinh=C.NGAYSINH
                                ,NgayKham
                                ,loai
                                ,LoaiBN=E.MALOAIBN
								,IsBNMoi= (CASE WHEN ISNULL(F.ISTAIKHAM,0)=0 THEN N'BN mới' else N'Tái khám' end )
                                ,HuongDieuTri=(case when f.idkhoachuyen=15 then N'Chuyển cấp cứu' else  TenHuongDieuTri end)
                                ,TenBacSi=I.TENBACSI
                                ,ChanDoan=H.MoTa
                                FROM KHAMBENH F
                                    LEFT JOIN  CHITIETDANGKYKHAM A ON A.IDCHITIETDANGKYKHAM=F.IDCHITIETDANGKYKHAM
	                                LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
	                                LEFT JOIN BENHNHAN C ON B.IDBENHNHAN=C.IDBENHNHAN
	                                LEFT JOIN BANGGIADICHVU D ON A.IDBANGGIADICHVU=D.IDBANGGIADICHVU
	                                LEFT JOIN KB_LOAIBN E ON C.LOAI=E.ID 
                                    LEFT JOIN KB_HUONGDIEUTRI G ON F.HUONGDIEUTRI=G.HuongDieuTriId
                                    LEFT JOIN CHANDOANICD H ON F.ketluan=H.IDICD
                                    LEFT JOIN BACSI I ON (CASE WHEN ISNULL(F.IDBACSI2,0)<>0 THEN F.IDBACSI2 ELSE F.IDBACSI END )=I.IDBACSI
                                WHERE 1=1" + "\r\n"
                               + (TuNgay != "" ? "  AND F.NGAYKHAM>='" + TuNgay + "'\r\n" : "")
                               + (DenNgay != "" ? "  AND F.NGAYKHAM<='" + DenNgay + "'\r\n" : "")
                               + (this.txtSoBHT.Text.Trim() != "" ? "           AND C.SOBHYT LIKE N'%" + this.txtSoBHT.Text.Trim() + "%'\r\n" : "")
                               + (this.txtTenBenhNhan.Text.Trim() != "" ? "           AND C.TENBENHNHAN  LIKE N'%" + this.txtTenBenhNhan.Text.Trim() + "%'\r\n" : "")
                               + (this.txtMaBenhNhan.Text.Trim() != "" ? "            AND C.MABENHNHAN LIKE N'%" + this.txtMaBenhNhan.Text.Trim() + "%'\r\n" : "")
                               + (this.txtDiaChi.Text.Trim() != "" ? "       AND C.DIACHI LIKE N'%" + this.txtDiaChi.Text.Trim() + "%'\r\n" : "")
                               + (this.txtDienThoai.Text.Trim() != "" ? "      AND C.DIENTHOAI LIKE N'%" + this.txtDienThoai.Text.Trim() + "%'\r\n" : "")
                               + (this.ddPhongSo.SelectedValue != "" && this.ddPhongSo.SelectedValue != "-1" && this.ddPhongSo.SelectedValue != "0" ? "  AND ISNULL(A.PHONGID,0) = '" + this.ddPhongSo.SelectedValue + "'\r\n" : "")
                               + (this.ddlBS.SelectedValue != "" && this.ddlBS.SelectedValue != "-1" && this.ddlBS.SelectedValue != "0" ? "  AND ( CASE WHEN ISNULL(F.IDBACSI2,0)<>0 THEN F.IDBACSI2 ELSE  ISNULL(F.IDBACSI,0) END) = '" + this.ddlBS.SelectedValue + "'\r\n" : "")
                               + (this.cbLoaiBN.SelectedValue != "" && this.cbLoaiBN.SelectedValue != "-1" && this.cbLoaiBN.SelectedValue != "0" ? "  AND ISNULL(C.LOAI,0) = '" + this.cbLoaiBN.SelectedValue + "'\r\n" : "")
                               + @"   AND ISNULL(A.DAHUY,0)=0
                                ";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        return dtCTPhieu;
    }
    private void BindListBenhNhan()
    {
        DataTable dtCTPhieu = this.dtGetList();
        DataView dvtemp = new DataView(dtCTPhieu.Copy());
        this.txtSLCLS.Text = dvtemp.Count.ToString();
        this.txtSLDKK.Text = (dtCTPhieu.Rows.Count - dvtemp.Count).ToString();
        dvtemp.RowFilter = "LOAI = '1'";
        this.txtSLKBH.Text = dvtemp.Count.ToString();
        dvtemp.RowFilter = "LOAI = '3'";
        this.txtSLKT.Text = dvtemp.Count.ToString();

        dvtemp.RowFilter = "LOAI = '2'";
        this.txtSLKDV.Text = dvtemp.Count.ToString();

        this.txtSLBN.Text = dtCTPhieu.Rows.Count.ToString();

        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();

    }

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtDienThoai.Text = "";
        txtDiaChi.Text = "";
        this.txtTuNgay.Text = "";
        this.txtDenNgay.Text = "";
        this.txtSoBHT.Text = "";
        this.cbLoaiBN.SelectedValue = "0";
    }

    private void BindCTPhieu(DataTable dtSRC)
    {
        if (dtSRC == null) return;
        dgr.DataSource = dtSRC;
        dgr.DataBind();
    }
    #endregion
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        
        if (e.CommandName == "ViewTTBN")
        {
            int idkhambenh = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.location=\"../KhamBenh_TH/KhamBenh.aspx?dkMenu=KhamBenh_TH&#idkhoachinh=" + idkhambenh + "\";", true);

        }


    }
    protected void btnGetList_Click(object sender, EventArgs e)
    {
        BindListBenhNhan();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        StaticData.SetFocus(this, "txtMaBenhNhan");
    }
    protected void btnxuatexcel_Click(object sender, EventArgs e)
    {
        try
        {
            string TuNgay = "";
            if (this.txtTuNgay.Text != "") TuNgay = StaticData.CheckDate(this.txtTuNgay.Text);
            string DenNgay = "";
            if (this.txtDenNgay.Text.Trim() != "") DenNgay = StaticData.CheckDate(this.txtDenNgay.Text) + " 23:59:59";

            string strSQL = @"SELECT ROW_NUMBER() OVER (ORDER BY TENBENHNHAN)   as STT,
                        convert(varchar(10),F.ngaykham,103) as [Ngày khám],
                        C.tenbenhnhan as [Tên bệnh nhân],
                        DBO.GetNamSinh(C.ngaysinh) as [Năm sinh],
                        C.diachi as [Địa chỉ],
                        CD.MoTa  as [Chẩn đoán],
                        [Hướng điều trị]=(case when f.idkhoachuyen=15 then N'Chuyển cấp cứu' else  TenHuongDieuTri end)
                        ,'' as [Ghi chú]
                         FROM KHAMBENH F
                                    LEFT JOIN  CHITIETDANGKYKHAM A ON A.IDCHITIETDANGKYKHAM=F.IDCHITIETDANGKYKHAM
	                                LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
	                                LEFT JOIN BENHNHAN C ON B.IDBENHNHAN=C.IDBENHNHAN
	                                LEFT JOIN BANGGIADICHVU D ON A.IDBANGGIADICHVU=D.IDBANGGIADICHVU
	                                LEFT JOIN KB_LOAIBN E ON C.LOAI=E.ID 
                                    LEFT JOIN KB_HuongDieuTri hdt ON hdt.huongdieutriid=F.huongdieutri
                                    LEFT JOIN CHANDOANICD CD ON F.KETLUAN=CD.IDICD
                         WHERE 1=1" + "\r\n"
                               + (TuNgay != "" ? "  AND B.NGAYDANGKY>='" + TuNgay + "'\r\n" : "")
                               + (DenNgay != "" ? "  AND B.NGAYDANGKY<='" + DenNgay + "'\r\n" : "")
                               + (this.txtSoBHT.Text.Trim() != "" ? "           AND C.SOBHYT LIKE N'%" + this.txtSoBHT.Text.Trim() + "%'\r\n" : "")
                               + (this.txtTenBenhNhan.Text.Trim() != "" ? "           AND C.TENBENHNHAN  LIKE N'%" + this.txtTenBenhNhan.Text.Trim() + "%'\r\n" : "")
                               + (this.txtMaBenhNhan.Text.Trim() != "" ? "            AND C.MABENHNHAN LIKE N'%" + this.txtMaBenhNhan.Text.Trim() + "%'\r\n" : "")
                               + (this.txtDiaChi.Text.Trim() != "" ? "       AND C.DIACHI LIKE N'%" + this.txtDiaChi.Text.Trim() + "%'\r\n" : "")
                               + (this.txtDienThoai.Text.Trim() != "" ? "      AND C.DIENTHOAI LIKE N'%" + this.txtDienThoai.Text.Trim() + "%'\r\n" : "")
                               + (this.ddPhongSo.SelectedValue != "" && this.ddPhongSo.SelectedValue != "-1" && this.ddPhongSo.SelectedValue != "0" ? "  AND ISNULL(A.PHONGID,0) = '" + this.ddPhongSo.SelectedValue + "'\r\n" : "")
                               + (this.ddlBS.SelectedValue != "" && this.ddlBS.SelectedValue != "-1" && this.ddlBS.SelectedValue != "0" ? "  AND ( CASE WHEN ISNULL(F.IDBACSI2,0)<>0 THEN F.IDBACSI2 ELSE  ISNULL(F.IDBACSI,0) END) = '" + this.ddlBS.SelectedValue + "'\r\n" : "")
                               + (this.cbLoaiBN.SelectedValue != "" && this.cbLoaiBN.SelectedValue != "-1" && this.cbLoaiBN.SelectedValue != "0" ? "  AND ISNULL(C.LOAI,0) = '" + this.cbLoaiBN.SelectedValue + "'\r\n" : "")
                                ;

            DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

            if (dtCTPhieu != null && dtCTPhieu.Rows.Count > 0)
            {

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                "attachment;filename=dsbnkhamtrongngay.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                GridView GV = new GridView();
                GV.ShowFooter = false;
                GV.AllowPaging = false;
                GV.DataSource = dtCTPhieu;
                GV.DataBind();

                GV.RowStyle.HorizontalAlign = HorizontalAlign.Left;
                GV.HeaderStyle.BackColor = System.Drawing.Color.FromName("#DADADA");
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GV.RenderControl(hw);
                Response.Output.Write("<div style=\"font-weight:bold; font-size:13px;\" align=left>Sở Y Tế TP. Bến Tre</div>");
                Response.Output.Write("<div style=\"font-weight:bold; font-size:13px;\" align=left>Bệnh Viện Đa Khoa Minh Đức</div>");

                Response.Output.Write("<div style=\"font-weight:bold; font-size:17px;\" align=center>DANH SÁCH BỆNH NHÂN KHÁM</div>");
                string ngay = "Từ ngày " + txtTuNgay.Text + " đến ngày " + txtDenNgay.Text;
                if (Convert.ToString(txtDenNgay.Text) == Convert.ToString(txtTuNgay.Text))
                {
                    ngay = "Ngày " + txtTuNgay.Text;
                }
                Response.Output.Write("<div style=\"font-weight:bold; font-size:15px;\" align=center>" + ngay + "</div>");

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch//(Exception ex)
        {
            //  Response.Write("<br><br><br>"+ex.Message);
        }


    }
}

