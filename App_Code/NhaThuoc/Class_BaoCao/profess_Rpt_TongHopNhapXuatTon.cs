using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary DEScription for BienBangKiemNhap
/// </summary>
public class profess_Rpt_TongHopNhapXuatTon : ExportToExcel.Profess_ExportToExcelByCode
{
    public profess_Rpt_TongHopNhapXuatTon()
    {
        this.IsDeleteTotalRow = false;
    }
    public string TuNgay = null;
    public string DenNgay = null;
    public string IdKho = null;
    public string TenThuoc = null;
    public string LoaiThuocID = null;
    public string IsTGN = "-1";
    public string IsTHTT = "-1";
    public string TenLoaiThuoc = "";
    public string TenKho = "KHOA DƯỢC";
    public bool IsHaveDonGia = false;
    public bool IsOrderByName = false;
    public bool IsOnlySoLuong = false;
    public bool IsRutGon=false;
    public string IDTHUOC = null;
   
    public string tugio;
    public string tuphut;
    public string dengio;
    public string denphut;


    public override DataTable getViewTable()
    {
        if(TenLoaiThuoc==null||TenLoaiThuoc=="")
        {
            TenLoaiThuoc = DataAcess.Connect.GetTable("SELECT TenLoai FROM THUOC_LOAITHUOC WHERE LOAITHUOCID=" + LoaiThuocID).Rows[0][0].ToString();
        }
        bool IsKhoNhap = true;
        if (IsRutGon)
        {
            string arrIdKhoNhap = StaticData.GetParaValueDB("IdKhoNhap");

            if (arrIdKhoNhap != null && arrIdKhoNhap != "")
            {
                IsKhoNhap = (arrIdKhoNhap.IndexOf(IdKho) != -1 ? true : false);
            }
        }

        this.TuNgay = StaticData.CheckDate(this.TuNgay);
        if (this.tugio == null || this.tugio == "") this.tugio = "00";
        if (this.tuphut == null || this.tuphut == "") this.tuphut = "00";
        this.TuNgay += " " + tugio + ":" + tuphut + ":00";

        this.DenNgay = StaticData.CheckDate(this.DenNgay);
        if (this.dengio == null || this.dengio == "") this.dengio = "23";
        if (this.denphut == null || this.denphut == "") this.denphut = "59";
        this.DenNgay += " " + dengio + ":" + denphut + ":59";


        this.FromDate = TuNgay;
        this.ToDate = this.DenNgay;
        string sqlSelect="";
        if (IsOnlySoLuong) this.IsHaveDonGia = false;
        if (IsHaveDonGia) this.IsOnlySoLuong = false;
        if (IsRutGon)
        {
            IsHaveDonGia = false;
            IsOnlySoLuong = false;
        }

        string sqlGetDeclareDate = @"SELECT TOP 1 DECLAREDATE FROM zKhoDeclared WHERE IDKHO=" + IdKho
                                                                                + @"AND ( ISNULL(LOAITHUOCID,0)=0 OR LOAITHUOCID="+this.LoaiThuocID+@"  )
		                                                                        ORDER BY LOAITHUOCID DESC";

        DataTable dtDeclareDate = DataAcess.Connect.GetTable(sqlGetDeclareDate);
        string DeclateDate = "2013-07-29 13:30:00";
        if (dtDeclareDate != null && dtDeclareDate.Rows.Count > 0)
            DeclateDate = dtDeclareDate.Rows[0][0].ToString();

        if (!this.IsHaveDonGia)
        {
            sqlSelect = @"  
			                 SELECT 
					         STT=1,TTHC=sttindm05
					        ,tensp= TENTHUOC,
					        TENDVT,Dongia=0,
					        DAUKY_SL = 0,--ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"'  AND NGAYTHANG_NHAP>='"+ DeclateDate+"'    AND NGAYTHANG_NHAP<'" + TuNgay + @"'  AND IDTHUOC=T.IDTHUOC)-ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND  NGAYTHANG_XUAT>='"+DeclateDate+"'   AND NGAYTHANG_XUAT<'" + TuNgay + @"'  AND IDTHUOC=T.IDTHUOC),0),0),
					        DAUKY_TT =0,--ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"'  AND NGAYTHANG_NHAP>='" + DeclateDate + "' AND NGAYTHANG_NHAP<'" + TuNgay + @"'  AND IDTHUOC=T.IDTHUOC)-ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"'  AND NGAYTHANG_XUAT>='" + DeclateDate + "' AND NGAYTHANG_XUAT<'" + TuNgay + @"'  AND IDTHUOC=T.IDTHUOC),0),0),
					        NHAP_SL=(SELECT SUM(SOLUONG) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"' AND NGAYTHANG_NHAP>='" + FromDate + @"' AND NGAYTHANG_NHAP<='" + ToDate + @"'" + (IsKhoNhap ? " AND IDLOAINHAP_NHAP<>4" : "") + @"  AND IDTHUOC=T.IDTHUOC),
					        NHAP_TT=(SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"' AND NGAYTHANG_NHAP>='" + FromDate + @"' AND NGAYTHANG_NHAP<='" + ToDate + @"'" + (IsKhoNhap ? "" : " AND IDLOAINHAP_NHAP=4") + @"  AND IDTHUOC=T.IDTHUOC),"
                    + (IsKhoNhap ? @"  

					        NHAP_SL2=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"' AND NGAYTHANG_NHAP>='" + FromDate + @"' AND NGAYTHANG_NHAP<='" + ToDate + @"' AND IDLOAINHAP_NHAP=4  AND IDTHUOC=T.IDTHUOC),0),
					        NHAP_TT2=ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"' AND NGAYTHANG_NHAP>='" + FromDate + @"' AND NGAYTHANG_NHAP<='" + ToDate + @"' AND IDLOAINHAP_NHAP=4  AND IDTHUOC=T.IDTHUOC),0),
                            "
                        : @" 
                            NHAP_SL2=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + FromDate + @"' AND NGAYTHANG_XUAT<='" + ToDate + @"' AND IDLOAIXUAT_XUAT=4  AND IDTHUOC=T.IDTHUOC),0),
					        NHAP_TT2=ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + FromDate + @"' AND NGAYTHANG_XUAT<='" + ToDate + @"' AND IDLOAIXUAT_XUAT=4 AND IDTHUOC=T.IDTHUOC),0),
                           "
                      )
                     +(IsKhoNhap? @"
					        XUAT_SL=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + FromDate + @"' AND NGAYTHANG_XUAT<='" + ToDate + @"'" + (IsRutGon ? " " : "AND IDLOAIXUAT_XUAT<>4") + @"    AND IDTHUOC=T.IDTHUOC),0),
					        XUAT_TT=ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + FromDate + @"' AND NGAYTHANG_XUAT<='" + ToDate + @"'" + (IsRutGon ? "" : " AND IDLOAIXUAT_XUAT<>4") + @"    AND IDTHUOC=T.IDTHUOC),0),
                              "
                          :
                          @"
					        XUAT_SL=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + FromDate + @"' AND NGAYTHANG_XUAT<='" + ToDate + @"'" + (IsRutGon ? " AND IDLOAIXUAT_XUAT<>4" : "") + @"    AND IDTHUOC=T.IDTHUOC),0),
					        XUAT_TT=ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + FromDate + @"' AND NGAYTHANG_XUAT<='" + ToDate + @"'" + (IsRutGon ? " AND IDLOAIXUAT_XUAT<>4" : "") + @"    AND IDTHUOC=T.IDTHUOC),0),
                          "
                      )
                    +@"
					        XUAT_SL2=" +(IsRutGon? "0":@"ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + TuNgay + @"' AND NGAYTHANG_XUAT<='" + DenNgay + @"' AND IDLOAIXUAT_XUAT=4  AND IDTHUOC=T.IDTHUOC),0)")+@",
					        XUAT_TT2="+(IsRutGon?"0" :@" ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + TuNgay + @"' AND NGAYTHANG_XUAT<='" + DenNgay + @"' AND IDLOAIXUAT_XUAT=4  AND IDTHUOC=T.IDTHUOC),0)")+ @",
                            CUOIKY_SL=0.0,
                            CUOIKY_TT=0.0,
					        GhiChu=''
                            ,NHOMTHUOC=ISNULL(T2.MANHOM+'.','')+ T2.TENNHOM
                            ,CATENAME=ISNULL(T3.DES +'.','') + T3.CATENAME
                            ,T3.DES,T2.MANHOM,T.IdThuoc
			        FROM THUOC T
			        LEFT JOIN THUOC_DONVITINH T1 ON T.IDDVT=T1.ID
			        LEFT JOIN NHOMTHUOC T2 ON T.IDNHOMTHUOC=T2.IDNHOMTHUOC
			        LEFT JOIN CATEGORY T3 ON T.CATEID=T3.CATEID
			        WHERE 1=1       and T.ISTHUOCBV=1";
        }
        else
        {
            sqlSelect = @"  SELECT DISTINCT
					         STT=1,TTHC=sttindm05
					        ,tensp= TENTHUOC,
					        TENDVT,Dongia=ROUND( ISNULL(A.DONGIA,0)*(100.0+ISNULL(VAT,0))/100,0),
					        DAUKY_SL =0,--ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"'  AND NGAYTHANG_NHAP>='" + DeclateDate + "'  AND NGAYTHANG_NHAP<'" + TuNgay + @"'  AND DONGIA=A.DONGIA AND IDTHUOC=T.IDTHUOC)-ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"'  AND NGAYTHANG_XUAT>='" + DeclateDate + "' AND NGAYTHANG_XUAT<'" + TuNgay + @"'  AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC),0),0),
					        DAUKY_TT =0,--ROUND( ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"'  AND NGAYTHANG_NHAP>='" + DeclateDate + "'  AND NGAYTHANG_NHAP<'" + TuNgay + @"'  AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC)-ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"'  AND NGAYTHANG_XUAT>='" + DeclateDate + "' AND NGAYTHANG_XUAT<'" + TuNgay + @"'  AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC),0),0),0),
					        NHAP_SL=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"' AND NGAYTHANG_NHAP>='" + TuNgay + @"' AND NGAYTHANG_NHAP<='" + DenNgay + @"'"+( IsKhoNhap?"  AND IDLOAINHAP_NHAP<>4" :"")+@"   AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC),0),
					        NHAP_TT=ROUND( ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"' AND NGAYTHANG_NHAP>='" + TuNgay + @"' AND NGAYTHANG_NHAP<='" + DenNgay + @"'"+(IsKhoNhap?" AND IDLOAINHAP_NHAP<>4" :"")+@"  AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC),0),0),
					        NHAP_SL2=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"' AND NGAYTHANG_NHAP>='" + TuNgay + @"' AND NGAYTHANG_NHAP<='" + DenNgay + @"' AND IDLOAINHAP_NHAP=4   AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC),0),
					        NHAP_TT2=ROUND( ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP='" + IdKho + @"' AND NGAYTHANG_NHAP>='" + TuNgay + @"' AND NGAYTHANG_NHAP<='" + DenNgay + @"' AND IDLOAINHAP_NHAP=4   AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC),0),0),
					        XUAT_SL=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + TuNgay + @"' AND NGAYTHANG_XUAT<='" + DenNgay + @"' AND IDLOAIXUAT_XUAT<>4   AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC),0),
					        XUAT_TT=ROUND( ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + TuNgay + @"' AND NGAYTHANG_XUAT<='" + DenNgay + @"' AND IDLOAIXUAT_XUAT<>4   AND DONGIA=A.DONGIA AND IDTHUOC=T.IDTHUOC),0),0),
					        XUAT_SL2=ISNULL((SELECT SUM(SOLUONG) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + TuNgay + @"' AND NGAYTHANG_XUAT<='" + DenNgay + @"' AND IDLOAIXUAT_XUAT=4  AND DONGIA=A.DONGIA  AND IDTHUOC=T.IDTHUOC),0),
					        XUAT_TT2=ROUND( ISNULL((SELECT SUM(SOLUONG*DONGIA*(100.0+ISNULL(VAT,0))/100) FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT='" + IdKho + @"' AND NGAYTHANG_XUAT>='" + TuNgay + @"' AND NGAYTHANG_XUAT<='" + DenNgay + @"' AND IDLOAIXUAT_XUAT=4  AND DONGIA=A.DONGIA AND IDTHUOC=T.IDTHUOC),0),0),
                            CUOIKY_SL=0.0,
                            CUOIKY_TT=0.0,
					        GhiChu=''
                            ,NHOMTHUOC=ISNULL(T2.MANHOM+'.','')+ T2.TENNHOM
                            ,CATENAME=ISNULL(T3.DES +'.','') + T3.CATENAME
                            ,T3.DES,T2.MANHOM,A.IdThuoc
			        FROM CHITIETPHIEUNHAPKHO A
					LEFT JOIN THUOC T ON A.IDTHUOC=T.IDTHUOC
			        LEFT JOIN THUOC_DONVITINH T1 ON T.IDDVT=T1.ID
			        LEFT JOIN NHOMTHUOC T2 ON T.IDNHOMTHUOC=T2.IDNHOMTHUOC
			        LEFT JOIN CATEGORY T3 ON T.CATEID=T3.CATEID
			        WHERE 1=1       and T.ISTHUOCBV=1";
            
            
        }

        if (this.IsTGN != "-1")
            sqlSelect += " AND T.IsTGN=1";
        if (this.IsTHTT != "-1")
            sqlSelect += " AND T.IsTHTT=1";
        if (this.TenThuoc != "")
            sqlSelect += " AND T.TENTHUOC LIKE N'" + TenThuoc + "%'";
        if (this.LoaiThuocID != null && this.LoaiThuocID != "" && this.LoaiThuocID != "0")
            sqlSelect += " AND T.LoaiThuocID=" + this.LoaiThuocID;

        if (IsKhoNhap)
        {
            sqlSelect += @"  SELECT DISTINCT
					         STT=1,TTHC=sttindm05
					        ,tensp= TENTHUOC,
					        TENDVT,Dongia=0,
					        DAUKY_SL =0,
					        DAUKY_TT =0,
					        NHAP_SL=0,
					        NHAP_TT=0,
					        NHAP_SL2=0,
					        NHAP_TT2=0,
					        XUAT_SL=0,
					        XUAT_TT=0,
					        XUAT_SL2=0,
					        XUAT_TT2=0,
                            CUOIKY_SL=0.0,
                            CUOIKY_TT=0.0,
					        GhiChu=''
                            ,NHOMTHUOC=ISNULL(T2.MANHOM+'.','')+ T2.TENNHOM
                            ,CATENAME=ISNULL(T3.DES +'.','') + T3.CATENAME
                            ,T3.DES,T2.MANHOM,T.IdThuoc
			        FROM   THUOC T 
			        LEFT JOIN THUOC_DONVITINH T1 ON T.IDDVT=T1.ID
			        LEFT JOIN NHOMTHUOC T2 ON T.IDNHOMTHUOC=T2.IDNHOMTHUOC
			        LEFT JOIN CATEGORY T3 ON T.CATEID=T3.CATEID
			        WHERE 1=1       and T.ISTHUOCBV=1
                        AND NOT EXISTS (SELECT TOP 1 1 FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP=" + IdKho + @" AND IDTHUOC=T.IDTHUOC)
                        AND NOT EXISTS (SELECT TOP 1 1 FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT=" + IdKho + @" AND IDTHUOC=T.IDTHUOC)";
            if (this.IsTGN != "-1")
                sqlSelect += " AND T.IsTGN=1";
            if (this.IsTHTT != "-1")
                sqlSelect += " AND T.IsTHTT=1";
            if (this.TenThuoc != "")
                sqlSelect += " AND T.TENTHUOC LIKE N'" + TenThuoc + "%'";
            if (this.LoaiThuocID != null && this.LoaiThuocID != "" && this.LoaiThuocID != "0")
                sqlSelect += " AND T.LoaiThuocID=" + this.LoaiThuocID;

        }
        else
        {
            sqlSelect += @"  SELECT DISTINCT
					         STT=1,TTHC=sttindm05
					        ,tensp= TENTHUOC,
					        TENDVT,Dongia=0,
					        DAUKY_SL =0,
					        DAUKY_TT =0,
					        NHAP_SL=0,
					        NHAP_TT=0,
					        NHAP_SL2=0,
					        NHAP_TT2=0,
					        XUAT_SL=0,
					        XUAT_TT=0,
					        XUAT_SL2=0,
					        XUAT_TT2=0,
                            CUOIKY_SL=0.0,
                            CUOIKY_TT=0.0,
					        GhiChu=''
                            ,NHOMTHUOC=ISNULL(T2.MANHOM+'.','')+ T2.TENNHOM
                            ,CATENAME=ISNULL(T3.DES +'.','') + T3.CATENAME
                            ,T3.DES,T2.MANHOM,T.IdThuoc
			        FROM   THUOC T 
			        LEFT JOIN THUOC_DONVITINH T1 ON T.IDDVT=T1.ID
			        LEFT JOIN NHOMTHUOC T2 ON T.IDNHOMTHUOC=T2.IDNHOMTHUOC
			        LEFT JOIN CATEGORY T3 ON T.CATEID=T3.CATEID
			        WHERE 1=1       and T.ISTHUOCBV=1
                        AND NOT EXISTS (SELECT TOP 1 1 FROM CHITIETPHIEUNHAPKHO WHERE IDKHO_NHAP=" + IdKho + @" AND IDTHUOC=T.IDTHUOC)
                        AND NOT EXISTS (SELECT TOP 1 1 FROM CHITIETPHIEUXUATKHO WHERE IDKHO_XUAT=" + IdKho + @" AND IDTHUOC=T.IDTHUOC)
                        AND EXISTS (SELECT TOP 1 1 FROM THUOC_COSOTUTRUC_CHITIET A0 INNER JOIN THUOC_COSOTUTRUC B0 ON A0.IdCoSoTuTruc=B0.IdCoSoTuTruc
                                     WHERE B0.IDKHO=" + IdKho + @" AND A0.IDTHUOC=T.IDTHUOC)";
            if (this.IsTGN != "-1")
                sqlSelect += " AND T.IsTGN=1";
            if (this.IsTHTT != "-1")
                sqlSelect += " AND T.IsTHTT=1";
            if (this.TenThuoc != "")
                sqlSelect += " AND T.TENTHUOC LIKE N'" + TenThuoc + "%'";
            if (this.LoaiThuocID != null && this.LoaiThuocID != "" && this.LoaiThuocID != "0")
                sqlSelect += " AND T.LoaiThuocID=" + this.LoaiThuocID;
        }

        DataTable dt = GetTable(sqlSelect);
        if (dt != null)
        {
            if (!IsKhoNhap)
            {
                dt.DefaultView.RowFilter = "DAUKY_SL>0 OR DAUKY_TT>0 OR NHAP_SL>0 OR NHAP_TT>0 OR NHAP_SL2>0 OR NHAP_TT2>0  OR XUAT_SL>0 OR XUAT_TT>0  OR XUAT_SL2>0  OR XUAT_TT2>0";
                dt = dt.DefaultView.ToTable();
            }
            if (!this.IsOrderByName)
            {

                if (dt.Columns.IndexOf("DES1") == -1)
                    dt.Columns.Add("DES1", dt.Columns.Count.GetType());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["DES1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["DES"].ToString());
                }
                
            }
            else
            {
                dt.DefaultView.Sort = "tensp";
                dt = dt.DefaultView.ToTable();
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;

                string iDAUKY_SL = dt.Rows[i]["DAUKY_SL"].ToString();
                if (iDAUKY_SL == "") iDAUKY_SL = "0";

                string iNHAP_SL = dt.Rows[i]["NHAP_SL"].ToString();
                if (iNHAP_SL == "") iNHAP_SL = "0";

                string iNHAP_SL2 = dt.Rows[i]["NHAP_SL2"].ToString();
                if (iNHAP_SL2 == "") iNHAP_SL2 = "0";

                string iXUAT_SL = dt.Rows[i]["XUAT_SL"].ToString();
                if (iXUAT_SL == "") iXUAT_SL = "0";

                string iXUAT_SL2 = dt.Rows[i]["XUAT_SL2"].ToString();
                if (iXUAT_SL2 == "") iXUAT_SL2 = "0";



                string iDAUKY_TT = dt.Rows[i]["DAUKY_TT"].ToString();
                if (iDAUKY_TT == "") iDAUKY_TT = "0";

                string iNHAP_TT = dt.Rows[i]["NHAP_TT"].ToString();
                if (iNHAP_TT == "") iNHAP_TT = "0";

                string iNHAP_TT2 = dt.Rows[i]["NHAP_TT2"].ToString();
                if (iNHAP_TT2 == "") iNHAP_TT2 = "0";

                string iXUAT_TT = dt.Rows[i]["XUAT_TT"].ToString();
                if (iXUAT_TT == "") iXUAT_TT = "0";

                string iXUAT_TT2 = dt.Rows[i]["XUAT_TT2"].ToString();
                if (iXUAT_TT2 == "") iXUAT_TT2 = "0";



                double iCUOIKY_SL = double.Parse(iDAUKY_SL) + double.Parse(iNHAP_SL) +(IsKhoNhap? double.Parse(iNHAP_SL2): -double.Parse(iNHAP_SL2)) - double.Parse(iXUAT_SL) - (!IsRutGon? double.Parse(iXUAT_SL2) :0);
                double iThanhtienton = double.Parse(iDAUKY_TT) + double.Parse(iNHAP_TT) +(IsKhoNhap? double.Parse(iNHAP_TT2):-double.Parse(iNHAP_TT2)) - double.Parse(iXUAT_TT) - (!IsRutGon? double.Parse(iXUAT_TT2) :0);

                if (IsRutGon)
                {
                    if (IsKhoNhap)
                    {
                        iCUOIKY_SL = double.Parse(iDAUKY_SL) + double.Parse(iNHAP_SL) + double.Parse(iNHAP_SL2) - double.Parse(iXUAT_SL) - double.Parse(iXUAT_SL2);
                    }
                    else
                    {
                        iCUOIKY_SL = double.Parse(iDAUKY_SL) + double.Parse(iNHAP_SL) - double.Parse(iNHAP_SL2) - double.Parse(iXUAT_SL);
                    }
                }

                dt.Rows[i]["CUOIKY_SL"] = iCUOIKY_SL;
                dt.Rows[i]["CUOIKY_TT"] = iThanhtienton;
            }  
            if (!this.IsHaveDonGia)
            {

                #region Fix tên thuốc trùng nhau
                System.Collections.Generic.List<string> lstT = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<int[]> lstTarr = new System.Collections.Generic.List<int[]>();

                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    string iTenThuoc = dt.Rows[i]["IdThuoc"].ToString();
                    if (lstT.IndexOf(iTenThuoc) == -1)
                    {
                        lstT.Add(iTenThuoc);
                        int[] arr = new int[] { i };
                        for (int j = i + 1; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["IdThuoc"].ToString().ToLower().Trim() == iTenThuoc.ToLower().Trim())
                            {
                                Array.Resize(ref arr, arr.Length + 1);
                                arr[arr.Length - 1] = j;
                            }
                        }
                        lstTarr.Add(arr);
                    }
                }

                for (int i = 0; i < lstTarr.Count; i++)
                {
                    if (lstTarr[i].Length >= 2)
                    {
                        for (int k = 5; k <= 16; k++)
                        {
                            double dTotalK = 0;
                            for (int j = 0; j < lstTarr[i].Length; j++)
                            {
                                dTotalK += (dt.Rows[lstTarr[i][j]][k].ToString() != "" ? double.Parse(dt.Rows[lstTarr[i][j]][k].ToString()) : 0);
                            }

                            for (int j = 0; j < lstTarr[i].Length; j++)
                            {
                                dt.Rows[lstTarr[i][j]][k] = dTotalK;
                                if (j != 0)
                                {
                                    dt.Rows[lstTarr[i][j]]["GhiChu"] = (dt.Rows[lstTarr[i][0]]["DES"].ToString() != "" ? dt.Rows[lstTarr[i][0]]["DES"].ToString() : "Dòng " + (lstTarr[i][0] + 1).ToString());
                                    dt.Rows[lstTarr[i][j]]["DonGia"] = (dt.Rows[lstTarr[i][0]]["Dongia"].ToString() == "" ? dt.Rows[lstTarr[i][0]]["Dongia"] : 0);
                                }
                            }


                        }
                    }
                }


                #endregion
        
            }
           
        }
        if (!IsOrderByName)
            dt.DefaultView.Sort = "DES1,NHOMTHUOC,tensp";
        else
            dt.DefaultView.Sort = "tensp";

        dt = dt.DefaultView.ToTable();
        for (int i = 0; i < dt.Rows.Count; i++)
            dt.Rows[i]["STT"] = i + 1;
        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        if (this.IsOnlySoLuong)
        {
            if (this.LoaiThuocID != "2")
                return "BaoCaoNhapXuatTon_SL.xls";
            else
                return "BaoCaoNhapXuatTon_SL_HC.xls";
        }
        if (this.LoaiThuocID != "2")
            return "BaoCaoNhapXuatTon.xls";
        else
            return "BaoCaoNhapXuatTon_HC.xls"; 
    }
    protected override string SetOutputFileName()
    {
        return "BaoCaoNhapXuatTon.xls";//TÊN FILE XUẤT RA
    }
    protected override string SetHeaderText()
    {
        string s = "BÁO CÁO NHẬP XUẤT TỒN";// TÊN REPORT
        s += " " + this.TenLoaiThuoc.ToUpper();
        if (this.IsTGN == "1")
            s += " GÂY NGHIỆN";
        else if (this.IsTHTT == "1")
            s += " HƯỚNG TÂM THẦN";
        return s;
    }
    protected override ExportToExcel.CellIndex SetHeaderIndex()
    {
        return GetCellIndex("A4");//VỊ TRÍ CỦA TÊN REPORT TRON FILE EXCEL
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A11");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("DAUKY_TT");
        lst.Add("NHAP_TT");
        lst.Add("NHAP_TT2");
        lst.Add("XUAT_TT");
        lst.Add("XUAT_TT2");
        lst.Add("CUOIKY_TT");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("NHOMTHUOC"); //theo câu select
        lst.Add("CATENAME"); //theo câu select
        lst.Add("DES"); //theo câu select
        lst.Add("MANHOM"); //theo câu select
        if (!this.IsOrderByName)
        {
            lst.Add("DES1"); //theo câu select
        }
        lst.Add("IdThuoc"); //theo câu select 
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        if (!this.IsOrderByName)
        {
            lst.Add("CATENAME"); //theo câu select
            lst.Add("NHOMTHUOC"); //theo câu select
        }
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        string s1 = this.TuNgay;
        string s2 = this.DenNgay;
        lst.Add(TenKho + " - " + StaticData.TimeDescription(s1, s2) +" ("+ this.tugio+"h"+this.tuphut +"->"+ this.dengio+"h"+this.denphut+")");
        string TenThuocName = "Tên thuốc - Hàm lượng";
        if (LoaiThuocID != "1")
            TenThuocName = "Tên " + this.TenLoaiThuoc.ToLower();
        lst.Add(TenThuocName);
        return lst;
    }
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("A6"));
        lst.Add(GetCellIndex("C8"));
        return lst;
    }
}
