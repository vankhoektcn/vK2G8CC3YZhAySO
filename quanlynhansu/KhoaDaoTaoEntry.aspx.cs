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

public partial class KhoaDaoTaoEntry : System.Web.UI.Page
{
   static string strSearch="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTuNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
            txtDenNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
            BindListKhoaDaoTao("");
            VisibleBtn(true);
        }
    }

    private void BindListKhoaDaoTao(string sWhere)
    {
        //DataAcess.Connect.NewConnect("mayso4", "NhanSu", "sa", "123");MinhDucDB1306201106
        string strSQL = "select ROW_NUMBER ( ) OVER(ORDER BY tungay) AS STT,*,case when nopvanbang='true' then 'Có' else 'Không' end as vanbang  from khoadaotao where status='true' " + sWhere;
        strSQL +=" order by tungay ";
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        dgr.DataSource = dtCTPhieu;
        dgr.DataBind();
    }
    private DataTable LoaDdataEdit(int iidchucvu)
    {
        string strSQL = "SELECT p.* FROM khoadaotao p WHERE status=1 and idkhoadaotao = " + iidchucvu;
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        return dt;
    }
    private void SetValueEditPC(DataTable dtSRC)
    {
        txtMucDDT.Value = dtSRC.Rows[0]["mucdichdaotao"].ToString();
        txtDiaDiem.Value = dtSRC.Rows[0]["diadiem"].ToString();
        txtTuNgay.Value = DateTime.Parse(dtSRC.Rows[0]["tungay"].ToString()).ToString("dd/MM/yyyy");
        txtDenNgay.Value = DateTime.Parse(dtSRC.Rows[0]["denngay"].ToString()).ToString("dd/MM/yyyy");
        txtHocPhi.Value = dtSRC.Rows[0]["hocphi"].ToString();
        txtCtyTra.Value = dtSRC.Rows[0]["ctytra"].ToString();
        txtNVTra.Value = dtSRC.Rows[0]["nvtra"].ToString();
        if (dtSRC.Rows[0]["nopvanbang"].ToString() == "true")
            cbVanBang.Checked = true;
        txtGhiChu.Value = dtSRC.Rows[0]["ghichu"].ToString();
        StaticData.SetFocus(this, "txtMucDDT");
    }
    #region "Grid Event"
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

    public void DelKhoaDaoTao(object s, DataGridCommandEventArgs e)
    {
        int imaphong=0;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        //string sqlDelete = "delete from khoadaotao where idkhoadaotao=" + imaphong;
        string sqlDelete = "update khoadaotao set status=0 where idkhoadaotao=" + imaphong;        
        bool kt = DataAcess.Connect.ExecSQL(sqlDelete);
        if (kt)
        {
            StaticData.MsgBox(this, "Đã xóa !");
            BindListKhoaDaoTao(strSearch);

        }
        else
            StaticData.MsgBox(this, "Có lỗi khi xóa !");
    }
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        int imaphong;
        Label lbVB;
        imaphong = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        lbVB = (Label)(e.Item.Cells[0].FindControl("lbVanBang"));
        txtmaphieu.Value = imaphong.ToString();
        DataTable dtEdit = LoaDdataEdit(imaphong);
        SetValueEditPC(dtEdit);
        if (lbVB.Text.Trim() == "Có")
            cbVanBang.Checked = true;
        VisibleBtn(false);
    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindListKhoaDaoTao(strSearch);
    }
    #endregion
    #region "Các hàm kiểm tra"
    private bool CheckValid(int isadd)
    {
        if (txtMucDDT.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập mục đích khóa đào tạo. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtMucDDT");
            return false;
        }
        if (txtDiaDiem.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập địa điểm đào tạo. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtDiaDiem");
            return false;
        }
        if (txtHocPhi.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập học phí. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtHocPhi");
            return false;
        }
        if (txtCtyTra.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập số tiền Cty trả. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtCtyTra");
            return false;
        }
        if (txtNVTra.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập Nhân viên trả. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtNVTra");
            return false;
        }
        if (txtTuNgay.Value == "" || StaticData.CheckDate(txtTuNgay.Value) == "")
        {
            StaticData.MsgBox(this, "Ngày tháng không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtTuNgay");
            return false;
        }
        if (txtDenNgay.Value == "" || StaticData.CheckDate(txtDenNgay.Value) == "")
        {
            StaticData.MsgBox(this, "Ngày tháng không hợp lệ. Vui lòng kiểm tra lại.");
            StaticData.SetFocus(this, "txtDenNgay");
            return false;
        }
        return true;
    }
    public void SetValueEmpty()
    {
        txtMucDDT.Value = "";
        txtDiaDiem.Value = "";
        txtTuNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
        txtDenNgay.Value = DateTime.Now.ToString("dd/MM/yyyy");
        txtHocPhi.Value = "";
        txtCtyTra.Value = "";
        txtNVTra.Value = "";
        txtGhiChu.Value = "";
        strSearch = "";
        cbVanBang.Checked = false;
        VisibleBtn(true);
    }
    private void VisibleBtn(bool bl)
    {
        btnAdd.Visible = bl;
        btnEdit.Visible = !bl;
    }
    #endregion
    #region "Các hàm xử lý"
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(0))
        {
           
                
                //Lấy id 
            int id = StaticData.ParseInt(DataAcess.Connect.GetTable("select isnull(max(idkhoadaotao),0)+1 as MaxID from khoadaotao ").Rows[0][0].ToString());
                //thêm chức vụ
            string nopvanBang = "0";
            if (cbVanBang.Checked)
                nopvanBang = "1";
            NhanSu_Process.KhoaDaoTao KDT = NhanSu_Process.KhoaDaoTao.Insert_Object(id.ToString(), txtMucDDT.Value.Trim(), txtDiaDiem.Value.Trim(), StaticData.CheckDate(txtTuNgay.Value.Trim()), StaticData.CheckDate(txtDenNgay.Value.Trim()), txtHocPhi.Value.Replace(",", "").Replace(".", ""), txtCtyTra.Value.Replace(",", "").Replace(".", ""), txtNVTra.Value.Replace(",", "").Replace(".", ""), nopvanBang, txtGhiChu.Value, "1");
                if (KDT == null)
                {
                    StaticData.MsgBox(this, "Có lỗi xảy ra trong quá trình lưu thông tin khóa đào tạo. Vui lòng kiểm tra lại.");
                    return;
                }
                else
                {
                    StaticData.MsgBox(this, "Lưu thành công!.");
                    BindListKhoaDaoTao("");
                    SetValueEmpty();
                    StaticData.SetFocus(this, "txtMucDDT");
                }
            
            

        }
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (CheckValid(1))
        {
            int imahh = StaticData.ParseInt(txtmaphieu.Value);
            NhanSu_Process.KhoaDaoTao CV = new NhanSu_Process.KhoaDaoTao();
            CV.idkhoadaotao = imahh.ToString();
            string tuNgay=StaticData.CheckDate(txtTuNgay.Value.Trim());
            string denNgay=StaticData.CheckDate(txtDenNgay.Value.Trim());
            string nopvnbang = "0";
            if (cbVanBang.Checked)
                nopvnbang = "1";
            bool kt = CV.Save_Object(imahh.ToString(), txtMucDDT.Value.Trim(), txtDiaDiem.Value.Trim(),tuNgay,denNgay,txtHocPhi.Value.Replace(",","").Replace(",",""),txtCtyTra.Value.Replace(",","").Replace(",",""),txtNVTra.Value.Replace(",","").Replace(",",""),nopvnbang,txtGhiChu.Value,"1");
            if (kt)
            {
                StaticData.MsgBox(this, "Cập nhật thông tin khóa đào tạo thành công.");
                BindListKhoaDaoTao("");
                SetValueEmpty();
            }
            else
                StaticData.MsgBox(this, "Có lỗi khi cập nhật !");
            StaticData.SetFocus(this, "txtmachucvu");

        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        SetValueEmpty();
    }
    protected void btnTim_Click(object sender, ImageClickEventArgs e)
    {

        strSearch = "";
        if (txtMucDDT.Value.Trim() != "")
            strSearch = " and mucdichdaotao like N'%" + txtMucDDT.Value.Trim() + "%' ";
        if (txtDiaDiem.Value.Trim() != "")
            strSearch += " and diadiem like N'%" + txtDiaDiem.Value.Trim() + "%' ";
        if (txtGhiChu.Value.Trim() != "")
            strSearch += " and ghichu like N'%" + txtGhiChu.Value.Trim() + "%' ";
        if (txtTuNgay.Value.Trim() != "")
            strSearch += " and tungay >='" + StaticData.CheckDate(txtTuNgay.Value.Trim()) + " 00:00:00'";
        if (txtDenNgay.Value.Trim() != "")
            strSearch += " and denngay <='" + StaticData.CheckDate(txtDenNgay.Value.Trim()) + " 23:59:59'";
        if (cbVanBang.Checked)
            strSearch += " and nopvanbang='true'";
        BindListKhoaDaoTao(strSearch);
    }

    #endregion
    protected void btnEcel_Click(object sender, ImageClickEventArgs e)
    {
        string filename = "DSKhoaDT";
        string tcty = "BỆNH VIỆN MINH ĐỨC";
        string khoa = "Phòng Nhân Sự";
        string header = "DANH SÁCH KHÓA ĐÀO TẠO";
        string strNhanSu = "GĐ.Nhân Sự";
        clsExport.exprortToExcelDataGrid(filename, tcty, khoa, header, dgr, strNhanSu);
    }
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "ChiTiet")
            Response.Redirect("dangkykhoadaotao.aspx?idkhoadaotao="+dgr.DataKeys[e.Item.ItemIndex]);
            //ScriptManager.RegisterStartupScript(Page,Page.GetType(),"openchitietdangkykhoaDT","window.location.href=''",true);
    }
}
