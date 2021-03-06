using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod]
    public string[] getICD(string prefixText, int count)
    {
        List<string> responses = new List<string>();
            string swhere = "";
            
             swhere += " AND MoTa LIKE N'" + prefixText + "%'";
            

           DataTable  arr =DataAcess.Connect.GetTable("SELECT top(100)* FROM ChanDoanICD WHERE 1 =1 " + swhere + "");
           if (arr.Rows.Count > 0)
           {
               foreach (DataRow h in arr.Rows)
               {
                   responses.Add(h["IDICD"] + "@" + h["MaICD"] + "@" + h["MoTa"]);
               }

           }
           else
           {
               responses.Add(" @ @ ");
           }
 
        return responses.ToArray();
    }

    [WebMethod]
    [ScriptMethod]
    public string[] getMaICD(string prefixText, int count)
    {
        List<string> responses = new List<string>();
        string swhere = "";

        swhere += " AND MaICD LIKE N'" + prefixText + "%'";


        DataTable arr = DataAcess.Connect.GetTable("SELECT top(100)* FROM ChanDoanICD WHERE 1 =1 " + swhere + "");
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                responses.Add(h["IDICD"] + "@" + h["MaICD"] + "@" + h["MoTa"]);
            }

        }
        else
        {
            responses.Add(" @ @ ");
        }
        
        return responses.ToArray();
    }
    // Bệnh Viện 
    [WebMethod]
    [ScriptMethod]
    public string[] getTenBenhVien(string prefixText, int count)
    {
        List<string> responses = new List<string>();
        string swhere = "";

        swhere += " AND tenbenhvien LIKE N'%" + prefixText + "%'";


        DataTable arr = DataAcess.Connect.GetTable("SELECT * FROM benhvien WHERE 1 =1 " + swhere + " order by tenbenhvien");
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                responses.Add(h["idbenhvien"] + "@" + h["mabenhvien"] + "@" + h["tenbenhvien"]);
            }

        }
        else
        {
            responses.Add(" @ @ ");
        }

        return responses.ToArray();
    }

    [WebMethod]
    [ScriptMethod]
    public string[] getMaBenhVien(string prefixText, int count)
    {
        List<string> responses = new List<string>();
        string swhere = "";

        swhere += " AND mabenhvien LIKE N'" + prefixText + "%'";


        DataTable arr = DataAcess.Connect.GetTable("SELECT * FROM benhvien WHERE 1 =1 " + swhere + "  order by mabenhvien, tenbenhvien");
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                responses.Add(h["idbenhvien"] + "@" + h["mabenhvien"] + "@" + h["tenbenhvien"]);
            }

        }
        else
        {
            responses.Add(" @ @ ");
        }

        return responses.ToArray();
    }
    // Noi Gioi Thieu 
    #region
    [WebMethod]
    [ScriptMethod]
    public string[] getTenGioiThieu(string prefixText, int count)
    {
        List<string> responses = new List<string>();
        string swhere = "";

        swhere += " AND tennoidangky LIKE N'%" + prefixText + "%'";


        DataTable arr = DataAcess.Connect.GetTable("SELECT * FROM kb_noidangkykb WHERE 1 =1 " + swhere + " order by tennoidangky");
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                responses.Add(h["IDNOIDANGKY"] + "@" + h["MASO"] + "@" + h["tennoidangky"]);
            }

        }
        else
        {
            responses.Add(" @ @ ");
        }

        return responses.ToArray();
    }

    [WebMethod]
    [ScriptMethod]
    public string[] getMaGioiThieu(string prefixText, int count)
    {
        List<string> responses = new List<string>();
        string swhere = "";

        swhere += " AND MASO LIKE N'" + prefixText + "%'";


        DataTable arr = DataAcess.Connect.GetTable("SELECT * FROM kb_noidangkykb WHERE 1 =1 " + swhere + "  order by MASO, tennoidangky");
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                responses.Add(h["idbenhvien"] + "@" + h["MASO"] + "@" + h["tennoidangky"]);
            }

        }
        else
        {
            responses.Add(" @ @ ");
        }

        return responses.ToArray();
    }
 #endregion

    //Nghe nghiep 
    #region
    [WebMethod]
    [ScriptMethod]
    public string[] getTenNgheNghiep(string prefixText, int count)
    {
        List<string> responses = new List<string>();
        string swhere = "";

        swhere += " AND TenNgheNghiep LIKE N'%" + prefixText + "%'";


        DataTable arr = DataAcess.Connect.GetTable("SELECT * FROM NgheNghiep WHERE 1 =1 " + swhere + "  order by TenNgheNghiep");
        if (arr.Rows.Count > 0)
        {
            foreach (DataRow h in arr.Rows)
            {
                responses.Add(h["idNgheNghiep"] + "@" + h["TenNgheNghiep"]);
            }

        }
        else
        {
            responses.Add(" @ @ ");
        }

        return responses.ToArray();
    }
    [WebMethod]
    [ScriptMethod]
    public string[] getNoiGioThieu(string prefixText, int count)
    {
              List<string> responses = new List<string>();
              string swhere = "";
              swhere += " AND tennoidangky LIKE N'%" + prefixText + "%'";
              DataTable arr = DataAcess.Connect.GetTable("SELECT * FROM KB_NOIDANGKYKB WHERE 1 =1 " + swhere + "  order by tennoidangky");
              if (arr.Rows.Count > 0)
              {
                  foreach (DataRow h in arr.Rows)
                  {
                      responses.Add(h["IDNOIDANGKY"] + "@" + h["MASO"] + "@" + h["TENNOIDANGKY"]);
                  }
              }
              else
              {
                  responses.Add(" @ @ ");
              }
              return responses.ToArray(); 
    }
    #endregion
}

