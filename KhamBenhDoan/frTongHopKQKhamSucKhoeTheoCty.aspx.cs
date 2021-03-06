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

public partial class thongke_frTongHopKQKhamSucKhoeTheoCty : System.Web.UI.Page
{
    string strSearch;
    int idbnView = 0;
    string dkmenu = "KQKhamSucKhoe";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        txtdatefrom.Value = EmailClass.FormatDateTime(DateTime.Now.AddMonths(-1).ToString());
        txtdateto.Value = EmailClass.FormatDateTime(DateTime.Now.ToString());
        LoadDLL();
        LoadMenu();
    }
    private void LoadMenu()
    {
        try
        {
            string dkmenu = Request.QueryString["dkmenu"].ToString();
            PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
        }
        catch (Exception ex)
        {
        }
    }
    #region Load dropdownlist
    private void LoadDLL()
    {
        ddlBS.Items.Clear();
        ddlBS.Items.Add(new ListItem("- - - Chọn Công Ty - - -", "0"));
        string sql1 = "select idcongty,tencty from Kb_Congty";
        DataTable tb1 = DataAcess.Connect.GetTable(sql1);
        if (tb1.Rows.Count > 0)
        {
            for (int i = 0; i < tb1.Rows.Count; i++)
            {
                ddlBS.Items.Add(new ListItem(tb1.Rows[i][1].ToString(), tb1.Rows[i][0].ToString()));
            }
        }
    }
    #endregion
    protected void btnSearch_Onclick(object sender, EventArgs e)
    {
        string IDcty = ddlBS.SelectedValue.ToString().Trim();
        string datefrom = EmailClass.DateTimeFormat(txtdatefrom.Value);
        string dateto = EmailClass.DateTimeFormat(txtdateto.Value);
        if (IDcty != "0")
            BindListBenhNhan(IDcty, datefrom, dateto);
    }
    private void BindListBenhNhan(string idcty, string datefrom, string dateto)
    {
        string strSQL = "";
        strSQL += @" SELECT     B.tenbenhnhan, B.ngaysinh, B.gioitinh, S.chieucao, S.cannang, S.mach, C.tencty, K.dando, B.idcongty
            ,S.huyetap1, S.huyetap2,   S.MatTrai, S.MatPhai
            ,S.TMH, S.RHM, S.NgoaiDaLieu,  K.SieuAm, K.XNMau
            ,K.XNNuocTieu, K.DienTim, K.XQ, K.PhanLoai, K.PhuKhoa, K.ngaykham
        FROM   benhnhan B INNER JOIN      KB_CongTy C ON B.idcongty = C.idcongty 
            RIGHT OUTER JOIN khambenh K ON B.idbenhnhan = K.idbenhnhan
            RIGHT OUTER JOIN sinhhieu S ON k.iddangkykham = S.iddangkykham 
        WHERE     (B.idcongty = '" + idcty + "')";
        if (!string.IsNullOrEmpty(txtdatefrom.Value) && !string.IsNullOrEmpty(txtdateto.Value))
            strSQL += " AND (K.ngaykham BETWEEN CONVERT(DATETIME, '" + datefrom + "', 102) AND CONVERT(DATETIME, '" + dateto + " 23:59:59 ', 102))";
        DataTable dt = DataAcess.Connect.GetTable(strSQL);
        StringBuilder s = new StringBuilder();
        s.Append("<table width='100%' cellpadding=3 cellspacing=3 style=' font-family:Times New Roman;'>");
        s.Append("</table><div style='height:30px;'>&nbsp;&nbsp;</div>");
        s.Append("<div style='clear:both'><table width='100%' cellpadding=3 cellspacing=0 border=1 bordercolor='#999' style='border-collapse:collapse'>");
        s.Append("<tr style='background:#CCC'>");
        s.Append("<td align=center style='font-weight:bold;height:25px; font-size:15px; font-family:times new roman;'>STT</td>");
        s.Append("<td align=center style='font-weight:bold; font-size:15px; font-family:times new roman;'>Tên bệnh nhân</td>");
        s.Append("<td align=center style='font-weight:bold; font-size:15px; font-family:times new roman;'>Năm sinh</td>");
        s.Append("<td align=center style='font-weight:bold; font-size:15px; font-family:times new roman;'>Giới tính</td>");
        s.Append("<td align=center style='font-weight:bold; font-size:15px; font-family:times new roman;'>Chiều cao</td>");
        s.Append("<td align=center style='font-weight:bold; font-size:15px; font-family:times new roman;'>Cân nặng</td>");
        s.Append("<td align=center style='font-weight:bold; font-size:15px; font-family:times new roman;'>Nhịp tim</td>");
        s.Append("<td align=center style='font-weight:bold; font-size:15px; font-family:times new roman;'>Tên công ty</td>");
        s.Append("<td align=center style='font-weight:bold; font-size:15px; font-family:times new roman;'>Ghi chú</td>");
        s.Append("</tr>");
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int cout = i + 1;
                string giotinh = "";
                if (dt.Rows[i][2].ToString() == "0")
                    giotinh = "Nữ";
                else
                    giotinh = "Nam";
                string Idcty = dt.Rows[i]["idcongty"].ToString();
                string tencty = "";
                string sql1 = "select tencty from Kb_Congty where idcongty='" + Idcty + "'";
                DataTable dtcty = DataAcess.Connect.GetTable(sql1);
                if (dtcty!= null && dtcty.Rows.Count > 0)
                {
                    tencty = dtcty.Rows[0][0].ToString();
                }
                s.Append("<tr>");
                s.Append("<td align=center style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + cout + "</td>");
                s.Append("<td align=left style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + dt.Rows[i][0] + "</td>");
                s.Append("<td align=center style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + dt.Rows[i][1] + "</td>");
                s.Append("<td align=left style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + giotinh + "</td>");
                s.Append("<td align=left style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + dt.Rows[i][3] + "</td>");
                s.Append("<td align=left style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + dt.Rows[i][4] + "</td>");
                s.Append("<td align=left style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + dt.Rows[i][5] + "</td>");
                s.Append("<td align=left style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + dt.Rows[i][6] + "</td>");
                s.Append("<td align=left style='font-weight:normal; font-size:15px; font-family:times new roman;'>" + dt.Rows[i][7] + "</td>");
                s.Append("</tr>");
            }
        }
        s.Append("</table>");
        danhsachbenhnhan.Text = "" + s;
    }
    protected void btnprint_OnClick(object sender, EventArgs e)
    {

        string IDcty = ddlBS.SelectedValue.ToString().Trim();
        //Response.Redirect("fr_rptBangTongHopKQSucKhoeTheoCty.aspx?Idcty=" + IDcty + "&datefrom=" + EmailClass.DateTimeFormat(txtdatefrom.Value) + "&dateto=" + EmailClass.DateTimeFormat(txtdateto.Value) + "");
        this.OpenLink("fr_rptBangTongHopKQSucKhoeTheoCty.aspx?Idcty=" + IDcty + "&datefrom=" + EmailClass.DateTimeFormat(txtdatefrom.Value) + "&dateto=" + EmailClass.DateTimeFormat(txtdateto.Value) + "");
    }

    private void OpenLink(string LinkName)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "script", "window.open('" + LinkName + "');", true);
    }
}
