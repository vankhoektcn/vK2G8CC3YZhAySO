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
public partial class canlamsang_PhieuHenKQ : Genaratepage
{
    private string idPH=null;
    ReportDocument R;
    protected void Page_Load(object sender, EventArgs e)
    {
        string dkmenu = "" + "";  if (Request.QueryString["dkmenu"]!=null &&  dkmenu == "")  dkmenu = Request.QueryString["dkmenu"].ToString();
        
        if (dkmenu == "kb")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/khambenh/uscmenu.ascx"));
            
        }
        if (dkmenu == "thuphi")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/ThuVienPhi/uscmenu.ascx"));
           
        }
        if (dkmenu == "tiepnhan")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/nhanbenh/uscmenu.ascx"));
        }
        if (dkmenu == "cls")
        {
            PlaceHolder1.Controls.Add(LoadControl("~/canlamsang/uscmenu.ascx"));
        }
        if (Request.QueryString["idPH"] != null)
        {
            idPH = Request.QueryString["idPH"];
            
        }
            showReport();
       
    }
    private void showReport()
    {
        string listidThu = "";//Khoe 21_07
        if (Request.QueryString["listIDThu"] != null)
            listidThu=Request.QueryString["listIDThu"].ToString();
        DataTable dt;
        R = new ReportDocument();
        string sql="";
        if (Request.QueryString["idPH"] != null)
        {
            //CODE CU
        //    sql = "select bn.mabenhnhan,tenbenhnhan,bn.ngaysinh as t ,tenbacsi , "
        //+ " datepart(hour,ngayhen) as gioH, day(ngayhen) as ngayH, month(ngayhen) as thangH, year(ngayhen) as namH "
        //+ " from phieuhen ph inner join benhnhan bn on bn.idbenhnhan=ph.idbenhnhan "
        //+ " inner join bacsi bs on bs.idbacsi = ph.idbacsi where IDPhieuHen="+idPH+"";
            //TRUONGNHAT-PC CAP NHAT THEM TEN KHOA PHONG VA CHI DINH VAO PHIEU HEN KET QUA
            sql = ""
                        + " select ChiDinh= DBO.GetDichVuCLS3(bn.IDBenhNhan,'',''),tenphongkhambenh=dbo.KB_GetPhongKhambenh(bn.IDBenhNhan,'',''),bn.mabenhnhan,tenbenhnhan,bn.ngaysinh as t ,tenbacsi ,  datepart(hour,ngayhen) as gioH, day(ngayhen) as ngayH, month(ngayhen) as thangH, year(ngayhen) as namH  " + "\r\n"
                        + " from phieuhen ph inner join benhnhan bn on bn.idbenhnhan=ph.idbenhnhan" + "\r\n"
                        + " left join khambenhcanlamsan kb on kb.idbenhnhan=bn.idbenhnhan" + "\r\n"
                        + " left join banggiadichvu dv on dv.idbanggiadichvu=kb.idcanlamsan" + "\r\n"
                        + " left join phongkhambenh pk on dv.idphongkhambenh=pk.idphongkhambenh " + "\r\n"
                        + " left join bacsi bs on bs.idbacsi = ph.idbacsi where IDPhieuHen=" + idPH + "" + "";
            if(listidThu != "")
                    sql += " and kb.idkhambenhcanlamsan in ("+listidThu+") \r\n";
                         sql += " group by bn.mabenhnhan,tenbenhnhan,bn.ngaysinh ,tenbacsi ,  datepart(hour,ngayhen), day(ngayhen), month(ngayhen), year(ngayhen),bn.IDBenhNhan,pk.tenphongkhambenh" + "\r\n"
                        + " " + "\r\n";

        }
        if (Request.QueryString["idkhambenh"] != null)//Khoe 21_07
        {
            //Code cu
            //sql = "select mabenhnhan,gioH='',ngayH='',thangH='',namH='',tenbenhnhan,ngaysinh as t,tenbacsi='' from benhnhan where idbenhnhan=" + Request.QueryString["idbn"] + "";
            //TRUONGNHAT-PC CAP NHAT THEM TEN KHOA PHONG VA CHI DINH VAO PHIEU HEN KET QUA
            sql = ""
            + "  select ChiDinh=dv.tendichvu,pk.tenphongkhambenh,bn.mabenhnhan,gioH='',ngayH='',thangH='',namH='',tenbenhnhan,ngaysinh as t,tenbacsi=''" + "\r\n"
            + "   from  khambenhcanlamsan kbCLS " + "\r\n"
            + "  left join khambenh kb on kb.idkhambenh=kbCLS.idkhambenh" + "\r\n"
            + "  left join benhnhan bn on bn.idbenhnhan=kb.idbenhnhan" + "\r\n"
            + "  left join banggiadichvu dv on dv.idbanggiadichvu=kbCLS.idcanlamsan" + "\r\n"
            + "  left join phongkhambenh pk on dv.idphongkhambenh=pk.idphongkhambenh" + "\r\n"
            + "   where kb.idkhambenh=" + Request.QueryString["idkhambenh"].ToString() + "" + "";// and kbCLS.idkhambenhcanlamsan in (" + listidThu + ") \r\n"
            if(listidThu != "")
                    sql += " and kbCLS.idkhambenhcanlamsan in ("+listidThu+") \r\n";
                sql += "  group by pk.tenphongkhambenh,bn.mabenhnhan,tenbenhnhan,ngaysinh,bn.IDBenhNhan,dv.tendichvu" + "\r\n";

        }
        else if (Request.QueryString["idbn"] != null) 
        {
            //Code cu
            //sql = "select mabenhnhan,gioH='',ngayH='',thangH='',namH='',tenbenhnhan,ngaysinh as t,tenbacsi='' from benhnhan where idbenhnhan=" + Request.QueryString["idbn"] + "";
            //TRUONGNHAT-PC CAP NHAT THEM TEN KHOA PHONG VA CHI DINH VAO PHIEU HEN KET QUA
            sql=""
                + " select ChiDinh= DBO.GetDichVuCLS3(BN.IDBenhNhan,'',''),pk.tenphongkhambenh,bn.mabenhnhan,gioH='',ngayH='',thangH='',namH='',tenbenhnhan,ngaysinh as t,tenbacsi=''" + "\r\n"
                +"  from benhnhan bn" + "\r\n"
                +" left join khambenhcanlamsan kb on kb.idbenhnhan=bn.idbenhnhan" + "\r\n"
                +" left join banggiadichvu dv on dv.idbanggiadichvu=kb.idcanlamsan" + "\r\n"
                +" left join phongkhambenh pk on dv.idphongkhambenh=pk.idphongkhambenh" + "\r\n"
                + "  where bn.idbenhnhan=" + Request.QueryString["idbn"] + "" + "";//  and kb.idkhambenhcanlamsan in (" + listidThu + ") \r\n"
            if (listidThu != "")
                sql += " and kb.idkhambenhcanlamsan in (" + listidThu + ") \r\n";

                sql += " group by pk.tenphongkhambenh,bn.mabenhnhan,tenbenhnhan,ngaysinh,bn.IDBenhNhan" + "\r\n";
        
        }
        dt = DataAcess.Connect.GetTable(sql);
       
        #region Report tiêu đề
        R.Load(Server.MapPath("../Report/PhieuHenKQ.rpt"));
        DataTable dtTieuDeCty = DataAcess.Connect.GetTable("SELECT * FROM TIEUDECTY");
        if (dtTieuDeCty != null)
            R.OpenSubreport("crpt_ThongTinDonVi.rpt").SetDataSource(dtTieuDeCty);
        string tieude = dtTieuDeCty.Rows[0]["Ten_Cty"].ToString();
        string[] slp = tieude.Split('-');
        string til = slp[0];
        string subtil =(slp.Length>1 ? slp[1] :"");
        ((TextObject)R.OpenSubreport("crpt_ThongTinDonVi.rpt").ReportDefinition.ReportObjects["txtSubtitle"]).Text = subtil;
        ((TextObject)R.OpenSubreport("crpt_ThongTinDonVi.rpt").ReportDefinition.ReportObjects["txtTitle"]).Text = til;
        
        #endregion

        DataSet ds = new DataSet();
        #region ma vach
        string mabenhnhan = dt.Rows[0]["mabenhnhan"].ToString();
        iTextSharp.text.pdf.Barcode128 barcode = new iTextSharp.text.pdf.Barcode128();
        barcode.ChecksumText = false;
        barcode.Code = mabenhnhan;
        DataTable dtmavach = new DataTable();
        bool dkPK = (StaticData.GetParameter("sysBarcode") == "1");
        if (dkPK == true)
        {

            DataRow Row = dtmavach.NewRow();
            System.Drawing.Image bmp = barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White);
            Byte[] arrByte = (Byte[])System.ComponentModel.TypeDescriptor.GetConverter(bmp).ConvertTo(bmp, typeof(Byte[]));
            dtmavach.Columns.Add("MaVachKhoe", arrByte.GetType());




            Row["MaVachKhoe"] = arrByte;
            dtmavach.Rows.Add(Row);
        }
        #endregion
        dtmavach.TableName = "MaVach";
        ds.Tables.Add(dtmavach);


        R.SetDataSource(ds);

        R.SetParameterValue("gio", DateTime.Now.Hour.ToString());
        R.SetParameterValue("ngay", DateTime.Now.Day.ToString());
        R.SetParameterValue("thang", DateTime.Now.Month.ToString());
        R.SetParameterValue("nam", DateTime.Now.Year.ToString());
        R.SetParameterValue("gioHen", dt.Rows[0]["gioH"].ToString());
        R.SetParameterValue("ngayHen", dt.Rows[0]["ngayH"].ToString());
        R.SetParameterValue("thangHen", dt.Rows[0]["thangH"].ToString());
        R.SetParameterValue("namHen", dt.Rows[0]["namH"].ToString());
        R.SetParameterValue("tenBN", dt.Rows[0]["tenbenhnhan"].ToString());
        R.SetParameterValue("tuoi", dt.Rows[0]["t"].ToString());
        R.SetParameterValue("bsdieutri", dt.Rows[0]["tenbacsi"].ToString());
        R.SetParameterValue("maBN", dt.Rows[0]["mabenhnhan"].ToString());
        //SHOW THEM CHI DINH VA KHOA PHONG
        if (Request.QueryString["idkhambenh"] != null)
        {
            string ChiDinh = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                    ChiDinh += "\"" + dt.Rows[i]["ChiDinh"].ToString() + "\",";
            }
            ChiDinh = ChiDinh.TrimEnd(',');
            R.SetParameterValue("txtChiDinh", ChiDinh);
        }
        else
        R.SetParameterValue("txtChiDinh", dt.Rows[0]["ChiDinh"].ToString());
        string CacKhoa = "";
        string[] arrK = new string[] { };
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Array.IndexOf(arrK, dt.Rows[i]["tenphongkhambenh"].ToString()) == -1)
            {
                Array.Resize(ref arrK, arrK.Length + 1);
                arrK[arrK.Length - 1] = dt.Rows[i]["tenphongkhambenh"].ToString();
                CacKhoa += dt.Rows[i]["tenphongkhambenh"].ToString() + ",";
            }
        }
        CacKhoa = CacKhoa.TrimEnd(',');
            R.SetParameterValue("txtKhoa", CacKhoa);
        this.crptView.ReportSource = R;
        this.crptView.DataBind();
    }
    protected void crptView_Unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);

    }
    #region khoi tao va giai phong bo nho
    protected void form_unload(object sender, EventArgs e)
    {
        StaticData.DisPoseReport(R);
    }    
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
}
