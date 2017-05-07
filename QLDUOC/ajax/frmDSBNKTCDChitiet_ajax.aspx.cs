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

public partial class frmDSBNKTCDChitiet_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "loaddskhoa": loaddskhoa(); break;
            case "loaddsphong": loaddsphong(); break;
            case "TimKiem": TimKiem(); break;
            case "DuyetLan1": DuyetLan1(); break;
            case "func_ThieuCD": func_ThieuCD(); break;
            case "LuuGhiChuCD": LuuGhiChuCD(); break;
            case "SetDefault": SetDefault(); break;
            case "SaveKTCD": SaveKTCD(); break;
        }
    }
    private void loaddskhoa()
    {
        string SQL = string.Format(@"SELECT * FROM PHONGKHAMBENH");
        DataTable table = DataAcess.Connect.GetTable(SQL);
        table.DefaultView.RowFilter = "loaiphong=0";
        table = table.DefaultView.ToTable();
        StringBuilder html = new StringBuilder();
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.AppendLine(table.Rows[i][2].ToString() + "|" + table.Rows[i][0].ToString());
            }
        }
        Response.Clear();
        Response.Write(html.ToString());
    }
    private void loaddsphong()
    {
        bool IsAdmin = SysParameter.UserLogin.IsAdmin(this);
        string IdKhoa = Request.QueryString["IdKhoa"];
        DataTable table = null;
        if (IdKhoa != null && IdKhoa != "")
        {
            string sql = @"SELECT *,TenPhongFull=DBO.HS_TenPhong(ID)
	                     FROM KB_PHONG A1
	                    LEFT JOIN BANGGIADICHVU B1 ON A1.DICHVUKCB=B1.IDBANGGIADICHVU
	                    WHERE 1=1
	                    AND status=1
                       " + (IsAdmin ? "" : " and a1.id in ( select phongid from kb_dieuduong_phong where  iddieuduong=" + SysParameter.UserLogin.UserID(this) + ")") + @" 
	                    AND B1.IDPHONGKHAMBENH=" + IdKhoa
                 + @"  ORDER BY ISNULL(SOTT,0),ISNULL(MASO,'') ,TENPHONG ";
            table = DataAcess.Connect.GetTable(sql);
        }
        StringBuilder html = new StringBuilder();
        if (table != null && table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                html.AppendLine(table.Rows[i]["TenphongFull"].ToString() + "|" + table.Rows[i]["Id"].ToString());
            }
        }
        Response.Clear();
        Response.Write(html.ToString());
    }
    private void TimKiem()
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        if (idkhambenh == null || idkhambenh == "") idkhambenh = "0";
        StringBuilder html = new StringBuilder();
        html.Append("<<table class='jtable' id=\"gridTable\">");
                bool xetduyet1 = Userlogin_new.HavePermision(this, "XetDuyet1");
                bool xetduyet2 = Userlogin_new.HavePermision(this, "XetDuyet2");
                html.Append("<tr>");
                html.Append("<th>STT</th>");
                html.Append("<th>Tên thuốc</th>");
                html.Append("<th>SL</th>");
                html.Append("<th>Xuất</th>");
                html.Append("<th>Chênh lệch</th>");
                html.Append("<th>ĐVT</th>");
                html.Append("<th>Kho</th>");
                html.Append("<th>Ghi chú</th>");
                html.Append("<th><input type='checkbox' id='chkAllTrue' onclick='checkAllTrue(this," +idkhambenh + ");' />? Đúng</th>");
                html.Append("<th>? Sai</th>");
                
                html.Append("<th></th>");
                
                html.Append("</tr>");
                string SQL_CHITIET =  @"SELECT STT=ROW_NUMBER() OVER(ORDER BY A.IDCHITIETBENHNHANTOATHUOC),A.IDTHUOC
		                                        ,B.TENTHUOC,A.SOLUONGKE,E.TENDVT,K.TENKHO,A.NGAYRATOA,A.ISDUYET,A.IDKHO
                                                ,A.ISDAXUAT,A.IDCHITIETBENHNHANTOATHUOC,G.tennguoidung AS NGUOIDUYET,ISDUYET2,GHICHUDUYET
                                            ,H.tennguoidung AS NGUOIXUAT
                                            ,SLXuat=(SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDCHITIETBENHNHANTOATHUOC=A.IDCHITIETBENHNHANTOATHUOC)
                                            ,Chenhlech=N''    
                                        FROM CHITIETBENHNHANTOATHUOC A
	                                        LEFT JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
	                                        LEFT JOIN THUOC_LOAITHUOC C ON ISNULL(B.LOAITHUOCID,1)=C.LOAITHUOCID
	                                        LEFT JOIN THUOC_CACHDUNG D ON A.IDCACHDUNG=D.IDCACHDUNG
	                                        LEFT JOIN THUOC_DONVITINH E ON A.IDDVT=E.ID
	                                        LEFT JOIN CATEGORY F ON B.CATEID=F.CATEID
	                                        LEFT JOIN KHOTHUOC K ON K.IDKHO=A.IDKHO 
                                          LEFT JOIN NGUOIDUNG G ON A.IDNGUOIDUYET=G.IDNGUOIDUNG
                                          LEFT JOIN NGUOIDUNG H ON A.IDNGUOIXUAT=H.IDNGUOIDUNG
                                        WHERE A.IDKHAMBENH="+idkhambenh ;
                DataTable dt = DataAcess.Connect.GetTable(SQL_CHITIET);
                bool Have_xetduyet2 = Userlogin_new.HavePermision(this, "xetduyet2");
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string slXuat = dt.Rows[j]["SLXUAT"].ToString();
                        string SOLUONGKE = dt.Rows[j]["SOLUONGKE"].ToString();
                        if (slXuat == "") slXuat = "0";
                        if (SOLUONGKE == "") SOLUONGKE = "0";
                        double lech = double.Parse(SOLUONGKE) - double.Parse(slXuat);
                        if (lech != 0)
                            dt.Rows[j]["Chenhlech"] = lech.ToString(); 


                        html.Append("<tr>");
                        html.Append("<td style='width:3%;'>" + dt.Rows[j]["STT"] + "<input type='hidden' mkv='true' id='idchitietbenhnhantoathuoc' value='" + dt.Rows[j]["IDCHITIETBENHNHANTOATHUOC"] + "' /></td>");
                        html.Append("<td style='text-align:left;width:22%;''>" + dt.Rows[j]["TENTHUOC"] + "</td>");
                        html.Append("<td style='width:6%;'>" + dt.Rows[j]["SOLUONGKE"] + "</td>");
                        html.Append("<td style='width:6%;'>" + dt.Rows[j]["SLXUAT"] + "</td>");
                        html.Append("<td style='width:6%;'>" + dt.Rows[j]["Chenhlech"] + "</td>");
                        html.Append("<td style='width:7%;'>" + dt.Rows[j]["TENDVT"] + "</td>");
                        html.Append("<td style='width:17%;'>" + dt.Rows[j]["TENKHO"] + "</td>");
                        html.Append("<td><input type='text' id='ghichuDuyet' mkv='true' value='" + dt.Rows[j]["GHICHUDUYET"] + "' style='width:90%;' /></td>");
                        html.Append("<td style='width:7%;'><input type='checkbox' mkv='true' id='IsTrue' " + (StaticData.IsCheck(dt.Rows[j]["IsDuyet2"]) ? "checked " : "") + " onclick=\"CheckValid(this);\""+" /></td>");
                        html.Append("<td style='width:7%;'><input type='checkbox' mkv='true' id='IsFalse' " + (dt.Rows[j]["IsDuyet2"].ToString() == "0" || dt.Rows[j]["IsDuyet2"].ToString().ToLower() == "false" ? "checked " : "") + " onclick=\"CheckValid(this);\"" + " /></td>");
                        
                        html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[j]["IDCHITIETBENHNHANTOATHUOC"] + "'/></td>");
                        html.Append("</tr>");
                    }
                }
//                html.Append(@"</table>
//                            </td>");
                html.Append("<tr><td colspan='11'></td></tr>");
        html.Append("</table>");
        Response.Clear();
        Response.Write(html.ToString());
    }
    private void DuyetLan1()
    {
        try
        {
            string idctbntt = Request.QueryString["idchitietbenhnhantoathuoc"];
            string ghichuDuyet = Request.QueryString["ghichuDuyet"];
            bool IsTrue = StaticData.IsCheck(Request.QueryString["IsTrue"].ToString());
            bool IsFalse = StaticData.IsCheck(Request.QueryString["IsFalse"].ToString());
            //anh xử lý ở đây nha anh Sơn
            if (IsTrue || IsFalse)
            {
                string sql = @"UPDATE CHITIETBENHNHANTOATHUOC SET ISDUYET2=" + (IsTrue ? "1" : "0") + @",IDNGUOIDUYET2=" + SysParameter.UserLogin.UserID(this) + ",GHICHUDUYET=N'" + ghichuDuyet + @"' 
                    WHERE IDCHITIETBENHNHANTOATHUOC='" + idctbntt + "'";
                bool kt = DataAcess.Connect.ExecSQL(sql);
            }
        }
        catch (Exception)
        {
            Response.StatusCode = 500;
        }
    }
    private void DuyetLan1BK()
    {
        string lst = Request.QueryString["list"].TrimEnd('@');
        string[] arrId = lst.Split('@');
        System.Collections.Generic.List<string> _lstId = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> _lstIsTrue = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> _lstIsFalse = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> _lstGhiChu = new System.Collections.Generic.List<string>();
        for (int i = 0; i < arrId.Length; i++)
        {

            string[] arr = arrId[i].ToString().Split('^');
            _lstId.Add(arr[0]);
            _lstIsTrue.Add(arr[1]);
            _lstIsFalse.Add(arr[2]);
            _lstGhiChu.Add(arr[3]);
        }
        string userid = SysParameter.UserLogin.UserID(this);
        int r = 0;
        for (int i = 0; i < _lstId.Count; i++)
        {

            bool istrue = StaticData.IsCheck(_lstIsTrue[i]);
            bool isfalse = StaticData.IsCheck(_lstIsFalse[i]);
            string isduyet = (istrue ? " 1" : (isfalse ? "0" : "NULL"));
            string idnguoiduyet = "0";
            if (istrue || isfalse)
            {
                idnguoiduyet = userid;
            }
            string SQL_UPDATE = string.Format(@"UPDATE CHITIETBENHNHANTOATHUOC SET ISDUYET2=" + isduyet + @",IDNGUOIDUYET2={0},GHICHUDUYET=N'{1}' 
                    WHERE IDCHITIETBENHNHANTOATHUOC={2} ",
            idnguoiduyet, _lstGhiChu[i].ToString(), _lstId[i].ToString() );
            bool ok = DataAcess.Connect.ExecSQL(SQL_UPDATE);
            if (ok)
            {
                r++;
            }
            else
            {

            }

        }
        if (r > 0)
        {
            Response.Write("1" + "|" + "thực hiện thành công.");
            return;
        }

    }


    private void func_ThieuCD()
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        string IsThieuCD = Request.QueryString["IsThieuCD"];
        if (StaticData.IsCheck(IsThieuCD)) IsThieuCD = "1";
        else IsThieuCD = "0";
        string SQL = @"UPDATE KHAMBENH SET IsThieuCD=" + IsThieuCD + @" WHERE idkhambenh=" + idkhambenh;
        bool ok = DataAcess.Connect.ExecSQL(SQL);
        if (ok) Response.Write("1" + "|" + "thực hiện thành công.");
        else
        {
            Response.Write("0" + "|" + "thực hiện không thành công.");
            Response.StatusCode = 500;
        }
         
    }
    private void LuuGhiChuCD()
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        string GhiChuCD = Request.QueryString["GhiChuCD"];
        string SQL = @"UPDATE KHAMBENH SET GhiChuCD=N'" + GhiChuCD + @"' WHERE idkhambenh=" + idkhambenh;
        bool ok = DataAcess.Connect.ExecSQL(SQL);
        if (ok) Response.Write("1" + "|" + "thực hiện thành công.");
        else
        {
            Response.Write("0" + "|" + "thực hiện không thành công.");
            Response.StatusCode = 500;
        }

    }
    ////--------------------------------------------------------
    private void SetDefault()
    {
        string idkhambenh = Request.QueryString["idkhambenh"];
        if (idkhambenh == null || idkhambenh == "") idkhambenh = "0";
        string SQL = string.Format(@"SELECT DISTINCT TENBENHNHAN AS HOTENBN,
                                       E.NGAYSINH,
                                       GIOITINH=DBO.GETGIOITINH(E.GIOITINH),
                                       TENBACSI,
                                       PHONG=DBO.HS_TENPHONG(B.PHONGID),
                                       B.NGAYKHAM,
                                       B.IDKHAMBENH 
                                       ,B.IsCheckAllCD 
                                       ,B.GHICHUCD
                                        ,TENDICHVU=DBO.HS_GET_DICHVU(C.IDBENHBHDONGTIEN)
                                    FROM   KHAMBENH B 
                                    INNER JOIN DANGKYKHAM C ON B.IDDANGKYKHAM=C.IDDANGKYKHAM
                                    INNER JOIN BACSI D ON B.IDBACSI=D.IDBACSI
                                    INNER JOIN BENHNHAN E ON B.IDBENHNHAN=E.IDBENHNHAN
                                    WHERE 1=1 AND B.IDKHAMBENH=" + idkhambenh);

        bool perLuu = Userlogin_new.HavePermision(this, "xetduyet2");

        DataTable dt2 = DataAcess.Connect.GetTable(SQL); 
        string html = "";
            html += "<root>";

            if (dt2 != null && dt2.Rows.Count > 0)
            {
                html += "<data  id=\"ngaykham\">" + string.Format("{0:dd/MM hh:mm}", dt2.Rows[0]["NGAYKHAM"]) + "</data>";
                html += "<data  id=\"PHONG\">" + dt2.Rows[0]["PHONG"].ToString() + "</data>";
                html += "<data  id=\"tenbn\">" + dt2.Rows[0]["HOTENBN"].ToString() + "</data>";
                html += "<data  id=\"ngaysinh\">" + dt2.Rows[0]["ngaysinh"].ToString() + "</data>";
                html += "<data  id=\"gioitinh\">" + dt2.Rows[0]["GIOITINH"].ToString() + "</data>";
                html += "<data  id=\"TENDICHVU\">" + dt2.Rows[0]["TENDICHVU"].ToString() + "</data>";
                html += "<data  id=\"GHICHUCD\">" + dt2.Rows[0]["GHICHUCD"].ToString() + "</data>";
                html += "<data  id=\"IsCheckAllCD\">" + dt2.Rows[0]["IsCheckAllCD"].ToString() + "</data>";
            }
        if(perLuu)
            html += "<data  id=\"perLuu\">" + "1" + "</data>";
        else
            html += "<data  id=\"perLuu\">" + "0" + "</data>";

            html += "</root>";
            Response.Clear();
            Response.Write(html);
    }//End void
    ////--------------------------------------------------------

    void SaveKTCD()
    {
        string idkhambenh = Request.QueryString["idkhoachinh"];
        string GhiChuCD = Request.QueryString["GhiChuCD"];
        string IsCheckAllCD = Request.QueryString["IsCheckAllCD"];
        if (idkhambenh == null || idkhambenh == "") return;
        bool ok = DataAcess.Connect.ExecSQL("UPDATE KHAMBENH SET GhiChuCD=N'" + GhiChuCD + "' , IsCheckAllCD='" + IsCheckAllCD + "' WHERE IDKHAMBENH=" + idkhambenh);
        Response.Clear();
        if (ok)
        {
            Response.Write("1");
            return;
        }
        Response.Write("Lưu ghi chú và tình trạng kiểm tra thất bại");
    }

}//END CLASS
