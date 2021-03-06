using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using System.Data.SqlClient;

public partial class frm_DS_ThuocSapHetHan : Genaratepage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
             
        if (!IsPostBack)
        {
            bindkho();
            txtsongay.Text = StaticData.GetParaValueDB("SoNgayCanDate");
            BindGrid();
            
        }
    }
    #region bind kho
    private void bindkho()
    {
        DataTable dt = StaticData.dtGetKho(this, false);
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddlkho, dt, "idkho", "tenkho", "-------------Chọn kho------------");
            ddlkho.SelectedValue = StaticData.MacDinhKhoNhapMuaID;
        }
    }

    #endregion
    #region Not Used
    #region Grid Event

    public void dgr_Sort(System.Object Sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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
            e.Item.Cells[3].Text = (e.Item.Cells[3].Text == "&nbsp;" ? "" : Convert.ToDateTime(e.Item.Cells[3].Text).ToString("dd/MM/yyyy"));
            e.Item.Cells[5].Text = (e.Item.Cells[5].Text == "&nbsp;" ? "" : Convert.ToDateTime(e.Item.Cells[5].Text).ToString("dd/MM/yyyy"));
            e.Item.Cells[6].Text = (e.Item.Cells[6].Text == "" ? "" : StaticData.FormatNumber(e.Item.Cells[6].Text, false).ToString());            
        }

    }
    public void Edit(object s, DataGridCommandEventArgs e)
    {
      
    }

    public void DelPhieuNhap(object s, DataGridCommandEventArgs e)
    {
       
    }


    public void BindData(DataTable dtSRC)
    {
        DataView dvSource = dtSRC.DefaultView;
        dvSource.AllowEdit = true;
        dvSource.AllowNew = true;
        dgr.DataSource = dvSource;
        dgr.DataBind();
    }
   

    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgr.CurrentPageIndex = e.NewPageIndex;
        BindGrid();
    }
   
    #endregion      
   
    private void form_unload(object sender, System.EventArgs e)
    {
        
    }

    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(form_unload);
    }
    #endregion
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnXem_ServerClick(object sender, EventArgs e)
    {
        this.BindGrid();
    }
    #endregion
    public void BindGrid()
    {
      if(this.txtsongay.Text=="")this.txtsongay.Text="0";

        DataTable tTable = new DataTable();
        string CommandText = @"SELECT A.idchitietphieunhapkho,
                                  C.tenthuoc,
                                  C.congthuc,
	                              D.TENDVT,
                                  NGAYNHAP=B.NGAYTHANG,
                                  A.ngayhethan,
                                  A.losanxuat,
                                  SOLUONGTON=A.soluong-ISNULL((SELECT sum(soluong) FROM chitietphieuxuatkho WHERE IDCHITIETPHIEUNHAPKHO=A.idchitietphieunhapkho ),0)

                            FROM chitietphieunhapkho A
                            LEFT JOIN phieunhapkho B ON A.IDPHIEUNHAP=B.IDPHIEUNHAP
                            LEFT JOIN thuoc C ON A.idthuoc=C.idthuoc
                            LEFT JOIN Thuoc_DonViTinh D ON C.iddvt=D.Id
                            WHERE B.idkho="+this.ddlkho.SelectedValue.ToString()+ @"
                                   and A.soluong-isnull((SELECT sum(soluong) FROM chitietphieuxuatkho WHERE IDCHITIETPHIEUNHAPKHO=A.idchitietphieunhapkho ),0)>0
                                   AND convert(INT,A.ngayhethan-getdate())<=" + this.txtsongay.Text
                            +@" ORDER BY C.TENTHUOC,B.NGAYTHANG";

        tTable = DataAcess.Connect.GetTable(CommandText);
        DataView dvSource = tTable.DefaultView;
        dvSource.AllowEdit = true;
        dvSource.AllowNew = true;

        dgr.DataSource = dvSource;
        dgr.DataBind();
       // if (tTable.Rows.Count < 15)
          //  infospace.InnerHtml = "<p><p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;<p>&nbsp;";
    }
    
}
