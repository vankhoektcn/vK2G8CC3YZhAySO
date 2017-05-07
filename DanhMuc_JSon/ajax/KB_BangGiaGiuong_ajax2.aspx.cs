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

public partial class KB_BangGiaGiuong_ajax : System.Web.UI.Page
{
    protected DataProcess s_KB_BangGiaGiuong()
    {
        DataProcess KB_BangGiaGiuong = new DataProcess("KB_BangGiaGiuong");
        KB_BangGiaGiuong.data("BangGiaGiuongId", Request.QueryString["idkhoachinh"]);
        KB_BangGiaGiuong.data("GiuongId", Request.QueryString["GiuongId"]);
        KB_BangGiaGiuong.data("GiaBH", Request.QueryString["GiaBH"]);
        KB_BangGiaGiuong.data("GiaDV", Request.QueryString["GiaDV"]);
        KB_BangGiaGiuong.data("GiaNgoaiGio", Request.QueryString["GiaNgoaiGio"]);
        KB_BangGiaGiuong.data("Status", Request.QueryString["Status"]);
        KB_BangGiaGiuong.data("IsTransfer", Request.QueryString["IsTransfer"]);
        KB_BangGiaGiuong.data("IsBHYT", Request.QueryString["IsBHYT"]);
        return KB_BangGiaGiuong;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_KB_BangGiaGiuong(); break;
            case "xoa": Xoa_KB_BangGiaGiuong(); break;
            case "TimKiem": TimKiem(); break;
            case "GiuongIdSearch": GiuongIdSearch(); break;
            case "IdKhoaSearch": IdKhoaSearch(); break;
            case "getLan": getLan(); break;
            case "setTimKiem": setTimKiem(); break;
            case "CopyBangGia": CopyBangGia(); break;
        }
    }
    private void IdKhoaSearch()
    {
        DataTable table = DataProcess.GetTable("select * from phongkhambenh where isnull(loaiphong,0)=0 and isnull(isnoitru,0)=1");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenphongkhambenh"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void GiuongIdSearch()
    {
        DataTable table = DataProcess.GetTable("select * from KB_Giuong ");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i][1].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void Xoa_KB_BangGiaGiuong()
    {
        try
        {
            DataProcess process = s_KB_BangGiaGiuong();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("BangGiaGiuongId"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void LuuTable_KB_BangGiaGiuong()
    {
        try
        {
            string tungay = Request.QueryString["TuNgay"];
            tungay = StaticData.CheckDate(tungay);
            DataProcess process = s_KB_BangGiaGiuong();
            process.data("TuNgay", tungay);
            if (process.getData("BangGiaGiuongId") != null && process.getData("BangGiaGiuongId") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("BangGiaGiuongId"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("BangGiaGiuongId"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void TimKiem()
    {
        string idkhoa = Request.QueryString["IdKhoa"];
        string lanid = Request.QueryString["LANID"];
        bool search = StaticData.HavePermision(this, "KB_BangGiaGiuong_Search");
        if (search)
        {
            bool add = StaticData.HavePermision(this, "KB_BangGiaGiuong_Add");
            bool delete = StaticData.HavePermision(this, "KB_BangGiaGiuong_Delete");
            bool edit = StaticData.HavePermision(this, "KB_BangGiaGiuong_Edit");
            DataProcess process = s_KB_BangGiaGiuong();
            process.EnablePaging = false;
            string sqlSelect = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY TB1.TENKHOA,TB1.TENPHONG,TB1.GIUONGCODE),  
		                TB1.*,
		                TB2.GiaBH,
		                TB2.GiaDV,
		                TB2.IsBHYT,
		                TB2.BANGGIAID
                            FROM (
                            select
                                 GiuongId= A.GiuongId
                                 ,A.GiuongCode
                                 ,TENPHONG=DBO.HS_TENPHONG(B.ID)
                                 ,TENKHOA=D.TENPHONGKHAMBENH
                                 ,BangGiaGiuongId=(SELECT TOP 1 BangGiaGiuongId FROM KB_BANGGIAGIUONG A1  
							                                LEFT JOIN KB_BANGGIAGIUONG_LAN B1 ON A1.BANGGIAID=B1.BANGGIAID
							                                WHERE A1.GIUONGID=A.GIUONGID
                                                                AND B1.LANID=" + ((lanid != null && lanid != "" && lanid != "null") ? lanid : "''") + @"
					                                )
                            from kb_giuong A
                            LEFT JOIN KB_PHONG B ON A.idPhong=B.ID
                            LEFT JOIN BANGGIADICHVU C ON B.DICHVUKCB=C.IDBANGGIADICHVU
                            LEFT JOIN PHONGKHAMBENH D ON C.IDPHONGKHAMBENH=D.IDPHONGKHAMBENH
                            " + ((idkhoa != null && idkhoa != "") ? " WHERE D.IDPHONGKHAMBENH=" + idkhoa : "") + @" 
                            ) AS TB1
                LEFT JOIN KB_BANGGIAGIUONG AS TB2 ON TB1.BangGiaGiuongId=TB2.BangGiaGiuongId
                ORDER BY TB1.TENKHOA,TB1.TENPHONG,TB1.GIUONGCODE";

            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
    private void getLan()
    {
        string sqlSelect = @"( SELECT LANID FROM KB_BANGGIAGIUONG_LAN )
                              UNION
                            (
                                SELECT LANID +1 FROM KB_BANGGIAGIUONG_LAN
                            )  ";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        string html = "";
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += table.Rows[i][0].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

            }
        }
        Response.Clear();
        Response.Write(html);
    }
  
    private void setTimKiem()
    {
        if (StaticData.HavePermision(this, "KB_BangGiaGiuong_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string sqlSelect = @"SELECT  TOP 1 IDKHOACHINH=T.BANGGIAID
	                        ,TUNGAY=CONVERT(VARCHAR(10),T.TUNGAY,103)
                        FROM KB_BANGGIAGIUONG_LAN T
	                        LEFT JOIN KB_BANGGIAGIUONG A ON A.BANGGIAID=T.BANGGIAID
                 where T.LANID='" + idkhoachinh + "'";
            DataTable table = DataProcess.GetTable(sqlSelect);
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }
    private void CopyBangGia()
    {
        string lanid = Request.QueryString["lanthu"];
        bool search = StaticData.HavePermision(this, "KB_BangGiaGiuong_Search");
        if (search)
        {
            bool add = StaticData.HavePermision(this, "KB_BangGiaGiuong_Add");
            bool delete = StaticData.HavePermision(this, "KB_BangGiaGiuong_Delete");
            bool edit = StaticData.HavePermision(this, "KB_BangGiaGiuong_Edit");
            DataProcess process = s_KB_BangGiaGiuong();
            process.EnablePaging = false;
            string sqlSelect = @"SELECT STT=ROW_NUMBER() OVER(ORDER BY TB1.TENKHOA,TB1.TENPHONG,TB1.GIUONGCODE),  
		                GiuongId= TB1.GiuongId
	                    ,TB1.GiuongCode
	                    ,TB1.TENPHONG 
	                    ,TB1.TENKHOA 
	                    ,BangGiaGiuongId=NULL
	                    ,TB2.GiaBH,
	                    TB2.GiaDV,
	                    TB2.IsBHYT,
	                    BANGGIAID=NULL
                            FROM (
                            select
                                 GiuongId= A.GiuongId
                                 ,A.GiuongCode
                                 ,TENPHONG=DBO.HS_TENPHONG(B.ID)
                                 ,TENKHOA=D.TENPHONGKHAMBENH
                                 ,BangGiaGiuongId=(SELECT TOP 1 BangGiaGiuongId FROM KB_BANGGIAGIUONG A1  
							                                LEFT JOIN KB_BANGGIAGIUONG_LAN B1 ON A1.BANGGIAID=B1.BANGGIAID
							                                WHERE A1.GIUONGID=A.GIUONGID
                                                                AND B1.LANID=" + lanid + @"
					                                )
                            from kb_giuong A
                            LEFT JOIN KB_PHONG B ON A.idPhong=B.ID
                            LEFT JOIN BANGGIADICHVU C ON B.DICHVUKCB=C.IDBANGGIADICHVU
                            LEFT JOIN PHONGKHAMBENH D ON C.IDPHONGKHAMBENH=D.IDPHONGKHAMBENH
                            ) AS TB1
                LEFT JOIN KB_BANGGIAGIUONG AS TB2 ON TB1.BangGiaGiuongId=TB2.BangGiaGiuongId
                ORDER BY TB1.TENKHOA,TB1.TENPHONG,TB1.GIUONGCODE";

            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}


