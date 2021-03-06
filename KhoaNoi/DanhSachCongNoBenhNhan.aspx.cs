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

public partial class CapCuu_DanhSachCongNoBenhNhan : Genaratepage
{
    string loaibh;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            
            SetValueEmpty();
            txtRaVienLuc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            StaticData.SetFocus(this, "txtMaBenhNhan");
                DataTable dtCTPhieu = GetTableSearch();
                BindListBenhNhan(dtCTPhieu);

        }
        string dkmenu = Request.QueryString["dkmenu"];
        if (dkmenu == "thuphi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/thuvienphi/uscmenu.ascx"));
        }
        if (dkmenu == "capcuu")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/CapCuu/uscmenu.ascx"));
        }
        if (dkmenu == "khoangoai")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/KhoaNgoai/uscmenu.ascx"));
        }
        if (dkmenu == "khoasan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/KhoaSan/uscmenu.ascx"));
        }
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



    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
        txtMaBenhNhan.ReadOnly = false;
        StaticData.SetFocus(this, "txtMaBenhNhan");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dtCTPhieu = GetTableSearch();
        BindListBenhNhan(dtCTPhieu);
    }
    private DataTable GetTableSearch()
    {
        string mabenhnhan = txtMaBenhNhan.Text.Trim();
        string tenbenhnhan = txtTenBenhNhan.Text.Trim();
        string ngayxuatvien = txtRaVienLuc.Text.Trim();

        return dtSearchBenhNhanPTT(mabenhnhan, tenbenhnhan, ngayxuatvien, loaibh);
    }
    private DataTable dtSearchBenhNhanPTT(string MaBenhNhan
               , string sTenBenhnhan
               , string sNgayKham
               , string loaibh
               )
    {
        string tungay = StaticData.CheckDate(sNgayKham);
        string denngay = StaticData.CheckDate(sNgayKham) + " 23:59:59";
        string sqlselect = @"select  -- A.idkhambenh ,A.idbenhnhan,a.iddangkykham,a.idchitietdangkykham
*,case when isnull(abc.sotienbnphaitra,0)=0 then ThanhToan else abc.sotienbnphaitra end as sotienbnphaitra1
,case when isnull(SoTienTamUng-TongSoTien,0)>0 then SoTienTamUng-TongSoTien else 0 end as TUConLai
 from (
select   A.idkhambenh ,A.idbenhnhan,a.iddangkykham,a.idchitietdangkykham
,case when (isnull(a.hoantat,0)=0  or idphongkhambenh<>1) and
a.idchitietdangkykham not in (select idchitietdangkykham from khambenh where idchitietdangkykham=a.idchitietdangkykham and isnull(huongdieutri,0) in(1,3,4,16,17))
then N'Tạm ứng' else N'' end as status
        ,mabenhnhan
        ,tenbenhnhan
        ,ngaysinh
        ,dbo.GetGioiTinh(B.gioitinh) AS GIOITINH 
        ,B.sobhyt
        ,case when b.loai<>1 then N'' else  B.DungTuyen end as DungTuyen
        ,A.ngaykham 
        , TongSoTien=[dbo].[KB_GETSOTIEN_capcuu](A.iddangkykham,B.idbenhnhan)
,SoTienTamUng=isnull((select SUM(sotien) from tamung where isdathu=1 and isnull(soCTTU,0)<>0  and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
       , SoTienDaDong=dbo.[KB_GETSOTIEN_capcuu_DaDong](A.iddangkykham,B.idbenhnhan)

        ,SoTienBNPhaiTra=[dbo].[KB_GETSOTIEN_BNTra_capcuu](A.iddangkykham,B.idbenhnhan)
            -dbo.[KB_GETSOTIEN_capcuu_DaDong](A.iddangkykham,B.idbenhnhan)--Trong nay da bao gon tien tạm ứng nếu có
    +isnull((select SUM(convert(float,SoTienHU)) from tamung where isdathu=1 and isnull(soCTHU,0)<>0 and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
	-isnull((select sum(ThanhToan) from kb_phieuthanhtoan where idchitietdangkykham=A.idchitietdangkykham),0)
,sotienHoanUng= isnull((select SUM(convert(float,SoTienHU)) from tamung where isdathu=1 and isnull(soCTHU,0)<>0 and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
,ThanhToan=+isnull((select sum(ThanhToan) from kb_phieuthanhtoan where idchitietdangkykham=A.idchitietdangkykham),0)
 from khambenh A
left join chitietdangkykham c on c.idchitietdangkykham=a.idchitietdangkykham
left join banggiadichvu bg on bg.idbanggiadichvu= c.idbanggiadichvu
	LEFT JOIN BENHNHAN B ON A.IdBenhNhan=B.idbenhnhan
WHERE b.idbenhnhan is not null and isnull(a.idkhambenhgoc,0)=0
--and isnull(a.isnoitru,0)=0
and 
(
 a.idchitietdangkykham in (select khambenh.idchitietdangkykham from khambenh left join chitietdangkykham on khambenh.idchitietdangkykham=chitietdangkykham.idchitietdangkykham
								left join banggiadichvu on banggiadichvu.idbanggiadichvu=chitietdangkykham.idbanggiadichvu
								where khambenh.idchitietdangkykham=a.idchitietdangkykham and huongdieutri=8 and phongkhamchuyenden=4 ) 
)";
        if (sTenBenhnhan=="" && MaBenhNhan=="")
            sqlselect += @"and A.ngaykham>='" + tungay + @"' and A.ngaykham<='" +denngay+@"'";
        if (sTenBenhnhan != null && sTenBenhnhan != "")
            sqlselect += " AND B.TenBenhnhan LIKE N'%" + sTenBenhnhan + "%'";
        if (MaBenhNhan != null && MaBenhNhan != "")
            sqlselect += " AND B.MABENHNHAN LIKE N'%"+MaBenhNhan+"%'";
        sqlselect += @" ) as abc ";
        DataTable dt= DataAcess.Connect.GetTable(sqlselect);
        dt = DataAcess.Connect.GetTable(sqlselect);
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
                ////if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "Chưa thu")
                ////{
                ////    ((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Enabled = false;
                ////    btn.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn thực thu Phiếu thu " + e.Item.Cells[6].Text + " hay không?');");
                ////}
                ////if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "Đã thu")
                ////{
                ////    ((LinkButton)(e.Item.Cells[0].FindControl("lbtnEdit"))).Enabled = true;
                ////    btn.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn hủy thực thu Phiếu thu " + e.Item.Cells[6].Text + " hay không?');");
                ////}                
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
        else if (e.CommandName == "ViewBLTT")
        {           
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

}
