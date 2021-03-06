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


public partial class DMNghiepVu_ajax : System.Web.UI.Page
{
    protected DataProcess s_DMNghiepVu()
    {
        DataProcess DMNghiepVu = new DataProcess("DMNghiepVu");
        DMNghiepVu.data("Id", Request.QueryString["Id"]);
        DMNghiepVu.data("MaNghiepVu", Request.QueryString["MaNghiepVu"]);
        DMNghiepVu.data("TenNghiepVu", Request.QueryString["TenNghiepVu"]);
        DMNghiepVu.data("DienGiai", Request.QueryString["DienGiai"]);
        DMNghiepVu.data("TiepDauNgu", Request.QueryString["TiepDauNgu"]);
        DMNghiepVu.data("SoCT_hientai", Request.QueryString["SoCT_hientai"]);
        DMNghiepVu.data("TKNo", Request.QueryString["TKNo"]);
        DMNghiepVu.data("TKCo", Request.QueryString["TKCo"]);
        DMNghiepVu.data("TKThue", Request.QueryString["TKThue"]);
        DMNghiepVu.data("tkck", Request.QueryString["tkck"]);
        DMNghiepVu.data("VAT", Request.QueryString["VAT"]);
        return DMNghiepVu;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable_DMNghiepVu(); break;
            case "xoa": Xoa_DMNghiepVu(); break;
            case "TimKiem": TimKiem(); break;
            case "testsoct": testsoct(); break;
            case "testsoct1": testsoct1(); break;
            case "Save": Save(); break;
        }
    }

    private void testsoct()
    {
        string html = "";
        string sophieu = Request.QueryString["so_phieu"].ToString();
        if (sophieu != "")
        {
            try
            {
                if (sophieu.Substring(sophieu.Length - 8, 8).Length == 8)
                {
                    int test = int.Parse(sophieu.Substring(sophieu.Length - 8, 8));
                    string tiepdaungu = Request.QueryString["tiepdaungu"].ToString();
                    if (tiepdaungu == sophieu.Substring(0, sophieu.Length - 8))
                    {
                        string sql = "";
                        if (Request.QueryString["MaNghiepVu"].ToString() == "PN_TSCD" && Request.QueryString["MaNghiepVu"].ToString() == "PN_CCDC"
                            && Request.QueryString["MaNghiepVu"].ToString() == "PX_TSCD" && Request.QueryString["MaNghiepVu"].ToString() == "PX_CCDC")
                        {
                            sql = "select so_phieu from phieu_nhap_vt where so_phieu='" + Request.QueryString["so_phieu"] + "'";
                            try
                            {
                                DataTable table = DataAcess.Connect.GetTable(sql);
                                if (table.Rows.Count > 0)
                                    html = "2";//Số ct này đã tồn tại
                            }
                            catch
                            {
                                html = "1";
                            }
                        }
                    }
                    else
                        html = "1";
                }
                else
                    html = "1";
            }
            catch
            {
                html = "1";//số ct ko hợp lệ
            }
        }
        else
        {
            html = "0";
        }

        Response.Clear(); Response.Write(html);
    }
    private void testsoct1()
    {
        string html = "";
        string sophieu = Request.QueryString["so_phieu"].ToString();
        if (sophieu != "")
        {
            try
            {
                int test = int.Parse(sophieu.Substring(sophieu.Length - 8, 8));
            }
            catch
            {
                html = "1";//số ct ko hợp lệ
            }
        }
        else
        {
            html = "0";
        }

        Response.Clear(); Response.Write(html);
    }
    private void Xoa_DMNghiepVu()
    {
        try
        {
            DataProcess process = s_DMNghiepVu();
            bool ok = process.Delete();
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

    private void Save()
    {
        string manghiepvu = Request.QueryString["manghiepvu"].ToString();
        string tennghiepvu = Request.QueryString["tennghiepvu"].ToString();
        string diengiai = Request.QueryString["diengiai"].ToString();
        string tiepdaungu = Request.QueryString["tiepdaungu"].ToString();
        string soct_hientai = Request.QueryString["soct_hientai"].ToString();
        string tkno = Request.QueryString["tkno"].ToString();
        string tkco = Request.QueryString["tkco"].ToString();
        string tkck = Request.QueryString["tkck"].ToString();
        string tkthue = Request.QueryString["tkthue"].ToString();
        string[] vat = Request.QueryString["vat"].ToString().Split('.');
        string test = "";
        DataTable tbtest = DataAcess.Connect.GetTable("select top 1 tiepdaungu from dmnghiepvu where tiepdaungu='" + tiepdaungu + "'");
        if (tbtest.Rows.Count == 0)
        {
            string sqlsave = "insert into dmnghiepvu values('" + manghiepvu + "',N'" + tennghiepvu + "',N'" + diengiai + "','" + tiepdaungu + "'";
            sqlsave += ",'" + soct_hientai + "','" + tkno + "','" + tkco + "','" + tkthue + "','" + tkck + "','" + vat[0].ToString() + "')";
            bool ktsave = DataAcess.Connect.ExecSQL(sqlsave);
            if (ktsave)
                test = "0";//Thành công
            else
                test = "1";//Thất bại
        }
        else
        {
            test = "2";//Mã đã tồn tại
        }
        Response.Clear(); Response.Write(test);
    }
    private void LuuTable_DMNghiepVu()
    {
        try
        {
            DataProcess process = s_DMNghiepVu();
            string sql = "select tiepdaungu from dmnghiepvu where tiepdaungu='" + process.getData("TiepDauNgu") + "'";
            DataTable tbtest = DataAcess.Connect.GetTable(sql);
            if (tbtest.Rows.Count<=1)
            {
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
                    bool ok = process.Insert();
                    if (ok)
                    {
                        Response.Clear(); Response.Write(process.getData("Id"));
                        return;
                    }
                }
            }
            else
                Response.StatusCode = 500;    
        }
        catch
        {
        }
        //Response.StatusCode = 500;       
    }
    private void TimKiem()
    {
        DataProcess process = s_DMNghiepVu();
        process.Page = Request.QueryString["page"];
        process.NumberRow = "50";
        DataTable table = process.Search(@"select STT=row_number() over (order by T.Id),T.*
                               from DMNghiepVu T
          where " + process.sWhere());
        string html = "";
        html += process.Paging();
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th></th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Mã Nghiệp Vụ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tên Nghiệp Vụ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Diễn Giải") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Tiếp Đầu Ngữ") + "</th>";
        //html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoCT_Hiện Tại") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK Nợ") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK Có") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK Thuế") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TK Chiết Khấu") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("VAT") + "</th>";
        html += "<th></th>";
        html += "</tr>";
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html += "<tr>";
                    html += "<td>" + table.Rows[i]["stt"].ToString() + "</td>";
                    if (StaticData.HavePermision(this.Page, "KeToanDM_KTDM_DanhMucNghiepVu_Xoa"))
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                    else
                        html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\"></td>";
                    html += "<td><input mkv='true' id='MaNghiepVu' readonly='readonly' type='text' value='" + table.Rows[i]["MaNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:80px'/></td>";
                    html += "<td><input mkv='true' id='TenNghiepVu' readonly='readonly' type='text' value='" + table.Rows[i]["TenNghiepVu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='DienGiai' type='text' value='" + table.Rows[i]["DienGiai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='TiepDauNgu' type='text' value='" + table.Rows[i]["TiepDauNgu"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' style='width:50px'/>";
                    html += "<input mkv='true' id='SoCT_hientai' type='hidden' value='" + table.Rows[i]["SoCT_hientai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);'  onblur='testsoct(this);' style='width:100%'/></td>";
                    //html += "<td><input mkv='true' id='SoCT_hientai' type='text' value='" + table.Rows[i]["SoCT_hientai"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);'  onblur='testsoct(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='TKNo' type='text' value='" + table.Rows[i]["TKNo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:40px'/></td>";
                    html += "<td><input mkv='true' id='TKCo' type='text' value='" + table.Rows[i]["TKCo"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:40px'/></td>";
                    html += "<td><input mkv='true' id='TKThue' type='text' value='" + table.Rows[i]["TKThue"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:40px'/></td>";
                    html += "<td><input mkv='true' id='tkck' type='text' value='" + table.Rows[i]["tkck"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:40px'/></td>";
                    html += "<td><input mkv='true' id='VAT' type='text' value='" + table.Rows[i]["VAT"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:40px'/></td>";
                    html += "<td><input mkv='true' id=\"Id\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["Id"] + "'/></td>";
                    html += "</tr>";
                }
            }
            else
            {
                /*html += "<tr>";
                html += "<td>1</td>";
                html += "<td> <a id=\"xoaRow\" onclick=\"xoa(this);\" onfocus=\"chuyendong(this);\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</td>";
                html += "<td><input mkv='true' id='MaNghiepVu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TenNghiepVu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='DienGiai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TiepDauNgu' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='SoCT_hientai' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKNo' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKCo' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='TKThue' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='tkck' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyenphim(this);ShowTaiKhoan1(this);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id='VAT' type='text' value='' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' onblur='TestSo(this,false,false);' style='width:100%'/></td>";
                html += "<td><input mkv='true' id=\"Id\" mkv=\"true\" type=\"hidden\" value=''/></td>";
                html += "</tr>";
                 */
            }
        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        html += process.Paging();
        Response.Clear(); Response.Write(html);
    }

}

