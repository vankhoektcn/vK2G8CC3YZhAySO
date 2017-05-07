<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HDBH_XuatHoaDon.aspx.cs" Inherits="ketoan_HDDV_XuatHoaDon" %>
<!--#include file = "header.htm" -->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />

<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_HoaDonDV.ascx" TagName="menu_hodondichvu" TagPrefix="uc1" %>
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/scriptoflong.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>
<script src="../ketoan/js_KeToan/PagerSize.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    
     var dp_cal;var dp_cal2;
  
	window.onload = function () 
	{
	    phanquyen();
	   // dp_cal = new Epoch('epoch_popup','popup',document.getElementById('txtNgayLapHoaDon'));	
	   // dp_cal2 = new Epoch('epoch_popup','popup',document.getElementById('txtNgayThu'));	  
	    //TaoMaSoHoaDon();
	    //document.getElementById('txtNgayLapHoaDon').value='';
	    document.getElementById('txtsoseri').value="MD/11P";
	    document.getElementById('TableDanhSach').style.display='none' ;           	    
	    document.getElementById('TableDanhSach').style.display='block';	    
	    var queryString = "";
	    queryString =  window.location.search.substring(1).split('&');
	    if(queryString!="" && queryString!="dkmenu=kthddv")
	    {	        	        
	        var IDHoaDon = queryString[0].split('=');
	        var SoHD = queryString[1].split('=');
	        var loai_hd = queryString[2].split('=');  
	        		             
	        if(loai_hd[1]!="")
	        {	            
	            document.getElementById('bt_Luu').value ="Sửa";	            
	            LockForm("true");	            
	            if(loai_hd[1]=="1" || loai_hd[1]=="2" || loai_hd[1]=="8" )
	            {	               		                              
	               LoadChiTietHoaDon(IDHoaDon[1]);	
	               document.getElementById('TableDanhSach').style.display='block'; 	                          
	            }	            	                     
	        }
	    }
	};
	function phanquyen() 
	{
	    var quyenthem = '<%=StaticData.HavePermision(this.Page, "KeToanHDDV_HDBH_XuatHoaDon_Them")%>';
        var quyensua = '<%=StaticData.HavePermision(this.Page, "KeToanHDDV_HDBH_XuatHoaDon_Sua")%>';
        var quyenxoa = '<%=StaticData.HavePermision(this.Page, "KeToanHDDV_HDBH_XuatHoaDon_Xoa")%>';
        if(quyenthem == 'False' && quyensua == 'False')
        {
                document.getElementById('bt_Luu').disabled = true;
                }
            else
                document.getElementById('bt_Luu').disabled = false;
	}
function TaoMaSoHoaDon()
{    
      var Table = "Hoa_Don_DV";
       var KyTuDau = "HDDV";
       var Column = "So_HD";
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {  
                        document.getElementById('txtSoHoaDon').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&KyTuDau="+KyTuDau+"&Column="+Column+"&times="+Math.random(),true);
            xmlHttp.send(null);            
}
function bt_Click(Ctr)
{          
    var ngaylap_ct=document.getElementById('txtNgayLapHoaDon').value;
    kiemtrangaykhoaso(ngaylap_ct,Ctr);    
}
function TaoMoi()
{
    
    if(document.getElementById('bt_LoadDSPT').value=='LoadData')      
    {               
        document.getElementById('bt_LoadDSPT').value='ConnectData'       
    }  
    LockForm("false");
    document.getElementById('bt_Luu').value = "Lưu";
    //document.getElementById('bt_LoadDSPT').style.visibility = "inherit";
    //location.href("HDDV_XuatHoaDon.aspx");
    //DeleteNumPage();
    ResetDataonTable();
    //TaoMaSoHoaDon();
}
function SuaHoaDon()
{
    LockForm("false");
    document.getElementById('bt_Sua').style.visibility ="hidden";
    document.getElementById('bt_Luu').style.visibility ="inherit";
    //document.getElementById('bt_LoadDSPT').style.visibility = "hidden";
}
function LoadChiTietHoaDon(IDHoaDon)
{    
     xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      {                        
                        Row = value.split('|');
                        data = Row[1].split('&');
                        //hoa_donID(0),so_hd(1),so_seri(2),ngay_lap_hd(3),ma_kh(4),ten_KH(5),NguoiMua(6),DiaChi(7),MaSoThue(8),dien_giai(9),tk_no(10),tk_co(11),tk_thue(12),thue_suat(13),tien(14),tien_thue(15),tong_tien(16)
                       ShowChiTietHoaDon(data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],data[8],data[9],data[10],data[11],data[12],data[13],data[14],data[15],data[16],data[17]);                                 
                      }
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=LoadChiTietHoaDonBanHang&IDHoaDon="+IDHoaDon+"&times="+Math.random(),true);
            xmlHttp.send(null);
}
function ShowChiTietHoaDon(HoaDonID,SoHD,SoSeri,NgayLapHD,MaKH,TenKH,NguoiMua,DiaChi,MaSoThue,DienGiai,TKNo,TKCo,TKThue,ThueSuat,Tien,TienThue,TongTien,LoaiHD)
{      
    document.getElementById('hdHoaDonID').value = HoaDonID;
    document.getElementById('txtMaKH').value=MaKH;
    document.getElementById('txtSoHoaDon').value=SoHD;
    
    document.getElementById('txtSoTien').value=FormatSoTien(Tien);
    document.getElementById('txtTaiKhoanNo').value=TKNo;
    document.getElementById('txtTaiKhoanCo').value=TKCo;
    
    document.getElementById('txtTongTien').value= FormatSoTien(TongTien);
    document.getElementById('txtDienGiai').value=DienGiai;
       
    document.getElementById('txtTenKH').value=TenKH;
    document.getElementById('txtNguoiMua').value=NguoiMua;
    document.getElementById('txtDiaChi').value=DiaChi;
    document.getElementById('txtMaSoThue').value=MaSoThue;
    document.getElementById('txtSoSeri').value=SoSeri;
    document.getElementById('txtTienThue').value= FormatSoTien(TienThue);
    
    document.getElementById('txtTaiKhoanThue').value=TKThue;
    document.getElementById('txtNgayLapHoaDon').value=NgayLapHD;
    document.getElementById('txtThueSuat').value=ThueSuat;    
    document.getElementById('ddlloaixuat').value=LoaiHD;
    LoadDanhSachPhieuThuHoaDonBanHang(SoHD);                  
}
//----------------------- các function kiểm tra---------------------------------------
function TestNumberofInput(obj)
{
    if(CheckType=="KhachHang")
    {
         var key;
        if(window.event)
        {
          key = window.event.keyCode; 
        }
        var txtObj = document.getElementById(obj);
        //if((key<48||key>57)&&key!=190&&key!=8&&key!=9&&key!=37&&key!=38&&key!=39&&key!=40)
         if((key>=65&&key<=90))
        {
            alert("Chỉ được nhập số!");
            txtObj.value ="";
            txtObj.focus();
        }
        else
        {
             var number = txtObj.value;
             if(number=="")
                number="0";
             if(!isFinite(parseFloat(number))||parseFloat(number)>999999999)
             {   alert("Nhập số quá giới hạn cho phép!Vui lòng kiểm tra lại cảm ơn!"); 
                 txtObj.value ="";
                 txtObj.focus();
             }
         }
     }
}
function TestMaTaiKhoan(txtTaiKhoan)
{
    var MaTaiKhoan = document.getElementById(txtTaiKhoan);
    if(MaTaiKhoan.value!="")
    {
        xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="1")
                      {  
                        alert("Tài khoản bạn chọn nhập chưa có trong danh mục tài khoản. Vui lòng kiểm tra lại. Cảm ơn!");
                         MaTaiKhoan.value ="";
                         document.getElementById(txtTaiKhoan).focus();
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TestMaTaiKhoan&Key="+MaTaiKhoan.value+"&times="+Math.random(),true);
            xmlHttp.send(null);
    }
}
function ResetDataonTable()
{    
    document.getElementById('hdHoaDonID').value="0";
    document.getElementById('txtMaKH').value="";
    document.getElementById('txtTenKH').value="";
    document.getElementById('txtNguoiMua').value="";
    document.getElementById('txtDiaChi').value="";
    document.getElementById('txtSoHoaDon').value="";
        
    document.getElementById('txtSoTien').value="";
    document.getElementById('txtTaiKhoanNo').value="";
    document.getElementById('txtTaiKhoanCo').value="";
    
    document.getElementById('txtTongTien').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayThu').value="";
    
    document.getElementById('txtMaSoThue').value="";
    document.getElementById('txtSoSeri').value="";
    document.getElementById('txtTienThue').value="";
    
    document.getElementById('txtTaiKhoanThue').value="";
    document.getElementById('txtNgayLapHoaDon').value="";
    document.getElementById('txtThueSuat').value="";
    //DeleteNumPage();
      
//    if(CheckType=="KhachHang")
//        ResetTableDSHangHoa();
//    else
        ResetTableDSPhieuThu(); 
    //TaoMaSoHoaDon();
    
}
function ResetTableDSPhieuThu()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var lastRow = Row;
    while(lastRow>2)
    {
        TableDanhSach.deleteRow(lastRow-1);
        lastRow--;
    }   
}
function ResetTableDSHangHoa()
{
    var TableDanhSach = document.getElementById('tablehanghoa');
    var Row = TableDanhSach.rows.length;
    var lastRow = Row;
    while(lastRow>2)
    {
        TableDanhSach.deleteRow(lastRow-1);
        lastRow--;
    }   
}
function FormatSoTien(Tien)
{
	    return formatCurrency(Tien);
}
function TinhTienThue()
{
    var SoTien = document.getElementById('txtSoTien');    
    var ThueSuat = document.getElementById('txtThueSuat').value;
    var TienThue = document.getElementById('txtTienThue');
    var TongTien = document.getElementById('txtTongTien').value; 
    TongTien =ChangeFormatCurrency(TongTien);
    var tientruocthue;
    tientruocthue=Math.round((eval(TongTien)*100)/(100+eval(ThueSuat)));   
    SoTien.value = FormatSoTien(tientruocthue);    
    if(ThueSuat=="")
        ThueSuat = '0';
   var TinhTienThue = Math.round((eval(tientruocthue)*eval(ThueSuat))/100);
    //var TinhTienThue = (parseInt(ChangeFormatCurrency(SoTien))*parseInt(ThueSuat))/100;    
    TienThue.value = FormatSoTien(TinhTienThue);      
}
function CheckAll(Ctr)
{
    var CheckedValue;
    
    for(i = 0;i<Ctr.childNodes.length;i++)
    {
        if(Ctr.childNodes[i].tagName!=undefined&&Ctr.childNodes[i].tagName.toLowerCase()=="input"&&Ctr.childNodes[i].type.toLowerCase()=="checkbox")
        {
            CheckedValue = Ctr.childNodes[i].checked;
            break;
        }
    }     
    var parentNode_table = Ctr.parentNode.parentNode;
    for(j=2;j<parentNode_table.childNodes.length;j++)
    {
        var tr = parentNode_table.childNodes[j];
        for(k=0;k<tr.childNodes.length;k++)
        {
            td = tr.childNodes[k];
            if(td.id!=undefined&&td.id.toLowerCase()=="td_checkbox")
            {
                for(t=0;t<td.childNodes.length;t++)
                {
                    var CheckBox = td.childNodes[t];
                    if(CheckBox.type!=undefined&&CheckBox.type.toLowerCase()=="checkbox")
                    {
                        CheckBox.checked = CheckedValue;
                        break;
                    }
                }
            }
        }
    }
}
function LockForm(ReadOnLy)
{    
    if(ReadOnLy=="false")
    {
        document.getElementById('txtMaKH').removeAttribute('readOnly');
        document.getElementById('txtTenKH').removeAttribute('readOnly',false);
        document.getElementById('txtSoHoaDon').removeAttribute('readOnly');
        
        document.getElementById('txtSoTien').removeAttribute('readOnly',false);
        document.getElementById('txtTaiKhoanNo').removeAttribute('readOnly');
        document.getElementById('txtTaiKhoanCo').removeAttribute('readOnly');
        
        document.getElementById('txtTongTien').removeAttribute('readOnly');
        document.getElementById('txtDienGiai').removeAttribute('readOnly');
           
        document.getElementById('txtMaSoThue').removeAttribute('readOnly');
        document.getElementById('txtSoSeri').removeAttribute('readOnly');
        document.getElementById('txtTienThue').removeAttribute('readOnly');
        
        document.getElementById('txtTaiKhoanThue').removeAttribute('readOnly');
        document.getElementById('txtNgayLapHoaDon').removeAttribute('readOnly');
        document.getElementById('txtThueSuat').removeAttribute('readOnly');
        document.getElementById('TongPhieuThu').removeAttribute('readOnly');
        if(CheckType == "BenhNhan")
        {
            document.getElementById('txtSoTien').setAttribute('readOnly', false);
        }
        else
        if(CheckType =="KhachLe")
        {
            document.getElementById('txtMaKH').setAttribute('readOnly', true);
            document.getElementById('txtTenKH').setAttribute('readOnly', false);
            document.getElementById('txtSoTien').setAttribute('readOnly', false);                 
        }
    }
    else
    if(ReadOnLy=="true")
    {
        document.getElementById('txtMaKH').setAttribute('readOnly', true);
        document.getElementById('txtTenKH').setAttribute('readOnly', false);
        document.getElementById('txtSoHoaDon').setAttribute('readOnly', true);
        
        document.getElementById('txtSoTien').setAttribute('readOnly', true);
        document.getElementById('txtTaiKhoanNo').setAttribute('readOnly', true);
        document.getElementById('txtTaiKhoanCo').setAttribute('readOnly', true);
        
        document.getElementById('txtTongTien').setAttribute('readOnly', true);
        document.getElementById('txtDienGiai').setAttribute('readOnly', true);
           
        document.getElementById('txtMaSoThue').setAttribute('readOnly', true);
        document.getElementById('txtSoSeri').setAttribute('readOnly', true);
        document.getElementById('txtTienThue').setAttribute('readOnly', true);
        
        document.getElementById('txtTaiKhoanThue').setAttribute('readOnly', true);
        document.getElementById('txtNgayLapHoaDon').setAttribute('readOnly', true);
        document.getElementById('txtThueSuat').setAttribute('readOnly', true);
        document.getElementById('TongPhieuThu').setAttribute('readOnly', true);     
    }
}
  var CheckType="KhachHang";
function RadioChecked(Ctr)
{
    document.getElementById('TableDanhSach').style.display='none';      
    if(Ctr == "BenhNhan")
    {
         CheckType="BenhNhan";
        
      ResetDataonTable();
      document.getElementById('txtMaKH').value="";
      document.getElementById('txtTenKH').value="";
      document.getElementById('txtMaKH').removeAttribute('readOnly');
      document.getElementById('txtTenKH').removeAttribute('read0nly',false);
      document.getElementById('txtSoTien').setAttribute('readOnly', false);
      document.getElementById('TableDanhSach').style.display='block';           
    }
    else
    if(Ctr =="KhachLe")
    {
         CheckType="KhachLe"; 
         ResetDataonTable();
        document.getElementById('txtMaKH').value="KhachLe";
       // document.getElementById('txtTenKH').value="Khách lẻ";
        document.getElementById('txtSoTien').value="";
        document.getElementById('txtMaKH').setAttribute('readOnly', true);
        document.getElementById('txtTenKH').removeAttribute('read0nly',false);
        document.getElementById('txtSoTien').setAttribute('readOnly', false);
        document.getElementById('TableDanhSach').style.display='block';        
    }    
    
}
function TestDate(t)
	{
		if (t.value != "")
		{
			t.value=AddString(t.value);
			if (isDate(t.value)==false)
			{
				t.value="";
				alert("Bạn nhập ngày tháng không hợp lệ ! ");
				t.focus();
				
			}
		}
		return;
	}
function TestSoHoaDon()
{
    var SoHoaDon  = document.getElementById('txtSoHoaDon');
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value==1)
                  {  
                    alert("Số hóa đơn này đã tồn tại. Vui lòng kiểm tra lại. Cảm ơn!");
                    SoHoaDon.value = "";
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=TestSoHoaDon&Key="+SoHoaDon.value+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
//-------------------------- Các hàm load dữ liêu------------------------------
//===============================================================================

function ShowTaiKhoan(Ctr)
{    
    var obj=Ctr.id;   
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                               // document.getElementById(obj).blur();
                                                            }
                                                        );           
}
function setChonTaiKhoan(MaTaiKhoan,obj)
{
       var txtTaiKhoan=document.getElementById(obj);
      txtTaiKhoan.value=MaTaiKhoan;     
}
function ShowKhachHang(obj)
{   
        var objsrc = document.getElementById(obj);      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachKhachHang_BN&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:700,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    setChonKhachHang(data[2],data[3],data[4],data[6]);
                                                                   // document.getElementById(obj).blur();
                                                                }
                                                            ); 
               
}

function setChonBenhNhan(MaKH,TenKH,idBenhNhan,DiaChi)
{      
      var txtMaKH=document.getElementById('txtMaKH');
      var txtTenKH=document.getElementById('txtTenKH');
      var hd_IDBN = document.getElementById('hd_idBenhNhan');
      var txtDiaChi= document.getElementById('txtDiaChi');
      txtMaKH.value=MaKH;
      txtTenKH.value = TenKH;
      hd_IDBN.value = idBenhNhan;
      txtDiaChi.value = DiaChi;
      document.getElementById('txtTenKH').focus();
}
function setChonKhachHang(MaKH,TenKH,DiaChi,MST)
{      
      var txtMaKH=document.getElementById('txtMaKH');
      var txtTenKH=document.getElementById('txtTenKH');
      var txtDiaChi= document.getElementById('txtDiaChi');
      var txtMaSoThue=document.getElementById('txtMaSoThue');
      txtMaKH.value=MaKH;
      txtTenKH.value = TenKH;   
      txtDiaChi.value = DiaChi;
      txtMaSoThue.value=MST;     
      document.getElementById('txtTenKH').focus();
      //alert(hd_IDBN.value);
}
function showhanghoa(Ctr)
{
    var obj=Ctr.id;    
    var objsrc = document.getElementById(obj);      
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachHangHoa&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:700,scroll:true,formatItem:function(data)
                                                            {return data[1];}
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {                                                                                                                                   
                                                                    setchonhanghoa(data[2],data[3],data[4],obj);
                                                                   // document.getElementById(obj).blur();
                                                                }
                                                            ); 
                                                            
}
function setchonhanghoa(mahang,tenhang,dvt,obj)
{    
    var a=parseInt(obj.substr(obj.length-1,1));    
    document.getElementById('tablehanghoa').rows[a].cells[2].getElementsByTagName("input")[0].value=mahang;
    document.getElementById('tablehanghoa').rows[a].cells[3].getElementsByTagName("input")[0].value=tenhang;
    document.getElementById('tablehanghoa').rows[a].cells[4].getElementsByTagName("input")[0].value=dvt;           
}
function tinhthanhtien(Ctr)
{  
    var obj=Ctr.id;     
    //alert(obj); 
    var i=parseInt(obj.substr(obj.length-1,1));    
    var soluong=document.getElementById('tablehanghoa').rows[i].cells[6].getElementsByTagName("input")[0].value;    
    var dongia=document.getElementById('tablehanghoa').rows[i].cells[7].getElementsByTagName("input")[0].value;  
    var thanhtien=document.getElementById('tablehanghoa').rows[i].cells[8].getElementsByTagName("input")[0].value;     
    dongia=ChangeFormatCurrency(dongia);     
    thanhtien=soluong*dongia    
    document.getElementById('tablehanghoa').rows[i].cells[8].getElementsByTagName("input")[0].value=FormatSoTien(thanhtien);        
}
function dinhdangdongia(Ctr)
{
    var obj=Ctr.id;  
    var i=parseInt(obj.substr(obj.length-1,1));   
    var dongia=document.getElementById('tablehanghoa').rows[i].cells[7].getElementsByTagName("input")[0].value;
    document.getElementById('tablehanghoa').rows[i].cells[7].getElementsByTagName("input")[0].value=FormatSoTien(dongia);
}
function changethanhtien()
{   
    document.getElementById('TongTien').value=FormatSoTien(tinhtongtien());
    document.getElementById('txtSoTien').value=FormatSoTien(tinhtongtien());
    document.getElementById('txtTongTien').value=FormatSoTien(tinhtongtien());
    
}
function tinhtongtien()
{
    var table=document.getElementById('tablehanghoa');
    var rows=table.rows.length;
    var tongtien=0;
    var thanhtien=0;
    //alert(rows);
    for(var i=2;i<rows;i++)
    {       
        //alert(i);
        thanhtien=document.getElementById('tablehanghoa').rows[i].cells[8].getElementsByTagName("input")[0].value;        
        if(thanhtien !=0)
            thanhtien=ChangeFormatCurrency(thanhtien);        
        tongtien = tongtien + parseInt(thanhtien);
    }   
    return tongtien;
}
//=====================================Phan Trang==================================================
function ShowPage(Ctr,ItemCount,ArrayPage)
{
    if(Ctr!=currentPage)
    { 
        if(currentPage!="")
        {
           document.getElementById(currentPage).style.color='black';
        }
        document.getElementById(Ctr).style.color='blue';
        currentPage = Ctr;
    }
    var num_page = Ctr.split('_')[1];
    //alert(num_page);
   ResetTableDSPhieuThu();
   var Array =  ShowArrayItem(num_page,ItemCount,ArrayPage);
   var row = Array.split('|');
    for(var i = 1;i<row.length;i++)
    {
        var Column = row[i];
        if(Column!=""&& Column!=null)
        {
            var data = Column.split('&');
            ShowDanhSachPhieuThuBanThuoc(data[0],data[1],data[2],data[3],data[4],data[5],data[6],0);
         }           
    }
}
//=======================================================================================
function Chon_LoaDanhSachPT()
{             
    if(document.getElementById('txtNgayThu').value=='')        
    {
        alert('vui lòng chọn ngày lấy dữ liệu');
        document.getElementById('txtNgayThu').focus();
        return false;
    }              
    LoadPhieuThu_forBenhNhan();            
}
function ShowDanhSachPhieuThuBanThuoc(STT,idphieuxuat,maphieuxuat,ngaythang,mabenhnhan,tenbenhnhan,ghichu,tkno,thanhtien,tienthue,tien_ck,tongtien)
{          
    var TableDanhSach = document.getElementById('TableDanhSach');
    var lastRow = TableDanhSach.rows.length; 
    var shtml = "<tr class=\"RowGidView\">";
        shtml += "		<td class=\"Column1\" style=\"width:4%\">" + STT + "</td>";
        shtml += "		<td class=\"Column2\" id=\"td_checkbox\" style=\"width:3%\" ><input type=\"hidden\" id=\"idphieuxuat_"+(lastRow-1)+"\" value=\""+idphieuxuat+"\"/><input type=\"checkbox\" id=\"checkbox_"+(lastRow-1)+"\" checked=\"checked\" /></td>";        
        //shtml += "		<td class=\"Column3\" id=\"txtmaphieuxuat_"+(lastRow-1)+"\" style=\"width:8%\"><a href=KTD_PhieuXuatKho.aspx?dkmenu=ktduoc#idkhoachinh="+idphieuxuat+">"+maphieuxuat+"</a></td>	";
        shtml += "		<td class=\"Column3\" id=\"txtmaphieuxuat_"+(lastRow-1)+"\" style=\"width:8%\"><button  id=\"btnphieuxuat\" stype=\"width:100%\"  onclick=\"xemphieuxuat("+idphieuxuat+")\">"+maphieuxuat+"</button></td>	";
        shtml +="       <td class=\"Column4\" id=\"txtngaythang_"+(lastRow-1)+"\" style=\"width:7%\">"+ngaythang+"</td>";
        shtml += "		<td class=\"Column5\" id=\"txtmabn_"+(lastRow-1)+"\" style=\"width:8%\"> "+mabenhnhan+"</td>	";
        shtml += "		<td class=\"Column6\" id=\"txttenbn_"+(lastRow-1)+"\" style=\"width:15%\">"+tenbenhnhan+"</td>";
        shtml += "		<td class=\"Column7\" id=\"txtghichu_"+(lastRow-1)+"\" style=\"width:15%\">"+ghichu+"</td>";
        shtml += "		<td class=\"Column8\" id=\"txttkno_"+(lastRow-1)+"\"style=\"width:7%\">"+tkno+"</td>";
        shtml += "		<td class=\"Column9\" id=\"txtthanhtien_"+(lastRow-1)+"\" style=\"width:7%\">"+FormatSoTien(thanhtien)+"</td>	";     
        shtml += "		<td class=\"Column10\" id=\"txttienthue_"+(lastRow-1)+"\" style=\"width:6%\">"+FormatSoTien(tienthue)+"</td>	"; 
        shtml += "		<td class=\"Column11\" id=\"txttien_ck_"+(lastRow-1)+"\"style=\"width:8%\">"+FormatSoTien(tien_ck)+"</td>	"; 
        shtml += "		<td class=\"Column12\" id=\"txttongtien_"+(lastRow-1)+"\" style=\"width:12%\"><input id=\"tongtien_"+(lastRow-1)+"\" type=\"text\"  value=\""+FormatSoTien(tongtien)+"\" /></td>	";                          
     shtml += "	</tr>";
  $("#TableDanhSach:last").append(shtml);
  
  document.getElementById('TongPhieuThu').style.visibility = "inherit";
}

function xemphieuxuat(idphieuxuat)
{
    var loaihoadon=document.getElementById('ddlloaixuat').value;
    if(loaihoadon==1 || loaihoadon==2)    
        window.open("KTD_PhieuXuatKho.aspx?dkmenu=ktduoc#idkhoachinh="+idphieuxuat);
    else
        alert('Chức năng này chưa có!');
}
function LoadPhieuThu_forBenhNhan()
{           
        ResetTableDSPhieuThu();
        var idBenhNhan = document.getElementById('hd_idBenhNhan').value;
        var NgayThu = document.getElementById('txtNgayThu').value; 
        var vat=document.getElementById('txtThueSuat').value;
        var loaixuat=document.getElementById('ddlloaixuat').value;                      
        xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value!="")
                      { 
                        var ArrayPage = value;
                        var row=ArrayPage.split('|');
                        for(var i = 1;i<row.length;i++)
                        {
                            var Column = row[i];
                            if(Column!=""&&Column!=null)
                            {
                                var data = Column.split('&');
                                ShowDanhSachPhieuThuBanThuoc(i,data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],data[8],data[9],data[10],0);
                            }
                        }                       
                      }
                      else
                        alert("Không có phiếu thu nào thỏa điều kiện lọc!");
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=LoadDSPhieuThu_byBenhNhan&idBenhNhan="+idBenhNhan+"&NgayThu="+NgayThu+"&vat="+vat+"&loaixuat="+loaixuat+"&times="+Math.random(),true);
            xmlHttp.send(null);   
}
function ShowDanhSachPhieuThu_forBenhNhan(MaBenhNhan,TenBenhNhan,NgayThu,ThanhTien,idBenhNhan)
{
    var txtSoTien = document.getElementById('txtSoTien');
    var txtTongTien = document.getElementById('txtTongTien');
     var txtNgayThu = document.getElementById('txtNgayThu');
    document.getElementById('txtThueSuat').value = "0";;
    document.getElementById('txtTienThue').value ="0";
    txtSoTien.value = FormatSoTien(ThanhTien);
    txtTongTien.value = FormatSoTien(ThanhTien);
    txtNgayThu.value = NgayThu;
}

function CongPhieuThu()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var TongTien = 0;
    var x;   
    if(Row>2)
    {
        while(Row>2)
        {
            
            var idCheckBox = "checkbox_"+(Row-2);
            var checkbox = document.getElementById(idCheckBox);
            if(checkbox.checked)
            {
                var count = TongTien;
                var txtSoTien = "tongtien_"+(Row-2);
                var sotien =  document.getElementById(txtSoTien);
                TongTien =  eval(count) + (eval(ChangeFormatCurrency(sotien.value)));
                 
            }
            Row--;
            
        }
     }
     else
     {
        alert("Chưa chọn phiếu thu. Vui lòng kiểm tra lại.");
     }
     
    var txtSoTien = document.getElementById('txtSoTien');
    txtSoTien.value = FormatSoTien(TongTien);
     var txtTongTien = document.getElementById('txtTongTien');
    txtTongTien.value = FormatSoTien(TongTien);
}

//==================================================Lưu Hóa đơn=============================================
//==========================================================================================================
function LuuHoaDon(Ctr)
{
    Ctr.disabled  = true;
    document.getElementById('message').style.visibility = "visible";                      
    var HoaDonID = document.getElementById('hdHoaDonID').value;
    var SoHD = document.getElementById('txtSoHoaDon').value;
    var loai_hd=document.getElementById('ddlloaixuat').value;
    var SoSeri = document.getElementById('txtSoSeri').value;
    var NgayLapHoaDon = document.getElementById('txtNgayLapHoaDon').value;  
    var MaKH = document.getElementById('txtMaKH').value;
    var TenKH = document.getElementById('txtTenKH').value;
    var NguoiMua = document.getElementById('txtNguoiMua').value;
    var DiaChi = document.getElementById('txtDiaChi').value;
    var MaSoThue = document.getElementById('txtMaSoThue').value;
        
    var DienGiai = document.getElementById('txtDienGiai').value;
    var TKNo = document.getElementById('txtTaiKhoanNo').value;
    var TKCo = document.getElementById('txtTaiKhoanCo').value;
    var TKThue = document.getElementById('txtTaiKhoanThue').value;
    var ThueSuat = document.getElementById('txtThueSuat').value;
    var Tien = document.getElementById('txtSoTien').value;
    var TienThue = document.getElementById('txtTienThue').value;
    var TongTien = document.getElementById('txtTongTien').value;
    var UserDau = 'Ngoc';
    var UserCuoi = '';
    var Status = 0;
    if(TKCo=="")
        {
            alert('Chưa chọn tài khoản có. Vui lòng kiểm tra lại. Cảm ơn!');
            Ctr.disabled  = false;
            document.getElementById('message').style.visibility = "hidden";
        }
    
    if(ThueSuat=="")
    {
       ThueSuat = '0';
       TienThue = '0';
    }
    if(SoHD=="")
    {
        alert('Chưa nhập số hóa đơn. Vui lòng kiểm tra lại. Cảm ơn!');
          Ctr.disabled  = false;
           document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(TKNo=="")
    {
        alert('Chưa chọn tài khoản nợ. Vui lòng kiểm tra lại. Cảm ơn!');
         Ctr.disabled  = false;
           document.getElementById('message').style.visibility = "hidden";
    }
    else        
    if(Tien=="")
    {
        alert('Chưa tính số tiền của hóa đơn. Vui lòng kiểm tra lại hoặc nhấn nút \"load phiếu thu\" để tính tiền. Cảm ơn!');
         Ctr.disabled  = false;
           document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(MaKH=="")
    {
        alert('Chưa chọn mã khách hàng hoặc bệnh nhân. Vui lòng kiểm tra lại. Cảm ơn!');
         Ctr.disabled  = false;
           document.getElementById('message').style.visibility = "hidden";
    }
    else
    if(NgayLapHoaDon=="")
    {
        alert('Chưa chọn ngày lập hóa đơn. Vui lòng kiểm tra lại. Cảm ơn!');
         Ctr.disabled  = false;
           document.getElementById('message').style.visibility = "hidden";
    }
    else
    {               
        GetSaveHoaDon(Ctr,HoaDonID,SoHD,SoSeri,NgayLapHoaDon,MaKH,TenKH,NguoiMua,DiaChi,MaSoThue,DienGiai,TKNo,TKCo,TKThue,ThueSuat,Tien,TienThue,TongTien,UserDau,UserCuoi,Status,loai_hd)
    }            
} 
 //==================================================Xóa sổ cái trước khi sửa hóa đơn========================
//==========================================================================================================
function GetSaveHoaDon(Ctr,HoaDonId,SoHD,SoSeri,NgayLapHD,idKH,TenKH,NguoiMua,DiaChi,MaSoThue,DienGiai,TKNo,TKCo,TKThue,ThueSuat,Tien,TienThue,TongTien,UserDau,UserCuoi,Status,loai_hd)
{    
   Ctr.disabled = true;
    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value==1)
                  {                                                                    
                      XoaChiTietHoaDon(Ctr,SoHD);                                          
                      //alert('Lưu hóa đơn thành công!');                      
//                      Ctr.disabled  = false;
//                      document.getElementById('message').style.visibility = "hidden"; 
//                      document.getElementById('bt_Luu').value ="Sửa";                    
                  }
                  else
                  {
                     alert('Lưu hóa đơn thất bại. Vui lòng kiểm tra lại. Cảm ơn!');
                     Ctr.disabled  = false;
                     document.getElementById('message').style.visibility = "hidden";
                  }                              
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=SaveHoaDonBanHang&HoaDonId="+HoaDonId+"&SoHD="+SoHD+"&SoSeri="+SoSeri+"&NgayLapHD="+NgayLapHD+"&idKH="+idKH+"&TenKH="+ encodeURIComponent(TenKH)+"&NguoiMua="+ encodeURIComponent(NguoiMua)+"&DiaChi="+ encodeURIComponent(DiaChi)+"&MaSoThue="+MaSoThue+"&DienGiai="+ encodeURIComponent(DienGiai)+"&TKNo="+TKNo+"&TKCo="+TKCo+"&TKThue="+TKThue+"&ThueSuat="+ThueSuat+"&Tien="+ChangeFormatCurrency(Tien)+"&TienThue="+ChangeFormatCurrency(TienThue)+"&TongTien="+ChangeFormatCurrency(TongTien)
          +"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+(UserCuoi)+"&Status="+Status+"&loai_hd="+loai_hd+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function XoaChiTietHoaDon(Ctr,SoHD)// Xóa chi tiết hóa đơn trước khi sửa chi tiết hóa đơn
{
    //XoaChiTietHoaDonDichVu
       var xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
               // XoaSoCai(Ctr,SoHD);
                 LuuChiTietHoaDon(Ctr,SoHD);
            }
        }
        xmlHttp.open("GET","ajax.aspx?do=XoaChiTietHoaDonBanHang&SoHD="+SoHD+"&time="+Math.random(),true);
        xmlHttp.send(null);
}
function XoaSoCai(Ctr,SoHD)
{    
        var  xmlHttp1 = GetMSXmlHttp();
        xmlHttp1.onreadystatechange = function()
        {
            if(xmlHttp1.readyState == 4)
            {
                var value = xmlHttp1.responseText;                              
            }
        }         
          xmlHttp1.open("GET","ajax.aspx?do=XoaSoCaiBySoPT&SoPT="+SoHD+"&times="+Math.random(),true);
        xmlHttp1.send(null);
        
}
//==================================================Lưu Chi tiết hóa đơn=============================================
//===================================================================================================================
function LuuChiTietHoaDon(Ctr,SoHD)
{
    //var SoHD = document.getElementById('txtSoHoaDon').value;        
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;
    var idphieuxuat="";
    if(Row>2)
    {
      while(Row>2)
       {
            var idCheckBox = "checkbox_"+(Row-2);
            var checkbox = document.getElementById(idCheckBox);
            if(checkbox.checked)
            {
                var idMaPT = "idphieuxuat_"+(Row-2);
                idphieuxuat +=";"+ document.getElementById(idMaPT).value;                                                                            
                // Lưu chi tiết phiếu thu mới
            }
            Row--;           
        }        
        Kiemtrasomathangxuat(Ctr,SoHD,idphieuxuat);
     }
    else
    {
         alert('Chưa có phiếu thu cho hóa đơn này. Vui lòng kiểm tra lại. Cảm ơn!');
         Ctr.disabled  = false;
           document.getElementById('message').style.visibility = "hidden";
        XoaHoaDon(SoHD);
    }
}
function Kiemtrasomathangxuat(Ctr,SoHD,MaPT)
{      
    var loaihd=document.getElementById('ddlloaixuat').value;
    var xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="1")
                {
                   alert('Hóa đơn xuất trên 15 mặt hàng hoặc tên mặt hàng quá dài.');
                   XoaHoaDon(SoHD);
                   Ctr.disabled  = false;
                   document.getElementById('message').style.visibility = "hidden";                                          
                }
                else
                {
                    GetSaveChiTietHoaDon(Ctr,SoHD,MaPT);
                }                               
            }
        }         
          xmlHttp.open("GET","ajax.aspx?do=Kiemtrasomathangxuat&SoHD="+SoHD+"&MaPT="+MaPT+"&loaihd="+loaihd+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function GetSaveChiTietHoaDon(Ctr,SoHD,MaPT)
{
    var loaihd=document.getElementById('ddlloaixuat').value;      
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="1")
                {
                  alert("Lưu hóa đơn thành công");    
                    //CapNhatTrangThaiPhieuThu(Ctr);  
                    Ctr.disabled  = false;
                    document.getElementById('message').style.visibility = "hidden";                       
                    document.getElementById('bt_Luu').value ="Sửa";
                }
                else
                {
                   alert("Lưu chi tiết hóa đơn thất bại");    
                   XoaHoaDon(SoHD);
                }                
                Ctr.disabled = false;
                var SoHD = document.getElementById('txtSoHoaDon').value;
                document.getElementById('message').style.visibility = "hidden";
                LockForm("true");
                document.getElementById('bt_Luu').value = "Sửa";
                //document.getElementById('bt_LoadDSPT').style.visibility = "hidden";
                ResetTableDSPhieuThu();
                LoadDanhSachPhieuThuHoaDonBanHang(SoHD);  
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=SaveChiTietHoaDonBanHang&SoHD="+SoHD+"&MaPT="+MaPT+"&loaihd="+loaihd+"&times="+Math.random(),true);
        xmlHttp.send(null);
}

function XoaHoaDon(SoHD)
{
      var NgayLapHD = document.getElementById('txtNgayLapHoaDon').value;   
      var xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                if(value=="1")
                {
                    // XoaSoCai(Ctr,SoHD);
                }
                var value = xmlHttp.responseText;
               // document.getElementById('bt_LoadDSPT').style.visibility = "visible";
            }
        }         
          xmlHttp.open("GET","ajax.aspx?do=XoaHoaDonDichVu&SoHD="+SoHD+"&NgayLapHD="+NgayLapHD+"&times="+Math.random(),true);
        xmlHttp.send(null);
}

function CapNhatTrangThaiPhieuThu(Ctr)
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;   
    var PhieuThu_List="";
    if(Row>2)
    {
        while(Row>2)
        {
            var DoanhThuID = "DoanhThuID_"+(Row-2);
            var objDoanhThuID = document.getElementById(DoanhThuID);
                       
            var IDKH = "idBenhNhan_"+(Row-2);
            var objKH = document.getElementById(IDKH);
            
            var NgayThu = "NgayThu_"+(Row-2);
            var Ngay_Thu = document.getElementById(NgayThu);
            
            var idCheckBox = "checkbox_"+(Row-2);
            var checkbox = document.getElementById(idCheckBox);
            if(checkbox.checked)
            {               
               GetFunctionCapNhat(Ctr,objKH.value,Ngay_Thu.value,objDoanhThuID.value,1);
            }
            else
            {
               GetFunctionCapNhat(Ctr,objKH.value,Ngay_Thu.value,objDoanhThuID.value,0);
            }
            Row--;            
        }
     }   
}
function GetFunctionCapNhat(Ctr,idBenhNhan,NgayThu,DoanhThuID,TrangThai)
{      
      xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;            
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=CapNhatTrangThaiDoanhThu&DoanhThuID="+DoanhThuID+"&idBenhNhan="+idBenhNhan+"&NgayThu="+NgayThu+"&TrangThai="+TrangThai+"&times="+Math.random(),true);
        xmlHttp.send(null);        
}
//==================================================Load danh sách phiếu thu của hóa đơn dịch vụ=============================================
//===================================================================================================================
function LoadDanhSachPhieuThuHoaDonBanHang(SoHD)
{    
    var loaihd=document.getElementById('ddlloaixuat').value;
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value!="")                 
                  {  // ngay_thu(0),id_bn(1),mabenhnhan(2),tenbenhnhan(3),tien_thu(4),doanhthuid
                    var ArrayPage = value;                    
//                        var Array =  CreatePager(20,ArrayPage);
//                        var row = Array.split('|');
                        var row= ArrayPage.split('|');
                        for(var i = 1;i<row.length;i++)
                        {
                            var Column = row[i];
                            if(Column!=""&&Column!=null)
                            {
                                var data = Column.split('&');                                
                                ShowDanhSachPhieuThuBanThuoc(i,data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],data[8],data[9],data[10],0);
                            }
                        }
                  }
                  else
                  {
                    alert("Hóa đơn này không có phiếu thu!");
                    //document.getElementById('bt_LoadDSPT').disable = false;
                    document.getElementById('message').style.visibility = "hidden";
                  }                  
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=LoadDanhSachPhieuThuHoaDonBanHang&SoHD="+SoHD+"&loaihd="+loaihd+"&times="+Math.random(),true);
        xmlHttp.send(null);
}
function In_hoa_don()
{
    //alert('chưa có mẫu hóa đơn');
    var so_hd=document.getElementById('txtSoHoaDon').value;
    var ngay_lap_hd =document.getElementById ('txtNgayLapHoaDon').value;    
    var loaihd=document.getElementById('ddlloaixuat').value; 
    var hinhthucin=document.getElementById('ddlhinhthucin').value;
    if(ngay_lap_hd=="")
    {
        alert('Chua có ngày lập hóa đơn, xin nhập vào!');
    }
    else                
            {
                if(hinhthucin==1)
                    window.open("KTD_rptXuatHoaDonBanHangTH.aspx?so_hoa_don=" + so_hd+"&loaihd="+loaihd +"&hinhthucin="+hinhthucin );                   
                if(hinhthucin==0)    
                {                     
                    window.open("HDDV_rptXuatHoaDon.aspx?so_hoa_don=" + so_hd+"&ngay_lap_hd="+ngay_lap_hd );                 
                     window.open("KTD_rptXuatHoaDonBanHangTH.aspx?so_hoa_don=" + so_hd+"&loaihd="+loaihd +"&hinhthucin="+hinhthucin );                                                
                }
            }
}
function copynoidung()
{
    var makh=document.getElementById('txtMakh').value;
    var tenkh=document.getElementById('txtTenKH').value;
    var mst=document.getElementById('txtMaSoThue').value;
    var nguoimua=document.getElementById('txtNguoiMua').value;
    var diachi=document.getElementById('txtDiaChi').value;
//   var sohoadon=document.getElementById('txtSoHoaDon').value;
//   var ngaylaphd=document.getElementById('txtNgayLapHoaDon').value;
//   var soseri=document.getElementById('txtsoseri').value;
//   var sotien= document.getElementById('txtsotien').value;
    var tkno=document.getElementById('txttaikhoanno').value;
    var tkco=document.getElementById('txttaikhoanco').value;
    var diengiai=document.getElementById('txtDienGiai').value;
    TaoMoi();       
    document.getElementById('txtMakh').value=makh;    
    document.getElementById('txtTenKH').value=tenkh;
    document.getElementById('txtMaSoThue').value=mst;
    document.getElementById('txtNguoiMua').value=nguoimua;
    document.getElementById('txtDiaChi').value=diachi;
//    document.getElementById('txtSoHoaDon').value=sohoadon;
//    document.getElementById('txtNgayLapHoaDon').value=ngaylaphd;
//    document.getElementById('txtsoseri').value=soseri;
//    document.getElementById('txtsotien').value=sotien;
    document.getElementById('txttaikhoanno').value=tkno;
    document.getElementById('txttaikhoanco').value=tkco;
    document.getElementById('txtMakh').focus();
    document.getElementById('txtDienGiai').value = diengiai;
    alert('Copy nội dung thành công');
}
function ngaylap()
{
    dinhdangngay(document.getElementById('txtNgayLapHoaDon'));
}
function ngaythu()
{
    dinhdangngay(document.getElementById('txtNgayThu'));
}

function ShowDanhSachHDKH_CT(stt,mahang,tenhang,dvt,tkco,soluong,dongia,thanhtien)
{          
        var tablehanghoa = document.getElementById('tablehanghoa');
        var lastRow = tablehanghoa.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:5%;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+stt+"\" style=\"width:99% ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:5%\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\" /></td>";       
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"mahang_"+(lastRow)+"\" onfocus=\"showhanghoa(this)\" value=\""+mahang+"\"/></td>	";     
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"tenhang_"+(lastRow)+"\" onfocus=\"showhanghoa(this)\" style=\"width:99%\" value=\""+tenhang+"\" /></td>	";
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"dvt_"+(lastRow)+"\" value=\""+dvt+"\" /></td>	";
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" id=\"taikhoanco_"+(lastRow)+"\" value=\""+tkco+"\"  /></td>	";     
            shtml += "		<td class=\"Column1_CK\"><input type=\"text\" onblur=\"tinhthanhtien(this)\"  id=\"soluong_"+(lastRow)+"\" value=\""+soluong+"\" style =\"text-align:right\" /></td>	";                                
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"dongia_"+(lastRow)+"\" onblur=\"dinhdangdongia(this);tinhthanhtien(this)\"  style =\"text-align:right\" value=\""+FormatSoTien(dongia)+"\" /></td>	";             
            shtml += "		<td class=\"Column2_CK\"><input type=\"text\" id=\"thanhtien_"+(lastRow)+"\" onfocus=\"changethanhtien()\" style =\"text-align:right\"  value=\""+FormatSoTien(thanhtien)+"\" /></td>	";                                           
         shtml += "	</tr>";         
      $("#tablehanghoa:last").append(shtml);            
}
function loaddanhsachHDKH_CT(so_hd,ngay_hd)
{
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {
            var value=xmlHttp.responseText;                       
            if(value!="")
            {                
                var table=value.split('|');                
                for(var i=1;i<table.length;i++)
                {
                    column=table[i].split('&');
                    if(column!="" || column!=null)
                    {
                    var a=column;                   
                    ShowDanhSachHDKH_CT(i+1,a[0],a[1],a[2],a[3],a[4],a[5],a[6]);
                    }
                }                     
            }           
            else
                alert('không có hóa đơn này trong danh sách');
        } 
    }
    xmlHttp.open("GET","ajax.aspx?do=loaddanhsachHDKH_CT&so_hd="+so_hd+"&ngay_hd="+ngay_hd+"&times="+Math.random(),true);
    xmlHttp.send("null");    
}
function kiemtrasohoadon()
{    
    var tenbang="hoa_don_dv";
    var tenfield="so_hd";
    var dieukien=document.getElementById('txtSoHoaDon').value;       
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {            
            var value=xmlHttp.responseText;
            if (value==1)
            {
                alert('Số hóa đơn này đã có, xin nhập lại số khác!');
                document.getElementById('txtSoHoaDon').focus();
            }            
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien,"&times="+Math.random(),true);
    xmlHttp.send(null);    
}
function kiemtrangaykhoaso(ngaylap_ct,Ctr)
{       
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {
            var value=xmlHttp.responseText; 
            if(value==1)
                alert('Ngày lập hóa đơn phải lớn hơn ngày khóa sổ!');
            else 
            {
                if(document.getElementById('bt_Luu').value =="Sửa")
                {
                    LockForm("false");
                    document.getElementById('bt_Luu').value = "Lưu";        
                }
                else
                if(document.getElementById('bt_Luu').value =="Lưu")
                {                                            
                    LuuHoaDon(Ctr);    
                }
            }             
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrangaykhoaso&ngaylap_ct="+ngaylap_ct+"&times="+Math.random(),true)    
    xmlHttp.send(null);      
}
function Chonloaixuat()
{
    var loaixuat=document.getElementById('ddlloaixuat').value;
    if(loaixuat==5)
    {
        document.getElementById('ddlhttt').disabled=false;        
    }
    else
        document.getElementById('ddlhttt').disabled=true;
    //alert(loaixuat);
}
function Chonhttt()
{
    var httt=document.getElementById('ddlhttt').value;    
    if(httt!=0)    
        loadtaikhoan(httt);
}
function loadtaikhoan(httt)
{
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {
            var value=xmlHttp.responseText; 
            if(value!="")
                document.getElementById('txtTaiKhoanNo').value =value;        
            else
                alert('Chưa có tài khoản nợ cho hình thức này');
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=loaitaikhoan&hinhthucthanhtoan="+httt+"&times="+Math.random(),true)    
    xmlHttp.send(null);      
}
//===================================================================================================================
</script>
<form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:menu_hodondichvu ID="hoadondichvu1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>    
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">XUẤT HÓA ĐƠN BÁN HÀNG</div></td>
                </tr>
                <tr>
					    <td width="100%" valign = "top">
						    <table cellPadding="0" width="100%" border="0">
							    <tr>
								    <td vAlign="top" align="center" width="100%">
									    <table cellSpacing="0" cellPadding="0" width="98%" border="0">
										    
										    <tr style="padding-bottom: 5px; padding-top: 10px">
											    <td align="left"  style="height: 20px;width:100%;padding-left:200px">
												    <table class="Table" >												        
                                                        <tr>
                                                            <td class="tdLabel">Mã Khách : </td>
                                                            <td class="tdText"><input id="txtMaKH"  type="text" onfocus="ShowKhachHang('txtMaKH')" class="InputText" /><input type="hidden" id="hd_idBenhNhan" /></td>
                                                            
                                                            <td class="tdLabel">Tên Khách: </td>
                                                            <td  class="tdText"><input id="txtTenKH" type="text"  onfocus="ShowKhachHang('txtTenKH')" class="InputText" /></td>
                                                            
                                                            <td class="tdLabel"> Mã số thuế : </td>
                                                            <td  class="tdText"><input id="txtMaSoThue" type="text" class="InputText" /></td>
                                                           
                                                        </tr>
                                                         <tr>
                                                            <td class="tdLabel">Người mua hàng : </td>
                                                            <td class="tdText"><input id="txtNguoiMua"  type="text" onfocus="ShowKhachHang('txtMaKH')" class="InputText" /><input type="hidden" id="Hidden1" /></td>
                                                            
                                                            <td class="tdLabel">Địa chỉ : </td>
                                                            <td  class="tdText" colspan="3" style="width:565px"><input id="txtDiaChi" type="text"  onfocus="ShowKhachHang('txtTenKH')" class="InputText" style="width:100%" /></td>                                                                                                                                                                                    
                                                        </tr>
                                                        <tr>                                                            
                                                             <td class="tdLabel" >Số hóa đơn :</td>
                                                            <td  class="tdText" ><input id="txtSoHoaDon" type="text" onblur ="kiemtrasohoadon()" class="InputText" />
                                                                                    <input id="hdHoaDonID" type="hidden" />
                                                            </td>
                                                            
                                                            <td class="tdLabel" >Ngày lập hóa đơn :</td>
                                                            <td class="tdText" ><input id="txtNgayLapHoaDon" onblur="ngaylap();" style="width:100px;" runat="server"  type="text"/>
                                                             &nbsp(dd/mm/yy)</td>
                                                            
                                                            <td class="tdLabel" >Số seri :</td>
                                                            <td  class="tdText" ><input id="txtSoSeri" type="text" class="InputText" /></td>
                                                        </tr> 
                                                         <tr>
                                                            <td class="tdLabel" >Số tiền : </td>
                                                            <td class="tdText" ><input id="txtSoTien" onchange="TinhTienThue()" onkeyup="TestNumberofInput('txtSoTien')" type="text" class="InputTien" /></td>
                                                            
                                                            <td class="tdLabel" >Thuế suất : </td>
                                                            <td  class="tdText" ><input id="txtThueSuat"  onkeyup="TestNumberofInput('txtThueSuat')"  onchange="TinhTienThue()" type="text" class="InputText" style=" text-align:right; width:100px" />%</td>
                                                            
                                                            <td class="tdLabel" >Tiền thuế : </td>
                                                            <td  class="tdText" ><input id="txtTienThue" type="text" class="InputTien" readonly="readonly" /></td>
                                                        </tr>                                                            
                                                        <tr>
                                                            <td class="tdLabel">Tài khoản nợ: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanNo" type="text" class="InputText" onchange="TestMaTaiKhoan('txtTaiKhoanNo')" onfocus="ShowTaiKhoan(this)" /></td>
                                                            <td class="tdLabel"><label id="lbltk_co">Tài khoản có:</label></td>
                                                            <td  class="tdText"><input id="txtTaiKhoanCo" type="text" class="InputText" onchange="TestMaTaiKhoan('txtTaiKhoanCo')" onfocus="ShowTaiKhoan(this)" /></td>
                                                            <td class="tdLabel">Tài khoản thuế :</td>
                                                            <td  class="tdText"><input id="txtTaiKhoanThue" type="text" class="InputText" onchange="TestMaTaiKhoan('txtTaiKhoanThue')" onfocus="ShowTaiKhoan(this)" /></td>
                                                        </tr>
                                                        
                                                        <tr>                                                                                                                      
                                                            <td class="tdLabel">Tổng tiền :</td>
                                                            <td colspan="2"  class="tdText"><input id="txtTongTien" class="InputTien" readonly="readonly" type="text" />VND  </td> 
                                                                                                                                                                                                                                       
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel">Diễn giải :</td>
                                                            <td colspan="6"  class="tdText">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>                                                            
                                                        </tr>
                                                        <tr>
                                                            <td class="tdLabel"><label id="lblngay_thu">Ngày thu :</label></td>
                                                            <td  class="tdText" ><input id="txtNgayThu" style="width:100px;" runat="server" onblur="ngaythu();" type="text"/>&nbsp<label id="lblmau">(dd/mm/yy)</label></td>                                                                                                                        
                                                            <td>Chọn loại xuất:</td>
                                                            <td><asp:dropdownlist id="ddlloaixuat" runat="server" ></asp:dropdownlist> </td>                                                                                                                        
                                                            <td> Chọn hình thức in</td>
                                                            <td>
                                                                <asp:dropdownlist id="ddlhinhthucin" runat="server">
                                                                <asp:ListItem Value="0">In k&#232;m bảng k&#234;</asp:ListItem>
                                                                <asp:ListItem Value="1">In chi tiết</asp:ListItem>
                                                                </asp:dropdownlist>                                                               
                                                            </td>
                                                        </tr>                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">
                                                                <input type="button" id="bt_LoadDSPT" onclick="Chon_LoaDanhSachPT()" value="Load phiếu thu" />                                                                                                                               
                                                                <input type="button" value="Lưu" id="bt_Luu"  onclick="bt_Click(this)" style="width:100px" />
                                                                <input type="button" value="Tạo mới" style="width:100px" id="bt_TaoMoi" onclick="TaoMoi()" />
                                                                <input type="button" value="IN" onclick ="In_hoa_don()" style="width:50px" id="bt_in" />        
                                                                <input type="button" value="Copy" onclick ="copynoidung()" style="width:50px" id="bt_copy" />                                                                        
                                                                <input type="button"  id="TongPhieuThu" onclick="CongPhieuThu()" style="visibility:hidden" value="Tính doanh thu"/>                                                        
                                                                
                                                            </td>
                                                        </tr>
                                                         <tr>
                                                            <td colspan="9" style="text-align:center">
                                                                <label id="message"  style="visibility:hidden" > Đang xử lý vui lòng chờ trong giây lát....</label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </td>                                                  
										    </tr>
									    </table>
								    </td>
							    </tr>							    							    							   
						    </table>	
						    </td>					    						    				   					    
				</tr>
            </table>
         </td>
       </tr>       	    
     </table>     
    <table class="TableGidview" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="12" >DANH SÁCH PHIẾU THU</td>
         </tr>
		<tr class="HeaderGidView">
		     <td class="HeaderColumn1" >STT</td>
		     <td class="HeaderColumn1" id="td_checkbox" onclick='CheckAll(this)'><input type="checkbox"  id="checkbox_all" /></td>
		     <td class="HeaderColumn1">
		        Mã phiếu 
		     </td>
		     <td class="HeaderColumn1">
		        Ngày thu		       
		    </td>
		    <td class="HeaderColumn1">
		        Mã KH
		    </td>
		    <td class="HeaderColumn4">
		        Tên khách hàng		     
		    </td>	
		    <td class="HeaderColumn4">
		        diễn giải		     
		    </td>	
		    <td class="HeaderColumn5">
		        TK nợ		     
		    </td>	
		    <td class="HeaderColumn5">
		        Thành Tiền		     		        
		    </td>		   
		    <td class="HeaderColumn5">
		        Tiền thuế		     
		    </td>	
		    <td class="HeaderColumn5">
		        Tiền CK		     
		    </td>	
		    <td class="HeaderColumn6">
		        Tổng tiền	     
		    </td>	
		</tr>					 					  
	</table>           
</form>
<!--#include file ="footer.htm"-->

