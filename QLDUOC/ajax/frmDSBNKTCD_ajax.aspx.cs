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
using System.Text;

public partial class frmDSBNKTCD_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "loaddskhoa": loaddskhoa(); break;
            case "loaddsphong": loaddsphong(); break;
            case "TimKiem": TimKiem(); break;
        }
    }
    private void loaddskhoa()
    {
        string idkhoa = Request.QueryString["IdKhoa"];
        string SQL = string.Format(@"SELECT * FROM PHONGKHAMBENH");
        DataTable table = DataAcess.Connect.GetTable(SQL);
        table.DefaultView.RowFilter = "loaiphong=0";
        if(idkhoa!=null &&idkhoa!="")
            table.DefaultView.RowFilter += " and Idphongkhambenh="+idkhoa;
        table = table.DefaultView.ToTable();
        StringBuilder html = new StringBuilder();
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.AppendLine(table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString());
            }
        }
        Response.Clear();
        Response.Write(html.ToString());
    }
    private void loaddsphong()
    {
        bool IsAdmin = SysParameter.UserLogin.IsAdmin(this);
        string IdKhoa = Request.QueryString["IdKhoa"];
        DataTable table = null;
        if (IdKhoa != null && IdKhoa != "")
        {
            string sql = @"SELECT *,TenPhongFull=DBO.HS_TenPhong(ID)
	                     FROM KB_PHONG A1
	                    LEFT JOIN BANGGIADICHVU B1 ON A1.DICHVUKCB=B1.IDBANGGIADICHVU
	                    WHERE 1=1
	                    AND status=1
                       " + (IsAdmin ? "" : " and a1.id in ( select phongid from kb_dieuduong_phong where  iddieuduong=" + SysParameter.UserLogin.UserID(this) + ")") + @" 
	                    AND B1.IDPHONGKHAMBENH=" + IdKhoa
                 + @"  ORDER BY ISNULL(SOTT,0),ISNULL(MASO,'') ,TENPHONG ";
            table = DataAcess.Connect.GetTable(sql);
        }
        StringBuilder html = new StringBuilder();
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.AppendLine(table.Rows[i]["TenphongFull"].ToString() + "|" + table.Rows[i]["Id"].ToString());
            }
        }
        Response.Clear();
        Response.Write(html.ToString());
    }
    private void TimKiem()
    {
        string idkhoa = Request.QueryString["ddlKhoa"];
        string idphong = Request.QueryString["ddlPhong"];
        string tungay = Request.QueryString["TuNgay"];
        string denngay = Request.QueryString["DenNgay"];
        string mabn = Request.QueryString["mabn"];
        string hotenbn = Request.QueryString["tenbn"];
        string ngaysinh = Request.QueryString["ngaysinh"];
        string SQL = string.Format(@"SELECT  TENBENHNHAN AS HOTENBN,
                                       E.NGAYSINH,
                                       GIOITINH=DBO.GETGIOITINH(E.GIOITINH),
                                       TENBACSI,
                                       PHONG=DBO.HS_TENPHONG(B.PHONGID),
                                       B.NGAYKHAM,
                                       B.IDKHAMBENH
                                       ,TENDICHVU=DBO.HS_GET_DICHVU(C.IDBENHBHDONGTIEN)
                                       ,B.IsCheckAllCD
                                    FROM   KHAMBENH B  
                                    INNER JOIN DANGKYKHAM C ON B.IDDANGKYKHAM=C.IDDANGKYKHAM
                                    INNER JOIN BACSI D ON B.IDBACSI=D.IDBACSI
                                    INNER JOIN BENHNHAN E ON B.IDBENHNHAN=E.IDBENHNHAN
                                    
                                    WHERE 1=1");

        if (idkhoa != null && idkhoa != "" && idkhoa != "null")
        {
            SQL += " AND B.IDPHONGKHAMBENH=" + idkhoa;
        }
        if (idphong != null && idphong != "" && idphong != "null")
        {
            SQL += " AND B.PHONGID=" + idphong;
        }
        if (tungay != null && tungay != "")
        {
            SQL += " AND B.NGAYKHAM >='" + StaticData.CheckDate(tungay) + "'";
        }
        if (denngay != null && denngay != "")
        {
            SQL += " AND B.NGAYKHAM <='" + StaticData.CheckDate(denngay) + " 23:59:59'";
        }
        if (mabn != null && mabn != "")
        {
            SQL += " AND E.MABENHNHAN =N'" + mabn + "'";
        }
        if (hotenbn != null && hotenbn != "")
        {
            SQL += " AND (E.TENBENHNHAN LIKE N'%" + hotenbn + "%' OR E.NAMENOTSIGN LIKE N'%" + StaticData.s_GetNameNotSign(hotenbn) + "%')";
        }
        if (ngaysinh != null && ngaysinh != "")
        {
            SQL += " AND E.NGAYSINH ='" + ngaysinh + "'";
        }
        SQL += " ORDER BY B.NGAYKHAM ";
        DataTable table = DataAcess.Connect.GetTable(SQL);
        StringBuilder html = new StringBuilder();
        html.Append("<table id='gridTableChoDuyet' class='jtable'>");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th>Ngày TH </th>");
        html.Append("<th>Họ tên bệnh nhân</th>");
        html.Append("<th>Ngày sinh</th>");
        html.Append("<th>Giới tính</th>");
        html.Append("<th>Dịch vụ </th>");
        html.Append("<th>KT Xong? </th>");
        html.Append("</tr>");
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                bool xetduyet1 = Userlogin_new.HavePermision(this, "XetDuyet1");
                bool xetduyet2 = Userlogin_new.HavePermision(this, "XetDuyet2");
                html.Append("<tr style='cursor:pointer;' onclick=\"ViewDetailCD('" + table.Rows[i]["idkhambenh"].ToString() + "')\" >   ");
                html.Append("<td style='width:3%;'>" + (i + 1).ToString() + "</td>");
                html.Append("<td style='width:10%;'>" + string.Format("{0:dd/MM hh:mm}", table.Rows[i]["NGAYKHAM"]) + "</td>");
                html.Append("<td style='width:20%; text-align:left;'>" + table.Rows[i]["HOTENBN"].ToString() + "</td>");
                html.Append("<td style='width:10%;'>" + table.Rows[i]["NGAYSINH"].ToString() + "</td>");
                html.Append("<td style='width:5%;'>" + table.Rows[i]["GIOITINH"].ToString() + "</td>");
                html.Append("<td style='width:40%;text-align:left;'>" + table.Rows[i]["TENDICHVU"].ToString() + "</td>");
                html.Append("<td style='width:5%;'    >  <input type='checkbox'  disabled='true' " + (StaticData.IsCheck(table.Rows[i]["IsCheckAllCD"].ToString()) ? "checked" : "") + "/>" + "</td>");
            }
        }
        html.Append("</table>");
        Response.Clear();
        Response.Write(html.ToString());
    }
   
     
}
