<%@ WebHandler Language="C#" Class="benhnhanbhdongtien" %>

using System;
using System.Web;
using System.Data;
public class benhnhanbhdongtien : IHttpHandler
{
    HttpResponse _resq = HttpContext.Current.Response;
    protected DataProcess s_Z_BENHNHANBHDT()
    {
        DataProcess Z_BENHNHANBHDT = new DataProcess("Z_BENHNHANBHDT");
        Z_BENHNHANBHDT.data("ID", HttpContext.Current.Request.QueryString["idkhoachinh"]);
        Z_BENHNHANBHDT.data("HOTENBN", HttpContext.Current.Request.QueryString["HOTENBN"]);
        Z_BENHNHANBHDT.data("NGAYTINHBH", HttpContext.Current.Request.QueryString["NGAYTINHBH"]);
        Z_BENHNHANBHDT.data("ISBHYT", HttpContext.Current.Request.QueryString["ISBHYT"]);
        Z_BENHNHANBHDT.data("TONGTIENBNPT", HttpContext.Current.Request.QueryString["TONGTIENBNPT"]);
        Z_BENHNHANBHDT.data("TONGTIENBNDATRA", HttpContext.Current.Request.QueryString["TONGTIENBNDATRA"]);
        Z_BENHNHANBHDT.data("TONGTIENBNPTCONLAI", HttpContext.Current.Request.QueryString["TONGTIENBNPTCONLAI"]);
        Z_BENHNHANBHDT.data("MABENHNHAN", HttpContext.Current.Request.QueryString["MABENHNHAN"]);
        Z_BENHNHANBHDT.data("NGAYSINH", HttpContext.Current.Request.QueryString["NGAYSINH"]);
        Z_BENHNHANBHDT.data("GIOITINH", HttpContext.Current.Request.QueryString["GIOITINH"]);
        Z_BENHNHANBHDT.data("KHOA", HttpContext.Current.Request.QueryString["KHOA"]);
        Z_BENHNHANBHDT.data("USERID", HttpContext.Current.Request.QueryString["USERID"]);
        return Z_BENHNHANBHDT;
    }
    public void ProcessRequest(HttpContext context)
    {
        string action = context.Request.QueryString["do"];
        switch (action)
        {
            case "layds": layds();
                break;
        }
    }
    private void layds()
    {
        string tungay = HttpContext.Current.Request.QueryString["tungay"];
        string denngay = HttpContext.Current.Request.QueryString["denngay"];
        string mabn = HttpContext.Current.Request.QueryString["mabn"];
        string hotenbn = HttpContext.Current.Request.QueryString["hotenbn"];
        tungay = StaticData.CheckDate(tungay);
        denngay = StaticData.CheckDate(denngay) + " 23:59:59";
        string USERID = HttpContext.Current.Request.QueryString["userid"];
        string SQL_ = @"DELETE FROM Z_BENHNHANBHDT	WHERE USERID=" + USERID + @"			
                        INSERT INTO Z_BENHNHANBHDT
                        SELECT A.ID,
                               A.HOTENBN,
                               A.NGAYTINHBH,
                               A.ISBHYT,
                               A.TONGTIENBNPT,
                               TONGTIENBNDATRA=ISNULL(A.TONGTIENBNDATRA,0)
                            ,TONGTIENBNPTCONLAI=ISNULL(TONGTIENBNPTCONLAI,0)
                            ,B.MABENHNHAN
                            ,B.NGAYSINH
                            ,GIOITINH=DBO.GETGIOITINH(B.GIOITINH)
                            ,KHOA=ISNULL(DBO.HB_KHOADANGKY2(A.IDKHAMBENH_LAST),DBO.HB_KHOADANGKY3(A.ID))
			                ,USERID=" + USERID + @"      
                        FROM HS_BENHNHANBHDONGTIEN A 
                            LEFT JOIN BENHNHAN B ON A.IDBENHNHAN=B.IDBENHNHAN            
                        WHERE 1=1";
        if (tungay != null && tungay != "")
        {
            SQL_ += " AND NGAYTINHBH>='" + tungay + "'";
        }
        if (denngay != null && denngay != "")
        {
            SQL_ += " AND NGAYTINHBH <='" + denngay + "'";
        }
        if (mabn != null && mabn != "")
        {
            SQL_ += " AND MABENHNHAN='" + mabn + "'";
        }
        if (hotenbn != null && hotenbn != "")
        {
            SQL_ += " AND HOTENBN LIKE N'%" + hotenbn + "%'";
        }
        bool OK = DataAcess.Connect.ExecSQL(SQL_);
        DataProcess process = s_Z_BENHNHANBHDT();
        process.EnablePaging = false;
        DataTable table = process.Search(@"select STT=row_number() over (order by T.ID),T.*
                               from Z_BENHNHANBHDT T
          where USERID=" + USERID);
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write(DataProcess.JSONDataTable_Parameters(table));
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}