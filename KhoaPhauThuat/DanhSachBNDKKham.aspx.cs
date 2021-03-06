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
    //_____________________________________________________________________________________________________________
    string LoaiBenhNhan;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbHeader.InnerText = "DANH SÁCH BỆNH NHÂN NHẬP KHOA";
        string IsHauPhau = Request.QueryString["IsHauPhau"];
        if(IsHauPhau=="1")
            lbHeader.InnerText = "DANH SÁCH BỆNH NHÂN ĐANG THEO DÕI";


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
    //_____________________________________________________________________________________________________________
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
        string IdKhoa_default = Request.QueryString["IdKhoa"];
        if (IdKhoa_default == null || IdKhoa_default == "") IdKhoa_default = "22";
        string IsHauPhau = Request.QueryString["IsHauPhau"];
        string PhongHauPhau = StaticData.GetParaValueDB("IdPhongHauPhau");
        string sTuNgay = StaticData.CheckDate(Tungay.Text);
        string sDenNgay = StaticData.CheckDate(Denngay.Text);
        DataTable dt = null;
        string sql = null;
        if (IsHauPhau != "1")
        {
              sql = @"(
                                SELECT  MABENHNHAN,
		                                TENBENHNHAN,
		                                NGAYSINH,
		                                GIOITINH=DBO.GETGIOITINH(GIOITINH),
		                                NGAYNHAPKHOA=ISNULL(TGXUATVIEN,NGAYKHAM),
                                        KHOACHUYEN=TENPHONGKHAMBENH,
                                        CHUYENDEN=(SELECT TENPHONGKHAMBENH FROM KHAMBENH A1 INNER JOIN PHONGKHAMBENH B1 ON A1.IDPHONGKHAMBENH=B1.IDPHONGKHAMBENH WHERE A1.IDKHAMBENH=A.IDKHAMBENHMOI),
		                                A.IDCHITIETDANGKYKHAM,
                                        LOAIKHAMID=D.LOAIKHAMID,
                                        IDBENHNHAN=A.IDBENHNHAN,
                                        A.IDKHAMBENH,
                                        A.IDKHAMBENHMOI,
		                                TYPE='NHAPKHOA'
                                FROM KHAMBENH A
                                LEFT JOIN PHONGKHAMBENH B ON A.IDPHONGKHAMBENH=B.IDPHONGKHAMBENH
                                LEFT JOIN BENHNHAN C ON A.IDBENHNHAN=C.IDBENHNHAN
                                LEFT JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
                                WHERE  ISNULL(A.ISDACHUYENKHOA,0)<>2 AND
		                                ISNULL(A.TGXUATVIEN,A.NGAYKHAM)>='" + sTuNgay + @"' 
                                AND 	ISNULL(A.TGXUATVIEN,A.NGAYKHAM)<='" + sDenNgay + @" 23:59:59'  
                                AND A.PHONGKHAMCHUYENDEN=" + IdKhoa_default + @"
                                AND (  A.IDPHONGKHAMBENH<>" + IdKhoa_default + @"   OR  ( A.IDPHONGKHAMBENH=" + IdKhoa_default + @" AND A.PHONGID="+PhongHauPhau+@"  AND A.IDKHOACHUYEN="+IdKhoa_default+@" ))      "
                                  + (this.txtMaBN.Text != "" ? " AND C.MABENHNHAN LIKE N'%" + this.txtMaBN.Text + "%'" : "")
                                 + (this.txtTenBN.Text != "" ? " AND C.TENBENHNHAN LIKE N'%" + this.txtTenBN.Text + "%'" : "")
                                + @"
                                )
                                UNION ALL
                                (

                                SELECT  MABENHNHAN,
		                                TENBENHNHAN,
		                                NGAYSINH,
		                                GIOITINH=DBO.GETGIOITINH(GIOITINH),
		                                NGAYNHAPKHOA=NGAYKHAM,
                                        KHOACHUYEN=(SELECT TOP 1 TENPHONGKHAMBENH FROM KHAMBENH A1 INNER JOIN PHONGKHAMBENH B1 ON A1.IDPHONGKHAMBENH=B1.IDPHONGKHAMBENH WHERE   A1.IDDANGKYKHAM=A.IDDANGKYKHAM AND ( CASE WHEN ISNULL(A.IDKHAMBENHGOC,0)<>0 THEN (CASE WHEN A1.IDKHAMBENH=A.IDKHAMBENHGOC THEN 1 ELSE 0 END)  ELSE ( CASE WHEN A1.IDKHAMBENH<A.IDKHAMBENH THEN 1 ELSE 0 END )  END)=1     ORDER BY A1.IDKHAMBENH DESC),
                                        CHUYENDEN=B.TENPHONGKHAMBENH,
		                                A.IDCHITIETDANGKYKHAM,
                                        LOAIKHAMID=D.LOAIKHAMID,
                                        IDBENHNHAN=A.IDBENHNHAN,
                                        IDKHAMBENH=A.IDKHAMBENH,
                                        IDKHAMBENHMOI=A.IDKHAMBENH,
                                        TYPE='DAKHAM'
                                FROM KHAMBENH A
                                LEFT JOIN PHONGKHAMBENH B ON A.IDPHONGKHAMBENH=B.IDPHONGKHAMBENH
                                LEFT JOIN BENHNHAN C ON A.IDBENHNHAN=C.IDBENHNHAN
                                LEFT JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
                                WHERE    A.PHONGID<>" + PhongHauPhau + @"
		                               AND  A.NGAYKHAM>='" + sTuNgay + @"' 
                                AND 	 A.NGAYKHAM<='" + sDenNgay + @" 23:59:59'  
                                AND      A.IDPHONGKHAMBENH=" + IdKhoa_default + @""
                                    + (this.txtMaBN.Text != "" ? " AND C.MABENHNHAN LIKE N'%" + this.txtMaBN.Text + "%'" : "")
                                    + (this.txtTenBN.Text != "" ? " AND C.TENBENHNHAN LIKE N'%" + this.txtTenBN.Text + "%'" : "")
                                + @"
                              )";

          
        }
        else
        {
             sql = @"(
                                SELECT  MABENHNHAN,
		                                TENBENHNHAN,
		                                NGAYSINH,
		                                GIOITINH=DBO.GETGIOITINH(GIOITINH),
		                                NGAYNHAPKHOA=ISNULL(TGXUATVIEN,NGAYKHAM),
                                        KHOACHUYEN=TENPHONGKHAMBENH,
                                        CHUYENDEN=(SELECT TENPHONGKHAMBENH FROM KHAMBENH A1 INNER JOIN PHONGKHAMBENH B1 ON A1.IDPHONGKHAMBENH=B1.IDPHONGKHAMBENH WHERE A1.IDKHAMBENH=A.IDKHAMBENHMOI),
		                                A.IDCHITIETDANGKYKHAM,
                                        LOAIKHAMID=D.LOAIKHAMID,
                                        IDBENHNHAN=A.IDBENHNHAN,
                                        A.IDKHAMBENH,
                                        IDKHAMBENHMOI=A.IDKHAMBENHMOI,
		                                TYPE='NHAPKHOA'
                                FROM KHAMBENH A
                                LEFT JOIN PHONGKHAMBENH B ON A.IDPHONGKHAMBENH=B.IDPHONGKHAMBENH
                                LEFT JOIN BENHNHAN C ON A.IDBENHNHAN=C.IDBENHNHAN
                                LEFT JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
                                WHERE   ISNULL(A.ISDACHUYENKHOA,0)<>2 AND
		                                ISNULL(A.TGXUATVIEN,A.NGAYKHAM)>='" + sTuNgay + @"' 
                                AND 	ISNULL(A.TGXUATVIEN,A.NGAYKHAM)<='" + sDenNgay + @" 23:59:59'  
                                AND A.PHONGKHAMCHUYENDEN=" + IdKhoa_default + @"
                                AND A.IDPHONGKHAMBENH<>" + IdKhoa_default + @""
                                  + (this.txtMaBN.Text != "" ? " AND C.MABENHNHAN LIKE N'%" + this.txtMaBN.Text + "%'" : "")
                                 + (this.txtTenBN.Text != "" ? " AND C.TENBENHNHAN LIKE N'%" + this.txtTenBN.Text + "%'" : "")
                                + @"
                                )
                                UNION ALL
                                (

                                SELECT DISTINCT  MABENHNHAN,
		                                TENBENHNHAN,
		                                NGAYSINH,
		                                GIOITINH=DBO.GETGIOITINH(GIOITINH),
		                                NGAYNHAPKHOA=E.NGAYKHAM,
                                        KHOACHUYEN=(SELECT TENPHONGKHAMBENH FROM   PHONGKHAMBENH B1  WHERE B1.IDPHONGKHAMBENH= E.IDPHONGKHAMBENH),
                                        CHUYENDEN=( SELECT TOP 1  TENPHONGKHAMBENH FROM PHONGKHAMBENH  B1 INNER JOIN KHAMBENH A1 ON A1.IDPHONGKHAMBENH=B1.IDPHONGKHAMBENH WHERE A1.IDKHAMBENH=A.IDKHAMBENHGOC ORDER BY A1.IDKHAMBENH DESC),
		                                A.IDCHITIETDANGKYKHAM,
                                        LOAIKHAMID=D.LOAIKHAMID,
                                        IDBENHNHAN=A.IDBENHNHAN,
                                        IDKHAMBENH=NULL,
                                        IDKHAMBENHMOI=A.IDKHAMBENHGOC,
                                        TYPE='DAKHAM'
                                FROM KHAMBENH A
                                LEFT JOIN PHONGKHAMBENH B ON A.IDPHONGKHAMBENH=B.IDPHONGKHAMBENH
                                LEFT JOIN BENHNHAN C ON A.IDBENHNHAN=C.IDBENHNHAN
                                LEFT JOIN DANGKYKHAM D ON A.IDDANGKYKHAM=D.IDDANGKYKHAM
                                LEFT JOIN KHAMBENH E ON A.IDKHAMBENHGOC=E.IDKHAMBENH
                                WHERE    A.PHONGID=" + PhongHauPhau + @"
		                              AND   A.NGAYKHAM>='" + sTuNgay + @"' 
                                AND 	 A.NGAYKHAM<='" + sDenNgay + @" 23:59:59'  
                                AND      A.IDPHONGKHAMBENH=" + IdKhoa_default + @""
                                    + (this.txtMaBN.Text != "" ? " AND C.MABENHNHAN LIKE N'%" + this.txtMaBN.Text + "%'" : "")
                                    + (this.txtTenBN.Text != "" ? " AND C.TENBENHNHAN LIKE N'%" + this.txtTenBN.Text + "%'" : "")
                                + @"
                              )";

        }

        DataTable table = DataAcess.Connect.GetTable(sql);
        dt = table.Copy();
        dt.Rows.Clear();
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        for (int i = 0; i < table.Rows.Count; i++)
        {
            string IDKHAMBENHMOI = table.Rows[i]["IDKHAMBENHMOI"].ToString();
            if (IDKHAMBENHMOI == "") StaticData.dt_ImportRow(table, i, dt);
            else
            {
                if (lstC.IndexOf(IDKHAMBENHMOI) == -1)
                {
                    StaticData.dt_ImportRow(table, i, dt);
                    lstC.Add(IDKHAMBENHMOI);
                }

            }
        }

        dt.Columns.Add("STT", "STT".GetType());
        dt.DefaultView.Sort = "NGAYNHAPKHOA";
        dt = dt.DefaultView.ToTable();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["STT"] = i + 1;
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    //_____________________________________________________________________________________________________________
    
    public void loadKhoa()
    {
        string IdKhoa_default = Request.QueryString["IdKhoa"];
        if (IdKhoa_default == null || IdKhoa_default == "") IdKhoa_default = "22";
        if (IdKhoa_default != "1")
            this.Khoa.Enabled = false;
        StaticData.FillCombo(Khoa, DataAcess.Connect.GetTable("select * from phongkhambenh"), "idphongkhambenh", "tenphongkhambenh");
        Khoa.SelectedValue = IdKhoa_default;
    }
    //_____________________________________________________________________________________________________________
    protected void TimKiem_Click(object sender, EventArgs e)
    {
        getTableDS();
    }
    //_____________________________________________________________________________________________________________
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        getTableDS();
    }
    //_____________________________________________________________________________________________________________
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
    //_____________________________________________________________________________________________________________
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
   
        int row = Convert.ToInt32(e.CommandArgument);
        string idchitietdangkykham = GridView1.DataKeys[row].Value.ToString();
        string idbenhnhan = ((Label)GridView1.Rows[row].Cells[1].FindControl("IDBENHNHAN")).Text;
        string IsHauPhau = Request.QueryString["IsHauPhau"];
        string IDKHAMBENH = ((Label)GridView1.Rows[row].Cells[1].FindControl("IDKHAMBENH")).Text;
        string LOAIKHAMID = ((Label)GridView1.Rows[row].Cells[1].FindControl("LOAIKHAMID")).Text;
        string TYPE = ((Label)GridView1.Rows[row].Cells[1].FindControl("TYPE")).Text;
        string idkhambenhmoi = ((Label)GridView1.Rows[row].Cells[1].FindControl("IDKHAMBENHMOI")).Text;

        if (e.CommandName == "Kham")
        {
        if (idkhambenhmoi == null || idkhambenhmoi == "")
        {
            if (IDKHAMBENH != "")
            {
                string sqlSelect0 = "SELECT * FROM KHAMBENH WHERE IDKHAMBENH=" + IDKHAMBENH;
                DataTable dtKB0 = DataAcess.Connect.GetTable(sqlSelect0);
                if (dtKB0 == null || dtKB0.Rows.Count == 0) return;
                idkhambenhmoi = dtKB0.Rows[0]["idkhambenhmoi"].ToString();
            }
        }
            #region Insert khám bệnh mới
            if (idkhambenhmoi == null || idkhambenhmoi == "")
            {
                string sqlSelect1 = "SELECT * FROM KHAMBENH WHERE IDKHAMBENH=" + IDKHAMBENH;
                DataTable dtKB = DataAcess.Connect.GetTable(sqlSelect1);
                if (dtKB == null || dtKB.Rows.Count == 0) return;
                string TGXuatVienPrev = dtKB.Rows[0]["TGXuatVien"].ToString();
                string NgayKhamPrev = dtKB.Rows[0]["NgayKham"].ToString();
                if (TGXuatVienPrev == "") TGXuatVienPrev = NgayKhamPrev;
                TGXuatVienPrev = DateTime.Parse(TGXuatVienPrev).ToString("dd/MM/yyyy");
                DataProcess KB = new DataProcess("khambenh");
                KB.data("idbenhnhan", idbenhnhan);
                KB.data("idchitietdangkykham", idchitietdangkykham);
                KB.data("iddangkykham", dtKB.Rows[0]["iddangkykham"].ToString());
                KB.data("ngaykham", TGXuatVienPrev);
                KB.data("TGXuatVien", TGXuatVienPrev);
                KB.data("idkhambenhchuyenphong", IDKHAMBENH);
                KB.data("idkhoa", this.Khoa.SelectedValue);
                KB.data("IDPHONGKHAMBENH", this.Khoa.SelectedValue);
                KB.data("idkhoachuyen", this.Khoa.SelectedValue);
                KB.data("IdChuyenPK", StaticData.GetParaValueDB("IdPhongHauPhau"));
                bool OK = KB.Insert();
                if (!OK) return;
                idkhambenhmoi = KB.getData("idkhambenh");
                bool OK2 = DataAcess.Connect.ExecSQL("UPDATE KHAMBENH SET IDKHAMBENHMOI=" + idkhambenhmoi + " WHERE IDKHAMBENH=" + IDKHAMBENH);
            }
            #endregion
            if (IsHauPhau != "1")
            {
                if (idkhambenhmoi != null && idkhambenhmoi != "")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "&idkhoachinh=" + idkhambenhmoi + "','_blank','location=0,status=0,menubar=0,scrollbars=1;');", true);
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "KhamBenh.aspx?dkMenu=" + Request.QueryString["dkMenu"] + "&LoaiBN=" + Request.QueryString["LoaiBN"] + "#idchitietdangkykham=" + idchitietdangkykham + "&idbenhnhan=" + idbenhnhan + (IDKHAMBENH != null && IDKHAMBENH != "0" ? "&idkhambenhchuyenphong=" + IDKHAMBENH : "") + "','_blank','location=0;status=0,menubar=0,scrollbars=1;');", true);
            }
            else
            {

                #region Tạo Khambenh_View
                string IDBENHNHAN = idbenhnhan;
                string DenNgay = StaticData.CheckDate(this.Denngay.Text) + " 23:59:59";
                if (DenNgay == null || DenNgay == "")
                    DenNgay = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
                if (IDBENHNHAN == null || IDBENHNHAN == "") return;
                string IdKhoa = this.Khoa.SelectedValue;
                if (IdKhoa == null || IdKhoa == "") IdKhoa = "22";

                DataTable dt = DataAcess.Connect.GetTable("SELECT * FROM HS_KHAMBENH_VIEW WHERE IDBENHNHAN=" + IDBENHNHAN
                                                       + " AND DenNgay<='" + DenNgay + "' AND IDKHOA=" + IdKhoa);
                if (dt == null) return;
                string idkhoachinh = null;
                if (dt.Rows.Count > 0) idkhoachinh = dt.Rows[0][0].ToString();
                else
                {
                    string sqlMaxIdToathuoc = "SELECT MAX(IdToaThuoc) FROM HS_KHAMBENH_VIEW";
                    DataTable dtIdToaThuoc = DataAcess.Connect.GetTable(sqlMaxIdToathuoc);
                    if (dtIdToaThuoc == null) return;
                    if (dtIdToaThuoc.Rows.Count == 0 || dtIdToaThuoc.Rows[0][0].ToString() == "0" || dtIdToaThuoc.Rows[0][0].ToString() == "")
                        idkhoachinh = "1";
                    else
                        idkhoachinh = (int.Parse(dtIdToaThuoc.Rows[0][0].ToString()) + 1).ToString();

                    string sqlSave = @"
                                  INSERT INTO HS_KHAMBENH_VIEW(IdToaThuoc,DenNgay,IDBENHNHAN,IDKHOA)
                                  select DISTINCT IdToaThuoc=" + idkhoachinh
                                                   + @",DenNgay='" + DenNgay
                                                   + @"', A.IDBENHNHAN
                                            , " + IdKhoa + @"
                                            FROM KHAMBENH A
                                            WHERE  IDKHOACHUYEN=" + IdKhoa
                                                           + @" AND ISNULL(A.IDKHOA,A.IDPHONGKHAMBENH)=" + IdKhoa
                                                           + "  AND   ISNULL(A.TGXuatVien,A.NGAYKHAM)<='" + DenNgay + "'"
                                                           + "   AND A.IDBENHNHAN =" + IDBENHNHAN;
                    bool ok = DataAcess.Connect.ExecSQL(sqlSave);
                    if (!ok) return;
                }

                #region Lưu chi tiết đơn thuốc
                string SQLSAVECHITIET = @"
                                                DELETE HS_KHAMBENH_VIEWDetail WHERE IdToaThuoc=" + idkhoachinh + @"
                                                INSERT INTO HS_KHAMBENH_VIEWDetail (IdToaThuoc,
                                                                                    ChiTietThuoc,
                                                                                    ChiTietBenh,
                                                                                    ChiTietCLS,
                                                                                    IDKHAMBENH
                                                                                   )
                                                
                                                SELECT " + idkhoachinh
                                                           + @", ChiTietThuoc=DBO.HS_CHITIETTHUOC(A.IDKHAMBENH)
	                                                   ,ChiTietBenh=DBO.HS_CHITIETBENH2(A.IDKHAMBENH)
	                                                   ,ChiTietCLS=DBO.HS_CHITIETCANLAMSAN(A.IDKHAMBENH)
                                                       ,A.IDKHAMBENH
                                                  FROM KHAMBENH A
                                                  LEFT JOIN KB_PHONG B ON ISNULL(A.PHONGID,A.IDPHONG)=B.ID  
                                            WHERE ( A.IDKHAMBENH>" + idkhambenhmoi + " OR A.IDPHONG=" + StaticData.GetParaValueDB("IdPhongHauPhau") + ")"
                                                           + @" AND ISNULL(A.IDKHOA,A.IDPHONGKHAMBENH)=" + IdKhoa
                                                           + "  AND   ISNULL(A.TGXuatVien,A.NGAYKHAM)<='" + DenNgay + "'"
                                                           + "   AND A.idchitietdangkykham =" + idchitietdangkykham
                                                           + "   AND A.IDBENHNHAN =" + IDBENHNHAN;

                bool ok_detail = DataAcess.Connect.ExecSQL(SQLSAVECHITIET);
                if (!ok_detail)
                {
                    return;
                }
                string sqlDetail = "SELECT TOP 1 IDKHAMBENH FROM HS_KHAMBENH_VIEWDETAIL WHERE IDTOATHUOC=" + idkhoachinh;
                DataTable dtDetail = DataAcess.Connect.GetTable(sqlDetail);
                if (dtDetail == null)
                {
                    return;
                }
                string LoaiBN = LOAIKHAMID;
                string idkhambenhchuyenphong = IDKHAMBENH;
                if (IsHauPhau == "1") idkhambenhchuyenphong = idkhambenhmoi;
                string IsHaveKhamBenh = "1";
                if (dtDetail.Rows.Count == 0) IsHaveKhamBenh = "0";
                string data = idkhoachinh + "|" + IsHaveKhamBenh + "|" + LoaiBN + "|" + idchitietdangkykham + "|" + IDBENHNHAN + "|" + idkhambenhchuyenphong;
                #endregion

                #endregion
                #region Gọi giao diện hậu phẫu
                string IsHaveId = data.Split('|')[1];
                if (IsHaveId == "1")
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "HS_KHAMBENH_VIEW3.aspx?idkhoachinh=" + data.Split('|')[0]
                        + "&LoaiBN=" + data.Split('|')[2]
                        + "&idchitietdangkykham=" + data.Split('|')[3]
                        + "&IDBENHNHAN=" + data.Split('|')[4]
                        + "&idkhambenhchuyenphong=" + data.Split('|')[5]
                        + "&disabledCaKipMo=1"
                        + "','_blank','location=0,status=0,menubar=0,scrollbars=1;');", true);
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "msg", "window.open('" + "KhamBenh.aspx?LoaiBN=" + data.Split('|')[2]
                        + "&idchitietdangkykham=" + data.Split('|')[3]
                        + "&IDBENHNHAN=" + data.Split('|')[4]
                        + "&idkhambenhchuyenphong=" + data.Split('|')[5]
                        + "&disabledCaKipMo=1"
                                + "','_blank','location=0,status=0,menubar=0,scrollbars=1;');", true);
                #endregion
            }
        }
        if (e.CommandName == "xemcno")
        {
            string dkmenu = Request.QueryString["dkmenu"];
            string idkhoa = Khoa.SelectedValue;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "show", "window.open('../noitru_BaoCao/nvk_ChiTietCongNoBenhNhan.aspx?dkmenu=" + dkmenu + "&idbenhnhan=" + idbenhnhan + "&idctdkk=" + idchitietdangkykham + "&IdKhoa=" + idkhoa + "&IsShowTamUng=1'" + ",'_blank','location=0,status=0,menubar=0,scrollbars=1');", true);
        }
    }
    //_____________________________________________________________________________________________________________
}
