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
using System.Collections.Generic;
public partial class NVK_dsChoTaiKham : Genaratepage
{
    string strSearch;
    string dkmenu = null;
    private string login_IdBacsi = null;
    string IdKhoakhambenh;
    string maKhoakhambenh;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SetValueEmpty();
            this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");       
            StaticData.SetFocus(this, "txtMaBenhNhan");
            this.IdKhoakhambenh = Request.QueryString["idkhoa"].ToString();
            this.maKhoakhambenh = Request.QueryString["MaKhoa"].ToString();
            BindListBenhNhan("");
            loadPK();
            if (Request.QueryString["idkhoa"].ToString() == "25")
            {
                ddlKhoa.Visible = false; spChonKhoa.Visible = false;
                trKhoa.Visible = false;
                spKhoaNhap.InnerText = "Phòng nhập :";
            }
        }
         dkmenu = Request.QueryString["dkmenu"].ToString();
       if(dkmenu.Equals("tansoi"))
         LoadMenu();
     }
     private void LoadMenu()
     {
         string dkmenu = Request.QueryString["dkmenu"];
         PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
     }
    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }


    #region "U Function"

    private void loadPK()
    {
        string sql = ""
                     + " SELECT * FROM PHONGKHAMBENH " + "\r\n"
                     + " WHERE 1=1 "
                     + " AND LOAIPHONG=0" + "\r\n";
        if (this.login_IdBacsi != null && this.login_IdBacsi != "")
            sql += "AND IDPHONGKHAMBENH IN (SELECT IDPHONGKHAMBENH FROM BACSI_PHONGKHAM WHERE IDBACSI=" + login_IdBacsi + " )" + "\r\n";
        sql += " and idphongkhambenh="+this.IdKhoakhambenh+" ";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlKhoa, dt, "idphongkhambenh", "tenphongkhambenh");
        if(dt.Rows.Count>0)
        ddlKhoa.SelectedIndex = 1;
    }
    public void loadPhongKham()
    {
        string sql = "SELECT Id,TenPhong=ISNULL(MASO +'-','')+ TENPHONG  FROM kb_phong WHERE DichVuKCB=" + ddlNoidung.SelectedValue;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhong, dt, "id", "tenphong", "-- Chọn Phòng Khám --");
        if (dt.Rows.Count > 0) ddlPhong.SelectedIndex = 0;
    }
    public void noidungkcb()
    {
        string sql = "SELECT IDBANGGIADICHVU,TENDICHVU FROM BANGGIADICHVU WHERE IDPHONGKHAMBENH=" + ddlKhoa.SelectedValue + " and idbanggiadichvu<>1790";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlNoidung, dt, "idbanggiadichvu", "tendichvu", "-- Chọn nội dung khám --");
        if (dt.Rows.Count > 0) ddlNoidung.SelectedIndex = 0;
    }
    public void LoadPhongNhap()
    {
        string isphongnoitru="isphongnoitru=1";
        if (Request.QueryString["idkhoa"].ToString() == "15")
            isphongnoitru = "isphongnoitru=0";
        string sql = @"select p.*,MaTen=MaSo+'-'+TenPhong from kb_phong p left join banggiadichvu bg on bg.idbanggiadichvu=p.dichvukcb
left join phongkhambenh k on k.idphongkhambenh=bg.idphongkhambenh where " + isphongnoitru + " and k.idphongkhambenh=" + ddlKhoa.SelectedValue + " AND id<>61 ";
        if (hdLoaiBN.Value == "1")
            sql += " and p.LoaiBN=1";
        else
            sql += " and p.LoaiBN=0";
        sql += " order by TenPhong ";
        DataTable dtPhongNhap = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPhongNhapVien, dtPhongNhap, "id", "MaTen");
        if(dtPhongNhap.Rows.Count>0)
            LoadGiuongNhap(ddlPhongNhapVien.SelectedValue); 
    }
    public void LoadGiuongNhap(string idPhongNhap)
    {
        string sql = @"select giuongid,giuongcode from kb_giuong where idphong="+idPhongNhap;
        DataTable dtGuong = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlGiuongNhapVien, dtGuong, "giuongid", "giuongcode");
        if (ddlGiuongNhapVien.SelectedValue != "0" && ddlGiuongNhapVien.SelectedValue != "")
            LoadTienGiuong(ddlGiuongNhapVien.SelectedValue);
    }
    private void BindListBenhNhan(string sWhere)
    {
        string ngaybt = "";
        string ngaykt = "";
        ngaybt = StaticData.CheckDate(txtTuNgay.Text.Trim());
        ngaykt = StaticData.CheckDate(txtDenNgay.Text.Trim());
        if (ngaykt != "")
            ngaykt = ngaykt + " 23:59:59";
        DataTable dtCTPhieu = new DataTable();
        string strSQL = @"select 
            idkhambenh= isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=tk.idchitietdangkykham order by idkhambenh asc),0)
            ,idkhambenhnhap=isnull((select top 1 idkhambenh from khambenh where idchitietdangkykham=tk.idchitietdangkykham order by idkhambenh desc),0)
            ,case when isnull(tk.isdataikham,0)=0 then N'Nhập khoa' else N'Đã nhập' end as TinhTrang
            ,mabenhnhan	
            ,tenbenhnhan
            ,diachi
            ,dienthoai
            ,Gioi=dbo.getgioitinh(bn.gioitinh)
            ,namsinh=ngaysinh 
            ,ngaykham= ngayhentaikham
            from nvk_HenTaiKham tk left join benhnhan bn on bn.idbenhnhan= tk.idbenhnhan

            where 1=1 and IdKhoaSeTaiKham='" + Request.QueryString["idkhoa"]+"' "+sWhere+"";

            if (txtTuNgay.Text != "")
            {
                strSQL += " and NgayHenTaiKham >='" + StaticData.CheckDate(txtTuNgay.Text) + "'";
            }
            if (txtDenNgay.Text != "")
            {
                strSQL += " and NgayHenTaiKham <='" + StaticData.CheckDate(txtDenNgay.Text) + " 23:58:59:999'";
            }
        dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        if (dtCTPhieu != null)
        {
            dgr.DataSource = dtCTPhieu;
            dgr.DataBind();
        }
    }

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtDienThoai.Text = "";
        txtDiaChi.Text = "";
        ddlGioiTinh.SelectedIndex = 0;
        this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");  
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        strSearch = "";
        txtMaBenhNhan.ReadOnly = false;
        StaticData.SetFocus(this, "txtMaBenhNhan");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = GetChuoiSearch();
        BindListBenhNhan(strSearch);
    }
    private string GetChuoiSearch()
    {
        
        string skq = "";
        if (txtMaBenhNhan.Text != "")
        {
            skq += "  and bn.mabenhnhan LIKE '%" + txtMaBenhNhan.Text.Trim() + "%' ";
        }
        if (txtTenBenhNhan.Text != "")
        {
            skq += " AND bn.tenbenhnhan LIKE N'%" + txtTenBenhNhan.Text.Trim() + "%' ";
        }
        if (txtDienThoai.Text != "")
        {
            skq += " AND bn.dienthoai LIKE '%" + txtDienThoai.Text.Trim() + "%' ";
        }
        if (txtDiaChi.Text != "")
        {
            skq += " AND bn.diachi LIKE N'%" + txtDiaChi.Text.Trim() + "%' ";
        }
        if (ddlGioiTinh.SelectedValue != "-1")
        {
            skq += " AND bn.gioitinh = " + ddlGioiTinh.SelectedValue;
        }
        
        return skq;
    }
    #endregion
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
//        int idkhambenh;
//        string idbenhnhan = e.CommandArgument.ToString();
//        idkhambenh = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
//        string sql = @"select madichvu,bg.idphongkhambenh,kb.phongkhamchuyenden from khambenh kb left join banggiadichvu bg on bg.idbanggiadichvu=kb.iddvphongchuyenden
//                    where --madichvu is not null and
//        isnull(idkhambenhgoc,0)=0 and idkhambenh=" + idkhambenh + "";
//        DataTable dt = DataAcess.Connect.GetTable(sql);
//        if (dt.Rows.Count > 0 && dt.Rows[0]["idphongkhambenh"].ToString() == "2" || dt.Rows[0]["phongkhamchuyenden"].ToString()=="2")
//            Response.Redirect("../noitru/Benhanngoaikhoa.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
//        else if (dt.Rows.Count > 0 && dt.Rows[0]["idphongkhambenh"].ToString() == "4" || dt.Rows[0]["phongkhamchuyenden"].ToString() == "4")
//            Response.Redirect("../noitru/Benhannoikhoa.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
//        //else
//        //    Response.Redirect("../noitru/Benhannoikhoa.aspx?dkmenu=" + this.dkmenu + "#idkhambenhgoc=" + idkhambenh + "");
        
    }
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Edit")
        {
            string idkhambenhnhap=e.CommandArgument.ToString();
            DataTable dtBN = DataAcess.Connect.GetTable(@"select case when isnull(gioitinh,0)=0 then N'Nam' else N'Nữ' end as Gioi,*,NgayVaoVien = convert(varchar,ngaytiepnhan,103)+' '+convert(varchar,ngaytiepnhan,108)
from benhnhan where idbenhnhan =(select idbenhnhan from khambenh where idkhambenh="+idkhambenhnhap+")");
            if (dtBN != null && dtBN.Rows.Count > 0)
            {
                txtTenBNNhap.Text = dtBN.Rows[0]["tenbenhnhan"].ToString();
                txtMaBNNhap.Text = dtBN.Rows[0]["mabenhnhan"].ToString();
                txtGioiTinhNhap.Text = dtBN.Rows[0]["Gioi"].ToString();
                txtNgayVaoVien.Text = dtBN.Rows[0]["NgayVaoVien"].ToString();
                hdIdKhamBenh.Value = dgr.DataKeys[e.Item.ItemIndex].ToString();//
                hdIdKhamBenhNhap.Value = idkhambenhnhap;
                DataTable dtKB = DataAcess.Connect.GetTable(@"select cd.maicd,cd.mota,k.tenphongkhambenh,kb.* from khambenh kb left join phongkhambenh k
                on kb.idphongkhambenh=k.idphongkhambenh left join chandoanicd cd on cd.idicd=kb.ketluan where idkhambenh=" + hdIdKhamBenh.Value);
                hdIdBenhNhan.Value = e.CommandArgument.ToString();
                hdLoaiBN.Value = dtBN.Rows[0]["loai"].ToString();
                txtchandoanKhoaChuyen.Text = dtKB.Rows[0]["mota"].ToString();
                txtmachandoanKhoaChuyen.Text = dtKB.Rows[0]["maicd"].ToString();
                name4.Value = e.CommandName.ToString();
                hdTenBenhNhan.Value = e.Item.Cells[3].Text;
                txtKhoaChuyen.Text = dtKB.Rows[0]["tenphongkhambenh"].ToString();
                txtKhoaNhap.Text = ddlKhoa.SelectedItem.Text;
                txtNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtGioNhap.Text = DateTime.Now.ToString("HH:mm");
                //LoadDanhSachBacSiKhoa();
                //LoadDanhSachDieuDuongKhoa();
                if (!Request.QueryString["idkhoa"].Equals("22") && !Request.QueryString["idkhoa"].Equals("25"))
                {
                    LoadPhongNhap();
                }
                else
                    spoidungGiuong.Visible = false;
                #region load thông tin nhập khoa nếu đã nhập
                if (((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Text == "Đã nhập")
                {
                    LoadNoiDungNhapKhoa(dtKB.Rows[0]["idchitietdangkykham"].ToString());
                }
                else
                {
                    hdIdNoiTruSuaNhap.Value = "0";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'block';document.getElementById('txtmachandoan_3').focus();", true);
                }
                if (hdIdNoiTruSuaNhap.Value == "0")
                {
                    btlydo.Visible = true; btSuaNhapVien.Visible = false;
                }
                else
                {
                    btlydo.Visible = false; btSuaNhapVien.Visible = true;
                }
                #endregion
                StaticData.SetFocus(this, "txtmachandoan_3");
            }
            else
                StaticData.MsgBox(this,"Vui lòng thử lại sau !");
        }
    }
    private void LoadNoiDungNhapKhoa(string idchitietdangkykham)
    {
        string sqlNoiTru = @"select top 1 convert(int,isnull(ischontrongngay,0)) as isChon
,ngaynhaptruoc=convert(varchar(10),ngayvaovien,103)
,Gionhaptruoc=convert(varchar(5),ngayvaovien,108)
,* from benhnhannoitru where IdChiTietDangKyKham =" + idchitietdangkykham + " and idkhoanoitru=" + ddlKhoa.SelectedValue + " and isNhapKhoa=1 order by idnoitru asc";
        DataTable dtNoiTru = DataAcess.Connect.GetTable(sqlNoiTru);
        if (dtNoiTru != null && dtNoiTru.Rows.Count > 0)
        {
            #region load thông tin Ngày nhập
            txtNgayNhap.Text = dtNoiTru.Rows[0]["ngaynhaptruoc"].ToString();
            txtGioNhap.Text = dtNoiTru.Rows[0]["Gionhaptruoc"].ToString();
            #endregion
            if (!Request.QueryString["idkhoa"].Equals("22") && !Request.QueryString["idkhoa"].Equals("25"))
            {
                #region load thông tin phòng đã nhập
                try
                {
                    ddlPhongNhapVien.SelectedValue = dtNoiTru.Rows[0]["idphongnoitru"].ToString();
                }
                catch (Exception ex) { }
                LoadGiuongNhap(ddlPhongNhapVien.SelectedValue);
                if (ddlGiuongNhapVien.Items.Count > 0)
                    try
                    {
                        ddlGiuongNhapVien.SelectedValue = dtNoiTru.Rows[0]["idgiuong"].ToString();
                    }
                    catch (Exception ex) { }
                #endregion
                #region load thông tin tiền giường
                txtTienGiuong.Text = StaticData.FormatNumberOption(dtNoiTru.Rows[0]["giagiuong"], ",", ".", false).ToString();
                #endregion
                #region load thông tin bác sĩ,điều dưỡng
                string idBS = dtNoiTru.Rows[0]["idbacsinhap"].ToString() == "" || dtNoiTru.Rows[0]["idbacsinhap"].ToString() == "0" ? "0" : dtNoiTru.Rows[0]["idbacsinhap"].ToString();
                string idDD = dtNoiTru.Rows[0]["iddieuduongnhap"].ToString() == "" || dtNoiTru.Rows[0]["iddieuduongnhap"].ToString() == "0" ? "0" : dtNoiTru.Rows[0]["iddieuduongnhap"].ToString();
                string sqlBS = @"SELECT A.IDBACSI AS IDBACSI,A.TENBACSI AS TENBACSI FROM BACSI A WHERE IDBACSI=" + idBS + "";
                DataTable dtBS = DataAcess.Connect.GetTable(sqlBS);
                if (dtBS != null && dtBS.Rows.Count > 0)
                {
                    idbacsi.Value = dtBS.Rows[0]["IDBACSI"].ToString();
                    mkv_idbacsi.Value = dtBS.Rows[0]["TENBACSI"].ToString();
                }
                string sqlDD = @"select idnhanvien,tennhanvien,idphongban from nhanvien a
                left join chucvu b on a.idchucvu=b.idchucvu where  (machucvu like N'NHS%'or machucvu like N'DD%' or b.idchucvu=42)
                and idnhanvien=" + idDD + " ";
                DataTable dtDD = DataAcess.Connect.GetTable(sqlDD);
                if (dtDD != null && dtDD.Rows.Count > 0)
                {
                    iddieuduong.Value = dtDD.Rows[0]["idnhanvien"].ToString();
                    mkv_iddieuduong.Value = dtDD.Rows[0]["tennhanvien"].ToString();
                }
                #endregion
                #region load thông tin chọn tính giường
                if (dtNoiTru.Rows[0]["isChon"].ToString() == "1")
                    cbTinhTienTrongNgay.Checked = true;
                else
                    cbTinhTienTrongNgay.Checked = false;
                #endregion
            }
            //else
                //spoidungGiuong.Visible = false;
            hdIdNoiTruSuaNhap.Value = dtNoiTru.Rows[0]["idnoitru"].ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "2", "divlydo.style.display = '';", true);
        }
        else
        {
            hdIdNoiTruSuaNhap.Value = "0";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "2", "divlydo.style.display = 'none';", true);
        }
    }
    public void LoadDanhSachBacSiKhoa()
    {
        string sql = @"select id=bs.idbacsi,bs.tenbacsi,idphongban=bs.idphongkhambenh from bacsi bs left join bacsi_phongkham bp on bp.idbacsi=bs.idbacsi  where bp.idphongkhambenh=" + Request.QueryString["idkhoa"].ToString() + @"
union all
select id=idnhanvien,tenbacsi=tennhanvien,idphongban from nhanvien where  idchucvu=6 and idphongban=" +Request.QueryString["idphongban"].ToString()+@" ";
        DataTable dtBacSi = DataAcess.Connect.GetTable(sql);
        //StaticData.FillCombo(ddlBacSiKhoa, dtBacSi, "id", "tenbacsi");
    }
    public void LoadDanhSachDieuDuongKhoa()
    {
        string sqlPhongBan = " and idphongban=" + Request.QueryString["idphongban"].ToString();
        if (Request.QueryString["idphongban"].ToString() == "45" || Request.QueryString["idphongban"].ToString() == "43")
            sqlPhongBan = " and idphongban in(45,43) ";
        string sql = @"select  --cv.idchucvu,cv.machucvu,tenchucvu,
    id=idnhanvien,tenbacsi=tennhanvien,idphongban from nhanvien a --left join chucvu cv on cv.idchucvu=a.idchucvu where idphongban=17
    left join chucvu b on a.idchucvu=b.idchucvu where 1=1 "+sqlPhongBan+" and (machucvu like N'NHS%'or machucvu like N'DD%' or b.idchucvu=42)";
        DataTable dtBacSi = DataAcess.Connect.GetTable(sql);
       // StaticData.FillCombo(ddlDieuDuongKhoa, dtBacSi, "id", "tenbacsi");
    }
    public void DelBenhNhan(object s, DataGridCommandEventArgs e)
    {
         
    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Text == "Đã nhập")
            {
                //((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Enabled = false;
            }
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }
        }

    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        strSearch = GetChuoiSearch();
        BindListBenhNhan(strSearch);
        stt = e.NewPageIndex * dgr.PageSize + 1;
    }
    #endregion

    protected void InHoaDon(object source, DataGridCommandEventArgs e)
    {

    }
    protected void btlydo_Click(object sender, EventArgs e)
    {
        if (StaticData.CheckDate(txtNgayNhap.Text) == "")
        {
            StaticData.MsgBox(this, "Chưa nhập ngày hợp lệ !");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "1", "divlydo.style.display = '';", true);
            return;
        }
        if (Request.QueryString["idkhoa"].Equals("22") || Request.QueryString["idkhoa"].Equals("25"))
        {
            NhapKhoaPhauThuat();
            return;
        }
        if (ddlPhongNhapVien.SelectedValue == "" || ddlPhongNhapVien.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Chưa chọn phòng nhập viện !");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "1", "divlydo.style.display = '';", true);
            return;
        }
        if (ddlGiuongNhapVien.SelectedValue == "" || ddlGiuongNhapVien.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Chưa chọn giường nhập viện !");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "2", "divlydo.style.display = '';", true);
            return;
        }
        if (hdIdKhamBenh.Value == "" || hdIdKhamBenh.Value == "0")
            StaticData.MsgBox(this, "Chưa chọn Bệnh Nhân !");
        else
        {
            string TienGiuongNhap = txtTienGiuong.Text.Replace(",", "").Trim();
            string NgayNhap = StaticData.CheckDate(txtNgayNhap.Text.Trim()) + " " + txtGioNhap.Text.Trim();
            if (StaticData.ParseFloat(TienGiuongNhap) == 0)
            {
                StaticData.MsgBox(this, "Chưa nhập tiền giường !");
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "3", "divlydo.style.display = '';", true);
                return;
            }
            if (idbacsi.Value == "" || idbacsi.Value == "0")
            { StaticData.MsgBox(this, "Chưa chọn bác sĩ !");
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "4", "divlydo.style.display = '';", true);
                return; }
            if (iddieuduong.Value == "" || iddieuduong.Value == "0")
            { StaticData.MsgBox(this, "Chưa chọn điều dưỡng !");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "5", "divlydo.style.display = '';", true);
                return; }
            string sqlKB = @"select * from khambenh where idkhambenh ="+hdIdKhamBenh.Value+"";
            DataTable dtKB = DataAcess.Connect.GetTable(sqlKB);
            DataTable dtNoiTru = DataAcess.Connect.GetTable("select * from benhnhannoitru where IdChiTietDangKyKham =" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString());
            
            string sql = "";
            if (btlydo.Visible == true)
            {
                sql = @"insert into benhnhannoitru (NgayVaoVien,NhapTuKhoa,IdKhoaNoiTru,IdChiTietDangKyKham,IdKhamBenhGoc,IdBenhNhan,IdPhongNoiTru,IdGiuong,GhiChu,ListIdCD,GiaGiuong,IdKhamBenhNhap,idbacsiNhap,iddieuduongNhap,isNhapKhoa)
values ('" + NgayNhap + @"'," + dtKB.Rows[0]["idphongkhambenh"].ToString() + ",'" + Request.QueryString["idkhoa"].ToString() + "','" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString() + @"'
          ,'" + dtKB.Rows[0]["IdKhamBenh"].ToString() + "','" + dtKB.Rows[0]["IdBenhNhan"].ToString() + "','" + ddlPhongNhapVien.SelectedValue + "'," + ddlGiuongNhapVien.SelectedValue + ",N'','" + txtIdChanDoan_3.Value + "','" + TienGiuongNhap + "','" + hdIdKhamBenhNhap.Value + @"'
        ,'" + idbacsi.Value + "','" + iddieuduong.Value + "',1)";
            }
            else
            {
                sql = @"update benhnhannoitru set NgayVaoVien='" + NgayNhap + @"',IdPhongNoiTru='" + ddlPhongNhapVien.SelectedValue + @"'
                    ,IdGiuong=" + ddlGiuongNhapVien.SelectedValue + ",GiaGiuong=" + TienGiuongNhap + @"
                    ,idbacsiNhap='" + idbacsi.Value + "',iddieuduongNhap='" + iddieuduong.Value + @"'
                where idnoitru=" + hdIdNoiTruSuaNhap.Value+ "";
            }
            bool ktNhap = DataAcess.Connect.ExecSQL(sql);
            if (ktNhap)
            {
                sql = "update benhnhanxuatkhoa set IsNhapLai=1 where idkhoaxuat='"+ddlKhoa.SelectedValue+"' and idchitietdangkykham=" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString() + "";
                ktNhap = DataAcess.Connect.ExecSQL(sql);
                sql = "update benhnhannoitru set IsDaNhap=1 where IdKhoaNoiTru='" + ddlKhoa.SelectedValue + "' and idchitietdangkykham=" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString();
                ktNhap = DataAcess.Connect.ExecSQL(sql);

                #region cập nhật trạng thái check tính giường
                if (cbTinhTienTrongNgay.Checked == true)
                {
                    if (hdIdNoiTruSuaNhap.Value != "0")
                    {
                        bool ktTTG = StaticData.NVK_CapNhatTinhTrangGiuong(txtNgayNhap.Text.Trim(), dtKB.Rows[0]["IdChiTietDangKyKham"].ToString(), hdIdNoiTruSuaNhap.Value, "0");
                    }
                    else
                    {
                        string sqlKiemTra = @"select top 1 idnoitru from benhnhannoitru where idchitietdangkykham=" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString() + "  and convert(varchar(10),ngayvaovien,103)='" + txtNgayNhap.Text.Trim() + "' order by idnoitru desc";
                        DataTable dtTienG = DataAcess.Connect.GetTable(sqlKiemTra);
                        if (dtTienG.Rows.Count > 0)
                        {
                            bool ktTTG = StaticData.NVK_CapNhatTinhTrangGiuong(txtNgayNhap.Text.Trim(), dtKB.Rows[0]["IdChiTietDangKyKham"].ToString(), dtTienG.Rows[0]["idnoitru"].ToString(), "0");
                        }
                    }
                }
                else if(hdIdNoiTruSuaNhap.Value !="0")
                {
                    sql = @"update benhnhannoitru set ischontrongngay=0 where idnoitru=" + hdIdNoiTruSuaNhap.Value + @"";
                    bool ktTTG = DataAcess.Connect.ExecSQL(sql);
                }
                #endregion
                //Response.Redirect("DanhSachBenhNhanChoNhapKhoa.aspx?dkmenu="+this.dkmenu+"&IdKhoa=" + Request.QueryString["IdKhoa"].ToString() + "&MaKhoa=" + Request.QueryString["MaKhoa"].ToString() + "");
                //divlydo.Style.Add("display", "none");
                if (hdIdNoiTruSuaNhap.Value != "0")
                    StaticData.MsgBox(this, "Đã cập nhật !");
                else
                    StaticData.MsgBox(this, "Đã nhập bệnh nhân " + hdTenBenhNhan.Value + " vào "+ddlKhoa.SelectedItem.Text+"");
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'none';", true);
                strSearch = GetChuoiSearch();
                BindListBenhNhan(strSearch);
            }
        }      
    }

    private void NhapKhoaPhauThuat()
    {
        string NgayNhap = StaticData.CheckDate(txtNgayNhap.Text.Trim()) + " " + txtGioNhap.Text.Trim();
        string sqlKB = @"select * from khambenh where idkhambenh =" + hdIdKhamBenh.Value + "";
        DataTable dtKB = DataAcess.Connect.GetTable(sqlKB);
        DataTable dtNoiTru = DataAcess.Connect.GetTable("select * from benhnhannoitru where IdChiTietDangKyKham =" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString());

        string sql = "";
        if (btlydo.Visible == true)
        {
            sql = @"insert into benhnhannoitru (NgayVaoVien,NhapTuKhoa,IdKhoaNoiTru
    ,IdChiTietDangKyKham,IdKhamBenhGoc,IdBenhNhan
        ,GhiChu,ListIdCD,IdKhamBenhNhap,isNhapKhoa)
values ('" + NgayNhap + @"'," + dtKB.Rows[0]["idphongkhambenh"].ToString() + ",'" + Request.QueryString["idkhoa"].ToString() + @"'
    ,'" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString() + @"','" + dtKB.Rows[0]["IdKhamBenh"].ToString() + "','" + dtKB.Rows[0]["IdBenhNhan"].ToString() + @"'
        ,N'','" + txtIdChanDoan_3.Value + "','" + hdIdKhamBenhNhap.Value + @"',1)";
        }
        else
        {
            sql = @"update benhnhannoitru set NgayVaoVien='" + NgayNhap + @"' where idnoitru=" + hdIdNoiTruSuaNhap.Value + "";
        }
        bool ktNhap = DataAcess.Connect.ExecSQL(sql);
        if (ktNhap)
        {
            sql = "update benhnhanxuatkhoa set IsNhapLai=1 where idkhoaxuat='" + ddlKhoa.SelectedValue + "' and idchitietdangkykham=" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString() + "";
            ktNhap = DataAcess.Connect.ExecSQL(sql);
            sql = "update benhnhannoitru set IsDaNhap=1 where IdKhoaNoiTru='" + ddlKhoa.SelectedValue + "' and idchitietdangkykham=" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString();
            ktNhap = DataAcess.Connect.ExecSQL(sql);

            string sqlTaiKham = "update nvk_hentaikham set IsDaTaiKham=1 where idchitietdangkykham=" + dtKB.Rows[0]["IdChiTietDangKyKham"].ToString() + " and IdKhoaSeTaiKham='" + Request.QueryString["idkhoa"] + "'";
            bool ktTK = DataAcess.Connect.ExecSQL(sqlTaiKham);
            if (hdIdNoiTruSuaNhap.Value != "0")
                StaticData.MsgBox(this, "Đã cập nhật !");
            else
                StaticData.MsgBox(this, "Đã nhập bệnh nhân " + hdTenBenhNhan.Value + " vào " + ddlKhoa.SelectedItem.Text + "");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'none';", true);
            strSearch = GetChuoiSearch();
            BindListBenhNhan(strSearch);
        }
    }
    protected void ddlKhoa_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlKhoa.SelectedValue != "0")
        {
            noidungkcb();
        }
    }
    protected void ddlNoidung_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNoidung.SelectedValue != "0")
        {
            loadPhongKham();
        }
    }
    protected void ddlPhongNhapVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGiuongNhap(ddlPhongNhapVien.SelectedValue);
    }
    protected void ddlGiuongNhapVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTienGiuong(ddlGiuongNhapVien.SelectedValue);
    }
    public void LoadTienGiuong(string idGiuong)
    {
        string sqlG = @"select top 1 giuongcode,giaBH,giaDV,giangoaigio from kb_giuong g left join KB_BangGiaGiuong t on g.giuongid=t.giuongid
 where g.giuongid=" + idGiuong + " order by banggiagiuongid desc";
        DataTable dtG = DataAcess.Connect.GetTable(sqlG);
        if (dtG.Rows.Count > 0)
        {
            if (hdLoaiBN.Value == "1")
                txtTienGiuong.Text = StaticData.FormatNumber(dtG.Rows[0]["giaBH"], false).ToString();
            else
                txtTienGiuong.Text = StaticData.FormatNumber(dtG.Rows[0]["giaDV"], false).ToString();
        }
    }
}
