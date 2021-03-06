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

public partial class quanlynhansu_frmDSThueThuNhapCaNhan : System.Web.UI.Page
{
    string getStrChuoi;
    protected void Page_Load(object sender, EventArgs e)
    {
        getStrChuoi = getChuoi();
        blindNhanVien(getStrChuoi);
        loadHopDong();
    }
    private void blindNhanVien(string sWhere)
    {
        string sql = ""
                    + " SELECT ROW_NUMBER()OVER(ORDER BY NV.IDNHANVIEN DESC) AS STT, NV.IDNHANVIEN,NV.MANHANVIEN,NV.TENNHANVIEN,NV.NGAYSINH,NV.DIACHITHUONGTRU," + "\r\n"
                    + " 		CV.TENCHUCVU,PB.TENPHONGBAN,LNV.LUONGCANBAN,LNV.THUETHUNHAP," + "\r\n"
                    + "  CASE WHEN ISNULL(NV.GIOITINH,0)=0 THEN N'NAM' ELSE N'NỮ' END AS GIOITINH "+ "\r\n"
                    + "  FROM NHANVIEN NV" + "\r\n"
                    + " LEFT JOIN CHUCVU CV ON CV.IDCHUCVU=NV.IDCHUCVU" + "\r\n"
                    + " LEFT JOIN PHONGBAN PB ON PB.IDPHONGBAN=NV.IDPHONGBAN" + "\r\n"
                    + " LEFT JOIN LUONGNHANVIEN LNV ON LNV.IDNHANVIEN=NV.IDNHANVIEN" + "\r\n"
                    + " LEFT JOIN HOPDONG HD ON HD.IDNHANVIEN=NV.IDNHANVIEN" + "\r\n"
                    + " LEFT JOIN LOAIHOPDONG LHD ON LHD.IDLOAIHOPDONG=HD.IDLOAIHOPDONG" + "\r\n"
                    + " WHERE LNV.LUONGCANBAN>='4000000'" + sWhere;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        dgrList.DataSource = dt;
        dgrList.DataBind();
    }

    private void loadHopDong()
    {
        string strsql = "SELECT * FROM LOAIHOPDONG";
        DataTable dt = DataAcess.Connect.GetTable(strsql);
        StaticData.FillCombo(ddlLoaiHD, dt, "idloaihopdong", "tenloaihopdong", "--Chọn loại hợp đồng--");
    }
    private string getChuoi()
    {
        string strSearch = "";
        if (ddlThang.SelectedValue != "")
        {
            strSearch += "AND MONTH(THANGNAM)=" + ddlThang.SelectedValue.ToString();
        }
        if (ddlNam.SelectedValue != "")
        {
            strSearch += " AND YEAR(THANGNAM)=" + ddlNam.SelectedValue.ToString();
        }
        if (txtMaNV.Text != "")
        {
            strSearch += " AND NV.MANHANVIEN=N'" + txtMaNV.Text.ToString() + "'";
        }
        if (txtTenNV.Text != "")
        {
            strSearch += " AND NV.TENNHANVIEN LIKE N'%"+txtTenNV.Text.ToString()+"%'";
        }
        if (ddlLoaiHD.SelectedValue != "0" && ddlLoaiHD.SelectedValue != "")
        {
            strSearch += " AND HD.IDLOAIHOPDONG="+ddlLoaiHD.SelectedValue;

        }
        return strSearch;
    }

    protected void btnTim_Click(object sender, EventArgs e)
    {
        getStrChuoi = getChuoi();
        blindNhanVien(getStrChuoi);
    }
}
