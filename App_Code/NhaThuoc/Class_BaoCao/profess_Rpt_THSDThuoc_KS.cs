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
public class  profess_Rpt_THSDThuoc_KS : ExportToExcel.Profess_ExportToExcelByCode
{
    public string TTHoatChat = null;
    public string TenHoatChat = null;
    public string BietDuoc = null;
    public string TenNhom = null;
    public string CateName = null;
    

    public  profess_Rpt_THSDThuoc_KS()
    {
        this.IsDeleteTotalRow = true;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string select = @"   select        
                                TTHC='1'
                                ,hoatchat=CongThuc,MaATC='',TTBD=''
                                ,BietDuoc=tenthuoc
                                ,NUOCSX =TENHANGSANXUAT
                                ,NONGDOHL=TENTHUOC
                                ,tenDVT
                                ,DUONGDUNG=TenCachDung
                                ,SoLuong=(SELECT SUM(SOLUONG) 
                                                FROM CHITIETPHIEUXUATKHO A1 
                                                    LEFT JOIN PHIEUXUATKHO B1 ON A1.IDPHIEUXUAT=B1.IDPHIEUXUAT
                                                WHERE B1.IDKHO=4 AND NGAYTHANG>='"+this.FromDate +"' and NgayThang<='"+this.ToDate+"'"
                                               + @" AND IDTHUOC=A.IDTHUOC    
                                          )
                                ,DonGia=DBO.Thuoc_GetDonGiaNhap(A.IdThuoc,'"+this.ToDate+"')"
        + @"
                      FROM THUOC A 
                      LEFT JOIN THUOC_DONVITINH B ON A.IDDVT=B.ID
                      LEFT JOIN THUOC_CACHDUNG C ON A.IDCACHDUNG=C.IDCACHDUNG
                      LEFT JOIN HANGSANXUAT D ON A.IDHANGSANXUAT=B.ID
                      WHERE A.ISTHUOCBV=1 AND LOAITHUOCID=1 AND ISTKS=1 ";

        if (this.TTHoatChat != null && this.TTHoatChat != "")
            select += " AND A.TTHOATCHAT='" + this.TTHoatChat + "'";
        if (this.TenHoatChat != null && this.TenHoatChat != "")
            select += " AND A.CONGTHUC LIKE N'%" + this.TenHoatChat + "%'";
        if (this.BietDuoc != null && this.BietDuoc != "")
            select += " AND A.TENTHUOC LIKE  N'%" + this.BietDuoc + "%'";
        if (this.TenNhom != null && this.TenNhom != "")
            select += " AND A.TenNhom LIKE  N'%" + this.TenNhom + "%'";

        if (this.CateName != null && this.CateName != "")
            select += " AND A.catename LIKE  N'%" + this.CateName + "%'";

        select += " ORDER BY CONGTHUC,TENTHUOC";

        DataTable dt = DataAcess.Connect.GetTable(select);
        if (dt != null)
        {
            #region Xu ly bietduoc
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               
                string bietduoc = dt.Rows[i]["BietDuoc"].ToString();

                int n = -1;
                for (int j = 0; j < bietduoc.Length; j++)
                {
                    if (char.IsNumber(bietduoc[j]))
                    {
                        n = j;
                        break;
                    }
                }
                if (n != -1)
                {
                    string nongdo = bietduoc.Substring(n, bietduoc.Length - n );
                    dt.Rows[i]["BietDuoc"] = bietduoc.Substring(0, n );
                    dt.Rows[i]["NongDoHL"] = nongdo;
                }


            }
            #endregion
            #region Xu ly hoat chat
            System.Collections.Generic.List<string> lstHC = new System.Collections.Generic.List<string>();
            int ii = 0;
            while(ii<dt.Rows.Count)
            {
               
                string Hoatchat=dt.Rows[ii]["Hoatchat"].ToString();
                if (lstHC.IndexOf(Hoatchat) == -1)
                {
                   
                    lstHC.Add(Hoatchat);
                    dt.Rows[ii]["TTHC"] = lstHC.Count.ToString();
                    dt.Rows[ii]["TTBD"] = lstHC.Count.ToString() + ".1";
                    int j = ii + 1;
                    int k = 2;
                    while (j < dt.Rows.Count)
                    {
                        if (dt.Rows[j]["hoatchat"].ToString() == Hoatchat)
                        {
                            dt.Rows[j]["TTHC"] = lstHC.Count.ToString();
                            dt.Rows[j]["TTBD"] = lstHC.Count.ToString() + "." + k.ToString();
                            k++;
                            j++;
                        }
                        else
                            break;
                    }
                    ii += k - 1;
                }
                 

            }
            #endregion
        }
        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
       return "PhuLuc05.xls";
    }
    protected override string SetOutputFileName() 
    {
        return "PhuLuc05.xls";
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
   
   
    protected override System.Collections.Generic.List<string> SetListColumnMergeRow()
    {
        System.Collections.Generic.List<string> lstC = new System.Collections.Generic.List<string>();
        lstC.Add("TTHC");
            lstC.Add("hoatchat");
            lstC.Add("BietDuoc");
        return lstC;
    }
    protected override string[] SetListColumnFixValues()
    {
        string[] a = new string[] {"DonGia" };
        return a;
    }
     
  
    protected override System.Collections.Generic.List<ExportToExcel.CellIndex> SetListOtherIndex()
    {
        System.Collections.Generic.List<ExportToExcel.CellIndex> lst = new System.Collections.Generic.List<ExportToExcel.CellIndex>();
        lst.Add(GetCellIndex("D3"));
        return lst;
    }
    protected override System.Collections.Generic.List<object> SetListOtherValue()
    {
        string timeD = StaticData.TimeDescription(this.FromDate, this.ToDate);
        System.Collections.Generic.List<object> lst = new System.Collections.Generic.List<object>();
        lst.Add(timeD);
        return lst;

    }
    
     
    
}
