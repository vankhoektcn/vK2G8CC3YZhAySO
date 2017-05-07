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
 
 public partial class loainghiphep : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
          if(!IsPostBack){
              HiddenField2.Value = "select row_number() over (order by tennghiphep) as STT,* from loainghiphep";
          Page.DataBind();
         gettable(HiddenField2.Value);
    }     
     }
 
     public void gettable(string sql)
     {
         DataTable table = DataAcess.Connect.GetTable(sql);
         gridTable.DataSource = table;
         gridTable.DataBind();
     }
 protected void gridTable_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#F6EBCD',this.style.cursor = 'pointer'");
             e.Row.Attributes.Add("ondblclick", "alert('not event')");
             e.Row.Attributes.Add("onclick", "setControlFind('" + gridTable.DataKeys[e.Row.RowIndex].Value.ToString() + "','" + hsLibrary.clDictionaryDB.sGetValueLanguage("update") + "')");
             if (e.Row.RowState != DataControlRowState.Alternate)
             {
                 e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
             }
             else
             {
                 e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#CAE3FF'");
             }
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
     protected void Button1_Click(object sender, EventArgs e)
     {
         if (HiddenField1.Value != "")
         {
             try
             {
                 HiddenField2.Value = "select row_number() over (order by tennghiphep) as STT,* from loainghiphep where  " + HiddenField1.Value;
             gettable(HiddenField2.Value);
}catch{}             HiddenField1.Value = "";
         }
         else
         {
    string sql="";
 if (tennghiphep.Text_TextBox.Trim() != ""){
  sql+=" and tennghiphep like N'%" + tennghiphep.Text_TextBox + "%' ";
         }
         HiddenField2.Value = "select row_number() over (order by tennghiphep) as STT,* from loainghiphep where 1=1 " + sql;
             gettable(HiddenField2.Value);
         }
     }
 }
 
