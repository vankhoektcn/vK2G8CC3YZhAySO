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


public partial class ThuVienPhi_ThuTamUng_New : Page
{
    //string loaibh;
    public static string IdBenhNhanPage;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            if (Request.QueryString["idbenhnhan"] == null)
                return;
            string IdBenhNhan = Request.QueryString["idbenhnhan"].ToString();
            hdidbenhnhan.Value = IdBenhNhan;

            LoadThongTinBN(IdBenhNhan);
            IdBenhNhanPage = IdBenhNhan;
                DataTable dtCTPhieu = GetTableSearch(IdBenhNhan);
                BindListTamUng(dtCTPhieu);
        }
        //string dkmenu = Request.QueryString["dkmenu"].ToString();
        //hddkmenu.Value=dkmenu;
        //if(dkmenu=="capcuu")
        //    PlaceHolder1.Controls.Add(LoadControl("~/CapCuu/uscmenu.ascx"));
        //if (dkmenu == "tiepnhan")
        //{
        //    PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        //}
        //if (dkmenu == "thuphi")
        //{
        //    PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
        //}
    }
    private void LoadThongTinBN(string IdBenhNhan)
    {
        string sqlbenhnhan= @"SELECT *
,case when isnull(gioitinh,0)=0 then N'Nam' else N'Nữ' end as GioiTinhBN 
,convert(varchar,ngaytiepnhan,103) as NgayNhapKham
 from benhnhan where idbenhnhan="+IdBenhNhan+"";
        DataTable dtBN = DataAcess.Connect.GetTable(sqlbenhnhan);
        if (dtBN != null && dtBN.Rows.Count > 0)
        {
            txtMaBenhNhan.Text = dtBN.Rows[0]["MaBenhNhan"].ToString();
            txtTenBenhNhan.Text = dtBN.Rows[0]["tenBenhNhan"].ToString();
            txtDiaChi.Text = dtBN.Rows[0]["DiaChi"].ToString();
            txtNgaySinh.Text = dtBN.Rows[0]["NgaySinh"].ToString();
            txtNgayTiepNhan.Text = dtBN.Rows[0]["NgayNhapKham"].ToString();
            txtSoDienThoai.Text = dtBN.Rows[0]["dienthoai"].ToString();
            txtGioiTinh.Text = dtBN.Rows[0]["GioiTinhBN"].ToString();
        }
    }
    #region "U Function"


    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        txtMaBenhNhan.ReadOnly = false;
        StaticData.SetFocus(this, "txtMaBenhNhan");
    }
   
    private DataTable GetTableSearch(string idbenhnhan)
    {
        return dtSearchBenhNhan(idbenhnhan);
    }
    private DataTable dtSearchBenhNhan(string idbenhnhan)
    {
//        string sqlselect = @"select row_number() over (order by idtamung) as stt
//    ,* from
//    (
        string sqlselect = @"select  row_number() over (order by idtamung) as stt,
        tu.idtamung,dk.idbenhnhan,kb.idkhambenh,ctdkk.idchitietdangkykham,ctdkk.iddangkykham,sct.quyenso,sochungtu=sct.sophieuCT ";
        if (Request.QueryString["idkhoa"] != null)
            sqlselect += @",'' as status
,case when isnull(tu.isdathu,0)=1 then N'' else N'Sửa' end as Sua
,case when isnull(tu.isdathu,0)=1 then N'' else N'Xóa' end as Xoa  ";
        else
            sqlselect += @",case when isnull(tu.isdahuy,0)=1 then N'Phục hồi' when isnull(tu.isdathu,0)=0 then N'Chưa thu' else N'Đã thu' end as status
,case when isnull(tu.isdathu,0)=1 then N'' else N'Sửa' end as Sua
,case when isnull(tu.isdathu,0)=1 then N'' else N'Xóa' end as Xoa
";
        sqlselect += @",Phongkhambenh=phong.Maso +'-'+phong.tenphong
        ,dichvukham=bg.tendichvu
        ,ngaykham=convert(varchar,kb.ngaykham,103)
,ngayTamung,tenphongkhambenh
        ,bacsi=bs.tenbacsi
        ,sotien=tu.SoTien
        ,LydoTamUng=tu.LyDoTU
         from tamung tu left join sochungtu sct on sct.stt= tu.SoCTTU
        left join chitietdangkykham ctdkk on ctdkk.idchitietdangkykham=tu.iddangkykham
		left join dangkykham dk on dk.iddangkykham =ctdkk.iddangkykham
        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
        left join khambenh kb on kb.idchitietdangkykham=tu.iddangkykham
        left join bacsi bs on kb.idbacsi= bs.idbacsi
        left join kb_phong phong on phong.id= ctdkk.PhongId
left join phongkhambenh pk on pk.idphongkhambenh=tu.idkhoaTU
        where isnull(soCTHU,0)=0 and isnull(idkhambenhgoc,0)=0 and  kb.idkhambenh is not null and  dk.idbenhnhan=" + idbenhnhan + @"";

    //union all
    //    select top 1
    //    idtamung=1000,kb.idbenhnhan,kb.idkhambenh,ctdkk.idchitietdangkykham,ctdkk.iddangkykham,quyenso='',sochungtu=''
    //    ,status=N'Tạm ứng' 
    //    ,Phongkhambenh=phong.Maso +'-'+phong.tenphong
    //    ,dichvukham=bg.tendichvu
    //    ,ngaykham=convert(varchar,kb.ngaykham,103)
    //    ,bacsi=bs.tenbacsi
    //    ,sotien=0
    //    ,LydoTamUng=N'Chưa tạm ứng'
    //     from khambenh kb
    //    left join chitietdangkykham ctdkk on ctdkk.idchitietdangkykham=kb.idchitietdangkykham
    //    left join kb_phong phong on phong.id= ctdkk.PhongId
    //    left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
    //    left join bacsi bs on kb.idbacsi= bs.idbacsi
    //    where kb.idkhambenh is not null and  idbenhnhan="+idbenhnhan+@"
    //    order by idkhambenh desc
    //) as abc";
        return DataAcess.Connect.GetTable(sqlselect);
    }
    private void BindListTamUng(DataTable dt)
    {
        dgr.DataSource = dt;
        dgr.DataBind();
    }


    #endregion

    #region "Grid Event"


    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
    }
    #endregion

    protected void dgr_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        LinkButton btnStatus = ((LinkButton)(e.Item.Cells[1].FindControl("lnbtnStatus")));
        LinkButton btnIn = ((LinkButton)(e.Item.Cells[0].FindControl("lbnIn")));
        
        if (e.CommandName == "TU")
        {
            LinkButton btn = new LinkButton();
            btn = (LinkButton)(e.Item.Cells[6].FindControl("lbnSua"));            
            int iddangkykham = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]); //StaticData.ParseInt(dgr.Items[2].ToString());
            Page page = HttpContext.Current.Handler as Page;
            if (btn.Text == "Sửa")
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "tamung(" + iddangkykham + ",1);", true);
            else
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "tamung(" + iddangkykham + ",0);", true);

        }
        if (e.CommandName == "inBLTU")
        {
            hdIdTamUng.Value = e.CommandArgument.ToString();
            int iddangkykham = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            if(Request.QueryString["idkhoa"] != null)
                Response.Write("<script>window.open('../capcuu/frmPhieuBaoThuTamUng.aspx?hdIdTamUng=" + hdIdTamUng.Value + "#isPrint=1');</script>");
            else
                Response.Write("<script>window.open('frmBienlaitamung.aspx?idTamUng=" + hdIdTamUng.Value + "&iddkk=" + iddangkykham + "');</script>");
        }
        else if (e.CommandName.ToString() == "Status")
        {
            hdIdTamUng.Value = e.CommandArgument.ToString();
            int iddangkykham = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            HDidCHiTietDKK.Value = iddangkykham.ToString();
            if (btnStatus.Text == "Đã thu")
            {
                nguoidung.Text = SysParameter.UserLogin.FullName(this);
                ngaythang.Text = DateTime.Now.ToShortDateString();
                kieutt.Text = "Huy Tam Ung";
                divlydo.Style.Add("display", "");
            }
            else if (btnStatus.Text == "Phục hồi")
            {
                string sqlUpdate = @"update tamung set isDaHuy=0 where iddangkykham=" + iddangkykham + "";
                bool kt = DataAcess.Connect.ExecSQL(sqlUpdate);
                if (kt)
                {
                    StaticData.MsgBox(this, "Đã phục hồi phiếu tạm ứng !");
                    btnStatus.Text = "Đã thu";
                    btnIn.Enabled = true;
                    return;
                    //btnIn.Text = "";
                }
            }
            if (btnStatus.Text == "Chưa thu")
            {
                string sqlUpdate = @"update tamung set isDaThu=1 where idtamung=" + e.CommandArgument.ToString() +"";
                bool kt = DataAcess.Connect.ExecSQL(sqlUpdate);
                if (kt)
                {
                   // StaticData.MsgBox(this, "Đã Thu phiếu tạm ứng !");
                    btnStatus.Text = "Đã thu";
                    ((LinkButton)(e.Item.Cells[1].FindControl("lnbtnSua"))).Text="";
                    ((LinkButton)(e.Item.Cells[1].FindControl("lnbtnXoa"))).Text = "";
                    btnIn.Enabled = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dfgw", "InPhieuSauThu(" + e.CommandArgument.ToString() + "," + dgr.DataKeys[e.Item.ItemIndex].ToString() + ");", true);
                    return;
                    //btnIn.Text = "";
                }
            }
        }
        else if (e.CommandName.ToString() == "ThuTien")
        {
            hdIdTamUng.Value = e.CommandArgument.ToString();
            int iddangkykham = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            HDidCHiTietDKK.Value = iddangkykham.ToString();
            if (btnStatus.Text == "Đã thu")
            {
                nguoidung.Text = SysParameter.UserLogin.FullName(this);
                ngaythang.Text = DateTime.Now.ToShortDateString();
                kieutt.Text = "Huy Tam Ung";
                divlydo.Style.Add("display", "");
            }
            else if (btnStatus.Text == "Phục hồi")
            {
                string sqlUpdate = @"update tamung set isDaHuy=0 where idtamung=" + hdIdTamUng.Value + "";
                bool kt = DataAcess.Connect.ExecSQL(sqlUpdate);
                if (kt)
                {
                    StaticData.MsgBox(this, "Đã phục hồi phiếu tạm ứng !");
                    btnStatus.Text = "Đã thu";
                    btnIn.Enabled = true;
                    return;
                    //btnIn.Text = "";
                }
            }
            if (btnStatus.Text == "Chưa thu")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "tamung(" + iddangkykham + ",1);", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "duan", "InPhieuSauThu(" + dgr.DataKeys[e.Item.ItemIndex].ToString() + ");", true);
                btnIn.Enabled = true;
            }
            else if (btnStatus.Text == "Tạm ứng")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "tamung(" + iddangkykham + ",0);", true);
            }
        }
        else if (e.CommandName.ToString() == "SuaTU")
        {
            #region Sửa nội dung tạm ứng
            //StaticData.MsgBox(this,"Sửa !"); 
            int iddangkykham = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
            string idtamung= e.CommandArgument.ToString();
            HDidCHiTietDKK.Value = iddangkykham.ToString();
            hdIdTamUng.Value = idtamung;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "SuaTamUng(" + iddangkykham + ",1," + idtamung+ ");", true);
            #endregion
        }
        else if (e.CommandName.ToString() == "XoaTU")
        {
            #region Xóa tạm ứng
            string idtamung = e.CommandArgument.ToString();
            string sqlXoa = "delete from tamung where idtamung="+idtamung;
            bool ktXoa = DataAcess.Connect.ExecSQL(sqlXoa);
            if (ktXoa)
            {
                DataTable dtCTPhieu = GetTableSearch(IdBenhNhanPage);
                BindListTamUng(dtCTPhieu);
                StaticData.MsgBox(this, "Đã xóa !");
            }
            else
                StaticData.MsgBox(this, "Xóa thất bại!"); 
            #endregion
        }
    }
    protected void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnIn = ((LinkButton)(e.Item.Cells[0].FindControl("lbnIn")));
            LinkButton btnStatus = ((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus")));
            LinkButton btnXoa = ((LinkButton)(e.Item.Cells[0].FindControl("lnbtnXoa")));
            if (btnStatus.Text == "")
            {
                btnStatus.Attributes.Add("onclick", "return false;");
            }
            //-------------------------------------------------------------------
            if (btnStatus.Text == "Chưa thu")
            {
                btnIn.Enabled = false;
                btnIn.Text = "In BL tạm ứng";
                //btnStatus.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn thực thu Phiếu thu " + e.Item.Cells[6].Text + " hay không?');");
            }
            else if (btnStatus.Text == "Phục hồi")
            {
                btnIn.Enabled = false;
                btnIn.Text = "In BL tạm ứng";
                btnStatus.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn phục hồi phiếu tạm ứng " + e.Item.Cells[6].Text + " hay không?');");
            }
            else if (btnStatus.Text == "Đã thu" || btnStatus.Text == "")
            {
                btnIn.Enabled = true;
                btnIn.Text = "In BL tạm ứng";
                if (btnStatus.Text == "Đã thu")
                    btnStatus.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn hủy thực thu tạm ứng " + e.Item.Cells[6].Text + " hay không?');");
            }
            else if (btnStatus.Text == "Tạm ứng")
            {
                btnIn.Text = "";
                btnIn.Enabled = false;
            }
            btnXoa.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn xóa phiếu tạm ứng " + e.Item.Cells[6].Text + " hay không?');");
            //------------------------------------------------------------------
            //btn.Attributes.Add("onclick", "return ConfirmDelete();");
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
    protected void btlydo_Click(object sender, EventArgs e)
    {
        if (HDidCHiTietDKK.Value == "" || HDidCHiTietDKK.Value == "0")
        { StaticData.MsgBox(this, "Vui lòng thử lại sau !"); return; }
        Process.trangthailuutrudulieu TrangThai= Process.trangthailuutrudulieu.Insert_Object(SysParameter.UserLogin.UserID(this), DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "tamung", "idTamUng", hdIdTamUng.Value, lydo.Text, kieutt.Text);
        
        string sqlUpdate = @"update tamung set isDaHuy=1 where idtamung=" + hdIdTamUng.Value + "";
        bool kt = DataAcess.Connect.ExecSQL(sqlUpdate);
        if (kt)
        {
            divlydo.Style.Add("display", "none");
            StaticData.MsgBox(this, "Đã hủy phiếu tạm ứng !");
            DataTable dtCTPhieu = GetTableSearch(hdidbenhnhan.Value);
            BindListTamUng(dtCTPhieu);
        }
    }
}
