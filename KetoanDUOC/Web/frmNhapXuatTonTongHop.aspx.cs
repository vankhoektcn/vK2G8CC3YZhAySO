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

public partial class QLDUOC_Web_frmNhapXuatTonTongHop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            this.bindkho();
        }
    }
    #region bind kho
    private void bindkho()
    {
        string tenkho = "";
        DataTable dt = DataAcess.Connect.GetTable("SELECT * FROM KHOTHUOC WHERE ISNULL(ISKT,0)=0 AND TENKHO LIKE N'" + tenkho + "%' ORDER BY TENKHO");
        if (dt != null && dt.Rows.Count > 0)
        {
            StaticData.FillCombo(ddlkho, dt, "idkho", "tenkho", "-------------Chọn kho------------");
            this.ddlkho.SelectedValue = StaticData.MacDinhKhoNhapMuaID;
        }

        StaticData.FillCombo(this.cbLoaiThuoc, Thuoc_Process.Thuoc_LoaiThuoc.dtGetAll(), "LoaiThuocID", "TenLoai", "Chọn đối tượng");
        cbLoaiThuoc.SelectedValue = "1";
    }
    #endregion

    protected void btnLayDanhSach_Click(object sender, EventArgs e)
    {
        if (this.ddlkho.SelectedValue == null || this.ddlkho.SelectedValue == "") return;
        string tungay = this.txtTuNgay.Text;
        if (tungay != "")
            tungay = StaticData.CheckDate(tungay);
        string denngay = this.txtDenNgay.Text;
        if (denngay != "")
            denngay = StaticData.CheckDate(denngay) + " 23:59:59";

        string IdKho = this.ddlkho.SelectedValue;
        string sql = @" SELECT STT=ROW_NUMBER() OVER (ORDER BY  TB.TENTHUOC,TB.IDTHUOC,TypeCode,NGAYTHANG) ,TB.*
                                 FROM 
                                 (
                                 (
                                   SELECT LoaiNX=TenLoaiNhap
			                                ,A.IDTHUOC
			                                ,TENTHUOC
			                                ,TENDVT
			                                ,NGAYTHANG
			                                ,SoPhieu=MaPhieuNhap
			                                ,DOITUONG=dbo.Thuoc_Get_DoiTuongNhap(A.IdPhieuNhap)
			                                ,SOLUONG
			                                ,DONGIA
			                                ,A.THANHTIEN
			                                ,TENTU,TENNGAN,TypeCode=0
	                                 FROM CHITIETPHIEUNHAPKHO A
		                                 LEFT JOIN PHIEUNHAPKHO B ON A.IDPHIEUNHAP=B.IDPHIEUNHAP
		                                 LEFT JOIN THUOC C ON A.IDTHUOC=C.IDTHUOC
		                                 LEFT JOIN TUTHUOC D ON A.IDTU=D.IDTU
		                                 LEFT JOIN NGAN E ON A.IDNGAN=E.IDNGAN
		                                 left join nhacungcap f on b.NHACUNGCAPID=f.NHACUNGCAPID
		                                 LEFT JOIN THUOC_DONVITINH G ON A." + Profess.TBLS.tbl_chitietphieunhapkho.dvt.ToString() + @"=G.ID
		                                 LEFT JOIN thuoc_loainhap H ON B.IdLoaiNhap=H.IDLoaiNhap
	                                 WHERE C.ISTHUOCBV=1 "
                                           + (tungay != "" ? " AND B.NGAYTHANG>='" + tungay + "'" : "")
                                            + (denngay != "" ? " AND B.NGAYTHANG<='" + denngay + "'" : "")
                                            + " AND  B.IDKHO=" + IdKho + @"
                                 )

                                 UNION
	                                (
		                                 SELECT LoaiNX=N'Tổng Nhập'
			                                ,A.IDTHUOC
			                                ,TENTHUOC
			                                ,TENDVT
			                                ,NGAYTHANG=null
			                                ,SoPhieu=''
			                                ,DOITUONG=''
			                                ,SOLUONG=(SELECT sum(A1.soluong) FROM chitietphieunhapkho A1
                                                         LEFT JOIN phieunhapkho B1 ON A1.idphieunhap=B1.idphieunhap
							                                WHERE 	B1.IDKHO=" + IdKho + @" AND A1.idthuoc=A.idthuoc
                                                            "
                                            + (tungay != "" ? " AND B1.NGAYTHANG>='" + tungay + "'" : "")
                                            + (denngay != "" ? " AND B1.NGAYTHANG<='" + denngay + "'" : "")
                                            + @")
			                                ,DONGIA=0
			                                ,THANHTIEN=(SELECT sum(A1.THANHTIEN) FROM chitietphieunhapkho A1
                                                         LEFT JOIN phieunhapkho B1 ON A1.idphieunhap=B1.idphieunhap
							                                WHERE 	B1.IDKHO=" + IdKho + @" AND A1.idthuoc=A.idthuoc
                                            "
                                            + (tungay != "" ? " AND B1.NGAYTHANG>='" + tungay + "'" : "")
                                            + (denngay != "" ? " AND B1.NGAYTHANG<='" + denngay + "'" : "")
                                            + @"
						                                )
			                                ,TENTU='',TENNGAN='',TypeCode=1
	                                 FROM thuoc A
                                          LEFT JOIN Thuoc_DonViTinh B ON A.iddvt=B.Id
	                                 WHERE A.ISTHUOCBV=1 AND IDTHUOC IN (SELECT idthuoc FROM chitietphieunhapkho A1
                                                         LEFT JOIN phieunhapkho B1 ON A1.idphieunhap=B1.idphieunhap
							                                WHERE 	B1.IDKHO=" + IdKho
                                                            + (tungay != "" ? " AND B1.NGAYTHANG>='" + tungay + "'" : "")
                                                            + (denngay != "" ? " AND B1.NGAYTHANG<='" + denngay + "'" : "")
                                                            + @" AND A1.idthuoc=A.idthuoc
                                                      )

	                                )

                                 UNION
                                 (
	                                 SELECT LoaiNX=TenLoaiXuat
				                                ,A.IDTHUOC
				                                , TENTHUOC
				                                ,TENDVT
				                                ,NGAYTHANG
				                                ,SoPhieu=MaPhieuXuat
				                                ,DOITUONG=dbo.Thuoc_Get_DoiTuongXuat(A.IdPhieuXuat)
				                                ,SOLUONG
				                                ,DONGIA=A.GIAVON
				                                ,THANHTIEN=A.TienVon
				                                ,TENTU,TENNGAN,TypeCode=0

			                                 FROM CHITIETPHIEUXUATKHO A
				                                 LEFT JOIN PHIEUXUATKHO B ON A.IDPHIEUXUAT=B.IDPHIEUXUAT
				                                 LEFT JOIN THUOC C ON A.IDTHUOC=C.IDTHUOC
				                                 LEFT JOIN TUTHUOC D ON A.IDTU=D.IDTU
				                                 LEFT JOIN NGAN E ON A.IDNGAN=E.IDNGAN
				                                 left join khachhang f on b.idkhachhang=f.idkhachhang
				                                 LEFT JOIN THUOC_DONVITINH G ON A." + Profess.TBLS.tbl_chitietphieuxuatkho.dvt.ToString() + @"=G.ID
				                                 LEFT JOIN thuoc_loaixuat H ON B.loaixuat=H.IDLoaixuat
			                                 WHERE  C.ISTHUOCBV=1 "
                                            + (tungay != "" ? " AND B.NGAYTHANG>='" + tungay + "'" : "")
                                            + (denngay != "" ? " AND B.NGAYTHANG<='" + denngay + "'" : "")
                                            + " AND  B.IDKHO=" + IdKho + @" 
                                )
                                 UNION
	                                (
		                                 SELECT LoaiNX=N'Tổng Xuất'
			                                ,A.IDTHUOC
			                                ,TENTHUOC
			                                ,TENDVT
			                                ,NGAYTHANG=null
			                                ,SoPhieu=''
			                                ,DOITUONG=''
			                                ,SOLUONG=(SELECT sum(A1.soluong) FROM chitietphieuxuatkho A1
                                                         LEFT JOIN phieuxuatkho B1 ON A1.idphieuxuat=B1.idphieuxuat
							                                WHERE 	B1.IDKHO=" + IdKho + @" AND A1.idthuoc=A.idthuoc
                                            "
                                            + (tungay != "" ? " AND B1.NGAYTHANG>='" + tungay + "'" : "")
                                            + (denngay != "" ? " AND B1.NGAYTHANG<='" + denngay + "'" : "")
                                            + @" )
			                                ,DONGIA=0
			                                ,THANHTIEN=(SELECT sum(A1.THANHTIEN) FROM chitietphieuxuatkho A1
                                                         LEFT JOIN phieuxuatkho B1 ON A1.idphieuxuat=B1.idphieuxuat
							                                WHERE 	B1.IDKHO=" + IdKho + @" AND A1.idthuoc=A.idthuoc
                                                    "
                                            + (tungay != "" ? " AND B1.NGAYTHANG>='" + tungay + "'" : "")
                                            + (denngay != "" ? " AND B1.NGAYTHANG<='" + denngay + "'" : "")
                                            + @"
						                                )
			                                ,TENTU='',TENNGAN='',TypeCode=2
	                                 FROM thuoc A
                                          LEFT JOIN Thuoc_DonViTinh B ON A.iddvt=B.Id
	                                 WHERE  A.ISTHUOCBV=1 AND IDTHUOC IN (SELECT idthuoc FROM chitietphieuxuatkho A1
                                                         LEFT JOIN phieuxuatkho B1 ON A1.idphieuxuat=B1.idphieuxuat
							                                WHERE 	B1.IDKHO=" + IdKho
                                                                    + (tungay != "" ? " AND B1.NGAYTHANG>='" + tungay + "'" : "")
                                                                    + (denngay != "" ? " AND B1.NGAYTHANG<='" + denngay + "'" : "")
                                                                    + @" AND A1.idthuoc=A.idthuoc
                                                      )

	                                ))
                                  AS TB 
                  LEFT JOIN THUOC TB2 ON TB.IDTHUOC=TB2.IDTHUOC
                    WHERE 1=1";


        if (this.txtTenThuoc.Text.Trim() != "")
            sql += " AND TB.TENTHUOC LIKE N'" + this.txtTenThuoc.Text.Trim() + "%'";

        if (this.cbLoaiThuoc.SelectedValue != null && this.cbLoaiThuoc.SelectedValue != "0")
            sql += " AND TB2.LOAITHUOCID=" + this.cbLoaiThuoc.SelectedValue;



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
                    // dt.Rows[i]["TenThuoc"] = DBNull.Value;
                }


            }
        }
        this.dgr.DataSource = dt;
        this.dgr.DataBind();
    }


    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }
        }

    }
}
