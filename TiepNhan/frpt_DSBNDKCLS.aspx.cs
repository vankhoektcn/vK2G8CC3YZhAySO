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
public partial class frpt_DSBNDKCLS : MKVPage
{
    
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
        this.dkmenu = Request.QueryString["dkMenu"];
        PlaceHolder1.Controls.Add(LoadControl("~/" + dkmenu + "/uscmenu.ascx"));
         
       

    }
    private void LoadData()
    {
        DateTime sysdate = DataAcess.Connect.d_SystemDate();
        this.txtTuNgay.Text = sysdate.ToString("dd/MM/yyyy");
        this.txtDenNgay.Text = sysdate.ToString("dd/MM/yyyy");
        DataTable dt2 = DataAcess.Connect.GetTable("SELECT * FROM KB_LOAIBN");
       
    }
    private void loadTTHCBN(int idbn)
    {
        string sql = "select * from benhnhan where idbenhnhan="+idbn+"";
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
        if (this.txtDenNgay.Text.Trim() != "") DenNgay = StaticData.CheckDate(this.txtDenNgay.Text) +" 23:59:59";

        string strSQL = @"SELECT ROW_NUMBER() OVER (ORDER BY TENBENHNHAN ) AS STT,TB.* FROM 
                                (
                                   select DISTINCT 
		                                tendichvu=( Case when ISNULL(A.IDKhamBenh,0)=0 THEN  N'Tự đăng ký CLS' ELSE G.TENBACSI END)
		                                ,A.idbenhnhan
		                                ,c.mabenhnhan
		                                ,c.tenbenhnhan
		                                ,c.diachi
		                                ,GioiTinh=dbo.getgioitinh(c.gioitinh)
		                                ,c.dienthoai
		                                ,namsinh=C.NGAYSINH
		                                ,ngaytiepnhan=LEFT( CONVERT(NVARCHAR,NGAYTHU,120),LEN(CONVERT(NVARCHAR,NGAYTHU,120))-3)
		                                ,LoaiBN=E.MaLoaiBN
		                                ,c.loai
		                                ,C.SOBHYT
                                        ,XTYPE=2
                                        ,A.MaPhieuCLS
                                        ,DaThuView=(CASE WHEN A.DATHU=1 THEN N'Đã thu' else N'Chưa thu' end ),
                                        A.IDDANGKYCLS
		                                FROM KHAMBENHCANLAMSAN A
			                                LEFT JOIN BENHNHAN C ON A.IDBENHNHAN=C.IDBENHNHAN
			                                LEFT JOIN KB_LOAIBN E ON C.LOAI=E.ID 
                                            LEFT JOIN KHAMBENH F ON A.IDKHAMBENH=F.IDKHAMBENH 
                                            LEFT JOIN BACSI G ON F.IDBACSI=G.IDBACSI
		                                 WHERE ISNULL(A.DAHUY,0)=0" + "\r\n"
                                       + (TuNgay != "" ? "  AND A.NGAYTHU>='" + TuNgay + "'\r\n" : "")
                                       + (DenNgay != "" ? "  AND A.NGAYTHU<='" + DenNgay + "'\r\n" : "")
                                       + (this.txtSoBHT.Text.Trim() != "" ? "  AND C.SOBHYT LIKE N'%" + this.txtSoBHT.Text.Trim() + "%'\r\n" : "")
                                       + (this.txtTenBenhNhan.Text.Trim() != "" ? "  AND C.TENBENHNHAN  LIKE N'%" + this.txtTenBenhNhan.Text.Trim() + "%'\r\n" : "")
                                       + (this.txtMaBenhNhan.Text.Trim() != "" ? "  AND C.MABENHNHAN LIKE N'%" + this.txtMaBenhNhan.Text.Trim() + "%\r\n'" : "")
                                       + (this.txtDiaChi.Text.Trim() != "" ? "  AND C.DIACHI LIKE N'%" + this.txtDiaChi.Text.Trim() + "%'\r\n" : "")
                                       + (this.txtDienThoai.Text.Trim() != "" ? "  AND C.DIENTHOAI LIKE N'%" + this.txtDienThoai.Text.Trim() + "%'\r\n" : "")
		                               +( this.chbIsTuDen.Checked==true?  @"         AND ISNULL(A.IDKHAMBENH,0)=0" :"")
                                       +( this.chbIsCD.Checked==true?  @"         AND ISNULL(A.IDKHAMBENH,0)<>0" :"")
                                       + (this.chbIsTuDen_KK.Checked == true ? @" AND  ISNULL(a.IsDaDKK,0)=0" : "")
                                       +" AND ( A.IDKHOADANGKY=1  OR F.IDPHONGKHAMBENH=1 )"
                                        +" ) AS TB";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        return dtCTPhieu;
    }
    private void BindListBenhNhan()
    {
        DataTable dtCTPhieu = this.dtGetList();
       
        

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
        if (e.CommandName.ToString() == "Detail")
        {
            
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "window.open('hs_DangKyCLS3.aspx?idkhoachinh=" + e.CommandArgument.ToString() + "');", true);
        }
    }
    protected void btnGetList_Click(object sender, EventArgs e)
    {
            dgr.Visible = true;
            dsbntn.Visible = false;
            BindListBenhNhan();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        SetValueEmpty();
        StaticData.SetFocus(this, "txtMaBenhNhan");
    }
    protected void btnxuatexcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtCTPhieu = this.dtGetList();
           if (dtCTPhieu != null && dtCTPhieu.Rows.Count > 0)
            {
                dtCTPhieu.Columns.Remove("XTYPE");
                dtCTPhieu.Columns.Remove("LOAI");
                dtCTPhieu.Columns.Remove("IDBENHNHAN");

                dtCTPhieu.Columns["TENDICHVU"].ColumnName = "Phòng KCB";
                dtCTPhieu.Columns["MABENHNHAN"].ColumnName = "Mã BN";
                dtCTPhieu.Columns["TENBENHNHAN"].ColumnName = "Tên bệnh nhân";
                dtCTPhieu.Columns["gioitinh"].ColumnName = "Giới tính";
                dtCTPhieu.Columns["ngaytiepnhan"].ColumnName = "Ngày KCB";
                dtCTPhieu.Columns["isbnmoi"].ColumnName = "Loại BN";

                dtCTPhieu.Columns["diachi"].ColumnName = "Địa chỉ";
                dtCTPhieu.Columns["dienthoai"].ColumnName = "Điện thoại";
                dtCTPhieu.Columns["namsinh"].ColumnName = "Ngày sinh";
                dtCTPhieu.Columns["loaibn"].ColumnName = "Loại khám";
                dtCTPhieu.Columns["sobhyt"].ColumnName = "Số BHYT";


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
            "attachment;filename=DataTable.xls");
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
        catch
        {
        }

    }
}

