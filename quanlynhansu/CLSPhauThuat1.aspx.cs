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
 
 public partial class CLSPhauThuat : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
          if(!IsPostBack){ 
          HiddenField2.Value = @"select idCLSPhauThuat,tengoiphauthuat,tendichvu from CLSPhauThuat cp
left join goiphauthuat gp on gp.idgoiphauthuat=cp.idgoiphauthuat
left join banggiadichvu bg on bg.idbanggiadichvu = cp.idCLS where 1=1";
          Page.DataBind();
          string sqlSelect = "select idgoiphauthuat,tengoiphauthuat from goiphauthuat order by tengoiphauthuat";
          DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
          idGoiPhauThuat.SetDataDropList(dt, "idgoiphauthuat", "tengoiphauthuat","0","--- Chọn gói phẫu thuật ---");
          //sqlSelect = "select idbanggiadichvu,tendichvu from banggiadichvu order by tendichvu";
          //     dt = DataAcess.Connect.GetTable(sqlSelect);
               //idCLS.SetDataDropList(dt, "idbanggiadichvu", "tendichvu", "0", "--- Chọn CLS ---");
         gettable(HiddenField2.Value);
}     }
 
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
                 HiddenField2.Value = @"select idCLSPhauThuat,tengoiphauthuat,tendichvu from CLSPhauThuat cp
left join goiphauthuat gp on gp.idgoiphauthuat=cp.idgoiphauthuat
left join banggiadichvu bg on bg.idbanggiadichvu = cp.idCLS where 1=1" + HiddenField1.Value;
             gettable(HiddenField2.Value);
}catch{}             HiddenField1.Value = "";
         }
         else
         {
    string sql="";
 if (idGoiPhauThuat.SelectedValue.Trim() != "0"){
     sql += " and gp.idGoiPhauThuat = '" + idGoiPhauThuat.SelectedValue + "'";
         }
         if (idCLS_ID.Value.Trim() != "")
         {
             sql += " and cp.idCLS = '" + idCLS_ID.Value + "'";
         }
         HiddenField2.Value = @"select idCLSPhauThuat,tengoiphauthuat,tendichvu from CLSPhauThuat cp
left join goiphauthuat gp on gp.idgoiphauthuat=cp.idgoiphauthuat
left join banggiadichvu bg on bg.idbanggiadichvu = cp.idCLS where 1=1" + sql;
             gettable(HiddenField2.Value);
         }
     }
     protected void Button2_Click(object sender, EventArgs e)
     {
         idGoiPhauThuat.SelectedIndex = 0;
         idCLS_ID.Value = "";
         idCLS.Text_TextBox = "";
     }
}
 
