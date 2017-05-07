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

public partial class QuanLyNguoiDung_dmGiuong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSua.Visible = false;
        LoadMenu();
        if (!IsPostBack)
        {
            loadData("");
        }
        
    }
    private void LoadMenu()
    {
        string dkmenu = Request.QueryString["dkmenu"].ToString();
        PlaceHolder1.Controls.Add(LoadControl(StaticData.NVK_LoadMenuPhanHe(dkmenu)));
    }
    private bool checkValue()
    {
        if (txtMaGiuong.Value == "")
        {
            
            StaticData.MsgBox(this, "Bạn chưa nhập mã giường");
            return false;
        }
        if (txtLoaiGiuong.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập loại giường");
            return false;
        }
         if (txtPhongKham.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn phòng khám giường");
            return false;
        }
        if (txtGiaDV.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập giá dịch vụ");
            return false;
        }
        if (txtGiaBH.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập giá bảo hiểm");
            return false;
        }
        if (txtGiaNgoaiGio.Value == "")
        {
            StaticData.MsgBox(this, "Bạn chưa nhập giá ngoài giờ");
            return false;
        }
        return true;
    }
    public void PageIndexStyleChanged(object Sender, DataGridPageChangedEventArgs e)
    {
        dgrDanhMucGiuong.CurrentPageIndex = e.NewPageIndex;
       // BindListPhongKham(strSearch);
    }
    public void dgr_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        LinkButton btn;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            btn = (LinkButton)(e.Item.Cells[1].FindControl("lbtnDel"));
            btn.Attributes.Add("onclick", "return ConfirmDelete();");
            e.Item.Attributes.Add("onmouseover", "this.style.backgroundColor=\'#F6EBCD\'");
            if (e.Item.ItemType == ListItemType.Item)
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'White\'");
            }
            else
            {
                e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#CAE3FF\'");
            }
        }
    }
    protected void dgr_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string id = (dgrDanhMucGiuong.DataKeys[e.Item.ItemIndex]).ToString();
        if (e.CommandName.ToString() == "Edit")
        {
            loadDataEdit(id);
            btnSua.Visible = true;
        }
        if (e.CommandName.ToString() == "Del")
        {
            string sqlDel = "Delete from Kb_Giuong where Giuongid=" + id;
            bool check = DataAcess.Connect.ExecSQL(sqlDel);
            if (check == true)
            {
                StaticData.MsgBox(this, "Đã xóa thành công");
                loadData("");
            }
            else
            {
                StaticData.MsgBox(this, "Xóa thất bại");
            }
        }

    }
    protected void loadDataEdit(string id)
    {
        string sql = @"select pk.id,pk.tenphong,giuong.giuongid,GiuongCode,LoaiGiuong,DVT,GiaBH,GiaDV,GiaNgoaiGio,TenPhong ,
                    case when isnull(bg.status,0)=1 Then N'Đã đặt' Else N'Chưa Đặt' end as TrangThai
                    from Kb_Giuong giuong
                    left join kb_banggiagiuong bg on bg.GiuongID=giuong.GiuongID
                    left join kb_phong pk on pk.id=giuong.idphong where giuong.giuongid="+id;
        DataTable dtData = DataAcess.Connect.GetTable(sql);
        txtMaGiuong.Value = dtData.Rows[0]["GiuongCode"].ToString();
        txtLoaiGiuong.Value = dtData.Rows[0]["LoaiGiuong"].ToString();
        txtDVT.Value = dtData.Rows[0]["DVT"].ToString();
        txtGiaBH.Value = dtData.Rows[0]["GiaBH"].ToString();
        txtGiaDV.Value = dtData.Rows[0]["GiaDV"].ToString();
        txtGiaNgoaiGio.Value = dtData.Rows[0]["GiaNgoaiGio"].ToString();
        txtidGiuong.Value = dtData.Rows[0]["GiuongID"].ToString();
        txtPhongKham.Value = dtData.Rows[0]["tenphong"].ToString();
        txtIdPhong.Value = dtData.Rows[0]["id"].ToString();
        if (dtData.Rows[0]["TrangThai"].ToString() == "Đã đặt")
        {
            ckbDaDat.Checked = true;
        }
        else
        {
            ckbDaDat.Checked = false;
        }
    }
    private string searchData()
    {
        string str = "";
        if (txtMaGiuong.Value.ToString() != "")
        {
            str += " and GiuongCode='"+txtMaGiuong.Value.ToString().TrimEnd()+"'";
        }
        if (txtLoaiGiuong.Value.ToString() != "")
        {
            str += " and LoaiGiuong='" + txtLoaiGiuong.Value.ToString() + "'";
        }
        if (txtDVT.Value.ToString() != "")
        {
            str += " and DVT=N'" + txtDVT.Value.ToString() + "'";
        }
        if (txtPhongKham.Value.ToString() != "")
        {
            str += " and TenPhong like N'%"+txtPhongKham.Value.ToString()+"%'";
        }
        if (ckbDaDat.Checked==true)
        {
            str += " and bg.status=1";
        }
        return str;
    }
    protected void loadData(string where)
    {
        string sql = @"select giuong.giuongid,GiuongCode,LoaiGiuong,DVT,GiaBH,GiaDV,GiaNgoaiGio,TenPhong ,
                    case when isnull(bg.status,0)=1 Then N'Đã đặt' Else N'Chưa Đặt' end as TrangThai
                    from Kb_Giuong giuong
                    left join kb_banggiagiuong bg on bg.GiuongID=giuong.GiuongID
                    left join kb_phong pk on pk.id=giuong.idphong where 1=1"+where;
        DataTable dtData = DataAcess.Connect.GetTable(sql);
        dgrDanhMucGiuong.DataSource = dtData;
        dgrDanhMucGiuong.DataBind();
    }
    protected void btnLuu_Click(object sender, ImageClickEventArgs e)
    {
        if (checkValue()==true)
        {
            string temp;
            string dadat = "";
            KT_Profess.KB_Giuong Giuong = null;
            if (ckbDaDat.Checked == true)
            {
                dadat = "1";
            }
            else
            {
                dadat = "0";
            }
            Giuong = KT_Profess.KB_Giuong.Insert_Object(txtMaGiuong.Value.ToString(), txtLoaiGiuong.Value.ToString(), txtDVT.Value.ToString(),dadat, txtDVT.Value.ToString(),txtIdPhong.Value.ToString());
            temp = Giuong.GiuongId;
            if (temp !="0")
            {
                KT_Profess.KB_BangGiaGiuong banggiagiuong = KT_Profess.KB_BangGiaGiuong.Insert_Object(temp, "", txtGiaBH.Value.ToString(), txtGiaDV.Value.ToString(), txtGiaNgoaiGio.Value.ToString(), dadat, "");
                if (banggiagiuong.BangGiaGiuongId != "0")
                {
                    StaticData.MsgBox(this, "Đã lưu thành công");
                    string strSearch = searchData();
                    loadData(strSearch);
                }
            }
            else
            {
                StaticData.MsgBox(this, "Lưu thất bại");
            }
        }
    }
    protected void btnSua_Click(object sender, ImageClickEventArgs e)
    {
        string dadat = "";
        if (ckbDaDat.Checked == true)
        {
            dadat = "1";
        }
        else
        {
            dadat = "0";
        }
        string sqlUpdate = "update kb_giuong set GiuongCode=N'"+txtMaGiuong.Value.ToString()+"',LoaiGiuong=N'"+txtLoaiGiuong.Value.ToString()+"',DVT=N'"+txtDVT.Value.ToString()+"',Status="+dadat+",idPhong="+txtIdPhong.Value.ToString()+" where GiuongID="+txtidGiuong.Value.ToString();
        bool update = DataAcess.Connect.ExecSQL(sqlUpdate);
        if (update == true)
        {
            string sqlGia = "update kb_BangGiagiuong set GiaDV=N'" + txtGiaDV.Value.ToString() + "',GiaBH=N'" + txtGiaBH.Value.ToString() + "',GiaNgoaiGio=N'" + txtGiaNgoaiGio.Value.ToString() + "',Status=" + dadat + " where GiuongID=" + txtidGiuong.Value.ToString();
            bool OK = DataAcess.Connect.ExecSQL(sqlGia);
            if (OK == true)
            {
                StaticData.MsgBox(this, "Cập nhật thành công");
            }
            else
            {
                StaticData.MsgBox(this, "Cập nhật thất bại");
            }
        }
        else
        {
            StaticData.MsgBox(this, "Cập nhật thất bại");
        }

    }
    protected void btnMoi_Click(object sender, ImageClickEventArgs e)
    {
        txtDVT.Value = "";
        txtGiaBH.Value = "";
        txtGiaDV.Value = "";
        txtGiaNgoaiGio.Value = "";
        txtidGiuong.Value = "";
        txtIdPhong.Value = "";
        txtLoaiGiuong.Value = "";
        txtMaGiuong.Value = "";
        txtPhongKham.Value = "";
        ckbDaDat.Checked = false;
        loadData("");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string search = searchData();
        loadData(search);
    }
}
