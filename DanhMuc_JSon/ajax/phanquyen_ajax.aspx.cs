using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public partial class DanhMuc_JSon_ajax_phanquyen_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "listnguoidung": listnguoidung(); break;
            case "getListQuyen": getListQuyen(); break;
            case "getQuyen": getQuyen(); break;
            case "saveQuyen": saveQuyen(); break;
        }
    }
    private void saveQuyen()
    {
        int flag = 0;
        string userid = Request.QueryString["userid"];
        string[] listquyen = Request.QueryString["listquyen"].Split('@');
        string sqlDel_ = string.Format(@"
                    BEGIN TRAN
                        DELETE FROM USERPROFILE WHERE USERID={0}
                    IF @@ERROR<> 0
                        ROLLBACK TRAN
                    COMMIT TRAN    
                    ", userid);
        bool OK = DataAcess.Connect.ExecSQL(sqlDel_);
        if (!OK)
        {
            flag = -1;
            return;
        }
        for (int i = 0; i < listquyen.Length; i++)
        {
            string lst = listquyen[i].Trim();
            if (lst != null && lst != "")
            {
                DataTable table = DataAcess.Connect.GetTable(string.Format(@"
                                                        select stt=(select top 1 epid
                                                        from userprofile
                                                        order by epid desc)+1
                                                        "));
                if (table == null || table.Rows.Count == 0)
                {
                    flag = -2;
                    return;
                }
                DataProcess _user_profile = new DataProcess("USERPROFILE");
                _user_profile.data("EPID", table.Rows[0][0].ToString());
                _user_profile.data("UserID", userid);
                _user_profile.data("PermID", listquyen[i]);
                _user_profile.data("Status", "1");
                _user_profile.data("IsTransfer", "0");
                bool ok_insert = _user_profile.Insert();
                if (!ok_insert)
                {
                    flag = -3;
                    return;
                }
            }
        }
        Response.Clear();
        Response.Write(flag);

    }
    private void listnguoidung()
    {
        string sqlSelect = string.Format(@"SELECT IDNGUOIDUNG, NGUOIDUNG=USERNAME + ' - ' + TENNGUOIDUNG FROM NGUOIDUNG WHERE USERNAME !='ADMIN' ORDER BY USERNAME");
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table != null && table.Rows.Count > 0)
        {
            Response.Clear();
            Response.Write(CreateJsonParameters(table));
        }
    }
    private void getListQuyen()
    {
        JavaScriptSerializer jserial = new JavaScriptSerializer();
        string permdesc = Request.QueryString["permdesc"];
        string sqlSelect = string.Format(@"select top 15 permid,permdesc=ISNULL(permdesc,'')+'('+ PERMNAME +')' 
                                                from permision where
                                         status=1 and ISNULL(permdesc,'')+'('+ PERMNAME +')'  like N'%" + permdesc + @"%' order by ISNULL(permdesc,'')+'('+ PERMNAME +')' ");
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table != null && table.Rows.Count > 0)
        {
            Response.Clear();
            Response.Write(CreateJsonParameters(table));
        }
    }
    private void getQuyen()
    {
        JavaScriptSerializer jserial = new JavaScriptSerializer();
        string idnguoidung = Request.QueryString["idnguoidung"];
        string sqlSelect = string.Format(@"select a.permid,permdesc=ISNULL(permdesc,'')+'('+ PERMNAME +')'  from userprofile a 
                                    left join permision b on a.permid=b.permid 
                        where userid='" + idnguoidung + "'");
        DataTable table = DataAcess.Connect.GetTable(sqlSelect);
        if (table != null && table.Rows.Count > 0)
        {
            Response.Clear();
            Response.Write(CreateJsonParameters(table));
        }
    }

    public string CreateJsonParameters(DataTable dt)
    {
        StringBuilder JsonString = new StringBuilder();
        if (dt != null && dt.Rows.Count > 0)
        {
            JsonString.Append("{ ");
            JsonString.Append("\"JSON\":[ ");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JsonString.Append("{ ");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < dt.Columns.Count - 1)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() +
                              "\":" + "\"" +
                              dt.Rows[i][j].ToString() + "\",");
                    }
                    else if (j == dt.Columns.Count - 1)
                    {
                        JsonString.Append("\"" +
                           dt.Columns[j].ColumnName.ToString() + "\":" +
                           "\"" + dt.Rows[i][j].ToString() + "\"");
                    }
                }
                if (i == dt.Rows.Count - 1)
                {
                    JsonString.Append("} ");
                }
                else
                {
                    JsonString.Append("}, ");
                }
            }

            JsonString.Append("]}");
            return JsonString.ToString();
        }
        else
        {
            return null;
        }
    }
}
