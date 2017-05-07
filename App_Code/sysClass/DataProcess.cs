using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for DataProcess
/// </summary>
public class DataProcess : IUDSCollection.IUDCollections
{
    public DataProcess(string tableName)
        : base(tableName)
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string Paging(string tableName)
    {
        string html = this.Pagingfunc("loadTableAjax" + tableName + "($.mkv.queryString(\"idkhoachinh\"),$(this).text())");
        return html;
    }

    public string Paging()
    {
        string html = this.Pagingfunc("Find(this,$(this).text())");
        return html;
    }
    public static DataTable GetTable(string sqlSelect)
    {
        return DataAcess.Connect.GetTable(sqlSelect);
    }
}
