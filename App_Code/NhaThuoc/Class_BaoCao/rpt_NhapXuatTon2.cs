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
/// Summary description for BienBangKiemNhap
/// </summary>
public class _rpt_NhapXuatTon2 : ExportToExcel.Profess_ExportToExcelByCode
{
    public _rpt_NhapXuatTon2()
    {
        this.IsDeleteTotalRow = true;
    }
    public string IdKho = "";
    public string IdKho2 = "";
    public string TenThuoc = "";
    public string LoaiThuocId = "";
    public override DataTable getViewTable() // bắt buộc
    {
        string sql = @" SELECT STT=ROW_NUMBER() OVER (ORDER BY  TB.TENTHUOC,TB.IDTHUOC,NGAYTHANG,TypeCode) ,TB.*
                                 FROM 
                                 (
                                 (
                                   SELECT LoaiNX=TenLoaiNhap
			                                ,TENTHUOC
			                                ,TENDVT
			                                ,NGAYTHANG
			                                ,SoPhieu=  MaPhieuNhap
			                                ,DOITUONG=dbo.Thuoc_Get_DoiTuongNhap(A.IdPhieuNhap)
			                                ,SOLUONG
			                                ,DONGIA
			                                ,A.THANHTIEN
			                                ,TypeCode=0
			                                ,A.IDTHUOC
	                                 FROM CHITIETPHIEUNHAPKHO A
		                                 LEFT JOIN PHIEUNHAPKHO B ON A.IDPHIEUNHAP=B.IDPHIEUNHAP
		                                 LEFT JOIN THUOC C ON A.IDTHUOC=C.IDTHUOC
		                                 left join nhacungcap f on b.NHACUNGCAPID=f.NHACUNGCAPID
		                                 LEFT JOIN THUOC_DONVITINH G ON A." + Profess.TBLS.tbl_chitietphieunhapkho.dvt.ToString() + @"=G.ID
		                                 LEFT JOIN thuoc_loainhap H ON B.IdLoaiNhap=H.IDLoaiNhap
	                                 WHERE C.ISTHUOCBV=1 "
                                        + (this.FromDate != "" ? " AND B.NGAYTHANG>='" + this.FromDate + "'" : "")
                                         + (this.ToDate != "" ? " AND B.NGAYTHANG<='" + this.ToDate + "'" : "")
                                         + " AND  B.IDKHO=" + IdKho + @"
                                 )

                                 UNION ALL
	                                (
		                                 SELECT LoaiNX=N'Tổng Nhập'
			                                ,TENTHUOC
			                                ,TENDVT
			                                ,NGAYTHANG=GETDATE()
			                                ,SoPhieu=''
			                                ,DOITUONG=''
			                                ,SOLUONG=(SELECT sum(A1.soluong) FROM chitietphieunhapkho A1
                                                         LEFT JOIN phieunhapkho B1 ON A1.idphieunhap=B1.idphieunhap
							                                WHERE 	B1.IDKHO=" + IdKho + @" AND A1.idthuoc=A.idthuoc
                                                            "
                                         + (this.FromDate != "" ? " AND B1.NGAYTHANG>='" + this.FromDate + "'" : "")
                                         + (this.ToDate != "" ? " AND B1.NGAYTHANG<='" + this.ToDate + "'" : "")
                                         + @")
			                                ,DONGIA=0
			                                ,THANHTIEN=(SELECT sum(A1.THANHTIEN) FROM chitietphieunhapkho A1
                                                         LEFT JOIN phieunhapkho B1 ON A1.idphieunhap=B1.idphieunhap
							                                WHERE 	B1.IDKHO=" + IdKho + @" AND A1.idthuoc=A.idthuoc
                                            "
                                         + (this.FromDate != "" ? " AND B1.NGAYTHANG>='" + this.FromDate + "'" : "")
                                         + (this.ToDate != "" ? " AND B1.NGAYTHANG<='" + this.ToDate + "'" : "")
                                         + @"
						                                )
			                                ,TypeCode=1
			                                ,A.IDTHUOC

	                                 FROM thuoc A
                                          LEFT JOIN Thuoc_DonViTinh B ON A.iddvt=B.Id
	                                 WHERE A.ISTHUOCBV=1 AND IDTHUOC IN (SELECT idthuoc FROM chitietphieunhapkho A1
                                                         LEFT JOIN phieunhapkho B1 ON A1.idphieunhap=B1.idphieunhap
							                                WHERE 	B1.IDKHO=" + IdKho
                                                         + (this.FromDate != "" ? " AND B1.NGAYTHANG>='" + this.FromDate + "'" : "")
                                                         + (this.ToDate != "" ? " AND B1.NGAYTHANG<='" + this.ToDate + "'" : "")
                                                         + @" AND A1.idthuoc=A.idthuoc
                                                      )

	                                )

                                 UNION ALL
                                 (
	                                 SELECT LoaiNX=TenLoaiXuat
				                                , TENTHUOC
				                                ,TENDVT
				                                ,NGAYTHANG
				                                ,SoPhieu= ISNULL(B.SOPHIEUYC,   MaPhieuXuat)
				                                ,DOITUONG=dbo.Thuoc_Get_DoiTuongXuat(A.IdPhieuXuat)
				                                ,SOLUONG
				                                ,DONGIA=A.GIAVON
				                                ,THANHTIEN=A.TienVon
				                                ,TypeCode=2
				                                ,A.IDTHUOC

			                                 FROM CHITIETPHIEUXUATKHO A
				                                 LEFT JOIN PHIEUXUATKHO B ON A.IDPHIEUXUAT=B.IDPHIEUXUAT
				                                 LEFT JOIN THUOC C ON A.IDTHUOC=C.IDTHUOC
				                                 left join khachhang f on b.idkhachhang=f.idkhachhang
				                                 LEFT JOIN THUOC_DONVITINH G ON A." + Profess.TBLS.tbl_chitietphieuxuatkho.dvt.ToString() + @"=G.ID
				                                 LEFT JOIN thuoc_loaixuat H ON B.loaixuat=H.IDLoaixuat
			                                 WHERE  C.ISTHUOCBV=1 "
                                         + (this.FromDate != "" ? " AND B.NGAYTHANG>='" + this.FromDate + "'" : "")
                                         + (this.ToDate != "" ? " AND B.NGAYTHANG<='" + this.ToDate + "'" : "")
                                         + (IdKho2 != null && IdKho2 != "" && IdKho2 != "0" ? " AND IDKHO2=" + IdKho2 : "")
                                         + " AND  B.IDKHO=" + IdKho + @" 
                                )
                                 UNION ALL
	                                (
		                                 SELECT LoaiNX=N'Tổng Xuất'
			                                ,TENTHUOC
			                                ,TENDVT
			                                ,NGAYTHANG=GETDATE()
			                                ,SoPhieu=''
			                                ,DOITUONG=''
			                                ,SOLUONG=(SELECT sum(A1.soluong) FROM chitietphieuxuatkho A1
                                                         LEFT JOIN phieuxuatkho B1 ON A1.idphieuxuat=B1.idphieuxuat
							                                WHERE 	B1.IDKHO=" + IdKho + @" AND A1.idthuoc=A.idthuoc
                                            "
                                      + (IdKho2 != null && IdKho2 != "" && IdKho2 != "0" ? " AND IDKHO2=" + IdKho2 : "")
                                         + (this.FromDate != "" ? " AND B1.NGAYTHANG>='" + this.FromDate + "'" : "")
                                         + (this.ToDate != "" ? " AND B1.NGAYTHANG<='" + this.ToDate + "'" : "")
                                         + @" )
			                                ,DONGIA=0
			                                ,THANHTIEN=(SELECT sum(A1.THANHTIEN) FROM chitietphieuxuatkho A1
                                                         LEFT JOIN phieuxuatkho B1 ON A1.idphieuxuat=B1.idphieuxuat
							                                WHERE 	B1.IDKHO=" + IdKho + @" AND A1.idthuoc=A.idthuoc
                                                    "
                                         + (this.FromDate != "" ? " AND B1.NGAYTHANG>='" + this.FromDate + "'" : "")
                                         + (this.ToDate != "" ? " AND B1.NGAYTHANG<='" + this.ToDate + "'" : "")
                                         + @"
						                                )
			                                ,TypeCode=3
			                                ,A.IDTHUOC

	                                 FROM thuoc A
                                          LEFT JOIN Thuoc_DonViTinh B ON A.iddvt=B.Id
	                                 WHERE  A.ISTHUOCBV=1 AND IDTHUOC IN (SELECT idthuoc FROM chitietphieuxuatkho A1
                                                         LEFT JOIN phieuxuatkho B1 ON A1.idphieuxuat=B1.idphieuxuat
							                                WHERE 	B1.IDKHO=" + IdKho
                                                                 + (this.FromDate != "" ? " AND B1.NGAYTHANG>='" + this.FromDate + "'" : "")
                                                                 + (this.ToDate != "" ? " AND B1.NGAYTHANG<='" + this.ToDate + "'" : "")
                                                                 + @" AND A1.idthuoc=A.idthuoc
                                                      )

	                                ))
                                  AS TB 
                  LEFT JOIN THUOC TB2 ON TB.IDTHUOC=TB2.IDTHUOC
                    WHERE 1=1";


        if (this.TenThuoc != "")
            sql += " AND TB.TENTHUOC LIKE N'" + this.TenThuoc + "%'";

        if (this.LoaiThuocId != null && this.LoaiThuocId != "0")
            sql += " AND TB2.LOAITHUOCID=" + this.LoaiThuocId;
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt != null)
        {
            System.Collections.Generic.List<string> lstIdThuoc = new System.Collections.Generic.List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string IdThuoc = dt.Rows[i]["IdThuoc"].ToString();
                int n = lstIdThuoc.IndexOf(IdThuoc);
                if (n == -1)
                {

                    lstIdThuoc.Add(IdThuoc);
                    dt.Rows[i]["STT"] = lstIdThuoc.Count;
                }
                else
                {
                    dt.Rows[i]["STT"] = DBNull.Value;
                }
            }
        }
        return dt;
    }

    protected override string SetInputFileName() 
    {
        return "NhapXuatTon2.xls";
    }
    protected override string SetOutputFileName()
    {
        return "NhapXuatTon2.xls";
    }
    protected override string SetHeaderText()
    {
        return "BIÊN BẢN KIỂM NHẬP KHO";
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A2");
    }
    protected override bool SetIsSumByGroupValue() 
    {
        return true;
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("TypeCode");
        lst.Add("IDTHUOC");
        return lst;
    }
}
