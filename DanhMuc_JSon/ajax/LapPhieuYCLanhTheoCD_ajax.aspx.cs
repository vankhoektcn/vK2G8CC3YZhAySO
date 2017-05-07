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

public partial class LapPhieuYCLanhTheoCD_ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "TimKiem": TimKiem(); break;
            case "UpdateChitietChiDinh": UpdateChitietChiDinh(); break;
            case "SetDefault": SetDefault(); break;
            case "SavePhieuYCXuat": SavePhieuYCXuat(); break;
            case "XoaPhieuYCXuat": XoaPhieuYCXuat(); break;
            case "KiemTraTonYC": KiemTraTonYC(); break;
        }
    }

    private void TimKiem()
    {
        string IdPhieuYc = Request.QueryString["IdPhieuYc"];
        string idkho = Request.QueryString["IdKhoYc"];
        string TuNgay = Request.QueryString["TuNgay"];
        string DenNgay = Request.QueryString["DenNgay"];
        string TuGio = Request.QueryString["TuGio"];
        string DenGio = Request.QueryString["DenGio"];
        string TuPhut = Request.QueryString["TuPhut"];
        string DenPhut = Request.QueryString["DenPhut"];
        string IsDuTru = Request.QueryString["IsDuTru"];
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string NgayDuyet = Request.QueryString["NgayDuyet"];
        string GioDuyet = Request.QueryString["GioDuyet"];
        string PhutDuyet = Request.QueryString["PhutDuyet"];
        string IdKhoDuyet = Request.QueryString["IdKhoDuyet"];
        string LoaiThuocID_Clause = "";
        if (LoaiThuocID != null && LoaiThuocID != "")
        {
            if (LoaiThuocID == "5") LoaiThuocID_Clause = " AND B.LoaiThuocID=1 AND B.IsTGN=1";
            else if (LoaiThuocID == "6") LoaiThuocID_Clause = " AND B.LoaiThuocID=1 AND B.IsTHTT=1";
            else if (LoaiThuocID == "1") LoaiThuocID_Clause = " AND B.LoaiThuocID=1 AND ISNULL( B.IsTHTT,0)=0 AND ISNULL(B.IsTGN,0)=0";
            else LoaiThuocID_Clause = " AND B.LoaiThuocID=" + LoaiThuocID;

        }
        bool IsDuyetIn = false;
        if (IdPhieuYc == null || IdPhieuYc == "")
        {
            if (TuNgay == null || TuNgay == "") return;
            if (DenNgay == null || DenNgay == "") return;
            if (idkho == null || idkho == "") return;
            if (LoaiThuocID == null || LoaiThuocID == "") return;

            if (TuGio == null || TuGio == "") TuGio = "00";
            if (TuPhut == null || TuPhut == "") TuPhut = "00";
            if (DenGio == null || DenGio == "") DenGio = "23";
            if (DenPhut == null || DenPhut == "") DenPhut = "59";
            if (GioDuyet == null || GioDuyet == "") GioDuyet = "23";
            if (PhutDuyet == null || PhutDuyet == "") PhutDuyet = "59";
            TuNgay = StaticData.CheckDate(TuNgay) + " " + TuGio + ":" + TuPhut + ":00";
            DenNgay = StaticData.CheckDate(DenNgay) + " " + DenGio + ":" + DenPhut + ":59";
        }
        else
        {
            string sqlSelectPrev = "SELECT * FROM YC_PHIEUYCXUAT WHERE IdPhieuYc=" + IdPhieuYc;
            DataTable dtPrev = DataAcess.Connect.GetTable(sqlSelectPrev);
            IdKhoDuyet = dtPrev.Rows[0]["IdKhoDuyet"].ToString();
            IsDuTru = dtPrev.Rows[0]["IsDuTru"].ToString();
            IsDuyetIn = StaticData.IsCheck(dtPrev.Rows[0]["IsDuyetIn"].ToString());
            NgayDuyet = dtPrev.Rows[0]["NgayDuyet"].ToString();
            DateTime dNgayDuyet = DateTime.Parse(dtPrev.Rows[0]["NgayDuyet"].ToString());
            NgayDuyet = dNgayDuyet.ToString("dd/MM/yyyy");
            GioDuyet = dNgayDuyet.ToString("HH");
            PhutDuyet = dNgayDuyet.ToString("mm");

        }

        string NgayKham_Name = "C.NgayKham";
        string NgayDuTru_Null = " and isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='' ";
        if (StaticData.IsCheck(IsDuTru))
        {
            NgayKham_Name = "C.ngayDuTruThuoc";
            NgayDuTru_Null = "";
        }

        StringBuilder html = new StringBuilder();
        html.Append("<<table class='jtable' id=\"gridTable\">");
        html.Append("<tr>");
        html.Append("<th  style='width:1%;' >STT</th>");
        html.Append("<th  style='width:6.25%;'>NGÀY ĐK</th>");
        //html.Append("<th  style='width:6.25%;'>MÃ BN</th>");
        html.Append("<th  style='width:18.75%;'>TÊN BN</th>");
        html.Append("<th  style='width:6.25%;'>NGÀY SINH</th>");
        html.Append("<th  style='width:6.25%;'>KCB</th>");
        html.Append("<th  style='width:6.25%;'>NGÀY CĐ</th>");
        html.Append("<th  style='width:18.75%;'>ĐỐI TƯỢNG</th>");
        html.Append("<th  style='width:5%;'>SL\r\nKÊ</th>");
        html.Append("<th  style='width:5%;'><input type='checkbox' id='chkAllTrue' onclick='checkAllTrue(this);' />? CHỌN</th>");
        html.Append("<th  style='width:5%;'>CỘNG</th>");
        html.Append("<th  style='width:5%;'></th>");
        html.Append("<th  style='width:5%;'>SL TỒN</th>");
        html.Append("<th  style='width:5%;'>SL \r\nDỰ TRÙ</th>");
        html.Append("<th  style='width:5%;'>SL \r\nCHO PHÉP</th>");
        html.Append("<th  style='width:0%;'></th>");

        html.Append("</tr>");
        string SQL_CHITIET = @"SELECT  
                                                STT='',
                                                NGAYDANGKY=CONVERT(NVARCHAR(20),NGAYDANGKY,103),
		                                        E.MABENHNHAN,
		                                        E.TENBENHNHAN,
		                                        E.NGAYSINH,
		                                        LOAIKCB=G.TENLOAI,
	                                           NGAYCD= " + NgayKham_Name + @",
	                                           TENTHUOC,
	                                           SOLUONGKE,
	                                           CHOICE=CONVERT(BIT,1),
                                               TONGSLKE=0.0,
	                                           A.IDCHITIETBENHNHANTOATHUOC	,   
                                               A.IDTHUOC,	
                                               c.IDBENHNHAN,
                                               SLTON=0.0,SLDUTRU=0.0,SLCHOPHEP=0.0

                                        FROM CHITIETBENHNHANTOATHUOC A
                                        INNER JOIN THUOC B ON A.IDTHUOC=B.IDTHUOC
                                        INNER JOIN KHAMBENH C ON A.IDKHAMBENH=C.IDKHAMBENH
                                        INNER JOIN DANGKYKHAM D ON C.IDDANGKYKHAM=D.IDDANGKYKHAM
                                        INNER JOIN BENHNHAN E ON D.IDBENHNHAN=E.IDBENHNHAN
                                        INNER JOIN THUOC_DONVITINH F ON B.IDDVT=F.ID
                                        LEFT JOIN KB_LOAIKHAM G ON D.LOAIKHAMID=G.LOAIKHAMID
                                        WHERE " + (IdPhieuYc != null && IdPhieuYc != "" ? " A.IdPhieuYc_XUAT=" + IdPhieuYc : @"
                                                        A.IDKHO=" + idkho + @"
                                                         AND " + NgayKham_Name + ">='" + TuNgay + @"'
                                                         AND " + NgayKham_Name + @"<='" + DenNgay + @"'
	                                                     "+NgayDuTru_Null+@"
	                                                     AND ISNULL(IsDaXuatTheoYC,0)=0"
                                                      + "" + "\r\n"
                                                 + LoaiThuocID_Clause
                                         )
                                                 + @"
                                        ORDER BY  isnull(nvk_UuTienYL,100),TENDVT,tenthuoc 
                                        ";
        DataTable dt = DataAcess.Connect.GetTable(SQL_CHITIET);
        System.Collections.Generic.List<string> lstThuoc = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> lstBenhNhan = new System.Collections.Generic.List<string>();

        if (dt != null)
        {
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string tenthuoc = dt.Rows[j]["TENTHUOC"].ToString();
                string TONGSLKE = "0";
                int n = StaticData.int_Search(dt, "IDTHUOC=" + dt.Rows[j]["IDTHUOC"].ToString());

                if (n != -1)
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "IDTHUOC=" + dt.Rows[j]["IDTHUOC"].ToString();
                    DataTable dt2 = dv.ToTable();
                    TONGSLKE = dt2.Compute("sum(SOLUONGKE)", "").ToString();

                }
                if (n != j)
                {
                    tenthuoc = "-";
                    TONGSLKE = "";
                    dt.Rows[j]["SLTON"] = DBNull.Value;
                    dt.Rows[j]["SLDUTRU"] = DBNull.Value;
                    dt.Rows[j]["SLCHOPHEP"] = DBNull.Value;

                }
                else
                {

                    double dTongSLKe = double.Parse(TONGSLKE);
                    double dSLTON = 0;
                    double dSLDUTRU = 0;

                    if (IsDuyetIn == false && (IdPhieuYc == null || IdPhieuYc == "" || (IdPhieuYc != null && IdPhieuYc != "" && StaticData.GetParaValueDB("ChoPhepCapNhatSLTONDuyetIn") == "1")))
                    {
                        string sqlSelectTonKho = "SELECT SLTON=DBO.Thuoc_TonKho_new_1910(" + dt.Rows[j]["IDTHUOC"].ToString() + ",'" + StaticData.CheckDate(NgayDuyet) + " " + GioDuyet + ":" + PhutDuyet + ":59'" + "," + IdKhoDuyet + @") 
									                 ,SLDUTRU=  DBO.HS_SLYEUCAUCHUADUYET(" + dt.Rows[j]["IDTHUOC"].ToString() + "," + IdKhoDuyet + @",NULL)";
                        DataTable dtTonKho = DataAcess.Connect.GetTable(sqlSelectTonKho);
                        if (dtTonKho != null && dtTonKho.Rows.Count > 0)
                        {

                            dt.Rows[j]["SLTON"] = dtTonKho.Rows[0]["SLTON"].ToString();
                            dt.Rows[j]["SLDUTRU"] = dtTonKho.Rows[0]["SLDUTRU"].ToString();
                            dSLTON = (dtTonKho.Rows[0]["SLTON"].ToString() != "" ? double.Parse(dtTonKho.Rows[0]["SLTON"].ToString()) : 0);
                            dSLDUTRU = (dtTonKho.Rows[0]["SLDUTRU"].ToString() != "" ? double.Parse(dtTonKho.Rows[0]["SLDUTRU"].ToString()) : 0);

                            if (dSLDUTRU > 0 && IdPhieuYc != null && IdPhieuYc != "")
                                dSLDUTRU = dSLDUTRU - dTongSLKe;


                        }
                    }
                    else
                    {

                        string sqlSelectTonKho2 = @"SELECT SLTON,SLDUTRU 
                                                                FROM YC_PHIEUYCXUATCHITIET A 
                                                            WHERE A.IDPHIEUYC=" + IdPhieuYc + " AND IDTHUOC=" + dt.Rows[j]["IDTHUOC"].ToString();
                        DataTable dtTonKho2 = DataAcess.Connect.GetTable(sqlSelectTonKho2);
                        if (dtTonKho2 != null && dtTonKho2.Rows.Count > 0)
                        {
                            dt.Rows[j]["SLTON"] = dtTonKho2.Rows[0]["SLTON"].ToString();
                            dt.Rows[j]["SLDUTRU"] = dtTonKho2.Rows[0]["SLDUTRU"].ToString();
                            dSLTON = (dtTonKho2.Rows[0]["SLTON"].ToString() != "" ? double.Parse(dtTonKho2.Rows[0]["SLTON"].ToString()) : 0);
                            dSLDUTRU = (dtTonKho2.Rows[0]["SLDUTRU"].ToString() != "" ? double.Parse(dtTonKho2.Rows[0]["SLDUTRU"].ToString()) : 0);

                        }
                    }

                    double dSLTON2 = dSLTON - dSLDUTRU;
                    if (dTongSLKe <= dSLTON2) dt.Rows[j]["SLCHOPHEP"] = TONGSLKE;
                    else dt.Rows[j]["SLCHOPHEP"] = dSLTON2;
                }

                if (lstThuoc.IndexOf(dt.Rows[j]["idthuoc"].ToString()) == -1)
                {
                    lstThuoc.Add(dt.Rows[j]["idthuoc"].ToString());
                    dt.Rows[j]["STT"] = lstThuoc.Count;
                }
                if (lstBenhNhan.IndexOf(dt.Rows[j]["idbenhnhan"].ToString()) == -1)
                    lstBenhNhan.Add(dt.Rows[j]["idbenhnhan"].ToString());


                html.Append("<tr>");
                html.Append("<td  >" + dt.Rows[j]["STT"] + "</td>");
                html.Append("<td style='text-align:left;'>" + dt.Rows[j]["NGAYDANGKY"] + "</td>");
                //html.Append("<td  >" + dt.Rows[j]["MABENHNHAN"] + "</td>");
                html.Append("<td  >" + dt.Rows[j]["TENBENHNHAN"] + "</td>");
                html.Append("<td  >" + dt.Rows[j]["NGAYSINH"] + "</td>");
                html.Append("<td  >" + dt.Rows[j]["LOAIKCB"] + "</td>");
                html.Append("<td  >" + DateTime.Parse(dt.Rows[j]["NGAYCD"].ToString()).ToString("dd HH:mm") + "</td>");
                html.Append("<td  >" + tenthuoc + "</td>");
                html.Append("<td  ><input mkv='true' id='SOLUONGKE' type='text'" + (IsDuyetIn == true ? " disabled " : "") + " value='" + dt.Rows[j]["SOLUONGKE"] + "' style='width:100%'  onblur=\"CheckValid(this);\" /></td>");
                html.Append("<td  ><input type='checkbox' mkv='true' id='CHOICE' " + (StaticData.IsCheck(dt.Rows[j]["CHOICE"]) ? "checked " : "") + " onclick=\"CheckValid(this);\"" + " /></td>");
                html.Append("<td  ><input mkv='true'  id='TONGSLKE' type='text' disabled value='" + TONGSLKE + "' style='width:100%'    /></td>");
                html.Append("<td  >"+(tenthuoc!="" &&tenthuoc!="-" ?"<input type='checkbox' mkv='true' id='CheckTongSLKe' checked       onclick=\"CheckTongSLKe_click(this);\"" + " />" :"")+ " </td>");
                html.Append("<td  ><input mkv='true'  id='SLTON' type='text' disabled value='" + dt.Rows[j]["SLTON"] + "'    style='width:100%'   /></td>");
                html.Append("<td  ><input mkv='true'  id='SLDUTRU' type='text' disabled value='" + dt.Rows[j]["SLDUTRU"] + "'  style='width:100%'    /></td>");
                html.Append("<td  >" + dt.Rows[j]["SLCHOPHEP"] + "</td>");
                html.Append("<td><input mkv='true' id='idkhoachinh' type='hidden' value='" + dt.Rows[j]["IDCHITIETBENHNHANTOATHUOC"] + "'/>");
                html.Append("<input mkv='true' id='IDTHUOC' type='hidden' value='" + dt.Rows[j]["IDTHUOC"] + "'/>");
                html.Append("<input mkv='true' id='SLCHOPHEP' type='hidden' value='" + dt.Rows[j]["SLCHOPHEP"] + "'/>");
                html.Append("<input mkv='true' id='idbenhnhan' type='hidden' value='" + dt.Rows[j]["idbenhnhan"] + "'/>");
                html.Append("<input mkv='true' id='TENTHUOC' type='hidden' value='" + tenthuoc + "'/></td>");
                html.Append("</tr>");
            }
            html.Append("<tr>");
            html.Append("<td  > </td>");
            html.Append("<td style='text-align:right; 'CỘNG > </td>");
            //html.Append("<td  >CỘNG</td>");
            html.Append("<td  ><input id='tongbenhnhan' type='text' disabled value='" + lstBenhNhan.Count.ToString() + "'/></td>");
            html.Append("<td  > </td>");
            html.Append("<td  > </td>");
            html.Append("<td  > </td>");
            html.Append("<td  ><input id='tongthuoc' type='text' disabled value='" + lstThuoc.Count.ToString() + "'/></td>");
            html.Append("<td  > </td>");
            html.Append("<td  > </td>");
            html.Append("<td  > </td>");
            html.Append("<td  > </td>");
            html.Append("<td  > </td>");
            html.Append("<td  > </td>");
            html.Append("<td  > </td>");
            html.Append("<td></td>");

            html.Append("</tr>");
        }
        html.Append("<tr><td colspan='11'></td></tr>");
        html.Append("</table>");
        Response.Clear();
        Response.Write(html.ToString());
    }
    private void KiemTraTonYC()
    {
        try
        {
            string IDTHUOC = Request.QueryString["IDTHUOC"];
            string TONGSLKE = Request.QueryString["TONGSLKE"];
            string IdPhieuYc = Request.QueryString["IdPhieuYc"];
            string IdKhoDuyet = Request.QueryString["IdKhoDuyet"];
            string NgayDuyet = Request.QueryString["NgayDuyet"];
            string GioDuyet = Request.QueryString["GioDuyet"];
            string PhutDuyet = Request.QueryString["PhutDuyet"];
            if (GioDuyet == null || GioDuyet == "") GioDuyet = "23";
            if (PhutDuyet == null || PhutDuyet == "") PhutDuyet = "59";

            string value = "0";
            if (TONGSLKE != null && TONGSLKE != "" && TONGSLKE != "0" && StaticData.ParseInt(IDTHUOC) > 0)
            {
                string sqlSelectTonKho = "SELECT SLTON=DBO.Thuoc_TonKho_new_1910(" + IDTHUOC + ",'" + StaticData.CheckDate(NgayDuyet) + " " + GioDuyet + ":" + PhutDuyet + ":59'" + "," + IdKhoDuyet + @") 
									                 ,SLDUTRU=  DBO.HS_SLYEUCAUCHUADUYET(" + IDTHUOC + "," + IdKhoDuyet + @",NULL)";
                DataTable dtTonKho = DataAcess.Connect.GetTable(sqlSelectTonKho);
                if (dtTonKho != null && dtTonKho.Rows.Count > 0)
                {
                    double slton = double.Parse(dtTonKho.Rows[0]["SLTON"].ToString());
                    double sldutru = double.Parse(dtTonKho.Rows[0]["SLDUTRU"].ToString());
                    if (StaticData.ParseInt(IdPhieuYc) > 0)
                        sldutru = sldutru - double.Parse(TONGSLKE);
                    if ((slton - sldutru) < double.Parse(TONGSLKE))
                    {
                        value = "0";
                    }
                    else
                        value = "1";
                }
            }
            else
                value = "1";
            Response.Clear();
            Response.Write(value);
        }
        catch (Exception)
        {
            Response.Clear();
            Response.Write("0");
        }
    }
    private void UpdateChitietChiDinh()
    {
        try
        {
            string idctbntt = Request.QueryString["idkhoachinh"];
            string IdPhieuYc = Request.QueryString["IdPhieuYc"];
            string IDTHUOC = Request.QueryString["IDTHUOC"];
            string TONGSLKE = Request.QueryString["TONGSLKE"];
            string TENTHUOC = Request.QueryString["TENTHUOC"];
            string SOLUONGKE = Request.QueryString["SOLUONGKE"];
            string SLTON = Request.QueryString["SLTON"];
            string SLDUTRU = Request.QueryString["SLDUTRU"];






            bool Choice = StaticData.IsCheck(Request.QueryString["Choice"]);
            if (Choice)
            {
                string sql = @"UPDATE CHITIETBENHNHANTOATHUOC SET IsDaXuatTheoYC =1,SOLUONGKE='" + SOLUONGKE + "',IdPhieuYc_XUAT=" + IdPhieuYc + @"
                    WHERE IDCHITIETBENHNHANTOATHUOC='" + idctbntt + "'";
                bool kt = DataAcess.Connect.ExecSQL(sql);
            }

            else
            {
                string sql = @"UPDATE CHITIETBENHNHANTOATHUOC SET IsDaXuatTheoYC =0,IdPhieuYc_XUAT=NULL,SOLUONGKE='" + SOLUONGKE + @"'  
                    WHERE IDCHITIETBENHNHANTOATHUOC='" + idctbntt + "'";
                bool kt = DataAcess.Connect.ExecSQL(sql);
            }
            if (TONGSLKE != null && TONGSLKE != "" && TONGSLKE != "0")
            {
                string sqlCheck1 = "SELECT * FROM YC_PHIEUYCXUATCHITIET WHERE IdPhieuYc=" + IdPhieuYc + " AND IDTHUOC=" + IDTHUOC;
                DataTable dtCheck1 = DataAcess.Connect.GetTable(sqlCheck1);
                if (dtCheck1 == null) return;
                if (dtCheck1.Rows.Count == 0)
                {
                    string sqlSave = @"INSERT INTO YC_PHIEUYCXUATCHITIET(IDCHITIETYC,IdPhieuYc,IDTHUOC,SOLUONGYC,SLTON,SLDUTRU)
                                 SELECT          IDCHITIETYC=ISNULL(( SELECT MAX(IdChiTietYc)  FROM YC_PHIEUYCXUATCHITIET),0)+1,
                                           IdPhieuYc=" + IdPhieuYc + ","
                                               + "IDTHUOC=" + IDTHUOC + ","
                                               + "SOLUONGYC=" + TONGSLKE + ","
                                               + "SLTON='" + SLTON + "',"
                                               + "SLDUTRU='" + SLDUTRU + "'"
                                               ;
                    bool ok2 = DataAcess.Connect.ExecSQL(sqlSave);
                }
                else
                {
                    string sqlUpdate = @"UPDATE  YC_PHIEUYCXUATCHITIET SET
                                                SOLUONGYC=" + TONGSLKE + ","
                                               + "SLTON='" + SLTON + "',"
                                               + "SLDUTRU='" + SLDUTRU + @"'    
                                       WHERE IDCHITIETYC=" + dtCheck1.Rows[0]["IDCHITIETYC"].ToString();
                        
                                                
                    bool ok3 = DataAcess.Connect.ExecSQL(sqlUpdate);
                }
            }
            else
                if (TENTHUOC != "" && TENTHUOC != "-")
                {
                    string sqlDelete = @"DELETE  YC_PHIEUYCXUATCHITIET WHERE  IdPhieuYc=" + IdPhieuYc + "  AND IDTHUOC=" + IDTHUOC;
                    bool ok3 = DataAcess.Connect.ExecSQL(sqlDelete);
                }
        }
        catch (Exception)
        {
            Response.StatusCode = 500;
        }
    }

    ////--------------------------------------------------------

    void SavePhieuYCXuat()
    {
        Response.Clear();
        string NgayYc = Request.QueryString["NgayYc"];
        string GioYc = Request.QueryString["GioYc"];
        string PhutYC = Request.QueryString["PhutYC"];
        string IdKhoYc = Request.QueryString["IdKhoYc"];
        string LoaiThuocID = Request.QueryString["LoaiThuocID"];
        string IdKhoDuyet = Request.QueryString["IdKhoDuyet"];
        string NgayDuyet = Request.QueryString["NgayDuyet"];
        string GioDuyet = Request.QueryString["GioDuyet"];
        string PhutDuyet = Request.QueryString["PhutDuyet"];
        string TuNgay = Request.QueryString["TuNgay"];
        string TuGio = Request.QueryString["TuGio"];
        string TuPhut = Request.QueryString["TuPhut"];
        string DenNgay = Request.QueryString["DenNgay"];
        string DenGio = Request.QueryString["DenGio"];
        string DenPhut = Request.QueryString["DenPhut"];
        string IsDuTru = Request.QueryString["IsDuTru"];
        string IdPhieuYc = Request.QueryString["IdPhieuYc"];
        if (TuGio == null || TuGio == "") TuGio = "00";
        if (TuPhut == null || TuPhut == "") TuPhut = "00";
        if (DenGio == null || DenGio == "") DenGio = "23";
        if (DenPhut == null || DenPhut == "") DenPhut = "59";


        if (GioYc == null || GioYc == "") GioYc = "00";
        if (PhutYC == null || PhutYC == "") PhutYC = "00";
        if (GioDuyet == null || GioDuyet == "") GioDuyet = "23";
        if (PhutDuyet == null || PhutDuyet == "") PhutDuyet = "59";


        DataProcess Yc_PhieuYCXuat = new DataProcess("Yc_PhieuYCXuat");
        Yc_PhieuYCXuat.data("IdPhieuYc", IdPhieuYc);
        Yc_PhieuYCXuat.data("NgayYc", NgayYc + " " + GioYc + ":" + PhutYC);
        Yc_PhieuYCXuat.data("IdKhoYc", IdKhoYc);
        Yc_PhieuYCXuat.data("LoaiThuocID", LoaiThuocID);
        Yc_PhieuYCXuat.data("IdKhoDuyet", IdKhoDuyet);
        Yc_PhieuYCXuat.data("IsDuTru", IsDuTru);
        Yc_PhieuYCXuat.data("IsTheoCD", "1");
        Yc_PhieuYCXuat.data("NgayDuyet", NgayDuyet + " " + GioDuyet + ":" + PhutDuyet);
        Yc_PhieuYCXuat.data("TuNgay", TuNgay + " " + TuGio + ":" + TuPhut);
        Yc_PhieuYCXuat.data("DenNgay", DenNgay + " " + DenGio + ":" + DenPhut);
        Yc_PhieuYCXuat.data("IdNguoiYc", SysParameter.UserLogin.UserID(this));
        bool ok1 = false;
        if (IdPhieuYc == null || IdPhieuYc == "")
            ok1 = Yc_PhieuYCXuat.Insert();
        else ok1 = Yc_PhieuYCXuat.Update();
        if (ok1 == false) return;
        if (IdPhieuYc == null || IdPhieuYc == "")
        {
            string sqlSelect = "SELECT TOP 1 IdPhieuYc FROM YC_PHIEUYCXUAT WHERE IdKhoYc=" + IdKhoYc + " AND IdKhoDuyet=" + IdKhoDuyet + " ORDER BY IdPhieuYc DESC";
            DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
            if (dt != null && dt.Rows.Count > 0)
            {
                string sqlSaveSoPhieuYC = "EXEC HS_CREATE_MAPHIEUYCXUATBYKHO '" + StaticData.CheckDate(NgayDuyet) + "' ," + IdKhoDuyet + " ," + dt.Rows[0][0].ToString() + "  ";
                bool ok11 = DataAcess.Connect.ExecSQL(sqlSaveSoPhieuYC);
                string sqlSelect2 = "SELECT SOPHIEUYC FROM YC_PHIEUYCXUAT WHERE IdPhieuYc=" + dt.Rows[0][0].ToString();
                DataTable dt2 = DataAcess.Connect.GetTable(sqlSelect2);
                if (dt2 != null && dt2.Rows.Count > 0)
                {

                    Response.Write(dt.Rows[0][0].ToString() + ";" + dt2.Rows[0][0].ToString());
                }
            }
            else Response.Write("");
        }
        else
        {

            string sqlSelect3 = "SELECT IdPhieuYc, SOPHIEUYC FROM YC_PHIEUYCXUAT WHERE IdPhieuYc=" + IdPhieuYc;
            DataTable dt3 = DataAcess.Connect.GetTable(sqlSelect3);
            if (dt3 != null && dt3.Rows.Count > 0)
            {

                Response.Write(dt3.Rows[0][0].ToString() + ";" + dt3.Rows[0][0].ToString());
            }
            else Response.Write("");
        }

    }
    //─────────────────────────────────────────────────────────────────────────────────────── 
    private void XoaPhieuYCXuat()
    {
        Response.Clear();
        string idphieuyc = Request.QueryString["IdPhieuYc"];
        if (string.IsNullOrEmpty(idphieuyc))
        {
            Response.Write("Chưa có phiếu YC !");
            return;
        }
        bool ok = false;
        string sqlDelCt = "delete  yc_phieuycxuatchitiet where idphieuyc ='" + idphieuyc + "'";
        ok = DataAcess.Connect.ExecSQL(sqlDelCt);
        if (!ok)
        {
            Response.Write("Lỗi xóa chi tiết Yêu cầu !");
            return;
        }
        string sqlDelYC = "delete  yc_phieuycxuat where idphieuyc ='" + idphieuyc + "'";
        ok = DataAcess.Connect.ExecSQL(sqlDelYC);
        if (!ok)
        {
            Response.Write("Lỗi xóa phiếu YC !");
            return;
        }
        string sqlUpCD = "update chitietbenhnhantoathuoc set IsDaXuatTheoYC=0,IdPhieuYc_XUAT=0 where IdPhieuYc_XUAT='" + idphieuyc + "'";
        ok = DataAcess.Connect.ExecSQL(sqlUpCD);
        if (!ok)
        {
            Response.Write("Lỗi cập nhật chỉ định !");
            return;
        }
        Response.Write("1");
    }
    //─────────────────────────────────────────────────────────────────────────────────────── 
    private void SetDefault()
    {
        string IdPhieuYc = Request.QueryString["IdPhieuYc"];
        if (IdPhieuYc == null || IdPhieuYc == "") IdPhieuYc = "0";
        if (IdPhieuYc == "0") return;
        string SQL = @" SELECT T.*
                            FROM YC_PHIEUYCXUAT T 
                            WHERE T.IdPhieuYc=" + IdPhieuYc;

        bool perLuu = Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_Add");
        bool perXoa = Userlogin_new.HavePermision(this, "Yc_PhieuYCXuat_delete");
        bool perDuyetIn = true;

        DataTable dt2 = DataAcess.Connect.GetTable(SQL);
        string html = "";
        html += "<root>";

        if (dt2 != null && dt2.Rows.Count > 0)
        {
            perLuu = perLuu && !StaticData.IsCheck(dt2.Rows[0]["IsDuyetIn"].ToString());
            perXoa = perXoa && !StaticData.IsCheck(dt2.Rows[0]["IsDuyetIn"].ToString());
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                if (dt2.Columns[i].DataType != DateTime.Now.GetType())
                    html += "<data id=\"" + dt2.Columns[i].ColumnName + "\">" + dt2.Rows[0][i].ToString() + "</data>";
            }

            if (dt2.Rows[0]["NgayYc"].ToString() != "")
            {
                html += "<data  id=\"NgayYc\">" + DateTime.Parse(dt2.Rows[0]["NgayYc"].ToString()).ToString("dd/MM/yyyy") + "</data>";
                html += "<data  id=\"GioYc\">" + DateTime.Parse(dt2.Rows[0]["NgayYc"].ToString()).ToString("HH") + "</data>";
                html += "<data  id=\"PhutYc\">" + DateTime.Parse(dt2.Rows[0]["NgayYc"].ToString()).ToString("mm") + "</data>";
            }
            if (dt2.Rows[0]["NgayDuyet"].ToString() != "")
            {
                html += "<data  id=\"NgayDuyet\">" + DateTime.Parse(dt2.Rows[0]["NgayDuyet"].ToString()).ToString("dd/MM/yyyy") + "</data>";
                html += "<data  id=\"GioDuyet\">" + DateTime.Parse(dt2.Rows[0]["NgayDuyet"].ToString()).ToString("HH") + "</data>";
                html += "<data  id=\"PhutDuyet\">" + DateTime.Parse(dt2.Rows[0]["NgayDuyet"].ToString()).ToString("mm") + "</data>";
            }
            if (dt2.Rows[0]["TuNgay"].ToString() != "")
            {
                html += "<data  id=\"TuNgay\">" + DateTime.Parse(dt2.Rows[0]["TuNgay"].ToString()).ToString("dd/MM/yyyy") + "</data>";
                html += "<data  id=\"TuGio\">" + DateTime.Parse(dt2.Rows[0]["TuNgay"].ToString()).ToString("HH") + "</data>";
                html += "<data  id=\"TuPhut\">" + DateTime.Parse(dt2.Rows[0]["TuNgay"].ToString()).ToString("mm") + "</data>";
            }
            if (dt2.Rows[0]["DenNgay"].ToString() != "")
            {
                html += "<data  id=\"DenNgay\">" + DateTime.Parse(dt2.Rows[0]["DenNgay"].ToString()).ToString("dd/MM/yyyy") + "</data>";
                html += "<data  id=\"DenGio\">" + DateTime.Parse(dt2.Rows[0]["DenNgay"].ToString()).ToString("HH") + "</data>";
                html += "<data  id=\"DenPhut\">" + DateTime.Parse(dt2.Rows[0]["DenNgay"].ToString()).ToString("mm") + "</data>";
            }

            if (!StaticData.IsCheck(dt2.Rows[0]["IsDuyetIn"].ToString())) perDuyetIn = false;


        }
        else
            perXoa = false;

        if (perLuu)
            html += "<data  id=\"perLuu\">" + "1" + "</data>";
        else
            html += "<data  id=\"perLuu\">" + "0" + "</data>";

        if (perXoa)
            html += "<data  id=\"perXoa\">" + "1" + "</data>";
        else
            html += "<data  id=\"perXoa\">" + "0" + "</data>";

        if (perDuyetIn)
            html += "<data  id=\"perPint\">" + "1" + "</data>";
        else
            html += "<data  id=\"perPint\">" + "0" + "</data>";


        html += "</root>";
        Response.Clear();
        Response.Write(html);
    }//End void
    //─────────────────────────────────────────────────────────────────────────────────────── 
}//END CLASS
