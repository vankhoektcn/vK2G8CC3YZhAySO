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

public partial class DanhSachBNDaKham : System.Web.UI.Page
{
    string LoaiBenhNhan;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "QLBV-  Khám Bệnh";
        string dkMenu = Request.QueryString["dkMenu"];
        if (dkMenu != null && dkMenu != "")
        {
            if (dkMenu != "uscmenu_NgoaiSan")
                PlaceHolder1.Controls.Add(LoadControl("~/" + dkMenu + "/uscmenu.ascx"));
            else
                PlaceHolder1.Controls.Add(LoadControl("~/" + "KhoaSan" + "/uscmenu_NgoaiSan.ascx"));
        }
        if (Request.QueryString["LoaiBN"] != null)
        {
            LoaiBenhNhan = Request.QueryString["LoaiBN"];
        }
        else LoaiBenhNhan = "DV";
        if (IsPostBack) return;

        Tungay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        Denngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        this.DichvuKCB.Visible = StaticData.EnableChuyenKhoa;
        this.lbChuyenKhoa.Visible = this.DichvuKCB.Visible;
        loadKhoa();
        getTableDS();


    }
    public void getTableDS()
    {
        string sqldk = "";
        if (Tungay.Text == "")
        {
            StaticData.MsgBox(this, "Từ ngày không được trống");
            return;
        }
        else if (Denngay.Text == "")
        {
            StaticData.MsgBox(this, "Đến ngày không được trống");
            return;
        }
        string swhere = "";
        if (txtMaBN.Text != null && txtMaBN.Text != "")
        {
            swhere += " and c.mabenhnhan='" + txtMaBN.Text.Trim() + "'";
        }
        if (txtTenBN.Text != null && txtTenBN.Text != "")
        {
            swhere += " and (dbo.untiengviet(c.tenbenhnhan) like N'%" + txtTenBN.Text.Trim() + "%' or c.tenbenhnhan like N'%" + txtTenBN.Text.Trim() + "%')";
        }

        string sql = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY IDKHAMBENH),
          A.IDCHITIETDANGKYKHAM,
	      A.IDDANGKYKHAM,
	      B.NGAYDANGKY,
	      C.MABENHNHAN,
	      C.TENBENHNHAN,
	        C.NGAYSINH,
	      GIOITINH=DBO.GetGioiTinh( C.GIOITINH),
	      B.IDBENHNHAN	,
          D.IDKHAMBENH,
          E.TENBACSI,
          D.NGAYKHAM,
          TenHuongDieuTri=( CASE WHEN D.IDKHOACHUYEN=15 THEN N'Chuyển cấp cứu' else (CASE WHEN D.IDKHOACHUYEN=25 THEN N'Chuyển tán sỏi'  ELSE  (CASE WHEN D.IDKHOACHUYEN=46 THEN N'Chuyển hóa trị' else F.TenHuongDieuTri end) END) end ),
          HaveCLS=isnull((select top 1 N'In phiếu CĐCLS' from khambenhcanlamsan where idkhambenh=d.idkhambenh),''),
          HaveThuoc=isnull((select top 1 N'In toa thuốc' from chitietbenhnhantoathuoc where idkhambenh=d.idkhambenh),'')
          ,CreateUser=(SELECT TENNGUOIDUNG FROM NGUOIDUNG WHERE IDNGUOIDUNG=D.IDDIEUDUONG)
          ,EditUser=(SELECT TENNGUOIDUNG FROM NGUOIDUNG WHERE IDNGUOIDUNG=D.IDDIEUDUONG2)
          ,LoaiDK=(CASE WHEN B.LOAIKHAMID=1 THEN N'BH' ELSE 'DV' END)
	    FROM KHAMBENH D
        LEFT JOIN CHITIETDANGKYKHAM A ON A.IDCHITIETDANGKYKHAM=D.IDCHITIETDANGKYKHAM
		LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
		LEFT JOIN BENHNHAN C ON C.IDBENHNHAN=B.IDBENHNHAN
        LEFT JOIN BACSI E ON ( CASE WHEN ISNULL(D.IDBACSI2,0)<>0 THEN D.IDBACSI2 ELSE  D.IDBACSI END )=E.IDBACSI
        LEFT JOIN KB_HUONGDIEUTRI F ON D.HUONGDIEUTRI=F.HUONGDIEUTRIID
        WHERE NGAYKHAM>='" + DataProcess.sGetSaveValue(Tungay.Text, "date").Replace("'", "") + @"'
	    AND NGAYKHAM<='" + DataProcess.sGetSaveValue(Denngay.Text, "date").Replace("'", "") + @" 23:59:59'
		AND D.PHONGID='" + Phong.SelectedValue + @"' -- PHONGID = PHÒNG XÁC ĐỊNH TRÊN GIAO DIỆN 
		"+ swhere;

        DataTable table = DataAcess.Connect.GetTable(sql);
        GridView1.DataSource = table;
        GridView1.DataBind();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int row = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Kham")
        {
            string IDKHAMBENH = GridView1.DataKeys[row].Value.ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "#idkhoachinh=" + IDKHAMBENH + "','_blank','location=0;status=0,menubar=0,scrollbars=1;');", true);
        }
    }
    public void loadKhoa()
    {
        string IdKhoa_default = Request.QueryString["IdKhoa"];
        if (IdKhoa_default == null || IdKhoa_default == "") IdKhoa_default = "1";
        if (IdKhoa_default != "1")
            this.Khoa.Enabled = false;
        StaticData.FillCombo(Khoa, DataAcess.Connect.GetTable("select * from phongkhambenh"), "idphongkhambenh", "tenphongkhambenh");
        Khoa.SelectedValue = IdKhoa_default;
        StaticData.FillCombo(DichvuKCB, DataAcess.Connect.GetTable("select * from banggiadichvu where idphongkhambenh='" + Khoa.SelectedValue + "'"), "idbanggiadichvu", "tendichvu");
        StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByKhoa(IdKhoa_default), "id", "TenPhongFull");
        DichvuKCB_SelectedIndexChanged(null, null);
    }

    protected void Khoa_SelectedIndexChanged(object sender, EventArgs e)
    {

        StaticData.FillCombo(DichvuKCB, DataAcess.Connect.GetTable("select * from banggiadichvu where idphongkhambenh='" + Khoa.SelectedValue + "'"), "idbanggiadichvu", "tendichvu");
        if (this.DichvuKCB.Visible)
            StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByChuyenKhoa(this.DichvuKCB.SelectedValue, this.LoaiBenhNhan), "id", "TenPhongFull");
        else
            StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByKhoa(this.Khoa.SelectedValue), "id", "TenPhongFull");

        
    }
    protected void DichvuKCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DichvuKCB.Visible == false) return;
        StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByChuyenKhoa(this.DichvuKCB.SelectedValue, this.LoaiBenhNhan), "id", "TenPhongFull");
        Session["dichvu"] = DichvuKCB.SelectedValue;
    }
    protected void TimKiem_Click(object sender, EventArgs e)
    {
        getTableDS();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        getTableDS();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Row.RowState != DataControlRowState.Alternate)
            {
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }
        }
    }

}
