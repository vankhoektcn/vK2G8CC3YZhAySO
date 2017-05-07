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
 
 public partial class CaPhauThuat : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
         if (IsPostBack) return;
         ValidateRequest.messageError = "";
         ValidateRequest.ruleError = "";
         Page.DataBind();
         NgayPhauThuat.Text_TextBox = DateTime.Now.ToString("dd/MM/yyyy");
         NgayHienTai.Value = DateTime.Now.ToString("dd/MM/yyyy");
         //LoadDanhSachPhong();
     }
     public void LoadDanhSachPhong()
     {
         DataTable table = NhanSu_Process.KB_Phong.GetTable("select * from KB_Phong where dichvuKCB=2003 ");
         idPhongPhauThuat.SetDataDropList(table, "id", "tenphong", "", "-------Chọn phòng phẫu thuật-------");
     }
 }
 
