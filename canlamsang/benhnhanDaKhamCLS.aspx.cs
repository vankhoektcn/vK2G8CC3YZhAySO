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
public partial class nhanbenh_benhnhanDaKhamCLS : System.Web.UI.Page
{
    string strSearch;
    string dkmenu = null;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            SetValueEmpty();

            StaticData.SetFocus(this, "txtMaBenhNhan");
            //bind_ddlthangnam();
            string ngaybt = StaticData.CheckDate(txtNgayBD.Text);
            string ngaykt = StaticData.CheckDate(txtNgayKT.Text);
            loadPK();
            BindListBenhNhan("",ngaybt,ngaykt);//-----can chinh lai
        }
          dkmenu = Request.QueryString["dkmenu"].ToString();

        if (dkmenu == "kb")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
        }
        if (dkmenu == "tiepnhan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        }
        if (dkmenu == "cls")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        }
        if (dkmenu == "thuphi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
        }
        if (dkmenu == "thongke")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/thongke/uscmenu.ascx"));
        }
        if (dkmenu == "kh")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/KhachHang/uscmenu.ascx"));
        }
    }

    private void bind_ddlthangnam()
    {
        //DateTime dt = DataAcess.Connect.d_SystemDate();
        //string key;
        //ddl_nam.Items.AddRange(new ListItem[] { new ListItem(dt.Year.ToString()), new ListItem(Convert.ToString(dt.Year - 1)) });
        //ddl_thangbd.SelectedIndex = dt.Month - 1;
        //ddl_thangkt.SelectedIndex = dt.Month - 1;
        //int songay = StaticData.GetSoNgay(dt.Month, dt.Year);
        ////string a = "011".Substring(1, 2);
        //for (int i = 1; i <= songay; i++)
        //{
        //    key = "0" + i.ToString();
        //    key = key.Substring(key.Length - 2, 2);
        //    ddl_ngaybd.Items.Add(key);
        //    ddl_ngaykt.Items.Add(key);
        //}
        //ddl_ngaybd.SelectedIndex = dt.Day - 1;
        //ddl_ngaykt.SelectedIndex = dt.Day - 1;
    }
    private int stt = 1;
    protected string STT()
    {
        return (stt++).ToString();
    }


    #region "U Function"
    //TRUONGNHAT-PC
    private void loadPK()
    {
        string sql = ""
                     + " SELECT * FROM PHONGKHAMBENH " + "\r\n"
                     + " WHERE 1=1 "
                     + " AND LOAIPHONG=1" + "\r\n";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        StaticData.FillCombo(ddlKhoa, dt, "idphongkhambenh", "tenphongkhambenh", "Chọn phòng/khoa");
        ddlKhoa.SelectedIndex = 0;
    }
    private void BindListBenhNhan(string sWhere, string ngaybd, string ngaykt)
    {


        DataTable dtCTPhieu = new DataTable();

        string sql = "";

        if (ngaykt != null && ngaybd != null)
        {
            string where = "";
           
            //if (ddlKhoa.SelectedValue.ToString() == "25")
            //{
                string where1 = "";
                if (ngaybd != "")
                {
                    where += " AND  kbcls.ngaythu>='" + ngaybd + " 00:00:00' ";
                    where1 += " AND  CLS.NGAYKHAM>='" + ngaybd + " 00:00:00' ";
                }
                if (ngaybd != "")
                {
                    where += " AND kbcls.ngaythu<='" + ngaykt + " 23:59:59'";
                    where1 += " AND CLS.NGAYKHAM<='" + ngaykt + " 23:59:59'";
                }
                           

                sql = string.Format(@"select distinct CLS.idbenhnhan,	B.mabenhnhan, B.tenbenhnhan,B.diachi,   B.dienthoai,
			                       case when isnull(B.gioitinh,0)=0 then 'Nam' else N'Nữ' end as gioitinh,
			                       B.ngaysinh,   Ngaykham=kbcls.ngaythu,
			                       DichVuKham=N'Xét nghiệm' ,
				                    tenbscls=(SELECT TOP 1 bs.tenbacsi
				                    FROM ketqua_canlamsangchitiet ct
				                    LEFT JOIN BACSI bs ON bs.IDBACSI=CT.IDBBSCLS 
				                    WHERE CLS.idketqua_canlamsang=ct.idketqua_canlamsang),
                    IDDIEUTRICANLAMSAN=CLS.idketqua_canlamsang ,cls.madangkycls
                    from ketqua_canlamsang CLS 
                    left join khambenhcanlamsan kbcls on kbcls.madangkycls=cls.madangkycls
                    LEFT JOIN BENHNHAN B ON CLS.IDBENHNHAN=B.IDBENHNHAN

                    WHERE  1=1  
                    AND EXISTS (SELECT TOP 1 CT1.IDKETQUA_CANLAMSANGCHITIET 
			                    FROM ketqua_canlamsangchitiet ct1
			                    LEFT JOIN BANGGIADICHVU DV ON DV.IDBANGGIADICHVU=CT1.IDBANGGIADICHVU
			                    LEFT JOIN PHONGKHAMBENH KB ON KB.IDPHONGKHAMBENH=DV.IDPHONGKHAMBENH
			                    LEFT JOIN BACSI F ON F.IDBACSI=CT1.IDBBSCLS
			                    WHERE CLS.idketqua_canlamsang=ct1.idketqua_canlamsang {0} 
                     AND KB.maphongkhambenh='XN') {1}", where, sWhere.Replace(" AND CLS.IDPHONGKHAMBENH="+ddlKhoa.SelectedValue, "").Replace("kbcls.madangkyCLS", "cls.madangkycls"));
              
                
                 
                sql +=
                            " union all("
                                + "    select DISTINCT " + "\r\n"
                                + "                              				   CLS.idbenhnhan," + "\r\n"
                                + "                              				   B.mabenhnhan," + "\r\n"
                                + "                              				   B.tenbenhnhan," + "\r\n"
                                + "                              				   B.diachi," + "\r\n"
                                + "                              				   B.dienthoai," + "\r\n"
                                + "                              				   case when isnull(B.gioitinh,0)=0 then 'Nam' else N'Nữ' end as gioitinh," + "\r\n"
                                + "                              				   B.ngaysinh," + "\r\n"
                                + "                              				   Ngaykham=CLS.NGAYKHAM ," + "\r\n"
                                + "                              				   DichVuKham=TENPHONGKHAMBENH  ," + "\r\n"
                                + "                              				   F.TENBACSI AS tenbscls,CLS.IDDIEUTRICANLAMSAN ,kbcls.madangkycls" + "\r\n"
                                + "                                    from DIEUTRICANLAMSAN CLS " + "\r\n"
                                + "                              	   LEFT JOIN BENHNHAN B ON CLS.IDBENHNHAN=B.IDBENHNHAN " + "\r\n"
                                + "                              	   LEFT JOIN PHONGKHAMBENH KB ON KB.IDPHONGKHAMBENH=CLS.IDPHONGKHAMBENH" + "\r\n"
                                + "                              	   LEFT JOIN BACSI F ON F.IDBACSI=CLS.IDBACSI" + "\r\n"
                                + "                              		LEFT JOIN khambenhcanlamsan kbcls ON kbcls.idbenhnhan=CLS.idbenhnhan and cls.soid =kbcls.madangkycls" + "\r\n"
                                + " " + "\r\n"
                                + " WHERE  1=1 " + where1 + " \r\n"
                                 + " " + "\r\n" + sWhere
                                + " )" + "\r\n"
                                + "   " + "\r\n";
            //}
            //else
            //{
            //    if (ngaybd != "")
            //        where += " AND  CLS.NGAYKHAM>='" + ngaybd + " 00:00:00' ";
            //    if (ngaybd != "")
            //        where += " AND CLS.NGAYKHAM<='" + ngaykt + " 23:59:59'";
            //    sql =
            //                ""
            //                    + "    select DISTINCT " + "\r\n"
            //                    + "                              				   CLS.idbenhnhan," + "\r\n"
            //                    + "                              				   B.mabenhnhan," + "\r\n"
            //                    + "                              				   B.tenbenhnhan," + "\r\n"
            //                    + "                              				   B.diachi," + "\r\n"
            //                    + "                              				   B.dienthoai," + "\r\n"
            //                    + "                              				   case when isnull(B.gioitinh,0)=0 then 'Nam' else N'Nữ' end as gioitinh," + "\r\n"
            //                    + "                              				   B.ngaysinh," + "\r\n"
            //                    + "                              				   Ngaykham=CLS.NGAYKHAM ," + "\r\n"
            //                    + "                              				   DichVuKham=TENPHONGKHAMBENH  ," + "\r\n"
            //                    + "                              				   F.TENBACSI AS tenbscls,CLS.IDDIEUTRICANLAMSAN ,kbcls.madangkycls" + "\r\n"
            //                    + "                                    from DIEUTRICANLAMSAN CLS " + "\r\n"
            //                    + "                              	   LEFT JOIN BENHNHAN B ON CLS.IDBENHNHAN=B.IDBENHNHAN " + "\r\n"
            //                    + "                              	   LEFT JOIN PHONGKHAMBENH KB ON KB.IDPHONGKHAMBENH=CLS.IDPHONGKHAMBENH" + "\r\n"
            //                    + "                              	   LEFT JOIN BACSI F ON F.IDBACSI=CLS.IDBACSI" + "\r\n"
            //                    + "                              		LEFT JOIN khambenhcanlamsan kbcls ON kbcls.idbenhnhan=CLS.idbenhnhan and cls.soid =kbcls.madangkycls" + "\r\n"
            //                    + " " + "\r\n"
            //                    + " WHERE  1=1 " + where + " \r\n"
            //                     + " " + "\r\n" + sWhere
            //                    + " ORDER BY CLS.NGAYKHAM" + "\r\n"
            //                    + "   " + "\r\n";
            //}
        }
        else
        {
                            sql = ""
                            + "   select " + "\r\n"
                            + "   idbenhnhan," + "\r\n"
                            + "   mabenhnhan," + "\r\n"
                            + "   tenbenhnhan," + "\r\n"
                            + "   diachi," + "\r\n"
                            + "   dienthoai," + "\r\n"
                            + "   case when isnull(gioitinh,0)=0 then 'Nam' else N'Nữ' end as gioitinh," + "\r\n"
                            + "   ngaysinh," + "\r\n"
                            + "  Ngaykham=DBO.[GetListNgayKhamCLS](B.IDBenhNhan,'','')," + "\r\n"
                            + "   DichVuKham= DBO.GetDichVuCLS3(B.IDBenhNhan,'',''), [dbo].[GetTenBSCLS](b.idbenhnhan,'','') as tenbscls" + "\r\n"
                            + "    from benhnhan B" + "\r\n"
                            + "   Where Exists(select IDBenhNhan From dieutricanlamsan dt where idkhambenhcanlamsan in " + "\r\n"
                            + " ( select idkhambenh from  khambenh where idbenhnhan=b.idbenhnhan ) or ( dt.IDBenhNhan=B.IDBenhNhan))" + "\r\n"
                            + "  " + "\r\n" + sWhere + " ORDER BY Ngaykham ";
        }
        dtCTPhieu = DataAcess.Connect.GetTable(sql);

        if (dtCTPhieu!=null && dtCTPhieu.Rows.Count > 0)
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
        txtNgayBD.Text = DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
        txtNgayKT.Text = DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
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
    //-------can chinh lai
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        strSearch = GetChuoiSearch();
        //if (txtMaBenhNhan.Text == "")
        {
            string ngaybt = StaticData.CheckDate(txtNgayBD.Text);
            string ngaykt = StaticData.CheckDate(txtNgayKT.Text);
            //string ngaybt = ddl_nam.Text + "/" + ddl_thangbd.Text + "/" + ddl_ngaybd.Text;
            //string ngaykt = ddl_nam.Text + "/" + ddl_thangkt.Text + "/" + ddl_ngaykt.Text;
            BindListBenhNhan(strSearch, ngaybt, ngaykt);
        }
        //else
        //{
        //    BindListBenhNhan(strSearch, null, null);
        //}

    }
    private string GetChuoiSearch()
    {

        string skq = "";
        if (txtMaBenhNhan.Text != "")
        {
            skq += " AND b.mabenhnhan LIKE '%" + txtMaBenhNhan.Text.Trim() + "%' ";
        }
        if (txtTenBenhNhan.Text != "")
        {
            skq += " AND b.tenbenhnhan LIKE N'%" + txtTenBenhNhan.Text.Trim() + "%' ";
        }
        if (txtDienThoai.Text != "")
        {
            skq += " AND b.dienthoai LIKE '%" + txtDienThoai.Text.Trim() + "%' ";
        }
        if (txtDiaChi.Text != "")
        {
            skq += " AND b.diachi LIKE N'%" + txtDiaChi.Text.Trim() + "%' ";
        }
        if (ddlGioiTinh.SelectedValue != "2")
        {
            skq += " AND b.gioitinh = " + ddlGioiTinh.SelectedValue;
        }
        if (ddlKhoa.SelectedValue != "0")
        {
            skq += " AND CLS.IDPHONGKHAMBENH=" + ddlKhoa.SelectedValue;
        }
        if(txtMaCLS.Text!="")
        {
            skq += " AND kbcls.madangkyCLS='"+txtMaCLS.Text.ToString()+"'";
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

    //TRUONGNHAT-PC EDIT BENH NHAN CHI DINH CAN LAM SAN
    //CODE CU
    //public void Edit(object s, DataGridCommandEventArgs e)
    //{
    //    int idbenhnhan = 0;
    //    idbenhnhan = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
    //    Response.Redirect("benhnhannew.aspx?idbenhnhan=" + idbenhnhan);
    //}
    //CODE 16/07/2011
    //SUA CHI DINH CAN LAM SAN
    public void Edit(object s, DataGridCommandEventArgs e)
    {
        int idbenhnhan = 0;
        if(dgr.DataKeys[e.Item.ItemIndex].ToString()!="")
                idbenhnhan = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
            string tenphong = e.Item.Cells[10].Text;
            int idcls =StaticData.ParseInt(e.CommandArgument.ToString());
            if (tenphong.ToLower().Trim() == "xét nghiệm")
            {
                string macls = e.Item.Cells[3].Text;
                string slqBSCLS = "select top 1 idbbscls from ketqua_canlamsangchitiet where idketqua_canlamsang=" + idcls;
                DataTable dtbsCLS = DataAcess.Connect.GetTable(slqBSCLS);
                if (dtbsCLS != null && dtbsCLS.Rows.Count > 0)
                {
                    int idbs = StaticData.ParseInt(dtbsCLS.Rows[0]["idbbscls"].ToString());
                    Response.Redirect("../canlamsang/frmKQXetNghiem_new.aspx?new=0&macls='" + macls + "'&idbs=" + idbs + "&idphongkhambenh=25&loaibn=0&dkmenu=cls");
                }
                else
                {
                    String sql = "select top 1 idkhambenh from khambenhcanlamsan where dbo.kb_getidbenhnhan(idkhambenhcanlamsan)=" + idbenhnhan;
                    DataTable dt = DataAcess.Connect.GetTable(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string sqlBS = "select idbacsi from dieutricanlamsan where idbenhnhan=" + idbenhnhan;
                        DataTable dtbs = DataAcess.Connect.GetTable(sqlBS);
                        int idbs = StaticData.ParseInt(dtbs.Rows[0]["idbacsi"].ToString());
                        

                        if (dt.Rows[0]["idkhambenh"].ToString() != "0")
                        {
                            Response.Redirect("../canlamsang/thambenhentry.aspx?idbn=" + idbenhnhan + "&dkMenu=" + this.dkmenu);
                        }

                        else
                        {
                            Response.Redirect("../canlamsang/dieutrikhachlecanlamsan.aspx?idbn=" + idbenhnhan + "&idbs=" + idbs + "&dkMenu=" + this.dkmenu + "&idcls=" + idcls);

                        }
                    }
                   
                }
            }
            else
            {
                string sqlBS = "select idbacsi from dieutricanlamsan where idbenhnhan=" + idbenhnhan;
                DataTable dtbs = DataAcess.Connect.GetTable(sqlBS);
                int idbs = StaticData.ParseInt(dtbs.Rows[0]["idbacsi"].ToString());
                if (tenphong.ToLower().Trim() == "siêu âm")
                {
                    Response.Redirect("../canlamsang/KQSieuAm.aspx?idbn=" + idbenhnhan + "&idbs=" + idbs + "&dkMenu=" + this.dkmenu + "&idcls=" + idcls);
                }
                if (tenphong.ToLower().Trim() == "fibro scan")
                {
                    Response.Redirect("../canlamsang/KQFiboScan.aspx?idbn=" + idbenhnhan + "&idbs=" + idbs + "&dkMenu=" + this.dkmenu + "&idcls=" + idcls);
                }
            }
            //else
            //{
            //    String sql = "select top 1 idkhambenh from khambenhcanlamsan where dbo.kb_getidbenhnhan(idkhambenhcanlamsan)=" + idbenhnhan;
            //    DataTable dt = DataAcess.Connect.GetTable(sql);
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        if (dt.Rows[0]["idkhambenh"].ToString() != "0")
            //        {
            //            Response.Redirect("../canlamsang/thambenhentry.aspx?idbn=" + idbenhnhan + "&dkMenu=" + this.dkmenu);
            //        }

            //        else
            //        {
            //            Response.Redirect("../canlamsang/dieutrikhachlecanlamsan.aspx?idbn=" + idbenhnhan + "&idbs=" + idbs + "&dkMenu=" + this.dkmenu + "&idcls=" + idcls);

            //        }
            //    }
            //    else
            //    {
            //        StaticData.MsgBox(this, "Lỗi dữ liệu.");
            //    }
            //}
    }
    public void DelBenhNhan(object s, DataGridCommandEventArgs e)
    {
        name2.Value = dgr.DataKeys[e.Item.ItemIndex].ToString();
        name4.Value = e.CommandName.ToString();
        name3.Value = "idbenhnhan";
        nguoidung.Text = SysParameter.UserLogin.FullName(this);
        ngaythang.Text = DateTime.Now.ToShortDateString();
        kieutt.Text = ((LinkButton)(e.Item.Cells[0].FindControl("lbtnDel"))).Text;
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "divlydo.style.display = 'block';", true);
        
    }

    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ////ThuanNH 05/04/2010 
            ////Redirect su kien onclick in hoa don (Phieu tong hop thanh toan BH)
            //btn = (LinkButton)(e.Item.Cells[0].FindControl("lbtnInHoaDon"));
            //btn.Attributes.Add("onclick", "return InPhieuDangTHThanhToanBH(" + dgr.DataKeys[e.Item.ItemIndex] + ");");
            //------------------------------------------------------------------
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
        if (txtMaBenhNhan.Text == "")
        {
            string ngaybt = StaticData.CheckDate(txtNgayBD.Text);
            string ngaykt = StaticData.CheckDate(txtNgayKT.Text);
            //string ngaybt = ddl_nam.Text + "/" + ddl_thangbd.Text + "/" + ddl_ngaybd.Text;
            //string ngaykt = ddl_nam.Text + "/" + ddl_thangkt.Text + "/" + ddl_ngaykt.Text;
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
        if (e.CommandName == "Del")
        {
            int imabn;
            imabn = System.Convert.ToInt32(dgr.DataKeys[e.Item.ItemIndex]);
            DataTable checkExistBN = DataAcess.Connect.GetTable("select * from DangkyKham where idBenhNhan=" + imabn + "");
            if (checkExistBN == null || checkExistBN.Rows.Count == 0)
            {
                bool kqDeleteBN = DataAcess.Connect.ExecSQL("delete from benhnhan where idbenhnhan=" + imabn + "");

                StaticData.MsgBox(this, "Bệnh nhân này đã xóa khỏi danh sách.");
                strSearch = GetChuoiSearch();
                if (txtMaBenhNhan.Text == "")
                {
                    string ngaybt = StaticData.CheckDate(txtNgayBD.Text);
                    string ngaykt = StaticData.CheckDate(txtNgayKT.Text);
                    //string ngaybt = ddl_nam.Text + "/" + ddl_thangbd.Text + "/" + ddl_ngaybd.Text;
                    //string ngaykt = ddl_nam.Text + "/" + ddl_thangkt.Text + "/" + ddl_ngaykt.Text;
                    BindListBenhNhan(strSearch, ngaybt, ngaykt);
                }
                else
                {
                    BindListBenhNhan(strSearch, null, null);
                }
            }
            else
            {
                StaticData.MsgBox(this, "Bệnh nhân này đã được thu phí .Vui lòng hãy xóa phiếu thu trước rồi xóa bệnh nhân này");
            }
            return;  
        }
    }
    protected void btlydo_Click(object sender, EventArgs e)
    {
        Process.trangthailuutrudulieu.Insert_Object(SysParameter.UserLogin.UserID(this), DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "benhnhan", name3.Value.ToString(), name2.Value.ToString(), lydo.Text, kieutt.Text);
        int imabn;
        imabn = System.Convert.ToInt32(name2.Value);
        DataTable checkExistBN = DataAcess.Connect.GetTable("select * from DangkyKham where idBenhNhan=" + imabn + "");
        if (checkExistBN == null || checkExistBN.Rows.Count == 0)
        {
            bool kqDeleteBN = DataAcess.Connect.ExecSQL("delete from benhnhan where idbenhnhan=" + imabn + "");

            StaticData.MsgBox(this, "Bệnh nhân này đã xóa khỏi danh sách.");
            strSearch = GetChuoiSearch();
            if (txtMaBenhNhan.Text == "")
            {
                string ngaybt = StaticData.CheckDate(txtNgayBD.Text);
                string ngaykt = StaticData.CheckDate(txtNgayKT.Text);
                //string ngaybt = ddl_nam.Text + "/" + ddl_thangbd.Text + "/" + ddl_ngaybd.Text;
                //string ngaykt = ddl_nam.Text + "/" + ddl_thangkt.Text + "/" + ddl_ngaykt.Text;
                BindListBenhNhan(strSearch, ngaybt, ngaykt);
            }
            else
            {
                BindListBenhNhan(strSearch, null, null);
            }
        }
        else
        {
            StaticData.MsgBox(this, "Bệnh nhân này đã được thu phí .Vui lòng hãy xóa phiếu thu trước rồi xóa bệnh nhân này");
        }


        //clsBenhNhan cls = new clsBenhNhan();
        Session["IdBenhNhan"] = imabn.ToString();
        Response.Redirect("benhnhantaikham.aspx");    
    }
}
