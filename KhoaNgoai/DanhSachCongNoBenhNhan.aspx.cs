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
        else
        {
            PlaceHolder1.Controls.Add(LoadControl("uscmenu.ascx"));
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
        string sqlselect = @"select   A.idkhambenh ,A.idbenhnhan,a.iddangkykham,a.idchitietdangkykham
--case when isnull((select top 1 isdathu from chitietdangkykham where idchitietdangkykham= A.idchitietdangkykham),0)=1 then N'Đã thu' else N'Chưa thu' end as status
,status= N'Tạm ứng'
        , A.IdBenhNhan
        ,mabenhnhan
        ,tenbenhnhan
        ,ngaysinh
        ,dbo.GetGioiTinh(B.gioitinh) AS GIOITINH 
        ,B.sobhyt
        ,B.DungTuyen
        ,A.ngaykham 
        , TongSoTien=[dbo].[KB_GETSOTIEN_capcuu](A.iddangkykham,B.idbenhnhan)
,SoTienTamUng=isnull((select SUM(sotien) from tamung where isdathu=1 and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
       , SoTienDaDong=isnull((select SUM(sotien) from tamung where isdathu=1 and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
+ (select isnull(sum(cls.thanhtien),0) from khambenhcanlamsan cls where cls.dathu=1 and cls.thucthu=1 and idkhambenh=A.idkhambenh)
+ (select isnull(sum(ctdkk.dongia),0) from chitietdangkykham ctdkk where ctdkk.isdathu=1 and ctdkk.idchitietdangkykham=A.idchitietdangkykham  )
        ,SoTienBNPhaiTra=[dbo].[KB_GETSOTIEN_BNTra_capcuu](A.iddangkykham,B.idbenhnhan)-
isnull((select SUM(sotien) from tamung where isdathu=1 and isnull(isdahuy,0)=0 and iddangkykham=A.idchitietdangkykham),0)
- (select isnull(sum(cls.thanhtien),0) from khambenhcanlamsan cls where cls.dathu=1 and cls.thucthu=1 and idkhambenh=A.idkhambenh)
- (select isnull(sum(ctdkk.dongia),0) from chitietdangkykham ctdkk where ctdkk.isdathu=1 and ctdkk.idchitietdangkykham=A.idchitietdangkykham  )
 from khambenh A
	LEFT JOIN BENHNHAN B ON A.IdBenhNhan=B.idbenhnhan
WHERE b.idbenhnhan is not null and A.idphongkhambenh=2 and A.ngaykham>='" + tungay+@"'
	and A.ngaykham<='" +denngay+@"'";
        if (sTenBenhnhan != null && sTenBenhnhan != "")
            sqlselect += " AND B.TenBenhnhan LIKE N'%" + sTenBenhnhan + "%'";
        if (MaBenhNhan != null && MaBenhNhan != "")
            sqlselect += " AND B.MABENHNHAN LIKE N'%"+MaBenhNhan+"%'";

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
