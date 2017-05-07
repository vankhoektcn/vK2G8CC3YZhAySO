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

public partial class KB_Phong_ajax : System.Web.UI.Page
{
    //________________________________________________________________
    protected DataProcess s_KB_Phong()
    {
        DataProcess KB_Phong = new DataProcess("KB_Phong");
        KB_Phong.data("Id", Request.QueryString["idkhoachinh"]);
        KB_Phong.data("MaSo", Request.QueryString["MaSo"]);
        KB_Phong.data("TenPhong", Request.QueryString["TenPhong"]);
        KB_Phong.data("DichVuKCB", Request.QueryString["DichVuKCB"]);
        KB_Phong.data("GhiChu", Request.QueryString["GhiChu"]);
        KB_Phong.data("isPhongNoiTru", Request.QueryString["isPhongNoiTru"]);
        KB_Phong.data("SOTT", Request.QueryString["SOTT"]);
        return KB_Phong;
    }
    //________________________________________________________________
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_KB_Phong(); break;
            case "xoa": Xoa_KB_Phong(); break;
            case "TimKiem": TimKiem(); break;
            case "DichVuKCBSearch": DichVuKCBSearch(); break;
            case "idkhoasearch": idkhoasearch(); break;
        }
    }
    //________________________________________________________________
    private void idkhoasearch()
    {

        DataTable table = StaticData.dtKhoa();

        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html += table.Rows[i]["TenPhongKhamBenh"].ToString() + "|" + table.Rows[i][0].ToString() + Environment.NewLine;

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }

    private void DichVuKCBSearch()
    {
        AutoComplete.DichVuKCBSearch(this, true);
    }
    //________________________________________________________________
    private void Xoa_KB_Phong()
    {
        try
        {
            DataProcess process = s_KB_Phong();
            //bool ok = process.Delete();
            bool ok = DataAcess.Connect.ExecSQL("update KB_Phong set status=0 where id='"+process.getData("Id")+"'");
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("Id"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    //________________________________________________________________
    private void LuuTable_KB_Phong()
    {
        try
        {
            DataProcess process = s_KB_Phong();
            if (process.getData("Id") != null && process.getData("Id") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id"));
                    return;
                }
            }
            else
            {
                process.data("Status", "1");
                process.data("LoaiBN", "1");
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("Id"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    //________________________________________________________________
    private void TimKiem()
    {
        bool search = Userlogin_new.HavePermision(this, "KB_Phong_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "KB_Phong_Add");
            bool delete = Userlogin_new.HavePermision(this, "KB_Phong_Delete");
            bool edit = Userlogin_new.HavePermision(this, "KB_Phong_Edit");
            DataProcess process = s_KB_Phong();
            string IdKhoa = Request.QueryString["IdKhoa"];
            process.EnablePaging = false;
            string sql = @"select STT=row_number() over (order by T.Id),T.*
                                   ,A.tendichvu
                                               from KB_Phong T
                                    left join banggiadichvu  A on T.DichVuKCB=A.idbanggiadichvu
                          where  " + process.sWhere() +" and Status=1 "+ (IdKhoa != null && IdKhoa != "" ? " AND A.IDPHONGKHAMBENH=" + IdKhoa : "");
            DataTable table = process.Search(sql);
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
    //________________________________________________________________
}


