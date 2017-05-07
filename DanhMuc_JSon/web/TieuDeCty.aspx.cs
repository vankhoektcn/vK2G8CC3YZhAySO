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
using System.Data.SqlClient;

public partial class DanhMuc_JSon_web_TieuDeCty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadThongTinCty();
    }
    private void LoadThongTinCty()
    {
        DataTable dt = DataAcess.Connect.GetTable("select top 1 * from TieuDeCty ");
        if(dt != null && dt.Rows.Count>0)
        {
            IdTieuDeCty.Value=dt.Rows[0]["ID_TT"].ToString();
            Image1.ImageUrl = "../../images/" + dt.Rows[0]["Logo"].ToString();
            txtTenCty.Text = dt.Rows[0]["Ten_Cty"].ToString();
            txtDC.Text = dt.Rows[0]["DiaChi"].ToString();
            txtDT.Text = dt.Rows[0]["DienThoai"].ToString();
            txtFax.Text = dt.Rows[0]["Fax"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtMST.Text = dt.Rows[0]["SoThue"].ToString();
            txtWebsite.Text = dt.Rows[0]["Website"].ToString();
        }
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTenCty.Text))
        {
            StaticData.MsgBox(this, "Bạn chưa nhập đủ thông tin !");
            return;
        }
        string sql = @"
            update TieuDeCty set Ten_Cty=N'" + txtTenCty.Text + @"'
	            ,DiaChi=N'" +txtDC.Text+@"'
	            ,DienThoai='"+txtDT.Text+@"'
	            ,Fax='"+txtFax.Text+@"'
	            ,SoThue='"+txtMST.Text+@"'
	            ,Email='"+txtEmail.Text+@"'
	            ,Website='"+txtWebsite.Text+@"'
            where ID_TT='" + IdTieuDeCty.Value + "'";
        bool kt = DataAcess.Connect.ExecSQL(sql);
        if (kt)
            StaticData.MsgBox(this, "Lưu thông tin thành công!");
        else
            StaticData.MsgBox(this, "Lưu THẤT BẠI !");
    }
    protected void btnSaveLogo_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(fulLogo.FileName))
        {
            StaticData.MsgBox(this, "Chưa  chọn logo !");
            return;
        }

        HttpPostedFile file = fulLogo.PostedFile;
        byte[] fileData = new Byte[file.ContentLength];
        file.InputStream.Read(fileData, 0, file.ContentLength);

        string filePath = Server.MapPath("~/images/") + fulLogo.FileName;
        fulLogo.SaveAs(filePath);
        Image1.ImageUrl = "../../images/" + fulLogo.FileName;
        #region from filePath
        //        string sqlLogo = @"
//                update TieuDeCty set Logo='" + fulLogo.FileName + @"'
//		                ,Logo_image=(SELECT * FROM OPENROWSET(
//	                        BULK '" + filePath + @"',
//	                        SINGLE_BLOB) AS x)";
        //bool ok = DataAcess.Connect.ExecSQL(sqlLogo);
        //if (ok)
        //    StaticData.MsgBox(this, "Lưu Logo thành công!");
        //else
        //    StaticData.MsgBox(this, "Lưu Logo LỖI!");
        #endregion
        #region From byte[]
        string sqlLogo = @"
                update TieuDeCty set Logo=@ImageFileName
		                ,Logo_image=@Image where ID_TT=" + IdTieuDeCty.Value + "";
        SqlConnection conn = DataAcess.Connect.GetConnection();
        if (conn.State != ConnectionState.Open)
            conn.Open();
        try
        {
            SqlCommand command = new SqlCommand(sqlLogo, conn);
            SqlParameter para0 = new SqlParameter("@ImageFileName", fulLogo.FileName);
            command.Parameters.Add(para0);
            SqlParameter para1 = new SqlParameter("@Image", fileData);
            command.Parameters.Add(para1);
            int x = command.ExecuteNonQuery();
            if (x > 0)
                StaticData.MsgBox(this, "Lưu Logo thành công!");
            else
                StaticData.MsgBox(this, "Lưu Logo LỖI!");
        }
        catch (Exception)
        {
        }
        conn.Close();
        #endregion
    }

    //protected void btnSaveLogo_Click(object sender, EventArgs e)
    //{
    //    if (this.TieuDe == null) return;
    //    HttpPostedFile file = fulLogo.PostedFile;
    //    byte[] fileData = new Byte[file.ContentLength];
    //    file.InputStream.Read(fileData, 0, file.ContentLength);

    //    bool ok = this.TieuDe.Update_LogoImage(fulLogo.FileName, fileData);
    //    if (ok)
    //    {
    //        string filePath = Server.MapPath("~/images/") + fulLogo.FileName;
    //        fulLogo.SaveAs(filePath);
    //        Image1.ImageUrl = "../images/" + fulLogo.FileName;

    //        StaticData.MsgBox(this, "Lưu Logo thành công!");
    //    }
    //    else
    //    {
    //        StaticData.MsgBox(this, "Lưu Logo thất bại. Vui lòng kiểm tra lại!");
    //    }
    //}
}
