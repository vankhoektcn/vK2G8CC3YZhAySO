<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KTTM_ThuKhac.aspx.cs" Inherits="ketoan_KTTM_ThuKhac" %>
 <!--#include file ="header.htm"-->
<link type="text/css" rel="stylesheet" href="../ketoan/css_KeToan/sheet_index.css" />
<link href="../ketoan/css_KeToan/epoch_styles.css" type="text/css" rel="stylesheet" />
<link href="../ketoan/css_KeToan/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/default.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/style.css" />
<script type="text/javascript" src="../ketoan/js_KeToan/libary.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/script.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/scriptoflong.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jscript.js"></script>
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/table_TCHD.css" />
<link type="text/css" rel="stylesheet" href="../ketoan/css_ketoan/epoch_styles.css" />
<link href="../ketoan/css_ketoan/dropdown/dropdown.css" media="screen" rel="stylesheet" type="text/css" />
<link href="../ketoan/css_ketoan/dropdown/themes/default/default.css" media="screen" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../ketoan/js_KeToan/epoch_classes.js"></script>
<script type="text/javascript" src="../ketoan/editor/editor.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/myjava.js"></script>
<script type="text/javascript" src="../ketoan/js_KeToan/jquery-1.4.2.js"></script>
<script src="../js/jquery.autocomplete.js" type="text/javascript"></script>    
<%@ Register Src="~/ketoan/Menu_KT/uscmenuKT_TienMat.ascx" TagName="menu_ketoantienmat" TagPrefix="uc1" %>
 <script language="javascript" type="text/javascript">
        
 //========================Các hàm kiểm tra===================   
     var dp_cal;
     var loaithu="";
     var nguoidung="";
     var ngaythu="";
     $(document).ready(function(){
        var queryString = "";
	    var loaithu="";	     
	    queryString =  window.location.search.substring(1).split('&');	    
	    if(queryString!="" && queryString!="dkmenu=kttienmat" )
	    {
	        var idPhieuThu = queryString[0].split('=');
	        var SoPT = queryString[1].split('=');	        	        
	         if(document.getElementById('bt_Luu').value =="Sửa")
            {
                document.getElementById('bt_Luu').value = "Lưu";        
            }            
	        DanhSachPhieuThuOfKhachHang(idPhieuThu[1]);		      	                  
	    }
	    if(queryString.length==5)
	    {	       
	        var tongtien=queryString[0].split('=');
	        var diengiai=queryString[1].split('=');
	        var doanhthu=queryString[2].split('=');
	        var ngaythu=queryString[3].split('=');
	        nguoidung=queryString[4].split('=');	        
	        document.getElementById('txtDienGiai').value=diengiai[1];
	        document.getElementById('TongTien').value=tongtien[1];	  
	        doanhthukhoa=doanhthu[1].split('|');   
	        var tkdoanhthu="";
	        var khoa="";
	        var tien="";   
	        var diengiaict="";	 	                	        
	        for(i=1;i<doanhthukhoa.length;i++)
	        {	            		                             
	            var row=doanhthukhoa[i].split('$');	           
	            tkdoanhthu=row[0];	
	            khoa=row[1];           
	            tien=row[2];
	            diengiaict='doanh thu khoa '+khoa+' ngày '+ngaythu[1];
	            ThemDong_phieuthu(tkdoanhthu,diengiaict,FormatSoTien(tien));   
	        }	        	        
	        document.getElementById('txtMaPT').focus();
	        loaithu=1;
	    }
	     $("#bt_Luu").click(function(){
            var ngaylap_ct=document.getElementById('txtNgayLapPhieuThu').value;
               if(loaithu==1)        
                    {                                   
                        updatedsdathu(nguoidung[1],ngaythu[1]);
                        nguoidung= nguoidung[1];
                        ngaythu = ngaythu[1];        
                    }
               kiemtrangaykhoaso(nguoidung,ngaythu,ngaylap_ct,this);
         });
     });
    

//function bt_Click(Ctr)
//{
//   var ngaylap_ct=document.getElementById('txtNgayLapPhieuThu').value;
//   if(loaithu==1)        
//        {
//            updatedsdathu(khoa,ngaythu);            
//        }
//   kiemtrangaykhoaso(ngaylap_ct,Ctr);
//}

function updatedsdathu(nguoidung,ngaythu)
{      
      xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value==1)
                      {  
                       // alert('update thành công!');
                      }
                }
            }
            xmlHttp.open("GET","ajax.aspx?do=updatedsdathu&nguoidung="+encodeURIComponent(nguoidung)+"&ngaythu="+ngaythu+"&times="+Math.random(),false);
            xmlHttp.send(null);
}

function kiemtrangaykhoaso(nguoidung,ngaythu,ngaylap_ct,Ctr)
{       
    var sophieu=document.getElementById('txtMaPT').value;    
    var tDay=new Date();
    var tYear=tDay.getFullYear();   
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
                if(Ctr.value=="Sửa")
                {
                 Ctr.value = "Lưu";
                }
                else 
                {
//                     if(sophieu=="")
//                    {       
//                        if(tYear <= 2012 )               
//                            TaoMaSoHoaDon2012(); 
//                        else
//                            TaoMaSoHoaDon();                
//                    }     
                    LuuPhieuThuKhac(nguoidung,ngaythu,Ctr);
                    if(document.getElementById('txtMaKH').value!="")
                    themkhachhang();
                }
            }             
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrangaykhoaso&ngaylap_ct="+ngaylap_ct+"&times="+Math.random(),true)    
    xmlHttp.send(null);      
}

function TaoMaSoHoaDon()
{       
        var Table = "Phieu_Thu";
       var manghiepvu = "PHIEU_THU";
       var Column = "so_phieu_thu";
       var ngaylap=document.getElementById('txtNgayLapPhieuThu').value;
       xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                    
                      if (value!="")
                      {                         
                        document.getElementById('txtMaPT').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong&Table="+Table+"&manghiepvu="+manghiepvu+"&Column="+Column+"&ngaylap="+ngaylap+"&times="+Math.random(),false);
            xmlHttp.send(null);
}

function TaoMaSoHoaDon2012()
{       
       var Table = "Phieu_Thu";
       var manghiepvu = "PHIEU_THU";
       var Column = "so_phieu_thu";
       var ngaylap=document.getElementById('txtNgayLapPhieuThu').value;
       xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;                    
                      if (value!="")
                      {                                          
                        document.getElementById('txtMaPT').value = value;  
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TaoMaSoTuDong_minhduc&Table="+Table+"&manghiepvu="+manghiepvu+"&Column="+Column+"&ngaylap="+ngaylap+"&times="+Math.random(),false);
            xmlHttp.send(null);
}

function getFormatSoTien(idText)
{
    var txtPhatSinh = document.getElementById(idText);
    txtPhatSinh.value = FormatSoTien(txtPhatSinh.value);
    TinhTongTien();
}
function FormatSoTien(obj)
{
	    return formatCurrency(obj);
}
function TestNumberofInput(obj)
{
        var key;
        if(window.event)
        {
          key = window.event.keyCode; 
        }
        //alert(key);
        var txtObj = document.getElementById(obj);
        //if((key<48||key>57)&&key!=190&&key!=8&&key!=9&&key!=37&&key!=38&&key!=39&&key!=40)
        if((key>=65&&key<=90))
        {
            alert("Chỉ được nhập số!");            
            txtObj.value ="";
        }
        else
        {
            var number = txtObj.value;
             if(number=="")
                number="0";
             if(!isFinite(parseFloat(number))||parseFloat(number)>999999999999)
             {   alert("Nhập sai định dạng.Chỉ được nhập số!Vui lòng kiểm tra lại cảm ơn!"); 
                 txtObj.value ="";
             }
         }     
}
//==================Các hàm xử lý==============================
function ResetDataonTable()
{
   if(document.getElementById('bt_Luu').value =="Sửa")
    {
        document.getElementById('bt_Luu').value = "Lưu";        
    }
    document.getElementById('txtMaKH').value="";
    document.getElementById('txtTenKH').value="";
    document.getElementById('txtMaPT').value="";
    document.getElementById('txtdiachi').value="";
    document.getElementById('hdPhieuThuID').value="";
    
    document.getElementById('txtTaiKhoanNo').value="";
    document.getElementById('txtDienGiai').value="";
    document.getElementById('txtNgayLapPhieuThu').value="";
    document.getElementById('txtNguoiNopTien').value="";
    document.getElementById('txtNgayLapPhieuThu').focus();
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
    document.getElementById('TongTien').value="";
//TongTien = 0;
}
function ShowTaiKhoan(obj)
{
    var objsrc = document.getElementById(obj);
  
        $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=DanhSachTaiKhoan_Jquery&Key="+objsrc.value+"&obj="+obj,
                                                    {width:350,scroll:true,formatItem:function(data)
                                                        {return data[1];}
                                                    }
                                                ).result(
                                                            function(event,data)
                                                            {
                                                                setChonTaiKhoan(data[2],obj);
                                                               //document.getElementById(obj).blur();
                                                            }
                                                        );           
}

function setChonTaiKhoan(MaTaiKhoan,obj)
{      
      var txtTaiKhoan=document.getElementById(obj);
      txtTaiKhoan.value=MaTaiKhoan;
      document.getElementById(obj).focus();      
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
                        alert("Tài khoản bạn chọn chưa có trong danh mục tài khoản. Vui lòng kiểm tra lại. Cảm ơn!");
                         MaTaiKhoan.value ="";
                      }
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=TestMaTaiKhoan&Key="+MaTaiKhoan.value+"&times="+Math.random(),true);
            xmlHttp.send(null);
    }
}
function ShowKhachHang(obj)
{                        
            var objsrc = document.getElementById(obj);            
            $("#"+obj).unautocomplete().autocomplete("ajax.aspx?do=LoadDanhSachKhachHang&Key="+encodeURIComponent(objsrc.value)+"&obj="+obj,
                                                        {width:700,scroll:true,formatItem:function(data)
                                                            {if(data!="") return data[1]; }
                                                        }
                                                    ).result(
                                                                function(event,data)
                                                                {
                                                                    
                                                                    setChonKhachHang(data[2],data[3],data[4],data[5]);
                                                                    document.getElementById(obj).blur();
                                                                   // document.getElementById('txtTenKH').focus();
                                                                }
                                                            ); 
   
}
function setChonKhachHang(MaKH,TenKH,diachi,nguoilienhe)
{     
      var txtMaKH=document.getElementById('txtMaKH');
      var txtTenKH=document.getElementById('txtTenKH');      
      txtMaKH.value=MaKH;
      txtTenKH.value = TenKH;           
      document.getElementById('txtdiachi').value=diachi;
      document.getElementById('txtNguoiNopTien').value=nguoilienhe;
      document.getElementById('txtTenKH').focus();
      //setTimeout(kiemtramakhach(),10);
}
function CreateTableChiTietPhieuThu()
{
    
    for(i = 0;i<2;i++)
    {
        var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>"
            shtml += "		<td class=\"Column1_TK\" style=\"width:150px\">  <input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\" onchange=\"TestMaTaiKhoan('TaiKhoanCo_"+(lastRow)+"')\" onfocus=\"ShowTaiKhoan('TaiKhoanCo_"+(lastRow)+"')\" style=\"width:100%;text-align:center\"/></td>	";
            shtml +="      <td class=\"Column2_TK\" style=\"width:300px\">    <input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:100%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column3_TK\" style=\"width:200px\"><input type=\"text\" id=\"PhatSinh_"+(lastRow)+"\" onkeyup=\"TestNumberofInput('PhatSinh_"+(lastRow)+"')\" onchange=\"getFormatSoTien('PhatSinh_"+(lastRow)+"')\" style=\"width:100%;text-align:right\" /></td>	";
           
                    
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
  }
}
function ShowChiTietPhieuThu(IDPhieuThuCT,TaiKhoanCo,DienGiai,PhatSinhCo)
{
        
        var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>"
            shtml += "		<td class=\"Column1_TK\" style=\"width:150px\"><input type=\"hidden\" id=\"hdIDPhieuThuCT_"+(lastRow)+"\" value=\""+IDPhieuThuCT+"\"/>  <input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\" value=\""+TaiKhoanCo+"\" onchange=\"TestMaTaiKhoan('TaiKhoanCo_"+(lastRow)+"')\" onfocus=\"ShowTaiKhoan('TaiKhoanCo_"+(lastRow)+"')\" style=\"width:100%;text-align:center\"/></td>	";
            shtml +="      <td class=\"Column2_TK\" style=\"width:300px\">    <input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" value=\""+DienGiai+"\" style=\"width:100%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column3_TK\" style=\"width:200px\"><input type=\"text\" id=\"PhatSinh_"+(lastRow)+"\" value=\""+ FormatSoTien(PhatSinhCo)+"\" onkeyup=\"TestNumberofInput('PhatSinh_"+(lastRow)+"')\" onchange=\"getFormatSoTien('PhatSinh_"+(lastRow)+"')\" style=\"width:100%;text-align:right\" /></td>	";                               
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
 }
function ThemDong()
{
     var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_TK\" style=\"width:150px\"><input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\"   onfocus=\"ShowTaiKhoan('TaiKhoanCo_"+(lastRow)+"')\" style=\"width:100%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column2_TK\" style=\"width:300px\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:100%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column3_TK\" style=\"width:200px\"><input type=\"text\" id=\"PhatSinh_"+(lastRow)+"\" onchange=\"getFormatSoTien('PhatSinh_"+(lastRow)+"')\" onkeyup=\"TestNumberofInput('PhatSinh_"+(lastRow)+"')\"  style=\"width:100%x;text-align:right\" /></td>	";                               
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
}
function ThemDong_phieuthu(tkdoanhthu,diengiai,tongtien)
{
     var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
        var shtml = "<tr class=\"RowGidView\">";
            shtml += "		<td class=\"Column0\" style=\"width:50px;\"><input  type=\"text\" id=\"STT_" + (lastRow) + "\" value=\""+(lastRow-1)+"\" style=\"width:20px ;text-align:center; background-color:#E2EFFF;border-style:none\" readonly=\"readonly\" /></td>";
            shtml += "		<td class=\"Column0\" style=\"width:50px\"><input type=\"checkbox\" id=\"checkbox_" + (lastRow) + "\"/></td>";
            shtml += "		<td class=\"Column1_TK\" style=\"width:150px\"><input type=\"text\" id=\"TaiKhoanCo_"+(lastRow)+"\"   onfocus=\"ShowTaiKhoan('TaiKhoanCo_"+(lastRow)+"')\" style=\"width:100%;text-align:center\"/></td>	";
            shtml +="       <td class=\"Column2_TK\" style=\"width:300px\"><input type=\"text\" id =\"DienGiai_"+(lastRow)+"\" style=\"width:100%;text-align:left\" /></td>";
            shtml += "		<td class=\"Column3_TK\" style=\"width:200px\"><input type=\"text\" id=\"PhatSinh_"+(lastRow)+"\" onchange=\"getFormatSoTien('PhatSinh_"+(lastRow)+"')\" onkeyup=\"TestNumberofInput('PhatSinh_"+(lastRow)+"')\"  style=\"width:100%x;text-align:right\" /></td>	";                               
         shtml += "	</tr>";
      $("#TableDanhSach:last").append(shtml);
      document.getElementById('TableDanhSach').rows[lastRow].cells[2].getElementsByTagName("input")[0].value=tkdoanhthu;
      document.getElementById('TableDanhSach').rows[lastRow].cells[3].getElementsByTagName("input")[0].value=diengiai;
      document.getElementById('TableDanhSach').rows[lastRow].cells[4].getElementsByTagName("input")[0].value=tongtien;
}
function XoaDong()
{
     var TableDanhSach = document.getElementById('TableDanhSach');
        var lastRow = TableDanhSach.rows.length; 
      
        if(lastRow>2)
        {
                for(var i=2;i<lastRow;i++)
                {
                     var idCheckBox = "checkbox_"+i;
                     var checkbox = document.getElementById(idCheckBox);
                    if(checkbox.checked)
                    {                       
                        TableDanhSach.deleteRow(i);
                        UpdateRowOfTable();
                        XoaDong();
                          break;
                    }                  
                }
                // UpdateRowOfTable();                               
        }       
}
function UpdateRowOfTable()
{
      var TableDanhSach = document.getElementById('TableDanhSach');
      var lastRow = TableDanhSach.rows.length; 
      if(lastRow>2)
      {
        for(var i=2;i<lastRow;i++)
        {        
             TableDanhSach.rows[i].cells[0].getElementsByTagName("input")[0].id = "STT_"+i;
             TableDanhSach.rows[i].cells[0].getElementsByTagName("input")[0].value = i-1;
             TableDanhSach.rows[i].cells[1].getElementsByTagName("input")[0].id = "checkbox_"+i;
             TableDanhSach.rows[i].cells[2].getElementsByTagName("input")[0].id = "TaiKhoanCo_"+i;
             TableDanhSach.rows[i].cells[3].getElementsByTagName("input")[0].id = "DienGiai_"+i;
             TableDanhSach.rows[i].cells[4].getElementsByTagName("input")[0].id = "PhatSinh_"+i;
             
        }
      }
        TinhTongTien();
}

//================================================================================================================
 var TongTien = 0;
function CongTongTien(ThanhTien)
{
    var count = TongTien;
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = FormatSoTien(TongTien);
     
}
function TinhTongTien()
{
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
   var Tien = 0;
    var x;
    //var lastRow= Row-2;
    if(Row>2)
    {
        for(var i=2;i<Row;i++)
        {            
            var count = Tien;
            var txtSoTien = "PhatSinh_"+i;
            var sotien =  document.getElementById(txtSoTien);
            if(sotien.value!="")
            {
                Tien =  eval(count) + (eval(ChangeFormatCurrency(sotien.value)));
            }    
        }
     }     
    var txtTongTien = document.getElementById('TongTien');
    txtTongTien.value = FormatSoTien(Tien);     
}
//================================================Lưu phiếu thu hóa đơn===========================================
function LuuPhieuThuKhac(nguoithubd,ngaythubd,Ctr)
{
      Ctr.disabled = true;
      document.getElementById('message').style.visibility = "visible";
  var PhieuThuID = document.getElementById('hdPhieuThuID').value;
  var SoPT = document.getElementById('txtMaPT').value;
  var NgayThu = document.getElementById('txtNgayLapPhieuThu').value;
  var MaKH = document.getElementById('txtMaKH').value;
  var TenKH = document.getElementById('txtTenKH').value;
  var NguoiNop = document.getElementById('txtNguoiNopTien').value;
  var DienGiai = document.getElementById('txtDienGiai').value;
  var TKNo = document.getElementById('txtTaiKhoanNo').value;
  var Tien = document.getElementById('TongTien').value;
  var UserDau ='Tăng Thúy Ngọc';
  var UserCuoi='Cyber Tang'
  var soctgoc=document.getElementById('txtsoctgoc').value;
  var chungtugoc=document.getElementById('txtchungtugoc').value;
  var Status='0';
  if(SoPT=="")
  {
    alert("Chưa nhập số phiếu thu. Vui lòng kiểm tra lại, cảm ơn!");
  }
  else
  if(NgayThu=="")
  {
    alert("Chưa chọn ngày lập phiếu thu. Vui lòng kiểm tra lại, cảm ơn!");
    Ctr.disabled = false;
      document.getElementById('message').style.visibility = "hidden";
  } 
  else
  if(TKNo=="")
  {
    alert("Chưa chọn tài khoản nợ. Vui lòng kiểm tra lại, cảm ơn!");
    Ctr.disabled = false;
      document.getElementById('message').style.visibility = "hidden";
  }
  else
  if(Tien=="")
  {
    alert("Chưa tính tổng tiền cho phiếu thu. Vui lòng kiểm tra lại, cảm ơn!");
    Ctr.disabled = false;
      document.getElementById('message').style.visibility = "hidden";
  }
  else
    GetFunctionLuuPTKhac(Ctr,PhieuThuID,SoPT,NgayThu,MaKH,TenKH,NguoiNop,DienGiai,TKNo,Tien,soctgoc,chungtugoc,UserDau,UserCuoi,Status,nguoithubd,ngaythubd)  
}

function GetFunctionLuuPTKhac(Ctr,PhieuThuID,SoPT,NgayThu,MaKH,TenKH,NguoiNop,DienGiai,TKNo,Tien,soctgoc,chungtugoc,UserDau,UserCuoi,Status,nguoithubd,ngaythubd)
{
        xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;                
                  if (value==1)
                  {                     
                    XoaChiTietPhieuThu(Ctr,SoPT);
                  }
            }
        }
         // xmlHttp.open("GET","ajax.aspx?do=LuuPhieuThuHoaDon&SoPT="+SoPT+"&NgayThu="+NgayThu+"&MaKH="+MaKH+"&NguoiNop="+encodeURIComponent(NguoiNop)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+TKNo+"&Tien="+ChangeFormatCurrency(Tien)+"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+encodeURIComponent(UserCuoi)+"&Status="+Status+"&times="+Math.random(),true);
          xmlHttp.open("GET","ajax.aspx?do=LuuPhieuThu&PhieuThuID="+PhieuThuID+"&SoPT="+SoPT+"&NgayThu="+NgayThu+"&MaKH="+MaKH+"&NguoiNop="+encodeURIComponent(NguoiNop)+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+ TKNo+"&Tien="+ChangeFormatCurrency(Tien)+"&soctgoc="+soctgoc+"&chungtugoc="+encodeURIComponent(chungtugoc)+"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+encodeURIComponent(UserCuoi)+"&Status="+Status+"&nguoithubd="+encodeURIComponent(nguoithubd)+"&ngaythubd="+ngaythubd+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
//================================================================================================================
//=======================================Lưu chi tiết phiếu thu===================================================
function XoaChiTietPhieuThu(Ctr,SoPT)
{   
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                XoaSoCai(Ctr,SoPT);                 
            }
        }         
          xmlHttp.open("GET","ajax.aspx?do=XoaChiTietPhieuThu&SoPT="+SoPT+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
function XoaSoCai(Ctr,SoPT)
{
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;                
                 LuuChiTietPhieuThuKhac(Ctr);                 
            }
        }         
          xmlHttp.open("GET","ajax.aspx?do=XoaSoCaiBySoPT&SoPT="+SoPT+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
function XoaPhieuThu(SoPhieuThu)
{
    xmlHttp = GetMSXmlHttp();
            xmlHttp.onreadystatechange = function()
            {
                if(xmlHttp.readyState == 4)
                {
                    var value = xmlHttp.responseText;
                      if (value=="1")
                      {                         
                      }                      
                }
            }
              xmlHttp.open("GET","ajax.aspx?do=XoaPhieuThu_fault&SoPhieuThu="+SoPhieuThu+"&times="+Math.random(),false);
            xmlHttp.send(null);
}
function LuuChiTietPhieuThuKhac(Ctr)
{    
    var TableDanhSach = document.getElementById('TableDanhSach');
    var Row = TableDanhSach.rows.length;
    var x;
    var rs = 1;
    var SoPT = document.getElementById('txtMaPT').value;
     var valueTaiKhoanCo ="";
     var valueDienGiai ="";
      var valuePhatSinhCo ="";
      var flag = false;
    if(Row>2)
    {
        for(var i=2;i<Row;i++)
        {
        //null,sophieuthu,tkco,psco,null,soHD,NgaylapHD,tientrenHD,null,null,null,diengiai,0
         
                  var idTaiKhoanCo= "TaiKhoanCo_"+i;//(Row-2);
                  var idPhatSinhCo = "PhatSinh_"+i;//(Row-2);
                  var idDienGiai = "DienGiai_"+i;//(Row-2);
                if(document.getElementById(idTaiKhoanCo).value=="")
                {
                    alert("Chưa có Mã tài khoản. Vui lòng kiểm tra lại.Vui lòng xóa dòng trống nếu không dùng Cảm ơn!");
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    flag= false;
                }
                else
                if(document.getElementById(idPhatSinhCo).value=="")           
                {
                    alert("Chưa có số tiền phát sinh. Vui lòng kiểm tra lại.Vui lòng xóa dòng trống nếu không dùng Cảm ơn!");
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    flag= false;
                }
             
                else
                 {  
                    flag= true;
                       valueTaiKhoanCo +=";"+ document.getElementById(idTaiKhoanCo).value;
                       valueDienGiai +=";"+ document.getElementById(idDienGiai).value;
                       
                        var PSCo = document.getElementById(idPhatSinhCo).value;
                        valuePhatSinhCo +=";"+ ChangeFormatCurrency(PSCo);
                
                }
            
        }
        if(flag)
        {
            getFunctionLuuCTPTKhac(Ctr,SoPT,valueTaiKhoanCo,valueDienGiai,valuePhatSinhCo);
        }
        else
        {
            alert("Chưa có chi tiết phiếu thu. Vui lòng kiểm tra lại.Vui lòng xóa dòng trống nếu không dùng Cảm ơn!");
            Ctr.disabled = false;
            document.getElementById('message').style.visibility = "hidden";
            XoaPhieuThu(SoPT);
        }
  
     }
     else
     {
        alert("Chưa có chi tiết phiếu thu. Vui lòng kiểm tra lại.Vui lòng xóa dòng trống nếu không dùng Cảm ơn!");
            Ctr.disabled = false;
            document.getElementById('message').style.visibility = "hidden";
            XoaPhieuThu(SoPT);
     }     
}
function getFunctionLuuCTPTKhac(Ctr,SoPT,TKCo,DienGiai,PhatSinhCo)
{
    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="1")
                    LuuSoCai(Ctr,DienGiai,TKCo,PhatSinhCo);
                else
                {
                    alert("Lưu chi tiết phiếu thu thất bại. Vui lòng kiểm tra lại.Vui lòng xóa dòng trống nếu không dùng Cảm ơn!");
                    Ctr.disabled = false;
                    document.getElementById('message').style.visibility = "hidden";
                    XoaPhieuThu(SoPT);
                }
            }
        }        
          xmlHttp.open("GET","ajax.aspx?do=LuuChiTietPhieuThuKhac&SoPT="+SoPT+"&TKCo="+TKCo+"&DienGiai="+encodeURIComponent(DienGiai)+"&PhatSinhCo="+PhatSinhCo+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
function LuuSoCai(Ctr,DienGiai,TKCo,PSCo)
{
      var SoPT = document.getElementById('txtMaPT').value;
      var NgayThu = document.getElementById('txtNgayLapPhieuThu').value;
      var MaKH = document.getElementById('txtMaKH').value;
      var dien_giai=document.getElementById('txtDienGiai').value;
      var TKNo = document.getElementById('txtTaiKhoanNo').value;
      var UserDau = "Tăng Thúy Ngọc";
      var UserCuoi = "CyberTang";
       xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                if(value=="1")
                {
                    alert("Lưu phiếu thu khác thành công");
                    Ctr.value = "Sửa";
                     //ResetTableDSPhieuThu(SoPT);
                     //getChiTietPhieuThuKhac(SoPT);
                    document.getElementById('bt_Luu').value ="Sửa";
                }
                else
                 {   alert("Lưu phiếu thu khác thất bại");
                     XoaPhieuThu(Ctr);
                 }
                Ctr.disabled = false;
                document.getElementById('message').style.visibility = "hidden";
            }
        }        
        xmlHttp.open("GET","ajax.aspx?do=LuuSoCai_PhieuThuKhac&SoPT="+SoPT+"&NgayThu="+NgayThu+"&MaKH="+MaKH+"&DienGiai="+encodeURIComponent(DienGiai)+"&TKNo="+TKNo+"&TKCo="+TKCo+"&PSCo="+PSCo+"&UserDau="+encodeURIComponent(UserDau)+"&UserCuoi="+encodeURIComponent(UserCuoi)+"&times="+Math.random(),false);
        xmlHttp.send(null);  
}
//================================================================================================================

//=======================================================================================================================================
//============================================Load phiếu thu và chi tiet phieu tu ben danh sách phieu thu chuyển qua=====================
//=======================================================================================================================================
function DanhSachPhieuThuOfKhachHang(idPhieuThu)
{
    xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value!="")
                  {  
                    //alert(value);
                    var Row = value.split('|');
                    for(i=1;i<Row.length;i++)
                    {
                        var Column = Row[i].split('&');
                        //phieu_thu_id;so_phieu_thu;ngay_thu;ma_kh;tenkhachhang;nguoi_nop;dien_giai;tk_no;tien
                        LoadPhieuThuKhac(Column[0],Column[1],Column[2],Column[3],Column[4],Column[5],Column[6],Column[7],Column[8],Column[9],Column[10],Column[11]);
                        
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=DanhSachPhieuThuOfKhachHang&idPhieuThu="+idPhieuThu+"&times="+Math.random(),true);
        xmlHttp.send(null);
}

function LoadPhieuThuKhac(idPhieuThu,SoPT,NgayLapPT,MaKH,TenKH,NguoiNop,DienGiai,TaiKhoanNo,TongTien,soctgoc,chungtugoc,diachi)
{
    
  ResetTableDSPhieuThu(); 
  document.getElementById('hdPhieuThuID').value = idPhieuThu;
  document.getElementById('txtMaPT').value = SoPT;
  document.getElementById('txtNgayLapPhieuThu').value = NgayLapPT;
  document.getElementById('txtMaKH').value = MaKH;
  document.getElementById('txtTenKH').value = TenKH;
  document.getElementById('txtdiachi').value = diachi;
  document.getElementById('txtNguoiNopTien').value = NguoiNop;
  document.getElementById('txtDienGiai').value = DienGiai;
  document.getElementById('txtTaiKhoanNo').value = TaiKhoanNo;
  document.getElementById('TongTien').value = FormatSoTien(TongTien);
  document.getElementById('txtsoctgoc').value = soctgoc;
  document.getElementById('txtchungtugoc').value = chungtugoc;
  
   if(document.getElementById('bt_Luu').value =="Lưu")
    {
        document.getElementById('bt_Luu').value = "Sửa";        
    }  
  getChiTietPhieuThuKhac(SoPT);  
}
function getChiTietPhieuThuKhac(SoPT)
{
     xmlHttp = GetMSXmlHttp();
        xmlHttp.onreadystatechange = function()
        {
            if(xmlHttp.readyState == 4)
            {
                var value = xmlHttp.responseText;
                  if (value!="")
                  {  
                    //alert(value);
                    var Row = value.split('|');                  
                    for(i=1;i<Row.length;i++)
                    {
                        var Column = Row[i].split('&');
                        //phieu_thu_ct_id(0),tk_co(1),dien_giai(2),tongtien(3) (du lieu tra ve)
                        ShowChiTietPhieuThu(Column[0],Column[1],Column[2],Column[3]);
                    }                    
                  }
            }
        }
          xmlHttp.open("GET","ajax.aspx?do=ChiTietPhieuThuKhac&SoPT="+SoPT+"&times="+Math.random(),false);
        xmlHttp.send(null);
}
//ham kiem tra ma khach hang da co hay chua
function kiemtramakhach()
{
    var tenbang="khachhang";
    var tenfield="makhachhang";    
    var dieukien=document.getElementById('txtMaKH').value;  
    var kq;  
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {               
            var value=xmlHttp.responseText;            
            //document.getElementById('txtTenKH').focus(); 
            xacnhan(value);
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien+"&times="+Math.random(),false);
    xmlHttp.send(null);
}
function xacnhan(kq)
{
    if (kq==0)
    {
        if (confirm('Mã khách hàng này chưa có!Bạn muốn thêm mới không?'))
            {                    
              document.getElementById('txtTenKH').focus();                               
            }           
        else
            document.getElementById('txtNguoiNopTien').focus();            
     }
}

function InPhieuThuKhac()
{
    var SoPhieuThu = document.getElementById('txtMaPT').value;
    var NgayThu = document.getElementById('txtNgayLapPhieuThu').value;
    var soctgoc=document.getElementById('txtsoctgoc').value;
    var chungtugoc=document.getElementById('txtchungtugoc').value;
    if(NgayThu=="")
    {
        alert("Chưa có ngày lập phiếu thu. Vui lòng kiểm tra lại. Cảm ơn!");
    }
    else
    {
        window.open("KTTM_rptPhieuThu.aspx?so_phieu_thu=" + SoPhieuThu + "&ngay_thu=" + NgayThu+"&soctgoc="+soctgoc+"&chungtugoc="+chungtugoc);
    }
}
function ngaylapphieu()
{
    dinhdangngay(document.getElementById('txtNgayLapPhieuThu'));
}
function themkhachhang()
{
    var makhach=document.getElementById('txtMaKH').value;
    var tenkh=document.getElementById('txtTenKH').value;
    var diachi=document.getElementById('txtdiachi').value;
    var nguoinoptien=document.getElementById('txtNguoiNopTien').value;
    xmlHttp=GetMSXmlHttp();
    xmlHttp.open("GET","ajax.aspx?do=themkhachhang&makh="+makhach+"&tenkh="+encodeURIComponent(tenkh)+"&diachi="+encodeURIComponent(diachi)+"&nguoinoptien="+nguoinoptien+"&times="+Math.random(),true);
    xmlHttp.send(null);
}
function kiemtramaphieuthu()
{
    var tenbang="phieu_thu";
    var tenfield="so_phieu_thu";
    var dieukien=document.getElementById('txtMaPT').value;       
    xmlHttp=GetMSXmlHttp();
    xmlHttp.onreadystatechange=function()
    {
        if(xmlHttp.readyState==4)
        {            
            var value=xmlHttp.responseText;
            if (value==1)
            {
                alert('Số phiếu thu này đã có, xin nhập lại số khác!');
                document.getElementById('txtMaPT').focus();
            }            
        }
    }
    xmlHttp.open("GET","ajax.aspx?do=kiemtrathongtinTable&tenbang="+tenbang+"&tenfield="+tenfield+"&dieukien="+dieukien,"&times="+Math.random(),true);
    xmlHttp.send(null);
    
}
function copynoidung()
{
    var ngaylapphieu=document.getElementById('txtNgayLapPhieuThu').value;
    var makh=document.getElementById('txtMaKH').value;
    var tenkh=document.getElementById('txtTenKH').value;    
    var nguoimua=document.getElementById('txtNguoiNopTien').value;
    var diachi=document.getElementById('txtdiachi').value;
    var tkno=document.getElementById('txtTaiKhoanNo').value;    
    var diengiai=document.getElementById('txtDienGiai').value;
    ResetDataonTable();       
    document.getElementById('txtMaPT').value='PT-';
    document.getElementById('txtNgayLapPhieuThu').value=ngaylapphieu;    
    document.getElementById('txtMaKH').value=makh;    
    document.getElementById('txtTenKH').value=tenkh;    
    document.getElementById('txtNguoiNopTien').value=nguoimua;
    document.getElementById('txtdiachi').value=diachi;
    document.getElementById('txtTaiKhoanNo').value=tkno;    
    document.getElementById('txtMaPT').focus();
    document.getElementById('txtDienGiai').value = diengiai;
    alert('Copy nội dung thành công');
}
//================================================================================================================
</script>
<form id="form1" runat="server">
<table cellpadding = "0" cellspacing = "0" border = "0" width = "100%" style ="background-color: #C0C0C0">
    <tr>
        <td width = "100%" align = "left" style="height: 34px;background-color:#007138">
            <uc1:menu_ketoantienmat ID="menu_ketoantienmat1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">&nbsp;</td>
    </tr>
    <tr>
        <td width = "100%" align = "left" style ="background-color:#D4D0C8">
            <table border="0" cellpadding="1" cellspacing="1" width="100%" id="user">
                <tr style="height:10px">
                    <td><div  class = "tdHeader">PHIẾU THU KHÁC</div></td>
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
                                                            <td class="tdLabel">Mã phiếu thu : </td>
                                                            <td class="tdText"><input  id="txtMaPT"  type="text" focus="kiemtramaphieuthu()" class="InputText" /><input type="hidden" id="hdPhieuThuID" /></td>
                                                            
                                                            <td class="tdLabel" >Ngày lập PT:</td>
                                                            <td  class="tdCalenda" ><input id="txtNgayLapPhieuThu" runat="server" style="width:100px;" onblur="ngaylapphieu();"  type="text"/>&nbsp(dd/mm/yy)</td>
                                                           
                                                           <td class="tdLabel">Mã khách hàng : </td>
                                                            <td class="tdText"><input id="txtMaKH"  type="text" onfocus="ShowKhachHang('txtMaKH');" onblur="kiemtramakhach();" class="InputText"/></td>

                                                        </tr>
                                                        <tr>                                                                                                                        
                                                            <td class="tdLabel">Tên khách hàng : </td>
                                                            <td  class="tdText"><input id="txtTenKH" type="text"  onfocus="ShowKhachHang('txtTenKH')" class="InputText" /></td>
                                                            
                                                             <td class="tdLabel"> Địa chỉ : </td>
                                                            <td  class="tdText"><input id="txtdiachi" type="text" class="InputText" /><input type="hidden" id="hd_idBenhNhan" /></td>                                                           
                                                            
                                                            <td class="tdLabel"> Người nộp tiền : </td>
                                                            <td  class="tdText"><input id="txtNguoiNopTien" type="text" class="InputText" /></td>

                                                        </tr>
                                                                                                       
                                                        <tr>
                                                            <td class="tdLabel">Tài khoản nợ: </td>
                                                            <td  class="tdText"><input id="txtTaiKhoanNo" type="text" class="InputText" onchange="TestMaTaiKhoan('txtTaiKhoanNo')" onfocus="ShowTaiKhoan('txtTaiKhoanNo')"  /></td>                                                                                                                       
                                                            
                                                            <td class="tdLabel"> Số CT gốc : </td>
                                                            <td  class="tdText"><input id="txtsoctgoc" style="width:50px" type="text" class="InputText" /></td>                                                           

                                                            <td class="tdLabel"> Chứng từ gốc : </td>
                                                            <td  class="tdText"><input id="txtchungtugoc" type="text" class="InputText" /></td>   
                                                        </tr>                                                        
                                                        
                                                        <tr>
                                                            <td class="tdLabel">Diễn giải : </td>
                                                            <td colspan="6"  class="tdText">
                                                                <textarea id="txtDienGiai" style="width:570px" cols="20"  rows="2"></textarea></td>
                                                            
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="6" style="text-align:center">                                                                                                                               
                                                                <input type="button" value="Lưu" id="bt_Luu" style="width:100px" />
                                                                <input type="button" value="Tạo mới"  style="width:100px" onclick="ResetDataonTable();" id="bt_Reset" />
                                                                <input type="button" value="IN"  style="width:100px" id="bt_in" onclick="InPhieuThuKhac()" />
                                                                <input type="button" value="Copy"  style="width:100px" id="Button1" onclick="copynoidung()" />                                                                
                                                            </td>
                                                        </tr>
                                                           <tr>
                                                            <td colspan="9" style="text-align:center">
                                                                <label id="message"  style="display:none" > Đang xử lý vui lòng chờ trong giây lát....</label>
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
     
     <div style="text-align:center;background-color:Silver">
<table class="TableGidview" style="width:800px" id="TableDanhSach">
         <tr>
              <td class ="tdHeader" colspan="5"> Chi tiết phiếu thu khác</td>
         </tr>
		<tr class="HeaderGidView" style="width:100%">
		     <td class="HeaderColumn0_TK" style="width:50px">STT</td>
		     <td class="HeaderColumn0_TK" style="width:50px">Xóa</td>
		     <td class="HeaderColumn1_TK" style="width:150px">
		    Tài khoản có
		     </td>		     
		     <td class="HeaderColumn2_TK" style="width:300px">
		       Diễn giải
		       
		    </td>
		    <td class="HeaderColumn3_TK" style="width:200px">
		        Phát sinh có
		    </td>
		    	    
		</tr>					 	  						 
	</table>    
	     
    <div class ="tdHeader"  style="width:800px; font-size:14px;text-align:right">Tổng tiền : <input type="text" style="width:200px; text-align:right" readonly="readonly" id="TongTien" onclick="TinhTongTien()"/></div>      
</div>
<div style="padding-left:220px"><input type="button"   id="bt_ThemDong" value="Thêm dòng" onclick="ThemDong()"/><input type="button" id="bt_XoaDong" value="Xóa dòng" onclick="XoaDong()" /></div>

</form>
<!--#include file ="footer.htm"-->