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
 using System.Threading;
 
 public partial class catruc : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
          Page.DataBind(); 
         gettable("select *,ROW_NUMBER() OVER (ORDER BY idcatruc) AS STT from catruc");
     }
 
 public void gettable(string sql)
     {
         DataTable table = DataAcess.Connect.GetTable(sql);
         if (table.Rows.Count > 0)
         {
             gridTable.DataSource = table;
             gridTable.DataBind();
         }
         else
         {
             DataRow row = table.NewRow();
             table.Rows.Add(row);
             gridTable.DataSource = table;
             gridTable.DataBind();
         }
     }
 protected void gridTable_RowDataBound(object sender, GridViewRowEventArgs e)
     {
 if (e.Row.RowType == DataControlRowType.DataRow)
         {
             e.Row.Attributes.Add("onmouseover", "if(this.style.backgroundColor != 'red'){this.style.backgroundColor='#F6EBCD',this.style.cursor = 'pointer'}");
             e.Row.Attributes.Add("onmouseout", "if(this.style.backgroundColor != 'red'){this.style.backgroundColor='White'}");
         }
  if (e.Row.RowType == DataControlRowType.Header)
         {
             for(int i=0;i<e.Row.Cells.Count;i++){
                 e.Row.Cells[i].Text = hsLibrary.clDictionaryDB.sGetValueLanguage(e.Row.Cells[i].Text);
             }
         }
     }
     protected void gridTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         gridTable.PageIndex = e.NewPageIndex;
         gettable(HiddenField2.Value);
     }
     public bool checks(object text)
     {
         if (text == null) return false;
         if (text.ToString() == "1" || text.ToString().ToLower() == "true") return true;
         return false;
     }
 
     public string coverdate(object date)
     {
         return String.Format("{0:dd/MM/yyyy}", date);
     }
     protected void Button1_Click(object sender, EventArgs e)
     {
         if (HiddenField1.Value != "")
         {
try{
             HiddenField2.Value = "select *,ROW_NUMBER() OVER (ORDER BY idcatruc) AS STT from catruc where  " + HiddenField1.Value;
             gettable(HiddenField2.Value);
}catch{}
             HiddenField1.Value = "";
         }
         else
         {
             string sql = "1=1";
             if (tencatruc.Value != "")
             {
                 sql += " and tencatruc like N'%" + tencatruc.Value + "%'";
             }
             if (tientruc.Value != "")
             {
                 sql += " and tientruc like N'%" + tientruc.Value + "%'";
             }
             if (ghichu.Value != "")
             {
                 sql += " and ghichu like N'%" + ghichu.Value + "%'";
             }
             HiddenField2.Value = "select *,ROW_NUMBER() OVER (ORDER BY idcatruc) AS STT from catruc where "+ sql;
             gettable(HiddenField2.Value);
         }
     }
 }
 
