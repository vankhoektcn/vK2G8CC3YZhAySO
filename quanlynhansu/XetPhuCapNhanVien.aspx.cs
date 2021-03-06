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
public partial class XetPhuCapNhanVien : Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            BindListPhongBan();
            BindListNhanVien();
            pnl1.Visible = false;
        }
    }
    private void BindListPhongBan()
    {
        string sql = "select * from phongban where status=1 ORder by tenphongban";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlPhongBan, dt, "idphongban", "tenphongban", "------Chọn phòng ban------");
        }
    }
    private void BindListNhanVien()
    {
        string PhongBanIn = "";
        if (ddlPhongBan.SelectedValue != "0")
            PhongBanIn = " and nv.idphongban=" + ddlPhongBan.SelectedValue;
        string sql = @"select nv.idnhanvien,nv.tennhanvien from nhanvien nv
            where nv.status=1
            and nv.idnhanvien in (select hd.idnhanvien from hopdong hd
             where nv.idnhanvien=hd.idnhanvien and hd.status=1) 
            " + PhongBanIn + @"
            order by nv.tennhanvien";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            StaticData.FillCombo(ddlNhanVien, dt, "idnhanvien", "tennhanvien","----Chọn nhân viên----");
        }
    }
    private void loadDSPC()
    {
        string sql = ""
+ " select ROW_NUMBER ( ) OVER(ORDER BY pc.idphucap) AS STT,pc.*,GiaTriMuc," + "\r\n"
+ " isnull(convert(bit,(SELECT top 1 isnull(1,0) from ChiTietPhuCap_NhanVien where idnhanvien = '"+ddlNhanVien.SelectedValue+"' and idphucap=pc.idphucap)),0) as IsCheck " + "\r\n"
+ "  from danhmucphucap pc left join ChiTietPhuCap_NhanVien ctpc on ctpc.idphucap=pc.idphucap and ctpc.idnhanvien = '"+ddlNhanVien.SelectedValue+"' where pc.status=1" + "\r\n";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            dtgListPK.DataSource = dt.DefaultView;
            dtgListPK.DataBind();
            txtIdNhanVienHd.Value = ddlNhanVien.SelectedValue;
        }
    }

    private void loadDSPCPhong()
    {
        string sql = ""
+ " select ROW_NUMBER ( ) OVER(ORDER BY pc.idphucap) AS STT,pc.*,GiaTriMuc=''," + "\r\n"
+ " convert(bit,0) as IsCheck " + "\r\n"
+ "  from danhmucphucap pc where pc.status=1 " + "\r\n";
        DataTable dt = DataAcess.Connect.GetTable(sql);
        if (dt.Rows.Count != 0)
        {
            dtgListPK.DataSource = dt.DefaultView;
            dtgListPK.DataBind();
            txtIdNhanVienHd.Value = ddlNhanVien.SelectedValue;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql ;
        bool dk = true;
        string[] txtboxid = new string[dtgListPK.Items.Count];
        string idPhuCap;
        if (ddlNhanVien.SelectedValue == "0")
        {
            DataTable tablenhanvien = DataAcess.Connect.GetTable("select * from nhanvien inner join hopdong hd on nhanvien.idnhanvien=hd.idnhanvien where hd.status=1 and nhanvien.status=1 and idphongban=" + ddlPhongBan.SelectedValue + " and NHANVIEN.status = 1");
            for (int t = 0; t < tablenhanvien.Rows.Count; t++)
            {
                txtIdNhanVienHd.Value = tablenhanvien.Rows[t]["idnhanvien"].ToString();
                for (int i = 0; i <= dtgListPK.Items.Count - 1; i++)
                {
                    if (((CheckBox)dtgListPK.Items[i].FindControl("chkSelect")).Checked == true)
                    {
                        dk = false;
                    }

                }
                if (dk == true)
                {
                    //StaticData.MsgBox(this,"Bạn không chọn bất kỳ phụ cấp nào !");
                    string delPhuCapNhanVien = "delete from ChiTietPhuCap_NhanVien where idnhanvien=" + txtIdNhanVienHd.Value;
                    bool ktDel = DataAcess.Connect.ExecSQL(delPhuCapNhanVien);
                    StaticData.MsgBox(this, "Đã xóa phụ cấp nhân viên !");
                }
                else
                {
                    try
                    {
                        for (int i = 0; i <= dtgListPK.Items.Count - 1; i++)
                        {
                            if (((CheckBox)dtgListPK.Items[i].FindControl("chkSelect")).Checked == true)
                            {
                                txtboxid[i] = ((Label)dtgListPK.Items[i].FindControl("lblIdPhuCap")).Text;
                                idPhuCap = txtboxid[i].ToString();
                                dk = false;
                                string kt = "select * from ChiTietPhuCap_NhanVien where idnhanvien=" + txtIdNhanVienHd.Value + " and idphucap = '" + idPhuCap + "'";
                                DataTable dt = DataAcess.Connect.GetTable(kt);

                                if (dt.Rows.Count == 0)
                                {
                                    string idPhuCap_NhanVien = StaticData.MaxIdNhanSuTheoTable("ChiTietPhuCap_NhanVien", "idChiTietPhuCap_NV");
                                    string GiaTriMuc = ((TextBox)dtgListPK.Items[i].FindControl("txtGiaTriMuc")).Text;
                                    sql = "insert into ChiTietPhuCap_NhanVien (idChiTietPhuCap_NV,idnhanvien,idphucap,GiaTriMuc) values('" + idPhuCap_NhanVien + "','" + txtIdNhanVienHd.Value + "','" + idPhuCap + "','" + GiaTriMuc + "')";
                                    DataAcess.Connect.ExecSQL(sql);
                                }
                                else
                                {
                                    string GiaTriMuc = ((TextBox)dtgListPK.Items[i].FindControl("txtGiaTriMuc")).Text;
                                    sql = "update  ChiTietPhuCap_NhanVien set GiaTriMuc=" + GiaTriMuc + " where idnhanvien=" + txtIdNhanVienHd.Value + " and idphucap=" + idPhuCap;
                                    DataAcess.Connect.ExecSQL(sql);
                                }

                            }
                            if (((CheckBox)dtgListPK.Items[i].FindControl("chkSelect")).Checked == false)
                            {
                                txtboxid[i] = ((Label)dtgListPK.Items[i].FindControl("lblIdPhuCap")).Text;
                                idPhuCap = txtboxid[i].ToString();
                                dk = false;
                                string kt = "select * from ChiTietPhuCap_NhanVien where idnhanvien=" + txtIdNhanVienHd.Value + " and idphucap = '" + idPhuCap + "'";
                                DataTable dt = DataAcess.Connect.GetTable(kt);

                                if (dt.Rows.Count > 0)
                                {
                                    sql = "delete from ChiTietPhuCap_NhanVien where idnhanvien='" + txtIdNhanVienHd.Value + "' and idphucap ='" + idPhuCap + "'";
                                    DataAcess.Connect.ExecSQL(sql);
                                }
                                else
                                {

                                }

                            }

                        }
                        StaticData.MsgBox(this, "Lưu phụ cấp thành công!");
                    }
                    catch (Exception ex)
                    {
                        StaticData.MsgBox(this, "Có lỗi trong quá trình lưu phụ cấp. Vui lòng bạn kiểm tra lại!");
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i <= dtgListPK.Items.Count - 1; i++)
            {
                if (((CheckBox)dtgListPK.Items[i].FindControl("chkSelect")).Checked == true)
                {
                    dk = false;
                }

            }
            if (dk == true)
            {
                //StaticData.MsgBox(this,"Bạn không chọn bất kỳ phụ cấp nào !");
                string delPhuCapNhanVien = "delete from ChiTietPhuCap_NhanVien where idnhanvien=" + txtIdNhanVienHd.Value;
                bool ktDel = DataAcess.Connect.ExecSQL(delPhuCapNhanVien);
                StaticData.MsgBox(this, "Đã xóa phụ cấp nhân viên !");
            }
            else
            {
                try
                {
                    for (int i = 0; i <= dtgListPK.Items.Count - 1; i++)
                    {
                        if (((CheckBox)dtgListPK.Items[i].FindControl("chkSelect")).Checked == true)
                        {
                            txtboxid[i] = ((Label)dtgListPK.Items[i].FindControl("lblIdPhuCap")).Text;
                            idPhuCap = txtboxid[i].ToString();
                            dk = false;
                            string kt = "select * from ChiTietPhuCap_NhanVien where idnhanvien=" + txtIdNhanVienHd.Value + " and idphucap = '" + idPhuCap + "'";
                            DataTable dt = DataAcess.Connect.GetTable(kt);

                            if (dt.Rows.Count == 0)
                            {
                                string idPhuCap_NhanVien = StaticData.MaxIdNhanSuTheoTable("ChiTietPhuCap_NhanVien", "idChiTietPhuCap_NV");
                                string GiaTriMuc = ((TextBox)dtgListPK.Items[i].FindControl("txtGiaTriMuc")).Text;
                                sql = "insert into ChiTietPhuCap_NhanVien (idChiTietPhuCap_NV,idnhanvien,idphucap,GiaTriMuc) values('" + idPhuCap_NhanVien + "','" + ddlNhanVien.SelectedValue.ToString() + "','" + idPhuCap + "','" + GiaTriMuc + "')";
                                DataAcess.Connect.ExecSQL(sql);
                            }
                            else
                            {
                                string GiaTriMuc = ((TextBox)dtgListPK.Items[i].FindControl("txtGiaTriMuc")).Text;
                                sql = "update  ChiTietPhuCap_NhanVien set GiaTriMuc=" + GiaTriMuc + " where idnhanvien=" + txtIdNhanVienHd.Value + " and idphucap=" + idPhuCap;
                                DataAcess.Connect.ExecSQL(sql);
                            }

                        }
                        if (((CheckBox)dtgListPK.Items[i].FindControl("chkSelect")).Checked == false)
                        {
                            txtboxid[i] = ((Label)dtgListPK.Items[i].FindControl("lblIdPhuCap")).Text;
                            idPhuCap = txtboxid[i].ToString();
                            dk = false;
                            string kt = "select * from ChiTietPhuCap_NhanVien where idnhanvien=" + ddlNhanVien.SelectedValue.ToString() + " and idphucap = '" + idPhuCap + "'";
                            DataTable dt = DataAcess.Connect.GetTable(kt);

                            if (dt.Rows.Count > 0)
                            {
                                sql = "delete from ChiTietPhuCap_NhanVien where idnhanvien='" + ddlNhanVien.SelectedValue.ToString() + "' and idphucap ='" + idPhuCap + "'";
                                DataAcess.Connect.ExecSQL(sql);
                            }
                            else
                            {

                            }

                        }

                    }
                    StaticData.MsgBox(this, "Lưu phụ cấp thành công!");
                }
                catch (Exception ex)
                {
                    StaticData.MsgBox(this, "Có lỗi trong quá trình lưu phụ cấp. Vui lòng bạn kiểm tra lại!");
                }
            }
        }
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Response.Redirect("XetPhuCapNhanVien.aspx");
    }
    
    protected void ddlNhanVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNhanVien.SelectedValue == "0")
        {
            pnl1.Visible = false;
        }
        else
        {
            loadDSPC();
            pnl1.Visible = true;
        }
    }
    protected void ddlPhongBan_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindListNhanVien();
        if (ddlPhongBan.SelectedValue == "0")
        {
            pnl1.Visible = false;
        }
        else
        {
            loadDSPCPhong();
            pnl1.Visible = true;
        }
    }
}
