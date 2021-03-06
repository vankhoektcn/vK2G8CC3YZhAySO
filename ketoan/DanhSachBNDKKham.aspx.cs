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

public partial class DanhSachBNDKKham : System.Web.UI.Page
{
    string LoaiBenhNhan;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "QLBV-  KHOA PHẪU THUẬT";
        string dkMenu = Request.QueryString["dkMenu"];
        if (dkMenu != null && dkMenu != "")
        {
            try
            {
                if (dkMenu != "uscmenu_NgoaiSan")
                    PlaceHolder1.Controls.Add(LoadControl("~/" + dkMenu + "/uscmenu.ascx"));
                else
                    PlaceHolder1.Controls.Add(LoadControl("~/" + "KhoaSan" + "/uscmenu_NgoaiSan.ascx"));
            }
            catch
            {

            }
        }
        if (Request.QueryString["LoaiBN"] != null)
        {
            LoaiBenhNhan = Request.QueryString["LoaiBN"];
        }
        else LoaiBenhNhan = "DV";
        if (IsPostBack) return;
        Tungay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        Denngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        loadKhoa();
        getTableDS();


    }
    public void getTableDS()
    {
        string IdKhoa_default = Request.QueryString["IdKhoa"];
        if (IdKhoa_default == null || IdKhoa_default == "") IdKhoa_default = "22";

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
        string sql = @" SELECT  
                              IDCHITIETDANGKYKHAM=ISNULL(G.IDCHITIETDANGKYKHAM,A.IDCHITIETDANGKYKHAM),
                              IDDANGKYKHAM=ISNULL(F.IDDANGKYKHAM, A.IDDANGKYKHAM),
							  SoTT=G.SoTT,
                              NGAYDANGKY=ISNULL(d.TGXuatVien,D.NGAYKHAM),
                              C.MABENHNHAN,    
                              C.TENBENHNHAN,
							  C.NGAYSINH,
                              GIOITINH=DBO.GetGioiTinh( C.GIOITINH),
                              B.IDBENHNHAN	,
							  D1.TenLoai AS LoaiUT,
                              D.IDKHAMBENH,d1.ThuTu as TTUT
                              ,d.idkhambenhmoi
                             ,KhoaChuyen=K2.TENPHONGKHAMBENH
                             ,ChuyenDen= ( CASE WHEN ISNULL(D0.IdBenhVienChuyen,0)<>0 THEN TenBenhVien ELSE   (Case When D.IDKHOA<>D0.IDKHOA  THEN ( CASE WHEN ISNULL(D0.IdChuyenPK,0)=0 THEN I.TenPhongKhamBenh ELSE DBO.HS_TENPHONG(D0.IdChuyenPK) +' - ' + I.TenPhongKhamBenh END  )ELSE DBO.HS_TENPHONG(D0.IdChuyenPK) END) END)
                            FROM KHAMBENH D
                            LEFT JOIN CHITIETDANGKYKHAM A ON A.IDCHITIETDANGKYKHAM=D.IDCHITIETDANGKYKHAM
	                        LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
	                        LEFT JOIN BENHNHAN C ON C.IDBENHNHAN=B.IDBENHNHAN
                            LEFT JOIN PHONGKHAMBENH K2 ON ISNULL(D.IDKHOA,D.IDPHONGKHAMBENH)=K2.IDPHONGKHAMBENH
                            LEFT JOIN BACSI E ON D.IDBACSI=E.IDBACSI
                            LEFT JOIN DANGKYKHAM F ON D.IDKHAMBENH=F.IDKHAMBENH_CHUYEN
                            LEFT JOIN CHITIETDANGKYKHAM G ON F.IDDANGKYKHAM=G.IDDANGKYKHAM
                            LEFT JOIN KB_LOAIUUTIEN D1 ON C.idloaiuutien=D1.ID
                            LEFT JOIN KB_HUONGDIEUTRI HDT ON D.HUONGDIEUTRI=HDT.HUONGDIEUTRIID
                            LEFT JOIN KHAMBENH D0 ON D.idkhambenhmoi=D0.IDKHAMBENH
                            LEFT JOIN PHONGKHAMBENH I ON D0.IdkhoaChuyen=I.IDPHONGKHAMBENH
                            LEFT JOIN BENHVIEN K ON D0.IdBenhVienChuyen=K.idBenhVien
                            WHERE ISNULL(D.IDKHOA,D.IDPHONGKHAMBENH) <> " + IdKhoa_default + @" AND isnull(D.TGXuatVien,d.ngaykham)>='" + StaticData.CheckDate(Tungay.Text) + @"'
                            AND isnull(D.TGXuatVien,d.ngaykham)<='" + StaticData.CheckDate(this.Denngay.Text) + @" 23:59:59'
                            AND isnull(D.IdkhoaChuyen,D.PHONGKHAMCHUYENDEN)=" + this.Khoa.SelectedValue + "" + "\r\n"
                           + (txtMaBN.Text != null && txtMaBN.Text != "" ? " and c.mabenhnhan='" + txtMaBN.Text.Trim() + "'" : "")
                               + (txtTenBN.Text != null && txtTenBN.Text != "" ? " and (dbo.untiengviet(c.tenbenhnhan) like N'%" + txtTenBN.Text.Trim() + "%' or c.tenbenhnhan like N'%" + txtTenBN.Text.Trim() + "%')" : "");

        DataTable table = DataAcess.Connect.GetTable(sql);
        table.Columns.Add("STT", "STT".GetType());
        table.DefaultView.Sort = "TTUT,SoTT";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            table.Rows[i]["STT"] = i + 1;
        }
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int row = Convert.ToInt32(e.CommandArgument);
        string idchitietdangkykham = GridView1.DataKeys[row].Value.ToString();
        string idbenhnhan = ((Label)GridView1.Rows[row].Cells[1].FindControl("IDBENHNHAN")).Text;

        if (e.CommandName == "Kham")
        {
            string IDKHAMBENH = ((Label)GridView1.Rows[row].Cells[1].FindControl("IDKHAMBENH")).Text;
            string idkhambenhmoi = ((Label)GridView1.Rows[row].Cells[1].FindControl("idkhambenhmoi")).Text;
            if (idkhambenhmoi != null && idkhambenhmoi != "")
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "&idkhoachinh=" + idkhambenhmoi + "','_blank','location=0,status=0,menubar=0,scrollbars=1;');", true);
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "&LoaiBN=" + Request.QueryString["LoaiBN"] + "#idchitietdangkykham=" + idchitietdangkykham + "&idbenhnhan=" + idbenhnhan + (IDKHAMBENH != null && IDKHAMBENH != "0" ? "&idkhambenhchuyenphong=" + IDKHAMBENH : "") + "','_blank','location=0;status=0,menubar=0,scrollbars=1;');", true);
            this.GridView1.Rows[row].Visible = false;
        }
        if (e.CommandName == "xemcno")
        {
            string dkmenu = Request.QueryString["dkmenu"];
            string idkhoa = Khoa.SelectedValue;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "show", "window.open('../noitru_BaoCao/nvk_ChiTietCongNoBenhNhan.aspx?dkmenu=" + dkmenu + "&idbenhnhan=" + idbenhnhan + "&idctdkk=" + idchitietdangkykham + "&IdKhoa=" + idkhoa + "&IsShowTamUng=1'" + ",'_blank','location=0,status=0,menubar=0,scrollbars=1');", true);
        }
    }
    public void loadKhoa()
    {
        //string IdKhoa_default = Request.QueryString["IdKhoa"];
        //if (IdKhoa_default == null || IdKhoa_default == "") IdKhoa_default = "22";
        //if (IdKhoa_default != "1")
        //    this.Khoa.Enabled = false;
        StaticData.FillCombo(Khoa, DataAcess.Connect.GetTable("select * from phongkhambenh"), "idphongkhambenh", "tenphongkhambenh");
        //Khoa.SelectedValue = IdKhoa_default;
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
            ////ThuanNH 05/04/2010 
            ////Redirect su kien onclick in hoa don (Phieu tong hop thanh toan BH)
            //btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnInHoaDon"));
            //btn.Attributes.Add("onclick", "return InPhieuDangTHThanhToanBH(" + dgr.DataKeys[e.Item.ItemIndex] + ");");
            //------------------------------------------------------------------
            //btn.Attributes.Add("onclick", "return ConfirmDelete();");
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
