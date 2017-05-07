using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// TRUONGNHAT-PC
/// DATE : 10/08/2010
/// DESCRIPTION : XUAT DU LIEU RA EXCEL
/// </summary>
public class clsExport
{
    //LOAI BO CAC CONTROL HYPERLINK
    private  static void DisableControls(Control gv)
    {

        LinkButton lb = new LinkButton();
        Literal l = new Literal();
        string name = String.Empty;
        for (int i = 0; i < gv.Controls.Count; i++)
        {
            if (gv.Controls[i].GetType() == typeof(LinkButton))
            {
                l.Text = (gv.Controls[i] as LinkButton).Text;
                l.Text = "";
                gv.Controls.Remove(gv.Controls[i]);
                
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(DropDownList))
            {
                l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                l.Text = "";
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            if (gv.Controls[i].HasControls())
            {
                DisableControls(gv.Controls[i]);
            }

        }

    }
    //XAY DUNG CAC STYLE
    private void styleKeToan()
    {

    }
    //DUNG CHO GRIDVIEW
    public static void exprortToExcel(string filname, string tencty, string khoa, string header, GridView gv, string strFooter)
    {

        //BIEN CUC BO
        string ngay = System.DateTime.Now.ToString("dd");
        string thang = System.DateTime.Now.ToString("MM");
        string nam = System.DateTime.Now.ToString("yyyy");
        string date = "Ngày " + ngay + " tháng " + thang + " năm " + nam;

        //HEADER
        string tilte = "";
        tilte = "<table>";

        tilte += "<tr>";
        tilte += "<td colspan=\"5\" class=\"title\" align = \"left\">";
        tilte += "<span class=\"title\" style =\"color:Black;font-size:12px\">" + tencty + "</span>";
        tilte += "</td>";
        tilte += "</tr>";

        tilte += "<tr>";
        tilte += "<td colspan=\"5\" class=\"title\" align = \"left\">";
        tilte += "<span class=\"title\" style =\"color:Black;font-size:12px\">" + khoa + "</span>";
        tilte += "</td>";
        tilte += "</tr>";

        tilte += "<tr>";
        tilte += "<td colspan=\"10\" rowspan=\"3\" class=\"title\" align = \"center\">";
        tilte += "<span class=\"title\" style =\"color:Black;font-weight: bold;font-size:medium\">" + header + "</span>";
        tilte += "<br/>";
        tilte += "<span class=\"title\" style =\"color:Black;font-weight: bold\">" + date + "</span>";
        tilte += "</td>";
        tilte += "</tr>";
        tilte += "</table>";

        //FOOTER
        int n = gv.Columns.Count;
        int cols;
        if (n <=7)
        {
            cols =7;
        }
        else
        {
            cols = n-5;
        }
        string footer = "";
        footer += "<table>";
        footer += "<tr>";
        //footer += "<td colspan=\"" + cols + "\" rowspan=\"3\" class=\"title\" align = \"left\">";
        //footer += "</td>";

        footer += "<td colspan=\"3\" rowspan=\"3\" class=\"title\" align = \"center\">";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">;</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">Người nộp tiền</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "</td>";


        footer += "<td colspan=\"3\" rowspan=\"3\" class=\"title\" align = \"center\">";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">Thủ Quỹ</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "</td>";


        footer += "<td colspan=\"3\" rowspan=\"3\" class=\"title\" align = \"center\">";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">Kế toán trưởng</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "</td>";

        footer += "<td colspan=\"3\" rowspan=\"3\" class=\"title\" align = \"center\">";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">" + date + "</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">" + strFooter + "</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">(ký tên và đóng dấu)</span>";
        footer += "</td>";
        footer += "</tr>";
        footer += "</table>";

        string attachment = "attachment; filename=" + filname + ".xls";
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        StringWriter sWriter = new StringWriter();
        HtmlTextWriter htwWriter = new HtmlTextWriter(sWriter);
        DisableControls(gv); 
        //gv.Columns[0].Visible = false;
        //gv.Columns[1].Visible = false;
        gv.AllowPaging = false;
        //tdHeader.RenderControl(htwWriter);
        gv.FooterRow.Visible = false;
        gv.RenderControl(htwWriter);
        HttpContext.Current.Response.Write(tilte);
        HttpContext.Current.Response.Write(sWriter.ToString());
        HttpContext.Current.Response.Write(footer);
        HttpContext.Current.Response.End();
    }
    //DUNG CHO DATAGRID
    public static void exprortToExcelDataGrid_BCKBnoiTru(string filname, string htmlHeaderFull, DataGrid gv, string htmlFooterFull)
    {
        string attachment = "attachment; filename=" + filname + ".xls";
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        StringWriter sWriter = new StringWriter();
        HtmlTextWriter htwWriter = new HtmlTextWriter(sWriter);
        DisableControls(gv);
        //gv.Columns[0].Visible = false;
        //gv.Columns[1].Visible = false;
        gv.AllowPaging = false;
        //tdHeader.RenderControl(htwWriter);
        gv.RenderControl(htwWriter);
        HttpContext.Current.Response.Write(htmlHeaderFull);
        HttpContext.Current.Response.Write(sWriter.ToString());
        HttpContext.Current.Response.Write(htmlFooterFull);
        HttpContext.Current.Response.End();
    }
    public static void exprortToExcelDataGrid(string filname, string tencty, string khoa, string header, DataGrid gv, string strFooter)
    {
        //BIEN CUC BO
        string ngay = System.DateTime.Now.ToString("dd");
        string thang = System.DateTime.Now.ToString("MM");
        string nam = System.DateTime.Now.ToString("yyyy");
        string date = "Ngày " + ngay + " tháng " + thang + " năm " + nam;

        //HEADER
        string tilte = "";
        tilte = "<table>";

        tilte += "<tr>";
        tilte += "<td colspan=\"5\" class=\"title\" align = \"left\">";
        tilte += "<span class=\"title\" style =\"color:Black;font-size:12px\">" + tencty + "</span>";
        tilte += "</td>";
        tilte += "</tr>";

        tilte += "<tr>";
        tilte += "<td colspan=\"5\" class=\"title\" align = \"left\">";
        tilte += "<span class=\"title\" style =\"color:Black;font-size:12px\">" + khoa + "</span>";
        tilte += "</td>";
        tilte += "</tr>";

        tilte += "<tr>";
        tilte += "<td colspan=\"10\" rowspan=\"3\" class=\"title\" align = \"center\">";
        tilte += "<span class=\"title\" style =\"color:Black;font-weight: bold;font-size:medium\">" + header + "</span>";
        tilte += "<br/>";
        tilte += "<span class=\"title\" style =\"color:Black;font-weight: bold\">" + date + "</span>";
        tilte += "</td>";
        tilte += "</tr>";
        tilte += "</table>";

        //FOOTER
        int n = gv.Columns.Count;
        int cols;
        if (n <= 7)
        {
            cols = 7;
        }
        else
        {
            cols = n - 5;
        }
        string footer = "";
        footer += "<br/>";
        footer += "<table>";
        footer += "<tr>";
        //footer += "<td colspan=\"" + cols + "\" rowspan=\"3\" class=\"title\" align = \"left\">";
        //footer += "</td>";


        footer += "<td colspan=\"2\" rowspan=\"3\" class=\"title\" align = \"center\">";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">Người nộp tiền</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "</td>";


        footer += "<td colspan=\"3\" rowspan=\"3\" class=\"title\" align = \"center\">";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">Thủ Quỹ</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "</td>";


        footer += "<td colspan=\"3\" rowspan=\"3\" class=\"title\" align = \"center\">";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">Kế toán trưởng</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\"></span>";
        footer += "</td>";

        footer += "<td colspan=\"3\" rowspan=\"3\" class=\"title\" align = \"center\">";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">" + date + "</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">" + strFooter + "</span>";
        footer += "<br/>";
        footer += "<span class=\"title\" style =\"color:Black;font-size:12px\">(ký tên và đóng dấu)</span>";
        footer += "</td>";
        footer += "</tr>";
        footer += "</table>";

        string attachment = "attachment; filename=" + filname + ".xls";
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        StringWriter sWriter = new StringWriter();
        HtmlTextWriter htwWriter = new HtmlTextWriter(sWriter);
        DisableControls(gv);
        //gv.Columns[0].Visible = false;
        //gv.Columns[1].Visible = false;
        gv.AllowPaging = false;
        //tdHeader.RenderControl(htwWriter);
        gv.RenderControl(htwWriter);
        HttpContext.Current.Response.Write(tilte);
        HttpContext.Current.Response.Write(sWriter.ToString());
        HttpContext.Current.Response.Write(footer);
        HttpContext.Current.Response.End();
    }
}
