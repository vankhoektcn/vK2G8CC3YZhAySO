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
public partial class frmListKhamBenh_KhoaSan : Genaratepage
{
    string dkmenu = "tiepnhan";
    string madichvu;
    string idkhoa;
    protected void Page_Load(object sender, EventArgs e)
    {
        madichvu = Request.QueryString["madichvu"].ToString();
        idkhoa = Request.QueryString["idkhoa"].ToString();
        this.lbLoaiBN.Visible = this.cbLoaiBN.Visible = StaticData.HaveBHYT;
       
        if (!IsPostBack)
        {
            SetValueEmpty();
            this.LoadDataNoiTru();
            StaticData.SetFocus(this,"mabN");
        }
        if (Request.QueryString["dkmenu"]!=null) 
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
        string sql = @"SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE 1=1 " + KhoaInSelect + @"
         and IDBANGGIADICHVU in (select dichvuKCB from kb_phong P where P.dichvuKCB=IDBANGGIADICHVU AND isnull(isphongnoitru,0)=0 )";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddndk, dt, "idbanggiadichvu", "tendichvu","--Chọn nội dung khám--");
        //if (dt.Rows.Count > 0) ddndk.SelectedIndex = 1;
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
        sql += " and pk.idphongkhambenh="+idkhoa+@" order by pk.tenphongkhambenh";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPK, dt, "idphongkhambenh", "tenphongkhambenh");
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


        string strSQL = @"SELECT ROW_NUMBER() OVER (ORDER BY NGAYKHAM,TENBENHNHAN) AS STT, NGAYDANGKY, NGAYKHAM
                          ,kb.IDKHAMBENH ,kB.IdBenhNhan
                         ,bn.MABENHNHAN
                         ,bn.TENBENHNHAN
                         ,NAMSINH=DBO.GetNamSinh(Bn.NGAYSINH)
                         ,GIOITINH=DBO.GETGIOITINH(Bn.GIOITINH)
                         ,SoBHYT
                         ,KHOA=TENPHONGKHAMBENH
                         ,TENBACSI
                         ,CHANDOANSOBO
                         ,CHANDOANXACDINH=E.MOTA
                         ,HuongGiaiQuyet=TenHuongDieuTri
                         ,IsBNMoi=DBO.KB_IsBenhNhanMoi(kb.IdDangKyKham)
                         ,LoaiBN=G.TenLoai
                         ,IsHaveCLS=CONVERT (BIT, ISNULL((SELECT TOP 1  1 FROM KHAMBENHCANLAMSAN  A1 WHERE A1.IDKHAMBENH=kb.IDKHAMBENH),0))
                         ,DaCLS=CONVERT(BIT, ISNULL((SELECT TOP 1  1 FROM KHAMBENHCANLAMSAN A1 WHERE A1.IDKHAMBENH=kb.IDKHAMBENH AND A1.NGAYKHAM IS NOT NULL ),0))
                         FROM khambenh kb left join benhnhan bn on bn.idbenhnhan =kb.idbenhnhan
							left join CHITIETDANGKYKHAM AS  T1 on t1.idchitietdangkykham=kb.idchitietdangkykham
							LEFT JOIN DANGKYKHAM dk ON dk.IDDANGKYKHAM=kb.IDDANGKYKHAM
							LEFT JOIN PHONGKHAMBENH C ON DBO.KB_getIdPhongKhamBenh(kb.IDCHITIETDANGKYKHAM)=C.IDPHONGKHAMBENH
							LEFT JOIN BACSI D ON kb.IDBACSI=D.IDBACSI
							LEFT JOIN CHANDOANICD E ON kb.KETLUAN=E.IDICD
							LEFT JOIN KB_HUONGDIEUTRI F ON kb.huongdieutri=F.HuongdieuTriId
							LEFT JOIN KB_LOAIBN G ON isnull(Bn.LOAI,3)=G.ID
                         WHERE 1=1 and kb.IDKHAMBENH IS NOT NULL AND ISNULL(kb.IDKHAMBENHGOC,0)=0
             AND  Bn.IDBENHNHAN IS NOT NULL and dk.idbenhnhan is not null 
";
        if (this.ddlPK.SelectedValue.ToString() != "0")
            strSQL += " AND C.IDPHONGKHAMBENH=" + this.ddlPK.SelectedValue.ToString();
        if (this.cbLoaiBN.SelectedValue.ToString() != "0")
            strSQL += " AND Bn.LOAI=" + this.cbLoaiBN.SelectedValue.ToString();
        if (this.ddndk.SelectedValue.ToString() != "0")
            strSQL += " AND T1.IDBANGGIADICHVU=" + this.ddndk.SelectedValue.ToString();
        if (this.ddlPhong.SelectedValue.ToString() != "0")
            strSQL += " AND T1.PhongID=" + this.ddlPhong.SelectedValue.ToString();
        if (ngaybt != "")
            strSQL += " AND kb.NGAYKHAM>='" + ngaybt + "'";
        if (ngaykt != "")
            strSQL += " AND kb.NGAYKHAM<='" + ngaykt + "'";
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
            //Response.Redirect("../khambenh/frm_Edit_DSBNdakham.aspx?IdKhamBenh=" + idlankham + "&dkmenu=" + this.dkmenu+"&IdKhoa="+Request.QueryString["idkhoa"] );
            string link="../khambenh/frm_Edit_DSBNdakham.aspx?IdKhamBenh=" + idlankham + "&dkmenu=nomenu&IdKhoa=" + Request.QueryString["idkhoa"];
            string script="window.open('"+link+"','_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "nvk_openKham", script, true);
            //Response.Redirect("../khambenh/frm_Edit_DSBNdakham.aspx?IdKhamBenh=" + idlankham + "&dkmenu=nomenu&IdKhoa=" + Request.QueryString["idkhoa"]);
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

