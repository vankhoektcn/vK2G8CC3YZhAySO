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

public partial class frm_PhieuYCXuat_ajax : System.Web.UI.Page
 {
     protected void Page_Load(object sender, EventArgs e)
     {
         string action = Request.QueryString["do"];
         switch (action)
         {
             case "Them": InsertThuoc_PhieuYCXuat(); break;
             case "Sua": UpdateThuoc_PhieuYCXuat(); break;
             case "TimKiem": TimKiem(); break;
             case "setTimKiem": setTimKiem(); break;
             case "luuTableThuoc_ChiTietPhieuYCXuat": LuuTableThuoc_ChiTietPhieuYCXuat();break ;
             case "loadTableThuoc_ChiTietPhieuYCXuat": loadTableThuoc_ChiTietPhieuYCXuat(); break;
             case "loadTableThuoc_ChiTietPhieuDaYCXuat": loadTableThuoc_ChiTietPhieuDaYCXuat(); break;
             case "xoa": XoaThuoc_PhieuYCXuat(); break;
             case "xoaThuoc_ChiTietPhieuYCXuat": XoaThuoc_ChiTietPhieuYCXuat(); break;
              case "droplist_idphongkhambenh": LoadDropList_idphongkhambenh(); break;
              case "droplist_idloaithuoc": LoadDropList_idloaithuoc(); break;
              case "getthuoc": getthuoc(); break;

              case "NewMaPhieuYCLinhThuoc": NewMaPhieuYCLinhThuoc(); break;
              case "NewMaPhieuYCTraThuoc": NewMaPhieuYCTraThuoc(); break;
              case "loadTableThuoc_BNTra": loadTableThuoc_BNTra(); break;
              case "BeforeLuuBenhNhanTraThuoc": InsertThuoc_PhieuYCTra(); break;
              case "UpdateThuoc_PhieuYCTra": UpdateThuoc_PhieuYCTra(); break;
              case "LuuBenhNhanTraThuoc": LuuTableThuoc_ChiTietPhieuBNTraThuoc(); break;//LuuBenhNhanTraThuoc(); break;
              case "xoaNVK_Thuoc_PhieuYCTra": xoaNVK_Thuoc_PhieuYCTra(); break;
              case "xoaNVK_Thuoc_chitietPhieuYCTra": xoaNVK_Thuoc_chitietPhieuYCTra(); break;

              case "setTimKiemDaYCTra": setTimKiemDaYCTra(); break;
              case "LoadDanhSachPhieuDaYCTra": LoadDanhSachPhieuDaYCTra(); break;
              case "loadChiTietPhieuDaYC_Tra": loadChiTietPhieuDaYC_Tra(); break;

                 //nvk function 
              case "nvk_LoadTableThuocYeuCauXuat": nvk_LoadTableThuocChuaYeuCauXuat(); break;
              case "nvk_XoaPhieuYCXuat": nvk_XoaPhieuYCXuat(); break;
         }
     }
    private void loadChiTietPhieuDaYC_Tra()
    {
        string idPhieuTra = Request.QueryString["idkhoachinh"];
        if(idPhieuTra==null && idPhieuTra.Equals(""))
            idPhieuTra= "0";
        //DataTable table1 = Thuoc_Process.Thuoc_DonViTinh.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");
        DataTable table1 = DataAcess.Connect.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");
        string html = "";
        html += "<table id=\"gridTables\" border=\"1\" align=\"center\" width=\"100%\" bgcolor=\"white\">";
        html += "<tr style='background-color:#4D67A2;color:white;height:25px;text-align:center'>";
        html += "<td style='font-size:20px;font-weight:bold'>STT</td>";
        html += "<td></td>";
        html += "<td></td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maSP") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenSP") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DVT") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Số lượng trả</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Số lượng nhận</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</td>";
        int stt = 0;
        string sqlDSYC = @"select ct.IdChiTietPhieuYCtra,t.idthuoc,t.sttindm05,t.tenthuoc,t.iddvt,SoLuong=ct.soluong,Slxuat=ct.slNhan,GhiChu=''
                            from NVK_Thuoc_chitietPhieuYCTra ct inner join NVK_Thuoc_PhieuYCTra yc on YC.IdPhieuYCTra=ct.IdPhieuYCTra 
	                            inner join thuoc t on t.idthuoc= ct.idthuoc
                            where yc.IdPhieuYCTra=" +idPhieuTra+@"
                            order by t.tenthuoc";
        DataTable DSYC = DataAcess.Connect.GetTable(sqlDSYC);
        
            for (int i = 0; i < DSYC.Rows.Count; i++)
            {
                stt += 1;
                DataTable tablethuoc = DataAcess.Connect.GetTable("select top 1 sttindm05,iddvt from thuoc where idthuoc='" + DSYC.Rows[i]["idthuoc"].ToString() + "'");
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td >" + stt.ToString() + "</td>";
                html += "<td ><a onclick='xoaontable(this.name,this)' name='" + DSYC.Rows[i]["IdChiTietPhieuYCtra"].ToString() + "'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input id='IDthuoc_" + stt.ToString() + "' type='hidden' value='" + DSYC.Rows[i]["idthuoc"].ToString() + "'/></td>";
                html += "<td ><input style='width:100px' id='sttindm05_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);checkchuyenphim=true;'  value='" + tablethuoc.Rows[0]["sttindm05"].ToString() + "'/></td>";
                html += "<td ><input style='width:300px' id='tenthuoc_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);timkiemthuoc(this);checkchuyenphim=true;'  value='" + DSYC.Rows[i]["tenthuoc"].ToString() + "'/></td>";
                html += "<td><select style='width:50px' id='dvt_" + stt.ToString() + "'  />";
                for (int ii = 0; ii < table1.Rows.Count; ii++)
                {
                    if (tablethuoc.Rows[0]["iddvt"].ToString() == table1.Rows[ii][0].ToString())
                    {
                        html += "<option selected value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                    }
                    else
                    {
                        html += "<option value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                    }
                }
                html += "</select></td>";
                html += "<td><input style='width:50px' id='SoLuong_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["SoLuong"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                html += "<td><input style='width:50px' id='SLXuat_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["Slxuat"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                html += "<td><input style='width:250px'  id='GhiChu_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["GhiChu"].ToString() + "' /></td>"; //onkeydown='chuyendong(this);'
                html += "<td><input type='hidden' id='idchitietTra' value='0'/></td>";
                html += "</tr>";
            }
        string sqlIdChiTiet = @"select idchitietbenhnhantoathuoc from NVK_Thuoc_ChiTietYCTra_bntt a 
                                left join NVK_Thuoc_chitietPhieuYCTra ct on a.IdChiTietPhieuYCTra=ct.IdChiTietPhieuYCTra
                                where ct.IdPhieuYCTra="+idPhieuTra+"";
        DataTable dtIdCT = DataAcess.Connect.GetTable(sqlIdChiTiet);
        string strIdChitiet = "";
        if (dtIdCT.Rows.Count > 0)
            for (int k = 0; k < dtIdCT.Rows.Count; k++)
                strIdChitiet += dtIdCT.Rows[k]["idchitietbenhnhantoathuoc"].ToString() + ",";
        html += "<tr><td><input type='hidden' id='listIdChiTietToaThuoc' value='" + strIdChitiet + "'/></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }
    public void LoadDanhSachPhieuDaYCTra()
    {
        string idLoaiThuoc = Request.QueryString["idLoaiThuoc"] != null ? Request.QueryString["idLoaiThuoc"].ToString() : "";

        //DataTable table1 = Thuoc_Process.Thuoc_DonViTinh.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");
        //DataTable table = Thuoc_Process.Thuoc_ChiTietPhieuYCXuat.GetTable("select ctthuoc.*,t.tenthuoc from Thuoc_ChiTietPhieuYCXuat ctthuoc left join thuoc t on t.idthuoc=ctthuoc.idthuoc where ctthuoc.IdPhieuYC='" + sql + "'");
        string IdKhoYC = Request.QueryString["IdKhoYC"].ToString();
        if (IdKhoYC.Trim() == "") IdKhoYC = "0";
        string NgayYC = Request.QueryString["NgayYC"].ToString();
        string SoPhieuYC = Request.QueryString["SoPhieuYC"].ToString();
        string sqlYC = @"select IdPhieuYCTra,convert(varchar(10),ngayYC,103)+' '+convert(varchar(10),ngayYC,108) as NgayYC
                ,sophieu,tennguoidung,tenkho
                ,case when isnull((select top 1 idThuoc_ChiTietYeuCauTra from NVK_Thuoc_ChiTietYCTra_bntt nvk left join NVK_Thuoc_chitietPhieuYCTra ct on ct.IdChiTietPhieuYCTra=nvk.IdChiTietPhieuYCTra
                                  where ct.IdPhieuYCTra=yc.IdPhieuYCTra and nvk.isDaTra=1 ),0)=0 then N'Chưa duyệt'
                    else N'Đã duyệt' end as  TrangThai
                 from NVK_Thuoc_PhieuYCTra yc left join nguoidung nd on nd.idnguoidung=yc.idnguoiYC
                left join khothuoc kho on kho.idkho=yc.idphongkhambenh
                where yc.idphongkhambenh=" + IdKhoYC + @"";
        if (!NgayYC.Equals(""))
            sqlYC += @" and convert(varchar(10),ngayYC,103)='" + NgayYC + @"' ";
        if (!SoPhieuYC.Equals(""))
            sqlYC += " and YC.SoPhieu like N'%" + SoPhieuYC + "%'";
        if (idLoaiThuoc != "")
            sqlYC += @" and yc.loaithuocid=" + idLoaiThuoc + " ";
        sqlYC += @"order by IdPhieuYCTra desc ";
        DataTable table = DataAcess.Connect.GetTable(sqlYC);
        string html = "";
        html += "<table id=\"gridTables\" border=\"1\" align=\"center\" width=\"100%\" bgcolor=\"white\">";
        html += "<tr style='background-color:#4D67A2;color:white;height:25px;text-align:center'>";
        html += "<td style='font-size:10px;font-weight:bold'>STT</td>";
        html += "<td style='width:15px'></td>";
        html += "<td></td>";
        html += "<td style='font-size:12px;font-weight:bold'>Ngày Y/C</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Kho yêu cầu</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Người yêu cầu</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Số phiếu</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Trạng thái</td>";
        //html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Slxuat") + "</td>";
        //html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</td>";
        int stt = 0;
        string strIdChitiet = "";
        #region Load Các thuốc đã yêu cầu xuất
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                stt = i + 1;
                //DataTable tablethuoc = DataAcess.Connect.GetTable("select top 1 sttindm05,iddvt from thuoc where idthuoc='" + table.Rows[i]["idthuoc"].ToString() + "'");
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td >" + (i + 1) + "</td>";
                html += @"<td ><a ";
                //if (table.Rows[i]["TrangThai"].ToString().Equals("Chưa duyệt"))
                html += @"onclick='Inphieu(" + table.Rows[i]["IdPhieuYCTra"].ToString() + @")'";
                //else { }
                html += @"name='" + table.Rows[i]["IdPhieuYCTra"].ToString() + "'>In phiếu Y/C</a></td>";
                html += @"<td><input id='IDthuoc_" + (i + 1) + "' type='hidden' value='" + table.Rows[i]["NgayYC"].ToString() + @"'/> 
                    <a onclick='SuaphieuYC(" + table.Rows[i]["IdPhieuYCTra"].ToString() + ")' name='" + table.Rows[i]["IdPhieuYCTra"].ToString() + @"'>";
                if (table.Rows[i]["TrangThai"].ToString().Equals("Chưa duyệt"))
                    html += @"Sửa";
                html += @"</a>
                    </td>";
                html += "<td ><input style='width:100%' id='sttindm05_" + (i + 1) + "' type='text' value='" + table.Rows[i]["NgayYC"].ToString() + "'/></td>";
                html += "<td ><input style='width:100%' id='tenthuoc_" + (i + 1) + "'  type='text' value='" + table.Rows[i]["tenkho"].ToString() + "'/></td>";

                html += "<td><input style='width:100%' id='tennguoidung_" + (i + 1) + "' type='text' value='" + table.Rows[i]["tennguoidung"].ToString() + "'/></td>";
                html += "<td><input style='width:100%' id='SoPhieu_" + (i + 1) + "' type='text' value='" + table.Rows[i]["sophieu"].ToString() + "' /></td>";
                html += "<td ><a  name='" + table.Rows[i]["TrangThai"].ToString() + "'>" + table.Rows[i]["TrangThai"].ToString() + "</a></td>";
                html += "<td><input type='hidden' value='" + table.Rows[i]["IdPhieuYCTra"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        #endregion
        //end Load Các thuốc đã yêu cầu xuất
        string sqlIdChiTiet = @"";
        html += "<tr><td><input type='hidden' id='listIdChiTietToaThuoc' value='" + strIdChitiet + "'/></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }
    private void setTimKiemDaYCTra()
    {
        Response.Clear();Response.Write("");
    }
    private void NewMaPhieuYCTraThuoc()
    {
        string ngayYC = DataAcess.Connect.GetTable("select convert(varchar(10),getdate(),126)").Rows[0][0].ToString();
        string MaPhieuYC = StaticData.NewPhieuYeuCauTraThuoc(ngayYC);
        Response.Clear();
        Response.Write(MaPhieuYC);
    }
    private void InsertThuoc_PhieuYCTra()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"];
            string ListIdChiTietToaThuoc = Request.QueryString["ListIdChiTietToaThuoc"].ToString().TrimEnd(',').TrimStart(',');
            if (ListIdChiTietToaThuoc.Equals(""))
            {
                Response.Clear(); Response.Write("");
                return;
            }
            string NgayYC_Tra = StaticData.CheckDate(Request.QueryString["NgayTra"].ToString());
            if(!NgayYC_Tra.Equals(""))
                NgayYC_Tra += " " + DateTime.Now.ToString("HH:mm");
            else
                NgayYC_Tra = DateTime.Now.ToString("yyyy/MM/dd HH:mm");//
            string SoPhieu = Request.QueryString["SoPhieu"].ToString();
            string idnguoiYC = SysParameter.UserLogin.UserID(this);
            string idloaithuoc = Request.QueryString["idloaithuoc"];
            string idphongkhambenh = Request.QueryString["idphongkhambenh"].ToString();
            string ghichu = Request.QueryString["ghichu"].ToString();
            DataTable k = DataAcess.Connect.GetTable("SELECT TOP 1 IdPhieuYCTra FROM NVK_Thuoc_PhieuYCTra ORDER BY IdPhieuYCTra DESC");
            string so = "0";
            if (k.Rows.Count > 0)
            {
                so = k.Rows[0][0].ToString();
            }
            int IdTang = int.Parse(so) + 1;

            string sqlInsert = @"
            insert into NVK_Thuoc_PhieuYCTra (
                IdPhieuYCTra,NgayYC,
                SoPhieu,idnguoiYC,
                idphongkhambenh,ghichu,
                LoaiThuocID,LoaiTraID
                )
                values(
                " + IdTang.ToString() + @",'" + NgayYC_Tra + @"',
                '" +SoPhieu+"',"+idnguoiYC+@",
                "+idphongkhambenh+",N'"+ghichu+@"',
                "+idloaithuoc+@",1
            )";
            bool ktInsert = DataAcess.Connect.ExecSQL(sqlInsert);
            if (ktInsert)
            {
                //if(Request.QueryString["IdKhoYC"] !=null )
                //{
                //    string sqlupdate = @"update Thuoc_PhieuYCXuat set idKhoYC=" + Request.QueryString["IdKhoYC"].ToString()+ " where idphieuYC=" + tempTT.IdPhieuYC + "";
                //    bool ktUD = DataAcess.Connect.ExecSQL(sqlupdate);
                //}
                string idInsert = DataAcess.Connect.GetTable("SELECT TOP 1 IdPhieuYCTra FROM NVK_Thuoc_PhieuYCTra ORDER BY IdPhieuYCTra DESC").Rows[0][0].ToString();
                Response.Clear(); Response.Write(idInsert);
                return;
            }
        }
        catch
        {
        }
        Response.Clear(); Response.Write("");
    }
    private void UpdateThuoc_PhieuYCTra()
    {
        try
        {
            char[] splitter = { '/' };
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string NgayYC = StaticData.CheckDate(Request.QueryString["NgayYC"].ToString());
            string SoPhieu = Request.QueryString["SoPhieu"].ToString();
            string idnguoiYC = SysParameter.UserLogin.UserID(this);
            string idphongkhambenh = Request.QueryString["idphongkhambenh"].ToString();
            string ghichu = Request.QueryString["ghichu"].ToString();
            //string idloaithuoc = Request.QueryString["idloaithuoc"];
            string idloaithuoc = DataAcess.Connect.GetTable("select * from NVK_Thuoc_PhieuYCTra where IdPhieuYCTra=" + idkhoachinh + "").Rows[0]["loaithuocid"].ToString();

            //Thuoc_Process.Thuoc_PhieuYCXuat temp = Thuoc_Process.Thuoc_PhieuYCXuat.Create_Thuoc_PhieuYCXuat(idkhoachinh);
            //bool ok = temp.Save_Object(temp.IdPhieuYC, temp.NgayYC, temp.SoPhieu, idnguoiYC, idphongkhambenh, ghichu, idloaithuoc);
            string SqlUpdate = @" update  NVK_Thuoc_PhieuYCTra set idnguoiYC="+idnguoiYC+" where IdPhieuYCTra="+idkhoachinh+" ";
            bool ok = DataAcess.Connect.ExecSQL(SqlUpdate);
            if (ok)
            {
                string Del_NVK_Thuoc_ChiTietYCXuat = @"delete from NVK_Thuoc_ChiTietYCTra_bntt where idThuoc_ChiTietYeuCauTra in
                    (select idThuoc_ChiTietYeuCauTra from NVK_Thuoc_ChiTietYCTra_bntt nvk left join NVK_Thuoc_chitietPhieuYCTra ct on nvk.IdChiTietPhieuYCTra=ct.IdChiTietPhieuYCTra where ct.IdPhieuYCTra=" + idkhoachinh + ")";
                bool ktDel = DataAcess.Connect.ExecSQL(Del_NVK_Thuoc_ChiTietYCXuat);
                Response.Clear(); Response.Write(idkhoachinh);
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    public void LuuTableThuoc_ChiTietPhieuBNTraThuoc()
    {
        if (Request.QueryString["idthuoc"] != "")
        {
            try
            {
                string idkhoachinh = "0";//Request.QueryString["idkhoachinh"].ToString();
                string IdPhieuYC = Request.QueryString["IdPhieuYC"].ToString();
                string IDthuoc = Request.QueryString["IDthuoc"].ToString();
                string sqlTonTai = "select IdChiTietPhieuYCTra from NVK_Thuoc_chitietPhieuYCTra where IDthuoc="+IDthuoc+" and IdPhieuYCTra=" + IdPhieuYC;
                DataTable dtTT= DataAcess.Connect.GetTable(sqlTonTai);
                if (dtTT != null && dtTT.Rows.Count > 0)
                    idkhoachinh = dtTT.Rows[0]["IdChiTietPhieuYCTra"].ToString();
                string SoLuong = Request.QueryString["SoLuong"].ToString();
                string slNhan = Request.QueryString["slxuat"].ToString();
                string GhiChu = Request.QueryString["GhiChu"].ToString();
                string listIdChitietbenhnhantoathuoc = Request.QueryString["ListIdChiTietToaThuoc"];
                //return;
                DataTable k = DataAcess.Connect.GetTable("SELECT TOP 1 IdChiTietPhieuYCTra FROM NVK_Thuoc_chitietPhieuYCTra ORDER BY IdChiTietPhieuYCTra DESC");
                string so = "0";
                if (k.Rows.Count > 0)
                {
                    so = k.Rows[0][0].ToString();
                }
                int IdTang = int.Parse(so) + 1;
                if (!idkhoachinh.Trim().Equals("") && !idkhoachinh.Trim().Equals("0"))
                {
                    //Thuoc_Process.Thuoc_ChiTietPhieuYCXuat temp = Thuoc_Process.Thuoc_ChiTietPhieuYCXuat.Create_Thuoc_ChiTietPhieuYCXuat(idkhoachinh);
                    //bool ok = temp.Save_Object(temp.IdChiTietPhieuYC, IdPhieuYC, IDthuoc, SoLuong, GhiChu, slxuat);
                    string SqlUpdate = @" update  NVK_Thuoc_chitietPhieuYCTra set IDthuoc="+IDthuoc+",SoLuong="+SoLuong+",GhiChu=N'"+GhiChu+"',SlNhan=" + slNhan + " where IdChiTietPhieuYCTra= " + idkhoachinh;
                    bool ok = DataAcess.Connect.ExecSQL(SqlUpdate);
                    if (ok)
                    {
                        InsertRow_NVK_Thuoc_ChiTietYCTra_bntt(idkhoachinh, IDthuoc, listIdChitietbenhnhantoathuoc);
                        Response.Clear(); Response.Write(idkhoachinh);
                        return;
                    }
                }
                else
                {
                    //Thuoc_Process.Thuoc_ChiTietPhieuYCXuat tempTT = Thuoc_Process.Thuoc_ChiTietPhieuYCXuat.Insert_Object(int.Parse(so) + 1 + "", IdPhieuYC, IDthuoc, SoLuong, GhiChu, slxuat);
                    string sqlInsert = @"
                        insert into NVK_Thuoc_chitietPhieuYCTra (
                        IdChiTietPhieuYCTra,IdPhieuYCTra,
                        IDthuoc,SoLuong,
                        GhiChu,SlNhan
                        )
                        values(
                        " + IdTang.ToString() + "," + IdPhieuYC + @",
                        " +IDthuoc+","+SoLuong+@",
                        N'"+GhiChu+"',"+slNhan+@"
                        )";
                    bool ktInsert = DataAcess.Connect.ExecSQL(sqlInsert);
                    if (ktInsert)
                    {
                        //string idInsert = DataAcess.Connect.GetTable("SELECT TOP 1 IdChiTietPhieuYCTra FROM NVK_Thuoc_chitietPhieuYCTra ORDER BY IdPhieuYCTra DESC").Rows[0][0].ToString();
                        InsertRow_NVK_Thuoc_ChiTietYCTra_bntt(IdTang.ToString(), IDthuoc, listIdChitietbenhnhantoathuoc);
                        if (listIdChitietbenhnhantoathuoc != null)
                        {
                            string[] arrIdCTBenhNhan = listIdChitietbenhnhantoathuoc.ToString().Split(',');
                            for (int i = 0; i < arrIdCTBenhNhan.Length; i++)
                            {
                                int idct = StaticData.ParseInt(arrIdCTBenhNhan[i]);
                                if (idct > 0)
                                {
                                    string sqlCT = "update chitietbenhnhantoathuoc set IsDaXuatTra='1' where idchitietbenhnhantoathuoc=" + idct;
                                    DataAcess.Connect.ExecSQL(sqlCT);
                                }
                            }
                        }
                        Response.Clear(); Response.Write(IdTang.ToString());
                        return;
                    }
                }

            }
            catch (Exception) { }
        }
        Response.StatusCode = 500;
    }
    private void LuuBenhNhanTraThuoc()
    {
        if (Request.QueryString["idthuoc"] != "")
        {
            try
            {
                string idchitietbenhnhantoathuoc = Request.QueryString["idchitietbenhnhantoathuoc"].ToString();
                string IDthuoc = Request.QueryString["IDthuoc"].ToString();
                string SoLuongTra = Request.QueryString["SoLuong"].ToString();
                string slNhan = Request.QueryString["slxuat"].ToString();
                string GhiChu = Request.QueryString["GhiChu"].ToString();
                DataTable dtCTTT = DataAcess.Connect.GetTable(@"select soluongxuat=CEILING(soluongke-isnull(soluongtra,0)),CEILING(soluongke) as soluongkeBN,b.idbenhnhan,a.* from chitietbenhnhantoathuoc a left join khambenh b on a.idkhambenh=b.idkhambenh where idchitietbenhnhantoathuoc='" + idchitietbenhnhantoathuoc + "'");
                if(dtCTTT.Rows.Count >0)
                {
                string sqlPhieuXuatDau = @"select top 1 * from chitietphieuxuatkho where idchitietbenhnhantoathuoc='"+idchitietbenhnhantoathuoc+@"' and idthuoc ='"+IDthuoc+"' order by idchitietphieuxuat asc";
                DataTable dtPhieuXuatDau = DataAcess.Connect.GetTable(sqlPhieuXuatDau);
                if (dtPhieuXuatDau.Rows.Count > 0)
                {
                    string Del = @"delete from chitietphieuxuatkho where idchitietbenhnhantoathuoc='" + idchitietbenhnhantoathuoc + "'  and idthuoc ='" + IDthuoc + "'  and idchitietphieuxuat <> '" + dtPhieuXuatDau.Rows[0]["idchitietphieuxuat"].ToString() + "'";
                    bool ktDel = DataAcess.Connect.ExecSQL(Del);
                    if (ktDel)
                    {
                        int SoLuongMoi = StaticData.ParseInt(dtCTTT.Rows[0]["soluongkeBN"]) - StaticData.ParseInt(SoLuongTra);
                        string Up = @"update chitietphieuxuatkho set soluong='" + SoLuongMoi + "' where idchitietphieuxuat='" + dtPhieuXuatDau.Rows[0]["idchitietphieuxuat"].ToString() + "'";
                        ktDel = DataAcess.Connect.ExecSQL(Up);
                        Up = @"update chitietbennhnhantoathuoc set isDaXuatTra=1 where idchitietbenhnhantoathuoc='" + idchitietbenhnhantoathuoc + "'";
                        ktDel = DataAcess.Connect.ExecSQL(Up);
                    }
                }
                else
                {
                    string idkhambenh = dtCTTT.Rows[0]["idkhambenh"].ToString();
                    string idbenhnhan = dtCTTT.Rows[0]["idbenhnhan"].ToString();
                    string iddieuduong = SysParameter.UserLogin.UserID(this);
                    myInsertPhieuXuatKho.XuatTheoToa(null, idkhambenh);
                }
                }
            }
            catch (Exception) { }
        }
        Response.StatusCode = 500;
    }
    private void NewMaPhieuYCLinhThuoc()
    {
        string ngayYC = DataAcess.Connect.GetTable("select convert(varchar(10),getdate(),126)").Rows[0][0].ToString();
        string MaPhieuYC = StaticData.NewPhieuYeuCauLinhThuoc(ngayYC);
        Response.Clear();
        Response.Write(MaPhieuYC);
    }
     private void getthuoc()
     {
         StaticData.getthuoc(this);
//         string sql = "";         
//         if (Request.QueryString["q"] != null)
//         {
//             sql = " and tenthuoc like N'" + Request.QueryString["q"] + "%' ";
//         }
//         string loaithuocid = (Request.QueryString["loaithuoc"] != null ? Request.QueryString["loaithuoc"].ToString() : null);
//         if (Request.QueryString["loaithuoc"] != null && Request.QueryString["loaithuoc"].ToString() != "")
//         {
//             if (loaithuocid == "5" || loaithuocid == "6")
//             {
//                 sql += " and loaithuocid='1'";
//                 if (loaithuocid == "5")
//                     sql += " AND T.IsTGN=1 ";

//                 if (loaithuocid == "6")
//                     sql += "AND T.IsTHTT=1 ";
//             }
//             else
//                 sql += " and loaithuocid='" + loaithuocid + "'";

//         }
//         //string html = "";
//         //DataTable table = DataAcess.Connect.GetTable("select top 20 idthuoc,tenthuoc,sttindm05,iddvt from thuoc where tenthuoc like '" + sql + "%' and loaithuocid='"+Request.QueryString["loaithuoc"]+"'");
//         //for (int i = 0; i < table.Rows.Count; i++)
//         //{
//         //    html += table.Rows[i][1] + "|" + table.Rows[i][0] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + Environment.NewLine;
//         //}
//         string html =
//        string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", ""
//        + "<div style =\"color:#000;position:absolute;top:0px;left:0;z-index:1000;background-color:#cfcfcf;border:1px solid black;width:97%;height:30px;padding-right:25px\">"
//        + "<div style=\"width:20%;height:30px;color:#000;font-weight:bold;float:left\" >Biệt dược</div>"
//        + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >TT Hoạt chất</div>"
//        + "<div style=\"width:20%;height:30px;color:#000;font-weight:bold;float:left\" >Hoạt chất</div>"
//        + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left;\" >Đơn vị tính</div>"
//        + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >Hạn dùng</div>"
//        + "<div style=\"width:10%;height:30px;color:#000;font-weight:bold;float:left\" >Đơn giá</div>"
//        + "<div style=\"width:15%;height:30px;color:#000;font-weight:bold;float:left\" >Số lượng tồn</div>"
//        + "</div>", "", "", "", "","", Environment.NewLine);
//         html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", "<div style='height:35px'></div>", "", "", "", "","", Environment.NewLine);
//         string sql2 = @"select distinct  t.idthuoc,t.tenthuoc,t.congthuc,t.iddvt
//		,convert(varchar,a.ngayhethan,103)as ngayhethan
//        ,soLuongTon=  dbo.Thuoc_TongSLNhap(a.idthuoc,a.dongia,a.ngayhethan,null)-dbo.Thuoc_TongSLxuat(a.idthuoc,a.dongia,a.ngayhethan,null)
//        ,dvt.tendvt,t.sttindm05,t.tthoatchat,a.dongia
//        from chitietphieunhapkho a
//        inner join thuoc t on a.idthuoc=t.idthuoc
//        left join Thuoc_DonViTinh dvt on dvt.id=t.iddvt      
//        where  a.idthuoc is not null 
//        and  t.isthuocbv=1  " + sql
//        +"order by t.tenthuoc  ";
         
                  
//         DataTable table = DataAcess.Connect.GetTable(sql2);
//         foreach (DataRow h in table.Rows)
//         {
//             //html += table.Rows[i][1] + "|" + table.Rows[i][0] + "|" + table.Rows[i][2] + "|" + table.Rows[i][3] + Environment.NewLine;
//             html += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", "<div>"
//           + "<div style=\"width:20%;height:30px;float:left\" >" + h["tenthuoc"] + "</div>"
//           + "<div style=\"width:10%;height:30px;float:left\" >" + h["tthoatchat"] + "</div>"
//           + "<div style=\"width:20%;height:30px;float:left\" >" + h["congthuc"] + "</div>"
//           + "<div style=\"width:10%;height:30px;float:left\" >" + h["tendvt"] + "</div>"
//           + "<div style=\"width:15%;height:30px;float:left\" >" + h["ngayhethan"] + "</div>"
//           + "<div style=\"width:10%;height:30px;float:left\" >" + StaticData.FormatSNumberToPrint(h["dongia"].ToString()) + "</div>"
//           + "<div style=\"width:15%;height:30px;float:left\" >" + h["soLuongTon"] + "</div>"
//           + "</div>", h["idthuoc"], h["congthuc"], h["iddvt"], h["tenthuoc"], h["sttindm05"], Environment.NewLine);
//         }
//         Response.Clear();
//         Response.Write(html);
//         Response.End();
     }
 // luon luon chi co 2 truong la id va value
     private void LoadDropList_idphongkhambenh()
     {
         string sWTrong = "";
         if (Request.QueryString["dkMenu"] != null)
         {
             string dkMenu = Request.QueryString["dkMenu"].ToString();
             if (dkMenu == "capcuu")
                 sWTrong += " and pkb.maphongkhambenh='05'";
             else if (dkMenu == "khoanoi")
                 sWTrong += " and pkb.maphongkhambenh='04'";
             else if (dkMenu == "khoasan" || dkMenu == "phongsanh")
                 sWTrong += " and pkb.maphongkhambenh='03'";
             else if (dkMenu == "kb")
                 sWTrong += " and pkb.maphongkhambenh='01'";
             else if (dkMenu == "khoangoai")
                 sWTrong += " and pkb.maphongkhambenh='02'";
             else if (dkMenu == "phukhoa")
                 sWTrong += " and pkb.maphongkhambenh='02'";             
         }
         string sql=@"select k.* 
                    from khothuoc k
                    left join phongkhambenh pkb on pkb.idphongkhambenh=k.idkhoa where 1=1 and nvk_loaikho<>4"+sWTrong;
         DataTable table = Thuoc_Process.phongkhambenh .GetTable(sql);
         string html = "";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int y = 0; y < table.Rows.Count; y++)
             {
 
                 html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y][2].ToString();
 
             }
         }
     }
                Response.Clear(); Response.Write(html);
}
// luon luon chi co 2 truong la id va value
private void LoadDropList_idloaithuoc()
{
    DataTable table = Thuoc_Process.phongkhambenh.GetTable("select * from THUOC_loaithuoc ");
    string html = "";
    if (table != null)
    {
        if (table.Rows.Count > 0)
        {
            DataRow DR1 = table.NewRow();
            DR1[0] = "5";
            DR1[1] = "THUOCGN";
            DR1[2] = "T.G.Nghiện";
            table.Rows.Add(DR1);


            DataRow DR2 = table.NewRow();
            DR2[0] = "6";
            DR2[1] = "THUOCHTT";
            DR2[2] = "T.Hướng TT";
            table.Rows.Add(DR2);


            for (int y = 0; y < table.Rows.Count; y++)
            {

                html += "@" + table.Rows[y][0].ToString() + "^" + table.Rows[y][2].ToString();

            }
        }
    }
    Response.Clear(); Response.Write(html);
}

    private void xoaNVK_Thuoc_PhieuYCTra()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
             string sql = "delete NVK_Thuoc_PhieuYCTra where IdPhieuYCTra=" + idkhoachinh;
             bool ok = DataAcess.Connect.ExecSQL(sql);
             if (ok)
             {
                         Response.Clear();Response.Write(idkhoachinh);
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
     private void XoaThuoc_PhieuYCXuat()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
             string sql = "delete Thuoc_PhieuYCXuat where IdPhieuYC=" + idkhoachinh;
             //bool ok = Process.Thuoc_PhieuYCXuat.ExecSQL(sql);
             bool ok = DataAcess.Connect.ExecSQL(sql);
             if (ok)
             {
                         Response.Clear();Response.Write(idkhoachinh);
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
    private void xoaNVK_Thuoc_chitietPhieuYCTra()
    {
        try
        {
            string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
            string mySql=@"select top 1 IdPhieuYCTra from  NVK_Thuoc_chitietPhieuYCTra where idchitietphieuYCtra=" +idkhoachinh;
            DataTable dtPhieu=DataAcess.Connect.GetTable(mySql);
            string sql = "delete NVK_Thuoc_chitietPhieuYCTra where IdChiTietPhieuYCTra=" + idkhoachinh;
            bool ok = DataAcess.Connect.ExecSQL(sql);
            if (ok)
            {
                string sqlPhieu = @"select count(idchitietphieuYCtra) as dem from NVK_Thuoc_chitietPhieuYCTra where IdPhieuYCTra=
                isnull((select top 1 IdPhieuYCTra from  NVK_Thuoc_chitietPhieuYCTra where idchitietphieuYCtra="+idkhoachinh+@"),0)";
                DataTable dtPhieuTra = DataAcess.Connect.GetTable(sqlPhieu);
                if (dtPhieuTra != null && dtPhieuTra.Rows[0]["dem"].ToString() =="0")
                {
                    string SqlDeleTe = @"delete from NVK_Thuoc_PhieuYCTra where IdPhieuYCTra="+dtPhieu.Rows[0]["IdPhieuYCTra"];
                    bool kq = DataAcess.Connect.ExecSQL(SqlDeleTe);
                }
                Response.Clear(); Response.Write(idkhoachinh);
                return;
            }
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
     private void XoaThuoc_ChiTietPhieuYCXuat()
     {
         try
         {
             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
             string mySql = @"select top 1 IdPhieuYC from  Thuoc_ChiTietPhieuYCXuat where IdChiTietPhieuYC=" + idkhoachinh;
             DataTable dtPhieu = DataAcess.Connect.GetTable(mySql);
             string sql = "delete Thuoc_ChiTietPhieuYCXuat where IdChiTietPhieuYC=" + idkhoachinh;
             //bool ok = Process.Thuoc_ChiTietPhieuYCXuat.ExecSQL(sql);
             bool ok = DataAcess.Connect.ExecSQL(sql);
             if (ok)
             {
                 string sqlPhieu = @"select count(idchitietphieuYCtra) as dem from Thuoc_ChiTietPhieuYCXuat where IdPhieuYC=
                isnull((select top 1 IdPhieuYC from  Thuoc_ChiTietPhieuYCXuat where IdChiTietPhieuYC=" + idkhoachinh + @"),0)";
                DataTable dtPhieuTra = DataAcess.Connect.GetTable(sqlPhieu);
                if (dtPhieuTra != null && dtPhieuTra.Rows[0]["dem"].ToString() =="0")
                {
                    string SqlDeleTe = @"delete from Thuoc_PhieuYCXuat where IdPhieuYC=" + dtPhieu.Rows[0]["IdPhieuYC"];
                    bool kq = DataAcess.Connect.ExecSQL(SqlDeleTe);
                }
                         Response.Clear();Response.Write(idkhoachinh);
                 return;
             }
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
     private void setTimKiem()
     {
         string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
         string sW="";
         if (idkhoachinh == "")
         {
             sW += " and convert(varchar(10),ngayyc,103)=convert(varchar(10),getdate(),103) order by idphieuyc desc";
         }
         else
             sW += " and IdPhieuYC = " + idkhoachinh;

         string sWTrong = "";
         if (Request.QueryString["dkMenu"] != null)
         {
             string dkMenu = Request.QueryString["dkMenu"].ToString();
             if (dkMenu == "capcuu")
                 sWTrong += " and pkb.maphongkhambenh='05'";
             else if (dkMenu == "khoanoi")
                 sWTrong += " and pkb.maphongkhambenh='04'";
             else if (dkMenu == "khoasan")
                 sWTrong += " and pkb.maphongkhambenh='03'";
             else if (dkMenu == "kb")
                 sWTrong += " and pkb.maphongkhambenh='01'";
             else if (dkMenu == "khoangoai")
                 sWTrong += " and pkb.maphongkhambenh='02'";
             else if (dkMenu == "phukhoa")
                 sWTrong += " and pkb.maphongkhambenh='02'";
             else
                 sWTrong += " and 1=0";
         }
         else
             sWTrong = " and 1=0";
         int idkho = 0;
         if (Request.QueryString["idkho"] != null)
         {
             idkho = StaticData.ParseInt(Request.QueryString["idkho"].ToString());
         }
         if (idkhoachinh == "")
         {
             sWTrong += " and pyc.idphongkhambenh=" + idkho.ToString();
         }
         string sql=@"select pyc.IdPhieuYC,pyc.NgayYC,SoPhieu,pyc.idphongkhambenh,pyc.ghichu 
            from Thuoc_PhieuYCXuat pyc
            inner join khothuoc k on pyc.idphongkhambenh=k.idkho
            inner join phongkhambenh pkb on pkb.idphongkhambenh=k.idkhoa
            where 1=1 and isnull((select count(*) from Thuoc_chitietPhieuYCXuat ctyc 
					inner join chitietphieuxuatkho ctxk on ctxk.idchitietphieuyeucauxuatkho=ctyc.idchitietphieuyc
					where ctyc.IdPhieuYC=pyc.IdPhieuYC),0)=0 " + sWTrong + sW;
         //DataTable table = Process.Thuoc_PhieuYCXuat.GetTable(sql);
         DataTable table = DataAcess.Connect.GetTable(sql);
         string html = "";
         if (table != null)
         {
             if (table.Rows.Count > 0)
             {
                 for (int y = 0; y < table.Columns.Count; y++)
                 {
                     try
                     {

                         html += DateTime.Parse(table.Rows[0][y].ToString()).ToString("dd/MM/yyyy") + "@";
                     }
                     catch (Exception)
                     {
                         html += table.Rows[0][y].ToString() + "@";
                     }
                 }
             }
         }
         Response.Clear();Response.Write(html);
     }
 
     private void TimKiem()
     {
         string sql = "1=1";
         if (Request.QueryString["IdPhieuYC"] != null)
         {
             sql += " and IdPhieuYC = '" + Request.QueryString["IdPhieuYC"] + "'";
         }
         if (Request.QueryString["NgayYC"] != null){
 if(Request.QueryString["NgayYC"] == "")         {
             sql += " and NgayYC like '%'";
         }else{ sql += " and NgayYC >= '" + Request.QueryString["NgayYC"] + "'";
}}         if (Request.QueryString["SoPhieu"] != null)
         {
             sql += " and SoPhieu like N'%" + Request.QueryString["SoPhieu"] + "%'";
         }
         if (Request.QueryString["idnguoiYC"] != null)
         {
             sql += " and idnguoiYC = '" + Request.QueryString["idnguoiYC"] + "'";
         }
         if (Request.QueryString["idphongkhambenh"] != null)
         {
             sql += " and idphongkhambenh = '" + Request.QueryString["idphongkhambenh"] + "'";
         }
         if (Request.QueryString["ghichu"] != null)
         {
             sql += " and ghichu like N'%" + Request.QueryString["ghichu"] + "%'";
         }
         DataTable table = DataAcess.Connect.GetTable("select IdPhieuYC,NgayYC,SoPhieu,idnguoiYC,idphongkhambenh,ghichu  from Thuoc_PhieuYCXuat where " + sql);
         string html ="";
         html += "<table name=\"tablefind\" id=\"tablefind\" border=\"1\" align=\"center\" width=\"100%\">";
         html += "<tr style='background-color:#4D67A2;color:white;font-weight:bold'>";
         html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("IdPhieuYC") + "</td>";
         html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("NgayYC") + "</td>";
         html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoPhieu") + "</td>";
         html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idnguoiYC") + "</td>";
         html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("idphongkhambenh") + "</td>";
         html += "<td>" + hsLibrary.clDictionaryDB.sGetValueLanguage("ghichu") + "</td>";
         html += "</tr>";
         if(table != null){if (table.Rows.Count > 0)
         {
             for (int i = 0; i < table.Rows.Count; i++)
             {
                 html += "<tr id=\"background\" style='cursor:pointer;color:gray' onclick=\"setControlFind('" + table.Rows[i]["IdPhieuYC"].ToString() + "','" + hsLibrary.clDictionaryDB.sGetValueLanguage("update") + "')\">";
                         html += "<td>" + table.Rows[i]["IdPhieuYC"].ToString() + "</td>";
                         if(table.Rows[i]["NgayYC"].ToString() != ""){
                        html += "<td>" + DateTime.Parse(table.Rows[i]["NgayYC"].ToString()).ToShortDateString() + "</td>";}
                       else{ html += "<td>" + table.Rows[i]["NgayYC"].ToString() + "</td>";}
                         html += "<td>" + table.Rows[i]["SoPhieu"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["idnguoiYC"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["idphongkhambenh"].ToString() + "</td>";
                         html += "<td>" + table.Rows[i]["ghichu"].ToString() + "</td>";
                 html += "</tr>";
             }
             html += "</table>";
                     Response.Clear();Response.Write(html);
             return;
         }}
         else
         {
                     Response.StatusCode = 500;
         }
     }

     private void InsertThuoc_PhieuYCXuat()
     {
         //Response.Clear(); Response.Write("1");
         //return;// nvk return 
         try
         {
             #region nvk Comment 0509 
             //char[] splitter = { '/' };
             //string NgayYC = StaticData.CheckDate(Request.QueryString["NgayYC"].ToString()) + " " + DateTime.Now.ToString("hh:mm");
             //NgayYC = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
             //string SoPhieu = Request.QueryString["SoPhieu"].ToString();
             //string idnguoiYC = SysParameter.UserLogin.UserID(this);
             //string idloaithuoc = Request.QueryString["idloaithuoc"];
             //string idphongkhambenh = Request.QueryString["idphongkhambenh"].ToString();
             //string ghichu = Request.QueryString["ghichu"].ToString();
             //DataTable k = DataAcess.Connect.GetTable("SELECT TOP 1 IdPhieuYC FROM Thuoc_PhieuYCXuat ORDER BY IdPhieuYC DESC");
             //string so = "0";
             //if (k.Rows.Count > 0)
             //{
             //    so = k.Rows[0][0].ToString();
             //}

             //Thuoc_Process.Thuoc_PhieuYCXuat tempTT = Thuoc_Process.Thuoc_PhieuYCXuat.Insert_Object(int.Parse(so) + 1 + "", NgayYC, SoPhieu, idnguoiYC, idphongkhambenh, ghichu, idloaithuoc);
             //if (tempTT != null)
             //{
             //    //if(Request.QueryString["IdKhoYC"] !=null )
             //    //{
             //    //    string sqlupdate = @"update Thuoc_PhieuYCXuat set idKhoYC=" + Request.QueryString["IdKhoYC"].ToString()+ " where idphieuYC=" + tempTT.IdPhieuYC + "";
             //    //    bool ktUD = DataAcess.Connect.ExecSQL(sqlupdate);
             //    //}
             //    Response.Clear(); Response.Write(tempTT.IdPhieuYC);
             //    return;
             //} 
             #endregion
         }
         catch
         {
         }
         Response.Clear(); Response.Write("");


     }
     private void UpdateThuoc_PhieuYCXuat()
     {
         try
         {
             #region nvk Comment 0509
//             char[] splitter = { '/' };
//             string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
//             string NgayYC = StaticData.CheckDate(Request.QueryString["NgayYC"].ToString());
//             string SoPhieu = Request.QueryString["SoPhieu"].ToString();
//             string idnguoiYC = SysParameter.UserLogin.UserID(this);
//             string idphongkhambenh = Request.QueryString["idphongkhambenh"].ToString();
//             string ghichu = Request.QueryString["ghichu"].ToString();
//             //string idloaithuoc = Request.QueryString["idloaithuoc"];
//             string idloaithuoc = DataAcess.Connect.GetTable("select * from Thuoc_PhieuYCXuat where idphieuYC=" + idkhoachinh + "").Rows[0]["loaithuocid"].ToString();

//             Thuoc_Process.Thuoc_PhieuYCXuat temp = Thuoc_Process.Thuoc_PhieuYCXuat.Create_Thuoc_PhieuYCXuat(idkhoachinh);
//             bool ok = temp.Save_Object(temp.IdPhieuYC, temp.NgayYC, temp.SoPhieu, idnguoiYC, idphongkhambenh, ghichu, idloaithuoc);
//             if (ok)
//             {
//                 string Del_NVK_Thuoc_ChiTietYCXuat = @"delete from NVK_Thuoc_ChiTietYCXuat where idThuoc_ChiTietYeuCau in
//                    (select idThuoc_ChiTietYeuCau from NVK_Thuoc_ChiTietYCXuat nvk left join Thuoc_chitietPhieuYCXuat ct on nvk.IdChiTietPhieuYC=ct.IdChiTietPhieuYC where ct.idphieuYC=" + temp.IdPhieuYC + ")";
//                 bool ktDel = DataAcess.Connect.ExecSQL(Del_NVK_Thuoc_ChiTietYCXuat);
//                 Response.Clear(); Response.Write(idkhoachinh);
//                 return;
//             } 
             #endregion
         }
         catch
         {
         }
                     Response.StatusCode = 500;
     }
  public void LuuTableThuoc_ChiTietPhieuYCXuat()
     {
         if (Request.QueryString["idthuoc"] != "")
         {
             try
             {
                 #region nvk Comment 0509
                 //string idkhoachinh = Request.QueryString["idkhoachinh"].ToString();
                 //char[] splitter = { '/' };
                 //string IdPhieuYC = Request.QueryString["IdPhieuYC"].ToString();
                 //string IDthuoc = Request.QueryString["IDthuoc"].ToString();
                 //string SLKyNay = Request.QueryString["SLKyNay"].ToString();
                 //string SlKyTruoc = Request.QueryString["SlKyTruoc"].ToString();
                 //string TongSoLuong = Request.QueryString["TongSoLuong"].ToString();
                 //string slxuat = Request.QueryString["slxuat"].ToString();
                 //string GhiChu = Request.QueryString["GhiChu"].ToString();
                 //string listIdChitietbenhnhantoathuoc = Request.QueryString["ListIdChiTietToaThuoc"];
                 ////return;
                 //DataTable k = DataAcess.Connect.GetTable("SELECT TOP 1 IdChiTietPhieuYC FROM Thuoc_ChiTietPhieuYCXuat ORDER BY IdChiTietPhieuYC DESC");
                 //string so = "0";
                 //if (k.Rows.Count > 0)
                 //{
                 //    so = k.Rows[0][0].ToString();
                 //}
                 //if (!idkhoachinh.Trim().Equals(""))
                 //{
                 //    Thuoc_Process.Thuoc_ChiTietPhieuYCXuat temp = Thuoc_Process.Thuoc_ChiTietPhieuYCXuat.Create_Thuoc_ChiTietPhieuYCXuat(idkhoachinh);
                 //    bool ok = temp.Save_Object(temp.IdChiTietPhieuYC, IdPhieuYC, IDthuoc, TongSoLuong, GhiChu, slxuat);
                 //    if (ok)
                 //    {
                 //        bool ktUpdateSL = DataAcess.Connect.ExecSQL("update thuoc_chitietphieuYCxuat set SLKyNay='" + SLKyNay + "',SLKyTruocTreo=" + SlKyTruoc + " where IdChiTietPhieuYC=" + temp.IdChiTietPhieuYC + "");
                 //        InsertRow_NVK_Thuoc_ChiTietYCXuat(temp.IdChiTietPhieuYC, IDthuoc, listIdChitietbenhnhantoathuoc);
                 //        Response.Clear(); Response.Write(idkhoachinh);
                 //        return;
                 //    }
                 //}
                 //else
                 //{
                 //    Thuoc_Process.Thuoc_ChiTietPhieuYCXuat tempTT = Thuoc_Process.Thuoc_ChiTietPhieuYCXuat.Insert_Object(int.Parse(so) + 1 + "", IdPhieuYC, IDthuoc, TongSoLuong, GhiChu, slxuat);
                 //    if (tempTT != null)
                 //    {
                 //        bool ktUpdateSL = DataAcess.Connect.ExecSQL("update thuoc_chitietphieuYCxuat set SLKyNay='" + SLKyNay + "',SLKyTruocTreo=" + SlKyTruoc + " where IdChiTietPhieuYC=" + tempTT.IdChiTietPhieuYC + "");
                 //        InsertRow_NVK_Thuoc_ChiTietYCXuat(tempTT.IdChiTietPhieuYC, IDthuoc, listIdChitietbenhnhantoathuoc);
                 //        if (listIdChitietbenhnhantoathuoc != null)
                 //        {
                 //            string[] arrIdCTBenhNhan = listIdChitietbenhnhantoathuoc.ToString().Split(',');
                 //            for (int i = 0; i < arrIdCTBenhNhan.Length; i++)
                 //            {
                 //                int idct = StaticData.ParseInt(arrIdCTBenhNhan[i]);
                 //                if (idct > 0)
                 //                {
                 //                    string sqlCT = "update chitietbenhnhantoathuoc set IsDaYeuCau='1' where idchitietbenhnhantoathuoc=" + idct;
                 //                    DataAcess.Connect.ExecSQL(sqlCT); //nvk comment
                 //                }
                 //            }
                 //        }
                 //        Response.Clear(); Response.Write(tempTT.IdChiTietPhieuYC);
                 //        return;
                 //    }
                 //} 
                 #endregion
                
             }
             catch (Exception) { }
         }
                 Response.StatusCode = 500;
     }
    private void InsertRow_NVK_Thuoc_ChiTietYCTra_bntt(string IdChiTietPhieuYC, string idthuoc, string listIdChitietbenhnhantoathuoc)
    {
        string[] arrIdCTBNTT = listIdChitietbenhnhantoathuoc.ToString().Split(',');
        for (int i = 0; i < arrIdCTBNTT.Length; i++)
        {
            int idct = StaticData.ParseInt(arrIdCTBNTT[i]);
            if (idct > 0)
            {
                string sqlCT = "select idthuoc from  chitietbenhnhantoathuoc where idchitietbenhnhantoathuoc=" + idct;
                DataTable dtIDThuoc = DataAcess.Connect.GetTable(sqlCT);
                if (dtIDThuoc != null && dtIDThuoc.Rows.Count > 0)
                {
                    if (dtIDThuoc.Rows[0]["idthuoc"].ToString().Trim() == idthuoc)
                    {
                        string sqlInsert = @"insert into NVK_Thuoc_ChiTietYCTra_bntt (
                                IdChiTietPhieuYCTra,
                                Idchitietbenhnhantoathuoc,
                                isDaTra)
                                values(
                                " + IdChiTietPhieuYC + "," + idct + @",0
                                )";
                        bool ktInsert = DataAcess.Connect.ExecSQL(sqlInsert);
                    }
                }
            }
        }
    }
    private void InsertRow_NVK_Thuoc_ChiTietYCXuat(string IdChiTietPhieuYC,string idthuoc, string listIdChitietbenhnhantoathuoc)
    {
        string[] arrIdCTBNTT = listIdChitietbenhnhantoathuoc.ToString().Split(',');
        for (int i = 0; i < arrIdCTBNTT.Length; i++)
        {
            int idct = StaticData.ParseInt(arrIdCTBNTT[i]);
            if (idct > 0)
            {
                string sqlCT = "select idthuoc from  chitietbenhnhantoathuoc where idchitietbenhnhantoathuoc=" + idct;
                DataTable dtIDThuoc= DataAcess.Connect.GetTable(sqlCT);
                if (dtIDThuoc != null && dtIDThuoc.Rows.Count > 0)
                {
                    if (dtIDThuoc.Rows[0]["idthuoc"].ToString().Trim() == idthuoc)
                    {
                        string sqlInsert = @"insert into NVK_Thuoc_ChiTietYCXuat (
                                IdChiTietPhieuYC,
                                Idchitietbenhnhantoathuoc,
                                isDaXuat)
                                values(
                                "+IdChiTietPhieuYC+","+idct+@",0
                                )";
                        bool ktInsert = DataAcess.Connect.ExecSQL(sqlInsert);
                    }
                }
            }
        }
        listIdChitietbenhnhantoathuoc = listIdChitietbenhnhantoathuoc.TrimEnd(',');
        if (listIdChitietbenhnhantoathuoc.Equals(""))
            listIdChitietbenhnhantoathuoc = "0";
        string sqlUd_IsYCThuocTreo = @"update thuoc_chitietphieuYcXuat set Status_ThuocTreo=1
                             where IdChiTietPhieuYC <> '" + IdChiTietPhieuYC + "' and idthuoc='" + idthuoc + @"'
                             and IdChiTietPhieuYC in(select IdChiTietPhieuYC from NVK_Thuoc_ChiTietYCXuat where idchitietbenhnhantoathuoc in(" + listIdChitietbenhnhantoathuoc + @"))
                             and isnull(SoLuong,0) > isnull(SlXuat,0) ";
        bool ktUd_IsYCThuocTreo = DataAcess.Connect.ExecSQL(sqlUd_IsYCThuocTreo);
        string sqlUd_IsYCThuocTreo_YCLai = @"update thuoc_chitietphieuYcXuat set Status_ThuocTreo=2
                             where IdChiTietPhieuYC = '" + IdChiTietPhieuYC + "'";
        bool ktUd_IsYCThuocTreo_YCLai = DataAcess.Connect.ExecSQL(sqlUd_IsYCThuocTreo_YCLai);
    }
    
 public void loadTableThuoc_ChiTietPhieuYCXuat()
     {
         string NgayYC = Request.QueryString["ngayYC"] != null ? Request.QueryString["ngayYC"] : DateTime.Now.ToString("dd/MM/yyyy");         
         string idLoaiThuoc = Request.QueryString["idLoaiThuoc"] != null ? Request.QueryString["idLoaiThuoc"].ToString() : "";
         string sql="";
             sql+=Request.QueryString["idkhoachinh"].ToString();
             DataTable table1 = DataAcess.Connect.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");
             DataTable table = DataAcess.Connect.GetTable("select ctthuoc.*,t.tenthuoc from Thuoc_ChiTietPhieuYCXuat ctthuoc left join thuoc t on t.idthuoc=ctthuoc.idthuoc where ctthuoc.IdPhieuYC='" + sql + "'");
         string html ="";
         html += "<table id=\"gridTables\" border=\"1\" align=\"center\" width=\"100%\" bgcolor=\"white\">";
         html += "<tr style='background-color:#4D67A2;color:white;height:25px;text-align:center'>";
         html += "<td style='font-size:20px;font-weight:bold'>STT</td>";
         html += "<td></td>";
         html += "<td></td>";
         html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maSP") + "</td>";
         html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenSP") + "</td>";
         html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DVT") + "</td>";
         html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoLuong") + "</td>";
         html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Slxuat") + "</td>";
         html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</td>";
         int stt = 0;
         string strIdChitiet = "";
         if (Request.QueryString["Update"] != null)
         {
         #region Load Các thuốc đã yêu cầu xuất 
             if (table.Rows.Count > 0)
             {
                 for (int i = 0; i < table.Rows.Count; i++)
                 {
                     stt = i + 1;
                     DataTable tablethuoc = DataAcess.Connect.GetTable("select top 1 sttindm05,iddvt from thuoc where idthuoc='" + table.Rows[i]["idthuoc"].ToString() + "'");
                     html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                     html += "<td >" + (i + 1) + "</td>";
                     html += "<td ><a onclick='xoaontable(this.name,this)' name='" + table.Rows[i]["IdChiTietPhieuYC"].ToString() + "'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                     html += "<td><input id='IDthuoc_" + (i + 1) + "' type='hidden' value='" + table.Rows[i]["idthuoc"].ToString() + "'/></td>";
                     html += "<td ><input style='width:100px' id='sttindm05_" + (i + 1) + "' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);checkchuyenphim=true;'  value='" + tablethuoc.Rows[0]["sttindm05"].ToString() + "'/></td>";
                     html += "<td ><input style='width:300px' id='tenthuoc_" + (i + 1) + "' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);timkiemthuoc(this);checkchuyenphim=true;'  value='" + table.Rows[i]["tenthuoc"].ToString() + "'/></td>";
                     html += "<td><select style='width:50px' id='dvt_" + (i + 1) + "' disabled='true' />";
                     for (int ii = 0; ii < table1.Rows.Count; ii++)
                     {
                         if (tablethuoc.Rows[0]["iddvt"].ToString() == table1.Rows[ii][0].ToString())
                         {
                             html += "<option selected value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                         }
                         else
                         {
                             html += "<option value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                         }
                     }
                     html += "</select></td>";
                     html += "<td><input style='width:50px' id='SoLuong_" + (i + 1) + "' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + table.Rows[i]["SoLuong"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                     html += "<td><input style='width:50px' id='SLXuat_" + (i + 1) + "' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + table.Rows[i]["Slxuat"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                     html += "<td><input style='width:250px'  id='GhiChu_" + (i + 1) + "' disabled='true' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + table.Rows[i]["GhiChu"].ToString() + "' /></td>";
                     html += "<td><input type='hidden' value='" + table.Rows[i]["IdChiTietPhieuYC"].ToString() + "'/></td>";
                     html += "</tr>";
                 }
             }
         #endregion 
         }
         //end Load Các thuốc đã yêu cầu xuất
         string sWYS = "";
         #region Bỏ
         //if (Request.QueryString["dkMenu"] != null)
         //{
         //    string dkMenu=Request.QueryString["dkMenu"].ToString();
         //    if (dkMenu == "capcuu")
         //        sWYS = " and pkb.maphongkhambenh='05'";
         //    else if (dkMenu == "khoanoi")
         //        sWYS = " and pkb.maphongkhambenh='04'";
         //    else if (dkMenu == "khoasan")
         //        sWYS = " and pkb.maphongkhambenh='03'";
         //    else if (dkMenu == "kb")
         //        sWYS = " and pkb.maphongkhambenh='01'";
         //    else if (dkMenu == "khoangoai")
         //        sWYS = " and pkb.maphongkhambenh='02'";
         //    else if (dkMenu == "phukhoa")
         //        sWYS = " and pkb.maphongkhambenh='02'";
         //    else
         //        sWYS = " and 1=0";
         //}
         //else
         //    sWYS = " and 1=0"; 
         #endregion
         int idkho = 0;
         if (Request.QueryString["idkho"] != null)
         {
             idkho = StaticData.ParseInt(Request.QueryString["idkho"].ToString());
         }
         sWYS += " and cttt.idkho=" + idkho.ToString();
         string sqlDSYC = @"select t.idthuoc,t.sttindm05,t.tenthuoc,t.iddvt,SoLuong=sum(cttt.soluongke),Slxuat=0,GhiChu=''	
                        from chitietbenhnhantoathuoc cttt
                        inner join khambenh kb on cttt.idkhambenh=kb.idkhambenh
                        inner join thuoc t on cttt.idthuoc=t.idthuoc
                        inner join phongkhambenh pkb on pkb.idphongkhambenh=kb.idphongkhambenh where 1=1 ";
                 if(NgayYC !="")
                     sqlDSYC += @"
  and (   (convert(varchar(10),ngaykham,103)='" + NgayYC + @"' --and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')=''
                                    )
        or  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='" + NgayYC + @"'
    )";
                    sqlDSYC+=@" and isnull(cttt.IsDaYeuCau,0)=0 " +sWYS+@"";
                    if (idLoaiThuoc != "")
                    sqlDSYC += @" and t.loaithuocid='" + idLoaiThuoc + @"'";
                    sqlDSYC += @"  group by t.tenthuoc,t.idthuoc,t.sttindm05,t.tenthuoc,t.iddvt
                        order by t.tenthuoc";
        DataTable DSYC=DataAcess.Connect.GetTable(sqlDSYC);
        if (Request.QueryString["Update"] == null)
        {
            for (int i = 0; i < DSYC.Rows.Count; i++)
            {
                stt += 1;
                DataTable tablethuoc = DataAcess.Connect.GetTable("select top 1 sttindm05,iddvt from thuoc where idthuoc='" + DSYC.Rows[i]["idthuoc"].ToString() + "'");
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td >" + stt.ToString() + "</td>";
                html += "<td ><a onclick='xoaontable(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input id='IDthuoc_" + stt.ToString() + "' type='hidden' value='" + DSYC.Rows[i]["idthuoc"].ToString() + "'/></td>";
                html += "<td ><input style='width:100px' id='sttindm05_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);checkchuyenphim=true;'  value='" + tablethuoc.Rows[0]["sttindm05"].ToString() + "'/></td>";
                html += "<td ><input style='width:300px' id='tenthuoc_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);timkiemthuoc(this);checkchuyenphim=true;'  value='" + DSYC.Rows[i]["tenthuoc"].ToString() + "'/></td>";
                html += "<td><select style='width:50px' id='dvt_" + stt.ToString() + "'  />";
                for (int ii = 0; ii < table1.Rows.Count; ii++)
                {
                    if (tablethuoc.Rows[0]["iddvt"].ToString() == table1.Rows[ii][0].ToString())
                    {
                        html += "<option selected value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                    }
                    else
                    {
                        html += "<option value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                    }
                }
                html += "</select></td>";
                html += "<td><input style='width:50px' id='SoLuong_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["SoLuong"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                html += "<td><input style='width:50px' id='SLXuat_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["Slxuat"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                html += "<td><input style='width:250px'  id='GhiChu_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["GhiChu"].ToString() + "' /></td>";
                html += "<td><input type='hidden' value=''/></td>";
                html += "</tr>";
            }
        }
            #region khong co du lieu
            //else
            //{
            //    table.Rows.Add(table.NewRow());
            //        html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
            //        html += "<td>1</td>";
            //        html += "<td><a onclick='xoaontable(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            //        html += "<td><input id='IDthuoc_1' type='hidden' /></td>";
            //        html += "<td ><input style='width:100px' id='sttindm05_1'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);checkchuyenphim=true;'  value=''/></td>";
            //        html += "<td><input style='width:300px' id='tenthuoc_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);timkiemthuoc(this);checkchuyenphim=true;'  value='' /></td>";
            //        html += "<td><select style='width:50px' id='dvt_1' />";
            //        for (int ii = 0; ii < table1.Rows.Count; ii++)
            //        {
            //            html += "<option value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
            //        }
            //        html += "</select></td>";
            //        html += "<td><input style='width:50px' id='SoLuong_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='' onblur='TestSo(this,false,true);' /></td>";
            //        html += "<td><input style='width:50px' id='slxuat_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='' onblur='TestSo(this,false,true);' /></td>";
            //        html += "<td><input style='width:250px' id='GhiChu_1' type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='' /></td>";
            //        html += "<td><input type='hidden' value=''/></td>";
            //        html += "</tr>";
            //}
            #endregion       
        string sqlIdChiTiet = "";
        if (Request.QueryString["Update"] == null)
        {
            sqlIdChiTiet = @"select distinct idchitietbenhnhantoathuoc
                        from chitietbenhnhantoathuoc cttt
                        inner join khambenh kb on cttt.idkhambenh=kb.idkhambenh
                        inner join thuoc t on cttt.idthuoc=t.idthuoc
                        inner join phongkhambenh pkb on pkb.idphongkhambenh=kb.idphongkhambenh where 1=1 ";
            if (NgayYC != "")
                sqlIdChiTiet += @" and convert(varchar(10),kb.ngaykham,103)='" + NgayYC + "'";
            sqlIdChiTiet += @" and isnull(cttt.IsDaYeuCau,0)=0 " + sWYS + @"
                        and t.loaithuocid='" + idLoaiThuoc + @"'
                        ";
        }
        else
        {
            string idPhieuYeuCauXuat = Request.QueryString["idkhoachinh"] == null || Request.QueryString["idkhoachinh"].ToString().Equals("") ? "" : Request.QueryString["idkhoachinh"];
            sqlIdChiTiet = @"select distinct idchitietbenhnhantoathuoc
                        from NVK_Thuoc_ChiTietYCXuat nvk left join Thuoc_chitietPhieuYCXuat ctyc on ctyc.IdChiTietPhieuYC=nvk.IdChiTietPhieuYC
                        where ctyc.IdPhieuYC=" + idPhieuYeuCauXuat + @"
                       ";
        }
        DataTable dtIdCT = DataAcess.Connect.GetTable(sqlIdChiTiet);
        if (dtIdCT.Rows.Count > 0)
            for (int k = 0; k < dtIdCT.Rows.Count; k++)
                strIdChitiet += dtIdCT.Rows[k]["idchitietbenhnhantoathuoc"].ToString() + ",";
        html += "<tr><td><input type='hidden' id='listIdChiTietToaThuoc' value='"+strIdChitiet+"'/></td><td></td></tr>";
        html += "</table>";
                 Response.Clear();Response.Write(html);
     }

    public void loadTableThuoc_ChiTietPhieuDaYCXuat()
    {
        string sql = "";
        sql += Request.QueryString["idkhoachinh"].ToString();
        string idLoaiThuoc = Request.QueryString["idLoaiThuoc"] != null ? Request.QueryString["idLoaiThuoc"].ToString() : "";

        //DataTable table1 = Thuoc_Process.Thuoc_DonViTinh.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");
        //DataTable table = Thuoc_Process.Thuoc_ChiTietPhieuYCXuat.GetTable("select ctthuoc.*,t.tenthuoc from Thuoc_ChiTietPhieuYCXuat ctthuoc left join thuoc t on t.idthuoc=ctthuoc.idthuoc where ctthuoc.IdPhieuYC='" + sql + "'");
        string IdKhoYC = Request.QueryString["IdKhoYC"].ToString();
        if (IdKhoYC.Trim() == "") IdKhoYC = "0";
        string NgayYC = Request.QueryString["NgayYC"].ToString();
        string SoPhieuYC = Request.QueryString["SoPhieuYC"].ToString();
        string sqlYC = @"select idphieuYC,convert(varchar(10),ngayYC,103)+' '+convert(varchar(10),ngayYC,108) as NgayYC
                ,sophieu,tennguoidung,tenkho
                ,TrangThai=case DBO.THUOC_ISDAXUAT(yc.IdPhieuYC) when 0 then N'CHƯA XUẤT' when 1 then N'Đang treo' when 2 then N'Treo(đã YC lại)'
                when 3 then N'ĐÃ DUYỆT' END
                 from Thuoc_PhieuYCXuat yc left join nguoidung nd on nd.idnguoidung=yc.idnguoiYC
                left join khothuoc kho on kho.idkho=yc.idphongkhambenh
                where  isnull(YC.LoaiYCid,1)=1 and  yc.idphongkhambenh=" + IdKhoYC + @"";
        if( !NgayYC.Equals(""))
            sqlYC += @" and convert(varchar(10),ngayYC,103)='" + NgayYC+@"' ";
        if (!SoPhieuYC.Equals(""))
            sqlYC += " and YC.SoPhieu like N'%"+SoPhieuYC+"%'";
        if (idLoaiThuoc != "")
            sqlYC += @" and yc.loaithuocid=" + idLoaiThuoc + " ";
                sqlYC += @"order by idphieuYC desc ";
        DataTable table = DataAcess.Connect.GetTable(sqlYC);
        string html = "";
        html += "<table id=\"gridTables\" border=\"1\" align=\"center\" width=\"100%\" bgcolor=\"white\">";
        html += "<tr style='background-color:#4D67A2;color:white;height:25px;text-align:center'>";
        html += "<td style='font-size:10px;font-weight:bold'>STT</td>";
        html += "<td style='width:15px'></td>";
        html += "<td></td>";
        html += "<td style='font-size:12px;font-weight:bold'>Ngày Y/C</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Kho yêu cầu</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Người yêu cầu</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Số phiếu</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Trạng thái</td>";
        //html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Slxuat") + "</td>";
        //html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</td>";
        int stt = 0;
        string strIdChitiet = "";
        #region Load Các thuốc đã yêu cầu xuất
        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                stt = i + 1;
                //DataTable tablethuoc = DataAcess.Connect.GetTable("select top 1 sttindm05,iddvt from thuoc where idthuoc='" + table.Rows[i]["idthuoc"].ToString() + "'");
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td >" + (i + 1) + "</td>";
                html += @"<td ><a ";
                //if (table.Rows[i]["TrangThai"].ToString().Equals("Chưa duyệt"))
                    html += @"onclick='Inphieu(" + table.Rows[i]["idphieuYC"].ToString() + @")'";
                //else { }
                html += @"name='" + table.Rows[i]["idphieuYC"].ToString() + "'>In phiếu Y/C</a></td>";
                #region Sửa phiếu thì dùng lại đoạn này
                //                html += @"<td><input id='IDthuoc_" + (i + 1) + "' type='hidden' value='" + table.Rows[i]["NgayYC"].ToString() + @"'/> 
//                    <a onclick='SuaphieuYC(" + table.Rows[i]["idphieuYC"].ToString() + ")' name='" + table.Rows[i]["idphieuYC"].ToString() + @"'>";
//                if (table.Rows[i]["TrangThai"].ToString().Equals("Chưa duyệt"))
//                    html += @"Xóa";
                // html += @"</a></td>";
                #endregion
                html += @"<td><input id='IDthuoc_" + (i + 1) + "' type='hidden' value='" + table.Rows[i]["NgayYC"].ToString() + @"'/> ";
                html += "    <a onclick=\"nvk_XoaphieuYC(" + table.Rows[i]["idphieuYC"].ToString() + ",'" + table.Rows[i]["sophieu"].ToString() + "')\" name='" + table.Rows[i]["idphieuYC"].ToString() + @"'>";
                if (table.Rows[i]["TrangThai"].ToString().Equals("CHƯA XUẤT"))
                    html += @"Xóa";
                html += @"</a>
                    </td>";
                html += "<td ><input style='width:100%' id='sttindm05_" + (i + 1) + "' type='text' value='" + table.Rows[i]["NgayYC"].ToString() + "'/></td>";
                html += "<td ><input style='width:100%' id='tenthuoc_" + (i + 1) + "'  type='text' value='" + table.Rows[i]["tenkho"].ToString() + "'/></td>";
                
                html += "<td><input style='width:100%' id='tennguoidung_" + (i + 1) + "' type='text' value='" + table.Rows[i]["tennguoidung"].ToString() + "'/></td>";
                html += "<td><input style='width:100%' id='SoPhieu_" + (i + 1) + "' type='text' value='" + table.Rows[i]["sophieu"].ToString() + "' /></td>";
                html += "<td ><a  name='" + table.Rows[i]["TrangThai"].ToString() + "'>" + table.Rows[i]["TrangThai"].ToString() + "</a></td>";
                html += "<td><input type='hidden' value='" + table.Rows[i]["idphieuYC"].ToString() + "'/></td>";
                html += "</tr>";
            }
        }
        #endregion
        //end Load Các thuốc đã yêu cầu xuất
        string sqlIdChiTiet = @"";
        html += "<tr><td><input type='hidden' id='listIdChiTietToaThuoc' value='" + strIdChitiet + "'/></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }

    public void loadTableThuoc_BNTra()
    {
        string idbenhnhan = "0";
        string ChuoiNgayChoThuoc = "convert(varchar(10),getdate(),103)";
        string DKNgay = "";
        if (Request.QueryString["ngaychothuoc"] != null)
        {
            if (Request.QueryString["ngaychothuoc"].ToString().Trim().Equals(""))
                ChuoiNgayChoThuoc = "";
            else
                ChuoiNgayChoThuoc = "" + Request.QueryString["ngaychothuoc"].ToString() + "";
        }
        if (ChuoiNgayChoThuoc.Equals(""))
            DKNgay = " ";
        else
            //DKNgay = " and convert(varchar(10),kb.ngaykham,103)=" + ChuoiNgayChoThuoc + @"";
            DKNgay = @"and (   (convert(varchar(10),ngaykham,103)='" + ChuoiNgayChoThuoc + @"' --and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')=''
                                    )
        or  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='" + ChuoiNgayChoThuoc + @"'
    )";
        if (Request.QueryString["idbenhnhan"] != null)
            idbenhnhan=Request.QueryString["idbenhnhan"].ToString();
        string sql = "";
        DataTable table1 = DataAcess.Connect.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");
        string html = "";
        html += "<table id=\"gridTables\" border=\"1\" align=\"center\" width=\"100%\" bgcolor=\"white\">";
        html += "<tr style='background-color:#4D67A2;color:white;height:25px;text-align:center'>";
        html += "<td style='font-size:20px;font-weight:bold'>STT</td>";
        html += "<td></td>";
        html += "<td></td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maSP") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenSP") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DVT") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Số lượng trả</td>";
        html += "<td style='font-size:12px;font-weight:bold'>Số lượng nhận</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</td>";
        int stt = 0;
        string sWYS = "";
        
        int idkho = 0;
        int IdLoaiThuoc = 0;
        if (Request.QueryString["idkho"] != null)
        {
            idkho = StaticData.ParseInt(Request.QueryString["idkho"].ToString());
        }
        if (Request.QueryString["idloaithuoc"] != null)
        {
            IdLoaiThuoc = StaticData.ParseInt(Request.QueryString["idloaithuoc"].ToString());
        }
        if (!idbenhnhan.Equals("0") && !idbenhnhan.Equals(""))
            sWYS += " and kb.idbenhnhan=" + idbenhnhan;
        sWYS += " and cttt.idkho=" + idkho.ToString();
        sWYS += " and t.LoaiThuocID=" + IdLoaiThuoc.ToString();
        string sqlDSYC = @"select idthuoc,sttindm05,tenthuoc,iddvt,SoLuong=sum(SoLuong),Slxuat=sum(Slxuat),GhiChu from
                    ( select idchitietbenhnhantoathuoc,t.idthuoc,t.sttindm05,t.tenthuoc,t.iddvt,SoLuong=soluongtra,Slxuat=0,GhiChu=''	
                        from chitietbenhnhantoathuoc cttt
                        inner join khambenh kb on cttt.idkhambenh=kb.idkhambenh
                        inner join thuoc t on cttt.idthuoc=t.idthuoc
                        inner join phongkhambenh pkb on pkb.idphongkhambenh=kb.idphongkhambenh
                        where 1=1 " +DKNgay+ @"
                        and isnull(cttt.IsDaXuatTra,0)=0
                        " + sWYS + @" and isnull(soluongtra,0) >0
and  exists (select idchitietbenhnhantoathuoc from chitietphieuxuatkho where idchitietbenhnhantoathuoc=cttt.idchitietbenhnhantoathuoc and isnull(IDCHITIETPHIEUYEUCAUXUATKHO,0)> 0)
                    )as abc
                    group by idthuoc,sttindm05,tenthuoc,iddvt,GhiChu
                    order by tenthuoc";
        DataTable DSYC = DataAcess.Connect.GetTable(sqlDSYC);
        if (Request.QueryString["Update"] == null)
        {
            for (int i = 0; i < DSYC.Rows.Count; i++)
            {
                stt += 1;
                DataTable tablethuoc = DataAcess.Connect.GetTable("select top 1 sttindm05,iddvt from thuoc where idthuoc='" + DSYC.Rows[i]["idthuoc"].ToString() + "'");
                html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
                html += "<td >" + stt.ToString() + "</td>";
                html += "<td ></td>";
                //html += "<td ><a onclick='xoaontable(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
                html += "<td><input id='IDthuoc_" + stt.ToString() + "' type='hidden' value='" + DSYC.Rows[i]["idthuoc"].ToString() + "'/></td>";
                html += "<td ><input style='width:100px' id='sttindm05_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);checkchuyenphim=true;'  value='" + tablethuoc.Rows[0]["sttindm05"].ToString() + "'/></td>";
                html += "<td ><input style='width:300px' id='tenthuoc_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);timkiemthuoc(this);checkchuyenphim=true;'  value='" + DSYC.Rows[i]["tenthuoc"].ToString() + "'/></td>";
                html += "<td><select style='width:50px' id='dvt_" + stt.ToString() + "'  />";
                for (int ii = 0; ii < table1.Rows.Count; ii++)
                {
                    if (tablethuoc.Rows[0]["iddvt"].ToString() == table1.Rows[ii][0].ToString())
                    {
                        html += "<option selected value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                    }
                    else
                    {
                        html += "<option value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                    }
                }
                html += "</select></td>";
                html += "<td><input style='width:50px'  disabled='disabled' id='SoLuong_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["SoLuong"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                html += "<td><input style='width:50px'  disabled='disabled' id='SLXuat_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["Slxuat"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
                html += "<td><input style='width:250px'  id='GhiChu_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["GhiChu"].ToString() + "' /></td>";
                html += "<td><input type='hidden' id='idchitietTra' value='0'/></td>";
                html += "</tr>";
            }
        }
        string sqlIdChiTiet = @"select idchitietbenhnhantoathuoc
                        from chitietbenhnhantoathuoc cttt
                        inner join khambenh kb on cttt.idkhambenh=kb.idkhambenh
                        inner join thuoc t on cttt.idthuoc=t.idthuoc
                        inner join phongkhambenh pkb on pkb.idphongkhambenh=kb.idphongkhambenh
                        where 1=1 " + DKNgay + @"
                        and isnull(cttt.IsDaXuatTra,0)=0
                        " + sWYS + @" and isnull(soluongtra,0) >0
and  exists (select idchitietbenhnhantoathuoc from chitietphieuxuatkho where idchitietbenhnhantoathuoc=cttt.idchitietbenhnhantoathuoc and isnull(IDCHITIETPHIEUYEUCAUXUATKHO,0)> 0)
                        order by t.tenthuoc";
        DataTable dtIdCT = DataAcess.Connect.GetTable(sqlIdChiTiet);
        string strIdChitiet = "";
        if (dtIdCT.Rows.Count > 0)
            for (int k = 0; k < dtIdCT.Rows.Count; k++)
                strIdChitiet += dtIdCT.Rows[k]["idchitietbenhnhantoathuoc"].ToString() + ",";
        html += "<tr><td><input type='hidden' id='listIdChiTietToaThuoc' value='" + strIdChitiet + "'/></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }
    //nvk function 
    #region nvk function 
    private void nvk_LoadTableThuocChuaYeuCauXuat()
    {
        string NgayYC = Request.QueryString["ngayYC"] != null ? Request.QueryString["ngayYC"] : DateTime.Now.ToString("dd/MM/yyyy");
        string idLoaiThuoc = Request.QueryString["idLoaiThuoc"] != null ? Request.QueryString["idLoaiThuoc"].ToString() : "";
        string sql = "";
        sql += Request.QueryString["idkhoachinh"].ToString();
        DataTable table1 = DataAcess.Connect.GetTable("select * from Thuoc_DonViTinh order by TenDVT ");
        DataTable table = DataAcess.Connect.GetTable("select ctthuoc.*,t.tenthuoc from Thuoc_ChiTietPhieuYCXuat ctthuoc left join thuoc t on t.idthuoc=ctthuoc.idthuoc where ctthuoc.IdPhieuYC='" + sql + "'");
        string html = "";
        html += "<table id=\"gridTables\" border=\"1\" align=\"center\" width=\"100%\" bgcolor=\"white\">";
        html += "<tr style='background-color:#4D67A2;color:white;height:25px;text-align:center'>";
        html += "<td style='font-size:20px;font-weight:bold'>STT</td>";
        //html += "<td></td>";
        html += "<td></td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("maSP") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("TenSP") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("DVT") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thuoc_KyNayYC") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Thuoc_KyTruocConLai") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("SoLuong") + "</td>";
        //html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("Slxuat") + "</td>";
        html += "<td style='font-size:12px;font-weight:bold'>" + hsLibrary.clDictionaryDB.sGetValueLanguage("GhiChu") + "</td>";
        int stt = 0;
        string strIdChitiet = "";
        string sWYS = "";
        int idkho = 0;
        if (Request.QueryString["idkho"] != null)
        {
            idkho = StaticData.ParseInt(Request.QueryString["idkho"].ToString());
        }
        sWYS += " and cttt.idkho=" + idkho.ToString();
        string sqlDSYC = @"select t.idthuoc,t.sttindm05,t.tenthuoc,t.iddvt,SoLuongMoi=sum(cttt.soluongke)-sum(isnull(soluongtra,0))
,SLKyTruocTreo=dbo.nvk_SLYCTreo_Kho_Thuoc('" + idkho + "',t.idthuoc),TongSoLuongYC=sum(cttt.soluongke) -sum(isnull(soluongtra,0))+ dbo.nvk_SLYCTreo_Kho_Thuoc('" + idkho + @"',t.idthuoc)
,Slxuat=0,GhiChu=''	
                        from chitietbenhnhantoathuoc cttt
                        inner join khambenh kb on cttt.idkhambenh=kb.idkhambenh
                        inner join thuoc t on cttt.idthuoc=t.idthuoc
                        inner join phongkhambenh pkb on pkb.idphongkhambenh=kb.idphongkhambenh where 1=1 ";
        if (NgayYC != "")
            sqlDSYC += @"
  and (   (convert(varchar(10),ngaykham,103)='" + NgayYC + @"' --and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')=''
                                    )
        or  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='" + NgayYC + @"'
    )";
        sqlDSYC += @" and isnull(cttt.IsDaYeuCau,0)=0 " + sWYS + @"";
        if (idLoaiThuoc != "")
            sqlDSYC += @" and t.loaithuocid='" + idLoaiThuoc + @"'";
        sqlDSYC += @"  group by t.tenthuoc,t.idthuoc,t.sttindm05,t.tenthuoc,t.iddvt
 having  ( sum(cttt.soluongke) -sum(isnull(soluongtra,0))+ dbo.nvk_SLYCTreo_Kho_Thuoc('"+idkho+@"',t.idthuoc) ) >0 
                        ";
        //nvk thêm những thuốc kỳ này không có đang bị treo
        #region nvk thêm những thuốc kỳ này không có đang bị treo
        sqlDSYC += @"
 union all
            select t.idthuoc,t.sttindm05,t.tenthuoc,t.iddvt,SoLuongMoi=0
            ,SLKyTruocTreo=(isnull(SoLuong,0)- isnull(SlXuat,0)),TongSoLuongYC=(isnull(SoLuong,0)- isnull(SlXuat,0))
            ,Slxuat=0,GhiChu=N'YC Duyệt treo'	
            from  thuoc_chitietphieuYCxuat ctYC inner join thuoc t on ctYC.IDthuoc=t.idthuoc
            inner join thuoc_phieuYCxuat YC on yc.IdPhieuYC=ctYC.IdPhieuYC
            where isnull(YC.LoaiYCid,1)=1 and  YC.idphieuYC >0 and YC.idphongkhambenh='" + idkho + @"' and isnull(ctYC.SlXuat,0)< isnull(ctYC.SoLuong,0) and isnull(ctYC.Status_ThuocTreo,0)=0 ";
            if (idLoaiThuoc != "")
                sqlDSYC += @" and t.loaithuocid='" + idLoaiThuoc + @"'";
            sqlDSYC += @" and t.idthuoc not in (select idthuoc from chitietbenhnhantoathuoc where idkho='" + idkho + "' and isnull(IsDaYeuCau,0)=0)";
        #endregion
        DataTable DSYC = DataAcess.Connect.GetTable(sqlDSYC);
        for (int i = 0; i < DSYC.Rows.Count; i++)
        {
            stt += 1;
            DataTable tablethuoc = DataAcess.Connect.GetTable("select top 1 sttindm05,iddvt from thuoc where idthuoc='" + DSYC.Rows[i]["idthuoc"].ToString() + "'");
            html += "<tr id=\"background\" style='cursor:pointer;color:gray' >";
            html += "<td >" + stt.ToString() + "</td>";
            //html += "<td ><a onclick='xoaontable(this.name,this)' name=''>" + hsLibrary.clDictionaryDB.sGetValueLanguage("delete") + "</a></td>";
            html += "<td><input id='IDthuoc_" + stt.ToString() + "' type='hidden' value='" + DSYC.Rows[i]["idthuoc"].ToString() + "'/></td>";
            html += "<td ><input style='width:100px' id='sttindm05_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);checkchuyenphim=true;'  value='" + tablethuoc.Rows[0]["sttindm05"].ToString() + "'/></td>";
            html += "<td ><input style='width:300px' id='tenthuoc_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this);timkiemthuoc(this);checkchuyenphim=true;'  value='" + DSYC.Rows[i]["tenthuoc"].ToString() + "'/></td>";
            html += "<td><select style='width:50px' id='dvt_" + stt.ToString() + "'  />";
            for (int ii = 0; ii < table1.Rows.Count; ii++)
            {
                if (tablethuoc.Rows[0]["iddvt"].ToString() == table1.Rows[ii][0].ToString())
                {
                    html += "<option selected value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                }
                else
                {
                    html += "<option value='" + table1.Rows[ii][0] + "'>" + table1.Rows[ii][1] + "</option>";
                }
            }
            html += "</select></td>";
            html += "<td><input style='width:50px' disabled='disabled'  id='KyNay_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["SoLuongMoi"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
            html += "<td><input style='width:50px' disabled='disabled' id='KyTruoc_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["SLKyTruocTreo"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
            html += "<td><input style='width:50px' disabled='disabled' id='SoLuong_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["TongSoLuongYC"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
            //html += "<td><input style='width:50px' id='SLXuat_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["Slxuat"].ToString() + "' onblur='TestSo(this,false,true);'/></td>";
            html += "<td><input style='width:250px'  id='GhiChu_" + stt.ToString() + "'  type='text' onfocusout='chuyenformout(this)' onfocus='chuyenform(this)'  value='" + DSYC.Rows[i]["GhiChu"].ToString() + "' /></td>";
            html += "<td><input type='hidden' value=''/></td>";
            html += "</tr>";
        }
        string sqlIdChiTiet = "";
        sqlIdChiTiet = @"select distinct idchitietbenhnhantoathuoc
                        from chitietbenhnhantoathuoc cttt
                        inner join khambenh kb on cttt.idkhambenh=kb.idkhambenh
                        inner join thuoc t on cttt.idthuoc=t.idthuoc
                        inner join phongkhambenh pkb on pkb.idphongkhambenh=kb.idphongkhambenh where 1=1 ";
        if (NgayYC != "")
            sqlIdChiTiet += @"
  and (   (convert(varchar(10),ngaykham,103)='" + NgayYC + @"' --and  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')=''
                                    )
        or  isnull(convert(varchar(10),ngayDuTruThuoc,103),'')='" + NgayYC + @"'
    )";
        sqlIdChiTiet += @" and isnull(cttt.IsDaYeuCau,0)=0 " + sWYS + @"
                        and t.loaithuocid='" + idLoaiThuoc + @"'
 and  ( cttt.soluongke -isnull(soluongtra,0)+ dbo.nvk_SLYCTreo_Kho_Thuoc('"+idkho+@"',t.idthuoc) ) >0 
                        ";
        //nvk thêm danh sách idchitietbenhnhantoathuoc những thuốc kỳ này không có đang bị treo
        #region nvk thêm danh sách idchitietbenhnhantoathuoc những thuốc kỳ này không có đang bị treo
        sqlIdChiTiet += @"
union all
            select CTct.Idchitietbenhnhantoathuoc
            from  thuoc_chitietphieuYCxuat ctYC inner join thuoc t on ctYC.IDthuoc=t.idthuoc
            inner join NVK_Thuoc_ChiTietYCXuat CTct on CTct.IdChiTietPhieuYC=ctYC.IdChiTietPhieuYC 
            inner join thuoc_phieuYCxuat YC on yc.IdPhieuYC=ctYC.IdPhieuYC
            where YC.idphieuYC >0 and YC.idphongkhambenh='" + idkho + @"' and isnull(ctYC.SlXuat,0)>0 and isnull(ctYC.SlXuat,0)< isnull(ctYC.SoLuong,0)";
        if (idLoaiThuoc != "")
            sqlIdChiTiet += @" and t.loaithuocid='" + idLoaiThuoc + @"'";
        sqlIdChiTiet += @" and t.idthuoc not in (select idthuoc from chitietbenhnhantoathuoc where idkho='" + idkho + "' and isnull(IsDaYeuCau,0)=0)";
        #endregion
        DataTable dtIdCT = DataAcess.Connect.GetTable(sqlIdChiTiet);
        if (dtIdCT.Rows.Count > 0)
            for (int k = 0; k < dtIdCT.Rows.Count; k++)
                strIdChitiet += dtIdCT.Rows[k]["idchitietbenhnhantoathuoc"].ToString() + ",";
        
        html += "<tr><td><input type='hidden' id='listIdChiTietToaThuoc' value='" + strIdChitiet + "'/></td><td></td></tr>";
        html += "</table>";
        Response.Clear(); Response.Write(html);
    }
    private void nvk_XoaPhieuYCXuat()
    {
        try
        {
            #region nvk Comment 0509
            //string idkhoachinh = Request.QueryString["IdPhieuYC"];
            //string MaPhieuYC = Request.QueryString["MaPhieuYC"];
            //#region cap nhat lai chitietbenhnhantoathuoc cho phep lap lai phieu yC moi
            //string sqlCTBNTT = "select idchitietbenhnhantoathuoc from NVK_Thuoc_ChiTietYCXuat  where IdChiTietPhieuYC in(select IdChiTietPhieuYC from thuoc_chitietphieuYCxuat  where IdPhieuYC='" + idkhoachinh + "')";
            //DataTable dtDsBNTT = DataAcess.Connect.GetTable(sqlCTBNTT);
            //if (dtDsBNTT != null && dtDsBNTT.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtDsBNTT.Rows.Count; i++)
            //    {
            //        string UpdateCTBNTT = "update chitietbenhnhantoathuoc set IsDaYeuCau=0 where idchitietbenhnhantoathuoc ='" + dtDsBNTT.Rows[i]["idchitietbenhnhantoathuoc"] + "'";
            //        bool kt = DataAcess.Connect.ExecSQL(UpdateCTBNTT);
            //    }
            //}
            //#endregion
            //string Xoa_thuoc_chitietphieuYCxuat = @"delete from NVK_Thuoc_ChiTietYCXuat where IdChiTietPhieuYC in(select IdChiTietPhieuYC from thuoc_chitietphieuYCxuat  where IdPhieuYC='" + idkhoachinh + "')";
            //bool ok = DataAcess.Connect.ExecSQL(Xoa_thuoc_chitietphieuYCxuat);
            //string Xoa_NVK_Thuoc_ChiTietYCXuat = @"delete from thuoc_chitietphieuYCxuat where IdPhieuYC='" + idkhoachinh + "'";
            //if (ok)
            //{
            //    ok = DataAcess.Connect.ExecSQL(Xoa_NVK_Thuoc_ChiTietYCXuat);
            //    string sql = "delete Thuoc_PhieuYCXuat where IdPhieuYC=" + idkhoachinh;
            //    if (ok)
            //    {
            //        ok = Process.Thuoc_PhieuYCXuat.ExecSQL(sql);
            //        if (ok)
            //        {
            //            Response.Clear(); Response.Write(idkhoachinh);
            //            return;
            //        }
            //    }
            //} 
            #endregion
        }
        catch
        {
        }
        Response.StatusCode = 500;
    }
    #endregion
}
 
 
