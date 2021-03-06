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

public partial class nvk_commonFuntion_ajax : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             // from frm_PhieuYCXuat_ajax.aspx.cs
             case "NewMaPhieuYCLinhThuoc": NewMaPhieuYCLinhThuoc(); break;
             case "NewMaPhieuYCTraThuoc": NewMaPhieuYCTraThuoc(); break;
             case "nvk_TuyChonInChiDinh": nvk_TuyChonInChiDinh(); break;
             case "nvk_CheckAllCLS_In": nvk_CheckAllCLS_In(); break;
             case "nvk_setHuyKhamBenhCanLamSang": nvk_setHuyKhamBenhCanLamSang(); break;
             case "TimKiemBenhNhan" : nvk_TimKiembenhNhan();break;
             case "setNoiDungChungNhan": nvk_setNoiDungChungNhan(); break;
             case "loadicd" : loadicd(); break;

                 // from nhanbenh/ajax

             case "TimBenhVienTheoMa": TimBenhVien(true); break;
             case "TimBenhVienTheoTen": TimBenhVien(false); break;
             case "TimChanDoanTheoMa": TimChanDoan(true); break;
             case "TimChanDoanTheoTen": TimChanDoan(false); break;
             case "idbacsisearch": idbacsisearch(); break;
             case "TaoSVV_click": TaoSVV_click(); break;
         }
     }
     #region bacsi_search
    private void idbacsisearch()
    {
        string TenBS = Request.QueryString["q"].ToString();
        string sqlBS = @"SELECT 
            A.IDBACSI AS IDBACSI
            ,A.TENBACSI AS TENBACSI
            FROM BACSI A
            WHERE tenbacsi like N'%" + TenBS + "%'";
        DataTable table = DataAcess.Connect.GetTable(sqlBS);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
     #endregion
     #region In chỉ định theo yêu cầu
     private void nvk_TuyChonInChiDinh()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idkhambenh = Request.QueryString["idkhambenh"];
        string sqlListCLS = @"select cls.idkhambenhcanlamsan,bg.tendichvu,tongtienDV=(isnull(bg.giadichvu,cls.dongia)*cls.soluong)
                        ,maphongkhambenh = case when p.maphongkhambenh = N'DVKTKHAC' then 0 else 1 end 
             from khambenhcanlamsan cls inner join banggiadichvu bg on bg.idbanggiadichvu=cls.idcanlamsan
		            inner join phongkhambenh p on p.idphongkhambenh = bg.idphongkhambenh
             where cls.idkhambenh='" + idkhambenh + "'";
        string LisCLSDaHoan = ""; string LisCLSChuaHoan = "";
        DataTable dtListCLS = DataAcess.Connect.GetTable(sqlListCLS);
        DataView dvTempt = new DataView(dtListCLS.Copy());
        dvTempt.RowFilter = "maphongkhambenh > 0";
        DataTable dtCLS = dvTempt.ToTable();
        html.Append(@"<div style='width:96%;height:100%;background-color:#D4D0C8;padding:10px 10px 10px 10px' >");

        #region danh sách CLS
        if (dtCLS != null && dtCLS.Rows.Count > 0)
        {
            html.Append(@"
        <span style='width:99%;text-align:left' id='spDSCLS'>
            <fieldset style='border-width:thick;padding-bottom:15px;border-color:#778899;text-align:left;background-color:#D4D0C8;padding-left:30px'><legend>Chọn CLS Cần In</legend>");
            for (int i = 0; i < dtCLS.Rows.Count; i++)
            {
                if (i == 0)
                {
                    html.Append( "<span style='color:Red;font-weight:bold'><input type='checkbox'  id='cbAllCLS' onclick=\"CheckAllCLS(this,'" + idkhambenh + "',0)\" name='nhomCheckbox' value='checkAll' />&nbsp; Chọn tất cả CLS</span><br/>");
                }
                html.Append( @"<span  style='color:Blue;'><input type='checkbox' id='" + dtCLS.Rows[i]["idkhambenhcanlamsan"] + "' onclick='CheckChonCLS(this," + dtCLS.Rows[i]["tongtienDV"] + ")' name='nhomCheckbox' value='" + dtCLS.Rows[i]["idkhambenhcanlamsan"] + "' />&nbsp; " + dtCLS.Rows[i]["tendichvu"] + "  (" + dtCLS.Rows[i]["tongtienDV"] + @")</span><br/>");
            }
        html.Append(@"
            </fieldset>
        </span>");
        }
        #endregion

        dvTempt.RowFilter = "maphongkhambenh = 0";
        DataTable dtDV = dvTempt.ToTable();

        #region Danh Sách Dịch vụ
        if (dtDV != null && dtDV.Rows.Count > 0)
        {
        html.Append(@"
        <span style='width:100%' id='spDSDichVu'>
            <fieldset style='border-width:thick;padding-bottom:15px;border-color:Black;text-align:left;background-color:#D4D0C8;padding-left:30px'><legend>Chọn Dịch Vụ Cần In</legend>");
        
            for (int i = 0; i < dtDV.Rows.Count; i++)
            {
                if (i == 0)
                {
                    html.Append("<span style='color:Red;font-weight:bold'><input type='checkbox'  id='cbAllDV' onclick=\"CheckAllCLS(this,'" + idkhambenh + "',1)\" name='nhomCheckbox' value='checkAll' />&nbsp; Chọn tất cả DV</span><br/>");
                }
                html.Append(@"<span  style='color:Blue;'><input type='checkbox' id='" + dtDV.Rows[i]["idkhambenhcanlamsan"] + "' onclick='CheckChonCLS(this," + dtDV.Rows[i]["tongtienDV"] + ")' name='nhomCheckbox_DV' value='" + dtDV.Rows[i]["idkhambenhcanlamsan"] + "' />&nbsp; " + dtDV.Rows[i]["tendichvu"] + "  (" + dtDV.Rows[i]["tongtienDV"] + @")</span><br/>");
            }
        html.Append(@"
            </fieldset>
        </span>");
        }
        html.Append(@"
        <span style='width:96%;text-align:center;background-color:#D4D0C8' id='spDSbutton'>
                        <input type='hidden' id='lisIDClsIn' value=''>
              <input type='button' id='btnIn' value='In Phiếu CD' onclick='nvk_InTuyChonCLS_DV(" + idkhambenh + @");'/>
        </span>");
        #endregion 
        html.Append(@"</div>");
        Response.Write(html);
    }

    private void nvk_CheckAllCLS_In()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idkhambenh = Request.QueryString["idkhambenh"];
        string ListIDCLS = Request.QueryString["ListIDCLS"];        
        string nvk_isDV = Request.QueryString["nvk_isDV"];
        string CheckAll = Request.QueryString["CheckAll"];
        bool IsCheckAll = CheckAll == "true" ? true : false;
        string strCheck = "";
        if (IsCheckAll)
            strCheck = "checked";
        string sqlListCLS = @"select cls.idkhambenhcanlamsan,bg.tendichvu,tongtienDV=(cls.dongia*cls.soluong)
             from khambenhcanlamsan cls inner join banggiadichvu bg on bg.idbanggiadichvu=cls.idcanlamsan
		            inner join phongkhambenh p on p.idphongkhambenh = bg.idphongkhambenh
             where cls.idkhambenh='" + idkhambenh + "'";
        string text_CheckAll = "Chọn Dịch Vụ Cần In";
        string str_isDV = "1";
        string ListID_New = "";
        if (nvk_isDV == "0")// cls
        {
            sqlListCLS += " and p.maphongkhambenh <> N'DVKTKHAC'";
            text_CheckAll = "Chọn CLS Cần In";
            str_isDV="0";
        }
        else
            sqlListCLS += " and p.maphongkhambenh = N'DVKTKHAC'";
        DataTable dtListCLS = DataAcess.Connect.GetTable(sqlListCLS);

        #region danh sách CLS
        if (dtListCLS != null && dtListCLS.Rows.Count > 0)
        {
            ListID_New = ListIDCLS.TrimEnd(',').TrimStart(',') +",";
            string[] arrID_Old = ListIDCLS.Split(','); 
            html.Append(@"
            <fieldset style='border-width:thick;padding-bottom:15px;border-color:#778899;text-align:left;background-color:#D4D0C8;padding-left:30px'><legend>" + text_CheckAll + "</legend>");
            for (int i = 0; i < dtListCLS.Rows.Count; i++)
            {
                if (i == 0)
                {
                    html.Append("<span style='color:Red;font-weight:bold'><input type='checkbox' " + strCheck + " id='cbAllCLS' onclick=\"CheckAllCLS(this,'" + idkhambenh + "'," + str_isDV + ")\" name='nhomCheckbox' value='checkAll' />&nbsp; Chọn tất cả CLS</span><br/>");
                }
                html.Append(@"<span  style='color:Blue;'><input type='checkbox' "+strCheck+" id='" + dtListCLS.Rows[i]["idkhambenhcanlamsan"] + "' onclick='CheckChonCLS(this," + dtListCLS.Rows[i]["tongtienDV"] + ")' name='nhomCheckbox' value='" + dtListCLS.Rows[i]["idkhambenhcanlamsan"] + "' />&nbsp; " + dtListCLS.Rows[i]["tendichvu"] + "  (" + dtListCLS.Rows[i]["tongtienDV"] + @")</span><br/>");
                
                #region cập nhật list ID In
                if (IsCheckAll)
                {
                    bool isAdd = true;
                    for (int j = 0; j < arrID_Old.Length; j++)
                    {
                        if (dtListCLS.Rows[i]["idkhambenhcanlamsan"].ToString().Equals(arrID_Old[j]))
                            isAdd = false;
                    }
                    if (isAdd)
                        ListID_New += dtListCLS.Rows[i]["idkhambenhcanlamsan"].ToString() + ",";
                }
                #endregion
            }
            #region IsCheckAll = false => loại bỏ bớt id nếu trùng
            if (!IsCheckAll)
            {
                string LisNewNew = "";
                for (int k = 0; k < arrID_Old.Length; k++)
                {
                    bool IsRemove= false;
                    for (int l = 0; l < dtListCLS.Rows.Count; l++)
                    {
                        if (dtListCLS.Rows[l]["idkhambenhcanlamsan"].ToString().Equals(arrID_Old[k]))
                            IsRemove = true;
                    }
                    if(!IsRemove)
                        LisNewNew += arrID_Old[k] + ",";
                }
                ListID_New = LisNewNew ;
            }
            #endregion
            html.Append(@"
            </fieldset>");
        }
        else
            ListID_New = ListIDCLS;
        ListID_New = ListID_New.TrimStart(',').TrimEnd(',');
        #endregion

        Response.Write(html.ToString()+"~~"+ ListID_New);
    }
     #endregion
     private void NewMaPhieuYCLinhThuoc()
    {
        string ngayYC = DataAcess.Connect.GetTable("select convert(varchar(10),getdate(),126)").Rows[0][0].ToString();
        string MaPhieuYC = StaticData.NewPhieuYeuCauLinhThuoc(ngayYC);
        Response.Clear();
        Response.Write(MaPhieuYC);
    }
    private void NewMaPhieuYCTraThuoc()
    {
        string ngayYC = DataAcess.Connect.GetTable("select convert(varchar(10),getdate(),126)").Rows[0][0].ToString();
        string MaPhieuYC = StaticData.NewPhieuYeuCauTraThuoc(ngayYC);
        Response.Clear();
        Response.Write(MaPhieuYC);
    }

    private void nvk_setHuyKhamBenhCanLamSang()
    {
        string idkbcls = Request.QueryString["idkbcls"];
        string nvkDahuy = Request.QueryString["nvkDahuy"];
        string sql = "update khambenhcanlamsan set dahuy='" + nvkDahuy + "' where idkhambenhcanlamsan ='" + idkbcls + "'";
        if (DataAcess.Connect.ExecSQL(sql))
        {
            Response.Clear();
            Response.Write("1");
        }
        else
        {
            Response.Clear();
            Response.Write("Lỗi !");
        }

    }

    private void nvk_TimKiembenhNhan()
    {
        string swhere = "";
        if(Request.QueryString["mabenhnhan"] != null)
            swhere =" and bn.mabenhnhan like N'%"+ Request.QueryString["mabenhnhan"]+"%'";
        if(Request.QueryString["tenbenhnhan"] != null)
            swhere +=" and bn.tenbenhnhan like N'%"+ Request.QueryString["tenbenhnhan"]+"%'";

        string sqlSelect = @"select top 20 STT=ROW_NUMBER() OVER (ORDER BY BN.IDBENHNHAN) , bn.*" + "\r\n"
                  + " ,A.TenLoai " + "\r\n"
                  + " ,TenLoaiBN = B.TenLoai" + "\r\n"
                    + "           from benhnhan bn" + "\r\n"
                    + "left join KB_LoaiUutien  A on bn.idloaiuutien=A.Id" + "\r\n"
                    + "left join KB_LoaiBN  B on bn.loai=B.Id" + "\r\n"
                    + "where 1=1 " + swhere;
        sqlSelect += " order by ngaytiepnhan desc";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>Mã bệnh nhân</th>";
        html += "<th>Tên bệnh nhân</th>";
        html += "<th>Loại ưu tiên</th>";
        html += "<th>Địa chỉ</th>";
        html += "<th>Ngày sinh</th>";
        html += "<th>Loại khám</th>";
        html += "<th>Ngày tiếp nhận</th>";
        html += "</tr>";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr style='cursor:pointer' onclick=\"setNoiDungChungNhan('" + table.Rows[i]["idbenhnhan"].ToString() + "')\">";
                html += "<td>" + table.Rows[i]["mabenhnhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["tenbenhnhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenLoai"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["diachi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["ngaysinh"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenLoaiBN"].ToString() + "</td>";
                if (table.Rows[i]["ngaytiepnhan"].ToString() != "")
                {
                    html += "<td>" + DateTime.Parse(table.Rows[i]["ngaytiepnhan"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>";
                }
                else { html += "<td>" + table.Rows[i]["ngaytiepnhan"].ToString() + "</td>"; }
                html += "</tr>";
            }
            html += "</table>";
            Response.Clear(); Response.Write(html);
            return;
        }
        else
        {
            Response.StatusCode = 500;
        }

    }
    private void nvk_setNoiDungChungNhan()
    {
        string idbenhnhan = Request.QueryString["idbenhnhan"];
        if (idbenhnhan == null || idbenhnhan == "" || idbenhnhan == "0")
        {
            Response.Clear();
            Response.Write("");
        }
        string strChungNhan = "";
        string sql = @"
select soCN='',txtSoVaoVien,TenBenhNhan,txtNgaySinh=bn.ngaysinh,txtGioiTinh=dbo.getgioitinh(bn.gioitinh)
	,txtNgheNghiep=TenNgheNghiep,txtNoiLamViec=bn.noicongtac,txtCMND=bn.chungminhthu
	,txtNgay_noiCM='',txtDiaChi=bn.diachi
	,txtVaoVienLuc=''
	,txtRaVienLuc=''
	,lyDoVaoVien=bn.lidovaovien,chanDoan='',dieuTri='',thuongTichVaovien='',thuongTichRavien=''
from (
select nn.*,bn.*,ngaydangky,txtSoVaoVien = isnull((select top 1 SOVAOVIEN from hs_benhnhanbhdongtien where id =dkk.IdBenhBHDongTien),'')
,ngayravien= isnull((select top 1 NgayXuatKhoa from benhnhanxuatkhoa where idchitietdangkykham =ct.idchitietdangkykham order by ngayxuatkhoa desc),getdate())
 from   benhnhan bn left join nghenghiep nn on nn.idNgheNghiep=bn.nghenghiep
	left join dangkykham dkk on dkk.idbenhnhan =bn.idbenhnhan --and iddangkykham =isnull((select top 1 iddangkykham from dangkykham where idbenhnhan =bn.idbenhnhan order by iddangkykham desc),0)
	left join chitietdangkykham ct on ct.iddangkykham =dkk.iddangkykham
 where bn.idbenhnhan ='" + idbenhnhan+@"'
) bn";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                strChungNhan += dt.Rows[0][i].ToString() + "|";
            }
            strChungNhan = strChungNhan.TrimEnd('|');
        }
        Response.Clear();
        Response.Write(strChungNhan);
    }
    private void loadicd()
    {
        string loai = Request.QueryString["loai"];
        string kytu = Request.QueryString["q"];
        string sql = "";
        if (loai == "ma")
        {
            sql = "select TOP 10 * from ChanDoanICD where maicd like N'%" + kytu + "%'";
        }
        else
        {
            sql = "select TOP 10 * from ChanDoanICD where mota like N'%" + kytu + "%'";
        }
        DataTable table =DataAcess.Connect.GetTable(sql);
        string html = "";


        if (table.Rows.Count > 0)
        {
            foreach (DataRow h in table.Rows)
            {
                html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div>"
                                                             +
                                                             "<div style=\"width:80px;float:left;overflow:hidden\" >" +
                                                             h["maicd"] + "</div>"
                                                             +
                                                             "<div style=\"width:400px;float:left;overflow:hidden\" >" +
                                                             h["mota"] + "</div>"
                                                             + "</div>", h["idicd"], h["maicd"],
                                      h["mota"], Environment.NewLine);
            }
        }

        Response.Clear();
        Response.Write(html);
    }
    private void TimBenhVien(bool IsTheoMa)
    {
        string html = "";
        string trsTenCT = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"].ToString() != "")
            trsTenCT = Request.QueryString["q"].ToString();
        string sql1 = "";
        if (IsTheoMa)
            sql1 = @"SELECT TOP 20 * from benhvien where mabenhvien LIKE N'%" + trsTenCT + "%'";
        else
            sql1 = @"SELECT TOP 20 * from benhvien where tenbenhvien LIKE N'%" + trsTenCT + "%'";
        DataTable tb1 = DataAcess.Connect.GetTable(sql1);
        if (tb1.Rows.Count < 1)
        {
            Response.Clear();
            Response.Write("false");
            Response.End();
            return;
        }
        else
        {
            foreach (DataRow h in tb1.Rows)
            {
                html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div>"
                + "<div style=\"width:15%;float:left\" >" + h["mabenhvien"] + "</div>"
                + "<div style=\"width:80%;float:left\" >" + h["tenbenhvien"] + "</div>"
                + "</div>", h["mabenhvien"], h["tenbenhvien"], h["idbenhvien"], Environment.NewLine);
            }
            Response.Clear();
            Response.Write(html);
            Response.End();
        }
    }
    private void TimChanDoan(bool IsTheoMa)
    {
        string html = "";
        string trsTenCT = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"].ToString() != "")
            trsTenCT = Request.QueryString["q"].ToString();
        string sql1 = "";
        if (IsTheoMa)
            sql1 = @"SELECT TOP 20 * from chandoanicd where maICD LIKE N'%" + trsTenCT + "%'";
        else
            sql1 = @"SELECT TOP 20 * from chandoanicd where MoTa LIKE N'%" + trsTenCT + "%'";
        DataTable tb1 = DataAcess.Connect.GetTable(sql1);
        if (tb1.Rows.Count < 1)
        {
            Response.Clear();
            Response.Write("false");
            Response.End();
            return;
        }
        else
        {
            foreach (DataRow h in tb1.Rows)
            {
                html += string.Format("{0}|{1}|{2}|{3}|{4}", "<div>"
                + "<div style=\"width:15%;float:left\" >" + h["maICD"] + "</div>"
                + "<div style=\"width:80%;float:left\" >" + h["MoTa"] + "</div>"
                + "</div>", h["maICD"], h["MoTa"], h["idICD"], Environment.NewLine);
            }
            Response.Clear();
            Response.Write(html);
            Response.End();
        }
    }
    private void TaoSVV_click()
    {
        string idctdkk = Request.QueryString["idctdkk"];
        string idkhoa = Request.QueryString["idkhoa"];
        string IsBANoiTru = Request.QueryString["IsBANoiTru"];
        if (idctdkk.Equals("0") || idctdkk.Equals("") || IsBANoiTru.Equals(""))
        {
            Response.Clear(); Response.Write(""); return;
        }
        string sqlSelect1 = @"SELECT IDBENHBHDONGTIEN 
                                FROM CHITIETDANGKYKHAM A
                                LEFT JOIN DANGKYKHAM B ON A.IDDANGKYKHAM=B.IDDANGKYKHAM
                                WHERE A.IDCHITIETDANGKYKHAM=" + idctdkk;
        DataTable dt1 = DataAcess.Connect.GetTable(sqlSelect1);
        if (dt1 == null || dt1.Rows.Count == 0)
        {Response.Clear(); Response.Write(""); return;};
        string IdBenhNhanBHDongTien = dt1.Rows[0][0].ToString();
        string sqlSave1 = "EXEC ZHS_MASOVAOVIEN " + IdBenhNhanBHDongTien + "," + IsBANoiTru;
        bool OK = DataAcess.Connect.ExecSQL(sqlSave1);
        if (!OK)
        { Response.Clear(); Response.Write(""); return; };
        string sqlSelect2 = "SELECT SOVAOVIEN FROM HS_BENHNHANBHDONGTIEN WHERE ID=" + IdBenhNhanBHDongTien;
        DataTable dt2 = DataAcess.Connect.GetTable(sqlSelect2);
        if (dt2 == null || dt2.Rows.Count == 0)
        { Response.Clear(); Response.Write(""); return; };
        string SoVaoVien = dt2.Rows[0][0].ToString();
        Response.Clear(); 
        Response.Write(SoVaoVien);

    }
 }
 
 
