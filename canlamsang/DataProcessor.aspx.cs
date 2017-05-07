using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json.Linq;   
namespace MeKongViet
{
    public partial class DataProcessor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ProcessAjaxRequest();
        }
        private void ProcessAjaxRequest()
        {
            if (Request.ContentType.Contains("json") && Request.QueryString["Save"] != null)
                SaveMyData();
            if (Request.ContentType.Contains("json") && Request.QueryString["luuChiTiet"] != null)
                luuChiTietCSL();
            if (Request.ContentType.Contains("json") && Request.QueryString["showDSDV"] != null)
                showDSDV();
            if (Request.ContentType.Contains("json") && Request.QueryString["loadKQTruoc"] != null)
                loadKQTruoc();
            if (Request.ContentType.Contains("json") && Request.QueryString["luuTraDV"] != null)
                SaveTraDV();
            if (Request.ContentType.Contains("json") && Request.QueryString["ExportAutomatic"] != null)
                ExportAuto();
        }

        private void ExportAuto()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string line = "";
            line = sr.ReadToEnd();
            JObject jo = JObject.Parse(line);
            string madkcls = Server.UrlDecode((string)jo["madkcls"]).TrimEnd(',');
            string sql = "";
            string maphieuCLS = "";
            DataTable dt = new DataTable();
            if (madkcls != null && madkcls != "")
            {
                sql = @"select maphieuCLS from khambenhcanlamsan where madangkycls='"+madkcls+"'";
            }
            if (sql!="")
            {
                dt = DataAcess.Connect.GetTable(sql);
                if (dt!=null&&dt.Rows.Count>0)
	            {
		             maphieuCLS=dt.Rows[0]["maphieuCLS"].ToString();
	            }
                if (maphieuCLS!="")
                {
                    //bool ok=DataAcess.Connect.ExecSQL("Exec THUOC_XUAT_HOACHAT_XETNGHIEM '"+maphieuCLS+"'"); 
                }
            }
        }

        private void SaveTraDV()
        {
            string test = "1234";
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string line = "";
            line = sr.ReadToEnd();
            JObject jo = JObject.Parse(line);
            string idDV = Server.UrlDecode((string)jo["idDV"]).TrimEnd(',');
            string madangky = Server.UrlDecode((string)jo["madangky"]).TrimEnd(',');
            string[] a = null;
            string sql = "";
            if (idDV!="")
            {
                a = idDV.Split(',');
            }
            string scanlamsan="";
            if (a.Length>0&&madangky!="")
            {
                foreach (string item in a)
                {
                    sql += @" update khambenhcanlamsan set isTra='true',isDatraTien='false'  where idcanlamsan=" + item + " and madangkyCLS='" + madangky + "';";
                    scanlamsan+=item+",";
                }
            }
            if (sql!="")
            {
                DataAcess.Connect.ExecSQL(sql);
            }
            DataTable dtt = DataAcess.Connect.GetTable(@"select idcanlamsan from khambenhcanlamsan where idcanlamsan in(" + scanlamsan.TrimEnd(',') + ") and isTra=1 and madangkyCLS='"+madangky+"'");

            if (dtt.Rows.Count >0)
            {
                test = "Ok";
                Response.Write(test);
            }
            else
            {
                test = "";
                Response.Write(test);
            }
        }
        private void luuChiTietCSL()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string line = "";
            line = sr.ReadToEnd();
            JObject jo = JObject.Parse(line);
            string idDV = Server.UrlDecode((string)jo["idDV"]).TrimEnd(',');
            string listKQ = ((string)jo["listKQ"]).TrimEnd(',') ;
            string listGiaTriBT = ((string)jo["listGiaTriBT"]).TrimEnd(',');
            string listIsBatThuong = ((string)jo["listisBatThuong"]).TrimEnd(',');
            string listIdChiTietDV = ((string)jo["listIdChiTietDV"]).TrimEnd(',');
            string idKQCLS = ((string)jo["idKQCLS"]);
            string idBS = ((string)jo["idBS"]);
            string madkCLS = ((string)jo["maCLS"]);
            string []arrIDDV = idDV.Split(',');
            string[] arrIdChiTietDV = listIdChiTietDV.Split(',');
            string[] arrKQ = listKQ.Split(',');
            string[] arrGiaTriBT = listGiaTriBT.Split(',');
            string[] arrIsBatThuong = listIsBatThuong.Split(',');
            string date =System.DateTime.Now.ToString();
            List<string> list = new List<string>();
            DataTable dt = Process_cls.ketqua_canlamsangchitiet.dtSearchByidketqua_canlamsang(idKQCLS);
            if (dt.Rows.Count > 0)
            {
                string del = "delete from ketqua_canlamsangchitiet where idketqua_canlamsang=" + idKQCLS;
                DataAcess.Connect.Exec(del);
            }
            for (int i = 0; i < arrIDDV.Length; i++)
            {
                Process_cls.ketqua_canlamsangchitiet kqct = Process_cls.ketqua_canlamsangchitiet.Insert_Object(idKQCLS.ToString(), arrIDDV[i].ToString(), arrIdChiTietDV[i].ToString(), arrKQ[i].ToString(), arrIsBatThuong[i].ToString(), date, idBS.ToString(), "", arrGiaTriBT[i].ToString());
                list.Add(kqct.idketqua_canlamsangchitiet.ToString());
            }
            string[] check =list.ToArray();
            if (check.Length == arrIDDV.Length)
            {
                string update = "update khambenhcanlamsan set dakham=1 where madangkycls='"+madkCLS+"' and idcanlamsan in ("+idDV+")";
                DataAcess.Connect.ExecSQL(update);
                    Response.Write(idKQCLS);
                    return;
            }
            //truong hop that bai - rollback
            else
            {
                string del = "delete from select * from ketqua_canlamsangchitiet where idketqua_canlamsang="+idKQCLS;
                DataAcess.Connect.Exec(del);
                Response.Write("");
            }
        }
        private void SaveMyData()
        {  
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string line = "";
            line = sr.ReadToEnd();
            JObject jo = JObject.Parse(line);
            string maCLS = Server.UrlDecode((string)jo["madangkyCLS"]);
            string idbn =(string)jo["idBenhNhan"];
            Process_cls.ketqua_canlamsang id = Process_cls.ketqua_canlamsang.Insert_Object(maCLS, idbn, "");
            if (id.idketqua_canlamsang.ToString() != "")
            {
                Response.Write(id.idketqua_canlamsang.ToString());
            }
            else
            {
                Response.Write("");
            }
        }
        private void showDSDV()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string line = "";
            line = sr.ReadToEnd();
            JObject jo = JObject.Parse(line);
            string madangkycls = Server.UrlDecode((string)jo["madangkyCLS"]);

            string idcls = madangkycls;
            string sqlDV = string.Format(@"SELECT mamaycls,tendichvu +ISNULL(' - '+tenmaycls,'') tendichvu
                                            FROM DMMayCanLamSang
                                            WHERE mamaycls IN (SELECT b.mamaycls
                                            FROM khambenhcanlamsan k
                                            INNER JOIN banggiadichvu b ON k.idcanlamsan=b.idbanggiadichvu
                                            where k.madangkycls='{0}')", idcls);
            DataTable dt = DataAcess.Connect.GetTable(sqlDV);
            DateTime date = DateTime.Now;
            string ngaymacdinh = date.ToString("dd/MM/yyyy");
            string maketquacls = Request.QueryString["listmacls"];
            if (maketquacls == null) maketquacls = "";
            maketquacls = maketquacls.TrimEnd('@');
            string[] listMacls = maketquacls.Split('@');
            if (listMacls == null || listMacls.Length < dt.Rows.Count)
                listMacls = new string[dt.Rows.Count];

            string madangkycsl = madangkycls;
            if (dt != null && dt.Rows.Count > 0)
            {
                string html = "";
                html = " <span id=\"headerntt\">Thông tin máy cận lâm sàn</span>";
                html += "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" width=\"600px\">";
                html += "<tr style =\"background-color: #4D67A2\">";
                html += "<td width=\"150px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Mã KQ CLS</td>";
                html += "<td width=\"300px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Tên dịch vụ - máy cận lâm sàn</td>";
                html += "<td width=\"100px\" class=\"item\" style=\"color:white;font-weight:bold;\" >Ngày thực hiện</td>";
                html += "</tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tendichvu = dt.Rows[i]["tendichvu"].ToString();
                    string mamaycls = dt.Rows[i]["mamaycls"].ToString();
                    string macls = "";
                    string ngaythuchien = "";
                    string temma = listMacls[i];
                    if (temma != null)
                    {
                        string[] temp = temma.Split('$');
                        if (temp.Length > 2)
                        {
                            macls = temp[0];
                            ngaythuchien = temp[2];
                        }
                    }

                    html += "<tr onmouseover=\"this.bgColor='#FFFFFF'\" onmouseout=\"this.bgColor=''\" style=\"cursor:pointer;\" >";
                    html += "<td width=\"150px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtMaCLSan_" + (i + 1).ToString() + "\" value = \"" + (macls != "" ? macls : madangkycsl) + "\" style =\"width:150px; text-align:left;\"" + (i == 0 ? "/ onblur=\"setValue();\"" : "") + "></td>";
                    html += "<td width=\"300px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtTenDV_" + (i + 1).ToString() + "\" value = \"" + tendichvu + "\" style =\"width:300px; text-align:left;\" ><input type=\"hidden\" id=\"txtmamaycls_" + (i + 1).ToString() + "\" value = \"" + mamaycls + "\" style =\"width:100px; text-align:left;\" /></td>";
                    html += "<td width=\"100px\" class=\"ptext\" align = \"left\" style = \"padding-right:2px\"><input class=\"input\" type=\"text\" id=\"txtNgayThucHien_" + (i + 1).ToString() + "\" value = \"" + (ngaythuchien == "" ? ngaymacdinh : ngaythuchien) + "\" style =\"width:100px; text-align:left;\" /></td>";
                    html += "</tr>";
                }
                html += "</table>";
                html += "<input type=\"hidden\" id=\"txtSodong1\" value = \"" + dt.Rows.Count.ToString() + "\" style =\"width:100px; text-align:left;\" >";
                Response.Write(html);
            }
            else
            {
                Response.Write("");
            }
        }
        private void loadKQTruoc()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            string line = "";
            line = sr.ReadToEnd();
            JObject jo = JObject.Parse(line);
            string idbenhnhan = Server.UrlDecode((string)jo["idBenhNhan"]);
            string macls = Server.UrlDecode((string)jo["macls"]);
            if (idbenhnhan == "")
            {
                Response.Write("Bệnh nhân này chưa làm dịch vụ này trước đây ");
            }
            else
            {
                string iddichvu = Server.UrlDecode((string)jo["iddichvu"]);
                string sqlKQ = @"select ct.idchitietdichvu,tenchitiet,ketqua,BatThuong=isbatthuong,ngaycls
                            from ketqua_canlamsangchitiet ct
                            inner join ketqua_canlamsang kq on kq.idketqua_canlamsang=ct.idketqua_canlamsang
                            inner join chitietdichvu dv on dv.idchitietdichvu=ct.idchitietdichvu
                            where idbenhnhan=" + idbenhnhan + @" and ct.idchitietdichvu=" + iddichvu+" and  kq.madangkycls<>'"+macls+"'";
                DataTable dtKQ = DataAcess.Connect.GetTable(sqlKQ);
                string html = "";
                html += "<table class=\"ttable\">";
                html += "<tr>";
                html += "<th >Kết quả</th>";
                html += "<th>Bất thường</th>";
                html += "<th style=\"width:70px\">Ngày khám</th>";
                html += "</tr>";
                if(dtKQ!=null && dtKQ.Rows.Count>0)
                {
                    for (int i = 0; i < dtKQ.Rows.Count; i++)
                    {
                        string check = dtKQ.Rows[i]["BatThuong"].ToString();
                        string ckb = "";
                        string font = "";
                        if (check == "True")
                        {
                            font = "style=\"color:red;font-weight:bold\"";
                            ckb = "checked";
                        }
                        html += "<tr>";
                        html += "<td "+font+">" + dtKQ.Rows[i]["ketqua"].ToString() + "</td>";
                        html += "<td><input type=\"checkbox\" " + ckb + " style=\"width:20px\" /></td>";
                        html += "<td>" +string.Format("{0:dd/MM/yyyy}", dtKQ.Rows[i]["ngaycls"]) + "</td>";
                        html += "</tr>";
                    }

                    html += "<tr><td colspan=\"4\" style=\"hover:none\" ><a onclick=\"hidePop();\">Đóng</a></td></tr>";
                }
                else
                {
                    html += "<tr><td colspan=\"4\">Bệnh nhân này chưa làm dịch vụ này trước đây</td></tr>";
                    html += "<tr><td colspan=\"4\" style=\"hover:none\" ><a onclick=\"hidePop();\">Đóng</a></td></tr>";
                }
                Response.Write(html);
            }
        }

    }
   

}
