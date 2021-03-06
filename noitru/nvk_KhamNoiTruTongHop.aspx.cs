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

using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Text;
public partial class nvk_KhamNoiTruTongHop : Genaratepage
{
    string strSearch;
    string dkmenu = null;
    private string login_IdBacsi = null;
    string IdKhoakhambenh;
    static string maKhoakhambenh;
    private static DataTable stdtBenhNhanCho;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(DataAcess.Connect.GetConnectionString());
        if (!IsPostBack)
        {
            if (Request.QueryString["controlName"] != null)
            {
                Result(Request.QueryString["controlName"].ToString());
            }
            else
            {
                string sqlBN = @"
                select * from ( (

                select  distinct  dbo.idchitietdangkykham,dbo.idbenhnhan,mabenhnhan,tenbenhnhan,diachi,LoaiKham=Loai.MaLoaiBN,dk.ngaydangky
                ,case when isnull(bn.gioitinh,0)=1 then N'Nữ' else N'Nam' end as Gioi
                        ,dienthoai,gioitinh,ngaysinh as namsinh 
                        ,iddichvugoc=bg.idbanggiadichvu
                        ,dbo.ngaynhapvien
						,idkhoanoitru=" + Request.QueryString["idkhoa"] + @"
						,isTamTheoDoi=0
                        from  dbo.[NVK_DSBNNoiTruTheoKhoa_1](" + Request.QueryString["idkhoa"] + @")  dbo
                inner join benhnhan bn on bn.idbenhnhan= dbo.idbenhnhan
                        inner join chitietdangkykham ctdkk on dbo.idchitietdangkykham= ctdkk.idchitietdangkykham 
        		inner join dangkykham dk on dk.iddangkykham=ctdkk.iddangkykham
                        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
                        left join kb_phong phong on ctdkk.phongid=phong.id
                    left join kb_loaiBN Loai on Loai.id=dk.LoaiKhamID
                        where 1=1 --and (isnull(kb.hoantat,0)=0 or kb.idphongkhambenh=1 )  and isnull(kb.idkhambenhgoc,0)=0
)union(
select  distinct  dbo.idchitietdangkykham,dbo.idbenhnhan,mabenhnhan,tenbenhnhan,diachi,LoaiKham=Loai.MaLoaiBN,dk.ngaydangky
                ,case when isnull(bn.gioitinh,0)=1 then N'Nữ' else N'Nam' end as Gioi
                        ,dienthoai,gioitinh,ngaysinh as namsinh 
                        ,iddichvugoc=bg.idbanggiadichvu
                        ,ngaynhapvien= (SELECT TOP 1 NGAYVAOVIEN FROM BENHNHANNOITRU KK WHERE KK.IDCHITIETDANGKYKHAM=dbo.IDCHITIETDANGKYKHAM   ORDER BY KK.IDNOITRU ASC)
						,idkhoanoitru=dbo.idkhoanoitru
						,isTamTheoDoi=1
from  benhnhannoitru  dbo
                inner join benhnhan bn on bn.idbenhnhan= dbo.idbenhnhan
                inner join chitietdangkykham ctdkk on dbo.idchitietdangkykham= ctdkk.idchitietdangkykham 
        		inner join dangkykham dk on dk.iddangkykham=ctdkk.iddangkykham
                        left join banggiadichvu bg on bg.idbanggiadichvu=ctdkk.idbanggiadichvu
                        left join kb_phong phong on ctdkk.phongid=phong.id
                    left join kb_loaiBN Loai on Loai.id=dk.LoaiKhamID
                        where dbo.idkhoanoitru ='" + Request.QueryString["idkhoa"] + @"' and 
                            dbo.isTamTheoDoi=1 and isdanhap=0  
)
) as nvk order by isTamTheoDoi desc,ngaynhapvien desc
";
                DataTable table = DataAcess.Connect.GetTable(sqlBN);
                stdtBenhNhanCho = table;
                if (table != null)
                    divDSBN.InnerHtml = DanhSachBenhNhanCho(table);
            }
        }
        //if (Request.QueryString["dkmenu"].ToString().ToLower().Equals("khoasan"))
        //    PlaceHolder1.Controls.Add(LoadControl("~/khoasan/uscmenu_1808.ascx"));
        //else
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
    [WebMethod]
    public static string Result(string controlName)
    {
        return RenderControl(controlName);
    }

    public static string RenderControl(string controlName)
    {
        Page page = new Page();
        UserControl userControl = (UserControl)page.LoadControl(controlName);
        userControl.EnableViewState = false;
        HtmlForm form = new HtmlForm();
        form.Controls.Add(userControl);
        page.Controls.Add(form);

        StringWriter textWriter = new StringWriter();
        HttpContext.Current.Server.Execute(page, textWriter, false);
        return textWriter.ToString();
    }
    private string DanhSachBenhNhanCho(DataTable table)
    {
        string html = "";
        if (table.Rows.Count > 0)
        {
            html = "<table class='jtable' id=\"gridTabledskb\">";
            html += "<tr>";
            html += "<th>STT</th>";
            html += "<th></th>";
            html += "<th>Mã bệnh nhân</th>";
            html += "<th>Tên bệnh nhân</th>";
            //html += "<th>Địa chỉ</th>";
            html += "<th>Giới</th>";
            html += "<th>NS</th>";
            html += "<th>Khám</th>";
            html += "<th>Ngày nhập viện</th>";
            html += "<th></th>";
            html += "</tr>";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += "<tr >";//onclick=\"SetBenhNhanDangKham('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idchitietdangkykham"].ToString() + "');\"
                html += "<td>" + (i + 1) + "</td>";//table.Rows[i]["stt"].ToString()

                html += "<td><input type='button' value='Chọn' style='width:50px;height:23px;color:Blue;background-image:none'  onclick=\"SetBenhNhanDangKham('" + table.Rows[i]["idbenhnhan"].ToString() + "','" + table.Rows[i]["idchitietdangkykham"].ToString() + "');\"/></td>";
                html += "<td>" + table.Rows[i]["MaBenhNhan"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["TenBenhNhan"].ToString() + "</td>";
                //html += "<td>" + table.Rows[i]["DiaChi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["Gioi"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["namsinh"].ToString() + "</td>";
                html += "<td>" + table.Rows[i]["LoaiKham"].ToString() + "</td>";
                if (table.Columns.IndexOf("ngaynhapvien") != -1)
                {
                    html += "<td>" + DateTime.Parse(table.Rows[i]["ngaynhapvien"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>";
                }
                else
                {
                    if (table.Rows[i]["ngaydangky"].ToString() != "")
                    {
                        html += "<td>" + DateTime.Parse(table.Rows[i]["ngaydangky"].ToString()).ToString("dd/MM/yyyy HH:mm") + "</td>";
                    }
                    else { html += "<td>" + table.Rows[i]["ngaydangky"].ToString() + "</td>"; }
                }
                if (table.Rows[i]["isTamTheoDoi"].ToString().Equals("1"))
                {
                    html += "<td><a onclick=\"HuyTheoDoi(" + table.Rows[i]["idchitietdangkykham"].ToString() + "," + table.Rows[i]["idkhoanoitru"].ToString() + ")\">Loại khỏi DS</a></td>";
                }
                else
                    html += "<td></td>";
                html += "</tr>";
            }

            html += "</table>";
        }
        return html;
    }
    protected void btnTimBN_Click(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        DataView dvtemp = new DataView(stdtBenhNhanCho.Copy());
        string strFilter = "mabenhnhan like '%" + txtMaBenhNhan.Value + "%' and tenbenhnhan like '%" + txtTenBenhNhan.Value +"%'";
        dvtemp.RowFilter = strFilter;
        table=dvtemp.ToTable();
        divDSBN.InnerHtml= DanhSachBenhNhanCho(table);

    }
    protected void btnTamUng_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "dcdd", "SetBenhNhanDangKham('" + hdIdbenhnhan.Value + "','" + hdIdCtDkk.Value + "')", true);
        //spTamUng.InnerHtml = "Tạm ứng";
        string a = hdIdbenhnhan.Value;
        string b = hdIdKhambenhGoc.Value;
        string c = hdIdCtDkk.Value;
    }
    protected void btnDichVu_Click(object sender, EventArgs e)
    {
        //divNoiDung.InnerHtml = "Chỉ định dịch vụ";
    }
    protected void btnThuoc_Click(object sender, EventArgs e)
    {
        //divNoiDung.InnerHtml = "Chỉ định thuốc";
    }
    protected void btnGiuong_Click(object sender, EventArgs e)
    {
        //spTienGiuong.InnerHtml = "Tiền giường xuất khoa";
    }
    protected void btnXuatKhoa_Click(object sender, EventArgs e)
    {
        //sXuatKhoa.InnerHtml = "Cho xuất khoa nào ! (-_-)";
    }
}
