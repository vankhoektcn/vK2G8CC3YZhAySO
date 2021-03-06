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

public partial class nvk_DS_PhieuYCTra : Genaratepage
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
          
            txtTuNgay.Text = DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
            this.txtDenNgay.Text = this.txtTuNgay.Text;
            bindkho();
            LoaDSPhieuYC(GetChuoiSearch());
           
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
   protected void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        
        //bool OK = (Userlogin_new.HavePermision(this, "XuatTheoYC") || SysParameter.UserLogin.IsAdmin(this));
        e.Item.Cells[0].Visible = false;//OK;
                //if (e.Item.Cells[7].Text == "ĐÃ TRẢ")
                //    e.Item.Cells[0].Text = "";
         //string listName = Request.QueryString["list"];
         //if (  listName == "1")
         //           e.Item.Cells[7].Visible = true;
         //else
         //           e.Item.Cells[7].Visible = false ;
    }
    #endregion
    #region LoaDSPhieuYC
    private void LoaDSPhieuYC(string sqlSelect)
    {
        string strSQL = sqlSelect;
        
        DataTable dtCTPhieu = DataAcess.Connect.GetTable(strSQL);
        if (dtCTPhieu != null )
        {
            dgr.DataSource = dtCTPhieu;
            dgr.DataBind();
        }
    }
    #endregion
    #region LayDS _click
    protected void btnGetList_Click(object sender, EventArgs e)
    {
        string strSearch = GetChuoiSearch();
        LoaDSPhieuYC(strSearch);
    }
#endregion
    #region GetChuoiSearch
    private string GetChuoiSearch()
    {

        string skq = @"
                select STT= Row_number() over(order by NgayYC),IdPhieuYC=yct.IdPhieuYCtra
                ,NgayYC,SoPhieu,TenNguoiYeuCau=TenNguoiDung,TenKho,
                ghichu,TrangThai=DBO.THUOC_TrangThaiPhieuYCTra(yct.IdPhieuYCtra) 
                from NVK_Thuoc_PhieuYCTra yct
                left join KhoThuoc kt on kt.IdKHo=yct.idphongkhambenh
                left join NGUOIDUNG nd on nd.IDNGUOIDUNG=yct.IDNGUOIYC
                where 1=1 and kt.idkhoa="+Request.QueryString["idkhoa"]+@" and DBO.THUOC_TrangThaiPhieuYCTra(yct.IdPhieuYCtra)=N'ĐÃ TRẢ'   ";
        string listName = Request.QueryString["list"];
       // if (listName != "1")
         //   skq += "  AND  DBO.THUOC_ISDAXUAT(A.IdPhieuYC)=1" + "\r\n";

        if (txtTuNgay.Text != "")
        {
            string TuNgay = StaticData.CheckDate(txtTuNgay.Text.Trim());
            skq += " AND NgayYC >= '" + TuNgay + "'";
        }
        if (txtDenNgay.Text != "")
        {
            string DenNgay = StaticData.CheckDate(txtDenNgay.Text.Trim()) + " 23:59:59";
            skq += " AND  NgayYC <='" + DenNgay + "'";
        }
        if (ddlKhoThuoc.SelectedValue != "0" && ddlKhoThuoc.SelectedValue != "")
        {
            skq += " AND yct.IdPhongKhamBenh = " + ddlKhoThuoc.SelectedValue;
        }
        
        return skq;
    }
    #endregion
    #region BindCTPhieu
    private void BindCTPhieu(DataTable dtSRC)
    {
        if (dtSRC == null) return;
        dgr.DataSource = dtSRC;
        dgr.DataBind();
    }
    #endregion
    #region "Grid Event"
    private DataTable dtGetSource(int  IdPhieuXuat ,ref double Tongtien)
    {
        int iKey;
        iKey = IdPhieuXuat;
        int VAT = 0;
        #region Xac nhan

        DataTable dtXuat = new DataTable();
        string stemp = "";
        Type tTemp = stemp.GetType();
        double dtemp = 0;
        Type tdTemp = dtemp.GetType();

        dtXuat.Columns.Add("STT", tTemp);
        dtXuat.Columns.Add("TenThuoc", tTemp);
        dtXuat.Columns.Add("congthuc", tTemp);
        dtXuat.Columns.Add("SoLuong", tTemp);
        dtXuat.Columns.Add("SLXuat", tTemp);
        dtXuat.Columns.Add("GiaBan", tdTemp);
        dtXuat.Columns.Add("ChietKhau", tTemp);
        dtXuat.Columns.Add("TTTT", tdTemp);
        dtXuat.Columns.Add("SoTien", tdTemp);
        dtXuat.Columns.Add("idthuoc", tTemp);
        dtXuat.Columns.Add("IdChiTietPhieuYC", tTemp);
        dtXuat.Columns.Add("SLTon", tTemp);
        dtXuat.Columns.Add("idchitietbenhnhantoathuoc", tTemp);

        string sysDate = DataAcess.Connect.s_SystemDate();

        string idkho = StaticData.MacDinhKhoNhapMuaID;

        string sql = "select t.idthuoc,IdChiTietPhieuYC=ct.IdChiTietPhieuYCtra,t.tenthuoc,t.congthuc, t.donvitinh,t.iddvt,ThanhTienTruocThue=0, ThanhTien=0 ,";
        sql += "  ct.soluong,SL_Ton=DBO.Thuoc_TonKho_new_1910( CT.IDTHUOC, GETDATE() ," + idkho + " ), "
        + " GiaBan= dbo.Thuoc_TinhGiaXuat2 (ct.idthuoc ,'" + sysDate + "', 1 ," + idkho + " ),kctyc.idchitietbenhnhantoathuoc";
        sql += " from NVK_Thuoc_chitietPhieuYCTra ct left join thuoc t  on ct.idthuoc = t.idthuoc ";
        sql += " inner join NVK_Thuoc_ChiTietYCTra_bntt kctyc on kctyc.idchitietphieuyctra=ct.idchitietphieuyctra  ";
        sql += " where kctyc.isdatra<>1 and T.IDTHUOC IS NOT NULL AND T.IDTHUOC <>0 AND  ct.IdPhieuYCtra = " + iKey.ToString();
        DataTable listthuoc = DataAcess.Connect.GetTable(sql);
          Tongtien = 0;
        for (int i = 0; i < listthuoc.Rows.Count; i++)
        {
            if (listthuoc.Rows[i]["GiaBan"].ToString() == "")
                listthuoc.Rows[i]["GiaBan"] = "0";
            DataRow R_Xuat = dtXuat.NewRow();
            R_Xuat["STT"] = i + 1;
            R_Xuat["TenThuoc"] = listthuoc.Rows[i]["tenthuoc"].ToString();
            R_Xuat["Soluong"] = listthuoc.Rows[i]["soluong"].ToString();
            R_Xuat["GiaBan"] = listthuoc.Rows[i]["GiaBan"].ToString();
            R_Xuat["ChietKhau"] = "0";
            R_Xuat["congthuc"] = listthuoc.Rows[i]["congthuc"].ToString();
            R_Xuat["idthuoc"] = listthuoc.Rows[i]["idthuoc"].ToString();
            R_Xuat["IdChiTietPhieuYC"] = listthuoc.Rows[i]["IdChiTietPhieuYC"].ToString();
            R_Xuat["SLTon"] = listthuoc.Rows[i]["SL_Ton"].ToString();
            R_Xuat["idchitietbenhnhantoathuoc"] = listthuoc.Rows[i]["idchitietbenhnhantoathuoc"].ToString();
            //int SlXuat = 0;
            //string sGiaBan = listthuoc.Rows[i]["GiaBan"].ToString();
            //if (sGiaBan == "") sGiaBan = "0";
            //float GiaBan = float.Parse(sGiaBan);
            //string sCK = "0";
            //if (sCK == "") sCK = "0";
            //int chietkhau = int.Parse(sCK);
            //double TTXuat = 0;
            //double TTXuat_TT = 0;
            //string idthuoc = listthuoc.Rows[i]["idthuoc"].ToString();
            //if (idthuoc == "") idthuoc = "0";
            //string sqldspn = " select A.* ,soluongton=(A.soluong- DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)  ) from chitietphieunhapkho A";
            //sqldspn += " left join phieunhapkho B on A.idphieunhap=B.idphieunhap";
            //sqldspn += " where  B.IDKHO=" + idkho + " AND   idthuoc=" + idthuoc;
            //sqldspn += " and A.soluong>DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)";
            //sqldspn += " and B.ngaythang<=" + "'" + sysDate + "'";
            //sqldspn += " order by A.ngayhethan";
            //int m = 0;
            //int n = StaticData.ParseInt(listthuoc.Rows[i]["soluong"].ToString());
            //DataTable dtthuoc = DataAcess.Connect.GetTable(sqldspn);
            //if (dtthuoc != null && dtthuoc.Rows.Count != 0)
            //{
            //    for (int j = 0; idthuoc != "" && j < dtthuoc.Rows.Count; j++)
            //    {
            //        int slt = StaticData.ParseInt(dtthuoc.Rows[j]["soluongton"].ToString());
            //        if (n >= slt) m = slt;
            //        else
            //            m = n;
            //        SlXuat += m;

            //        double thanhtien = (double)m * GiaBan;
            //        double thanhtientruocthue = (double)thanhtien * ((100.0 - chietkhau) / 100);
            //        double ThanhTienSauThue = thanhtientruocthue * ((100.0 + VAT) / 100);
            //        Tongtien += ThanhTienSauThue;
            //        TTXuat += ThanhTienSauThue;
            //        TTXuat_TT += thanhtientruocthue;
            //        if (n - slt < 0) break;
            //        else n -= slt;
            //    }//end for 1.1
            //}
            //TTXuat = Math.Round(TTXuat, 0);
            //TTXuat_TT = Math.Round(TTXuat_TT, 0);
            //R_Xuat["SLXuat"] = SlXuat;
            //R_Xuat["SLXuat1"] = SlXuat;
            //R_Xuat["SoTien"] = TTXuat;
            //R_Xuat["TTTT"] = TTXuat_TT;
            dtXuat.Rows.Add(R_Xuat);

        }   //end for 1
        return dtXuat;
        #endregion
    }
     
    protected void Dongy_Click(object sender, EventArgs e)
    {
        string ListIdChiTietBenhNhanToaThuoc = "0";
        for (int i = 0; i < grid.Rows.Count; i++)
        {
            ListIdChiTietBenhNhanToaThuoc = grid.DataKeys[i].Value.ToString().TrimStart(',').TrimEnd(',');
            string SoLuongMoi =((TextBox)this.grid.Rows[i].Cells[3].FindControl("Soluong")).Text;
            //try
            //{
                string sqlTop = "select top 1 * from  chitietphieuxuatkho where  idchitietbenhnhantoathuoc in (" + ListIdChiTietBenhNhanToaThuoc + ")";
                string idPXTop1 = DataAcess.Connect.GetTable(sqlTop).Rows[0]["idchitietphieuxuat"].ToString();
                string Del = @"delete from chitietphieuxuatkho where idchitietbenhnhantoathuoc in(" + ListIdChiTietBenhNhanToaThuoc + ") and idchitietphieuxuat <> " + idPXTop1 + "";
                bool ktDel = DataAcess.Connect.ExecSQL(Del);
                string sqlSLXuatNew = @"
            select SoLuongXuatMoi= isnull(
	            (
		            select sum(slxuat) from thuoc_chitietPhieuYCXuat where idchitietphieuYC in
		            (select idchitietphieuYC from NVK_Thuoc_ChiTietYCXuat where idchitietbenhnhantoathuoc in(" + ListIdChiTietBenhNhanToaThuoc + @")
		            ) --group by idthuoc
	            )
            ,0)
            -  isnull(
            (
	            select sum(slNhan) from nvk_thuoc_chitietphieuYCtra where idchitietphieuYCtra in
	            (select idchitietphieuYCtra from nvk_thuoc_chitietYCtra_BNTT where idchitietbenhnhantoathuoc in(" +ListIdChiTietBenhNhanToaThuoc+@")
	            )-- group by idthuoc	
            )
            ,0)";
                DataTable dtSLXuatNew = DataAcess.Connect.GetTable(sqlSLXuatNew);
                if (dtSLXuatNew != null && dtSLXuatNew.Rows.Count > 0)
                    SoLuongMoi = dtSLXuatNew.Rows[0]["SoLuongXuatMoi"].ToString();
                else if (SoLuongMoi.Equals("") || SoLuongMoi.Equals("0"))
                    SoLuongMoi = "0";
                string Up = @"update chitietphieuxuatkho set soluong=" + SoLuongMoi + " where idchitietphieuxuat = " + idPXTop1 + "";
                bool ktUpdate = DataAcess.Connect.ExecSQL(Up);
                if (ktUpdate)
                {
                    string sqlUD = "update NVK_Thuoc_ChiTietYCTra_bntt set isdatra='1' where idchitietbenhnhantoathuoc in (" + ListIdChiTietBenhNhanToaThuoc + " )";
                    ktUpdate= DataAcess.Connect.ExecSQL(sqlUD);
                }
            //}
            //catch (Exception ex)
            //{
            //    continue;
            //}
            //}
        }
    }
    #endregion
    #region bindkho
    private void bindkho()
    {
        DataTable dt = DataAcess.Connect.GetTable("select * from khothuoc where idkhoa ="+Request.QueryString["idkhoa"]+"");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddlKhoThuoc, dt, "idkho", "tenkho", "Chọn kho");
        }
    }
     #endregion
    #region Hiển thị chi tiết
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        int idPhieuxuat = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
        Session["idPhieuxuat"] = idPhieuxuat;
        if (e.CommandName.ToLower() == "edit")
        {
            double Tongtien = 0;
            DataTable dtXuat = dtGetSource(idPhieuxuat, ref Tongtien);
            grid.DataSource = dtXuat;
            grid.DataBind();
            string tt = Math.Floor(Math.Round(Tongtien)).ToString();
            // tongtien.Text = StaticData.FormatNumber(tt, false).ToString();
            //   lbchuy.Text = new clsDocSoTien().ReadNumToString(tt);
            ScriptManager.RegisterStartupScript(Page, GetType(), "", "document.getElementById('divgrid').style.display='block';", true);
        }
        else
        {
            OpenLink("frm_PhieuBNTraThuoc.aspx?dkmenu="+Request.QueryString["dkmenu"]+"#idkhoachinh=" + idPhieuxuat+"&xemThoi=1&Update=1&NgayYeuCauSua="+e.Item.Cells[4].Text+"");
        }
    }

    private void OpenLink(string LinkName)
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + LinkName + "\",'_blank')</script>");

    }
    #endregion

}
