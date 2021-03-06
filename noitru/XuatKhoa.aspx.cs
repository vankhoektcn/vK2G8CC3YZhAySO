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
public partial class NoiTru_XuatKhoa : Genaratepage
{
    string strSearch;
    string dkmenu = null;
    private string login_IdBacsi = null;
    string IdKhoakhambenh;
    static string maKhoakhambenh;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            load_loaibn();
            StaticData.SetFocus(this, "txtMaBenhNhan");
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "document.getElementById('div2').style.display='none';", true);
            //div2.Visible = false;
            //tableHuongDieuTri.Visible = false;
            btnInChuyenVien.Visible = false;
            btnInXuatVien.Visible = false;
        }

        dkmenu = Request.QueryString["dkmenu"].ToString();
        LoadMenu();
    }
    private void LoadMenu()
    {
        string dkmenu = Request.QueryString["dkmenu"];
        PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
    }
    private void load_loaibn()
    {
        DataTable dtb = Profess.KB_LoaiBN.dtGetAll();
        StaticData.FillCombo(ddlLoaiKham, dtb, "id", "TenLoai", "----Chọn loại khám----");
    }
    private void load_HuongDieuTri()
    {
        string sqlHDT = @"select *,case when huongdieutriid=1 then N'Chuyển phòng KTP'";
        //if (Request.QueryString["idkhoa"].ToString() != "15")
            sqlHDT += "when huongdieutriid=8 then N'Chuyển khoa'";
        sqlHDT += "else TenHuongDieuTri end as HuongDT FROM kb_huongdieutri where 1=1 ";
        if (Request.QueryString["idkhoa"].ToString() != "15")
            sqlHDT += "and huongdieutriid in(3,4,8,11,16,17)";
        else
            sqlHDT += "and huongdieutriid in(1,3,4,8,11,16,17)";
        DataTable dtHdt = DataAcess.Connect.GetTable(sqlHDT);
        StaticData.FillCombo(ddlHuongDieuTri, dtHdt, "huongdieutriid", "HuongDT", "----Chọn hướng điều trị----");
    }
    private void load_KhoaChuyenDen()
    {
        DataTable dtKhoa = DataAcess.Connect.GetTable("select * FROM phongkhambenh where loaiphong=0 and idphongkhambenh not in(2,3,4) and idphongkhambenh not in(" + Request.QueryString["IdKhoa"].ToString() + ")");
        StaticData.FillCombo(ddlKhoa, dtKhoa, "idphongkhambenh", "tenphongkhambenh");
    }
    private void load_KhoaChuyenDen1()
    {
        DataTable dtKhoa = DataAcess.Connect.GetTable("select * FROM phongkhambenh where loaiphong=0 and  idphongkhambenh<>1 and idphongkhambenh not in(" + Request.QueryString["IdKhoa"].ToString() + ")");
        StaticData.FillCombo(ddlKhoa, dtKhoa, "idphongkhambenh", "tenphongkhambenh");
    }
    private void load_BenhVien()
    {
        //DataTable dtKhoa = DataAcess.Connect.GetTable("select * FROM benhvien  where isnull(mabenhvien,'')<>'' ");
        //StaticData.FillCombo(ddlBenhVien, dtKhoa, "idbenhvien", "tenbenhvien");
    }
    private void load_PhongChuyenDen()
    {
        //StaticData.MsgBox(this,ddlKhoa.SelectedValue+","+LoaiBn.Value);
        //StaticData.MsgBox(this, hdLoaiBN.Value);
        string sqlLoaiBN = "";
        if (hdLoaiBN.Value != "0" && hdLoaiBN.Value != "")
        {
            if (hdLoaiBN.Value == "1")
                sqlLoaiBN = " and p.loaiBN=1";
            else
                sqlLoaiBN = " and p.loaiBN=0";
        }
        if (ddlKhoa.SelectedValue != "0")
        {
            string sqlP = @"--select id,tenphong=maso+'-'+tenphong FROM kb_phong where id in
                --(
	                select id,tenphong=maso+'-'+tenphong from kb_phong p left join banggiadichvu bg on bg.idbanggiadichvu=p.dichvukcb where 1=1 "+sqlLoaiBN+" and  isnull(p.isphongnoitru,0)=0 and bg.idphongkhambenh=" + ddlKhoa.SelectedValue + @"
                --)";
            DataTable dtPhong = DataAcess.Connect.GetTable(sqlP);
            StaticData.FillCombo(ddlPhong, dtPhong, "id", "tenphong","chon phòng");
        }
    }
    #region btn_Click
    protected void btnTim_Click(object sender, EventArgs e)
    {
        string DK = KiemTraChuoiTimKiem();
        //string sql = @"select bn.*,kb.idkhambenh from benhnhan bn left join khambenh kb on kb.idbenhnhan=bn.idbenhnhan where 1=1 " +DK + "";
        string sql = @"select top 50 kb.idchitietdangkykham
            ,kb.idkhambenh as idkhambenhgoc
            ,idkhambenh= isnull(
		            (
			            select top 1 idkhambenh from khambenh kk where kk.idchitietdangkykham=kb.idchitietdangkykham   order by kk.idkhambenh desc
		            )
		            ,0)
            ,bn.* 
            --from dbo.[NVK_DSBNNoiTruTheoKhoa_1](" + Request.QueryString["idkhoa"].ToString() + @")
            from khambenh kb  left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan 
             where 1=1 --and isnull(kb.isdathanhtoan,0)=1 
        and  isnull( (select top 1 isdaravien from khambenh where idchitietdangkykham =kb.idchitietdangkykham and (idphongkhambenh=" + Request.QueryString["idkhoa"].ToString() + @" or idphongkhambenh=1) and isdaravien=1 order by idkhambenh desc)
,0)=1
and isnull(kb.idkhambenhgoc,0)=0
            and  (kb.idphongkhambenh =" + Request.QueryString["idkhoa"].ToString() + @"
              or kb.idchitietdangkykham in(select idchitietdangkykham from khambenh where idchitietdangkykham=kb.idchitietdangkykham and huongdieutri in(1,7,8) and phongkhamchuyenden =" + Request.QueryString["idkhoa"].ToString() + @")
            )
 " + DK + "";
        DataTable dtBN = DataAcess.Connect.GetTable(sql);
        if (dtBN.Rows.Count == 1)
        {
            SetBenhNhan(dtBN);
        }
        else if (dtBN.Rows.Count > 1)
        {
            dgrBenhNhanNoiTru.DataSource = dtBN;
            dgrBenhNhanNoiTru.DataBind();
            ScriptManager.RegisterStartupScript(Page, GetType(), null, "loadPopupTTBN();", true);
            dgrBenhNhanNoiTru.Visible = true;
        }
        else
        {
            StaticData.SetFocus(this, "txtMaBenhNhan");
            StaticData.MsgBox(this, "Không tìm thấy bệnh nhân!");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg1", "document.getElementById('div2').style.display='none';", true);
        }
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtDiaChi.Text = "";
        ddlGioiTinh.SelectedValue = "-1";
        ddlLoaiKham.SelectedValue = "0";
        btnInChuyenVien.Visible = false;
        btnInXuatVien.Visible = false;
        //ddlHuongDieuTri.SelectedValue = "0";
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg1", "document.getElementById('div2').style.display='none';", true);
    }
    protected void btnLuuXuatKhoa_Click(object sender, EventArgs e)
    {
        if (ddlHuongDieuTri.SelectedValue == "0")
        { StaticData.MsgBox(this,"Chưa chọn hướng điều trị !"); return; }
        string huongdieutri = ddlHuongDieuTri.SelectedValue.ToString();
        string khoa = ddlKhoa.SelectedValue.ToString();
        string pkchuyenden = ddlPhong.SelectedValue.ToString();
        string bvChuyenDen = hdIdBenhVien.Value;//ddlBenhVien.SelectedValue.ToString();
        string phuongphap = txtPhuongphap.Text.ToString();
        string loidan = txtLoiDan.Text.ToString();
        bool ok =false;
        string sql = "";
        if (huongdieutri == "1" || huongdieutri == "8")
        {
            if (pkchuyenden.Equals("")) pkchuyenden = "0";
            sql = "update khambenh set ngaykham=getdate(),huongdieutri=" + huongdieutri + ",phongkhamchuyenden=" + khoa + ",idphongchuyenden=" + pkchuyenden + " where idkhambenh=" + hdIdKhamBenh.Value.ToString();
        }
        else if (huongdieutri == "4")
        {
            sql = "update khambenh set huongdieutri=" + huongdieutri + ",ghichuhuongdieutri=" + bvChuyenDen + "where idkhambenh=" + hdIdKhamBenh.Value.ToString();
        }
        else if (huongdieutri == "17")
        {
            sql = "update khambenh set huongdieutri=" + huongdieutri + ",dando=N'" + phuongphap + "',noidungtaikham=N'" + loidan + "' where idkhambenh=" + hdIdKhamBenh.Value.ToString();
        }
        else
        {
            sql = "update khambenh set huongdieutri=" + huongdieutri + ",dando=N'" + phuongphap + "'where idkhambenh=" + hdIdKhamBenh.Value.ToString();
        }
        ok = DataAcess.Connect.ExecSQL(sql);
        if (ok)
        {
            string sqlDaXuat = "select * from benhnhanxuatkhoa where idchitietdangkykham=" + hdIdChiTietDKK.Value.ToString() + " and idkhoaxuat="+Request.QueryString["idkhoa"]+"  order by idxuatkhoa desc";
            DataTable dtDaXuat = DataAcess.Connect.GetTable(sqlDaXuat);
            string sqlInsert = "";
            if (dtDaXuat != null && dtDaXuat.Rows.Count > 0)
            {
                //--update benhnhanxuatkhoa set NgayXuatKhoa=getdate() where idxuatkhoa=" + dtDaXuat.Rows[0]["idxuatkhoa"].ToString() + "";
                sqlInsert = @"
                        update benhnhanxuatkhoa set NgayXuatKhoa=getdate()
                        ,IdHuongDieuTri=" + ddlHuongDieuTri.SelectedValue.ToString() + @"
                        ,IdKhoaChuyenDen='"+ddlKhoa.SelectedValue.ToString()+@"'
                        ,IdPhongChuyenDen='"+ddlPhong.SelectedValue.ToString()+@"'
                        ,IdBVChuyenDen='"+hdIdBenhVien.Value+@"'
                        ,PhuongPhapDT=N'"+txtPhuongphap.Text.ToString()+@"'
                        ,LoiDanXuatKhoa=N'"+txtLoiDan.Text.ToString()+@"'
                        ,ChanDoanXuatKhoa='"+hdIdChanDoan.Value +@"'
                        ,isnhaplai=0
                        ,idtinhTrang="+ddlTinhTrang.SelectedValue+@"
                        ,LyDoXuatKhoa=N'" + txtLySoXK.Text + @"'
                         where idxuatkhoa=" + dtDaXuat.Rows[0]["idxuatkhoa"].ToString()+"";
            }
            else
            {
                sqlInsert = "INSERT INTO BenhNhanXuatKhoa (NgayXuatKhoa,IdKhoaXuat,IdChiTietDangKyKham,"
                            + " IdKhamBenhGoc "
                            + " ,IdBenhNhan "
                            + " ,IdHuongDieuTri "
                            + " ,IdKhoaChuyenDen "
                            + " ,IdPhongChuyenDen "
                            + " ,IdBVChuyenDen "
                            + " ,PhuongPhapDT "
                            + " ,LoiDanXuatKhoa"
                            + @" ,ChanDoanXuatKhoa,isnhaplai,idtinhTrang,LyDoXuatKhoa) "
                           + " VALUES"
                           + " ('" + System.DateTime.Now.ToString() + "'"
                             + ",'" + Request.QueryString["IdKhoa"].ToString() + "' "
                            + " ,'" + hdIdChiTietDKK.Value.ToString() + "' "
                            + " ,'" + hdIdKBGoc.Value.ToString() + "' "
                            + " ,'" + hdIdBN.Value.ToString() + "' "
                            + " ,'" + ddlHuongDieuTri.SelectedValue.ToString() + "' "
                            + " ,'" + ddlKhoa.SelectedValue.ToString() + "' "
                            + " ,'" + ddlPhong.SelectedValue.ToString() + "' "
                            + " ,'" + hdIdBenhVien.Value + "'"
                            + " ,N'" + txtPhuongphap.Text.ToString() + "' "
                            + " ,N'" + txtLoiDan.Text.ToString() + "'"
                            + @" ,'" + hdIdChanDoan.Value + @"','0'," + ddlTinhTrang.SelectedValue + ",N'" + txtLySoXK.Text + @"'
                       )";
            }
            bool insert = DataAcess.Connect.ExecSQL(sqlInsert);
            if (insert )
            {
                if (ddlHuongDieuTri.SelectedValue.ToString().Trim() == "8" || ddlHuongDieuTri.SelectedValue.ToString().Trim() == "17" || ddlHuongDieuTri.SelectedValue.ToString().Trim() == "16" || ddlHuongDieuTri.SelectedValue.ToString().Trim()=="11"
                    || ddlHuongDieuTri.SelectedValue.ToString().Trim() == "4" || ddlHuongDieuTri.SelectedValue.ToString().Trim()=="3"
                    )
                {
                    sql = "update benhnhannoitru set IsDaNhap=0 where idkhoanoitru=" + Request.QueryString["idkhoa"].ToString() + " and idchitietdangkykham=" + hdIdChiTietDKK.Value.ToString();
                    bool ktIsDaNhap = DataAcess.Connect.ExecSQL(sql);
                }
                switch (huongdieutri)
                {
                    case "4":
                        {
                            bool ktDV= LuuPhiVanChuyen(hdIdKhamBenh.Value, hdIdBenhVien.Value);
                            btnInChuyenVien.Visible = true; break;
                        }
                    case "17": btnInXuatVien.Visible = true; break;
                }
                StaticData.MsgBox(this, "Đã lưu thành công");
            }
            if (!insert)
            {
                StaticData.MsgBox(this, "Lưu thất bại");
            }
        }
        else
        {
            StaticData.MsgBox(this, "Lưu thất bại");
        }
    }
    private bool LuuPhiVanChuyen(string idkhambenhchuyen,string idbenhvien)
    { 
        bool kt=false;
        string NgayKham = DateTime.Parse(DataAcess.Connect.s_SystemDate()).ToString("yyyy/MM/dd HH:mm");
        DataTable dtbv = DataAcess.Connect.GetTable("select * from benhvien where idbenhvien="+idbenhvien);
        string idbanggiadichvu = dtbv.Rows[0]["idbanggiadichvu"].ToString();
        #region loại dịch vụ
        if (cbCoBS.Checked == true && cbCoDD.Checked == true)
            idbanggiadichvu = dtbv.Rows[0]["idbanggiadichvuDDBS"].ToString();
        else if (cbCoBS.Checked == false && cbCoDD.Checked == true)
            idbanggiadichvu = dtbv.Rows[0]["idbanggiadichvuDD"].ToString(); 
        #endregion
        if (idbanggiadichvu.Equals("") || idbanggiadichvu.Equals("0"))
        {
            StaticData.MsgBox(this,"Chưa xác nhận phí vận chuyển !");
            return false;
        }
        string MaPhieuDV = "";
        #region Mã phiếu dịch vụ
        string sql = "select top 1 maphieucls from khambenhcanlamsan where idkhambenh=" + idkhambenhchuyen;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt == null || dt.Rows.Count == 0)
            MaPhieuDV = StaticData.NewSoChungTu(NgayKham, hdIdBN.Value, "Phí vận chuyển bệnh nhân", "0");
        else
            MaPhieuDV = dt.Rows[0][0].ToString(); 
        #endregion
        string sqlVC = @"insert into khambenhcanlamsan (idkhambenh,idcanlamsan,ngaythu,idnguoidung,
        ngaykham,idbenhnhan,maphieuCLS,soluong,GhiChu)
values(" + idkhambenhchuyen + "," + idbanggiadichvu + ",getdate()," + SysParameter.UserLogin.UserID(this) + @",
        getdate()," + hdIdBN.Value.ToString() + ",'"+MaPhieuDV+"',1,N'Phí vận chuyển bệnh nhân')";
        kt = DataAcess.Connect.ExecSQL(sqlVC);
        return kt;
    }
    protected void btnInChuyenVien_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "duan", "InPhieuChuyenVien(" + hdIdBN.Value + ");", true);
    }
    protected void btnInXuatVien_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "duan", "InPhieuRaVien(" + hdIdKhamBenh.Value + ");", true);
    }
    protected void btnMoiXuatKhoa_Click(object sender, EventArgs e)
    {
        ddlHuongDieuTri.SelectedValue = "0";
        loadDieuTri();
    }
    #endregion
    public void SetBenhNhan( DataTable dtBN)
    {
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "document.getElementById('div2').style.display='block';", true);      
            LoaiBn.Value = dtBN.Rows[0]["loai"].ToString();
            hdIdKhamBenh.Value = dtBN.Rows[0]["idkhambenh"].ToString();
            txtMaBenhNhan.Text = dtBN.Rows[0]["mabenhnhan"].ToString();
            txtTenBenhNhan.Text = dtBN.Rows[0]["tenbenhnhan"].ToString();
            hdIdBN.Value = dtBN.Rows[0]["idbenhnhan"].ToString();
            hdLoaiBN.Value = dtBN.Rows[0]["loai"].ToString();
            txtDiaChi.Text = dtBN.Rows[0]["diachi"].ToString();
            hdIdChiTietDKK.Value = dtBN.Rows[0]["idchitietdangkykham"].ToString();
            hdIdKBGoc.Value = dtBN.Rows[0]["idkhambenhgoc"].ToString();
            ddlGioiTinh.SelectedValue = dtBN.Rows[0]["gioitinh"].ToString();
            ddlLoaiKham.SelectedValue = dtBN.Rows[0]["loai"].ToString();
            //// Load thông tin xuất khoa
            load_HuongDieuTri();
            StaticData.SetFocus(this, "ddlHuongDieuTri");
        //div2.Style.Add("display", "block");        
    }
    public string KiemTraChuoiTimKiem()
    {
        string Where="";
        
            if (txtMaBenhNhan.Text.Trim() != "")
            {
                Where += " and mabenhnhan like N'%"+txtMaBenhNhan.Text.Trim()+"%'";
            }
            if (txtTenBenhNhan.Text.Trim() != "")
            {
                Where += " and tenbenhnhan like N'%" + txtTenBenhNhan.Text.Trim() + "%'";
            }
            if (txtDiaChi.Text.Trim() != "")
            {
                Where += " and diachi like N'%" + txtDiaChi.Text.Trim() + "%'";
            }
            if (ddlGioiTinh.SelectedValue != "-1")
            {
                Where += " and gioitinh =" + ddlGioiTinh.SelectedValue + "";
            }
            if (ddlLoaiKham.SelectedValue != "0")
            {
                Where += " and Loai =" + ddlLoaiKham.SelectedValue + "";
            }
        return Where;
    }
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "ViewTTBN")
        {
            int idbn = System.Convert.ToInt32(dgrBenhNhanNoiTru.DataKeys[e.Item.ItemIndex]);
            string sql = @"select kb.idchitietdangkykham
,kb.idkhambenh as idkhambenhgoc
,idkhambenh= isnull(
		(
			select top 1 idkhambenh from khambenh kk where kk.idchitietdangkykham=kb.idchitietdangkykham   order by kk.idkhambenh desc
		)
		,0)
,bn.* 
--from dbo.[NVK_DSBNNoiTruTheoKhoa_1](" + Request.QueryString["idkhoa"].ToString() + @")
from khambenh kb  left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan 
where 1=1 and bn.idbenhnhan= " + idbn;// +DK + "";
            DataTable dtBN = DataAcess.Connect.GetTable(sql);
            SetBenhNhan(dtBN);
        }
    }
    protected void btnAnTTBN_Click(object sender, EventArgs e)
    {
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "document.getElementById('light1').style.display='none';", true);
    }
    protected void loadDieuTri()
    {
        if (ddlHuongDieuTri.SelectedValue == "1")//Chuyển phòng
        {
            lbKhoa.Visible = true; lbPhong.Visible = true;
            ddlKhoa.Visible = true; ddlPhong.Visible = true;
            btnLuuXuatKhoa.Visible = true; //btnMoiXuatKhoa.Visible = true;

            spBV.Visible = false;//ddlBenhVien.Visible = false;
            spChanDoan.Visible = false;
            tbRaVien.Visible = false;
            load_KhoaChuyenDen();
            load_PhongChuyenDen();
        }
        else if (ddlHuongDieuTri.SelectedValue == "4")//Chuyển viện
        {
            lbKhoa.Visible = false; lbPhong.Visible = false;
            ddlKhoa.Visible = false; ddlPhong.Visible = false; tbRaVien.Visible = false;

            lbKhoa.Visible = true; spBV.Visible = true;//ddlBenhVien.Visible = true;
            spChanDoan.Visible = true;
            lbKhoa.Text = "Chọn BV";
            load_BenhVien();
        }
        else if (ddlHuongDieuTri.SelectedValue == "8")//Nhập viện
        {
            lbKhoa.Visible = true; lbPhong.Visible = false;
            ddlKhoa.Visible = true; ddlPhong.Visible = false;
            btnLuuXuatKhoa.Visible = true; //btnMoiXuatKhoa.Visible = true;

            spBV.Visible = false;//ddlBenhVien.Visible = false;
            spChanDoan.Visible = false;
            tbRaVien.Visible = false;
            load_KhoaChuyenDen1();
        }
        else if (ddlHuongDieuTri.SelectedValue == "17")//Xuất viện
        {
            lbKhoa.Visible = false; lbPhong.Visible = false;
            ddlKhoa.Visible = false; ddlPhong.Visible = false; spBV.Visible = false;//ddlBenhVien.Visible = false;
            spChanDoan.Visible = true;

            tbRaVien.Visible = true;
            if (Request.QueryString["idkhoa"].ToString() == "3")
            {
                txtLoiDan.Text = @"Uống thuốc theo toa.
Cho trẻ bú sữa mẹ.
Đưa trẻ đi tiêm ngừa đúng lịch.";
                txtPhuongphap.Text = @"Mổ lấy thai.
Kháng sinh.";
            }
            else
                txtLoiDan.Text = @"Uống thuốc theo toa.
Hết thuốc tái khám.";
        }
        else
        {
            lbKhoa.Visible = false; lbPhong.Visible = false;
            ddlKhoa.Visible = false; ddlPhong.Visible = false; spBV.Visible = false;//ddlBenhVien.Visible = false;
            spChanDoan.Visible = false;
            tbRaVien.Visible = false;
        }
        LoadTinhTrang(ddlHuongDieuTri.SelectedValue);
    }
    private void LoadTinhTrang(string huongdieutri)
    {
        string sqlTT = "";
        if (huongdieutri == "11")
            sqlTT = "select * from KB_TinhTrangXuatKhoa where idtinhtrang=5";
        else
            sqlTT = "select * from KB_TinhTrangXuatKhoa where idtinhtrang<>5";
        DataTable dtTT = DataAcess.Connect.GetTable(sqlTT);
        StaticData.FillCombo(ddlTinhTrang,dtTT,"idtinhtrang","tentinhtrang");
    }
    protected void ddlHuongDieuTri_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDieuTri();
    }
    protected void ddlKhoa_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_PhongChuyenDen();
    }
}
