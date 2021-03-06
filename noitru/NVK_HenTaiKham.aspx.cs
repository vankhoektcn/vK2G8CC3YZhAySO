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
public partial class NVK_HenTaiKham : Genaratepage
{
    string strSearch;
    string dkmenu = null;
    private string login_IdBacsi = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetValueEmpty();
            StaticData.SetFocus(this, "txtMaBenhNhan");
            LoadLoaiKham();
            LoadKhoaTaiKham();
            BindListBenhNhan("");
        }
        dkmenu = Request.QueryString["dkmenu"].ToString();
        LoadMenu();
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

    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }


    #region "U Function"
    private void LoadLoaiKham()
    {
        string sqlLK = "select * from KB_LoaiBN";
        DataTable dtLK = DataAcess.Connect.GetTable(sqlLK);
        if (dtLK != null && dtLK.Rows.Count > 0)
            StaticData.FillCombo(ddlLoaiKham, dtLK, "id", "tenloai", "__Chọn loại khám__");
    }
    private void LoadKhoaTaiKham()
    {
        string sqlLK = "select * from phongkhambenh where loaiphong=0";
        DataTable dtLK = DataAcess.Connect.GetTable(sqlLK);
        if (dtLK != null && dtLK.Rows.Count > 0)
            StaticData.FillCombo(ddlKhoaTaiKham, dtLK, "idphongkhambenh", "tenphongkhambenh");
        try
        {
            ddlKhoaTaiKham.SelectedValue = Request.QueryString["idkhoa"].ToString();
        }
        catch (Exception){}
    }
    private void BindListBenhNhan(string sWhere)
    {
        string ngaybt = "";
        string ngaykt = "";
        DataTable dtCTPhieu = new DataTable();
        string strSQL = "";

        string dk = @"case when isnull((select top 1 idHenTaiKham from NVK_HenTaiKham where idchitietdangkykham =kb.idchitietdangkykham and IdKhoaSeTaiKham=" + Request.QueryString["idkhoa"] + @" and IsDaTaiKham=0),0)=0 then N'Hẹn tái khám'
                else N'Đã hẹn' end as ChucNang";

        strSQL = @"select top 20 row_number() over(order by ngaytaikham) as stt,* from (
select distinct	kb.idchitietdangkykham,
           " +dk+ @"
         ,kb.idbenhnhan,mabenhnhan,tenbenhnhan,bn.sobhyt,bn.diachi
        ,bn.dienthoai,dbo.GetGioiTinh(bn.gioitinh) as gioitinh,bn.ngaysinh as namsinh 
        ,KhoaTaiKham= isnull((select top 1 tenphongkhambenh from NVK_HenTaiKham tk left join phongkhambenh k on k.idphongkhambenh=tk.IdKhoaSeTaiKham
            where idchitietdangkykham =kb.idchitietdangkykham and IdKhoaSeTaiKham=" + Request.QueryString["idkhoa"] + @" and IsDaTaiKham=0 order by NgayTaoPhieuHen desc),'')
        ,NgayTaiKham= isnull((select top 1 NgayHenTaiKham from NVK_HenTaiKham tk 
            where idchitietdangkykham =kb.idchitietdangkykham and IdKhoaSeTaiKham=" + Request.QueryString["idkhoa"] + @" and IsDaTaiKham=0 order by NgayTaoPhieuHen desc),null)
        from khambenh kb left join benhnhan bn on bn.idbenhnhan= kb.idbenhnhan
        where 1=1 and isnull(hoantat,0)=0 and isnull(kb.idkhambenhgoc,0)=0 
        " +sWhere+@"
    and kb.idchitietdangkykham in (select idchitietdangkykham from benhnhannoitru where idchitietdangkykham=kb.idchitietdangkykham and idkhoanoitru=" + Request.QueryString["idkhoa"].ToString() + @" and isdanhap=1)";

        strSQL += @" -- order by ngaykham desc
        )as abc";
        
        dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        if (dtCTPhieu != null)
        {
            dgr.DataSource = dtCTPhieu;
            if(dtCTPhieu.Rows.Count<dgr.PageSize)
            dgr.CurrentPageIndex = 0;
            dgr.DataBind();
        }
    }

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        ddlGioiTinh.SelectedIndex = 0;
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
        if (ddlGioiTinh.SelectedValue != "-1")
        {
            skq += " AND bn.gioitinh = " + ddlGioiTinh.SelectedValue;
        }
        if (ddlLoaiKham.SelectedValue != "0")
        {
            skq += " AND bn.loai = " + ddlLoaiKham.SelectedValue;
        }
        return skq;
    }
    #endregion
    #region "Grid Event"
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        DataTable dtBN = DataAcess.Connect.GetTable(@"select case when isnull(gioitinh,0)=0 then N'Nam' else N'Nữ' end as Gioi,*,NgayHienTai = convert(varchar,getdate(),103)+' '+convert(varchar,getdate(),108)
from benhnhan where idbenhnhan=" + e.CommandArgument.ToString());
        if (dtBN != null && dtBN.Rows.Count > 0)
        {
            txtTenBNNhap.Text = dtBN.Rows[0]["tenbenhnhan"].ToString();
            txtMaBNNhap.Text = dtBN.Rows[0]["mabenhnhan"].ToString();
            txtGioiTinhNhap.Text = dtBN.Rows[0]["Gioi"].ToString();
            txtNgayHen.Text = dtBN.Rows[0]["NgayHienTai"].ToString();

            DataTable dtKB = DataAcess.Connect.GetTable("select TenKhoaHen=isnull((select tenphongkhambenh from phongkhambenh where idphongkhambenh='" + Request.QueryString["idkhoa"] + "'),'')");
            txtKhoaHen.Text = dtKB.Rows[0]["TenKhoaHen"].ToString();
            hdIdchitietdangkykham.Value = dgr.DataKeys[e.Item.ItemIndex].ToString();//
            hdIdBenhNhan.Value = e.CommandArgument.ToString();
            hdTenBenhNhan.Value = e.Item.Cells[3].Text;
            hdLoaiBN.Value = dtBN.Rows[0]["loai"].ToString();
            //LoadPhongNhap(hdIdchitietdangkykham.Value);
            string sqlDaCo = @"select *,ngay103=convert(varchar(10),ngayhentaikham,103),gio108=convert(varchar(5),ngayhentaikham,108) from nvk_hentaikham where idchitietdangkykham=" + hdIdchitietdangkykham.Value + " and isdataikham=0 order by idhentaikham desc";
            DataTable dtDaCo = DataAcess.Connect.GetTable(sqlDaCo);
            if (dtDaCo != null && dtDaCo.Rows.Count > 0)
            {
                txtNgayTaiKham.Text = dtDaCo.Rows[0]["ngay103"].ToString();
                txtGioTaiKham.Text = dtDaCo.Rows[0]["gio108"].ToString();
                txtGhiChuTaiKham.Text = dtDaCo.Rows[0]["GhiChuTaiKham"].ToString();
            }
            else
            {
                txtNgayTaiKham.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtGioTaiKham.Text = "08:00";//DateTime.Now.ToString("HH:mm");
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'block';", true);

            StaticData.SetFocus(this, "txtmachandoan_3");
        }
        else
            StaticData.MsgBox(this, "Vui lòng thử lại sau !");
        
    }
    public void DelBenhNhan(object s, DataGridCommandEventArgs e)
    {

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
    
    protected void ddlKhoaTaiKham_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    
    protected void btlydo_Click(object sender, EventArgs e)
    {
        string NgayTaiKham = StaticData.CheckDate(txtNgayTaiKham.Text.Trim()) + " " + txtGioTaiKham.Text.Trim();
        
        string sqlKB = @"select  top 1 * from khambenh where idchitietdangkykham=" + hdIdchitietdangkykham.Value + " order by idkhambenh desc";
        DataTable dtkb = DataAcess.Connect.GetTable(sqlKB);
        hdIdKhamBenh.Value = dtkb.Rows[0]["idkhambenh"].ToString();
        if (Request.QueryString["idkhoa"].ToString() == "15")
        {
        }
        else
        {
            string sqlNoiTru = @"select top 1 *,case when isnull((select top 1 idgiuong from benhnhannoitru where isnull(idgiuong,0)<>0 and  idchitietdangkykham =nt.idchitietdangkykham and idkhoanoitru=nt.idkhoanoitru),0)=0 then N'Xét giường'
            else N'Chuyển giường' end as ChucNang
            from benhnhannoitru nt where idchitietdangkykham=" + hdIdchitietdangkykham.Value + " and idkhoanoitru=" + Request.QueryString["idkhoa"] + @" order by idnoitru desc";
            DataTable dtNoiTru = DataAcess.Connect.GetTable(sqlNoiTru);
            if (dtNoiTru != null && dtNoiTru.Rows.Count > 0)
            {
                string sqlTonTai = "select * from nvk_HenTaiKHam where idchitietdangkykham=" + hdIdchitietdangkykham.Value + " and IdKhoaSeTaiKham=" + Request.QueryString["idkhoa"] + " and IsDaTaiKham=0  order by idhentaikham desc";
                DataTable dtTonTai = DataAcess.Connect.GetTable(sqlTonTai);
                string sqlIns = "";
                if (dtTonTai != null && dtTonTai.Rows.Count > 0)
                {
                    sqlIns = @" update NVK_HenTaiKham set NgayHenTaiKham='" + NgayTaiKham + "', GhiChuTaiKham=N'"+txtGhiChuTaiKham.Text+@"'
                                ,IdKhoaSeTaiKham='"+ddlKhoaTaiKham.SelectedValue+"' where idHenTaiKham='"+dtTonTai.Rows[0]["idHenTaiKham"]+"'";
                }
                else
                {
                    sqlIns = @"insert into NVK_HenTaiKham (
                    NgayTaoPhieuHen
                    ,NgayHenTaiKham
                    ,IdKhoaTaoPhieuHen
                    ,IdKhoaSeTaiKham
                    ,idchitietdangkykham
                    ,idbenhnhan
                    ,IsDaTaiKham
                    ,GhiChuTaiKham
                    )
                    values (
                    getdate()
                    ,'" + NgayTaiKham+@"'
                    ,'"+Request.QueryString["idkhoa"]+@"'
                    ,'"+ddlKhoaTaiKham.SelectedValue+@"'
                    ,'"+hdIdchitietdangkykham.Value+@"'
                    ,'"+dtkb.Rows[0]["idbenhnhan"]+@"'
                    ,'0'
                    ,N'" + txtGhiChuTaiKham.Text + @"'
                    )";
                }
                bool ktIns = DataAcess.Connect.ExecSQL(sqlIns);
                if (ktIns)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dfgw", "InPhieuHen('../khambenh/frm_Rpt_PhieuThanhToan.aspx?idchitietdangkykham=" + hdIdchitietdangkykham.Value + "');", true);
                    ImageButton1_Click(null, null);
                }
                else
                    StaticData.MsgBox(this,"Lỗi");
            }
            else
            {
                StaticData.MsgBox(this, "Bệnh nhân này chưa nhập khoa. Vui lòng nhập khoa trước !");
            }
        }
    }
}
