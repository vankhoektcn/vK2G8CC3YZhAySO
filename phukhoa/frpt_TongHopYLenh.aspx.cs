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
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
using System.Text.RegularExpressions;


public partial class frpt_TongHopYLenh : Page
{
    private ReportDocument report = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "YLenh", "new Epoch('epoch_popup','popup',document.getElementById('txtTuNgay'));", true);
        if (!IsPostBack)
        {
            //StaticData.FillCombo(this.cbLoaiKham, Process.KB_LoaiKham.dtGetAll(), "LoaiKhamID", "TenLoai", "--Chọn loại khám--");
            this.txtTuNgay.Text = DataAcess.Connect.d_SystemDate().ToString("dd/MM/yyyy");
            this.txtDenNgay.Text = this.txtTuNgay.Text;
            divChonGiuong.InnerHtml = "<input type='checkbox' id='cbGiuong' value='Check vô mình đi !' onclick='setCheckGiuong(this)'/>";
            LoadDanhSachPhong();
        }
            string dkmenu =   Request.QueryString["dkmenu"].ToString();
            if (dkmenu == "") dkmenu = "khoanoi";

            if (dkmenu == "thuphi")
            {
                PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
            }
            else if (dkmenu == "tiepnhan")
            {
                PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
            }
            else if (dkmenu == "khambenh")
            {
                PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
            }
            else if (dkmenu == "khoasan")
            {
                PlaceHolder1.Controls.Add(LoadControl("~/khoasan/uscmenu.ascx"));
            }
            else if (dkmenu == "khoanoi")
            {
                PlaceHolder1.Controls.Add(LoadControl("~/khoanoi/uscmenu.ascx"));
            }
            else if (dkmenu == "khoangoai")
            {
                PlaceHolder1.Controls.Add(LoadControl("~/khoangoai/uscmenu.ascx"));
            }
            else if (dkmenu == "thongke")
            {
                PlaceHolder1.Controls.Add(LoadControl("~/thongke/uscmenu.ascx"));
            }

            GetReport(IsPostBack);
        if (hdListIdG.Value != "" && hdListIdG.Value != "0")
            divGiuongDaChon.InnerHtml = "<input type='button' value='Hiện Giường' id='btnHienThiCTG'  onclick='xoaGiuongTable(0);'/><input type='button' value='Mới' id='btnClearCTG'  onclick='ClearDanhSachGiuong();'/>";
        else
            divGiuongDaChon.InnerHtml = "HÃY CHỌN GIƯỜNG !";
    }
    private void LoadDanhSachPhong()
    {
        string sqlPhong = "select p.* from kb_PHONG p left join banggiadichvu bg on bg.idbanggiadichvu=p.DichVuKCB where  isPhongNoiTru=1 and bg.idphongkhambenh=" + Request.QueryString["idkhoa"] + " order by TenPhong";
        DataTable dtPhong = DataAcess.Connect.GetTable(sqlPhong);
        string ListPhongHtml="";
        if (dtPhong.Rows.Count > 0)
        {
            for (int i = 0; i < dtPhong.Rows.Count; i++)
            {
                ListPhongHtml += @"<input type='button' id='" + dtPhong.Rows[i]["id"] + "' runat='server' onclick='Phong_click(this)' value='" + dtPhong.Rows[i]["TenPhong"].ToString() + @"' style='background-color:Blue;color:white' />";
                if ((i+1) % 10 == 0 || (i+1) % 10 == 5)
                    ListPhongHtml += "<br />";
            }
        }
        divChonGiuong.InnerHtml = ListPhongHtml;
    }
    protected void btnLayBaoCao_Click(object sender, EventArgs e)
    {
        //StaticData.MsgBox(this, hdListIdG.Value);
        GetReport(true);
    }
    private void GetReport( bool PostBack)
    {
        if (!PostBack)
            return;
        if (hdListIdG.Value == "" || hdListIdG.Value == "0")
        {
            StaticData.MsgBox(this, "Bạn chưa chọn giường. Hãy chọn giường trước !"); return;
        }
        string tuN = txtTuNgay.Text.Trim();
        string denN = txtDenNgay.Text.Trim();
        #region Dữ liệu mẫu
//        string sqlRow = @"
//select idrow=100000,Stt=1,Phong=N'Phòng 1',Giuong=N'Giường 1',MaBenhNhan='BN-01012012-12',TenBenhNhan=N'Nguyễn Thanh A',int=123--,double=456,string=N''
//union all
//select idrow=200000,Stt=2,Phong=N'Phòng 1',Giuong=N'Giường 2',MaBenhNhan='BN2',TenBenhNhan=N'Nguyễn Thanh B',int=123--,double=456.0,string=N''
//union all
//select idrow=300000,Stt=3,Phong=N'Phòng 2',Giuong=N'Giường 5',MaBenhNhan='BN3',TenBenhNhan=N'Trần Thanh Sang',int=123--,double=456.0,string=N''";
//        DataTable dtRow = DataAcess.Connect.GetTable(sqlRow);
//        string sqlColumn = @"
//select idColumn=123456,MaThuoc='T1',TenThuoc=N'Thuốc 1',int_col=1,double_col=1,string_col=''
//union all
//select idColumn=234567,MaThuoc='T2',TenThuoc=N'Thuốc 2',int_col=2,double_col=2,string_col=''";
//        DataTable dtColumn = DataAcess.Connect.GetTable(sqlColumn);
//        string sqlDetail = @"
//select idDetail=1,idRow=29054,idColumn=123456,SoLuongThuoc_int=1,SLThuoc_string=1,SLThuoc_double=1
//union all 
//select idDetail=2,idRow=29054,idColumn=234567,SoLuongThuoc_int=2,SLThuoc_string=1,SLThuoc_double=1
//union all 
//select idDetail=3,idRow=200000,idColumn=123456,SoLuongThuoc_int=3,SLThuoc_string=1,SLThuoc_double=1
//union all 
//select idDetail=4,idRow=200000,idColumn=234567,SoLuongThuoc_int=3,SLThuoc_string=1,SLThuoc_double=1
//union all 
//select idDetail=5,idRow=300000,idColumn=123456,SoLuongThuoc_int=4,SLThuoc_string=1,SLThuoc_double=1
//union all 
//select idDetail=6,idRow=300000,idColumn=234567,SoLuongThuoc_int=5,SLThuoc_string=1,SLThuoc_double=1";
//        DataTable dtDetail = DataAcess.Connect.GetTable(sqlDetail);
        #endregion

       
        #region Dữ liệu thực
        string[] arrIdGiuong = hdListIdG.Value.Split(',');
        #region table_Row
        string sqlRow = @"select idrow=abc.idbenhnhan,Stt=convert(varchar(4),row_number()over(order by bn.tenbenhnhan)),Phong=tenphong,Giuong=giuongcode,MaBenhNhan=bn.mabenhnhan,TenBenhNhan=bn.TenBenhNhan+' ('+dbo.GetNamSinh(ngaysinh )+')'
        from (";
        string sqlSub = "";
        for (int i = 0; i < arrIdGiuong.Length; i++)
        {
            if (i == 0)
                sqlSub += @"select top 1 idnoitru,idbenhnhan,isdanhap,idgiuong from benhnhannoitru nt where idgiuong=" + arrIdGiuong[i] + @" order by ngayvaovien desc  
                ";
            //else if(i==arrIdGiuong.Length-1)
            //    sqlSub = @"";
            else
                sqlSub += @"union all
	                    select top 1 idnoitru,idbenhnhan,isdanhap,idgiuong from benhnhannoitru nt where idgiuong=" + arrIdGiuong[i] + @" order by ngayvaovien desc
                ";
        }
        sqlRow += sqlSub + @")
        as abc left join benhnhan bn on bn.idbenhnhan=abc.idbenhnhan
            left join kb_giuong g on g.giuongid=abc.idgiuong left join  kb_phong p on g.idphong=p.id
        where isdanhap=1
        and abc.idbenhnhan in(select kb.idbenhnhan from khambenh kb inner join chitietbenhnhantoathuoc ct on kb.idkhambenh=ct.idkhambenh and convert(varchar(10),ngaykham,103)='" + txtTuNgay.Text + @"' where kb.idbenhnhan=abc.idbenhnhan)
";
        DataTable dtRow = DataAcess.Connect.GetTable(sqlRow);
        #endregion
        #region table_column
        string sqlColumn = @"
        select distinct idColumn=t.idthuoc,MaThuoc=t.sttindm05,TenThuoc
        from chitietbenhnhantoathuoc ct inner join thuoc t on t.idthuoc=ct.idthuoc
        inner join khambenh kb on kb.idkhambenh=ct.idkhambenh 
        where kb.idphongkhambenh=2 and convert(varchar(10),ngaykham,103)='" + txtTuNgay.Text + @"' and idbenhnhan in
        (
	        select idbenhnhan
	        from (
		        " + sqlSub + @"
	        )
	        as abc  where isdanhap=1
        )";
        DataTable dtColumn = DataAcess.Connect.GetTable(sqlColumn);
        #endregion
        #region table_detail
        string sqlDetail = @"
        select idDetail=row_number()over(order by idbenhnhan),idRow=kb.idbenhnhan,idColumn=ct.idthuoc,SoLuongThuoc_int=sum(soluongke)
        from chitietbenhnhantoathuoc ct inner join khambenh kb on kb.idkhambenh=ct.idkhambenh 
        where kb.idphongkhambenh=2 and convert(varchar(10),ngaykham,103)='" + txtTuNgay.Text + @"' and idbenhnhan in
        (
	        select idbenhnhan
	        from (
		        " + sqlSub + @"
	        )
	        as abc  where isdanhap=1
        )
        group by kb.idbenhnhan,ct.idthuoc";
        DataTable dtDetail = DataAcess.Connect.GetTable(sqlDetail);
        #endregion
        #endregion
        if (dtRow.Rows.Count == 0 || dtColumn.Rows.Count == 0 || dtDetail.Rows.Count == 0)
        {
            StaticData.MsgBox(this, "Không tìm thấy Y lệnh nào !"); return;
        }
        DataTable dtRow1 = dtRow;
        DataTable dtColumn1 = dtColumn;
        DataTable dtDetail1 = dtDetail;
        dtRow1.TableName = "dtTongHopYLenh_Row";
        dtColumn1.TableName = "dtTongHopYLenh_Col";
        dtDetail1.TableName = "dtTongHopYLenh_Detail";
        DataSet ds = new DataSet("dsTongHopYLenh");
        ds.Tables.Add(dtRow1);
        ds.Tables.Add(dtColumn1);
        ds.Tables.Add(dtDetail1);
        //report.Load(Server.MapPath("CrystalReportYLenh.rpt"));
        report.Load(Server.MapPath("rptTongHopYLenh_1.rpt"));
        report.SetDataSource(ds);
        R.ReportSource = report;
        string ten_khoa = "";
        try
        {
            DataTable dtKhoa = DataAcess.Connect.GetTable("select tenphongkhambenh from phongkhambenh where idphongkhambenh =" + Request.QueryString["idkhoa"].ToString());
            ten_khoa = dtKhoa.Rows[0]["tenphongkhambenh"].ToString();
        }
        catch (Exception ex)
        {}
        report.SetParameterValue("@TenKhoa", ten_khoa);
        report.SetParameterValue("@Ngay", "Ngày: " + txtTuNgay.Text);
        this.R.DataBind();
    }
    protected void R_Unload(object sender, EventArgs e)
    {
        if (report != null)
        {
            report.Clone();
            report.Dispose();
            R.Dispose();
            R = null;
            GC.Collect();
        }
    }

    protected void form_unload(object sender, EventArgs e)
    {
        if (report != null)
        {
            report.Clone();
            report.Dispose();
            report = null;
           
            GC.Collect();
        }
    }
    #region khoi tao va giai phong bo nho
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        InitialComponent();
    }
    private void InitialComponent()
    {
        this.Unload += new EventHandler(form_unload);
    }
    #endregion

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtTuNgay.Text = "anjsndaa";
    }
}
