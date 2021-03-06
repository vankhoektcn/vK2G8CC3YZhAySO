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

public partial class DanhSachBNChuyenKhoa : System.Web.UI.Page
{
    string LoaiBenhNhan;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Page.Title = "QLBV-  Khám Bệnh";
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
        LoadMenu();
    }
    private void LoadMenu()
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"].ToString();
            PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
        }
        catch (Exception ex)
        {
        }
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
        string sql = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY G.SOTT,D.IDKHAMBENH),
          IDCHITIETDANGKYKHAM=ISNULL(G.IDCHITIETDANGKYKHAM,A.IDCHITIETDANGKYKHAM),
	      IDDANGKYKHAM=ISNULL(F.IDDANGKYKHAM, A.IDDANGKYKHAM),
	      d.TGXuatVien,
	      C.MABENHNHAN,    
	          C.NGAYSINH,
        	--TUOI=DBO.kb_GetTuoi(C.NGAYSINH),
            C.TENBENHNHAN,
	      GIOITINH=DBO.GetGioiTinh( C.GIOITINH),
	      B.IDBENHNHAN	,
          D.IDKHAMBENH,
          TENKHOA=K2.TENPHONGKHAMBENH,
          TENPHONG=DBO.HS_TENPHONG(D.PHONGID),
          E.TENBACSI
	    FROM KHAMBENH D
        LEFT JOIN CHITIETDANGKYKHAM A ON A.IDCHITIETDANGKYKHAM=D.IDCHITIETDANGKYKHAM
		LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
		LEFT JOIN BENHNHAN C ON C.IDBENHNHAN=B.IDBENHNHAN
        LEFT JOIN PHONGKHAMBENH K2 ON D.IDKHOA=K2.IDPHONGKHAMBENH
        LEFT JOIN BACSI E ON D.IDBACSI=E.IDBACSI
        LEFT JOIN DANGKYKHAM F ON D.IDKHAMBENH=F.IDKHAMBENH_CHUYEN
        LEFT JOIN CHITIETDANGKYKHAM G ON F.IDDANGKYKHAM=G.IDDANGKYKHAM
        WHERE D.TGXuatVien>='" + DataProcess.sGetSaveValue(Tungay.Text, "date").Replace("'", "") + @"'
	    AND D.TGXuatVien<='" + DataProcess.sGetSaveValue(Denngay.Text, "date").Replace("'", "") + @" 23:59:59'
        AND D.IdkhoaChuyen=" + this.Khoa.SelectedValue + "" + "\r\n"
        + (this.Phong.SelectedValue != null && this.Phong.SelectedValue != "" ? " AND D.IdChuyenPK='" + Phong.SelectedValue + @"'" : "")
        + " AND  ISNULL( B.DAHUY,0)=0" + "\r\n"
        + " AND (ISNULL(IsChuyenPhongCoPhi,0)=0   OR  G.IsDathu=1 )" + "\r\n"
        + " AND  ISNULL(D.idkhambenhchuyenphong,0)=0   ";

        DataTable table = DataAcess.Connect.GetTable(sql);
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
    

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         
        int row = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Kham")
        {
            string idPTTCu = GridView1.DataKeys[row].Value.ToString();
            string idbenhnhan = ((Label)GridView1.Rows[row].Cells[1].FindControl("IDBENHNHAN")).Text;
            //StaticData.OpenLink(this, "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "&LoaiBN=" + Request.QueryString["LoaiBN"] + "#idkhambenhchuyenphong=" + idPTTCu);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "window.open('" + "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "&LoaiBN=" + Request.QueryString["LoaiBN"] + "#idkhambenhchuyenphong=" + idPTTCu + "');", true);
            
            this.GridView1.Rows[row].Visible = false;  
        }
    }
    public void loadKhoa()
    {
        
        StaticData.FillCombo(Khoa, DataAcess.Connect.GetTable("select * from phongkhambenh"), "idphongkhambenh", "tenphongkhambenh");
        if (Session["khoa"] != null)
            Khoa.SelectedValue = Session["khoa"].ToString();
        StaticData.FillCombo(DichvuKCB, DataAcess.Connect.GetTable("select * from banggiadichvu where idphongkhambenh='" + Khoa.SelectedValue + "'"), "idbanggiadichvu", "tendichvu");
        if (Session["dichvu"] != null)
            DichvuKCB.SelectedValue = Session["dichvu"].ToString();
        StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru(), "id", "TenPhongFull");
        DichvuKCB_SelectedIndexChanged(null, null);
    }

    protected void Khoa_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        StaticData.FillCombo(DichvuKCB, DataAcess.Connect.GetTable("select * from banggiadichvu where idphongkhambenh='"+Khoa.SelectedValue+"'"), "idbanggiadichvu", "tendichvu");
        if(this.DichvuKCB.Visible)
            StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByChuyenKhoa(this.DichvuKCB.SelectedValue, this.LoaiBenhNhan), "id", "TenPhongFull");
        else
            StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByKhoa(this.Khoa.SelectedValue), "id", "TenPhongFull");

        Session["khoa"] = Khoa.SelectedValue;
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
        LinkButton btn;
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
