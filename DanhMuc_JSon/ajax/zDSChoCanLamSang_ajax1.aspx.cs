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

public partial class zDSChoCanLamSang_ajax : System.Web.UI.Page
{
    protected DataProcess s_zDSChoCanLamSang()
    {
        DataProcess zDSChoCanLamSang = new DataProcess("zDSChoCanLamSang");
        zDSChoCanLamSang.data("ID", Request.QueryString["idkhoachinh"]);
        zDSChoCanLamSang.data("IdKhoa", Request.QueryString["IdKhoa"]);
        zDSChoCanLamSang.data("TuNgay", Request.QueryString["TuNgay"]);
        zDSChoCanLamSang.data("DenNgay", Request.QueryString["DenNgay"]);
        zDSChoCanLamSang.data("MaCLS", Request.QueryString["MaCLS"]);
        zDSChoCanLamSang.data("MaBenhNhan", Request.QueryString["MaBenhNhan"]);
        zDSChoCanLamSang.data("TenBenhNhan", Request.QueryString["TenBenhNhan"]);
        zDSChoCanLamSang.data("GioiTinh", Request.QueryString["GioiTinh"]);
        zDSChoCanLamSang.data("NgaySinh", Request.QueryString["NgaySinh"]);
        zDSChoCanLamSang.data("BSChiDinh", Request.QueryString["BSChiDinh"]);
        zDSChoCanLamSang.data("SoBHYT", Request.QueryString["SoBHYT"]);
        return zDSChoCanLamSang;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["do"];
        switch (action)
        {
            case "TimKiem": TimKiem(); break;
            case "IdKhoaSearch": IdKhoaSearch(); break;
        }
    }

    private void IdKhoaSearch()
    {
        string sql = "select pk.* from phongkhambenh pk ";
        if (SysParameter.UserLogin.IdBacSi(this) != null && SysParameter.UserLogin.IdBacSi(this) != "")
        {
            sql += "inner join bacsi_phongkham bspk on bspk.idphongkhambenh = pk.idphongkhambenh where  pk.loaiphong = 1 and bspk.idbacsi=" + SysParameter.UserLogin.IdBacSi(this).ToString() + "";
        }
        else
        {
            sql += "where pk.loaiphong = 1 order by pk.tenphongkhambenh";
        }
        DataTable table = DataProcess.GetTable(sql);
        StringBuilder html = new StringBuilder();
        if (table != null)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    html.AppendLine(table.Rows[i]["tenphongkhambenh"].ToString() + "|" + table.Rows[i][0].ToString());

                }
            }
        }
        Response.Clear(); Response.Write(html);
    }
    private void TimKiem()
    {
        DataProcess process = s_zDSChoCanLamSang();
        process.EnablePaging = false;
        string tungay = !string.IsNullOrEmpty(Request.QueryString["TuNgay"]) ? StaticData.CheckDate(Request.QueryString["TuNgay"]) : DateTime.Now.ToString("MM/dd/yyyy");
        string denngay = !string.IsNullOrEmpty(Request.QueryString["DenNgay"]) ? StaticData.CheckDate(Request.QueryString["DenNgay"]) + " 23:59:59" : DateTime.Now.ToString("MM/dd/yyyy") + " 23:59:59";
        string sql = "";
        if (string.IsNullOrEmpty(Request.QueryString["isDaCLS"]) || Request.QueryString["isDaCLS"].ToString().Equals("0"))
        {
            sql = @"
        select STT=row_number() over (order by TuNgay),* from 
        (   
                 (select distinct isNewCLS=0,cls.idkhambenh
	                ,IdKhoa=p.idphongkhambenh,p.tenphongkhambenh
	                ,TuNgay=convert(varchar(10),NgayThu,103)
	                ,MaCLS=cls.maphieuCLS
	                ,MaBenhNhan
	                ,TenBenhNhan
	                ,GioiTinh=case when isnull(gioitinh,0)=0 then 'Nam' else N'Nữ' end
	                ,NgaySinh
	                ,BSChiDinh= isnull((select top 1 tenbacsi from khambenh kb left join bacsi bs on bs.idbacsi=kb.idbacsi where kb.idkhambenh =cls.idkhambenh ),'')
	                ,idbacsi= (select top 1 idbacsi from khambenh where idkhambenh =cls.idkhambenh )
                    ,p.maphongkhambenh
                from khambenhcanlamsan cls inner join benhnhan BN   on cls.IDBenhNhan=BN.IDBenhNhan 
	                left join banggiadichvu bg on bg.idbanggiadichvu = cls.idcanlamsan 
	                left join phongkhambenh p on p.idphongkhambenh =bg.idphongkhambenh
                    left join khambenh kb on kb.idkhambenh =cls.idkhambenh
                where cls.dahuy=0 and cls.dakham=0 and isnull(kb.isxetnghiem,0)<>1
	                and cls.NgayThu >= '" + tungay + @"'
	                and cls.NgayThu <= '" + denngay + @"'
	                " + (!string.IsNullOrEmpty(Request.QueryString["IdKhoa"]) && !Request.QueryString["IdKhoa"].ToString().Equals("null") ? "and bg.idphongkhambenh ='" + Request.QueryString["IdKhoa"] + "'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["MaCLS"]) ? "and cls.madangkycls ='" + Request.QueryString["MaCLS"] + "'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["MaBenhNhan"]) ? "and bn.mabenhnhan like N'%" + Request.QueryString["MaBenhNhan"] + "%'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["TenBenhNhan"]) ? "and bn.tenbenhnhan like N'%" + Request.QueryString["TenBenhNhan"] + "%'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["BSChiDinh"]) ? "and cls.tenBSChiDinh like N'%" + Request.QueryString["BSChiDinh"] + "%'" : "") + @"
                )
            union all
            (select distinct isNewCLS=1,kb.idkhambenh
	                ,IdKhoa=" + Request.QueryString["IdKhoa"] + @"
                    ,tenphongkhambenh=(select tenphongkhambenh from phongkhambenh where idphongkhambenh ='" + Request.QueryString["IdKhoa"] + @"' )
	                ,TuNgay=convert(varchar(10),ngaykham,103)
	                ,MaCLS=isnull((select top 1 maphieuCLS from khambenhcanlamsan where idkhambenh =kb.idkhambenh and dahuy=0 and dakham=0),'') 
	                ,MaBenhNhan
	                ,TenBenhNhan
	                ,GioiTinh=case when isnull(bn.gioitinh,0)=0 then 'Nam' else N'Nữ' end
	                ,bn.NgaySinh
	                ,BSChiDinh= tenbacsi
	                ,bs.idbacsi
                    ,maphongkhambenh=(select maphongkhambenh from phongkhambenh where idphongkhambenh ='" + Request.QueryString["IdKhoa"] + @"' )
                from khambenh kb inner join benhnhan BN   on kb.IDBenhNhan=BN.IDBenhNhan
	                left join phongkhambenh p on p.idphongkhambenh= kb.idphongkhambenh
				    left join bacsi bs on bs.idbacsi= kb.idbacsi
                where kb.isxetnghiem=1
	                and kb.NgayKham >= '" + tungay + @"'
	                and kb.NgayKham <= '" + denngay + @"'
	                " + (!string.IsNullOrEmpty(Request.QueryString["MaBenhNhan"]) ? "and bn.mabenhnhan like N'%" + Request.QueryString["MaBenhNhan"] + "%'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["TenBenhNhan"]) ? "and bn.tenbenhnhan like N'%" + Request.QueryString["TenBenhNhan"] + "%'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["BSChiDinh"]) ? "and bs.tenbacsi like N'%" + Request.QueryString["BSChiDinh"] + "%'" : "") + @"
				    --and not exists( select top 1 1 from khambenhcanlamsan cls left join banggiadichvu bg on bg.idbanggiadichvu=cls.idcanlamsan where idkhambenh=kb.idkhambenh and bg.idphongkhambenh ='" + Request.QueryString["IdKhoa"] + @"')
                )
        ) as abc";
        }
        else
        {
            sql = @"select distinct STT=row_number() over (order by TuNgay),* from 
            (select distinct   KQ.idketqua_canlamsang
                    ,isNewCLS=0,cls.idkhambenh
	                ,IdKhoa=p.idphongkhambenh,p.tenphongkhambenh
	                ,TuNgay=convert(varchar(10),NgayThu,103)
	                ,MaCLS=cls.maphieuCLS
	                ,MaBenhNhan
	                ,TenBenhNhan
	                ,GioiTinh=case when isnull(gioitinh,0)=0 then 'Nam' else N'Nữ' end
	                ,NgaySinh
	                ,BSChiDinh= isnull((select top 1 tenbacsi from khambenh kb left join bacsi bs on bs.idbacsi=kb.idbacsi where kb.idkhambenh =cls.idkhambenh ),'')
	                ,idbacsi= (select top 1 idbacsi from khambenh where idkhambenh =cls.idkhambenh )
                    ,p.maphongkhambenh
                from khambenhcanlamsan cls inner join benhnhan BN   on cls.IDBenhNhan=BN.IDBenhNhan 
	                inner join ketqua_canlamsang kq on kq.madangkycls= cls.madangkycls
	                left join banggiadichvu bg on bg.idbanggiadichvu = cls.idcanlamsan 
	                left join phongkhambenh p on p.idphongkhambenh =bg.idphongkhambenh
                    left join khambenh kb on kb.idkhambenh =cls.idkhambenh
                where cls.dahuy=0 and cls.dakham=1 
	                and cls.NgayThu >= '" + tungay + @"'
	                and cls.NgayThu <= '" + denngay + @"'
	                " + (!string.IsNullOrEmpty(Request.QueryString["IdKhoa"]) && !Request.QueryString["IdKhoa"].ToString().Equals("null") ? "and bg.idphongkhambenh ='" + Request.QueryString["IdKhoa"] + "'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["MaCLS"]) ? "and cls.madangkycls ='" + Request.QueryString["MaCLS"] + "'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["MaBenhNhan"]) ? "and bn.mabenhnhan like N'%" + Request.QueryString["MaBenhNhan"] + "%'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["TenBenhNhan"]) ? "and bn.tenbenhnhan like N'%" + Request.QueryString["TenBenhNhan"] + "%'" : "") + @"
	                " + (!string.IsNullOrEmpty(Request.QueryString["BSChiDinh"]) ? "and cls.tenBSChiDinh like N'%" + Request.QueryString["BSChiDinh"] + "%'" : "") + @"
            ) as abc";
        }
        DataTable table = process.Search(sql);
        string head = "\"\":\"\""
            + ",\"IDKHOA\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdKhoa") + "\""
            + ",\"TUNGAY\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TuNgay") + "\""
            + ",\"DENNGAY\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("DenNgay") + "\""
            + ",\"MACLS\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaCLS") + "\""
            + ",\"MABENHNHAN\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("MaBenhNhan") + "\""
            + ",\"TENBENHNHAN\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenBenhNhan") + "\""
            + ",\"GIOITINH\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("GioiTinh") + "\""
            + ",\"NGAYSINH\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgaySinh") + "\""
            + ",\"BSCHIDINH\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("BSChiDinh") + "\""
            + ",\"SOBHYT\":\"" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoBHYT") + "\""
   + "";
        Response.Clear(); Response.Write(DataProcess.JSONDataTable_Parameters(table, head));
    }
}


