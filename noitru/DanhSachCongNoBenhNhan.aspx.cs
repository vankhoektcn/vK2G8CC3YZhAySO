using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Process;

public partial class KhoaSan_DanhSachCongNoBenhNhan : Genaratepage
{
    string loaibh;
    string madichvu;
    string idkhoa;
    protected void Page_Load(object sender, EventArgs e)
    {
        //madichvu = Request.QueryString["madichvu"].ToString();
        idkhoa = Request.QueryString["idkhoa"].ToString();
        if (!IsPostBack)
        {
            
            SetValueEmpty();
            txtRaVienLuc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            StaticData.SetFocus(this, "txtMaBenhNhan");
                DataTable dtCTPhieu = GetTableSearch();
                BindListBenhNhan(dtCTPhieu);

        }
        LoadMenu();
    }
    private void LoadMenu()
    {
        string dkmenu = Request.QueryString["dkmenu"].ToString();
        PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
    }
    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }

#region "U Function"

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtRaVienLuc.Text = "";
    }



    
    private DataTable GetTableSearch()
    {
        string mabenhnhan = txtMaBenhNhan.Text.Trim();
        string tenbenhnhan = txtTenBenhNhan.Text.Trim();
        string ngayxuatvien = txtRaVienLuc.Text.Trim();

        //return dtSearchBenhNhanPTT(mabenhnhan, tenbenhnhan, ngayxuatvien, loaibh);
        return nvk_tableBN_ChoSanh(mabenhnhan, tenbenhnhan, ngayxuatvien);
    }
    private DataTable nvk_tableBN_ChoSanh(string mabenhnhan,string tenbenhnhan, string ngayVaovien)
    {
        string sqlCS = @"
select *,CTTamUng=case when TongTienXetChoTU>0 then N'Chi tiết TU' else  N'' end from
(
        
        select idkhambenh=nt.idkhambenhnhap,nt.idbenhnhan,nt.idchitietdangkykham
        ,status=N'Tạm ứng'
        ,mabenhnhan,tenbenhnhan, dienthoai,ngaysinh,gioitinh=dbo.GetGioiTinh(Bn.gioitinh)
        ,ngayvaovien=nt.ngayvaovien
        ,phongkham =isnull((select top 1 tenphong from kb_phong where id =nt.idphongnoitru),(select top 1 tenphong from kb_phong where id=ct.PhongID))
        ,SoTienTamUng=isnull((select SUM(sotien) from tamung where isdathu=1 and isnull(soCTTU,0)<>0  and isnull(isdahuy,0)=0 and iddangkykham=nt.idchitietdangkykham),0)
        ,TongTienXetChoTU=isnull((select SUM(sotien) from tamung where isnull(soCTTU,0)<>0  and isnull(isdahuy,0)=0 and iddangkykham=nt.idchitietdangkykham),0)
        ,TongSoTien=0
        ,SoTienDaDong=0
        ,TUConLai=0

        from benhnhannoitru nt inner join benhnhan bn on bn.idbenhnhan =nt.idbenhnhan
        inner join chitietdangkykham ct on ct.idchitietdangkykham = nt.idchitietdangkykham
        where isdanhap=1 and ischosanh =1";
        if(!mabenhnhan.Equals(""))
            sqlCS +=" and bn.mabenhnhan like N'%"+mabenhnhan+"%'";
        if(!tenbenhnhan.Equals(""))
            sqlCS += " and bn.tenbenhnhan like N'%" + tenbenhnhan + "%'";            
        if(mabenhnhan.Equals("") && tenbenhnhan.Equals("") && !ngayVaovien.Equals(""))
            sqlCS += " and convert(varchar(10),ngayvaovien,103) ='" + ngayVaovien + @"' ";
        sqlCS += @"
) as abc ";
        DataTable table = DataAcess.Connect.GetTable(sqlCS);
        return table;
    }
    private DataTable dtSearchBenhNhanPTT(string MaBenhNhan
               , string sTenBenhnhan
               , string sNgayKham
               , string loaibh
               )
    {
        string tungay = StaticData.CheckDate(sNgayKham);
        string denngay = StaticData.CheckDate(sNgayKham) + " 23:59:59";
        string sqlselect = @"select top 50 -- A.idkhambenh ,A.idbenhnhan,a.iddangkykham,a.idchitietdangkykham
*,case when isnull(abc.sotienbnphaitra,0)=0 then ThanhToan else abc.sotienbnphaitra end as sotienbnphaitra1
,case when isnull(SoTienDaDong-TongSoTien-sotienHoanUng,0)>0 then SoTienDaDong-TongSoTien-sotienHoanUng else SoTienDaDong-TongSoTien-sotienHoanUng end as TUConLai
 from (
select   A.idkhambenh ,A.idbenhnhan,a.iddangkykham,a.idchitietdangkykham
,case when (isnull(a.hoantat,0)=0  
and a.idchitietdangkykham not in (select idchitietdangkykham from khambenh where idchitietdangkykham=a.idchitietdangkykham and isnull(huongdieutri,0) in(3,4,16,17))
) or a.idphongkhambenh=1
then N'Tạm ứng' else N'' end as status

--,case when isnull((select top 1 isdathu from chitietdangkykham where idchitietdangkykham= A.idchitietdangkykham),0)=1 then N'Đã thu' else N'Chưa thu' end as status
        --, A.IdBenhNhan
        ,mabenhnhan
        ,tenbenhnhan,b.dienthoai
        ,ngaysinh
        ,dbo.GetGioiTinh(B.gioitinh) AS GIOITINH 
        ,B.sobhyt
        ,case when b.loai<>1 then N'' else  B.DungTuyen end as DungTuyen
        ,A.ngaykham 
,Phongkham= isnull((select tenphong from kb_phong where id in(select top 1 idphongnoitru from benhnhannoitru where idchitietdangkykham=c.idchitietdangkykham order by ngayvaovien desc) ),'')
        , TongSoTien=[dbo].[KB_GETSOTIEN_capcuu](A.iddangkykham,B.idbenhnhan)
,SoTienTamUng=isnull((select SUM(sotien) from tamung where isdathu=1 and isnull(soCTTU,0)<>0  and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
       , SoTienDaDong=dbo.[KB_GETSOTIEN_capcuu_DaDong](A.iddangkykham,B.idbenhnhan)
---isnull((select SUM(convert(float,SoTienHU)) from tamung where isdathu=1 and isnull(soCTHU,0)<>0 and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
--+isnull((select sum(ThanhToan) from kb_phieuthanhtoan where idchitietdangkykham=A.idchitietdangkykham),0)

        ,SoTienBNPhaiTra=[dbo].[KB_GETSOTIEN_BNTra_capcuu](A.iddangkykham,B.idbenhnhan)
            -dbo.[KB_GETSOTIEN_capcuu_DaDong](A.iddangkykham,B.idbenhnhan)--Trong nay da bao gon tien tạm ứng nếu có
    +isnull((select SUM(convert(float,SoTienHU)) from tamung where isdathu=1 and isnull(soCTHU,0)<>0 and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
	-isnull((select sum(ThanhToan) from kb_phieuthanhtoan where idchitietdangkykham=A.idchitietdangkykham),0)
,sotienHoanUng= isnull((select SUM(convert(float,SoTienHU)) from tamung where isnull(soCTHU,0)<>0 and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
,ThanhToan=+isnull((select sum(ThanhToan) from kb_phieuthanhtoan where idchitietdangkykham=A.idchitietdangkykham),0)
 from khambenh A
left join chitietdangkykham c on c.idchitietdangkykham=a.idchitietdangkykham
left join banggiadichvu bg on bg.idbanggiadichvu= c.idbanggiadichvu
	LEFT JOIN BENHNHAN B ON A.IdBenhNhan=B.idbenhnhan
WHERE b.idbenhnhan is not null and isnull(a.idkhambenhgoc,0)=0
and isnull(a.isnoitru,0)=0
and 
(
  --bg.madichvu='" + this.madichvu+ @"' or
a.idchitietdangkykham in (select khambenh.idchitietdangkykham from khambenh left join chitietdangkykham on khambenh.idchitietdangkykham=chitietdangkykham.idchitietdangkykham
								left join banggiadichvu on banggiadichvu.idbanggiadichvu=chitietdangkykham.idbanggiadichvu
								where khambenh.idchitietdangkykham=a.idchitietdangkykham and huongdieutri=8 and phongkhamchuyenden="+idkhoa+@" --and banggiadichvu.madichvu ='"+madichvu+@"'
                            ) 
)

";
        if (sTenBenhnhan != null && sTenBenhnhan != "")
            sqlselect += " AND B.TenBenhnhan LIKE N'%" + sTenBenhnhan + "%'";
        if (MaBenhNhan != null && MaBenhNhan != "")
            sqlselect += " AND B.MABENHNHAN LIKE N'%" + MaBenhNhan + "%'";
        if (MaBenhNhan == "" && sTenBenhnhan == "" )
        {
            sqlselect += " and A.ngaykham>='" + tungay + @"'
                          and A.ngaykham<='" + denngay + @"'";
        }
        sqlselect += @" ) as abc  order by ngaykham desc ";
        DataTable dt= DataAcess.Connect.GetTable(sqlselect);
        //dt = DataAcess.Connect.GetTable(sqlselect);
        return dt;
    }
    private void BindListBenhNhan(DataTable dtCTPhieu)
    {
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }

    
    #endregion

    #region "Grid Event"


    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        stt = e.NewPageIndex * dgr.PageSize + 1;
    }
    #endregion

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        LinkButton btnIN;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            btn = (LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"));
            btnIN = (LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"));
            //btnIN.Attributes.Add("onclick", "return InPhieuThuCapCuu(" + dgr.DataKeys[e.Item.ItemIndex] + ");");
            bool a = true;
            if (a == true)
            {
                ////((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Text = "In Phiếu Báo Thu";
                if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "")
                {
                    ((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Enabled = false;
                ////    btn.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn thực thu Phiếu thu " + e.Item.Cells[6].Text + " hay không?');");
                ////}
                ////if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "Đã thu")
                ////{
                ////    ((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Enabled = true;
                ////    btn.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn hủy thực thu Phiếu thu " + e.Item.Cells[6].Text + " hay không?');");
                }
            }
            else
            {
                //((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Text = "In Phiếu Thu";
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
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "ViewTTBN")
        {
            int idphieutt = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            string idbn = e.CommandArgument.ToString();
            string sql = "SELECT * FROM Khambenh where idkhambenh="+idphieutt;
            DataTable dt = DataAcess.Connect.GetTable(sql);
            string ngaykham="";
            if (dt!=null && dt.Rows.Count>0)
            {
                idbn=dt.Rows[0]["idbenhnhan"].ToString();
                ngaykham=dt.Rows[0]["Ngaykham"].ToString();
            }
 //StaticData.ParseInt(dgr.Items[2].ToString());
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"../khambenh/frm_Rpt_PhieuThanhToan.aspx?Idbenhnhan=" + idbn + "&DateNgayRV=" + ngaykham + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
        }
        else if (e.CommandName == "ViewMauTH")
        {
            string idchitietdangkykham = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "window.open(\"../noitru/frm_rpt_BangKeVienPhiTheoKhoa.aspx?idchitietdangkykham=" + idchitietdangkykham + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
        }
        else if (e.CommandName == "LichSu")
        {
            string idChiTietDangKyKham = e.CommandArgument.ToString();
            string sql = @"select top 1 idbenhnhan,idchitietdangkykham from tamung tu inner join khambenh kb on kb.idchitietdangkykham=tu.iddangkykham where  idchitietdangkykham=" + idChiTietDangKyKham + "";
            DataTable dtDKK = DataAcess.Connect.GetTable(sql);
            if (dtDKK.Rows.Count > 0)
                Response.Write("<script>window.open('../ThuVienPhi/ThuTamUng.aspx?idkhoa=" + Request.QueryString["idkhoa"].ToString() + "&idbenhnhan=" + dtDKK.Rows[0]["idbenhnhan"].ToString() + "','_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');</script>");
            else
                StaticData.MsgBox(this, "Bệnh nhân chưa tạm ứng cho đợt khám này !");
        }
        else if (e.CommandName.ToString() == "Status")
        {
            string idDangKyKham = e.CommandArgument.ToString();
            string IdKhamBenh = dgr.DataKeys[e.Item.ItemIndex].ToString();
            string IdNguoiThu = SysParameter.UserLogin.UserID(this);
            if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "Tạm ứng")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "tamung(" + e.CommandArgument.ToString() + ",0);", true);
            }
            else if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "Chưa thu")
            {
                string sqlUpdate = @"update chitietdangkykham set isdathu=1,idnguoithu="+IdNguoiThu+@" where iddangkykham="+idDangKyKham+@"";
                string sqlUpdate1 = "update dangkykham set dathu=1 where iddangkykham=" + idDangKyKham + @"";
                string sqlUpdate2 ="update khambenhcanlamsan set dathu=1,thucthu=1,idnguoithu=" + IdNguoiThu + @" where idkhambenh=" + IdKhamBenh + "";
                bool kt = DataAcess.Connect.ExecSQL(sqlUpdate);
                kt = DataAcess.Connect.ExecSQL(sqlUpdate1);
                kt = DataAcess.Connect.ExecSQL(sqlUpdate2);
                if (kt)
                {
                    ((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text = "Đã thu";
                    ((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Enabled = true;
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "duan", "InPhieuSauThu(" + dgr.DataKeys[e.Item.ItemIndex].ToString() + ");", true);
                }
            }
            else if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "Đã thu")
            {
                string sqlUpdate = @"update chitietdangkykham set isdathu=0,idnguoithu=0 where iddangkykham=" + idDangKyKham + @"";
                string sqlUpdate1 = "update dangkykham set dathu=0 where iddangkykham=" + idDangKyKham + @"";
                string sqlUpdate2 = "update khambenhcanlamsan set dathu=0,thucthu=0,idnguoithu=0 where idkhambenh=" + IdKhamBenh + "";
                bool kt = DataAcess.Connect.ExecSQL(sqlUpdate);
                kt = DataAcess.Connect.ExecSQL(sqlUpdate1);
                kt = DataAcess.Connect.ExecSQL(sqlUpdate2);
                if (kt)
                {
                    ((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text = "Chưa thu";
                    ((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Enabled = false;
                }
            }
        }
        else if (e.CommandName == "InPhieuThu")
        {
            //int idBHDongTien = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            //Page page = HttpContext.Current.Handler as Page;
            //ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"../ThuVienPhi/frpt_PhieuThuCapCuu.aspx?idBHDongTien=" + idBHDongTien + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
        }

    }

    protected void btnTim_Click(object sender, EventArgs e)
    {
        DataTable dtCTPhieu = GetTableSearch();
        BindListBenhNhan(dtCTPhieu);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        SetValueEmpty();
        txtMaBenhNhan.ReadOnly = false;
        StaticData.SetFocus(this, "txtMaBenhNhan");
    }
}
