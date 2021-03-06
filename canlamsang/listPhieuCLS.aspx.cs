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

public partial class canlamsang_listPhieuCLS : Genaratepage
{

    string strSearch;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SysParameter.UserLogin.FullName(this) == null)
        {
            Response.Redirect("javascript:window.close();");
        }
       
        if (!IsPostBack)
        {
            SetValueEmpty();
            loadBS();
            StaticData.SetFocus(this, "txtMaBenhNhan");
            bind_ddlthangnam();
            string ngaybt = ddl_nam.Text + "/" + ddl_thangbd.Text + "/" + ddl_ngaybd.Text;
            string ngaykt = ddl_nam.Text + "/" + ddl_thangkt.Text + "/" + ddl_ngaykt.Text;

            BindListBenhNhan("", ngaybt, ngaykt);
        }
        string dkmenu = "" + "";  if (Request.QueryString["dkmenu"]!=null &&  dkmenu == "")  dkmenu = Request.QueryString["dkmenu"].ToString();

        if (dkmenu == "kb")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
        }
        if (dkmenu == "thuphi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
        }
        if (dkmenu == "tiepnhan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        }
        if (dkmenu == "cls")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        }

    }
    private void loadBS()
    {
        string showBS = "select distinct * from bacsi bs inner join bacsi_phongkham bspk on bspk.idbacsi = bs.idbacsi where bspk.idphongkhambenh in (select idphongkhambenh from phongkhambenh where loaiphong=1)";
        if (SysParameter.UserLogin.UserID(this) != null)
        {
            showBS += " and bs.idbacsi = " + SysParameter.UserLogin.UserID(this).ToString() + "";
        }
        showBS += " order by tenbacsi ";
        DataTable dt = DataAcess.Connect.GetTable(showBS);
        StaticData.FillCombo(ddlBS, dt, "idbacsi", "tenbacsi", "Chọn bác sĩ");

        if (dt.Rows.Count == 1)
        {
            ddlBS.SelectedIndex = 1;
        }
    }
    private void bind_ddlthangnam()
    {
        DateTime dt = DataAcess.Connect.d_SystemDate();
        string key;
        ddl_nam.Items.AddRange(new ListItem[] { new ListItem(dt.Year.ToString()), new ListItem(Convert.ToString(dt.Year - 1)) });
        ddl_thangbd.SelectedIndex = dt.Month - 1;
        ddl_thangkt.SelectedIndex = dt.Month - 1;
        int songay = StaticData.GetSoNgay(dt.Month, dt.Year);
        //string a = "011".Substring(1, 2);
        for (int i = 1; i <= songay; i++)
        {
            key = "0" + i.ToString();
            key = key.Substring(key.Length - 2, 2);
            ddl_ngaybd.Items.Add(key);
            ddl_ngaykt.Items.Add(key);
        }
        ddl_ngaybd.SelectedIndex = dt.Day - 1;
        ddl_ngaykt.SelectedIndex = dt.Day - 1;
    }
    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }


    #region "U Function"

    private void BindListBenhNhan(string sWhere, string ngaybd, string ngaykt)
    {


        DataTable dtCTPhieu = new DataTable();
        string strSQL =
       ""
                    + " select  iddieutricanlamsan ,isnull(bn.idbenhnhan,bnK.idbenhnhan)as idbenhnhan," + "\r\n"
                    + " isnull(bn.mabenhnhan,bnK.mabenhnhan)as mabenhnhan," + "\r\n"
                    + " isnull(bn.tenbenhnhan,bnK.tenbenhnhan)as tenbenhnhan," + "\r\n"
                    + " isnull(bn.ngaysinh,bnK.ngaysinh)as ngaysinh," + "\r\n"
                    + " " + "\r\n"
                    + " isnull(dt.idkhambenhcanlamsan,0) as idkhambenh," + "\r\n"
                    + " dt.ngaykham" + "\r\n"
                    + " " + "\r\n"
                    + " from dieutricanlamsan dt left join benhnhan bn" + "\r\n"
                    + " on bn.idbenhnhan = dt.idbenhnhan" + "\r\n"
                    + " left join khambenh kb on kb.idkhambenh = dt.idkhambenhcanlamsan" + "\r\n"
                    + " left join benhnhan bnK on bnK.idbenhnhan = kb.idbenhnhan" + "\r\n"
                    + " " + "\r\n"
                    + " " + "\r\n";


        dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        if (dtCTPhieu != null && dtCTPhieu.Rows.Count > 0)
        {
            dgr.DataSource = dtCTPhieu;
            dgr.DataBind();
            lblTotal.Text = "Tổng số BN đã làm cls : " + dtCTPhieu.Rows.Count + " BN";
        }
        else
        {
            dgr.DataSource = "";
            dgr.DataBind();
        }


    }

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtDienThoai.Text = "";
        txtDiaChi.Text = "";
        ddlGioiTinh.SelectedIndex = 0;
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("benhnhannew.aspx");
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
        if (ddlBS.SelectedValue == "0")
        {
            StaticData.MsgBox(this,"Bạn chưa chọn Bác sĩ. Vui lòng kiểm tra lại");
        }
        else
        {
            strSearch = GetChuoiSearch();

            string ngaybt = ddl_nam.Text + "/" + ddl_thangbd.Text + "/" + ddl_ngaybd.Text;
            string ngaykt = ddl_nam.Text + "/" + ddl_thangkt.Text + "/" + ddl_ngaykt.Text;
            BindListBenhNhan(strSearch, ngaybt, ngaykt);
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
        if (txtDienThoai.Text != "")
        {
            skq += " AND bn.dienthoai LIKE '%" + txtDienThoai.Text.Trim() + "%' ";
        }
        if (txtDiaChi.Text != "")
        {
            skq += " AND bn.diachi LIKE N'%" + txtDiaChi.Text.Trim() + "%' ";
        }
        if (ddlGioiTinh.SelectedValue != "0" && ddlGioiTinh.SelectedValue != "")
        {
            skq += " AND bn.gioitinh = " + ddlGioiTinh.SelectedValue;
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
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        if (ddlBS.SelectedValue == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn Bác sĩ. Vui lòng kiểm tra lại");
        }
        else
        {
            int iddieutri;

            iddieutri = Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
            string idbs = ddlBS.SelectedValue;
            string idkb = ((Label)dgr.Items[e.Item.ItemIndex].FindControl("lbnIdKB")).Text;

            if (idkb == "0")
            {
                string idbn = ((Label)dgr.Items[e.Item.ItemIndex].FindControl("lbnIdBN")).Text;
                string idkbcls = ((Label)dgr.Items[e.Item.ItemIndex].FindControl("lbnIdKBCLS")).Text;
                Session["idbnCLS"] = idbn;
                Session["idDieutri"] = iddieutri;
                Session["idkhachlecanlamsan"] = idkbcls;
                Response.Redirect("dieutrikhachlecanlamsan.aspx?idbs=" + idbs );

            }
            else
            {
                Session["dieutricls"] = iddieutri;
                Session["idkb"] = idkb;

                Response.Redirect("thambenhentry.aspx?idbs=" + idbs );

            }
        }
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
        if (txtMaBenhNhan.Text == "")
        {
            string ngaybt = ddl_nam.Text + "/" + ddl_thangbd.Text + "/" + ddl_ngaybd.Text;
            string ngaykt = ddl_nam.Text + "/" + ddl_thangkt.Text + "/" + ddl_ngaykt.Text;
            BindListBenhNhan(strSearch, ngaybt, ngaykt);

        }
        else
        {
            BindListBenhNhan(strSearch, null, null);
        }

        stt = e.NewPageIndex * dgr.PageSize + 1;

    }
    #endregion

    protected void InHoaDon(object source, DataGridCommandEventArgs e)
    {

    }
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string idDV = ((Label)dgr.Items[e.Item.ItemIndex].FindControl("lblIDDichVu")).Text;
            //Page page = HttpContext.Current.Handler as Page;
            //ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "showDetailDV(" + idDV + ");", true);
        }
    }
}
