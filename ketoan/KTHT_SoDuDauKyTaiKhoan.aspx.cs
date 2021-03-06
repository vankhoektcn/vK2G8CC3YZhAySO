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

public partial class ketoan_KTHT_SoDuDauKyTaiKhoan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDanhSachTaiKhoan();
            txtNam.Value = DateTime.Now.Year.ToString();
        }
    }
    List<string> listTaiKhoan = new List<string>();
    List<string> listTenTaiKhoan = new List<string>();

    public List<string> getDanhSachTaiKhoanCon(string TKCapCha, string TenTKCapCha)
    {
        string sql2 = "select TaiKhoan,TenTaiKhoan as TKCap2 from DanhMucTk where TKCapCha = '"+TKCapCha +"'";
        DataTable List_TKCap2 = DataAcess.Connect.GetTable(sql2);
        if (List_TKCap2 != null && List_TKCap2.Rows.Count > 0)
        {
            for (int j=0; j < List_TKCap2.Rows.Count; j++)
            {
                string TKCapCon = List_TKCap2.Rows[j][0].ToString();
                string TenTKCapCon = List_TKCap2.Rows[j][1].ToString();
                getDanhSachTaiKhoanCon(TKCapCon, TenTKCapCon);
            }
        }
        else
        {
            listTaiKhoan.Add(TKCapCha);
            listTenTaiKhoan.Add(TenTKCapCha);
        }
        return listTaiKhoan;
    }
    public void LoadDanhSachTaiKhoan()
    {
        string sql1 = "select TaiKhoan,TenTaiKhoan as TKCap1 from DanhMucTk where cap=1 order by taikhoan";
        DataTable List_TKCap1 = DataAcess.Connect.GetTable(sql1);
        if (List_TKCap1 != null && List_TKCap1.Rows.Count > 0)
        {
            for (int i = 0; i < List_TKCap1.Rows.Count; i++)
            {
                string TKCap1 = List_TKCap1.Rows[i][0].ToString();
                string TenTKCap1 = List_TKCap1.Rows[i][1].ToString();
                getDanhSachTaiKhoanCon(TKCap1, TenTKCap1);
            }
            ShowDanhSachTaiKhoan();
        }
    }   
    public void ShowDanhSachTaiKhoan()
    {
        string shtml = "";

        shtml += "<table class=\"TableGidview\" id=\"TableDanhSach\">";
               shtml +="<tr class=\"HeaderGidView\">";
               shtml += "<td style=\"width:20px\">STT</td>";
               shtml += "<td style=\"width:80px\">Tài khoản</td>";
                   shtml +="<td style=\"width:300px\">Tên tài khoản</td>";
                   shtml += "<td style=\"width:150px\">Nợ đầu kỳ</td>";
                   shtml += "<td style=\"width:150px\">Có đầu kỳ</td>";
                   shtml += "<td style=\"width:150px\">Nợ đầu kỳ ngoại tệ</td>";
                   shtml += "<td style=\"width:150px\">Có đầu kỳ ngoại tệ</td>";                  
               shtml += "</tr>";                	    
	                       
        if (listTaiKhoan != null && listTaiKhoan.Count > 0)
        {
            for (int i = 0; i < listTaiKhoan.Count; i++)
            {             
                shtml += " <tr>";
                shtml += "		<td>"+(i+1)+"</td>";
                shtml += "		<td style=\"background-color:White\"><input type=\"hidden\" id=\"TaiKhoan_" + (i + 1) + "\" style=\"width:98%\" readonly=\"readonly\" value=\"" + listTaiKhoan[i] + "\" />" + listTaiKhoan[i] + "</td>";
                shtml += "		<td><input type=\"text\" id=\"TenTaiKhoan_" + (i + 1) + "\" style=\"width:98%\"  readonly=\"readonly\" value=\"" + listTenTaiKhoan[i] + "\" /></td>";
                shtml += "		<td><input type=\"text\" style=\"width:98%;text-align:right\"   id=\"NoDauKy_" + (i + 1) + "\" onkeyup=\"TestNumberofInput('NoDauKy_" + (i + 1) + "')\"  onchange=\"getFormatSoTien(this)\" /></td>";
                shtml += "		<td><input type=\"text\" style=\"width:98% ;text-align:right\" onchange=\"getFormatSoTien(this)\" id=\"CoDauKy_" + (i + 1) + "\" onkeyup=\"TestNumberofInput('CoDauKy_" + (i + 1) + "')\" /></td>";
                shtml += "	    <td><input type=\"text\" style=\"width:98% ;text-align:right\" onchange=\"getFormatSoTien(this)\" id=\"NoDauKyNgoaiTe_" + (i + 1) + "\" onkeyup=\"TestNumberofInput('NoDauKyNgoaiTe_" + (i + 1) + "')\"  /></td>";
                shtml += "		<td><input type=\"text\" style=\"width:98% ;text-align:right\" onchange=\"getFormatSoTien(this)\" id=\"CoDauKyNgoaiTe_" + (i + 1) + "\"  onkeyup=\"TestNumberofInput('CoDauKyNgoaiTe_" + (i + 1) + "')\" /></td>";               
                shtml += "	</tr>";
            }
        }
        shtml += "	</table>";
        divDanhSach.InnerHtml = shtml;
    }
    #region khoi tao va giai phong bo nho
    private void form_unload(object sender, System.EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(form_unload);
    }
    #endregion
}
