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

public partial class KB_Giuong_ajax : System.Web.UI.Page
{
    protected DataProcess s_KB_Giuong()
    {
        DataProcess KB_Giuong = new DataProcess("KB_Giuong");
        KB_Giuong.data("GiuongId", Request.QueryString["idkhoachinh"]);
        KB_Giuong.data("GiuongCode", Request.QueryString["GiuongCode"]);
        KB_Giuong.data("IDLOAIGIUONG", Request.QueryString["IDLOAIGIUONG"]);
        KB_Giuong.data("DVT", Request.QueryString["DVT"]);
        KB_Giuong.data("Status", Request.QueryString["Status"]);
        KB_Giuong.data("IsTransfer", Request.QueryString["IsTransfer"]);
        KB_Giuong.data("idPhong", Request.QueryString["idPhong"]);
        KB_Giuong.data("nvk_isGiuongCho", Request.QueryString["nvk_isGiuongCho"]);
        KB_Giuong.data("Status", "1");
        return KB_Giuong;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_KB_Giuong(); break;
            case "xoa": Xoa_KB_Giuong(); break;
            case "TimKiem": TimKiem(); break;
            case "IdKhoaSearch": IdKhoaSearch(); break;
            case "idPhongSearch": idPhongSearch(); break;
            case "IDLOAIGIUONGSEARCH": IDLOAIGIUONGSEARCH(); break;     
        }
    }

    private void idPhongSearch()
    {
        string idkhoa = Request.QueryString["IdKhoa"];
        if (idkhoa == null || idkhoa == "") idkhoa = "0";
        DataTable table = StaticData.dtPhong_ByKhoa(idkhoa);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenPhongFull"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IDLOAIGIUONGSEARCH()
    {
        string TENLOAIGIUONG = Request.QueryString["TENLOAIGIUONG"];
        string sqlSelect = "SELECT * FROM HS_LOAIGIUONG WHERE TENLOAIGIUONG LIKE N'%"+TENLOAIGIUONG+"%'";
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TENLOAIGIUONG"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
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
    private void Xoa_KB_Giuong()
    {
        try
        {
            DataProcess process = s_KB_Giuong();
            //bool ok = process.Delete();
            bool ok = DataAcess.Connect.ExecSQL("update kb_giuong set status =0 where giuongid ='" + process.getData("GiuongId") + "'");
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("GiuongId"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }

    private void LuuTable_KB_Giuong()
    {
        try
        {
            DataProcess process = s_KB_Giuong();
            if (process.getData("GiuongId") != null && process.getData("GiuongId") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("GiuongId"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("GiuongId"));
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
        string idPhong = Request.QueryString["idPhong"];
        string GiuongCode = Request.QueryString["GiuongCode"];
        bool search = Userlogin_new.HavePermision(this, "KB_Giuong_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "KB_Giuong_Add");
            bool delete = Userlogin_new.HavePermision(this, "KB_Giuong_Delete");
            bool edit = Userlogin_new.HavePermision(this, "KB_Giuong_Edit");
            DataProcess process = s_KB_Giuong();
            process.EnablePaging = false;
            string sqlSelect= @"
                    select  STT=row_number() over (order by T.GiuongId),T.*
                       ,TenPhong=DBO.HS_TENPHONG(A.ID)
                        ,TENKHOA=D.TENPHONGKHAMBENH
                        ,IDKHOA=C.IDPHONGKHAMBENH
                        ,TENLOAIGIUONG
                        from KB_Giuong T
                        left join KB_Phong  A on T.idPhong=A.Id
                        LEFT JOIN BANGGIADICHVU C ON A.DICHVUKCB=C.IDBANGGIADICHVU
					    LEFT JOIN PHONGKHAMBENH D ON C.IDPHONGKHAMBENH=D.IDPHONGKHAMBENH
                        LEFT JOIN HS_LOAIGIUONG E ON T.IDLOAIGIUONG=E.IDLOAIGIUONG
                        WHERE T.status=1 ";  
            if (idkhoa != null && idkhoa != "")
            {
                sqlSelect += " AND D.IDPHONGKHAMBENH=" + idkhoa;
            }
            if (!string.IsNullOrEmpty(idPhong))
            {
                sqlSelect += " AND A.id=" + idPhong;
            }
            if (!string.IsNullOrEmpty(GiuongCode))
            {
                sqlSelect += " AND T.GiuongCode like N'%"+GiuongCode+"%'";
            }
            DataTable table = DataAcess.Connect.GetTable(sqlSelect);
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
}


