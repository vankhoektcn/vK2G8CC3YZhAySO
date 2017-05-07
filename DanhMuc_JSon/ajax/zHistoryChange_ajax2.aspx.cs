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

public partial class zHistoryChange_ajax : System.Web.UI.Page
{
    protected DataProcess s_zHistoryChange()
    {
        DataProcess zHistoryChange = new DataProcess("zHistoryChange");
        zHistoryChange.data("ID", Request.QueryString["idkhoachinh"]);
        zHistoryChange.data("TableName", Request.QueryString["TableName"]);
        zHistoryChange.data("SaveDate", Request.QueryString["SaveDate"]);
        zHistoryChange.data("Description", Request.QueryString["Description"]);
        zHistoryChange.data("TypeEdit", Request.QueryString["TypeEdit"]);
        zHistoryChange.data("IdKhoaChinh", Request.QueryString["IdKhoaChinh"]);
        zHistoryChange.data("IdNguoiDung", Request.QueryString["IdNguoiDung"]);
        return zHistoryChange;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "xoa": Xoa_zHistoryChange(); break;
            case "TimKiem": TimKiem(); break;

        }
    }
    private void Xoa_zHistoryChange()
    {
        try
        {
            DataProcess process = s_zHistoryChange();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("ID"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void TimKiem()
    {
        bool search = Userlogin_new.HavePermision(this, "zHistoryChange_Search");
        if (search)
        {
            bool add = Userlogin_new.HavePermision(this, "zHistoryChange_Add");
            bool delete = Userlogin_new.HavePermision(this, "zHistoryChange_Delete");
            bool edit = Userlogin_new.HavePermision(this, "zHistoryChange_Edit");
            DataProcess process = s_zHistoryChange();
            process.EnablePaging = false;
            DataTable table = process.Search(@"select STT=row_number() over (order by T.ID),T.*,B.TENNGUOIDUNG
                               from zHistoryChange T LEFT JOIN NGUOIDUNG B ON T.IDNGUOIDUNG=B.IDNGUOIDUNG
                    where " + process.sWhere());
            Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, add, edit, delete));
        }
        else
        {
            Response.Clear(); Response.Write("Bạn không có quyền xem dữ liệu!");
        }
    }
   
}


