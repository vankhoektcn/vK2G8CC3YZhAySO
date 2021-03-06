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
using System.Text ;

public partial class frm_DS_PhieuYCXuatKho : Genaratepage
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.GetPostBackEventReference(this, string.Empty);
        if (!IsPostBack)
        {

            txtTuNgay.Text = DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
            this.txtDenNgay.Text = this.txtTuNgay.Text;
            bindkho();
            LoaDSPhieuYC(GetChuoiSearch());            
        }
    }
    protected void AfterUserConfirmationHandler()
    {
        //Do your stuff here which you want to do when the user has confirmed the action
        nvk_hd_IsCanhBao.Value = "1";
    }

    protected void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        bool OK = (Userlogin_new.HavePermision(this, "XuatTheoYC") || SysParameter.UserLogin.IsAdmin(this));
        e.Item.Cells[0].Visible = OK;
        if (e.Item.Cells[7].Text == "ĐÃ XUẤT")
            e.Item.Cells[0].Text = "";
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
        if (dtCTPhieu != null)
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
        string sqlIdkhoIn = "";
        if (ddlKhoThuoc.SelectedValue != "0" && ddlKhoThuoc.SelectedValue != "")
        {
            sqlIdkhoIn = "AND A.IdPhongKhamBenh = " + ddlKhoThuoc.SelectedValue;
            string sqlNVKLoaiKho = "select nvk_loaikho,idkhoa from khothuoc where idkho=" + ddlKhoThuoc.SelectedValue;
            DataTable dtNVK = DataAcess.Connect.GetTable(sqlNVKLoaiKho);

            if (dtNVK.Rows[0]["nvk_loaikho"].ToString().Equals("2"))
            {
                string idKhoTT = "0";
                string idKhoAo = "0";
                try
                {
                    idKhoTT = DataAcess.Connect.GetTable("select idkho from khothuoc where idkhoa=" + dtNVK.Rows[0]["idkhoa"] + " and nvk_loaikho=2").Rows[0]["idkho"].ToString();
                    idKhoAo = DataAcess.Connect.GetTable("select idkho from khothuoc where idkhoa=" + dtNVK.Rows[0]["idkhoa"] + " and nvk_loaikho=3").Rows[0]["idkho"].ToString();
                }
                catch (Exception)
                {
                    
                    throw;
                }
                DataTable dtKhoAo_TT= DataAcess.Connect.GetTable("select idkho from khothuoc where idkhoa=" + dtNVK.Rows[0]["idkhoa"] + " and nvk_loaikho in (2,3)");
                string ListIdKhoAo_TT = "0";
                for(int i=0;i<dtKhoAo_TT.Rows.Count;i++)
                {
                    ListIdKhoAo_TT +=dtKhoAo_TT.Rows[i]["idkho"].ToString() +",";
                }
                ListIdKhoAo_TT = ListIdKhoAo_TT.TrimEnd(',');
                if (idKhoTT != null && !idKhoTT.Equals(""))
                {
                    //sqlIdkhoIn = "AND A.IdPhongKhamBenh in('" + idKhoAo + "','" + idKhoTT + "')";
                    sqlIdkhoIn = "AND A.IdPhongKhamBenh in("+ListIdKhoAo_TT+")";
                }
            }
        }
        string skq = ""
                + " select STT= Row_number() over(order by NgayYC) , IdPhieuYC," + "\r\n"
                + " NgayYC," + "\r\n"
                + " SoPhieu," + "\r\n"
                + " TenNguoiYeuCau=TenNguoiDung," + "\r\n"
                + " TenKho," + "\r\n"
                + @" ghichu
                ,TrangThai=case DBO.THUOC_ISDAXUAT(A.IdPhieuYC) when 0 then N'CHƯA XUẤT' when 1 then N'Đang treo' when 2 then N'Treo(đã YC lại)'
                when 3 then N'ĐÃ DUYỆT' END
                ,case DBO.THUOC_ISDAXUAT(A.IdPhieuYC) when 0 then N'Xuất thuốc' when 1 THEN N'Xuất treo'
                    else '' end as tinhtrangXuat                
                    " + "\r\n"
                + " from Thuoc_PhieuYCXuat a" + "\r\n"
                + " left join KhoThuoc B ON A.idphongkhambenh=B.IdKHo" + "\r\n"
                + " LEFT JOIN NGUOIDUNG C ON A.IDNGUOIYC=C.IDNGUOIDUNG" + "\r\n"
                + " where 1=1  " + "\r\n";
        string listName = Request.QueryString["list"];
        // if (listName != "1")
        //   skq += "  AND  DBO.THUOC_ISDAXUAT(A.IdPhieuYC)=1" + "\r\n";
        //DBO.THUOC_TrangThaiPhieuYC(A.IdPhieuYC)='Chưa Xuất'

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

        skq += sqlIdkhoIn;

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
    private DataTable dtGetSource(int IdPhieuXuat, ref double Tongtien)
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
        dtXuat.Columns.Add("SLXuat1", tTemp);

        string sysDate = DataAcess.Connect.s_SystemDate();

        string idkho = StaticData.MacDinhKhoNhapMuaID;
        string LoaiBN = "2";
        string sql = "select t.idthuoc,ct.IdChiTietPhieuYC,t.tenthuoc,t.congthuc, t.donvitinh,t.iddvt,ThanhTienTruocThue=0, ThanhTien=0 ,";
        sql += @" soluong= isnull(ct.soluong,0)- isnull((select sum(soluong) from chitietphieuxuatkho where IDCHITIETPHIEUYEUCAUXUATKHO =ct.IdChiTietPhieuYC),0)
,SL_Ton=DBO.Thuoc_TonKho_new( CT.IDTHUOC, GETDATE() ," + idkho + " ), "
        + " GiaBan= dbo.Thuoc_TinhGiaXuat2 (ct.idthuoc ,'" + sysDate + "',"+LoaiBN+", 1 ,4," + idkho + " )";
        sql += " from Thuoc_ChiTietPhieuYCXuat ct left join thuoc t ";
        sql += "    on ct.idthuoc = t.idthuoc ";
        sql += " where T.IDTHUOC IS NOT NULL AND T.IDTHUOC <>0 AND  ct.IdPhieuYC = " + iKey.ToString() + @"
 and (isnull(ct.soluong,0)- isnull((select sum(soluong) from chitietphieuxuatkho where IDCHITIETPHIEUYEUCAUXUATKHO =ct.IdChiTietPhieuYC),0)) >0
";
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

            int SlXuat = 0;
            string sGiaBan = listthuoc.Rows[i]["GiaBan"].ToString();
            if (sGiaBan == "") sGiaBan = "0";
            float GiaBan = float.Parse(sGiaBan);
            string sCK = "0";
            if (sCK == "") sCK = "0";
            int chietkhau = int.Parse(sCK);
            double TTXuat = 0;
            double TTXuat_TT = 0;
            string idthuoc = listthuoc.Rows[i]["idthuoc"].ToString();
            if (idthuoc == "") idthuoc = "0";
            string sqldspn = " select A.* ,soluongton=(A.soluong- DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)  ) from chitietphieunhapkho A";
            sqldspn += " left join phieunhapkho B on A.idphieunhap=B.idphieunhap";
            sqldspn += " where  B.IDKHO=" + idkho + " AND   idthuoc=" + idthuoc;
            sqldspn += " and A.soluong>DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)";
            sqldspn += " and B.ngaythang<=" + "'" + sysDate + "'";
            sqldspn += " order by A.ngayhethan";
            int m = 0;
            int n = StaticData.ParseInt(listthuoc.Rows[i]["soluong"].ToString());
            DataTable dtthuoc = DataAcess.Connect.GetTable(sqldspn);
            if (dtthuoc != null && dtthuoc.Rows.Count != 0)
            {
                for (int j = 0; idthuoc != "" && j < dtthuoc.Rows.Count; j++)
                {
                    int slt = StaticData.ParseInt(dtthuoc.Rows[j]["soluongton"].ToString());
                    if (n >= slt) m = slt;
                    else
                        m = n;
                    SlXuat += m;

                    double thanhtien = (double)m * GiaBan;
                    double thanhtientruocthue = (double)thanhtien * ((100.0 - chietkhau) / 100);
                    double ThanhTienSauThue = thanhtientruocthue * ((100.0 + VAT) / 100);
                    Tongtien += ThanhTienSauThue;
                    TTXuat += ThanhTienSauThue;
                    TTXuat_TT += thanhtientruocthue;
                    if (n - slt < 0) break;
                    else n -= slt;
                }//end for 1.1
            }
            TTXuat = Math.Round(TTXuat, 0);
            TTXuat_TT = Math.Round(TTXuat_TT, 0);
            R_Xuat["SLXuat"] = SlXuat;
            R_Xuat["SLXuat1"] = SlXuat;
            R_Xuat["SoTien"] = TTXuat;
            R_Xuat["TTTT"] = TTXuat_TT;
            dtXuat.Rows.Add(R_Xuat);

        }   //end for 1
        return dtXuat;
        #endregion
    }
    private DataTable nvk_dtGetSource(int IdPhieuXuat, ref double Tongtien,string LisIdThuoc,string LisSLChapNhanXuat)
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
        dtXuat.Columns.Add("mabenhnhan", tTemp);
        dtXuat.Columns.Add("tenbenhnhan", tTemp);
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
        dtXuat.Columns.Add("Idchitietbenhnhantoathuoc", tTemp);
        dtXuat.Columns.Add("SLTon", tTemp);
        dtXuat.Columns.Add("SLXuat1", tTemp);

        string sysDate = DataAcess.Connect.s_SystemDate();

        string idkho = StaticData.MacDinhKhoNhapMuaID;
        string LoaiBN = "2";

        string sql = @"select t.idthuoc,ct.IdChiTietPhieuYC,CtCT.Idchitietbenhnhantoathuoc
,bbn.tenbenhnhan,bbn.mabenhnhan,bbn.ngaysinh,gioitinh=dbo.getgioitinh(bbn.gioitinh)
,t.tenthuoc,t.congthuc, t.donvitinh,t.iddvt,ThanhTienTruocThue=0, ThanhTien=0
,soluong=isnull(ctbntt.soluongke,0)- --nvk comment isnull(ctbntt.soluongtra,0) -
isnull((select sum(soluong) from chitietphieuxuatkho where idchitietbenhnhantoathuoc=ctbntt.idchitietbenhnhantoathuoc and isnull(IDCHITIETPHIEUYEUCAUXUATKHO,0)>0 ),0)
,SL_Ton=DBO.Thuoc_TonKho_new( CT.IDTHUOC, GETDATE() ," + idkho + @" )
,GiaBan= dbo.Thuoc_TinhGiaXuat2 (ct.idthuoc ,'" + sysDate + "',"+LoaiBN+", 1 , 4 ," + idkho + @" )
            from NVK_Thuoc_ChiTietYCXuat CtCT inner join  Thuoc_ChiTietPhieuYCXuat ct on CtCT.IdChiTietPhieuYC=ct.IdChiTietPhieuYC
				inner join chitietbenhnhantoathuoc ctbntt on ctbntt.idchitietbenhnhantoathuoc=CtCT.Idchitietbenhnhantoathuoc
				inner join khambenh kkb on kkb.idkhambenh=ctbntt.idkhambenh
				inner join benhnhan bbn on bbn.idbenhnhan=kkb.idbenhnhan
		        left join thuoc t on ct.idthuoc = t.idthuoc 
         where T.IDTHUOC IS NOT NULL AND T.IDTHUOC <>0 AND  ct.IdPhieuYC= '" + iKey.ToString() + @"'
 and (isnull(ctbntt.soluongke,0)- --nvk comment isnull(ctbntt.soluongtra,0) -
isnull((select sum(soluong) from chitietphieuxuatkho where idchitietbenhnhantoathuoc=ctbntt.idchitietbenhnhantoathuoc and isnull(IDCHITIETPHIEUYEUCAUXUATKHO,0)>0 ),0)) >0
order by idchitietbenhnhantoathuoc";
        DataTable listthuoc = DataAcess.Connect.GetTable(sql);
        #region nvk table duyệt Phiếu yêu cầu ngoài bệnh nhân 
        if (listthuoc == null || listthuoc.Rows.Count == 0)
        {
            sql = @"select t.idthuoc,ct.IdChiTietPhieuYC,Idchitietbenhnhantoathuoc=0
                    ,tenbenhnhan='',mabenhnhan='',ngaysinh=null,gioitinh=null
                    ,t.tenthuoc,t.congthuc, t.donvitinh,t.iddvt,ThanhTienTruocThue=0, ThanhTien=0
                    ,soluong=isnull(ct.soluong,0) - isnull(ct.SLxuat,0)
                    ,SL_Ton=DBO.Thuoc_TonKho_new( CT.IDTHUOC, GETDATE() ,"+idkho+@" )
                    ,GiaBan= dbo.Thuoc_TinhGiaXuat2 (ct.idthuoc ,'" + sysDate + "',"+LoaiBN+", 1 , 4 ," + idkho + @" )
                                from Thuoc_ChiTietPhieuYCXuat ct left join thuoc t on ct.idthuoc = t.idthuoc 
                             where T.IDTHUOC IS NOT NULL AND T.IDTHUOC <>0 AND  ct.IdPhieuYC= '" + iKey.ToString() + @"'";
            listthuoc = DataAcess.Connect.GetTable(sql);
        }
        #endregion
        Tongtien = 0;
        string[] arrIdThuoc = LisIdThuoc.Split(',');
        string[] arrSLThuocChapNhanXuatTong = LisSLChapNhanXuat.Split(',');
        for (int i = 0; i < listthuoc.Rows.Count; i++)
        {
            if (listthuoc.Rows[i]["GiaBan"].ToString() == "")
                listthuoc.Rows[i]["GiaBan"] = "0";
            DataRow R_Xuat = dtXuat.NewRow();
            R_Xuat["STT"] = i + 1;
            R_Xuat["mabenhnhan"] = listthuoc.Rows[i]["mabenhnhan"].ToString();
            R_Xuat["tenbenhnhan"] = listthuoc.Rows[i]["tenbenhnhan"].ToString();
            R_Xuat["TenThuoc"] = listthuoc.Rows[i]["tenthuoc"].ToString();
            R_Xuat["Soluong"] = listthuoc.Rows[i]["soluong"].ToString();
            R_Xuat["GiaBan"] = listthuoc.Rows[i]["GiaBan"].ToString();
            R_Xuat["ChietKhau"] = "0";
            R_Xuat["congthuc"] = listthuoc.Rows[i]["congthuc"].ToString();
            R_Xuat["idthuoc"] = listthuoc.Rows[i]["idthuoc"].ToString();
            R_Xuat["IdChiTietPhieuYC"] = listthuoc.Rows[i]["IdChiTietPhieuYC"].ToString();
            R_Xuat["Idchitietbenhnhantoathuoc"] = listthuoc.Rows[i]["Idchitietbenhnhantoathuoc"].ToString();
            R_Xuat["SLTon"] = listthuoc.Rows[i]["SL_Ton"].ToString();

            int SlXuat = 0;
            string sGiaBan = listthuoc.Rows[i]["GiaBan"].ToString();
            if (sGiaBan == "") sGiaBan = "0";
            float GiaBan = float.Parse(sGiaBan);
            string sCK = "0";
            if (sCK == "") sCK = "0";
            int chietkhau = int.Parse(sCK);
            double TTXuat = 0;
            double TTXuat_TT = 0;
            string idthuoc = listthuoc.Rows[i]["idthuoc"].ToString();
            if (idthuoc == "") idthuoc = "0";
            string sqldspn = " select A.* ,soluongton=(A.soluong- DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)  ) from chitietphieunhapkho A";
            sqldspn += " left join phieunhapkho B on A.idphieunhap=B.idphieunhap";
            sqldspn += " where  B.IDKHO=" + idkho + " AND   idthuoc=" + idthuoc;
            sqldspn += " and A.soluong>DBO.Thuoc_GetSoluongXuat2(A.IdChiTietPhieuNhapKho)";
            sqldspn += " and B.ngaythang<=" + "'" + sysDate + "'";
            sqldspn += " order by A.ngayhethan";
            int m = 0;
            int n = StaticData.ParseInt(listthuoc.Rows[i]["soluong"].ToString());
            DataTable dtthuoc = DataAcess.Connect.GetTable(sqldspn);
            if (dtthuoc != null && dtthuoc.Rows.Count != 0)
            {
                for (int j = 0; idthuoc != "" && j < dtthuoc.Rows.Count; j++)
                {
                    int slt = StaticData.ParseInt(dtthuoc.Rows[j]["soluongton"].ToString());
                    if (n >= slt) m = slt;
                    else
                        m = n;
                    SlXuat += m;

                    double thanhtien = (double)m * GiaBan;
                    double thanhtientruocthue = (double)thanhtien * ((100.0 - chietkhau) / 100);
                    double ThanhTienSauThue = thanhtientruocthue * ((100.0 + VAT) / 100);
                    Tongtien += ThanhTienSauThue;
                    TTXuat += ThanhTienSauThue;
                    TTXuat_TT += thanhtientruocthue;
                    if (n - slt < 0) break;
                    else n -= slt;
                }//end for 1.1
            }
            //nếu số lượng xuất tính dc <= sl người dùng chọn -> dùng số lượng tính dc
            for (int k = 0; k < arrIdThuoc.Length; k++)
            {
                if (arrIdThuoc[k].Equals(listthuoc.Rows[i]["idthuoc"].ToString()))
                {
                    int SlChapNhanConLai = StaticData.ParseInt(arrSLThuocChapNhanXuatTong[k]);
                    if (SlXuat >= SlChapNhanConLai)
                    {
                        SlXuat = SlChapNhanConLai;
                        arrSLThuocChapNhanXuatTong[k] = "0";
                    }
                    else
                    {
                        int nvkConLai = SlChapNhanConLai - SlXuat;
                        arrSLThuocChapNhanXuatTong[k] = nvkConLai.ToString();
                    }
                    break; //End for nvk CHƯA TÍNH GIÁ ,THÀNH TIỀN ??????
                }
            }
            //nếu số lượng xuất tính dc >= sl người dùng chọn -> dùng số lượng 
            TTXuat = Math.Round(TTXuat, 0);
            TTXuat_TT = Math.Round(TTXuat_TT, 0);
            R_Xuat["SLXuat"] = SlXuat;
            R_Xuat["SLXuat1"] = SlXuat;
            R_Xuat["SoTien"] = TTXuat;
            R_Xuat["TTTT"] = TTXuat_TT;
            dtXuat.Rows.Add(R_Xuat);

        }   //end for 1
        return dtXuat;
        #endregion
    }
    protected void CanhBao_Click(object sender, EventArgs e)
    {
        bool nvk_isCanhBao = false;
        for (int j = 0; j < this.grid.Rows.Count; j++)
        {
            string iSLXuat = ((TextBox)this.grid.Rows[j].Cells[6].FindControl("iSLXuat")).Text;
            string nvk_SoLuongYC = ((HiddenField)this.grid.Rows[j].Cells[6].FindControl("hdSoLuongYCAsp")).Value;
            if (StaticData.ParseInt(iSLXuat) < StaticData.ParseInt(nvk_SoLuongYC))
            {
                nvk_isCanhBao = true; break;
            }
        }
        if (nvk_isCanhBao)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "", "document.getElementById('divgrid').style.display='block';", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "nvk_CanhBao", "nvk_CanhBaoTreoThuoc();", true);
            //http://codeasp.net/blogs/raghav_khunger/microsoft-net/777/asp-net-how-to-open-confirm-box-from-codebehind-or-server-side
        }
        else
        {
            nvk_hd_IsCanhBao.Value = "1";
            Dongy_Click(null, null);
        }
    }
    protected void Dongy_Click(object sender, EventArgs e)
    {
        int IdPhieuYC = (int)Session["idPhieuxuat"];
        double Tongtien = 0;
        int nvkI = this.grid.Rows.Count;
        string LisIdThuoc = "";
        string LisSLChapNhanXuat = "";
        bool nvk_isCanhBao=false;
        for (int j = 0; j < this.grid.Rows.Count; j++)
        {
            string iSLXuat = ((TextBox)this.grid.Rows[j].Cells[6].FindControl("iSLXuat")).Text;
            string nvkIdThuoc = ((HiddenField)this.grid.Rows[j].Cells[6].FindControl("hdIdThuocAsp")).Value;
            LisIdThuoc += nvkIdThuoc + ",";
            LisSLChapNhanXuat += iSLXuat + ",";
        }
        LisIdThuoc = LisIdThuoc.TrimEnd(',');
        LisSLChapNhanXuat = LisSLChapNhanXuat.TrimEnd(',');
        if (nvk_hd_IsCanhBao.Value.Equals("2"))
            return;
        DataTable dtXuat = nvk_dtGetSource(IdPhieuYC, ref Tongtien, LisIdThuoc, LisSLChapNhanXuat);
        DataView dvtemp = new DataView(dtXuat.Copy());
        dvtemp.RowFilter = " SLXuat1 >0";
        dtXuat= dvtemp.ToTable();
        if (dtXuat.Rows.Count == 0)
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "nvk_BaokoXuat", "alert('Số lượng xuất phải >0 !');", true);
            StaticData.MsgBox(this,"Số lượng xuất phải >0 !");
            return;
        }
        //return;
        string IdKhoYeuCau = DataAcess.Connect.GetTable("select idkhoYC= isnull((select idphongkhambenh from  Thuoc_PhieuYCXuat where idphieuyc=" + IdPhieuYC + "),0)").Rows[0]["idkhoYC"].ToString();

        int idphieuxuat = myInsertPhieuXuatKho.LuuPhieuXuatChuyenKho("0", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), IdKhoYeuCau, StaticData.MacDinhKhoNhapMuaID,
             dtXuat, SysParameter.UserLogin.UserID(this), "Phiếu xuất chuyển kho", "0", "4", "0", false);

        //return; //nvk return
        #region nvk cập nhật SLXuat thuoc_chitietphieuYCxuat
        string sqlLastPX = @"select idthuoc,sum(soluong) as soluongX
         from chitietphieuxuatkho
         where idphieuxuat ='" + idphieuxuat + @"'
         group by idthuoc ";
        DataTable dtLastPX = DataAcess.Connect.GetTable(sqlLastPX);
        if (dtLastPX.Rows.Count > 0)
        {
            string dkUd = ", Status_ThuocTreo=0";
            //DataTable dtIsNgoaiBN = DataAcess.Connect.GetTable("select top 1 idThuoc_ChiTietYeuCau from NVK_Thuoc_ChiTietYCXuat ctct inner join thuoc_chitietphieuycxuat ct on ct.IdChiTietPhieuYC=ctct.IdChiTietPhieuYC where  ct.idphieuyc ='"+IdPhieuYC+"'");
            //if (dtIsNgoaiBN != null && dtIsNgoaiBN.Rows.Count == 0)
            //    dkUd = "";
            for (int k = 0; k < dtLastPX.Rows.Count; k++)
            {
                string Ud_thuoc_chitietphieuYCxuat = "update thuoc_chitietphieuYCxuat set SLXuat=SLXuat + '" + dtLastPX.Rows[k]["soluongX"] + "'"+dkUd+" where idthuoc='" + dtLastPX.Rows[k]["idthuoc"] + "' and IdPhieuYC='" + IdPhieuYC + "'";
                bool kt_Ud_thuoc_chitietphieuYCxuat = DataAcess.Connect.ExecSQL(Ud_thuoc_chitietphieuYCxuat);
                //string Ud_StatusTreo = "update thuoc_chitietphieuYCxuat set Status_ThuocTreo=0 where idthuoc='" + dtLastPX.Rows[k]["idthuoc"] + "' and IdPhieuYC='" + IdPhieuYC + "'";
                //bool kt_Ud_StatusTreo = DataAcess.Connect.ExecSQL(Ud_StatusTreo);
            }
        }
        #endregion
        btnGetList_Click(null, null);
        //Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open ('frm_PhieuChuyenKhoResult.aspx?IdPhieuXuat=" + idphieuxuat + "')</script>");
        string LinkName = "frm_PhieuChuyenKhoResult.aspx?IdPhieuXuat=" + idphieuxuat + "";
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "InXemPhieuYC('" + LinkName + "');", true);
    }
    #endregion
    #region bindkho
    private void bindkho()
    {
        DataTable dt = StaticData.dtGetKho(this, false);
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
            //OpenLink("frm_PhieuYCXuat.aspx#idkhoachinh=" + idPhieuxuat);
            //OpenLink("http://192.168.1.241/MinhDucTest/QuanLyNhaThuoc/frm_PhieuYCXuat_Crpt.aspx?IdPhieuYC="+idPhieuxuat+""); ==> VÌ DÙNG UPDATEPANEL NÊN KHÔNG MỞ DC = CACH NAY
            string LinkName = "http://192.168.1.241/MinhDucTest/QuanLyNhaThuoc/frm_PhieuYCXuat_Crpt.aspx?IdPhieuYC=" + idPhieuxuat + "";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "InXemPhieuYC('" + LinkName + "');", true);
        }
    }

    private void OpenLink(string LinkName)
    {
        Response.Write("<script language = \"javascript\" type=\"text/javascript\">window.open (\"" + LinkName + "\",'_blank')</script>");

    }
    #endregion

}
