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

public partial class ketoan_ajax_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "taikhoanSearch": taikhoanSearch(); break;
        }
    }
    private void taikhoanSearch()
    {
        string taikhoan = Request.QueryString["q"].ToString();
        //string sql = "select taikhoan,tentaikhoan from danhmuctk where taikhoan like '" + tkkho.Trim() + "%'";
        //DataTable table = DataAcess.Connect.GetTable(sql);
        DataTable table = taikhoanchitiet(taikhoan);
        string html = "";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    html += string.Format("{0}|{1}|{2}",
                                     "<div style=\"width:100%;height:20px\">"
                                         + "<div style=\"width:35%;float:left;height:20px\" >" + row["TaiKhoan"] + "</div>"
                                         + "<div style=\"width:65%;float:left;height:20px\" >" + row["TenTaiKhoan"] + "</div>"
                                     + "</div>", row["TaiKhoan"].ToString().Trim(), Environment.NewLine);
                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    public DataTable taikhoanchitiet(string tk)
    {
        DataTable dt = new DataTable();
        string sql = "";
        string tk1 = "";
        DataTable dtkq = new DataTable();
        dtkq.Columns.Add("taikhoan");
        dtkq.Columns.Add("tentaikhoan");
        sql = "select taikhoan,tentaikhoan from danhmuctk where taikhoan like '" + tk.Trim() + "%' order by taikhoan ";
        dt = DataAcess.Connect.GetTable(sql);
        int sodong = dt.Rows.Count;
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < sodong; i++)
            {
                tk1 = dt.Rows[i]["taikhoan"].ToString();
                string sqlkq = "select taikhoan,tentaikhoan from danhmuctk where taikhoan like '" + tk1.Trim() + "%' order by taikhoan desc"; ;
                DataTable dt1 = new DataTable();
                dt1 = DataAcess.Connect.GetTable(sqlkq);
                if (dt1 != null && dt1.Rows.Count == 1)
                {
                    DataRow r = dtkq.NewRow();
                    r["taikhoan"] = dt1.Rows[0]["taikhoan"];
                    r["tentaikhoan"] = dt1.Rows[0]["tentaikhoan"];
                    dtkq.Rows.Add(r);
                }
            }
        }
        return dtkq;
    }    
}
