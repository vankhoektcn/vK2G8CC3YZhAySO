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
public class profess_Rpt_Thuoc : ExportToExcel.Profess_ExportToExcelByCode
{
    public string LoaiThuocID = null;
    public string CateID = null;
    public string NhomThuocID = null;
    public string IsTHTT = null;
    public string IsTGN = null;
    public string ISTDTL = null;
    public string ISTPX = null;
    public string ISTcorticoid = null;
    public string ISTKS = null;
    public string IsDTUT = null;
    public string sudungchobh = null;
    public bool IsOrderByName = false;
    public string IsThuocBV = "1";
    public string IsQPTBH = "0";
    public profess_Rpt_Thuoc()
    {
        this.IsDeleteTotalRow = true;
    }
    public override DataTable getViewTable() // bắt buộc
    {
        string select = @"select
                                TTHoatChat
                                ,STT =1
                                , tenthuoc 
                                ,hoatchat=CongThuc 
                                ,tenDVT
                                ,DONGIA=NULL
                                ,LOSANXUAT=NULL
                                ,NGAYHETHAN=NULL
                                ,TENNUOCSX
                                ,CateName=ISNULL(d.des +'.','') + ISNULL(D.CateName,'')
                                ,GroupName=ISNULL(c.MaNhom +'.','')+ ISNULL(tennhom,''),d.DES
                                from thuoc b 
                                left join hs_thuocnhom TN ON B.IDTHUOC=TN.IDTHUOC
                                left join nhomthuoc c on c.idnhomthuoc=TN.idnhomthuoc
                                left join category d on d.cateid=TN.cateid
                                LEFT JOIN THUOC_DONVITINH E ON B.IDDVT=E.ID
                                LEFT JOIN NUOCSX F ON B.IDNUOCSANXUAT=F.IDNUOCSX
                                where ISNULL( ISTHUOCBV,0)="+IsThuocBV;
        if (this.LoaiThuocID != null && this.LoaiThuocID != "")
            select += " AND b.loaithuocid='" + this.LoaiThuocID + "'";
        if (CateID != null && CateID != "")
                select += " AND TN.cateid = '" + CateID + "'";
            if (this.NhomThuocID != null && NhomThuocID != "")
                select += " AND TN.IDNHOMTHUOC = '" + NhomThuocID + "'";
        if (IsTHTT != null)
        {
            if (StaticData.IsCheck(IsTHTT))
                select += " AND  B.IsTHTT=1";
            else
                select += " AND ISNULL(B.IsTHTT,0)=0";
        }

        if (IsTGN != null)
        {
            if (StaticData.IsCheck(IsTGN))
                select += " AND  B.IsTGN=1";
            else
                select += " AND ISNULL(B.IsTGN,0)=0";
        }
        if (ISTDTL != null)
        {
            if (StaticData.IsCheck(ISTDTL))
                select += " AND  B.ISTDTL=1";
            else
                select += " AND ISNULL(B.ISTDTL,0)=0";
        }
        if (ISTPX != null)
        {
            if (StaticData.IsCheck(ISTPX))
                select += " AND  B.ISTPX=1";
            else
                select += " AND ISNULL(B.ISTPX,0)=0";
        }
        if (ISTcorticoid != null)
        {
            if (StaticData.IsCheck(ISTcorticoid))
                select += " AND  B.ISTcorticoid=1";
            else
                select += " AND ISNULL(B.ISTcorticoid,0)=0";
        }
        if (ISTKS != null)
        {
            if (StaticData.IsCheck(ISTKS))
                select += " AND  B.ISTKS=1";
            else
                select += " AND ISNULL(B.ISTKS,0)=0";
        }

        if (IsDTUT != null)
        {
            if (StaticData.IsCheck(IsDTUT))
                select += " AND  B.IsDTUT=1";
            else
                select += " AND ISNULL(B.IsDTUT,0)=0";
        }
        if (sudungchobh != null)
        {
            if (StaticData.IsCheck(sudungchobh))
                select += " AND  B.sudungchobh=1";
            else
                select += " AND ISNULL(B.sudungchobh,0)=0";
        }
        if (IsQPTBH == "1")
        {
            select += " and b.sudungchobh=1 and b.isngoaitru=1";
        }
        DataTable dt = DataAcess.Connect.GetTable(select);
        if (dt.Columns.IndexOf("DES1") == -1)
            dt.Columns.Add("DES1", dt.Columns.Count.GetType());
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["DES1"] = StaticData.DoiTuSoLaMaSangInt(dt.Rows[i]["DES"].ToString());
        }

        if (!IsOrderByName)
        {
            dt.DefaultView.Sort = "DES1,GroupName,tenthuoc";
            if(LoaiThuocID=="1")
                dt.DefaultView.Sort = "DES1,GroupName,hoatchat, tenthuoc";
        }
        else
            dt.DefaultView.Sort = "tenthuoc";

        dt = dt.DefaultView.ToTable();
        for (int i = 0; i < dt.Rows.Count; i++)
            dt.Rows[i]["STT"] = i + 1;

        return dt;
    }
    protected override string SetInputFileName() // bắt buộc
    {
        if (this.LoaiThuocID == "2") return "DanhMucHoaChat.xls";
        if (this.LoaiThuocID == "3") return "DanhMucDungCu.xls";
        if (this.LoaiThuocID == "4") return "DanhMucVTYT.xls";
        return "DanhMucThuoc.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override string SetOutputFileName()
    {
        if (this.LoaiThuocID == "2") return "DanhMucHoaChat.xls";
        if (this.LoaiThuocID == "4") return "DanhMucVTYT.xls";
        if (this.LoaiThuocID == "3") return "DanhMucDungCu.xls";
        return "DanhMucThuoc.xls";//TÊN FIE GỐC TƯƠNG ĐƯƠNG VỚI CRYTAL REPORT
    }
    protected override ExportToExcel.CellIndex SetStartDataIndex()
    {
        return GetCellIndex("A7");//VỊ TRÍ DÒNG 1 , CỘT 1 CỦA DỮ LIỆU SẼ XUẤT RA
    }
    protected override System.Collections.Generic.List<string> SetListHidenColumnName()// dùng cho những trường ko thể hiện ra trong Excel so với câu select
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        lst.Add("CateName");
        lst.Add("GroupName");
        lst.Add("DES1");
        lst.Add("DES");
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListGroupName()// cho phép Group by theo những cột nào
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        if (!this.IsOrderByName)
        {
            lst.Add("CateName"); 
            lst.Add("GroupName"); 
        }
        return lst;
    }
    protected override System.Collections.Generic.List<string> SetListSumColumnName() // hàm cho phép tính tổng cộng trên những cột nào => có thể ko có hàm 
    {
        System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
        if (!this.IsOrderByName)
            lst.Add("DONGIA");
        return lst;
    }
    protected override bool SetIsSumByGroupValue() /// cho phép tính tổng trên group hay ko
    {
        return true;
    }
}
