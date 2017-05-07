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

public partial class nvk_BenhNhanChoSanh_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "btnTimKiem_click": btnTimKiem_click(); break;
         }
     }
    //tìm kiếm bệnh nhân chờ nhập khoa
    private void btnTimKiem_click()
    {
        System.Text.StringBuilder html = new System.Text.StringBuilder();
        string idkhoa = Request.QueryString["idkhoa"];
        string mabenhnhan = Request.QueryString["mabenhnhan"];
        string tenbenhnhan = Request.QueryString["tenbenhnhan"];
        string tungay = Request.QueryString["tungay"];
        string denngay = Request.QueryString["denngay"];
        if (idkhoa == null || idkhoa.Equals(""))
        {
            Response.Write("Chưa xác định khoa !");
            return;
        }
        string sqlChoNhap = @"
            select nt.idnoitru,nt.IdKhamBenhNhap,nt.idchitietdangkykham,nt.idbenhnhan,nt.idkhoanoitru,kb.iddangkykham
        ,idkbChoSanh=isnull( kb.idkhambenhmoi, isnull( (select top 1 idkhambenh from khambenh where idchitietdangkykham=nt.idchitietdangkykham and idphongkhambenh='" + idkhoa+@"' and idkhambenh > nt.idkhambenhnhap) ,0) )
            ,nt.idbenhnhan
            ,BN.MABENHNHAN
            ,BN.TENBENHNHAN
            ,BN.DIACHI
            ,BN.DIENTHOAI
            ,Gioi	 = case when isnull(gioitinh,0)=0 then N'Nam' else N'Nữ' end
            ,namsinh = ngaysinh
            ,ngayVaoCho= convert(varchar(10),nt.ngayvaovien,103)+' '+convert(varchar(5),nt.ngayvaovien,108)
            ,chuyentu =phong.maso +'-'+phong.tenphong
            ,GiuongNhap = isnull((select top 1 ph.giuongcode from benhnhannoitru bnt inner join kb_giuong ph on ph.GiuongId=bnt.IdGiuong where bnt.idchitietdangkykham= nt.idchitietdangkykham and bnt.idkhoanoitru='" + idkhoa + @"' and isChoSanh=1 order by bnt.idnoitru desc),'')

                    from benhnhannoitru nt inner join benhnhan bn on bn.idbenhnhan= nt.idbenhnhan
                    left join chitietdangkykham ctdkk on nt.idchitietdangkykham= ctdkk.idchitietdangkykham 
                    left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
                    left join kb_phong phong on ctdkk.phongid=phong.id
                    left join khambenh kb on kb.idkhambenh =nt.idkhambenhnhap
                    where nt.isChoSanh=1 and nt.isnhapkhoa=1 and nt.IsDaNhap=1 ";
                     
        #region nvk_dieukienSQL
        string nvk_dk = "";
        if (!mabenhnhan.Equals(""))
            nvk_dk += " and bn.mabenhnhan like N'%" + mabenhnhan + "%'";
        if (!tenbenhnhan.Equals(""))
            nvk_dk += " and bn.tenbenhnhan like N'%" + tenbenhnhan + "%'";
        if (!tungay.Equals(""))
            nvk_dk += " and nt.NgayVaoVien >='" + StaticData.CheckDate(tungay) + "'";
        if (!denngay.Equals(""))
            nvk_dk += " and nt.NgayVaoVien <='" + StaticData.CheckDate(denngay) + " 23:59:59'";
        sqlChoNhap += nvk_dk + " order by NgayVaoVien desc";
        #endregion
        DataTable dtChoNhap = DataAcess.Connect.GetTable(sqlChoNhap);
        if (dtChoNhap != null)
        {
            html.Append(nvk_htmlTableBenhChoSanh(dtChoNhap));
        }
        else
            html.Append("Lỗi khi load danh sách chờ !");
        Response.Clear();
        Response.Write(html);
    }
    private string nvk_htmlTableBenhChoSanh(DataTable table)
    {
        string html = "";
        #region header table 
        html += "<table class='jtable' id=\"gridTabledsNhapKhoa\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th style='width:60px'>Khám</th>";
        html += "<th style='width:60px'>TT Chờ</th>";
        html += "<th style='width:60px'>Nhập HS</th>";
        html += "<th style='width:110px'>Mã bệnh nhân</th>";
        html += "<th style='width:150px'>Tên bệnh nhân</th>";
        html += "<th>Địa chỉ</th>";
        html += "<th>Điện thoại</th>";
        html += "<th>Giới tính</th>";
        html += "<th>Ngày sinh</th>";
        html += "<th>Ngày cho nhập</th>";
        html += "<th>Nhập từ</th>";
        html += "<th>Giường chờ</th>";
        html += "</tr>";
        #endregion
        #region nội dung bênh nhân chờ 
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1) + "</td>";
            html += @"<td>";
            #region Insert khám bệnh mới
            string idkhambenhmoi = table.Rows[i]["idkbChoSanh"].ToString();
            if (idkhambenhmoi == null || idkhambenhmoi == "0" || idkhambenhmoi=="")
            {
                string sqlSelect1 = "SELECT * FROM KHAMBENH WHERE IDKHAMBENH=" + table.Rows[i]["idkhambenhnhap"].ToString();
                DataTable dtKB = DataAcess.Connect.GetTable(sqlSelect1);
                if (dtKB == null || dtKB.Rows.Count == 0) continue;
                string TGXuatVienPrev = dtKB.Rows[0]["TGXuatVien"].ToString();
                string NgayKhamPrev = dtKB.Rows[0]["NgayKham"].ToString();
                if (TGXuatVienPrev == "") TGXuatVienPrev = NgayKhamPrev;
                TGXuatVienPrev = DateTime.Parse(TGXuatVienPrev).ToString("dd/MM/yyyy");
                DataProcess KB = new DataProcess("khambenh");
                KB.data("idbenhnhan", table.Rows[i]["idbenhnhan"].ToString());
                KB.data("idchitietdangkykham", table.Rows[i]["idchitietdangkykham"].ToString());
                KB.data("iddangkykham", dtKB.Rows[0]["iddangkykham"].ToString());
                KB.data("ngaykham", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));//TGXuatVienPrev);
                //KB.data("TGXuatVien", TGXuatVienPrev);
                KB.data("idkhambenhchuyenphong", table.Rows[i]["idkhambenhnhap"].ToString());
                KB.data("idkhoa", table.Rows[i]["idkhoanoitru"].ToString());
                KB.data("IDPHONGKHAMBENH", table.Rows[i]["idkhoanoitru"].ToString());
                KB.data("idkhoachuyen", table.Rows[i]["idkhoanoitru"].ToString());
                KB.data("IdChuyenPK", StaticData.GetParaValueDB("IdPhongHauPhau"));
                bool OK = KB.Insert();
                if (!OK) continue;
                idkhambenhmoi = KB.getData("idkhambenh");
                bool OK2 = DataAcess.Connect.ExecSQL("UPDATE KHAMBENH SET IDKHAMBENHMOI=" + idkhambenhmoi + " WHERE IDKHAMBENH=" + table.Rows[i]["idkhambenhnhap"].ToString());
            }
            #endregion
            html += "<input type='button' value='Khám' style='width:60px;height:25px;background-color:#CAE3FF;background-image:none;font-weight:bold;color:Blue'  onclick=\"DongKhamChoSanh_Click(" + idkhambenhmoi + "," + table.Rows[i]["idchitietdangkykham"].ToString() + "," + table.Rows[i]["idbenhnhan"].ToString() + ",this);\"/>";
            html += @"</td>";
            html += @"<td>";
            html += "<input type='button' value='Đang chờ' style='width:65px;height:25px;background-color:#CAE3FF;background-image:none;color:Red'  onclick=\"DongVaoChoSanh_Click('" + table.Rows[i]["idnoitru"].ToString() + "','" + table.Rows[i]["IdKhamBenhNhap"].ToString() + "',this);\"/>";
            html += @"</td>";
            html += @"<td>";
            html += "<input type='button' value='Nhập HS' style='width:60px;height:25px;background: #E15625;color:white'  onclick=\"DongNhapHauSan_Click('" + table.Rows[i]["idnoitru"].ToString() + "','" + table.Rows[i]["IdKhamBenhNhap"].ToString() + "',this);\"/>";
            html += @"</td>";
            html += "<td>" + table.Rows[i]["mabenhnhan"] + "</td>";
            html += "<td>" + table.Rows[i]["tenbenhnhan"] + "</td>";
            html += "<td>" + table.Rows[i]["diachi"] + "</td>";
            html += "<td>" + table.Rows[i]["dienthoai"] + "</td>";
            html += "<td>" + table.Rows[i]["gioi"] + "</td>";
            html += "<td>" + table.Rows[i]["namsinh"] + "</td>";
            html += "<td>" + table.Rows[i]["ngayVaoCho"] + "</td>";
            html += "<td>" + table.Rows[i]["chuyentu"] + "</td>";
            html += "<td>" + table.Rows[i]["giuongnhap"] + "</td>";
            html += "</tr>";
        }
        #endregion
        #region đóng table
        html += "</table>";
        #endregion
        return html;
    }
}
 
 
