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

public partial class frmDSBNChoTTVP : MKVPage
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "QLBV - VIỆN PHÍ";
        if (!IsPostBack)
        {
            SetValueEmpty();
            this.txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            StaticData.SetFocus(this, "txtMaBenhNhan");
            DataTable dtCTPhieu = GetTableSearch();
            BindListBenhNhan(dtCTPhieu);

        }
       string dkMenu = Request.QueryString["dkMenu"];
        if (dkMenu != null && dkMenu != "")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/" + dkMenu + "/uscmenu.ascx"));
        }
         
    }

    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }
    #endregion
    #region "U Function"

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
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
        string TuNgay = txtTuNgay.Text.Trim();
        string DenNgay = txtDenNgay.Text.Trim();
        return dtSearchBenhNhanPTT(mabenhnhan, tenbenhnhan, TuNgay,  DenNgay);
    }
    private DataTable dtSearchBenhNhanPTT(string MaBenhNhan
               , string sTenBenhnhan
               , string TuNgay
               ,string DenNgay
               )
    {
        string IsBNBH = Request.QueryString["IsBNBH"];
        string IsBNDV = Request.QueryString["IsBNDV"];

        TuNgay = StaticData.CheckDate(TuNgay) + " 00:00:00";
        DenNgay = StaticData.CheckDate(DenNgay) + " 23:59:59";
        string sqlselect = @"select row_number() over (order by A.Id) as STT,   A.Id 
		                                , A.IdBenhNhan
		                                ,mabenhnhan
		                                ,tenbenhnhan
		                                ,ngaysinh
		                                ,dbo.GetGioiTinh(B.gioitinh) AS GIOITINH 
		                                ,A.sobhyt
		                                ,Case A.DungTuyen when 'Y' then N'Đ.Tuyến' else N'Tr.Tuyến' end as DungTuyen
                                         ,NgayTinhBH = NGAYTINHBH 
		                                , TongSoTien=(CASE WHEN A.ISBHYT =1THEN  TongTienBH ELSE TONGTIENDV END)
                                        ,BHTra
		                                ,BNPhaiTra=(CASE WHEN A.ISBHYT =1 THEN  BNPhaiTra ELSE TongTienBNPT END)
                                        ,BNDaTraChenhLechBHYT=(CASE WHEN A.ISBHYT=1 THEN  BNDaTraChenhLechBHYT ELSE TongTienBNDaTra END)
                                        ,BNPhaiTraChenhLechBHYT=(CASE WHEN A.ISBHYT=1 THEN  BNPhaiTraChenhLechBHYT ELSE TongTienBNPTConLai END)
                                        ,IsNoiTru=isnull(a.isnoitru,0)
                                        ,TenBV=(case when isnull(a.isnoitru,0) =1 then N'BV02' else N'BV01' end)
                                        ,IDCHITIETDANGKYKHAM=A.IDCHITIETDANGKYKHAM_LAST
                                 from HS_BenhNhanBHDongTien A
                                LEFT JOIN BENHNHAN B ON A.IdBenhNhan=B.idbenhnhan
                                WHERE ISNULL( A.ISBHYT,0)=" + (IsBNBH=="1"? "1" :"0" )+@" 
		                                 AND  NgayTinhBH>='" + TuNgay + @"' AND NgayTinhBH<='" + DenNgay + @"'
                                        AND isnull( A.idkhambenh_last,0) <>0

                                 ";
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
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            btn = (LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"));


            bool a = false;
            if (a == true)
            {
                if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "Chưa thu")
                {

                    btn.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn thực thu Phiếu thu " + e.Item.Cells[6].Text + " hay không?');");
                }
                if (((LinkButton)(e.Item.Cells[0].FindControl("lnbtnStatus"))).Text == "Đã thu")
                {

                    btn.Attributes.Add("onclick", "return confirm('Bạn có chắc chắn hủy thực thu Phiếu thu " + e.Item.Cells[6].Text + " hay không?');");
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
    #endregion
    #region Hiển thị Mẫu BV01
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        int idphieutt = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
        string IsNoiTru = dgr.Items[e.Item.ItemIndex].Cells[13].Text;
        string idchitietdangkykham = dgr.Items[e.Item.ItemIndex].Cells[14].Text;
        Page page = HttpContext.Current.Handler as Page;
        if (e.CommandName == "ViewBV")
        {
            if(StaticData.IsCheck(IsNoiTru)==false)
              ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"frm_rpt_chiphikhambenh.aspx?idphieutt=" + idphieutt + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
          else
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"../noitru/frm_Rpt_BieuMau02.aspx?idchitietdangkykham=" + idchitietdangkykham + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
        }
        if (e.CommandName == "ViewBangKe")
        {
            
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "window.open(\"frm_rpt_DongChiTra.aspx?ID=" + idphieutt + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');", true);
            
        }

    }
    #endregion
}
