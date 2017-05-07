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
using Microsoft.Office;

public partial class nvk_TongHopYLenh_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "ShowDanhSachGiuongChon": NVK_ShowDanhSachGiuongChon(); break;
            case "getGiuongMotPhong": NVK_getGiuongMotPhong(); break;

            // y LỆNH NGOẠI TRÚ THEO BỆNH NHÂN
            case "ShowDanhSachBenhNhanChon": nvk_ShowDanhSachBenhNhanChon(); break;
            case "nvk_benhnhansearch": nvk_benhnhansearch(); break;
            ////
            case "LoadAll_BN_YLenh": LoadAll_BN_YLenh(); break;
            case "ShowDanhSachXoaBenhNhan": nvk_ShowDanhSachXoaBenhNhan(); break;
        }
    }
    private void LoadAll_BN_YLenh()
    {
        string idkhoa = Request.QueryString["IdKhoa"];
        string NoiYLenh = Request.QueryString["NoiYLenh"];
        string IdLoaiThuoc = Request.QueryString["IdLoaiThuoc"];
        string nvk_IdKhoThuoc = Request.QueryString["IdKhoThuoc"];
        string NgayYL = Request.QueryString["NgayYL"];
        string TuGio = Request.QueryString["TuGio"];
        string DenNgayYL = Request.QueryString["DenNgayYL"];
        string DenGio = Request.QueryString["DenGio"];
        string TuNgay_Gio = StaticData.CheckDate(NgayYL.Trim()) + " " + TuGio.Trim();
        string DenNgay_Gio = StaticData.CheckDate(DenNgayYL.Trim()) + " " + DenGio.Trim();
        #region LoaiYlenh
        string IdLoaiYLenh = Request.QueryString["IdLoaiYLenh"];
        string dkLoaiYL = "";
        if (!string.IsNullOrEmpty(IdLoaiYLenh))
        {
            if (IdLoaiYLenh.Equals("2"))// bổ sung, dự trù
                dkLoaiYL = " and isnull(kb.maphieukham,'')<>'pkxk'";
            if (IdLoaiYLenh.Equals("3"))// Toa ra viện
                dkLoaiYL = " and isnull(kb.maphieukham,'')='pkxk'";
        }
        #endregion
        string sqlBNYL = @"select distinct kb.idbenhnhan from --[NVK_DSBNNoiTruTheoKhoa_1]('" + idkhoa + @"') nt inner join 
                        khambenh kb 
		                inner join chitietbenhnhantoathuoc ct on ct.idkhambenh =kb.idkhambenh --and isnull(idbenhnhantoathuoc,0)=0
						inner join thuoc t on t.idthuoc = ct.idthuoc
						--inner join khothuoc k on k.idkho =ct.idkho and k.nvk_loaikho in(2,3)
                where  kb.idphongkhambenh='" + idkhoa + @"' and t.loaithuocid='" + IdLoaiThuoc + "' "+dkLoaiYL+@"
                --- điền kiện ngày
			                and (  ( ngaykham >='" + TuNgay_Gio + @"' and ngaykham <='" + DenNgay_Gio + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
                                or ( ngayDuTruThuoc >='" + TuNgay_Gio + @"' and ngayDuTruThuoc <='" + DenNgay_Gio + @"' )
                            )
                ---end điều kiện ngày
                ";
        if (Request.QueryString["isYLTra"] != null && Request.QueryString["isYLTra"].ToString().Equals("1"))
        {
            sqlBNYL = @"select distinct idbenhnhan from khambenh kb inner join chitietbenhnhantoathuoc ct on ct.idkhambenh=kb.idkhambenh
				inner join thuoc t on t.idthuoc = ct.idthuoc and t.loaithuocid='" + IdLoaiThuoc + "' "+dkLoaiYL+@"
            where kb.idphongkhambenh ='" + idkhoa + @"' and isnull(ct.soluongtra,0) >0
            and ngaykham >='" + TuNgay_Gio + "' and ngaykham <='" + DenNgay_Gio + "' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')=''";
        }
        if (nvk_IdKhoThuoc != null && !nvk_IdKhoThuoc.Equals("0") && !nvk_IdKhoThuoc.Equals(""))
        {
            sqlBNYL += " and ct.idkho='" + nvk_IdKhoThuoc + "'";
        }
        DataTable dtBNYL = DataAcess.Connect.GetTable(sqlBNYL);
        string ListBNYL = "";
        if (dtBNYL != null && dtBNYL.Rows.Count > 0)
        {
            for (int i = 0; i < dtBNYL.Rows.Count; i++)
            {
                ListBNYL += dtBNYL.Rows[i]["idbenhnhan"].ToString() + ",";
            }
        }
        ListBNYL = ListBNYL.TrimEnd(',');

        #region list idgiuong
        if (!NoiYLenh.ToLower().Equals("capcuu") && !NoiYLenh.ToLower().Equals("phongsanh") && !NoiYLenh.ToLower().Equals("khoaphauthuat") && !NoiYLenh.ToLower().Equals("tansoi") && !NoiYLenh.ToLower().Equals("hoatri") && !ListBNYL.Equals(""))
        {
            string sqlG = "";
            if (Request.QueryString["isYLTra"] != null && Request.QueryString["isYLTra"].ToString().Equals("1"))
            {
                sqlG = @"select distinct idgiuong from benhnhannoitru nt where  idbenhnhan in(" + ListBNYL + @") and isnull(idgiuong,0)>0 and idkhoanoitru ='" + idkhoa + "'";
            }
            else
                sqlG = @"select distinct idgiuong from benhnhannoitru nt where idbenhnhan in(" + ListBNYL + @") and isnull(idgiuong,0)>0  and idkhoanoitru='" + idkhoa + "' ";
            DataTable dtG = DataAcess.Connect.GetTable(sqlG);
            if (dtG != null && dtG.Rows.Count > 0)
            {
                ListBNYL += "@~@";
                for (int i = 0; i < dtG.Rows.Count; i++)
                {
                    ListBNYL += dtG.Rows[i]["idgiuong"].ToString() + ",";
                }
            }
            else
            {
                ListBNYL = "";
            }
            ListBNYL = ListBNYL.TrimEnd(',');
        }
        #endregion

        Response.Clear();
        Response.Write(ListBNYL);
    }
    private void NVK_ShowDanhSachGiuongChon()
    {
        string idkhoa = Request.QueryString["IdKhoa"];
        string list_id_giuong = Request.QueryString["ListIdGiuong"];
        string list_id_benhnhan = Request.QueryString["ListIdBenhnhan"];
        string id_giuong = Request.QueryString["idGiuong"];
        string tinh_trang_check = Request.QueryString["tinhtrangCheck"];
        string StrHienBN = Request.QueryString["IsHienBN"] != null ? Request.QueryString["IsHienBN"].ToString().Trim().ToLower() : "false";
        bool IsHienBN = StrHienBN.Equals("true") ? true : false;
        #region Loai Thuốc, ngày giờ
        string IdLoaiThuoc = Request.QueryString["IdLoaiThuoc"];
        string nvk_IdKhoThuoc = Request.QueryString["IdKhoThuoc"];
        string NgayYL = Request.QueryString["NgayYL"];
        string TuGio = Request.QueryString["TuGio"];
        string DenNgayYL = Request.QueryString["DenNgayYL"];
        string DenGio = Request.QueryString["DenGio"];
        string TuNgay_Gio = StaticData.CheckDate(NgayYL.Trim()) + " " + TuGio.Trim();
        string DenNgay_Gio = StaticData.CheckDate(DenNgayYL.Trim()) + " " + DenGio.Trim();
        #endregion
        #region LoaiYlenh
        string IdLoaiYLenh = Request.QueryString["IdLoaiYLenh"];
        string dkLoaiYL = "";
        if (!string.IsNullOrEmpty(IdLoaiYLenh))
        {
            if (IdLoaiYLenh.Equals("2"))// bổ sung, dự trù
                dkLoaiYL = " and isnull(kb.maphieukham,'')<>'pkxk'";
            if (IdLoaiYLenh.Equals("3"))// Toa ra viện
                dkLoaiYL = " and isnull(kb.maphieukham,'')='pkxk'";
        }
        #endregion
        string ListResultIdG = "";
        string htmlDanhSachGiuong = "Danh sách";
        #region Cập nhật list idgiuong
        if (tinh_trang_check.Equals("0"))
        {
            string[] arrGiuong = list_id_giuong.TrimStart(',').TrimEnd(',').Split(',');
            for (int i = 0; i < arrGiuong.Length; i++)
            {
                if (arrGiuong[i] == id_giuong)
                    continue;
                else
                    ListResultIdG += arrGiuong[i] + ",";
            }
        }
        else
        {
            ListResultIdG = list_id_giuong.TrimEnd(',') + "," + id_giuong;
        }
        ListResultIdG = ListResultIdG.TrimEnd(',').TrimStart(',');
        #endregion

        #region Cập nhật list idbenhnhan theo list giường
        if (ListResultIdG == "") ListResultIdG = "-1";
        string ListResultIdBenhNhan = "";
        string sqlListBN_TheoG = "";
        if (Request.QueryString["isYLTra"] != null && Request.QueryString["isYLTra"].ToString().Equals("1"))
        {
            sqlListBN_TheoG = @"select distinct nt.idbenhnhan from benhnhannoitru nt  inner join khambenh kb on kb.idchitietdangkykham=nt.idchitietdangkykham 
			                 ngaykham >='" + TuNgay_Gio + @"' and ngaykham <='" + DenNgay_Gio + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')=''
		                inner join chitietbenhnhantoathuoc ct on ct.idkhambenh =kb.idkhambenh --and isnull(idbenhnhantoathuoc,0)=0
						inner join thuoc t on t.idthuoc = ct.idthuoc and t.loaithuocid='" + IdLoaiThuoc + "' "+dkLoaiYL+@"
             where idgiuong =" + id_giuong + @"--and isdanhap=1 ";
        }
        else
        {
            sqlListBN_TheoG = @"select distinct nt.idbenhnhan from benhnhannoitru nt  
                        inner join khambenh kb on kb.idchitietdangkykham=nt.idchitietdangkykham 
		                inner join chitietbenhnhantoathuoc ct on ct.idkhambenh =kb.idkhambenh --and isnull(idbenhnhantoathuoc,0)=0
						inner join thuoc t on t.idthuoc = ct.idthuoc and t.loaithuocid='" + IdLoaiThuoc + @"'
						inner join khothuoc k on k.idkho =ct.idkho and k.nvk_loaikho in(2,3)
             where idgiuong =" + id_giuong + " "+dkLoaiYL+@"
			                and (  ( ngaykham >='" + TuNgay_Gio + @"' and ngaykham <='" + DenNgay_Gio + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
                                or ( ngayDuTruThuoc >='" + TuNgay_Gio + @"' and ngayDuTruThuoc <='" + DenNgay_Gio + @"' )
                            )
                                and exists (select idbenhnhan from benhnhannoitru where idchitietdangkykham = nt.idchitietdangkykham  and idkhoanoitru='" + idkhoa + "' )";
        }

        if (nvk_IdKhoThuoc != null && !nvk_IdKhoThuoc.Equals("0") && !nvk_IdKhoThuoc.Equals(""))
        {
            sqlListBN_TheoG += " and ct.idkho='" + nvk_IdKhoThuoc + "'";
        }
        DataTable dtList_BN = DataAcess.Connect.GetTable(sqlListBN_TheoG);

        #region bỏ list BN cũ
        if (tinh_trang_check.Equals("0"))
        {
            string[] arrIdBenhNhan = list_id_benhnhan.TrimStart(',').TrimEnd(',').Split(',');
            for (int i = 0; i < arrIdBenhNhan.Length; i++)
            {
                bool IsAdd = true;
                for (int k = 0; k < dtList_BN.Rows.Count; k++)
                {
                    string idbn_k = dtList_BN.Rows[k]["idbenhnhan"].ToString().Trim();
                    if (arrIdBenhNhan[i] == idbn_k)
                    {
                        IsAdd = false;
                        break; // bỏ đi idbenhnhan K trong danh sách
                    }
                }
                if (IsAdd)
                    ListResultIdBenhNhan += arrIdBenhNhan[i] + ",";

            }
        }
        else
        {
            ListResultIdBenhNhan = list_id_benhnhan.TrimEnd(',') + ",";
            for (int k = 0; k < dtList_BN.Rows.Count; k++)
            {
                ListResultIdBenhNhan += dtList_BN.Rows[k]["idbenhnhan"].ToString().Trim() + ",";
            }
        }
        #endregion
        //for (int i = 0; i < dtList_BN.Rows.Count; i++)
        //{
        //    ListResultIdBenhNhan += dtList_BN.Rows[i]["idbenhnhan"] +",";
        //}
        ListResultIdBenhNhan = ListResultIdBenhNhan.TrimEnd(',').TrimStart(',');

        #endregion

        #region htmlDanhSachGiuong được chọn
        string sqlGiuong = "";
        if (!IsHienBN)
            sqlGiuong = @"select stt=row_number()over(order by tenphong),Giuongid,Giuongcode,tenphong,tengiuong='- '+Giuongcode+' ('+tenphong+')' from kb_giuong g left join kb_phong p on g.idphong=p.id where g.Giuongid in (" + ListResultIdG + ") order by tenphong"; //nvk comment
        else
        {
            sqlGiuong = @"
            select stt=row_number()over(order by idbenhnhan),* from (
                select distinct bn.idbenhnhan,Giuongid,Giuongcode,tenphong,tengiuong='- '+Giuongcode+' ('+tenphong+')'
                                    ,ma_tenBenhNhan ='('+bn.mabenhnhan+') '+bn.tenbenhnhan
                       from kb_giuong g left join kb_phong p on g.idphong=p.id
	                                left join benhnhannoitru nt on nt.idgiuong=g.giuongid --and isdanhap=1
                                and g.giuongid in (select top  1 idgiuong from benhnhannoitru where idbenhnhan =nt.idbenhnhan order by ngayvaovien desc)
	                                left join benhnhan bn on bn.idbenhnhan=nt.idbenhnhan
                       where bn.idbenhnhan in(" + (ListResultIdBenhNhan.Equals("") ? "0" : ListResultIdBenhNhan) + @")
                )as abc";
        }
        DataTable dtGiuong = DataAcess.Connect.GetTable(sqlGiuong);
        if (dtGiuong.Rows.Count > 0 && !ListResultIdG.Equals("") && !ListResultIdBenhNhan.Equals(""))
        {
            htmlDanhSachGiuong = NVK_GetTableGiuongBaoCao(dtGiuong, IsHienBN);
        }
        else
        {
            htmlDanhSachGiuong = "CHƯA MỘT GIƯỜNG NÀO ĐƯỢC CHỌN !";
            ListResultIdG = "";
            ListResultIdBenhNhan = "";
        }
        #endregion

        Response.Clear();
        Response.Write(ListResultIdG + "@~@" + htmlDanhSachGiuong + "@~@" + ListResultIdBenhNhan);

    }
    private void nvk_ShowDanhSachXoaBenhNhan()
    {
        string list_id_giuong = Request.QueryString["ListIdGiuong"];
        string list_id_benhnhan = Request.QueryString["ListIdBenhnhan"];
        string idBenhNhanXoa = Request.QueryString["idBenhNhanXoa"];
        string tinh_trang_check = Request.QueryString["tinhtrangCheck"];
        string StrHienBN = Request.QueryString["IsHienBN"] != null ? Request.QueryString["IsHienBN"].ToString().Trim().ToLower() : "false";
        bool IsHienBN = StrHienBN.Equals("true") ? true : false;
        #region ngày giờ
        string IdLoaiThuoc = Request.QueryString["IdLoaiThuoc"];
        string NgayYL = Request.QueryString["NgayYL"];
        string TuGio = Request.QueryString["TuGio"];
        string DenNgayYL = Request.QueryString["DenNgayYL"];
        string DenGio = Request.QueryString["DenGio"];
        string TuNgay_Gio = StaticData.CheckDate(NgayYL.Trim()) + " " + TuGio.Trim();
        string DenNgay_Gio = StaticData.CheckDate(DenNgayYL.Trim()) + " " + DenGio.Trim();
        #endregion
        #region LoaiYlenh
        string IdLoaiYLenh = Request.QueryString["IdLoaiYLenh"];
        string dkLoaiYL = "";
        if (!string.IsNullOrEmpty(IdLoaiYLenh))
        {
            if (IdLoaiYLenh.Equals("2"))// bổ sung, dự trù
                dkLoaiYL = " and isnull(kb.maphieukham,'')<>'pkxk' ";
            if (IdLoaiYLenh.Equals("3"))// Toa ra viện
                dkLoaiYL = " and isnull(kb.maphieukham,'')='pkxk' ";
        }
        #endregion
        string ListResultIdBenhNhan = "";
        string htmlDanhSachGiuong = "Danh sách";

        #region Cập nhật list Bệnh nhân
        string[] arrBenhNhan = list_id_benhnhan.TrimStart(',').TrimEnd(',').Split(',');
        for (int i = 0; i < arrBenhNhan.Length; i++)
        {
            if (arrBenhNhan[i] == idBenhNhanXoa)
                continue;
            else
                ListResultIdBenhNhan += arrBenhNhan[i] + ",";
        }
        ListResultIdBenhNhan = ListResultIdBenhNhan.TrimEnd(',');

        #endregion

        #region Cập nhật list idgiuong theo list bệnh nhân
        string ListResultIdG = "";
        if (ListResultIdBenhNhan == "") ListResultIdBenhNhan = "-1";
        string sqlListG_TheoBN = @"select distinct nt.idgiuong from benhnhannoitru nt  inner join khambenh kb on kb.idchitietdangkykham=nt.idchitietdangkykham 
		                inner join chitietbenhnhantoathuoc ct on ct.idkhambenh =kb.idkhambenh --and isnull(idbenhnhantoathuoc,0)=0
						inner join thuoc t on t.idthuoc = ct.idthuoc and t.loaithuocid='" + IdLoaiThuoc + @"'
						inner join khothuoc k on k.idkho =ct.idkho and k.nvk_loaikho in(2,3)
             where  nt.idbenhnhan in (" + ListResultIdBenhNhan + ") "+dkLoaiYL+@"
			                and (  ( ngaykham >='" + TuNgay_Gio + @"' and ngaykham <='" + DenNgay_Gio + @"' and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='')
                                or ( ngayDuTruThuoc >='" + TuNgay_Gio + @"' and ngayDuTruThuoc <='" + DenNgay_Gio + @"' )
                            )
                                and idnoitru in (select top 1 idnoitru from benhnhannoitru where idchitietdangkykham = nt.idchitietdangkykham and isdanhap=1 order by ngayvaovien desc)";
        DataTable dtList_Giuong = DataAcess.Connect.GetTable(sqlListG_TheoBN);
        for (int i = 0; i < dtList_Giuong.Rows.Count; i++)
        {
            ListResultIdG += dtList_Giuong.Rows[i]["idgiuong"] + ",";
        }
        ListResultIdG = ListResultIdG.TrimEnd(',').TrimStart(',');

        #endregion

        #region htmlDanhSachGiuong được chọn
        string sqlGiuong = "";
        sqlGiuong = @"
                    select stt=row_number()over(order by tenphong),bn.idbenhnhan,Giuongid,Giuongcode,tenphong,tengiuong='- '+Giuongcode+' ('+tenphong+')'
                        ,ma_tenBenhNhan ='('+bn.mabenhnhan+') '+bn.tenbenhnhan
                    from kb_giuong g left join kb_phong p on g.idphong=p.id
	                    left join benhnhannoitru nt on nt.idgiuong=g.giuongid and isdanhap=1
	                    left join benhnhan bn on bn.idbenhnhan=nt.idbenhnhan
                    where bn.idbenhnhan in(" + (ListResultIdBenhNhan.Equals("") ? "0" : ListResultIdBenhNhan) + @")
                     order by tenphong";
        DataTable dtGiuong = DataAcess.Connect.GetTable(sqlGiuong);
        if (dtGiuong.Rows.Count > 0 && !ListResultIdG.Equals("") && !ListResultIdBenhNhan.Equals(""))
        {
            htmlDanhSachGiuong = NVK_GetTableGiuongBaoCao(dtGiuong, true);
        }
        else
        {
            htmlDanhSachGiuong = "CHƯA MỘT GIƯỜNG NÀO ĐƯỢC CHỌN !";
            ListResultIdG = "";
            ListResultIdBenhNhan = "";
        }
        #endregion

        Response.Clear();
        Response.Write(ListResultIdG + "@~@" + htmlDanhSachGiuong + "@~@" + ListResultIdBenhNhan);

    }
    private string NVK_GetTableGiuongBaoCao(DataTable dt, bool isHienBN)
    {
        string html = "";//DANH SÁCH GIƯỜNG ĐÃ CHỌN <br/>
        int SoDong = dt.Rows.Count / 2;
        html += "<table class='jtable' id=\"gridFather\">";
        html += "<tr>";
        #region Cột 1
        html += "<td>";
        html += "<table class='jtable' id=\"gridTableCot1\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        if (!isHienBN)
        {
            html += "<th>Tên giường</th>"; //nvk comment
            html += "<th>Phòng</th>";
        }
        else
        {
            html += "<th>Bệnh nhân</th>";
            html += "<th>Giường/Phòng</th>";
        }
        html += "</tr>";

        for (int i = 0; i < SoDong; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1) + "</td>";
            if (!isHienBN)
            {
                html += "<td><a onclick='xoaGiuongTable(" + dt.Rows[i]["Giuongid"] + ")'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td>" + dt.Rows[i]["giuongcode"] + "</td>"; //nvk comment
                html += "<td>" + dt.Rows[i]["tenphong"] + "</td>";
            }
            else
            {
                html += "<td><a onclick='xoaBenhNhanTable(" + dt.Rows[i]["idbenhnhan"] + ")'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td>" + dt.Rows[i]["ma_tenBenhNhan"] + "</td>";
                html += "<td>" + dt.Rows[i]["tengiuong"] + "</td>";
            }
            html += "</tr>";
        }
        html += "</table>";
        html += "</td>";
        #endregion
        #region Cột 2
        html += "<td>";
        html += "<table class='jtable' id=\"gridTableCot2\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        if (!isHienBN)
        {
            html += "<th>Tên giường</th>";
            html += "<th>Phòng</th>";
        }
        else
        {
            html += "<th>Bệnh nhân</th>";
            html += "<th>Giường/Phòng</th>";
        }
        html += "</tr>";

        for (int i = SoDong; i < dt.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1) + "</td>";
            if (!isHienBN)
            {
                html += "<td><a onclick='xoaGiuongTable(" + dt.Rows[i]["Giuongid"] + ")'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td>" + dt.Rows[i]["Giuongcode"] + "</td>"; //nvk comment
                html += "<td>" + dt.Rows[i]["tenphong"] + "</td>";
            }
            else
            {
                html += "<td><a onclick='xoaBenhNhanTable(" + dt.Rows[i]["idbenhnhan"] + ")'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td>" + dt.Rows[i]["ma_tenBenhNhan"] + "</td>";
                html += "<td>" + dt.Rows[i]["tengiuong"] + "</td>";
            }
            html += "</tr>";
        }
        html += "</table>";
        html += "</td>";
        #endregion
        html += "</tr>";
        html += "</table>";
        html += @"<input type='button' value='Mới' id='btnClearCTG'  onclick='ClearDanhSachGiuong();'/>";
        return html;
    }
    private void NVK_getGiuongMotPhong()
    {
        string list_id_giuong = Request.QueryString["ListIdGiuong"];
        string idPhong = Request.QueryString["idphong"];
        string htmlGiuong = "";
        string sql = "select Giuongid,Giuongcode,tenphong from kb_giuong g left join kb_phong p on g.idphong=p.id where g.idphong=" + idPhong;
        DataTable dtGiuongPhong = DataAcess.Connect.GetTable(sql);
        if (dtGiuongPhong != null && dtGiuongPhong.Rows.Count > 0)
        {
            string[] arrGiuong = list_id_giuong.TrimStart(',').TrimEnd(',').Split(',');
            htmlGiuong = "DANH SÁCH GIƯỜNG PHÒNG \"" + dtGiuongPhong.Rows[0]["tenphong"].ToString() + "\":  <br />";
            for (int i = 0; i < dtGiuongPhong.Rows.Count; i++)
            {
                string check = "";
                for (int j = 0; j < arrGiuong.Length; j++)
                {
                    if (arrGiuong[j] == dtGiuongPhong.Rows[i]["giuongid"].ToString())
                    {
                        check = "Checked='true'"; break;
                    }
                }
                htmlGiuong += "<input type='checkbox'  onclick='setCheckGiuong(this)'  name='nhomCheckbox' " + check + " id='" + dtGiuongPhong.Rows[i]["giuongid"] + "' value='" + dtGiuongPhong.Rows[i]["giuongid"] + "'/>" + dtGiuongPhong.Rows[i]["Giuongcode"] + " <br />";
            }
            htmlGiuong += "<br /><input type='button' value='Đóng' id='btndongCTG'  onclick='CloseDivGiuong();'/>";
        }
        Response.Clear();
        Response.Write(htmlGiuong);
        return;
    }

    #region y lênh ngoại trú
    private void nvk_benhnhansearch()
    {
        string TenSearch = Request.QueryString["q"];
        string sql = @"select  top 20 * from (
                select  idbenhnhan,mabenhnhan,tenbenhnhan,diachi,ngaysinh,gioitinh=dbo.getgioitinh(gioitinh)
                ,tensearch=mabenhnhan+' | '+tenbenhnhan
                from benhnhan
                ) as nvk where tensearch like N'%" + TenSearch + "%'";
        DataTable table = DataAcess.Connect.GetTable(sql);

        string html = "";
        html = string.Format("{0}|{1}|{2}", ""
       + "<div style =\"color:#000;position:absolute;top:0px;left:-2px;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
       + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >STT</div>"
       + "<div style=\"width:20%;height:30px;color:#000;font-weight:bold;float:left\" >Mã BN</div>"
       + "<div style=\"width:25%;height:30px;color:#000;font-weight:bold;float:left\" >Tên BN</div>"
       + "<div style=\"width:35%;height:30px;color:#000;font-weight:bold;float:left\" >ĐC</div>"
       + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >NS</div>"
       + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >Giới</div>"
       + "</div><br/>", "", "", "", Environment.NewLine);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            if (i == 0)
            {
                html += string.Format("{0}|{1}|{2}", "<div>"
                + "<div style=\"width:5%;height:30px;float:left\" >" + (i + 1) + "</div>"
                + "<div style=\"width:20%;height:30px;float:left\" >null</div>"
                + "<div style=\"width:25%;height:30px;float:left\" >null</div>"
                + "<div style=\"width:35%;height:30px;color:#000;font-weight:bold;float:left\" >null</div>"
                + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >null</div>"
                + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >null</div>"
                 + "</div>", null, Environment.NewLine);
            }
            DataRow h = table.Rows[i];
            html += string.Format("{0}|{1}|{2}", "<div>"
        + "<div style=\"width:5%;height:30px;float:left\" >" + (i + 1) + "</div>"
        + "<div style=\"width:20%;height:30px;float:left\" >" + h["mabenhnhan"] + "</div>"
        + "<div style=\"width:25%;height:30px;float:left\" >" + h["tenbenhnhan"] + "</div>"
        + "<div style=\"width:35%;height:30px;color:#000;font-weight:bold;float:left\" >" + h["diachi"] + "</div>"
        + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >" + h["ngaysinh"] + "</div>"
        + "<div style=\"width:5%;height:30px;color:#000;font-weight:bold;float:left\" >" + h["gioitinh"] + "</div>"
         + "</div>", h["idbenhnhan"], Environment.NewLine);
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void nvk_ShowDanhSachBenhNhanChon()
    {
        string list_id_giuong = Request.QueryString["ListIdBN"];
        string idbenhnhan = Request.QueryString["idBN"];
        string tinh_trang_check = Request.QueryString["tinhtrangCheck"];
        string ListResultIdG = "";
        string htmlDanhSachGiuong = "Danh sách";
        #region Cập nhật list idBenhNhan
        if (!idbenhnhan.Equals("0") && !idbenhnhan.Equals(""))
        {
            if (tinh_trang_check.Equals("0"))
            {
                string[] arrGiuong = list_id_giuong.TrimStart(',').TrimEnd(',').Split(',');
                for (int i = 0; i < arrGiuong.Length; i++)
                {
                    if (arrGiuong[i] == idbenhnhan)
                        continue;
                    else
                        ListResultIdG += arrGiuong[i] + ",";
                }
                ListResultIdG = ListResultIdG.TrimEnd(',');
            }
            else
            {
                ListResultIdG = list_id_giuong.TrimStart(',').TrimEnd(',') + "," + idbenhnhan;
            }
        }
        else
            ListResultIdG = list_id_giuong.TrimStart(',').TrimEnd(',');
        ListResultIdG = ListResultIdG.TrimStart(',').TrimEnd(',');
        if (ListResultIdG.Equals(""))
            ListResultIdG = "0";
        #endregion
        #region htmlDanhSach BN được chọn
        if (ListResultIdG == "") ListResultIdG = "0";
        string sqlGiuong = @"select idbenhnhan,mabenhnhan,tenbenhnhan  from benhnhan where idbenhnhan in (" + ListResultIdG + ") order by tenbenhnhan";
        DataTable dtGiuong = DataAcess.Connect.GetTable(sqlGiuong);
        if (dtGiuong.Rows.Count > 0)
        {
            htmlDanhSachGiuong = NVK_GetTableBenhNhanBaoCao(dtGiuong);
        }
        else
            htmlDanhSachGiuong = "CHƯA MỘT BỆNH NHÂN NÀO ĐƯỢC CHỌN !";
        #endregion
        Response.Clear();
        Response.Write(ListResultIdG + "@~@" + htmlDanhSachGiuong);

    }
    private string NVK_GetTableBenhNhanBaoCao(DataTable dt)
    {
        string html = "";//DANH SÁCH BỆNH NHÂN ĐÃ CHỌN <br/>
        int SoDong = dt.Rows.Count / 2;
        html += "<table class='jtable' id=\"gridFather\">";
        html += "<tr>";
        #region Cột 1
        html += "<td>";
        html += "<table class='jtable' id=\"gridTableCot1\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Mã BN</th>";
        html += "<th>Tên BN</th>";
        html += "</tr>";

        for (int i = 0; i < SoDong; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1) + "</td>";
            html += "<td><a onclick='setBenhNhan(" + dt.Rows[i]["idbenhnhan"] + ",0)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td>" + dt.Rows[i]["mabenhnhan"] + "</td>";
            html += "<td>" + dt.Rows[i]["tenbenhnhan"] + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        html += "</td>";
        #endregion
        #region Cột 2
        html += "<td>";
        html += "<table class='jtable' id=\"gridTableCot2\">";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>Mã BN</th>";
        html += "<th>Tên BN</th>";
        html += "</tr>";

        for (int i = SoDong; i < dt.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1) + "</td>";
            html += "<td><a onclick='setBenhNhan(" + dt.Rows[i]["idbenhnhan"] + ",0)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td>" + dt.Rows[i]["mabenhnhan"] + "</td>";
            html += "<td>" + dt.Rows[i]["tenbenhnhan"] + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        html += "</td>";
        #endregion
        html += "</tr>";
        html += "</table>";
        html += @"<input type='button' value='Mới' style='width:70px' id='btnClearCTG'  onclick='ClearDanhSachGiuong();'/>";
        return html;
    }
    #endregion
}


