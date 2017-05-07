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
using System.Collections.Generic;

public partial class ketoan_KTHT_ThamSoTuyChon : System.Web.UI.Page
{
    List<string> listthamso = new List<string>();
    List<string> listgiatri = new List<string>();
    List<string> listdiengiai = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadlist_thamso();
        }
    }    
    public void loadlist_thamso()
    {
        string sql1 = "select tham_so,dien_giai,gia_tri from tham_so ";
        DataTable dt = new DataTable();
        dt = DataAcess.Connect.GetTable(sql1);
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ts = dt.Rows[i][0].ToString();
                string dg = dt.Rows[i][1].ToString();
                string gt = dt.Rows[i][2].ToString();               
                listthamso.Add(ts);
                listdiengiai.Add(dg);
                listgiatri.Add(gt);
                
            }
        }
        showlist_thamso();
    }
    public void showlist_thamso()
    {
        string shtml = "";        
        shtml += "<table class=\"TableGidview\" id=\"TableDanhSach\">";
        shtml += "<tr class=\"HeaderGidView\">";
        shtml += "<td style=\"width:20px\">STT</td>";
        shtml += "<td style=\"width:400px\">danh sách các tham số</td>";
        shtml += "<td style=\"width:300px\">Giá trị</td>";              
        shtml += "</tr>";
        
        if (listthamso != null && listthamso.Count > 0)
        {
            for (int i = 0; i < listthamso.Count; i++)
            {
                shtml += "<tr>";
                shtml += "<td>" + (i + 1) + "</td>";
                shtml += "<td ><input style=\"width:400px\" id=\"dien_giai_" + (i + 1) + "\" readonly=\"readonly\" value =\"" + listdiengiai[i] + "\" /></td> ";
                shtml += "<td style=\"background-color:white\" ><input style=\"width:400px\" type=\"text\" id=\"gia_tri_" + (i + 1) + "\" value=\""+listgiatri[i]+"\" /></td> ";                
                shtml += "<td><input type=\"hidden\" id=\"tham_so_" + (i + 1) + "\" value=\"" + listthamso[i] + "\" /></td>";
                shtml += "</tr>";
            }
        }

        shtml += "</table>";

        divlisttham_so.InnerHtml = shtml;        
    }

}
