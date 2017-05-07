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

public partial class ToaThuocMau_ajax : System.Web.UI.Page
{
    protected DataProcess s_ToaThuocMau()
    {
        DataProcess ToaThuocMau = new DataProcess("ToaThuocMau");
        ToaThuocMau.data("idToaThuoc", Request.QueryString["idkhoachinh"]);
        ToaThuocMau.data("TenToaThuoc", Request.QueryString["TenToaThuoc"]);
        ToaThuocMau.data("IdChanDoan", Request.QueryString["IdChanDoan"]);
        ToaThuocMau.data("Songay", Request.QueryString["Songay"]);
        ToaThuocMau.data("IdNguoiDung", Request.QueryString["IdNguoiDung"]);
        return ToaThuocMau;
    }
    protected DataProcess s_ToaThuocMauChiTiet()
    {
        DataProcess ToaThuocMauChiTiet = new DataProcess("ToaThuocMauChiTiet");
        ToaThuocMauChiTiet.data("idchitiettoathuoc", Request.QueryString["idkhoachinh"]);
        ToaThuocMauChiTiet.data("idtoathuoc", Request.QueryString["idtoathuoc"]);
        ToaThuocMauChiTiet.data("DoiTuongThuocID", Request.QueryString["DoiTuongThuocID"]);
        ToaThuocMauChiTiet.data("idthuoc", Request.QueryString["idthuoc"]);
        ToaThuocMauChiTiet.data("soluongke", Request.QueryString["soluongke"]);
        ToaThuocMauChiTiet.data("ngayuong", Request.QueryString["ngayuong"]);
        ToaThuocMauChiTiet.data("moilanuong", Request.QueryString["moilanuong"]);
        ToaThuocMauChiTiet.data("tenNgaydung", Request.QueryString["tenNgaydung"]);
        ToaThuocMauChiTiet.data("idcachdung", Request.QueryString["idcachdung"]);
        ToaThuocMauChiTiet.data("iddvdung", Request.QueryString["iddvdung"]);
        ToaThuocMauChiTiet.data("iddvt", Request.QueryString["iddvt"]);
        ToaThuocMauChiTiet.data("ischieu", Request.QueryString["ischieu"]);
        ToaThuocMauChiTiet.data("isngay", Request.QueryString["isngay"]);
        ToaThuocMauChiTiet.data("issang", Request.QueryString["issang"]);
        ToaThuocMauChiTiet.data("istoi", Request.QueryString["istoi"]);
        ToaThuocMauChiTiet.data("istrua", Request.QueryString["istrua"]);
        ToaThuocMauChiTiet.data("istuan", Request.QueryString["istuan"]);
        ToaThuocMauChiTiet.data("ghichu", Request.QueryString["ghichu"]);
        ToaThuocMauChiTiet.data("IsHaoPhi", Request.QueryString["IsHaoPhi"]);
        return ToaThuocMauChiTiet;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "Luu": SaveToaThuocMau(); break;
            case "TimKiem": TimKiem(); break;
            case "setTimKiem": setTimKiem(); break;
            case "luuTableToaThuocMauChiTiet": LuuTableToaThuocMauChiTiet(); break;
            case "loadTableToaThuocMauChiTiet": loadTableToaThuocMauChiTiet(); break;
            case "xoa": XoaToaThuocMau(); break;
            case "xoaToaThuocMauChiTiet": XoaToaThuocMauChiTiet(); break;
            case "IdChanDoanSearch": IdChanDoanSearch(); break;
            case "IdNguoiDungSearch": IdNguoiDungSearch(); break;
            case "DoiTuongThuocIDSearch": DoiTuongThuocIDSearch(); break;
            case "idthuocSearch": idthuocSearch(); break;
            case "idcachdungSearch": idcachdungSearch(); break;
            case "iddvdungSearch": iddvdungSearch(); break;
            case "iddvtSearch": iddvtSearch(); break;
        }
    }
    private void IdChanDoanSearch()
    {
        string sqlSelect = @"SELECT TOP 20 * FROM CHANDOANICD WHERE 1=1 ";
        string mota = Request.QueryString["q"];
        if (mota != null && mota != "")
        {
            sqlSelect += " AND MOTA LIKE N'%" + mota + "%'";
        }
        DataTable table = DataProcess.GetTable(sqlSelect);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["MoTa"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void IdNguoiDungSearch()
    {
        DataTable table = DataProcess.GetTable("select * from nguoidung ");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tennguoidung"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void DoiTuongThuocIDSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_LoaiThuoc");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenLoai"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void idthuocSearch()
    {
        string TypeSearch = Request.QueryString["TypeSearch"];
        string sValue = Request.QueryString["q"];
        string tenthuoc = null;
        string congthuc = null;
        if (TypeSearch == "tenthuoc")
            tenthuoc = sValue;
        else
            congthuc = sValue;
        string IdLoaiThuoc = Request.QueryString["loaithuocid"];
        if (IdLoaiThuoc == null || IdLoaiThuoc == "")
            IdLoaiThuoc = "1";
        string loaithuocid = "";
        loaithuocid = " and t.loaithuocid = " + IdLoaiThuoc;
        string IdKho = StaticData.GetParaValueDB("KhoThuocBHYT");
        string sql = @"SELECT top 20 t.idthuoc,t.tenthuoc
                        ,t.loaithuocid
                        ,dvt.tendvt as donvitinh,t.iddvt
                        ,t.congthuc as congthuc
                        , cd.tencachdung as duongdung,cd.idcachdung
                        ,t.sudungchobh
                        ,t.isthuocbv
                        FROM thuoc t
                        left join thuoc_donvitinh dvt on dvt.id=t.iddvt
                        left join thuoc_cachdung cd on cd.idcachdung=t.idcachdung
                        where 1=1 AND T.ISTHUOCBV=1 ";
        if (tenthuoc != null && tenthuoc != "")
            sql += " and  t.tenthuoc LIKE N'" + tenthuoc + @"%'";
        if (congthuc != null && congthuc != "")
            sql += " and  t.congthuc LIKE N'" + congthuc + @"%'";
        if (loaithuocid != null && loaithuocid != "")
            sql += loaithuocid;
        sql += " ORDER BY  isnull(t.sudungchobh,0) desc, isnull( t.isthuocbv,0) desc ,  t.tenthuoc ASC";
        string html = "";
        DataTable arr = DataAcess.Connect.GetTable(sql);
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                string strTon = "SELECT  [dbo].[Thuoc_TonKho_new_1910](" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + "'," + IdKho + ")";
                DataTable tbTon = DataAcess.Connect.GetTable(strTon);
                string giathuoc = "SELECT DBO.Thuoc_tinhGiaXuat2(" + h["idthuoc"] + ",'" + DateTime.Now.ToString("yyyy/MM/dd 23:59:59") + @"',1,1,1," + IdKho + ")";
                DataTable dtGiaThuoc = DataAcess.Connect.GetTable(giathuoc);
                html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}",
                                      "<div style=\"width:100%;height:30px;" + ((StaticData.IsCheck(h["sudungchobh"].ToString()) == false) ? "background-color:#CAE3FF;" : "") + "\">"
                                      + "<div style=\"width:21%;float:left;height:30px\" >" + h["tenthuoc"] + "</div>"
                                      + "<div style=\"width:23%;float:left;height:30px\" >" + h["congthuc"] + "</div>"
                                      + "<div style=\"text-align:left;width:12%;float:left;height:30px\" >" + h["duongdung"] + "</div>"
                                      + "<div style=\"text-align:left;width:10%;float:left;height:30px\" >" + h["donvitinh"] + "</div>"
                                      + "<div style=\"text-align:left;width:9%;float:left;height:30px\" >" + dtGiaThuoc.Rows[0][0] + "</div>"
                                      + "<div style=\"text-align:left;width:4%;float:left;height:30px\" >" + tbTon.Rows[0][0] + "</div>"
                                      + "<div style=\"text-align:right;width:7%;float:left;height:30px\" >" + (StaticData.IsCheck(h["sudungchobh"].ToString()) == true ? "BH" : "DV") + "</div>"
                                      + "<div style=\"text-align:right;width:10%;float:left;height:30px\" >" + (StaticData.IsCheck(h["isthuocbv"].ToString()) == true ? hsLibrary.clDictionaryDB.sGetValueLanguage("thuocbv") : hsLibrary.clDictionaryDB.sGetValueLanguage("thuocdv")) + "</div>"
                                      + "</div>", h["idthuoc"], h["donvitinh"], h["duongdung"], h["tenthuoc"], dtGiaThuoc.Rows[0][0],
                                      tbTon.Rows[0][0], h["congthuc"], StaticData.IsCheck(h["sudungchobh"].ToString()), h["iddvt"], h["idcachdung"], IdKho, Environment.NewLine);
                ;

            }
        }
        Response.Clear();
        Response.Write(html);
        Response.End();
    }
    private void idcachdungSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_CachDung");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tencachdung"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void iddvdungSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_DonViTinh");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenDVT"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void iddvtSearch()
    {
        DataTable table = DataProcess.GetTable("select * from Thuoc_DonViTinh");
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["TenDVT"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void XoaToaThuocMau()
    {
        try
        {
            DataProcess process = s_ToaThuocMau();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idToaThuoc"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void XoaToaThuocMauChiTiet()
    {
        try
        {
            DataProcess process = s_ToaThuocMauChiTiet();
            bool ok = process.Delete();
            if (ok)
            {
                Response.Clear(); Response.Write(process.getData("idchitiettoathuoc"));
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void setTimKiem()
    {
        if (Userlogin_new.HavePermision(this, "ToaThuocMau_Search"))
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            DataTable table = DataProcess.GetTable(@"select top 1 idkhoachinh=T.idToaThuoc,T.*
                   ,mkv_IdChanDoan = A.EnglishName
                   ,mkv_IdNguoiDung = B.tennguoidung
                               from ToaThuocMau T
                    left join ChanDoanICD  A on T.IdChanDoan=A.IDICD
                    left join nguoidung  B on T.IdNguoiDung=B.idnguoidung
                 where T.idToaThuoc ='" + idkhoachinh + "'");
            Response.Clear();
            Response.Write(DataProcess.JSONDataTable_Parameters(table));
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu");
            Response.StatusCode = 500;
        }
    }
    private void TimKiem()
    {
        if (Userlogin_new.HavePermision(this, "ToaThuocMau_Search"))
        {
            DataProcess process = s_ToaThuocMau();
            process.Page = Request.QueryString["page"];
            DataTable table = process.Search(@"select STT=row_number() over (order by T.idToaThuoc),T.*
                   ,A.EnglishName
                   ,B.tennguoidung
                               from ToaThuocMau T
                    left join ChanDoanICD  A on T.IdChanDoan=A.IDICD
                    left join nguoidung  B on T.IdNguoiDung=B.idnguoidung
          where " + process.sWhere());
            StringBuilder html = new StringBuilder();
            html.Append("<table class='jtable' id=\"tablefind\">");
            html.Append("<tr>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenToaThuoc") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdChanDoan") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Songay") + "</th>");
            html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdNguoiDung") + "</th>");
            html.Append("</tr>");
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        html.Append("<tr onclick=\"setControlFind('" + table.Rows[i]["idToaThuoc"].ToString() + "')\">");
                        html.Append("<td>" + table.Rows[i]["TenToaThuoc"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["EnglishName"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["Songay"].ToString() + "</td>");
                        html.Append("<td>" + table.Rows[i]["tennguoidung"].ToString() + "</td>");
                        html.Append("</tr>");
                    }
                    html.Append("</table>");
                    html.Append(process.Paging());
                    Response.Clear(); Response.Write(html);
                    return;
                }
            }
            else
            {
                Response.StatusCode = 500;
            }
        }
        else
        {
            Response.Write("Bạn không có quyền xem dữ liệu.");
        }
    }
    private void SaveToaThuocMau()
    {
        try
        {
            DataProcess process = s_ToaThuocMau();
            if (process.getData("idToaThuoc") != null && process.getData("idToaThuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idToaThuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idToaThuoc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableToaThuocMauChiTiet()
    {
        try
        {
            DataProcess process = s_ToaThuocMauChiTiet();
            if (process.getData("idchitiettoathuoc") != null && process.getData("idchitiettoathuoc") != "")
            {
                bool ok = process.Update();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitiettoathuoc"));
                    return;
                }
            }
            else
            {
                bool ok = process.Insert();
                if (ok)
                {
                    Response.Clear(); Response.Write(process.getData("idchitiettoathuoc"));
                    return;
                }
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void loadTableToaThuocMauChiTiet()
    {
        string paging = "";
        StringBuilder html = new StringBuilder();
        html.Append("<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th>STT</th>");
        html.Append("<th></th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("d.t.thuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idthuoc") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("iddvt") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("s.l.kê") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("c.dùng") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("n.uống") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("l.dùng") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("d.vị.dùng") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("issang") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("istrua") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ischieu") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("istoi") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("isngay") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("istuan") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</th>");
        html.Append("<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("h.phí") + "</th>");
        html.Append("<th></th>");
        html.Append("</tr>");
        bool add = Userlogin_new.HavePermision(this, "ToaThuocMauChiTiet_Add");
        bool search = Userlogin_new.HavePermision(this, "ToaThuocMauChiTiet_Search");
        if (search)
        {
            DataProcess process = s_ToaThuocMauChiTiet();
            process.Page = Request.QueryString["page"];
            string sqlSelect = @"select STT=row_number() over (order by T.idchitiettoathuoc),T.*
                   ,A.TenToaThuoc
                   ,B.TenLoai
                   ,C.TenDonVi
                   ,D.tencachdung
                   ,DVTINH=E.TenDVT
                   ,DVDUNG=F.TenDVT
                   ,C.TENTHUOC
                               from ToaThuocMauChiTiet T
                    left join ToaThuocMau  A on T.idtoathuoc=A.idToaThuoc
                    left join Thuoc_LoaiThuoc  B on T.DoiTuongThuocID=B.LoaiThuocID
                    left join thuoc  C on T.idthuoc=C.idthuoc
                    left join Thuoc_CachDung  D on T.idcachdung=D.idcachdung
                    left join Thuoc_DonViTinh  E on T.iddvdung=E.Id
                    left join Thuoc_DonViTinh  F on T.iddvt=F.Id
          where T.idtoathuoc='" + process.getData("idtoathuoc") + "'";
            DataTable table = process.Search(sqlSelect);
            if (table.Rows.Count > 0)
            {
                paging = process.Paging("ToaThuocMauChiTiet");
                bool delete = Userlogin_new.HavePermision(this, "ToaThuocMauChiTiet_Delete");
                bool edit = Userlogin_new.HavePermision(this, "ToaThuocMauChiTiet_Edit");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    html.Append("<tr>");
                    html.Append("<td>" + table.Rows[i]["stt"].ToString() + "</td>");
                    html.Append("<td><a style='color:" + (!delete ? "#cfcfcf" : "") + "' onclick=\"xoaontable(this," + delete.ToString().ToLower() + ");\">" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
                    html.Append("<td><input mkv='true' id='DoiTuongThuocID' type='hidden' value='" + table.Rows[i]["DoiTuongThuocID"] + "'/><input mkv='true' id='mkv_DoiTuongThuocID' type='text' value='" + table.Rows[i]["TenLoai"].ToString() + "' onfocus='DoiTuongThuocIDSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:80px' /></td>");
                    html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value='" + table.Rows[i]["idthuoc"] + "'/><input mkv='true' id='mkv_idthuoc' type='text' value='" + table.Rows[i]["TENTHUOC"].ToString() + "' onfocus=\"idthuocSearch(this,'tenthuoc');\" class=\"down_select\" " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='iddvt' type='hidden' value='" + table.Rows[i]["iddvt"] + "'/><input mkv='true' id='mkv_iddvt' type='text' value='" + table.Rows[i]["DVTINH"].ToString() + "' onfocus='iddvtSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:60px' /></td>");
                    html.Append("<td><input mkv='true' id='soluongke' type='text' value='" + table.Rows[i]["soluongke"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:40px' /></td>");
                    html.Append("<td><input mkv='true' id='idcachdung' type='hidden' value='" + table.Rows[i]["idcachdung"] + "'/><input mkv='true' id='mkv_idcachdung' type='text' value='" + table.Rows[i]["tencachdung"].ToString() + "' onfocus='idcachdungSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:80px'/></td>");
                    html.Append("<td><input mkv='true' id='ngayuong' type='text' value='" + table.Rows[i]["ngayuong"].ToString() + "' onblur='TestSo(this,false,false);' " + (!edit ? "disabled" : "") + " style='width:50px'/></td>");
                    html.Append("<td><input mkv='true' id='moilanuong' type='text'  value='" + table.Rows[i]["moilanuong"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:30px' /></td>");
                    html.Append("<td><input mkv='true' id='iddvdung' type='hidden' value='" + table.Rows[i]["iddvdung"] + "'/><input mkv='true' id='mkv_iddvdung' type='text' value='" + table.Rows[i]["DVDUNG"].ToString() + "' onfocus='iddvdungSearch(this);' class=\"down_select\" " + (!edit ? "disabled" : "") + " style='width:70px'/></td>");
                    html.Append("<td><input mkv='true' id='issang' type='checkbox' " + (table.Rows[i]["issang"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='ischieu' type='checkbox' " + (table.Rows[i]["ischieu"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='istrua' type='checkbox' " + (table.Rows[i]["istrua"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='istoi' type='checkbox' " + (table.Rows[i]["istoi"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='isngay' type='checkbox' " + (table.Rows[i]["isngay"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/>" + hsLibrary.clDictionaryDB.sGetValueLanguage("isngay") + "</td>");
                    html.Append("<td><input mkv='true' id='istuan' type='checkbox' " + (table.Rows[i]["istuan"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/>" + hsLibrary.clDictionaryDB.sGetValueLanguage("istuan") + "</td>");
                    html.Append("<td><input mkv='true' id='ghichu' type='text'  value='" + table.Rows[i]["ghichu"].ToString() + "' " + (!edit ? "disabled" : "") + " style='width:100px' /></td>");
                    html.Append("<td><input mkv='true' id='IsHaoPhi' type='checkbox' " + (table.Rows[i]["IsHaoPhi"].ToString() == "True" ? "checked" : "") + " " + (!edit ? "disabled" : "") + "/></td>");
                    html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + table.Rows[i]["idchitiettoathuoc"].ToString() + "'/></td>");
                    html.Append("</tr>");
                }
            }
        }
        if (add)
        {
            html.Append("<tr>");
            html.Append("<td>1</td>");
            html.Append("<td><a onclick='xoaontable(this)'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>");
            html.Append("<td><input mkv='true' id='DoiTuongThuocID' type='hidden' value=''/><input mkv='true' id='mkv_DoiTuongThuocID' type='text' value='' onfocus='DoiTuongThuocIDSearch(this);' class=\"down_select\" style='width:80px' /></td>");
            html.Append("<td><input mkv='true' id='idthuoc' type='hidden' value=''/><input mkv='true' id='mkv_idthuoc' type='text' value='' onfocus=\"idthuocSearch(this,'tenthuoc');\" class=\"down_select\"/></td>");
            html.Append("<td><input mkv='true' id='iddvt' type='hidden' value=''/><input mkv='true' id='mkv_iddvt' type='text' value='' onfocus='iddvtSearch(this);' class=\"down_select\" style='width:60px' /></td>");
            html.Append("<td><input mkv='true' id='soluongke' type='text' value='' onblur='TestSo(this,false,false);' style='width:40px' /></td>");
            html.Append("<td><input mkv='true' id='idcachdung' type='hidden' value=''/><input mkv='true' id='mkv_idcachdung' type='text' value='' onfocus='idcachdungSearch(this);' class=\"down_select\" style='width:80px'/></td>");
            html.Append("<td><input mkv='true' id='ngayuong' type='text' value='' onblur='TestSo(this,false,false);' style='width:50px'/></td>");
            html.Append("<td><input mkv='true' id='moilanuong' type='text' value='' style='width:30px' /></td>");
            html.Append("<td><input mkv='true' id='iddvdung' type='hidden' value=''/><input mkv='true' id='mkv_iddvdung' type='text' value='' onfocus='iddvdungSearch(this);' class=\"down_select\" style='width:70px'/></td>");
            html.Append("<td><input mkv='true' id='issang' type='checkbox' /></td>");
            html.Append("<td><input mkv='true' id='istrua' type='checkbox' /></td>");
            html.Append("<td><input mkv='true' id='ischieu' type='checkbox' /></td>");
            html.Append("<td><input mkv='true' id='istoi' type='checkbox' /></td>");
            html.Append("<td><input mkv='true' id='isngay' type='checkbox' />" + hsLibrary.clDictionaryDB.sGetValueLanguage("isngay") + "</td>");
            html.Append("<td><input mkv='true' id='istuan' type='checkbox' />" + hsLibrary.clDictionaryDB.sGetValueLanguage("istuan") + "</td>");
            html.Append("<td><input mkv='true' id='ghichu' type='text' value='' style='width:100px' /></td>");
            html.Append("<td><input mkv='true' id='IsHaoPhi' type='checkbox' /></td>");
            html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value=''/></td>");
            html.Append("</tr>");
        }
        html.Append("<tr><td></td><td colspan='3'>" + (add ? "" : "Bạn không có quyền thêm mới") + "</td></tr>");
        html.Append("</table>");
        if (!search)
            html.Append("Bạn không có quyền xem.");
        else
            html.Append(paging);
        Response.Clear(); Response.Write(html);
    }
}


