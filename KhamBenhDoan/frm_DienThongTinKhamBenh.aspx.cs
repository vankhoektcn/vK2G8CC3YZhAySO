using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DataAcess;
using SysParameter;

public partial class khambenh_frm_DienThongTinKhamBenh : System.Web.UI.Page
{
    private string GroupName;
    private string current_idBacSi;
    protected void Page_Load(object sender, EventArgs e)
    {
        current_idBacSi = UserLogin.IdBacSi(this);
        if (!IsPostBack)
        {
            txtNgayKham.Text = Connect.d_SystemDate().ToString("dd/MM/yyyy");
            loadPK();
            phongkham();
            LoadPhongKhamBenh();
            loadBS(ddlPK.SelectedValue);
        }
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
    private void LoadPhongKhamBenh()
    {
        string sql = "SELECT * FROM phongkhambenh WHERE idphongkhambenh <> " +
                     StaticData.ParseInt(Session["idphongkham"]) + " and loaiphong = 0";
        DataTable dt = Connect.GetTable(sql);
        //StaticData.FillCombo(ddlPhongKhamBenh, dt, "idphongkhambenh", "tenphongkhambenh", "--Chọn Khoa chuyển đến--");
        //StaticData.FillCombo(ddlKhoaNhapVien, dt, "idphongkhambenh", "tenphongkhambenh", "--Chọn Khoa Nhập viện--");
    }
    public void phongkham()
    {

        string sql = "";
        if (!string.IsNullOrEmpty(current_idBacSi))
        {
            sql = @"SELECT kb_p.Id,TenPhong=ISNULL(MASO +'-','')+ TENPHONG FROM kb_phong kb_p
                    inner join kb_phongkham kb_pk on kb_pk.phongid=kb_p.id
                    inner join bacsi bs on bs.idbacsi=kb_pk.idbacsi
                    ";
            sql += " where bs.idbacsi='" + current_idBacSi + "'";
        }
        else
        {
            sql = "SELECT Id,TenPhong=ISNULL(MASO +'-','')+ TENPHONG  FROM kb_phong ";
        }
        if (cbLoaiBN.SelectedValue != "0" && cbLoaiBN.SelectedValue!="")
        {
            if (cbLoaiBN.SelectedValue != "2")
            {
                sql += " AND LOAIBN=1";
            }
            else
            {
                sql += " AND LOAIBN=0";
            }
        }

        DataTable dt = Connect.GetTable(sql);
        StaticData.FillCombo(ddlphongkham, dt, "id", "tenphong", "-- Chọn Phòng Khám --");
        if (dt.Rows.Count > 0) ddlphongkham.SelectedIndex = 1;
    }
    private void loadPK()
    {
        string sql = "select * from phongkhambenh pk ";
        if (!string.IsNullOrEmpty(current_idBacSi))
        {
            sql +=
                "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where pk.loaiphong<>1 and   bspk.idbacsi=" +
                current_idBacSi + "";
        }
        else
        {
            sql += "where pk.loaiphong <> 1 order by pk.tenphongkhambenh";
        }
        DataTable dt = Connect.GetTable(sql);
        StaticData.FillCombo(ddlPK, dt, "idphongkhambenh", "tenphongkhambenh", "Chọn phòng/khoa");
        ddlPK.SelectedIndex = 0;
        if (ddlPK.Items.Count > 0)
        {
            ddlPK.SelectedIndex = 1;
        }
    }

    private void loadBS(string pk)
    {
        string sql = "";
        if (GroupName == "dieuduong")
        {
            sql = "select * from bacsi bs ";
            sql += "inner join bacsi_phongkham bspk on bspk.idbacsi = bs.idbacsi  where bspk.idphongkhambenh=" + pk +
                   " order by tenbacsi";
        }
        else
        {
            sql = "select * from bacsi bs ";
            if (!string.IsNullOrEmpty(current_idBacSi))
            {
                sql += "where idbacsi=  " + current_idBacSi + "";
            }
            else
            {
                sql += "inner join bacsi_phongkham bspk on bspk.idbacsi = bs.idbacsi  where bspk.idphongkhambenh=" + pk +
                       " order by tenbacsi";
            }
        }
        DataTable dt = Connect.GetTable(sql);
        StaticData.FillCombo(ddlBS, dt, "idbacsi", "tenbacsi", "Chọn bác sĩ");
        if (ddlBS.Items.Count > 0)
        {
            ddlBS.SelectedIndex = 1;
        }
        if (Request.QueryString["bs"] != null)
        {
            ddlBS.SelectedValue = Request.QueryString["bs"];
        }
    }
    protected void ddlnd_SelectedIndexChanged(object sender, EventArgs e)
    {
        phongkham();
    }
    protected void cbLoaiBN_SelectedIndexChanged(object sender, EventArgs e)
    {
        phongkham();
        if (txtLoaiBNhidden.Value != "")
        {
            return;
        }
    }
    protected void ddlnhomcls_SelectedIndexChanged(object sender, EventArgs e)
    {
        string idphongkhambenh = ddlnhomcls.SelectedValue;

        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "searchCLS(" + idphongkhambenh + ");", true);
    }
    protected void ddlPK_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}
