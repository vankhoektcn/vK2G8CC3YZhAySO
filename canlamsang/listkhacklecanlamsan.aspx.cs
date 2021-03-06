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

public partial class listkhacklecanlamsan : Genaratepage
{
    string strSearch;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (SysParameter.UserLogin.FullName(this) == null)
        {
            Response.Redirect("javascript:window.close();");
        }
        LoadMenu();
        if (!IsPostBack)
        {
            DataTable dtLoaiBN = DataAcess.Connect.GetTable("SELECT * FROM KB_LOAIBN  where status=1");
            StaticData.FillCombo(this.cbLoaiBN, dtLoaiBN, "Id", "TenLoai", "Loại BN");
            cbLoaiBN.SelectedIndex = 0;

            if (Session["idDieutri"] != null)
            {
                Session.Remove("idDieutri");
            }
            loadPK();
            if (ddlPK.SelectedValue != "" && ddlPK.SelectedValue != "0")
            {
                loadBS(ddlPK.SelectedValue);
            }
            SetValueEmpty();



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

            StaticData.SetFocus(this, "txtMaBenhNhan");
            txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            return;
            BindListBenhNhan("");


        }
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
    private void loadPK()
    {

        string sql = "select * from phongkhambenh pk ";
        if (SysParameter.UserLogin.IdBacSi(this) != null && SysParameter.UserLogin.IdBacSi(this) != "")
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where bspk.idbacsi=" + SysParameter.UserLogin.IdBacSi(this).ToString() + "";
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
        if (SysParameter.UserLogin.IdBacSi(this) != null && SysParameter.UserLogin.IdBacSi(this) != "")
        {
            sql += "where idbacsi=  " + SysParameter.UserLogin.IdBacSi(this).ToString() + "";
        }
        else
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idbacsi = bs.idbacsi  left join phongkhambenh pk on bspk.idphongkhambenh=pk.idphongkhambenh   where pk.loaiphong = 1 and bspk.idphongkhambenh=" + pk + " order by tenbacsi";
        }
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlBS, dt, "idbacsi", "tenbacsi", "Chọn bác sĩ");
        if (SysParameter.UserLogin.IdBacSi(this) != null)
        {
            if (ddlBS.Items.Count > 1)
            {
                ddlBS.SelectedIndex = 1;
            }
        }
        else
        {
            return;
        }
    }
    protected void ddlPK_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlPK.SelectedValue != "0" && ddlPK.SelectedValue != "")
        {
            loadBS(ddlPK.SelectedValue);
            if (ddlBS.SelectedValue != "0" && ddlPK.SelectedValue != "0")
            {
                strSearch = GetChuoiSearch();
                BindListBenhNhan(strSearch);
            }
            else
            {
                return;
            }
        }
    }

    #region "U Function"

    private void BindListBenhNhan(string sWhere)
    {
        string strsql = ""
                    + " select distinct" + "\r\n"
                    + " dbo.[GetIdCLS_ByMACLS](bn.idbenhnhan,k.maphieucls) as IDKhamBenhCanLamSan," + "\r\n"
                    + " K.idbenhnhan," + "\r\n"
                     + " madangkycls=K.maphieuCLS," + "\r\n"
                    + " mabenhnhan," + "\r\n"
                    + " tenbenhnhan," + "\r\n"
                    + " diachi," + "\r\n"
                    + " dienthoai,SoBHYT," + "\r\n"
                    + " case when isnull(gioitinh,0)=0 then 'Nam' else N'Nữ' end as TenGioiTinh," + "\r\n"
                    + " ngaysinh," + "\r\n"
                    + " NgayThu," + "\r\n"
                    + " case when tenBSChiDinh=' ' then N'BN tự đến' else tenBSChiDinh end as BSChiDinh" + "\r\n"
                    + "  from KhamBenhCanLamSan K " + "\r\n"
                    + " inner join benhnhan BN   on K.IDBenhNhan=BN.IDBenhNhan left join banggiadichvu bg on bg.idbanggiadichvu = k.idcanlamsan " + "\r\n"
                    + " Where 1=1 " + "\r\n";
        if (ddlPK.SelectedValue != "" && ddlPK.SelectedValue != "0")
        {
            strsql += " and  bg.idphongkhambenh = " + ddlPK.SelectedValue;
        }
        strsql += " " + "\r\n"
        + " and k.dahuy=0 and K.dakham=0" + "\r\n"
        + " AND NgayThu >= '" + StaticData.CheckDate(txtTuNgay.Text.Trim()) + "'"
        + " and NgayThu <='" + StaticData.CheckDate(txtDenNgay.Text.Trim()) + " 23:59:59" + "' " + sWhere;

        if (this.cbLoaiBN.SelectedValue != "0")
            strsql += " AND ISNULL(BN.LOAI,0)=" + this.cbLoaiBN.SelectedValue;
        if (txtMaCLS.Text.ToString() != "")
            strsql += " AND K.madangkycls='" + txtMaCLS.Text.ToString() + "'";
        strsql += " ORDER BY NgayThu desc";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strsql);
        if (dtCTPhieu != null)
        {
            dgr.DataSource = dtCTPhieu;
            dgr.DataBind();
            lblTotal.Text = "Tổng số BN đang chờ CLS " + dtCTPhieu.Rows.Count + " BN";
            if (dtCTPhieu.Rows.Count < 15)
                infospace.InnerHtml = "<p><p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;";
        }

    }

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtDiaChi.Text = "";
        this.txtSoBHYT.Text = "";
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("khachlecanlamsan.aspx");
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
        if (ddlBS.SelectedValue != "0" && ddlPK.SelectedValue != "0")
        {
            strSearch = GetChuoiSearch();
            BindListBenhNhan(strSearch);
        }
        else
        {
            StaticData.MsgBox(this, "Vui lòng chọn Phòng/Khoa và Bs trước khi lấy DSBN chờ CLS!");
        }
    }
    private string GetChuoiSearch()
    {
        string skq = "";
        if (txtMaBenhNhan.Text != "")
        {
            skq += " AND bn.mabenhnhan LIKE '%" + txtMaBenhNhan.Text.Trim() + "%' ";
        }
        if (txtTenBenhNhan.Text != "")
        {
            skq += " AND bn.tenbenhnhan LIKE N'%" + txtTenBenhNhan.Text.Trim() + "%' ";
        }
        if (txtDiaChi.Text != "")
        {
            skq += " AND bn.diachi LIKE N'%" + txtDiaChi.Text.Trim() + "%' ";
        }
        if (txtSoBHYT.Text != "")
        {
            skq += " AND bn.SoBHYT LIKE N'%" + txtSoBHYT.Text.Trim() + "%' ";
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
        string idkhachlecanlamsan;

        idkhachlecanlamsan = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
        idkhachlecanlamsan = idkhachlecanlamsan.Remove(idkhachlecanlamsan.Length - 1, 1);
        Session["idkhachlecanlamsan"] = idkhachlecanlamsan.ToString();
        string idbs = ddlBS.SelectedValue;
        Response.Redirect("dieutrikhachlecanlamsan.aspx?idbs=" + idbs + "&idphongkhambenh=" + this.ddlPK.SelectedValue.ToString() + "&loaibn=" + cbLoaiBN.SelectedValue.ToString());
    }
    public void DelBenhNhan(object s, DataGridCommandEventArgs e)
    {
        //int idkhachlecanlamsan;

        //idkhachlecanlamsan = StaticData.ParseInt(dgr.DataKeys[e.Item.ItemIndex]);
        //int idbenhnhan = Convert.ToInt16((Label)dgr.Items[e.Item.ItemIndex].FindControl(""));
        //Session["idkhachlecanlamsan"] = idkhachlecanlamsan.ToString();
        //Response.Redirect("dieutrikhachlecanlamsan.aspx?new=1&idkhambenh=" + idkhachlecanlamsan);    

        string idkhachlecanlamsan;

        idkhachlecanlamsan = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
        idkhachlecanlamsan = idkhachlecanlamsan.Remove(idkhachlecanlamsan.Length - 1, 1);
        Session["idbnCLS"] = ((Label)dgr.Items[e.Item.ItemIndex].FindControl("lblIdBN")).Text;
        Session["idkhachlecanlamsan"] = idkhachlecanlamsan.ToString();
        string madangky = "";
        madangky = e.Item.Cells[5].Text.ToString();
        string idbs = ddlBS.SelectedValue;
        string MaPhong = DataAcess.Connect.GetTable("select isnull((select maphongkhambenh from phongkhambenh where idphongkhambenh ='" + ddlPK.SelectedValue + "'),'')").Rows[0][0].ToString();
        string link = "";
        if (MaPhong.ToUpper() == "SA")
        {
            link = "KQSieuAM.aspx?new=1&idbs=" + idbs + "&idkhachlecanlamsan=" + idkhachlecanlamsan + "&MaPhong=" + MaPhong + "&idphongkhambenh=" + this.ddlPK.SelectedValue.ToString() + "&loaibn=" + cbLoaiBN.SelectedValue.ToString() + "&madangky=" + madangky;
        }
        else if (MaPhong.ToUpper() == "FC")//Fibro Scan
        {
            link = "KQFiboScan.aspx?new=1&idbs=" + idbs + "&idkhachlecanlamsan=" + idkhachlecanlamsan + "&MaPhong=" + MaPhong + "&idphongkhambenh=" + this.ddlPK.SelectedValue.ToString() + "&loaibn=" + cbLoaiBN.SelectedValue.ToString() + "&madangky=" + madangky;
        }
        else
        {
            link = "frmKQXetNghiem_new.aspx?new=1&macls='" + madangky.ToString() + "'&idbs=" + idbs + "&MaPhong=" + MaPhong + "&idphongkhambenh=" + this.ddlPK.SelectedValue.ToString() + "&loaibn=" + cbLoaiBN.SelectedValue.ToString() + "&dkmenu=nomenu";
        }
        Response.Write("<script>window.open(\"" + link + "\")</script>");
        e.Item.Visible = false;
    }
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnDel"));
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
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindListBenhNhan(strSearch);
    }
    #endregion

}
