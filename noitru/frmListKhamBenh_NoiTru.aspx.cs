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
public partial class frmListKhamBenh_NoiTru1 : Genaratepage
{
    string dkmenu = "tiepnhan";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lbLoaiBN.Visible = this.cbLoaiBN.Visible = StaticData.HaveBHYT;
       
        if (!IsPostBack)
        {
            SetValueEmpty();
            this.LoadDataNoiTru();
            StaticData.SetFocus(this, "mabN");
        }
         dkmenu = "" + ""; 
        if (Request.QueryString["dkmenu"]!=null &&  dkmenu == "") 
            dkmenu = Request.QueryString["dkmenu"].ToString();

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
    public void noidungkcb(string khoa)
    {
            string KhoaInSelect = khoa != "" ? "and IDPHONGKHAMBENH= " + khoa : "";
            string sql = @"SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE 1=1 and tendichvu <>N'Sổ khám bệnh' " + KhoaInSelect + @"
        and IDBANGGIADICHVU not in (select dichvuKCB from kb_phong p where p.dichvuKCB=IDBANGGIADICHVU and isphongnoitru=1)
";
            DataTable dt = DataAcess.Connect.GetTable(sql);
            StaticData.FillCombo(ddndk, dt, "idbanggiadichvu", "tendichvu", "-- Chọn nội dung khám --");
            if (dt.Rows.Count > 0)
                ddndk.SelectedIndex = 1;
                phongkham(ddndk.SelectedValue);
    }
    public void phongkham(string noidungkham)
    {
        string sql = "SELECT Id,TenPhong=ISNULL(MASO +'-','')+ TENPHONG  FROM kb_phong WHERE DichVuKCB=" + noidungkham;
        if (this.cbLoaiBN.SelectedValue != "0")
        {
            if (this.cbLoaiBN.SelectedValue != "2")
            {
                sql += " AND LOAIBN=1";
            }
            else
            {
                sql += " AND LOAIBN=0";
            }
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhong, dt, "id", "tenphong", "-- Chọn Phòng Khám --");
        //if (dt.Rows.Count > 0) ddlPhong.SelectedIndex = 1;
    }

    private void LoadDataNoiTru()
    {
        DateTime sysdate = DataAcess.Connect.d_SystemDate();
        this.txtTuNgay.Text = sysdate.ToString("dd/MM/yyyy");
        this.txtDenNgay.Text = sysdate.ToString("dd/MM/yyyy");
        string sql = "select * from phongkhambenh pk  ";
        string IdBacSi=SysParameter.UserLogin.IdBacSi(this);
         
        if ( IdBacSi!= null && IdBacSi!="" &&IdBacSi!="0")
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where  pk.loaiphong <> 1 AND bspk.idbacsi=" + SysParameter.UserLogin.IdBacSi(this) + "";
        }
        else
        {
            sql += "where pk.loaiphong <> 1 ";
        }
        sql += @" and pk.idphongkhambenh="+Request.QueryString["idkhoa"].ToString()+@" order by pk.tenphongkhambenh";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPK, dt, "idphongkhambenh", "tenphongkhambenh", "Chọn phòng/khoa");
        if (ddlPK.Items.Count > 1)
            ddlPK.SelectedIndex = 1;

        
        DataTable dt2 = DataAcess.Connect.GetTable("SELECT * FROM KB_LOAIBN");
        StaticData.FillCombo(this.cbLoaiBN, dt2, "Id", "TenLoai", "Loại BN");
        cbLoaiBN.SelectedIndex = 0;

        noidungkcb(ddlPK.SelectedValue);
        BindListBenhNhan();
    }

     
    #region "U Function"

    private void BindListBenhNhan( )
    {
        string ngaybt = this.txtTuNgay.Text;
        string ngaykt = this.txtDenNgay.Text;
        if (ngaybt != "")
        {
            ngaybt = ngaybt.Substring(6, 4) + "/" + ngaybt.Substring(3, 2) + "/" + ngaybt.Substring(0, 2) + " 00:00:00";
        }
        if (ngaykt != "")
        {
            ngaykt = ngaykt.Substring(6, 4) + "/" + ngaykt.Substring(3, 2) + "/" + ngaykt.Substring(0, 2) + " 23:59:59";
        }


        string strSQL = ""
                        + " SELECT ROW_NUMBER() OVER (ORDER BY NGAYKHAM,TENBENHNHAN) AS STT, NGAYDANGKY, NGAYKHAM" + "\r\n"
                          + ",A.IDKHAMBENH ,B.IdBenhNhan" + "\r\n"
                        + " ,MABENHNHAN" + "\r\n"
                        + " ,TENBENHNHAN" + "\r\n"
                        + " ,NAMSINH=DBO.GetNamSinh(B.NGAYSINH)" + "\r\n"
                        + " ,GIOITINH=DBO.GETGIOITINH(B.GIOITINH)" + "\r\n"
                        + " ,SoBHYT" + "\r\n"
                        + " ,KHOA=TENPHONGKHAMBENH" + "\r\n"
                        + " ,TENBACSI" + "\r\n"
                        + " ,CHANDOANSOBO" + "\r\n"
                        + " ,CHANDOANXACDINH=E.MOTA" + "\r\n"
                        + " ,HuongGiaiQuyet=TenHuongDieuTri" + "\r\n"
                        + " ,IsBNMoi=DBO.KB_IsBenhNhanMoi(T2.IdDangKyKham)" + "\r\n"
                        + " ,LoaiBN=G.TenLoai" + "\r\n"
                        + " ,IsHaveCLS=CONVERT (BIT, ISNULL((SELECT TOP 1  1 FROM KHAMBENHCANLAMSAN  A1 WHERE A1.IDKHAMBENH=A.IDKHAMBENH),0))" + "\r\n"
                        + " ,DaCLS=CONVERT(BIT, ISNULL((SELECT TOP 1  1 FROM KHAMBENHCANLAMSAN A1 WHERE A1.IDKHAMBENH=A.IDKHAMBENH AND A1.NGAYKHAM IS NOT NULL ),0))" + "\r\n"
                        + " FROM CHITIETDANGKYKHAM AS  T1" + "\r\n"
                        + " LEFT JOIN DANGKYKHAM T2 ON T1.IDDANGKYKHAM=T2.IDDANGKYKHAM" + "\r\n"
                        + " LEFT JOIN BENHNHAN B ON T2.IDBENHNHAN=B.IDBENHNHAN" + "\r\n"
                        + " LEFT JOIN PHONGKHAMBENH C ON DBO.KB_getIdPhongKhamBenh(T1.IDCHITIETDANGKYKHAM)=C.IDPHONGKHAMBENH" + "\r\n"
                        + " LEFT JOIN KHAMBENH A ON T2.IDDANGKYKHAM=A.IDDANGKYKHAM AND A.IDPHONGKHAMBENH=DBO.KB_getIdPhongKhamBenh(T1.IDCHITIETDANGKYKHAM)" + "\r\n"
                        + " LEFT JOIN BACSI D ON A.IDBACSI=D.IDBACSI" + "\r\n"
                        + " LEFT JOIN CHANDOANICD E ON A.KETLUAN=E.IDICD" + "\r\n"
                        + " LEFT JOIN KB_HUONGDIEUTRI F ON A.huongdieutri=F.HuongdieuTriId" + "\r\n"
                        + " LEFT JOIN KB_LOAIBN G ON isnull(B.LOAI,3)=G.ID" + "\r\n"
                        + " WHERE A.IDKHAMBENH IS NOT NULL AND ISNULL(A.IDKHAMBENHGOC,0)=0 AND  B.IDBENHNHAN IS NOT NULL and T2.idbenhnhan is not null  and ( T2.DaHuy=0 or T2.DaHuy is null)" + "\r\n"
                        ;
        if (this.ddlPK.SelectedValue.ToString() != "0")
            strSQL += " AND C.IDPHONGKHAMBENH=" + this.ddlPK.SelectedValue.ToString();
        if (this.cbLoaiBN.SelectedValue.ToString() != "0")
            strSQL += " AND B.LOAI=" + this.cbLoaiBN.SelectedValue.ToString();
        if (this.ddndk.SelectedValue.ToString() != "0")
            strSQL += " AND T1.IDBANGGIADICHVU=" + this.ddndk.SelectedValue.ToString();
        if (this.ddlPhong.SelectedValue.ToString() != "0")
            strSQL += " AND T1.PhongID=" + this.ddlPhong.SelectedValue.ToString();
        if (ngaybt != "")
            strSQL += " AND A.NGAYKHAM>='" + ngaybt + "'";
        if (ngaykt != "")
            strSQL += " AND A.NGAYKHAM<='" + ngaykt + "'";
        if (mabN.Text != "")
            strSQL += " AND MABENHNHAN like '%" + mabN.Text + "%'";
        if (tenbN.Text != "")
            strSQL += " AND TENBENHNHAN like N'%" + tenbN.Text + "%'";
       
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        DataView dvtemp = new DataView(dtCTPhieu.Copy());
        dvtemp.RowFilter="LoaiBN like '%bảo hiểm%'";
        this.txtSLKBH.Text = dvtemp.Count.ToString();
        dvtemp.RowFilter = "LoaiBN like '%thường%'";
        this.txtSLKT.Text = dvtemp.Count.ToString();
        dvtemp.RowFilter = "LoaiBN like '%dịch vụ%'";
        this.txtSLKDV.Text = dvtemp.Count.ToString();
        this.txtSLBN.Text = dtCTPhieu.Rows.Count.ToString();
        dgr.Columns[7].Visible= StaticData.HaveBHYT;
        dgr.Columns[8].Visible = dgr.Columns[7].Visible;
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
        
    }
  
    private void SetValueEmpty()
    {
        this.txtTuNgay.Text = "";
        this.txtDenNgay.Text = "";
        this.cbLoaiBN.SelectedValue = "0";
        this.ddlPK.SelectedValue = "0";
    }
    private void BindCTPhieu(DataTable dtSRC)
    {
        if (dtSRC == null) return;
        dgr.DataSource = dtSRC;
        dgr.DataBind();
    }
    #endregion

    private void OpenLink(string LinkName)
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + LinkName +
                       "\")</script>");
    }
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetail")
        {
            int idlankham;
            idlankham = Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
            string idbn = e.Item.Cells[4].Text;
            Response.Redirect("../khambenh/frm_Edit_DSBNdakham.aspx?IdKhamBenh=" + idlankham + "&dkmenu=" + this.dkmenu + "&IdKhoa=" + Request.QueryString["idkhoa"]);
            //Response.Redirect("../CapCuu/KhamTiepNhanCapCuu.aspx?dkmenu=" + this.dkmenu + "#idkhoachinh=" + idlankham + "");
            //Response.Redirect("../noitru/ChonCLSBenhVien.aspx?load=1&dkmenu=" + this.dkmenu + "&IdKhoa=" + Request.QueryString["idkhoa"].ToString() + "#idkhoachinh=" + idlankham + "&IsTheoDoiCC=0");
        }
    }
    protected void btnGetList_Click(object sender, EventArgs e)
    {
        BindListBenhNhan( );
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        SetValueEmpty();
    }

    protected void ddlPK_SelectedIndexChanged(object sender, EventArgs e)
    {
        noidungkcb(ddlPK.SelectedValue);
    }
    protected void ddndk_SelectedIndexChanged(object sender, EventArgs e)
    {
        phongkham(ddndk.SelectedValue);
    }
}

