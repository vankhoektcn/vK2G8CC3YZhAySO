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

public partial class benhnhanlist : Genaratepage
{
    private string currentIdBacSi = null;
    string strSearch;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        this.currentIdBacSi = SysParameter.UserLogin.IdBacSi(this);
       
        if (!IsPostBack)
        {
            DataTable dtLoaiBN = DataAcess.Connect.GetTable("SELECT * FROM KB_LOAIBN where status=1");
            StaticData.FillCombo(this.cbLoaiBN, dtLoaiBN, "Id", "TenLoai", "Loại BN");
            cbLoaiBN.SelectedIndex = 0;


            if (Session["dieutricls"] != null)
            {
                Session.Remove("dieutricls");
            }
            txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            loadPK();
            loadBS(ddlPK.SelectedValue);
            SetValueEmpty();
            BindListBenhNhan("");
            StaticData.SetFocus(this, "txtMaBenhNhan");
            string old_IdPhongKhamBenh = Request.QueryString["idphongkhambenh"];
            string old_IdBacSi = Request.QueryString["IdBacSi"];
            string old_LoaiBN = Request.QueryString["loaibn"];
            if (old_IdPhongKhamBenh != null)
            {
                this.ddlPK.SelectedValue = old_IdPhongKhamBenh;
                this.ddlPK_SelectedIndexChanged1(sender, e);
            }
            if (old_IdBacSi != null)
                this.ddlBS.SelectedValue = old_IdBacSi;
            if (old_LoaiBN != null)
                this.cbLoaiBN.SelectedValue = old_LoaiBN;
         
        }
    }
    private void loadPK()
    {
        string sql = "select * from phongkhambenh pk ";
        if (this.currentIdBacSi!=null &&this.currentIdBacSi!="" && this.currentIdBacSi!="0")
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where pk.loaiphong = 1 and  bspk.idbacsi=" + this.currentIdBacSi + "";
        }
        else
        {
            sql += "where pk.loaiphong = 1 order by pk.tenphongkhambenh";
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlPK, dt, "idphongkhambenh", "tenphongkhambenh", "Chọn phòng/khoa");
        ddlPK.SelectedIndex = 0;
        if (ddlPK.Items.Count == 2)
        {
            ddlPK.SelectedIndex = 1;
        }
    }
    private void loadBS(string pk)
    {
        string sql = "select * from bacsi bs ";
        if (this.currentIdBacSi != null && this.currentIdBacSi != "" && this.currentIdBacSi != "0")
        {
            sql += "where idbacsi=  " + this.currentIdBacSi + "";
        }
        else
        {
            sql += "left join bacsi_phongkham bspk on bspk.idbacsi = bs.idbacsi  where bspk.idphongkhambenh=" + pk + " order by tenbacsi";
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlBS, dt, "idbacsi", "tenbacsi", "Chọn bác sĩ");
        if (this.currentIdBacSi != null && this.currentIdBacSi != "" && this.currentIdBacSi != "0")
        {
            ddlBS.SelectedValue = this.currentIdBacSi;
        }
    }
    protected void ddlPK_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlPK.SelectedValue != "0")
        {
            loadBS(ddlPK.SelectedValue);
        }
    }

    #region "U Function"

    private void BindListBenhNhan(string sWhere)
    {

        string strSQL = "SELECT DISTINCT kbcls.ngaythu,dbo.[GetIdCLSKB](bn.idbenhnhan) as IDKhamBenhCanLamSan,kbcls.idkhambenh,TenGioiTinh=DBO.GetGioiTinh(bn.GioiTinh),   bn.*,DBO.GetNamSinh( BN.ngaysinh) as namsinh,KHOACD=TenPhongKhamBenh,BSCD =TenBacSi,ChanDoanSoBo=KB.ChanDoanBanDau,SoBHYT ";
        strSQL += "FROM khambenhcanlamsan kbcls LEFT JOIN khambenh kb ON kbcls.idkhambenh = kb.idkhambenh "
        + " LEFT JOIN BACSI BS ON KB.IDBACSI=BS.IDBACSI" + "\r\n"
        + " LEFT JOIN PHONGKHAMBENH PKB ON KB.IDPHONGKHAMBENH=PKB.IDPHONGKHAMBENH " + "\r\n";        
        strSQL += "LEFT JOIN benhnhan bn ON dbo.KB_GetIdBenhNhan( kbcls.IDKhamBenhCanLamSan) = bn.idbenhnhan LEFT join banggiadichvu bg on bg.idbanggiadichvu=kbcls.idcanlamsan ";
        strSQL += " LEFT JOIN KB_LOAIBN LBN ON LBN.ID=BN.LOAI " + "\r\n";
        strSQL += " WHERE 1=1 and isnull(kbcls.idkhambenh,0) <> 0 and kbcls.ngaythu >='" + StaticData.CheckDate(txtTuNgay.Text.Trim()) + "'"
                            +" and kbcls.ngaythu <='" + StaticData.CheckDate(txtDenNgay.Text.Trim()) +" 23:59:59" +"'"
                             +" and bg.idphongkhambenh=" + ddlPK.SelectedValue
                             + " and ( (BG.IsBatBuocthu =1 AND  dathu = 1)  OR (BG.IsBatBuocthu =0 AND  dathu = 0) OR LBN.ISKHAMTRUOC=1 )"
                             +" and kbcls.dahuy=0"
                              +" and kbcls.dakham = 0 " + sWhere;

        if (this.cbLoaiBN.SelectedValue != "0")
            strSQL += " AND ISNULL(BN.LOAI,0)=" + this.cbLoaiBN.SelectedValue;

        strSQL += " ORDER BY kbcls.ngaythu ";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
       
        if (dtCTPhieu != null )
        {
            dgr.DataSource = dtCTPhieu;
            dgr.DataBind();
            lblTotal.Text = "Tổng số BN đang chờ CLS : " + dtCTPhieu.Rows.Count + " BN";
            if (dtCTPhieu.Rows.Count < 15)
                infospace.InnerHtml = "<p><p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>";
        }
    }
    
    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        this.txtSoBHYT.Text = "";
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
            skq += " AND bn.mabenhnhan    LIKE '%" + txtMaBenhNhan.Text.Trim() + "%' ";
        }
        if (txtTenBenhNhan.Text != "")
        {
            skq += " AND bn.tenbenhnhan LIKE N'%" + txtTenBenhNhan.Text.Trim() + "%' ";
        }
        if (txtDiaChi.Text != "")
        {
            skq += " AND bn.DiaChi LIKE N'%" + txtDiaChi.Text.Trim() + "%' ";
        }
        if (txtSoBHYT.Text != "")
        {
            skq += " AND bn.SOBHYT LIKE N'%" + txtSoBHYT.Text.Trim() + "%' ";
        }
        return skq;
    }
    private void BindCTPhieu(DataTable dtSRC)
    {
        if (dtSRC == null) return;
        dgr.DataSource = dtSRC;
        dgr.DataBind();
    }
    #endregion
    #region "Grid Event"
    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }


    public void Edit(object s, DataGridCommandEventArgs e)
    {
        string iKey;

        iKey = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
        string idkhambenh = ((Label)dgr.Items[e.Item.ItemIndex].FindControl("lblidkb")).Text;
        iKey = iKey.Remove(iKey.Length - 1, 1);
        Session["idkhambenhcls"] = iKey.ToString();
        Session["idkb"] = idkhambenh;
        if (Session["dieutricls"] != null)
        {
            Session.Remove("dieutricls");
        }
       
        Session["themmoi"] = 1;
        string idbs = ddlBS.SelectedValue;
        Response.Redirect("thambenhentry.aspx?idbs=" + idbs + "&idphongkhambenh=" + this.ddlPK.SelectedValue.ToString() + "&loaibn=" + cbLoaiBN.SelectedValue.ToString() + "IdKhambenh=" + iKey.ToString() );
    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnDel"));
            btn.Attributes.Add("onclick", "return ConfirmDelete();");
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
    }
    #endregion    
    
}
