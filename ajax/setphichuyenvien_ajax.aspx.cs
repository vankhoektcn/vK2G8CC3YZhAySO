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

public partial class setphichuyenvien_ajax : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "luuTable": LuuTable(); break;
            case "TimKiem": TimKiem(); break;
            case "dichvusearch": dichvusearch(); break;
        }
    }
   
    private void dichvusearch()
    {
        string q = Request.QueryString["q"];
        if (q != "")
        {
            string sql = " select * from banggiadichvu where tendichvu like N'%"+ q+"%'" ;

            DataTable table = DataAcess.Connect.GetTable(sql);
            string html = "";
            if (table != null)
            {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                        html += table.Rows[i]["tendichvu"].ToString() +" - Chi phí :"+table.Rows[i]["giadichvu"].ToString()+"|"+ table.Rows[i]["idbanggiadichvu"].ToString() + Environment.NewLine;

                    }
                
            }
            Response.Clear(); Response.Write(html);
        }
    }
    
    private void LuuTable()
    {
        try
        {

            string iddv1 = Request.QueryString["iddv1"];
            string iddv2 = Request.QueryString["iddv2"];
            string iddv3 = Request.QueryString["iddv3"];
            string idbenhvien = Request.QueryString["idbenhvien"];
            string tenbenhvien = Request.QueryString["tenbenhvien"];
            string sql = "update benhvien  set tenbenhvien= N'" + tenbenhvien + "'";
            if (iddv1 != "")
                sql += ", idbanggiadichvu=" + iddv1;
            if (iddv2 != "")
                sql += ", idbanggiadichvuddbs=" + iddv2;
            if (iddv3 != "")
                sql += ", idbanggiadichvudd=" + iddv3;
            sql += " where idbenhvien=" + idbenhvien;
            DataAcess.Connect.Exec(sql);
            return;
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    private void TimKiem()
    {

        string sql="";
        string mabenhvien = Request.QueryString["mabenhvien"];
        string tenbenhvien = Request.QueryString["tenbenhvien"];
        if (mabenhvien != "")
            sql += " and mabenhvien like '%"+mabenhvien+"%'";
        if (tenbenhvien != "")
            sql += " and tenbenhvien like N'%" + tenbenhvien + "%'";
        sql = @"select top 50 STT=row_number() over (order by T.tenbenhvien),T.*
                   , A.tendichvu dv1, A.giadichvu giadv1, A.idbanggiadichvu iddv1
, B.tendichvu dv2, B.giadichvu giadv2, B.idbanggiadichvu iddv2
, C.tendichvu dv3, C.giadichvu giadv3, C.idbanggiadichvu iddv3
                               from benhvien T
                    left join banggiadichvu  A on T.idbanggiadichvu= A.idbanggiadichvu
left join banggiadichvu  B on T.idbanggiadichvuDDBS= B.idbanggiadichvu
left join banggiadichvu  C on T.idbanggiadichvuDD= C.idbanggiadichvu
          where 1=1 " + sql;
        DataTable table = DataAcess.Connect.GetTable(sql);
        string html = "";
        html += "<table class='jtable' id=\"gridTable\">";
        html += "<tr>";
        html += "<th>STT</th>";
        html += "<th width='80px'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("mabenhvien") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("tenbenhvien") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("phikocobsdd") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("phicobsdd") + "</th>";
        html += "<th>" + hsLibrary.clDictionaryDB.sGetValueLanguage("phicodd") + "</th>";
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
                    html += "<td>" + table.Rows[i]["mabenhvien"].ToString() + "</td>";
                    html += "<td><input mkv='true' id='tenbenhvien' type='text' value='" + table.Rows[i]["tenbenhvien"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);' style='width:100%'/></td>";
                    html += "<td><input mkv='true' id='dv1' type='text' value='" + table.Rows[i]["dv1"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);dichvusearch(this);' /></td>";
                    html += "<td><input mkv='true' id='dv2' type='text' value='" + table.Rows[i]["dv2"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);dichvusearch(this);' /></td>";
                    html += "<td><input mkv='true' id='dv3' type='text' value='" + table.Rows[i]["dv3"].ToString() + "' onfocusout='chuyenformout(this)' onfocus='chuyendong(this);chuyenphim(this);dichvusearch(this);'/></td>";
                    
                    
                    html += "<td><input mkv='true' id=\"iddv1\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["iddv1"] + "'/>";
                     html += "<input mkv='true' id=\"iddv2\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["iddv2"] + "'/>";
 html += "<input mkv='true' id=\"iddv3\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["iddv3"] + "'/>";
 html += "<input mkv='true' id=\"idbenhvien\" mkv=\"true\" type=\"hidden\" value='" + table.Rows[i]["idbenhvien"] + "'/>";
                        
                        
                        
                        html+="</td>";
                    html += "</tr>";
                }
            }

          

        }
        html += "<tr><td></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }
}
 
 
