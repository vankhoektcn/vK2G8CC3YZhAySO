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
using Profess;
using System.Drawing;
public partial class PhanQuyenNew : MKVPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            this.LoadDanhSachNguoiDung();
            btnSave.Visible = false;
            btnSave1.Visible = false;
            LoadLoaiQuyen();
        }
        PlaceHolder1.Controls.Add(LoadControl("~/QuanlyNguoiDung/menu_HeThong.ascx"));
    }
    protected void LoadLoaiQuyen()
    {
        string sqlLQ = @"select distinct SUBSTRING(PermDesc,0,CHARINDEX('_',PermDesc)) as loaiquyen 
          from permision where SUBSTRING(PermDesc,0,CHARINDEX('_',PermDesc))<>''";
        DataTable tbQ = DataAcess.Connect.GetTable(sqlLQ);
        StaticData.FillCombo(ddlLoaiQuyen, tbQ, "loaiquyen", "loaiquyen", "--Tất cả--");

    }
    protected void LuuQuyen(string Id, string PermID,bool isAllow)
    {
        bool OK1 = DataAcess.Connect.ExecSQL("DELETE FROM USERPROFILE WHERE USERID=" + Id + " and PermId='" + PermID + "'");
        if (OK1 == true && isAllow==true)
        {
            DataTable dt = DataAcess.Connect.GetTable("SELECT max(EPID) FROM UserProfile ");
            string newID = "1";
            if (dt == null)
            {
                DataAcess.Connect.RollBack();
                StaticData.MsgBox(this, "Lưu thông tin thất bại");
                return;
            }
            if (dt.Rows.Count != 0 && dt.Rows[0][0].ToString()!="")
                newID = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            UserProfile Perm = UserProfile.Insert_Object(newID, Id, PermID, "1", "0");
            if (Perm == null)
            {
                DataAcess.Connect.RollBack();
                StaticData.MsgBox(this, "Lưu thông tin thất bại");
                return;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtNguoiDung.Value == "0" || txtNguoiDung.Value == "")
        {
            StaticData.MsgBox(this,"Bạn chưa chọn người dùng !");
            return;
        }
        if (txtIdNguoiDung.Value == "0" || txtIdNguoiDung.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa xác định danh sách quyền cho \""+mkv_txtNguoiDung.Value+"\" !");
            return;
        }
        string Id = txtIdNguoiDung.Value;// this.cbNguoiDung.SelectedValue.ToString();
        if (Id == null) return;
        DataAcess.Connect.BeginTran();        

        for (int i = 0; i < this.dgView.Items.Count; i++)
        {
            // su lý xem
            if (i == 21)
            {
            }
            bool isXem = ((CheckBox)this.dgView.Items[i].Cells[2].FindControl("chbXem")).Checked;
            string idXem = ((HtmlInputHidden)this.dgView.Items[i].Cells[2].FindControl("IDXem")).Value;
            LuuQuyen(Id, idXem, isXem);
            // su ly them
            bool isThem = ((CheckBox)this.dgView.Items[i].Cells[3].FindControl("chbThem")).Checked;
            string idThem = ((HtmlInputHidden)this.dgView.Items[i].Cells[3].FindControl("IDThem")).Value;
            LuuQuyen(Id, idThem, isThem);
            // su ly sua
            bool isXoa = ((CheckBox)this.dgView.Items[i].Cells[4].FindControl("chbXoa")).Checked;
            string idXoa = ((HtmlInputHidden)this.dgView.Items[i].Cells[4].FindControl("IDXoa")).Value;
            LuuQuyen(Id, idXoa, isXoa);
            // su ly xoa
            bool isSua = ((CheckBox)this.dgView.Items[i].Cells[2].FindControl("chbSua")).Checked;
            string idSua = ((HtmlInputHidden)this.dgView.Items[i].Cells[2].FindControl("IDSua")).Value;
            LuuQuyen(Id, idSua, isSua);
                   
        }
      
        DataAcess.Connect.Commit();
       StaticData.MsgBox(this, "Lưu thông tin thành công");
    }

    private void LoadDanhSachNguoiDung()
    {
        string sql = ""
                + " select idnguoidung,tennguoidung=tennguoidung +'-'+ username +'-'+ tennhom" + "\r\n"
                + " from nguoidung a" + "\r\n"
                + " left join nhomnguoidung b on a.nhomid=b.nhomid" + "\r\n"
                + " order by a.nhomid,tennguoidung" + "\r\n";

        DataTable Dt = DataAcess.Connect.GetTable(sql);
        //StaticData.FillCombo(this.cbNguoiDung, Dt, "IdNguoiDung", "tennguoidung", "Chọn người dùng");
    }

    protected void btnGetList_Click(object sender, EventArgs e)
    {
        if (txtNguoiDung.Value == "0" || txtNguoiDung.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn người dùng !");
            return;
        }
        txtIdNguoiDung.Value = txtNguoiDung.Value;
        string Id = txtIdNguoiDung.Value;// this.cbNguoiDung.SelectedValue.ToString();
        string sW = "";
        if (ddlLoaiQuyen.SelectedIndex>0)
            sW = " and T.PermDesc like N'" + ddlLoaiQuyen.SelectedValue + "_%'";
        if (Id == null) return;
        string sqlSelect = @"
               select ROW_NUMBER() OVER (ORDER BY dbo.KB_PERNAME_SoTT(PermName),  PERMNAME) AS STT,*
                from                      
                (SELECT  distinct  DBO.KB_PERNAME_SHORT(T.PERMNAME) AS PERMNAME
                      , dbo.KB_PERDESC_SHORT(t.permdesc) as PERMDESC 
                      ,IsParent=case when exists( SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)  AND isParent='1') then 1 else 0 end
                      ,isnull( (SELECT TOP 1  CONVERT(BIT,1)  FROM USERPROFILE WHERE  USERID=" + Id + @" AND PERMID=(SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)  AND PERMNAME LIKE N'%_THEM')  ),0)  AS THEM
                      ,isnull((SELECT TOP 1  CONVERT(BIT,1)  FROM USERPROFILE WHERE USERID=" + Id + @" AND PERMID=(SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)  AND PERMNAME LIKE N'%_XOA')  ),0)  AS XOA
                      ,isnull((SELECT TOP 1  CONVERT(BIT,1)  FROM USERPROFILE WHERE USERID=" + Id + @" AND PERMID=(SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)  AND PERMNAME LIKE N'%_SUA')  ),0)  AS SUA
                      ,isnull((SELECT TOP 1   CONVERT(BIT,1)   FROM USERPROFILE WHERE USERID=" + Id + @" AND PERMID=(SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)  
                      AND (PERMNAME LIKE N'%_XEM' OR (PERMNAME NOT LIKE N'%_THEM' AND PERMNAME NOT LIKE N'%_XOA' AND PERMNAME not LIKE N'%_SUA')))  ),0)  AS XEM
                      ,IDThem=(SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)  AND PERMNAME LIKE N'%_THEM')
                      ,IDXoa=(SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)  AND PERMNAME LIKE N'%_XOA')  
                      ,IDSua=(SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)  AND PERMNAME LIKE N'%_SUA')  
                      ,IDXem=(SELECT TOP 1 PERMID FROM permision WHERE  DBO.KB_PERNAME_SHORT(PERMNAME)=DBO.KB_PERNAME_SHORT(T.PERMNAME)
                      AND (PERMNAME LIKE N'%_XEM' OR (PERMNAME NOT LIKE N'%_THEM' AND PERMNAME NOT LIKE N'%_XOA' AND PERMNAME not LIKE N'%_SUA')))
            FROM permision T
            WHERE T.STATUS=1
           " + sW + " )as A ";
        DataTable dt = DataAcess.Connect.GetTable(sqlSelect);
        this.dgView.DataSource = dt;
        this.dgView.DataBind();
        btnSave.Visible = true;
        btnSave1.Visible = true;
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        string idNDCpy = txtIdNguoiDung_CPY.Value.Trim();
        string Id = txtNguoiDung.Value;
        if (idNDCpy == "" || idNDCpy == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn người dùng để lấy quyền, vui lòng chọn lại!!");
            return;
        }
        if (txtNguoiDung.Value == "0" || txtNguoiDung.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn người dùng !");
            return;
        }
        bool OK1 = DataAcess.Connect.ExecSQL("DELETE FROM USERPROFILE WHERE USERID=" + Id);
        if (!OK1 == null)
        {
            DataAcess.Connect.RollBack();
            StaticData.MsgBox(this, "Lưu thông tin thất bại");
            return;
        }
        string sqlI = @"select * from UserProfile 
                    where UserId='" + idNDCpy + "' and status='1'";
        DataTable tbQ_CP = DataAcess.Connect.GetTable(sqlI);
        for (int i = 0; i < tbQ_CP.Rows.Count; i++)
        {
            string PermID = tbQ_CP.Rows[i]["PermID"].ToString();
            DataTable dt = DataAcess.Connect.GetTable("SELECT TOP 1 EPID FROM UserProfile ORDER BY EPID DESC");
            string newID = "1";
            if (dt == null)
            {
                DataAcess.Connect.RollBack();
                StaticData.MsgBox(this, "Lưu thông tin thất bại");
                return;
            }
            if (dt.Rows.Count != 0)
                newID = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            UserProfile Perm = UserProfile.Insert_Object(newID, Id, PermID, "1", "0");
            if (Perm == null)
            {
                DataAcess.Connect.RollBack();
                StaticData.MsgBox(this, "Lưu thông tin thất bại");
                return;
            }
        }
        btnGetList_Click(null, null);
    }
    protected void dgView_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView r = (DataRowView)e.Item.DataItem;
            if(StaticData.ParseInt(r["IDXEM"].ToString())==0)
                ((CheckBox)e.Item.Cells[2].FindControl("chbXem")).Enabled = false;
           if (StaticData.ParseInt(r["IDThem"].ToString()) == 0)
               ((CheckBox)e.Item.Cells[3].FindControl("chbThem")).Enabled = false;
            if (StaticData.ParseInt(r["IDXoa"].ToString()) == 0)
                ((CheckBox)e.Item.Cells[4].FindControl("chbXoa")).Enabled = false;
            if (StaticData.ParseInt(r["IDSua"].ToString()) == 0)
                ((CheckBox)e.Item.Cells[2].FindControl("chbSua")).Enabled = false;
            string IsParnt = r["isparent"].ToString();
            if (IsParnt == "1")
                e.Item.BackColor = Color.LightBlue;
        }
    }
}
