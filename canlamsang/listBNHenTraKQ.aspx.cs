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

public partial class canlamsang_listBNHenTraKQ : Genaratepage
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

            if (Session["dieutricls"] != null)
            {
                Session.Remove("dieutricls");
            }
            loadPK();
            loadBS(ddlPK.SelectedValue);
            SetValueEmpty();
            
            StaticData.SetFocus(this, "txtMaBenhNhan");
            txtTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            BindListBenhNhan("");
        }
    }

    private void loadPK()
    {

        string sql = "select * from phongkhambenh pk ";
        //if (SysParameter.UserLogin.IdBacSi(this) != "0" && SysParameter.UserLogin.IdBacSi(this) != "")
        //{
        //    sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where bspk.idbacsi=" + SysParameter.UserLogin.IdBacSi(this).ToString() + "";

        //}
        //else
        //{            
        //}
        sql += "where pk.loaiphong = 1 order by pk.tenphongkhambenh";
        DataTable dt = DataAcess.Connect.GetTable(sql);

        StaticData.FillCombo(ddlPK, dt, "idphongkhambenh", "tenphongkhambenh", "Chọn phòng/khoa");
        ddlPK.SelectedIndex = 0;
        if (ddlPK.Items.Count == 2)
        {
            ddlPK.SelectedIndex = 1;
        }
    }
    protected void ddlPK_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlPK.SelectedValue != "0")
        {
            loadBS(ddlPK.SelectedValue);
        }
    }
    private void loadBS(string pk)
    {
        DataTable dt;
        string sql = "select * from bacsi bs ";
        // if (SysParameter.UserLogin.IdBacSi(this) != null)
        //TRUONGNHAT-PC CAP NHAT LAI
        if (SysParameter.UserLogin.IdBacSi(this) != "0" && SysParameter.UserLogin.IdBacSi(this) != "")
        {
            sql += "where idbacsi=  " + SysParameter.UserLogin.IdBacSi(this).ToString() + "";
        }
        else if (pk != null)
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idbacsi = bs.idbacsi  where bspk.idphongkhambenh=" + pk + " order by tenbacsi";
        }
        else
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idbacsi = bs.idbacsi order by tenbacsi";
        }
        dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlBS, dt, "idbacsi", "tenbacsi", "Chọn bác sĩ");
        if (SysParameter.UserLogin.UserID(this) != null)
        {
            try
            {
                ddlBS.SelectedIndex = 1;
            }
            catch (Exception)
            {
            }
        }
    }
    #region "U Function"

    private void BindListBenhNhan(string sWhere)
    {
        int trangthai;
        string strSQL;
        //try
        //{
        //    trangthai = int.Parse(Request.QueryString["trangthai"].ToString());
        //     strSQL = "SELECT DISTINCT ph.IDPhieuHen,ph.ngayhen,bn.tenbenhnhan,bn.diachi,bn.mabenhnhan,bn.dienthoai,bn.ngaysinh,bs.tenbacsi ";
        //    strSQL += ",case when isnull(DaNhan,0)=1 then N'Đã nhận' else N'Chưa nhận' end as TrangThai";
        //    strSQL += " FROM phieuhen ph INNER JOIN benhnhan bn ON ph.idbenhnhan = bn.idbenhnhan inner join bacsi bs on bs.idbacsi=ph.idbacsi ";
        //    strSQL += " WHERE 1=1 and DaNhan=" + trangthai + " and idkhambenh=0 and ph.ngayhen >='" + StaticData.CheckDate(txtTuNgay.Text.Trim()) + "' and ph.ngayhen <='" + StaticData.CheckDate(txtDenNgay.Text.Trim()) + " 23:59:59" + "' " + sWhere;
        //}
        //catch
        //{
            strSQL = "SELECT DISTINCT ph.IDPhieuHen,ph.ngayhen,bn.tenbenhnhan,bn.diachi,bn.mabenhnhan,bn.dienthoai,bn.ngaysinh,bs.tenbacsi ";
            strSQL += ",case when isnull(DaNhan,0)=1 then N'Đã nhận' else N'Chưa nhận' end as TrangThai";
            strSQL += " FROM phieuhen ph INNER JOIN benhnhan bn ON ph.idbenhnhan = bn.idbenhnhan inner join bacsi bs on bs.idbacsi=ph.idbacsi ";
            strSQL += " WHERE 1=1  and ph.ngayhen >='" + StaticData.CheckDate(txtTuNgay.Text.Trim()) + "' and ph.ngayhen <='" + StaticData.CheckDate(txtDenNgay.Text.Trim()) + " 23:59:59" + "' " + sWhere;
        //}
       
        if (ddlBS.SelectedValue != "0")
        {
            strSQL += " and ph.idbacsi ="+ddlBS.SelectedValue+" ";
        }

        strSQL += " ORDER BY ph.ngayhen ";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);

        if (dtCTPhieu != null && dtCTPhieu.Rows.Count != 0)
        {
            dgr.DataSource = dtCTPhieu;
            dgr.DataBind();
            for (int i = 0; i < dtCTPhieu.Rows.Count; i++)
            {
                string test = dtCTPhieu.Rows[i]["TrangThai"].ToString();
                if (dtCTPhieu.Rows[i]["TrangThai"].ToString() == "Đã nhận")
                {
                    lblTotal.Text = "Tổng số BN đã nhận kết quả CLS : " + dtCTPhieu.Rows.Count + " BN";
                    lblHeader.Text = "DANH SÁCH PHIẾU HẸN ĐÃ TRẢ KQ CLS";
                }
                else if (dtCTPhieu.Rows[i]["TrangThai"].ToString() == "Chưa nhận")
                {
                    lblTotal.Text = "Danh sách bệnh nhân chờ lấy kết quả CLS : " + dtCTPhieu.Rows.Count + " BN";
                    lblHeader.Text = "DANH SÁCH BỆNH NHÂN CHỜ NHẬN PHIẾU HẸN KQ CLS";
                }
                else if (dtCTPhieu.Rows[i]["TrangThai"].ToString() == "Chưa nhận" || dtCTPhieu.Rows[i]["TrangThai"].ToString() == "Đã nhận")
                {
                    lblTotal.Text = "Tổng số phiếu CLS : " + dtCTPhieu.Rows.Count + " BN";
                    lblHeader.Text = "DANH SÁCH PHIẾU HẸN KQ CLS";
                }

            }
            if (dtCTPhieu.Rows.Count < 15)
                infospace.InnerHtml = "<p><p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>";
        }
    }

    private void SetValueEmpty()
    {
        txtMaBenhNhan.Text = "";
        txtTenBenhNhan.Text = "";
        txtDienThoai.Text = "";
        txtDiaChi.Text = "";
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
            StaticData.MsgBox(this, "Vui lòng chọn Khoa và Bác sĩ trước khi lấy danh sách!");
        }
    }
    private string GetChuoiSearch()
    {
       
        string skq = "";
        if (txtMaBenhNhan.Text != "")
        {
            skq += " AND bn.mabenhnhan = '" + txtMaBenhNhan.Text.Trim() + "' ";
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

        //iKey = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
        //string idkhambenh = ((Label)dgr.Items[e.Item.ItemIndex].FindControl("lblidkb")).Text;
        //iKey = iKey.Remove(iKey.Length - 1, 1);
        //Session["idkhambenhcls"] = iKey.ToString();
        //Session["idkb"] = idkhambenh;
        //Session["dieutricanlamsan"] = "0";
        //Session["themmoi"] = 1;
        //string idbs = ddlBS.SelectedValue;
        //Response.Redirect("thambenhentry.aspx?idbs=" + idbs + "");
    }
    public void DelBenhNhan(object s, DataGridCommandEventArgs e)
    {

    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnDel"));
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
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //e.Item.Cells[6].Text = Convert.ToDateTime(e.Item.Cells[6].Text).ToString("dd/MM/yyyy");
        }
    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {

        dgr.CurrentPageIndex = e.NewPageIndex;
        strSearch = GetChuoiSearch();
        BindListBenhNhan(strSearch);
    }
    #endregion

    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "in")
        {
           string iKey = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
           Response.Write("<script>window.open(\"PhieuHenKQ.aspx?idPH=" + iKey + "\",'_blank','location=no,menubar=no,resizable=yes,scrollbars=1,status=no,toolbar=no');</script>");
        }
        if (e.CommandName == "Status")
        {
            string idPhieuHen = System.Convert.ToString(dgr.DataKeys[e.Item.ItemIndex]);
            string sqlTest = "select DaNhan from phieuhen where idphieuhen="+idPhieuHen;
            string checkStatus = DataAcess.Connect.GetTable(sqlTest).Rows[0][0].ToString();
            if (checkStatus == "False" || checkStatus == "0" || checkStatus == "")
            {
                string sql = "update phieuhen set DaNhan=1 where idphieuhen =" + idPhieuHen;
                bool exc = DataAcess.Connect.ExecSQL(sql);
                if (exc == true)
                {
                    StaticData.MsgBox(this, "Cập nhật dữ liệu thành công");
                    strSearch = GetChuoiSearch();
                    BindListBenhNhan(strSearch);
                }
                else
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình cập nhật . Vui lòng kiểm tra lại!");
                }
            }
            else
            {
                StaticData.MsgBox(this, "Bệnh nhân này đã nhận rồi!");
                return;
            }
            
        }
    }
}
