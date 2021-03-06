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
        Page.Title = "QLBV-  Khám Bệnh";
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
        this.DichvuKCB.Visible = StaticData.EnableChuyenKhoa;
        this.lbChuyenKhoa.Visible = this.DichvuKCB.Visible;
        loadKhoa();
        getTableDS();


    }
    public void getTableDS()
    {

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
            swhere += " and (dbo.untiengviet(c.tenbenhnhan) like N'%" + StaticData.s_GetNameNotSign(txtTenBN.Text.Trim()) + "%' or c.tenbenhnhan like N'%" + txtTenBN.Text.Trim() + "%')";
        }
        string sBatBuocThuPhiTruocKham= StaticData.GetParameter("isBatBuocThuPhiTruocKham")!=null ? StaticData.GetParameter("isBatBuocThuPhiTruocKham"): "1";
        bool isBatBuocThuPhiTruocKham = StaticData.IsCheck(sBatBuocThuPhiTruocKham);
        string sql = @"( 
                        SELECT 
                           A.IDCHITIETDANGKYKHAM,
	                       A.IDDANGKYKHAM,
	                       A.SOTT,
	                       NGAYDANGKY=ISNULL(B.NGAYXACNHAN,B.NGAYDANGKY),
	                        C.MABENHNHAN,
	                        C.TENBENHNHAN,
	                        C.ngaysinh,
	                       GIOITINH=DBO.GetGioiTinh( C.GIOITINH),
	                       B.IDBENHNHAN,
                           D.TenLoai AS LoaiUT,IDKHAMBENH=0,d.ThuTu as TTUT,TYPE=1,TypeName=N'Chờ khám'+( CASE WHEN A.IsCoDKCLS=1 THEN N'(Có tự ĐKCLS)' ELSE '' END)
                           ,THOIGIANTRAKQ=A.NgayTraKQCLS
	                       FROM CHITIETDANGKYKHAM A
		                    LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
		                    LEFT JOIN BENHNHAN C ON C.IDBENHNHAN=B.IDBENHNHAN 
                            LEFT JOIN KB_LOAIUUTIEN D ON C.idloaiuutien=D.ID
                            LEFT JOIN BANGGIADICHVU E ON A.IDBANGGIADICHVU=E.IDBANGGIADICHVU
                            WHERE ISNULL(A.DAHUY,0)=0 AND  ISNULL(B.NGAYXACNHAN,B.NGAYDANGKY)>='" + DataProcess.sGetSaveValue(Tungay.Text, "date").Replace("'", "") + @"'
	                        AND ISNULL(B.NGAYXACNHAN,B.NGAYDANGKY)<='" + DataProcess.sGetSaveValue(Denngay.Text, "date").Replace("'", "") + @" 23:59:59'
		                    AND A.PHONGID='" + Phong.SelectedValue + @"'
                            " + (isBatBuocThuPhiTruocKham ? " AND (A.IsDaThu=1 or b.loaikhamid =1 OR E.IDPHONGKHAMBENH<>1  OR a.isNotThuPhiCapCuu=1) " : "") + @"
                            AND ISNULL(IDKHAMBENH_CHUYEN,0)=0
		                    AND NOT EXISTS (SELECT IDKHAMBENH FROM KHAMBENH WHERE IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM)
		                    AND ISNULL( B.DAHUY,0)=0 
                             " + swhere
                + ")"
                + "\r\n"
                + " UNION  ("
                            + @" SELECT  
                              IDCHITIETDANGKYKHAM=ISNULL(G.IDCHITIETDANGKYKHAM,A.IDCHITIETDANGKYKHAM),
                              IDDANGKYKHAM=ISNULL(F.IDDANGKYKHAM, A.IDDANGKYKHAM),
							  SoTT=( CASE WHEN ISNULL(IsChuyenPhongCoPhi,0)=0 THEN D.SoTTChuyenP ELSE  G.SoTT END),
                              NGAYDANGKY=d.TGXuatVien,
                              C.MABENHNHAN,    
                              C.TENBENHNHAN,
							  C.NGAYSINH,
                              GIOITINH=DBO.GetGioiTinh( C.GIOITINH),
                              B.IDBENHNHAN	,
							  D1.TenLoai AS LoaiUT,
                              D.IDKHAMBENH,d1.ThuTu as TTUT,TYPE=2,TypeName=N'Chuyển phòng'
                             ,THOIGIANTRAKQ=NULL
                            FROM KHAMBENH D
                            LEFT JOIN CHITIETDANGKYKHAM A ON A.IDCHITIETDANGKYKHAM=D.IDCHITIETDANGKYKHAM
	                        LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
	                        LEFT JOIN BENHNHAN C ON C.IDBENHNHAN=B.IDBENHNHAN
                            LEFT JOIN PHONGKHAMBENH K2 ON D.IDKHOA=K2.IDPHONGKHAMBENH
                            LEFT JOIN BACSI E ON D.IDBACSI=E.IDBACSI
                            LEFT JOIN DANGKYKHAM F ON D.IDKHAMBENH=F.IDKHAMBENH_CHUYEN
                            LEFT JOIN CHITIETDANGKYKHAM G ON F.IDDANGKYKHAM=G.IDDANGKYKHAM
                            LEFT JOIN KB_LOAIUUTIEN D1 ON C.idloaiuutien=D1.ID
                            WHERE D.TGXuatVien>='" + DataProcess.sGetSaveValue(Tungay.Text, "date").Replace("'", "") + @"'
                            AND D.TGXuatVien<='" + DataProcess.sGetSaveValue(Denngay.Text, "date").Replace("'", "") + @" 23:59:59'
                            AND D.IdkhoaChuyen=" + this.Khoa.SelectedValue + "" + "\r\n"
                            + (this.Phong.SelectedValue != null && this.Phong.SelectedValue != "" ? " AND D.IdChuyenPK='" + Phong.SelectedValue + @"'" : "")
                            + @" AND  ISNULL( B.DAHUY,0)=0
                             "+(isBatBuocThuPhiTruocKham?" AND (ISNULL(IsChuyenPhongCoPhi,0)=0   OR  G.IsDathu=1 )": "")+@"
                             AND  ISNULL(D.idkhambenhchuyenphong,0)=0   
                            "+ (txtMaBN.Text != null && txtMaBN.Text != "" ? " and c.mabenhnhan='" + txtMaBN.Text.Trim() + "'" : "")
                                + (txtTenBN.Text != null && txtTenBN.Text != "" ? " and (dbo.untiengviet(c.tenbenhnhan) like N'%" + txtTenBN.Text.Trim() + "%' or c.tenbenhnhan like N'%" + txtTenBN.Text.Trim() + "%')" : "")
                + ")"
                 + "\r\n"
                + @"
                 UNION
                 ( 
                      SELECT  
                                A.IDCHITIETDANGKYKHAM,
	                            A.IDDANGKYKHAM,
                                SoTT=ISNULL((SELECT TOP 1 SoTTChuyenP FROM KHAMBENH WHERE IDKHAMBENHMOI=D.IDKHAMBENH ORDER BY IDKHAMBENH DESC ),A.SOTT),
	                            B.NGAYDANGKY,
	                            C.MABENHNHAN,
	                            C.TENBENHNHAN,
	                            C.NGAYSINH,
	                            GIOITINH=DBO.GetGioiTinh( C.GIOITINH),
	                            B.IDBENHNHAN	,
                                D1.TenLoai AS LoaiUT,
                                D.IDKHAMBENH,d1.ThuTu as TTUT,TYPE=3,TypeName=N'Chờ CLS' 
                               ,THOIGIANTRAKQ=D.NgayTraKQCLS
	                        FROM KHAMBENH D
                            LEFT JOIN CHITIETDANGKYKHAM A ON A.IDCHITIETDANGKYKHAM=D.IDCHITIETDANGKYKHAM
		                    LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
		                    LEFT JOIN BENHNHAN C ON C.IDBENHNHAN=B.IDBENHNHAN
                            LEFT JOIN KB_LOAIUUTIEN D1 ON C.idloaiuutien=D1.ID
                            WHERE ISNULL(D.ISKHONGKHAM,0)=0 AND D.IsHaveCLS=1 AND D.HUONGDIEUTRI IN (6,10)  AND  NGAYKHAM>='" + DataProcess.sGetSaveValue(Tungay.Text, "date").Replace("'", "") + @"'
	                        AND NGAYKHAM<='" + DataProcess.sGetSaveValue(Denngay.Text, "date").Replace("'", "") + @" 23:59:59'
		                    AND D.PHONGID='" + Phong.SelectedValue + @"' -- PHONGID = PHÒNG XÁC ĐỊNH TRÊN GIAO DIỆN 
		                    " + swhere
                + ")";

        DataTable table = DataAcess.Connect.GetTable(sql);
        table.Columns.Add("STT", "STT".GetType());

        for (int i = 0; i < table.Rows.Count; i++)
        {
            if (table.Rows[i]["THOIGIANTRAKQ"].ToString() != "")
                table.Rows[i]["NGAYDANGKY"] = table.Rows[i]["THOIGIANTRAKQ"].ToString();
        }

        table.DefaultView.Sort = "TTUT,NGAYDANGKY,SoTT";
        table = table.DefaultView.ToTable();
        for (int i = 0; i < table.Rows.Count; i++)
        {
            table.Rows[i]["STT"] = i + 1;
        }
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
    //___________________________________________________________________________________________________________________

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int row = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Kham")
        {
            string idchitietdangkykham = GridView1.DataKeys[row].Value.ToString();
            string idbenhnhan = ((Label)GridView1.Rows[row].Cells[1].FindControl("IDBENHNHAN")).Text;
            string IDKHAMBENH = ((Label)GridView1.Rows[row].Cells[1].FindControl("IDKHAMBENH")).Text;
            string LoaiDS = ((Label)GridView1.Rows[row].Cells[1].FindControl("lbType")).Text;
            if (LoaiDS != "3")
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "&LoaiBN=" + Request.QueryString["LoaiBN"] + "#idchitietdangkykham=" + idchitietdangkykham + "&idbenhnhan=" + idbenhnhan + (IDKHAMBENH != null && IDKHAMBENH != "0" ? "&idkhambenhchuyenphong=" + IDKHAMBENH : "") + "','_blank','location=0;status=0,menubar=0,scrollbars=1;');", true);
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "#idkhoachinh=" + IDKHAMBENH + "','_blank','location=0;status=0,menubar=0,scrollbars=1;');", true);
            this.GridView1.Rows[row].Visible = false;
        }
    }
    //___________________________________________________________________________________________________________________
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
    //___________________________________________________________________________________________________________________
    protected void Khoa_SelectedIndexChanged(object sender, EventArgs e)
    {

        StaticData.FillCombo(DichvuKCB, DataAcess.Connect.GetTable("select * from banggiadichvu where idphongkhambenh='" + Khoa.SelectedValue + "'"), "idbanggiadichvu", "tendichvu");
        if (this.DichvuKCB.Visible)
            StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByChuyenKhoa(this.DichvuKCB.SelectedValue, this.LoaiBenhNhan), "id", "TenPhongFull");
        else
            StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByKhoa(this.Khoa.SelectedValue), "id", "TenPhongFull");

    }
    //___________________________________________________________________________________________________________________
    protected void DichvuKCB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DichvuKCB.Visible == false) return;
        StaticData.FillCombo(Phong, StaticData.dtPhong_NgoaiTru_ByChuyenKhoa(this.DichvuKCB.SelectedValue, this.LoaiBenhNhan), "id", "TenPhongFull");
        Session["dichvu"] = DichvuKCB.SelectedValue;
    }
    //___________________________________________________________________________________________________________________
    protected void TimKiem_Click(object sender, EventArgs e)
    {
        getTableDS();
    }
    //___________________________________________________________________________________________________________________
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        getTableDS();
    }
    //___________________________________________________________________________________________________________________
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string TYPE = ((Label)e.Row.FindControl("lbType")).Text;
            switch (TYPE)
            {
                case "1": e.Row.CssClass = "type1"; break;
                case "2": e.Row.CssClass = "type2"; break;
                case "3": e.Row.CssClass = "type3"; break;

            }

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'; this.style.cursor='pointer';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'\'");
            /*if (e.Row.RowState != DataControlRowState.Alternate)
            {
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
               
            }
            else
            {
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
               
            }*/
        }
    }
    //___________________________________________________________________________________________________________________
}
