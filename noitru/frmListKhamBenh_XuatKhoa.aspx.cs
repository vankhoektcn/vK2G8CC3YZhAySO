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
public partial class frmListKhamBenh_XuatKhoa : Genaratepage
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
            dkmenu = "" + "";
            if (Request.QueryString["dkmenu"] != null && dkmenu == "")
                dkmenu = Request.QueryString["dkmenu"].ToString();
            if (Request.QueryString["idkhoa"].ToString() == "25")
            {
                spHeader.InnerHtml = "DANH SÁCH BỆNH NHÂN TÁN SỎI ĐÃ XUẤT";
                lbKhoa.InnerText = "Phòng :";
            }
        }
        LoadMenu();
    }
    private void LoadMenu()
    {
        string dkmenu = Request.QueryString["dkmenu"];
        PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
    }
    public void noidungkcb(string khoa)
    {
        string KhoaInSelect = khoa != "" ? "and IDPHONGKHAMBENH= " + khoa : "";
        string sql = @"SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE 1=1 " + KhoaInSelect + @"
        and IDBANGGIADICHVU not in (select dichvuKCB from kb_phong p where p.dichvuKCB=IDBANGGIADICHVU and isphongnoitru=1)
";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddndk, dt, "idbanggiadichvu", "tendichvu", "-- Chọn nội dung khám --");
        if (dt.Rows.Count > 0) ddndk.SelectedIndex = 1;
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
        string IdBacSi = SysParameter.UserLogin.IdBacSi(this);

        //if (IdBacSi != null && IdBacSi != "" && IdBacSi != "0")
        //{
        //    sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where  pk.loaiphong <> 1 AND bspk.idbacsi=" + SysParameter.UserLogin.IdBacSi(this) + "";
        //}
        //else
        //{
            sql += "where pk.loaiphong <> 1 ";
        //}
        sql += @" and pk.idphongkhambenh=" + Request.QueryString["idkhoa"].ToString() + @" order by pk.tenphongkhambenh";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPK, dt, "idphongkhambenh", "tenphongkhambenh");
        if (ddlPK.Items.Count > 1)
            ddlPK.SelectedIndex = 1;


        DataTable dt2 = DataAcess.Connect.GetTable("SELECT * FROM KB_LOAIBN");
        StaticData.FillCombo(this.cbLoaiBN, dt2, "Id", "TenLoai", "Loại BN");
        cbLoaiBN.SelectedIndex = 0;

        noidungkcb(ddlPK.SelectedValue);
        load_HuongDieuTri();
        BindListBenhNhan();
    }


    #region "U Function"
    private void load_HuongDieuTri()
    {
        string sqlHDT = @"select *,case when huongdieutriid=1 then N'Chuyển phòng KTP'";
        //if (Request.QueryString["idkhoa"].ToString() != "15")
        sqlHDT += "when huongdieutriid=8 then N'Chuyển khoa'";
        sqlHDT += "else TenHuongDieuTri end as HuongDT FROM kb_huongdieutri where 1=1 ";
        if (Request.QueryString["idkhoa"].ToString() != (StaticData.GetParameter("nvk_idkhoacapcuu")))
            sqlHDT += "and huongdieutriid in(" + StaticData.GetParaValueDB("HUONGDIEUTRIXUATKHOA") + ")";
        else
            sqlHDT += "and huongdieutriid in(" + StaticData.GetParaValueDB("HUONGDIEUTRIXUATKHOA_CC") + ")";
        DataTable dtHdt = DataAcess.Connect.GetTable(sqlHDT);
        StaticData.FillCombo(ddlHuongDT, dtHdt, "huongdieutriid", "HuongDT", "----Chọn hướng điều trị----");
    }
    private void BindListBenhNhan()
    {
        //return;
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


        string strSQL = @"SELECT  ROW_NUMBER() OVER (ORDER BY NGAYKHAM,TENBENHNHAN) AS STT,sovaovien=DBO.zHS_GetSoVaoVienFromKB(A.IDKHAMBENH), NGAYKHAM=xk.ngayxuatkhoa 
            ,idchitietdangkykham=a.idchitietdangkykham,A.IDKHAMBENH ,B.IdBenhNhan,nvk_idkhoa=a.idphongkhambenh,
            case when isnull((select top 1 tinhtrangBA from KB_KhoaTraBenhAn where idchitietdangkykham=a.idchitietdangkykham and idkhambenhcuoi=a.idkhambenh and idkhoatra=" + ddlPK.SelectedValue + @"),0)=1 then N'Chờ duyệt' 
 when isnull((select top 1 tinhtrangBA from KB_KhoaTraBenhAn where idchitietdangkykham=a.idchitietdangkykham and idkhambenhcuoi=a.idkhambenh and idkhoatra=" + ddlPK.SelectedValue + @"),0)=2 then N'Trả BA' 
 when isnull((select top 1 tinhtrangBA from KB_KhoaTraBenhAn where idchitietdangkykham=a.idchitietdangkykham and idkhambenhcuoi=a.idkhambenh and idkhoatra=" + ddlPK.SelectedValue + @"),0)=3 then N'Đã trả BA'  
            when isnull(
            (select top 1 ct.idchitietdangkykham from chitietdangkykham ct where ct.idchitietdangkykham=a.idchitietdangkykham 
              and ( 
		            ct.idchitietdangkykham in
		            (select top 1 idchitietdangkykham from khambenh where idchitietdangkykham=ct.idchitietdangkykham and huongdieutri in('12','13')
		             union all
		             select top 1 idchitietdangkykham from benhnhannoitru where idchitietdangkykham=ct.idchitietdangkykham 
		            )
	                or ct.idbanggiadichvu in(select idbanggiadichvu from banggiadichvu where idbanggiadichvu=ct.idbanggiadichvu and madichvu in('3030'))
	              )
            )
            ,0)=0 then N'' else
             N'Trả BA' end as TraBenhAn
                              ,idkhambenhXK=isnull((select top 1 idkhambenh from khambenh where maphieukham =N'PKXK' and idchitietdangkykham=a.idchitietdangkykham and idphongkhambenh=" + ddlPK.SelectedValue + @" order by idkhambenh desc),0) ,MABENHNHAN
             ,TENBENHNHAN
             ,NAMSINH=DBO.GetNamSinh(B.NGAYSINH)
             ,GIOITINH=DBO.GETGIOITINH(B.GIOITINH)
             ,bh.SoBHYT
             ,KHOAChuyen=p1.TENPHONGKHAMBENH
            ,case when a.huongdieutri=8 or a.huongdieutri=1  then isnull(p2.TENPHONGKHAMBENH,h.tenhuongdieutri) 
              when a.huongdieutri=4 then isnull((select top 1 tenbenhvien from benhnhanxuatkhoa xk left join benhvien bv on xk.idBVchuyenden=bv.idbenhvien where idchitietdangkykham=a.idchitietdangkykham order by idxuatkhoa desc),'')
              else h.tenhuongdieutri end as KHOADen
            ,InRaVien= case a.huongdieutri when 17 then N'Giấy RV' when 4 then N'Giấy CV' else N'' end
            ,case when  a.huongdieutri=4 then isnull((select top 1 tenbenhvien from benhnhanxuatkhoa xk left join benhvien bv on xk.idBVchuyenden=bv.idbenhvien where idchitietdangkykham=a.idchitietdangkykham order by idxuatkhoa desc),0)
                end as ghichuHDT
            ,InToaRaVien=N''--case when exists (select idkhambenh from chitietbenhnhantoathuoc where idkhambenh =a.idkhambenh) then N'Toa RV' else N'' end
             ,LoaiBN=G.TenLoai
             ,IsNoiTru=(CASE WHEN DBO.zHS_GetIsNoiTruFromKB(A.IDKHAMBENH)=1 THEN N'Nội trú' else N'Ngoại trú' end)
             --,IsHaveCLS=CONVERT (BIT, ISNULL((SELECT TOP 1  1 FROM KHAMBENHCANLAMSAN  A1 left join khambenh kk on kk.idkhambenh=a1.idkhambenh WHERE kk.idchitietdangkykham=A.idchitietdangkykham),0))
			,LoaiTaiNanId=isnull(dkk.LoaiTaiNanId,0)
             FROM benhnhanxuatkhoa xk 
            inner join khambenh a on a.idkhambenh= xk.idkhambenhxk
            left join dangkykham dkk on a.iddangkykham=dkk.iddangkykham
			left join benhnhan b on b.idbenhnhan=a.idbenhnhan
            left join kb_loaibn g on g.id=DKK.LOAIKHAMID
            left join phongkhambenh p1 on p1.idphongkhambenh=a.idphongkhambenh
            left join phongkhambenh p2 on p2.idphongkhambenh=a.phongkhamchuyenden
            left join kb_huongdieutri h on h.huongdieutriid=a.huongdieutri
            
            left join benhnhan_bhyt bh on dkk.idbenhnhan_bh=bh.idbenhnhan_bh
    where  1=1 ";
        string where = " and xk.idkhoaxuat = " + ddlPK.SelectedValue ;
        if (!soVaoVien.Text.Trim().Equals(""))
            where += @" and isnull(DBO.zHS_GetSoVaoVienFromKB(A.IDKHAMBENH),'') like N'%" + soVaoVien.Text.Trim() + "%'";
        if (this.cbLoaiBN.SelectedValue.ToString() != "0")
            where += " AND B.LOAI=" + this.cbLoaiBN.SelectedValue.ToString();
        if (this.ddlHuongDT.SelectedValue.ToString() != "0")
            where += " AND xk.IdHuongDieuTri=" + this.ddlHuongDT.SelectedValue.ToString();
        if (ngaybt != "" && ngaykt != "")
        {
            where += @" AND (xk.ngayxuatkhoa>='" + ngaybt + @"'  AND xk.ngayxuatkhoa<='" + ngaykt + @"'  )";
        }
        if (mabN.Text != "")
            where += " AND MABENHNHAN = '" + mabN.Text + "'";
        if (tenbN.Text != "")
            where += " AND TENBENHNHAN like N'%" + tenbN.Text + "%'";
        strSQL += where;
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        if (dtCTPhieu == null )
        {
            StaticData.MsgBox(this, "Không tìm thấy thông tin xuất khoa !"); return;
        }
        for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
        {
            string sql_intoa = "select InToaRaVien=case when exists (select idkhambenh from chitietbenhnhantoathuoc where idkhambenh ='"+dtCTPhieu.Rows[i]["IDKHAMBENH"]+"') then N'Toa RV' else N'' end";
            DataTable dt_inToa = DataAcess.Connect.GetTable(sql_intoa);
            if (dt_inToa != null && dt_inToa.Rows.Count > 0)
                dtCTPhieu.Rows[i]["InToaRaVien"] = dt_inToa.Rows[0][0];
        }
        string sqlFilter = @"
            select distinct dkk.iddangkykham,LoaiTaiNanId=isnull(dkk.LoaiTaiNanId,0),LoaiBN=G.TenLoai
            from benhnhanxuatkhoa xk 
	            inner join chitietdangkykham ctdk on ctdk.idchitietdangkykham =xk.idchitietdangkykham
	            inner join dangkykham dkk on dkk.iddangkykham= ctdk.iddangkykham
				inner join benhnhan bn on bn.idbenhnhan =dkk.idbenhnhan
                left join kb_loaibn g on g.id=DKK.LOAIKHAMID
            where 1=1 " + where;
        DataTable dtFilter = DataAcess.Connect.GetTable(sqlFilter);
        DataView dvtemp = new DataView(dtFilter.Copy());
        dvtemp.RowFilter = "LoaiBN like '%bảo hiểm%'";
        this.txtSLKBH.Text = dvtemp.Count.ToString();
        dvtemp.RowFilter = "LoaiBN like '%thường%'";
        this.txtSLKT.Text = dvtemp.Count.ToString();
        dvtemp.RowFilter = "LoaiBN like '%dịch vụ%'";
        this.txtSLKDV.Text = dvtemp.Count.ToString();
        this.txtSLBN.Text = dtFilter.Rows.Count.ToString();
        //dgr.Columns[7].Visible= StaticData.HaveBHYT;
        //dgr.Columns[8].Visible = dgr.Columns[7].Visible;
        dvtemp.RowFilter = "LoaiTaiNanId=1";
        this.txtTNGT.Text = dvtemp.Count.ToString();
        dvtemp.RowFilter = "LoaiTaiNanId=2";
        this.txtTNSH.Text = dvtemp.Count.ToString();
        dvtemp.RowFilter = "LoaiTaiNanId=3";
        this.txtBdBc.Text = dvtemp.Count.ToString();
        dvtemp.RowFilter = "LoaiTaiNanId=4";
        this.txtTNKhac.Text = dvtemp.Count.ToString();
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
        ////if (dtCTPhieu.Rows.Count == 0)
        ////    StaticData.MsgBox(this,"Không tìm thấy bệnh nhân nào !");

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
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }
            btn = (LinkButton)(e.Item.Cells[1].FindControl("lbtnTraBA"));
            if (btn.Text != "Trả BA")
                btn.Enabled = false;
        }
    }
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "TheoDoi")
        {
            #region tạm theo dõi bệnh nhân nội trú
            string idKhamBenhXuatKhoa = e.CommandArgument.ToString();
            string sqlInfo = "select idchitietdangkykham, idbenhnhan, idphongkhambenh from khambenh where maphieukham ='pkxk' and idkhambenh ="+idKhamBenhXuatKhoa+"";
            DataTable dtInfo = DataAcess.Connect.GetTable(sqlInfo);
            if (dtInfo != null && dtInfo.Rows.Count > 0)
            {
                string up = "update benhnhannoitru set isTamTheoDoi=1 where idchitietdangkykham ='" + dtInfo.Rows[0]["idchitietdangkykham"] + "' and idkhoanoitru ='" + dtInfo.Rows[0]["idphongkhambenh"] + "' ";
                bool kt = DataAcess.Connect.ExecSQL(up);
                if (kt)
                {
                    StaticData.MsgBox(this, "Đã thêm bệnh nhân vào danh sách theo dõi !");
                    return;
                }
            }
            StaticData.MsgBox(this, "Lỗi !");
            #endregion
        }
        else if (e.CommandName == "Edit")
        {
            int idlankham;
            idlankham = Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
            string idbn = e.Item.Cells[4].Text;
            string idchitietdangkykham = e.CommandArgument.ToString();
            hdIdChiTietDangKyKham.Value = idchitietdangkykham;
            hdidkhamBenh1311.Value = idlankham.ToString();
            string sqlDS = @"select kb.*,bn.mabenhnhan,bn.tenbenhnhan,bn.diachi
            ,Lan=N'Lần khám '+str(ROW_NUMBER() OVER (ORDER BY idkhambenh))
+'('+ (select isnull((select top 1 case when isnull(idchitietbenhnhantoathuoc,0)<>0 then N'Thuốc,' else '' end as Loai from chitietbenhnhantoathuoc where idkhambenh=kb.idkhambenh ),''))
+' '+ (select isnull((select top 1 case when isnull(idkhambenhcanlamsan,0)<>0 then N'CLS' else '' end as Loai from khambenhcanlamsan where idkhambenh=kb.idkhambenh ),''))
+')'
,isdaravien1=isnull((select top 1 convert(int,isdaravien) from khambenh where idkhambenh=" + idlankham.ToString() + @" ),0)
            from khambenh kb left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan where idchitietdangkykham=" + idchitietdangkykham + " --and idphongkhambenh=" + ddlPK.SelectedValue + @"
                and kb.idkhambenh<=" + idlankham.ToString();
            DataTable dtkb = DataAcess.Connect.GetTable(sqlDS);
            if (dtkb.Rows.Count > 0)
            {
                dgrChiTietChild.DataSource = dtkb;
                dgrChiTietChild.DataBind();
                dgrChiTietChild.Visible = true;
                #region Xét quyền
                //StaticData.MsgBox(this, idlankham.ToString() + " ; " + dtkb.Rows[0]["isdaravien"].ToString().Trim()); return;
                if (dtkb.Rows[0]["isdaravien1"].ToString().Trim() == "1")
                {
                    bool isAdmin = false;
                    DataTable dtAdmin = DataAcess.Connect.GetTable("select * from UserProfile where permid=8 and userid=" + SysParameter.UserLogin.UserID(this));
                    if (dtAdmin.Rows.Count > 0 || SysParameter.UserLogin.GroupID(this) == "4")
                        isAdmin = true;
                    if (!isAdmin)
                    {
                        dgrChiTietChild.Columns[0].Visible = false;
                    }
                }
                #endregion

                lbMaBN.Text = dtkb.Rows[0]["mabenhnhan"].ToString();
                lbTenBenhNhan.Text = dtkb.Rows[0]["tenbenhnhan"].ToString();
                lbDiaChi.Text = dtkb.Rows[0]["diachi"].ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Open", "divNoiDungKham.style.display = 'block';", true);
            }
            //}
        }
        else if (e.CommandName == "TraBenhAn")
        {
            int idkhambenhgoc;
            idkhambenhgoc = Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
            string idKhamBenhXuatKhoa = e.CommandArgument.ToString();
            string sql = @"select * from khambenh where idkhambenh=" + idKhamBenhXuatKhoa + "";
            try
            {
                DataTable dtTraBA = DataAcess.Connect.GetTable("select * from kb_KhoaTraBenhAn where idKhamBenhCuoi=" + idKhamBenhXuatKhoa);
                if (dtTraBA.Rows.Count > 0)
                    sql = @" update KB_KhoaTraBenhAn set tinhtrangBA=1 where idTraBenhAn=" + dtTraBA.Rows[0]["idTraBenhAn"].ToString();
                else
                {
                    DataTable dtKB = DataAcess.Connect.GetTable(sql);
                    sql = @"insert into KB_KhoaTraBenhAn (idBenhNhan,idKhamBenhCuoi,idChiTietDangKyKham,SoVaoVien,NgayTra,IdKhoaTra,idNguoiTra,tinhtrangBA)
            values ('" + dtKB.Rows[0]["idbenhnhan"].ToString() + "','" + idKhamBenhXuatKhoa + "','" + dtKB.Rows[0]["idChiTietDangKyKham"].ToString() + @"'
                ,'" + dtKB.Rows[0]["SoVaoVien"].ToString() + "',getdate(),'" + Request.QueryString["idkhoa"].ToString() + "','" + SysParameter.UserLogin.UserID(this) + "',1)";
                }
                bool kt = DataAcess.Connect.ExecSQL(sql);
                if (kt)
                {
                    BindListBenhNhan();
                    StaticData.MsgBox(this, "Đã trả bệnh án cho phòng tổng hợp !");
                    return;
                }
            }
            catch (Exception)
            {
                StaticData.MsgBox(this, "Lỗi khi trả bệnh án !");
            }
        }
        else if (e.CommandName == "InRaVien")
        {
            LinkButton lbtnInGiayHDT = ((LinkButton)e.Item.Cells[1].FindControl("lbtnInGiayHDT"));
            string idKhamBenhXuatKhoa = e.CommandArgument.ToString();
            string idkhoaIn = Request.QueryString["idkhoa"].ToString();
            if (lbtnInGiayHDT.Text.Equals("Giấy RV"))
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "nvk_GRV", "InPhieuRaVien(" + idKhamBenhXuatKhoa + "," + idkhoaIn + ");", true);
            else if (lbtnInGiayHDT.Text.Equals("Giấy CV"))
            {
                string nvk_idctdkk = DataAcess.Connect.GetTable(@"select idchitietdangkykham=isnull((select idchitietdangkykham from khambenh where idkhambenh ='" + idKhamBenhXuatKhoa + "'),0)").Rows[0]["idchitietdangkykham"].ToString();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "nvk_GCV", "nvk_InGiayChuyenVien(" + nvk_idctdkk + "," + idkhoaIn + ");", true);
            }
        }
        else if (e.CommandName == "InToaRaVien")
        {
            string idKhamBenhXuatKhoa = e.CommandArgument.ToString();
            string idkhoaIn = Request.QueryString["idkhoa"].ToString();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "nvk_TRV", "nvk_InToaRaVien(" + idKhamBenhXuatKhoa + "," + idkhoaIn + ");", true);
        }
    }
    protected void btnGetList_Click(object sender, EventArgs e)
    {
        BindListBenhNhan();
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
    protected void dgr_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindListBenhNhan();
    }
    protected void PageIndexStyleChanged(object source, DataGridPageChangedEventArgs e)
    {

    }
    protected void dgrChiTietChild_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "EditKhamBenh")
        {
            string idkhambenh = e.CommandArgument.ToString();
            string sqlkb = @"select bn.mabenhnhan,kb.idbenhnhan,isnull(kb.idkhambenhgoc,0) as isKhamBenhGoc,iscothuoc=isnull((select top 1 idkhambenh from chitietbenhnhantoathuoc where idkhambenh=kb.idkhambenh),0)
            from khambenh kb left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan where idkhambenh=" + idkhambenh;
            DataTable dtKB = DataAcess.Connect.GetTable(sqlkb);
            if (dtKB != null && dtKB.Rows.Count > 0)
            {
                string link = "../khambenh/frm_Edit_DSBNdakham.aspx?IdKhamBenh=" + idkhambenh + "&dkmenu=nomenu&IdKhoa=" + Request.QueryString["idkhoa"];
                
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Sua", "OpenLinkChiDinh('" + link + "');", true);
            }
            return;
        }
    }
    protected void btnHuyXuatKhoa_click(object sender, EventArgs e)
    {
        if (HuyLenhXuatKhoa(hdIdChiTietDangKyKham.Value, Request.QueryString["idkhoa"]))
        {
            BindListBenhNhan();
            StaticData.MsgBox(this, "Đã hủy lệnh xuất khoa !");
        }
        else
        {
            StaticData.MsgBox(this, "Lỗi !");
        }
    }
    private bool HuyLenhXuatKhoa(string idchitietdangkykham, string idkhoa)
    {
        bool kt = false;
        string sqlUpDate = " UPDATE BENHNHANNOITRU SET ISDANHAP=1 where idchitietdangkykham =" + idchitietdangkykham + " and idkhoanoitru =" + idkhoa + "";
        kt = DataAcess.Connect.ExecSQL(sqlUpDate);
        if (kt)
        {
            string UpdateIn = "";
            if (idkhoa.Equals((StaticData.GetParameter("nvk_idkhoacapcuu"))))
                UpdateIn = "set huongdieutri=14,isdachuyenkhoa=2";
            else
                UpdateIn = "set huongdieutri=8,phongkhamchuyenden=" + idkhoa + ",isdachuyenkhoa=2";
            string sqlKbXuat = @"update khambenh " + UpdateIn + " where isdachuyenkhoa=0 and maphieukham=N'PKXK' and idchitietdangkykham=" + idchitietdangkykham + " and  huongdieutri in (1,3,4,7,8,11,16,17) and idphongkhambenh=" + idkhoa + "";
            kt = DataAcess.Connect.ExecSQL(sqlKbXuat);
            if (kt)
            {
                string idxuatkhoa = "0"; string idKBxuatkhoa = "0";
                DataTable dtXK = DataAcess.Connect.GetTable("select top 1 * from benhnhanxuatkhoa where idchitietdangkykham='" + idchitietdangkykham + "' order by idxuatkhoa desc");
                if (dtXK.Rows.Count > 0)
                {
                    idKBxuatkhoa = dtXK.Rows[0]["IdKhamBenhXK"].ToString();
                    string sqlDvCV = @"delete from khambenhcanlamsan where idkhambenh='" + idKBxuatkhoa + @"' and idcanlamsan in(
                                 select idbanggiadichvu from benhvien where idbenhvien='" + dtXK.Rows[0]["IdBVChuyenDen"] + @"'
                                union select idbanggiadichvuDDBS from benhvien where idbenhvien='" + dtXK.Rows[0]["IdBVChuyenDen"] + @"'
                                union select idbanggiadichvuDD from benhvien where idbenhvien='" + dtXK.Rows[0]["IdBVChuyenDen"] + @"'
                                )";
                    kt = DataAcess.Connect.ExecSQL(sqlDvCV);
                    if (kt)
                    {
                        kt = DataAcess.Connect.ExecSQL("delete from benhnhanxuatkhoa where idxuatkhoa='" + dtXK.Rows[0]["idxuatkhoa"] + "'");
                    }
                }
            }
        }
        return kt;
    }
}

