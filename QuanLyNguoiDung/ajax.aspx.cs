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

public partial class QuanLyNguoiDung_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string html = "";
        //DataTable table = DataAcess.Connect.GetTable("select top 10 idnhanvien,tennhanvien,didong from nhanvien where nhanvien.status=1 and tennhanvien like N'%" + Request.QueryString["q"] + "%'");
        //if (table.Rows.Count > 0)
        //{
        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {
        //        html += table.Rows[i]["idnhanvien"].ToString() + "|" + table.Rows[i]["tennhanvien"].ToString() + "|" + table.Rows[i]["didong"].ToString() + Environment.NewLine;
        //    }
        //}
        //Response.Clear();
        //Response.Write(html);
          string action = StaticData.escape(Request.QueryString["do"]);
          switch (action)
          {
              //Dang ky thang nam lam viec
              case "timPhong": timPhong(); break;
              case "timNhanVien": timNhanVien(); break;
          }
    }
    private void timNhanVien()
    {
        string html = "";
        DataTable table = DataAcess.Connect.GetTable("select top 10 idnhanvien,tennhanvien,didong from nhanvien where nhanvien.status=1 and tennhanvien like N'%" + Request.QueryString["q"] + "%'");
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html += table.Rows[i]["idnhanvien"].ToString() + "|" + table.Rows[i]["tennhanvien"].ToString() + "|" + table.Rows[i]["didong"].ToString() + Environment.NewLine;
            }
        }
        Response.Clear();
        Response.Write(html);
    }
    private void timPhong()
    {
        string html = "";
        html += string.Format("{0}|{1}|{2}|{3}", ""

        + "<div style =\"background-color: red;\">"
        + "<div style=\"width:100%;color:white;font-weight:bold;float:left\" >Phòng</div>"
        + "</div>", "", "", Environment.NewLine);
        string trsTenCT = "";
        if (Request.QueryString["q"] != null && Request.QueryString["q"].ToString() != "")
            trsTenCT = Request.QueryString["q"].ToString();
        string sql1 = @"select id,TenPhong from kb_phong
                    where TenPhong like N'%"+trsTenCT+"%'";
        DataTable tb1 = DataAcess.Connect.GetTable(sql1);
        if (tb1.Rows.Count < 1)
        {
            Response.Clear();
            Response.Write("false");
            Response.End();
            return;
        }
        else
        {
            foreach (DataRow h in tb1.Rows)
            {
                html += string.Format("{0}|{1}|{2}|{3}", "<div>"
                + "<div style=\"width:100%;float:left\" >" + h["TenPhong"] + "</div>"
                + "</div>", h["tenphong"], h["id"], Environment.NewLine);
            }
            Response.Clear();
            Response.Write(html);
            Response.End();
        }
    }
}
